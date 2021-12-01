using DCSoft.Drawing;
using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       文档边框和背景编辑对话框
	///       </summary>
	[ComVisible(false)]
	public class dlgDocumentBorderBackground : Form
	{
		private IContainer icontainer_0 = null;

		private GroupBox groupBox1;

		private GControl8 lstBorderSettings;

		private Label label1;

		private Label label2;

		private GControl8 lstBorderStyle;

		private GClass304 btnTopBorderColor;

		private Label label3;

		private Label label4;

		private CheckBox chkTopBorder;

		private PictureBox picBorderPreview;

		private CheckBox chkRightBorder;

		private ImageList imageList_0;

		private CheckBox chkCenterVerticalBorder;

		private CheckBox chkLeftBorder;

		private CheckBox chkBottomBorder;

		private CheckBox chkMiddleHorizontalBorder;

		private ComboBox cboBorderApplyRange;

		private Label lblBorderApplyRange;

		private GroupBox groupBox2;

		private GClass304 btnBackgroundColor;

		private Label label6;

		private Button btnOK;

		private Button btnCancel;

		private NumericUpDown txtBorderWidth;

		private Label label7;

		private GClass304 btnRightBorderColor;

		private GClass304 btnLeftBorderColor;

		private GClass304 btnBottomBorderColor;

		private Label label9;

		private Label label8;

		private Label label5;

		private Label label13;

		private Label label12;

		private Label label11;

		private Label label10;

		private Button btnOptions;

		private StyleApplyRanges styleApplyRanges_0 = StyleApplyRanges.None;

		private GraphicsUnit graphicsUnit_0 = GraphicsUnit.Document;

		private BorderBackgroundCommandParameter borderBackgroundCommandParameter_0 = null;

		private bool bool_0 = false;

		private Bitmap bitmap_0 = null;

		private bool bool_1 = false;

		public EventHandler eventHandler_0 = null;

		/// <summary>
		///       是否显示应用范围选型
		///       </summary>
		public bool ShowApplyRange
		{
			get
			{
				return cboBorderApplyRange.Visible;
			}
			set
			{
				cboBorderApplyRange.Visible = value;
			}
		}

		/// <summary>
		///       样式应用范围
		///       </summary>
		public StyleApplyRanges AllowApplyRanges
		{
			get
			{
				return styleApplyRanges_0;
			}
			set
			{
				styleApplyRanges_0 = value;
			}
		}

		/// <summary>
		///       文档图形单位
		///       </summary>
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

		/// <summary>
		///       命令参数对象
		///       </summary>
		public BorderBackgroundCommandParameter CommandParameter
		{
			get
			{
				return borderBackgroundCommandParameter_0;
			}
			set
			{
				borderBackgroundCommandParameter_0 = value;
			}
		}

		/// <summary>
		///       数值发生改变标记
		///       </summary>
		public bool ValueModified
		{
			get
			{
				return bool_0;
			}
			set
			{
				bool_0 = value;
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
			icontainer_0 = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Commands.dlgDocumentBorderBackground));
			DCSoftDotfuscate.GClass309 gClass = new DCSoftDotfuscate.GClass309();
			DCSoftDotfuscate.GClass309 gClass2 = new DCSoftDotfuscate.GClass309();
			DCSoftDotfuscate.GClass309 gClass3 = new DCSoftDotfuscate.GClass309();
			DCSoftDotfuscate.GClass309 gClass4 = new DCSoftDotfuscate.GClass309();
			DCSoftDotfuscate.GClass309 gClass5 = new DCSoftDotfuscate.GClass309();
			DCSoftDotfuscate.GClass309 gClass6 = new DCSoftDotfuscate.GClass309();
			DCSoftDotfuscate.GClass309 gClass7 = new DCSoftDotfuscate.GClass309();
			DCSoftDotfuscate.GClass309 gClass8 = new DCSoftDotfuscate.GClass309();
			DCSoftDotfuscate.GClass309 gClass9 = new DCSoftDotfuscate.GClass309();
			groupBox1 = new System.Windows.Forms.GroupBox();
			btnRightBorderColor = new DCSoftDotfuscate.GClass304();
			btnLeftBorderColor = new DCSoftDotfuscate.GClass304();
			btnBottomBorderColor = new DCSoftDotfuscate.GClass304();
			btnTopBorderColor = new DCSoftDotfuscate.GClass304();
			label13 = new System.Windows.Forms.Label();
			label12 = new System.Windows.Forms.Label();
			label11 = new System.Windows.Forms.Label();
			label10 = new System.Windows.Forms.Label();
			txtBorderWidth = new System.Windows.Forms.NumericUpDown();
			chkRightBorder = new System.Windows.Forms.CheckBox();
			imageList_0 = new System.Windows.Forms.ImageList(icontainer_0);
			chkCenterVerticalBorder = new System.Windows.Forms.CheckBox();
			chkLeftBorder = new System.Windows.Forms.CheckBox();
			chkBottomBorder = new System.Windows.Forms.CheckBox();
			chkMiddleHorizontalBorder = new System.Windows.Forms.CheckBox();
			chkTopBorder = new System.Windows.Forms.CheckBox();
			picBorderPreview = new System.Windows.Forms.PictureBox();
			label7 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			lstBorderStyle = new DCSoftDotfuscate.GControl8();
			lstBorderSettings = new DCSoftDotfuscate.GControl8();
			label1 = new System.Windows.Forms.Label();
			label9 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			cboBorderApplyRange = new System.Windows.Forms.ComboBox();
			lblBorderApplyRange = new System.Windows.Forms.Label();
			groupBox2 = new System.Windows.Forms.GroupBox();
			btnOptions = new System.Windows.Forms.Button();
			btnBackgroundColor = new DCSoftDotfuscate.GClass304();
			label6 = new System.Windows.Forms.Label();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)txtBorderWidth).BeginInit();
			((System.ComponentModel.ISupportInitialize)picBorderPreview).BeginInit();
			groupBox2.SuspendLayout();
			SuspendLayout();
			groupBox1.Controls.Add(btnRightBorderColor);
			groupBox1.Controls.Add(btnLeftBorderColor);
			groupBox1.Controls.Add(btnBottomBorderColor);
			groupBox1.Controls.Add(btnTopBorderColor);
			groupBox1.Controls.Add(label13);
			groupBox1.Controls.Add(label12);
			groupBox1.Controls.Add(label11);
			groupBox1.Controls.Add(label10);
			groupBox1.Controls.Add(txtBorderWidth);
			groupBox1.Controls.Add(chkRightBorder);
			groupBox1.Controls.Add(chkCenterVerticalBorder);
			groupBox1.Controls.Add(chkLeftBorder);
			groupBox1.Controls.Add(chkBottomBorder);
			groupBox1.Controls.Add(chkMiddleHorizontalBorder);
			groupBox1.Controls.Add(chkTopBorder);
			groupBox1.Controls.Add(picBorderPreview);
			groupBox1.Controls.Add(label7);
			groupBox1.Controls.Add(label3);
			groupBox1.Controls.Add(label4);
			groupBox1.Controls.Add(label2);
			groupBox1.Controls.Add(lstBorderStyle);
			groupBox1.Controls.Add(lstBorderSettings);
			groupBox1.Controls.Add(label1);
			groupBox1.Controls.Add(label9);
			groupBox1.Controls.Add(label8);
			groupBox1.Controls.Add(label5);
			resources.ApplyResources(groupBox1, "groupBox1");
			groupBox1.Name = "groupBox1";
			groupBox1.TabStop = false;
			resources.ApplyResources(btnRightBorderColor, "btnRightBorderColor");
			btnRightBorderColor.Name = "btnRightBorderColor";
			btnRightBorderColor.UseVisualStyleBackColor = true;
			btnRightBorderColor.method_9(new System.EventHandler(method_1));
			resources.ApplyResources(btnLeftBorderColor, "btnLeftBorderColor");
			btnLeftBorderColor.Name = "btnLeftBorderColor";
			btnLeftBorderColor.UseVisualStyleBackColor = true;
			btnLeftBorderColor.method_9(new System.EventHandler(method_1));
			resources.ApplyResources(btnBottomBorderColor, "btnBottomBorderColor");
			btnBottomBorderColor.Name = "btnBottomBorderColor";
			btnBottomBorderColor.UseVisualStyleBackColor = true;
			btnBottomBorderColor.method_9(new System.EventHandler(method_1));
			resources.ApplyResources(btnTopBorderColor, "btnTopBorderColor");
			btnTopBorderColor.Name = "btnTopBorderColor";
			btnTopBorderColor.UseVisualStyleBackColor = true;
			btnTopBorderColor.method_9(new System.EventHandler(method_1));
			resources.ApplyResources(label13, "label13");
			label13.Name = "label13";
			resources.ApplyResources(label12, "label12");
			label12.Name = "label12";
			resources.ApplyResources(label11, "label11");
			label11.Name = "label11";
			resources.ApplyResources(label10, "label10");
			label10.Name = "label10";
			txtBorderWidth.DecimalPlaces = 3;
			resources.ApplyResources(txtBorderWidth, "txtBorderWidth");
			txtBorderWidth.Name = "txtBorderWidth";
			txtBorderWidth.ValueChanged += new System.EventHandler(txtBorderWidth_ValueChanged);
			resources.ApplyResources(chkRightBorder, "chkRightBorder");
			chkRightBorder.ImageList = imageList_0;
			chkRightBorder.Name = "chkRightBorder";
			chkRightBorder.UseVisualStyleBackColor = true;
			chkRightBorder.CheckedChanged += new System.EventHandler(chkTopBorder_CheckedChanged);
			imageList_0.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("imageList1.ImageStream");
			imageList_0.TransparentColor = System.Drawing.Color.Red;
			imageList_0.Images.SetKeyName(0, "BorderFlagBottom.bmp");
			imageList_0.Images.SetKeyName(1, "BorderFlagCenterVertical.bmp");
			imageList_0.Images.SetKeyName(2, "BorderFlagLeft.bmp");
			imageList_0.Images.SetKeyName(3, "BorderFlagMiddleHorizontal.bmp");
			imageList_0.Images.SetKeyName(4, "BorderFlagNone.bmp");
			imageList_0.Images.SetKeyName(5, "BorderFlagRight.bmp");
			imageList_0.Images.SetKeyName(6, "BorderFlagTop.bmp");
			resources.ApplyResources(chkCenterVerticalBorder, "chkCenterVerticalBorder");
			chkCenterVerticalBorder.ImageList = imageList_0;
			chkCenterVerticalBorder.Name = "chkCenterVerticalBorder";
			chkCenterVerticalBorder.UseVisualStyleBackColor = true;
			chkCenterVerticalBorder.CheckedChanged += new System.EventHandler(chkTopBorder_CheckedChanged);
			resources.ApplyResources(chkLeftBorder, "chkLeftBorder");
			chkLeftBorder.ImageList = imageList_0;
			chkLeftBorder.Name = "chkLeftBorder";
			chkLeftBorder.UseVisualStyleBackColor = true;
			chkLeftBorder.CheckedChanged += new System.EventHandler(chkTopBorder_CheckedChanged);
			resources.ApplyResources(chkBottomBorder, "chkBottomBorder");
			chkBottomBorder.ImageList = imageList_0;
			chkBottomBorder.Name = "chkBottomBorder";
			chkBottomBorder.UseVisualStyleBackColor = true;
			chkBottomBorder.CheckedChanged += new System.EventHandler(chkTopBorder_CheckedChanged);
			resources.ApplyResources(chkMiddleHorizontalBorder, "chkMiddleHorizontalBorder");
			chkMiddleHorizontalBorder.ImageList = imageList_0;
			chkMiddleHorizontalBorder.Name = "chkMiddleHorizontalBorder";
			chkMiddleHorizontalBorder.UseVisualStyleBackColor = true;
			chkMiddleHorizontalBorder.CheckedChanged += new System.EventHandler(chkTopBorder_CheckedChanged);
			resources.ApplyResources(chkTopBorder, "chkTopBorder");
			chkTopBorder.ImageList = imageList_0;
			chkTopBorder.Name = "chkTopBorder";
			chkTopBorder.UseVisualStyleBackColor = true;
			chkTopBorder.CheckedChanged += new System.EventHandler(chkTopBorder_CheckedChanged);
			picBorderPreview.BackColor = System.Drawing.Color.White;
			resources.ApplyResources(picBorderPreview, "picBorderPreview");
			picBorderPreview.Name = "picBorderPreview";
			picBorderPreview.TabStop = false;
			picBorderPreview.Paint += new System.Windows.Forms.PaintEventHandler(picBorderPreview_Paint);
			resources.ApplyResources(label7, "label7");
			label7.Name = "label7";
			resources.ApplyResources(label3, "label3");
			label3.Name = "label3";
			resources.ApplyResources(label4, "label4");
			label4.Name = "label4";
			resources.ApplyResources(label2, "label2");
			label2.Name = "label2";
			resources.ApplyResources(lstBorderStyle, "lstBorderStyle");
			lstBorderStyle.BackColor = System.Drawing.SystemColors.Window;
			lstBorderStyle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			gClass.method_1((System.Drawing.Image)resources.GetObject("imageListBoxItem1.Image"));
			gClass.method_3(0);
			resources.ApplyResources(gClass, "imageListBoxItem1");
			gClass2.method_1((System.Drawing.Image)resources.GetObject("imageListBoxItem2.Image"));
			gClass2.method_3(0);
			resources.ApplyResources(gClass2, "imageListBoxItem2");
			gClass3.method_1((System.Drawing.Image)resources.GetObject("imageListBoxItem3.Image"));
			gClass3.method_3(0);
			resources.ApplyResources(gClass3, "imageListBoxItem3");
			gClass4.method_1((System.Drawing.Image)resources.GetObject("imageListBoxItem4.Image"));
			gClass4.method_3(0);
			resources.ApplyResources(gClass4, "imageListBoxItem4");
			gClass5.method_1((System.Drawing.Image)resources.GetObject("imageListBoxItem5.Image"));
			gClass5.method_3(0);
			resources.ApplyResources(gClass5, "imageListBoxItem5");
			lstBorderStyle.method_5().Add(gClass);
			lstBorderStyle.method_5().Add(gClass2);
			lstBorderStyle.method_5().Add(gClass3);
			lstBorderStyle.method_5().Add(gClass4);
			lstBorderStyle.method_5().Add(gClass5);
			lstBorderStyle.Name = "lstBorderStyle";
			lstBorderStyle.method_11(new System.EventHandler(method_3));
			resources.ApplyResources(lstBorderSettings, "lstBorderSettings");
			lstBorderSettings.BackColor = System.Drawing.SystemColors.Window;
			lstBorderSettings.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			gClass6.method_1((System.Drawing.Image)resources.GetObject("imageListBoxItem6.Image"));
			gClass6.method_3(0);
			resources.ApplyResources(gClass6, "imageListBoxItem6");
			gClass6.method_9("0");
			gClass7.method_1((System.Drawing.Image)resources.GetObject("imageListBoxItem7.Image"));
			gClass7.method_3(0);
			resources.ApplyResources(gClass7, "imageListBoxItem7");
			gClass7.method_9("1");
			gClass8.method_1((System.Drawing.Image)resources.GetObject("imageListBoxItem8.Image"));
			gClass8.method_3(0);
			resources.ApplyResources(gClass8, "imageListBoxItem8");
			gClass8.method_9("2");
			gClass9.method_1((System.Drawing.Image)resources.GetObject("imageListBoxItem9.Image"));
			gClass9.method_3(0);
			resources.ApplyResources(gClass9, "imageListBoxItem9");
			gClass9.method_9("3");
			lstBorderSettings.method_5().Add(gClass6);
			lstBorderSettings.method_5().Add(gClass7);
			lstBorderSettings.method_5().Add(gClass8);
			lstBorderSettings.method_5().Add(gClass9);
			lstBorderSettings.Name = "lstBorderSettings";
			lstBorderSettings.method_11(new System.EventHandler(method_0));
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			resources.ApplyResources(label9, "label9");
			label9.Name = "label9";
			resources.ApplyResources(label8, "label8");
			label8.Name = "label8";
			resources.ApplyResources(label5, "label5");
			label5.Name = "label5";
			cboBorderApplyRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboBorderApplyRange.FormattingEnabled = true;
			resources.ApplyResources(cboBorderApplyRange, "cboBorderApplyRange");
			cboBorderApplyRange.Name = "cboBorderApplyRange";
			cboBorderApplyRange.SelectedIndexChanged += new System.EventHandler(cboBorderApplyRange_SelectedIndexChanged);
			resources.ApplyResources(lblBorderApplyRange, "lblBorderApplyRange");
			lblBorderApplyRange.Name = "lblBorderApplyRange";
			groupBox2.Controls.Add(btnOptions);
			groupBox2.Controls.Add(btnBackgroundColor);
			groupBox2.Controls.Add(label6);
			resources.ApplyResources(groupBox2, "groupBox2");
			groupBox2.Name = "groupBox2";
			groupBox2.TabStop = false;
			resources.ApplyResources(btnOptions, "btnOptions");
			btnOptions.Name = "btnOptions";
			btnOptions.UseVisualStyleBackColor = true;
			btnOptions.Click += new System.EventHandler(btnOptions_Click);
			resources.ApplyResources(btnBackgroundColor, "btnBackgroundColor");
			btnBackgroundColor.Name = "btnBackgroundColor";
			btnBackgroundColor.UseVisualStyleBackColor = true;
			btnBackgroundColor.method_9(new System.EventHandler(method_2));
			resources.ApplyResources(label6, "label6");
			label6.Name = "label6";
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.Name = "btnOK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(btnCancel);
			base.Controls.Add(cboBorderApplyRange);
			base.Controls.Add(btnOK);
			base.Controls.Add(groupBox2);
			base.Controls.Add(groupBox1);
			base.Controls.Add(lblBorderApplyRange);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgDocumentBorderBackground";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgDocumentBorderBackground_Load);
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)txtBorderWidth).EndInit();
			((System.ComponentModel.ISupportInitialize)picBorderPreview).EndInit();
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgDocumentBorderBackground()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
			btnBackgroundColor.method_5(bool_2: true);
			btnBackgroundColor.method_7(Color.Transparent);
			btnLeftBorderColor.method_5(bool_2: true);
			btnLeftBorderColor.method_7(Color.Black);
			btnTopBorderColor.method_5(bool_2: true);
			btnTopBorderColor.method_7(Color.Black);
			btnRightBorderColor.method_5(bool_2: true);
			btnRightBorderColor.method_7(Color.Black);
			btnBottomBorderColor.method_5(bool_2: true);
			btnBottomBorderColor.method_7(Color.Black);
		}

		private void dlgDocumentBorderBackground_Load(object sender, EventArgs e)
		{
			btnOptions.Visible = (eventHandler_0 != null);
			if ((AllowApplyRanges & StyleApplyRanges.Cell) != StyleApplyRanges.Cell)
			{
				chkMiddleHorizontalBorder.Visible = false;
				chkCenterVerticalBorder.Visible = false;
			}
			if (AllowApplyRanges == StyleApplyRanges.None)
			{
				lblBorderApplyRange.Visible = false;
				cboBorderApplyRange.Visible = false;
			}
			bitmap_0 = (Bitmap)picBorderPreview.Image;
			picBorderPreview.Image = null;
			bitmap_0.MakeTransparent(Color.White);
			if (borderBackgroundCommandParameter_0 == null)
			{
				borderBackgroundCommandParameter_0 = new BorderBackgroundCommandParameter();
			}
			bool_1 = true;
			lstBorderSettings.method_14((int)borderBackgroundCommandParameter_0.BorderSettingsStyle);
			switch (borderBackgroundCommandParameter_0.BorderStyle)
			{
			case DashStyle.Solid:
				lstBorderStyle.method_14(4);
				break;
			case DashStyle.Dash:
				lstBorderStyle.method_14(0);
				break;
			case DashStyle.Dot:
				lstBorderStyle.method_14(3);
				break;
			case DashStyle.DashDot:
				lstBorderStyle.method_14(1);
				break;
			case DashStyle.DashDotDot:
				lstBorderStyle.method_14(2);
				break;
			}
			chkBottomBorder.Checked = borderBackgroundCommandParameter_0.BottomBorder;
			chkCenterVerticalBorder.Checked = borderBackgroundCommandParameter_0.CenterVerticalBorder;
			chkLeftBorder.Checked = borderBackgroundCommandParameter_0.LeftBorder;
			chkMiddleHorizontalBorder.Checked = borderBackgroundCommandParameter_0.MiddleHorizontalBorder;
			chkRightBorder.Checked = borderBackgroundCommandParameter_0.RightBorder;
			chkTopBorder.Checked = borderBackgroundCommandParameter_0.TopBorder;
			if ((AllowApplyRanges & StyleApplyRanges.Text) == StyleApplyRanges.Text)
			{
				cboBorderApplyRange.Items.Add(WriterStrings.StyleApplyRangeText);
				if (borderBackgroundCommandParameter_0.ApplyRange == StyleApplyRanges.Text)
				{
					cboBorderApplyRange.SelectedIndex = cboBorderApplyRange.Items.Count - 1;
				}
			}
			if ((AllowApplyRanges & StyleApplyRanges.Paragraph) == StyleApplyRanges.Paragraph)
			{
				cboBorderApplyRange.Items.Add(WriterStrings.StyleApplyRangeParagraph);
				if (borderBackgroundCommandParameter_0.ApplyRange == StyleApplyRanges.Paragraph)
				{
					cboBorderApplyRange.SelectedIndex = cboBorderApplyRange.Items.Count - 1;
				}
			}
			if ((AllowApplyRanges & StyleApplyRanges.Field) == StyleApplyRanges.Field)
			{
				cboBorderApplyRange.Items.Add(WriterStrings.StyleApplyRangeField);
				if (borderBackgroundCommandParameter_0.ApplyRange == StyleApplyRanges.Field)
				{
					cboBorderApplyRange.SelectedIndex = cboBorderApplyRange.Items.Count - 1;
				}
			}
			if ((AllowApplyRanges & StyleApplyRanges.Cell) == StyleApplyRanges.Cell)
			{
				cboBorderApplyRange.Items.Add(WriterStrings.StyleApplyRangeCell);
				if (borderBackgroundCommandParameter_0.ApplyRange == StyleApplyRanges.Cell)
				{
					cboBorderApplyRange.SelectedIndex = cboBorderApplyRange.Items.Count - 1;
				}
			}
			if ((AllowApplyRanges & StyleApplyRanges.Row) == StyleApplyRanges.Row)
			{
				cboBorderApplyRange.Items.Add(WriterStrings.StyleApplyRangeRow);
				if (borderBackgroundCommandParameter_0.ApplyRange == StyleApplyRanges.Row)
				{
					cboBorderApplyRange.SelectedIndex = cboBorderApplyRange.Items.Count - 1;
				}
			}
			if ((AllowApplyRanges & StyleApplyRanges.Table) == StyleApplyRanges.Table)
			{
				cboBorderApplyRange.Items.Add(WriterStrings.StyleApplyRangeTable);
				if (borderBackgroundCommandParameter_0.ApplyRange == StyleApplyRanges.Table)
				{
					cboBorderApplyRange.SelectedIndex = cboBorderApplyRange.Items.Count - 1;
				}
			}
			if ((AllowApplyRanges & StyleApplyRanges.Section) == StyleApplyRanges.Section)
			{
				cboBorderApplyRange.Items.Add(WriterStrings.StyleApplyRangeSection);
				if (borderBackgroundCommandParameter_0.ApplyRange == StyleApplyRanges.Section)
				{
					cboBorderApplyRange.SelectedIndex = cboBorderApplyRange.Items.Count - 1;
				}
			}
			btnTopBorderColor.method_1(borderBackgroundCommandParameter_0.BorderTopColor);
			btnLeftBorderColor.method_1(borderBackgroundCommandParameter_0.BorderLeftColor);
			btnRightBorderColor.method_1(borderBackgroundCommandParameter_0.BorderRightColor);
			btnBottomBorderColor.method_1(borderBackgroundCommandParameter_0.BorderBottomColor);
			btnBackgroundColor.method_1(borderBackgroundCommandParameter_0.BackgroundColor);
			if (borderBackgroundCommandParameter_0.BorderWidth == 1f)
			{
				txtBorderWidth.Value = 1m;
			}
			else
			{
				txtBorderWidth.Value = (decimal)GraphicsUnitConvert.Convert((double)borderBackgroundCommandParameter_0.BorderWidth, DocumentGraphicsUnit, GraphicsUnit.Pixel);
			}
			bool_1 = false;
			ValueModified = false;
		}

		private void method_0(object sender, EventArgs e)
		{
			if (!bool_1)
			{
				bool_1 = true;
				ValueModified = true;
				switch (lstBorderSettings.method_13())
				{
				case 0:
					chkBottomBorder.Checked = false;
					chkCenterVerticalBorder.Checked = false;
					chkLeftBorder.Checked = false;
					chkMiddleHorizontalBorder.Checked = false;
					chkRightBorder.Checked = false;
					chkTopBorder.Checked = false;
					break;
				case 1:
					chkBottomBorder.Checked = true;
					chkCenterVerticalBorder.Checked = false;
					chkLeftBorder.Checked = true;
					chkMiddleHorizontalBorder.Checked = false;
					chkRightBorder.Checked = true;
					chkTopBorder.Checked = true;
					break;
				case 2:
					chkBottomBorder.Checked = true;
					chkCenterVerticalBorder.Checked = true;
					chkLeftBorder.Checked = true;
					chkMiddleHorizontalBorder.Checked = true;
					chkRightBorder.Checked = true;
					chkTopBorder.Checked = true;
					break;
				}
				bool_1 = false;
				picBorderPreview.Invalidate();
			}
		}

		private void chkTopBorder_CheckedChanged(object sender, EventArgs e)
		{
			if (bool_1)
			{
				return;
			}
			bool_1 = true;
			ValueModified = true;
			picBorderPreview.Invalidate();
			if (chkBottomBorder.Checked && chkLeftBorder.Checked && chkRightBorder.Checked && chkTopBorder.Checked)
			{
				if (chkCenterVerticalBorder.Checked && chkMiddleHorizontalBorder.Checked)
				{
					lstBorderSettings.method_14(2);
				}
				else if (!chkMiddleHorizontalBorder.Checked && !chkCenterVerticalBorder.Checked)
				{
					lstBorderSettings.method_14(1);
				}
				else
				{
					lstBorderSettings.method_14(3);
				}
			}
			else if (!chkBottomBorder.Checked && !chkCenterVerticalBorder.Checked && !chkLeftBorder.Checked && !chkMiddleHorizontalBorder.Checked && !chkRightBorder.Checked && !chkTopBorder.Checked)
			{
				lstBorderSettings.method_14(0);
			}
			else
			{
				lstBorderSettings.method_14(3);
			}
			bool_1 = false;
		}

		private void picBorderPreview_Paint(object sender, PaintEventArgs e)
		{
			using (SolidBrush brush = new SolidBrush(btnBackgroundColor.method_0()))
			{
				e.Graphics.FillRectangle(brush, 14, 13, 92, 72);
			}
			e.Graphics.DrawImage(bitmap_0, 0, 0);
			if (txtBorderWidth.Value > 0m)
			{
				using (Pen pen = new Pen(btnTopBorderColor.method_0(), (float)txtBorderWidth.Value))
				{
					if (chkBottomBorder.Checked)
					{
						pen.Color = btnBottomBorderColor.method_0();
						e.Graphics.DrawLine(pen, 14, 85, 106, 85);
					}
					if (chkCenterVerticalBorder.Checked)
					{
						pen.Color = btnTopBorderColor.method_0();
						e.Graphics.DrawLine(pen, 60, 13, 60, 85);
					}
					if (chkLeftBorder.Checked)
					{
						pen.Color = btnLeftBorderColor.method_0();
						e.Graphics.DrawLine(pen, 14, 13, 14, 85);
					}
					if (chkMiddleHorizontalBorder.Checked)
					{
						pen.Color = btnTopBorderColor.method_0();
						e.Graphics.DrawLine(pen, 14, 49, 106, 49);
					}
					if (chkRightBorder.Checked)
					{
						pen.Color = btnRightBorderColor.method_0();
						e.Graphics.DrawLine(pen, 106, 13, 106, 85);
					}
					if (chkTopBorder.Checked)
					{
						pen.Color = btnTopBorderColor.method_0();
						e.Graphics.DrawLine(pen, 14, 13, 106, 13);
					}
				}
			}
		}

		private void method_1(object sender, EventArgs e)
		{
			ValueModified = true;
			picBorderPreview.Invalidate();
		}

		private void method_2(object sender, EventArgs e)
		{
			ValueModified = true;
			picBorderPreview.Invalidate();
		}

		private void txtBorderWidth_ValueChanged(object sender, EventArgs e)
		{
			ValueModified = true;
			picBorderPreview.Invalidate();
		}

		private void cboBorderApplyRange_SelectedIndexChanged(object sender, EventArgs e)
		{
			ValueModified = true;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (ValueModified)
			{
				base.DialogResult = DialogResult.OK;
				if (lstBorderSettings.method_15() != null)
				{
					borderBackgroundCommandParameter_0.BorderSettingsStyle = (BorderSettingsStyle)Convert.ToInt32(lstBorderSettings.method_15().method_8());
				}
				switch (lstBorderStyle.method_13())
				{
				default:
					borderBackgroundCommandParameter_0.BorderStyle = DashStyle.Solid;
					break;
				case 0:
					borderBackgroundCommandParameter_0.BorderStyle = DashStyle.Dash;
					break;
				case 1:
					borderBackgroundCommandParameter_0.BorderStyle = DashStyle.DashDot;
					break;
				case 2:
					borderBackgroundCommandParameter_0.BorderStyle = DashStyle.DashDotDot;
					break;
				case 3:
					borderBackgroundCommandParameter_0.BorderStyle = DashStyle.Dot;
					break;
				case 4:
					borderBackgroundCommandParameter_0.BorderStyle = DashStyle.Solid;
					break;
				}
				borderBackgroundCommandParameter_0.TopBorder = chkTopBorder.Checked;
				borderBackgroundCommandParameter_0.MiddleHorizontalBorder = chkMiddleHorizontalBorder.Checked;
				borderBackgroundCommandParameter_0.BottomBorder = chkBottomBorder.Checked;
				borderBackgroundCommandParameter_0.LeftBorder = chkLeftBorder.Checked;
				borderBackgroundCommandParameter_0.CenterVerticalBorder = chkCenterVerticalBorder.Checked;
				borderBackgroundCommandParameter_0.RightBorder = chkRightBorder.Checked;
				borderBackgroundCommandParameter_0.BorderBottomColor = btnBottomBorderColor.method_0();
				borderBackgroundCommandParameter_0.BorderRightColor = btnRightBorderColor.method_0();
				borderBackgroundCommandParameter_0.BorderLeftColor = btnLeftBorderColor.method_0();
				borderBackgroundCommandParameter_0.BorderTopColor = btnTopBorderColor.method_0();
				float num = (float)txtBorderWidth.Value;
				if (num == 1f)
				{
					borderBackgroundCommandParameter_0.BorderWidth = 1f;
				}
				else
				{
					borderBackgroundCommandParameter_0.BorderWidth = (float)GraphicsUnitConvert.Convert((double)num, GraphicsUnit.Pixel, DocumentGraphicsUnit);
				}
				borderBackgroundCommandParameter_0.BackgroundColor = btnBackgroundColor.method_0();
				if (cboBorderApplyRange.Text == WriterStrings.StyleApplyRangeText)
				{
					borderBackgroundCommandParameter_0.ApplyRange = StyleApplyRanges.Text;
				}
				else if (cboBorderApplyRange.Text == WriterStrings.StyleApplyRangeTable)
				{
					borderBackgroundCommandParameter_0.ApplyRange = StyleApplyRanges.Table;
				}
				else if (cboBorderApplyRange.Text == WriterStrings.StyleApplyRangeSection)
				{
					borderBackgroundCommandParameter_0.ApplyRange = StyleApplyRanges.Section;
				}
				else if (cboBorderApplyRange.Text == WriterStrings.StyleApplyRangeRow)
				{
					borderBackgroundCommandParameter_0.ApplyRange = StyleApplyRanges.Row;
				}
				else if (cboBorderApplyRange.Text == WriterStrings.StyleApplyRangeParagraph)
				{
					borderBackgroundCommandParameter_0.ApplyRange = StyleApplyRanges.Paragraph;
				}
				else if (cboBorderApplyRange.Text == WriterStrings.StyleApplyRangeField)
				{
					borderBackgroundCommandParameter_0.ApplyRange = StyleApplyRanges.Field;
				}
				else if (cboBorderApplyRange.Text == WriterStrings.StyleApplyRangeCell)
				{
					borderBackgroundCommandParameter_0.ApplyRange = StyleApplyRanges.Cell;
				}
				base.DialogResult = DialogResult.OK;
			}
			Close();
		}

		private void method_3(object sender, EventArgs e)
		{
			ValueModified = true;
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnOptions_Click(object sender, EventArgs e)
		{
			if (eventHandler_0 != null)
			{
				eventHandler_0(sender, e);
			}
		}
	}
}
