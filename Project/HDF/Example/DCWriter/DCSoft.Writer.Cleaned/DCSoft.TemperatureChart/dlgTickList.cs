using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.TemperatureChart
{
	/// <summary>
	///       时间刻度列表编辑器
	///       </summary>
	[ComVisible(false)]
	public class dlgTickList : Form
	{
		private IContainer icontainer_0 = null;

		private ToolStrip toolStrip1;

		private DataGridView dgvTicks;

		private DataGridViewTextBoxColumn Column1;

		private DataGridViewTextBoxColumn Column2;

		private DataGridViewTextBoxColumn Column3;

		private ToolStripButton btnDelete;

		private ToolStripSeparator toolStripSeparator1;

		private ToolStripTextBox txtSeconds;

		private ToolStripButton btnSetTickBySeconds;

		private ToolStripSeparator toolStripSeparator2;

		private ToolStripButton btnOK;

		private ToolStripButton btnCancel;

		private TickInfoList tickInfoList_0 = null;

		/// <summary>
		///       时刻列表
		///       </summary>
		public TickInfoList InputTicks
		{
			get
			{
				return tickInfoList_0;
			}
			set
			{
				tickInfoList_0 = value;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.TemperatureChart.dlgTickList));
			toolStrip1 = new System.Windows.Forms.ToolStrip();
			btnDelete = new System.Windows.Forms.ToolStripButton();
			toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			txtSeconds = new System.Windows.Forms.ToolStripTextBox();
			btnSetTickBySeconds = new System.Windows.Forms.ToolStripButton();
			toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			btnOK = new System.Windows.Forms.ToolStripButton();
			btnCancel = new System.Windows.Forms.ToolStripButton();
			dgvTicks = new System.Windows.Forms.DataGridView();
			Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			toolStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dgvTicks).BeginInit();
			SuspendLayout();
			toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[7]
			{
				btnDelete,
				toolStripSeparator1,
				txtSeconds,
				btnSetTickBySeconds,
				toolStripSeparator2,
				btnOK,
				btnCancel
			});
			resources.ApplyResources(toolStrip1, "toolStrip1");
			toolStrip1.Name = "toolStrip1";
			toolStrip1.ShowItemToolTips = false;
			btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			resources.ApplyResources(btnDelete, "btnDelete");
			btnDelete.Name = "btnDelete";
			btnDelete.Click += new System.EventHandler(btnDelete_Click);
			toolStripSeparator1.Name = "toolStripSeparator1";
			resources.ApplyResources(toolStripSeparator1, "toolStripSeparator1");
			txtSeconds.Name = "txtSeconds";
			resources.ApplyResources(txtSeconds, "txtSeconds");
			btnSetTickBySeconds.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			resources.ApplyResources(btnSetTickBySeconds, "btnSetTickBySeconds");
			btnSetTickBySeconds.Name = "btnSetTickBySeconds";
			btnSetTickBySeconds.Click += new System.EventHandler(btnSetTickBySeconds_Click);
			toolStripSeparator2.Name = "toolStripSeparator2";
			resources.ApplyResources(toolStripSeparator2, "toolStripSeparator2");
			btnOK.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.Name = "btnOK";
			btnOK.Click += new System.EventHandler(btnOK_Click);
			btnCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			dgvTicks.AllowUserToResizeRows = false;
			dgvTicks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvTicks.Columns.AddRange(Column1, Column2, Column3);
			resources.ApplyResources(dgvTicks, "dgvTicks");
			dgvTicks.Name = "dgvTicks";
			dgvTicks.RowTemplate.Height = 23;
			dgvTicks.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(dgvTicks_CellContentClick);
			resources.ApplyResources(Column1, "Column1");
			Column1.Name = "Column1";
			resources.ApplyResources(Column2, "Column2");
			Column2.Name = "Column2";
			resources.ApplyResources(Column3, "Column3");
			Column3.Name = "Column3";
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(dgvTicks);
			base.Controls.Add(toolStrip1);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgTickList";
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgTickList_Load);
			toolStrip1.ResumeLayout(false);
			toolStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)dgvTicks).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgTickList()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgTickList_Load(object sender, EventArgs e)
		{
			if (tickInfoList_0 != null)
			{
				foreach (TickInfo item in tickInfoList_0)
				{
					dgvTicks.Rows.Add(item.Text, item.Value, ColorTranslator.ToHtml(item.Color));
				}
			}
		}

		private void dgvTicks_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == 2)
			{
				dgvTicks.CancelEdit();
				dgvTicks.EndEdit();
				using (ColorDialog colorDialog = new ColorDialog())
				{
					string text = Convert.ToString(dgvTicks.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
					if (text != null)
					{
						colorDialog.Color = ColorTranslator.FromHtml(text);
					}
					if (colorDialog.ShowDialog(this) == DialogResult.OK)
					{
						dgvTicks.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = ColorTranslator.ToHtml(colorDialog.Color);
					}
				}
			}
		}

		private void btnSetTickBySeconds_Click(object sender, EventArgs e)
		{
			int num = 4;
			int result = 0;
			if (!int.TryParse(txtSeconds.Text, out result))
			{
				return;
			}
			int num2 = 86400 / result;
			if (num2 > 100 && MessageBox.Show(this, DCTimeLineStrings.WarringSmallTickStep, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
			{
				return;
			}
			dgvTicks.Rows.Clear();
			for (int i = 0; i < 86400; i += result)
			{
				DateTime dateTime = new DateTime(1900, 1, 1).AddSeconds(i);
				string text = dateTime.Hour.ToString();
				if (result < 60)
				{
					text = dateTime.ToString("HH:mm:ss");
				}
				else if (result < 3600)
				{
					text = dateTime.ToString("HH:mm");
				}
				dgvTicks.Rows.Add(text, (double)i / 3600.0, ColorTranslator.ToHtml(Color.Black));
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (tickInfoList_0 == null)
			{
				tickInfoList_0 = new TickInfoList();
			}
			else
			{
				tickInfoList_0.Clear();
			}
			foreach (DataGridViewRow item in (IEnumerable)dgvTicks.Rows)
			{
				if (!item.IsNewRow)
				{
					try
					{
						TickInfo tickInfo = new TickInfo();
						tickInfo.Text = Convert.ToString(item.Cells[0].Value);
						tickInfo.Value = Convert.ToSingle(item.Cells[1].Value);
						string text = Convert.ToString(item.Cells[2].Value);
						if (!string.IsNullOrEmpty(text))
						{
							tickInfo.Color = ColorTranslator.FromHtml(text);
						}
						tickInfoList_0.Add(tickInfo);
					}
					catch (Exception ex)
					{
						MessageBox.Show(this, ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
						item.Selected = true;
						return;
					}
				}
			}
			base.DialogResult = DialogResult.OK;
			Close();
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			if (dgvTicks.CurrentRow != null && !dgvTicks.CurrentRow.IsNewRow)
			{
				dgvTicks.Rows.Remove(dgvTicks.CurrentRow);
			}
		}
	}
}
