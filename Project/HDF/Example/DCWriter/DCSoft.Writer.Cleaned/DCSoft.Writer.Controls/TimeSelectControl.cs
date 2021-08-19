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
	public class TimeSelectControl : UserControl
	{
		private IContainer icontainer_0 = null;

		private Label label1;

		private NumericUpDown cboHour;

		private NumericUpDown cboMinute;

		private NumericUpDown cboSecend;

		private Button btnOK;

		private Button btnCancel;

		private Button btnClear;

		private Size size_0 = Size.Empty;

		private DateTime dateTime_0 = DateTime.Now;

		private IWindowsFormsEditorService iwindowsFormsEditorService_0 = null;

		private bool bool_0 = false;

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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Controls.TimeSelectControl));
			label1 = new System.Windows.Forms.Label();
			cboHour = new System.Windows.Forms.NumericUpDown();
			cboMinute = new System.Windows.Forms.NumericUpDown();
			cboSecend = new System.Windows.Forms.NumericUpDown();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			btnClear = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)cboHour).BeginInit();
			((System.ComponentModel.ISupportInitialize)cboMinute).BeginInit();
			((System.ComponentModel.ISupportInitialize)cboSecend).BeginInit();
			SuspendLayout();
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
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
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(btnClear);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(cboSecend);
			base.Controls.Add(cboMinute);
			base.Controls.Add(cboHour);
			base.Controls.Add(label1);
			base.Name = "TimeSelectControl";
			base.Load += new System.EventHandler(TimeSelectControl_Load);
			base.Resize += new System.EventHandler(TimeSelectControl_Resize);
			((System.ComponentModel.ISupportInitialize)cboHour).EndInit();
			((System.ComponentModel.ISupportInitialize)cboMinute).EndInit();
			((System.ComponentModel.ISupportInitialize)cboSecend).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public TimeSelectControl()
		{
			InitializeComponent();
			size_0 = base.Size;
		}

		private void TimeSelectControl_Load(object sender, EventArgs e)
		{
			cboHour.Value = dateTime_0.Hour;
			cboMinute.Value = dateTime_0.Minute;
			cboSecend.Value = dateTime_0.Second;
			bool_0 = false;
		}

		protected override bool ProcessDialogKey(Keys keyData)
		{
			if (keyData == Keys.Escape && EditorService != null)
			{
				EditorService.CloseDropDown();
			}
			return base.ProcessDialogKey(keyData);
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
			return base.Size;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			DateTime now = DateTime.Now;
			DateTimeValue = new DateTime(now.Year, now.Month, now.Day, Convert.ToInt32(cboHour.Value), Convert.ToInt32(cboMinute.Value), Convert.ToInt32(cboSecend.Value));
			Modified = true;
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

		private void method_0(object sender, DateRangeEventArgs e)
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
			bool_0 = false;
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

		private void TimeSelectControl_Resize(object sender, EventArgs e)
		{
		}
	}
}
