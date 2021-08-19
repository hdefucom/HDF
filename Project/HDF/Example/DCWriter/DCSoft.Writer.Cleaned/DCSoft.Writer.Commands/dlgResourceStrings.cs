using DCSoft.Writer.Controls;
using DCSoftDotfuscate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       编辑字符串资源对话框
	///       </summary>
	[ComVisible(false)]
	public class dlgResourceStrings : Form
	{
		private WriterControl writerControl_0 = null;

		private IContainer icontainer_0 = null;

		private Panel panel1;

		private DataGridView dgvStringResource;

		private DataGridViewTextBoxColumn Column1;

		private DataGridViewTextBoxColumn Column2;

		private ToolStrip toolStrip1;

		private ToolStripButton btnCopy;

		private Label label1;

		/// <summary>
		///       编辑器控件
		///       </summary>
		public WriterControl WriterControl
		{
			get
			{
				return writerControl_0;
			}
			set
			{
				writerControl_0 = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgResourceStrings()
		{
			InitializeComponent();
		}

		private void dlgResourceStrings_Load(object sender, EventArgs e)
		{
			Cursor = Cursors.WaitCursor;
			try
			{
				List<string> list = GClass380.smethod_2();
				for (int i = 0; i < list.Count; i += 2)
				{
					dgvStringResource.Rows.Add(list[i], list[i + 1]);
				}
			}
			finally
			{
				Cursor = Cursors.Default;
			}
		}

		private void btnCopy_Click(object sender, EventArgs e)
		{
			try
			{
				dgvStringResource.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
				Clipboard.SetDataObject(dgvStringResource.GetClipboardContent());
			}
			catch (Exception)
			{
				throw;
			}
		}

		private void dgvStringResource_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				if (e.RowIndex >= 0)
				{
					DataGridViewRow dataGridViewRow = dgvStringResource.Rows[e.RowIndex];
					WriterControl.SetResourceStringValue(Convert.ToString(dataGridViewRow.Cells[0].Value), Convert.ToString(dataGridViewRow.Cells[1].Value));
					dataGridViewRow.Cells[1].Style.ForeColor = Color.Red;
				}
			}
			catch (Exception)
			{
				throw;
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Commands.dlgResourceStrings));
			panel1 = new System.Windows.Forms.Panel();
			dgvStringResource = new System.Windows.Forms.DataGridView();
			Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			toolStrip1 = new System.Windows.Forms.ToolStrip();
			btnCopy = new System.Windows.Forms.ToolStripButton();
			label1 = new System.Windows.Forms.Label();
			panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dgvStringResource).BeginInit();
			toolStrip1.SuspendLayout();
			SuspendLayout();
			panel1.Controls.Add(dgvStringResource);
			panel1.Controls.Add(toolStrip1);
			panel1.Controls.Add(label1);
			resources.ApplyResources(panel1, "panel1");
			panel1.Name = "panel1";
			dgvStringResource.AllowUserToAddRows = false;
			dgvStringResource.AllowUserToDeleteRows = false;
			dgvStringResource.AllowUserToOrderColumns = true;
			dgvStringResource.AllowUserToResizeRows = false;
			dgvStringResource.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvStringResource.Columns.AddRange(Column1, Column2);
			resources.ApplyResources(dgvStringResource, "dgvStringResource");
			dgvStringResource.Name = "dgvStringResource";
			dgvStringResource.RowHeadersVisible = false;
			dgvStringResource.RowTemplate.Height = 23;
			dgvStringResource.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(dgvStringResource_CellValueChanged);
			dataGridViewCellStyle.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			Column1.DefaultCellStyle = dataGridViewCellStyle;
			resources.ApplyResources(Column1, "Column1");
			Column1.Name = "Column1";
			Column1.ReadOnly = true;
			Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			resources.ApplyResources(Column2, "Column2");
			Column2.Name = "Column2";
			toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[1]
			{
				btnCopy
			});
			resources.ApplyResources(toolStrip1, "toolStrip1");
			toolStrip1.Name = "toolStrip1";
			btnCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			resources.ApplyResources(btnCopy, "btnCopy");
			btnCopy.Name = "btnCopy";
			btnCopy.Click += new System.EventHandler(btnCopy_Click);
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(panel1);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgResourceStrings";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgResourceStrings_Load);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)dgvStringResource).EndInit();
			toolStrip1.ResumeLayout(false);
			toolStrip1.PerformLayout();
			ResumeLayout(false);
		}
	}
}
