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
	[ToolboxItem(false)]
	[ComVisible(false)]
	public class DateSelectControl : UserControl
	{
		private IContainer icontainer_0 = null;

		private MonthCalendar myMonthCalendar;

		private Button btnOK;

		private Button btnCancel;

		private Button btnClear;

		private Size size_0 = Size.Empty;

		private DateTime dateTime_0 = DateTime.Now;

		private IWindowsFormsEditorService iwindowsFormsEditorService_0 = null;

		private bool bool_0 = false;

		private bool bool_1 = false;

		private GClass254 gclass254_0 = new GClass254();

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
				return bool_0;
			}
			set
			{
				bool_0 = value;
			}
		}

		/// <summary>
		///       空数据标记
		///       </summary>
		public bool NullValueFlag
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Controls.DateSelectControl));
			myMonthCalendar = new System.Windows.Forms.MonthCalendar();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			btnClear = new System.Windows.Forms.Button();
			SuspendLayout();
			resources.ApplyResources(myMonthCalendar, "myMonthCalendar");
			myMonthCalendar.Name = "myMonthCalendar";
			myMonthCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(myMonthCalendar_DateChanged);
			myMonthCalendar.KeyDown += new System.Windows.Forms.KeyEventHandler(myMonthCalendar_KeyDown);
			myMonthCalendar.MouseDown += new System.Windows.Forms.MouseEventHandler(myMonthCalendar_MouseDown);
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
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(btnClear);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(myMonthCalendar);
			base.Name = "DateSelectControl";
			base.Load += new System.EventHandler(DateSelectControl_Load);
			base.Resize += new System.EventHandler(DateSelectControl_Resize);
			ResumeLayout(false);
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public DateSelectControl()
		{
			InitializeComponent();
			size_0 = base.Size;
		}

		/// <summary>
		///       加载控件
		///       </summary>
		/// <param name="e">
		/// </param>
		protected override void OnLoad(EventArgs eventArgs_0)
		{
			base.OnLoad(eventArgs_0);
			myMonthCalendar.Focus();
		}

		private void DateSelectControl_Load(object sender, EventArgs e)
		{
			myMonthCalendar.SetDate(dateTime_0);
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
			if (preferredSize.Width < btnOK.Width * 3)
			{
				preferredSize.Width = btnOK.Width * 3;
				myMonthCalendar.Left = (preferredSize.Width - myMonthCalendar.Width) / 2;
			}
			int height = btnOK.Height;
			btnOK.Left = 0;
			btnOK.Top = myMonthCalendar.Bottom + height / 2;
			btnCancel.Left = (preferredSize.Width - btnCancel.Width) / 2;
			btnCancel.Top = btnOK.Top;
			btnClear.Left = preferredSize.Width - btnClear.Width;
			btnClear.Top = btnOK.Top;
			return new Size(preferredSize.Width, preferredSize.Height + height * 2);
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			dateTime_0 = myMonthCalendar.SelectionStart.Date;
			bool_0 = true;
			if (iwindowsFormsEditorService_0 != null)
			{
				iwindowsFormsEditorService_0.CloseDropDown();
			}
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			dateTime_0 = DateTime.MinValue;
			bool_0 = true;
			if (iwindowsFormsEditorService_0 != null)
			{
				iwindowsFormsEditorService_0.CloseDropDown();
			}
		}

		private void myMonthCalendar_DateChanged(object sender, DateRangeEventArgs e)
		{
			bool_0 = true;
		}

		private void method_0(object sender, EventArgs e)
		{
			bool_0 = true;
		}

		private void method_1(object sender, EventArgs e)
		{
			bool_0 = true;
		}

		private void method_2(object sender, EventArgs e)
		{
			bool_0 = true;
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			bool_0 = false;
			if (iwindowsFormsEditorService_0 != null)
			{
				iwindowsFormsEditorService_0.CloseDropDown();
			}
		}

		private void DateSelectControl_Resize(object sender, EventArgs e)
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
			if (e.KeyCode == Keys.Escape)
			{
				btnCancel_Click(null, null);
			}
		}
	}
}
