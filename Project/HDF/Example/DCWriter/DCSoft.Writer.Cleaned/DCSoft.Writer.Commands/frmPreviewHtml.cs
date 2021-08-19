using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       Html预览窗体对象
	///       </summary>
	[ComVisible(false)]
	public class frmPreviewHtml : Form
	{
		private IContainer icontainer_0 = null;

		private WebBrowser myWebBrowser;

		private string string_0 = "about:blank";

		/// <summary>
		///       要显示内容的Url
		///       </summary>
		public string HtmlUrl
		{
			get
			{
				return string_0;
			}
			set
			{
				string_0 = value;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Commands.frmPreviewHtml));
			myWebBrowser = new System.Windows.Forms.WebBrowser();
			SuspendLayout();
			resources.ApplyResources(myWebBrowser, "myWebBrowser");
			myWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
			myWebBrowser.Name = "myWebBrowser";
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(myWebBrowser);
			base.MinimizeBox = false;
			base.Name = "frmPreviewHtml";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(frmPreviewHtml_Load);
			ResumeLayout(false);
		}

		/// <summary>
		///       默认构造函数
		///       </summary>
		public frmPreviewHtml()
		{
			InitializeComponent();
		}

		/// <summary>
		///       窗体加载事件
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="e">
		/// </param>
		private void frmPreviewHtml_Load(object sender, EventArgs e)
		{
			myWebBrowser.Navigate(HtmlUrl);
		}
	}
}
