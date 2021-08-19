using DCSoft.Drawing;
using DCSoft.Writer.Dom;
using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.MedicalExpression
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

		private string[] string_0 = new string[14]
		{
			"通用公式",
			"月经史公式1",
			"月经史公式2",
			"月经史公式3",
			"月经史公式4",
			"瞳孔图",
			"光定位图",
			"胎心图",
			"恒牙牙位图",
			"乳牙牙位图",
			"标尺",
			"PD牙位图",
			"病变下牙牙位图",
			"病变上牙牙位图"
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.MedicalExpression.dlgMedicalExpressionEditor));
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
			foreach (object value in Enum.GetValues(typeof(DCMedicalExpressionStyle)))
			{
				listBoxDrawing.Items.Add(value);
			}
			listBoxDrawing.DrawMode = DrawMode.OwnerDrawFixed;
			listBoxDrawing.ItemHeight = listBoxDrawing.ClientSize.Height / listBoxDrawing.Items.Count;
			if (SourceEventArgs != null)
			{
				XTextNewMedicalExpressionElement xTextNewMedicalExpressionElement = (XTextNewMedicalExpressionElement)SourceEventArgs.Element;
				txtName.Text = xTextNewMedicalExpressionElement.Name;
				cboVAngle.SelectedIndex = (int)xTextNewMedicalExpressionElement.VAlign;
			}
			XTextNewMedicalExpressionElement xTextNewMedicalExpressionElement2 = (XTextNewMedicalExpressionElement)elementPropertiesEditEventArgs_0.Element;
			listBoxDrawing.SelectedItem = xTextNewMedicalExpressionElement2.ExpressionStyle;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			int num = 2;
			if (SourceEventArgs == null)
			{
				return;
			}
			bool flag = SourceEventArgs.LogUndo && SourceEventArgs.Document.CanLogUndo;
			XTextNewMedicalExpressionElement xTextNewMedicalExpressionElement = (XTextNewMedicalExpressionElement)SourceEventArgs.Element;
			XTextDocument document = SourceEventArgs.Document;
			bool flag2 = false;
			string text = txtName.Text;
			if (xTextNewMedicalExpressionElement.Name != text)
			{
				if (flag)
				{
					document.UndoList.AddProperty("Name", xTextNewMedicalExpressionElement.Name, text, xTextNewMedicalExpressionElement);
				}
				xTextNewMedicalExpressionElement.Name = text;
				flag2 = true;
			}
			VerticalAlignStyle selectedIndex = (VerticalAlignStyle)cboVAngle.SelectedIndex;
			if (selectedIndex != xTextNewMedicalExpressionElement.VAlign)
			{
				if (flag)
				{
					document.UndoList.AddProperty("VAlign", xTextNewMedicalExpressionElement.VAlign, selectedIndex, xTextNewMedicalExpressionElement);
				}
				xTextNewMedicalExpressionElement.VAlign = selectedIndex;
				flag2 = true;
				SourceEventArgs.SetContentEffect(ContentEffects.Layout);
			}
			DCMedicalExpressionStyle dCMedicalExpressionStyle = (DCMedicalExpressionStyle)listBoxDrawing.SelectedItem;
			if (xTextNewMedicalExpressionElement.ExpressionStyle != dCMedicalExpressionStyle)
			{
				if (flag && document.CanLogUndo)
				{
					document.UndoList.AddProperty("ExpressionStyle", xTextNewMedicalExpressionElement.ExpressionStyle, dCMedicalExpressionStyle, xTextNewMedicalExpressionElement);
				}
				xTextNewMedicalExpressionElement.ExpressionStyle = dCMedicalExpressionStyle;
				flag2 = true;
			}
			if (SourceEventArgs.Method == ElementPropertiesEditMethod.Edit)
			{
				if (flag2)
				{
					xTextNewMedicalExpressionElement.SizeInvalid = true;
					XTextContentElement contentElement = xTextNewMedicalExpressionElement.ContentElement;
					xTextNewMedicalExpressionElement.method_16(bool_9: true);
					contentElement.method_31(contentElement.PrivateContent.IndexOf(xTextNewMedicalExpressionElement));
					base.DialogResult = DialogResult.OK;
				}
			}
			else if (xTextNewMedicalExpressionElement.ExpressionStyle == DCMedicalExpressionStyle.PermanentTeethBitmap)
			{
				using (dlgPermanentTeethBitmap dlgPermanentTeethBitmap = new dlgPermanentTeethBitmap())
				{
					dlgPermanentTeethBitmap.InputValues = xTextNewMedicalExpressionElement.Values;
					if (dlgPermanentTeethBitmap.ShowDialog(this) == DialogResult.OK)
					{
						xTextNewMedicalExpressionElement.Values = dlgPermanentTeethBitmap.InputValues;
						xTextNewMedicalExpressionElement.method_18(dlgPermanentTeethBitmap.InputValues.Clone(), bool_9: true);
						base.DialogResult = DialogResult.OK;
					}
					else
					{
						base.DialogResult = DialogResult.Cancel;
					}
				}
			}
			else if (xTextNewMedicalExpressionElement.ExpressionStyle == DCMedicalExpressionStyle.DeciduousTeech)
			{
				using (dlgDeciduousTeech dlgDeciduousTeech = new dlgDeciduousTeech())
				{
					dlgDeciduousTeech.InputValues = xTextNewMedicalExpressionElement.Values;
					if (dlgDeciduousTeech.ShowDialog(this) == DialogResult.OK)
					{
						xTextNewMedicalExpressionElement.method_18(dlgDeciduousTeech.InputValues.Clone(), bool_9: true);
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
			int num = 4;
			DCMedicalExpressionStyle dCMedicalExpressionStyle = (DCMedicalExpressionStyle)listBoxDrawing.Items[e.Index];
			e.DrawBackground();
			GClass20 gClass = new GClass20();
			switch (dCMedicalExpressionStyle)
			{
			case DCMedicalExpressionStyle.PermanentTeethBitmap:
				gClass.method_9(dCMedicalExpressionStyle);
				gClass.method_0().Value1 = "8";
				gClass.method_0().Value2 = "7";
				gClass.method_0().Value3 = "6";
				gClass.method_0().Value4 = "5";
				gClass.method_0().Value5 = "4";
				gClass.method_0().Value6 = "3";
				gClass.method_0().Value7 = "2";
				gClass.method_0().Value8 = "1";
				gClass.method_0().Value9 = "1";
				gClass.method_0().Value10 = "2";
				gClass.method_0().Value11 = "3";
				gClass.method_0().Value12 = "4";
				gClass.method_0().Value13 = "5";
				gClass.method_0().Value14 = "6";
				gClass.method_0().Value15 = "7";
				gClass.method_0().Value16 = "8";
				gClass.method_0().Value17 = "8";
				gClass.method_0().Value18 = "7";
				gClass.method_0().Value19 = "6";
				gClass.method_0().Value20 = "5";
				gClass.method_0().Value21 = "4";
				gClass.method_0().Value22 = "3";
				gClass.method_0().Value23 = "2";
				gClass.method_0().Value24 = "1";
				gClass.method_0().Value25 = "1";
				gClass.method_0().Value26 = "2";
				gClass.method_0().Value27 = "3";
				gClass.method_0().Value28 = "4";
				gClass.method_0().Value29 = "5";
				gClass.method_0().Value30 = "6";
				gClass.method_0().Value31 = "7";
				gClass.method_0().Value32 = "8";
				break;
			case DCMedicalExpressionStyle.DeciduousTeech:
				gClass.method_9(dCMedicalExpressionStyle);
				gClass.method_0().Value1 = "Ⅴ";
				gClass.method_0().Value2 = "Ⅳ";
				gClass.method_0().Value3 = "Ⅲ";
				gClass.method_0().Value4 = "Ⅱ";
				gClass.method_0().Value5 = "Ⅰ";
				gClass.method_0().Value6 = "Ⅰ";
				gClass.method_0().Value7 = "Ⅱ";
				gClass.method_0().Value8 = "Ⅲ";
				gClass.method_0().Value9 = "Ⅳ";
				gClass.method_0().Value10 = "Ⅴ";
				gClass.method_0().Value11 = "Ⅴ";
				gClass.method_0().Value12 = "Ⅳ";
				gClass.method_0().Value13 = "Ⅲ";
				gClass.method_0().Value14 = "Ⅱ";
				gClass.method_0().Value15 = "Ⅰ";
				gClass.method_0().Value16 = "Ⅰ";
				gClass.method_0().Value17 = "Ⅱ";
				gClass.method_0().Value18 = "Ⅲ";
				gClass.method_0().Value19 = "Ⅳ";
				gClass.method_0().Value20 = "Ⅴ";
				break;
			case DCMedicalExpressionStyle.PainIndex:
				gClass.method_9(dCMedicalExpressionStyle);
				gClass.method_0().Value1 = "0";
				break;
			default:
				gClass.method_9(dCMedicalExpressionStyle);
				gClass.method_0().Value1 = "Value1";
				gClass.method_0().Value2 = "Value2";
				gClass.method_0().Value3 = "Value3";
				gClass.method_0().Value4 = "Value4";
				gClass.method_0().Value5 = "Value5";
				gClass.method_0().Value6 = "Value6";
				gClass.method_0().Value7 = "Value7";
				gClass.method_0().Value8 = "Value8";
				gClass.method_0().Value9 = "Value9";
				break;
			}
			Brush brush = SystemBrushes.ControlText;
			Pen pen = SystemPens.ControlText;
			if ((e.State & DrawItemState.Focus) == DrawItemState.Focus || (e.State & DrawItemState.Selected) == DrawItemState.Selected)
			{
				pen = SystemPens.HighlightText;
				brush = SystemBrushes.HighlightText;
				gClass.method_7(SystemColors.HighlightText);
			}
			Rectangle bounds = e.Bounds;
			RectangleF rectangleF_ = new RectangleF(bounds.Left + 3, bounds.Top + 3, listBoxDrawing.Width * 2 / 3, bounds.Height - 6);
			gClass.method_11(new DCGraphics(e.Graphics), rectangleF_);
			e.Graphics.DrawRectangle(pen, rectangleF_.Left, rectangleF_.Top, rectangleF_.Width, rectangleF_.Height);
			XFontValue xFontValue = new XFontValue();
			e.Graphics.DrawString(string_0[e.Index], xFontValue.Value, brush, rectangleF_.Width + 5f, rectangleF_.Top + 3f);
		}
	}
}
