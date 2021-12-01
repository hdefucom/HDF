using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       段落内容排版对话框
	///       </summary>
	[ComVisible(false)]
	public class dlgLayoutDirection : Form
	{
		private IContainer icontainer_0 = null;

		private RadioButton rdoDefault;

		private RadioButton rdoLeftToRight;

		private RadioButton rdoRightToLeft;

		private Button btnOK;

		private Button btnCancel;

		/// <summary>
		///       内容排版样式
		///       </summary>
		public ContentLayoutDirectionStyle LayoutDirection
		{
			get
			{
				if (rdoDefault.Checked)
				{
					return ContentLayoutDirectionStyle.Default;
				}
				if (rdoLeftToRight.Checked)
				{
					return ContentLayoutDirectionStyle.LeftToRight;
				}
				if (rdoRightToLeft.Checked)
				{
					return ContentLayoutDirectionStyle.RightToLeft;
				}
				return ContentLayoutDirectionStyle.Default;
			}
			set
			{
				rdoDefault.Checked = (value == ContentLayoutDirectionStyle.Default);
				rdoLeftToRight.Checked = (value == ContentLayoutDirectionStyle.LeftToRight);
				rdoRightToLeft.Checked = (value == ContentLayoutDirectionStyle.RightToLeft);
			}
		}

		/// <summary>
		///       对象初始化
		///       </summary>
		public dlgLayoutDirection()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgLayoutDirection_Load(object sender, EventArgs e)
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Commands.dlgLayoutDirection));
			rdoDefault = new System.Windows.Forms.RadioButton();
			rdoLeftToRight = new System.Windows.Forms.RadioButton();
			rdoRightToLeft = new System.Windows.Forms.RadioButton();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			SuspendLayout();
			resources.ApplyResources(rdoDefault, "rdoDefault");
			rdoDefault.ImageKey = DCSoft.Writer.WriterStrings.Command_AlignBottomCenter;
			rdoDefault.Name = "rdoDefault";
			rdoDefault.TabStop = true;
			rdoDefault.UseVisualStyleBackColor = true;
			resources.ApplyResources(rdoLeftToRight, "rdoLeftToRight");
			rdoLeftToRight.ImageKey = DCSoft.Writer.WriterStrings.Command_AlignBottomCenter;
			rdoLeftToRight.Name = "rdoLeftToRight";
			rdoLeftToRight.TabStop = true;
			rdoLeftToRight.UseVisualStyleBackColor = true;
			resources.ApplyResources(rdoRightToLeft, "rdoRightToLeft");
			rdoRightToLeft.ImageKey = DCSoft.Writer.WriterStrings.Command_AlignBottomCenter;
			rdoRightToLeft.Name = "rdoRightToLeft";
			rdoRightToLeft.TabStop = true;
			rdoRightToLeft.UseVisualStyleBackColor = true;
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.ImageKey = DCSoft.Writer.WriterStrings.Command_AlignBottomCenter;
			btnOK.Name = "btnOK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			btnCancel.ImageKey = DCSoft.Writer.WriterStrings.Command_AlignBottomCenter;
			btnCancel.Name = "btnCancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			base.AcceptButton = btnOK;
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = btnCancel;
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(rdoRightToLeft);
			base.Controls.Add(rdoLeftToRight);
			base.Controls.Add(rdoDefault);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgLayoutDirection";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgLayoutDirection_Load);
			ResumeLayout(false);
		}
	}
}
