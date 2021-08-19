using DCSoft.Writer.Dom;
using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	[ComVisible(false)]
	public class dlgDocmentGridLine : Form
	{
		private XTextDocument xtextDocument_0 = null;

		private GridLineSettings gridLineSettings_0 = new GridLineSettings();

		private IContainer icontainer_0 = null;

		private CheckBox chkShowGridLine;

		private Panel pnlGridLine;

		private CheckBox chkPrintGridLine;

		private GClass304 btnGridLineColor;

		private Label label1;

		private Button btnOK;

		private Button btnCancel;

		private ComboBox cboLineStyle;

		private Label label2;

		private ElementEventTemplate elementEventTemplate1;

		/// <summary>
		///       编辑器文档对象引用
		///       </summary>
		public XTextDocument Document
		{
			get
			{
				return xtextDocument_0;
			}
			set
			{
				xtextDocument_0 = value;
			}
		}

		/// <summary>
		///        网格线信息
		///       </summary>
		public GridLineSettings GridSettings
		{
			get
			{
				return gridLineSettings_0;
			}
			set
			{
				gridLineSettings_0 = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgDocmentGridLine()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgDocmentGridLine_Load(object sender, EventArgs e)
		{
			GClass11.smethod_0(cboLineStyle);
			if (GridSettings != null)
			{
				chkShowGridLine.Checked = GridSettings.ShowGridLine;
				btnGridLineColor.method_1(GridSettings.GridLineColor);
				chkPrintGridLine.Checked = GridSettings.PrintGridLine;
				cboLineStyle.SelectedItem = GridSettings.LineStyle;
			}
			chkShowGridLine_CheckedChanged(null, null);
		}

		private void chkShowGridLine_CheckedChanged(object sender, EventArgs e)
		{
			pnlGridLine.Enabled = chkShowGridLine.Checked;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (GridSettings != null)
			{
				GridSettings.ShowGridLine = chkShowGridLine.Checked;
				GridSettings.PrintGridLine = chkPrintGridLine.Checked;
				GridSettings.GridLineColor = btnGridLineColor.method_0();
				GridSettings.LineStyle = (DashStyle)cboLineStyle.SelectedItem;
			}
			base.DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void method_0(object sender, EventArgs e)
		{
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Commands.dlgDocmentGridLine));
			chkShowGridLine = new System.Windows.Forms.CheckBox();
			pnlGridLine = new System.Windows.Forms.Panel();
			chkPrintGridLine = new System.Windows.Forms.CheckBox();
			btnGridLineColor = new DCSoftDotfuscate.GClass304();
			label1 = new System.Windows.Forms.Label();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			elementEventTemplate1 = new DCSoft.Writer.ElementEventTemplate();
			label2 = new System.Windows.Forms.Label();
			cboLineStyle = new System.Windows.Forms.ComboBox();
			pnlGridLine.SuspendLayout();
			SuspendLayout();
			resources.ApplyResources(chkShowGridLine, "chkShowGridLine");
			chkShowGridLine.Name = "chkShowGridLine";
			chkShowGridLine.UseVisualStyleBackColor = true;
			chkShowGridLine.CheckedChanged += new System.EventHandler(chkShowGridLine_CheckedChanged);
			pnlGridLine.Controls.Add(cboLineStyle);
			pnlGridLine.Controls.Add(chkPrintGridLine);
			pnlGridLine.Controls.Add(btnGridLineColor);
			pnlGridLine.Controls.Add(label2);
			pnlGridLine.Controls.Add(label1);
			resources.ApplyResources(pnlGridLine, "pnlGridLine");
			pnlGridLine.Name = "pnlGridLine";
			resources.ApplyResources(chkPrintGridLine, "chkPrintGridLine");
			chkPrintGridLine.Name = "chkPrintGridLine";
			chkPrintGridLine.UseVisualStyleBackColor = true;
			resources.ApplyResources(btnGridLineColor, "btnGridLineColor");
			btnGridLineColor.Name = "btnGridLineColor";
			btnGridLineColor.method_5(true);
			btnGridLineColor.UseVisualStyleBackColor = true;
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.Name = "btnOK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			elementEventTemplate1.Name = "elementEventTemplate1";
			resources.ApplyResources(label2, "label2");
			label2.Name = "label2";
			cboLineStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboLineStyle.FormattingEnabled = true;
			resources.ApplyResources(cboLineStyle, "cboLineStyle");
			cboLineStyle.Name = "cboLineStyle";
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = btnCancel;
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(pnlGridLine);
			base.Controls.Add(chkShowGridLine);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgDocmentGridLine";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgDocmentGridLine_Load);
			pnlGridLine.ResumeLayout(false);
			pnlGridLine.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
