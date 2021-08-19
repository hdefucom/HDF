using DCSoft.Drawing;
using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Printing
{
	/// <summary>
	///       水印设置对话框
	///       </summary>
	[ComVisible(false)]
	public class dlgWatermarkInfo : Form
	{
		private IContainer icontainer_0 = null;

		private RadioButton rdoNone;

		private RadioButton rdoImage;

		private Button button1;

		private Label lblFileName;

		private RadioButton rdoText;

		private Panel pnlText;

		private Button btnFont;

		private Label label2;

		private TextBox txtText;

		private Label label1;

		private RadioButton rdoHor;

		private RadioButton rdoAngle;

		private Label label4;

		private GClass304 btnColor;

		private Label label3;

		private Panel pnlImage;

		private Button btnOK;

		private Button btnCancel;

		private CheckBox chkShow;

		private CheckBox chkPrint;

		private WatermarkInfo watermarkInfo_0 = null;

		private XImageValue ximageValue_0 = null;

		/// <summary>
		///       水印设置信息对象
		///       </summary>
		public WatermarkInfo InputInfo
		{
			get
			{
				return watermarkInfo_0;
			}
			set
			{
				watermarkInfo_0 = value;
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
			rdoNone = new System.Windows.Forms.RadioButton();
			rdoImage = new System.Windows.Forms.RadioButton();
			button1 = new System.Windows.Forms.Button();
			lblFileName = new System.Windows.Forms.Label();
			rdoText = new System.Windows.Forms.RadioButton();
			pnlText = new System.Windows.Forms.Panel();
			rdoHor = new System.Windows.Forms.RadioButton();
			rdoAngle = new System.Windows.Forms.RadioButton();
			label4 = new System.Windows.Forms.Label();
			btnColor = new DCSoftDotfuscate.GClass304();
			btnFont = new System.Windows.Forms.Button();
			label3 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			txtText = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			pnlImage = new System.Windows.Forms.Panel();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			chkShow = new System.Windows.Forms.CheckBox();
			chkPrint = new System.Windows.Forms.CheckBox();
			pnlText.SuspendLayout();
			pnlImage.SuspendLayout();
			SuspendLayout();
			rdoNone.AutoSize = true;
			rdoNone.Location = new System.Drawing.Point(12, 42);
			rdoNone.Name = "rdoNone";
			rdoNone.Size = new System.Drawing.Size(77, 16);
			rdoNone.TabIndex = 2;
			rdoNone.TabStop = true;
			rdoNone.Text = "无水印(&N)";
			rdoNone.UseVisualStyleBackColor = true;
			rdoNone.CheckedChanged += new System.EventHandler(rdoText_CheckedChanged);
			rdoImage.AutoSize = true;
			rdoImage.Location = new System.Drawing.Point(12, 67);
			rdoImage.Name = "rdoImage";
			rdoImage.Size = new System.Drawing.Size(89, 16);
			rdoImage.TabIndex = 3;
			rdoImage.TabStop = true;
			rdoImage.Text = "图片水印(&I)";
			rdoImage.UseVisualStyleBackColor = true;
			rdoImage.CheckedChanged += new System.EventHandler(rdoText_CheckedChanged);
			button1.Location = new System.Drawing.Point(19, 6);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(114, 23);
			button1.TabIndex = 0;
			button1.Text = "选择图片(&P)...";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			lblFileName.AutoSize = true;
			lblFileName.Location = new System.Drawing.Point(140, 12);
			lblFileName.Name = "lblFileName";
			lblFileName.Size = new System.Drawing.Size(23, 12);
			lblFileName.TabIndex = 1;
			lblFileName.Text = "   ";
			rdoText.AutoSize = true;
			rdoText.Location = new System.Drawing.Point(12, 132);
			rdoText.Name = "rdoText";
			rdoText.Size = new System.Drawing.Size(89, 16);
			rdoText.TabIndex = 5;
			rdoText.TabStop = true;
			rdoText.Text = "文字水印(&X)";
			rdoText.UseVisualStyleBackColor = true;
			rdoText.CheckedChanged += new System.EventHandler(rdoText_CheckedChanged);
			pnlText.Controls.Add(rdoHor);
			pnlText.Controls.Add(rdoAngle);
			pnlText.Controls.Add(label4);
			pnlText.Controls.Add(btnColor);
			pnlText.Controls.Add(btnFont);
			pnlText.Controls.Add(label3);
			pnlText.Controls.Add(label2);
			pnlText.Controls.Add(txtText);
			pnlText.Controls.Add(label1);
			pnlText.Location = new System.Drawing.Point(12, 151);
			pnlText.Name = "pnlText";
			pnlText.Size = new System.Drawing.Size(402, 126);
			pnlText.TabIndex = 6;
			rdoHor.AutoSize = true;
			rdoHor.Location = new System.Drawing.Point(197, 102);
			rdoHor.Name = "rdoHor";
			rdoHor.Size = new System.Drawing.Size(65, 16);
			rdoHor.TabIndex = 6;
			rdoHor.TabStop = true;
			rdoHor.Text = "水平(&H)";
			rdoHor.UseVisualStyleBackColor = true;
			rdoAngle.AutoSize = true;
			rdoAngle.Location = new System.Drawing.Point(94, 102);
			rdoAngle.Name = "rdoAngle";
			rdoAngle.Size = new System.Drawing.Size(65, 16);
			rdoAngle.TabIndex = 6;
			rdoAngle.TabStop = true;
			rdoAngle.Text = "斜式(&D)";
			rdoAngle.UseVisualStyleBackColor = true;
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(19, 104);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(35, 12);
			label4.TabIndex = 5;
			label4.Text = "版式:";
			btnColor.Location = new System.Drawing.Point(94, 69);
			btnColor.Name = "btnColor";
			btnColor.Size = new System.Drawing.Size(247, 23);
			btnColor.TabIndex = 4;
			btnColor.Text = "   ";
			btnColor.UseVisualStyleBackColor = true;
			btnFont.Location = new System.Drawing.Point(94, 39);
			btnFont.Name = "btnFont";
			btnFont.Size = new System.Drawing.Size(247, 23);
			btnFont.TabIndex = 3;
			btnFont.Text = "    ";
			btnFont.UseVisualStyleBackColor = true;
			btnFont.Click += new System.EventHandler(btnFont_Click);
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(19, 74);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(53, 12);
			label3.TabIndex = 2;
			label3.Text = "颜色(&C):";
			label3.Click += new System.EventHandler(label2_Click);
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(19, 44);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(53, 12);
			label2.TabIndex = 2;
			label2.Text = "字体(&F):";
			label2.Click += new System.EventHandler(label2_Click);
			txtText.Location = new System.Drawing.Point(94, 11);
			txtText.Name = "txtText";
			txtText.Size = new System.Drawing.Size(247, 21);
			txtText.TabIndex = 1;
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(19, 14);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(53, 12);
			label1.TabIndex = 0;
			label1.Text = "文字(&T):";
			pnlImage.Controls.Add(button1);
			pnlImage.Controls.Add(lblFileName);
			pnlImage.Location = new System.Drawing.Point(12, 86);
			pnlImage.Name = "pnlImage";
			pnlImage.Size = new System.Drawing.Size(402, 37);
			pnlImage.TabIndex = 4;
			btnOK.Location = new System.Drawing.Point(158, 296);
			btnOK.Name = "btnOK";
			btnOK.Size = new System.Drawing.Size(75, 23);
			btnOK.TabIndex = 7;
			btnOK.Text = "确定(&O)";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			btnCancel.Location = new System.Drawing.Point(278, 296);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(75, 23);
			btnCancel.TabIndex = 8;
			btnCancel.Text = "取消(&C)";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			chkShow.AutoSize = true;
			chkShow.Location = new System.Drawing.Point(11, 12);
			chkShow.Name = "chkShow";
			chkShow.Size = new System.Drawing.Size(144, 16);
			chkShow.TabIndex = 0;
			chkShow.Text = "在用户界面中显示水印";
			chkShow.UseVisualStyleBackColor = true;
			chkPrint.AutoSize = true;
			chkPrint.Location = new System.Drawing.Point(187, 12);
			chkPrint.Name = "chkPrint";
			chkPrint.Size = new System.Drawing.Size(72, 16);
			chkPrint.TabIndex = 1;
			chkPrint.Text = "打印水印";
			chkPrint.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = btnCancel;
			base.ClientSize = new System.Drawing.Size(419, 330);
			base.Controls.Add(chkPrint);
			base.Controls.Add(chkShow);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(pnlImage);
			base.Controls.Add(pnlText);
			base.Controls.Add(rdoText);
			base.Controls.Add(rdoImage);
			base.Controls.Add(rdoNone);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgWatermarkInfo";
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "水印";
			base.Load += new System.EventHandler(dlgWatermarkInfo_Load);
			pnlText.ResumeLayout(false);
			pnlText.PerformLayout();
			pnlImage.ResumeLayout(false);
			pnlImage.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgWatermarkInfo()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void label2_Click(object sender, EventArgs e)
		{
		}

		private void dlgWatermarkInfo_Load(object sender, EventArgs e)
		{
			int num = 4;
			if (InputInfo == null)
			{
				InputInfo = new WatermarkInfo();
			}
			chkShow.Checked = InputInfo.ShowWatermark;
			chkPrint.Checked = InputInfo.PrintWatermark;
			switch (watermarkInfo_0.Type)
			{
			case WatermarkType.None:
				rdoNone.Checked = true;
				break;
			case WatermarkType.Image:
				rdoImage.Checked = true;
				if (InputInfo.Image != null && InputInfo.Image.Value != null)
				{
					lblFileName.Text = InputInfo.Image.Width + "*" + InputInfo.Image.Height;
				}
				ximageValue_0 = InputInfo.Image;
				break;
			case WatermarkType.Text:
				rdoText.Checked = true;
				txtText.Text = InputInfo.Text;
				btnFont.Text = InputInfo.Font.ToString();
				btnFont.Tag = InputInfo.Font;
				btnColor.method_1(InputInfo.Color);
				rdoAngle.Checked = (InputInfo.Angle != 0f);
				rdoHor.Checked = !rdoAngle.Checked;
				break;
			}
			rdoText_CheckedChanged(null, null);
		}

		private void method_0(Control control_0, bool bool_0)
		{
			foreach (Control control in control_0.Controls)
			{
				control.Enabled = bool_0;
			}
		}

		private void rdoText_CheckedChanged(object sender, EventArgs e)
		{
			method_0(pnlText, rdoText.Checked);
			method_0(pnlImage, rdoImage.Checked);
		}

		private void btnFont_Click(object sender, EventArgs e)
		{
			using (FontDialog fontDialog = new FontDialog())
			{
				if (btnFont.Tag is XFontValue)
				{
					fontDialog.Font = ((XFontValue)btnFont.Tag).Value;
				}
				if (fontDialog.ShowDialog(this) == DialogResult.OK)
				{
					XFontValue xFontValue = new XFontValue(fontDialog.Font);
					btnFont.Text = xFontValue.ToString();
					btnFont.Tag = xFontValue;
				}
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			InputInfo.Clear();
			InputInfo.ShowWatermark = chkShow.Checked;
			InputInfo.PrintWatermark = chkPrint.Checked;
			if (rdoNone.Checked)
			{
				InputInfo.Type = WatermarkType.None;
			}
			else if (rdoImage.Checked)
			{
				InputInfo.Type = WatermarkType.Image;
				InputInfo.Image = ximageValue_0;
			}
			else if (rdoText.Checked)
			{
				InputInfo.Type = WatermarkType.Text;
				InputInfo.Text = txtText.Text;
				InputInfo.Font = (XFontValue)btnFont.Tag;
				InputInfo.Color = btnColor.method_0();
				if (rdoAngle.Checked)
				{
					InputInfo.Angle = -45f;
				}
				else
				{
					InputInfo.Angle = 0f;
				}
			}
			base.DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.Filter = PrintingResources.ImageFileFilter;
				openFileDialog.CheckFileExists = true;
				if (openFileDialog.ShowDialog(this) == DialogResult.OK)
				{
					ximageValue_0 = new XImageValue(openFileDialog.FileName);
					lblFileName.Text = openFileDialog.FileName;
				}
			}
		}
	}
}
