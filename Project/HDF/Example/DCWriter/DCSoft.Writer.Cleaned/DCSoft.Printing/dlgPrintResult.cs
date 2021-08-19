using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace DCSoft.Printing
{
	[ComVisible(false)]
	public class dlgPrintResult : Form
	{
		private PrintResult printResult_0 = null;

		private IContainer icontainer_0 = null;

		private TextBox txtResult;

		private Button btnClose;

		public PrintResult PrintResult
		{
			get
			{
				return printResult_0;
			}
			set
			{
				printResult_0 = value;
			}
		}

		public dlgPrintResult()
		{
			InitializeComponent();
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void dlgPrintResult_Load(object sender, EventArgs e)
		{
			int num = 9;
			if (printResult_0 == null)
			{
				return;
			}
			StringBuilder stringBuilder = new StringBuilder();
			int[] successedPageIndexs = printResult_0.SuccessedPageIndexs;
			foreach (int num2 in successedPageIndexs)
			{
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append(",");
				}
				stringBuilder.Append(num2.ToString());
			}
			string text = txtResult.Text;
			text = string.Format(text, printResult_0.Title, printResult_0.PrinterName, printResult_0.PaperSourceName, printResult_0.Copies, printResult_0.StartTime, printResult_0.EndTime, printResult_0.Message, printResult_0.JumpPrintMode, printResult_0.Position, stringBuilder, printResult_0.CompleteSuccessed, printResult_0.UserCancel, printResult_0.TotalTickSpan, printResult_0.InitalizeTickSpan);
			foreach (PrintPageResult pageInfo in printResult_0.PageInfos)
			{
				text = text + Environment.NewLine + "Page " + pageInfo.PageIndex + ",ContentHeight=" + pageInfo.ContentHeight + ",ContentHeightPrinted=" + pageInfo.ContentHeightPrinted + ",StartPositionInPage=" + pageInfo.StartPositionInPage + ",EndPositionInPage=" + pageInfo.EndPositionInPage + ",Tick=" + pageInfo.TickSpan;
			}
			txtResult.Text = text;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Printing.dlgPrintResult));
			txtResult = new System.Windows.Forms.TextBox();
			btnClose = new System.Windows.Forms.Button();
			SuspendLayout();
			resources.ApplyResources(txtResult, "txtResult");
			txtResult.Name = "txtResult";
			txtResult.ReadOnly = true;
			resources.ApplyResources(btnClose, "btnClose");
			btnClose.Name = "btnClose";
			btnClose.UseVisualStyleBackColor = true;
			btnClose.Click += new System.EventHandler(btnClose_Click);
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(btnClose);
			base.Controls.Add(txtResult);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgPrintResult";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgPrintResult_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
