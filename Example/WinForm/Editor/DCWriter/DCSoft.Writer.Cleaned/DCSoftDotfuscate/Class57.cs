using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.Printing;
using DCSoft.Writer;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Extension.Medical;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[Serializable]
	[ComVisible(false)]
	internal class Class57 : GClass23, GInterface5
	{
		private enum Enum7
		{
			const_0,
			const_1,
			const_2
		}

		private class Class56
		{
			private XTextElement xtextElement_0 = null;

			private string string_0 = null;

			private string string_1 = null;

			private string string_2 = null;

			public Class56(XTextElement xtextElement_1, string string_3, string string_4)
			{
				xtextElement_0 = xtextElement_1;
				string_0 = string_3;
				string_2 = string_4;
			}

			public XTextElement method_0()
			{
				return xtextElement_0;
			}

			public void method_1(XTextElement xtextElement_1)
			{
				xtextElement_0 = xtextElement_1;
			}

			public string method_2()
			{
				return string_0;
			}

			public void method_3(string string_3)
			{
				string_0 = string_3;
			}

			public string method_4()
			{
				return string_1;
			}

			public void method_5(string string_3)
			{
				string_1 = string_3;
			}

			public string method_6()
			{
				return string_2;
			}

			public void method_7(string string_3)
			{
				string_2 = string_3;
			}
		}

		public const string string_5 = "dc_";

		private static Graphics graphics_0 = null;

		private int int_2 = 0;

		private int int_3 = int.MaxValue;

		private bool bool_8 = false;

		private bool bool_9 = true;

		private bool bool_10 = true;

		private string string_6 = null;

		private string string_7 = null;

		public QueryListItemsEventHandler queryListItemsEventHandler_0 = null;

		private bool bool_11 = true;

		private bool bool_12 = false;

		private bool bool_13 = true;

		private string string_8 = null;

		private bool bool_14 = false;

		private bool bool_15 = false;

		private static int int_4 = 0;

		private List<Class56> list_0 = new List<Class56>();

		private string string_9 = null;

		private Dictionary<XTextElement, List<string>> dictionary_2 = new Dictionary<XTextElement, List<string>>();

		private int int_5 = 0;

		private bool bool_16 = false;

		private bool bool_17 = false;

		private bool bool_18 = false;

		private XTextElementList xtextElementList_0 = new XTextElementList();

		private XTextDocument xtextDocument_0 = null;

		private XTextDocumentList xtextDocumentList_0 = new XTextDocumentList();

		private bool bool_19 = false;

		private GEnum12 genum12_0 = GEnum12.const_2;

		private GClass119 gclass119_0 = new GClass119();

		private bool bool_20 = false;

		private Rectangle rectangle_0 = Rectangle.Empty;

		private RectangleF rectangleF_0 = RectangleF.Empty;

		private bool bool_21 = false;

		private bool bool_22 = false;

		private DCBackgroundTextOutputMode dcbackgroundTextOutputMode_0 = DCBackgroundTextOutputMode.Underline;

		private bool bool_23 = true;

		public void imethod_23(XTextElement xtextElement_0)
		{
			if (xtextElement_0 is XTextMedicalExpressionFieldElement)
			{
				method_81((XTextMedicalExpressionFieldElement)xtextElement_0);
			}
			else if (xtextElement_0 is XTextTDBarcodeElement)
			{
				method_82((XTextTDBarcodeElement)xtextElement_0);
			}
			else if (xtextElement_0 is XTextFieldBorderElement)
			{
				method_98((XTextFieldBorderElement)xtextElement_0);
			}
			else if (xtextElement_0 is XTextMediaElement)
			{
				method_93((XTextMediaElement)xtextElement_0);
			}
			else if (xtextElement_0 is XTextDocumentBodyElement)
			{
				method_99((XTextDocumentBodyElement)xtextElement_0);
			}
			else if (xtextElement_0 is XTextDocument)
			{
				method_100((XTextDocument)xtextElement_0);
			}
			else if (xtextElement_0 is XTextDirectoryFieldElement)
			{
				method_101((XTextDirectoryFieldElement)xtextElement_0);
			}
			else if (xtextElement_0 is XTextCustomShapeElement)
			{
				method_102((XTextCustomShapeElement)xtextElement_0);
			}
			else if (xtextElement_0 is XTextCheckBoxElementBase)
			{
				method_108((XTextCheckBoxElementBase)xtextElement_0);
			}
			else if (xtextElement_0 is XTextButtonElement)
			{
				method_109((XTextButtonElement)xtextElement_0);
			}
			else if (xtextElement_0 is XTextHorizontalLineElement)
			{
				method_97((XTextHorizontalLineElement)xtextElement_0);
			}
			else if (xtextElement_0 is XTextImageElement)
			{
				method_96((XTextImageElement)xtextElement_0);
			}
			else if (xtextElement_0 is XTextInputFieldElement)
			{
				method_95((XTextInputFieldElement)xtextElement_0);
			}
			else if (xtextElement_0 is XTextLabelElement)
			{
				method_94((XTextLabelElement)xtextElement_0);
			}
			else if (xtextElement_0 is XTextPageBreakElement)
			{
				method_92((XTextPageBreakElement)xtextElement_0);
			}
			else if (xtextElement_0 is XTextPageInfoElement)
			{
				method_91((XTextPageInfoElement)xtextElement_0);
			}
			else if (xtextElement_0 is XTextParagraphElement)
			{
				method_90((XTextParagraphElement)xtextElement_0);
			}
			else if (xtextElement_0 is XTextParagraphListItemElement)
			{
				method_89((XTextParagraphListItemElement)xtextElement_0);
			}
			else if (xtextElement_0 is XTextSectionElement)
			{
				method_88((XTextSectionElement)xtextElement_0);
			}
			else if (xtextElement_0 is XTextStringElement)
			{
				method_87((XTextStringElement)xtextElement_0);
			}
			else if (xtextElement_0 is XTextTableElement)
			{
				method_85((XTextTableElement)xtextElement_0);
			}
			else if (xtextElement_0 is XTextLineBreakElement)
			{
				method_84((XTextLineBreakElement)xtextElement_0);
			}
			else if (xtextElement_0 is XTextShapeInputFieldElement)
			{
				method_83((XTextShapeInputFieldElement)xtextElement_0);
			}
			else if (xtextElement_0 is XTextContentElement)
			{
				XTextContentElement xTextContentElement = (XTextContentElement)xtextElement_0;
				xTextContentElement.method_52(this);
			}
			else if (xtextElement_0 is XTextControlHostElement)
			{
				method_103((XTextControlHostElement)xtextElement_0);
			}
			else if (xtextElement_0 is XTextContainerElement)
			{
				method_104((XTextContainerElement)xtextElement_0);
			}
		}

		private void method_81(XTextMedicalExpressionFieldElement xtextMedicalExpressionFieldElement_0)
		{
			int num = 13;
			xtextMedicalExpressionFieldElement_0.InnerSerializeText = xtextMedicalExpressionFieldElement_0.Text;
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			if (!imethod_34())
			{
				if (!xtextMedicalExpressionFieldElement_0.RuntimeContentReadonly)
				{
					dictionary["ondblclick"] = "DCMedicalExpressionManager.ShowEditValueDialog( this );";
				}
				dictionary["dcfontsize"] = xtextMedicalExpressionFieldElement_0.RuntimeStyle.FontSize.ToString();
			}
			method_161(xtextMedicalExpressionFieldElement_0, dictionary);
		}

		private void method_82(XTextTDBarcodeElement xtextTDBarcodeElement_0)
		{
			method_160(xtextTDBarcodeElement_0);
		}

		private void method_83(XTextShapeInputFieldElement xtextShapeInputFieldElement_0)
		{
			if (xtextShapeInputFieldElement_0.EditMode)
			{
				method_104(xtextShapeInputFieldElement_0);
			}
			else
			{
				method_160(xtextShapeInputFieldElement_0);
			}
		}

		private void method_84(XTextLineBreakElement xtextLineBreakElement_0)
		{
			method_17("br", "");
		}

		private void method_85(XTextTableElement xtextTableElement_0)
		{
			int num = 5;
			imethod_0("table");
			method_19("id", xtextTableElement_0.ID);
			method_19("cellpadding", "0");
			method_19("cellspacing", "0");
			if (!imethod_34())
			{
				method_145(xtextTableElement_0);
			}
			method_39();
			if (method_128())
			{
				method_40("display", "block");
			}
			if (!xtextTableElement_0.Visible)
			{
				method_40("display", "none");
			}
			imethod_54(xtextTableElement_0.RuntimeStyle, xtextTableElement_0);
			method_40("border-collapse", "collapse");
			method_40("table-layout", "fixed");
			method_40("width", imethod_44(xtextTableElement_0.Width) + "px");
			method_63();
			StringBuilder stringBuilder = new StringBuilder();
			foreach (XTextTableColumnElement column in xtextTableElement_0.Columns)
			{
				if (column.RuntimeVisible)
				{
					if (stringBuilder.Length > 0)
					{
						stringBuilder.Append(",");
					}
					stringBuilder.Append(imethod_45(column.Width).ToString());
					imethod_0("col");
					float num2 = 0f;
					num2 = ((xtextTableElement_0.Columns.LastElement != column || !(xtextTableElement_0.Parent is XTextTableCellElement)) ? imethod_45(column.Width) : (imethod_45(column.Width) - 2f));
					method_19("style", "width:" + num2 + "px");
					method_19("width", num2 + "px");
					method_145(column);
					imethod_1();
				}
			}
			if (method_22() || (method_28() != XWebBrowsersStyle.AppleMAC_Safari && method_28() != XWebBrowsersStyle.InternetExplorer && (method_28() != XWebBrowsersStyle.InternetExplorer7 || method_31() == GEnum79.const_0)))
			{
			}
			RectangleF absBounds = xtextTableElement_0.AbsBounds;
			XTextTableRowElement xTextTableRowElement = null;
			XTextElementList xtextElementList_ = xtextTableElement_0.Rows;
			XTextElementList xtextElementList_2 = xtextTableElement_0.Cells;
			List<XTextTableCellElement> list = new List<XTextTableCellElement>();
			if (imethod_48())
			{
				xtextTableElement_0.method_51(out xtextElementList_, out xtextElementList_2);
			}
			XTextTableRowElement xTextTableRowElement2 = (XTextTableRowElement)xtextElementList_.LastElement;
			if (!imethod_50().IsEmpty)
			{
				int num3 = xtextElementList_.Count - 1;
				while (num3 >= 0)
				{
					XTextTableRowElement xTextTableRowElement3 = (XTextTableRowElement)xtextElementList_[num3];
					if (!(xTextTableRowElement3.AbsTop < (float)(imethod_50().Bottom - 2)))
					{
						num3--;
						continue;
					}
					xTextTableRowElement2 = xTextTableRowElement3;
					break;
				}
			}
			RectangleF a = imethod_50();
			foreach (XTextTableRowElement item in xtextElementList_)
			{
				if (method_152(item))
				{
					absBounds = item.AbsBounds;
					absBounds.Height = (int)item.Height;
					RectangleF rectangleF = absBounds;
					int num4 = 0;
					if (!imethod_50().IsEmpty)
					{
						rectangleF = RectangleF.Intersect(a, absBounds);
						if (rectangleF.Bottom != absBounds.Bottom)
						{
							num4 = 3;
						}
					}
					if (!rectangleF.IsEmpty && rectangleF.Height > 5f)
					{
						if (xTextTableRowElement == null)
						{
							xTextTableRowElement = item;
						}
						imethod_0("tr");
						if (!imethod_34())
						{
							method_145(item);
							method_19("colwidths", stringBuilder.ToString());
						}
						method_39();
						if (imethod_46().method_4() || item.RuntimeSpecifyHeight != 0f)
						{
							if (imethod_34())
							{
								float num5 = imethod_45(rectangleF.Height);
								if (method_28() == XWebBrowsersStyle.InternetExplorer7)
								{
									num5 = (float)Math.Round(num5);
								}
								method_40("height", num5 + "px");
							}
							else if (method_28() == XWebBrowsersStyle.InternetExplorer && method_30() == GEnum78.const_1)
							{
								method_40("height", imethod_44(rectangleF.Height + (float)num4 - 23f) + "px");
							}
							else if (method_28() == XWebBrowsersStyle.InternetExplorer7 && method_31() != 0)
							{
								method_19("height", imethod_44(rectangleF.Height + (float)num4 - 23f) + "px");
							}
							else
							{
								method_19("height", imethod_44(rectangleF.Height + (float)num4) + "px");
							}
						}
						if (method_128())
						{
							method_40("dispaly", "block");
						}
						method_63();
						foreach (XTextTableCellElement cell in item.Cells)
						{
							if (xtextElementList_2.Contains(cell))
							{
								if (cell.RuntimeVisible && !cell.IsOverrided)
								{
									if (imethod_42() == GEnum12.const_2)
									{
										int num6 = cell.RuntimeRowSpan;
										if (num6 > 1)
										{
											num6 = Math.Min(num6, xTextTableRowElement2.Index - cell.RowIndex + 1);
										}
										method_86(cell, num6);
									}
									else
									{
										method_86(cell, cell.RowSpan);
									}
									list.Add(cell);
								}
								else
								{
									XTextTableCellElement overrideCell = cell.OverrideCell;
									if (overrideCell != null && overrideCell.RuntimeVisible && !list.Contains(overrideCell))
									{
										list.Add(overrideCell);
										int num7 = 0;
										num7 = ((imethod_42() != GEnum12.const_2) ? (overrideCell.RowSpan - (item.Index - overrideCell.RowIndex)) : (overrideCell.RuntimeRowSpan - (item.Index - overrideCell.RowIndex)));
										method_86(cell, num7);
									}
								}
							}
						}
						imethod_2();
					}
					absBounds.Offset(0f, absBounds.Height);
				}
			}
			imethod_2();
		}

		private void method_86(XTextTableCellElement xtextTableCellElement_0, int int_6)
		{
			int num = 14;
			imethod_0("td");
			method_19("cellid", xtextTableCellElement_0.CellID);
			if (!imethod_34())
			{
				method_145(xtextTableCellElement_0);
			}
			if (!string.IsNullOrEmpty(xtextTableCellElement_0.ValueExpression))
			{
				method_19("id", xtextTableCellElement_0.ClientID);
			}
			if (!string.IsNullOrEmpty(xtextTableCellElement_0.ToolTip))
			{
				method_19("title", xtextTableCellElement_0.ToolTip);
			}
			if (int_6 > 1)
			{
				method_19("rowspan", int_6.ToString());
			}
			if (imethod_36() && xtextTableCellElement_0.RuntimeContentReadonly)
			{
				method_144(bool_24: false);
			}
			if (xtextTableCellElement_0.ColSpan > 1)
			{
				int num2 = 0;
				int colIndex = xtextTableCellElement_0.ColIndex;
				foreach (XTextTableColumnElement column in xtextTableCellElement_0.OwnerTable.Columns)
				{
					if (column.Index > colIndex && column.Index < colIndex + xtextTableCellElement_0.ColSpan - 1 && !column.Visible)
					{
						num2++;
					}
				}
				if (xtextTableCellElement_0.ColSpan - num2 > 1)
				{
					method_19("colspan", Convert.ToString(xtextTableCellElement_0.ColSpan - num2));
				}
			}
			method_39();
			if (!(xtextTableCellElement_0.ID == "1234"))
			{
			}
			DocumentContentStyle documentContentStyle = xtextTableCellElement_0.RuntimeStyle.CloneParent();
			if (xtextTableCellElement_0.OwnerRow.RuntimeSpecifyHeight != 0f)
			{
				documentContentStyle.PaddingBottom = 0f;
			}
			method_53(0);
			method_159(bool_24: true);
			imethod_54(documentContentStyle.MyRuntimeStyle, xtextTableCellElement_0);
			method_159(bool_24: false);
			method_40("width", imethod_44(xtextTableCellElement_0.Width) + "px");
			if (!imethod_34())
			{
				method_40("word-wrap", "break-word");
				method_40("word-break", "break-all");
			}
			if (method_128())
			{
				method_40("display", "inline-block");
			}
			method_63();
			int num3 = method_52();
			if (imethod_34())
			{
				Rectangle b = Rectangle.Ceiling(xtextTableCellElement_0.AbsBounds);
				float num4 = xtextTableCellElement_0.ClientHeight;
				float num5 = 0f;
				if (!imethod_50().IsEmpty)
				{
					Rectangle rectangle = Rectangle.Intersect(imethod_50(), b);
					if (Math.Abs(rectangle.Height - b.Height) >= 2)
					{
						num4 = (float)rectangle.Height - xtextTableCellElement_0.RuntimeStyle.PaddingTop - xtextTableCellElement_0.RuntimeStyle.PaddingBottom;
						num5 = 3.125f;
					}
				}
				if (xtextTableCellElement_0.HasContentElement)
				{
					imethod_0("div");
					method_39();
					float num6 = imethod_45(num4 - num5) - (float)num3;
					method_40("height", num6 + "px");
					method_40("overflow", "hidden");
					method_63();
					xtextTableCellElement_0.method_52(this);
					imethod_2();
				}
			}
			else if (imethod_42() == GEnum12.const_0 || imethod_42() == GEnum12.const_1)
			{
				method_105(xtextTableCellElement_0);
			}
			else
			{
				xtextTableCellElement_0.method_52(this);
			}
			if (imethod_34())
			{
				PrintPage printPage = xtextTableCellElement_0.OwnerDocument.Pages.SafeGet(xtextTableCellElement_0.OwnerDocument.PageIndex);
				if (xtextTableCellElement_0.method_62(printPage))
				{
					float num7 = printPage.Top - xtextTableCellElement_0.AbsTop;
					_ = xtextTableCellElement_0.Height - num7;
					XTextLineList xTextLineList = new XTextLineList();
					foreach (XTextLine privateLine in xtextTableCellElement_0.PrivateLines)
					{
						privateLine.Top += num7;
						xTextLineList.Add(privateLine);
					}
					try
					{
						xtextTableCellElement_0.method_52(this);
					}
					finally
					{
						foreach (XTextLine item in xTextLineList)
						{
							item.Top -= num7;
						}
					}
				}
			}
			imethod_2();
		}

		private void method_87(XTextStringElement xtextStringElement_0)
		{
			int num = 9;
			if (xtextStringElement_0.IsBackgroundText && xtextStringElement_0.Parent is XTextInputFieldElement)
			{
				XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)xtextStringElement_0.Parent;
				imethod_0("span");
				method_39();
				if (imethod_34() && xtextStringElement_0.OwnerDocument.Options.ViewOptions.PreserveBackgroundTextWhenPrint && !xtextStringElement_0.OwnerDocument.Options.ViewOptions.PrintBackgroundText)
				{
					method_40("visibility", "hidden");
				}
				else
				{
					method_40("color", method_61(xTextInputFieldElement.RuntimeBackgroundTextColor));
				}
				method_45(xtextStringElement_0.RuntimeStyle.Font.Value);
				if (xTextInputFieldElement.BackgroundTextItalic == DCBooleanValueHasDefault.True)
				{
					method_40("font-style", "italic");
				}
				else if (xTextInputFieldElement.BackgroundTextItalic == DCBooleanValueHasDefault.False)
				{
					method_40("font-style", "normal");
				}
				method_63();
				method_3(xtextStringElement_0.Text);
				imethod_2();
				return;
			}
			DocumentContentStyle documentContentStyle = xtextStringElement_0.RuntimeStyle.Parent;
			if (xtextStringElement_0.Parent is XTextInputFieldElement)
			{
				XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)xtextStringElement_0.Parent;
				Color color = documentContentStyle.Color;
				color = xTextInputFieldElement.method_35(color, documentContentStyle.MyRuntimeStyle, bool_26: true);
				if (color != documentContentStyle.Color)
				{
					documentContentStyle = (DocumentContentStyle)documentContentStyle.Clone();
					documentContentStyle.Color = color;
				}
			}
			string text = xtextStringElement_0.GetOutputText(imethod_48());
			if (xtextStringElement_0.OwnerDocument.Options.BehaviorOptions.DoubleCompressHtmlWhitespace)
			{
				text = text.Replace("  ", " ");
			}
			float num2 = 0f;
			if (xtextStringElement_0.MergeForPrintHtml && xtextStringElement_0.StartElement != null && xtextStringElement_0.EndElement != null && xtextStringElement_0.StartElement.CharValue == ' ' && xtextStringElement_0.EndElement.CharValue == ' ')
			{
				float left = xtextStringElement_0.StartElement.Left;
				float num3 = xtextStringElement_0.EndElement.Left + xtextStringElement_0.EndElement.Width;
				num2 = num3 - left;
				if (num2 < 0f)
				{
					num2 = 0f;
				}
			}
			if (imethod_34())
			{
				XTextContentElement contentElement = xtextStringElement_0.ContentElement;
				if (contentElement != null && contentElement.RateForAutoFixFontSizeMode < 1f)
				{
					documentContentStyle = (DocumentContentStyle)documentContentStyle.Clone();
					documentContentStyle.FontSize *= contentElement.RateForAutoFixFontSizeMode;
				}
			}
			method_157(text, documentContentStyle.MyRuntimeStyle, xtextStringElement_0, num2);
		}

		private void method_88(XTextSectionElement xtextSectionElement_0)
		{
			int num = 6;
			imethod_0("div");
			if (imethod_36())
			{
				method_140(xtextSectionElement_0.GetType());
				method_145(xtextSectionElement_0);
				if (xtextSectionElement_0.ContentReadonly == ContentReadonlyState.True)
				{
					method_144(bool_24: false);
				}
				else if (xtextSectionElement_0.ContentReadonly == ContentReadonlyState.False)
				{
					method_144(bool_24: true);
				}
			}
			method_39();
			imethod_54(xtextSectionElement_0.RuntimeStyle, xtextSectionElement_0);
			if (!xtextSectionElement_0.Visible)
			{
				method_40("display", "none");
			}
			method_63();
			string htmlTitle = xtextSectionElement_0.HtmlTitle;
			if (!string.IsNullOrEmpty(htmlTitle))
			{
				method_19("title", htmlTitle);
			}
			xtextSectionElement_0.method_52(this);
			imethod_2();
		}

		private void method_89(XTextParagraphListItemElement xtextParagraphListItemElement_0)
		{
			int num = 13;
			if (imethod_34())
			{
				XTextParagraphListItemElement.GClass5 gClass = new XTextParagraphListItemElement.GClass5(xtextParagraphListItemElement_0, bool_0: false, bool_1: false);
				if (!string.IsNullOrEmpty(gClass.string_0))
				{
					imethod_0("span");
					method_39();
					method_45(gClass.xfontValue_0.Value);
					method_40("color", method_61(gClass.color_0));
					method_40("display", "inline-block");
					method_40("width", imethod_44(xtextParagraphListItemElement_0.Width) + "px");
					method_40("text-align", "left");
					method_63();
					method_3(gClass.string_0);
					imethod_2();
				}
			}
		}

		private void method_90(XTextParagraphElement xtextParagraphElement_0)
		{
			int num = 15;
			RuntimeDocumentContentStyle runtimeStyle = xtextParagraphElement_0.RuntimeStyle;
			if (xtextParagraphElement_0.TemporaryFlag)
			{
				if (xtextParagraphElement_0.Elements.Count > 1)
				{
					XTextParagraphElement xTextParagraphElement = xtextParagraphElement_0.method_27(imethod_48());
					foreach (XTextElement element in xTextParagraphElement.Elements)
					{
						element.vmethod_18(this);
					}
				}
				else
				{
					method_15(" ");
				}
				return;
			}
			if (runtimeStyle.ParagraphListStyle != 0)
			{
				imethod_0("p");
			}
			else
			{
				imethod_0("li");
			}
			imethod_54(xtextParagraphElement_0.RuntimeStyle, xtextParagraphElement_0);
			method_40("text-justify", "inter-ideograph");
			method_40("margin-bottom", xtextParagraphElement_0.OwnerDocument.ToPixel((int)runtimeStyle.SpacingBeforeParagraph) + " px");
			if (runtimeStyle.ParagraphListStyle != 0 && runtimeStyle.FirstLineIndent != 0f)
			{
				method_40("margin-left", xtextParagraphElement_0.OwnerDocument.ToPixel((int)runtimeStyle.FirstLineIndent) + " px");
			}
			method_63();
			if (xtextParagraphElement_0.Elements.Count > 1)
			{
				XTextParagraphElement xTextParagraphElement = xtextParagraphElement_0.method_27(imethod_48());
				foreach (XTextElement element2 in xTextParagraphElement.Elements)
				{
					element2.vmethod_18(this);
				}
			}
			else
			{
				method_15(" ");
			}
			imethod_1();
		}

		private void method_91(XTextPageInfoElement xtextPageInfoElement_0)
		{
			imethod_0("label");
			method_140(xtextPageInfoElement_0.GetType());
			method_145(xtextPageInfoElement_0);
			method_143(bool_24: true);
			method_144(bool_24: false);
			method_39();
			method_45(xtextPageInfoElement_0.RuntimeStyle.Font.Value);
			method_40("color", method_61(xtextPageInfoElement_0.RuntimeStyle.Color));
			method_63();
			string text = "";
			text = xtextPageInfoElement_0.ContentText;
			method_3(text);
			imethod_2();
		}

		private void method_92(XTextPageBreakElement xtextPageBreakElement_0)
		{
			imethod_0("div");
			method_140(xtextPageBreakElement_0.GetType());
			method_145(xtextPageBreakElement_0);
			method_39();
			method_40("page-break-after", "always");
			method_63();
			imethod_2();
		}

		private void method_93(XTextMediaElement xtextMediaElement_0)
		{
			int num = 10;
			if (imethod_34())
			{
				imethod_0("div");
				method_39();
				method_40("width", imethod_44(xtextMediaElement_0.Width) + "px");
				method_40("height", imethod_44(xtextMediaElement_0.Height) + "px");
				method_40("text-align", "center");
				method_40("border", "1px solid black");
				method_63();
				method_3(xtextMediaElement_0.FileName);
				imethod_2();
				return;
			}
			if (method_118())
			{
				imethod_0("object");
				method_19("classid", "clsid:6bf52a52-394a-11d3-b153-00c04f79faa6");
				method_19("id", xtextMediaElement_0.ClientID);
				method_140(xtextMediaElement_0.GetType());
				method_145(xtextMediaElement_0);
				method_19("type", "application/x-oleobject");
				method_19("width", imethod_44(xtextMediaElement_0.Width) + "px");
				method_19("height", imethod_44(xtextMediaElement_0.Height) + "px");
				if (!string.IsNullOrEmpty(xtextMediaElement_0.FileName))
				{
					method_6("url", xtextMediaElement_0.FileName);
				}
				method_6("EnableContextMenu", xtextMediaElement_0.EnableMediaContextMenu.ToString());
				method_6("uiMode", xtextMediaElement_0.PlayerUIMode.ToString());
				if (xtextMediaElement_0.LoopPlay)
				{
					method_6("PlayCount", "0");
				}
				imethod_0("span");
				imethod_33();
				method_19("style", "background-color:yellow;border:1px solid black");
				method_3(WriterStrings.BrowserNotSupportActiveX);
				imethod_2();
				imethod_2();
				return;
			}
			imethod_0("video");
			method_19("id", xtextMediaElement_0.ClientID);
			method_144(bool_24: false);
			method_143(bool_24: true);
			method_140(xtextMediaElement_0.GetType());
			method_145(xtextMediaElement_0);
			method_19("width", imethod_44(xtextMediaElement_0.Width) + "px");
			method_19("height", imethod_44(xtextMediaElement_0.Height) + "px");
			method_19("style", "border:1px solid black");
			if (xtextMediaElement_0.LoopPlay)
			{
				method_19("loop", "true");
			}
			if (xtextMediaElement_0.PlayerUIMode == WindowsMediaPlayerUIMode.full)
			{
				method_19("controls", "true");
			}
			if (!string.IsNullOrEmpty(xtextMediaElement_0.FileName))
			{
				imethod_0("source");
				method_19("src", xtextMediaElement_0.FileName);
				if (string.IsNullOrEmpty(xtextMediaElement_0.FileContentType))
				{
					if (xtextMediaElement_0.FileName.EndsWith(".mp4", StringComparison.CurrentCultureIgnoreCase))
					{
						method_19("type", "video/mp4");
					}
				}
				else
				{
					method_19("type", xtextMediaElement_0.FileContentType);
				}
				imethod_2();
			}
			imethod_0("span");
			imethod_33();
			method_19("align", "center");
			method_19("style", "display:inline-block;background-color:yellow;border:1px solid black;width:" + imethod_44(xtextMediaElement_0.Width) + ";height:" + imethod_44(xtextMediaElement_0.Height));
			method_3(WriterStrings.BrowserNotSupportHtml5Video);
			imethod_2();
			imethod_2();
		}

		private void method_94(XTextLabelElement xtextLabelElement_0)
		{
			int num = 10;
			string text = xtextLabelElement_0.method_16(xtextLabelElement_0.OwnerDocument.PageIndex);
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			if (imethod_36())
			{
				imethod_0("span");
				method_19("id", xtextLabelElement_0.ID);
				method_144(bool_24: false);
				method_145(xtextLabelElement_0);
				method_140(xtextLabelElement_0.GetType());
				method_137(xtextLabelElement_0);
				method_39();
				method_45(xtextLabelElement_0.RuntimeStyle.Font.Value);
				imethod_54(xtextLabelElement_0.RuntimeStyle, xtextLabelElement_0);
				method_63();
				method_3(xtextLabelElement_0.Text);
				imethod_2();
				return;
			}
			DocumentContentStyle documentContentStyle = xtextLabelElement_0.RuntimeStyle.CloneParent();
			switch (xtextLabelElement_0.Alignment)
			{
			case DCContentAlignment.MiddleCenter:
				documentContentStyle.Align = DocumentContentAlignment.Center;
				break;
			case DCContentAlignment.MiddleLeft:
				documentContentStyle.Align = DocumentContentAlignment.Left;
				break;
			case DCContentAlignment.TopLeft:
				documentContentStyle.Align = DocumentContentAlignment.Left;
				break;
			case DCContentAlignment.TopCenter:
				documentContentStyle.Align = DocumentContentAlignment.Center;
				break;
			case DCContentAlignment.TopRight:
				documentContentStyle.Align = DocumentContentAlignment.Right;
				break;
			case DCContentAlignment.BottomLeft:
				documentContentStyle.Align = DocumentContentAlignment.Left;
				break;
			case DCContentAlignment.MiddleRight:
				documentContentStyle.Align = DocumentContentAlignment.Right;
				break;
			case DCContentAlignment.BottomRight:
				documentContentStyle.Align = DocumentContentAlignment.Right;
				break;
			case DCContentAlignment.BottomCenter:
				documentContentStyle.Align = DocumentContentAlignment.Center;
				break;
			}
			documentContentStyle.Multiline = xtextLabelElement_0.Multiline;
			method_157(text, documentContentStyle.MyRuntimeStyle, xtextLabelElement_0, xtextLabelElement_0.AutoSize ? 0f : xtextLabelElement_0.Width);
			documentContentStyle.Dispose();
		}

		private void method_95(XTextInputFieldElement xtextInputFieldElement_0)
		{
			int num = 12;
			if (imethod_34())
			{
				if (!xtextInputFieldElement_0.Visible || !xtextInputFieldElement_0.vmethod_3(this))
				{
					return;
				}
				imethod_0("span");
				method_39();
				if (xtextInputFieldElement_0.SpecifyWidth != 0f)
				{
					method_40("width", imethod_44(Math.Abs(xtextInputFieldElement_0.SpecifyWidth)) + "px");
					method_40("display", "online-block");
					method_40("white-space", "nowrap");
					method_40("overflow", "hidden");
					switch (xtextInputFieldElement_0.Alignment)
					{
					case StringAlignment.Near:
						method_40("text-align", "left");
						break;
					case StringAlignment.Center:
						method_40("text-align", "center");
						break;
					case StringAlignment.Far:
						method_40("text-align", "right");
						break;
					}
				}
				if (xtextInputFieldElement_0.TextColor.A > 0)
				{
					method_40("color", method_61(xtextInputFieldElement_0.TextColor));
				}
				imethod_54(xtextInputFieldElement_0.RuntimeStyle, xtextInputFieldElement_0);
				method_45(xtextInputFieldElement_0.RuntimeStyle.Font.Value);
				if (!xtextInputFieldElement_0.OwnerDocument.Options.ViewOptions.IgnoreFieldBorderWhenPrint && string.IsNullOrEmpty(xtextInputFieldElement_0.StartBorderText) && (!xtextInputFieldElement_0.RuntimeStyle.BorderLeft || xtextInputFieldElement_0.RuntimeStyle.BorderWidth == 0f || xtextInputFieldElement_0.RuntimeStyle.BorderLeftColor.A == 0))
				{
					method_40("border-left", "1px solid transparent");
					method_40("border-radius", "3px");
				}
				if (!xtextInputFieldElement_0.OwnerDocument.Options.ViewOptions.IgnoreFieldBorderWhenPrint && string.IsNullOrEmpty(xtextInputFieldElement_0.EndBorderText) && (!xtextInputFieldElement_0.RuntimeStyle.BorderRight || xtextInputFieldElement_0.RuntimeStyle.BorderWidth == 0f || xtextInputFieldElement_0.RuntimeStyle.BorderRightColor.A == 0))
				{
					method_40("border-right", "1px solid transparent");
					method_40("border-radius", "3px");
				}
				method_63();
				if (!string.IsNullOrEmpty(xtextInputFieldElement_0.StartBorderText))
				{
					imethod_0("span");
					method_19("style", "color:" + method_61(xtextInputFieldElement_0.StartElement.RuntimeBorderColor));
					method_3(xtextInputFieldElement_0.StartBorderText);
					imethod_2();
				}
				if (!string.IsNullOrEmpty(xtextInputFieldElement_0.LabelText))
				{
					imethod_0("span");
					method_3(xtextInputFieldElement_0.LabelText);
					imethod_2();
				}
				if (xtextInputFieldElement_0.Elements.Count == 0)
				{
					if (!string.IsNullOrEmpty(xtextInputFieldElement_0.BackgroundText))
					{
						if (xtextInputFieldElement_0.RuntimePrintBackgroundText)
						{
							imethod_0("span");
							method_39();
							method_40("color", method_61(xtextInputFieldElement_0.RuntimeBackgroundTextColor));
							if (xtextInputFieldElement_0.BackgroundTextItalic == DCBooleanValueHasDefault.True)
							{
								method_40("font-style", "italic");
							}
							else if (xtextInputFieldElement_0.BackgroundTextItalic == DCBooleanValueHasDefault.False)
							{
								method_40("font-style", "normal");
							}
							method_63();
							method_3(xtextInputFieldElement_0.BackgroundText);
							imethod_2();
						}
						else if (xtextInputFieldElement_0.OwnerDocument.Options.ViewOptions.PreserveBackgroundTextWhenPrint)
						{
							imethod_0("span");
							method_19("style", "color:transparent");
							method_3(xtextInputFieldElement_0.BackgroundText);
							imethod_2();
						}
					}
				}
				else
				{
					method_104(xtextInputFieldElement_0);
				}
				if (!string.IsNullOrEmpty(xtextInputFieldElement_0.UnitText))
				{
					imethod_0("span");
					method_3(xtextInputFieldElement_0.UnitText);
					imethod_2();
				}
				if (!string.IsNullOrEmpty(xtextInputFieldElement_0.EndBorderText))
				{
					imethod_0("span");
					method_19("style", "color:" + method_61(xtextInputFieldElement_0.EndElement.RuntimeBorderColor));
					method_3(xtextInputFieldElement_0.EndBorderText);
					imethod_2();
				}
				imethod_2();
			}
			else if (imethod_36())
			{
				ListItemCollection listItemCollection = null;
				if (xtextInputFieldElement_0.FieldSettings != null && xtextInputFieldElement_0.FieldSettings.EditStyle == InputFieldEditStyle.DropdownList)
				{
					listItemCollection = xtextInputFieldElement_0.GetRuntimeListItems();
				}
				if (listItemCollection != null && listItemCollection.Count == 0)
				{
					listItemCollection = null;
				}
				Enum7 @enum = Enum7.const_0;
				if (method_128() && xtextInputFieldElement_0.FieldSettings != null && xtextInputFieldElement_0.FieldSettings.EditStyle == InputFieldEditStyle.DropdownList && !xtextInputFieldElement_0.FieldSettings.MultiSelect)
				{
					@enum = Enum7.const_1;
				}
				if (xtextInputFieldElement_0.SpecifyWidth != 0f && method_126() && @enum == Enum7.const_0)
				{
					@enum = Enum7.const_2;
				}
				float num2 = 0f;
				ListItem listItem = null;
				bool flag = true;
				if (@enum == Enum7.const_1)
				{
					if ((listItemCollection == null || listItemCollection.Count == 0) && queryListItemsEventHandler_0 != null)
					{
						QueryListItemsEventArgs queryListItemsEventArgs = new QueryListItemsEventArgs();
						queryListItemsEventArgs.PageName = method_120();
						queryListItemsEventArgs.ControlName = method_122();
						queryListItemsEventArgs.ListSourceName = xtextInputFieldElement_0.InnerListSourceName;
						queryListItemsEventHandler_0(this, queryListItemsEventArgs);
						listItemCollection = queryListItemsEventArgs.Result;
					}
					if (listItemCollection != null && listItemCollection.Count > 0)
					{
						string text = xtextInputFieldElement_0.InnerValue;
						if (string.IsNullOrEmpty(text))
						{
							text = xtextInputFieldElement_0.Text;
						}
						num2 = 10f;
						using (DCGraphics dCGraphics = xtextInputFieldElement_0.OwnerDocument.CreateDCGraphics())
						{
							int num3 = 0;
							int num4 = 0;
							foreach (ListItem item in listItemCollection)
							{
								if (listItem == null)
								{
									string text2 = item.Value;
									if (string.IsNullOrEmpty(text2))
									{
										text2 = item.Text;
									}
									if (text2 == text)
									{
										listItem = item;
									}
								}
								string text3 = item.TextInList;
								if (string.IsNullOrEmpty(text3))
								{
									text3 = item.Text;
								}
								if (!string.IsNullOrEmpty(text3))
								{
									num3 = Math.Max(num3, text3.Length);
									num4 = ((num4 != 0) ? Math.Min(num4, text3.Length) : text3.Length);
									float num5 = item.DisplayWidth = dCGraphics.MeasureString(text3, xtextInputFieldElement_0.RuntimeStyle.Font, 10000, GClass95.smethod_0()).Width;
									num2 = Math.Max(num2, item.DisplayWidth);
								}
							}
							if (num3 - num4 < 2)
							{
								num2 = 0f;
								flag = false;
							}
						}
						XTextContentElement contentElement = xtextInputFieldElement_0.ContentElement;
						if (num2 > contentElement.ClientWidth - 3f)
						{
							num2 = contentElement.ClientWidth - 3f;
						}
						else
						{
							num2 = 0f;
						}
					}
				}
				string clientID = xtextInputFieldElement_0.ClientID;
				if ((@enum == Enum7.const_2 || @enum == Enum7.const_1) && (!string.IsNullOrEmpty(xtextInputFieldElement_0.LabelText) || !string.IsNullOrEmpty(xtextInputFieldElement_0.StartBorderText)))
				{
					imethod_0("label");
					imethod_33();
					method_143(bool_24: true);
					method_144(bool_24: false);
					method_19("for", clientID);
					method_39();
					method_45(xtextInputFieldElement_0.RuntimeStyle.Font.Value);
					method_40("color", method_61(xtextInputFieldElement_0.RuntimeStyle.Color));
					method_63();
					if (!string.IsNullOrEmpty(xtextInputFieldElement_0.StartBorderText))
					{
						imethod_0("span");
						method_19("style", "color:" + method_61(xtextInputFieldElement_0.StartElement.RuntimeBorderColor));
						method_3(xtextInputFieldElement_0.StartBorderText);
						imethod_2();
					}
					method_3(xtextInputFieldElement_0.LabelText);
					imethod_2();
				}
				switch (@enum)
				{
				case Enum7.const_2:
					imethod_0("input");
					method_19("type", "text");
					if (!string.IsNullOrEmpty(xtextInputFieldElement_0.BackgroundText))
					{
						method_19("placeholder", xtextInputFieldElement_0.BackgroundText);
					}
					break;
				case Enum7.const_1:
					imethod_0("select");
					method_144(bool_24: false);
					if (flag)
					{
						method_19("autowidth", "true");
					}
					break;
				default:
					imethod_0("span");
					break;
				}
				method_19("id", clientID);
				method_19("idback", clientID);
				method_19("name", xtextInputFieldElement_0.Name);
				if (@enum != Enum7.const_1)
				{
					string text4 = "InputFieldNormal";
					if (xtextInputFieldElement_0.RuntimeContentReadonly)
					{
						text4 = " InputFieldReadonly";
					}
					method_19("class", text4);
				}
				method_140(xtextInputFieldElement_0.GetType());
				method_137(xtextInputFieldElement_0);
				method_132(xtextInputFieldElement_0);
				if (!string.IsNullOrEmpty(xtextInputFieldElement_0.ToolTip))
				{
					method_19("title", xtextInputFieldElement_0.ToolTip);
				}
				bool flag2 = false;
				bool flag3 = false;
				if (!xtextInputFieldElement_0.UserEditable || xtextInputFieldElement_0.RuntimeContentReadonly || imethod_29())
				{
					flag3 = true;
				}
				if (!xtextInputFieldElement_0.UserEditable || xtextInputFieldElement_0.RuntimeContentReadonly || imethod_29())
				{
					switch (@enum)
					{
					case Enum7.const_2:
						method_19("readonly", "true");
						break;
					case Enum7.const_1:
						method_19("disabled", "true");
						break;
					default:
						method_144(bool_24: false);
						break;
					}
				}
				else if (method_149())
				{
					XTextElement parent = xtextInputFieldElement_0.Parent;
					bool flag4 = true;
					while (parent != null)
					{
						if (!(parent is XTextInputFieldElement))
						{
							parent = parent.Parent;
							continue;
						}
						flag4 = false;
						break;
					}
					if (flag4)
					{
						method_144(bool_24: true);
						flag2 = true;
					}
				}
				bool flag5 = true;
				bool flag6 = true;
				if (@enum != Enum7.const_1 && @enum != Enum7.const_2)
				{
					flag5 = (!string.IsNullOrEmpty(xtextInputFieldElement_0.StartBorderText) || !string.IsNullOrEmpty(xtextInputFieldElement_0.LabelText) || ((!imethod_29()) ? true : false));
					flag6 = (!string.IsNullOrEmpty(xtextInputFieldElement_0.EndBorderText) || !string.IsNullOrEmpty(xtextInputFieldElement_0.UnitText) || ((!imethod_29()) ? true : false));
				}
				else
				{
					flag5 = false;
					flag6 = false;
				}
				_ = xtextInputFieldElement_0.OwnerDocument.Options.ViewOptions;
				if (!imethod_29() && method_116())
				{
					List<string> list = new List<string>();
					if (!xtextInputFieldElement_0.RuntimeContentReadonly)
					{
						list.Add("onmousedown");
					}
					if (xtextInputFieldElement_0.RuntimeEnableHighlight == EnableState.Enabled)
					{
						list.Add("onmouseenter");
						list.Add("onmouseleave");
						list.Add("onfocus");
						list.Add("onblur");
					}
					if (!xtextInputFieldElement_0.RuntimeContentReadonly)
					{
						if (!list.Contains("onfocus"))
						{
							list.Add("onfocus");
						}
						switch (@enum)
						{
						case Enum7.const_1:
							list.Add("onchange");
							if (!string.IsNullOrEmpty(xtextInputFieldElement_0.InnerListSourceName))
							{
								list.Add("onclick");
							}
							break;
						case Enum7.const_2:
							list.Add("onchange");
							list.Add("onclick");
							list.Add("ondblclick");
							break;
						default:
							list.Add("onclick");
							list.Add("ondblclick");
							break;
						}
					}
					list.Add("onkeydown");
					list.Add("onkeypress");
					foreach (string item2 in list)
					{
						method_19(item2, "DCInputFieldManager.HandleInputFieldEvent(event, this , '" + item2 + "');");
					}
				}
				bool flag7 = false;
				float num6 = 0f;
				if (xtextInputFieldElement_0.SpecifyWidth != 0f && method_126())
				{
					num6 = Math.Abs(xtextInputFieldElement_0.SpecifyWidth);
					if (@enum == Enum7.const_2 || @enum == Enum7.const_1)
					{
						num6 = num6 - xtextInputFieldElement_0.StartElement.ContentWidth - xtextInputFieldElement_0.EndElement.ContentWidth;
						if (num6 < 0f)
						{
							num6 = 0f;
						}
					}
					num6 = imethod_44(num6);
					num6 += 4f;
					if (!(xtextInputFieldElement_0.SpecifyWidth < 0f))
					{
					}
					method_19("fixedcontentwidth", num6 + "px");
					if (num6 < 20f && (flag3 || imethod_29()))
					{
						if (string.IsNullOrEmpty(xtextInputFieldElement_0.StartBorderText))
						{
							flag5 = false;
						}
						if (string.IsNullOrEmpty(xtextInputFieldElement_0.EndBorderText))
						{
							flag6 = false;
						}
					}
				}
				if (!imethod_29())
				{
					if (flag5)
					{
						method_19("hasbegin", "true");
					}
					if (flag6)
					{
						method_19("hasend", "true");
					}
				}
				if (flag7)
				{
					method_19("endtagahead", "true");
				}
				method_145(xtextInputFieldElement_0);
				method_39();
				if (xtextInputFieldElement_0.TextColor.A > 0)
				{
					method_40("color", method_61(xtextInputFieldElement_0.TextColor));
				}
				if (xtextInputFieldElement_0.SpecifyWidth != 0f && Math.Abs(xtextInputFieldElement_0.SpecifyWidth) < 40f)
				{
					method_40("border-radius", "0");
				}
				imethod_54(xtextInputFieldElement_0.RuntimeStyle, xtextInputFieldElement_0);
				method_45(xtextInputFieldElement_0.RuntimeStyle.Font.Value);
				if (@enum == Enum7.const_2 || @enum == Enum7.const_1)
				{
					if (@enum == Enum7.const_2)
					{
						if (!(num6 < 20f))
						{
						}
						RuntimeDocumentContentStyle runtimeStyle = xtextInputFieldElement_0.RuntimeStyle;
						bool flag8 = false;
						if (runtimeStyle.BorderBottom && runtimeStyle.BorderWidth > 0f && runtimeStyle.BorderColor.A > 0)
						{
							flag8 = true;
							method_49("bottom", runtimeStyle.BorderColor, (int)runtimeStyle.BorderWidth, runtimeStyle.BorderStyle);
						}
						if (runtimeStyle.BorderLeft && runtimeStyle.BorderWidth > 0f && runtimeStyle.BorderColor.A > 0)
						{
							method_49("left", runtimeStyle.BorderColor, (int)runtimeStyle.BorderWidth, runtimeStyle.BorderStyle);
						}
						else if (!flag8)
						{
							method_40("border-left", "1px solid " + method_61(xtextInputFieldElement_0.StartElement.RuntimeBorderColor));
						}
						if (runtimeStyle.BorderTop && runtimeStyle.BorderWidth > 0f && runtimeStyle.BorderColor.A > 0)
						{
							method_49("top", runtimeStyle.BorderColor, (int)runtimeStyle.BorderWidth, runtimeStyle.BorderStyle);
						}
						if (runtimeStyle.BorderRight && runtimeStyle.BorderWidth > 0f && runtimeStyle.BorderColor.A > 0)
						{
							method_49("right", runtimeStyle.BorderColor, (int)runtimeStyle.BorderWidth, runtimeStyle.BorderStyle);
						}
						else if (!flag8)
						{
							method_40("border-right", "1px solid " + method_61(xtextInputFieldElement_0.StartElement.RuntimeBorderColor));
						}
						imethod_54(xtextInputFieldElement_0.RuntimeStyle, xtextInputFieldElement_0);
					}
					if (!method_128())
					{
						method_45(xtextInputFieldElement_0.RuntimeStyle.Font.Value);
					}
				}
				if (@enum == Enum7.const_0)
				{
					if (method_126() && num6 != 0f)
					{
						method_40("display", "inline-block");
						method_40("width", num6 + "px");
						method_40("white-space", "nowrap");
						method_40("overflow", "hidden");
					}
					if (xtextInputFieldElement_0.RuntimeContentReadonly || imethod_29())
					{
						if (!flag5 && (!xtextInputFieldElement_0.RuntimeStyle.BorderLeft || xtextInputFieldElement_0.RuntimeStyle.BorderWidth == 0f || xtextInputFieldElement_0.RuntimeStyle.BorderLeftColor.A == 0))
						{
							method_40("border-left", "1px solid " + method_61(xtextInputFieldElement_0.StartElement.RuntimeBorderColor));
							method_40("border-radius", "3px");
						}
						if (!flag6 && (!xtextInputFieldElement_0.RuntimeStyle.BorderRight || xtextInputFieldElement_0.RuntimeStyle.BorderWidth == 0f || xtextInputFieldElement_0.RuntimeStyle.BorderRightColor.A == 0))
						{
							method_40("border-right", "1px solid " + method_61(xtextInputFieldElement_0.StartElement.RuntimeBorderColor));
							method_40("border-radius", "3px");
						}
					}
				}
				if ((@enum == Enum7.const_1 || @enum == Enum7.const_2) && num6 > 0f)
				{
					method_40("width", num6 + "px");
				}
				if (num6 > 0f)
				{
					switch (xtextInputFieldElement_0.Alignment)
					{
					case StringAlignment.Near:
						method_40("text-align", "left");
						break;
					case StringAlignment.Center:
						method_40("text-align", "center");
						break;
					case StringAlignment.Far:
						method_40("text-align", "right");
						break;
					}
				}
				if (!xtextInputFieldElement_0.ContentEditable || xtextInputFieldElement_0.RuntimeContentReadonly)
				{
					method_40("cursor", "default");
				}
				else if (flag2)
				{
					method_40("cursor", "text");
				}
				if (!xtextInputFieldElement_0.Visible)
				{
					method_40("display", "none");
				}
				method_63();
				if (!imethod_29() && @enum == Enum7.const_0)
				{
					method_19("bordertexcolor", method_61(xtextInputFieldElement_0.StartElement.RuntimeBorderColor));
					method_19("contentcolor", method_61(xtextInputFieldElement_0.RuntimeStyle.Color));
				}
				switch (@enum)
				{
				case Enum7.const_1:
					if ((listItemCollection == null || listItemCollection.Count == 0) && queryListItemsEventHandler_0 != null)
					{
						QueryListItemsEventArgs queryListItemsEventArgs = new QueryListItemsEventArgs();
						queryListItemsEventArgs.ListSourceName = xtextInputFieldElement_0.InnerListSourceName;
						queryListItemsEventHandler_0(xtextInputFieldElement_0, queryListItemsEventArgs);
						listItemCollection = queryListItemsEventArgs.Result;
					}
					if (listItemCollection != null && listItemCollection.Count > 0)
					{
						string text = xtextInputFieldElement_0.InnerValue;
						if (string.IsNullOrEmpty(text))
						{
							text = xtextInputFieldElement_0.Text;
						}
						foreach (ListItem item3 in listItemCollection)
						{
							imethod_0("option");
							string text2 = item3.Value;
							if (string.IsNullOrEmpty(text2))
							{
								text2 = item3.Text;
							}
							method_19("value", text2);
							if (item3 == listItem)
							{
								method_19("selected", "true");
							}
							if (item3.DisplayWidth > 0f)
							{
								method_19("pixelwidth", imethod_44(item3.DisplayWidth).ToString());
							}
							method_3(item3.Text);
							imethod_1();
						}
					}
					break;
				case Enum7.const_2:
					method_19("value", xtextInputFieldElement_0.Text);
					break;
				}
				if ((@enum == Enum7.const_0 || @enum == Enum7.const_2) && listItemCollection != null && listItemCollection.Count > 0)
				{
					int num7 = 0;
					if (method_124() || !imethod_29())
					{
						method_19("listitemcount", listItemCollection.Count.ToString());
						if (listItemCollection.GenerateTemplate)
						{
							method_19("listtemp", "1");
						}
						int num8 = 0;
						foreach (ListItem item4 in listItemCollection)
						{
							method_19("listtext" + num8, item4.Text);
							method_19("listvalue" + num8, item4.Value);
							method_19("listtextinlist" + num8, item4.TextInList);
							string text5 = string.IsNullOrEmpty(item4.TextInList) ? item4.Text : item4.TextInList;
							if (!string.IsNullOrEmpty(text5))
							{
								num7 = Math.Max(num7, Encoding.Default.GetByteCount(text5));
							}
							num8++;
						}
						if (num7 > 40)
						{
							num7 = 40;
						}
						method_19("maxbytelength", num7.ToString());
					}
				}
				if (@enum == Enum7.const_0)
				{
					Color runtimeBorderColor = xtextInputFieldElement_0.StartElement.RuntimeBorderColor;
					if (flag6 && flag7)
					{
						imethod_0("span");
						method_19("dctype", "end");
						imethod_33();
						if (string.IsNullOrEmpty(xtextInputFieldElement_0.UnitText))
						{
							method_39();
							if (method_126() && num6 != 0f)
							{
								method_40("float", "right");
							}
							method_40("color", method_61(runtimeBorderColor));
							method_63();
							if (string.IsNullOrEmpty(xtextInputFieldElement_0.EndBorderText))
							{
								method_3("]");
							}
							else
							{
								method_3(xtextInputFieldElement_0.EndBorderText);
							}
						}
						else
						{
							if (method_126() && num6 != 0f)
							{
								method_39();
								method_40("float", "right");
								method_63();
							}
							method_3(xtextInputFieldElement_0.UnitText);
							imethod_0("span");
							method_19("style", "color:" + method_61(runtimeBorderColor));
							if (string.IsNullOrEmpty(xtextInputFieldElement_0.EndBorderText))
							{
								method_3("]");
							}
							else
							{
								method_3(xtextInputFieldElement_0.EndBorderText);
							}
							imethod_2();
						}
						imethod_2();
					}
					if (flag5)
					{
						imethod_0("span");
						method_19("dctype", "start");
						imethod_33();
						if (string.IsNullOrEmpty(xtextInputFieldElement_0.LabelText))
						{
							method_39();
							if (method_126() && num6 != 0f)
							{
								method_40("float", "left");
							}
							method_40("color", method_61(runtimeBorderColor));
							method_63();
							if (string.IsNullOrEmpty(xtextInputFieldElement_0.StartBorderText))
							{
								method_3("[");
							}
							else
							{
								method_3(xtextInputFieldElement_0.StartBorderText);
							}
						}
						else
						{
							method_39();
							if (method_126() && num6 != 0f)
							{
								method_40("float", "left");
							}
							method_40("color", method_61(runtimeBorderColor));
							method_63();
							imethod_0("span");
							if (string.IsNullOrEmpty(xtextInputFieldElement_0.StartBorderText))
							{
								method_3("[");
							}
							else
							{
								method_3(xtextInputFieldElement_0.StartBorderText);
							}
							imethod_2();
							method_3(xtextInputFieldElement_0.LabelText);
						}
						imethod_2();
					}
					if (xtextInputFieldElement_0.Elements.Count == 0)
					{
						if (!flag5 || !flag6)
						{
							method_3(" ");
							method_18("&nbsp;");
						}
					}
					else
					{
						method_104(xtextInputFieldElement_0);
					}
					if (xtextInputFieldElement_0.Elements.Count == 0 && !string.IsNullOrEmpty(xtextInputFieldElement_0.BackgroundText))
					{
						string backgroundText = xtextInputFieldElement_0.BackgroundText;
						for (int i = 0; i < backgroundText.Length; i++)
						{
							char c = backgroundText[i];
							imethod_0("span");
							method_19("dctype", "backgroundtext");
							method_19("text", c.ToString());
							imethod_33();
							method_19("style", "color:" + method_61(xtextInputFieldElement_0.RuntimeBackgroundTextColor));
							method_3(c.ToString());
							imethod_2();
						}
					}
					if (flag6)
					{
						imethod_0("span");
						method_19("dctype", "end");
						imethod_33();
						if (string.IsNullOrEmpty(xtextInputFieldElement_0.UnitText))
						{
							method_39();
							if (method_126() && num6 != 0f)
							{
								method_40("float", "right");
							}
							method_40("color", method_61(runtimeBorderColor));
							method_63();
							if (string.IsNullOrEmpty(xtextInputFieldElement_0.EndBorderText))
							{
								method_3("]");
							}
							else
							{
								method_3(xtextInputFieldElement_0.EndBorderText);
							}
						}
						else
						{
							if (method_126() && num6 != 0f)
							{
								method_39();
								method_40("float", "right");
								method_63();
							}
							method_3(xtextInputFieldElement_0.UnitText);
							imethod_0("span");
							method_19("style", "color:" + method_61(runtimeBorderColor));
							if (string.IsNullOrEmpty(xtextInputFieldElement_0.EndBorderText))
							{
								method_3("]");
							}
							else
							{
								method_3(xtextInputFieldElement_0.EndBorderText);
							}
							imethod_2();
						}
						imethod_2();
					}
				}
				if ((@enum == Enum7.const_1 || @enum == Enum7.const_2) && (!string.IsNullOrEmpty(xtextInputFieldElement_0.UnitText) || !string.IsNullOrEmpty(xtextInputFieldElement_0.EndBorderText)))
				{
					imethod_0("label");
					imethod_33();
					method_143(bool_24: true);
					method_144(bool_24: false);
					method_19("for", clientID);
					method_39();
					method_45(xtextInputFieldElement_0.RuntimeStyle.Font.Value);
					method_40("color", method_61(xtextInputFieldElement_0.RuntimeStyle.Color));
					method_63();
					method_3(xtextInputFieldElement_0.UnitText);
					if (!string.IsNullOrEmpty(xtextInputFieldElement_0.EndBorderText))
					{
						imethod_0("span");
						method_19("style", "color:" + method_61(xtextInputFieldElement_0.StartElement.RuntimeBorderColor));
						method_3(xtextInputFieldElement_0.EndBorderText);
						imethod_2();
					}
					imethod_2();
				}
				imethod_2();
			}
			else if (imethod_46().method_16())
			{
				if (method_146().Contains(xtextInputFieldElement_0))
				{
					return;
				}
				method_146().Add(xtextInputFieldElement_0);
				if (!string.IsNullOrEmpty(xtextInputFieldElement_0.LabelText))
				{
					method_156(xtextInputFieldElement_0, xtextInputFieldElement_0.LabelText, xtextInputFieldElement_0.RuntimeStyle, xtextInputFieldElement_0.ID);
				}
				if (xtextInputFieldElement_0.FieldSettings != null && xtextInputFieldElement_0.FieldSettings.EditStyle == InputFieldEditStyle.DropdownList)
				{
					imethod_0("select");
					method_19("id", xtextInputFieldElement_0.ID);
					method_19("name", xtextInputFieldElement_0.Name);
					method_39();
					imethod_54(xtextInputFieldElement_0.RuntimeStyle, xtextInputFieldElement_0);
					method_63();
					if (xtextInputFieldElement_0.FieldSettings.ListSource != null && xtextInputFieldElement_0.FieldSettings.ListSource.Items != null)
					{
						int num9 = 0;
						foreach (ListItem item5 in xtextInputFieldElement_0.FieldSettings.ListSource.Items)
						{
							imethod_0("option");
							method_19("value", item5.Value);
							if (num9 == xtextInputFieldElement_0.SelectedIndex)
							{
								method_19("selected", "true");
							}
							method_3(item5.Text);
							imethod_1();
							num9++;
						}
					}
					imethod_1();
				}
				else if (xtextInputFieldElement_0.FieldSettings != null && (xtextInputFieldElement_0.FieldSettings.EditStyle == InputFieldEditStyle.Date || xtextInputFieldElement_0.FieldSettings.EditStyle == InputFieldEditStyle.DateTime || xtextInputFieldElement_0.FieldSettings.EditStyle == InputFieldEditStyle.DateTimeWithoutSecond || xtextInputFieldElement_0.FieldSettings.EditStyle == InputFieldEditStyle.Time))
				{
					imethod_0("input");
					method_19("id", xtextInputFieldElement_0.ID);
					method_19("name", xtextInputFieldElement_0.Name);
					method_19("type", "input");
					if (!string.IsNullOrEmpty(xtextInputFieldElement_0.BackgroundText))
					{
						method_19("placeholder", xtextInputFieldElement_0.BackgroundText);
					}
					if (!string.IsNullOrEmpty(xtextInputFieldElement_0.ToolTip))
					{
						method_19("title", xtextInputFieldElement_0.ToolTip);
					}
					method_39();
					imethod_54(xtextInputFieldElement_0.RuntimeStyle, xtextInputFieldElement_0);
					float num5 = xtextInputFieldElement_0.EndElement.AbsLeft + (0f - xtextInputFieldElement_0.StartElement.AbsLeft);
					if (xtextInputFieldElement_0.Parent is XTextTableCellElement && xtextInputFieldElement_0.Parent.Elements.Count <= 2)
					{
						num5 = xtextInputFieldElement_0.Parent.ClientWidth;
					}
					method_40("width", imethod_44(num5) + "px");
					method_63();
					imethod_1();
					imethod_0("input");
					method_19("type", "button");
					method_19("value", "浏览");
					method_19("onclick", "DCBrowse" + xtextInputFieldElement_0.FieldSettings.EditStyle.ToString() + "('" + xtextInputFieldElement_0.ID + "')");
					imethod_1();
				}
				else
				{
					bool flag9;
					if (flag9 = (xtextInputFieldElement_0.StartElement.OwnerLine != xtextInputFieldElement_0.EndElement.OwnerLine && xtextInputFieldElement_0.Elements.Count > 0))
					{
						imethod_0("textarea");
						float num5 = xtextInputFieldElement_0.EndElement.AbsLeft - xtextInputFieldElement_0.StartElement.AbsLeft;
					}
					else
					{
						imethod_0("input");
						method_19("type", "input");
						if (!string.IsNullOrEmpty(xtextInputFieldElement_0.BackgroundText))
						{
							method_19("placeholder", xtextInputFieldElement_0.BackgroundText);
						}
					}
					if (!string.IsNullOrEmpty(xtextInputFieldElement_0.ToolTip))
					{
						method_19("title", xtextInputFieldElement_0.ToolTip);
					}
					method_19("id", xtextInputFieldElement_0.ID);
					method_19("name", xtextInputFieldElement_0.Name);
					method_39();
					imethod_54(xtextInputFieldElement_0.RuntimeStyle, xtextInputFieldElement_0);
					if (flag9)
					{
						float num5 = xtextInputFieldElement_0.ContentElement.ClientWidth;
						method_40("width", imethod_44(num5) + "px");
						float float_ = xtextInputFieldElement_0.EndElement.OwnerLine.AbsBottom - xtextInputFieldElement_0.StartElement.OwnerLine.AbsTop;
						method_40("height", imethod_44(float_) + "px");
					}
					else if (xtextInputFieldElement_0.SpecifyWidth != 0f)
					{
						method_40("width", imethod_44(Math.Abs(xtextInputFieldElement_0.SpecifyWidth)) + "px");
					}
					else
					{
						float num5 = xtextInputFieldElement_0.EndElement.AbsLeft - xtextInputFieldElement_0.StartElement.AbsLeft;
						if (xtextInputFieldElement_0.Parent is XTextTableCellElement && xtextInputFieldElement_0.Parent.Elements.Count <= 2)
						{
							num5 = xtextInputFieldElement_0.Parent.ClientWidth;
						}
						method_40("width", imethod_44(num5) + "px");
					}
					method_63();
					string text3 = xtextInputFieldElement_0.Text;
					if (!string.IsNullOrEmpty(text3))
					{
						if (flag9)
						{
							method_3(text3);
						}
						else
						{
							method_19("value", text3);
						}
					}
					if (flag9)
					{
						imethod_2();
					}
					else
					{
						imethod_1();
					}
				}
				if (!string.IsNullOrEmpty(xtextInputFieldElement_0.UnitText))
				{
					method_156(xtextInputFieldElement_0, xtextInputFieldElement_0.UnitText, xtextInputFieldElement_0.RuntimeStyle, xtextInputFieldElement_0.ID);
				}
			}
			else
			{
				method_104(xtextInputFieldElement_0);
			}
		}

		private static Graphics smethod_2()
		{
			if (graphics_0 == null)
			{
				Bitmap image = new Bitmap(1, 1);
				graphics_0 = Graphics.FromImage(image);
			}
			return graphics_0;
		}

		private void method_96(XTextImageElement xtextImageElement_0)
		{
			int num = 4;
			if (xtextImageElement_0.HasAdditionalShape && xtextImageElement_0.Image != null && xtextImageElement_0.Image.Value != null)
			{
				GClass357 gClass = method_66(xtextImageElement_0.Image.Value, null);
				xtextImageElement_0.InnerNativeImageSource = gClass.method_0();
			}
			xtextImageElement_0.InnerHasNoImage = (xtextImageElement_0.Image == null || !xtextImageElement_0.Image.HasContent);
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			string text = method_20();
			if (text != null && text.Length > 0)
			{
				dictionary["title"] = text;
			}
			switch (xtextImageElement_0.VAlign)
			{
			case VerticalAlignStyle.Top:
				dictionary["align"] = "top";
				break;
			case VerticalAlignStyle.Middle:
				dictionary["align"] = "middle";
				break;
			case VerticalAlignStyle.Bottom:
				dictionary["align"] = "bottom";
				break;
			}
			if (xtextImageElement_0.InnerHasNoImage && !string.IsNullOrEmpty(imethod_31()))
			{
				dictionary["src"] = imethod_31() + "?dcwritergetnoneimage=" + xtextImageElement_0.OwnerDocument.ToPixel(xtextImageElement_0.Width) + "," + xtextImageElement_0.OwnerDocument.ToPixel(xtextImageElement_0.Height);
			}
			method_161(xtextImageElement_0, dictionary);
		}

		private void method_97(XTextHorizontalLineElement xtextHorizontalLineElement_0)
		{
			int num = 19;
			imethod_0("hr");
			method_19("id", xtextHorizontalLineElement_0.ID);
			method_145(xtextHorizontalLineElement_0);
			method_19("color", method_61(xtextHorizontalLineElement_0.RuntimeStyle.Color));
			method_19("size", method_151(xtextHorizontalLineElement_0.LineSize).ToString());
			method_39();
			if (xtextHorizontalLineElement_0.LineLengthInCM > 0f)
			{
				method_40("width", xtextHorizontalLineElement_0.LineLengthInCM + "cm");
			}
			method_40("margin-top", "1px");
			if (method_28() == XWebBrowsersStyle.InternetExplorer8)
			{
				method_40("border-width", "0");
			}
			method_63();
			imethod_1();
		}

		private void method_98(XTextFieldBorderElement xtextFieldBorderElement_0)
		{
			int num = 18;
			XTextInputFieldElementBase xTextInputFieldElementBase = (XTextInputFieldElementBase)xtextFieldBorderElement_0.Parent;
			if (!imethod_34())
			{
				return;
			}
			float num2 = 0f;
			if (xtextFieldBorderElement_0.Width > xtextFieldBorderElement_0.ContentWidth)
			{
				num2 = xtextFieldBorderElement_0.Width;
			}
			if (xtextFieldBorderElement_0 == xTextInputFieldElementBase.StartElement)
			{
				if (!string.IsNullOrEmpty(xTextInputFieldElementBase.LabelText) || num2 > 6f)
				{
					string text = xTextInputFieldElementBase.LabelText;
					if (string.IsNullOrEmpty(text))
					{
						text = " ";
					}
					DocumentContentStyle documentContentStyle = xTextInputFieldElementBase.RuntimeStyle.CloneParent();
					documentContentStyle.BorderWidth = 0f;
					documentContentStyle.BackgroundColor = Color.Empty;
					method_157(text, documentContentStyle.MyRuntimeStyle, xTextInputFieldElementBase, num2);
				}
			}
			else if (xtextFieldBorderElement_0 == xTextInputFieldElementBase.EndElement && (!string.IsNullOrEmpty(xTextInputFieldElementBase.UnitText) || num2 > 6f))
			{
				string text = xTextInputFieldElementBase.UnitText;
				if (string.IsNullOrEmpty(text))
				{
					text = " ";
				}
				DocumentContentStyle documentContentStyle = xTextInputFieldElementBase.RuntimeStyle.CloneParent();
				documentContentStyle.BorderWidth = 0f;
				documentContentStyle.BackgroundColor = Color.Empty;
				method_157(text, documentContentStyle.MyRuntimeStyle, xTextInputFieldElementBase, num2);
			}
		}

		private void method_99(XTextDocumentBodyElement xtextDocumentBodyElement_0)
		{
			float tickCountFloat = CountDown.GetTickCountFloat();
			xtextDocumentBodyElement_0.method_52(this);
			tickCountFloat = CountDown.GetTickCountFloat() - tickCountFloat;
		}

		private void method_100(XTextDocument xtextDocument_1)
		{
			xtextDocument_1.States.RenderMode = DocumentRenderMode.Html;
			method_42(xtextDocument_1.DefaultStyle.Font.Value);
			method_104(xtextDocument_1);
		}

		private void method_101(XTextDirectoryFieldElement xtextDirectoryFieldElement_0)
		{
			int num = 16;
			xtextDirectoryFieldElement_0.method_35(bool_21: false);
			imethod_0("div");
			method_19("id", xtextDirectoryFieldElement_0.ClientID);
			method_140(xtextDirectoryFieldElement_0.GetType());
			method_145(xtextDirectoryFieldElement_0);
			method_144(bool_24: false);
			method_143(bool_24: true);
			method_39();
			method_63();
			foreach (XTextElement element in xtextDirectoryFieldElement_0.Elements)
			{
				XTextLabelElement xTextLabelElement = element as XTextLabelElement;
				if (xTextLabelElement != null && xTextLabelElement.LinkInfo != null)
				{
					imethod_0("div");
					XTextDirectoryFieldElement.GClass4 gClass = (XTextDirectoryFieldElement.GClass4)xTextLabelElement.Tag;
					method_39();
					method_40("background-color", "#cccccc");
					method_40("margin-left", Convert.ToString(gClass.method_4() * 20) + "px");
					method_63();
					imethod_0("a");
					method_19("href", xTextLabelElement.LinkInfo.Reference);
					method_19("title", xTextLabelElement.LinkInfo.Title);
					method_39();
					method_45(xtextDirectoryFieldElement_0.RuntimeStyle.Font.Value);
					method_63();
					method_3(xTextLabelElement.LinkInfo.Title);
					imethod_2();
					imethod_2();
				}
			}
			imethod_2();
		}

		private void method_102(XTextCustomShapeElement xtextCustomShapeElement_0)
		{
			method_160(xtextCustomShapeElement_0);
		}

		private void method_103(XTextControlHostElement xtextControlHostElement_0)
		{
			int num = 11;
			if (xtextControlHostElement_0.RuntimeControlType == HostedControlType.OCX)
			{
				imethod_0("object");
				method_140(xtextControlHostElement_0.GetType());
				method_145(xtextControlHostElement_0);
				string text = xtextControlHostElement_0.TypeFullName;
				if (text != null)
				{
					if (text.StartsWith("OCX:"))
					{
						text = text.Substring(4);
					}
					method_19("classid", "clsid:" + text);
				}
				method_19("width", imethod_44(xtextControlHostElement_0.Width) + "px");
				method_19("height", imethod_44(xtextControlHostElement_0.Height) + "px");
				if (xtextControlHostElement_0.Parameters != null && xtextControlHostElement_0.Parameters.Count > 0)
				{
					foreach (ObjectParameter parameter in xtextControlHostElement_0.Parameters)
					{
						method_6(parameter.Name, parameter.Value);
					}
				}
				imethod_0("span");
				method_3(WriterStrings.BrowserNotSupportActiveX);
				imethod_2();
				imethod_2();
			}
			else
			{
				imethod_0("span");
				method_19("id", xtextControlHostElement_0.ClientID);
				method_140(xtextControlHostElement_0.GetType());
				method_143(bool_24: true);
				method_144(bool_24: false);
				method_145(xtextControlHostElement_0);
				method_39();
				method_40("border", "1px solid black");
				method_40("background-color", "gray");
				method_40("width", imethod_44(xtextControlHostElement_0.Width) + "px");
				method_40("height", imethod_44(xtextControlHostElement_0.Height) + "px");
				method_40("display", "inline-block");
				method_45(xtextControlHostElement_0.OwnerDocument.DefaultFont.Value);
				method_63();
				method_3(xtextControlHostElement_0.TypeFullName);
				imethod_2();
			}
		}

		private void method_104(XTextContainerElement xtextContainerElement_0)
		{
			method_105(xtextContainerElement_0);
		}

		private void method_105(XTextContainerElement xtextContainerElement_0)
		{
			int num = 8;
			XTextElementList xTextElementList = WriterUtils.smethod_61(xtextContainerElement_0.Elements, imethod_48(), this, imethod_38());
			if (xTextElementList != null && xTextElementList.Count > 0)
			{
				foreach (XTextElement item in xTextElementList)
				{
					if (!imethod_48() || item.HasSelection)
					{
						if (item is XTextParagraphFlagElement)
						{
							method_17("br", string.Empty);
						}
						else
						{
							item.vmethod_18(this);
						}
					}
				}
			}
		}

		private void method_106(XTextCheckBoxElementBase xtextCheckBoxElementBase_0)
		{
			int num = 0;
			imethod_0("span");
			method_39();
			XFontValue xFontValue = xtextCheckBoxElementBase_0.RuntimeStyle.Font.Clone();
			xFontValue.Name = "Wingdings";
			method_45(xFontValue.Value);
			if (xtextCheckBoxElementBase_0.RuntimeStyle.Color.A != 0)
			{
				method_40("color", method_61(xtextCheckBoxElementBase_0.RuntimeStyle.Color));
			}
			method_63();
			if (xtextCheckBoxElementBase_0.ControlStyle != 0)
			{
			}
			if (xtextCheckBoxElementBase_0.RuntimeVisualStyle == CheckBoxVisualStyle.CheckBox || xtextCheckBoxElementBase_0.RuntimeVisualStyle == CheckBoxVisualStyle.SystemCheckBox)
			{
				if (xtextCheckBoxElementBase_0.Checked)
				{
					method_5('\uf0fe');
				}
				else
				{
					method_5('\uf06f');
				}
			}
			else if (xtextCheckBoxElementBase_0.Checked)
			{
				method_5('\uf0a4');
			}
			else
			{
				method_5('\uf0a1');
			}
			imethod_2();
		}

		private void method_107(XTextCheckBoxElementBase xtextCheckBoxElementBase_0)
		{
			int num = 12;
			string clientID = xtextCheckBoxElementBase_0.ClientID;
			imethod_0("span");
			method_19("id", clientID + "_label");
			imethod_33();
			method_144(bool_24: false);
			method_39();
			method_45(xtextCheckBoxElementBase_0.RuntimeStyle.Font.Value);
			method_40("cursor", "default");
			method_63();
			if (!xtextCheckBoxElementBase_0.Readonly && !imethod_29())
			{
				method_19("onclick", "DCWriterControllerEditor.OnLabelClick('" + clientID + "');");
			}
			method_3(xtextCheckBoxElementBase_0.Caption);
			imethod_2();
		}

		private void method_108(XTextCheckBoxElementBase xtextCheckBoxElementBase_0)
		{
			int num = 4;
			if (imethod_46().method_16() || imethod_36())
			{
				string clientID = xtextCheckBoxElementBase_0.ClientID;
				if (!xtextCheckBoxElementBase_0.CheckAlignLeft)
				{
					method_107(xtextCheckBoxElementBase_0);
				}
				bool flag;
				if (flag = (imethod_36() && !method_149()))
				{
					imethod_0("span");
					method_144(bool_24: false);
				}
				imethod_0("input");
				if (xtextCheckBoxElementBase_0.ControlStyle == CheckBoxControlStyle.CheckBox)
				{
					method_19("type", "checkbox");
				}
				else
				{
					method_19("type", "radio");
				}
				method_140(xtextCheckBoxElementBase_0.GetType());
				method_19("value", xtextCheckBoxElementBase_0.CheckedValue);
				if (xtextCheckBoxElementBase_0.Checked)
				{
					method_19("checked", "true");
				}
				if (imethod_36())
				{
					method_144(bool_24: false);
					method_143(bool_24: true);
				}
				if (xtextCheckBoxElementBase_0.Readonly || imethod_29())
				{
					method_19("disabled", "true");
				}
				method_19("id", clientID);
				method_19("name", xtextCheckBoxElementBase_0.Name);
				if (!string.IsNullOrEmpty(xtextCheckBoxElementBase_0.ToolTip))
				{
					method_19("title", xtextCheckBoxElementBase_0.ToolTip);
				}
				method_145(xtextCheckBoxElementBase_0);
				method_137(xtextCheckBoxElementBase_0);
				method_132(xtextCheckBoxElementBase_0);
				if (!xtextCheckBoxElementBase_0.Readonly && !imethod_29())
				{
					method_19("onclick", "DCWriterControllerEditor.HandleCheckedChanged( event , this);DCInputFieldManager.executClientJavaScript( event , this , 'click');");
					method_19("ondblclick", "DCInputFieldManager.executClientJavaScript( event , this , 'dblclick');");
					string effectTargetElementIDs = xtextCheckBoxElementBase_0.OwnerDocument.ElementIDForEditableDependentExecuter.GetEffectTargetElementIDs(xtextCheckBoxElementBase_0);
					if (!string.IsNullOrEmpty(effectTargetElementIDs))
					{
						method_19("editabletargetids", effectTargetElementIDs);
					}
				}
				imethod_1();
				if (flag)
				{
					imethod_2();
				}
				if (xtextCheckBoxElementBase_0.CheckAlignLeft)
				{
					method_107(xtextCheckBoxElementBase_0);
				}
			}
			else
			{
				if (xtextCheckBoxElementBase_0.CheckAlignLeft)
				{
					method_106(xtextCheckBoxElementBase_0);
				}
				if (!string.IsNullOrEmpty(xtextCheckBoxElementBase_0.Text))
				{
					method_157(xtextCheckBoxElementBase_0.Text, xtextCheckBoxElementBase_0.RuntimeStyle, xtextCheckBoxElementBase_0, 0f);
				}
				if (!xtextCheckBoxElementBase_0.CheckAlignLeft)
				{
					method_106(xtextCheckBoxElementBase_0);
				}
			}
		}

		private void method_109(XTextButtonElement xtextButtonElement_0)
		{
			imethod_0("input");
			method_19("type", "button");
			method_19("id", xtextButtonElement_0.ClientID);
			method_140(xtextButtonElement_0.GetType());
			method_145(xtextButtonElement_0);
			method_143(bool_24: true);
			method_144(bool_24: false);
			method_133(xtextButtonElement_0, "onclick");
			method_133(xtextButtonElement_0, "ondblclick");
			method_132(xtextButtonElement_0);
			method_19("value", xtextButtonElement_0.Text);
			method_39();
			method_40("width", imethod_44(xtextButtonElement_0.Width) + "px");
			method_40("height", imethod_44(xtextButtonElement_0.Height) + "px");
			imethod_54(xtextButtonElement_0.RuntimeStyle, xtextButtonElement_0);
			method_63();
			imethod_1();
		}

		public Class57()
		{
			method_44(bool_8: true);
		}

		public int method_110()
		{
			return int_2;
		}

		public void method_111(int int_6)
		{
			int_2 = int_6;
		}

		public int method_112()
		{
			return int_3;
		}

		public void method_113(int int_6)
		{
			int_3 = int_6;
		}

		public bool method_114()
		{
			return bool_8;
		}

		public void method_115(bool bool_24)
		{
			bool_8 = bool_24;
		}

		public bool method_116()
		{
			return bool_9;
		}

		public void method_117(bool bool_24)
		{
			bool_9 = bool_24;
		}

		public bool method_118()
		{
			return bool_10;
		}

		public void method_119(bool bool_24)
		{
			bool_10 = bool_24;
		}

		public string method_120()
		{
			return string_6;
		}

		public void method_121(string string_10)
		{
			string_6 = string_10;
		}

		public string method_122()
		{
			return string_7;
		}

		public void method_123(string string_10)
		{
			string_7 = string_10;
		}

		public bool method_124()
		{
			return bool_11;
		}

		public void method_125(bool bool_24)
		{
			bool_11 = bool_24;
		}

		public bool imethod_29()
		{
			return bool_12;
		}

		public void imethod_30(bool bool_24)
		{
			bool_12 = bool_24;
		}

		public bool method_126()
		{
			return bool_13;
		}

		public void method_127(bool bool_24)
		{
			bool_13 = bool_24;
		}

		public string imethod_31()
		{
			return string_8;
		}

		public void imethod_32(string string_10)
		{
			string_8 = string_10;
		}

		public bool method_128()
		{
			return bool_14;
		}

		public void method_129(bool bool_24)
		{
			bool_14 = bool_24;
		}

		public bool method_130()
		{
			return bool_15;
		}

		public void method_131(bool bool_24)
		{
			bool_15 = bool_24;
		}

		public void method_132(XTextElement xtextElement_0)
		{
			int num = 0;
			if (!imethod_34())
			{
				foreach (Class56 item in list_0)
				{
					if (item.method_0() == xtextElement_0)
					{
						method_19("fname_" + item.method_2(), item.method_4());
					}
				}
			}
		}

		public bool method_133(XTextElement xtextElement_0, string string_10)
		{
			int num = 2;
			StringBuilder stringBuilder = new StringBuilder();
			foreach (Class56 item in list_0)
			{
				if (item.method_0() == xtextElement_0 && item.method_2() == string_10)
				{
					stringBuilder.Append(item.method_4() + "();");
				}
			}
			if (stringBuilder.Length > 0)
			{
				method_19(string_10, stringBuilder.ToString());
				return true;
			}
			return false;
		}

		public bool method_134(XTextDocument xtextDocument_1)
		{
			int num = 16;
			if (imethod_29())
			{
				return false;
			}
			if (xtextDocument_1 == null)
			{
				throw new ArgumentNullException("document");
			}
			if (!XTextDocument.smethod_13(GEnum6.const_125))
			{
				return false;
			}
			xtextDocument_1.ElementIDForEditableDependentExecuter.RefreshState();
			if (!string.IsNullOrEmpty(xtextDocument_1.GlobalJavaScript))
			{
				method_7(xtextDocument_1.GlobalJavaScript);
			}
			if (xtextDocument_1.GlobalJavaScriptReferences != null)
			{
				foreach (string globalJavaScriptReference in xtextDocument_1.GlobalJavaScriptReferences)
				{
					if (!string.IsNullOrEmpty(globalJavaScriptReference))
					{
						method_8(globalJavaScriptReference);
					}
				}
			}
			if (!xtextDocument_1.Options.BehaviorOptions.EnableExpression)
			{
				return false;
			}
			StringBuilder stringBuilder = new StringBuilder();
			list_0 = new List<Class56>();
			foreach (XTextContainerElement item in xtextDocument_1.GetElementsByType(typeof(XTextContainerElement)))
			{
				if (!string.IsNullOrEmpty(item.JavaScriptForClick))
				{
					string text = item.JavaScriptForClick.Trim();
					if (text.Length > 0)
					{
						list_0.Add(new Class56(item, "onclick", text));
					}
				}
				if (!string.IsNullOrEmpty(item.JavaScriptForDoubleClick))
				{
					string text = item.JavaScriptForDoubleClick.Trim();
					if (text.Length > 0)
					{
						list_0.Add(new Class56(item, "ondblclick", text));
					}
				}
			}
			foreach (XTextObjectElement item2 in xtextDocument_1.GetElementsByType(typeof(XTextObjectElement)))
			{
				if (!string.IsNullOrEmpty(item2.JavaScriptForClick))
				{
					string text = item2.JavaScriptForClick.Trim();
					if (text.Length > 0)
					{
						list_0.Add(new Class56(item2, "onclick", text));
					}
				}
				if (!string.IsNullOrEmpty(item2.JavaScriptForDoubleClick))
				{
					string text = item2.JavaScriptForDoubleClick.Trim();
					if (text.Length > 0)
					{
						list_0.Add(new Class56(item2, "ondblclick", text));
					}
				}
			}
			if (list_0.Count > 0)
			{
				stringBuilder.AppendLine();
				foreach (Class56 item3 in list_0)
				{
					item3.method_5("dc_" + item3.method_2() + Convert.ToString(int_4++));
					stringBuilder.AppendLine("document.body." + item3.method_4() + " = function( eventObject , eventSource , eventParameter )");
					stringBuilder.AppendLine("{");
					stringBuilder.AppendLine(item3.method_6());
					stringBuilder.AppendLine("}");
				}
			}
			List<GClass39> list = new List<GClass39>();
			if (xtextDocument_1.ExpressionExecuter != null)
			{
				xtextDocument_1.ExpressionExecuter.imethod_3();
				if (xtextDocument_1.ExpressionExecuter is Class55)
				{
					list.AddRange(((Class55)xtextDocument_1.ExpressionExecuter).method_7());
				}
			}
			foreach (XTextInputFieldElement item4 in xtextDocument_1.GetElementsByType(typeof(XTextInputFieldElement)))
			{
				string text2 = item4.DefaultEventExpression;
				if (!string.IsNullOrEmpty(text2))
				{
					StringBuilder stringBuilder2 = new StringBuilder();
					while (true)
					{
						int num2 = text2.IndexOf("value", StringComparison.CurrentCultureIgnoreCase);
						if (num2 < 0)
						{
							break;
						}
						char c = '\0';
						if (num2 > 0)
						{
							c = text2[num2 - 1];
						}
						char c2 = '\0';
						if (num2 + 5 < text2.Length)
						{
							c2 = text2[num2 + 5];
						}
						bool flag = false;
						if (!char.IsLetterOrDigit(c) && !char.IsLetterOrDigit(c2) && c != '\'' && c2 != '\'' && c != '[' && c2 != ']')
						{
							flag = true;
						}
						stringBuilder2.Append(text2.Substring(0, num2));
						text2 = text2.Substring(num2 + 5);
						if (flag)
						{
							stringBuilder2.Append("[");
						}
						stringBuilder2.Append("value");
						if (flag)
						{
							stringBuilder2.Append("]");
						}
					}
					if (text2.Length > 0)
					{
						stringBuilder2.Append(text2);
					}
					GClass39 gClass = new GClass39();
					gClass.method_5(item4);
					gClass.method_3(item4.OwnerDocument.GetNextElement(item4, typeof(XTextFieldElementBase), includeHiddenElement: true));
					if (gClass.method_2() != null)
					{
						gClass.method_9(stringBuilder2.ToString());
						gClass.method_7("VISIBLE");
						gClass.method_17();
						list.Add(gClass);
					}
				}
			}
			StringBuilder stringBuilder3 = new StringBuilder();
			if (list.Count > 0)
			{
				foreach (GClass39 item5 in list)
				{
					int_4++;
					string text3 = "DCExp" + int_4;
					if (stringBuilder3.Length > 0)
					{
						stringBuilder3.Append(",");
					}
					stringBuilder3.Append(text3);
					string str = smethod_6(item5);
					stringBuilder.AppendLine("/* from " + item5.method_2().ID + "*/");
					stringBuilder.AppendLine("document.body." + text3 + "= function()");
					stringBuilder.AppendLine("{");
					stringBuilder.AppendLine("var DCT = function( id ) {return DCWriterExpressionManager.GetElementTextForExpression( id );};");
					stringBuilder.AppendLine("var DCN = function( id ) {var v = DCWriterExpressionManager.GetElementNumericValueForExpression( id ); if( isNaN( v )) return 0; else return v ;};");
					stringBuilder.AppendLine("var DCRT = function( name ) {return DCWriterExpressionManager.GetCheckRadioBoxElementValueForExpression( name , false );};");
					stringBuilder.AppendLine("var DCRN = function( name ) {return DCWriterExpressionManager.GetCheckRadioBoxElementValueForExpression( name , true );};");
					stringBuilder.AppendLine("var expResult = " + str + ";");
					XTextElement xTextElement = smethod_7(item5.method_2());
					if (item5.method_6() == "VISIBLE")
					{
						stringBuilder.AppendLine("DCWriterExpressionManager.SetExpressionVisibleResult( \"" + xTextElement.ClientID + "\" , expResult );");
					}
					else
					{
						stringBuilder.AppendLine("DCWriterExpressionManager.SetExpressionResult( \"" + xTextElement.ClientID + "\" , expResult );");
					}
					stringBuilder.AppendLine("};");
					XTextElementList xTextElementList = item5.method_13();
					foreach (XTextElement item6 in xTextElementList)
					{
						XTextElement key = smethod_7(item6);
						List<string> list2 = null;
						if (dictionary_2.ContainsKey(key))
						{
							list2 = dictionary_2[key];
						}
						else
						{
							list2 = new List<string>();
							dictionary_2[key] = list2;
						}
						if (!list2.Contains(text3))
						{
							list2.Add(text3);
						}
					}
				}
			}
			List<CopySourceExecuteInfo> list3 = xtextDocument_1.CopySourceExecuter.imethod_3();
			if (list3 != null && list3.Count > 0)
			{
				foreach (CopySourceExecuteInfo item7 in list3)
				{
					if ((string.IsNullOrEmpty(item7.SourcePropertyName) || string.Compare(item7.SourcePropertyName, "Text", ignoreCase: true) == 0) && (string.IsNullOrEmpty(item7.DescPropertyName) || string.Compare(item7.DescPropertyName, "EditorTextExt", ignoreCase: true) == 0))
					{
						int_4++;
						string text3 = "DCCopySource" + int_4;
						if (stringBuilder3.Length > 0)
						{
							stringBuilder3.Append(",");
						}
						stringBuilder3.Append(text3);
						stringBuilder.AppendLine("//from " + item7.TargetElement.ID);
						stringBuilder.AppendLine("document.body." + text3 + "=function()");
						stringBuilder.AppendLine("{");
						stringBuilder.AppendLine("var txt = DCWriterControllerEditor.GetElementText(\"" + item7.SourceElement.ClientID + "\");");
						stringBuilder.AppendLine("var txt2 = DCWriterControllerEditor.GetElementText(\"" + item7.TargetElement.ClientID + "\");");
						stringBuilder.AppendLine("if( txt != txt2 ){DCWriterControllerEditor.SetElementText(\"" + item7.TargetElement.ClientID + "\" , txt );}");
						stringBuilder.AppendLine("};");
						List<string> list2 = null;
						if (dictionary_2.ContainsKey(item7.SourceElement))
						{
							list2 = dictionary_2[item7.SourceElement];
						}
						else
						{
							list2 = new List<string>();
							dictionary_2[item7.SourceElement] = list2;
						}
						if (!list2.Contains(text3))
						{
							list2.Add(text3);
						}
					}
				}
			}
			if (stringBuilder.Length > 0)
			{
				method_136(stringBuilder3.ToString());
				stringBuilder.AppendLine();
				imethod_0("script");
				method_19("language", "javascript");
				method_3("   ");
				method_18(stringBuilder.ToString());
				imethod_2();
				return true;
			}
			return false;
		}

		public string method_135()
		{
			return string_9;
		}

		public void method_136(string string_10)
		{
			string_9 = string_10;
		}

		public void method_137(XTextElement xtextElement_0)
		{
			int num = 1;
			if (!imethod_29())
			{
				string value = method_138(xtextElement_0);
				if (!string.IsNullOrEmpty(value))
				{
					method_19("effectexpression", value);
				}
			}
		}

		private string method_138(XTextElement xtextElement_0)
		{
			int num = 19;
			if (xtextElement_0 == null)
			{
				throw new ArgumentNullException("element");
			}
			if (dictionary_2.ContainsKey(xtextElement_0))
			{
				List<string> list = dictionary_2[xtextElement_0];
				StringBuilder stringBuilder = new StringBuilder();
				foreach (string item in list)
				{
					if (stringBuilder.Length > 0)
					{
						stringBuilder.Append(",");
					}
					stringBuilder.Append(item);
				}
				return stringBuilder.ToString();
			}
			return null;
		}

		private static void smethod_3(XTextElement xtextElement_0, GClass55 gclass55_0, StringBuilder stringBuilder_0, bool bool_24)
		{
			int num = 17;
			if (gclass55_0 is GClass59)
			{
				GClass59 gClass = (GClass59)gclass55_0;
				if (gClass.method_3() == GEnum3.const_1)
				{
					stringBuilder_0.Append("\"" + gClass.method_2() + "\"");
				}
				else if (gClass.method_3() == GEnum3.const_5)
				{
					if (bool_24)
					{
						stringBuilder_0.Append("document.body.GetVariableValue(\"" + gClass.method_2() + "\")");
					}
					else
					{
						stringBuilder_0.Append("document.body.GetVariableValue(\"" + gClass.method_2() + "\")");
					}
				}
				else
				{
					stringBuilder_0.Append(gClass.method_2());
				}
			}
			else if (gclass55_0 is GClass60)
			{
				GClass60 gClass2 = (GClass60)gclass55_0;
				string text = gClass2.method_2().ToUpper().Trim();
				bool bool_25 = smethod_5(text);
				if (text.IndexOf(".") < 0 && text != "DCN" && text != "DCT")
				{
					stringBuilder_0.Append("DCExpression." + text);
				}
				else
				{
					stringBuilder_0.Append(gClass2.method_2());
				}
				stringBuilder_0.Append("(");
				for (int i = 0; i < gClass2.method_3().Length; i++)
				{
					if (i > 0)
					{
						stringBuilder_0.Append(",");
					}
					smethod_3(xtextElement_0, gClass2.method_3()[i], stringBuilder_0, bool_25);
				}
				stringBuilder_0.Append(")");
			}
			else if (gclass55_0 is GClass58)
			{
				GClass58 gClass3 = (GClass58)gclass55_0;
				string text2 = null;
				text2 = ((string.Compare(gClass3.Name, "value", ignoreCase: true) != 0) ? gClass3.Name : xtextElement_0.ClientID);
				if (bool_24)
				{
					stringBuilder_0.Append("DCN(\"" + text2 + "\")");
				}
				else
				{
					stringBuilder_0.Append("DCT(\"" + text2 + "\")");
				}
			}
			else if (gclass55_0 is GClass57)
			{
				GClass57 gClass4 = (GClass57)gclass55_0;
				stringBuilder_0.Append("(");
				switch (gClass4.method_4())
				{
				case GEnum2.const_0:
					smethod_3(xtextElement_0, gClass4.method_2(), stringBuilder_0, bool_24: false);
					stringBuilder_0.Append(" && ");
					smethod_3(xtextElement_0, gClass4.method_3(), stringBuilder_0, bool_24: false);
					break;
				case GEnum2.const_1:
					smethod_3(xtextElement_0, gClass4.method_2(), stringBuilder_0, bool_24: false);
					stringBuilder_0.Append(" || ");
					smethod_3(xtextElement_0, gClass4.method_3(), stringBuilder_0, bool_24: false);
					break;
				case GEnum2.const_2:
				{
					bool bool_26 = smethod_4(gClass4.method_2()) || smethod_4(gClass4.method_3());
					smethod_3(xtextElement_0, gClass4.method_2(), stringBuilder_0, bool_26);
					stringBuilder_0.Append(" != ");
					smethod_3(xtextElement_0, gClass4.method_3(), stringBuilder_0, bool_26);
					break;
				}
				case GEnum2.const_3:
					smethod_3(xtextElement_0, gClass4.method_2(), stringBuilder_0, bool_24: false);
					stringBuilder_0.Append(" <= ");
					smethod_3(xtextElement_0, gClass4.method_3(), stringBuilder_0, bool_24: false);
					break;
				case GEnum2.const_4:
					smethod_3(xtextElement_0, gClass4.method_2(), stringBuilder_0, bool_24: false);
					stringBuilder_0.Append(" >= ");
					smethod_3(xtextElement_0, gClass4.method_3(), stringBuilder_0, bool_24: false);
					break;
				case GEnum2.const_5:
					smethod_3(xtextElement_0, gClass4.method_2(), stringBuilder_0, bool_24: false);
					stringBuilder_0.Append(" < ");
					smethod_3(xtextElement_0, gClass4.method_3(), stringBuilder_0, bool_24: false);
					break;
				case GEnum2.const_6:
					smethod_3(xtextElement_0, gClass4.method_2(), stringBuilder_0, bool_24: false);
					stringBuilder_0.Append(" > ");
					smethod_3(xtextElement_0, gClass4.method_3(), stringBuilder_0, bool_24: false);
					break;
				case GEnum2.const_7:
				{
					bool bool_26 = smethod_4(gClass4.method_2()) || smethod_4(gClass4.method_3());
					smethod_3(xtextElement_0, gClass4.method_2(), stringBuilder_0, bool_26);
					stringBuilder_0.Append(" == ");
					smethod_3(xtextElement_0, gClass4.method_3(), stringBuilder_0, bool_26);
					break;
				}
				case GEnum2.const_8:
					smethod_3(xtextElement_0, gClass4.method_2(), stringBuilder_0, bool_24: false);
					stringBuilder_0.Append(" - ");
					smethod_3(xtextElement_0, gClass4.method_3(), stringBuilder_0, bool_24: false);
					break;
				case GEnum2.const_9:
				{
					bool bool_26 = smethod_4(gClass4.method_2()) || smethod_4(gClass4.method_3());
					smethod_3(xtextElement_0, gClass4.method_2(), stringBuilder_0, bool_26);
					stringBuilder_0.Append(" + ");
					smethod_3(xtextElement_0, gClass4.method_3(), stringBuilder_0, bool_26);
					break;
				}
				case GEnum2.const_10:
					smethod_3(xtextElement_0, gClass4.method_2(), stringBuilder_0, bool_24: false);
					stringBuilder_0.Append(" % ");
					smethod_3(xtextElement_0, gClass4.method_3(), stringBuilder_0, bool_24: false);
					break;
				case GEnum2.const_11:
					smethod_3(xtextElement_0, gClass4.method_2(), stringBuilder_0, bool_24: false);
					stringBuilder_0.Append(" / ");
					smethod_3(xtextElement_0, gClass4.method_3(), stringBuilder_0, bool_24: false);
					break;
				case GEnum2.const_12:
					smethod_3(xtextElement_0, gClass4.method_2(), stringBuilder_0, bool_24: false);
					stringBuilder_0.Append(" * ");
					smethod_3(xtextElement_0, gClass4.method_3(), stringBuilder_0, bool_24: false);
					break;
				}
				stringBuilder_0.Append(")");
			}
			else if (gclass55_0 is GClass56)
			{
			}
		}

		private static bool smethod_4(GClass55 gclass55_0)
		{
			if (gclass55_0 is GClass59)
			{
				GClass59 gClass = (GClass59)gclass55_0;
				if (gClass.method_3() == GEnum3.const_1)
				{
					return true;
				}
			}
			if (gclass55_0 is GClass60)
			{
				GClass60 gClass2 = (GClass60)gclass55_0;
				if (smethod_5(gClass2.method_2()))
				{
					return true;
				}
			}
			return false;
		}

		private static bool smethod_5(string string_10)
		{
			int num = 17;
			if (string.IsNullOrEmpty(string_10))
			{
				return false;
			}
			string_10 = string_10.Trim().ToUpper();
			int num2;
			switch (string_10)
			{
			default:
				num2 = ((!(string_10 == "CDOUBLE")) ? 1 : 0);
				break;
			case "LEN":
			case "PARAMETER":
			case "FIND":
			case "LOOKUP":
			case "AGE":
			case "AGEMONTH":
			case "AGEWEEK":
			case "AGEDAY":
			case "AGEHOUR":
			case "CINT":
				num2 = 0;
				break;
			}
			if (num2 == 0)
			{
				return true;
			}
			return false;
		}

		internal static string smethod_6(GClass39 gclass39_0)
		{
			int num = 14;
			if (string.IsNullOrEmpty(gclass39_0.method_8()))
			{
				return null;
			}
			gclass39_0.method_17();
			StringBuilder stringBuilder = new StringBuilder();
			string text = gclass39_0.method_8();
			text = text.Replace("=", "==");
			string[] array = VariableString.AnalyseVariableString(text, "[", "]");
			char c = '\0';
			bool flag = false;
			for (int i = 0; i < array.Length; i++)
			{
				if (i % 2 == 0)
				{
					string string_ = array[i];
					string text2 = GClass53.smethod_3(string_);
					stringBuilder.Append(text2);
					c = (text2.EndsWith("'") ? '\'' : (text2.EndsWith("\"") ? '"' : '\0'));
					flag = true;
					string string_2 = text2.Trim().ToUpper();
					flag = GClass39.smethod_1(string_2);
					continue;
				}
				bool flag2 = false;
				if (c != 0 && i < array.Length - 1)
				{
					string text3 = array[i + 1];
					if (text3.Length > 0 && text3[0] == c)
					{
						flag2 = true;
					}
				}
				bool bool_ = !flag2 && !flag;
				if (string.Compare(array[i], "value", ignoreCase: true) == 0)
				{
					bool_ = false;
				}
				object obj = gclass39_0.method_14()[(i - 1) / 2];
				if (obj == null)
				{
					stringBuilder.Append(" 0 ");
				}
				else if (obj is XTextElement)
				{
					stringBuilder.Append(smethod_8((XTextElement)obj, bool_));
				}
				else
				{
					if (!(obj is ArrayList))
					{
						continue;
					}
					ArrayList arrayList = (ArrayList)obj;
					if (arrayList.Count > 0 && arrayList[0] is XTextCheckBoxElementBase)
					{
						XTextCheckBoxElementBase xtextCheckBoxElementBase_ = (XTextCheckBoxElementBase)arrayList[0];
						stringBuilder.Append(smethod_9(xtextCheckBoxElementBase_, bool_));
						continue;
					}
					for (int j = 0; j < arrayList.Count; j++)
					{
						if (j > 0)
						{
							stringBuilder.Append(",");
						}
						stringBuilder.Append(smethod_8((XTextElement)arrayList[j], bool_));
					}
				}
			}
			return stringBuilder.ToString();
		}

		private static XTextElement smethod_7(XTextElement xtextElement_0)
		{
			if (xtextElement_0 is XTextTableCellElement)
			{
				XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)xtextElement_0;
				XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)xTextTableCellElement.Elements.method_5(typeof(XTextInputFieldElement));
				if (xTextInputFieldElement != null)
				{
					return xTextInputFieldElement;
				}
				XTextCheckBoxElementBase xTextCheckBoxElementBase = (XTextCheckBoxElementBase)xTextTableCellElement.Elements.method_5(typeof(XTextCheckBoxElementBase));
				if (xTextCheckBoxElementBase != null)
				{
					return xTextCheckBoxElementBase;
				}
			}
			return xtextElement_0;
		}

		private static string smethod_8(XTextElement xtextElement_0, bool bool_24)
		{
			int num = 7;
			if (xtextElement_0 == null)
			{
				throw new ArgumentNullException("element");
			}
			xtextElement_0 = smethod_7(xtextElement_0);
			if (bool_24)
			{
				return "DCN('" + xtextElement_0.ClientID + "')";
			}
			return "DCT('" + xtextElement_0.ClientID + "')";
		}

		private static string smethod_9(XTextCheckBoxElementBase xtextCheckBoxElementBase_0, bool bool_24)
		{
			int num = 15;
			if (xtextCheckBoxElementBase_0 == null)
			{
				throw new ArgumentNullException("element");
			}
			string name = xtextCheckBoxElementBase_0.Name;
			if (string.IsNullOrEmpty(name))
			{
				return null;
			}
			if (bool_24)
			{
				return "DCRN(\"" + name + "\")";
			}
			return "DCRT(\"" + name + "\")";
		}

		public string method_139(DocumentComment documentComment_0)
		{
			return "dcm_" + method_141() + "_" + documentComment_0.Index;
		}

		public void method_140(Type type_0)
		{
			int num = 11;
			if (type_0 == null)
			{
				throw new ArgumentNullException("t");
			}
			if (!type_0.IsSubclassOf(typeof(XTextElement)) && !type_0.Equals(typeof(DocumentComment)))
			{
				throw new ArgumentException(type_0.FullName + " <> XTextElement");
			}
			if (!imethod_34() && (method_124() || !imethod_29()))
			{
				method_19("dctype", type_0.Name);
			}
		}

		public int method_141()
		{
			return int_5;
		}

		public void method_142(int int_6)
		{
			int_5 = int_6;
		}

		public void method_143(bool bool_24)
		{
			int num = 17;
			if (!imethod_34())
			{
				method_19("UNSELECTABLE", bool_24 ? "on" : "off");
			}
		}

		public void method_144(bool bool_24)
		{
			int num = 16;
			if (!imethod_34())
			{
				method_19("CONTENTEDITABLE", bool_24.ToString());
			}
		}

		public void imethod_33()
		{
			int num = 14;
			if (!imethod_34() && (method_124() || !imethod_29()))
			{
				method_19("dcignore", "1");
			}
		}

		public int method_145(object object_0)
		{
			int num = 12;
			if (object_0 == null)
			{
				throw new ArgumentNullException("instance");
			}
			if (imethod_34())
			{
				return 0;
			}
			if (!method_124() && imethod_29())
			{
				return 0;
			}
			int num2 = 0;
			GClass116[] array = GClass116.smethod_1(object_0.GetType());
			foreach (GClass116 gClass in array)
			{
				if (!gClass.method_4())
				{
					continue;
				}
				bool bool_ = false;
				string text = gClass.method_6(object_0, ref bool_);
				if (!bool_)
				{
					if (text == null)
					{
						text = "";
					}
					if (!string.IsNullOrEmpty(text))
					{
						method_19(gClass.method_1().ToLower(), text);
						num2++;
					}
				}
			}
			return num2;
		}

		public bool imethod_34()
		{
			return bool_16;
		}

		public void imethod_35(bool bool_24)
		{
			bool_16 = bool_24;
		}

		public bool imethod_36()
		{
			return bool_17;
		}

		public void imethod_37(bool bool_24)
		{
			bool_17 = bool_24;
		}

		public bool imethod_38()
		{
			return bool_18;
		}

		public void imethod_39(bool bool_24)
		{
			bool_18 = bool_24;
		}

		internal XTextElementList method_146()
		{
			return xtextElementList_0;
		}

		public XTextDocument method_147()
		{
			if (xtextDocument_0 == null && xtextDocumentList_0 != null)
			{
				return xtextDocumentList_0.FirstDocument;
			}
			return xtextDocument_0;
		}

		public void method_148(XTextDocument xtextDocument_1)
		{
			xtextDocument_0 = xtextDocument_1;
		}

		public XTextDocumentList imethod_40()
		{
			return xtextDocumentList_0;
		}

		public void imethod_41(XTextDocumentList xtextDocumentList_1)
		{
			xtextDocumentList_0 = xtextDocumentList_1;
		}

		public bool method_149()
		{
			return bool_19;
		}

		public void method_150(bool bool_24)
		{
			bool_19 = bool_24;
		}

		public GEnum12 imethod_42()
		{
			return genum12_0;
		}

		public void imethod_43(GEnum12 genum12_1)
		{
			genum12_0 = genum12_1;
		}

		public int method_151(float float_2)
		{
			if (float_2 <= 0f)
			{
				return 0;
			}
			if (float_2 == 1f)
			{
				return 1;
			}
			int num = (int)GraphicsUnitConvert.Convert(float_2, method_147().DocumentGraphicsUnit, GraphicsUnit.Pixel);
			if (num < 1)
			{
				num = 1;
			}
			return num;
		}

		public int imethod_44(float float_2)
		{
			if (float_2 <= 0f)
			{
				return 0;
			}
			int num = (int)GraphicsUnitConvert.Convert(float_2, method_147().DocumentGraphicsUnit, GraphicsUnit.Pixel);
			if (num == 0)
			{
				num = 1;
			}
			return num;
		}

		public float imethod_45(float float_2)
		{
			if (float_2 <= 0f)
			{
				return 0f;
			}
			float num = GraphicsUnitConvert.Convert(float_2, method_147().DocumentGraphicsUnit, GraphicsUnit.Pixel);
			if (num == 0f)
			{
				num = 1f;
			}
			return num;
		}

		public GClass119 imethod_46()
		{
			if (gclass119_0 == null)
			{
				gclass119_0 = new GClass119();
			}
			return gclass119_0;
		}

		public void imethod_47(GClass119 gclass119_1)
		{
			gclass119_0 = gclass119_1;
		}

		public override bool vmethod_4()
		{
			return imethod_46().method_2();
		}

		public override void vmethod_5(bool bool_24)
		{
		}

		public override bool vmethod_6()
		{
			return imethod_46().vmethod_0();
		}

		public override void vmethod_7(bool bool_24)
		{
		}

		public bool imethod_48()
		{
			return bool_20;
		}

		public void imethod_49(bool bool_24)
		{
			bool_20 = bool_24;
		}

		public bool method_152(XTextElement xtextElement_0)
		{
			return xtextElement_0.RuntimeVisible;
		}

		public Rectangle imethod_50()
		{
			return rectangle_0;
		}

		public void imethod_51(Rectangle rectangle_1)
		{
			rectangle_0 = rectangle_1;
		}

		public RectangleF imethod_52()
		{
			return rectangleF_0;
		}

		public void imethod_53(RectangleF rectangleF_1)
		{
			rectangleF_0 = rectangleF_1;
		}

		internal void method_153(string string_10)
		{
			int num = 0;
			GClass472 gClass = XTextDocument.smethod_6(bool_32: false);
			if (gClass.method_6())
			{
				imethod_0("span");
				method_19("style", "color:black;font-size:9pt;background-color:" + method_61(gClass.method_18()));
				string text = gClass.method_8() + " " + string_10;
				text = XMLHelper.ToXMLEntryRandom(text, 0.6);
				method_3(" ");
				method_18(text);
				imethod_2();
			}
			else
			{
				imethod_0("span");
				method_19("style", "color:red;font-size:15pt;font-weight:bold;background-color:" + method_61(gClass.method_18()));
				string text = gClass.method_8();
				text = XMLHelper.ToXMLEntryRandom(text, 0.6);
				method_3(" ");
				method_18(text);
				imethod_2();
			}
		}

		public bool method_154()
		{
			return bool_21;
		}

		public void method_155(bool bool_24)
		{
			bool_21 = bool_24;
			XTextDocument.smethod_2(bool_21);
		}

		public void imethod_10()
		{
			int num = 17;
			XTextDocument.smethod_2(method_154());
			method_35();
			if (imethod_46().method_0() != null)
			{
				method_25(imethod_46().method_0());
			}
			foreach (XTextDocument item in imethod_40())
			{
				item.CheckPageRefreshed();
			}
			if (imethod_42() != 0)
			{
				return;
			}
			vmethod_1();
			imethod_0("div");
			GClass472 gClass = XTextDocument.smethod_6(bool_32: false);
			if (gClass != null && !gClass.method_6())
			{
				imethod_0("div");
				method_39();
				method_40("font-name", gClass.method_10());
				method_40("font-size", gClass.method_12() + "pt");
				if (gClass.method_14())
				{
					method_40("font-weight", "bold");
				}
				method_40("color", ColorTranslator.ToHtml(gClass.method_16()));
				method_63();
				method_15(gClass.method_8());
				imethod_1();
			}
			imethod_51(Rectangle.Empty);
			if (imethod_40() != null && imethod_40().Count > 0)
			{
				if (imethod_46().method_12() && method_147().Header.HasContentElement && method_147().PageSettings.EnableHeaderFooter)
				{
					method_147().Header.vmethod_18(this);
					if (method_147().Options.ViewOptions.ShowHeaderBottomLine)
					{
						imethod_0("hr");
						float headerBottomLineWidth = method_147().Options.ViewOptions.HeaderBottomLineWidth;
						if (headerBottomLineWidth > 1f)
						{
							method_19("size", headerBottomLineWidth.ToString());
						}
						imethod_1();
					}
				}
				if (imethod_48())
				{
					XTextDocument xTextDocument = imethod_40()[0];
					xTextDocument.CurrentContentElement.vmethod_18(this);
				}
				else
				{
					foreach (XTextDocument item2 in imethod_40())
					{
						item2.Body.vmethod_18(this);
					}
				}
				if (imethod_46().method_12() && method_147().Footer.HasContentElement && method_147().PageSettings.EnableHeaderFooter)
				{
					method_147().Footer.vmethod_18(this);
				}
			}
			imethod_1();
			vmethod_2();
		}

		public void method_156(XTextElement xtextElement_0, string string_10, RuntimeDocumentContentStyle runtimeDocumentContentStyle_0, string string_11)
		{
			int num = 17;
			if (!string.IsNullOrEmpty(string_10))
			{
				imethod_0("label");
				method_19("id", string_11 + "_label");
				method_144(bool_24: false);
				method_39();
				if (runtimeDocumentContentStyle_0 != null)
				{
					imethod_54(runtimeDocumentContentStyle_0, xtextElement_0);
					method_45(runtimeDocumentContentStyle_0.Font.Value);
				}
				method_63();
				method_19("for", string_11);
				method_3(string_10);
				imethod_1();
			}
		}

		public void method_157(string string_10, RuntimeDocumentContentStyle runtimeDocumentContentStyle_0, XTextElement xtextElement_0, float float_2)
		{
			int num = 13;
			bool flag = imethod_34() && (string_10 == null || string_10.Trim().Length == 0);
			XTextDocument ownerDocument = xtextElement_0.OwnerDocument;
			string link = runtimeDocumentContentStyle_0.Link;
			if (link != null && link.Trim().Length > 0)
			{
				imethod_0("a");
				method_19("href", link);
			}
			else
			{
				imethod_0("span");
			}
			if (runtimeDocumentContentStyle_0.CommentIndex >= 0)
			{
				method_19("refcommentindex", runtimeDocumentContentStyle_0.CommentIndex.ToString());
			}
			GClass96 toolTipInfo = xtextElement_0.GetToolTipInfo();
			if (toolTipInfo != null)
			{
				string text = toolTipInfo.method_5();
				if (!string.IsNullOrEmpty(text))
				{
					if (!string.IsNullOrEmpty(toolTipInfo.method_3()))
					{
						text = toolTipInfo.method_3() + Environment.NewLine + text;
					}
					method_19("title", text);
				}
			}
			method_39();
			imethod_54(runtimeDocumentContentStyle_0, xtextElement_0);
			if (!flag)
			{
				method_45(runtimeDocumentContentStyle_0.Font.Value);
			}
			if (ownerDocument.Options.SecurityOptions.ShowPermissionMark)
			{
				int creatorPermessionLevel = xtextElement_0.CreatorPermessionLevel;
				if (creatorPermessionLevel >= 0)
				{
					TrackVisibleConfig trackVisibleConfig = ownerDocument.Options.SecurityOptions.GetTrackVisibleConfig(creatorPermessionLevel);
					if (trackVisibleConfig != null)
					{
						if (trackVisibleConfig.BackgroundColor.A != 0)
						{
							if (imethod_34())
							{
								method_40("background-color", method_61(trackVisibleConfig.BackgroundColor) + "!important");
							}
							else
							{
								method_40("background-color", method_61(trackVisibleConfig.BackgroundColor));
							}
						}
						if (trackVisibleConfig.UnderLineColorNum >= 0)
						{
							method_40("text-decoration", "underline");
							method_40("text-decoration-color", method_61(trackVisibleConfig.UnderLineColor));
							if (trackVisibleConfig.UnderLineColorNum == 2)
							{
								method_40("text-decoration-style", "double");
							}
						}
					}
				}
				creatorPermessionLevel = xtextElement_0.DeleterPermissionLevel;
				if (creatorPermessionLevel >= 0)
				{
					TrackVisibleConfig trackVisibleConfig = ownerDocument.Options.SecurityOptions.GetTrackVisibleConfig(creatorPermessionLevel);
					if (trackVisibleConfig != null && trackVisibleConfig.DeleteLineNum > 0)
					{
						method_40("text-decoration", "line-through");
						method_40("text-decoration-color", method_61(trackVisibleConfig.DeleteLineColor));
						if (trackVisibleConfig.DeleteLineNum == 2)
						{
							method_40("text-decoration-style", "double");
						}
					}
				}
			}
			if (runtimeDocumentContentStyle_0.CommentIndex >= 0 && !imethod_34())
			{
				DocumentComment byCommentIndex = xtextElement_0.OwnerDocument.Comments.GetByCommentIndex(runtimeDocumentContentStyle_0.CommentIndex);
				if (byCommentIndex != null)
				{
					method_40("background-color", method_61(ControlPaint.Light(byCommentIndex.BackColor)));
				}
			}
			if (float_2 > 0f)
			{
				method_40("width", xtextElement_0.OwnerDocument.ToPixel((int)float_2) + "px");
				method_40("display", "inline-block");
				method_40("text-align", runtimeDocumentContentStyle_0.Align.ToString());
				method_40("overflow", "hidden");
				if (!runtimeDocumentContentStyle_0.Multiline)
				{
					method_40("white-space", "nowrap");
					method_40("word-break", "keep-all");
				}
				if (method_28() != XWebBrowsersStyle.InternetExplorer7)
				{
					method_40("vertical-align", "bottom");
				}
			}
			method_63();
			method_15(string_10);
			imethod_2();
		}

		public bool method_158()
		{
			return bool_22;
		}

		public void method_159(bool bool_24)
		{
			bool_22 = bool_24;
		}

		public void imethod_54(RuntimeDocumentContentStyle runtimeDocumentContentStyle_0, XTextElement xtextElement_0)
		{
			int num = 0;
			if (runtimeDocumentContentStyle_0 == null)
			{
				throw new ArgumentNullException("style");
			}
			GraphicsUnit unit = GraphicsUnit.Document;
			if (method_147() != null)
			{
				unit = method_147().DocumentGraphicsUnit;
			}
			if (runtimeDocumentContentStyle_0.BorderLeftColor == runtimeDocumentContentStyle_0.BorderTopColor && runtimeDocumentContentStyle_0.BorderTopColor == runtimeDocumentContentStyle_0.BorderRightColor && runtimeDocumentContentStyle_0.BorderRightColor == runtimeDocumentContentStyle_0.BorderBottomColor && runtimeDocumentContentStyle_0.BorderWidth > 0f)
			{
				method_54(runtimeDocumentContentStyle_0.BorderLeft, runtimeDocumentContentStyle_0.BorderTop, runtimeDocumentContentStyle_0.BorderRight, runtimeDocumentContentStyle_0.BorderBottom, runtimeDocumentContentStyle_0.BorderColor, Math.Max(1, xtextElement_0.OwnerDocument.ToPixel((int)runtimeDocumentContentStyle_0.BorderWidth)), runtimeDocumentContentStyle_0.BorderStyle);
			}
			else
			{
				if (runtimeDocumentContentStyle_0.BorderLeft && runtimeDocumentContentStyle_0.BorderLeftColor.A != 0)
				{
					method_48("left", runtimeDocumentContentStyle_0.BorderLeftColor, imethod_44(runtimeDocumentContentStyle_0.BorderWidth), runtimeDocumentContentStyle_0.BorderStyle);
				}
				if (runtimeDocumentContentStyle_0.BorderTop && runtimeDocumentContentStyle_0.BorderTopColor.A != 0)
				{
					method_48("top", runtimeDocumentContentStyle_0.BorderTopColor, imethod_44(runtimeDocumentContentStyle_0.BorderWidth), runtimeDocumentContentStyle_0.BorderStyle);
				}
				if (runtimeDocumentContentStyle_0.BorderRight && runtimeDocumentContentStyle_0.BorderRightColor.A != 0)
				{
					method_48("right", runtimeDocumentContentStyle_0.BorderRightColor, imethod_44(runtimeDocumentContentStyle_0.BorderWidth), runtimeDocumentContentStyle_0.BorderStyle);
				}
				if (runtimeDocumentContentStyle_0.BorderBottom && runtimeDocumentContentStyle_0.BorderBottomColor.A != 0)
				{
					method_48("bottom", runtimeDocumentContentStyle_0.BorderBottomColor, imethod_44(runtimeDocumentContentStyle_0.BorderWidth), runtimeDocumentContentStyle_0.BorderStyle);
				}
			}
			if (xtextElement_0 is XTextParagraphFlagElement || xtextElement_0 is XTextParagraphElement)
			{
				if (imethod_34())
				{
					switch (runtimeDocumentContentStyle_0.Align)
					{
					default:
						method_40("text-align", "left");
						break;
					case DocumentContentAlignment.Left:
						method_40("text-align", "left");
						break;
					case DocumentContentAlignment.Center:
						method_40("text-align", "center");
						break;
					case DocumentContentAlignment.Right:
						method_40("text-align", "right");
						break;
					case DocumentContentAlignment.Justify:
						method_40("text-align", "justify");
						break;
					}
				}
				if (runtimeDocumentContentStyle_0.SpacingBeforeParagraph > 0f)
				{
					method_40("margin-top", imethod_45(runtimeDocumentContentStyle_0.SpacingBeforeParagraph).ToString("0.00") + "px");
				}
				if (runtimeDocumentContentStyle_0.SpacingAfterParagraph > 0f)
				{
					method_40("margin-bottom", imethod_45(runtimeDocumentContentStyle_0.SpacingAfterParagraph).ToString("0.00") + "px");
				}
				if (runtimeDocumentContentStyle_0.LeftIndent > 0f && runtimeDocumentContentStyle_0.ParagraphListStyle == ParagraphListStyle.None)
				{
					method_40("margin-left", imethod_45(runtimeDocumentContentStyle_0.LeftIndent).ToString("0.00") + "px");
				}
				switch (runtimeDocumentContentStyle_0.LineSpacingStyle)
				{
				case LineSpacingStyle.Space1pt5:
					method_40("line-height", "150%");
					break;
				case LineSpacingStyle.SpaceDouble:
					method_40("line-height", "200%");
					break;
				case LineSpacingStyle.SpaceSpecify:
					method_40("line-height", imethod_45(runtimeDocumentContentStyle_0.LineSpacing).ToString("0.00") + "px");
					break;
				case LineSpacingStyle.SpaceMultiple:
					method_40("line-height", Convert.ToString(runtimeDocumentContentStyle_0.LineSpacing * 100f) + "%");
					break;
				}
			}
			else
			{
				float float_ = runtimeDocumentContentStyle_0.PaddingLeft;
				float paddingTop = runtimeDocumentContentStyle_0.PaddingTop;
				float float_2 = runtimeDocumentContentStyle_0.PaddingRight;
				float paddingBottom = runtimeDocumentContentStyle_0.PaddingBottom;
				if (xtextElement_0 is XTextContentElement && imethod_34())
				{
					float_ = 0f;
					float_2 = 0f;
				}
				int num2 = (int)Math.Floor(imethod_45(float_));
				int num3 = (int)Math.Floor(imethod_45(paddingTop));
				int num4 = (int)Math.Floor(imethod_45(float_2));
				int num5 = (int)Math.Floor(imethod_45(paddingBottom));
				if (method_158() && method_52() > 0)
				{
					int num6 = Math.Min(method_52(), num5);
					if (num6 > 0)
					{
						method_53(method_52() - num6);
						num5 -= num6;
					}
					num6 = Math.Min(method_52(), num3);
					if (num6 > 0)
					{
						method_53(method_52() - num6);
						num3 -= num6;
					}
				}
				method_46(num2, num3, num4, num5);
				method_47((int)Math.Floor(imethod_45(runtimeDocumentContentStyle_0.MarginLeft)), (int)Math.Floor(imethod_45(runtimeDocumentContentStyle_0.MarginTop)), (int)Math.Floor(imethod_45(runtimeDocumentContentStyle_0.MarginRight)), (int)Math.Floor(imethod_45(runtimeDocumentContentStyle_0.MarginBottom)));
			}
			if (runtimeDocumentContentStyle_0.HasBackgroundColorValue)
			{
				Color backgroundColor = runtimeDocumentContentStyle_0.BackgroundColor;
				if (backgroundColor.A > 0)
				{
					if (imethod_34())
					{
						method_40("background-color", method_61(backgroundColor) + "!important");
					}
					else
					{
						method_40("background-color", method_61(backgroundColor));
					}
				}
			}
			if (imethod_34() && runtimeDocumentContentStyle_0.PrintBackColor.A > 0)
			{
				method_40("background-color", method_61(runtimeDocumentContentStyle_0.PrintBackColor) + "!important");
			}
			if (runtimeDocumentContentStyle_0.BackgroundImage != null && runtimeDocumentContentStyle_0.BackgroundImage.HasContent)
			{
				GClass357 gClass = method_66(runtimeDocumentContentStyle_0.BackgroundImage.Value, null);
				if (imethod_34())
				{
					method_40("background-image", "url(" + gClass.method_0() + ") !important");
				}
				else
				{
					method_40("background-image", "url(" + gClass.method_0() + ")");
				}
			}
			if (XDependencyObject.smethod_4(runtimeDocumentContentStyle_0.Parent, "BackgroundPosition"))
			{
				string text = null;
				switch (runtimeDocumentContentStyle_0.BackgroundPosition)
				{
				case ContentAlignment.MiddleCenter:
					text = "center center";
					break;
				case ContentAlignment.MiddleLeft:
					text = "center left";
					break;
				case ContentAlignment.TopLeft:
					text = "top left";
					break;
				case ContentAlignment.TopCenter:
					text = "top center";
					break;
				case ContentAlignment.TopRight:
					text = "top right";
					break;
				case ContentAlignment.BottomLeft:
					text = "bottom left";
					break;
				case ContentAlignment.MiddleRight:
					text = "center right";
					break;
				case ContentAlignment.BottomRight:
					text = "bottom right";
					break;
				case ContentAlignment.BottomCenter:
					text = "bottom center";
					break;
				}
				method_40("background-position", text);
			}
			if (runtimeDocumentContentStyle_0.BackgroundPositionX != 0f)
			{
				method_40("background-position-x", GraphicsUnitConvert.ToCSSLength(imethod_44(runtimeDocumentContentStyle_0.BackgroundPositionX), unit, GEnum87.const_5));
			}
			if (runtimeDocumentContentStyle_0.BackgroundPositionY != 0f)
			{
				method_40("background-position-y", GraphicsUnitConvert.ToCSSLength(imethod_44(runtimeDocumentContentStyle_0.BackgroundPositionY), unit, GEnum87.const_5));
			}
			if (runtimeDocumentContentStyle_0.BackgroundRepeat)
			{
				method_40("background-repeat", "repeat");
			}
			Color color = Color.Empty;
			if (runtimeDocumentContentStyle_0.PrintColor.A != 0)
			{
				color = runtimeDocumentContentStyle_0.PrintColor;
			}
			else if (XDependencyObject.smethod_4(runtimeDocumentContentStyle_0.Parent, "Color"))
			{
				color = runtimeDocumentContentStyle_0.Color;
			}
			if ((xtextElement_0 is XTextLabelElement || xtextElement_0 is XTextStringElement || xtextElement_0 is XTextCharElement || xtextElement_0 is XTextCheckBoxElementBase) && color.A != 0 && color != Color.Black)
			{
				method_40("color", method_61(color));
			}
			if (xtextElement_0 is XTextParagraphFlagElement && (double)Math.Abs(runtimeDocumentContentStyle_0.FirstLineIndent) > 0.05 && runtimeDocumentContentStyle_0.ParagraphListStyle == ParagraphListStyle.None)
			{
				method_40("text-indent", GraphicsUnitConvert.ToCSSLength(runtimeDocumentContentStyle_0.FirstLineIndent, unit, GEnum87.const_5));
			}
			if (runtimeDocumentContentStyle_0.PageBreakAfter)
			{
				method_40("page-break-after", "always");
			}
			if (runtimeDocumentContentStyle_0.PageBreakBefore)
			{
				method_40("page-break-before", "always");
			}
			if (xtextElement_0 is XTextParagraphFlagElement)
			{
				if (runtimeDocumentContentStyle_0.RightToLeft)
				{
					method_40("direction", "rtl");
				}
				else
				{
					method_40("direction", "tr");
				}
			}
			if ((double)Math.Abs(runtimeDocumentContentStyle_0.Spacing) > 0.05)
			{
				method_40("letter-spacing", GraphicsUnitConvert.ToCSSLength(runtimeDocumentContentStyle_0.Spacing, unit, GEnum87.const_5));
			}
			if (!runtimeDocumentContentStyle_0.VertialText)
			{
			}
			if (xtextElement_0 is XTextTableCellElement)
			{
				switch (runtimeDocumentContentStyle_0.VerticalAlign)
				{
				case VerticalAlignStyle.Top:
					method_40("vertical-align", "top");
					break;
				case VerticalAlignStyle.Middle:
					method_40("vertical-align", "middle");
					break;
				case VerticalAlignStyle.Bottom:
					method_40("vertical-align", "bottom");
					break;
				}
			}
			if (!runtimeDocumentContentStyle_0.Visible)
			{
				method_40("visibility", "hidden");
			}
			if (XDependencyObject.smethod_4(runtimeDocumentContentStyle_0.Parent, "Zoom"))
			{
				method_40("zoom", runtimeDocumentContentStyle_0.Zoom.ToString());
			}
		}

		public void method_160(XTextElement xtextElement_0)
		{
			method_161(xtextElement_0, null);
		}

		public void method_161(XTextElement xtextElement_0, Dictionary<string, string> dictionary_3)
		{
			int num = 2;
			XTextDocument ownerDocument = xtextElement_0.OwnerDocument;
			_ = xtextElement_0.RuntimeStyle;
			string value = null;
			if (dictionary_3 != null && dictionary_3.ContainsKey("src"))
			{
				value = dictionary_3["src"];
			}
			bool flag = false;
			if (xtextElement_0 is XTextObjectElement && imethod_34())
			{
				XTextObjectElement xTextObjectElement = (XTextObjectElement)xtextElement_0;
				if (xTextObjectElement.ZOrderStyle == ElementZOrderStyle.InFrontOfText)
				{
					flag = true;
					imethod_0("span");
					method_19("style", "position:relative");
				}
			}
			string value2 = null;
			if (string.IsNullOrEmpty(value))
			{
				Image image = xtextElement_0.CreateContentImage();
				if (xtextElement_0 is XTextImageElement)
				{
					XTextImageElement xTextImageElement = (XTextImageElement)xtextElement_0;
					if (xTextImageElement.TransparentColor.A != 0 && image is Bitmap)
					{
						((Bitmap)image).MakeTransparent(xTextImageElement.TransparentColor);
					}
				}
				if (image != null)
				{
					if (imethod_46() != null && imethod_46().method_10())
					{
						MemoryStream memoryStream = new MemoryStream();
						image.Save(memoryStream, ImageFormat.Png);
						memoryStream.Close();
						byte[] inArray = memoryStream.ToArray();
						string str = Convert.ToBase64String(inArray);
						value2 = "data:image/png;base64," + str;
					}
					else
					{
						GClass357 gClass = method_67(image, null, xtextElement_0, flag ? ImageFormat.Png : null);
						value = gClass.method_0();
					}
				}
			}
			if (string.IsNullOrEmpty(value) && string.IsNullOrEmpty(value2))
			{
				return;
			}
			imethod_0("img");
			method_19("id", xtextElement_0.ClientID);
			if (imethod_36())
			{
				method_140(xtextElement_0.GetType());
				method_145(xtextElement_0);
			}
			if (dictionary_3 != null)
			{
				foreach (string key in dictionary_3.Keys)
				{
					method_19(key, dictionary_3[key]);
				}
			}
			GClass96 toolTipInfo = xtextElement_0.GetToolTipInfo();
			if (toolTipInfo != null && !string.IsNullOrEmpty(toolTipInfo.method_5()))
			{
				method_19("title", toolTipInfo.method_5());
			}
			method_39();
			imethod_54(xtextElement_0.RuntimeStyle, xtextElement_0);
			if (flag)
			{
				XTextObjectElement xTextObjectElement = (XTextObjectElement)xtextElement_0;
				if (xTextObjectElement.ZOrderStyle == ElementZOrderStyle.InFrontOfText)
				{
					method_40("position", "absolute");
					if (xTextObjectElement.OffsetX != 0f)
					{
						method_40("left", GraphicsUnitConvert.Convert(xTextObjectElement.OffsetX, xtextElement_0.OwnerDocument.DocumentGraphicsUnit, GraphicsUnit.Pixel) + "px");
					}
					if (xTextObjectElement.OffsetY != 0f)
					{
						method_40("top", GraphicsUnitConvert.Convert(xTextObjectElement.OffsetY, xtextElement_0.OwnerDocument.DocumentGraphicsUnit, GraphicsUnit.Pixel) + "px");
					}
				}
			}
			method_63();
			if (!string.IsNullOrEmpty(value2))
			{
				method_19("src", value2);
			}
			else if (!(dictionary_3?.ContainsKey("src") ?? false))
			{
				method_19("src", value);
			}
			method_19("width", Convert.ToInt32(ownerDocument.ToPixel(xtextElement_0.Width)) + "px");
			method_19("height", Convert.ToInt32(ownerDocument.ToPixel(xtextElement_0.Height)) + "px");
			method_140(xtextElement_0.GetType());
			method_145(xtextElement_0);
			method_132(xtextElement_0);
			if (!imethod_29())
			{
				method_19("onclick", "DCInputFieldManager.executClientJavaScript( event , this , 'click');");
				method_19("ondblclick", "DCInputFieldManager.executClientJavaScript( event , this , 'dblclick');");
			}
			imethod_1();
			if (flag)
			{
				imethod_2();
			}
		}

		public DCBackgroundTextOutputMode imethod_55()
		{
			return dcbackgroundTextOutputMode_0;
		}

		public void imethod_56(DCBackgroundTextOutputMode dcbackgroundTextOutputMode_1)
		{
			dcbackgroundTextOutputMode_0 = dcbackgroundTextOutputMode_1;
		}

		public bool imethod_57()
		{
			return bool_23;
		}

		public void imethod_58(bool bool_24)
		{
			bool_23 = bool_24;
		}

		public void method_162()
		{
			int num = 19;
			imethod_0("script");
			method_19("language", "javascript");
			int num2 = method_1();
			int num3 = (method_2() != null) ? method_2().Length : 0;
			method_3(Environment.NewLine + "document.body.setAttribute('serverchars','" + num3 + "');");
			method_3(Environment.NewLine + "document.body.setAttribute('serverticks','" + num2 + "');");
			method_3(Environment.NewLine);
			imethod_2();
		}

		int GInterface5.imethod_3(string string_10)
		{
			return method_78(string_10);
		}

		void GInterface5.imethod_4(Stream stream_0)
		{
			method_76(stream_0);
		}

		void GInterface5.imethod_5(TextWriter textWriter_0)
		{
			method_75(textWriter_0);
		}

		void GInterface5.imethod_6(Stream stream_0)
		{
			method_79(stream_0);
		}

		void GInterface5.imethod_15(string string_10)
		{
			method_18(string_10);
		}

		void GInterface5.imethod_16(string string_10)
		{
			method_3(string_10);
		}

		void GInterface5.imethod_17(bool bool_24, bool bool_25, bool bool_26, bool bool_27, Color color_0, int int_6, DashStyle dashStyle_0)
		{
			method_54(bool_24, bool_25, bool_26, bool_27, color_0, int_6, dashStyle_0);
		}

		void GInterface5.imethod_18(string string_10, string string_11)
		{
			method_19(string_10, string_11);
		}

		string GInterface5.imethod_21(Color color_0)
		{
			return method_61(color_0);
		}

		string GInterface5.imethod_22(DashStyle dashStyle_0)
		{
			return method_62(dashStyle_0);
		}

		void GInterface5.imethod_24()
		{
			method_39();
		}

		void GInterface5.imethod_25(string string_10, string string_11)
		{
			method_40(string_10, string_11);
		}

		void GInterface5.imethod_26()
		{
			method_63();
		}

		Encoding GInterface5.imethod_7()
		{
			return method_24();
		}

		void GInterface5.imethod_8(Encoding encoding_1)
		{
			method_25(encoding_1);
		}

		string GInterface5.imethod_9()
		{
			return method_70();
		}

		bool GInterface5.imethod_11()
		{
			return method_22();
		}

		void GInterface5.imethod_12(bool bool_24)
		{
			method_23(bool_24);
		}

		string GInterface5.imethod_13()
		{
			return method_64();
		}

		void GInterface5.imethod_14(string string_10)
		{
			method_65(string_10);
		}

		XWebBrowsersStyle GInterface5.imethod_19()
		{
			return method_28();
		}

		void GInterface5.imethod_20(XWebBrowsersStyle xwebBrowsersStyle_1)
		{
			method_29(xwebBrowsersStyle_1);
		}

		int GInterface5.imethod_27()
		{
			return method_52();
		}

		void GInterface5.imethod_28(int int_6)
		{
			method_53(int_6);
		}
	}
}
