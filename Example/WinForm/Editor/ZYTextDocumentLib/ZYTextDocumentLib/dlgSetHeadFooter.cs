using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using XDesignerCommon;

namespace ZYTextDocumentLib
{
	public class dlgSetHeadFooter : Form
	{
		private Label label1;

		private TextBox txtHeadHeight;

		private Label label2;

		private TextBox txtHeadText;

		private TextBox txtFooterText;

		private Label label3;

		private TextBox txtFooterHeight;

		private Label label4;

		private Button cmdOK;

		private Button cmdCancel;

		private Container components = null;

		internal ZYTextDocument myDocument = null;

		public dlgSetHeadFooter()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			label1 = new System.Windows.Forms.Label();
			txtHeadHeight = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			txtHeadText = new System.Windows.Forms.TextBox();
			txtFooterText = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			txtFooterHeight = new System.Windows.Forms.TextBox();
			label4 = new System.Windows.Forms.Label();
			cmdOK = new System.Windows.Forms.Button();
			cmdCancel = new System.Windows.Forms.Button();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(8, 8);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(97, 17);
			label1.TabIndex = 0;
			label1.Text = "页眉高度(毫米):";
			txtHeadHeight.Location = new System.Drawing.Point(104, 8);
			txtHeadHeight.Name = "txtHeadHeight";
			txtHeadHeight.Size = new System.Drawing.Size(136, 21);
			txtHeadHeight.TabIndex = 1;
			txtHeadHeight.Text = "";
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(8, 32);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(60, 17);
			label2.TabIndex = 2;
			label2.Text = "页眉文本:";
			txtHeadText.Location = new System.Drawing.Point(8, 48);
			txtHeadText.Multiline = true;
			txtHeadText.Name = "txtHeadText";
			txtHeadText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			txtHeadText.Size = new System.Drawing.Size(424, 96);
			txtHeadText.TabIndex = 3;
			txtHeadText.Text = "";
			txtHeadText.WordWrap = false;
			txtFooterText.Location = new System.Drawing.Point(8, 208);
			txtFooterText.Multiline = true;
			txtFooterText.Name = "txtFooterText";
			txtFooterText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			txtFooterText.Size = new System.Drawing.Size(424, 96);
			txtFooterText.TabIndex = 7;
			txtFooterText.Text = "";
			txtFooterText.WordWrap = false;
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(8, 184);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(60, 17);
			label3.TabIndex = 6;
			label3.Text = "页脚文本:";
			txtFooterHeight.Location = new System.Drawing.Point(104, 152);
			txtFooterHeight.Name = "txtFooterHeight";
			txtFooterHeight.Size = new System.Drawing.Size(136, 21);
			txtFooterHeight.TabIndex = 5;
			txtFooterHeight.Text = "";
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(8, 160);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(97, 17);
			label4.TabIndex = 4;
			label4.Text = "页脚高度(毫米):";
			cmdOK.Location = new System.Drawing.Point(272, 320);
			cmdOK.Name = "cmdOK";
			cmdOK.TabIndex = 8;
			cmdOK.Text = "确定(&O)";
			cmdOK.Click += new System.EventHandler(cmdOK_Click);
			cmdCancel.Location = new System.Drawing.Point(360, 320);
			cmdCancel.Name = "cmdCancel";
			cmdCancel.TabIndex = 9;
			cmdCancel.Text = "取消(&C)";
			cmdCancel.Click += new System.EventHandler(cmdCancel_Click);
			AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			base.ClientSize = new System.Drawing.Size(442, 351);
			base.Controls.Add(cmdCancel);
			base.Controls.Add(cmdOK);
			base.Controls.Add(txtFooterText);
			base.Controls.Add(label3);
			base.Controls.Add(txtFooterHeight);
			base.Controls.Add(label4);
			base.Controls.Add(txtHeadText);
			base.Controls.Add(label2);
			base.Controls.Add(txtHeadHeight);
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgSetHeadFooter";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "设置页眉页脚";
			base.Load += new System.EventHandler(dlgSetHeadFooter_Load);
			ResumeLayout(false);
		}

		private void dlgSetHeadFooter_Load(object sender, EventArgs e)
		{
			if (myDocument != null)
			{
				txtHeadHeight.Text = MeasureConvert.DocumentToMillimeter(myDocument.HeadHeight).ToString();
				txtHeadText.Text = myDocument.HeadString;
				txtFooterHeight.Text = MeasureConvert.DocumentToMillimeter(myDocument.FooterHeight).ToString();
				txtFooterText.Text = myDocument.FooterString;
			}
		}

		private void cmdOK_Click(object sender, EventArgs e)
		{
			try
			{
				if (myDocument != null)
				{
					myDocument.HeadHeight = (int)MeasureConvert.MillimeterToDocument(Convert.ToDouble(txtHeadHeight.Text));
					myDocument.HeadString = txtHeadText.Text;
					myDocument.FooterHeight = (int)MeasureConvert.MillimeterToDocument(Convert.ToDouble(txtFooterHeight.Text));
					myDocument.FooterString = txtFooterText.Text;
				}
				base.DialogResult = DialogResult.OK;
				Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, "数据设置错误:" + ex.Message, "系统提示");
			}
		}

		private void cmdCancel_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
