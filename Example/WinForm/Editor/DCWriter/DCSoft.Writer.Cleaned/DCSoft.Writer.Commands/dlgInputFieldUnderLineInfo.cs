using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       编辑器命令InputFieldUnderLine自带的命令参数编辑窗体类
	///       </summary>
	[ComVisible(false)]
	public class dlgInputFieldUnderLineInfo : Form
	{
		public InputFieldUnderLineCommandParameter inputFieldUnderLineCommandParameter_0 = null;

		public bool bool_0 = false;

		private IContainer icontainer_0 = null;

		private Label lblLineStyle;

		private Label lblLineWidth;

		private Label lblLineLength;

		private Label lblLineColor;

		private NumericUpDown numLineWidth;

		private NumericUpDown numLineLength;

		private ComboBox cboboxLineStyle;

		private CheckBox chkUseLength;

		private RadioButton rdobtnAddLine;

		private RadioButton rdobtnRemoveLine;

		private Button btnLineColor;

		private Panel panel1;

		private Button btnOK;

		private Button btnCancel;

		/// <summary>
		///       默认构造函数
		///       </summary>
		public dlgInputFieldUnderLineInfo()
		{
			InitializeComponent();
			inputFieldUnderLineCommandParameter_0 = new InputFieldUnderLineCommandParameter();
			base.DialogResult = DialogResult.Cancel;
			numLineLength.Maximum = decimal.MaxValue;
		}

		/// <summary>
		///       带参数的构造函数
		///       </summary>
		/// <param name="par">
		/// </param>
		public dlgInputFieldUnderLineInfo(InputFieldUnderLineCommandParameter inputFieldUnderLineCommandParameter_1)
		{
			InitializeComponent();
			inputFieldUnderLineCommandParameter_0 = inputFieldUnderLineCommandParameter_1;
			base.DialogResult = DialogResult.Cancel;
			numLineLength.Maximum = decimal.MaxValue;
			bool_0 = inputFieldUnderLineCommandParameter_1.IsAddLine;
		}

		private void dlgInputFieldUnderLineInfo_Load(object sender, EventArgs e)
		{
			cboboxLineStyle.DataSource = Enum.GetNames(typeof(DashStyle));
			cboboxLineStyle.SelectedIndex = 1;
			btnLineColor.BackColor = inputFieldUnderLineCommandParameter_0.InputFieldUnderLineColor;
			numLineLength.Value = (decimal)inputFieldUnderLineCommandParameter_0.InputFieldUnderLineLength;
			numLineWidth.Value = (decimal)inputFieldUnderLineCommandParameter_0.InputFieldUnderLineWidth;
			cboboxLineStyle.SelectedItem = inputFieldUnderLineCommandParameter_0.InputFieldUnderLineStyle.ToString();
			chkUseLength.Checked = inputFieldUnderLineCommandParameter_0.bUseMyOwnLength;
			if (bool_0)
			{
				Panel panel = panel1;
				rdobtnAddLine.Checked = true;
				panel.Enabled = true;
			}
			else
			{
				rdobtnRemoveLine.Checked = true;
			}
		}

		private void rdobtnRemoveLine_CheckedChanged(object sender, EventArgs e)
		{
			panel1.Enabled = rdobtnAddLine.Checked;
		}

		private void chkUseLength_CheckedChanged(object sender, EventArgs e)
		{
			Label label = lblLineLength;
			bool enabled = numLineLength.Enabled = chkUseLength.Checked;
			label.Enabled = enabled;
		}

		private void btnLineColor_Click(object sender, EventArgs e)
		{
			using (ColorDialog colorDialog = new ColorDialog())
			{
				colorDialog.AnyColor = true;
				colorDialog.Color = Color.Black;
				colorDialog.FullOpen = false;
				colorDialog.SolidColorOnly = true;
				if (colorDialog.ShowDialog() == DialogResult.OK)
				{
					btnLineColor.BackColor = colorDialog.Color;
				}
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			bool_0 = rdobtnAddLine.Checked;
			if (bool_0)
			{
				inputFieldUnderLineCommandParameter_0.bUseMyOwnLength = chkUseLength.Checked;
				inputFieldUnderLineCommandParameter_0.InputFieldUnderLineColor = btnLineColor.BackColor;
				inputFieldUnderLineCommandParameter_0.InputFieldUnderLineLength = (float)numLineLength.Value;
				inputFieldUnderLineCommandParameter_0.InputFieldUnderLineWidth = (float)numLineWidth.Value;
				inputFieldUnderLineCommandParameter_0.InputFieldUnderLineStyle = (DashStyle)Enum.Parse(typeof(DashStyle), (string)cboboxLineStyle.SelectedItem);
			}
			base.DialogResult = DialogResult.OK;
			Close();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Commands.dlgInputFieldUnderLineInfo));
			lblLineStyle = new System.Windows.Forms.Label();
			lblLineWidth = new System.Windows.Forms.Label();
			lblLineLength = new System.Windows.Forms.Label();
			lblLineColor = new System.Windows.Forms.Label();
			numLineWidth = new System.Windows.Forms.NumericUpDown();
			numLineLength = new System.Windows.Forms.NumericUpDown();
			cboboxLineStyle = new System.Windows.Forms.ComboBox();
			chkUseLength = new System.Windows.Forms.CheckBox();
			rdobtnAddLine = new System.Windows.Forms.RadioButton();
			rdobtnRemoveLine = new System.Windows.Forms.RadioButton();
			btnLineColor = new System.Windows.Forms.Button();
			panel1 = new System.Windows.Forms.Panel();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)numLineWidth).BeginInit();
			((System.ComponentModel.ISupportInitialize)numLineLength).BeginInit();
			panel1.SuspendLayout();
			SuspendLayout();
			resources.ApplyResources(lblLineStyle, "lblLineStyle");
			lblLineStyle.Name = "lblLineStyle";
			resources.ApplyResources(lblLineWidth, "lblLineWidth");
			lblLineWidth.Name = "lblLineWidth";
			resources.ApplyResources(lblLineLength, "lblLineLength");
			lblLineLength.Name = "lblLineLength";
			resources.ApplyResources(lblLineColor, "lblLineColor");
			lblLineColor.Name = "lblLineColor";
			numLineWidth.DecimalPlaces = 1;
			numLineWidth.Increment = new decimal(new int[4]
			{
				1,
				0,
				0,
				65536
			});
			resources.ApplyResources(numLineWidth, "numLineWidth");
			numLineWidth.Name = "numLineWidth";
			numLineWidth.Value = new decimal(new int[4]
			{
				1,
				0,
				0,
				0
			});
			numLineLength.DecimalPlaces = 2;
			resources.ApplyResources(numLineLength, "numLineLength");
			numLineLength.Minimum = new decimal(new int[4]
			{
				100,
				0,
				0,
				-2147483648
			});
			numLineLength.Name = "numLineLength";
			cboboxLineStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboboxLineStyle.FormattingEnabled = true;
			resources.ApplyResources(cboboxLineStyle, "cboboxLineStyle");
			cboboxLineStyle.Name = "cboboxLineStyle";
			resources.ApplyResources(chkUseLength, "chkUseLength");
			chkUseLength.Name = "chkUseLength";
			chkUseLength.UseVisualStyleBackColor = true;
			chkUseLength.CheckedChanged += new System.EventHandler(chkUseLength_CheckedChanged);
			resources.ApplyResources(rdobtnAddLine, "rdobtnAddLine");
			rdobtnAddLine.Name = "rdobtnAddLine";
			rdobtnAddLine.TabStop = true;
			rdobtnAddLine.UseVisualStyleBackColor = true;
			resources.ApplyResources(rdobtnRemoveLine, "rdobtnRemoveLine");
			rdobtnRemoveLine.Name = "rdobtnRemoveLine";
			rdobtnRemoveLine.UseVisualStyleBackColor = true;
			rdobtnRemoveLine.CheckedChanged += new System.EventHandler(rdobtnRemoveLine_CheckedChanged);
			resources.ApplyResources(btnLineColor, "btnLineColor");
			btnLineColor.Name = "btnLineColor";
			btnLineColor.UseVisualStyleBackColor = true;
			btnLineColor.Click += new System.EventHandler(btnLineColor_Click);
			panel1.Controls.Add(lblLineColor);
			panel1.Controls.Add(btnLineColor);
			panel1.Controls.Add(lblLineStyle);
			panel1.Controls.Add(chkUseLength);
			panel1.Controls.Add(cboboxLineStyle);
			panel1.Controls.Add(numLineLength);
			panel1.Controls.Add(lblLineWidth);
			panel1.Controls.Add(lblLineLength);
			panel1.Controls.Add(numLineWidth);
			resources.ApplyResources(panel1, "panel1");
			panel1.Name = "panel1";
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.Name = "btnOK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			btnCancel.UseVisualStyleBackColor = true;
			base.AcceptButton = btnOK;
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = btnCancel;
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(panel1);
			base.Controls.Add(rdobtnRemoveLine);
			base.Controls.Add(rdobtnAddLine);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgInputFieldUnderLineInfo";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgInputFieldUnderLineInfo_Load);
			((System.ComponentModel.ISupportInitialize)numLineWidth).EndInit();
			((System.ComponentModel.ISupportInitialize)numLineLength).EndInit();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
