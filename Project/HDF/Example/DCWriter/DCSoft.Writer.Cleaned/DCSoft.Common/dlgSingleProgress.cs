using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace DCSoft.Common
{
	                                                                    /// <summary>
	                                                                    ///       简单的后台任务等待对话框
	                                                                    ///       </summary>
	[ComVisible(false)]
	[DCInternal]
	public class dlgSingleProgress : Form
	{
		private delegate void MyVoidHandler();

		private Thread _Thread = null;

		private WinTaskBarProgressInfo _TBInfo = null;

		private object _DoWorkEventSender = null;

		private EventArgs _DoWorkEventArgs = null;

		                                                                    /// <summary>
		                                                                    ///       执行任务的委托
		                                                                    ///       </summary>
		public EventHandler EventDoWork = null;

		                                                                    /// <summary>
		                                                                    ///       Required designer variable.
		                                                                    ///       </summary>
		private IContainer components = null;

		private Label lblUserMessage;

		private ProgressBar progressBar1;

		                                                                    /// <summary>
		                                                                    ///       用户提示信息
		                                                                    ///       </summary>
		public string UserMessage
		{
			get
			{
				return lblUserMessage.Text;
			}
			set
			{
				lblUserMessage.Text = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       执行任务时的发起者
		                                                                    ///       </summary>
		public object DoWorkEventSender
		{
			get
			{
				return _DoWorkEventSender;
			}
			set
			{
				_DoWorkEventSender = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       执行任务时的参数
		                                                                    ///       </summary>
		public EventArgs DoWorkEventArgs
		{
			get
			{
				return _DoWorkEventArgs;
			}
			set
			{
				_DoWorkEventArgs = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       初始化对象
		                                                                    ///       </summary>
		public dlgSingleProgress()
		{
			InitializeComponent();
			_DoWorkEventSender = this;
		}

		private void dlgSingleProgress_Load(object sender, EventArgs e)
		{
			if (EventDoWork != null)
			{
				_Thread = new Thread(MyStart);
				_Thread.Priority = ThreadPriority.BelowNormal;
				_Thread.IsBackground = true;
				_Thread.Start();
				_TBInfo = new WinTaskBarProgressInfo(this, supportCrossUIThread: true);
				_TBInfo.SetIndeterminate();
			}
		}

		public void CompleteWork()
		{
			if (_TBInfo != null)
			{
				_TBInfo.EndProgress();
			}
		}

		private void MyStart()
		{
			if (EventDoWork != null)
			{
				EventDoWork(DoWorkEventSender, DoWorkEventArgs);
			}
			Invoke(new MyVoidHandler(base.Close), null);
		}

		                                                                    /// <summary>
		                                                                    ///       Clean up any resources being used.
		                                                                    ///       </summary>
		                                                                    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (_TBInfo != null)
			{
				_TBInfo.Dispose();
				_TBInfo = null;
			}
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		                                                                    /// <summary>
		                                                                    ///       Required method for Designer support - do not modify
		                                                                    ///       the contents of this method with the code editor.
		                                                                    ///       </summary>
		private void InitializeComponent()
		{
			lblUserMessage = new System.Windows.Forms.Label();
			progressBar1 = new System.Windows.Forms.ProgressBar();
			SuspendLayout();
			lblUserMessage.Font = new System.Drawing.Font("宋体", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			lblUserMessage.Location = new System.Drawing.Point(12, 22);
			lblUserMessage.Name = "lblUserMessage";
			lblUserMessage.Size = new System.Drawing.Size(443, 84);
			lblUserMessage.TabIndex = 0;
			lblUserMessage.Text = "正在执行操作，请稍候...";
			lblUserMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			progressBar1.Location = new System.Drawing.Point(16, 123);
			progressBar1.Name = "progressBar1";
			progressBar1.Size = new System.Drawing.Size(439, 23);
			progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
			progressBar1.TabIndex = 1;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(477, 167);
			base.ControlBox = false;
			base.Controls.Add(progressBar1);
			base.Controls.Add(lblUserMessage);
			Cursor = System.Windows.Forms.Cursors.WaitCursor;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgSingleProgress";
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			base.Load += new System.EventHandler(dlgSingleProgress_Load);
			ResumeLayout(false);
		}
	}
}
