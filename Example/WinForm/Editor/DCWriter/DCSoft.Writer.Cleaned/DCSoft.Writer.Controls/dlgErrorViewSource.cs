using DCSoft.Common;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       显示错误内容对话框
	///       </summary>
	[ComVisible(false)]
	
	public class dlgErrorViewSource : Form
	{
		private IContainer icontainer_0 = null;

		private TextBox txtSource;

		/// <summary>
		///       错误内容
		///       </summary>
		public string ReportSource
		{
			get
			{
				return txtSource.Text;
			}
			set
			{
				txtSource.Text = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgErrorViewSource()
		{
			InitializeComponent();
		}

		private void dlgErrorViewSource_Load(object sender, EventArgs e)
		{
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Controls.dlgErrorViewSource));
			txtSource = new System.Windows.Forms.TextBox();
			SuspendLayout();
			resources.ApplyResources(txtSource, "txtSource");
			txtSource.Name = "txtSource";
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(txtSource);
			base.MinimizeBox = false;
			base.Name = "dlgErrorViewSource";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgErrorViewSource_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
