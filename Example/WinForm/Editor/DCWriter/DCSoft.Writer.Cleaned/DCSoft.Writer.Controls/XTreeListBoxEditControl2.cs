using DCSoft.WinForms;
using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       下拉列表方式的数据编辑器
	///       </summary>
	[ComVisible(false)]
	[ToolboxItem(false)]
	public class XTreeListBoxEditControl2 : UserControl, IMessageFilter
	{
		private TextWindowsFormsEditorHost textWindowsFormsEditorHost_0 = null;

		private bool bool_0 = false;

		private GEnum29 genum29_0 = GEnum29.const_0;

		private IContainer icontainer_0 = null;

		private GControl5 lstItems;

		private Panel pnlButton;

		private Button btnCancel;

		private Button btnOK;

		/// <summary>
		///       按钮是否可见
		///       </summary>
		public bool ButtonVisible
		{
			get
			{
				return pnlButton.Visible;
			}
			set
			{
				pnlButton.Visible = value;
			}
		}

		/// <summary>
		///       编辑器宿主
		///       </summary>
		public TextWindowsFormsEditorHost EditorHost
		{
			get
			{
				return textWindowsFormsEditorHost_0;
			}
			set
			{
				textWindowsFormsEditorHost_0 = value;
			}
		}

		/// <summary>
		///       数值发生改变标志
		///       </summary>
		public bool Modified
		{
			get
			{
				return bool_0;
			}
			set
			{
				bool_0 = value;
			}
		}

		/// <summary>
		///       图标列表
		///       </summary>
		public ImageList ImageList
		{
			get
			{
				return lstItems.method_37();
			}
			set
			{
				lstItems.method_38(value);
			}
		}

		/// <summary>
		///       内置的列表框控件
		///       </summary>
		public GControl5 ListBox => lstItems;

		/// <summary>
		///       初始化对象
		///       </summary>
		public XTreeListBoxEditControl2()
		{
			SetStyle(ControlStyles.Selectable, value: false);
			InitializeComponent();
		}

		/// <summary>
		///       加载控件
		///       </summary>
		/// <param name="e">
		/// </param>
		protected override void OnLoad(EventArgs eventArgs_0)
		{
			base.OnLoad(eventArgs_0);
			if (!base.DesignMode && lstItems.method_78() != null)
			{
				lstItems.method_69(lstItems.method_78());
			}
		}

		bool IMessageFilter.PreFilterMessage(ref Message message_0)
		{
			if (lstItems == null || lstItems.IsDisposed)
			{
				return false;
			}
			return lstItems.PreFilterMessage(ref message_0);
		}

		public bool method_0()
		{
			lstItems.method_55(bool_14: false);
			if (lstItems.method_78() != null)
			{
				WinFormUtils.RunOnceDelay(delegate
				{
					if (lstItems.vmethod_6())
					{
						lstItems.method_70(lstItems.method_78());
					}
					else
					{
						lstItems.method_69(lstItems.method_78());
					}
				}, 50);
			}
			EditorHost.DropDownControl(this);
			return Modified;
		}

		/// <summary>
		///       获得推荐的大小
		///       </summary>
		/// <param name="proposedSize">
		/// </param>
		/// <returns>
		/// </returns>
		public override Size GetPreferredSize(Size proposedSize)
		{
			Size preferredSize = lstItems.GetPreferredSize(proposedSize);
			if (pnlButton.Visible)
			{
				preferredSize.Height += pnlButton.Height;
			}
			preferredSize.Height = Math.Min(preferredSize.Height, Screen.PrimaryScreen.WorkingArea.Width / 2);
			return preferredSize;
		}

		private void method_1(object sender, EventArgs e)
		{
		}

		private void method_2(object sender, EventArgs e)
		{
			Modified = true;
			genum29_0 = GEnum29.const_1;
			if (EditorHost != null)
			{
				EditorHost.CloseDropDown();
			}
		}

		private void method_3(object sender, EventArgs e)
		{
			Modified = false;
			genum29_0 = GEnum29.const_2;
			if (EditorHost != null)
			{
				EditorHost.CloseDropDown();
			}
		}

		private void method_4(object sender, EventArgs e)
		{
			Size preferredSize = lstItems.GetPreferredSize(new Size(500, 250));
			preferredSize.Width = preferredSize.Width + base.Width - base.ClientSize.Width;
			preferredSize.Height = preferredSize.Height + base.Height - base.ClientSize.Height;
			if (EditorHost != null)
			{
				EditorHost.method_6(preferredSize);
			}
			else
			{
				base.Size = preferredSize;
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			method_2(null, null);
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			method_3(null, null);
		}

		private void pnlButton_Resize(object sender, EventArgs e)
		{
			btnOK.Left = pnlButton.ClientSize.Width / 4 - btnOK.Width / 2;
			btnCancel.Left = (int)((double)pnlButton.ClientSize.Width * 0.75 - (double)(btnCancel.Width / 2));
		}

		/// <summary> 
		///       清理所有正在使用的资源。
		///       </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && icontainer_0 != null)
			{
				icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		/// <summary> 
		///       设计器支持所需的方法 - 不要
		///       使用代码编辑器修改此方法的内容。
		///       </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Controls.XTreeListBoxEditControl2));
			lstItems = new DCSoftDotfuscate.GControl5();
			pnlButton = new System.Windows.Forms.Panel();
			btnCancel = new System.Windows.Forms.Button();
			btnOK = new System.Windows.Forms.Button();
			pnlButton.SuspendLayout();
			SuspendLayout();
			lstItems.BackColor = System.Drawing.SystemColors.Window;
			lstItems.method_46(16);
			lstItems.Dock = System.Windows.Forms.DockStyle.Fill;
			lstItems.Name = "lstItems";
			lstItems.method_19(new System.EventHandler(method_1));
			lstItems.method_21(new System.EventHandler(method_2));
			lstItems.method_23(new System.EventHandler(method_3));
			lstItems.method_25(new System.EventHandler(method_4));
			pnlButton.Controls.Add(btnCancel);
			pnlButton.Controls.Add(btnOK);
			resources.ApplyResources(pnlButton, "pnlButton");
			pnlButton.Name = "pnlButton";
			pnlButton.Resize += new System.EventHandler(pnlButton_Resize);
			pnlButton.Dock = System.Windows.Forms.DockStyle.Bottom;
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.Name = "btnOK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			base.Controls.Add(lstItems);
			base.Controls.Add(pnlButton);
			base.Name = "XTreeListBoxEditControl2";
			resources.ApplyResources(this, "$this");
			pnlButton.ResumeLayout(false);
			ResumeLayout(false);
		}

		[CompilerGenerated]
		private void method_5(object sender, EventArgs e)
		{
			if (lstItems.vmethod_6())
			{
				lstItems.method_70(lstItems.method_78());
			}
			else
			{
				lstItems.method_69(lstItems.method_78());
			}
		}
	}
}
