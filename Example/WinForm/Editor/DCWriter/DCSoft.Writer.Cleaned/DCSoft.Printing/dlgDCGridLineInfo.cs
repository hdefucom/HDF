using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Printing
{
	[ComVisible(false)]
	public class dlgDCGridLineInfo : Form
	{
		private IContainer icontainer_0 = null;

		private ComboBox cboLineStyle;

		private CheckBox chkShowGridLine;

		private Button btnCancel;

		private CheckBox chkPrintGridLine;

		private Button btnOK;

		private GClass304 btnGridLineColor;

		private Panel pnlGridLine;

		private NumericUpDown txtGridLineSpan;

		private Label label3;

		private Label label2;

		private Label label1;

		private CheckBox chkAlignToGrid;

		private DCGridLineInfo dcgridLineInfo_0 = null;

		public DCGridLineInfo InputGridLineInfo
		{
			get
			{
				return dcgridLineInfo_0;
			}
			set
			{
				dcgridLineInfo_0 = value;
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
			cboLineStyle = new System.Windows.Forms.ComboBox();
			chkShowGridLine = new System.Windows.Forms.CheckBox();
			btnCancel = new System.Windows.Forms.Button();
			chkPrintGridLine = new System.Windows.Forms.CheckBox();
			btnOK = new System.Windows.Forms.Button();
			btnGridLineColor = new DCSoftDotfuscate.GClass304();
			pnlGridLine = new System.Windows.Forms.Panel();
			txtGridLineSpan = new System.Windows.Forms.NumericUpDown();
			label3 = new System.Windows.Forms.Label();
			chkAlignToGrid = new System.Windows.Forms.CheckBox();
			label2 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			pnlGridLine.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)txtGridLineSpan).BeginInit();
			SuspendLayout();
			cboLineStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboLineStyle.FormattingEnabled = true;
			cboLineStyle.Location = new System.Drawing.Point(127, 55);
			cboLineStyle.Name = "cboLineStyle";
			cboLineStyle.Size = new System.Drawing.Size(109, 20);
			cboLineStyle.TabIndex = 3;
			chkShowGridLine.AutoSize = true;
			chkShowGridLine.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			chkShowGridLine.Location = new System.Drawing.Point(3, 12);
			chkShowGridLine.Name = "chkShowGridLine";
			chkShowGridLine.Size = new System.Drawing.Size(84, 16);
			chkShowGridLine.TabIndex = 0;
			chkShowGridLine.Text = "绘制网格线";
			chkShowGridLine.UseVisualStyleBackColor = true;
			chkShowGridLine.CheckedChanged += new System.EventHandler(chkShowGridLine_CheckedChanged);
			btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			btnCancel.Location = new System.Drawing.Point(139, 249);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(95, 23);
			btnCancel.TabIndex = 3;
			btnCancel.Text = "取消(&C)";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			chkPrintGridLine.AutoSize = true;
			chkPrintGridLine.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			chkPrintGridLine.Location = new System.Drawing.Point(12, 162);
			chkPrintGridLine.Name = "chkPrintGridLine";
			chkPrintGridLine.Size = new System.Drawing.Size(84, 16);
			chkPrintGridLine.TabIndex = 7;
			chkPrintGridLine.Text = "打印网格线";
			chkPrintGridLine.UseVisualStyleBackColor = true;
			btnOK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			btnOK.Location = new System.Drawing.Point(38, 249);
			btnOK.Name = "btnOK";
			btnOK.Size = new System.Drawing.Size(95, 23);
			btnOK.TabIndex = 2;
			btnOK.Text = "确定(&O)";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			btnGridLineColor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			btnGridLineColor.Location = new System.Drawing.Point(127, 16);
			btnGridLineColor.Name = "btnGridLineColor";
			btnGridLineColor.method_5(true);
			btnGridLineColor.Size = new System.Drawing.Size(109, 23);
			btnGridLineColor.TabIndex = 1;
			btnGridLineColor.UseVisualStyleBackColor = true;
			pnlGridLine.Controls.Add(txtGridLineSpan);
			pnlGridLine.Controls.Add(label3);
			pnlGridLine.Controls.Add(cboLineStyle);
			pnlGridLine.Controls.Add(chkAlignToGrid);
			pnlGridLine.Controls.Add(chkPrintGridLine);
			pnlGridLine.Controls.Add(btnGridLineColor);
			pnlGridLine.Controls.Add(label2);
			pnlGridLine.Controls.Add(label1);
			pnlGridLine.Location = new System.Drawing.Point(12, 34);
			pnlGridLine.Name = "pnlGridLine";
			pnlGridLine.Size = new System.Drawing.Size(253, 196);
			pnlGridLine.TabIndex = 1;
			txtGridLineSpan.DecimalPlaces = 2;
			txtGridLineSpan.Increment = new decimal(new int[4]
			{
				1,
				0,
				0,
				65536
			});
			txtGridLineSpan.Location = new System.Drawing.Point(127, 90);
			txtGridLineSpan.Name = "txtGridLineSpan";
			txtGridLineSpan.Size = new System.Drawing.Size(109, 21);
			txtGridLineSpan.TabIndex = 5;
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(10, 92);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(77, 12);
			label3.TabIndex = 4;
			label3.Text = "跨度(厘米)：";
			chkAlignToGrid.AutoSize = true;
			chkAlignToGrid.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			chkAlignToGrid.Location = new System.Drawing.Point(12, 127);
			chkAlignToGrid.Name = "chkAlignToGrid";
			chkAlignToGrid.Size = new System.Drawing.Size(132, 16);
			chkAlignToGrid.TabIndex = 6;
			chkAlignToGrid.Text = "文本行对齐到网格线";
			chkAlignToGrid.UseVisualStyleBackColor = true;
			label2.AutoSize = true;
			label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			label2.Location = new System.Drawing.Point(10, 55);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(77, 12);
			label2.TabIndex = 2;
			label2.Text = "网格线样式：";
			label1.AutoSize = true;
			label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			label1.Location = new System.Drawing.Point(10, 21);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(77, 12);
			label1.TabIndex = 0;
			label1.Text = "网格线颜色：";
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = btnCancel;
			base.ClientSize = new System.Drawing.Size(280, 287);
			base.Controls.Add(chkShowGridLine);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(pnlGridLine);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgDCGridLineInfo";
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "网格线设置";
			base.Load += new System.EventHandler(dlgDCGridLineInfo_Load);
			pnlGridLine.ResumeLayout(false);
			pnlGridLine.PerformLayout();
			((System.ComponentModel.ISupportInitialize)txtGridLineSpan).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		public dlgDCGridLineInfo()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgDCGridLineInfo_Load(object sender, EventArgs e)
		{
			GClass11.smethod_0(cboLineStyle);
			if (dcgridLineInfo_0 == null)
			{
				dcgridLineInfo_0 = new DCGridLineInfo();
			}
			chkShowGridLine.Checked = dcgridLineInfo_0.Visible;
			btnGridLineColor.method_1(dcgridLineInfo_0.Color);
			chkPrintGridLine.Checked = dcgridLineInfo_0.Printable;
			cboLineStyle.SelectedItem = dcgridLineInfo_0.LineStyle;
			txtGridLineSpan.Value = (decimal)dcgridLineInfo_0.GridSpanInCM;
			chkAlignToGrid.Checked = dcgridLineInfo_0.AlignToGridLine;
			chkShowGridLine_CheckedChanged(null, null);
		}

		private void chkShowGridLine_CheckedChanged(object sender, EventArgs e)
		{
			pnlGridLine.Enabled = chkShowGridLine.Checked;
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (dcgridLineInfo_0 == null)
			{
				dcgridLineInfo_0 = new DCGridLineInfo();
			}
			dcgridLineInfo_0.Visible = chkShowGridLine.Checked;
			dcgridLineInfo_0.Color = btnGridLineColor.method_0();
			dcgridLineInfo_0.AlignToGridLine = chkAlignToGrid.Checked;
			dcgridLineInfo_0.GridSpanInCM = (float)txtGridLineSpan.Value;
			dcgridLineInfo_0.LineStyle = (DashStyle)cboLineStyle.SelectedItem;
			dcgridLineInfo_0.Printable = chkPrintGridLine.Checked;
			base.DialogResult = DialogResult.OK;
			Close();
		}
	}
}
