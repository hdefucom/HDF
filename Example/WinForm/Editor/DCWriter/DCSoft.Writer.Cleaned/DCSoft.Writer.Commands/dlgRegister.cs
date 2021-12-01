using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       注册对话框
	///       </summary>
	[ComVisible(false)]
	public class dlgRegister : Form
	{
		private IContainer icontainer_0 = null;

		private Label label2;

		private TextBox txtRegisterCode;

		private Label label3;

		private Button btnOK;

		private Button btnCancel;

		private Button btnCancelRegister;

		private string string_0 = "";

		/// <summary>
		///       注册码
		///       </summary>
		public string InputRegisterCode
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Commands.dlgRegister));
			label2 = new System.Windows.Forms.Label();
			txtRegisterCode = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			btnCancelRegister = new System.Windows.Forms.Button();
			SuspendLayout();
			resources.ApplyResources(label2, "label2");
			label2.Name = "label2";
			resources.ApplyResources(txtRegisterCode, "txtRegisterCode");
			txtRegisterCode.Name = "txtRegisterCode";
			label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			resources.ApplyResources(label3, "label3");
			label3.Name = "label3";
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.Name = "btnOK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			resources.ApplyResources(btnCancelRegister, "btnCancelRegister");
			btnCancelRegister.Name = "btnCancelRegister";
			btnCancelRegister.UseVisualStyleBackColor = true;
			btnCancelRegister.Click += new System.EventHandler(btnCancelRegister_Click);
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = btnCancel;
			base.Controls.Add(btnCancelRegister);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(txtRegisterCode);
			base.Controls.Add(label2);
			base.Controls.Add(label3);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgRegister";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgRegister_Load);
			ResumeLayout(false);
			PerformLayout();
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgRegister()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgRegister_Load(object sender, EventArgs e)
		{
			txtRegisterCode.Text = InputRegisterCode;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			string text = txtRegisterCode.Text.Trim();
			if (!string.IsNullOrEmpty(text))
			{
				InputRegisterCode = text;
				base.DialogResult = DialogResult.OK;
				Close();
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnCancelRegister_Click(object sender, EventArgs e)
		{
			WriterAppHost.smethod_1();
		}
	}
}
