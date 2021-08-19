using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace DCSoft.TemperatureChart
{
	/// <summary>
	///       编辑单个字符串数据的对话框
	///       </summary>
	[ComVisible(false)]
	public class dlgEditSingleValue : Form
	{
		private DateTimePrecisionMode dateTimePrecisionMode_0 = DateTimePrecisionMode.Second;

		private object object_0 = null;

		private float float_0 = float.NaN;

		private CancelEventHandler cancelEventHandler_0 = null;

		private IContainer icontainer_0 = null;

		private Label lblTitle;

		private TextBox txtValue;

		private Button btnOK;

		private Button btnCancel;

		private Label label1;

		private DateTimePicker dateTimePicker1;

		/// <summary>
		///       输入时间的精度
		///       </summary>
		[DefaultValue(DateTimePrecisionMode.Second)]
		public DateTimePrecisionMode InputTimePrecision
		{
			get
			{
				return dateTimePrecisionMode_0;
			}
			set
			{
				dateTimePrecisionMode_0 = value;
			}
		}

		/// <summary>
		///       允许输入时间
		///       </summary>
		public bool EnableInputTime
		{
			get
			{
				return dateTimePicker1.Enabled;
			}
			set
			{
				dateTimePicker1.Enabled = value;
			}
		}

		/// <summary>
		///       输入的时间
		///       </summary>
		public DateTime InputTime
		{
			get
			{
				return Class157.smethod_1(dateTimePicker1.Value, InputTimePrecision);
			}
			set
			{
				dateTimePicker1.Value = value;
			}
		}

		/// <summary>
		///       父对象
		///       </summary>
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
		///        输入的文本内容
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
		///       结果值
		///       </summary>
		public float ResultValue
		{
			get
			{
				return float_0;
			}
			set
			{
				float_0 = value;
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
		///       初始化对象
		///       </summary>
		public dlgEditSingleValue()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgEditSingleValue_Load(object sender, EventArgs e)
		{
			dateTimePicker1.CustomFormat = Class157.smethod_0(InputTimePrecision);
			txtValue.Focus();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.TemperatureChart.dlgEditSingleValue));
			lblTitle = new System.Windows.Forms.Label();
			txtValue = new System.Windows.Forms.TextBox();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			label1 = new System.Windows.Forms.Label();
			dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
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
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			resources.ApplyResources(dateTimePicker1, "dateTimePicker1");
			dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			dateTimePicker1.Name = "dateTimePicker1";
			base.AcceptButton = btnOK;
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = btnCancel;
			base.Controls.Add(dateTimePicker1);
			base.Controls.Add(label1);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(txtValue);
			base.Controls.Add(lblTitle);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgEditSingleValue";
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgEditSingleValue_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
