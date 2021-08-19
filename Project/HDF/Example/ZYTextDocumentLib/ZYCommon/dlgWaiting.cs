using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ZYCommon
{
	public class dlgWaiting : Form
	{
		private Label lblTitle;

		private Button cmdCancel;

		private Container components = null;

		public bool ShowCancelButton
		{
			get
			{
				return cmdCancel.Visible;
			}
			set
			{
				cmdCancel.Visible = value;
			}
		}

		public dlgWaiting()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.OK;
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
			lblTitle = new System.Windows.Forms.Label();
			cmdCancel = new System.Windows.Forms.Button();
			SuspendLayout();
			lblTitle.AutoSize = true;
			lblTitle.Font = new System.Drawing.Font("宋体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			lblTitle.ForeColor = System.Drawing.Color.Red;
			lblTitle.Location = new System.Drawing.Point(8, 8);
			lblTitle.Name = "lblTitle";
			lblTitle.Size = new System.Drawing.Size(164, 19);
			lblTitle.TabIndex = 0;
			lblTitle.Text = "系统正在运行,请稍候...";
			cmdCancel.Location = new System.Drawing.Point(256, 40);
			cmdCancel.Name = "cmdCancel";
			cmdCancel.TabIndex = 1;
			cmdCancel.Text = "取消(&C)";
			cmdCancel.Visible = false;
			cmdCancel.Click += new System.EventHandler(cmdCancel_Click);
			AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			base.ClientSize = new System.Drawing.Size(354, 71);
			base.ControlBox = false;
			base.Controls.Add(cmdCancel);
			base.Controls.Add(lblTitle);
			ForeColor = System.Drawing.SystemColors.WindowText;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "dlgWaiting";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "系统提示";
			ResumeLayout(false);
		}

		private void cmdCancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
			Close();
		}
	}
}
