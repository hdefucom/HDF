using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       命令列表窗体对象
	///       </summary>
	[ComVisible(false)]
	public class dlgCommandList : Form
	{
		private WriterAppHost writerAppHost_0 = WriterAppHost.Default;

		private static Bitmap bitmap_0 = null;

		private IContainer icontainer_0 = null;

		private DataGridView dgvCommands;

		private DataGridViewCheckBoxColumn Column1;

		private DataGridViewImageColumn Column6;

		private DataGridViewTextBoxColumn Column2;

		private DataGridViewTextBoxColumn Column3;

		private DataGridViewTextBoxColumn Column4;

		private DataGridViewTextBoxColumn Column5;

		/// <summary>
		///       编辑器宿主坏境
		///       </summary>
		public WriterAppHost AppHost
		{
			get
			{
				return writerAppHost_0;
			}
			set
			{
				writerAppHost_0 = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgCommandList()
		{
			InitializeComponent();
		}

		private void dlgCommandList_Load(object sender, EventArgs e)
		{
			if (bitmap_0 == null)
			{
				bitmap_0 = new Bitmap(16, 16);
				using (Graphics graphics = Graphics.FromImage(bitmap_0))
				{
					graphics.Clear(Color.White);
				}
			}
			WriterCommandList allCommands = AppHost.CommandContainer.AllCommands;
			dgvCommands.Rows.Clear();
			foreach (WriterCommand item in allCommands)
			{
				int index = dgvCommands.Rows.Add(item.Enable, (item.ToolbarImage == null) ? bitmap_0 : item.ToolbarImage, item.Name, item.Description, (item.Module == null) ? "" : item.Module.Name, item.ShortcutKey);
				dgvCommands.Rows[index].Tag = item;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Commands.dlgCommandList));
			dgvCommands = new System.Windows.Forms.DataGridView();
			Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			Column6 = new System.Windows.Forms.DataGridViewImageColumn();
			Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)dgvCommands).BeginInit();
			SuspendLayout();
			dgvCommands.AllowUserToAddRows = false;
			dgvCommands.AllowUserToDeleteRows = false;
			dgvCommands.AllowUserToResizeRows = false;
			dgvCommands.BackgroundColor = System.Drawing.SystemColors.Control;
			dgvCommands.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvCommands.Columns.AddRange(Column1, Column6, Column2, Column3, Column4, Column5);
			resources.ApplyResources(dgvCommands, "dgvCommands");
			dgvCommands.Name = "dgvCommands";
			dgvCommands.RowHeadersVisible = false;
			dgvCommands.RowTemplate.Height = 23;
			resources.ApplyResources(Column1, "Column1");
			Column1.Name = "Column1";
			Column1.ReadOnly = true;
			resources.ApplyResources(Column6, "Column6");
			Column6.Name = "Column6";
			Column6.ReadOnly = true;
			resources.ApplyResources(Column2, "Column2");
			Column2.Name = "Column2";
			Column2.ReadOnly = true;
			resources.ApplyResources(Column3, "Column3");
			Column3.Name = "Column3";
			Column3.ReadOnly = true;
			resources.ApplyResources(Column4, "Column4");
			Column4.Name = "Column4";
			Column4.ReadOnly = true;
			resources.ApplyResources(Column5, "Column5");
			Column5.Name = "Column5";
			Column5.ReadOnly = true;
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(dgvCommands);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgCommandList";
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgCommandList_Load);
			((System.ComponentModel.ISupportInitialize)dgvCommands).EndInit();
			ResumeLayout(false);
		}
	}
}
