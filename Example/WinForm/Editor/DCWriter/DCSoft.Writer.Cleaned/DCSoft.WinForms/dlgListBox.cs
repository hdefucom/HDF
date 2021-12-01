using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.WinForms
{
	/// <summary>
	///       列表对话框
	///       </summary>
	[ComVisible(false)]
	public class dlgListBox : Form
	{
		[CompilerGenerated]
		private sealed class Class5
		{
			public dlgListBox dlgListBox_0;

			public EventHandler eventHandler_0;

			public void method_0(object sender, EventArgs e)
			{
				eventHandler_0(dlgListBox_0, e);
			}
		}

		private IContainer icontainer_0 = null;

		private ListBox lstItems;

		private Button btnOK;

		private Button btnCancel;

		private Button btnExten;

		/// <summary>
		///       内置的列表框控件
		///       </summary>
		public ListBox InnerListBox => lstItems;

		/// <summary>
		///       列表项目
		///       </summary>
		public ListBox.ObjectCollection ListItems => lstItems.Items;

		public object SelectedItem
		{
			get
			{
				return lstItems.SelectedItem;
			}
			set
			{
				lstItems.SelectedItem = value;
			}
		}

		public string SelectedText
		{
			get
			{
				return lstItems.Text;
			}
			set
			{
				lstItems.Text = value;
			}
		}

		/// <summary>
		///       Clean up any resources being used.
		///       </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && icontainer_0 != null)
			{
				icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		/// <summary>
		///       Required method for Designer support - do not modify
		///       the contents of this method with the code editor.
		///       </summary>
		private void InitializeComponent()
		{
			lstItems = new System.Windows.Forms.ListBox();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			btnExten = new System.Windows.Forms.Button();
			SuspendLayout();
			lstItems.Dock = System.Windows.Forms.DockStyle.Top;
			lstItems.FormattingEnabled = true;
			lstItems.ItemHeight = 12;
			lstItems.Location = new System.Drawing.Point(0, 0);
			lstItems.Name = "lstItems";
			lstItems.Size = new System.Drawing.Size(376, 304);
			lstItems.TabIndex = 0;
			btnOK.Location = new System.Drawing.Point(142, 310);
			btnOK.Name = "btnOK";
			btnOK.Size = new System.Drawing.Size(108, 23);
			btnOK.TabIndex = 1;
			btnOK.Text = "确定(&O)";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			btnCancel.Location = new System.Drawing.Point(256, 310);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(108, 23);
			btnCancel.TabIndex = 2;
			btnCancel.Text = "取消(&C)";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			btnExten.Location = new System.Drawing.Point(12, 310);
			btnExten.Name = "btnExten";
			btnExten.Size = new System.Drawing.Size(123, 23);
			btnExten.TabIndex = 3;
			btnExten.Text = "扩展";
			btnExten.UseVisualStyleBackColor = true;
			btnExten.Visible = false;
			base.AcceptButton = btnOK;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = btnCancel;
			base.ClientSize = new System.Drawing.Size(376, 345);
			base.Controls.Add(btnExten);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(lstItems);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgListBox";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "选择项目";
			base.Load += new System.EventHandler(dlgListBox_Load);
			ResumeLayout(false);
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgListBox()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgListBox_Load(object sender, EventArgs e)
		{
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		/// <summary>
		///       显示扩展按钮
		///       </summary>
		/// <param name="text">文本值</param>
		/// <param name="handler">句柄对象</param>
		public void ShowExtButton(string text, EventHandler handler)
		{
			btnExten.Text = text;
			btnExten.Visible = true;
			if (handler != null)
			{
				btnExten.Click += delegate(object sender, EventArgs e)
				{
					handler(this, e);
				};
			}
		}
	}
}
