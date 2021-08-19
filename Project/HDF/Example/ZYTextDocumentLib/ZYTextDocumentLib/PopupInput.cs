using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ZYTextDocumentLib
{
	public class PopupInput : Form
	{
		private Label label1;

		private TextBox txtInput;

		private Button cmdOk;

		private Button cmdCancel;

		private Container components = null;

		public PopupInput()
		{
			InitializeComponent();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			label1 = new System.Windows.Forms.Label();
			txtInput = new System.Windows.Forms.TextBox();
			cmdOk = new System.Windows.Forms.Button();
			cmdCancel = new System.Windows.Forms.Button();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(8, 8);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(54, 17);
			label1.TabIndex = 0;
			label1.Text = "输入名称";
			txtInput.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			txtInput.Location = new System.Drawing.Point(8, 32);
			txtInput.Name = "txtInput";
			txtInput.Size = new System.Drawing.Size(248, 21);
			txtInput.TabIndex = 1;
			txtInput.Text = "";
			cmdOk.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			cmdOk.Location = new System.Drawing.Point(104, 64);
			cmdOk.Name = "cmdOk";
			cmdOk.TabIndex = 2;
			cmdOk.Text = "确定(&O)";
			cmdCancel.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			cmdCancel.Location = new System.Drawing.Point(184, 64);
			cmdCancel.Name = "cmdCancel";
			cmdCancel.TabIndex = 3;
			cmdCancel.Text = "取消(&C)";
			AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			base.ClientSize = new System.Drawing.Size(266, 98);
			base.ControlBox = false;
			base.Controls.Add(cmdCancel);
			base.Controls.Add(cmdOk);
			base.Controls.Add(txtInput);
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "PopupInput";
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			ResumeLayout(false);
		}
	}
}
