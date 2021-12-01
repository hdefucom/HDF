using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public abstract class GClass9
	{
		private ListControl listControl_0 = null;

		private object object_0 = null;

		private ITypeDescriptorContext itypeDescriptorContext_0 = null;

		public ListControl method_0()
		{
			return listControl_0;
		}

		public void method_1(ListControl listControl_1)
		{
			listControl_0 = listControl_1;
			if (listControl_1 is ComboBox)
			{
				ComboBox comboBox = (ComboBox)listControl_1;
				if (vmethod_2().Height > 0)
				{
					comboBox.DrawMode = DrawMode.OwnerDrawVariable;
					comboBox.DrawItem += vmethod_0;
					comboBox.ItemHeight = vmethod_2().Height;
				}
				else
				{
					comboBox.DrawMode = DrawMode.Normal;
				}
				IEnumerable enumerable = vmethod_3();
				if (enumerable != null)
				{
					foreach (object item in enumerable)
					{
						comboBox.Items.Add(item);
					}
				}
			}
			else if (listControl_1 is ListBox)
			{
				ListBox listBox = (ListBox)listControl_1;
				if (vmethod_2().Height > 0)
				{
					listBox.DrawMode = DrawMode.OwnerDrawVariable;
					listBox.ItemHeight = vmethod_2().Height + 5;
					listBox.MeasureItem += vmethod_1;
					listBox.DrawItem += vmethod_0;
				}
				else
				{
					listBox.DrawMode = DrawMode.Normal;
				}
				IEnumerable enumerable = vmethod_3();
				if (enumerable != null)
				{
					foreach (object item2 in enumerable)
					{
						listBox.Items.Add(item2);
					}
				}
			}
		}

		public void method_2()
		{
			if (listControl_0 is ComboBox)
			{
				ComboBox comboBox = (ComboBox)listControl_0;
				comboBox.Items.Clear();
				IEnumerable enumerable = vmethod_3();
				if (enumerable != null)
				{
					foreach (object item in enumerable)
					{
						comboBox.Items.Add(item);
					}
				}
			}
			else if (listControl_0 is ListBox)
			{
				ListBox listBox = (ListBox)listControl_0;
				listBox.Items.Clear();
				IEnumerable enumerable = vmethod_3();
				if (enumerable != null)
				{
					foreach (object item2 in enumerable)
					{
						listBox.Items.Add(item2);
					}
				}
			}
		}

		public object method_3()
		{
			return object_0;
		}

		public void method_4(object object_1)
		{
			object_0 = object_1;
		}

		public ITypeDescriptorContext method_5()
		{
			return itypeDescriptorContext_0;
		}

		public void method_6(ITypeDescriptorContext itypeDescriptorContext_1)
		{
			itypeDescriptorContext_0 = itypeDescriptorContext_1;
		}

		protected virtual void vmethod_0(object sender, DrawItemEventArgs e)
		{
			object object_ = null;
			if (listControl_0 is ListBox)
			{
				object_ = ((ListBox)listControl_0).Items[e.Index];
			}
			else if (listControl_0 is ComboBox)
			{
				object_ = ((ComboBox)listControl_0).Items[e.Index];
			}
			e.DrawBackground();
			Size size = vmethod_2();
			Rectangle rectangle = new Rectangle(e.Bounds.Left, e.Bounds.Top, 0, e.Bounds.Height);
			if (size.Width > 0 && size.Height > 0)
			{
				rectangle = new Rectangle(e.Bounds.Left + 2, e.Bounds.Top + (e.Bounds.Height - vmethod_2().Height) / 2, size.Width, size.Height);
				rectangle.Height = e.Bounds.Bottom - rectangle.Top - 1;
				vmethod_4(e.Graphics, rectangle, object_);
				e.Graphics.DrawRectangle(Pens.Black, rectangle);
			}
			string text = vmethod_6(object_);
			if (text != null)
			{
				using (SolidBrush brush = new SolidBrush(e.ForeColor))
				{
					using (StringFormat stringFormat = new StringFormat())
					{
						stringFormat.Alignment = StringAlignment.Near;
						stringFormat.LineAlignment = StringAlignment.Center;
						stringFormat.FormatFlags = StringFormatFlags.NoWrap;
						e.Graphics.DrawString(text, e.Font, brush, new RectangleF(rectangle.Right + 3, e.Bounds.Top, e.Bounds.Width - rectangle.Right - 3, e.Bounds.Height), stringFormat);
					}
				}
			}
		}

		protected virtual void vmethod_1(object sender, MeasureItemEventArgs e)
		{
			Size size = vmethod_2();
			if (size.Height > 0)
			{
				e.ItemHeight = size.Height + 5;
			}
			else
			{
				e.ItemHeight = 1 + (int)Math.Ceiling(listControl_0.Font.GetHeight(e.Graphics));
			}
		}

		public virtual Size vmethod_2()
		{
			return Size.Empty;
		}

		public virtual IEnumerable vmethod_3()
		{
			return null;
		}

		public virtual void vmethod_4(Graphics graphics_0, Rectangle rectangle_0, object object_1)
		{
		}

		public virtual object vmethod_5(object object_1)
		{
			return object_1;
		}

		public virtual string vmethod_6(object object_1)
		{
			if (object_1 == null)
			{
				return "";
			}
			return Convert.ToString(object_1);
		}
	}
}
