using DCSoft.Common;
using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       执行跨进程承载控件的窗口
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[ComVisible(false)]
	
	public class dlgCrosssPrecessHost : Form
	{
		private IContainer icontainer_0 = null;

		private Label lblTitle;

		private Timer timer_0;

		private Label lblStatus;

		private IntPtr intptr_0 = IntPtr.Zero;

		private Control control_0 = null;

		private GClass271 gclass271_0 = null;

		/// <summary>
		///       承载控件的容器控件句柄
		///       </summary>
		public IntPtr HostContainerHandle
		{
			get
			{
				return intptr_0;
			}
			set
			{
				intptr_0 = value;
			}
		}

		/// <summary>
		///       被跨进程承载的WinForm控件对象
		///       </summary>
		public Control HostedControl
		{
			get
			{
				return control_0;
			}
			set
			{
				control_0 = value;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Controls.dlgCrosssPrecessHost));
			lblTitle = new System.Windows.Forms.Label();
			timer_0 = new System.Windows.Forms.Timer(icontainer_0);
			lblStatus = new System.Windows.Forms.Label();
			SuspendLayout();
			resources.ApplyResources(lblTitle, "lblTitle");
			lblTitle.Name = "lblTitle";
			timer_0.Interval = 1000;
			timer_0.Tick += new System.EventHandler(timer_0_Tick);
			lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			resources.ApplyResources(lblStatus, "lblStatus");
			lblStatus.Name = "lblStatus";
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(lblStatus);
			base.Controls.Add(lblTitle);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.Name = "dlgCrosssPrecessHost";
			base.Load += new System.EventHandler(dlgCrosssPrecessHost_Load);
			ResumeLayout(false);
			PerformLayout();
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgCrosssPrecessHost()
		{
			InitializeComponent();
		}

		private void dlgCrosssPrecessHost_Load(object sender, EventArgs e)
		{
			int num = 8;
			Text = Application.ProductName;
			if (HostedControl == null)
			{
				lblTitle.Text = "没有设置控件实例!";
				return;
			}
			if (HostContainerHandle == IntPtr.Zero)
			{
				lblTitle.Text = "未知名容器控件句柄!";
				return;
			}
			Text = HostedControl.ProductName + " V:" + HostedControl.ProductVersion;
			lblTitle.Text = string.Format(lblTitle.Text, HostedControl.ProductName);
			gclass271_0 = new GClass271();
			gclass271_0.method_3(HostContainerHandle);
			if (!HostedControl.IsHandleCreated)
			{
				HostedControl.CreateControl();
			}
			gclass271_0.method_1(HostedControl.Handle);
			gclass271_0.method_5(DockStyle.Fill);
			if (gclass271_0.method_6())
			{
				timer_0.Start();
			}
		}

		/// <summary>
		///       窗体准备关闭时的处理
		///       </summary>
		/// <param name="e">参数</param>
		protected override void OnClosing(CancelEventArgs cancelEventArgs_0)
		{
			if (gclass271_0 != null)
			{
				cancelEventArgs_0.Cancel = true;
			}
			else
			{
				base.OnClosing(cancelEventArgs_0);
			}
		}

		private void timer_0_Tick(object sender, EventArgs e)
		{
			int num = 9;
			if (gclass271_0 != null)
			{
				if (gclass271_0.method_6())
				{
					GClass244 gClass = new GClass244(gclass271_0.method_2());
					lblStatus.Text = "Contaienr handle:" + gClass.Handle + " Text:" + gClass.method_3();
					return;
				}
				lblStatus.Text = "";
				gclass271_0 = null;
				timer_0.Stop();
				Close();
			}
			else
			{
				timer_0.Stop();
				Close();
			}
		}
	}
}
