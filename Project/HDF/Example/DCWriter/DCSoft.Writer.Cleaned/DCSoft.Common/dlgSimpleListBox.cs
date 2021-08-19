using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Common
{
	                                                                    /// <summary>
	                                                                    ///       简单的列表对话框
	                                                                    ///       </summary>
	[ComVisible(false)]
	public class dlgSimpleListBox : Form
	{
		private List<string> list_0 = new List<string>();

		private string string_0 = null;

		private IContainer icontainer_0 = null;

		private Button btnOK;

		private Button btnCancel;

		private ListBox lstItems;

		public List<string> InputItems
		{
			get
			{
				return list_0;
			}
			set
			{
				list_0 = value;
			}
		}

		public string InputText
		{
			get
			{
				return string_0;
			}
			set
			{
				string_0 = value;
			}
		}

		public dlgSimpleListBox()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgSimpleListBox_Load(object sender, EventArgs e)
		{
			if (list_0 != null)
			{
				lstItems.Items.AddRange(list_0.ToArray());
			}
			if (!string.IsNullOrEmpty(string_0))
			{
				lstItems.Text = string_0;
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			string_0 = lstItems.Text;
			base.DialogResult = DialogResult.OK;
			Close();
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
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			lstItems = new System.Windows.Forms.ListBox();
			SuspendLayout();
			btnOK.Location = new System.Drawing.Point(60, 328);
			btnOK.Name = "btnOK";
			btnOK.Size = new System.Drawing.Size(75, 23);
			btnOK.TabIndex = 1;
			btnOK.Text = "确定(&O)";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			btnCancel.Location = new System.Drawing.Point(171, 328);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(75, 23);
			btnCancel.TabIndex = 2;
			btnCancel.Text = "取消(&C)";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			lstItems.Dock = System.Windows.Forms.DockStyle.Top;
			lstItems.Font = new System.Drawing.Font("宋体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			lstItems.FormattingEnabled = true;
			lstItems.ItemHeight = 14;
			lstItems.Location = new System.Drawing.Point(0, 0);
			lstItems.Name = "lstItems";
			lstItems.Size = new System.Drawing.Size(316, 312);
			lstItems.TabIndex = 0;
			base.AcceptButton = btnOK;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = btnCancel;
			base.ClientSize = new System.Drawing.Size(316, 363);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(lstItems);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgSimpleListBox";
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "列表对话框";
			base.Load += new System.EventHandler(dlgSimpleListBox_Load);
			ResumeLayout(false);
		}
	}
}
