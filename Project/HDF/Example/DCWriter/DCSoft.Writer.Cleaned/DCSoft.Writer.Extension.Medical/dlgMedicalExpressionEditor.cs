using DCSoft.Drawing;
using DCSoft.Writer.Dom;
using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Extension.Medical
{
	/// <summary>
	///       医学表达式设置对话框
	///       </summary>
	[ComVisible(false)]
	public class dlgMedicalExpressionEditor : Form
	{
		private IContainer icontainer_0 = null;

		private Label label1;

		private TextBox txtName;

		private Label label6;

		private Button btnOK;

		private Button btnCancel;

		private ListBox listBoxDrawing;

		private Panel panel1;

		private ComboBox cboVAngle;

		private Label label2;

		private string[] string_0 = new string[10]
		{
			"月经史公式1",
			"月经史公式2",
			"月经史公式3",
			"月经史公式4",
			"瞳孔图",
			"光定位图",
			"胎心图",
			"恒牙牙位图",
			"乳牙牙位图",
			"标尺"
		};

		private ElementPropertiesEditEventArgs elementPropertiesEditEventArgs_0 = null;

		private DocumentContentStyle documentContentStyle_0 = null;

		/// <summary>
		///       事件参数
		///       </summary>
		public ElementPropertiesEditEventArgs SourceEventArgs
		{
			get
			{
				return elementPropertiesEditEventArgs_0;
			}
			set
			{
				elementPropertiesEditEventArgs_0 = value;
			}
		}

		/// <summary>
		///       当前文档内容样式
		///       </summary>
		public DocumentContentStyle CurrentContentStyle
		{
			get
			{
				return documentContentStyle_0;
			}
			set
			{
				documentContentStyle_0 = value;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Extension.Medical.dlgMedicalExpressionEditor));
			label1 = new System.Windows.Forms.Label();
			txtName = new System.Windows.Forms.TextBox();
			label6 = new System.Windows.Forms.Label();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			listBoxDrawing = new System.Windows.Forms.ListBox();
			panel1 = new System.Windows.Forms.Panel();
			cboVAngle = new System.Windows.Forms.ComboBox();
			label2 = new System.Windows.Forms.Label();
			panel1.SuspendLayout();
			SuspendLayout();
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			resources.ApplyResources(txtName, "txtName");
			txtName.Name = "txtName";
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
			listBoxDrawing.Cursor = System.Windows.Forms.Cursors.Default;
			resources.ApplyResources(listBoxDrawing, "listBoxDrawing");
			listBoxDrawing.FormattingEnabled = true;
			listBoxDrawing.Name = "listBoxDrawing";
			listBoxDrawing.DrawItem += new System.Windows.Forms.DrawItemEventHandler(listBoxDrawing_DrawItem);
			panel1.Controls.Add(listBoxDrawing);
			resources.ApplyResources(panel1, "panel1");
			panel1.Name = "panel1";
			cboVAngle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboVAngle.FormattingEnabled = true;
			cboVAngle.Items.AddRange(new object[3]
			{
				resources.GetString("cboVAngle.Items"),
				resources.GetString("cboVAngle.Items1"),
				resources.GetString("cboVAngle.Items2")
			});
			resources.ApplyResources(cboVAngle, "cboVAngle");
			cboVAngle.Name = "cboVAngle";
			resources.ApplyResources(label2, "label2");
			label2.Name = "label2";
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(cboVAngle);
			base.Controls.Add(label2);
			base.Controls.Add(panel1);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(label6);
			base.Controls.Add(txtName);
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgMedicalExpressionEditor";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgMedicalExpressionEditor_Load);
			panel1.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgMedicalExpressionEditor()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
			listBoxDrawing.IntegralHeight = false;
		}

		private void dlgMedicalExpressionEditor_Load(object sender, EventArgs e)
		{
			foreach (object value in Enum.GetValues(typeof(MedicalExpressionStyle)))
			{
				listBoxDrawing.Items.Add(value);
			}
			listBoxDrawing.DrawMode = DrawMode.OwnerDrawFixed;
			listBoxDrawing.ItemHeight = listBoxDrawing.ClientSize.Height / listBoxDrawing.Items.Count;
			if (SourceEventArgs != null)
			{
				XTextMedicalExpressionFieldElement xTextMedicalExpressionFieldElement = (XTextMedicalExpressionFieldElement)SourceEventArgs.Element;
				txtName.Text = xTextMedicalExpressionFieldElement.Name;
				cboVAngle.SelectedIndex = (int)xTextMedicalExpressionFieldElement.VAlign;
			}
			XTextMedicalExpressionFieldElement xTextMedicalExpressionFieldElement2 = (XTextMedicalExpressionFieldElement)elementPropertiesEditEventArgs_0.Element;
			listBoxDrawing.SelectedItem = xTextMedicalExpressionFieldElement2.ExpressionStyle;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			int num = 8;
			if (SourceEventArgs == null)
			{
				return;
			}
			bool flag = SourceEventArgs.LogUndo && SourceEventArgs.Document.CanLogUndo;
			XTextMedicalExpressionFieldElement xTextMedicalExpressionFieldElement = (XTextMedicalExpressionFieldElement)SourceEventArgs.Element;
			XTextDocument document = SourceEventArgs.Document;
			bool flag2 = false;
			string text = txtName.Text;
			if (xTextMedicalExpressionFieldElement.Name != text)
			{
				if (flag)
				{
					document.UndoList.AddProperty("Name", xTextMedicalExpressionFieldElement.Name, text, xTextMedicalExpressionFieldElement);
				}
				xTextMedicalExpressionFieldElement.Name = text;
				flag2 = true;
			}
			VerticalAlignStyle selectedIndex = (VerticalAlignStyle)cboVAngle.SelectedIndex;
			if (selectedIndex != xTextMedicalExpressionFieldElement.VAlign)
			{
				if (flag)
				{
					document.UndoList.AddProperty("VAlign", xTextMedicalExpressionFieldElement.VAlign, selectedIndex, xTextMedicalExpressionFieldElement);
				}
				xTextMedicalExpressionFieldElement.VAlign = selectedIndex;
				flag2 = true;
				SourceEventArgs.SetContentEffect(ContentEffects.Layout);
			}
			MedicalExpressionStyle medicalExpressionStyle = (MedicalExpressionStyle)listBoxDrawing.SelectedItem;
			if (xTextMedicalExpressionFieldElement.ExpressionStyle != medicalExpressionStyle)
			{
				if (flag && document.CanLogUndo)
				{
					document.UndoList.AddProperty("ExpressionStyle", xTextMedicalExpressionFieldElement.ExpressionStyle, medicalExpressionStyle, xTextMedicalExpressionFieldElement);
				}
				xTextMedicalExpressionFieldElement.ExpressionStyle = medicalExpressionStyle;
				flag2 = true;
			}
			if (SourceEventArgs.Method == ElementPropertiesEditMethod.Edit)
			{
				if (flag2)
				{
					if (!xTextMedicalExpressionFieldElement.EditMode)
					{
						xTextMedicalExpressionFieldElement.SizeInvalid = true;
						XTextContentElement contentElement = xTextMedicalExpressionFieldElement.ContentElement;
						xTextMedicalExpressionFieldElement.CheckShapeState(updateSize: true);
						contentElement.method_31(contentElement.PrivateContent.IndexOf(xTextMedicalExpressionFieldElement));
					}
					base.DialogResult = DialogResult.OK;
				}
			}
			else if (xTextMedicalExpressionFieldElement.ExpressionStyle == MedicalExpressionStyle.PermanentTeethBitmap)
			{
				using (dlgPermanentTeethBitmap dlgPermanentTeethBitmap = new dlgPermanentTeethBitmap())
				{
					if (!string.IsNullOrEmpty(xTextMedicalExpressionFieldElement.Text))
					{
						xTextMedicalExpressionFieldElement.SetInnerTextFast("");
					}
					string text2 = xTextMedicalExpressionFieldElement.Text;
					if (dlgPermanentTeethBitmap.ShowDialog(this) == DialogResult.OK)
					{
						string text3 = string.Concat(dlgPermanentTeethBitmap.RightTopValue1, ",", dlgPermanentTeethBitmap.RightTopValue2, ",", dlgPermanentTeethBitmap.RightTopValue3, ",", dlgPermanentTeethBitmap.RightTopValue4, ",", dlgPermanentTeethBitmap.RightTopValue5, ",", dlgPermanentTeethBitmap.RightTopValue6, ",", dlgPermanentTeethBitmap.RightTopValue7, ",", dlgPermanentTeethBitmap.RightTopValue8, ",", dlgPermanentTeethBitmap.LeftTopValue1, ",", dlgPermanentTeethBitmap.LeftTopValue2, ",", dlgPermanentTeethBitmap.LeftTopValue3, ",", dlgPermanentTeethBitmap.LeftTopValue4, ",", dlgPermanentTeethBitmap.LeftTopValue5, ",", dlgPermanentTeethBitmap.LeftTopValue6, ",", dlgPermanentTeethBitmap.LeftTopValue7, ",", dlgPermanentTeethBitmap.LeftTopValue8, ",", dlgPermanentTeethBitmap.RightBottomValue1, ",", dlgPermanentTeethBitmap.RightBottomValue2, ",", dlgPermanentTeethBitmap.RightBottomValue3, ",", dlgPermanentTeethBitmap.RightBottomValue4, ",", dlgPermanentTeethBitmap.RightBottomValue5, ",", dlgPermanentTeethBitmap.RightBottomValue6, ",", dlgPermanentTeethBitmap.RightBottomValue7, ",", dlgPermanentTeethBitmap.RightBottomValue8, ",", dlgPermanentTeethBitmap.LeftBottomValue1, ",", dlgPermanentTeethBitmap.LeftBottomValue2, ",", dlgPermanentTeethBitmap.LeftBottomValue3, ",", dlgPermanentTeethBitmap.LeftBottomValue4, ",", dlgPermanentTeethBitmap.LeftBottomValue5, ",", dlgPermanentTeethBitmap.LeftBottomValue6, ",", dlgPermanentTeethBitmap.LeftBottomValue7, ",", dlgPermanentTeethBitmap.LeftBottomValue8);
						if (text3 != text2)
						{
							xTextMedicalExpressionFieldElement.SetEditorTextExt(text3, DomAccessFlags.Normal, disablePermissioin: false, updateContent: true);
						}
						base.DialogResult = DialogResult.OK;
					}
					else
					{
						base.DialogResult = DialogResult.Cancel;
					}
				}
			}
			else if (xTextMedicalExpressionFieldElement.ExpressionStyle == MedicalExpressionStyle.DeciduousTeech)
			{
				using (dlgDeciduousTeech dlgDeciduousTeech = new dlgDeciduousTeech())
				{
					if (!string.IsNullOrEmpty(xTextMedicalExpressionFieldElement.Text))
					{
						xTextMedicalExpressionFieldElement.SetInnerTextFast("");
					}
					string text2 = xTextMedicalExpressionFieldElement.Text;
					if (dlgDeciduousTeech.ShowDialog(this) == DialogResult.OK)
					{
						string text3 = string.Concat(dlgDeciduousTeech.RightTopValue1, ",", dlgDeciduousTeech.RightTopValue2, ",", dlgDeciduousTeech.RightTopValue3, ",", dlgDeciduousTeech.RightTopValue4, ",", dlgDeciduousTeech.RightTopValue5, ",", dlgDeciduousTeech.LeftTopValue1, ",", dlgDeciduousTeech.LeftTopValue2, ",", dlgDeciduousTeech.LeftTopValue3, ",", dlgDeciduousTeech.LeftTopValue4, ",", dlgDeciduousTeech.LeftTopValue5, ",", dlgDeciduousTeech.RightBottomValue1, ",", dlgDeciduousTeech.RightBottomValue2, ",", dlgDeciduousTeech.RightBottomValue3, ",", dlgDeciduousTeech.RightBottomValue4, ",", dlgDeciduousTeech.RightBottomValue5, ",", dlgDeciduousTeech.LeftBottomValue1, ",", dlgDeciduousTeech.LeftBottomValue2, ",", dlgDeciduousTeech.LeftBottomValue3, ",", dlgDeciduousTeech.LeftBottomValue4, ",", dlgDeciduousTeech.LeftBottomValue5);
						if (text3 != text2)
						{
							xTextMedicalExpressionFieldElement.SetEditorTextExt(text3, DomAccessFlags.Normal, disablePermissioin: false, updateContent: true);
						}
						base.DialogResult = DialogResult.OK;
					}
					else
					{
						base.DialogResult = DialogResult.Cancel;
					}
				}
			}
			else
			{
				base.DialogResult = DialogResult.OK;
			}
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void listBoxDrawing_DrawItem(object sender, DrawItemEventArgs e)
		{
			int num = 12;
			MedicalExpressionStyle medicalExpressionStyle = (MedicalExpressionStyle)listBoxDrawing.Items[e.Index];
			e.DrawBackground();
			GClass24 gClass = new GClass24();
			switch (medicalExpressionStyle)
			{
			case MedicalExpressionStyle.PermanentTeethBitmap:
				gClass.method_72(medicalExpressionStyle);
				gClass.method_8("8");
				gClass.method_10("7");
				gClass.method_12("6");
				gClass.method_14("5");
				gClass.method_16("4");
				gClass.method_18("3");
				gClass.method_20("2");
				gClass.method_22("1");
				gClass.method_24("1");
				gClass.method_26("2");
				gClass.method_28("3");
				gClass.method_30("4");
				gClass.method_32("5");
				gClass.method_34("6");
				gClass.method_36("7");
				gClass.method_38("8");
				gClass.method_40("8");
				gClass.method_42("7");
				gClass.method_44("6");
				gClass.method_46("5");
				gClass.method_48("4");
				gClass.method_50("3");
				gClass.method_52("2");
				gClass.method_54("1");
				gClass.method_56("1");
				gClass.method_58("2");
				gClass.method_60("3");
				gClass.method_62("4");
				gClass.method_64("5");
				gClass.method_66("6");
				gClass.method_68("7");
				gClass.method_70("8");
				break;
			case MedicalExpressionStyle.DeciduousTeech:
				gClass.method_72(medicalExpressionStyle);
				gClass.method_8("V");
				gClass.method_10("IV");
				gClass.method_12("III");
				gClass.method_14("II");
				gClass.method_16("I");
				gClass.method_18("I");
				gClass.method_20("II");
				gClass.method_22("III");
				gClass.method_24("IV");
				gClass.method_26("V");
				gClass.method_28("V");
				gClass.method_30("IV");
				gClass.method_32("III");
				gClass.method_34("II");
				gClass.method_36("I");
				gClass.method_38("I");
				gClass.method_40("II");
				gClass.method_42("III");
				gClass.method_44("IV");
				gClass.method_46("V");
				break;
			case MedicalExpressionStyle.PainIndex:
				gClass.method_72(medicalExpressionStyle);
				gClass.method_8("0");
				break;
			default:
				gClass.method_72(medicalExpressionStyle);
				gClass.method_8("Value1");
				gClass.method_10("Value2");
				gClass.method_12("Value3");
				gClass.method_14("Value4");
				gClass.method_16("Value5");
				gClass.method_18("Value6");
				gClass.method_20("Value7");
				gClass.method_22("Value8");
				gClass.method_24("Value9");
				break;
			}
			Brush brush = SystemBrushes.ControlText;
			Pen pen = SystemPens.ControlText;
			if ((e.State & DrawItemState.Focus) == DrawItemState.Focus || (e.State & DrawItemState.Selected) == DrawItemState.Selected)
			{
				pen = SystemPens.HighlightText;
				brush = SystemBrushes.HighlightText;
				gClass.method_5(SystemColors.HighlightText);
			}
			Rectangle bounds = e.Bounds;
			RectangleF rectangleF_ = new RectangleF(bounds.Left + 3, bounds.Top + 3, listBoxDrawing.Width * 2 / 3, bounds.Height - 6);
			gClass.method_74(new DCGraphics(e.Graphics), rectangleF_);
			e.Graphics.DrawRectangle(pen, rectangleF_.Left, rectangleF_.Top, rectangleF_.Width, rectangleF_.Height);
			XFontValue xFontValue = new XFontValue();
			e.Graphics.DrawString(string_0[e.Index], xFontValue.Value, brush, rectangleF_.Width + 5f, rectangleF_.Top + 3f);
		}
	}
}
