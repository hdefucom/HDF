using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Resources;
using System.Windows.Forms;

namespace ZYTextDocumentLib
{
	public class dlgPageSetup : Form
	{
		private TabControl myTab;

		private TabPage tabPage1;

		private TabPage tabPage2;

		private GroupBox groupBox1;

		private Label label1;

		private NumericUpDown txtTopMargin;

		private NumericUpDown txtBottomMargin;

		private Label label2;

		private Label label3;

		private NumericUpDown txtLeftMargin;

		private NumericUpDown txtRightMargin;

		private Label label4;

		private GroupBox groupBox2;

		private Label label5;

		private RadioButton radioButton1;

		private RadioButton radioButton2;

		private Label label6;

		private Label label7;

		private Label label8;

		private NumericUpDown numericUpDown1;

		private NumericUpDown numericUpDown2;

		private Label label9;

		private ComboBox cboPage;

		private GroupBox groupBox3;

		private PictureBox picPreview;

		private Button cmdOK;

		private Button cmdCancel;

		private Container components = null;

		public dlgPageSetup()
		{
			InitializeComponent();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			System.Resources.ResourceManager resourceManager = new System.Resources.ResourceManager(typeof(ZYTextDocumentLib.dlgPageSetup));
			myTab = new System.Windows.Forms.TabControl();
			tabPage1 = new System.Windows.Forms.TabPage();
			tabPage2 = new System.Windows.Forms.TabPage();
			groupBox1 = new System.Windows.Forms.GroupBox();
			label1 = new System.Windows.Forms.Label();
			txtTopMargin = new System.Windows.Forms.NumericUpDown();
			txtBottomMargin = new System.Windows.Forms.NumericUpDown();
			label2 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			txtLeftMargin = new System.Windows.Forms.NumericUpDown();
			txtRightMargin = new System.Windows.Forms.NumericUpDown();
			label4 = new System.Windows.Forms.Label();
			groupBox2 = new System.Windows.Forms.GroupBox();
			label5 = new System.Windows.Forms.Label();
			radioButton1 = new System.Windows.Forms.RadioButton();
			radioButton2 = new System.Windows.Forms.RadioButton();
			label6 = new System.Windows.Forms.Label();
			label7 = new System.Windows.Forms.Label();
			cboPage = new System.Windows.Forms.ComboBox();
			label8 = new System.Windows.Forms.Label();
			numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			numericUpDown2 = new System.Windows.Forms.NumericUpDown();
			label9 = new System.Windows.Forms.Label();
			groupBox3 = new System.Windows.Forms.GroupBox();
			picPreview = new System.Windows.Forms.PictureBox();
			cmdOK = new System.Windows.Forms.Button();
			cmdCancel = new System.Windows.Forms.Button();
			myTab.SuspendLayout();
			tabPage1.SuspendLayout();
			tabPage2.SuspendLayout();
			groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)txtTopMargin).BeginInit();
			((System.ComponentModel.ISupportInitialize)txtBottomMargin).BeginInit();
			((System.ComponentModel.ISupportInitialize)txtLeftMargin).BeginInit();
			((System.ComponentModel.ISupportInitialize)txtRightMargin).BeginInit();
			groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
			groupBox3.SuspendLayout();
			SuspendLayout();
			myTab.Controls.Add(tabPage1);
			myTab.Controls.Add(tabPage2);
			myTab.Dock = System.Windows.Forms.DockStyle.Top;
			myTab.Location = new System.Drawing.Point(0, 0);
			myTab.Name = "myTab";
			myTab.SelectedIndex = 0;
			myTab.Size = new System.Drawing.Size(426, 352);
			myTab.TabIndex = 0;
			tabPage1.Controls.Add(groupBox2);
			tabPage1.Controls.Add(groupBox1);
			tabPage1.Location = new System.Drawing.Point(4, 21);
			tabPage1.Name = "tabPage1";
			tabPage1.Size = new System.Drawing.Size(418, 327);
			tabPage1.TabIndex = 0;
			tabPage1.Text = "页边距";
			tabPage2.Controls.Add(numericUpDown1);
			tabPage2.Controls.Add(label8);
			tabPage2.Controls.Add(cboPage);
			tabPage2.Controls.Add(label7);
			tabPage2.Controls.Add(numericUpDown2);
			tabPage2.Controls.Add(label9);
			tabPage2.Location = new System.Drawing.Point(4, 21);
			tabPage2.Name = "tabPage2";
			tabPage2.Size = new System.Drawing.Size(418, 327);
			tabPage2.TabIndex = 1;
			tabPage2.Text = "纸张";
			groupBox1.Controls.Add(txtTopMargin);
			groupBox1.Controls.Add(label1);
			groupBox1.Controls.Add(txtBottomMargin);
			groupBox1.Controls.Add(label2);
			groupBox1.Controls.Add(label3);
			groupBox1.Controls.Add(txtLeftMargin);
			groupBox1.Controls.Add(txtRightMargin);
			groupBox1.Controls.Add(label4);
			groupBox1.Location = new System.Drawing.Point(8, 8);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(400, 80);
			groupBox1.TabIndex = 0;
			groupBox1.TabStop = false;
			groupBox1.Text = "页边距";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(16, 21);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(42, 17);
			label1.TabIndex = 0;
			label1.Text = "上(&T):";
			txtTopMargin.Location = new System.Drawing.Point(66, 19);
			txtTopMargin.Name = "txtTopMargin";
			txtTopMargin.Size = new System.Drawing.Size(72, 21);
			txtTopMargin.TabIndex = 1;
			txtBottomMargin.Location = new System.Drawing.Point(240, 19);
			txtBottomMargin.Name = "txtBottomMargin";
			txtBottomMargin.Size = new System.Drawing.Size(72, 21);
			txtBottomMargin.TabIndex = 1;
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(184, 21);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(42, 17);
			label2.TabIndex = 0;
			label2.Text = "下(&B):";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(16, 51);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(42, 17);
			label3.TabIndex = 0;
			label3.Text = "左(&L):";
			txtLeftMargin.Location = new System.Drawing.Point(66, 49);
			txtLeftMargin.Name = "txtLeftMargin";
			txtLeftMargin.Size = new System.Drawing.Size(72, 21);
			txtLeftMargin.TabIndex = 1;
			txtRightMargin.Location = new System.Drawing.Point(240, 49);
			txtRightMargin.Name = "txtRightMargin";
			txtRightMargin.Size = new System.Drawing.Size(72, 21);
			txtRightMargin.TabIndex = 1;
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(184, 51);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(42, 17);
			label4.TabIndex = 0;
			label4.Text = "右(&R):";
			groupBox2.Controls.Add(radioButton1);
			groupBox2.Controls.Add(label5);
			groupBox2.Controls.Add(radioButton2);
			groupBox2.Controls.Add(label6);
			groupBox2.Location = new System.Drawing.Point(8, 96);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new System.Drawing.Size(400, 80);
			groupBox2.TabIndex = 1;
			groupBox2.TabStop = false;
			groupBox2.Text = "方向";
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(24, 58);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(48, 17);
			label5.TabIndex = 1;
			label5.Text = "纵向(&P)";
			label5.Visible = false;
			radioButton1.Appearance = System.Windows.Forms.Appearance.Button;
			radioButton1.BackColor = System.Drawing.SystemColors.Control;
			radioButton1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			radioButton1.Image = (System.Drawing.Image)resourceManager.GetObject("radioButton1.Image");
			radioButton1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
			radioButton1.Location = new System.Drawing.Point(16, 16);
			radioButton1.Name = "radioButton1";
			radioButton1.Size = new System.Drawing.Size(64, 38);
			radioButton1.TabIndex = 2;
			radioButton1.Text = "纵向(&P)";
			radioButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			radioButton2.Appearance = System.Windows.Forms.Appearance.Button;
			radioButton2.BackColor = System.Drawing.SystemColors.Control;
			radioButton2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			radioButton2.Image = (System.Drawing.Image)resourceManager.GetObject("radioButton2.Image");
			radioButton2.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
			radioButton2.Location = new System.Drawing.Point(104, 16);
			radioButton2.Name = "radioButton2";
			radioButton2.Size = new System.Drawing.Size(64, 38);
			radioButton2.TabIndex = 2;
			radioButton2.Text = "横向(&S)";
			radioButton2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(112, 58);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(48, 17);
			label6.TabIndex = 1;
			label6.Text = "横向(&S)";
			label6.Visible = false;
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(17, 21);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(72, 17);
			label7.TabIndex = 0;
			label7.Text = "纸张大小(&R)";
			cboPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboPage.Location = new System.Drawing.Point(19, 40);
			cboPage.MaxDropDownItems = 15;
			cboPage.Name = "cboPage";
			cboPage.Size = new System.Drawing.Size(224, 20);
			cboPage.TabIndex = 1;
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(19, 66);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(54, 17);
			label8.TabIndex = 2;
			label8.Text = "宽度(&W):";
			numericUpDown1.Location = new System.Drawing.Point(104, 64);
			numericUpDown1.Name = "numericUpDown1";
			numericUpDown1.Size = new System.Drawing.Size(136, 21);
			numericUpDown1.TabIndex = 3;
			numericUpDown2.Location = new System.Drawing.Point(104, 92);
			numericUpDown2.Name = "numericUpDown2";
			numericUpDown2.Size = new System.Drawing.Size(136, 21);
			numericUpDown2.TabIndex = 3;
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(19, 94);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(54, 17);
			label9.TabIndex = 2;
			label9.Text = "宽度(&W):";
			groupBox3.Controls.Add(picPreview);
			groupBox3.Location = new System.Drawing.Point(11, 204);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new System.Drawing.Size(400, 140);
			groupBox3.TabIndex = 1;
			groupBox3.TabStop = false;
			groupBox3.Text = "预览";
			picPreview.BackColor = System.Drawing.SystemColors.Window;
			picPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			picPreview.Location = new System.Drawing.Point(144, 16);
			picPreview.Name = "picPreview";
			picPreview.Size = new System.Drawing.Size(128, 112);
			picPreview.TabIndex = 0;
			picPreview.TabStop = false;
			cmdOK.Location = new System.Drawing.Point(232, 360);
			cmdOK.Name = "cmdOK";
			cmdOK.TabIndex = 2;
			cmdOK.Text = "确定(&O)";
			cmdCancel.Location = new System.Drawing.Point(328, 360);
			cmdCancel.Name = "cmdCancel";
			cmdCancel.TabIndex = 3;
			cmdCancel.Text = "取消(&C)";
			AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			base.ClientSize = new System.Drawing.Size(426, 391);
			base.Controls.Add(cmdCancel);
			base.Controls.Add(cmdOK);
			base.Controls.Add(groupBox3);
			base.Controls.Add(myTab);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgPageSetup";
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "页面设置";
			base.Load += new System.EventHandler(dlgPageSetup_Load);
			myTab.ResumeLayout(false);
			tabPage1.ResumeLayout(false);
			tabPage2.ResumeLayout(false);
			groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)txtTopMargin).EndInit();
			((System.ComponentModel.ISupportInitialize)txtBottomMargin).EndInit();
			((System.ComponentModel.ISupportInitialize)txtLeftMargin).EndInit();
			((System.ComponentModel.ISupportInitialize)txtRightMargin).EndInit();
			groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
			groupBox3.ResumeLayout(false);
			ResumeLayout(false);
		}

		private void dlgPageSetup_Load(object sender, EventArgs e)
		{
			PrinterSettings printerSettings = new PrinterSettings();
			cboPage.Items.Clear();
			foreach (PaperSize paperSize in printerSettings.PaperSizes)
			{
				cboPage.Items.Add(paperSize.PaperName);
			}
		}
	}
}
