using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Printing
{
	[ComVisible(false)]
	public class dlgWaitPrintJob : Form
	{
		private string string_0 = null;

		private Label label1;

		private Label lblStatus;

		private Timer timer_0;

		private IContainer icontainer_0;

		private Button btnCancel;

		private PrintJob printJob_0 = null;

		/// <summary>
		///       打印任务对象
		///       </summary>
		public PrintJob PrintJob
		{
			get
			{
				return printJob_0;
			}
			set
			{
				printJob_0 = value;
			}
		}

		public dlgWaitPrintJob()
		{
			InitializeComponent();
			string_0 = lblStatus.Text;
			base.DialogResult = DialogResult.Cancel;
		}

		private void InitializeComponent()
		{
			icontainer_0 = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Printing.dlgWaitPrintJob));
			label1 = new System.Windows.Forms.Label();
			lblStatus = new System.Windows.Forms.Label();
			btnCancel = new System.Windows.Forms.Button();
			timer_0 = new System.Windows.Forms.Timer(icontainer_0);
			SuspendLayout();
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			resources.ApplyResources(lblStatus, "lblStatus");
			lblStatus.Name = "lblStatus";
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			timer_0.Enabled = true;
			timer_0.Tick += new System.EventHandler(timer_0_Tick);
			resources.ApplyResources(this, "$this");
			base.Controls.Add(btnCancel);
			base.Controls.Add(lblStatus);
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgWaitPrintJob";
			base.ShowInTaskbar = false;
			ResumeLayout(false);
			PerformLayout();
		}

		/// <summary>
		///       取消按钮事件
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="e">
		/// </param>
		private void btnCancel_Click(object sender, EventArgs e)
		{
			if (printJob_0 != null)
			{
				printJob_0.Cancel();
			}
			base.DialogResult = DialogResult.Cancel;
			Close();
		}

		private void timer_0_Tick(object sender, EventArgs e)
		{
			if (printJob_0 == null)
			{
				return;
			}
			lblStatus.Text = string_0 + printJob_0.Status;
			if (!printJob_0.IsRunning)
			{
				if (printJob_0.IsSuccessStatus)
				{
					base.DialogResult = DialogResult.OK;
				}
				Close();
			}
		}
	}
}
