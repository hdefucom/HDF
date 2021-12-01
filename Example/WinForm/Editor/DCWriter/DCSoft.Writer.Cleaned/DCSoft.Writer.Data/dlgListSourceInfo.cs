using DCSoft.Data.CSV;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using System;
using System.Collections;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Data
{
	/// <summary>
	///       列表来源信息编辑对话框
	///       </summary>
	[ComVisible(false)]
	public class dlgListSourceInfo : Form
	{
		private IContainer icontainer_0 = null;

		private Label label2;

		private ComboBox cboSource;

		private Button btnOK;

		private Button btnCancel;

		private GroupBox groupBox1;

		private DataGridView dgvItems;

		private DataGridViewTextBoxColumn Column1;

		private DataGridViewTextBoxColumn Column2;

		private DataGridViewTextBoxColumn colTextInList;

		private DataGridViewTextBoxColumn colGroup;

		private ToolStrip toolStrip1;

		private ToolStripButton btnDelete;

		private ToolStripButton btnPaste;

		private ListSourceInfo listSourceInfo_0 = null;

		private XTextElement xtextElement_0 = null;

		/// <summary>
		///       列表来源信息对象
		///       </summary>
		public ListSourceInfo ListSource
		{
			get
			{
				return listSourceInfo_0;
			}
			set
			{
				listSourceInfo_0 = value;
			}
		}

		/// <summary>
		///       相关的来源文档元素对象
		///       </summary>
		public XTextElement SourceElement
		{
			get
			{
				return xtextElement_0;
			}
			set
			{
				xtextElement_0 = value;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Data.dlgListSourceInfo));
			label2 = new System.Windows.Forms.Label();
			cboSource = new System.Windows.Forms.ComboBox();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			groupBox1 = new System.Windows.Forms.GroupBox();
			dgvItems = new System.Windows.Forms.DataGridView();
			Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			colTextInList = new System.Windows.Forms.DataGridViewTextBoxColumn();
			colGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
			toolStrip1 = new System.Windows.Forms.ToolStrip();
			btnDelete = new System.Windows.Forms.ToolStripButton();
			btnPaste = new System.Windows.Forms.ToolStripButton();
			groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dgvItems).BeginInit();
			toolStrip1.SuspendLayout();
			SuspendLayout();
			resources.ApplyResources(label2, "label2");
			label2.Name = "label2";
			cboSource.FormattingEnabled = true;
			resources.ApplyResources(cboSource, "cboSource");
			cboSource.Name = "cboSource";
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.Name = "btnOK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			groupBox1.Controls.Add(dgvItems);
			groupBox1.Controls.Add(toolStrip1);
			resources.ApplyResources(groupBox1, "groupBox1");
			groupBox1.Name = "groupBox1";
			groupBox1.TabStop = false;
			dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvItems.Columns.AddRange(Column1, Column2, colTextInList, colGroup);
			resources.ApplyResources(dgvItems, "dgvItems");
			dgvItems.Name = "dgvItems";
			dgvItems.RowTemplate.Height = 23;
			resources.ApplyResources(Column1, "Column1");
			Column1.Name = "Column1";
			resources.ApplyResources(Column2, "Column2");
			Column2.Name = "Column2";
			resources.ApplyResources(colTextInList, "colTextInList");
			colTextInList.Name = "colTextInList";
			resources.ApplyResources(colGroup, "colGroup");
			colGroup.Name = "colGroup";
			toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[2]
			{
				btnDelete,
				btnPaste
			});
			resources.ApplyResources(toolStrip1, "toolStrip1");
			toolStrip1.Name = "toolStrip1";
			toolStrip1.ShowItemToolTips = false;
			btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			resources.ApplyResources(btnDelete, "btnDelete");
			btnDelete.Name = "btnDelete";
			btnDelete.Click += new System.EventHandler(btnDelete_Click);
			btnPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			resources.ApplyResources(btnPaste, "btnPaste");
			btnPaste.Name = "btnPaste";
			btnPaste.Click += new System.EventHandler(btnPaste_Click);
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(groupBox1);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(cboSource);
			base.Controls.Add(label2);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgListSourceInfo";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgListSourceInfo_Load);
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)dgvItems).EndInit();
			toolStrip1.ResumeLayout(false);
			toolStrip1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgListSourceInfo()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgListSourceInfo_Load(object sender, EventArgs e)
		{
			if (xtextElement_0 != null && xtextElement_0.OwnerDocument != null && xtextElement_0.OwnerDocument.EditorControl != null)
			{
				WriterControl editorControl = xtextElement_0.OwnerDocument.EditorControl;
				cboSource.Items.AddRange(editorControl.ListItemsBuffer.GetItemsName());
			}
			if (ListSourceInfo.SupportSourceNames != null)
			{
				cboSource.Items.AddRange(ListSourceInfo.SupportSourceNames);
			}
			if (listSourceInfo_0 != null)
			{
				cboSource.Text = listSourceInfo_0.SourceName;
				if (listSourceInfo_0.Items != null)
				{
					foreach (ListItem item in listSourceInfo_0.Items)
					{
						dgvItems.Rows.Add(item.Text, item.Value, item.TextInList, item.Group);
					}
				}
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (listSourceInfo_0 == null)
			{
				listSourceInfo_0 = new ListSourceInfo();
			}
			listSourceInfo_0.SourceName = cboSource.Text.Trim();
			listSourceInfo_0.Items = new ListItemCollection();
			foreach (DataGridViewRow item in (IEnumerable)dgvItems.Rows)
			{
				if (item.Index != dgvItems.NewRowIndex)
				{
					ListItem listItem = new ListItem();
					listItem.Text = Convert.ToString(item.Cells[0].Value);
					listItem.Value = Convert.ToString(item.Cells[1].Value);
					listItem.TextInList = Convert.ToString(item.Cells[2].Value);
					listItem.Group = Convert.ToString(item.Cells[3].Value);
					listSourceInfo_0.Items.Add(listItem);
				}
			}
			if (listSourceInfo_0.Items.Count == 0)
			{
				listSourceInfo_0.Items = null;
			}
			listSourceInfo_0.RuntimeItems = null;
			base.DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			if (dgvItems.CurrentRow != null && dgvItems.CurrentRow.Index != dgvItems.NewRowIndex)
			{
				dgvItems.Rows.RemoveAt(dgvItems.CurrentRow.Index);
			}
		}

		private void btnPaste_Click(object sender, EventArgs e)
		{
			string text = Clipboard.GetText();
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			CSVDataReader cSVDataReader = CSVDataReader.FromTabString(text);
			cSVDataReader.IsFirstRowAsColumnNames = false;
			if (cSVDataReader != null)
			{
				while (cSVDataReader.Read())
				{
					object[] values = new object[cSVDataReader.FieldCount];
					cSVDataReader.GetValues(values);
					dgvItems.Rows.Add(values);
				}
				cSVDataReader.Close();
			}
		}
	}
}
