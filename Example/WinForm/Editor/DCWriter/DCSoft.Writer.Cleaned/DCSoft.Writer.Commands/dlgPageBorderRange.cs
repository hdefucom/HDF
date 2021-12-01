using DCSoft.Drawing;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       页面边框范围对话框
	///       </summary>
	[ComVisible(false)]
	public class dlgPageBorderRange : Form
	{
		private IContainer icontainer_0 = null;

		private RadioButton rdoPage;

		private RadioButton rdoBody;

		private Button btnOK;

		private Button btnCancel;

		private PageBorderBackgroundStyle pageBorderBackgroundStyle_0 = null;

		/// <summary>
		///       页面边框范围
		///       </summary>
		public PageBorderBackgroundStyle InputStyle
		{
			get
			{
				return pageBorderBackgroundStyle_0;
			}
			set
			{
				pageBorderBackgroundStyle_0 = value;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Commands.dlgPageBorderRange));
			rdoPage = new System.Windows.Forms.RadioButton();
			rdoBody = new System.Windows.Forms.RadioButton();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			SuspendLayout();
			resources.ApplyResources(rdoPage, "rdoPage");
			rdoPage.Name = "rdoPage";
			rdoPage.TabStop = true;
			rdoPage.UseVisualStyleBackColor = true;
			resources.ApplyResources(rdoBody, "rdoBody");
			rdoBody.Name = "rdoBody";
			rdoBody.TabStop = true;
			rdoBody.UseVisualStyleBackColor = true;
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.Name = "btnOK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			base.AcceptButton = btnOK;
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = btnCancel;
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(rdoBody);
			base.Controls.Add(rdoPage);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgPageBorderRange";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgPageBorderRange_Load);
			ResumeLayout(false);
			PerformLayout();
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgPageBorderRange()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgPageBorderRange_Load(object sender, EventArgs e)
		{
			if (InputStyle != null)
			{
				rdoPage.Checked = (InputStyle.BorderRange == PageBorderRangeTypes.Page);
				rdoBody.Checked = (InputStyle.BorderRange == PageBorderRangeTypes.Body);
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (InputStyle != null)
			{
				if (rdoBody.Checked)
				{
					InputStyle.BorderRange = PageBorderRangeTypes.Body;
				}
				else if (rdoPage.Checked)
				{
					InputStyle.BorderRange = PageBorderRangeTypes.Page;
				}
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
