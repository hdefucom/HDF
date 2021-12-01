using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Data
{
	/// <summary>
	///       项目列表编辑对话框
	///       </summary>
	[ComVisible(false)]
	public class dlgListItems : Form
	{
		private IContainer icontainer_0 = null;

		private Button btnDelete;

		private DataGridView dgvItems;

		private DataGridViewTextBoxColumn Column1;

		private DataGridViewTextBoxColumn Column2;

		private DataGridViewTextBoxColumn colTextInList;

		private DataGridViewTextBoxColumn colGroup;

		private Button btnOK;

		private Button btnCancel;

		private ListItemCollection listItemCollection_0 = null;

		/// <summary>
		///       项目列表对象
		///       </summary>
		public ListItemCollection InputItems
		{
			get
			{
				return listItemCollection_0;
			}
			set
			{
				listItemCollection_0 = value;
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
			btnDelete = new System.Windows.Forms.Button();
			dgvItems = new System.Windows.Forms.DataGridView();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			colTextInList = new System.Windows.Forms.DataGridViewTextBoxColumn();
			colGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)dgvItems).BeginInit();
			SuspendLayout();
			btnDelete.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			btnDelete.Location = new System.Drawing.Point(12, 329);
			btnDelete.Name = "btnDelete";
			btnDelete.Size = new System.Drawing.Size(119, 23);
			btnDelete.TabIndex = 1;
			btnDelete.Text = "删除项目";
			btnDelete.UseVisualStyleBackColor = true;
			btnDelete.Click += new System.EventHandler(btnDelete_Click);
			dgvItems.BackgroundColor = System.Drawing.SystemColors.Control;
			dgvItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvItems.Columns.AddRange(Column1, Column2, colTextInList, colGroup);
			dgvItems.Dock = System.Windows.Forms.DockStyle.Top;
			dgvItems.Location = new System.Drawing.Point(0, 0);
			dgvItems.Name = "dgvItems";
			dgvItems.RowTemplate.Height = 23;
			dgvItems.Size = new System.Drawing.Size(570, 323);
			dgvItems.TabIndex = 0;
			btnOK.Location = new System.Drawing.Point(261, 329);
			btnOK.Name = "btnOK";
			btnOK.Size = new System.Drawing.Size(110, 23);
			btnOK.TabIndex = 2;
			btnOK.Text = "确定(&O)";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			btnCancel.Location = new System.Drawing.Point(386, 329);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(110, 23);
			btnCancel.TabIndex = 2;
			btnCancel.Text = "取消(&C)";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			Column1.HeaderText = "文本";
			Column1.Name = "Column1";
			Column1.Width = 150;
			Column2.HeaderText = "数值";
			Column2.Name = "Column2";
			Column2.Width = 80;
			colTextInList.HeaderText = "指定列表文本";
			colTextInList.Name = "colTextInList";
			colGroup.HeaderText = "分组名";
			colGroup.Name = "colGroup";
			colGroup.Width = 80;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(570, 358);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(dgvItems);
			base.Controls.Add(btnDelete);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgListItems";
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "列表内容";
			base.Load += new System.EventHandler(dlgListItems_Load);
			((System.ComponentModel.ISupportInitialize)dgvItems).EndInit();
			ResumeLayout(false);
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgListItems()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgListItems_Load(object sender, EventArgs e)
		{
			if (listItemCollection_0 != null)
			{
				foreach (ListItem item in listItemCollection_0)
				{
					dgvItems.Rows.Add(item.Text, item.Value, item.TextInList, item.Group);
				}
			}
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			if (dgvItems.CurrentRow != null && dgvItems.CurrentRow.Index != dgvItems.NewRowIndex)
			{
				dgvItems.Rows.RemoveAt(dgvItems.CurrentRow.Index);
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (listItemCollection_0 == null)
			{
				listItemCollection_0 = new ListItemCollection();
			}
			listItemCollection_0.Clear();
			foreach (DataGridViewRow item in (IEnumerable)dgvItems.Rows)
			{
				if (item.Index != dgvItems.NewRowIndex)
				{
					ListItem listItem = new ListItem();
					listItem.Text = Convert.ToString(item.Cells[0].Value);
					listItem.Value = Convert.ToString(item.Cells[1].Value);
					listItem.TextInList = Convert.ToString(item.Cells[2].Value);
					listItem.Group = Convert.ToString(item.Cells[3].Value);
					listItemCollection_0.Add(listItem);
				}
			}
			base.DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
