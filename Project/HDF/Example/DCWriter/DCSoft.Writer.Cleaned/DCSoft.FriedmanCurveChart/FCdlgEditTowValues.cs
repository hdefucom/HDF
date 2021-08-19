using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace DCSoft.FriedmanCurveChart
{
	/// <summary>
	///       编辑2个数据的对话框
	///       </summary>
	[ComVisible(false)]
	public class FCdlgEditTowValues : Form
	{
		private object object_0 = null;

		private object object_1 = null;

		private CancelEventHandler cancelEventHandler_0 = null;

		private IContainer icontainer_0 = null;

		private Label lblTitle;

		private TextBox txtValue;

		private Button btnOK;

		private Button btnCancel;

		private TextBox textBox1;

		private Label label1;

		private DateTimePicker dateTimePicker1;

		private Label label2;

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
				return dateTimePicker1.Value;
			}
			set
			{
				dateTimePicker1.Value = value;
			}
		}

		/// <summary>
		///       标题1
		///       </summary>
		public string InputTitle1
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
		///       数值1
		///       </summary>
		public string InputValue1
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
		///       父对象1
		///       </summary>
		public object InputParent1
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
		///       标题2
		///       </summary>
		public string InputTitle2
		{
			get
			{
				return label1.Text;
			}
			set
			{
				label1.Text = value;
			}
		}

		/// <summary>
		///       数值2
		///       </summary>
		public string InputValue2
		{
			get
			{
				return textBox1.Text;
			}
			set
			{
				textBox1.Text = value;
			}
		}

		/// <summary>
		///       父对象2
		///       </summary>
		public object InputParent2
		{
			get
			{
				return object_1;
			}
			set
			{
				object_1 = value;
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
		public FCdlgEditTowValues()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void FCdlgEditTowValues_Load(object sender, EventArgs e)
		{
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
			lblTitle = new System.Windows.Forms.Label();
			txtValue = new System.Windows.Forms.TextBox();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			textBox1 = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			label2 = new System.Windows.Forms.Label();
			SuspendLayout();
			lblTitle.AutoSize = true;
			lblTitle.Location = new System.Drawing.Point(13, 42);
			lblTitle.Name = "lblTitle";
			lblTitle.Size = new System.Drawing.Size(41, 12);
			lblTitle.TabIndex = 0;
			lblTitle.Text = "label1";
			txtValue.Location = new System.Drawing.Point(13, 61);
			txtValue.Name = "txtValue";
			txtValue.Size = new System.Drawing.Size(224, 21);
			txtValue.TabIndex = 1;
			btnOK.Location = new System.Drawing.Point(32, 153);
			btnOK.Name = "btnOK";
			btnOK.Size = new System.Drawing.Size(75, 23);
			btnOK.TabIndex = 4;
			btnOK.Text = "确定(&O)";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			btnCancel.Location = new System.Drawing.Point(144, 153);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(75, 23);
			btnCancel.TabIndex = 5;
			btnCancel.Text = "取消(&C)";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			textBox1.Location = new System.Drawing.Point(13, 115);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(224, 21);
			textBox1.TabIndex = 3;
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(13, 96);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(41, 12);
			label1.TabIndex = 2;
			label1.Text = "label1";
			dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
			dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			dateTimePicker1.Location = new System.Drawing.Point(52, 9);
			dateTimePicker1.Name = "dateTimePicker1";
			dateTimePicker1.Size = new System.Drawing.Size(184, 21);
			dateTimePicker1.TabIndex = 7;
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(13, 13);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(41, 12);
			label2.TabIndex = 6;
			label2.Text = "时刻：";
			base.AcceptButton = btnOK;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = btnCancel;
			base.ClientSize = new System.Drawing.Size(253, 188);
			base.Controls.Add(dateTimePicker1);
			base.Controls.Add(label2);
			base.Controls.Add(textBox1);
			base.Controls.Add(label1);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(txtValue);
			base.Controls.Add(lblTitle);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgEditTowValues";
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "编辑";
			base.Load += new System.EventHandler(FCdlgEditTowValues_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
