using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.TemperatureChart
{
	/// <summary>
	///       时间轴数据窗口
	///       </summary>
	[ComVisible(false)]
	public class frmTimeLineData : Form
	{
		/// <summary>
		///       Required designer variable.
		///       </summary>
		private IContainer components = null;

		private Panel pnlTitle;

		private ToolStrip toolStrip1;

		private DataGridView dgvData;

		/// <summary>
		///       Clean up any resources being used.
		///       </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		/// <summary>
		///       Required method for Designer support - do not modify
		///       the contents of this method with the code editor.
		///       </summary>
		private void InitializeComponent()
		{
			pnlTitle = new System.Windows.Forms.Panel();
			toolStrip1 = new System.Windows.Forms.ToolStrip();
			dgvData = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
			SuspendLayout();
			pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
			pnlTitle.Location = new System.Drawing.Point(0, 25);
			pnlTitle.Name = "pnlTitle";
			pnlTitle.Size = new System.Drawing.Size(702, 35);
			pnlTitle.TabIndex = 0;
			toolStrip1.Location = new System.Drawing.Point(0, 0);
			toolStrip1.Name = "toolStrip1";
			toolStrip1.Size = new System.Drawing.Size(702, 25);
			toolStrip1.TabIndex = 2;
			toolStrip1.Text = "toolStrip1";
			dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
			dgvData.Location = new System.Drawing.Point(0, 60);
			dgvData.Name = "dgvData";
			dgvData.RowTemplate.Height = 23;
			dgvData.Size = new System.Drawing.Size(702, 294);
			dgvData.TabIndex = 3;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(702, 354);
			base.Controls.Add(dgvData);
			base.Controls.Add(pnlTitle);
			base.Controls.Add(toolStrip1);
			base.MinimizeBox = false;
			base.Name = "frmTimeLineData";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "时间轴数据";
			((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public frmTimeLineData()
		{
			InitializeComponent();
		}
	}
}
