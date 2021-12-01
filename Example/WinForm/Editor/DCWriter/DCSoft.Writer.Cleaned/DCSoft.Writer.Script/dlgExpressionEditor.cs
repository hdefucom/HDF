using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Script
{
	/// <summary>
	///       表达式编辑器对话框
	///       </summary>
	[ComVisible(false)]
	public class dlgExpressionEditor : Form
	{
		private IContainer icontainer_0 = null;

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
			SuspendLayout();
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(521, 412);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgExpressionEditor";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "表达式编辑器";
			ResumeLayout(false);
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgExpressionEditor()
		{
			InitializeComponent();
		}
	}
}