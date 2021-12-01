using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ZYCommon
{
	public class dlgChangePWD : Form
	{
		private Label label1;

		private Label label2;

		private Label label3;

		private Button cmdOK;

		private Button cmdCancel;

		private TextBox txtOldPWD;

		private TextBox txtNewPWD;

		private TextBox txtNewPWD2;

		private Container components = null;

		private string strOldPWD = "";

		private string strNewPWD = "";

		public CheckStringHandler CheckPWDHandler = null;

		public string OldPWD
		{
			get
			{
				return strOldPWD;
			}
			set
			{
				strOldPWD = value;
			}
		}

		public string NewPWD
		{
			get
			{
				return strNewPWD;
			}
			set
			{
				strNewPWD = value;
			}
		}

		public static string ChangePWD(string strTitle, CheckStringHandler CheckPWDHandler)
		{
			using (dlgChangePWD dlgChangePWD = new dlgChangePWD())
			{
				if (StringCommon.HasContent(strTitle))
				{
					dlgChangePWD.Text = strTitle;
				}
				dlgChangePWD.CheckPWDHandler = CheckPWDHandler;
				if (dlgChangePWD.ShowDialog() == DialogResult.OK)
				{
					return dlgChangePWD.NewPWD;
				}
			}
			return null;
		}

		public dlgChangePWD()
		{
			base.DialogResult = DialogResult.Cancel;
			InitializeComponent();
			txtOldPWD.Text = strOldPWD;
			txtNewPWD.Text = "";
			txtNewPWD2.Text = "";
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
			txtOldPWD = new System.Windows.Forms.TextBox();
			txtNewPWD = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			txtNewPWD2 = new System.Windows.Forms.TextBox();
			cmdOK = new System.Windows.Forms.Button();
			cmdCancel = new System.Windows.Forms.Button();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(12, 18);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(66, 17);
			label1.TabIndex = 1;
			label1.Text = "旧密码(P):";
			txtOldPWD.Location = new System.Drawing.Point(107, 14);
			txtOldPWD.Name = "txtOldPWD";
			txtOldPWD.PasswordChar = '*';
			txtOldPWD.Size = new System.Drawing.Size(245, 21);
			txtOldPWD.TabIndex = 2;
			txtOldPWD.Text = "";
			txtOldPWD.KeyDown += new System.Windows.Forms.KeyEventHandler(txtOldPWD_KeyDown);
			txtNewPWD.Location = new System.Drawing.Point(107, 50);
			txtNewPWD.Name = "txtNewPWD";
			txtNewPWD.PasswordChar = '*';
			txtNewPWD.Size = new System.Drawing.Size(245, 21);
			txtNewPWD.TabIndex = 4;
			txtNewPWD.Text = "";
			txtNewPWD.KeyDown += new System.Windows.Forms.KeyEventHandler(txtNewPWD_KeyDown);
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(12, 54);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(66, 17);
			label2.TabIndex = 3;
			label2.Text = "新密码(&N):";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(12, 82);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(91, 17);
			label3.TabIndex = 5;
			label3.Text = "验证新密码(&R):";
			txtNewPWD2.Location = new System.Drawing.Point(107, 78);
			txtNewPWD2.Name = "txtNewPWD2";
			txtNewPWD2.PasswordChar = '*';
			txtNewPWD2.Size = new System.Drawing.Size(245, 21);
			txtNewPWD2.TabIndex = 6;
			txtNewPWD2.Text = "";
			txtNewPWD2.KeyDown += new System.Windows.Forms.KeyEventHandler(txtNewPWD2_KeyDown);
			cmdOK.Location = new System.Drawing.Point(176, 112);
			cmdOK.Name = "cmdOK";
			cmdOK.TabIndex = 7;
			cmdOK.Text = "确定(&O)";
			cmdOK.Click += new System.EventHandler(cmdOK_Click);
			cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			cmdCancel.Location = new System.Drawing.Point(264, 112);
			cmdCancel.Name = "cmdCancel";
			cmdCancel.TabIndex = 8;
			cmdCancel.Text = "取消(&C)";
			cmdCancel.Click += new System.EventHandler(cmdCancel_Click);
			AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			base.CancelButton = cmdCancel;
			base.ClientSize = new System.Drawing.Size(362, 143);
			base.Controls.Add(cmdCancel);
			base.Controls.Add(cmdOK);
			base.Controls.Add(txtOldPWD);
			base.Controls.Add(label1);
			base.Controls.Add(txtNewPWD);
			base.Controls.Add(label2);
			base.Controls.Add(label3);
			base.Controls.Add(txtNewPWD2);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgChangePWD";
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "修改密码";
			ResumeLayout(false);
		}

		private void cmdOK_Click(object sender, EventArgs e)
		{
			if (CheckPWDHandler != null && !CheckPWDHandler(txtOldPWD.Text))
			{
				MessageBox.Show(this, "旧密码输入错误，请重新输入旧密码!", "修改密码", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				txtOldPWD.Focus();
				txtOldPWD.SelectAll();
			}
			else if (txtNewPWD2.Text != txtNewPWD.Text)
			{
				MessageBox.Show(this, "新密码和验证密码不一致，请重新输入新密码!", "修改密码", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				txtNewPWD2.Focus();
				txtNewPWD2.SelectAll();
			}
			else
			{
				strNewPWD = txtNewPWD.Text;
				base.DialogResult = DialogResult.OK;
				Close();
			}
		}

		private void cmdCancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
			Close();
		}

		private void txtOldPWD_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				base.ActiveControl = txtNewPWD;
			}
		}

		private void txtNewPWD_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				base.ActiveControl = txtNewPWD2;
			}
		}

		private void txtNewPWD2_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				cmdOK_Click(null, null);
			}
		}
	}
}
