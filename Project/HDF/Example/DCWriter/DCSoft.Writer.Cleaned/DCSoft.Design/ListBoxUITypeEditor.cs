using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace DCSoft.Design
{
	/// <summary>
	///       使用下来列表控件的数值编辑器
	///       </summary>
	[ComVisible(false)]
	public class ListBoxUITypeEditor : UITypeEditor
	{
		private IWindowsFormsEditorService _Service = null;

		private bool _Modified = false;

		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.DropDown;
		}

		protected virtual ListBox CreateListBox(ITypeDescriptorContext context, IServiceProvider provider, object currentValue)
		{
			return new ListBox();
		}

		protected Size GetPreferSize(ListBox listBox_0)
		{
			int num = 50;
			int num2 = 0;
			using (Graphics graphics = listBox_0.CreateGraphics())
			{
				using (StringFormat stringFormat = new StringFormat())
				{
					stringFormat.FormatFlags = StringFormatFlags.NoWrap;
					for (int i = 0; i < listBox_0.Items.Count; i++)
					{
						if (listBox_0.DrawMode == DrawMode.Normal)
						{
							string itemText = listBox_0.GetItemText(listBox_0.Items[i]);
							num2 += listBox_0.GetItemHeight(i);
							if (!string.IsNullOrEmpty(itemText))
							{
								num = (int)Math.Max(num, graphics.MeasureString(itemText, listBox_0.Font, 10000, stringFormat).Width);
							}
						}
						else
						{
							Rectangle itemRectangle = listBox_0.GetItemRectangle(i);
							num2 += itemRectangle.Height;
							num = Math.Max(num, itemRectangle.Width);
						}
					}
				}
			}
			num += 10;
			num2 += 10;
			if ((double)num2 > (double)Screen.PrimaryScreen.WorkingArea.Height * 0.4)
			{
				num2 = (int)((double)Screen.PrimaryScreen.WorkingArea.Height * 0.4);
			}
			if ((double)num > (double)Screen.PrimaryScreen.WorkingArea.Width * 0.3)
			{
				num = (int)((double)Screen.PrimaryScreen.WorkingArea.Width * 0.3);
			}
			return new Size(num, num2);
		}

		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			_Modified = false;
			_Service = null;
			ListBox listBox = CreateListBox(context, provider, value);
			if (listBox != null)
			{
				using (listBox)
				{
					_Service = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
					listBox.Click += ctl_Click;
					listBox.KeyDown += ctl_KeyDown;
					listBox.Tag = this;
					_Service.DropDownControl(listBox);
					if (_Modified)
					{
						object selectedItem = listBox.SelectedItem;
						if (selectedItem != null && context.PropertyDescriptor.PropertyType.IsInstanceOfType(selectedItem))
						{
							return selectedItem;
						}
						if (context.PropertyDescriptor.PropertyType.Equals(typeof(string)))
						{
							return listBox.Text;
						}
						return selectedItem;
					}
				}
			}
			return value;
		}

		private void ctl_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				_Modified = true;
				_Service.CloseDropDown();
			}
			else if (e.KeyCode == Keys.Escape)
			{
				_Modified = false;
				_Service.CloseDropDown();
			}
		}

		private void ctl_Click(object sender, EventArgs e)
		{
			_Modified = true;
			_Service.CloseDropDown();
		}
	}
}
