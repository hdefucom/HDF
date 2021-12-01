using DCSoft.Writer.Dom;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	[ComVisible(false)]
	public class dlgConvertTableElementToDataTable : Form
	{
		private IContainer icontainer_0 = null;

		private Label label1;

		private NumericUpDown txtHeaderRowIndex;

		private Button btnRefresh;

		private DataGridView myDataGridView;

		private Button btnSave;

		private Button btnClose;

		private XTextTableElement xtextTableElement_0 = null;

		public XTextTableElement InputTableElement
		{
			get
			{
				return xtextTableElement_0;
			}
			set
			{
				xtextTableElement_0 = value;
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
			label1 = new System.Windows.Forms.Label();
			txtHeaderRowIndex = new System.Windows.Forms.NumericUpDown();
			btnRefresh = new System.Windows.Forms.Button();
			myDataGridView = new System.Windows.Forms.DataGridView();
			btnSave = new System.Windows.Forms.Button();
			btnClose = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)txtHeaderRowIndex).BeginInit();
			((System.ComponentModel.ISupportInitialize)myDataGridView).BeginInit();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(12, 9);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(113, 12);
			label1.TabIndex = 0;
			label1.Text = "从0开始的标题行号:";
			txtHeaderRowIndex.Location = new System.Drawing.Point(128, 4);
			txtHeaderRowIndex.Name = "txtHeaderRowIndex";
			txtHeaderRowIndex.Size = new System.Drawing.Size(43, 21);
			txtHeaderRowIndex.TabIndex = 1;
			btnRefresh.Location = new System.Drawing.Point(196, 4);
			btnRefresh.Name = "btnRefresh";
			btnRefresh.Size = new System.Drawing.Size(75, 23);
			btnRefresh.TabIndex = 2;
			btnRefresh.Text = "刷新";
			btnRefresh.UseVisualStyleBackColor = true;
			btnRefresh.Click += new System.EventHandler(btnRefresh_Click);
			myDataGridView.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			myDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			myDataGridView.Location = new System.Drawing.Point(2, 33);
			myDataGridView.Name = "myDataGridView";
			myDataGridView.RowTemplate.Height = 23;
			myDataGridView.Size = new System.Drawing.Size(560, 280);
			myDataGridView.TabIndex = 3;
			btnSave.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			btnSave.Location = new System.Drawing.Point(237, 327);
			btnSave.Name = "btnSave";
			btnSave.Size = new System.Drawing.Size(125, 23);
			btnSave.TabIndex = 4;
			btnSave.Text = "保存数据...";
			btnSave.UseVisualStyleBackColor = true;
			btnSave.Click += new System.EventHandler(btnSave_Click);
			btnClose.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			btnClose.Location = new System.Drawing.Point(393, 327);
			btnClose.Name = "btnClose";
			btnClose.Size = new System.Drawing.Size(75, 23);
			btnClose.TabIndex = 5;
			btnClose.Text = "关闭";
			btnClose.UseVisualStyleBackColor = true;
			btnClose.Click += new System.EventHandler(btnClose_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(563, 362);
			base.Controls.Add(btnClose);
			base.Controls.Add(btnSave);
			base.Controls.Add(myDataGridView);
			base.Controls.Add(btnRefresh);
			base.Controls.Add(txtHeaderRowIndex);
			base.Controls.Add(label1);
			base.MinimizeBox = false;
			base.Name = "dlgConvertTableElementToDataTable";
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "将文档表格元素转换为数据表对象";
			base.Load += new System.EventHandler(dlgConvertTableElementToDataTable_Load);
			((System.ComponentModel.ISupportInitialize)txtHeaderRowIndex).EndInit();
			((System.ComponentModel.ISupportInitialize)myDataGridView).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		public dlgConvertTableElementToDataTable()
		{
			InitializeComponent();
		}

		private void dlgConvertTableElementToDataTable_Load(object sender, EventArgs e)
		{
			if (InputTableElement != null)
			{
				txtHeaderRowIndex.Maximum = InputTableElement.Rows.Count - 1;
				txtHeaderRowIndex.Minimum = -1m;
			}
		}

		private void btnRefresh_Click(object sender, EventArgs e)
		{
			int num = 2;
			if (InputTableElement == null)
			{
				return;
			}
			DataTable dataTable = new DataTable();
			dataTable.TableName = "DataTable";
			int num2 = (int)txtHeaderRowIndex.Value;
			if (num2 >= 0 && num2 < InputTableElement.Rows.Count)
			{
				XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)InputTableElement.Rows[num2];
				foreach (XTextTableCellElement cell in xTextTableRowElement.Cells)
				{
					DataColumn dataColumn = new DataColumn();
					dataTable.Columns.Add(dataColumn);
					if (!string.IsNullOrEmpty(cell.Text))
					{
						dataColumn.ColumnName = cell.Text;
					}
					else
					{
						dataColumn.ColumnName = "col" + dataTable.Columns.Count;
					}
				}
			}
			else
			{
				foreach (XTextTableColumnElement column in dataTable.Columns)
				{
					_ = column;
					DataColumn dataColumn2 = new DataColumn();
					dataTable.Columns.Add(dataColumn2);
					dataColumn2.ColumnName = "col" + dataTable.Columns.Count;
				}
				num2 = -1;
			}
			for (int i = num2 + 1; i < InputTableElement.Rows.Count; i++)
			{
				XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)InputTableElement.Rows[i];
				if (xTextTableRowElement.RuntimeVisible)
				{
					DataRow dataRow = dataTable.NewRow();
					for (int j = 0; j < xTextTableRowElement.Cells.Count; j++)
					{
						dataRow[j] = xTextTableRowElement.Cells[j].Text;
					}
					dataTable.Rows.Add(dataRow);
				}
			}
			myDataGridView.DataSource = dataTable;
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			int num = 13;
			DataTable dataTable = (DataTable)myDataGridView.DataSource;
			if (dataTable != null)
			{
				using (SaveFileDialog saveFileDialog = new SaveFileDialog())
				{
					saveFileDialog.Filter = "*.xml|*.xml";
					saveFileDialog.CheckPathExists = true;
					saveFileDialog.OverwritePrompt = true;
					if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
					{
						dataTable.WriteXml(saveFileDialog.FileName, XmlWriteMode.WriteSchema);
					}
				}
			}
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
