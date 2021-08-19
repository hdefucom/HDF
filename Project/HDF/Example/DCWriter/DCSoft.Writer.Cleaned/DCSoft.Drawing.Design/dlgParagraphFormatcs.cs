using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Drawing.Design
{
	/// <summary>
	///       段落设置对话框
	///       </summary>
	[ComVisible(false)]
	public class dlgParagraphFormatcs : Form
	{
		private IContainer icontainer_0 = null;

		private Label label1;

		private NumericUpDown txtLeftIndent;

		private Label label2;

		private NumericUpDown txtFirstLineIndent;

		private Label label3;

		private NumericUpDown txtSpacingBefore;

		private Label label4;

		private NumericUpDown txtSpacingAfter;

		private Label label5;

		private NumericUpDown txtLineSpacing;

		private ComboBox cboLineSpacingStyle;

		private Label lblBang;

		private Button btnOK;

		private Button btnCancel;

		private Button btnFirstIndent;

		private Button btnHangIndent;

		private Label lblBei;

		private Label label6;

		private ComboBox cboOutlineLevel;

		private Label label7;

		private Button btnListStyle;

		private CheckBox chkMultiLevel;

		private GraphicsUnit graphicsUnit_0 = GraphicsUnit.Document;

		private ContentStyle contentStyle_0 = null;

		public GraphicsUnit DocumentGraphicsUnit
		{
			get
			{
				return graphicsUnit_0;
			}
			set
			{
				graphicsUnit_0 = value;
			}
		}

		public ContentStyle ContentStyle
		{
			get
			{
				return contentStyle_0;
			}
			set
			{
				contentStyle_0 = value;
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtLeftIndent = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFirstLineIndent = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSpacingBefore = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSpacingAfter = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLineSpacing = new System.Windows.Forms.NumericUpDown();
            this.cboLineSpacingStyle = new System.Windows.Forms.ComboBox();
            this.lblBang = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnFirstIndent = new System.Windows.Forms.Button();
            this.btnHangIndent = new System.Windows.Forms.Button();
            this.lblBei = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cboOutlineLevel = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnListStyle = new System.Windows.Forms.Button();
            this.chkMultiLevel = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtLeftIndent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFirstLineIndent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSpacingBefore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSpacingAfter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLineSpacing)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "左侧缩进量(厘米):";
            // 
            // txtLeftIndent
            // 
            this.txtLeftIndent.DecimalPlaces = 1;
            this.txtLeftIndent.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.txtLeftIndent.Location = new System.Drawing.Point(122, 78);
            this.txtLeftIndent.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.txtLeftIndent.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            -2147483648});
            this.txtLeftIndent.Name = "txtLeftIndent";
            this.txtLeftIndent.Size = new System.Drawing.Size(56, 21);
            this.txtLeftIndent.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(204, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 12);
            this.label2.TabIndex = 30;
            this.label2.Text = "首行缩进量(厘米):";
            // 
            // txtFirstLineIndent
            // 
            this.txtFirstLineIndent.DecimalPlaces = 2;
            this.txtFirstLineIndent.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.txtFirstLineIndent.Location = new System.Drawing.Point(322, 78);
            this.txtFirstLineIndent.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.txtFirstLineIndent.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            -2147483648});
            this.txtFirstLineIndent.Name = "txtFirstLineIndent";
            this.txtFirstLineIndent.Size = new System.Drawing.Size(54, 21);
            this.txtFirstLineIndent.TabIndex = 40;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 12);
            this.label3.TabIndex = 50;
            this.label3.Text = "段落前间距(行):";
            // 
            // txtSpacingBefore
            // 
            this.txtSpacingBefore.DecimalPlaces = 1;
            this.txtSpacingBefore.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.txtSpacingBefore.Location = new System.Drawing.Point(122, 115);
            this.txtSpacingBefore.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.txtSpacingBefore.Name = "txtSpacingBefore";
            this.txtSpacingBefore.Size = new System.Drawing.Size(56, 21);
            this.txtSpacingBefore.TabIndex = 60;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(204, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 12);
            this.label4.TabIndex = 70;
            this.label4.Text = "段落后间距(行):";
            // 
            // txtSpacingAfter
            // 
            this.txtSpacingAfter.DecimalPlaces = 1;
            this.txtSpacingAfter.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.txtSpacingAfter.Location = new System.Drawing.Point(322, 115);
            this.txtSpacingAfter.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.txtSpacingAfter.Name = "txtSpacingAfter";
            this.txtSpacingAfter.Size = new System.Drawing.Size(54, 21);
            this.txtSpacingAfter.TabIndex = 80;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 90;
            this.label5.Text = "行距:";
            // 
            // txtLineSpacing
            // 
            this.txtLineSpacing.DecimalPlaces = 2;
            this.txtLineSpacing.Location = new System.Drawing.Point(312, 159);
            this.txtLineSpacing.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.txtLineSpacing.Name = "txtLineSpacing";
            this.txtLineSpacing.Size = new System.Drawing.Size(55, 21);
            this.txtLineSpacing.TabIndex = 120;
            // 
            // cboLineSpacingStyle
            // 
            this.cboLineSpacingStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLineSpacingStyle.FormattingEnabled = true;
            this.cboLineSpacingStyle.Items.AddRange(new object[] {
            "单倍行距",
            "1.5倍行距",
            "2倍行距",
            "最小值",
            "固定值",
            "多倍行距"});
            this.cboLineSpacingStyle.Location = new System.Drawing.Point(67, 159);
            this.cboLineSpacingStyle.Name = "cboLineSpacingStyle";
            this.cboLineSpacingStyle.Size = new System.Drawing.Size(111, 20);
            this.cboLineSpacingStyle.TabIndex = 100;
            this.cboLineSpacingStyle.SelectedIndexChanged += new System.EventHandler(this.cboOutlineLevel_SelectedIndexChanged);
            // 
            // lblBang
            // 
            this.lblBang.AutoSize = true;
            this.lblBang.Location = new System.Drawing.Point(204, 164);
            this.lblBang.Name = "lblBang";
            this.lblBang.Size = new System.Drawing.Size(71, 12);
            this.lblBang.TabIndex = 141;
            this.lblBang.Text = "设置值(磅):";
            this.lblBang.Visible = false;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(178, 207);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(99, 23);
            this.btnOK.TabIndex = 150;
            this.btnOK.Text = "确定(&O)";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(277, 207);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(99, 23);
            this.btnCancel.TabIndex = 160;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnFirstIndent
            // 
            this.btnFirstIndent.Location = new System.Drawing.Point(12, 207);
            this.btnFirstIndent.Name = "btnFirstIndent";
            this.btnFirstIndent.Size = new System.Drawing.Size(83, 23);
            this.btnFirstIndent.TabIndex = 130;
            this.btnFirstIndent.Text = "首行缩进";
            this.btnFirstIndent.UseVisualStyleBackColor = true;
            this.btnFirstIndent.Click += new System.EventHandler(this.btnFirstIndent_Click);
            // 
            // btnHangIndent
            // 
            this.btnHangIndent.Location = new System.Drawing.Point(95, 207);
            this.btnHangIndent.Name = "btnHangIndent";
            this.btnHangIndent.Size = new System.Drawing.Size(83, 23);
            this.btnHangIndent.TabIndex = 140;
            this.btnHangIndent.Text = "悬挂缩进";
            this.btnHangIndent.UseVisualStyleBackColor = true;
            this.btnHangIndent.Click += new System.EventHandler(this.btnHangIndent_Click);
            // 
            // lblBei
            // 
            this.lblBei.AutoSize = true;
            this.lblBei.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblBei.Location = new System.Drawing.Point(204, 141);
            this.lblBei.Name = "lblBei";
            this.lblBei.Size = new System.Drawing.Size(71, 12);
            this.lblBei.TabIndex = 141;
            this.lblBei.Text = "设置值(倍):";
            this.lblBei.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(12, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 90;
            this.label6.Text = "大纲级别:";
            // 
            // cboOutlineLevel
            // 
            this.cboOutlineLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOutlineLevel.FormattingEnabled = true;
            this.cboOutlineLevel.Items.AddRange(new object[] {
            "正文文本",
            "1 级",
            "2 级",
            "3 级",
            "4 级",
            "5 级",
            "6 级",
            "7 级",
            "8 级"});
            this.cboOutlineLevel.Location = new System.Drawing.Point(77, 12);
            this.cboOutlineLevel.Name = "cboOutlineLevel";
            this.cboOutlineLevel.Size = new System.Drawing.Size(111, 20);
            this.cboOutlineLevel.TabIndex = 100;
            this.cboOutlineLevel.SelectedIndexChanged += new System.EventHandler(this.cboOutlineLevel_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(204, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 161;
            this.label7.Text = "列表方式:";
            // 
            // btnListStyle
            // 
            this.btnListStyle.Location = new System.Drawing.Point(269, 12);
            this.btnListStyle.Name = "btnListStyle";
            this.btnListStyle.Size = new System.Drawing.Size(107, 23);
            this.btnListStyle.TabIndex = 162;
            this.btnListStyle.UseVisualStyleBackColor = true;
            this.btnListStyle.Click += new System.EventHandler(this.btnListStyle_Click);
            // 
            // chkMultiLevel
            // 
            this.chkMultiLevel.AutoSize = true;
            this.chkMultiLevel.Location = new System.Drawing.Point(14, 42);
            this.chkMultiLevel.Name = "chkMultiLevel";
            this.chkMultiLevel.Size = new System.Drawing.Size(96, 16);
            this.chkMultiLevel.TabIndex = 163;
            this.chkMultiLevel.Text = "多层段落列表";
            this.chkMultiLevel.UseVisualStyleBackColor = true;
            // 
            // dlgParagraphFormatcs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(399, 248);
            this.Controls.Add(this.chkMultiLevel);
            this.Controls.Add(this.btnListStyle);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnHangIndent);
            this.Controls.Add(this.btnFirstIndent);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cboOutlineLevel);
            this.Controls.Add(this.cboLineSpacingStyle);
            this.Controls.Add(this.txtLineSpacing);
            this.Controls.Add(this.txtSpacingAfter);
            this.Controls.Add(this.txtSpacingBefore);
            this.Controls.Add(this.txtFirstLineIndent);
            this.Controls.Add(this.txtLeftIndent);
            this.Controls.Add(this.lblBei);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblBang);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgParagraphFormatcs";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "段落";
            this.Load += new System.EventHandler(this.dlgParagraphFormatcs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtLeftIndent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFirstLineIndent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSpacingBefore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSpacingAfter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLineSpacing)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgParagraphFormatcs()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgParagraphFormatcs_Load(object sender, EventArgs e)
		{
			if (contentStyle_0 == null)
			{
				contentStyle_0 = new ContentStyle();
			}
			method_0(txtLeftIndent, (decimal)((double)GraphicsUnitConvert.Convert(ContentStyle.LeftIndent, DocumentGraphicsUnit, GraphicsUnit.Millimeter) / 10.0));
			method_0(txtFirstLineIndent, (decimal)((double)GraphicsUnitConvert.Convert(ContentStyle.FirstLineIndent, DocumentGraphicsUnit, GraphicsUnit.Millimeter) / 10.0));
			method_0(txtSpacingBefore, (decimal)((double)GraphicsUnitConvert.ToTwips(ContentStyle.SpacingBeforeParagraph, DocumentGraphicsUnit) / 312.0));
			method_0(txtSpacingAfter, (decimal)((double)GraphicsUnitConvert.ToTwips(ContentStyle.SpacingAfterParagraph, DocumentGraphicsUnit) / 312.0));
			cboLineSpacingStyle.SelectedIndex = (int)contentStyle_0.LineSpacingStyle;
			cboOutlineLevel_SelectedIndexChanged(null, null);
			cboOutlineLevel.SelectedIndex = contentStyle_0.ParagraphOutlineLevel + 1;
			btnListStyle.Text = ContentStyle.ParagraphListStyle.ToString();
			chkMultiLevel.Checked = ContentStyle.ParagraphMultiLevel;
			if (contentStyle_0.LineSpacingStyle == LineSpacingStyle.SpaceSpecify)
			{
				txtLineSpacing.Value = (decimal)GraphicsUnitConvert.ToTwips(contentStyle_0.LineSpacing, DocumentGraphicsUnit) / 20m;
			}
			else
			{
				txtLineSpacing.Value = (decimal)contentStyle_0.LineSpacing;
			}
		}

		private void method_0(NumericUpDown numericUpDown_0, decimal decimal_0)
		{
			if (decimal_0 > numericUpDown_0.Maximum)
			{
				numericUpDown_0.Value = numericUpDown_0.Maximum;
			}
			else if (decimal_0 < numericUpDown_0.Minimum)
			{
				numericUpDown_0.Value = numericUpDown_0.Minimum;
			}
			else
			{
				numericUpDown_0.Value = decimal_0;
			}
		}

		private void cboOutlineLevel_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch (cboLineSpacingStyle.SelectedIndex)
			{
			case 0:
			case 1:
			case 2:
			case 3:
				txtLineSpacing.Value = 0m;
				txtLineSpacing.Enabled = false;
				txtLineSpacing.Increment = 1m;
				lblBang.Visible = false;
				lblBei.Visible = false;
				txtLineSpacing.Visible = false;
				break;
			case 4:
			{
				txtLineSpacing.Enabled = true;
				float height = ContentStyle.Font.GetHeight(GraphicsUnit.Document);
				txtLineSpacing.Value = (decimal)((double)GraphicsUnitConvert.ToTwips(height, GraphicsUnit.Document) / 20.0);
				txtLineSpacing.Increment = 1m;
				lblBang.Visible = true;
				lblBei.Visible = false;
				txtLineSpacing.Visible = true;
				break;
			}
			case 5:
				txtLineSpacing.Value = 3m;
				txtLineSpacing.Increment = 0.25m;
				lblBang.Visible = false;
				lblBei.Visible = true;
				txtLineSpacing.Visible = true;
				txtLineSpacing.Enabled = true;
				break;
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
			ContentStyle.FirstLineIndent = (float)GraphicsUnitConvert.Convert((double)txtFirstLineIndent.Value * 10.0, GraphicsUnit.Millimeter, DocumentGraphicsUnit);
			ContentStyle.LeftIndent = (float)GraphicsUnitConvert.Convert((double)txtLeftIndent.Value * 10.0, GraphicsUnit.Millimeter, DocumentGraphicsUnit);
			ContentStyle.SpacingBeforeParagraph = (float)GraphicsUnitConvert.FromTwips((double)txtSpacingBefore.Value * 312.0, DocumentGraphicsUnit);
			ContentStyle.SpacingAfterParagraph = (float)GraphicsUnitConvert.FromTwips((double)txtSpacingAfter.Value * 312.0, DocumentGraphicsUnit);
			ContentStyle.LineSpacingStyle = (LineSpacingStyle)cboLineSpacingStyle.SelectedIndex;
			ContentStyle.ParagraphOutlineLevel = cboOutlineLevel.SelectedIndex - 1;
			ContentStyle.ParagraphListStyle = (ParagraphListStyle)Enum.Parse(typeof(ParagraphListStyle), btnListStyle.Text);
			ContentStyle.ParagraphMultiLevel = chkMultiLevel.Checked;
			switch (ContentStyle.LineSpacingStyle)
			{
			default:
				ContentStyle.LineSpacing = 0f;
				break;
			case LineSpacingStyle.SpaceSpecify:
				ContentStyle.LineSpacing = (float)GraphicsUnitConvert.FromTwips((double)txtLineSpacing.Value * 20.0, DocumentGraphicsUnit);
				break;
			case LineSpacingStyle.SpaceMultiple:
				ContentStyle.LineSpacing = (float)txtLineSpacing.Value;
				break;
			}
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnFirstIndent_Click(object sender, EventArgs e)
		{
			txtFirstLineIndent.Value = 0.85m;
			txtLeftIndent.Value = 0m;
		}

		private void btnHangIndent_Click(object sender, EventArgs e)
		{
			txtFirstLineIndent.Value = -0.74m;
			txtLeftIndent.Value = 2m;
		}

		private void btnListStyle_Click(object sender, EventArgs e)
		{
			using (dlgParagraphListStyle dlgParagraphListStyle = new dlgParagraphListStyle())
			{
				dlgParagraphListStyle.IncludeBulletedList = !chkMultiLevel.Checked;
				dlgParagraphListStyle.SelectedListStyle = (ParagraphListStyle)Enum.Parse(typeof(ParagraphListStyle), btnListStyle.Text);
				if (dlgParagraphListStyle.ShowDialog(this) == DialogResult.OK)
				{
					btnListStyle.Text = dlgParagraphListStyle.SelectedListStyle.ToString();
				}
			}
		}
	}
}
