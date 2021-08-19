using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Script
{
	[ComVisible(false)]
	public class dlgBrowseGACAssembly : Form
	{
		private DotNetAssemblyInfo dotNetAssemblyInfo_0 = null;

		private IContainer icontainer_0 = null;

		private ListView lvwAssembly;

		private ColumnHeader columnHeader_0;

		private ColumnHeader columnHeader_1;

		private Button cmdOK;

		private Button cmdCancel;

		private ColumnHeader columnHeader_2;

		public DotNetAssemblyInfo SelectedAssembly
		{
			get
			{
				return dotNetAssemblyInfo_0;
			}
			set
			{
				dotNetAssemblyInfo_0 = value;
			}
		}

		public dlgBrowseGACAssembly()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgBrowseGACAssembly_Load(object sender, EventArgs e)
		{
			foreach (DotNetAssemblyInfo global in DotNetAssemblyInfoList.GlobalList)
			{
				ListViewItem listViewItem = new ListViewItem(global.Name);
				listViewItem.SubItems.Add(global.VersionString);
				listViewItem.SubItems.Add(global.FileName);
				listViewItem.Tag = global;
				lvwAssembly.Items.Add(listViewItem);
			}
		}

		private void cmdOK_Click(object sender, EventArgs e)
		{
			if (lvwAssembly.SelectedItems.Count > 0)
			{
				ListViewItem listViewItem = lvwAssembly.SelectedItems[0];
				dotNetAssemblyInfo_0 = (DotNetAssemblyInfo)listViewItem.Tag;
				base.DialogResult = DialogResult.OK;
				Close();
			}
		}

		private void cmdCancel_Click(object sender, EventArgs e)
		{
			Close();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Script.dlgBrowseGACAssembly));
			lvwAssembly = new System.Windows.Forms.ListView();
			columnHeader_0 = new System.Windows.Forms.ColumnHeader();
			columnHeader_1 = new System.Windows.Forms.ColumnHeader();
			columnHeader_2 = new System.Windows.Forms.ColumnHeader();
			cmdOK = new System.Windows.Forms.Button();
			cmdCancel = new System.Windows.Forms.Button();
			SuspendLayout();
			resources.ApplyResources(lvwAssembly, "lvwAssembly");
			lvwAssembly.Columns.AddRange(new System.Windows.Forms.ColumnHeader[3]
			{
				columnHeader_0,
				columnHeader_1,
				columnHeader_2
			});
			lvwAssembly.FullRowSelect = true;
			lvwAssembly.GridLines = true;
			lvwAssembly.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			lvwAssembly.HideSelection = false;
			lvwAssembly.MultiSelect = false;
			lvwAssembly.Name = "lvwAssembly";
			lvwAssembly.Sorting = System.Windows.Forms.SortOrder.Ascending;
			lvwAssembly.UseCompatibleStateImageBehavior = false;
			lvwAssembly.View = System.Windows.Forms.View.Details;
			resources.ApplyResources(columnHeader_0, "columnHeader1");
			resources.ApplyResources(columnHeader_1, "columnHeader2");
			resources.ApplyResources(columnHeader_2, "columnHeader3");
			resources.ApplyResources(cmdOK, "cmdOK");
			cmdOK.Name = "cmdOK";
			cmdOK.UseVisualStyleBackColor = true;
			cmdOK.Click += new System.EventHandler(cmdOK_Click);
			resources.ApplyResources(cmdCancel, "cmdCancel");
			cmdCancel.Name = "cmdCancel";
			cmdCancel.UseVisualStyleBackColor = true;
			cmdCancel.Click += new System.EventHandler(cmdCancel_Click);
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(cmdCancel);
			base.Controls.Add(cmdOK);
			base.Controls.Add(lvwAssembly);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgBrowseGACAssembly";
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgBrowseGACAssembly_Load);
			ResumeLayout(false);
		}
	}
}
