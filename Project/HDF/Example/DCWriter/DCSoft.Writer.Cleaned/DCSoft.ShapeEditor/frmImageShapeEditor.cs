using DCSoft.Drawing;
using DCSoft.ShapeEditor.Dom;
using DCSoft.WinForms.Controls;
using DCSoft.WinForms.Design;
using DCSoft.WinForms.Native;
using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.ShapeEditor
{
	/// <summary>
	///       图片编辑器，本窗体专为DCSoft.Writer开发，也可用作本程序的测试窗体。 
	///       </summary>
	[ComVisible(false)]
	public class frmImageShapeEditor : Form
	{
		private Color color_0 = Color.Empty;

		private Image image_0 = null;

		private ShapeDocument shapeDocument_0 = null;

		private SizeF sizeF_0 = SizeF.Empty;

		private string string_0 = null;

		private string string_1 = null;

		private DCMenuHelper dcmenuHelper_0 = null;

		private int int_0 = 0;

		private IContainer icontainer_0 = null;

		private ToolStrip toolStrip1;

		private GControl9 myEditorControl;

		private ToolStripButton btnPoint;

		private ToolStripButton btnInsertRectangle;

		private ToolStripButton btnInsertLine;

		private ToolStripSeparator toolStripSeparator1;

		private ToolStripButton btnDelete;

		private ToolStripButton btnCancel;

		private ToolStripButton btnOK;

		private ToolStripSeparator toolStripSeparator2;

		private ToolStripButton btnFont;

		private ToolStripButton btnAlignLeft;

		private ToolStripButton btnAlignCenter;

		private ToolStripButton btnAlignRight;

		private ToolStripButton btnColor;

		private ToolStripButton btnInsertEllipse;

		private ToolStripButton btnBorder;

		private ToolStripButton btnZoomIn;

		private ToolStripButton btnZoomOut;

		private ToolStripSeparator toolStripSeparator3;

		private ToolStripButton btnInsertPolygon;

		private ToolStripDropDownButton btnBackgroundStyle;

		private ToolStripButton btnConfigFillStyle;

		private ToolStripButton btnInsertLines;

		private ToolStripButton btnLineColor;

		private ToolStripButton btnTextBackcolor;

		private SplitContainer mySplitContainer;

		private ListBox lstStdLabel;

		private ToolStripButton btnInsertWireLabel;

		private ToolStripButton btnInsertZoomIn;

		private ToolStripDropDownButton btnLineWidth;

		/// <summary>
		///       当前线条颜色
		///       </summary>
		public Color CurrentLineColor
		{
			get
			{
				return color_0;
			}
			set
			{
				color_0 = value;
			}
		}

		/// <summary>
		///       内容图片
		///       </summary>
		public Image ContentImage
		{
			get
			{
				return image_0;
			}
			set
			{
				image_0 = value;
			}
		}

		public bool ZoomButtonVisible
		{
			get
			{
				return btnZoomIn.Visible;
			}
			set
			{
				btnZoomIn.Visible = value;
				btnZoomOut.Visible = value;
			}
		}

		public GControl9 InnerEditorControl => myEditorControl;

		public ShapeDocument ShapeDocument
		{
			get
			{
				return shapeDocument_0;
			}
			set
			{
				shapeDocument_0 = value;
			}
		}

		/// <summary>
		///       用户指定的图片大小
		///       </summary>
		public SizeF SpecifyImageSize
		{
			get
			{
				return sizeF_0;
			}
			set
			{
				sizeF_0 = value;
			}
		}

		/// <summary>
		///       背景菜单项目配置信息字符串
		///       </summary>
		public string BackgroundMenuItemSettingString
		{
			get
			{
				return string_0;
			}
			set
			{
				string_0 = value;
			}
		}

		/// <summary>
		///       标准的文本标签列表，各个项目之间用逗号分开
		///       </summary>
		public string StandardLabels
		{
			get
			{
				return string_1;
			}
			set
			{
				string_1 = value;
			}
		}

		private DCMenuHelper MenuHelper
		{
			get
			{
				if (dcmenuHelper_0 == null)
				{
					dcmenuHelper_0 = new DCMenuHelper();
					dcmenuHelper_0.ColorPlate.method_12(method_2);
				}
				dcmenuHelper_0.ColorPlate.method_5(bool_3: true);
				return dcmenuHelper_0;
			}
		}

		internal static void smethod_0()
		{
			frmImageShapeEditor frmImageShapeEditor = new frmImageShapeEditor();
			frmImageShapeEditor.ShowInTaskbar = true;
			frmImageShapeEditor.MinimizeBox = true;
			frmImageShapeEditor.ContentImage = Image.FromFile(Path.Combine(Application.StartupPath, "demo.jpg"));
			frmImageShapeEditor.SpecifyImageSize = new SizeF(2000f, 2000f);
			ShapeDocument shapeDocument = new ShapeDocument();
			ShapeDocumentImagePage shapeDocumentImagePage = new ShapeDocumentImagePage();
			shapeDocumentImagePage.Width = 2000f;
			shapeDocumentImagePage.Height = 2000f;
			shapeDocument.TextBackColor = Color.White;
			shapeDocument.Pages.Add(shapeDocumentImagePage);
			shapeDocument.vmethod_20();
			frmImageShapeEditor.ShapeDocument = shapeDocument;
			Application.Run(frmImageShapeEditor);
		}

		public frmImageShapeEditor()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void frmImageShapeEditor_Load(object sender, EventArgs e)
		{
			lstStdLabel.Font = new Font(lstStdLabel.Font.Name, 12f);
			if (string.IsNullOrEmpty(StandardLabels))
			{
				mySplitContainer.Panel2Collapsed = true;
			}
			else
			{
				mySplitContainer.Panel2Collapsed = false;
				lstStdLabel.Items.AddRange(StandardLabels.Split(','));
			}
			string value = BackgroundMenuItemSettingString;
			if (string.IsNullOrEmpty(value))
			{
				value = ResourceStrings.DefaultBackgroundMenuItemSettingString;
			}
			if (!string.IsNullOrEmpty(value))
			{
				GClass441 gClass = new GClass441();
				gClass.method_1(value);
				foreach (GClass442 item in gClass)
				{
					method_4(item.method_2(), item.method_0());
				}
			}
			for (int i = 1; i < 7; i++)
			{
				ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem(i.ToString());
				btnLineWidth.DropDownItems.Add(toolStripMenuItem);
				toolStripMenuItem.Click += method_0;
			}
			if (shapeDocument_0 == null)
			{
				shapeDocument_0 = new ShapeDocument();
			}
			shapeDocument_0.EditorControl = myEditorControl;
			bool flag = false;
			if (shapeDocument_0.Pages.Count == 0 || !(shapeDocument_0.Pages[0] is ShapeDocumentImagePage))
			{
				flag = true;
				shapeDocument_0.Pages.Clear();
				ShapeDocumentImagePage shapeDocumentImagePage = new ShapeDocumentImagePage();
				shapeDocumentImagePage.Width = 2000f;
				shapeDocumentImagePage.Height = 2000f;
				if (!SpecifyImageSize.IsEmpty)
				{
					shapeDocumentImagePage.Width = SpecifyImageSize.Width;
					shapeDocumentImagePage.Height = SpecifyImageSize.Height;
				}
				else if (ContentImage != null)
				{
					SizeF size = ContentImage.Size;
					size = GraphicsUnitConvert.Convert(size, GraphicsUnit.Pixel, shapeDocument_0.DocumentGraphicsUnit);
					shapeDocumentImagePage.Width = size.Width;
					shapeDocumentImagePage.Height = size.Height;
				}
				else
				{
					shapeDocumentImagePage.Width = 2000f;
					shapeDocumentImagePage.Height = 2000f;
				}
				ContentStyle contentStyle = new ContentStyle();
				contentStyle.BorderLeft = true;
				contentStyle.BorderTop = true;
				contentStyle.BorderRight = true;
				contentStyle.BorderBottom = true;
				contentStyle.BorderColor = Color.Black;
				contentStyle.BorderWidth = 1f;
				shapeDocumentImagePage.StyleIndex = shapeDocument_0.ContentStyles.GetStyleIndex(contentStyle);
				shapeDocument_0.vmethod_19(shapeDocumentImagePage);
			}
			ShapeDocumentImagePage shapeDocumentImagePage2 = (ShapeDocumentImagePage)shapeDocument_0.FirstPage;
			shapeDocumentImagePage2.Image = new XImageValue(ContentImage);
			using (DCGraphics dcgraphics_ = shapeDocument_0.vmethod_21())
			{
				shapeDocument_0.vmethod_3(dcgraphics_);
			}
			if (SpecifyImageSize.Width > 0f)
			{
				shapeDocumentImagePage2.Resizeable = false;
				shapeDocumentImagePage2.AutoSize = false;
			}
			if (SpecifyImageSize.Height > 0f)
			{
				shapeDocumentImagePage2.Resizeable = false;
				shapeDocumentImagePage2.AutoSize = false;
				if (flag)
				{
					shapeDocument_0.ContentStyles.Default.FontSize = shapeDocument_0.ContentStyles.Default.FontSize / myEditorControl.method_17();
				}
			}
			myEditorControl.Font = shapeDocument_0.ContentStyles.Default.Font.Value;
			myEditorControl.method_5(shapeDocument_0);
			myEditorControl.method_20();
			if (SpecifyImageSize.IsEmpty)
			{
				btnZoomIn.Enabled = false;
				btnZoomOut.Enabled = false;
			}
			else
			{
				btnZoomIn.Enabled = (SpecifyImageSize.Height > shapeDocumentImagePage2.Height);
				btnZoomOut.Enabled = (SpecifyImageSize.Height < shapeDocumentImagePage2.Height);
				btnZoomOut_Click(null, null);
			}
			if (!CurrentLineColor.IsEmpty)
			{
				ContentStyle contentStyle = new ContentStyle();
				InnerEditorControl.method_34(contentStyle);
				contentStyle.BorderColor = CurrentLineColor;
				contentStyle.BorderLeft = true;
				contentStyle.BorderTop = true;
				contentStyle.BorderRight = true;
				contentStyle.BorderBottom = true;
				contentStyle.BorderStyle = DashStyle.Solid;
				contentStyle.BorderWidth = 1f;
			}
		}

		private void method_0(object sender, EventArgs e)
		{
			foreach (ToolStripMenuItem dropDownItem in btnLineWidth.DropDownItems)
			{
				dropDownItem.Checked = (dropDownItem == sender);
			}
			float num = Convert.ToInt32(((ToolStripMenuItem)sender).Text);
			float borderWidth = GraphicsUnitConvert.Convert(num, GraphicsUnit.Pixel, myEditorControl.method_4().DocumentGraphicsUnit);
			if (num == 1f)
			{
				borderWidth = 1f;
			}
			ContentStyle contentStyle = new ContentStyle();
			contentStyle.DisableDefaultValue = true;
			contentStyle.BorderWidth = borderWidth;
			myEditorControl.method_46().method_0(contentStyle);
		}

		private void method_1(object sender, EventArgs e)
		{
			Type type = typeof(string);
			int num = (int)GraphicsUnitConvert.Convert(myEditorControl.method_7().BorderWidth, myEditorControl.method_2(), GraphicsUnit.Pixel);
			if (myEditorControl.method_7().BorderWidth == 1f)
			{
				num = 1;
			}
			if (num < 0)
			{
				num = 0;
			}
			btnLineWidth.Text = string.Format(ResourceStrings.LineWidth_Width, num);
			foreach (ToolStripMenuItem dropDownItem in btnLineWidth.DropDownItems)
			{
				dropDownItem.Checked = (Convert.ToInt32(dropDownItem.Text) == num);
			}
			if (myEditorControl.method_36().method_0() != null)
			{
				type = myEditorControl.method_36().method_0().method_6();
			}
			btnPoint.Checked = type.Equals(typeof(string));
			btnInsertLine.Checked = type.Equals(typeof(ShapeLineElement));
			btnInsertRectangle.Checked = type.Equals(typeof(ShapeRectangleElement));
			btnInsertEllipse.Checked = type.Equals(typeof(ShapeEllipseElement));
			btnInsertPolygon.Checked = type.Equals(typeof(GClass327));
			btnDelete.Enabled = (myEditorControl.method_6() != null);
			ContentStyle contentStyle = myEditorControl.method_7();
			if (contentStyle != null)
			{
				btnAlignCenter.Checked = (contentStyle.Align == DocumentContentAlignment.Center);
				btnAlignLeft.Checked = (contentStyle.Align == DocumentContentAlignment.Left);
				btnAlignRight.Checked = (contentStyle.Align == DocumentContentAlignment.Right);
				foreach (ToolStripMenuItem dropDownItem2 in btnBackgroundStyle.DropDownItems)
				{
					if (dropDownItem2.Tag is XBrushStyleConst)
					{
						XBrushStyleConst xBrushStyleConst = (XBrushStyleConst)dropDownItem2.Tag;
						dropDownItem2.Checked = (contentStyle.BackgroundStyle == xBrushStyleConst);
					}
				}
				CurrentLineColor = contentStyle.BorderColor;
			}
		}

		private void btnPoint_Click(object sender, EventArgs e)
		{
			myEditorControl.vmethod_2();
		}

		private void btnInsertRectangle_Click(object sender, EventArgs e)
		{
			myEditorControl.vmethod_1(typeof(ShapeRectangleElement));
		}

		private void btnInsertLine_Click(object sender, EventArgs e)
		{
			myEditorControl.vmethod_1(typeof(ShapeLineElement));
		}

		private void btnInsertEllipse_Click(object sender, EventArgs e)
		{
			myEditorControl.vmethod_1(typeof(ShapeEllipseElement));
		}

		private void btnInsertLines_Click(object sender, EventArgs e)
		{
			myEditorControl.vmethod_1(typeof(ShapeLinesElement));
		}

		private void btnInsertPolygon_Click(object sender, EventArgs e)
		{
			myEditorControl.vmethod_1(typeof(ShapePolygonElement));
		}

		private void btnInsertWireLabel_Click(object sender, EventArgs e)
		{
			myEditorControl.vmethod_1(typeof(ShapeWireLabelElement));
		}

		private void btnInsertZoomIn_Click(object sender, EventArgs e)
		{
			myEditorControl.vmethod_1(typeof(ShapeZoomInElement));
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			myEditorControl.method_45();
		}

		private void btnFont_Click(object sender, EventArgs e)
		{
			if (myEditorControl.method_6() != null)
			{
				using (FontDialog fontDialog = new FontDialog())
				{
					fontDialog.Font = myEditorControl.method_6().RuntimeStyle.Font.Value;
					fontDialog.Color = myEditorControl.method_6().RuntimeStyle.Color;
					fontDialog.ShowColor = true;
					if (fontDialog.ShowDialog(this) == DialogResult.OK)
					{
						ContentStyle contentStyle = new ContentStyle();
						contentStyle.DisableDefaultValue = true;
						contentStyle.Font = new XFontValue(fontDialog.Font);
						contentStyle.Color = fontDialog.Color;
						myEditorControl.method_46().method_0(contentStyle);
					}
				}
			}
		}

		private void btnAlignLeft_Click(object sender, EventArgs e)
		{
			if (myEditorControl.method_46().Count > 0)
			{
				ContentStyle contentStyle = new ContentStyle();
				contentStyle.DisableDefaultValue = true;
				contentStyle.Align = DocumentContentAlignment.Left;
				myEditorControl.method_46().method_0(contentStyle);
			}
		}

		private void btnAlignCenter_Click(object sender, EventArgs e)
		{
			if (myEditorControl.method_46().Count > 0)
			{
				ContentStyle contentStyle = new ContentStyle();
				contentStyle.DisableDefaultValue = true;
				contentStyle.Align = DocumentContentAlignment.Center;
				myEditorControl.method_46().method_0(contentStyle);
			}
		}

		private void btnAlignRight_Click(object sender, EventArgs e)
		{
			if (myEditorControl.method_46().Count > 0)
			{
				ContentStyle contentStyle = new ContentStyle();
				contentStyle.DisableDefaultValue = true;
				contentStyle.Align = DocumentContentAlignment.Right;
				myEditorControl.method_46().method_0(contentStyle);
			}
		}

		private void btnLineColor_Click(object sender, EventArgs e)
		{
			if (myEditorControl.method_46().Count > 0)
			{
				MenuHelper.ColorPlate.method_5(bool_3: true);
				MenuHelper.ColorPlate.method_7(Color.Black);
				MenuHelper.ColorPlate.method_3(bool_3: false);
				MenuHelper.ColorPlate.method_11(myEditorControl.method_6().RuntimeStyle.BorderColor);
				int_0 = 0;
				MenuHelper.method_0(btnLineColor.Owner, btnLineColor.Bounds.X, btnLineColor.Bounds.Bottom);
			}
		}

		private void btnColor_Click(object sender, EventArgs e)
		{
			if (myEditorControl.method_46().Count > 0)
			{
				MenuHelper.ColorPlate.method_5(bool_3: true);
				MenuHelper.ColorPlate.method_7(Color.Black);
				MenuHelper.ColorPlate.method_3(bool_3: false);
				MenuHelper.ColorPlate.method_11(myEditorControl.method_6().RuntimeStyle.Color);
				int_0 = 1;
				MenuHelper.method_0(btnColor.Owner, btnColor.Bounds.X, btnColor.Bounds.Bottom);
			}
		}

		private void btnTextBackcolor_Click(object sender, EventArgs e)
		{
			MenuHelper.ColorPlate.method_5(bool_3: true);
			MenuHelper.ColorPlate.method_7(Color.White);
			MenuHelper.ColorPlate.method_3(bool_3: true);
			MenuHelper.ColorPlate.method_11(myEditorControl.method_4().TextBackColor);
			int_0 = 2;
			MenuHelper.method_0(btnTextBackcolor.Owner, btnTextBackcolor.Bounds.X, btnTextBackcolor.Bounds.Bottom);
		}

		private void method_2(object sender, EventArgs e)
		{
			if (int_0 == 2)
			{
				myEditorControl.method_4().TextBackColor = MenuHelper.ColorPlate.method_10();
				myEditorControl.Invalidate();
				return;
			}
			ContentStyle contentStyle = new ContentStyle();
			contentStyle.DisableDefaultValue = true;
			if (int_0 == 0)
			{
				contentStyle.BorderColor = MenuHelper.ColorPlate.method_10();
			}
			else if (int_0 == 1)
			{
				contentStyle.Color = MenuHelper.ColorPlate.method_10();
			}
			myEditorControl.method_46().method_0(contentStyle);
		}

		private void method_3(object sender, EventArgs e)
		{
			if (myEditorControl.method_46().Count > 0)
			{
				using (ColorDialog colorDialog = new ColorDialog())
				{
					colorDialog.Color = myEditorControl.method_6().RuntimeStyle.BackgroundColor;
					if (colorDialog.ShowDialog(this) == DialogResult.OK)
					{
						ContentStyle contentStyle = new ContentStyle();
						contentStyle.DisableDefaultValue = true;
						contentStyle.BackgroundColor = colorDialog.Color;
						myEditorControl.method_46().method_0(contentStyle);
					}
				}
			}
		}

		private void btnBorder_Click(object sender, EventArgs e)
		{
			if (myEditorControl.method_46().Count > 0)
			{
				using (dlgBorderBackground dlgBorderBackground = new dlgBorderBackground())
				{
					dlgBorderBackground.ContentStyle = myEditorControl.method_6().RuntimeStyle.Clone();
					dlgBorderBackground.ContentStyle.DisableDefaultValue = true;
					if (dlgBorderBackground.ShowDialog(this) == DialogResult.OK)
					{
						ContentStyle contentStyle = dlgBorderBackground.ContentStyle;
						myEditorControl.method_46().method_0(contentStyle);
					}
				}
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			StringWriter textWriter_ = new StringWriter();
			ShapeDocumentImagePage shapeDocumentImagePage = (ShapeDocumentImagePage)myEditorControl.method_12();
			XImageValue image = shapeDocumentImagePage.Image;
			shapeDocumentImagePage.Image = new XImageValue();
			myEditorControl.method_4().vmethod_30(textWriter_);
			shapeDocumentImagePage.Image = image;
			base.DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnZoomIn_Click(object sender, EventArgs e)
		{
			ShapeDocumentImagePage shapeDocumentImagePage = (ShapeDocumentImagePage)myEditorControl.method_10();
			if (SpecifyImageSize.Height > 0f && SpecifyImageSize.Height > shapeDocumentImagePage.Height)
			{
				myEditorControl.method_16(SpecifyImageSize.Width / shapeDocumentImagePage.Width);
				myEditorControl.method_18(SpecifyImageSize.Height / shapeDocumentImagePage.Height);
			}
			else
			{
				myEditorControl.method_16(1f);
				myEditorControl.method_18(1f);
			}
			myEditorControl.method_20();
			btnZoomIn.Enabled = false;
			btnZoomOut.Enabled = true;
		}

		private void btnZoomOut_Click(object sender, EventArgs e)
		{
			ShapeDocumentImagePage shapeDocumentImagePage = (ShapeDocumentImagePage)myEditorControl.method_10();
			if (SpecifyImageSize.Height < shapeDocumentImagePage.Height && SpecifyImageSize.Height > 0f)
			{
				myEditorControl.method_16(SpecifyImageSize.Width / shapeDocumentImagePage.Width);
				myEditorControl.method_18(SpecifyImageSize.Height / shapeDocumentImagePage.Height);
			}
			else
			{
				myEditorControl.method_16(1f);
				myEditorControl.method_18(1f);
			}
			myEditorControl.method_20();
			btnZoomOut.Enabled = false;
			btnZoomIn.Enabled = true;
		}

		public void method_4(string string_2, XBrushStyleConst xbrushStyleConst_0)
		{
			ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
			toolStripMenuItem.Text = string_2;
			Bitmap image = new Bitmap(16, 16);
			using (Graphics graphics = Graphics.FromImage(image))
			{
				graphics.Clear(Color.White);
				XBrushStyle xBrushStyle = new XBrushStyle();
				xBrushStyle.Color = Color.White;
				xBrushStyle.Color2 = Color.Black;
				xBrushStyle.Style = xbrushStyleConst_0;
				using (Brush brush = xBrushStyle.method_2(new Rectangle(0, 0, 16, 16)))
				{
					if (brush != null)
					{
						graphics.FillRectangle(brush, new Rectangle(0, 0, 16, 16));
					}
				}
				graphics.DrawRectangle(Pens.Black, 0, 0, 15, 15);
			}
			toolStripMenuItem.Image = image;
			toolStripMenuItem.Tag = xbrushStyleConst_0;
			toolStripMenuItem.Click += method_5;
			btnBackgroundStyle.DropDownItems.Add(toolStripMenuItem);
		}

		private void method_5(object sender, EventArgs e)
		{
			if (myEditorControl.method_46().Count > 0)
			{
				ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
				XBrushStyleConst backgroundStyle = (XBrushStyleConst)toolStripMenuItem.Tag;
				ContentStyle contentStyle = new ContentStyle();
				contentStyle.DisableDefaultValue = true;
				contentStyle.BackgroundStyle = backgroundStyle;
				contentStyle.BackgroundColor = Color.White;
				contentStyle.BackgroundRepeat = true;
				if (myEditorControl.method_46().method_0(contentStyle))
				{
					myEditorControl.method_52(bool_2: true);
				}
			}
		}

		private void btnConfigFillStyle_Click(object sender, EventArgs e)
		{
			GClass441 gClass = new GClass441();
			foreach (ToolStripMenuItem dropDownItem in btnBackgroundStyle.DropDownItems)
			{
				gClass.method_0((XBrushStyleConst)dropDownItem.Tag, dropDownItem.Text);
			}
			using (dlgFillStyleConfigDesigner dlgFillStyleConfigDesigner = new dlgFillStyleConfigDesigner())
			{
				dlgFillStyleConfigDesigner.InputListItems = gClass;
				if (dlgFillStyleConfigDesigner.ShowDialog(this) == DialogResult.OK)
				{
					btnBackgroundStyle.DropDownItems.Clear();
					foreach (GClass442 inputListItem in dlgFillStyleConfigDesigner.InputListItems)
					{
						method_4(inputListItem.method_2(), inputListItem.method_0());
					}
				}
			}
		}

		private void lstStdLabel_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Left)
			{
				return;
			}
			for (int i = 0; i < lstStdLabel.Items.Count; i++)
			{
				if (lstStdLabel.GetItemRectangle(i).Contains(e.X, e.Y) && MouseCapturer.DragDetect(lstStdLabel.Handle))
				{
					DataObject dataObject = new DataObject();
					dataObject.SetText(Convert.ToString(lstStdLabel.Items[i]));
					lstStdLabel.DoDragDrop(dataObject, DragDropEffects.Copy);
				}
			}
		}

		private void myEditorControl_DragEnter(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.Copy;
		}

		private void myEditorControl_DragOver(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.Copy;
		}

		private void myEditorControl_DragDrop(object sender, DragEventArgs e)
		{
			string text = null;
			if (e.Data.GetDataPresent(DataFormats.Text))
			{
				text = Convert.ToString(e.Data.GetData(DataFormats.Text));
			}
			else if (e.Data.GetDataPresent(DataFormats.UnicodeText))
			{
				text = Convert.ToString(e.Data.GetData(DataFormats.UnicodeText));
			}
			if (!string.IsNullOrEmpty(text))
			{
				ShapeRectangleElement shapeRectangleElement = new ShapeRectangleElement();
				shapeRectangleElement.Text = text;
				ContentStyle contentStyle = new ContentStyle();
				contentStyle.FontName = lstStdLabel.Font.Name;
				contentStyle.FontSize = lstStdLabel.Font.Size;
				contentStyle.BorderLeft = false;
				contentStyle.BorderTop = false;
				contentStyle.BorderRight = false;
				contentStyle.BorderBottom = false;
				contentStyle.Align = DocumentContentAlignment.Center;
				contentStyle.VerticalAlign = VerticalAlignStyle.Middle;
				contentStyle.Multiline = true;
				if (myEditorControl.method_33() != null)
				{
					contentStyle.Color = myEditorControl.method_33().Color;
					contentStyle.BorderColor = myEditorControl.method_33().BorderColor;
					contentStyle.BorderStyle = myEditorControl.method_33().BorderStyle;
					contentStyle.BorderWidth = myEditorControl.method_33().BorderWidth;
					contentStyle.BorderLeft = true;
					contentStyle.BorderTop = true;
					contentStyle.BorderRight = true;
					contentStyle.BorderBottom = true;
				}
				shapeRectangleElement.StyleIndex = myEditorControl.method_4().ContentStyles.GetStyleIndex(contentStyle);
				using (DCGraphics dCGraphics = myEditorControl.method_4().vmethod_21())
				{
					using (DrawStringFormatExt format = contentStyle.method_12())
					{
						shapeRectangleElement.Width = dCGraphics.MeasureString(text, contentStyle.Font, 1000, format).Width + 100f;
						shapeRectangleElement.Height = dCGraphics.GetFontHeight(contentStyle.Font) + 50f;
					}
				}
				Point point_ = myEditorControl.PointToClient(new Point(e.X, e.Y));
				PointF pointF = myEditorControl.method_23(point_);
				shapeRectangleElement.Left = pointF.X - shapeRectangleElement.Width / 2f;
				shapeRectangleElement.Top = pointF.Y - shapeRectangleElement.Height / 2f;
				myEditorControl.vmethod_5(shapeRectangleElement);
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.ShapeEditor.frmImageShapeEditor));
			toolStrip1 = new System.Windows.Forms.ToolStrip();
			btnPoint = new System.Windows.Forms.ToolStripButton();
			btnInsertRectangle = new System.Windows.Forms.ToolStripButton();
			btnInsertLine = new System.Windows.Forms.ToolStripButton();
			btnInsertLines = new System.Windows.Forms.ToolStripButton();
			btnInsertEllipse = new System.Windows.Forms.ToolStripButton();
			btnInsertPolygon = new System.Windows.Forms.ToolStripButton();
			btnInsertWireLabel = new System.Windows.Forms.ToolStripButton();
			btnInsertZoomIn = new System.Windows.Forms.ToolStripButton();
			toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			btnDelete = new System.Windows.Forms.ToolStripButton();
			btnCancel = new System.Windows.Forms.ToolStripButton();
			btnOK = new System.Windows.Forms.ToolStripButton();
			toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			btnAlignLeft = new System.Windows.Forms.ToolStripButton();
			btnAlignCenter = new System.Windows.Forms.ToolStripButton();
			btnAlignRight = new System.Windows.Forms.ToolStripButton();
			btnFont = new System.Windows.Forms.ToolStripButton();
			btnTextBackcolor = new System.Windows.Forms.ToolStripButton();
			btnColor = new System.Windows.Forms.ToolStripButton();
			btnLineColor = new System.Windows.Forms.ToolStripButton();
			btnLineWidth = new System.Windows.Forms.ToolStripDropDownButton();
			btnBackgroundStyle = new System.Windows.Forms.ToolStripDropDownButton();
			btnBorder = new System.Windows.Forms.ToolStripButton();
			toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			btnZoomIn = new System.Windows.Forms.ToolStripButton();
			btnZoomOut = new System.Windows.Forms.ToolStripButton();
			btnConfigFillStyle = new System.Windows.Forms.ToolStripButton();
			myEditorControl = new DCSoftDotfuscate.GControl9();
			mySplitContainer = new System.Windows.Forms.SplitContainer();
			lstStdLabel = new System.Windows.Forms.ListBox();
			toolStrip1.SuspendLayout();
			mySplitContainer.Panel1.SuspendLayout();
			mySplitContainer.Panel2.SuspendLayout();
			mySplitContainer.SuspendLayout();
			SuspendLayout();
			toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[27]
			{
				btnPoint,
				btnInsertRectangle,
				btnInsertLine,
				btnInsertLines,
				btnInsertEllipse,
				btnInsertPolygon,
				btnInsertWireLabel,
				btnInsertZoomIn,
				toolStripSeparator1,
				btnDelete,
				btnCancel,
				btnOK,
				toolStripSeparator2,
				btnAlignLeft,
				btnAlignCenter,
				btnAlignRight,
				btnFont,
				btnTextBackcolor,
				btnColor,
				btnLineColor,
				btnLineWidth,
				btnBackgroundStyle,
				btnBorder,
				toolStripSeparator3,
				btnZoomIn,
				btnZoomOut,
				btnConfigFillStyle
			});
			resources.ApplyResources(toolStrip1, "toolStrip1");
			toolStrip1.Name = "toolStrip1";
			btnPoint.CheckOnClick = true;
			btnPoint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			resources.ApplyResources(btnPoint, "btnPoint");
			btnPoint.Name = "btnPoint";
			btnPoint.Click += new System.EventHandler(btnPoint_Click);
			btnInsertRectangle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			resources.ApplyResources(btnInsertRectangle, "btnInsertRectangle");
			btnInsertRectangle.Name = "btnInsertRectangle";
			btnInsertRectangle.Click += new System.EventHandler(btnInsertRectangle_Click);
			btnInsertLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			resources.ApplyResources(btnInsertLine, "btnInsertLine");
			btnInsertLine.Name = "btnInsertLine";
			btnInsertLine.Click += new System.EventHandler(btnInsertLine_Click);
			btnInsertLines.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			resources.ApplyResources(btnInsertLines, "btnInsertLines");
			btnInsertLines.Name = "btnInsertLines";
			btnInsertLines.Click += new System.EventHandler(btnInsertLines_Click);
			btnInsertEllipse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			resources.ApplyResources(btnInsertEllipse, "btnInsertEllipse");
			btnInsertEllipse.Name = "btnInsertEllipse";
			btnInsertEllipse.Click += new System.EventHandler(btnInsertEllipse_Click);
			btnInsertPolygon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			resources.ApplyResources(btnInsertPolygon, "btnInsertPolygon");
			btnInsertPolygon.Name = "btnInsertPolygon";
			btnInsertPolygon.Click += new System.EventHandler(btnInsertPolygon_Click);
			btnInsertWireLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			resources.ApplyResources(btnInsertWireLabel, "btnInsertWireLabel");
			btnInsertWireLabel.Name = "btnInsertWireLabel";
			btnInsertWireLabel.Click += new System.EventHandler(btnInsertWireLabel_Click);
			btnInsertZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			resources.ApplyResources(btnInsertZoomIn, "btnInsertZoomIn");
			btnInsertZoomIn.Name = "btnInsertZoomIn";
			btnInsertZoomIn.Click += new System.EventHandler(btnInsertZoomIn_Click);
			toolStripSeparator1.Name = "toolStripSeparator1";
			resources.ApplyResources(toolStripSeparator1, "toolStripSeparator1");
			btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			resources.ApplyResources(btnDelete, "btnDelete");
			btnDelete.Name = "btnDelete";
			btnDelete.Click += new System.EventHandler(btnDelete_Click);
			btnCancel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			btnCancel.AutoToolTip = false;
			btnCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			btnOK.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			btnOK.AutoToolTip = false;
			btnOK.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.Name = "btnOK";
			btnOK.Click += new System.EventHandler(btnOK_Click);
			toolStripSeparator2.Name = "toolStripSeparator2";
			resources.ApplyResources(toolStripSeparator2, "toolStripSeparator2");
			btnAlignLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			resources.ApplyResources(btnAlignLeft, "btnAlignLeft");
			btnAlignLeft.Name = "btnAlignLeft";
			btnAlignLeft.Click += new System.EventHandler(btnAlignLeft_Click);
			btnAlignCenter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			resources.ApplyResources(btnAlignCenter, "btnAlignCenter");
			btnAlignCenter.Name = "btnAlignCenter";
			btnAlignCenter.Click += new System.EventHandler(btnAlignCenter_Click);
			btnAlignRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			resources.ApplyResources(btnAlignRight, "btnAlignRight");
			btnAlignRight.Name = "btnAlignRight";
			btnAlignRight.Click += new System.EventHandler(btnAlignRight_Click);
			btnFont.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			resources.ApplyResources(btnFont, "btnFont");
			btnFont.Name = "btnFont";
			btnFont.Click += new System.EventHandler(btnFont_Click);
			btnTextBackcolor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			resources.ApplyResources(btnTextBackcolor, "btnTextBackcolor");
			btnTextBackcolor.Name = "btnTextBackcolor";
			btnTextBackcolor.Click += new System.EventHandler(btnTextBackcolor_Click);
			btnColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			resources.ApplyResources(btnColor, "btnColor");
			btnColor.Name = "btnColor";
			btnColor.Click += new System.EventHandler(btnColor_Click);
			btnLineColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			resources.ApplyResources(btnLineColor, "btnLineColor");
			btnLineColor.Name = "btnLineColor";
			btnLineColor.Click += new System.EventHandler(btnLineColor_Click);
			btnLineWidth.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			resources.ApplyResources(btnLineWidth, "btnLineWidth");
			btnLineWidth.Name = "btnLineWidth";
			btnBackgroundStyle.AutoToolTip = false;
			resources.ApplyResources(btnBackgroundStyle, "btnBackgroundStyle");
			btnBackgroundStyle.Name = "btnBackgroundStyle";
			btnBorder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			resources.ApplyResources(btnBorder, "btnBorder");
			btnBorder.Name = "btnBorder";
			btnBorder.Click += new System.EventHandler(btnBorder_Click);
			toolStripSeparator3.Name = "toolStripSeparator3";
			resources.ApplyResources(toolStripSeparator3, "toolStripSeparator3");
			btnZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			resources.ApplyResources(btnZoomIn, "btnZoomIn");
			btnZoomIn.Name = "btnZoomIn";
			btnZoomIn.Click += new System.EventHandler(btnZoomIn_Click);
			btnZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			resources.ApplyResources(btnZoomOut, "btnZoomOut");
			btnZoomOut.Name = "btnZoomOut";
			btnZoomOut.Click += new System.EventHandler(btnZoomOut_Click);
			btnConfigFillStyle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			resources.ApplyResources(btnConfigFillStyle, "btnConfigFillStyle");
			btnConfigFillStyle.Name = "btnConfigFillStyle";
			btnConfigFillStyle.Click += new System.EventHandler(btnConfigFillStyle_Click);
			myEditorControl.AllowDrop = true;
			resources.ApplyResources(myEditorControl, "myEditorControl");
			myEditorControl.BackColor = System.Drawing.SystemColors.ControlDark;
			myEditorControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			myEditorControl.Name = "myEditorControl";
			myEditorControl.method_47(new System.EventHandler(method_1));
			myEditorControl.DragDrop += new System.Windows.Forms.DragEventHandler(myEditorControl_DragDrop);
			myEditorControl.DragEnter += new System.Windows.Forms.DragEventHandler(myEditorControl_DragEnter);
			myEditorControl.DragOver += new System.Windows.Forms.DragEventHandler(myEditorControl_DragOver);
			resources.ApplyResources(mySplitContainer, "mySplitContainer");
			mySplitContainer.Name = "mySplitContainer";
			mySplitContainer.Panel1.Controls.Add(myEditorControl);
			mySplitContainer.Panel2.Controls.Add(lstStdLabel);
			resources.ApplyResources(lstStdLabel, "lstStdLabel");
			lstStdLabel.FormattingEnabled = true;
			lstStdLabel.Name = "lstStdLabel";
			lstStdLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(lstStdLabel_MouseDown);
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(mySplitContainer);
			base.Controls.Add(toolStrip1);
			base.MinimizeBox = false;
			base.Name = "frmImageShapeEditor";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(frmImageShapeEditor_Load);
			toolStrip1.ResumeLayout(false);
			toolStrip1.PerformLayout();
			mySplitContainer.Panel1.ResumeLayout(false);
			mySplitContainer.Panel2.ResumeLayout(false);
			mySplitContainer.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
