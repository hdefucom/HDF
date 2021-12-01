#define DEBUG
using DCSoft.WinForms;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       计算器控件
	///       </summary>
	[ToolboxItem(false)]
	[ComVisible(false)]
	public class WriterCalculateControl : CalculateControl
	{
		private Button btnOK;

		private Button btnCancel;

		private bool bool_0 = false;

		private TextWindowsFormsEditorHost textWindowsFormsEditorHost_0 = null;

		/// <summary>
		///       数据是否修改
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
		///       编辑器宿主
		///       </summary>
		public TextWindowsFormsEditorHost EditorHost
		{
			get
			{
				return textWindowsFormsEditorHost_0;
			}
			set
			{
				textWindowsFormsEditorHost_0 = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public WriterCalculateControl()
		{
			InitializeComponent_1();
		}

		private void InitializeComponent_1()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(WriterCalculateControl));
			btnOK = new Button();
			btnCancel = new Button();
			SuspendLayout();
			componentResourceManager.ApplyResources(btnOK, "btnOK");
			btnOK.Name = "btnOK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += btnOK_Click;
			componentResourceManager.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += btnCancel_Click;
			componentResourceManager.ApplyResources(this, "$this");
			base.Controls.Add(btnOK);
			base.Controls.Add(btnCancel);
			base.Name = "WriterCalculateControl";
			base.Controls.SetChildIndex(txtShow, 0);
			base.Controls.SetChildIndex(btnCancel, 0);
			base.Controls.SetChildIndex(btnOK, 0);
			ResumeLayout(performLayout: false);
			PerformLayout();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			try
			{
				base.InputValue = Convert.ToDouble(txtShow.Text);
				Modified = true;
				EditorHost.CloseDropDown();
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.ToString());
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Modified = false;
			EditorHost.CloseDropDown();
		}
	}
}
