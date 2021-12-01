using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.WinForms.Native
{
	/// <summary>
	///       URL地址输入对话框
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[ComVisible(false)]
	public class dlgInputUrl : Form
	{
		private string string_0 = null;

		private IContainer icontainer_0 = null;

		private Label label1;

		private ComboBox cboURL;

		private Button btnOK;

		private Button btnCancel;

		/// <summary>
		///       输入的URL地址
		///       </summary>
		public string InputURL
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

		public dlgInputUrl()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgInputUrl_Load(object sender, EventArgs e)
		{
			string[] array = GClass286.smethod_12();
			if (array != null)
			{
				cboURL.Items.AddRange(array);
			}
			cboURL.Text = string_0;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			string text = cboURL.Text;
			if (text.Trim().Length != 0)
			{
				string_0 = text;
				base.DialogResult = DialogResult.OK;
				Close();
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.WinForms.Native.dlgInputUrl));
			label1 = new System.Windows.Forms.Label();
			cboURL = new System.Windows.Forms.ComboBox();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			SuspendLayout();
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			cboURL.FormattingEnabled = true;
			resources.ApplyResources(cboURL, "cboURL");
			cboURL.Name = "cboURL";
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.Name = "btnOK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = btnCancel;
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(cboURL);
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgInputUrl";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgInputUrl_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
