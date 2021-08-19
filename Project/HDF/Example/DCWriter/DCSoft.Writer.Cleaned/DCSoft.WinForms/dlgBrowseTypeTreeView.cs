using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DCSoft.WinForms
{
	/// <summary>
	///       dlgBrowseTypeTreeView 的摘要说明。
	///       </summary>
	public class dlgBrowseTypeTreeView : Form
	{
		private BrowseTypeTreeView tvwType;

		private Button cmdOK;

		private Button cmdCancel;

		/// <summary>
		///       必需的设计器变量。
		///       </summary>
		private Container components = null;

		private Type mySelectedType = null;

		public Type[] Types
		{
			get
			{
				return tvwType.Types;
			}
			set
			{
				tvwType.Types = value;
			}
		}

		public Type SelectedType
		{
			get
			{
				return mySelectedType;
			}
			set
			{
				mySelectedType = value;
			}
		}

		public dlgBrowseTypeTreeView()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		/// <summary>
		///       清理所有正在使用的资源。
		///       </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		/// <summary>
		///       设计器支持所需的方法 - 不要使用代码编辑器修改
		///       此方法的内容。
		///       </summary>
		private void InitializeComponent()
		{
			tvwType = new DCSoft.WinForms.BrowseTypeTreeView();
			cmdOK = new System.Windows.Forms.Button();
			cmdCancel = new System.Windows.Forms.Button();
			SuspendLayout();
			tvwType.Dock = System.Windows.Forms.DockStyle.Top;
			tvwType.ImageIndex = -1;
			tvwType.Location = new System.Drawing.Point(0, 0);
			tvwType.Name = "tvwType";
			tvwType.SelectedImageIndex = -1;
			tvwType.Size = new System.Drawing.Size(472, 368);
			tvwType.TabIndex = 0;
			cmdOK.Location = new System.Drawing.Point(256, 376);
			cmdOK.Name = "cmdOK";
			cmdOK.TabIndex = 1;
			cmdOK.Text = "确定(&O)";
			cmdOK.Click += new System.EventHandler(cmdOK_Click);
			cmdCancel.Location = new System.Drawing.Point(352, 376);
			cmdCancel.Name = "cmdCancel";
			cmdCancel.TabIndex = 1;
			cmdCancel.Text = "取消(&C)";
			cmdCancel.Click += new System.EventHandler(cmdCancel_Click);
			AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			base.ClientSize = new System.Drawing.Size(472, 406);
			base.Controls.Add(cmdOK);
			base.Controls.Add(tvwType);
			base.Controls.Add(cmdCancel);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgBrowseTypeTreeView";
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "浏览类型";
			base.Load += new System.EventHandler(dlgBrowseTypeTreeView_Load);
			ResumeLayout(false);
		}

		private void dlgBrowseTypeTreeView_Load(object sender, EventArgs e)
		{
			tvwType.RefreshView();
			tvwType.SelectedType = mySelectedType;
		}

		private void cmdOK_Click(object sender, EventArgs e)
		{
			int num = 3;
			Type selectedType = tvwType.SelectedType;
			if (selectedType == null)
			{
				MessageBox.Show(this, "请选择一个节点", "系统提示");
				return;
			}
			mySelectedType = selectedType;
			base.DialogResult = DialogResult.OK;
			Close();
		}

		private void cmdCancel_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
