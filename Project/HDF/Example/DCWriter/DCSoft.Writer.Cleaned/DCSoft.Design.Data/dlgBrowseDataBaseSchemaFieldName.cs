using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Design.Data
{
	[ComVisible(false)]
	public class dlgBrowseDataBaseSchemaFieldName : Form
	{
		private IContainer icontainer_0 = null;

		private Button btnOK;

		private ListView lvwFields;

		private ColumnHeader columnHeader_0;

		private ColumnHeader columnHeader_1;

		private ColumnHeader columnHeader_2;

		private Button btnCancel;

		private DataBaseSchemaTable dataBaseSchemaTable_0 = null;

		private string string_0 = null;

		public DataBaseSchemaTable InputDataTable
		{
			get
			{
				return dataBaseSchemaTable_0;
			}
			set
			{
				dataBaseSchemaTable_0 = value;
			}
		}

		public string SelectedFieldName
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
			btnOK = new System.Windows.Forms.Button();
			lvwFields = new System.Windows.Forms.ListView();
			columnHeader_0 = new System.Windows.Forms.ColumnHeader();
			columnHeader_1 = new System.Windows.Forms.ColumnHeader();
			columnHeader_2 = new System.Windows.Forms.ColumnHeader();
			btnCancel = new System.Windows.Forms.Button();
			SuspendLayout();
			btnOK.Location = new System.Drawing.Point(177, 295);
			btnOK.Name = "btnOK";
			btnOK.Size = new System.Drawing.Size(109, 23);
			btnOK.TabIndex = 4;
			btnOK.Text = "确定（&O)";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			lvwFields.Columns.AddRange(new System.Windows.Forms.ColumnHeader[3]
			{
				columnHeader_0,
				columnHeader_1,
				columnHeader_2
			});
			lvwFields.Dock = System.Windows.Forms.DockStyle.Top;
			lvwFields.FullRowSelect = true;
			lvwFields.GridLines = true;
			lvwFields.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			lvwFields.HideSelection = false;
			lvwFields.Location = new System.Drawing.Point(0, 0);
			lvwFields.MultiSelect = false;
			lvwFields.Name = "lvwFields";
			lvwFields.Size = new System.Drawing.Size(448, 279);
			lvwFields.TabIndex = 3;
			lvwFields.UseCompatibleStateImageBehavior = false;
			lvwFields.View = System.Windows.Forms.View.Details;
			columnHeader_0.Text = "名称";
			columnHeader_0.Width = 167;
			columnHeader_1.Text = "类型";
			columnHeader_1.Width = 91;
			columnHeader_2.Text = "说明";
			columnHeader_2.Width = 141;
			btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			btnCancel.Location = new System.Drawing.Point(318, 295);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(109, 23);
			btnCancel.TabIndex = 5;
			btnCancel.Text = "取消(&C)";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = btnCancel;
			base.ClientSize = new System.Drawing.Size(448, 330);
			base.Controls.Add(btnOK);
			base.Controls.Add(lvwFields);
			base.Controls.Add(btnCancel);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgBrowseDataBaseSchemaFieldName";
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "选择字段";
			base.Load += new System.EventHandler(dlgBrowseDataBaseSchemaFieldName_Load);
			ResumeLayout(false);
		}

		public dlgBrowseDataBaseSchemaFieldName()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgBrowseDataBaseSchemaFieldName_Load(object sender, EventArgs e)
		{
			if (InputDataTable != null)
			{
				ListViewItem listViewItem = null;
				foreach (DataBaseSchemaField field in InputDataTable.Fields)
				{
					ListViewItem listViewItem2 = new ListViewItem();
					listViewItem2.Text = field.Name;
					listViewItem2.SubItems.Add(field.FieldType);
					listViewItem2.SubItems.Add(field.Description);
					if (string.Compare(listViewItem2.Text, SelectedFieldName, ignoreCase: true) == 0)
					{
						listViewItem = listViewItem2;
					}
					lvwFields.Items.Add(listViewItem2);
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
			if (lvwFields.SelectedItems.Count > 0)
			{
				SelectedFieldName = lvwFields.SelectedItems[0].Text;
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
