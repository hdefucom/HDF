using DCSoft.Common;
using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DCSoft.WinForms
{
	/// <summary>
	///       dlgError 的摘要说明。
	///       </summary>
	public class dlgError : Form
	{
		/// <summary>
		///       对话框默认图标
		///       </summary>
		public static Icon DefaultIcon = null;

		/// <summary>
		///       对话框默认图片
		///       </summary>
		public static Image DefaultTitleImage = null;

		private Label label1;

		private Button cmdClose;

		/// <summary>
		///       必需的设计器变量。
		///       </summary>
		private Container components = null;

		private Button cmdSend;

		private Label label2;

		private LinkLabel lnkViewXML;

		private Label lblMsg;

		private Panel pnlTitle;

		private Label lblWait;

		public SystemDebugInfo DebugInfo = null;

		public dlgError()
		{
			InitializeComponent();
			if (DefaultIcon != null)
			{
				base.Icon = DefaultIcon;
			}
			if (DefaultTitleImage != null)
			{
				pnlTitle.BackgroundImage = DefaultTitleImage;
			}
		}

		/// <summary>
		///       清理所有正在使用的资源。
		///       </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		/// <summary>
		///       设计器支持所需的方法 - 不要使用代码编辑器修改
		///       此方法的内容。
		///       </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.WinForms.dlgError));
			pnlTitle = new System.Windows.Forms.Panel();
			label1 = new System.Windows.Forms.Label();
			lnkViewXML = new System.Windows.Forms.LinkLabel();
			cmdClose = new System.Windows.Forms.Button();
			cmdSend = new System.Windows.Forms.Button();
			label2 = new System.Windows.Forms.Label();
			lblMsg = new System.Windows.Forms.Label();
			lblWait = new System.Windows.Forms.Label();
			pnlTitle.SuspendLayout();
			SuspendLayout();
			pnlTitle.AccessibleDescription = null;
			pnlTitle.AccessibleName = null;
			resources.ApplyResources(pnlTitle, "pnlTitle");
			pnlTitle.BackColor = System.Drawing.Color.White;
			pnlTitle.Controls.Add(label1);
			pnlTitle.Font = null;
			pnlTitle.Name = "pnlTitle";
			label1.AccessibleDescription = null;
			label1.AccessibleName = null;
			resources.ApplyResources(label1, "label1");
			label1.BackColor = System.Drawing.Color.Transparent;
			label1.Name = "label1";
			lnkViewXML.AccessibleDescription = null;
			lnkViewXML.AccessibleName = null;
			resources.ApplyResources(lnkViewXML, "lnkViewXML");
			lnkViewXML.Font = null;
			lnkViewXML.Name = "lnkViewXML";
			lnkViewXML.TabStop = true;
			lnkViewXML.UseCompatibleTextRendering = true;
			lnkViewXML.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(lnkViewXML_LinkClicked);
			cmdClose.AccessibleDescription = null;
			cmdClose.AccessibleName = null;
			resources.ApplyResources(cmdClose, "cmdClose");
			cmdClose.BackgroundImage = null;
			cmdClose.Font = null;
			cmdClose.Name = "cmdClose";
			cmdClose.Click += new System.EventHandler(cmdClose_Click);
			cmdSend.AccessibleDescription = null;
			cmdSend.AccessibleName = null;
			resources.ApplyResources(cmdSend, "cmdSend");
			cmdSend.BackgroundImage = null;
			cmdSend.Font = null;
			cmdSend.Name = "cmdSend";
			cmdSend.Click += new System.EventHandler(cmdSend_Click);
			label2.AccessibleDescription = null;
			label2.AccessibleName = null;
			resources.ApplyResources(label2, "label2");
			label2.Font = null;
			label2.Name = "label2";
			lblMsg.AccessibleDescription = null;
			lblMsg.AccessibleName = null;
			resources.ApplyResources(lblMsg, "lblMsg");
			lblMsg.BackColor = System.Drawing.Color.Transparent;
			lblMsg.ForeColor = System.Drawing.Color.Red;
			lblMsg.Name = "lblMsg";
			lblWait.AccessibleDescription = null;
			lblWait.AccessibleName = null;
			resources.ApplyResources(lblWait, "lblWait");
			lblWait.Font = null;
			lblWait.ForeColor = System.Drawing.Color.Red;
			lblWait.Name = "lblWait";
			base.AccessibleDescription = null;
			base.AccessibleName = null;
			resources.ApplyResources(this, "$this");
			BackgroundImage = null;
			base.Controls.Add(lblWait);
			base.Controls.Add(lnkViewXML);
			base.Controls.Add(lblMsg);
			base.Controls.Add(label2);
			base.Controls.Add(cmdSend);
			base.Controls.Add(cmdClose);
			base.Controls.Add(pnlTitle);
			Font = null;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgError";
			base.Load += new System.EventHandler(dlgError_Load);
			pnlTitle.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		private void dlgError_Load(object sender, EventArgs e)
		{
			if (DebugInfo != null)
			{
				lblMsg.Text = DebugInfo.UserMessage;
				cmdSend.Visible = DebugInfo.IsReportURLOK;
			}
		}

		private void cmdClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void lnkViewXML_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			int num = 4;
			if (DebugInfo != null)
			{
				Cursor = Cursors.WaitCursor;
				try
				{
					string text = Path.Combine(Application.StartupPath, "error_report.xml");
					DebugInfo.Save(text);
					Process.Start("notepad.exe", text);
				}
				catch (Exception ex)
				{
					GClass252.smethod_9(this, "生成报告XML文件错误\r\n" + ex.ToString());
				}
				Cursor = Cursors.Default;
			}
		}

		private void cmdSend_Click(object sender, EventArgs e)
		{
			int num = 7;
			if (DebugInfo != null && StringFormatHelper.HasContent(DebugInfo.ReportURL))
			{
				lblWait.Visible = true;
				Cursor = Cursors.WaitCursor;
				Update();
				try
				{
					if (DebugInfo.SendReport())
					{
						GClass252.smethod_7(this, "成功的发送报告 " + DebugInfo.ReportURL);
					}
					else
					{
						GClass252.smethod_7(this, "发送报告时失败!");
					}
				}
				catch (Exception ex)
				{
					GClass252.smethod_9(this, "发送报告时发生错误:" + ex.Message);
				}
				lblWait.Visible = false;
				Cursor = Cursors.Default;
				Update();
			}
		}
	}
}
