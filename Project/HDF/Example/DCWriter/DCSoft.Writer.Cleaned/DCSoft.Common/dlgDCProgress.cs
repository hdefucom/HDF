using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace DCSoft.Common
{
	                                                                    /// <summary>
	                                                                    ///       进度对话框
	                                                                    ///       </summary>
	[ComVisible(false)]
	public class dlgDCProgress : Form
	{
		private delegate void Delegate2();

		private IContainer icontainer_0 = null;

		private Label lblMessage;

		private ProgressBar myProgressBar;

		private Button btnCancel;

		private System.Windows.Forms.Timer timer_0;

		private volatile bool bool_0 = false;

		private volatile bool bool_1 = false;

		public DCDoWorkEventHandler DoWorkHandler = null;

		private volatile bool bool_2 = true;

		private Thread thread_0 = null;

		                                                                    /// <summary>
		                                                                    ///       当进度结束，自动关闭窗口
		                                                                    ///       </summary>
		public bool AutoClose
		{
			get
			{
				return bool_0;
			}
			set
			{
				bool_0 = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       使用后台线程
		                                                                    ///       </summary>
		[DefaultValue(true)]
		public bool UseThread
		{
			get
			{
				return bool_2;
			}
			set
			{
				bool_2 = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       是否显示取消按钮
		                                                                    ///       </summary>
		public bool ShowCancelButton
		{
			get
			{
				return btnCancel.Visible;
			}
			set
			{
				btnCancel.Visible = value;
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
			icontainer_0 = new System.ComponentModel.Container();
			lblMessage = new System.Windows.Forms.Label();
			myProgressBar = new System.Windows.Forms.ProgressBar();
			btnCancel = new System.Windows.Forms.Button();
			timer_0 = new System.Windows.Forms.Timer(icontainer_0);
			SuspendLayout();
			lblMessage.Dock = System.Windows.Forms.DockStyle.Top;
			lblMessage.Location = new System.Drawing.Point(0, 0);
			lblMessage.Name = "lblMessage";
			lblMessage.Size = new System.Drawing.Size(380, 56);
			lblMessage.TabIndex = 0;
			lblMessage.Text = "           ";
			lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			myProgressBar.Location = new System.Drawing.Point(13, 69);
			myProgressBar.Name = "myProgressBar";
			myProgressBar.Size = new System.Drawing.Size(355, 18);
			myProgressBar.TabIndex = 1;
			btnCancel.Location = new System.Drawing.Point(253, 102);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(102, 23);
			btnCancel.TabIndex = 2;
			btnCancel.Text = "取消";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			timer_0.Tick += new System.EventHandler(timer_0_Tick);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(380, 137);
			base.Controls.Add(btnCancel);
			base.Controls.Add(myProgressBar);
			base.Controls.Add(lblMessage);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgDCProgress";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "正在执行操作";
			base.Load += new System.EventHandler(dlgDCProgress_Load);
			ResumeLayout(false);
		}

		                                                                    /// <summary>
		                                                                    ///       初始化对象
		                                                                    ///       </summary>
		public dlgDCProgress()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void method_0(object sender, DCProgressEventArgs e)
		{
			if (UseThread)
			{
				DCProgressEventHandler method = method_1;
				Invoke(method, sender, e);
			}
			else
			{
				method_1(sender, e);
			}
		}

		private void method_1(object sender, DCProgressEventArgs e)
		{
			if (e.State == DCProgressStates.Begin)
			{
				lblMessage.Text = e.Message;
				myProgressBar.Value = 0;
				myProgressBar.Maximum = e.Max;
			}
			else if (e.State == DCProgressStates.Progress)
			{
				lblMessage.Text = e.Message;
				if (e.Value > e.Max)
				{
					if (myProgressBar.Style != ProgressBarStyle.Marquee)
					{
						myProgressBar.Style = ProgressBarStyle.Marquee;
					}
				}
				else
				{
					myProgressBar.Maximum = e.Max;
					myProgressBar.Value = e.Value;
					if (myProgressBar.Style != ProgressBarStyle.Continuous)
					{
						myProgressBar.Style = ProgressBarStyle.Continuous;
					}
				}
				e.Cancel = bool_1;
				if (!UseThread)
				{
					Application.DoEvents();
				}
			}
			else if (e.State == DCProgressStates.Finish && AutoClose)
			{
				Close();
				if (!bool_1)
				{
					base.DialogResult = DialogResult.OK;
				}
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			bool_1 = true;
		}

		private void dlgDCProgress_Load(object sender, EventArgs e)
		{
			if (DoWorkHandler != null)
			{
				timer_0.Start();
			}
		}

		                                                                    /// <summary>
		                                                                    ///       创建处理进度信息的委托对象
		                                                                    ///       </summary>
		                                                                    /// <returns>创建的委托对象</returns>
		public DCProgressEventHandler CreateProgressEventHandler()
		{
			return method_0;
		}

		private void timer_0_Tick(object sender, EventArgs e)
		{
			timer_0.Stop();
			if (DoWorkHandler != null)
			{
				if (UseThread)
				{
					ThreadStart start = delegate
					{
						DoWorkHandler(this, CreateProgressEventHandler());
						Invoke(new Delegate2(base.Close));
					};
					thread_0 = new Thread(start);
					thread_0.Start();
				}
				else
				{
					DoWorkHandler(this, CreateProgressEventHandler());
					Close();
				}
			}
		}

		public static void DoWorkWithProgress(IWin32Window parent, DCDoWorkEventHandler handler)
		{
			if (handler != null)
			{
				using (dlgDCProgress dlgDCProgress = new dlgDCProgress())
				{
					dlgDCProgress.DoWorkHandler = handler;
					if (parent != null)
					{
						dlgDCProgress.ShowInTaskbar = false;
					}
					dlgDCProgress.ShowDialog(parent);
				}
			}
		}

		[CompilerGenerated]
		private void method_2()
		{
			DoWorkHandler(this, CreateProgressEventHandler());
			Invoke(new Delegate2(base.Close));
		}
	}
}
