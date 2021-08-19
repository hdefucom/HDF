using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       文档内容保护模式窗体对象
	///       </summary>
	[ComVisible(false)]
	public class dlgContentProtectedMode : Form
	{
		private IContainer icontainer_0 = null;

		private RadioButton rdoNone;

		private RadioButton rdoContent;

		private RadioButton rdoRange;

		private Button btnOK;

		private Button btnCancel;

		private ContentProtectType contentProtectType_0 = ContentProtectType.None;

		/// <summary>
		///       文档内容保护类型
		///       </summary>
		public ContentProtectType ContentProtectType
		{
			get
			{
				return contentProtectType_0;
			}
			set
			{
				contentProtectType_0 = value;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Commands.dlgContentProtectedMode));
			rdoNone = new System.Windows.Forms.RadioButton();
			rdoContent = new System.Windows.Forms.RadioButton();
			rdoRange = new System.Windows.Forms.RadioButton();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			SuspendLayout();
			resources.ApplyResources(rdoNone, "rdoNone");
			rdoNone.Name = "rdoNone";
			rdoNone.TabStop = true;
			rdoNone.UseVisualStyleBackColor = true;
			resources.ApplyResources(rdoContent, "rdoContent");
			rdoContent.Name = "rdoContent";
			rdoContent.TabStop = true;
			rdoContent.UseVisualStyleBackColor = true;
			resources.ApplyResources(rdoRange, "rdoRange");
			rdoRange.Name = "rdoRange";
			rdoRange.TabStop = true;
			rdoRange.UseVisualStyleBackColor = true;
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
			base.Controls.Add(rdoRange);
			base.Controls.Add(rdoContent);
			base.Controls.Add(rdoNone);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgContentProtectedMode";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgContentProtectedMode_Load);
			ResumeLayout(false);
			PerformLayout();
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgContentProtectedMode()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgContentProtectedMode_Load(object sender, EventArgs e)
		{
			rdoNone.Checked = (contentProtectType_0 == ContentProtectType.None);
			rdoContent.Checked = (contentProtectType_0 == ContentProtectType.Content);
			rdoRange.Checked = (contentProtectType_0 == ContentProtectType.Range);
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (rdoNone.Checked)
			{
				contentProtectType_0 = ContentProtectType.None;
			}
			else if (rdoContent.Checked)
			{
				contentProtectType_0 = ContentProtectType.Content;
			}
			else
			{
				contentProtectType_0 = ContentProtectType.Range;
			}
			base.DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
