using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.FriedmanCurveChart
{
	/// <summary>
	///       编辑多个标题和内容的窗体
	///       </summary>
	[ComVisible(false)]
	public class FCdlgTitleValues : Form
	{
		private IContainer icontainer_0 = null;

		private DataGridView dgvLabels;

		private DataGridViewTextBoxColumn Column1;

		private DataGridViewTextBoxColumn Column2;

		private Button btnOK;

		private Button btnCancel;

		private List<string> list_0 = new List<string>();

		private List<string> list_1 = new List<string>();

		/// <summary>
		///       标题列表
		///       </summary>
		public List<string> InputTitles => list_0;

		/// <summary>
		///       数值列表
		///       </summary>
		public List<string> InputValues => list_1;

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
			dgvLabels = new System.Windows.Forms.DataGridView();
			Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)dgvLabels).BeginInit();
			SuspendLayout();
			dgvLabels.AllowUserToAddRows = false;
			dgvLabels.AllowUserToDeleteRows = false;
			dgvLabels.AllowUserToOrderColumns = true;
			dgvLabels.AllowUserToResizeRows = false;
			dgvLabels.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
			dgvLabels.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvLabels.Columns.AddRange(Column1, Column2);
			dgvLabels.Dock = System.Windows.Forms.DockStyle.Top;
			dgvLabels.Location = new System.Drawing.Point(0, 0);
			dgvLabels.Name = "dgvLabels";
			dgvLabels.RowHeadersVisible = false;
			dgvLabels.RowTemplate.Height = 23;
			dgvLabels.Size = new System.Drawing.Size(459, 307);
			dgvLabels.TabIndex = 0;
			dataGridViewCellStyle.BackColor = System.Drawing.SystemColors.Control;
			Column1.DefaultCellStyle = dataGridViewCellStyle;
			Column1.HeaderText = "标题";
			Column1.Name = "Column1";
			Column1.ReadOnly = true;
			Column1.Width = 150;
			Column2.HeaderText = "内容";
			Column2.Name = "Column2";
			Column2.Width = 280;
			btnOK.Location = new System.Drawing.Point(120, 328);
			btnOK.Name = "btnOK";
			btnOK.Size = new System.Drawing.Size(103, 23);
			btnOK.TabIndex = 1;
			btnOK.Text = "确定(&O)";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			btnCancel.Location = new System.Drawing.Point(256, 328);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(103, 23);
			btnCancel.TabIndex = 2;
			btnCancel.Text = "取消(&C)";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(459, 363);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(dgvLabels);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgTitleValues";
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "编辑标题";
			base.Load += new System.EventHandler(FCdlgTitleValues_Load);
			((System.ComponentModel.ISupportInitialize)dgvLabels).EndInit();
			ResumeLayout(false);
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public FCdlgTitleValues()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void FCdlgTitleValues_Load(object sender, EventArgs e)
		{
			int num = Math.Max(InputTitles.Count, InputValues.Count);
			for (int i = 0; i < num; i++)
			{
				dgvLabels.Rows.Add(InputTitles[i], InputValues[i]);
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			int num = Math.Max(InputTitles.Count, InputValues.Count);
			for (int i = 0; i < num; i++)
			{
				InputValues[i] = Convert.ToString(dgvLabels.Rows[i].Cells[1].Value);
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
