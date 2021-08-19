using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace DCSoft.Common
{
	[ComVisible(false)]
	public class dlgDCNameValueList : Form
	{
		public class DCNameValueListUITypEditor : UITypeEditor
		{
			public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
			{
				return UITypeEditorEditStyle.Modal;
			}

			public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
			{
				using (dlgDCNameValueList dlgDCNameValueList = new dlgDCNameValueList())
				{
					dlgDCNameValueList.InputList = (DCNameValueList)value;
					IWindowsFormsEditorService windowsFormsEditorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
					if (windowsFormsEditorService.ShowDialog(dlgDCNameValueList) == DialogResult.OK)
					{
						return dlgDCNameValueList.InputList.Clone();
					}
				}
				return value;
			}
		}

		private DCNameValueList dcnameValueList_0 = null;

		private IContainer icontainer_0 = null;

		private ToolStrip toolStrip1;

		private ToolStripButton btnNewItem;

		private ToolStripButton btnDelete;

		private DataGridView dgvItems;

		private DataGridViewTextBoxColumn Column1;

		private DataGridViewTextBoxColumn Column2;

		private Button btnOK;

		private Button btnCancel;

		public DCNameValueList InputList
		{
			get
			{
				return dcnameValueList_0;
			}
			set
			{
				dcnameValueList_0 = value;
			}
		}

		public dlgDCNameValueList()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgDCNameValueList_Load(object sender, EventArgs e)
		{
			if (dcnameValueList_0 != null)
			{
				foreach (DCNameValueItem item in dcnameValueList_0)
				{
					dgvItems.Rows.Add(item.Name, item.Value);
				}
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (dcnameValueList_0 == null)
			{
				dcnameValueList_0 = new DCNameValueList();
			}
			dcnameValueList_0.Clear();
			for (int i = 0; i < dgvItems.Rows.Count; i++)
			{
				if (i != dgvItems.NewRowIndex)
				{
					dcnameValueList_0.Add(new DCNameValueItem(Convert.ToString(dgvItems.Rows[i].Cells[0].Value), Convert.ToString(dgvItems.Rows[i].Cells[1].Value)));
				}
			}
			base.DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnNewItem_Click(object sender, EventArgs e)
		{
			dgvItems.Rows[dgvItems.NewRowIndex].Cells[0].Selected = true;
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			if (dgvItems.CurrentRow != null && dgvItems.CurrentRow.Index != dgvItems.NewRowIndex)
			{
				dgvItems.Rows.Remove(dgvItems.CurrentRow);
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Common.dlgDCNameValueList));
			toolStrip1 = new System.Windows.Forms.ToolStrip();
			btnNewItem = new System.Windows.Forms.ToolStripButton();
			btnDelete = new System.Windows.Forms.ToolStripButton();
			dgvItems = new System.Windows.Forms.DataGridView();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			toolStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dgvItems).BeginInit();
			SuspendLayout();
			toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[2]
			{
				btnNewItem,
				btnDelete
			});
			toolStrip1.Location = new System.Drawing.Point(0, 0);
			toolStrip1.Name = "toolStrip1";
			toolStrip1.ShowItemToolTips = false;
			toolStrip1.Size = new System.Drawing.Size(438, 25);
			toolStrip1.TabIndex = 0;
			toolStrip1.Text = "toolStrip1";
			btnNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			btnNewItem.Image = (System.Drawing.Image)resources.GetObject("btnNewItem.Image");
			btnNewItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			btnNewItem.Name = "btnNewItem";
			btnNewItem.Size = new System.Drawing.Size(36, 22);
			btnNewItem.Text = "新增";
			btnNewItem.Click += new System.EventHandler(btnNewItem_Click);
			btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			btnDelete.Image = (System.Drawing.Image)resources.GetObject("btnDelete.Image");
			btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
			btnDelete.Name = "btnDelete";
			btnDelete.Size = new System.Drawing.Size(36, 22);
			btnDelete.Text = "删除";
			btnDelete.Click += new System.EventHandler(btnDelete_Click);
			dgvItems.BackgroundColor = System.Drawing.SystemColors.Control;
			dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvItems.Columns.AddRange(Column1, Column2);
			dgvItems.Dock = System.Windows.Forms.DockStyle.Top;
			dgvItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			dgvItems.Location = new System.Drawing.Point(0, 25);
			dgvItems.Name = "dgvItems";
			dgvItems.RowTemplate.Height = 23;
			dgvItems.Size = new System.Drawing.Size(438, 261);
			dgvItems.TabIndex = 1;
			btnOK.Location = new System.Drawing.Point(227, 296);
			btnOK.Name = "btnOK";
			btnOK.Size = new System.Drawing.Size(75, 23);
			btnOK.TabIndex = 2;
			btnOK.Text = "确定(&O)";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			btnCancel.Location = new System.Drawing.Point(322, 296);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(75, 23);
			btnCancel.TabIndex = 3;
			btnCancel.Text = "取消(&C)";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			Column1.HeaderText = "名称";
			Column1.Name = "Column1";
			Column2.HeaderText = "值";
			Column2.Name = "Column2";
			Column2.Width = 200;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(438, 327);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(dgvItems);
			base.Controls.Add(toolStrip1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgDCNameValueList";
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "名称-数值对";
			base.Load += new System.EventHandler(dlgDCNameValueList_Load);
			toolStrip1.ResumeLayout(false);
			toolStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)dgvItems).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
