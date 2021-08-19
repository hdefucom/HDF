using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       系统调试输出窗口
	///       </summary>
	[ComVisible(false)]
	public class frmSystemLog : Form
	{
		private IContainer icontainer_0 = null;

		private ToolStrip toolStrip1;

		private ToolStripButton txtSave;

		private TextBox txtLog;

		private ToolStripButton btnClear;

		private ToolStripSeparator toolStripSeparator1;

		private ToolStripButton btnStart;

		private ToolStripButton btnTopMost;

		private ToolStripButton btnHide;

		private GClass358 gclass358_0 = null;

		private static frmSystemLog frmSystemLog_0 = null;

		/// <summary>
		///       对象唯一静态实例
		///       </summary>
		public static frmSystemLog Instance
		{
			get
			{
				if (frmSystemLog_0 == null || frmSystemLog_0.IsDisposed)
				{
					frmSystemLog_0 = new frmSystemLog();
				}
				return frmSystemLog_0;
			}
		}

		public static bool IsVisible
		{
			get
			{
				if (frmSystemLog_0 != null && frmSystemLog_0.IsHandleCreated)
				{
					return frmSystemLog_0.Visible;
				}
				return false;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Commands.frmSystemLog));
			toolStrip1 = new System.Windows.Forms.ToolStrip();
			txtSave = new System.Windows.Forms.ToolStripButton();
			btnClear = new System.Windows.Forms.ToolStripButton();
			toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			btnStart = new System.Windows.Forms.ToolStripButton();
			btnTopMost = new System.Windows.Forms.ToolStripButton();
			btnHide = new System.Windows.Forms.ToolStripButton();
			txtLog = new System.Windows.Forms.TextBox();
			toolStrip1.SuspendLayout();
			SuspendLayout();
			toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[6]
			{
				txtSave,
				btnClear,
				toolStripSeparator1,
				btnStart,
				btnTopMost,
				btnHide
			});
			toolStrip1.Location = new System.Drawing.Point(0, 0);
			toolStrip1.Name = "toolStrip1";
			toolStrip1.Size = new System.Drawing.Size(747, 25);
			toolStrip1.TabIndex = 0;
			toolStrip1.Text = "toolStrip1";
			txtSave.AutoToolTip = false;
			txtSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			txtSave.Image = (System.Drawing.Image)resources.GetObject("txtSave.Image");
			txtSave.ImageTransparentColor = System.Drawing.Color.Magenta;
			txtSave.Name = "txtSave";
			txtSave.Size = new System.Drawing.Size(45, 22);
			txtSave.Text = "保存...";
			txtSave.Click += new System.EventHandler(txtSave_Click);
			btnClear.AutoToolTip = false;
			btnClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			btnClear.Image = (System.Drawing.Image)resources.GetObject("btnClear.Image");
			btnClear.ImageTransparentColor = System.Drawing.Color.Magenta;
			btnClear.Name = "btnClear";
			btnClear.Size = new System.Drawing.Size(36, 22);
			btnClear.Text = "清空";
			btnClear.Click += new System.EventHandler(btnClear_Click);
			toolStripSeparator1.Name = "toolStripSeparator1";
			toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			btnStart.Checked = true;
			btnStart.CheckOnClick = true;
			btnStart.CheckState = System.Windows.Forms.CheckState.Checked;
			btnStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			btnStart.Image = (System.Drawing.Image)resources.GetObject("btnStart.Image");
			btnStart.ImageTransparentColor = System.Drawing.Color.Magenta;
			btnStart.Name = "btnStart";
			btnStart.Size = new System.Drawing.Size(60, 22);
			btnStart.Text = "显示信息";
			btnStart.Click += new System.EventHandler(btnStart_Click);
			btnTopMost.AutoToolTip = false;
			btnTopMost.CheckOnClick = true;
			btnTopMost.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			btnTopMost.Image = (System.Drawing.Image)resources.GetObject("btnTopMost.Image");
			btnTopMost.ImageTransparentColor = System.Drawing.Color.Magenta;
			btnTopMost.Name = "btnTopMost";
			btnTopMost.Size = new System.Drawing.Size(72, 22);
			btnTopMost.Text = "最顶端显示";
			btnTopMost.Click += new System.EventHandler(btnTopMost_Click);
			btnHide.AutoToolTip = false;
			btnHide.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			btnHide.Image = (System.Drawing.Image)resources.GetObject("btnHide.Image");
			btnHide.ImageTransparentColor = System.Drawing.Color.Magenta;
			btnHide.Name = "btnHide";
			btnHide.Size = new System.Drawing.Size(36, 22);
			btnHide.Text = "隐藏";
			btnHide.Click += new System.EventHandler(btnHide_Click);
			txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
			txtLog.Location = new System.Drawing.Point(0, 25);
			txtLog.Multiline = true;
			txtLog.Name = "txtLog";
			txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			txtLog.Size = new System.Drawing.Size(747, 150);
			txtLog.TabIndex = 1;
			txtLog.WordWrap = false;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(747, 175);
			base.Controls.Add(txtLog);
			base.Controls.Add(toolStrip1);
			base.Name = "frmSystemLog";
			Text = "都昌软件系统调试输出";
			base.Load += new System.EventHandler(frmSystemLog_Load);
			toolStrip1.ResumeLayout(false);
			toolStrip1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		public frmSystemLog()
		{
			InitializeComponent();
			gclass358_0 = new GClass358(txtLog);
		}

		private void txtSave_Click(object sender, EventArgs e)
		{
			int num = 2;
			using (SaveFileDialog saveFileDialog = new SaveFileDialog())
			{
				saveFileDialog.Filter = "*.txt|*.txt";
				saveFileDialog.CheckPathExists = true;
				saveFileDialog.OverwritePrompt = true;
				if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
				{
					File.WriteAllText(saveFileDialog.FileName, txtLog.Text);
				}
			}
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			txtLog.Text = "";
		}

		private void btnStart_Click(object sender, EventArgs e)
		{
			gclass358_0.method_1(btnStart.Checked);
		}

		private void btnTopMost_Click(object sender, EventArgs e)
		{
			base.TopMost = btnTopMost.Checked;
		}

		private void btnHide_Click(object sender, EventArgs e)
		{
			Hide();
		}

		private void frmSystemLog_Load(object sender, EventArgs e)
		{
			gclass358_0.method_1(bool_3: true);
		}
	}
}
