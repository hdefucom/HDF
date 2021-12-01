using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       日期选择控件
	///       </summary>
	[ComVisible(false)]
	[ToolboxItem(false)]
	public class DateTimeSelectControl : UserControl
	{
		private Size size_0 = Size.Empty;

		private DateTime dateTime_0 = DateTime.Now;

		private bool bool_0 = false;

		private IWindowsFormsEditorService iwindowsFormsEditorService_0 = null;

		private bool bool_1 = false;

		private bool bool_2 = false;

		private GClass254 gclass254_0 = new GClass254();

		private IContainer icontainer_0 = null;

		private MonthCalendar myMonthCalendar;

		private NumericUpDown cboHour;

		private NumericUpDown cboMinute;

		private NumericUpDown cboSecend;

		private Button btnOK;

		private Button btnCancel;

		private Button btnClear;

		private Label lblHour;

		private Label lblMun;

		private Label lblSecond;

		/// <summary>
		///       演示的事件日期数据
		///       </summary>
		public DateTime DateTimeValue
		{
			get
			{
				return dateTime_0;
			}
			set
			{
				dateTime_0 = value;
			}
		}

		/// <summary>
		///       编辑器服务对象
		///       </summary>
		public IWindowsFormsEditorService EditorService
		{
			get
			{
				return iwindowsFormsEditorService_0;
			}
			set
			{
				iwindowsFormsEditorService_0 = value;
			}
		}

		/// <summary>
		///       数据是否发生改变
		///       </summary>
		public bool Modified
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
		///       是否显示秒
		///       </summary>
		[DefaultValue(true)]
		public bool SecondVisible
		{
			get
			{
				return cboSecend.Visible;
			}
			set
			{
				cboSecend.Visible = value;
				lblSecond.Visible = value;
			}
		}

		/// <summary>
		///       空数据标记
		///       </summary>
		public bool NullValueFlag
		{
			get
			{
				return bool_2;
			}
			set
			{
				bool_2 = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public DateTimeSelectControl()
		{
			InitializeComponent();
			size_0 = base.Size;
		}

		private void DateTimeSelectControl_Load(object sender, EventArgs e)
		{
			myMonthCalendar.SetDate(dateTime_0);
			cboHour.Value = dateTime_0.Hour;
			cboMinute.Value = dateTime_0.Minute;
			cboSecend.Value = dateTime_0.Second;
			bool_1 = false;
			bool_0 = false;
		}

		/// <summary>
		///       获得推荐的大小
		///       </summary>
		/// <param name="proposedSize">
		/// </param>
		/// <returns>
		/// </returns>
		public override Size GetPreferredSize(Size proposedSize)
		{
			if (!myMonthCalendar.IsHandleCreated)
			{
				myMonthCalendar.CreateControl();
			}
			myMonthCalendar.Dock = DockStyle.None;
			Size preferredSize = myMonthCalendar.GetPreferredSize(proposedSize);
			preferredSize.Width = Math.Max(preferredSize.Width, btnOK.Width * 3);
			cboHour.Top = myMonthCalendar.Bottom + 5;
			cboMinute.Top = cboHour.Top;
			cboSecend.Top = cboHour.Top;
			lblHour.Top = cboHour.Top + 3;
			lblMun.Top = lblHour.Top;
			lblSecond.Top = lblHour.Top;
			lblHour.Left = cboHour.Right;
			cboMinute.Left = lblHour.Right;
			lblMun.Left = cboMinute.Right;
			cboSecend.Left = lblMun.Right;
			lblSecond.Left = cboSecend.Right;
			preferredSize.Width = Math.Max(preferredSize.Width, lblSecond.Right);
			myMonthCalendar.Left = (preferredSize.Width - myMonthCalendar.Width) / 2;
			btnOK.Left = 0;
			btnOK.Top = cboHour.Bottom + 5;
			btnCancel.Left = (preferredSize.Width - btnCancel.Width) / 2;
			btnCancel.Top = btnOK.Top;
			btnClear.Left = preferredSize.Width - btnClear.Width;
			btnClear.Top = btnOK.Top;
			return new Size(preferredSize.Width, btnOK.Bottom + 5);
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (bool_0 || NullValueFlag)
			{
				DateTime selectionStart = myMonthCalendar.SelectionStart;
				dateTime_0 = new DateTime(selectionStart.Year, selectionStart.Month, selectionStart.Day, Convert.ToInt32(cboHour.Value), Convert.ToInt32(cboMinute.Value), cboSecend.Visible ? Convert.ToInt32(cboSecend.Value) : 0);
				bool_1 = true;
			}
			else
			{
				bool_1 = false;
			}
			if (iwindowsFormsEditorService_0 != null)
			{
				iwindowsFormsEditorService_0.CloseDropDown();
			}
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			dateTime_0 = DateTime.MinValue;
			bool_1 = true;
			if (iwindowsFormsEditorService_0 != null)
			{
				iwindowsFormsEditorService_0.CloseDropDown();
			}
		}

		private void myMonthCalendar_DateChanged(object sender, DateRangeEventArgs e)
		{
			bool_0 = true;
		}

		private void cboHour_ValueChanged(object sender, EventArgs e)
		{
			bool_0 = true;
		}

		private void cboMinute_ValueChanged(object sender, EventArgs e)
		{
			bool_0 = true;
		}

		private void cboSecend_ValueChanged(object sender, EventArgs e)
		{
			bool_0 = true;
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			bool_1 = false;
			if (iwindowsFormsEditorService_0 != null)
			{
				iwindowsFormsEditorService_0.CloseDropDown();
			}
		}

		/// <summary>
		///       预览按键按下事件
		///       </summary>
		/// <param name="e">参数</param>
		protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs previewKeyDownEventArgs_0)
		{
			base.OnPreviewKeyDown(previewKeyDownEventArgs_0);
			if (previewKeyDownEventArgs_0.KeyCode == Keys.Escape)
			{
				btnCancel_Click(null, null);
			}
		}

		private void DateTimeSelectControl_Resize(object sender, EventArgs e)
		{
		}

		private void myMonthCalendar_MouseDown(object sender, MouseEventArgs e)
		{
			if (gclass254_0.method_0(e))
			{
				btnOK_Click(null, null);
			}
		}

		private void myMonthCalendar_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				btnOK_Click(null, null);
			}
		}

		/// <summary> 
		///       清理所有正在使用的资源。
		///       </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && icontainer_0 != null)
			{
				icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		/// <summary> 
		///       设计器支持所需的方法 - 不要
		///       使用代码编辑器修改此方法的内容。
		///       </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Controls.DateTimeSelectControl));
			myMonthCalendar = new System.Windows.Forms.MonthCalendar();
			cboHour = new System.Windows.Forms.NumericUpDown();
			cboMinute = new System.Windows.Forms.NumericUpDown();
			cboSecend = new System.Windows.Forms.NumericUpDown();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			btnClear = new System.Windows.Forms.Button();
			lblHour = new System.Windows.Forms.Label();
			lblMun = new System.Windows.Forms.Label();
			lblSecond = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)cboHour).BeginInit();
			((System.ComponentModel.ISupportInitialize)cboMinute).BeginInit();
			((System.ComponentModel.ISupportInitialize)cboSecend).BeginInit();
			SuspendLayout();
			resources.ApplyResources(myMonthCalendar, "myMonthCalendar");
			myMonthCalendar.Name = "myMonthCalendar";
			myMonthCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(myMonthCalendar_DateChanged);
			myMonthCalendar.KeyDown += new System.Windows.Forms.KeyEventHandler(myMonthCalendar_KeyDown);
			myMonthCalendar.MouseDown += new System.Windows.Forms.MouseEventHandler(myMonthCalendar_MouseDown);
			resources.ApplyResources(cboHour, "cboHour");
			cboHour.Maximum = new decimal(new int[4]
			{
				23,
				0,
				0,
				0
			});
			cboHour.Name = "cboHour";
			cboHour.ValueChanged += new System.EventHandler(cboHour_ValueChanged);
			resources.ApplyResources(cboMinute, "cboMinute");
			cboMinute.Maximum = new decimal(new int[4]
			{
				59,
				0,
				0,
				0
			});
			cboMinute.Name = "cboMinute";
			cboMinute.ValueChanged += new System.EventHandler(cboMinute_ValueChanged);
			resources.ApplyResources(cboSecend, "cboSecend");
			cboSecend.Maximum = new decimal(new int[4]
			{
				59,
				0,
				0,
				0
			});
			cboSecend.Name = "cboSecend";
			cboSecend.ValueChanged += new System.EventHandler(cboSecend_ValueChanged);
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.Name = "btnOK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			resources.ApplyResources(btnClear, "btnClear");
			btnClear.Name = "btnClear";
			btnClear.UseVisualStyleBackColor = true;
			btnClear.Click += new System.EventHandler(btnClear_Click);
			resources.ApplyResources(lblHour, "lblHour");
			lblHour.Name = "lblHour";
			resources.ApplyResources(lblMun, "lblMun");
			lblMun.Name = "lblMun";
			resources.ApplyResources(lblSecond, "lblSecond");
			lblSecond.Name = "lblSecond";
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(lblSecond);
			base.Controls.Add(lblMun);
			base.Controls.Add(lblHour);
			base.Controls.Add(btnClear);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(cboSecend);
			base.Controls.Add(cboMinute);
			base.Controls.Add(cboHour);
			base.Controls.Add(myMonthCalendar);
			base.Name = "DateTimeSelectControl";
			base.Load += new System.EventHandler(DateTimeSelectControl_Load);
			base.Resize += new System.EventHandler(DateTimeSelectControl_Resize);
			((System.ComponentModel.ISupportInitialize)cboHour).EndInit();
			((System.ComponentModel.ISupportInitialize)cboMinute).EndInit();
			((System.ComponentModel.ISupportInitialize)cboSecend).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
