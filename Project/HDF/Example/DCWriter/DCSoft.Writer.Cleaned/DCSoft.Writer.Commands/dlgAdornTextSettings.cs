using DCSoft.Writer.Dom;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       提示文本设置对话框
	///       </summary>
	[ComVisible(false)]
	public class dlgAdornTextSettings : Form
	{
		private DocumentViewOptions documentViewOptions_0 = null;

		private IContainer icontainer_0 = null;

		private Label label1;

		private Button btnOK;

		private Button btnCancel;

		private Label label2;

		private ListBox cboVisible;

		private ListBox cboDefaultType;

		/// <summary>
		///       文档视图相关操作
		///       </summary>
		public DocumentViewOptions ViewOptions
		{
			get
			{
				return documentViewOptions_0;
			}
			set
			{
				documentViewOptions_0 = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgAdornTextSettings()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgAdornTextSettings_Load(object sender, EventArgs e)
		{
			if (ViewOptions != null)
			{
				cboVisible.SelectedIndex = (int)ViewOptions.AdornTextVisibility;
				cboDefaultType.SelectedIndex = (int)ViewOptions.DefaultAdornTextType;
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (ViewOptions != null)
			{
				ViewOptions.AdornTextVisibility = (DCAdornTextVisibility)cboVisible.SelectedIndex;
				ViewOptions.DefaultAdornTextType = (InputFieldAdornTextType)cboDefaultType.SelectedIndex;
			}
			base.DialogResult = DialogResult.OK;
			Close();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Commands.dlgAdornTextSettings));
			label1 = new System.Windows.Forms.Label();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			label2 = new System.Windows.Forms.Label();
			cboVisible = new System.Windows.Forms.ListBox();
			cboDefaultType = new System.Windows.Forms.ListBox();
			SuspendLayout();
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.Name = "btnOK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			resources.ApplyResources(label2, "label2");
			label2.Name = "label2";
			cboVisible.FormattingEnabled = true;
			resources.ApplyResources(cboVisible, "cboVisible");
			cboVisible.Items.AddRange(new object[3]
			{
				resources.GetString("cboVisible.Items"),
				resources.GetString("cboVisible.Items1"),
				resources.GetString("cboVisible.Items2")
			});
			cboVisible.Name = "cboVisible";
			cboDefaultType.FormattingEnabled = true;
			resources.ApplyResources(cboDefaultType, "cboDefaultType");
			cboDefaultType.Items.AddRange(new object[8]
			{
				resources.GetString("cboDefaultType.Items"),
				resources.GetString("cboDefaultType.Items1"),
				resources.GetString("cboDefaultType.Items2"),
				resources.GetString("cboDefaultType.Items3"),
				resources.GetString("cboDefaultType.Items4"),
				resources.GetString("cboDefaultType.Items5"),
				resources.GetString("cboDefaultType.Items6"),
				resources.GetString("cboDefaultType.Items7")
			});
			cboDefaultType.Name = "cboDefaultType";
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = btnCancel;
			base.Controls.Add(cboDefaultType);
			base.Controls.Add(cboVisible);
			base.Controls.Add(label2);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgAdornTextSettings";
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgAdornTextSettings_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
