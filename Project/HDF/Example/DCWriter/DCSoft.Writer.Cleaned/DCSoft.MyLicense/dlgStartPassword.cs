using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.MyLicense
{
	[ComVisible(false)]
	public class dlgStartPassword : Form
	{
		private IContainer icontainer_0 = null;

		private TextBox txtPassword;

		private Button btnOK;

		private Button btnCancel;

		private Panel panel1;

		private PictureBox picImg;

		private Label label1;

		private Label label2;

		public string PasswordText
		{
			get
			{
				return txtPassword.Text;
			}
			set
			{
				txtPassword.Text = value;
			}
		}

		public dlgStartPassword()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgStartPassword_Load(object sender, EventArgs e)
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

		protected override void Dispose(bool disposing)
		{
			if (disposing && icontainer_0 != null)
			{
				icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.MyLicense.dlgStartPassword));
			txtPassword = new System.Windows.Forms.TextBox();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			panel1 = new System.Windows.Forms.Panel();
			picImg = new System.Windows.Forms.PictureBox();
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)picImg).BeginInit();
			SuspendLayout();
			resources.ApplyResources(txtPassword, "txtPassword");
			txtPassword.Name = "txtPassword";
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.Name = "btnOK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			panel1.BackColor = System.Drawing.Color.White;
			panel1.Controls.Add(picImg);
			panel1.Controls.Add(label1);
			resources.ApplyResources(panel1, "panel1");
			panel1.Name = "panel1";
			resources.ApplyResources(picImg, "picImg");
			picImg.Name = "picImg";
			picImg.TabStop = false;
			label1.BackColor = System.Drawing.Color.Transparent;
			resources.ApplyResources(label1, "label1");
			label1.ForeColor = System.Drawing.Color.Blue;
			label1.Name = "label1";
			resources.ApplyResources(label2, "label2");
			label2.Name = "label2";
			base.AcceptButton = btnOK;
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = btnCancel;
			base.Controls.Add(label2);
			base.Controls.Add(panel1);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(txtPassword);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgStartPassword";
			base.Load += new System.EventHandler(dlgStartPassword_Load);
			panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)picImg).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
