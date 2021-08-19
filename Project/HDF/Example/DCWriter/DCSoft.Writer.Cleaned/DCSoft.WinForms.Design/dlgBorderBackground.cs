using DCSoft.Drawing;
using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.WinForms.Design
{
	/// <summary>
	///       边框背景样式编辑器
	///       </summary>
	/// <remarks>编写 袁永福</remarks>
	[ComVisible(false)]
	public class dlgBorderBackground : Form
	{
		private ContentStyle contentStyle_0 = null;

		private bool bool_0 = false;

		private Bitmap bitmap_0 = null;

		private bool bool_1 = false;

		private IContainer icontainer_0 = null;

		private GroupBox groupBox1;

		private Label label2;

		private GControl8 lstBorderStyle;

		private GClass304 btnBorderColor;

		private Label label3;

		private CheckBox chkTopBorder;

		private PictureBox picBorderPreview;

		private CheckBox chkRightBorder;

		private ImageList imageList_0;

		private CheckBox chkLeftBorder;

		private CheckBox chkBottomBorder;

		private GroupBox groupBox2;

		private GClass304 btnBackgroundColor;

		private Label label6;

		private Button btnOK;

		private Button btnCancel;

		private NumericUpDown txtBorderWidth;

		private Label label7;

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

		public dlgBorderBackground()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
			btnBackgroundColor.method_5(bool_2: true);
			btnBackgroundColor.method_7(Color.Transparent);
			btnBorderColor.method_5(bool_2: true);
			btnBorderColor.method_7(Color.Black);
		}

		private void dlgBorderBackground_Load(object sender, EventArgs e)
		{
			if (contentStyle_0 == null)
			{
				contentStyle_0 = new ContentStyle();
			}
			bitmap_0 = (Bitmap)picBorderPreview.Image;
			picBorderPreview.Image = null;
			bitmap_0.MakeTransparent(Color.White);
			bool_1 = true;
			switch (contentStyle_0.BorderStyle)
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
			chkBottomBorder.Checked = contentStyle_0.BorderBottom;
			chkLeftBorder.Checked = contentStyle_0.BorderLeft;
			chkRightBorder.Checked = contentStyle_0.BorderRight;
			chkTopBorder.Checked = contentStyle_0.BorderTop;
			btnBorderColor.method_1(contentStyle_0.BorderLeftColor);
			btnBackgroundColor.method_1(contentStyle_0.BackgroundColor);
			txtBorderWidth.Value = (decimal)contentStyle_0.BorderWidth;
			bool_1 = false;
			ValueModified = false;
		}

		private void chkTopBorder_CheckedChanged(object sender, EventArgs e)
		{
			if (!bool_1)
			{
				bool_1 = true;
				ValueModified = true;
				picBorderPreview.Invalidate();
				bool_1 = false;
			}
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
				using (Pen pen = new Pen(btnBorderColor.method_0(), (float)txtBorderWidth.Value))
				{
					if (chkBottomBorder.Checked)
					{
						e.Graphics.DrawLine(pen, 14, 85, 106, 85);
					}
					if (chkLeftBorder.Checked)
					{
						e.Graphics.DrawLine(pen, 14, 13, 14, 85);
					}
					if (chkRightBorder.Checked)
					{
						e.Graphics.DrawLine(pen, 106, 13, 106, 85);
					}
					if (chkTopBorder.Checked)
					{
						e.Graphics.DrawLine(pen, 14, 13, 106, 13);
					}
				}
			}
		}

		private void method_0(object sender, EventArgs e)
		{
			ValueModified = true;
			picBorderPreview.Invalidate();
		}

		private void method_1(object sender, EventArgs e)
		{
			ValueModified = true;
			picBorderPreview.Invalidate();
		}

		private void txtBorderWidth_ValueChanged(object sender, EventArgs e)
		{
			ValueModified = true;
			picBorderPreview.Invalidate();
		}

		private void method_2(object sender, EventArgs e)
		{
			ValueModified = true;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (ValueModified)
			{
				base.DialogResult = DialogResult.OK;
				contentStyle_0.DisableDefaultValue = true;
				switch (lstBorderStyle.method_13())
				{
				default:
					contentStyle_0.BorderStyle = DashStyle.Solid;
					break;
				case 0:
					contentStyle_0.BorderStyle = DashStyle.Dash;
					break;
				case 1:
					contentStyle_0.BorderStyle = DashStyle.DashDot;
					break;
				case 2:
					contentStyle_0.BorderStyle = DashStyle.DashDotDot;
					break;
				case 3:
					contentStyle_0.BorderStyle = DashStyle.Dot;
					break;
				case 4:
					contentStyle_0.BorderStyle = DashStyle.Solid;
					break;
				}
				contentStyle_0.BorderTop = chkTopBorder.Checked;
				contentStyle_0.BorderBottom = chkBottomBorder.Checked;
				contentStyle_0.BorderLeft = chkLeftBorder.Checked;
				contentStyle_0.BorderRight = chkRightBorder.Checked;
				contentStyle_0.BorderLeftColor = btnBorderColor.method_0();
				contentStyle_0.BorderTopColor = btnBorderColor.method_0();
				contentStyle_0.BorderRightColor = btnBorderColor.method_0();
				contentStyle_0.BorderBottomColor = btnBorderColor.method_0();
				contentStyle_0.BorderWidth = (int)txtBorderWidth.Value;
				contentStyle_0.BackgroundColor = btnBackgroundColor.method_0();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.WinForms.Design.dlgBorderBackground));
			DCSoftDotfuscate.GClass309 gClass = new DCSoftDotfuscate.GClass309();
			DCSoftDotfuscate.GClass309 gClass2 = new DCSoftDotfuscate.GClass309();
			DCSoftDotfuscate.GClass309 gClass3 = new DCSoftDotfuscate.GClass309();
			DCSoftDotfuscate.GClass309 gClass4 = new DCSoftDotfuscate.GClass309();
			DCSoftDotfuscate.GClass309 gClass5 = new DCSoftDotfuscate.GClass309();
			groupBox1 = new System.Windows.Forms.GroupBox();
			btnBackgroundColor = new DCSoftDotfuscate.GClass304();
			label6 = new System.Windows.Forms.Label();
			txtBorderWidth = new System.Windows.Forms.NumericUpDown();
			btnBorderColor = new DCSoftDotfuscate.GClass304();
			label7 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			lstBorderStyle = new DCSoftDotfuscate.GControl8();
			chkRightBorder = new System.Windows.Forms.CheckBox();
			imageList_0 = new System.Windows.Forms.ImageList(icontainer_0);
			chkLeftBorder = new System.Windows.Forms.CheckBox();
			chkBottomBorder = new System.Windows.Forms.CheckBox();
			chkTopBorder = new System.Windows.Forms.CheckBox();
			picBorderPreview = new System.Windows.Forms.PictureBox();
			groupBox2 = new System.Windows.Forms.GroupBox();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)txtBorderWidth).BeginInit();
			((System.ComponentModel.ISupportInitialize)picBorderPreview).BeginInit();
			groupBox2.SuspendLayout();
			SuspendLayout();
			groupBox1.Controls.Add(btnBackgroundColor);
			groupBox1.Controls.Add(label6);
			groupBox1.Controls.Add(txtBorderWidth);
			groupBox1.Controls.Add(btnBorderColor);
			groupBox1.Controls.Add(label7);
			groupBox1.Controls.Add(label3);
			groupBox1.Controls.Add(label2);
			groupBox1.Controls.Add(lstBorderStyle);
			resources.ApplyResources(groupBox1, "groupBox1");
			groupBox1.Name = "groupBox1";
			groupBox1.TabStop = false;
			resources.ApplyResources(btnBackgroundColor, "btnBackgroundColor");
			btnBackgroundColor.Name = "btnBackgroundColor";
			btnBackgroundColor.UseVisualStyleBackColor = true;
			btnBackgroundColor.method_9(new System.EventHandler(method_1));
			resources.ApplyResources(label6, "label6");
			label6.Name = "label6";
			resources.ApplyResources(txtBorderWidth, "txtBorderWidth");
			txtBorderWidth.Name = "txtBorderWidth";
			txtBorderWidth.ValueChanged += new System.EventHandler(txtBorderWidth_ValueChanged);
			resources.ApplyResources(btnBorderColor, "btnBorderColor");
			btnBorderColor.Name = "btnBorderColor";
			btnBorderColor.UseVisualStyleBackColor = true;
			btnBorderColor.method_9(new System.EventHandler(method_0));
			resources.ApplyResources(label7, "label7");
			label7.Name = "label7";
			resources.ApplyResources(label3, "label3");
			label3.Name = "label3";
			resources.ApplyResources(label2, "label2");
			label2.Name = "label2";
			resources.ApplyResources(lstBorderStyle, "lstBorderStyle");
			lstBorderStyle.BackColor = System.Drawing.SystemColors.Window;
			lstBorderStyle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			gClass.method_1((System.Drawing.Image)resources.GetObject("imageListBoxItem6.Image"));
			gClass.method_3(0);
			resources.ApplyResources(gClass, "imageListBoxItem6");
			gClass2.method_1((System.Drawing.Image)resources.GetObject("imageListBoxItem7.Image"));
			gClass2.method_3(0);
			resources.ApplyResources(gClass2, "imageListBoxItem7");
			gClass3.method_1((System.Drawing.Image)resources.GetObject("imageListBoxItem8.Image"));
			gClass3.method_3(0);
			resources.ApplyResources(gClass3, "imageListBoxItem8");
			gClass4.method_1((System.Drawing.Image)resources.GetObject("imageListBoxItem9.Image"));
			gClass4.method_3(0);
			resources.ApplyResources(gClass4, "imageListBoxItem9");
			gClass5.method_1((System.Drawing.Image)resources.GetObject("imageListBoxItem10.Image"));
			gClass5.method_3(0);
			resources.ApplyResources(gClass5, "imageListBoxItem10");
			lstBorderStyle.method_5().Add(gClass);
			lstBorderStyle.method_5().Add(gClass2);
			lstBorderStyle.method_5().Add(gClass3);
			lstBorderStyle.method_5().Add(gClass4);
			lstBorderStyle.method_5().Add(gClass5);
			lstBorderStyle.Name = "lstBorderStyle";
			lstBorderStyle.method_11(new System.EventHandler(method_3));
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
			groupBox2.Controls.Add(picBorderPreview);
			groupBox2.Controls.Add(chkTopBorder);
			groupBox2.Controls.Add(chkRightBorder);
			groupBox2.Controls.Add(chkBottomBorder);
			groupBox2.Controls.Add(chkLeftBorder);
			resources.ApplyResources(groupBox2, "groupBox2");
			groupBox2.Name = "groupBox2";
			groupBox2.TabStop = false;
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
			base.CancelButton = btnCancel;
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(groupBox2);
			base.Controls.Add(groupBox1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgBorderBackground";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgBorderBackground_Load);
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)txtBorderWidth).EndInit();
			((System.ComponentModel.ISupportInitialize)picBorderPreview).EndInit();
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			ResumeLayout(false);
		}
	}
}
