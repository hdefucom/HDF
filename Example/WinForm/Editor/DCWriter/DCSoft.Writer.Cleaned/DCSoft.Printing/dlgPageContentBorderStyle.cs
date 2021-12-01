using DCSoft.Drawing;
using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Printing
{
	[ComVisible(false)]
	public class dlgPageContentBorderStyle : Form
	{
		private IContainer icontainer_0 = null;

		private Label label1;

		private GClass304 btnBorderColor;

		private NumericUpDown txtBorderWidth;

		private Label label7;

		private Label label2;

		private ComboBox cboBorderStyle;

		private GroupBox groupBox1;

		private TextBox txtTopMargin;

		private TextBox txtLeftMargin;

		private TextBox txtBottomMargin;

		private Label lblLeft;

		private TextBox txtRightMargin;

		private Label lblRight;

		private Label lblBottom;

		private Label lblTop;

		private Button button1;

		private Button button2;

		private GClass304 btnBackColor;

		private Label label3;

		private ContentStyle contentStyle_0 = null;

		/// <summary>
		///       页面内容边框和背景设置信息
		///       </summary>
		public ContentStyle PageContentBorderStyle
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Printing.dlgPageContentBorderStyle));
			label1 = new System.Windows.Forms.Label();
			btnBorderColor = new DCSoftDotfuscate.GClass304();
			txtBorderWidth = new System.Windows.Forms.NumericUpDown();
			label7 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			cboBorderStyle = new System.Windows.Forms.ComboBox();
			groupBox1 = new System.Windows.Forms.GroupBox();
			txtTopMargin = new System.Windows.Forms.TextBox();
			txtLeftMargin = new System.Windows.Forms.TextBox();
			txtBottomMargin = new System.Windows.Forms.TextBox();
			lblLeft = new System.Windows.Forms.Label();
			txtRightMargin = new System.Windows.Forms.TextBox();
			lblRight = new System.Windows.Forms.Label();
			lblBottom = new System.Windows.Forms.Label();
			lblTop = new System.Windows.Forms.Label();
			button1 = new System.Windows.Forms.Button();
			button2 = new System.Windows.Forms.Button();
			btnBackColor = new DCSoftDotfuscate.GClass304();
			label3 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)txtBorderWidth).BeginInit();
			groupBox1.SuspendLayout();
			SuspendLayout();
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			resources.ApplyResources(btnBorderColor, "btnBorderColor");
			btnBorderColor.Name = "btnBorderColor";
			btnBorderColor.UseVisualStyleBackColor = true;
			resources.ApplyResources(txtBorderWidth, "txtBorderWidth");
			txtBorderWidth.Name = "txtBorderWidth";
			resources.ApplyResources(label7, "label7");
			label7.Name = "label7";
			resources.ApplyResources(label2, "label2");
			label2.Name = "label2";
			cboBorderStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboBorderStyle.FormattingEnabled = true;
			resources.ApplyResources(cboBorderStyle, "cboBorderStyle");
			cboBorderStyle.Name = "cboBorderStyle";
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
			resources.ApplyResources(txtLeftMargin, "txtLeftMargin");
			txtLeftMargin.Name = "txtLeftMargin";
			txtLeftMargin.Tag = "Pager LeftMargin";
			resources.ApplyResources(txtBottomMargin, "txtBottomMargin");
			txtBottomMargin.Name = "txtBottomMargin";
			txtBottomMargin.Tag = "Pager BottomMargin";
			resources.ApplyResources(lblLeft, "lblLeft");
			lblLeft.Name = "lblLeft";
			resources.ApplyResources(txtRightMargin, "txtRightMargin");
			txtRightMargin.Name = "txtRightMargin";
			txtRightMargin.Tag = "Pager RightMargin";
			resources.ApplyResources(lblRight, "lblRight");
			lblRight.Name = "lblRight";
			resources.ApplyResources(lblBottom, "lblBottom");
			lblBottom.Name = "lblBottom";
			resources.ApplyResources(lblTop, "lblTop");
			lblTop.Name = "lblTop";
			resources.ApplyResources(button1, "button1");
			button1.Name = "button1";
			button1.UseVisualStyleBackColor = true;
			resources.ApplyResources(button2, "button2");
			button2.Name = "button2";
			button2.UseVisualStyleBackColor = true;
			resources.ApplyResources(btnBackColor, "btnBackColor");
			btnBackColor.Name = "btnBackColor";
			btnBackColor.UseVisualStyleBackColor = true;
			resources.ApplyResources(label3, "label3");
			label3.Name = "label3";
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(btnBackColor);
			base.Controls.Add(label3);
			base.Controls.Add(button2);
			base.Controls.Add(button1);
			base.Controls.Add(groupBox1);
			base.Controls.Add(cboBorderStyle);
			base.Controls.Add(label2);
			base.Controls.Add(btnBorderColor);
			base.Controls.Add(txtBorderWidth);
			base.Controls.Add(label7);
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgPageContentBorderStyle";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgPageContentBorderStyle_Load);
			((System.ComponentModel.ISupportInitialize)txtBorderWidth).EndInit();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		public dlgPageContentBorderStyle()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgPageContentBorderStyle_Load(object sender, EventArgs e)
		{
			GClass11.smethod_0(cboBorderStyle);
			if (contentStyle_0 != null)
			{
				btnBorderColor.method_1(contentStyle_0.BorderColor);
				txtBorderWidth.Value = Convert.ToDecimal(contentStyle_0.BorderWidth);
			}
		}
	}
}
