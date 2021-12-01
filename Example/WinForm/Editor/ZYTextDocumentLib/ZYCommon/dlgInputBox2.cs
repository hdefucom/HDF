using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ZYCommon
{
	public class dlgInputBox2 : Form
	{
		private Label label1;

		private TextBox textBox1;

		private Label label2;

		private TextBox textBox2;

		private Button cmdOK;

		private Button cmdCancel;

		private Container components = null;

		public string Title1 = "";

		public string Title2 = "";

		public string Value1 = "";

		public string Value2 = "";

		public CheckStringHandler ValueCheck1 = null;

		public CheckStringHandler ValueCheck2 = null;

		public dlgInputBox2()
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
			textBox1 = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			textBox2 = new System.Windows.Forms.TextBox();
			cmdOK = new System.Windows.Forms.Button();
			cmdCancel = new System.Windows.Forms.Button();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(8, 8);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(42, 17);
			label1.TabIndex = 0;
			label1.Text = "label1";
			textBox1.Location = new System.Drawing.Point(8, 32);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(312, 21);
			textBox1.TabIndex = 1;
			textBox1.Text = "";
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(8, 64);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(42, 17);
			label2.TabIndex = 2;
			label2.Text = "label2";
			textBox2.Location = new System.Drawing.Point(8, 88);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(312, 21);
			textBox2.TabIndex = 3;
			textBox2.Text = "";
			cmdOK.Location = new System.Drawing.Point(160, 120);
			cmdOK.Name = "cmdOK";
			cmdOK.TabIndex = 4;
			cmdOK.Text = "确定(&O)";
			cmdOK.Click += new System.EventHandler(cmdOK_Click);
			cmdCancel.Location = new System.Drawing.Point(248, 120);
			cmdCancel.Name = "cmdCancel";
			cmdCancel.TabIndex = 5;
			cmdCancel.Text = "取消(&C)";
			cmdCancel.Click += new System.EventHandler(cmdCancel_Click);
			AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			base.ClientSize = new System.Drawing.Size(330, 151);
			base.Controls.Add(cmdCancel);
			base.Controls.Add(cmdOK);
			base.Controls.Add(textBox2);
			base.Controls.Add(label2);
			base.Controls.Add(textBox1);
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgInputBox2";
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "输入数据";
			base.Load += new System.EventHandler(Form_Load);
			ResumeLayout(false);
		}

		private void Form_Load(object sender, EventArgs e)
		{
			label1.Text = Title1;
			label2.Text = Title2;
			textBox1.Text = Value1;
			textBox2.Text = Value2;
		}

		private void cmdOK_Click(object sender, EventArgs e)
		{
			if (ValueCheck1 != null && !ValueCheck1(textBox1.Text))
			{
				MessageBox.Show(this, "第一个数据输入不正确,请重新输入!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				textBox1.SelectAll();
				return;
			}
			if (ValueCheck2 != null && !ValueCheck2(textBox2.Text))
			{
				MessageBox.Show(this, "第二个数据输入不正确,请重新输入!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				textBox2.SelectAll();
				return;
			}
			Value1 = textBox1.Text;
			Value2 = textBox2.Text;
			base.DialogResult = DialogResult.OK;
			Close();
		}

		private void cmdCancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
			Close();
		}

		public static string[] InputBox2(string strCaption, string strTitle1, string strTitle2, string DefaultValue1, string DefaultValue2, CheckStringHandler ValueCheck1, CheckStringHandler ValueCheck2)
		{
			using (dlgInputBox2 dlgInputBox = new dlgInputBox2())
			{
				dlgInputBox.Text = strCaption;
				dlgInputBox.Title1 = strTitle1;
				dlgInputBox.Title2 = strTitle2;
				dlgInputBox.Value1 = DefaultValue1;
				dlgInputBox.Value2 = DefaultValue2;
				dlgInputBox.ValueCheck1 = ValueCheck1;
				dlgInputBox.ValueCheck2 = ValueCheck2;
				if (dlgInputBox.ShowDialog() == DialogResult.OK)
				{
					return new string[2]
					{
						dlgInputBox.Value1,
						dlgInputBox.Value2
					};
				}
			}
			return null;
		}

		public static string[] InputBox2(string strCaption, string strTitle1, string strTitle2)
		{
			return InputBox2(strCaption, strTitle1, strTitle2, "", "", null, null);
		}
	}
}
