using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace DCSoft.TemperatureChart
{
	/// <summary>
	///       不带有时间的编辑单个数据的对话框
	///       </summary>
	[ComVisible(false)]
	public class dlgEditSingleValueWithoutTime : Form
	{
		private IContainer icontainer_0 = null;

		private Label lblTitle;

		private TextBox txtValue;

		private Button btnOK;

		private Button btnCancel;

		private object object_0 = null;

		private CancelEventHandler cancelEventHandler_0 = null;

		/// <summary>
		///       父对象
		///        </summary>
		public object InputParent
		{
			get
			{
				return object_0;
			}
			set
			{
				object_0 = value;
			}
		}

		/// <summary>
		///       标题
		///       </summary>
		public string InputTitle
		{
			get
			{
				return lblTitle.Text;
			}
			set
			{
				lblTitle.Text = value;
			}
		}

		/// <summary>
		///       数值
		///       </summary>
		public string InputValue
		{
			get
			{
				return txtValue.Text;
			}
			set
			{
				txtValue.Text = value;
			}
		}

		/// <summary>
		///       确定按钮点击事件
		///       </summary>
		public event CancelEventHandler EventOKButtonClick
		{
			add
			{
				CancelEventHandler cancelEventHandler = cancelEventHandler_0;
				CancelEventHandler cancelEventHandler2;
				do
				{
					cancelEventHandler2 = cancelEventHandler;
					CancelEventHandler value2 = (CancelEventHandler)Delegate.Combine(cancelEventHandler2, value);
					cancelEventHandler = Interlocked.CompareExchange(ref cancelEventHandler_0, value2, cancelEventHandler2);
				}
				while ((object)cancelEventHandler != cancelEventHandler2);
			}
			remove
			{
				CancelEventHandler cancelEventHandler = cancelEventHandler_0;
				CancelEventHandler cancelEventHandler2;
				do
				{
					cancelEventHandler2 = cancelEventHandler;
					CancelEventHandler value2 = (CancelEventHandler)Delegate.Remove(cancelEventHandler2, value);
					cancelEventHandler = Interlocked.CompareExchange(ref cancelEventHandler_0, value2, cancelEventHandler2);
				}
				while ((object)cancelEventHandler != cancelEventHandler2);
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.TemperatureChart.dlgEditSingleValueWithoutTime));
			lblTitle = new System.Windows.Forms.Label();
			txtValue = new System.Windows.Forms.TextBox();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			SuspendLayout();
			resources.ApplyResources(lblTitle, "lblTitle");
			lblTitle.Name = "lblTitle";
			resources.ApplyResources(txtValue, "txtValue");
			txtValue.Name = "txtValue";
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.Name = "btnOK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			base.AcceptButton = btnOK;
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = btnCancel;
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(txtValue);
			base.Controls.Add(lblTitle);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgEditSingleValueWithoutTime";
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgEditSingleValueWithoutTime_Load);
			ResumeLayout(false);
			PerformLayout();
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgEditSingleValueWithoutTime()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgEditSingleValueWithoutTime_Load(object sender, EventArgs e)
		{
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (cancelEventHandler_0 != null)
			{
				CancelEventArgs cancelEventArgs = new CancelEventArgs();
				cancelEventArgs.Cancel = false;
				cancelEventHandler_0(this, cancelEventArgs);
				if (cancelEventArgs.Cancel)
				{
					return;
				}
			}
			base.DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
