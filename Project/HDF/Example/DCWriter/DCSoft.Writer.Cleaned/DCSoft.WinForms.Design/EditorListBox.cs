using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace DCSoft.WinForms.Design
{
	/// <summary>
	///       在属性列表中弹出的列表控件，编写袁永福
	///       </summary>
	[ToolboxItem(false)]
	[ComVisible(false)]
	public class EditorListBox : ListBox
	{
		/// <summary>
		///       内置的列表项目类型
		///       </summary>
		private class ListItem
		{
			public string Value = null;

			public string Description = null;

			public string DisplayText = null;

			/// <summary>
			///       返回项目文本
			///       </summary>
			/// <returns>项目文本</returns>
			public override string ToString()
			{
				return DisplayText;
			}
		}

		private bool bolIgnoreCase = false;

		private IWindowsFormsEditorService mySvc = null;

		private bool bolModified = false;

		/// <summary>
		///       设置当前项目时是否考虑大小写
		///       </summary>
		public bool IgnoreCase
		{
			get
			{
				return bolIgnoreCase;
			}
			set
			{
				bolIgnoreCase = value;
			}
		}

		/// <summary>
		///       向控件添加列表项目
		///       </summary>
		/// <param name="Value">列表项目数值</param>
		/// <param name="Desc">列表项目说明</param>
		public void AddItem(string Value, string Desc)
		{
			ListItem listItem = new ListItem();
			listItem.Value = Value;
			listItem.Description = Desc;
			base.Items.Add(listItem);
		}

		public void AddRange(IEnumerable items)
		{
			foreach (string item in items)
			{
				AddItem(item, null);
			}
		}

		/// <summary>
		///       弹出列表控件供用户选择输入
		///       </summary>
		/// <param name="svc">设计环境服务对象</param>
		/// <param name="selectedValue">初始化选择的项目值</param>
		/// <returns>用户选择输入的列表项目值，若没有选择则返回空引用</returns>
		public string Popup(IWindowsFormsEditorService iwindowsFormsEditorService_0, string selectedValue)
		{
			int num = 10;
			Encoding encoding = Encoding.GetEncoding(936);
			foreach (ListItem item in base.Items)
			{
				if (item.Value != null)
				{
					int byteCount = encoding.GetByteCount(item.Value);
					if (byteCount > num)
					{
						num = byteCount;
					}
				}
			}
			num += 2;
			foreach (ListItem item2 in base.Items)
			{
				if (item2.Value != null)
				{
					int byteCount = encoding.GetByteCount(item2.Value);
					if (byteCount < num)
					{
						item2.DisplayText = item2.Value + new string(' ', num - byteCount) + item2.Description;
					}
				}
			}
			foreach (ListItem item3 in base.Items)
			{
				if (string.Compare(selectedValue, item3.Value, IgnoreCase) == 0)
				{
					base.SelectedItem = item3;
					break;
				}
			}
			int num2 = 0;
			using (Graphics graphics = CreateGraphics())
			{
				foreach (object item4 in base.Items)
				{
					string itemText = GetItemText(item4);
					if (itemText != null && itemText.Length > 0)
					{
						SizeF sizeF = graphics.MeasureString(itemText, Font, 10000, StringFormat.GenericDefault);
						if ((float)num2 < sizeF.Width)
						{
							num2 = (int)sizeF.Width;
						}
					}
				}
			}
			Size preferredSize = base.PreferredSize;
			preferredSize.Width = num2;
			preferredSize.Height = base.PreferredHeight;
			if (preferredSize.Height > 300)
			{
				preferredSize.Height = 300;
			}
			base.ClientSize = preferredSize;
			mySvc = iwindowsFormsEditorService_0;
			object selectedItem = base.SelectedItem;
			bolModified = false;
			iwindowsFormsEditorService_0.DropDownControl(this);
			mySvc = null;
			ListItem listItem2 = (ListItem)base.SelectedItem;
			if (listItem2 != null)
			{
				if (bolModified)
				{
					return listItem2.Value;
				}
				if (listItem2 != selectedItem)
				{
					return listItem2.Value;
				}
			}
			return null;
		}

		protected override void OnSelectedIndexChanged(EventArgs eventArgs_0)
		{
			base.OnSelectedIndexChanged(eventArgs_0);
			bolModified = true;
		}

		/// <summary>
		///       用户点击控件事件处理，关闭列表项目控件
		///       </summary>
		/// <param name="e">事件参数</param>
		protected override void OnClick(EventArgs eventArgs_0)
		{
			base.OnClick(eventArgs_0);
			if (mySvc != null)
			{
				mySvc.CloseDropDown();
			}
		}
	}
}
