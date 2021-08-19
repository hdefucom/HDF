using DCSoft.Drawing;
using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Printing
{
	[ComVisible(false)]
	public class dlgTerminalTextInfo : Form
	{
		private IContainer icontainer_0 = null;

		private Label label1;

		private TextBox txtText;

		private Label label2;

		private Button btnFont;

		private Label label3;

		private GClass304 btnColor;

		private Button btnOK;

		private Button btnCancel;

		private Label label4;

		private NumericUpDown txtMinHeight;

		private Label label5;

		private TextBox txtTextInMiddlePage;

		private DocumentTerminalTextInfo documentTerminalTextInfo_0 = null;

		/// <summary>
		///       文本信息对象
		///       </summary>
		public DocumentTerminalTextInfo InputTextInfo
		{
			get
			{
				return documentTerminalTextInfo_0;
			}
			set
			{
				documentTerminalTextInfo_0 = value;
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
			txtText = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			btnFont = new System.Windows.Forms.Button();
			label3 = new System.Windows.Forms.Label();
			btnColor = new DCSoftDotfuscate.GClass304();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			label4 = new System.Windows.Forms.Label();
			txtMinHeight = new System.Windows.Forms.NumericUpDown();
			label5 = new System.Windows.Forms.Label();
			txtTextInMiddlePage = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)txtMinHeight).BeginInit();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(9, 15);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(149, 12);
			label1.TabIndex = 0;
			label1.Text = "最后一页的空白占位文本：";
			txtText.Location = new System.Drawing.Point(63, 30);
			txtText.Name = "txtText";
			txtText.Size = new System.Drawing.Size(261, 21);
			txtText.TabIndex = 1;
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(14, 119);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(41, 12);
			label2.TabIndex = 4;
			label2.Text = "字体：";
			btnFont.Location = new System.Drawing.Point(63, 114);
			btnFont.Name = "btnFont";
			btnFont.Size = new System.Drawing.Size(261, 23);
			btnFont.TabIndex = 5;
			btnFont.UseVisualStyleBackColor = true;
			btnFont.Click += new System.EventHandler(btnFont_Click);
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(16, 156);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(41, 12);
			label3.TabIndex = 6;
			label3.Text = "颜色：";
			btnColor.Location = new System.Drawing.Point(63, 151);
			btnColor.Name = "btnColor";
			btnColor.Size = new System.Drawing.Size(261, 23);
			btnColor.TabIndex = 7;
			btnColor.UseVisualStyleBackColor = true;
			btnOK.Location = new System.Drawing.Point(76, 235);
			btnOK.Name = "btnOK";
			btnOK.Size = new System.Drawing.Size(75, 23);
			btnOK.TabIndex = 10;
			btnOK.Text = "确定(&O)";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			btnCancel.Location = new System.Drawing.Point(191, 235);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(75, 23);
			btnCancel.TabIndex = 11;
			btnCancel.Text = "取消(&C)";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(14, 200);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(101, 12);
			label4.TabIndex = 8;
			label4.Text = "最小高度(厘米)：";
			txtMinHeight.Increment = new decimal(new int[4]
			{
				1,
				0,
				0,
				65536
			});
			txtMinHeight.Location = new System.Drawing.Point(111, 198);
			txtMinHeight.Name = "txtMinHeight";
			txtMinHeight.Size = new System.Drawing.Size(213, 21);
			txtMinHeight.TabIndex = 9;
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(9, 64);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(161, 12);
			label5.TabIndex = 2;
			label5.Text = "中间页面中的空白占位文本：";
			txtTextInMiddlePage.Location = new System.Drawing.Point(63, 78);
			txtTextInMiddlePage.Name = "txtTextInMiddlePage";
			txtTextInMiddlePage.Size = new System.Drawing.Size(261, 21);
			txtTextInMiddlePage.TabIndex = 3;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(336, 268);
			base.Controls.Add(txtMinHeight);
			base.Controls.Add(label4);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(btnColor);
			base.Controls.Add(label3);
			base.Controls.Add(btnFont);
			base.Controls.Add(label2);
			base.Controls.Add(txtTextInMiddlePage);
			base.Controls.Add(label5);
			base.Controls.Add(txtText);
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgTerminalTextInfo";
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "空白占位文本";
			base.Load += new System.EventHandler(dlgTerminalTextInfo_Load);
			((System.ComponentModel.ISupportInitialize)txtMinHeight).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		public dlgTerminalTextInfo()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		protected override void OnClosing(CancelEventArgs cancelEventArgs_0)
		{
			base.OnClosing(cancelEventArgs_0);
		}

		private void dlgTerminalTextInfo_Load(object sender, EventArgs e)
		{
			if (documentTerminalTextInfo_0 == null)
			{
				documentTerminalTextInfo_0 = new DocumentTerminalTextInfo();
			}
			txtText.Text = documentTerminalTextInfo_0.Text;
			btnColor.method_1(documentTerminalTextInfo_0.Color);
			btnFont.Text = documentTerminalTextInfo_0.RuntimeFont.ToString();
			btnFont.Tag = documentTerminalTextInfo_0.RuntimeFont.Value;
			txtMinHeight.Value = (decimal)documentTerminalTextInfo_0.MinHeightInCMUnit;
			txtTextInMiddlePage.Text = documentTerminalTextInfo_0.TextInMiddlePage;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			documentTerminalTextInfo_0.Text = txtText.Text;
			documentTerminalTextInfo_0.TextInMiddlePage = txtTextInMiddlePage.Text;
			documentTerminalTextInfo_0.Color = btnColor.method_0();
			if (btnFont.Tag == null)
			{
				documentTerminalTextInfo_0.Font = null;
			}
			else
			{
				documentTerminalTextInfo_0.Font = new XFontValue((Font)btnFont.Tag);
			}
			documentTerminalTextInfo_0.MinHeightInCMUnit = (float)txtMinHeight.Value;
			base.DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnFont_Click(object sender, EventArgs e)
		{
			using (FontDialog fontDialog = new FontDialog())
			{
				if (btnFont.Tag != null)
				{
					fontDialog.Font = (Font)btnFont.Tag;
				}
				fontDialog.ShowColor = false;
				if (fontDialog.ShowDialog(this) == DialogResult.OK)
				{
					btnFont.Tag = fontDialog.Font;
					btnFont.Text = fontDialog.Font.ToString();
				}
			}
		}
	}
}
