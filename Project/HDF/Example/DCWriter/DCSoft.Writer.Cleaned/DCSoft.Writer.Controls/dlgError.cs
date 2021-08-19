using DCSoft.Common;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       dlgError 的摘要说明。
	///       </summary>
	[ComVisible(false)]
	[DCInternal]
	public class dlgError : Form
	{
		private Panel panel1;

		private Label label1;

		private Button cmdClose;

		private Container container_0 = null;

		private PictureBox picImg;

		private Button cmdSend;

		private Label label2;

		private TextBox lblMsg;

		private Button btnViewDetails;

		private TextBox txtStack;

		private Label label3;

		private ErrorReportInfo errorReportInfo_0 = null;

		private static dlgError dlgError_0 = null;

		/// <summary>
		///       错误报告信息
		///       </summary>
		public ErrorReportInfo ReportInfo
		{
			get
			{
				return errorReportInfo_0;
			}
			set
			{
				errorReportInfo_0 = value;
			}
		}

		/// <summary>
		///       当前显示的错误对话框窗体句柄值
		///       </summary>
		public static IntPtr CurrentInstanceHandle
		{
			get
			{
				if (dlgError_0 != null && dlgError_0.IsHandleCreated)
				{
					return dlgError_0.Handle;
				}
				return IntPtr.Zero;
			}
		}

		/// <summary>
		///       当前显示的错误对话框对象
		///       </summary>
		public static dlgError CurrentInstance => dlgError_0;

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgError()
		{
			InitializeComponent();
			dlgError_0 = this;
		}

		/// <summary>
		///       清理所有正在使用的资源。
		///       </summary>
		protected override void Dispose(bool disposing)
		{
			dlgError_0 = null;
			if (disposing && container_0 != null)
			{
				container_0.Dispose();
			}
			base.Dispose(disposing);
		}

		/// <summary>
		///       设计器支持所需的方法 - 不要使用代码编辑器修改
		///       此方法的内容。
		///       </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Controls.dlgError));
			panel1 = new System.Windows.Forms.Panel();
			picImg = new System.Windows.Forms.PictureBox();
			label1 = new System.Windows.Forms.Label();
			cmdClose = new System.Windows.Forms.Button();
			cmdSend = new System.Windows.Forms.Button();
			label2 = new System.Windows.Forms.Label();
			lblMsg = new System.Windows.Forms.TextBox();
			btnViewDetails = new System.Windows.Forms.Button();
			txtStack = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)picImg).BeginInit();
			SuspendLayout();
			panel1.BackColor = System.Drawing.Color.White;
			panel1.Controls.Add(picImg);
			panel1.Controls.Add(label1);
			resources.ApplyResources(panel1, "panel1");
			panel1.Name = "panel1";
			resources.ApplyResources(picImg, "picImg");
			picImg.Name = "picImg";
			picImg.TabStop = false;
			label1.BackColor = System.Drawing.Color.Transparent;
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			resources.ApplyResources(cmdClose, "cmdClose");
			cmdClose.Name = "cmdClose";
			cmdClose.Click += new System.EventHandler(cmdClose_Click);
			resources.ApplyResources(cmdSend, "cmdSend");
			cmdSend.Name = "cmdSend";
			cmdSend.Click += new System.EventHandler(cmdSend_Click);
			resources.ApplyResources(label2, "label2");
			label2.Name = "label2";
			lblMsg.BackColor = System.Drawing.Color.Gainsboro;
			lblMsg.BorderStyle = System.Windows.Forms.BorderStyle.None;
			resources.ApplyResources(lblMsg, "lblMsg");
			lblMsg.ForeColor = System.Drawing.Color.Red;
			lblMsg.Name = "lblMsg";
			lblMsg.ReadOnly = true;
			resources.ApplyResources(btnViewDetails, "btnViewDetails");
			btnViewDetails.Name = "btnViewDetails";
			btnViewDetails.UseVisualStyleBackColor = true;
			btnViewDetails.Click += new System.EventHandler(btnViewDetails_Click);
			resources.ApplyResources(txtStack, "txtStack");
			txtStack.Name = "txtStack";
			txtStack.ReadOnly = true;
			resources.ApplyResources(label3, "label3");
			label3.Name = "label3";
			resources.ApplyResources(this, "$this");
			base.CancelButton = cmdClose;
			base.Controls.Add(label2);
			base.Controls.Add(txtStack);
			base.Controls.Add(label3);
			base.Controls.Add(btnViewDetails);
			base.Controls.Add(lblMsg);
			base.Controls.Add(cmdSend);
			base.Controls.Add(cmdClose);
			base.Controls.Add(panel1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgError";
			base.Load += new System.EventHandler(dlgError_Load);
			panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)picImg).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		private void dlgError_Load(object sender, EventArgs e)
		{
			if (ReportInfo != null)
			{
				lblMsg.Text = ReportInfo.UserMessage;
				if (!string.IsNullOrEmpty(ReportInfo.ExceptionString))
				{
					txtStack.Text = ReportInfo.ExceptionString;
				}
				else if (!string.IsNullOrEmpty(ReportInfo.SystemMessage))
				{
					txtStack.Text = ReportInfo.SystemMessage;
				}
			}
			cmdSend.Visible = !string.IsNullOrEmpty(ErrorReporter.ReportServiceUrl);
		}

		private void cmdClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void cmdSend_Click(object sender, EventArgs e)
		{
			int num = 0;
			if (ReportInfo != null && string.IsNullOrEmpty(ErrorReporter.ReportServiceUrl))
			{
				Cursor = Cursors.WaitCursor;
				try
				{
					using (WebClient webClient = new WebClient())
					{
						string text = webClient.UploadString(ErrorReporter.ReportServiceUrl, "POST", ReportInfo.ToString());
						MessageBox.Show(this, text, Text);
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(this, ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				Cursor = Cursors.Default;
			}
		}

		private void btnViewDetails_Click(object sender, EventArgs e)
		{
			if (ReportInfo != null)
			{
				using (dlgErrorViewSource dlgErrorViewSource = new dlgErrorViewSource())
				{
					dlgErrorViewSource.ReportSource = ReportInfo.ToXMLString();
					dlgErrorViewSource.ShowDialog(this);
				}
			}
		}
	}
}
