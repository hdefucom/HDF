using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ZYCommon
{
	public class dlgInputBox5 : Form
	{
		internal Label lblTitle;

		internal TextBox txtInput;

		internal Button cmdOK;

		internal Button cmdCancel;

		public CheckStringHandler CheckValueHandler = null;

		public string ErrorValueMsg = "输入的数据错误，请重新输入!";

		private string strTextValue = "";

		private ComboBox comboBox1;

		private Label label1;

		private Label label2;

		private ComboBox comboBox2;

		private Container components = null;

		public string TextValue
		{
			get
			{
				return strTextValue;
			}
			set
			{
				strTextValue = value;
			}
		}

		public static string[] InputBox(string strTitle, string strInput, string fontName, string fontSize)
		{
			using (dlgInputBox5 dlgInputBox = new dlgInputBox5())
			{
				dlgInputBox.lblTitle.Text = strTitle;
				dlgInputBox.txtInput.Text = strInput;
				for (int i = 0; i < dlgInputBox.comboBox2.Items.Count; i++)
				{
					if (i < dlgInputBox.comboBox1.Items.Count && dlgInputBox.comboBox1.Items[i].ToString() == fontName)
					{
						dlgInputBox.comboBox1.SelectedIndex = i;
					}
					if (dlgInputBox.comboBox2.Items[i].ToString() == fontSize)
					{
						dlgInputBox.comboBox2.SelectedIndex = i;
					}
				}
				if (dlgInputBox.ShowDialog() == DialogResult.OK)
				{
					return new string[3]
					{
						dlgInputBox.txtInput.Text,
						dlgInputBox.comboBox1.SelectedItem.ToString(),
						dlgInputBox.comboBox2.SelectedItem.ToString()
					};
				}
			}
			return null;
		}

		public dlgInputBox5()
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
			lblTitle = new System.Windows.Forms.Label();
			txtInput = new System.Windows.Forms.TextBox();
			cmdOK = new System.Windows.Forms.Button();
			cmdCancel = new System.Windows.Forms.Button();
			comboBox1 = new System.Windows.Forms.ComboBox();
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			comboBox2 = new System.Windows.Forms.ComboBox();
			SuspendLayout();
			lblTitle.Location = new System.Drawing.Point(16, 24);
			lblTitle.Name = "lblTitle";
			lblTitle.Size = new System.Drawing.Size(40, 16);
			lblTitle.TabIndex = 0;
			lblTitle.Text = "标题";
			txtInput.Location = new System.Drawing.Point(64, 16);
			txtInput.Name = "txtInput";
			txtInput.Size = new System.Drawing.Size(248, 21);
			txtInput.TabIndex = 1;
			txtInput.Text = "";
			txtInput.KeyDown += new System.Windows.Forms.KeyEventHandler(txtInput_KeyDown);
			cmdOK.Location = new System.Drawing.Point(192, 112);
			cmdOK.Name = "cmdOK";
			cmdOK.TabIndex = 2;
			cmdOK.Text = "确定(&O)";
			cmdOK.Click += new System.EventHandler(cmdOK_Click);
			cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			cmdCancel.Location = new System.Drawing.Point(280, 112);
			cmdCancel.Name = "cmdCancel";
			cmdCancel.TabIndex = 3;
			cmdCancel.Text = "取消(&C)";
			cmdCancel.Click += new System.EventHandler(cmdCancel_Click);
			comboBox1.Items.AddRange(new object[6]
			{
				"宋体",
				"黑体",
				"楷体_GB2312",
				"仿宋_GB2312",
				"隶书",
				"幼圆"
			});
			comboBox1.Location = new System.Drawing.Point(64, 48);
			comboBox1.Name = "comboBox1";
			comboBox1.Size = new System.Drawing.Size(96, 20);
			comboBox1.TabIndex = 4;
			label1.Location = new System.Drawing.Point(16, 48);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(32, 21);
			label1.TabIndex = 5;
			label1.Text = "字体";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label2.Location = new System.Drawing.Point(16, 72);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(32, 21);
			label2.TabIndex = 6;
			label2.Text = "大小";
			label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			comboBox2.Items.AddRange(new object[9]
			{
				"12",
				"13",
				"14",
				"15",
				"16",
				"17",
				"18",
				"19",
				"20"
			});
			comboBox2.Location = new System.Drawing.Point(64, 72);
			comboBox2.Name = "comboBox2";
			comboBox2.Size = new System.Drawing.Size(96, 20);
			comboBox2.TabIndex = 7;
			AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			base.CancelButton = cmdCancel;
			base.ClientSize = new System.Drawing.Size(370, 143);
			base.Controls.Add(comboBox2);
			base.Controls.Add(label2);
			base.Controls.Add(label1);
			base.Controls.Add(comboBox1);
			base.Controls.Add(cmdCancel);
			base.Controls.Add(cmdOK);
			base.Controls.Add(txtInput);
			base.Controls.Add(lblTitle);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgInputBox5";
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "设置标题";
			base.Load += new System.EventHandler(dlgInputBox_Load);
			ResumeLayout(false);
		}

		private void cmdOK_Click(object sender, EventArgs e)
		{
			if (CheckValueHandler != null && !CheckValueHandler(txtInput.Text))
			{
				MessageBox.Show(this, ErrorValueMsg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				txtInput.Focus();
				txtInput.SelectAll();
			}
			else
			{
				strTextValue = txtInput.Text;
				base.DialogResult = DialogResult.OK;
				Close();
			}
		}

		private void cmdCancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
			Close();
		}

		private void txtInput_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				cmdOK_Click(null, null);
			}
		}

		private void dlgInputBox_Load(object sender, EventArgs e)
		{
		}
	}
}
