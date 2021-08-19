using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.Printing;
using DCSoft.Writer.Commands;
using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Dom.Design;
using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Extension
{
	/// <summary>
	///       单元格属性
	///       </summary>
	[ComVisible(false)]
	public class dlgTableCellProperties : Form
	{
		private ElementPropertiesEditEventArgs elementPropertiesEditEventArgs_0 = null;

		private DocumentContentStyle documentContentStyle_0 = null;

		private static string string_0 = "DCWriter是南京都昌信息科技有限公司自主研发的专业的电子病历文档编辑器。";

		private IContainer icontainer_0 = null;

		private Button btnCancel;

		private Button btnOK;

		private Button btnBrowseAttribute;

		private TextBox txtAttributes;

		private Label label2;

		private TextBox txtID;

		private Label label1;

		private Label label3;

		private TextBox txtTitle;

		private TabControl tabControl1;

		private TabPage tabPage1;

		private GroupBox groupBox1;

		private RadioButton rdVAlignTop;

		private RadioButton rdVAlignCenter;

		private RadioButton rdVAlignBottom;

		private GroupBox groupBox2;

		private NumericUpDown nudBottom;

		private Label label7;

		private NumericUpDown nudLeft;

		private Label label6;

		private NumericUpDown nudRight;

		private Label label5;

		private NumericUpDown nudTop;

		private Label label4;

		private TabPage tabPage3;

		private ListBox lstSlantSplitStyle;

		private ComboBox cboEventTemplateName;

		private Label label8;

		private Label label9;

		private TextBox txtExpression;

		private ComboBox cboContentReadonly;

		private Label label14;

		private ComboBox cboEnablePermission;

		private Label label15;

		private ComboBox cboMoveFocusHotKey;

		private Label label18;

		private Button btnBrowseAcceptElementType;

		private Label label16;

		private TextBox txtAcceptElementType;

		private CheckBox chkStreesBorder;

		private Button btnValueValidateSettings;

		private CheckBox chkEnableValueValidate;

		private Label label10;

		private ComboBox cboAutoFixFontSizeMode;

		private ComboBox cboCloneType;

		private Label label17;

		private CheckBox chkMirrorViewForCrossPage;

		private Button btnValueBinding;

		private Label label19;

		private TabPage tabPage4;

		private GroupBox groupBox3;

		private Button btnGridLine;

		private TextBox txtGridLine;

		private Button btnBrowseMemberExpressions;

		private Label label32;

		private TextBox txtMemberExpressions;

		/// <summary>
		///       编辑元素事件参数
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
		///       预览表格单元格网格线时使用的预览文字
		///       </summary>
		[Obsolete("★★★★本属性已退役，请使用文档配置选项Document.Options.EditOptions.GridLinePreviewText")]
		public static string GridLinePreviewText
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
		///       初始化对象
		///       </summary>
		public dlgTableCellProperties()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgTableCellProperties_Load(object sender, EventArgs e)
		{
			foreach (object value in Enum.GetValues(typeof(MoveFocusHotKeys)))
			{
				cboMoveFocusHotKey.Items.Add(value);
			}
			foreach (object value2 in Enum.GetValues(typeof(RectangleSlantSplitStyle)))
			{
				lstSlantSplitStyle.Items.Add(value2);
			}
			txtAcceptElementType.Tag = ElementType.All;
			if (SourceEventArgs != null)
			{
				string_0 = SourceEventArgs.Document.Options.EditOptions.GridLinePreviewText;
				SourceEventArgs.ContentEffect = ContentEffects.None;
				XTextDocument document = SourceEventArgs.Document;
				XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)SourceEventArgs.Element;
				txtAcceptElementType.Tag = xTextTableCellElement.AcceptChildElementTypes2;
				lstSlantSplitStyle.SelectedItem = xTextTableCellElement.SlantSplitLineStyle;
				txtID.Text = xTextTableCellElement.ID;
				txtExpression.Text = xTextTableCellElement.ValueExpression;
				cboMoveFocusHotKey.SelectedItem = xTextTableCellElement.MoveFocusHotKey;
				chkStreesBorder.Checked = xTextTableCellElement.StressBorder;
				cboAutoFixFontSizeMode.SelectedIndex = (int)xTextTableCellElement.AutoFixFontSizeMode;
				chkEnableValueValidate.Checked = xTextTableCellElement.EnableValueValidate;
				btnValueValidateSettings.Tag = xTextTableCellElement.ValidateStyle;
				chkEnableValueValidate_CheckedChanged(null, null);
				cboCloneType.SelectedIndex = (int)xTextTableCellElement.CloneType;
				chkMirrorViewForCrossPage.Checked = xTextTableCellElement.MirrorViewForCrossPage;
				if (xTextTableCellElement.ValueBinding != null)
				{
					btnValueBinding.Text = xTextTableCellElement.ValueBinding.ToString();
					btnValueBinding.Tag = xTextTableCellElement.ValueBinding.Clone();
				}
				if (SourceEventArgs.Elements.Count > 1)
				{
					txtID.Enabled = false;
					btnBrowseAttribute.Enabled = false;
					txtAttributes.Enabled = false;
				}
				else if (xTextTableCellElement.Attributes != null)
				{
					txtAttributes.Text = xTextTableCellElement.Attributes.ToString();
					txtAttributes.Tag = xTextTableCellElement.Attributes;
				}
				txtTitle.Text = xTextTableCellElement.ToolTip;
				cboEventTemplateName.Text = xTextTableCellElement.EventTemplateName;
				DocumentContentStyle documentContentStyle = xTextTableCellElement.RuntimeStyle.CloneParent();
				rdVAlignBottom.Checked = (documentContentStyle.VerticalAlign == VerticalAlignStyle.Bottom);
				rdVAlignCenter.Checked = (documentContentStyle.VerticalAlign == VerticalAlignStyle.Middle);
				rdVAlignTop.Checked = (documentContentStyle.VerticalAlign == VerticalAlignStyle.Top);
				nudBottom.Value = WriterUtils.smethod_36(document, documentContentStyle.PaddingBottom);
				nudTop.Value = WriterUtils.smethod_36(document, documentContentStyle.PaddingTop);
				nudRight.Value = WriterUtils.smethod_36(document, documentContentStyle.PaddingRight);
				nudLeft.Value = WriterUtils.smethod_36(document, documentContentStyle.PaddingLeft);
				cboContentReadonly.SelectedIndex = (int)xTextTableCellElement.ContentReadonly;
				cboEnablePermission.SelectedIndex = (int)xTextTableCellElement.EnablePermission;
				if (xTextTableCellElement.PropertyExpressions != null)
				{
					txtMemberExpressions.Tag = xTextTableCellElement.PropertyExpressions;
					txtMemberExpressions.Text = xTextTableCellElement.PropertyExpressions.ToString();
				}
				documentContentStyle_0 = documentContentStyle;
				documentContentStyle_0.DisableDefaultValue = true;
				if (xTextTableCellElement.GridLine != null)
				{
					txtGridLine.Tag = xTextTableCellElement.GridLine;
					txtGridLine.Text = xTextTableCellElement.GridLine.ToString();
				}
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			int num = 17;
			if (SourceEventArgs != null)
			{
				XTextDocument document = SourceEventArgs.Document;
				bool flag = SourceEventArgs.LogUndo && document.CanLogUndo;
				bool flag2 = false;
				foreach (XTextTableCellElement element in SourceEventArgs.Elements)
				{
					string text = null;
					if (txtID.Enabled)
					{
						text = txtID.Text.Trim();
						if (!WriterUtils.smethod_43(element.ID, text))
						{
							if (flag)
							{
								document.UndoList.AddProperty("ID", element.ID, text, element);
							}
							element.ID = text;
							flag2 = true;
							SourceEventArgs.SetContentEffect(ContentEffects.Content);
						}
					}
					text = txtTitle.Text.Trim();
					if (!WriterUtils.smethod_43(element.ToolTip, text))
					{
						if (flag)
						{
							document.UndoList.AddProperty("ToolTip", element.ToolTip, text, element);
						}
						element.ToolTip = text;
						flag2 = true;
						SourceEventArgs.SetContentEffect(ContentEffects.Content);
					}
					PropertyExpressionInfoList propertyExpressionInfoList = (PropertyExpressionInfoList)txtMemberExpressions.Tag;
					if (propertyExpressionInfoList != element.PropertyExpressions)
					{
						if (flag)
						{
							document.UndoList.AddProperty("PropertyExpressions", element.PropertyExpressions, propertyExpressionInfoList, element);
						}
						element.PropertyExpressions = propertyExpressionInfoList;
						flag2 = true;
						SourceEventArgs.SetContentEffect(ContentEffects.Content);
					}
					text = txtExpression.Text.Trim();
					if (!WriterUtils.smethod_43(element.ValueExpression, text))
					{
						if (flag)
						{
							document.UndoList.AddProperty("ValueExpression", element.ValueExpression, text, element);
						}
						element.ValueExpression = text;
						flag2 = true;
						SourceEventArgs.SetContentEffect(ContentEffects.Display);
						SourceEventArgs.UpdateExpressionResult = true;
					}
					text = cboEventTemplateName.Text.Trim();
					if (!WriterUtils.smethod_43(element.EventTemplateName, text))
					{
						if (flag)
						{
							document.UndoList.AddProperty("EventTemplateName", element.EventTemplateName, text, element);
						}
						element.EventTemplateName = text;
						flag2 = true;
						SourceEventArgs.SetContentEffect(ContentEffects.Content);
					}
					ElementType elementType = (ElementType)txtAcceptElementType.Tag;
					if (elementType != element.AcceptChildElementTypes2)
					{
						if (flag)
						{
							document.UndoList.AddProperty("AcceptChildElementTypes2", element.AcceptChildElementTypes2, elementType, element);
						}
						element.AcceptChildElementTypes2 = elementType;
						flag2 = true;
						SourceEventArgs.SetContentEffect(ContentEffects.Content);
					}
					if (txtAttributes.Enabled)
					{
						XAttributeList xAttributeList = (XAttributeList)txtAttributes.Tag;
						if (xAttributeList != element.Attributes)
						{
							if (flag)
							{
								document.UndoList.AddProperty("Attribute", element.Attributes, xAttributeList, element);
							}
							element.Attributes = xAttributeList;
							flag2 = true;
							SourceEventArgs.SetContentEffect(ContentEffects.Content);
						}
					}
					MoveFocusHotKeys moveFocusHotKeys = (MoveFocusHotKeys)cboMoveFocusHotKey.SelectedItem;
					if (moveFocusHotKeys != element.MoveFocusHotKey)
					{
						if (flag)
						{
							document.UndoList.AddProperty("MoveFocusHotKey", element.MoveFocusHotKey, moveFocusHotKeys, element);
						}
						element.MoveFocusHotKey = moveFocusHotKeys;
						flag2 = true;
						SourceEventArgs.SetContentEffect(ContentEffects.Content);
					}
					RectangleSlantSplitStyle rectangleSlantSplitStyle = (RectangleSlantSplitStyle)lstSlantSplitStyle.SelectedItem;
					if (rectangleSlantSplitStyle != element.SlantSplitLineStyle)
					{
						if (flag)
						{
							document.UndoList.AddProperty("SlantSplitLineStyle", element.SlantSplitLineStyle, rectangleSlantSplitStyle, element);
						}
						element.SlantSplitLineStyle = rectangleSlantSplitStyle;
						flag2 = true;
						SourceEventArgs.SetContentEffect(ContentEffects.Display);
					}
					if (chkStreesBorder.Checked != element.StressBorder)
					{
						if (flag)
						{
							document.UndoList.AddProperty("StressBorder", element.StressBorder, chkStreesBorder.Checked, element);
						}
						element.StressBorder = chkStreesBorder.Checked;
						flag2 = true;
						SourceEventArgs.SetContentEffect(ContentEffects.Display);
					}
					ContentAutoFixFontSizeMode selectedIndex = (ContentAutoFixFontSizeMode)cboAutoFixFontSizeMode.SelectedIndex;
					if (selectedIndex != element.AutoFixFontSizeMode)
					{
						if (flag)
						{
							document.UndoList.AddProperty("AutoFixFontSizeMode", element.AutoFixFontSizeMode, selectedIndex, element);
						}
						element.AutoFixFontSizeMode = selectedIndex;
						flag2 = true;
						SourceEventArgs.SetContentEffect(ContentEffects.Layout);
					}
					DocumentContentStyle documentContentStyle = element.RuntimeStyle.CloneParent();
					documentContentStyle.DisableDefaultValue = true;
					bool flag3 = false;
					float num2 = WriterUtils.smethod_37(SourceEventArgs.Document, nudLeft.Value);
					if (num2 != documentContentStyle.PaddingLeft)
					{
						documentContentStyle.PaddingLeft = num2;
						flag3 = true;
						SourceEventArgs.SetContentEffect(ContentEffects.Layout);
					}
					num2 = WriterUtils.smethod_37(SourceEventArgs.Document, nudTop.Value);
					if (num2 != documentContentStyle.PaddingTop)
					{
						documentContentStyle.PaddingTop = num2;
						flag3 = true;
						SourceEventArgs.SetContentEffect(ContentEffects.Layout);
					}
					num2 = WriterUtils.smethod_37(SourceEventArgs.Document, nudRight.Value);
					if (num2 != documentContentStyle.PaddingRight)
					{
						documentContentStyle.PaddingRight = num2;
						flag3 = true;
						SourceEventArgs.SetContentEffect(ContentEffects.Layout);
					}
					num2 = WriterUtils.smethod_37(SourceEventArgs.Document, nudBottom.Value);
					if (num2 != documentContentStyle.PaddingBottom)
					{
						documentContentStyle.PaddingBottom = num2;
						flag3 = true;
						SourceEventArgs.SetContentEffect(ContentEffects.Layout);
					}
					if (rdVAlignTop.Checked && documentContentStyle.VerticalAlign != 0)
					{
						documentContentStyle.VerticalAlign = VerticalAlignStyle.Top;
						flag3 = true;
						SourceEventArgs.SetContentEffect(ContentEffects.Layout);
					}
					if (rdVAlignCenter.Checked && documentContentStyle.VerticalAlign != VerticalAlignStyle.Middle)
					{
						documentContentStyle.VerticalAlign = VerticalAlignStyle.Middle;
						flag3 = true;
						SourceEventArgs.SetContentEffect(ContentEffects.Layout);
					}
					if (rdVAlignBottom.Checked && documentContentStyle.VerticalAlign != VerticalAlignStyle.Bottom)
					{
						documentContentStyle.VerticalAlign = VerticalAlignStyle.Bottom;
						flag3 = true;
						SourceEventArgs.SetContentEffect(ContentEffects.Layout);
					}
					if (chkEnableValueValidate.Checked != element.EnableValueValidate)
					{
						if (flag)
						{
							document.UndoList.AddProperty("EnableValueValidate", element.EnableValueValidate, chkEnableValueValidate.Checked, element);
						}
						element.EnableValueValidate = chkEnableValueValidate.Checked;
						SourceEventArgs.SetContentEffect(ContentEffects.Content);
					}
					if (element.EnableValueValidate)
					{
						ValueValidateStyle valueValidateStyle = (ValueValidateStyle)btnValueValidateSettings.Tag;
						if (valueValidateStyle != element.ValidateStyle)
						{
							if (flag)
							{
								document.UndoList.AddProperty("ValidateStyle", element.ValidateStyle, valueValidateStyle, element);
							}
							element.ValidateStyle = valueValidateStyle;
							SourceEventArgs.SetContentEffect(ContentEffects.Content);
						}
					}
					DCGridLineInfo dCGridLineInfo = (DCGridLineInfo)txtGridLine.Tag;
					if (dCGridLineInfo != null)
					{
						dCGridLineInfo = dCGridLineInfo.method_5();
					}
					if (dCGridLineInfo != element.GridLine)
					{
						if (flag)
						{
							document.UndoList.AddProperty("GridLine", element.GridLine, dCGridLineInfo, element);
						}
						element.GridLine = dCGridLineInfo;
						flag2 = true;
						documentContentStyle.GridLineColor = Color.Black;
						documentContentStyle.GridLineOffsetY = 0f;
						documentContentStyle.GridLineStyle = DashStyle.Solid;
						documentContentStyle.GridLineType = ContentGridLineType.None;
						flag3 = true;
						SourceEventArgs.SetContentEffect(ContentEffects.Layout);
					}
					ContentReadonlyState selectedIndex2 = (ContentReadonlyState)cboContentReadonly.SelectedIndex;
					if (selectedIndex2 != element.ContentReadonly && flag)
					{
						document.UndoList.AddProperty("ContentReadonly", element.ContentReadonly, selectedIndex2, element);
						element.ContentReadonly = selectedIndex2;
						flag2 = true;
						SourceEventArgs.SetContentEffect(ContentEffects.Content);
					}
					if (chkMirrorViewForCrossPage.Checked != element.MirrorViewForCrossPage && flag)
					{
						document.UndoList.AddProperty("MirrorViewForCrossPage", element.MirrorViewForCrossPage, chkMirrorViewForCrossPage.Checked, element);
						element.MirrorViewForCrossPage = chkMirrorViewForCrossPage.Checked;
						flag2 = true;
						SourceEventArgs.SetContentEffect(ContentEffects.Display);
					}
					TableRowCloneType selectedIndex3 = (TableRowCloneType)cboCloneType.SelectedIndex;
					if (selectedIndex3 != element.CloneType && flag)
					{
						document.UndoList.AddProperty("CloneType", element.CloneType, selectedIndex3, element);
						element.CloneType = selectedIndex3;
						flag2 = true;
						SourceEventArgs.SetContentEffect(ContentEffects.Content);
					}
					XDataBinding xDataBinding = (XDataBinding)btnValueBinding.Tag;
					if (xDataBinding != element.ValueBinding)
					{
						if (flag)
						{
							document.UndoList.AddProperty("ValueBinding", element.ValueBinding, xDataBinding, element);
						}
						element.ValueBinding = xDataBinding;
						flag2 = true;
						SourceEventArgs.SetContentEffect(ContentEffects.Content);
					}
					DCBooleanValue selectedIndex4 = (DCBooleanValue)cboEnablePermission.SelectedIndex;
					if (selectedIndex4 != element.EnablePermission)
					{
						if (flag)
						{
							document.UndoList.AddProperty("EnablePermission", element.EnablePermission, selectedIndex4, element);
						}
						element.EnablePermission = selectedIndex4;
						flag2 = true;
						SourceEventArgs.SetContentEffect(ContentEffects.Content);
					}
					if (flag3)
					{
						int styleIndex = document.ContentStyles.GetStyleIndex(documentContentStyle);
						if (element.StyleIndex != styleIndex)
						{
							if (flag)
							{
								document.UndoList.AddStyleIndex(element, element.StyleIndex, styleIndex);
							}
							element.StyleIndex = styleIndex;
							flag2 = true;
						}
					}
				}
				if (flag2)
				{
					base.DialogResult = DialogResult.OK;
				}
				Close();
			}
		}

		private void btnBrowseAttribute_Click(object sender, EventArgs e)
		{
			using (dlgAttributes dlgAttributes = new dlgAttributes())
			{
				dlgAttributes.InputAttributes = (XAttributeList)txtAttributes.Tag;
				if (dlgAttributes.ShowDialog(this) == DialogResult.OK)
				{
					txtAttributes.Tag = dlgAttributes.InputAttributes;
					txtAttributes.Text = dlgAttributes.InputAttributes.ToString();
				}
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void lstSlantSplitStyle_DrawItem(object sender, DrawItemEventArgs e)
		{
			DCGraphics dCGraphics = new DCGraphics(e.Graphics);
			RectangleSlantSplitStyle rectangleSlantSplitStyle = (RectangleSlantSplitStyle)lstSlantSplitStyle.Items[e.Index];
			e.DrawBackground();
			_ = SystemBrushes.ControlText;
			_ = SystemPens.ControlText;
			Color color = Color.Black;
			if ((e.State & DrawItemState.Focus) == DrawItemState.Focus || (e.State & DrawItemState.Selected) == DrawItemState.Selected)
			{
				color = SystemColors.HighlightText;
				_ = SystemPens.HighlightText;
				_ = SystemBrushes.HighlightText;
			}
			Rectangle bounds = e.Bounds;
			RectangleF rectangleF_ = new RectangleF(bounds.Left + 3, bounds.Top + 3, 100f, bounds.Height - 6);
			GClass503.smethod_0(dCGraphics, rectangleF_, color, rectangleSlantSplitStyle);
			dCGraphics.DrawRectangle(color, rectangleF_.Left, rectangleF_.Top, rectangleF_.Width, rectangleF_.Height);
			dCGraphics.DrawString(layoutRectangle: new RectangleF(rectangleF_.Right, bounds.Top, (float)bounds.Width - rectangleF_.Right, bounds.Height), string_0: rectangleSlantSplitStyle.ToString(), font: new XFontValue(lstSlantSplitStyle.Font), color: color, alignment: StringAlignment.Near, lineAlignment: StringAlignment.Center);
		}

		private void method_0(Graphics graphics_0, RectangleF rectangleF_0, string string_1, Font font_0, Color color_0, ContentGridLineType contentGridLineType_0)
		{
			int num = 12;
			if (string_1 == null)
			{
				string_1 = "ABC";
			}
			using (StringFormat stringFormat = new StringFormat())
			{
				stringFormat.Alignment = StringAlignment.Near;
				stringFormat.LineAlignment = StringAlignment.Near;
				SizeF sizeF = graphics_0.MeasureString(string_1, font_0, (int)rectangleF_0.Width, stringFormat);
				float height = font_0.GetHeight(graphics_0);
				using (SolidBrush brush = new SolidBrush(color_0))
				{
					graphics_0.DrawString(string_1, font_0, brush, rectangleF_0, stringFormat);
				}
				using (Pen pen = new Pen(color_0, 1f))
				{
					switch (contentGridLineType_0)
					{
					case ContentGridLineType.Display:
					{
						for (float num3 = 0f; num3 < sizeF.Height; num3 += height)
						{
							graphics_0.DrawLine(pen, rectangleF_0.Left, rectangleF_0.Top + num3, rectangleF_0.Right, rectangleF_0.Top + num3);
						}
						break;
					}
					case ContentGridLineType.ExtentToBottom:
					{
						for (float num2 = 0f; num2 < rectangleF_0.Height; num2 += height)
						{
							graphics_0.DrawLine(pen, rectangleF_0.Left, rectangleF_0.Top + num2, rectangleF_0.Right, rectangleF_0.Top + num2);
						}
						break;
					}
					}
					float height2 = (float)Math.Floor(rectangleF_0.Height / height) * height;
					graphics_0.DrawRectangle(pen, rectangleF_0.Left, rectangleF_0.Top, rectangleF_0.Width, height2);
				}
			}
		}

		private void btnBrowseAcceptElementType_Click(object sender, EventArgs e)
		{
			using (dlgElementTypeEditor dlgElementTypeEditor = new dlgElementTypeEditor())
			{
				dlgElementTypeEditor.InputElementType = (ElementType)txtAcceptElementType.Tag;
				if (dlgElementTypeEditor.ShowDialog(this) == DialogResult.OK)
				{
					txtAcceptElementType.Tag = dlgElementTypeEditor.InputElementType;
					txtAcceptElementType.Text = dlgElementTypeEditor.InputElementType.ToString();
				}
			}
		}

		private void chkEnableValueValidate_CheckedChanged(object sender, EventArgs e)
		{
			btnValueValidateSettings.Enabled = chkEnableValueValidate.Checked;
		}

		private void btnValueValidateSettings_Click(object sender, EventArgs e)
		{
			ValueValidateStyle valueValidateStyle = (ValueValidateStyle)btnValueValidateSettings.Tag;
			valueValidateStyle = ((valueValidateStyle != null) ? valueValidateStyle.method_4() : new ValueValidateStyle());
			using (dlgValueValidateStyleEditor dlgValueValidateStyleEditor = new dlgValueValidateStyleEditor())
			{
				dlgValueValidateStyleEditor.ValidateStyle = valueValidateStyle;
				if (dlgValueValidateStyleEditor.ShowDialog(this) == DialogResult.OK)
				{
					btnValueValidateSettings.Tag = valueValidateStyle;
				}
			}
		}

		private void btnValueBinding_Click(object sender, EventArgs e)
		{
			using (dlgXDataBinding dlgXDataBinding = new dlgXDataBinding())
			{
				dlgXDataBinding.XDataBinding = (XDataBinding)btnValueBinding.Tag;
				if (SourceEventArgs != null)
				{
					dlgXDataBinding.Document = SourceEventArgs.Document;
				}
				if (dlgXDataBinding.XDataBinding == null)
				{
					dlgXDataBinding.XDataBinding = new XDataBinding();
				}
				if (dlgXDataBinding.ShowDialog(this) == DialogResult.OK)
				{
					btnValueBinding.Tag = dlgXDataBinding.XDataBinding;
					btnValueBinding.Text = dlgXDataBinding.XDataBinding.ToString();
				}
			}
		}

		private void btnGridLine_Click(object sender, EventArgs e)
		{
			using (dlgDCGridLineInfo dlgDCGridLineInfo = new dlgDCGridLineInfo())
			{
				dlgDCGridLineInfo.InputGridLineInfo = (txtGridLine.Tag as DCGridLineInfo);
				if (dlgDCGridLineInfo.ShowDialog(this) == DialogResult.OK)
				{
					txtGridLine.Tag = dlgDCGridLineInfo.InputGridLineInfo.method_5();
					txtGridLine.Text = dlgDCGridLineInfo.InputGridLineInfo.ToString();
				}
			}
		}

		private void btnBrowseMemberExpressions_Click(object sender, EventArgs e)
		{
			using (dlgPropertyExpressionInfoList dlgPropertyExpressionInfoList = new dlgPropertyExpressionInfoList())
			{
				dlgPropertyExpressionInfoList.InputInfos = (PropertyExpressionInfoList)txtMemberExpressions.Tag;
				dlgPropertyExpressionInfoList.InputOwner = SourceEventArgs.Element;
				if (dlgPropertyExpressionInfoList.InputInfos == null)
				{
					dlgPropertyExpressionInfoList.InputInfos = new PropertyExpressionInfoList();
				}
				else
				{
					dlgPropertyExpressionInfoList.InputInfos = dlgPropertyExpressionInfoList.InputInfos.Clone();
				}
				if (dlgPropertyExpressionInfoList.ShowDialog(this) == DialogResult.OK)
				{
					txtMemberExpressions.Tag = dlgPropertyExpressionInfoList.InputInfos;
					txtMemberExpressions.Text = dlgPropertyExpressionInfoList.InputInfos.ToString();
				}
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Extension.dlgTableCellProperties));
			btnCancel = new System.Windows.Forms.Button();
			btnOK = new System.Windows.Forms.Button();
			btnBrowseAttribute = new System.Windows.Forms.Button();
			txtAttributes = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			txtID = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			txtTitle = new System.Windows.Forms.TextBox();
			tabControl1 = new System.Windows.Forms.TabControl();
			tabPage1 = new System.Windows.Forms.TabPage();
			btnValueBinding = new System.Windows.Forms.Button();
			label19 = new System.Windows.Forms.Label();
			chkMirrorViewForCrossPage = new System.Windows.Forms.CheckBox();
			cboCloneType = new System.Windows.Forms.ComboBox();
			label17 = new System.Windows.Forms.Label();
			label10 = new System.Windows.Forms.Label();
			btnValueValidateSettings = new System.Windows.Forms.Button();
			chkEnableValueValidate = new System.Windows.Forms.CheckBox();
			chkStreesBorder = new System.Windows.Forms.CheckBox();
			btnBrowseAcceptElementType = new System.Windows.Forms.Button();
			label16 = new System.Windows.Forms.Label();
			txtAcceptElementType = new System.Windows.Forms.TextBox();
			cboMoveFocusHotKey = new System.Windows.Forms.ComboBox();
			label18 = new System.Windows.Forms.Label();
			cboAutoFixFontSizeMode = new System.Windows.Forms.ComboBox();
			cboEnablePermission = new System.Windows.Forms.ComboBox();
			label15 = new System.Windows.Forms.Label();
			cboContentReadonly = new System.Windows.Forms.ComboBox();
			label14 = new System.Windows.Forms.Label();
			label9 = new System.Windows.Forms.Label();
			cboEventTemplateName = new System.Windows.Forms.ComboBox();
			label8 = new System.Windows.Forms.Label();
			txtExpression = new System.Windows.Forms.TextBox();
			tabPage4 = new System.Windows.Forms.TabPage();
			groupBox3 = new System.Windows.Forms.GroupBox();
			btnGridLine = new System.Windows.Forms.Button();
			txtGridLine = new System.Windows.Forms.TextBox();
			groupBox1 = new System.Windows.Forms.GroupBox();
			rdVAlignTop = new System.Windows.Forms.RadioButton();
			rdVAlignCenter = new System.Windows.Forms.RadioButton();
			rdVAlignBottom = new System.Windows.Forms.RadioButton();
			groupBox2 = new System.Windows.Forms.GroupBox();
			nudBottom = new System.Windows.Forms.NumericUpDown();
			label7 = new System.Windows.Forms.Label();
			nudLeft = new System.Windows.Forms.NumericUpDown();
			label6 = new System.Windows.Forms.Label();
			nudRight = new System.Windows.Forms.NumericUpDown();
			label5 = new System.Windows.Forms.Label();
			nudTop = new System.Windows.Forms.NumericUpDown();
			label4 = new System.Windows.Forms.Label();
			tabPage3 = new System.Windows.Forms.TabPage();
			lstSlantSplitStyle = new System.Windows.Forms.ListBox();
			btnBrowseMemberExpressions = new System.Windows.Forms.Button();
			label32 = new System.Windows.Forms.Label();
			txtMemberExpressions = new System.Windows.Forms.TextBox();
			tabControl1.SuspendLayout();
			tabPage1.SuspendLayout();
			tabPage4.SuspendLayout();
			groupBox3.SuspendLayout();
			groupBox1.SuspendLayout();
			groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudBottom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudLeft).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudRight).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudTop).BeginInit();
			tabPage3.SuspendLayout();
			SuspendLayout();
			btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.Name = "btnOK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			resources.ApplyResources(btnBrowseAttribute, "btnBrowseAttribute");
			btnBrowseAttribute.Name = "btnBrowseAttribute";
			btnBrowseAttribute.UseVisualStyleBackColor = true;
			btnBrowseAttribute.Click += new System.EventHandler(btnBrowseAttribute_Click);
			resources.ApplyResources(txtAttributes, "txtAttributes");
			txtAttributes.Name = "txtAttributes";
			txtAttributes.ReadOnly = true;
			resources.ApplyResources(label2, "label2");
			label2.Name = "label2";
			resources.ApplyResources(txtID, "txtID");
			txtID.Name = "txtID";
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			resources.ApplyResources(label3, "label3");
			label3.Name = "label3";
			resources.ApplyResources(txtTitle, "txtTitle");
			txtTitle.Name = "txtTitle";
			tabControl1.Controls.Add(tabPage1);
			tabControl1.Controls.Add(tabPage4);
			tabControl1.Controls.Add(tabPage3);
			resources.ApplyResources(tabControl1, "tabControl1");
			tabControl1.Name = "tabControl1";
			tabControl1.SelectedIndex = 0;
			tabPage1.Controls.Add(btnBrowseMemberExpressions);
			tabPage1.Controls.Add(label32);
			tabPage1.Controls.Add(txtMemberExpressions);
			tabPage1.Controls.Add(btnValueBinding);
			tabPage1.Controls.Add(label19);
			tabPage1.Controls.Add(chkMirrorViewForCrossPage);
			tabPage1.Controls.Add(cboCloneType);
			tabPage1.Controls.Add(label17);
			tabPage1.Controls.Add(label10);
			tabPage1.Controls.Add(btnValueValidateSettings);
			tabPage1.Controls.Add(chkEnableValueValidate);
			tabPage1.Controls.Add(chkStreesBorder);
			tabPage1.Controls.Add(btnBrowseAcceptElementType);
			tabPage1.Controls.Add(label16);
			tabPage1.Controls.Add(txtAcceptElementType);
			tabPage1.Controls.Add(cboMoveFocusHotKey);
			tabPage1.Controls.Add(label18);
			tabPage1.Controls.Add(cboAutoFixFontSizeMode);
			tabPage1.Controls.Add(cboEnablePermission);
			tabPage1.Controls.Add(label15);
			tabPage1.Controls.Add(cboContentReadonly);
			tabPage1.Controls.Add(label14);
			tabPage1.Controls.Add(label9);
			tabPage1.Controls.Add(cboEventTemplateName);
			tabPage1.Controls.Add(label8);
			tabPage1.Controls.Add(txtExpression);
			tabPage1.Controls.Add(txtTitle);
			tabPage1.Controls.Add(label1);
			tabPage1.Controls.Add(txtID);
			tabPage1.Controls.Add(btnBrowseAttribute);
			tabPage1.Controls.Add(label3);
			tabPage1.Controls.Add(txtAttributes);
			tabPage1.Controls.Add(label2);
			resources.ApplyResources(tabPage1, "tabPage1");
			tabPage1.Name = "tabPage1";
			tabPage1.UseVisualStyleBackColor = true;
			resources.ApplyResources(btnValueBinding, "btnValueBinding");
			btnValueBinding.Name = "btnValueBinding";
			btnValueBinding.UseVisualStyleBackColor = true;
			btnValueBinding.Click += new System.EventHandler(btnValueBinding_Click);
			resources.ApplyResources(label19, "label19");
			label19.Name = "label19";
			resources.ApplyResources(chkMirrorViewForCrossPage, "chkMirrorViewForCrossPage");
			chkMirrorViewForCrossPage.Name = "chkMirrorViewForCrossPage";
			chkMirrorViewForCrossPage.UseVisualStyleBackColor = true;
			cboCloneType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboCloneType.FormattingEnabled = true;
			cboCloneType.Items.AddRange(new object[3]
			{
				resources.GetString("cboCloneType.Items"),
				resources.GetString("cboCloneType.Items1"),
				resources.GetString("cboCloneType.Items2")
			});
			resources.ApplyResources(cboCloneType, "cboCloneType");
			cboCloneType.Name = "cboCloneType";
			resources.ApplyResources(label17, "label17");
			label17.Name = "label17";
			resources.ApplyResources(label10, "label10");
			label10.Name = "label10";
			resources.ApplyResources(btnValueValidateSettings, "btnValueValidateSettings");
			btnValueValidateSettings.Name = "btnValueValidateSettings";
			btnValueValidateSettings.UseVisualStyleBackColor = true;
			btnValueValidateSettings.Click += new System.EventHandler(btnValueValidateSettings_Click);
			resources.ApplyResources(chkEnableValueValidate, "chkEnableValueValidate");
			chkEnableValueValidate.Name = "chkEnableValueValidate";
			chkEnableValueValidate.UseVisualStyleBackColor = true;
			chkEnableValueValidate.CheckedChanged += new System.EventHandler(chkEnableValueValidate_CheckedChanged);
			resources.ApplyResources(chkStreesBorder, "chkStreesBorder");
			chkStreesBorder.Name = "chkStreesBorder";
			chkStreesBorder.UseVisualStyleBackColor = true;
			resources.ApplyResources(btnBrowseAcceptElementType, "btnBrowseAcceptElementType");
			btnBrowseAcceptElementType.Name = "btnBrowseAcceptElementType";
			btnBrowseAcceptElementType.UseVisualStyleBackColor = true;
			btnBrowseAcceptElementType.Click += new System.EventHandler(btnBrowseAcceptElementType_Click);
			resources.ApplyResources(label16, "label16");
			label16.Name = "label16";
			resources.ApplyResources(txtAcceptElementType, "txtAcceptElementType");
			txtAcceptElementType.Name = "txtAcceptElementType";
			txtAcceptElementType.ReadOnly = true;
			cboMoveFocusHotKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboMoveFocusHotKey.FormattingEnabled = true;
			resources.ApplyResources(cboMoveFocusHotKey, "cboMoveFocusHotKey");
			cboMoveFocusHotKey.Name = "cboMoveFocusHotKey";
			resources.ApplyResources(label18, "label18");
			label18.Name = "label18";
			cboAutoFixFontSizeMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboAutoFixFontSizeMode.FormattingEnabled = true;
			cboAutoFixFontSizeMode.Items.AddRange(new object[3]
			{
				resources.GetString("cboAutoFixFontSizeMode.Items"),
				resources.GetString("cboAutoFixFontSizeMode.Items1"),
				resources.GetString("cboAutoFixFontSizeMode.Items2")
			});
			resources.ApplyResources(cboAutoFixFontSizeMode, "cboAutoFixFontSizeMode");
			cboAutoFixFontSizeMode.Name = "cboAutoFixFontSizeMode";
			cboEnablePermission.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboEnablePermission.FormattingEnabled = true;
			cboEnablePermission.Items.AddRange(new object[3]
			{
				resources.GetString("cboEnablePermission.Items"),
				resources.GetString("cboEnablePermission.Items1"),
				resources.GetString("cboEnablePermission.Items2")
			});
			resources.ApplyResources(cboEnablePermission, "cboEnablePermission");
			cboEnablePermission.Name = "cboEnablePermission";
			resources.ApplyResources(label15, "label15");
			label15.Name = "label15";
			cboContentReadonly.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboContentReadonly.FormattingEnabled = true;
			cboContentReadonly.Items.AddRange(new object[3]
			{
				resources.GetString("cboContentReadonly.Items"),
				resources.GetString("cboContentReadonly.Items1"),
				resources.GetString("cboContentReadonly.Items2")
			});
			resources.ApplyResources(cboContentReadonly, "cboContentReadonly");
			cboContentReadonly.Name = "cboContentReadonly";
			resources.ApplyResources(label14, "label14");
			label14.Name = "label14";
			resources.ApplyResources(label9, "label9");
			label9.Name = "label9";
			cboEventTemplateName.FormattingEnabled = true;
			resources.ApplyResources(cboEventTemplateName, "cboEventTemplateName");
			cboEventTemplateName.Name = "cboEventTemplateName";
			resources.ApplyResources(label8, "label8");
			label8.Name = "label8";
			resources.ApplyResources(txtExpression, "txtExpression");
			txtExpression.Name = "txtExpression";
			tabPage4.Controls.Add(groupBox3);
			tabPage4.Controls.Add(groupBox1);
			tabPage4.Controls.Add(groupBox2);
			resources.ApplyResources(tabPage4, "tabPage4");
			tabPage4.Name = "tabPage4";
			tabPage4.UseVisualStyleBackColor = true;
			groupBox3.Controls.Add(btnGridLine);
			groupBox3.Controls.Add(txtGridLine);
			resources.ApplyResources(groupBox3, "groupBox3");
			groupBox3.Name = "groupBox3";
			groupBox3.TabStop = false;
			resources.ApplyResources(btnGridLine, "btnGridLine");
			btnGridLine.Name = "btnGridLine";
			btnGridLine.UseVisualStyleBackColor = true;
			btnGridLine.Click += new System.EventHandler(btnGridLine_Click);
			resources.ApplyResources(txtGridLine, "txtGridLine");
			txtGridLine.Name = "txtGridLine";
			txtGridLine.ReadOnly = true;
			groupBox1.Controls.Add(rdVAlignTop);
			groupBox1.Controls.Add(rdVAlignCenter);
			groupBox1.Controls.Add(rdVAlignBottom);
			resources.ApplyResources(groupBox1, "groupBox1");
			groupBox1.Name = "groupBox1";
			groupBox1.TabStop = false;
			resources.ApplyResources(rdVAlignTop, "rdVAlignTop");
			rdVAlignTop.Name = "rdVAlignTop";
			rdVAlignTop.UseVisualStyleBackColor = true;
			resources.ApplyResources(rdVAlignCenter, "rdVAlignCenter");
			rdVAlignCenter.Name = "rdVAlignCenter";
			rdVAlignCenter.UseVisualStyleBackColor = true;
			resources.ApplyResources(rdVAlignBottom, "rdVAlignBottom");
			rdVAlignBottom.Name = "rdVAlignBottom";
			rdVAlignBottom.UseVisualStyleBackColor = true;
			groupBox2.Controls.Add(nudBottom);
			groupBox2.Controls.Add(label7);
			groupBox2.Controls.Add(nudLeft);
			groupBox2.Controls.Add(label6);
			groupBox2.Controls.Add(nudRight);
			groupBox2.Controls.Add(label5);
			groupBox2.Controls.Add(nudTop);
			groupBox2.Controls.Add(label4);
			resources.ApplyResources(groupBox2, "groupBox2");
			groupBox2.Name = "groupBox2";
			groupBox2.TabStop = false;
			nudBottom.DecimalPlaces = 2;
			nudBottom.Increment = new decimal(new int[4]
			{
				5,
				0,
				0,
				131072
			});
			resources.ApplyResources(nudBottom, "nudBottom");
			nudBottom.Name = "nudBottom";
			resources.ApplyResources(label7, "label7");
			label7.Name = "label7";
			nudLeft.DecimalPlaces = 2;
			nudLeft.Increment = new decimal(new int[4]
			{
				5,
				0,
				0,
				131072
			});
			resources.ApplyResources(nudLeft, "nudLeft");
			nudLeft.Name = "nudLeft";
			resources.ApplyResources(label6, "label6");
			label6.Name = "label6";
			nudRight.DecimalPlaces = 2;
			nudRight.Increment = new decimal(new int[4]
			{
				5,
				0,
				0,
				131072
			});
			resources.ApplyResources(nudRight, "nudRight");
			nudRight.Name = "nudRight";
			resources.ApplyResources(label5, "label5");
			label5.Name = "label5";
			nudTop.DecimalPlaces = 2;
			nudTop.Increment = new decimal(new int[4]
			{
				5,
				0,
				0,
				131072
			});
			resources.ApplyResources(nudTop, "nudTop");
			nudTop.Name = "nudTop";
			resources.ApplyResources(label4, "label4");
			label4.Name = "label4";
			tabPage3.Controls.Add(lstSlantSplitStyle);
			resources.ApplyResources(tabPage3, "tabPage3");
			tabPage3.Name = "tabPage3";
			tabPage3.UseVisualStyleBackColor = true;
			resources.ApplyResources(lstSlantSplitStyle, "lstSlantSplitStyle");
			lstSlantSplitStyle.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			lstSlantSplitStyle.FormattingEnabled = true;
			lstSlantSplitStyle.Name = "lstSlantSplitStyle";
			lstSlantSplitStyle.DrawItem += new System.Windows.Forms.DrawItemEventHandler(lstSlantSplitStyle_DrawItem);
			resources.ApplyResources(btnBrowseMemberExpressions, "btnBrowseMemberExpressions");
			btnBrowseMemberExpressions.Name = "btnBrowseMemberExpressions";
			btnBrowseMemberExpressions.UseVisualStyleBackColor = true;
			btnBrowseMemberExpressions.Click += new System.EventHandler(btnBrowseMemberExpressions_Click);
			resources.ApplyResources(label32, "label32");
			label32.Name = "label32";
			resources.ApplyResources(txtMemberExpressions, "txtMemberExpressions");
			txtMemberExpressions.Name = "txtMemberExpressions";
			txtMemberExpressions.ReadOnly = true;
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = btnCancel;
			base.Controls.Add(tabControl1);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgTableCellProperties";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgTableCellProperties_Load);
			tabControl1.ResumeLayout(false);
			tabPage1.ResumeLayout(false);
			tabPage1.PerformLayout();
			tabPage4.ResumeLayout(false);
			groupBox3.ResumeLayout(false);
			groupBox3.PerformLayout();
			groupBox1.ResumeLayout(false);
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudBottom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudLeft).EndInit();
			((System.ComponentModel.ISupportInitialize)nudRight).EndInit();
			((System.ComponentModel.ISupportInitialize)nudTop).EndInit();
			tabPage3.ResumeLayout(false);
			ResumeLayout(false);
		}
	}
}
