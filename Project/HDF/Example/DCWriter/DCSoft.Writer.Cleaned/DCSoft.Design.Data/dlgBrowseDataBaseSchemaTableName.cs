using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace DCSoft.Design.Data
{
	[ComVisible(false)]
	public class dlgBrowseDataBaseSchemaTableName : Form
	{
		private IContainer icontainer_0 = null;

		private ListView lvwTable;

		private ColumnHeader columnHeader_0;

		private ColumnHeader columnHeader_1;

		private ColumnHeader columnHeader_2;

		private Button btnOK;

		private Button btnCancel;

		private string string_0 = null;

		private DataBaseSchemaTable dataBaseSchemaTable_0 = null;

		private DataBaseSchemaTable[] dataBaseSchemaTable_1 = null;

		private DataBaseSchema dataBaseSchema_0 = DataBaseSchema.Instance;

		/// <summary>
		///       选择的数据表的名称
		///       </summary>
		public string SelectedTableName
		{
			get
			{
				return string_0;
			}
			set
			{
				string_0 = value;
			}
		}

		/// <summary>
		///       能否多选项目
		///       </summary>
		public bool AllowMultiSelect
		{
			get
			{
				return lvwTable.MultiSelect;
			}
			set
			{
				lvwTable.MultiSelect = value;
			}
		}

		/// <summary>
		///       选择的数据表信息对象
		///       </summary>
		public DataBaseSchemaTable SelectedTableInfo => dataBaseSchemaTable_0;

		/// <summary>
		///       选择的数据表信息对象数组
		///       </summary>
		public DataBaseSchemaTable[] SelectedTableInfos => dataBaseSchemaTable_1;

		/// <summary>
		///       数据结构信息对象
		///       </summary>
		public DataBaseSchema DBSchema
		{
			get
			{
				return dataBaseSchema_0;
			}
			set
			{
				dataBaseSchema_0 = value;
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
			lvwTable = new System.Windows.Forms.ListView();
			columnHeader_0 = new System.Windows.Forms.ColumnHeader();
			columnHeader_1 = new System.Windows.Forms.ColumnHeader();
			columnHeader_2 = new System.Windows.Forms.ColumnHeader();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			SuspendLayout();
			lvwTable.Columns.AddRange(new System.Windows.Forms.ColumnHeader[3]
			{
				columnHeader_0,
				columnHeader_1,
				columnHeader_2
			});
			lvwTable.Dock = System.Windows.Forms.DockStyle.Top;
			lvwTable.FullRowSelect = true;
			lvwTable.GridLines = true;
			lvwTable.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			lvwTable.HideSelection = false;
			lvwTable.Location = new System.Drawing.Point(0, 0);
			lvwTable.MultiSelect = false;
			lvwTable.Name = "lvwTable";
			lvwTable.Size = new System.Drawing.Size(436, 300);
			lvwTable.TabIndex = 0;
			lvwTable.UseCompatibleStateImageBehavior = false;
			lvwTable.View = System.Windows.Forms.View.Details;
			columnHeader_0.Text = "名称";
			columnHeader_0.Width = 167;
			columnHeader_1.Text = "类型";
			columnHeader_1.Width = 81;
			columnHeader_2.Text = "说明";
			columnHeader_2.Width = 141;
			btnOK.Location = new System.Drawing.Point(146, 309);
			btnOK.Name = "btnOK";
			btnOK.Size = new System.Drawing.Size(109, 23);
			btnOK.TabIndex = 1;
			btnOK.Text = "确定（&O)";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			btnCancel.Location = new System.Drawing.Point(287, 309);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(109, 23);
			btnCancel.TabIndex = 2;
			btnCancel.Text = "取消(&C)";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = btnCancel;
			base.ClientSize = new System.Drawing.Size(436, 341);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(lvwTable);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgBrowseDataBaseSchemaTableName";
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "选择数据表";
			base.Load += new System.EventHandler(dlgBrowseDataBaseSchemaTableName_Load);
			ResumeLayout(false);
		}

		public dlgBrowseDataBaseSchemaTableName()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgBrowseDataBaseSchemaTableName_Load(object sender, EventArgs e)
		{
			if (dataBaseSchema_0 != null)
			{
				ListViewItem listViewItem = null;
				foreach (DataBaseSchemaTable table in dataBaseSchema_0.Tables)
				{
					ListViewItem listViewItem2 = new ListViewItem();
					listViewItem2.Text = table.Name;
					listViewItem2.SubItems.Add(table.Style.ToString());
					listViewItem2.SubItems.Add(table.Description);
					listViewItem2.Tag = table;
					lvwTable.Items.Add(listViewItem2);
					if (string.Compare(table.Name, SelectedTableName, ignoreCase: true) == 0)
					{
						listViewItem = listViewItem2;
					}
				}
				if (listViewItem != null)
				{
					listViewItem.Selected = true;
					listViewItem.EnsureVisible();
				}
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			int num = 9;
			if (lvwTable.SelectedItems.Count > 0)
			{
				ListViewItem listViewItem = lvwTable.SelectedItems[0];
				SelectedTableName = listViewItem.Text;
				dataBaseSchemaTable_0 = (DataBaseSchemaTable)listViewItem.Tag;
				dataBaseSchemaTable_1 = new DataBaseSchemaTable[1]
				{
					dataBaseSchemaTable_0
				};
				if (AllowMultiSelect)
				{
					List<DataBaseSchemaTable> list = new List<DataBaseSchemaTable>();
					StringBuilder stringBuilder = new StringBuilder();
					foreach (ListViewItem selectedItem in lvwTable.SelectedItems)
					{
						DataBaseSchemaTable dataBaseSchemaTable = (DataBaseSchemaTable)selectedItem.Tag;
						list.Add(dataBaseSchemaTable);
						if (stringBuilder.Length > 0)
						{
							stringBuilder.Append(",");
						}
						stringBuilder.Append(dataBaseSchemaTable.Name);
					}
					string_0 = stringBuilder.ToString();
					dataBaseSchemaTable_1 = list.ToArray();
				}
				base.DialogResult = DialogResult.OK;
				Close();
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
