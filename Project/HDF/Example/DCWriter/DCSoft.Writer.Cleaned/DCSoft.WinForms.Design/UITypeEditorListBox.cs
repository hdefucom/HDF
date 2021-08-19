using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace DCSoft.WinForms.Design
{
	[ToolboxItem(false)]
	[ComVisible(false)]
	public class UITypeEditorListBox : ListBox
	{
		private bool bolModified = false;

		private IWindowsFormsEditorService myEditorService;

		/// <summary>
		///       列表选择状态是否改变
		///       </summary>
		public bool Modified
		{
			get
			{
				return bolModified;
			}
			set
			{
				bolModified = value;
			}
		}

		/// <summary>
		///       设计器窗体服务对象
		///       </summary>
		public IWindowsFormsEditorService EditorService
		{
			get
			{
				return myEditorService;
			}
			set
			{
				myEditorService = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public UITypeEditorListBox()
		{
			base.BorderStyle = BorderStyle.None;
		}

		protected void CloseDropDown()
		{
			if (myEditorService != null)
			{
				myEditorService.CloseDropDown();
			}
		}

		/// <summary>
		///       显示控件
		///       </summary>
		/// <param name="svc">设计器服务对象</param>
		/// <returns>用户是否在列表中选择新的项目</returns>
		public bool ShowControl(IWindowsFormsEditorService iwindowsFormsEditorService_0)
		{
			myEditorService = iwindowsFormsEditorService_0;
			RefreshSize();
			Modified = false;
			iwindowsFormsEditorService_0.DropDownControl(this);
			return Modified;
		}

		protected override bool IsInputKey(Keys keyData)
		{
			if (keyData != Keys.Return && keyData != Keys.Escape)
			{
				return base.IsInputKey(keyData);
			}
			return true;
		}

		protected virtual void OnCommitSelection()
		{
			bolModified = true;
			CloseDropDown();
		}

		protected override void OnKeyDown(KeyEventArgs args)
		{
			base.OnKeyDown(args);
			if (args.KeyCode == Keys.Return)
			{
				OnCommitSelection();
			}
			else if (args.KeyCode == Keys.Escape)
			{
				CloseDropDown();
			}
		}

		protected override void OnSelectedIndexChanged(EventArgs eventArgs_0)
		{
			base.OnSelectedIndexChanged(eventArgs_0);
			OnCommitSelection();
		}

		public void SetText(string Text)
		{
			if (Text == null || Text.Length <= 0)
			{
				return;
			}
			int num = 0;
			while (true)
			{
				if (num < base.Items.Count)
				{
					string itemText = GetItemText(base.Items[num]);
					if (string.Compare(itemText, Text, ignoreCase: true) == 0)
					{
						break;
					}
					num++;
					continue;
				}
				return;
			}
			SelectedIndex = num;
		}

		public void RefreshSize()
		{
			int num = ItemHeight * base.Items.Count + 5;
			if (num > 300)
			{
				num = 300;
			}
			if (num < 50)
			{
				num = 50;
			}
			int num2 = 0;
			using (Graphics graphics = CreateGraphics())
			{
				foreach (object item in base.Items)
				{
					string itemText = GetItemText(item);
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
			num2 += 15;
			if (num2 > 300)
			{
				num2 = 300;
			}
			int num3 = base.PreferredHeight;
			if (num3 > 500)
			{
				num3 = 500;
			}
			base.ClientSize = new Size(num2, num3);
		}
	}
}
