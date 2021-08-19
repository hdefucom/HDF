using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Common
{
	                                                                    /// <summary>
	                                                                    ///       显示调试输出内容的窗口
	                                                                    ///       </summary>
	                                                                    /// <remarks>编制 袁永福</remarks>
	[ComVisible(false)]
	public class frmDebugOutput : Form
	{
		private GClass358 gclass358_0 = null;

		private IContainer icontainer_0 = null;

		private TextBox txtOutput;

		private ToolStrip toolStrip1;

		private ToolStripButton btnWordWrap;

		private ToolStripButton btnClear;

		                                                                    /// <summary>
		                                                                    ///       是否显示时间戳
		                                                                    ///       </summary>
		public bool ShowTimeStamp
		{
			get
			{
				return gclass358_0.method_4();
			}
			set
			{
				gclass358_0.method_5(value);
			}
		}

		                                                                    /// <summary>
		                                                                    ///       时间戳格式化字符串
		                                                                    ///       </summary>
		public string TimeStampFormat
		{
			get
			{
				return gclass358_0.method_6();
			}
			set
			{
				gclass358_0.method_7(value);
			}
		}

		                                                                    /// <summary>
		                                                                    ///       是否监听调试输出信息
		                                                                    ///       </summary>
		public bool EnableListenDebugOutput
		{
			get
			{
				return gclass358_0.method_0();
			}
			set
			{
				gclass358_0.method_1(value);
			}
		}

		                                                                    /// <summary>
		                                                                    ///       初始化对象
		                                                                    ///       </summary>
		public frmDebugOutput()
		{
			InitializeComponent();
		}

		private void frmDebugOutput_Load(object sender, EventArgs e)
		{
			gclass358_0 = new GClass358(txtOutput);
			gclass358_0.method_1(bool_3: true);
			gclass358_0.method_5(bool_3: true);
			gclass358_0.method_7("HH:mm:ss.fff|");
		}

		private void frmDebugOutput_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (gclass358_0 != null)
			{
				gclass358_0.method_1(bool_3: false);
			}
		}

		private void btnWordWrap_Click(object sender, EventArgs e)
		{
			txtOutput.WordWrap = btnWordWrap.Checked;
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			txtOutput.Text = "";
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Common.frmDebugOutput));
			txtOutput = new System.Windows.Forms.TextBox();
			toolStrip1 = new System.Windows.Forms.ToolStrip();
			btnWordWrap = new System.Windows.Forms.ToolStripButton();
			btnClear = new System.Windows.Forms.ToolStripButton();
			toolStrip1.SuspendLayout();
			SuspendLayout();
			resources.ApplyResources(txtOutput, "txtOutput");
			txtOutput.Name = "txtOutput";
			txtOutput.ReadOnly = true;
			toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[2]
			{
				btnWordWrap,
				btnClear
			});
			resources.ApplyResources(toolStrip1, "toolStrip1");
			toolStrip1.Name = "toolStrip1";
			btnWordWrap.CheckOnClick = true;
			resources.ApplyResources(btnWordWrap, "btnWordWrap");
			btnWordWrap.Name = "btnWordWrap";
			btnWordWrap.Click += new System.EventHandler(btnWordWrap_Click);
			resources.ApplyResources(btnClear, "btnClear");
			btnClear.Name = "btnClear";
			btnClear.Click += new System.EventHandler(btnClear_Click);
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(txtOutput);
			base.Controls.Add(toolStrip1);
			base.MinimizeBox = false;
			base.Name = "frmDebugOutput";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(frmDebugOutput_FormClosing);
			base.Load += new System.EventHandler(frmDebugOutput_Load);
			toolStrip1.ResumeLayout(false);
			toolStrip1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
