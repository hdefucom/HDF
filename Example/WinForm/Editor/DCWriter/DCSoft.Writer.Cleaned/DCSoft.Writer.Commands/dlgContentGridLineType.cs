using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       设置网格线样式的对话框
	///       </summary>
	[ComVisible(false)]
	public class dlgContentGridLineType : Form
	{
		private ContentGridLineType contentGridLineType_0 = ContentGridLineType.None;

		private IContainer icontainer_0 = null;

		private RadioButton rdoNone;

		private RadioButton rdoDisplay;

		private RadioButton rdoExtentToBottom;

		private Button btnOK;

		private Button btnCancel;

		/// <summary>
		///       网格线样式
		///       </summary>
		public ContentGridLineType GridLineType
		{
			get
			{
				return contentGridLineType_0;
			}
			set
			{
				contentGridLineType_0 = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgContentGridLineType()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgContentGridLineType_Load(object sender, EventArgs e)
		{
			rdoNone.Checked = (GridLineType == ContentGridLineType.None);
			rdoDisplay.Checked = (GridLineType == ContentGridLineType.Display);
			rdoExtentToBottom.Checked = (GridLineType == ContentGridLineType.ExtentToBottom);
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (rdoNone.Checked)
			{
				GridLineType = ContentGridLineType.None;
			}
			else if (rdoDisplay.Checked)
			{
				GridLineType = ContentGridLineType.Display;
			}
			else if (rdoExtentToBottom.Checked)
			{
				GridLineType = ContentGridLineType.ExtentToBottom;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Commands.dlgContentGridLineType));
			rdoNone = new System.Windows.Forms.RadioButton();
			rdoDisplay = new System.Windows.Forms.RadioButton();
			rdoExtentToBottom = new System.Windows.Forms.RadioButton();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			SuspendLayout();
			resources.ApplyResources(rdoNone, "rdoNone");
			rdoNone.Name = "rdoNone";
			rdoNone.UseVisualStyleBackColor = true;
			resources.ApplyResources(rdoDisplay, "rdoDisplay");
			rdoDisplay.Name = "rdoDisplay";
			rdoDisplay.UseVisualStyleBackColor = true;
			resources.ApplyResources(rdoExtentToBottom, "rdoExtentToBottom");
			rdoExtentToBottom.Name = "rdoExtentToBottom";
			rdoExtentToBottom.UseVisualStyleBackColor = true;
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
			base.Controls.Add(rdoExtentToBottom);
			base.Controls.Add(rdoDisplay);
			base.Controls.Add(rdoNone);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgContentGridLineType";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgContentGridLineType_Load);
			ResumeLayout(false);
		}
	}
}
