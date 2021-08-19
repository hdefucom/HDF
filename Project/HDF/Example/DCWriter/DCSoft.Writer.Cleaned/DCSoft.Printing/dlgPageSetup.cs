#define DEBUG
using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.WinForms;
using DCSoftDotfuscate;
using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Printing
{
	/// <summary>
	///       页面设置对话框
	///       </summary>
	[ComVisible(false)]
	public class dlgPageSetup : Form
	{
		private GroupBox groupBox1;

		private Label lblTop;

		private TextBox txtTopMargin;

		private TextBox txtBottomMargin;

		private Label lblBottom;

		private Label lblLeft;

		private TextBox txtLeftMargin;

		private TextBox txtRightMargin;

		private Label lblRight;

		private GroupBox groupBox2;

		private Label lblPageSize;

		private Label lblWidth;

		private Label lblHeight;

		private ComboBox cboPage;

		private GroupBox groupBox3;

		private PictureBox picPreview;

		private Button cmdOK;

		private Button cmdCancel;

		private RadioButton rdoLandscape;

		private RadioButton rdoLandscape2;

		private TextBox txtWidth;

		private TextBox txtHeight;

		private Label label1;

		private NumericUpDown nudCopies;

		private TabControl tabControl1;

		private TabPage tabPage1;

		private TabPage tabPage2;

		private ComboBox cboPrinterName;

		private Label label2;

		private ComboBox cboPageSource;

		private Label label3;

		private CheckBox chkAutoFitPageSize;

		private TabPage tabPage3;

		private PictureBox picBackgroundImage;

		private Label label4;

		private Label label5;

		private TextBox txtOffsetY;

		private TextBox txtOffsetX;

		private Label label7;

		private Label label6;

		private TextBox txtFooterDistance;

		private TextBox txtHeaderDistance;

		private ToolStrip toolStrip1;

		private ToolStripButton btnBrowseImage;

		private ToolStripButton btnPasteImage;

		private ToolStripButton btnClearImage;

		private CheckBox chkForPOSPrinter;

		private Button btnWatermark;

		private ToolStrip toolStrip2;

		private ToolStripDropDownButton toolStripDropDownButton1;

		private ToolStripMenuItem toolStripMenuItem1;

		private ToolStripMenuItem toolStripMenuItem2;

		private ToolStripMenuItem toolStripMenuItem3;

		private ToolStripMenuItem toolStripMenuItem4;

		private TextBox txtPageIndexsForHideHeaderFooter;

		private Label label8;

		private CheckBox chkAutoChoosePageSize;

		private Button btnTerminalText;

		private Button btnDocumentGridLine;

		private Label label9;

		private ComboBox cboDuplex;

		private Label label10;

		private CheckBox chkSwapLeftRightMargin;

		private CheckBox chkHeaderFooterDifferentFirstPage;

		private CheckBox chkEnableHeaderFooter;

		private GroupBox grpHeaderFooter;

		private Container container_0 = null;

		internal string string_0 = "Paget setting error";

		private XPageSettings xpageSettings_0 = null;

		/// <summary>
		///       页面设置对象
		///       </summary>
		public XPageSettings PageSettings
		{
			get
			{
				return xpageSettings_0;
			}
			set
			{
				xpageSettings_0 = value;
			}
		}

		public dlgPageSetup()
		{
			base.DialogResult = DialogResult.Cancel;
			InitializeComponent();
		}

		/// <summary>
		///       清理所有正在使用的资源。
		///       </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing && container_0 != null)
			{
				container_0.Dispose();
			}
			base.Dispose(disposing);
		}

		/// <summary>
		///       设计器支持所需的方法 - 不要使用代码编辑器修改
		///       此方法的内容。
		///       </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Printing.dlgPageSetup));
			groupBox2 = new System.Windows.Forms.GroupBox();
			rdoLandscape = new System.Windows.Forms.RadioButton();
			rdoLandscape2 = new System.Windows.Forms.RadioButton();
			groupBox1 = new System.Windows.Forms.GroupBox();
			txtTopMargin = new System.Windows.Forms.TextBox();
			txtLeftMargin = new System.Windows.Forms.TextBox();
			txtBottomMargin = new System.Windows.Forms.TextBox();
			lblLeft = new System.Windows.Forms.Label();
			txtRightMargin = new System.Windows.Forms.TextBox();
			lblRight = new System.Windows.Forms.Label();
			lblBottom = new System.Windows.Forms.Label();
			lblTop = new System.Windows.Forms.Label();
			txtWidth = new System.Windows.Forms.TextBox();
			lblWidth = new System.Windows.Forms.Label();
			cboPage = new System.Windows.Forms.ComboBox();
			lblPageSize = new System.Windows.Forms.Label();
			txtHeight = new System.Windows.Forms.TextBox();
			lblHeight = new System.Windows.Forms.Label();
			groupBox3 = new System.Windows.Forms.GroupBox();
			picPreview = new System.Windows.Forms.PictureBox();
			cmdOK = new System.Windows.Forms.Button();
			cmdCancel = new System.Windows.Forms.Button();
			label1 = new System.Windows.Forms.Label();
			nudCopies = new System.Windows.Forms.NumericUpDown();
			tabControl1 = new System.Windows.Forms.TabControl();
			tabPage1 = new System.Windows.Forms.TabPage();
			tabPage2 = new System.Windows.Forms.TabPage();
			chkHeaderFooterDifferentFirstPage = new System.Windows.Forms.CheckBox();
			chkSwapLeftRightMargin = new System.Windows.Forms.CheckBox();
			cboDuplex = new System.Windows.Forms.ComboBox();
			label10 = new System.Windows.Forms.Label();
			btnDocumentGridLine = new System.Windows.Forms.Button();
			label9 = new System.Windows.Forms.Label();
			btnTerminalText = new System.Windows.Forms.Button();
			chkAutoChoosePageSize = new System.Windows.Forms.CheckBox();
			txtPageIndexsForHideHeaderFooter = new System.Windows.Forms.TextBox();
			label8 = new System.Windows.Forms.Label();
			btnWatermark = new System.Windows.Forms.Button();
			chkForPOSPrinter = new System.Windows.Forms.CheckBox();
			label7 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			txtFooterDistance = new System.Windows.Forms.TextBox();
			label5 = new System.Windows.Forms.Label();
			txtHeaderDistance = new System.Windows.Forms.TextBox();
			txtOffsetY = new System.Windows.Forms.TextBox();
			txtOffsetX = new System.Windows.Forms.TextBox();
			chkAutoFitPageSize = new System.Windows.Forms.CheckBox();
			cboPageSource = new System.Windows.Forms.ComboBox();
			label3 = new System.Windows.Forms.Label();
			cboPrinterName = new System.Windows.Forms.ComboBox();
			label2 = new System.Windows.Forms.Label();
			tabPage3 = new System.Windows.Forms.TabPage();
			picBackgroundImage = new System.Windows.Forms.PictureBox();
			toolStrip1 = new System.Windows.Forms.ToolStrip();
			btnBrowseImage = new System.Windows.Forms.ToolStripButton();
			btnPasteImage = new System.Windows.Forms.ToolStripButton();
			btnClearImage = new System.Windows.Forms.ToolStripButton();
			toolStrip2 = new System.Windows.Forms.ToolStrip();
			toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
			toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
			chkEnableHeaderFooter = new System.Windows.Forms.CheckBox();
			grpHeaderFooter = new System.Windows.Forms.GroupBox();
			groupBox2.SuspendLayout();
			groupBox1.SuspendLayout();
			groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)picPreview).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudCopies).BeginInit();
			tabControl1.SuspendLayout();
			tabPage1.SuspendLayout();
			tabPage2.SuspendLayout();
			tabPage3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)picBackgroundImage).BeginInit();
			toolStrip1.SuspendLayout();
			toolStrip2.SuspendLayout();
			grpHeaderFooter.SuspendLayout();
			SuspendLayout();
			groupBox2.Controls.Add(rdoLandscape);
			groupBox2.Controls.Add(rdoLandscape2);
			resources.ApplyResources(groupBox2, "groupBox2");
			groupBox2.Name = "groupBox2";
			groupBox2.TabStop = false;
			rdoLandscape.BackColor = System.Drawing.SystemColors.Control;
			resources.ApplyResources(rdoLandscape, "rdoLandscape");
			rdoLandscape.Name = "rdoLandscape";
			rdoLandscape.UseVisualStyleBackColor = false;
			rdoLandscape.CheckedChanged += new System.EventHandler(rdoLandscape_CheckedChanged);
			rdoLandscape2.BackColor = System.Drawing.SystemColors.Control;
			resources.ApplyResources(rdoLandscape2, "rdoLandscape2");
			rdoLandscape2.Name = "rdoLandscape2";
			rdoLandscape2.UseVisualStyleBackColor = false;
			rdoLandscape2.CheckedChanged += new System.EventHandler(rdoLandscape2_CheckedChanged);
			groupBox1.Controls.Add(txtTopMargin);
			groupBox1.Controls.Add(txtLeftMargin);
			groupBox1.Controls.Add(txtBottomMargin);
			groupBox1.Controls.Add(lblLeft);
			groupBox1.Controls.Add(txtRightMargin);
			groupBox1.Controls.Add(lblRight);
			groupBox1.Controls.Add(lblBottom);
			groupBox1.Controls.Add(lblTop);
			resources.ApplyResources(groupBox1, "groupBox1");
			groupBox1.Name = "groupBox1";
			groupBox1.TabStop = false;
			resources.ApplyResources(txtTopMargin, "txtTopMargin");
			txtTopMargin.Name = "txtTopMargin";
			txtTopMargin.Tag = "Pager TopMargin";
			txtTopMargin.TextChanged += new System.EventHandler(txtTopMargin_TextChanged);
			txtTopMargin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtTopMargin_KeyPress);
			resources.ApplyResources(txtLeftMargin, "txtLeftMargin");
			txtLeftMargin.Name = "txtLeftMargin";
			txtLeftMargin.Tag = "Pager LeftMargin";
			txtLeftMargin.TextChanged += new System.EventHandler(txtLeftMargin_TextChanged);
			txtLeftMargin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtLeftMargin_KeyPress);
			resources.ApplyResources(txtBottomMargin, "txtBottomMargin");
			txtBottomMargin.Name = "txtBottomMargin";
			txtBottomMargin.Tag = "Pager BottomMargin";
			txtBottomMargin.TextChanged += new System.EventHandler(txtBottomMargin_TextChanged);
			txtBottomMargin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtBottomMargin_KeyPress);
			resources.ApplyResources(lblLeft, "lblLeft");
			lblLeft.Name = "lblLeft";
			resources.ApplyResources(txtRightMargin, "txtRightMargin");
			txtRightMargin.Name = "txtRightMargin";
			txtRightMargin.Tag = "Pager RightMargin";
			txtRightMargin.TextChanged += new System.EventHandler(txtRightMargin_TextChanged);
			txtRightMargin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtRightMargin_KeyPress);
			resources.ApplyResources(lblRight, "lblRight");
			lblRight.Name = "lblRight";
			resources.ApplyResources(lblBottom, "lblBottom");
			lblBottom.Name = "lblBottom";
			resources.ApplyResources(lblTop, "lblTop");
			lblTop.Name = "lblTop";
			resources.ApplyResources(txtWidth, "txtWidth");
			txtWidth.Name = "txtWidth";
			txtWidth.Tag = "Page Width";
			resources.ApplyResources(lblWidth, "lblWidth");
			lblWidth.Name = "lblWidth";
			lblWidth.Tag = "Page Width";
			cboPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			resources.ApplyResources(cboPage, "cboPage");
			cboPage.Name = "cboPage";
			cboPage.SelectedIndexChanged += new System.EventHandler(cboPage_SelectedIndexChanged);
			resources.ApplyResources(lblPageSize, "lblPageSize");
			lblPageSize.Name = "lblPageSize";
			resources.ApplyResources(txtHeight, "txtHeight");
			txtHeight.Name = "txtHeight";
			txtHeight.Tag = "Page Height";
			resources.ApplyResources(lblHeight, "lblHeight");
			lblHeight.Name = "lblHeight";
			lblHeight.Tag = "Page Height";
			groupBox3.Controls.Add(picPreview);
			resources.ApplyResources(groupBox3, "groupBox3");
			groupBox3.Name = "groupBox3";
			groupBox3.TabStop = false;
			resources.ApplyResources(picPreview, "picPreview");
			picPreview.BackColor = System.Drawing.SystemColors.Control;
			picPreview.Name = "picPreview";
			picPreview.TabStop = false;
			picPreview.Paint += new System.Windows.Forms.PaintEventHandler(picPreview_Paint);
			resources.ApplyResources(cmdOK, "cmdOK");
			cmdOK.Name = "cmdOK";
			cmdOK.Click += new System.EventHandler(cmdOK_Click);
			cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			resources.ApplyResources(cmdCancel, "cmdCancel");
			cmdCancel.Name = "cmdCancel";
			cmdCancel.Click += new System.EventHandler(cmdCancel_Click);
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			resources.ApplyResources(nudCopies, "nudCopies");
			nudCopies.Maximum = new decimal(new int[4]
			{
				200,
				0,
				0,
				0
			});
			nudCopies.Minimum = new decimal(new int[4]
			{
				1,
				0,
				0,
				0
			});
			nudCopies.Name = "nudCopies";
			nudCopies.Value = new decimal(new int[4]
			{
				1,
				0,
				0,
				0
			});
			nudCopies.ValueChanged += new System.EventHandler(nudCopies_ValueChanged);
			tabControl1.Controls.Add(tabPage1);
			tabControl1.Controls.Add(tabPage2);
			tabControl1.Controls.Add(tabPage3);
			resources.ApplyResources(tabControl1, "tabControl1");
			tabControl1.Name = "tabControl1";
			tabControl1.SelectedIndex = 0;
			tabPage1.BackColor = System.Drawing.SystemColors.Control;
			tabPage1.Controls.Add(cboPage);
			tabPage1.Controls.Add(lblPageSize);
			tabPage1.Controls.Add(label1);
			tabPage1.Controls.Add(lblWidth);
			tabPage1.Controls.Add(lblHeight);
			tabPage1.Controls.Add(txtHeight);
			tabPage1.Controls.Add(txtWidth);
			tabPage1.Controls.Add(nudCopies);
			tabPage1.Controls.Add(groupBox2);
			tabPage1.Controls.Add(groupBox1);
			resources.ApplyResources(tabPage1, "tabPage1");
			tabPage1.Name = "tabPage1";
			tabPage2.BackColor = System.Drawing.SystemColors.Control;
			tabPage2.Controls.Add(chkEnableHeaderFooter);
			tabPage2.Controls.Add(grpHeaderFooter);
			tabPage2.Controls.Add(chkSwapLeftRightMargin);
			tabPage2.Controls.Add(cboDuplex);
			tabPage2.Controls.Add(label10);
			tabPage2.Controls.Add(btnDocumentGridLine);
			tabPage2.Controls.Add(label9);
			tabPage2.Controls.Add(btnTerminalText);
			tabPage2.Controls.Add(chkAutoChoosePageSize);
			tabPage2.Controls.Add(btnWatermark);
			tabPage2.Controls.Add(chkForPOSPrinter);
			tabPage2.Controls.Add(label4);
			tabPage2.Controls.Add(label5);
			tabPage2.Controls.Add(txtOffsetY);
			tabPage2.Controls.Add(txtOffsetX);
			tabPage2.Controls.Add(chkAutoFitPageSize);
			tabPage2.Controls.Add(cboPageSource);
			tabPage2.Controls.Add(label3);
			tabPage2.Controls.Add(cboPrinterName);
			tabPage2.Controls.Add(label2);
			resources.ApplyResources(tabPage2, "tabPage2");
			tabPage2.Name = "tabPage2";
			resources.ApplyResources(chkHeaderFooterDifferentFirstPage, "chkHeaderFooterDifferentFirstPage");
			chkHeaderFooterDifferentFirstPage.Name = "chkHeaderFooterDifferentFirstPage";
			chkHeaderFooterDifferentFirstPage.UseVisualStyleBackColor = true;
			resources.ApplyResources(chkSwapLeftRightMargin, "chkSwapLeftRightMargin");
			chkSwapLeftRightMargin.Name = "chkSwapLeftRightMargin";
			chkSwapLeftRightMargin.UseVisualStyleBackColor = true;
			cboDuplex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboDuplex.FormattingEnabled = true;
			cboDuplex.Items.AddRange(new object[5]
			{
				resources.GetString("cboDuplex.Items"),
				resources.GetString("cboDuplex.Items1"),
				resources.GetString("cboDuplex.Items2"),
				resources.GetString("cboDuplex.Items3"),
				resources.GetString("cboDuplex.Items4")
			});
			resources.ApplyResources(cboDuplex, "cboDuplex");
			cboDuplex.Name = "cboDuplex";
			resources.ApplyResources(label10, "label10");
			label10.Name = "label10";
			resources.ApplyResources(btnDocumentGridLine, "btnDocumentGridLine");
			btnDocumentGridLine.Name = "btnDocumentGridLine";
			btnDocumentGridLine.UseVisualStyleBackColor = true;
			btnDocumentGridLine.Click += new System.EventHandler(btnDocumentGridLine_Click);
			resources.ApplyResources(label9, "label9");
			label9.Name = "label9";
			resources.ApplyResources(btnTerminalText, "btnTerminalText");
			btnTerminalText.Name = "btnTerminalText";
			btnTerminalText.UseVisualStyleBackColor = true;
			btnTerminalText.Click += new System.EventHandler(btnTerminalText_Click);
			resources.ApplyResources(chkAutoChoosePageSize, "chkAutoChoosePageSize");
			chkAutoChoosePageSize.Name = "chkAutoChoosePageSize";
			chkAutoChoosePageSize.UseVisualStyleBackColor = true;
			resources.ApplyResources(txtPageIndexsForHideHeaderFooter, "txtPageIndexsForHideHeaderFooter");
			txtPageIndexsForHideHeaderFooter.Name = "txtPageIndexsForHideHeaderFooter";
			resources.ApplyResources(label8, "label8");
			label8.Name = "label8";
			resources.ApplyResources(btnWatermark, "btnWatermark");
			btnWatermark.Name = "btnWatermark";
			btnWatermark.UseVisualStyleBackColor = true;
			btnWatermark.Click += new System.EventHandler(btnWatermark_Click);
			resources.ApplyResources(chkForPOSPrinter, "chkForPOSPrinter");
			chkForPOSPrinter.Name = "chkForPOSPrinter";
			chkForPOSPrinter.UseVisualStyleBackColor = true;
			resources.ApplyResources(label7, "label7");
			label7.Name = "label7";
			resources.ApplyResources(label6, "label6");
			label6.Name = "label6";
			resources.ApplyResources(label4, "label4");
			label4.Name = "label4";
			label4.Tag = "Page Width";
			resources.ApplyResources(txtFooterDistance, "txtFooterDistance");
			txtFooterDistance.Name = "txtFooterDistance";
			resources.ApplyResources(label5, "label5");
			label5.Name = "label5";
			label5.Tag = "Page Height";
			resources.ApplyResources(txtHeaderDistance, "txtHeaderDistance");
			txtHeaderDistance.Name = "txtHeaderDistance";
			resources.ApplyResources(txtOffsetY, "txtOffsetY");
			txtOffsetY.Name = "txtOffsetY";
			resources.ApplyResources(txtOffsetX, "txtOffsetX");
			txtOffsetX.Name = "txtOffsetX";
			resources.ApplyResources(chkAutoFitPageSize, "chkAutoFitPageSize");
			chkAutoFitPageSize.Name = "chkAutoFitPageSize";
			chkAutoFitPageSize.UseVisualStyleBackColor = true;
			cboPageSource.FormattingEnabled = true;
			resources.ApplyResources(cboPageSource, "cboPageSource");
			cboPageSource.Name = "cboPageSource";
			resources.ApplyResources(label3, "label3");
			label3.Name = "label3";
			cboPrinterName.FormattingEnabled = true;
			resources.ApplyResources(cboPrinterName, "cboPrinterName");
			cboPrinterName.Name = "cboPrinterName";
			cboPrinterName.TextChanged += new System.EventHandler(cboPrinterName_TextChanged);
			resources.ApplyResources(label2, "label2");
			label2.Name = "label2";
			tabPage3.BackColor = System.Drawing.SystemColors.Control;
			tabPage3.Controls.Add(picBackgroundImage);
			tabPage3.Controls.Add(toolStrip1);
			resources.ApplyResources(tabPage3, "tabPage3");
			tabPage3.Name = "tabPage3";
			picBackgroundImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			resources.ApplyResources(picBackgroundImage, "picBackgroundImage");
			picBackgroundImage.Name = "picBackgroundImage";
			picBackgroundImage.TabStop = false;
			toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[3]
			{
				btnBrowseImage,
				btnPasteImage,
				btnClearImage
			});
			resources.ApplyResources(toolStrip1, "toolStrip1");
			toolStrip1.Name = "toolStrip1";
			resources.ApplyResources(btnBrowseImage, "btnBrowseImage");
			btnBrowseImage.Name = "btnBrowseImage";
			btnBrowseImage.Click += new System.EventHandler(btnBrowseImage_Click);
			resources.ApplyResources(btnPasteImage, "btnPasteImage");
			btnPasteImage.Name = "btnPasteImage";
			btnPasteImage.Click += new System.EventHandler(btnPasteImage_Click);
			resources.ApplyResources(btnClearImage, "btnClearImage");
			btnClearImage.Name = "btnClearImage";
			btnClearImage.Click += new System.EventHandler(btnClearImage_Click);
			resources.ApplyResources(toolStrip2, "toolStrip2");
			toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[1]
			{
				toolStripDropDownButton1
			});
			toolStrip2.Name = "toolStrip2";
			toolStrip2.ShowItemToolTips = false;
			toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[4]
			{
				toolStripMenuItem1,
				toolStripMenuItem2,
				toolStripMenuItem3,
				toolStripMenuItem4
			});
			resources.ApplyResources(toolStripDropDownButton1, "toolStripDropDownButton1");
			toolStripDropDownButton1.Name = "toolStripDropDownButton1";
			toolStripMenuItem1.Name = "toolStripMenuItem1";
			resources.ApplyResources(toolStripMenuItem1, "toolStripMenuItem1");
			toolStripMenuItem1.Click += new System.EventHandler(toolStripMenuItem1_Click);
			toolStripMenuItem2.Name = "toolStripMenuItem2";
			resources.ApplyResources(toolStripMenuItem2, "toolStripMenuItem2");
			toolStripMenuItem2.Click += new System.EventHandler(toolStripMenuItem2_Click);
			toolStripMenuItem3.Name = "toolStripMenuItem3";
			resources.ApplyResources(toolStripMenuItem3, "toolStripMenuItem3");
			toolStripMenuItem3.Click += new System.EventHandler(toolStripMenuItem3_Click);
			toolStripMenuItem4.Name = "toolStripMenuItem4";
			resources.ApplyResources(toolStripMenuItem4, "toolStripMenuItem4");
			toolStripMenuItem4.Click += new System.EventHandler(toolStripMenuItem4_Click);
			resources.ApplyResources(chkEnableHeaderFooter, "chkEnableHeaderFooter");
			chkEnableHeaderFooter.Name = "chkEnableHeaderFooter";
			chkEnableHeaderFooter.UseVisualStyleBackColor = true;
			chkEnableHeaderFooter.CheckedChanged += new System.EventHandler(chkEnableHeaderFooter_CheckedChanged);
			grpHeaderFooter.Controls.Add(txtHeaderDistance);
			grpHeaderFooter.Controls.Add(chkHeaderFooterDifferentFirstPage);
			grpHeaderFooter.Controls.Add(txtFooterDistance);
			grpHeaderFooter.Controls.Add(label6);
			grpHeaderFooter.Controls.Add(label7);
			grpHeaderFooter.Controls.Add(txtPageIndexsForHideHeaderFooter);
			grpHeaderFooter.Controls.Add(label8);
			resources.ApplyResources(grpHeaderFooter, "grpHeaderFooter");
			grpHeaderFooter.Name = "grpHeaderFooter";
			grpHeaderFooter.TabStop = false;
			resources.ApplyResources(this, "$this");
			base.CancelButton = cmdCancel;
			base.Controls.Add(toolStrip2);
			base.Controls.Add(cmdCancel);
			base.Controls.Add(cmdOK);
			base.Controls.Add(groupBox3);
			base.Controls.Add(tabControl1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgPageSetup";
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgPageSetup_Load);
			groupBox2.ResumeLayout(false);
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			groupBox3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)picPreview).EndInit();
			((System.ComponentModel.ISupportInitialize)nudCopies).EndInit();
			tabControl1.ResumeLayout(false);
			tabPage1.ResumeLayout(false);
			tabPage1.PerformLayout();
			tabPage2.ResumeLayout(false);
			tabPage2.PerformLayout();
			tabPage3.ResumeLayout(false);
			tabPage3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)picBackgroundImage).EndInit();
			toolStrip1.ResumeLayout(false);
			toolStrip1.PerformLayout();
			toolStrip2.ResumeLayout(false);
			toolStrip2.PerformLayout();
			grpHeaderFooter.ResumeLayout(false);
			grpHeaderFooter.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		/// <summary>
		/// </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="e">
		/// </param>
		private void dlgPageSetup_Load(object sender, EventArgs e)
		{
			ArrayList arrayList = new ArrayList();
			arrayList.AddRange(Enum.GetNames(typeof(PaperKind)));
			arrayList.Sort();
			cboPage.Items.Clear();
			cboPage.Items.AddRange(arrayList.ToArray());
			cboPrinterName.Items.Clear();
			try
			{
				foreach (string installedPrinter in PrinterSettings.InstalledPrinters)
				{
					cboPrinterName.Items.Add(installedPrinter);
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}
			method_0();
		}

		private void method_0()
		{
			int num = 15;
			if (xpageSettings_0 != null)
			{
				cboPrinterName.Text = xpageSettings_0.PrinterName;
				for (int i = 0; i < cboPage.Items.Count; i++)
				{
					PaperKind paperKind = (PaperKind)Enum.Parse(typeof(PaperKind), (string)cboPage.Items[i]);
					if (xpageSettings_0.PaperKind == paperKind)
					{
						cboPage.SelectedIndex = i;
						break;
					}
				}
				chkAutoFitPageSize.Checked = xpageSettings_0.AutoFitPageSize;
				if (xpageSettings_0.EditTimeBackgroundImage != null)
				{
					picBackgroundImage.Image = xpageSettings_0.EditTimeBackgroundImage.Value;
					picBackgroundImage.Tag = xpageSettings_0.EditTimeBackgroundImage;
				}
				txtOffsetX.Text = MeasureConvert.HundredthsInchToCentimeter(xpageSettings_0.OffsetX).ToString("0.00");
				txtOffsetY.Text = MeasureConvert.HundredthsInchToCentimeter(xpageSettings_0.OffsetY).ToString("0.00");
				txtHeaderDistance.Text = MeasureConvert.HundredthsInchToCentimeter(xpageSettings_0.HeaderDistance).ToString("0.00");
				txtFooterDistance.Text = MeasureConvert.HundredthsInchToCentimeter(xpageSettings_0.FooterDistance).ToString("0.00");
				cboDuplex.SelectedIndex = (int)xpageSettings_0.SpecifyDuplex;
				txtLeftMargin.Text = Convert.ToDecimal(MeasureConvert.HundredthsInchToCentimeter(xpageSettings_0.LeftMargin)).ToString("0.00");
				txtTopMargin.Text = Convert.ToDecimal(MeasureConvert.HundredthsInchToCentimeter(xpageSettings_0.TopMargin)).ToString("0.00");
				txtRightMargin.Text = Convert.ToDecimal(MeasureConvert.HundredthsInchToCentimeter(xpageSettings_0.RightMargin)).ToString("0.00");
				txtBottomMargin.Text = Convert.ToDecimal(MeasureConvert.HundredthsInchToCentimeter(xpageSettings_0.BottomMargin)).ToString("0.00");
				rdoLandscape.Checked = !xpageSettings_0.Landscape;
				rdoLandscape2.Checked = xpageSettings_0.Landscape;
				nudCopies.Value = Convert.ToDecimal(xpageSettings_0.Copies);
				chkForPOSPrinter.Checked = xpageSettings_0.ForPOSPrinter;
				txtPageIndexsForHideHeaderFooter.Text = xpageSettings_0.PageIndexsForHideHeaderFooter;
				chkAutoChoosePageSize.Checked = xpageSettings_0.AutoChoosePageSize;
				btnDocumentGridLine.Tag = xpageSettings_0.DocumentGridLine;
				if (xpageSettings_0.DocumentGridLine != null)
				{
					btnDocumentGridLine.Text = xpageSettings_0.DocumentGridLine.ToString();
				}
				btnWatermark.Tag = xpageSettings_0.Watermark;
				btnTerminalText.Tag = xpageSettings_0.TerminalText;
				chkSwapLeftRightMargin.Checked = xpageSettings_0.SwapLeftRightMargin;
				chkHeaderFooterDifferentFirstPage.Checked = xpageSettings_0.HeaderFooterDifferentFirstPage;
				chkEnableHeaderFooter.Checked = xpageSettings_0.EnableHeaderFooter;
				chkEnableHeaderFooter_CheckedChanged(null, null);
			}
			if (cboPage.SelectedIndex >= 0)
			{
				method_2((PaperKind)Enum.Parse(typeof(PaperKind), cboPage.Text));
			}
		}

		private bool method_1(XPageSettings xpageSettings_1)
		{
			if (xpageSettings_1 != null)
			{
				xpageSettings_1.PaperKind = (PaperKind)Enum.Parse(typeof(PaperKind), cboPage.Text);
				if (xpageSettings_1.PaperKind == PaperKind.Custom)
				{
					xpageSettings_1.PaperWidth = (int)MeasureConvert.CentimeterToHundredthsInch(Convert.ToDouble(txtWidth.Text));
					xpageSettings_1.PaperHeight = (int)MeasureConvert.CentimeterToHundredthsInch(Convert.ToDouble(txtHeight.Text));
				}
				xpageSettings_1.LeftMargin = (int)MeasureConvert.CentimeterToHundredthsInch(Convert.ToDouble(txtLeftMargin.Text));
				xpageSettings_1.TopMargin = (int)MeasureConvert.CentimeterToHundredthsInch(Convert.ToDouble(txtTopMargin.Text));
				xpageSettings_1.RightMargin = (int)MeasureConvert.CentimeterToHundredthsInch(Convert.ToDouble(txtRightMargin.Text));
				xpageSettings_1.BottomMargin = (int)MeasureConvert.CentimeterToHundredthsInch(Convert.ToDouble(txtBottomMargin.Text));
				xpageSettings_1.Landscape = rdoLandscape2.Checked;
				xpageSettings_1.Copies = Convert.ToInt32(nudCopies.Value);
				xpageSettings_1.PrinterName = cboPrinterName.Text;
				xpageSettings_1.PaperSource = cboPageSource.Text;
				xpageSettings_1.AutoFitPageSize = chkAutoFitPageSize.Checked;
				xpageSettings_1.OffsetX = (float)MeasureConvert.CentimeterToHundredthsInch(Convert.ToDouble(txtOffsetX.Text));
				xpageSettings_1.OffsetY = (float)MeasureConvert.CentimeterToHundredthsInch(Convert.ToDouble(txtOffsetY.Text));
				xpageSettings_1.HeaderDistance = (int)MeasureConvert.CentimeterToHundredthsInch(Convert.ToDouble(txtHeaderDistance.Text));
				xpageSettings_1.FooterDistance = (int)MeasureConvert.CentimeterToHundredthsInch(Convert.ToDouble(txtFooterDistance.Text));
				xpageSettings_1.EditTimeBackgroundImage = (XImageValue)picBackgroundImage.Tag;
				xpageSettings_1.ForPOSPrinter = chkForPOSPrinter.Checked;
				xpageSettings_1.Watermark = (WatermarkInfo)btnWatermark.Tag;
				xpageSettings_1.TerminalText = (DocumentTerminalTextInfo)btnTerminalText.Tag;
				xpageSettings_1.PageIndexsForHideHeaderFooter = txtPageIndexsForHideHeaderFooter.Text;
				xpageSettings_1.AutoChoosePageSize = chkAutoChoosePageSize.Checked;
				xpageSettings_1.DocumentGridLine = (DCGridLineInfo)btnDocumentGridLine.Tag;
				xpageSettings_1.SpecifyDuplex = (DCDuplexType)cboDuplex.SelectedIndex;
				xpageSettings_1.SwapLeftRightMargin = chkSwapLeftRightMargin.Checked;
				xpageSettings_1.HeaderFooterDifferentFirstPage = chkHeaderFooterDifferentFirstPage.Checked;
				xpageSettings_1.EnableHeaderFooter = chkEnableHeaderFooter.Checked;
				return true;
			}
			return false;
		}

		/// <summary>
		/// </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="e">
		/// </param>
		private void picPreview_Paint(object sender, PaintEventArgs e)
		{
			if (method_4(bool_0: false))
			{
				if (xpageSettings_0 == null)
				{
					xpageSettings_0 = new XPageSettings();
				}
				if (!method_1(xpageSettings_0))
				{
					using (StringFormat stringFormat = new StringFormat())
					{
						stringFormat.Alignment = StringAlignment.Center;
						stringFormat.LineAlignment = StringAlignment.Center;
						e.Graphics.DrawString(string_0, Font, Brushes.Red, new RectangleF(0f, 0f, picPreview.Width, picPreview.Height), stringFormat);
					}
					return;
				}
				GClass269 gClass = new GClass269();
				gClass.method_5(xpageSettings_0.Landscape);
				gClass.method_3(xpageSettings_0.Margins);
				gClass.method_1(xpageSettings_0.PaperSize);
				gClass.method_8(picPreview.ClientRectangle);
				gClass.method_9(sender, e);
			}
		}

		/// <summary>
		/// </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="e">
		/// </param>
		private void cboPage_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboPage.SelectedIndex >= 0)
			{
				method_2((PaperKind)Enum.Parse(typeof(PaperKind), cboPage.Text));
				picPreview.Invalidate();
			}
		}

		private void method_2(PaperKind paperKind_0)
		{
			int num = 14;
			txtWidth.Enabled = (paperKind_0 == PaperKind.Custom);
			txtHeight.Enabled = (paperKind_0 == PaperKind.Custom);
			if (paperKind_0 == PaperKind.Custom)
			{
				decimal num2 = Convert.ToDecimal(MeasureConvert.HundredthsInchToCentimeter(xpageSettings_0.PaperWidth));
				decimal num3 = Convert.ToDecimal(MeasureConvert.HundredthsInchToCentimeter(xpageSettings_0.PaperHeight));
				txtWidth.Text = num2.ToString();
				txtHeight.Text = num3.ToString();
				return;
			}
			Size size = XPaperSizeCollection.smethod_1(paperKind_0);
			if (!size.IsEmpty)
			{
				txtWidth.Text = MeasureConvert.HundredthsInchToCentimeter(size.Width).ToString("0.00");
				txtHeight.Text = MeasureConvert.HundredthsInchToCentimeter(size.Height).ToString("0.00");
			}
		}

		private float method_3(string string_1)
		{
			float result = 0f;
			if (float.TryParse(string_1, out result))
			{
				return result;
			}
			return 0f;
		}

		private bool method_4(bool bool_0)
		{
			float result = 0f;
			if (!float.TryParse(txtLeftMargin.Text, out result))
			{
				if (bool_0)
				{
					MessageBox.Show(this, PrintingResources.PromptInputNumer, Text);
					txtLeftMargin.Select();
				}
				return false;
			}
			float result2 = 0f;
			if (!float.TryParse(txtTopMargin.Text, out result2))
			{
				if (bool_0)
				{
					MessageBox.Show(this, PrintingResources.PromptInputNumer, Text);
					txtTopMargin.Select();
				}
				return false;
			}
			float result3 = 0f;
			if (!float.TryParse(txtRightMargin.Text, out result3))
			{
				if (bool_0)
				{
					MessageBox.Show(this, PrintingResources.PromptInputNumer, Text);
					txtRightMargin.Select();
				}
				return false;
			}
			float result4 = 0f;
			if (!float.TryParse(txtBottomMargin.Text, out result4))
			{
				if (bool_0)
				{
					MessageBox.Show(this, PrintingResources.PromptInputNumer, Text);
					txtBottomMargin.Select();
				}
				return false;
			}
			float result5 = 0f;
			if (!float.TryParse(txtWidth.Text, out result5))
			{
				if (bool_0)
				{
					MessageBox.Show(this, PrintingResources.PromptInputNumer, Text);
					txtWidth.Select();
				}
				return false;
			}
			float result6 = 0f;
			if (!float.TryParse(txtHeight.Text, out result6))
			{
				if (bool_0)
				{
					MessageBox.Show(this, PrintingResources.PromptInputNumer, Text);
					txtHeight.Select();
				}
				return false;
			}
			if (rdoLandscape.Checked)
			{
				if (result5 < result + result3)
				{
					if (bool_0)
					{
						MessageBox.Show(this, PrintingResources.MargeMoreThanPageWidth, Text);
						txtWidth.Focus();
					}
					return false;
				}
				if (result6 < result2 + result4)
				{
					if (bool_0)
					{
						MessageBox.Show(this, PrintingResources.MargeMoreThanPageHeight, Text);
						txtWidth.Focus();
					}
					return false;
				}
			}
			else
			{
				if (result6 < result + result3)
				{
					if (bool_0)
					{
						MessageBox.Show(this, PrintingResources.MargeMoreThanPageWidth, Text);
						txtWidth.Focus();
					}
					return false;
				}
				if (result5 < result2 + result4)
				{
					if (bool_0)
					{
						MessageBox.Show(this, PrintingResources.MargeMoreThanPageHeight, Text);
						txtWidth.Focus();
					}
					return false;
				}
			}
			if (!method_5(txtOffsetX, bool_0))
			{
				return false;
			}
			if (!method_5(txtOffsetY, bool_0))
			{
				return false;
			}
			if (!method_5(txtHeaderDistance, bool_0))
			{
				return false;
			}
			if (!method_5(txtFooterDistance, bool_0))
			{
				return false;
			}
			return true;
		}

		private bool method_5(TextBox textBox_0, bool bool_0)
		{
			float result = 0f;
			if (!float.TryParse(textBox_0.Text, out result))
			{
				if (bool_0)
				{
					MessageBox.Show(this, PrintingResources.PromptInputNumer, Text);
					textBox_0.Focus();
				}
				return true;
			}
			return true;
		}

		/// <summary>
		/// </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="e">
		/// </param>
		private void cmdOK_Click(object sender, EventArgs e)
		{
			if (!method_4(bool_0: true))
			{
				return;
			}
			if (xpageSettings_0 == null)
			{
				xpageSettings_0 = new XPageSettings();
			}
			if (method_1(xpageSettings_0))
			{
				if (xpageSettings_0.EditTimeBackgroundImage != null)
				{
					xpageSettings_0.EditTimeBackgroundImage.ChangeImageFormat(ImageFormat.Jpeg);
				}
				base.DialogResult = DialogResult.OK;
				Close();
			}
			else
			{
				MessageBox.Show(this, string_0, Text);
			}
		}

		private void cmdCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void nudCopies_ValueChanged(object sender, EventArgs e)
		{
			picPreview.Invalidate();
		}

		private void method_6(object sender, EventArgs e)
		{
			picPreview.Invalidate();
		}

		private void rdoLandscape_CheckedChanged(object sender, EventArgs e)
		{
			picPreview.Invalidate();
		}

		private void rdoLandscape2_CheckedChanged(object sender, EventArgs e)
		{
			picPreview.Invalidate();
		}

		private void txtTopMargin_TextChanged(object sender, EventArgs e)
		{
			picPreview.Invalidate();
		}

		private void txtBottomMargin_TextChanged(object sender, EventArgs e)
		{
			picPreview.Invalidate();
		}

		private void txtLeftMargin_TextChanged(object sender, EventArgs e)
		{
			picPreview.Invalidate();
		}

		private void txtRightMargin_TextChanged(object sender, EventArgs e)
		{
			picPreview.Invalidate();
		}

		private void txtTopMargin_KeyPress(object sender, KeyPressEventArgs e)
		{
			picPreview.Invalidate();
		}

		private void txtBottomMargin_KeyPress(object sender, KeyPressEventArgs e)
		{
			picPreview.Invalidate();
		}

		private void txtLeftMargin_KeyPress(object sender, KeyPressEventArgs e)
		{
			picPreview.Invalidate();
		}

		private void txtRightMargin_KeyPress(object sender, KeyPressEventArgs e)
		{
			picPreview.Invalidate();
		}

		private void toolStripMenuItem2_Click(object sender, EventArgs e)
		{
			XPageSettings.WordDefault.method_5(xpageSettings_0);
			method_0();
		}

		private void toolStripMenuItem1_Click(object sender, EventArgs e)
		{
			XPageSettings.IEDefault.method_5(xpageSettings_0);
			method_0();
		}

		private void cboPrinterName_TextChanged(object sender, EventArgs e)
		{
			try
			{
				cboPageSource.Items.Clear();
				foreach (string installedPrinter in PrinterSettings.InstalledPrinters)
				{
					if (string.Compare(installedPrinter, cboPrinterName.Text, ignoreCase: true) == 0)
					{
						PrinterSettings printerSettings = new PrinterSettings();
						printerSettings.PrinterName = installedPrinter;
						foreach (PaperSource paperSource in printerSettings.PaperSources)
						{
							cboPageSource.Items.Add(paperSource.SourceName);
						}
						break;
					}
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}
		}

		private void btnBrowseImage_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.Filter = PrintingResources.ImageFileFilter;
				openFileDialog.CheckFileExists = true;
				if (openFileDialog.ShowDialog(this) == DialogResult.OK)
				{
					XImageValue xImageValue = new XImageValue();
					xImageValue.SafeLoadMode = true;
					xImageValue.Load(openFileDialog.FileName);
					picBackgroundImage.Tag = xImageValue;
					picBackgroundImage.Image = xImageValue.Value;
				}
			}
		}

		private void btnPasteImage_Click(object sender, EventArgs e)
		{
			XImageValue imageFromClipboard = WinFormUtils.GetImageFromClipboard();
			if (imageFromClipboard != null && imageFromClipboard.Value != null)
			{
				picBackgroundImage.Tag = imageFromClipboard;
				picBackgroundImage.Image = imageFromClipboard.Value;
			}
		}

		private void btnClearImage_Click(object sender, EventArgs e)
		{
			picBackgroundImage.Tag = null;
			picBackgroundImage.Image = null;
		}

		private void btnWatermark_Click(object sender, EventArgs e)
		{
			using (dlgWatermarkInfo dlgWatermarkInfo = new dlgWatermarkInfo())
			{
				dlgWatermarkInfo.InputInfo = (WatermarkInfo)btnWatermark.Tag;
				if (dlgWatermarkInfo.ShowDialog(this) == DialogResult.OK)
				{
					btnWatermark.Tag = dlgWatermarkInfo.InputInfo;
				}
			}
		}

		private void toolStripMenuItem3_Click(object sender, EventArgs e)
		{
			int num = 0;
			using (SaveFileDialog saveFileDialog = new SaveFileDialog())
			{
				saveFileDialog.CheckPathExists = true;
				saveFileDialog.OverwritePrompt = true;
				saveFileDialog.Filter = "*.pagesettings.xml|*.pagesettings.xml";
				if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
				{
					XPageSettings xPageSettings = new XPageSettings();
					if (method_1(xPageSettings))
					{
						XMLHelper.SaveObjectToXMLFile(xPageSettings, saveFileDialog.FileName);
					}
				}
			}
		}

		private void toolStripMenuItem4_Click(object sender, EventArgs e)
		{
			int num = 17;
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.CheckFileExists = true;
				openFileDialog.Filter = "*.pagesettings.xml|*.pagesettings.xml";
				if (openFileDialog.ShowDialog(this) == DialogResult.OK)
				{
					try
					{
						XPageSettings xPageSettings = (XPageSettings)XMLHelper.LoadObjectFromXMLFile(typeof(XPageSettings), openFileDialog.FileName);
						if (xPageSettings != null)
						{
							xpageSettings_0 = xPageSettings;
							method_0();
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show(this, ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
			}
		}

		private void btnTerminalText_Click(object sender, EventArgs e)
		{
			using (dlgTerminalTextInfo dlgTerminalTextInfo = new dlgTerminalTextInfo())
			{
				dlgTerminalTextInfo.InputTextInfo = (DocumentTerminalTextInfo)btnTerminalText.Tag;
				if (dlgTerminalTextInfo.ShowDialog(this) == DialogResult.OK)
				{
					btnTerminalText.Tag = dlgTerminalTextInfo.InputTextInfo;
				}
			}
		}

		private void btnDocumentGridLine_Click(object sender, EventArgs e)
		{
			using (dlgDCGridLineInfoForPageSettings dlgDCGridLineInfoForPageSettings = new dlgDCGridLineInfoForPageSettings())
			{
				dlgDCGridLineInfoForPageSettings.InputGridLineInfo = (btnDocumentGridLine.Tag as DCGridLineInfo);
				if (dlgDCGridLineInfoForPageSettings.ShowDialog(this) == DialogResult.OK)
				{
					btnDocumentGridLine.Tag = dlgDCGridLineInfoForPageSettings.InputGridLineInfo;
					btnDocumentGridLine.Text = dlgDCGridLineInfoForPageSettings.InputGridLineInfo.ToString();
				}
			}
		}

		private void chkEnableHeaderFooter_CheckedChanged(object sender, EventArgs e)
		{
			grpHeaderFooter.Enabled = chkEnableHeaderFooter.Checked;
			foreach (Control control in grpHeaderFooter.Controls)
			{
				control.Enabled = grpHeaderFooter.Enabled;
			}
		}
	}
}
