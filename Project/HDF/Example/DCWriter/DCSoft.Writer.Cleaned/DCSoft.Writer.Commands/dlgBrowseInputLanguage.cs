using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       选择语言对话框
	///       </summary>
	[ComVisible(false)]
	public class dlgBrowseInputLanguage : Form
	{
		private IContainer icontainer_0 = null;

		private ListBox lstLanguage;

		private Button btnOK;

		private Button btnCancel;

		private InputLanguage inputLanguage_0 = null;

		/// <summary>
		///       选择的语言
		///       </summary>
		public InputLanguage SelectedInputLanugae
		{
			get
			{
				return inputLanguage_0;
			}
			set
			{
				inputLanguage_0 = value;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Commands.dlgBrowseInputLanguage));
			lstLanguage = new System.Windows.Forms.ListBox();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			SuspendLayout();
			resources.ApplyResources(lstLanguage, "lstLanguage");
			lstLanguage.FormattingEnabled = true;
			lstLanguage.Name = "lstLanguage";
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.Name = "btnOK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(lstLanguage);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgBrowseInputLanguage";
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgBrowseInputLanguage_Load);
			ResumeLayout(false);
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgBrowseInputLanguage()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgBrowseInputLanguage_Load(object sender, EventArgs e)
		{
			lstLanguage.DisplayMember = "LayoutName ";
			foreach (InputLanguage installedInputLanguage in InputLanguage.InstalledInputLanguages)
			{
				lstLanguage.Items.Add(installedInputLanguage);
			}
			lstLanguage.SelectedItem = SelectedInputLanugae;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (lstLanguage.SelectedItem != null)
			{
				SelectedInputLanugae = (InputLanguage)lstLanguage.SelectedItem;
				base.DialogResult = DialogResult.OK;
				Close();
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
