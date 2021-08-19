using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	[ComVisible(false)]
	public class dlgGlobalDebugConfig : Form
	{
		private IContainer icontainer_0 = null;

		private CheckBox chkEnable;

		private CheckBox chkRealTimeLoad;

		private CheckBox chkShowMessageWhenCreateControl;

		private Label label1;

		private TextBox txtFileName;

		private CheckBox chkShowMessageWhenDispose;

		private Button btnOK;

		private Button btnCancel;

		public dlgGlobalDebugConfig()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgGlobalDebugConfig_Load(object sender, EventArgs e)
		{
			chkEnable.Checked = GlobalDebugConfig.Instance.Enable;
			chkRealTimeLoad.Checked = GlobalDebugConfig.Instance.RealTimeLoad;
			chkShowMessageWhenCreateControl.Checked = GlobalDebugConfig.Instance.ShowMessageWhenCreateControl;
			chkShowMessageWhenDispose.Checked = GlobalDebugConfig.Instance.ShowMessageWhenDisposeControl;
			txtFileName.Text = GlobalDebugConfig.FileName;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			GlobalDebugConfig.Instance.Enable = chkEnable.Checked;
			GlobalDebugConfig.Instance.RealTimeLoad = chkRealTimeLoad.Checked;
			GlobalDebugConfig.Instance.ShowMessageWhenDisposeControl = chkShowMessageWhenDispose.Checked;
			GlobalDebugConfig.Instance.ShowMessageWhenCreateControl = chkShowMessageWhenCreateControl.Checked;
			GlobalDebugConfig.Instance.Save();
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
			chkEnable = new System.Windows.Forms.CheckBox();
			chkRealTimeLoad = new System.Windows.Forms.CheckBox();
			chkShowMessageWhenCreateControl = new System.Windows.Forms.CheckBox();
			label1 = new System.Windows.Forms.Label();
			txtFileName = new System.Windows.Forms.TextBox();
			chkShowMessageWhenDispose = new System.Windows.Forms.CheckBox();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			SuspendLayout();
			chkEnable.AutoSize = true;
			chkEnable.Location = new System.Drawing.Point(12, 51);
			chkEnable.Name = "chkEnable";
			chkEnable.Size = new System.Drawing.Size(84, 16);
			chkEnable.TabIndex = 0;
			chkEnable.Text = "启用本功能";
			chkEnable.UseVisualStyleBackColor = true;
			chkRealTimeLoad.AutoSize = true;
			chkRealTimeLoad.Location = new System.Drawing.Point(42, 87);
			chkRealTimeLoad.Name = "chkRealTimeLoad";
			chkRealTimeLoad.Size = new System.Drawing.Size(72, 16);
			chkRealTimeLoad.TabIndex = 0;
			chkRealTimeLoad.Text = "实时加载";
			chkRealTimeLoad.UseVisualStyleBackColor = true;
			chkShowMessageWhenCreateControl.AutoSize = true;
			chkShowMessageWhenCreateControl.Location = new System.Drawing.Point(42, 120);
			chkShowMessageWhenCreateControl.Name = "chkShowMessageWhenCreateControl";
			chkShowMessageWhenCreateControl.Size = new System.Drawing.Size(144, 16);
			chkShowMessageWhenCreateControl.TabIndex = 0;
			chkShowMessageWhenCreateControl.Text = "创建控件时显示消息框";
			chkShowMessageWhenCreateControl.UseVisualStyleBackColor = true;
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(13, 13);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(77, 12);
			label1.TabIndex = 1;
			label1.Text = "配置文件名：";
			txtFileName.Location = new System.Drawing.Point(88, 10);
			txtFileName.Name = "txtFileName";
			txtFileName.ReadOnly = true;
			txtFileName.Size = new System.Drawing.Size(318, 21);
			txtFileName.TabIndex = 2;
			chkShowMessageWhenDispose.AutoSize = true;
			chkShowMessageWhenDispose.Location = new System.Drawing.Point(42, 155);
			chkShowMessageWhenDispose.Name = "chkShowMessageWhenDispose";
			chkShowMessageWhenDispose.Size = new System.Drawing.Size(144, 16);
			chkShowMessageWhenDispose.TabIndex = 0;
			chkShowMessageWhenDispose.Text = "销毁控件时显示消息框";
			chkShowMessageWhenDispose.UseVisualStyleBackColor = true;
			btnOK.Location = new System.Drawing.Point(156, 285);
			btnOK.Name = "btnOK";
			btnOK.Size = new System.Drawing.Size(75, 23);
			btnOK.TabIndex = 3;
			btnOK.Text = "确定(&O)";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			btnCancel.Location = new System.Drawing.Point(252, 285);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(75, 23);
			btnCancel.TabIndex = 3;
			btnCancel.Text = "取消(&C)";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(418, 320);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(txtFileName);
			base.Controls.Add(label1);
			base.Controls.Add(chkShowMessageWhenDispose);
			base.Controls.Add(chkShowMessageWhenCreateControl);
			base.Controls.Add(chkRealTimeLoad);
			base.Controls.Add(chkEnable);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.ShowInTaskbar = false;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgGlobalDebugConfig";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "全局性调试选项";
			base.Load += new System.EventHandler(dlgGlobalDebugConfig_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
