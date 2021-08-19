using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ZYCommon
{
	public class dlgInputBox : Form
	{
		internal Label lblTitle;

		internal TextBox txtInput;

		internal Button cmdOK;

		internal Button cmdCancel;

		public CheckStringHandler CheckValueHandler = null;

		public string ErrorValueMsg = "输入的数据错误，请重新输入!";

		private string strTextValue = "";

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

		public static string InputBox(string strTitle, string strCaption, string strDefaultValue)
		{
			using (dlgInputBox dlgInputBox = new dlgInputBox())
			{
				dlgInputBox.lblTitle.Text = strTitle;
				dlgInputBox.Text = strCaption;
				dlgInputBox.TextValue = strDefaultValue;
				if (dlgInputBox.ShowDialog() == DialogResult.OK)
				{
					return dlgInputBox.txtInput.Text;
				}
			}
			return null;
		}

		public static string InputPassword(string strTitle, string strCaption, CheckStringHandler CheckPWD)
		{
			using (dlgInputBox dlgInputBox = new dlgInputBox())
			{
				dlgInputBox.lblTitle.Text = strTitle;
				dlgInputBox.Text = strCaption;
				dlgInputBox.txtInput.PasswordChar = '*';
				dlgInputBox.CheckValueHandler = CheckPWD;
				dlgInputBox.ErrorValueMsg = "密码输入错误，请重新输入!";
				if (dlgInputBox.ShowDialog() == DialogResult.OK)
				{
					return dlgInputBox.TextValue;
				}
			}
			return null;
		}

		public dlgInputBox()
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
			SuspendLayout();
			lblTitle.Location = new System.Drawing.Point(16, 16);
			lblTitle.Name = "lblTitle";
			lblTitle.Size = new System.Drawing.Size(328, 32);
			lblTitle.TabIndex = 0;
			lblTitle.Text = "标题";
			txtInput.Location = new System.Drawing.Point(16, 56);
			txtInput.Name = "txtInput";
			txtInput.Size = new System.Drawing.Size(328, 21);
			txtInput.TabIndex = 1;
			txtInput.Text = "";
			txtInput.KeyDown += new System.Windows.Forms.KeyEventHandler(txtInput_KeyDown);
			cmdOK.Location = new System.Drawing.Point(176, 88);
			cmdOK.Name = "cmdOK";
			cmdOK.TabIndex = 2;
			cmdOK.Text = "确定(&O)";
			cmdOK.Click += new System.EventHandler(cmdOK_Click);
			cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			cmdCancel.Location = new System.Drawing.Point(264, 88);
			cmdCancel.Name = "cmdCancel";
			cmdCancel.TabIndex = 3;
			cmdCancel.Text = "取消(&C)";
			cmdCancel.Click += new System.EventHandler(cmdCancel_Click);
			AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			base.CancelButton = cmdCancel;
			base.ClientSize = new System.Drawing.Size(362, 127);
			base.Controls.Add(cmdCancel);
			base.Controls.Add(cmdOK);
			base.Controls.Add(txtInput);
			base.Controls.Add(lblTitle);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgInputBox";
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "输入框";
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
			txtInput.Text = strTextValue;
		}
	}
}
