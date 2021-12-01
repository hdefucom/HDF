using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       RTF文档内容编辑对话框
	///       </summary>
	[ComVisible(false)]
	public class dlgInputRTF : Form
	{
		private IContainer icontainer_0 = null;

		private Label label1;

		private RichTextBox txtInputText;

		private Button btnOK;

		private Button btnCancel;

		/// <summary>
		///       RTF内容
		///       </summary>
		public string InputRTFText
		{
			get
			{
				return txtInputText.Rtf;
			}
			set
			{
				txtInputText.Rtf = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgInputRTF()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Commands.dlgInputRTF));
			label1 = new System.Windows.Forms.Label();
			txtInputText = new System.Windows.Forms.RichTextBox();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			SuspendLayout();
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			txtInputText.AcceptsTab = true;
			resources.ApplyResources(txtInputText, "txtInputText");
			txtInputText.Name = "txtInputText";
			txtInputText.Text = DCSoft.Writer.WriterStrings.Command_AlignBottomCenter;
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
			base.Controls.Add(txtInputText);
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgInputRTF";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
