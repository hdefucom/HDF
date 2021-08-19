using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Common
{
	                                                                    /// <summary>
	                                                                    ///       编辑超链接的对话框
	                                                                    ///       </summary>
	[ComVisible(false)]
	public class dlgHyperlinkInfo : Form
	{
		private IContainer icontainer_0 = null;

		private Label label1;

		private TextBox txtReference;

		private Label label2;

		private ComboBox cboTarget;

		private Button btnOK;

		private Button btnCancel;

		private Label label3;

		private TextBox txtTitle;

		private HyperlinkInfo hyperlinkInfo_0 = null;

		                                                                    /// <summary>
		                                                                    ///       输入的超链接信息对象
		                                                                    ///       </summary>
		public HyperlinkInfo InputInfo
		{
			get
			{
				return hyperlinkInfo_0;
			}
			set
			{
				hyperlinkInfo_0 = value;
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
			label1 = new System.Windows.Forms.Label();
			txtReference = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			cboTarget = new System.Windows.Forms.ComboBox();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			label3 = new System.Windows.Forms.Label();
			txtTitle = new System.Windows.Forms.TextBox();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(12, 9);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(65, 12);
			label1.TabIndex = 0;
			label1.Text = "链接地址：";
			txtReference.Location = new System.Drawing.Point(72, 6);
			txtReference.Name = "txtReference";
			txtReference.Size = new System.Drawing.Size(390, 21);
			txtReference.TabIndex = 1;
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(13, 42);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(65, 12);
			label2.TabIndex = 2;
			label2.Text = "链接目标：";
			cboTarget.FormattingEnabled = true;
			cboTarget.Items.AddRange(new object[6]
			{
				"_blank",
				"_media",
				"_parent",
				"_search",
				"_self",
				"_top"
			});
			cboTarget.Location = new System.Drawing.Point(72, 42);
			cboTarget.Name = "cboTarget";
			cboTarget.Size = new System.Drawing.Size(150, 20);
			cboTarget.TabIndex = 3;
			btnOK.Location = new System.Drawing.Point(176, 122);
			btnOK.Name = "btnOK";
			btnOK.Size = new System.Drawing.Size(115, 23);
			btnOK.TabIndex = 6;
			btnOK.Text = "确定(&O)";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			btnCancel.Location = new System.Drawing.Point(317, 122);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(115, 23);
			btnCancel.TabIndex = 7;
			btnCancel.Text = "取消(&C)";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(12, 80);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(65, 12);
			label3.TabIndex = 4;
			label3.Text = "提示文本：";
			txtTitle.Location = new System.Drawing.Point(72, 77);
			txtTitle.Name = "txtTitle";
			txtTitle.Size = new System.Drawing.Size(390, 21);
			txtTitle.TabIndex = 5;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = btnCancel;
			base.ClientSize = new System.Drawing.Size(483, 160);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(cboTarget);
			base.Controls.Add(label2);
			base.Controls.Add(txtTitle);
			base.Controls.Add(label3);
			base.Controls.Add(txtReference);
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgHyperlinkInfo";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "超链接";
			base.Load += new System.EventHandler(dlgHyperlinkInfo_Load);
			ResumeLayout(false);
			PerformLayout();
		}

		                                                                    /// <summary>
		                                                                    ///       初始化对象
		                                                                    ///       </summary>
		public dlgHyperlinkInfo()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgHyperlinkInfo_Load(object sender, EventArgs e)
		{
			if (InputInfo != null)
			{
				txtReference.Text = InputInfo.Reference;
				cboTarget.Text = InputInfo.Target;
				txtTitle.Text = InputInfo.Title;
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (InputInfo == null)
			{
				InputInfo = new HyperlinkInfo();
			}
			InputInfo.Reference = txtReference.Text;
			InputInfo.Target = cboTarget.Text;
			InputInfo.Title = txtTitle.Text;
			base.DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
