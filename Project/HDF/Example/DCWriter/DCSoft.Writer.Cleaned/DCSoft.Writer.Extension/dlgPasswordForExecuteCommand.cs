using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Extension
{
	/// <summary>
	///       验证密码
	///       </summary>
	[ComVisible(false)]
	public class dlgPasswordForExecuteCommand : Form
	{
		private IContainer icontainer_0 = null;

		private Button btnOK;

		private Button btnCancel;

		private Label label1;

		private TextBox txtPassword;

		private string string_0;

		/// <summary>
		///       正确密码
		///       </summary>
		public string PasswordForExecuteCommand
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Extension.dlgPasswordForExecuteCommand));
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			label1 = new System.Windows.Forms.Label();
			txtPassword = new System.Windows.Forms.TextBox();
			SuspendLayout();
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.Name = "btnOK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			resources.ApplyResources(txtPassword, "txtPassword");
			txtPassword.Name = "txtPassword";
			base.AcceptButton = btnOK;
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = btnCancel;
			base.Controls.Add(txtPassword);
			base.Controls.Add(label1);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgPasswordForExecuteCommand";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgPasswordForExecuteCommand_Load);
			ResumeLayout(false);
			PerformLayout();
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgPasswordForExecuteCommand()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgPasswordForExecuteCommand_Load(object sender, EventArgs e)
		{
			txtPassword.Focus();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			txtPassword.Text = txtPassword.Text.Trim();
			string text = txtPassword.Text.Trim();
			if (!string.IsNullOrEmpty(text))
			{
				if (PasswordForExecuteCommand.ToLower() == text.ToLower())
				{
					base.DialogResult = DialogResult.OK;
					Close();
				}
				else
				{
					MessageBox.Show(this, WriterStrings.FailPasswordForExecuteCommand, WriterStrings.SystemAlert, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					txtPassword.Select();
				}
			}
			else
			{
				txtPassword.Focus();
			}
		}
	}
}
