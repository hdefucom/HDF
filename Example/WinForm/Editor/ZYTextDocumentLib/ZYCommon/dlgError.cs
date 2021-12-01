using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace ZYCommon
{
	public class dlgError : Form
	{
		private Panel panel1;

		private Label label1;

		private Button cmdClose;

		private Container components = null;

		private Button cmdSend;

		private Label label2;

		private LinkLabel lnkViewXML;

		private ProgressBar prgSend;

		private Label lblMsg;

		public ZYErrorReport ErrorReport = null;

		public dlgError()
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
			panel1 = new System.Windows.Forms.Panel();
			label1 = new System.Windows.Forms.Label();
			lnkViewXML = new System.Windows.Forms.LinkLabel();
			cmdClose = new System.Windows.Forms.Button();
			cmdSend = new System.Windows.Forms.Button();
			label2 = new System.Windows.Forms.Label();
			prgSend = new System.Windows.Forms.ProgressBar();
			lblMsg = new System.Windows.Forms.Label();
			panel1.SuspendLayout();
			SuspendLayout();
			panel1.BackColor = System.Drawing.Color.White;
			panel1.Controls.Add(label1);
			panel1.Dock = System.Windows.Forms.DockStyle.Top;
			panel1.Location = new System.Drawing.Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(418, 64);
			panel1.TabIndex = 0;
			label1.BackColor = System.Drawing.Color.Transparent;
			label1.Font = new System.Drawing.Font("宋体", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label1.Location = new System.Drawing.Point(8, 8);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(384, 40);
			label1.TabIndex = 1;
			label1.Text = "    程序运行出现错误，可能是系统设置或者程序错误，请通知系统管理员或软件供应商,软件作者为此给带来的不方便表示歉意并将尽快处理。";
			lnkViewXML.AutoSize = true;
			lnkViewXML.LinkArea = new System.Windows.Forms.LinkArea(17, 6);
			lnkViewXML.Location = new System.Drawing.Point(8, 160);
			lnkViewXML.Name = "lnkViewXML";
			lnkViewXML.Size = new System.Drawing.Size(276, 17);
			lnkViewXML.TabIndex = 3;
			lnkViewXML.TabStop = true;
			lnkViewXML.Text = "要查看这个错误报告包含的数据，  请单击此处。";
			lnkViewXML.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(lnkViewXML_LinkClicked);
			cmdClose.Location = new System.Drawing.Point(336, 189);
			cmdClose.Name = "cmdClose";
			cmdClose.Size = new System.Drawing.Size(72, 23);
			cmdClose.TabIndex = 1;
			cmdClose.Text = "关闭(&C)";
			cmdClose.Click += new System.EventHandler(cmdClose_Click);
			cmdSend.Location = new System.Drawing.Point(216, 189);
			cmdSend.Name = "cmdSend";
			cmdSend.Size = new System.Drawing.Size(112, 23);
			cmdSend.TabIndex = 2;
			cmdSend.Text = "发送错误报告(&S)";
			cmdSend.Click += new System.EventHandler(cmdSend_Click);
			label2.Location = new System.Drawing.Point(8, 112);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(392, 40);
			label2.TabIndex = 11;
			label2.Text = "    程序已经创建了一个错误报告,建议你将该报告发送给我们以帮助我们改善本程序的质量。该报告不会包含你的隐私信息，而且承诺不会向第三方透露其内容。";
			prgSend.Location = new System.Drawing.Point(8, 192);
			prgSend.Name = "prgSend";
			prgSend.Size = new System.Drawing.Size(200, 16);
			prgSend.TabIndex = 12;
			prgSend.Visible = false;
			lblMsg.BackColor = System.Drawing.Color.Transparent;
			lblMsg.Font = new System.Drawing.Font("宋体", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			lblMsg.ForeColor = System.Drawing.Color.Red;
			lblMsg.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			lblMsg.Location = new System.Drawing.Point(16, 72);
			lblMsg.Name = "lblMsg";
			lblMsg.Size = new System.Drawing.Size(384, 33);
			lblMsg.TabIndex = 13;
			lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			base.ClientSize = new System.Drawing.Size(418, 215);
			base.Controls.Add(lblMsg);
			base.Controls.Add(prgSend);
			base.Controls.Add(label2);
			base.Controls.Add(cmdSend);
			base.Controls.Add(cmdClose);
			base.Controls.Add(lnkViewXML);
			base.Controls.Add(panel1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgError";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "系统错误报告";
			base.Load += new System.EventHandler(dlgError_Load);
			panel1.ResumeLayout(false);
			ResumeLayout(false);
		}

		private void dlgError_Load(object sender, EventArgs e)
		{
			if (ErrorReport != null)
			{
				label1.Text = "    $ 运行出现错误，可能是系统设置或者程序错误，请通知系统管理员或软件供应商,软件作者为此给带来的不方便表示歉意并将尽快处理。".Replace("$", ErrorReport.SystemName);
				label2.Text = "    程序已经创建了一个错误报告,建议你将该报告发送给我们以帮助我们改善 $ 的质量。该报告不会包含你的隐私信息，而且承诺不会向第三方透露其内容。".Replace("$", ErrorReport.SystemName);
				lblMsg.Text = ErrorReport.UserMessage;
			}
		}

		private void cmdClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void lnkViewXML_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (ErrorReport != null)
			{
				Cursor = Cursors.WaitCursor;
				XmlTextWriter xmlTextWriter = null;
				try
				{
					string text = Path.Combine(Application.StartupPath, "errrep.xml");
					StreamWriter w = new StreamWriter(text, append: false);
					xmlTextWriter = new XmlTextWriter(w);
					xmlTextWriter.Formatting = Formatting.Indented;
					xmlTextWriter.Indentation = 4;
					xmlTextWriter.IndentChar = ' ';
					ErrorReport.CreateReportXML(xmlTextWriter);
					xmlTextWriter.Close();
					string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "notepad.exe");
					Process.Start(fileName, text);
				}
				catch (Exception ex)
				{
					xmlTextWriter?.Close();
					MessageBox.Show(null, "生成报告XML文件错误\r\n" + ex.ToString(), "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				Cursor = Cursors.Default;
			}
		}

		private void cmdSend_Click(object sender, EventArgs e)
		{
			if (ErrorReport != null && StringCommon.HasContent(ErrorReport.ReportURL))
			{
				Cursor = Cursors.WaitCursor;
				try
				{
					ArrayList httpPostEncoding = XMLHttpConnection.GetHttpPostEncoding(PostReportData);
					Refresh();
					if (httpPostEncoding != null)
					{
						string s = ErrorReport.CreateReportXML(bolIndent: false);
						Encoding encoding = httpPostEncoding[0] as Encoding;
						byte[] bytes = encoding.GetBytes(s);
						byte[] bytes2 = PostReportData(bytes);
						encoding = (httpPostEncoding[1] as Encoding);
						string text = new string(encoding.GetChars(bytes2));
						MessageBox.Show(this, text, "发送错误报告完毕", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(this, "发送错误报告到 " + ErrorReport.ReportURL + " 错误！\r\n" + ex.ToString(), "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				prgSend.Visible = false;
				prgSend.Value = 0;
				Cursor = Cursors.Default;
			}
		}

		private void SetProgress(int Completed, int Total)
		{
			if (Completed < Total)
			{
				prgSend.Value = Completed;
				prgSend.Refresh();
			}
		}

		private byte[] PostReportData(byte[] bytSend)
		{
			if (ErrorReport != null && StringCommon.HasContent(ErrorReport.ReportURL))
			{
				prgSend.Value = 0;
				prgSend.Visible = true;
				prgSend.Maximum = bytSend.Length;
				byte[] result = CommonFunction.HttpPostData(ErrorReport.ReportURL, bytSend, SetProgress, null);
				prgSend.Value = 0;
				prgSend.Visible = false;
				return result;
			}
			return null;
		}
	}
}
