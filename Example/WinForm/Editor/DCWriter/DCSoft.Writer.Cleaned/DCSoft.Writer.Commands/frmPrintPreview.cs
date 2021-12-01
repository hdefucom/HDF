using DCSoft.Printing;
using DCSoft.Writer.Controls;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       打印预览窗口
	///       </summary>
	[ComVisible(false)]
	public class frmPrintPreview : Form
	{
		private IContainer icontainer_0 = null;

		internal WriterPrintPreviewControl myPreviewControl;

		private bool bool_0 = false;

		private bool bool_1 = false;

		private int int_0 = 0;

		private Timer timer_0 = null;

		/// <summary>
		///       打印结果
		///       </summary>
		public PrintResult CurrentPrintResult => myPreviewControl.CurrentPrintResult;

		/// <summary>
		///       自动翻转到最后一页
		///       </summary>
		[DefaultValue(false)]
		public bool AutoTurnToLastPage
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
		///       是否翻转到指定页面
		///       </summary>
		[DefaultValue(false)]
		public bool IsTurnToPage
		{
			get
			{
				return bool_1;
			}
			set
			{
				bool_1 = value;
			}
		}

		/// <summary>
		///       翻转到指定页面
		///       </summary>
		[DefaultValue(0)]
		public int TurnToPage
		{
			get
			{
				return int_0;
			}
			set
			{
				int_0 = value;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Commands.frmPrintPreview));
			myPreviewControl = new DCSoft.Writer.Controls.WriterPrintPreviewControl();
			SuspendLayout();
			myPreviewControl.BackColor = System.Drawing.SystemColors.AppWorkspace;
			resources.ApplyResources(myPreviewControl, "myPreviewControl");
			myPreviewControl.Name = "myPreviewControl";
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(myPreviewControl);
			base.MinimizeBox = false;
			base.Name = "frmPrintPreview";
			base.ShowInTaskbar = false;
			ResumeLayout(false);
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public frmPrintPreview()
		{
			InitializeComponent();
		}

		/// <summary>
		///       加载窗体时的处理
		///       </summary>
		/// <param name="e">
		/// </param>
		protected override void OnLoad(EventArgs eventArgs_0)
		{
			base.OnLoad(eventArgs_0);
			if (!base.DesignMode)
			{
				timer_0 = new Timer();
				timer_0.Interval = 300;
				timer_0.Tick += timer_0_Tick;
				timer_0.Start();
			}
		}

		private void timer_0_Tick(object sender, EventArgs e)
		{
			if (timer_0 != null)
			{
				timer_0.Stop();
				timer_0.Dispose();
				timer_0 = null;
			}
			myPreviewControl.InvalidatePreview();
			if (AutoTurnToLastPage)
			{
				Point autoScrollPosition = new Point(0, myPreviewControl.PrintPreviewControl.AutoScrollMinSize.Height);
				myPreviewControl.PrintPreviewControl.AutoScrollPosition = autoScrollPosition;
			}
			else if (IsTurnToPage)
			{
				myPreviewControl.PrintPreviewControl.StartPage = TurnToPage;
			}
		}
	}
}
