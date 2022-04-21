using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.Writer;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Security;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	
	
	[ComVisible(false)]
	public class GClass95 : IDisposable
	{
		private XTextDocument xtextDocument_0 = null;

		internal GStruct20 gstruct20_0 = new GStruct20(bool_1: true);

		private HighlightInfoList highlightInfoList_0 = null;

		private static StringFormat stringFormat_0 = null;

		private bool bool_0 = true;

		private static Dictionary<string, GClass267> dictionary_0 = new Dictionary<string, GClass267>();

		private Dictionary<int, Dictionary<char, SizeF>> dictionary_1 = null;

		private bool bool_1 = false;

		internal GStruct20 gstruct20_1 = new GStruct20(bool_1: true);

		private Class105 class105_0 = null;

		private static DrawStringFormatExt drawStringFormatExt_0 = null;

		private DocumentOptions documentOptions_0 = null;

		private DocumentViewOptions documentViewOptions_0 = null;

		internal int int_0 = 0;

		private static DrawStringFormatExt drawStringFormatExt_1 = DrawStringFormatExt.GenericTypographic;

		[ThreadStatic]
		private static DrawStringFormatExt drawStringFormatExt_2 = null;

		private static int int_1 = 0;

		public XTextDocument method_0()
		{
			return xtextDocument_0;
		}

		public void method_1(XTextDocument xtextDocument_1)
		{
			xtextDocument_0 = xtextDocument_1;
			method_8();
		}

		public virtual bool vmethod_0(XTextElement xtextElement_0, DocumentPaintEventArgs documentPaintEventArgs_0, bool bool_2)
		{
			XTextDocument ownerDocument = xtextElement_0.OwnerDocument;
			DocumentSecurityOptions securityOptions = ownerDocument.Options.SecurityOptions;
			RuntimeDocumentContentStyle runtimeStyle = xtextElement_0.RuntimeStyle;
			int num = -1;
			bool flag = false;
			if (runtimeStyle.DeleterIndex >= 0)
			{
				UserHistoryInfo info = ownerDocument.UserHistories.GetInfo(runtimeStyle.DeleterIndex);
				if (info != null)
				{
					num = info.PermissionLevel;
					flag = true;
				}
			}
			else if (runtimeStyle.CreatorIndex >= 0)
			{
				UserHistoryInfo info = ownerDocument.UserHistories.GetInfo(runtimeStyle.CreatorIndex);
				if (info != null)
				{
					num = info.PermissionLevel;
					flag = false;
				}
			}
			if (num < 0)
			{
				return false;
			}
			TrackVisibleConfig trackVisibleConfig = securityOptions.GetTrackVisibleConfig(num);
			if (!(trackVisibleConfig?.Enabled ?? false))
			{
				return false;
			}
			bool result = false;
			_ = xtextElement_0.OwnerLine;
			RectangleF empty = RectangleF.Empty;
			empty = documentPaintEventArgs_0.ViewBounds;
			empty.Width = xtextElement_0.Width + xtextElement_0.WidthFix;
			if (xtextElement_0 is XTextParagraphFlagElement)
			{
				empty.Width = xtextElement_0.ViewWidth;
			}
			if (bool_2)
			{
				if (trackVisibleConfig.BackgroundColor.A != 0)
				{
					if (documentPaintEventArgs_0.Graphics != null)
					{
						documentPaintEventArgs_0.Graphics.FillRectangle(trackVisibleConfig.BackgroundColor, empty);
					}
					result = true;
				}
			}
			else if (flag)
			{
				if (trackVisibleConfig.DeleteLineNum > 0 && trackVisibleConfig.DeleteLineColor.A != 0)
				{
					for (int i = 0; i < trackVisibleConfig.DeleteLineNum; i++)
					{
						float num2 = empty.Top + (float)(i + 2) * empty.Height / (float)(trackVisibleConfig.DeleteLineNum + 3);
						if (documentPaintEventArgs_0.Graphics != null)
						{
							documentPaintEventArgs_0.Graphics.DrawLine(trackVisibleConfig.DeleteLineColor, empty.Left, num2, empty.Right, num2);
						}
					}
					result = true;
				}
			}
			else if (trackVisibleConfig.UnderLineColorNum > 0 && trackVisibleConfig.UnderLineColor.A != 0)
			{
				float num3 = GraphicsUnitConvert.Convert(2f, GraphicsUnit.Pixel, method_0().DocumentGraphicsUnit);
				for (int i = 0; i < trackVisibleConfig.UnderLineColorNum; i++)
				{
					float num2 = empty.Bottom - num3 * (float)i;
					if (documentPaintEventArgs_0.Graphics != null)
					{
						documentPaintEventArgs_0.Graphics.DrawLine(trackVisibleConfig.UnderLineColor, empty.Left, num2, empty.Right, num2);
					}
				}
				result = true;
			}
			return result;
		}

		private HighlightInfo method_2(XTextElement xtextElement_0)
		{
			if (highlightInfoList_0 == null)
			{
				highlightInfoList_0 = new HighlightInfoList();
			}
			else
			{
				int num = highlightInfoList_0.Count - 1;
				while (num >= 0)
				{
					if (!highlightInfoList_0[num].Contains(xtextElement_0))
					{
						num--;
						continue;
					}
					return highlightInfoList_0[num];
				}
			}
			for (XTextContainerElement parent = xtextElement_0.Parent; parent != null; parent = parent.Parent)
			{
				HighlightInfoList highlightInfoList = parent.vmethod_20();
				if (highlightInfoList != null && highlightInfoList.Count > 0)
				{
					foreach (HighlightInfo item in highlightInfoList)
					{
						if (item.Contains(xtextElement_0))
						{
							highlightInfoList_0.Add(item);
							return item;
						}
					}
				}
			}
			return null;
		}

		public virtual void vmethod_1(XTextElement xtextElement_0, DocumentPaintEventArgs documentPaintEventArgs_0, RectangleF rectangleF_0)
		{
			if (rectangleF_0.IsEmpty)
			{
				return;
			}
			RuntimeDocumentContentStyle runtimeDocumentContentStyle = null;
			if (documentPaintEventArgs_0.Style.HasVisibleBackground)
			{
				runtimeDocumentContentStyle = documentPaintEventArgs_0.Style;
			}
			else if (xtextElement_0.Parent != null && !(xtextElement_0.Parent is XTextContentElement))
			{
				runtimeDocumentContentStyle = xtextElement_0.Parent.vmethod_28(xtextElement_0);
			}
			if (runtimeDocumentContentStyle == null)
			{
				runtimeDocumentContentStyle = documentPaintEventArgs_0.Style;
			}
			Color color_ = runtimeDocumentContentStyle.BackgroundColor;
			if ((documentPaintEventArgs_0.RenderMode == DocumentRenderMode.Print || documentPaintEventArgs_0.RenderMode == DocumentRenderMode.ReadPaint || documentPaintEventArgs_0.RenderMode == DocumentRenderMode.PDF) && runtimeDocumentContentStyle.PrintBackColor.ToArgb() != Color.Empty.ToArgb())
			{
				color_ = runtimeDocumentContentStyle.PrintBackColor;
			}
			if (color_.A == 0)
			{
				if (runtimeDocumentContentStyle.CommentIndex >= 0 && documentPaintEventArgs_0.RenderMode == DocumentRenderMode.Paint && XTextDocument.smethod_13(GEnum6.const_148))
				{
					DocumentComment byCommentIndex = method_0().Comments.GetByCommentIndex(runtimeDocumentContentStyle.CommentIndex);
					if (byCommentIndex != null && byCommentIndex.RuntimeVisible)
					{
						color_ = ((method_0().CommentManager == null) ? byCommentIndex.BackColor : method_0().CommentManager.imethod_8(byCommentIndex));
					}
				}
				if (method_0().InnerComments != null && method_0().InnerComments.Count > 0)
				{
					foreach (DocumentComment innerComment in method_0().InnerComments)
					{
						if (innerComment.RuntimeVisible)
						{
							bool flag = false;
							if (innerComment.AnchorElement == xtextElement_0)
							{
								flag = true;
							}
							else if (innerComment.ReferenceElements != null && innerComment.ReferenceElements.Count > 0)
							{
								flag = innerComment.ReferenceElements.Contains(xtextElement_0);
							}
							if (flag)
							{
								color_ = ((method_0().CommentManager == null) ? innerComment.BackColor : method_0().CommentManager.imethod_8(innerComment));
								break;
							}
						}
					}
				}
			}
			if (color_.A != 0)
			{
				rectangleF_0 = RectangleF.Intersect(rectangleF_0, documentPaintEventArgs_0.ClipRectangle);
				if (!rectangleF_0.IsEmpty)
				{
					documentPaintEventArgs_0.Graphics.FillRectangle(color_, rectangleF_0);
					return;
				}
			}
			HighlightInfo highlightInfo = null;
			if (documentPaintEventArgs_0.ActiveMode && documentPaintEventArgs_0.RenderMode == DocumentRenderMode.Paint && !method_0().States.GenerateBmp && !method_0().States.GenerateLongBmp)
			{
				GInterface6 highlightManager = method_0().HighlightManager;
				if (highlightManager != null)
				{
					highlightInfo = method_0().HighlightManager.imethod_10(xtextElement_0);
				}
			}
			if (highlightInfo != null && ((documentPaintEventArgs_0.RenderMode != DocumentRenderMode.Print && documentPaintEventArgs_0.RenderMode != DocumentRenderMode.ReadPaint && documentPaintEventArgs_0.RenderMode != DocumentRenderMode.PDF) || highlightInfo.ActiveStyle == HighlightActiveStyle.AllTime))
			{
				RectangleF lineBounds = highlightInfo.GetLineBounds(xtextElement_0);
				if (!lineBounds.IsEmpty)
				{
					float num = Math.Min(lineBounds.Top, rectangleF_0.Top);
					float height = Math.Max(lineBounds.Bottom, rectangleF_0.Bottom) - num;
					rectangleF_0.Y = num;
					rectangleF_0.Height = height;
				}
				rectangleF_0 = RectangleF.Intersect(rectangleF_0, documentPaintEventArgs_0.ClipRectangle);
				if (highlightInfo.BackColor.A != 0 && !rectangleF_0.IsEmpty)
				{
					documentPaintEventArgs_0.Graphics.FillRectangle(highlightInfo.BackColor, rectangleF_0);
				}
			}
		}

		public virtual void vmethod_2(XTextElement xtextElement_0, DocumentPaintEventArgs documentPaintEventArgs_0, RectangleF rectangleF_0)
		{
			RuntimeDocumentContentStyle runtimeStyle = xtextElement_0.RuntimeStyle;
			if (runtimeStyle.HasVisibleBorder)
			{
				runtimeStyle.DrawBorder(documentPaintEventArgs_0.Graphics, rectangleF_0);
			}
		}

		public virtual void vmethod_3(XTextElement xtextElement_0, DocumentPaintEventArgs documentPaintEventArgs_0)
		{
			if (xtextElement_0 != null && xtextElement_0.OwnerLine != null)
			{
				RectangleF empty = RectangleF.Empty;
				empty = new RectangleF(xtextElement_0.AbsLeft, xtextElement_0.AbsTop, xtextElement_0.Width + xtextElement_0.WidthFix, xtextElement_0.Height);
				if (xtextElement_0 is XTextSectionElement)
				{
					empty = documentPaintEventArgs_0.ViewBounds;
				}
				vmethod_1(xtextElement_0, documentPaintEventArgs_0, empty);
			}
		}

		public StringFormat method_3()
		{
			if (stringFormat_0 == null)
			{
				stringFormat_0 = new StringFormat();
				stringFormat_0.Alignment = StringAlignment.Center;
				stringFormat_0.FormatFlags = StringFormatFlags.NoWrap;
			}
			return stringFormat_0;
		}

		public bool method_4()
		{
			return bool_0;
		}

		public void method_5(bool bool_2)
		{
			bool_0 = bool_2;
		}

		public bool method_6()
		{
			return bool_1;
		}

		public void method_7(bool bool_2)
		{
			bool_1 = bool_2;
		}

		public void method_8()
		{
			if (bool_1)
			{
				if (dictionary_1 == null)
				{
					dictionary_1 = new Dictionary<int, Dictionary<char, SizeF>>();
				}
				else
				{
					dictionary_1.Clear();
				}
			}
			else
			{
				dictionary_1 = null;
			}
		}

		internal Class105 method_9()
		{
			if (class105_0 == null)
			{
				class105_0 = new Class105();
			}
			return class105_0;
		}

		internal DrawStringFormatExt method_10()
		{
			return smethod_0();
		}

		public static DrawStringFormatExt smethod_0()
		{
			if (drawStringFormatExt_0 == null)
			{
				drawStringFormatExt_0 = new DrawStringFormatExt();
				drawStringFormatExt_0.SetStringFormatAsGenericTypographic();
				drawStringFormatExt_0.FormatFlags = (StringFormatFlags.FitBlackBox | StringFormatFlags.MeasureTrailingSpaces | StringFormatFlags.NoClip);
			}
			return drawStringFormatExt_0;
		}

		public virtual void vmethod_4(XTextCharElement xtextCharElement_0, DCGraphics dcgraphics_0)
		{
			gstruct20_1.method_3();
			gstruct20_1.method_2(bool_1: false);
			XTextDocument xTextDocument = method_0();
			if (documentOptions_0 == null)
			{
				documentOptions_0 = xTextDocument.Options;
			}
			if (documentViewOptions_0 == null)
			{
				documentViewOptions_0 = documentOptions_0.ViewOptions;
			}
			char runtimeCharValue = xtextCharElement_0.RuntimeCharValue;
			if (bool_1 && xtextCharElement_0.FontSizeZoomRate == 1f && runtimeCharValue != '\t' && dictionary_1 != null && dictionary_1.ContainsKey(xtextCharElement_0.StyleIndex))
			{
				Dictionary<char, SizeF> dictionary = dictionary_1[xtextCharElement_0.StyleIndex];
				if (dictionary.ContainsKey(runtimeCharValue))
				{
					SizeF sizeF = dictionary[runtimeCharValue];
					xtextCharElement_0.Width = sizeF.Width;
					xtextCharElement_0.Height = sizeF.Height;
					xtextCharElement_0.float_8 = dcgraphics_0.GetFontHeight(xtextCharElement_0.RuntimeStyle.Font);
					int_0++;
					return;
				}
			}
			MeasureMode measureMode_ = xTextDocument.MeasureMode;
			if (documentViewOptions_0.RichTextBoxCompatibility)
			{
				measureMode_ = MeasureMode.RichTextBoxCompatibility;
			}
			GraphicsUnit pageUnitFast = dcgraphics_0.PageUnitFast;
			method_9().method_6(pageUnitFast);
			method_9().method_4(measureMode_);
			method_9().method_8(documentViewOptions_0.OldWhitespaceWidth);
			if (!xTextDocument.LocalConfig.OldWhitespaceWidth)
			{
				method_9().method_8(method_0().LocalConfig.OldWhitespaceWidth);
			}
			RuntimeDocumentContentStyle runtimeStyle = xtextCharElement_0.RuntimeStyle;
			SizeF empty = SizeF.Empty;
			XFontValue fastFont = runtimeStyle.GetFastFont(xtextCharElement_0.FontSizeZoomRate);
			empty = method_9().method_10(fastFont, runtimeCharValue, dcgraphics_0.NativeGraphics, dcgraphics_0.PageUnitFast);
			if (documentOptions_0.BehaviorOptions.SpecifyDebugMode)
			{
				SizeF sizeF2 = dcgraphics_0.MeasureString(xtextCharElement_0.CharValue.ToString(), fastFont, 10000, DrawStringFormatExt.GenericTypographic);
				xtextCharElement_0.float_6 = sizeF2.Height;
				xtextCharElement_0.float_5 = sizeF2.Width;
			}
			if (Class131.smethod_1(xtextCharElement_0.CharValue) && empty.Width > 0f && smethod_1())
			{
				if (Class131.smethod_4(xtextCharElement_0.CharValue))
				{
					empty.Width = 0f;
				}
				else
				{
					Size size = TextRenderer.MeasureText(dcgraphics_0.GraphisForMeasure, xtextCharElement_0.CharValue.ToString(), fastFont.Value, new Size(1000, 1000), TextFormatFlags.NoPadding);
					size.Width = (int)GraphicsUnitConvert.FromPixel(size.Width, pageUnitFast, dcgraphics_0.DpiX);
					size.Height = (int)GraphicsUnitConvert.FromPixel(size.Height, pageUnitFast, dcgraphics_0.DpiX);
					empty.Width = size.Width;
				}
			}
			xtextCharElement_0.Width = empty.Width;
			xtextCharElement_0.Height = empty.Height + 1f;
			xtextCharElement_0.float_8 = empty.Height - method_9().method_0();
			xtextCharElement_0.Height = xtextCharElement_0.float_8;
			if (runtimeStyle.CharacterCircle != 0)
			{
				xtextCharElement_0.Width = Math.Max(xtextCharElement_0.Width, xtextCharElement_0.Height) * 1.4f;
				xtextCharElement_0.Height = xtextCharElement_0.Width;
			}
			if (runtimeStyle.Superscript || runtimeStyle.Subscript)
			{
				xtextCharElement_0.Width *= 0.6f;
			}
			if (runtimeCharValue == '\u0001')
			{
				xtextCharElement_0.Width = 0f;
			}
			if (bool_1 && runtimeStyle.CharacterCircle == CharacterCircleStyles.None && dictionary_1 != null)
			{
				Dictionary<char, SizeF> dictionary2 = null;
				if (dictionary_1.ContainsKey(xtextCharElement_0.StyleIndex))
				{
					dictionary2 = dictionary_1[xtextCharElement_0.StyleIndex];
				}
				else
				{
					dictionary2 = new Dictionary<char, SizeF>();
					dictionary_1[xtextCharElement_0.StyleIndex] = dictionary2;
				}
				dictionary2[runtimeCharValue] = new SizeF(xtextCharElement_0.Width, xtextCharElement_0.Height);
			}
			xtextCharElement_0.SizeInvalid = false;
			gstruct20_1.method_4();
		}

		public DrawStringFormatExt method_11()
		{
			return drawStringFormatExt_1;
		}

		public DrawStringFormatExt method_12()
		{
			if (drawStringFormatExt_2 == null)
			{
				drawStringFormatExt_2 = new DrawStringFormatExt();
				drawStringFormatExt_2.SetStringFormatAsGenericTypographic();
				drawStringFormatExt_2.FormatFlags = (StringFormatFlags.FitBlackBox | StringFormatFlags.MeasureTrailingSpaces | StringFormatFlags.NoClip);
			}
			return drawStringFormatExt_2;
		}

		private static bool smethod_1()
		{
			if (int_1 == 0)
			{
				GClass138 gClass = Class103.smethod_4();
				if (gClass.method_34() && !gClass.method_8().method_9())
				{
					int_1 = -1;
				}
				else
				{
					int_1 = 1;
				}
			}
			return int_1 == 1;
		}

		public virtual void vmethod_5(XTextCharElement xtextCharElement_0, DocumentPaintEventArgs documentPaintEventArgs_0)
		{
			int num = 6;
			char runtimeCharValue = xtextCharElement_0.RuntimeCharValue;
			if (runtimeCharValue == '\u0001')
			{
				return;
			}
			bool flag;
			if ((flag = Class131.smethod_1(xtextCharElement_0.CharValue)) && !smethod_1())
			{
				flag = false;
			}
			string text = null;
			if (flag)
			{
				XTextElementList content = xtextCharElement_0.DocumentContentElement.Content;
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append(xtextCharElement_0.CharValue);
				int num2 = content.FastIndexOf(xtextCharElement_0);
				if (num2 >= 0)
				{
					for (int i = num2 + 1; i < content.Count; i++)
					{
						XTextCharElement xTextCharElement = content[i] as XTextCharElement;
						if (xTextCharElement == null || !Class131.smethod_1(xTextCharElement.CharValue) || xTextCharElement.Width != 0f)
						{
							break;
						}
						stringBuilder.Append(xTextCharElement.CharValue);
						if (stringBuilder.Length == 6)
						{
							break;
						}
					}
					if (stringBuilder.Length > 1)
					{
						text = stringBuilder.ToString();
					}
				}
			}
			float num3 = 0f;
			_ = documentPaintEventArgs_0.Document.Options.ViewOptions;
			RuntimeDocumentContentStyle style = documentPaintEventArgs_0.Style;
			RectangleF viewBounds = documentPaintEventArgs_0.ViewBounds;
			RectangleF rectangleF = viewBounds;
			rectangleF.Y += method_9().method_0();
			if (documentPaintEventArgs_0.RenderMode == DocumentRenderMode.PDF)
			{
				rectangleF.Height *= 1.5f;
				rectangleF.Width *= 1.5f;
			}
			else
			{
				rectangleF.Height *= 1.5f;
				rectangleF.Width *= 1.5f;
			}
			Color color = style.Color;
			if (documentPaintEventArgs_0.RenderMode == DocumentRenderMode.Print || documentPaintEventArgs_0.RenderMode == DocumentRenderMode.ReadPaint || documentPaintEventArgs_0.RenderMode == DocumentRenderMode.PDF)
			{
				color = style.RuntimePrintColor;
			}
			DCBooleanValueHasDefault dCBooleanValueHasDefault = DCBooleanValueHasDefault.Default;
			if (xtextCharElement_0.Parent is XTextFieldElementBase)
			{
				XTextFieldElementBase xTextFieldElementBase = (XTextFieldElementBase)xtextCharElement_0.Parent;
				if (xTextFieldElementBase.IsBackgroundTextElement(xtextCharElement_0))
				{
					bool flag2 = false;
					if (documentPaintEventArgs_0.RenderMode == DocumentRenderMode.Paint)
					{
						flag2 = true;
					}
					else if (documentPaintEventArgs_0.RenderMode == DocumentRenderMode.PDF)
					{
						flag2 = true;
					}
					else
					{
						if ((documentPaintEventArgs_0.RenderMode != DocumentRenderMode.Print && documentPaintEventArgs_0.RenderMode != DocumentRenderMode.ReadPaint) || !xTextFieldElementBase.RuntimePrintBackgroundText)
						{
							return;
						}
						flag2 = true;
					}
					if (flag2)
					{
						color = xTextFieldElementBase.RuntimeBackgroundTextColor;
						dCBooleanValueHasDefault = xTextFieldElementBase.BackgroundTextItalic;
					}
				}
				else if (xTextFieldElementBase is XTextInputFieldElement)
				{
					XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)xTextFieldElementBase;
					color = xTextInputFieldElement.method_35(color, style, documentPaintEventArgs_0.RenderMode == DocumentRenderMode.Print || documentPaintEventArgs_0.RenderMode == DocumentRenderMode.ReadPaint);
				}
			}
			if (documentPaintEventArgs_0.RenderMode == DocumentRenderMode.Paint)
			{
				GInterface6 highlightManager = method_0().HighlightManager;
				if (highlightManager != null)
				{
					HighlightInfo highlightInfo = highlightManager.imethod_10(xtextCharElement_0);
					if (highlightInfo != null && highlightInfo.Color.A != 0)
					{
						color = highlightInfo.Color;
					}
				}
			}
			string string_ = runtimeCharValue.ToString();
			if (text != null)
			{
				string_ = text;
			}
			if (xtextCharElement_0.LinkCharNum <= 0)
			{
			}
			if (xtextCharElement_0.Width != 0f || !Class131.smethod_1(xtextCharElement_0.CharValue))
			{
			}
			GClass438.smethod_0(documentPaintEventArgs_0.Document.method_4(color));
			Color color_ = documentPaintEventArgs_0.Document.method_4(color);
			XFontValue xFontValue = style.Font.Clone();
			xFontValue.Size *= xtextCharElement_0.FontSizeZoomRate;
			switch (dCBooleanValueHasDefault)
			{
			case DCBooleanValueHasDefault.True:
				xFontValue.Italic = true;
				break;
			case DCBooleanValueHasDefault.False:
				xFontValue.Italic = false;
				break;
			}
			if (xFontValue.Underline && documentPaintEventArgs_0.RenderMode != DocumentRenderMode.PDF)
			{
				xFontValue.Underline = false;
			}
			DrawStringFormatExt drawStringFormatExt = method_12();
			drawStringFormatExt.Color = documentPaintEventArgs_0.Document.method_4(color);
			if (style.Subscript || style.Superscript)
			{
				xFontValue.Size *= 0.6f;
				if (style.Superscript)
				{
					if (documentPaintEventArgs_0.RenderMode == DocumentRenderMode.PDF)
					{
						drawStringFormatExt.Font = xFontValue;
						drawStringFormatExt.SetBounds(rectangleF);
						documentPaintEventArgs_0.Graphics.method_2(string_, drawStringFormatExt);
					}
					else
					{
						documentPaintEventArgs_0.Graphics.DrawString(string_, xFontValue, color_, rectangleF.Left, rectangleF.Top, method_12());
					}
				}
				else
				{
					float fontHeight = documentPaintEventArgs_0.Graphics.GetFontHeight(xFontValue);
					if (documentPaintEventArgs_0.RenderMode == DocumentRenderMode.PDF)
					{
						documentPaintEventArgs_0.Graphics.DrawString(string_, xFontValue, color_, new RectangleF(rectangleF.Left, (float)Math.Floor(viewBounds.Bottom - fontHeight), rectangleF.Width, rectangleF.Height), method_12());
					}
					else
					{
						documentPaintEventArgs_0.Graphics.DrawString(string_, xFontValue, color_, rectangleF.Left, (float)Math.Floor(viewBounds.Bottom - fontHeight), method_12());
					}
					if (xtextCharElement_0.ConnectFlag)
					{
						method_13(xtextCharElement_0, xFontValue, documentPaintEventArgs_0, rectangleF, color);
					}
				}
			}
			else if ((style.Underline || style.Strikeout) && xtextCharElement_0.CharValue == ' ')
			{
				XFontValue xFontValue2 = style.Font.Clone();
				if (xFontValue2.Underline)
				{
					if (documentPaintEventArgs_0.RenderMode == DocumentRenderMode.PDF)
					{
						documentPaintEventArgs_0.Graphics.DrawString("_", xFontValue2, color_, rectangleF, method_12());
					}
				}
				else
				{
					xFontValue2.Strikeout = false;
					if (documentPaintEventArgs_0.RenderMode == DocumentRenderMode.PDF)
					{
						documentPaintEventArgs_0.Graphics.DrawString("-", xFontValue2, color_, rectangleF, method_12());
					}
				}
			}
			else if (style.CharacterCircle == CharacterCircleStyles.None)
			{
				if (flag || text != null)
				{
					GraphicsUnit pageUnit = documentPaintEventArgs_0.Graphics.PageUnit;
					float dpiX = documentPaintEventArgs_0.Graphics.DpiX;
					_ = documentPaintEventArgs_0.Graphics.DpiY;
					documentPaintEventArgs_0.Graphics.ResetClip();
					RectangleF rectangleF2 = new RectangleF(rectangleF.Left, rectangleF.Top, xtextCharElement_0.Width, xtextCharElement_0.Height);
					Matrix transform = documentPaintEventArgs_0.Graphics.Transform;
					float num4 = transform.Elements[0];
					float num5 = transform.Elements[3];
					rectangleF2.X *= num4;
					rectangleF2.Y *= num5;
					rectangleF2.X += transform.OffsetX;
					rectangleF2.Y += transform.OffsetY;
					rectangleF2.X = (float)GraphicsUnitConvert.ToPixel(rectangleF2.X, pageUnit, dpiX);
					rectangleF2.Width = (float)GraphicsUnitConvert.ToPixel(rectangleF2.Width, pageUnit, dpiX);
					rectangleF2.Y = (float)GraphicsUnitConvert.ToPixel(rectangleF2.Y, pageUnit, dpiX);
					rectangleF2.Height = (float)GraphicsUnitConvert.ToPixel(rectangleF2.Height, pageUnit, dpiX);
					XFontValue xfontValue_ = new XFontValue(xFontValue.Name, xFontValue.Size * num4 * dpiX / 96f, xFontValue.Style);
					Rectangle rectangle_ = new Rectangle((int)rectangleF2.Left, (int)rectangleF2.Top, (int)rectangleF2.Width, (int)rectangleF2.Height);
					documentPaintEventArgs_0.Graphics.method_1(string_, xfontValue_, rectangle_, color, TextFormatFlags.NoClipping | TextFormatFlags.NoPadding);
				}
				else
				{
					documentPaintEventArgs_0.Graphics.DrawString(string_, xFontValue, color_, new RectangleF(rectangleF.Left, rectangleF.Top + num3, rectangleF.Width, rectangleF.Height), method_12());
				}
				if (xtextCharElement_0.ConnectFlag)
				{
					method_13(xtextCharElement_0, xFontValue, documentPaintEventArgs_0, rectangleF, color);
				}
			}
			else
			{
				RectangleF square = RectangleCommon.GetSquare(viewBounds);
				float num6 = square.Width * 0.1f;
				square.Offset(num6, num6);
				square.Width -= num6 * 2f;
				square.Height -= num6 * 2f;
				RectangleF rectangleF_ = new RectangleF(rectangleF.Left + num6 * 2f, rectangleF.Top + num6 * 2f, rectangleF.Width - num6 * 4f, rectangleF.Height - num6 * 4f);
				using (DrawStringFormatExt drawStringFormatExt2 = method_12().Clone())
				{
					drawStringFormatExt2.Alignment = StringAlignment.Center;
					drawStringFormatExt2.LineAlignment = StringAlignment.Center;
					documentPaintEventArgs_0.Graphics.DrawString(string_, xFontValue, color_, square, drawStringFormatExt2);
				}
				if (xtextCharElement_0.ConnectFlag)
				{
					method_13(xtextCharElement_0, xFontValue, documentPaintEventArgs_0, rectangleF_, color);
				}
				switch (style.CharacterCircle)
				{
				case CharacterCircleStyles.Circle:
					documentPaintEventArgs_0.Graphics.DrawEllipse(style.Color, square);
					break;
				case CharacterCircleStyles.Rectangle:
					documentPaintEventArgs_0.Graphics.DrawRectangle(style.Color, square.Left, square.Top, square.Width, square.Height);
					break;
				}
			}
			if (style.Underline && documentPaintEventArgs_0.RenderMode != DocumentRenderMode.PDF)
			{
				float fontHeight = documentPaintEventArgs_0.Graphics.GetFontHeight(xFontValue) - 3f;
				Color color_2 = color;
				if (style.UnderlineColor.A != 0)
				{
					color_2 = style.UnderlineColor;
				}
				if (style.UnderLineStyle == TextUnderlineStyle.Single)
				{
					documentPaintEventArgs_0.Graphics.DrawLine(color_2, rectangleF.Left, rectangleF.Top + fontHeight, rectangleF.Left + xtextCharElement_0.Width + xtextCharElement_0.WidthFix, rectangleF.Top + fontHeight);
				}
				else
				{
					DrawerUtil.DrawUnderLine(documentPaintEventArgs_0.Graphics, style.UnderLineStyle, color_2, rectangleF.Left, rectangleF.Top + fontHeight, rectangleF.Left + xtextCharElement_0.Width + xtextCharElement_0.WidthFix, rectangleF.Top + fontHeight, -GraphicsUnitConvert.Convert(3, GraphicsUnit.Pixel, documentPaintEventArgs_0.Graphics.PageUnitFast));
				}
			}
			if (style.EmphasisMark)
			{
				documentPaintEventArgs_0.Graphics.ResetClip();
				float emphasisMarkSize = method_0().Options.ViewOptions.EmphasisMarkSize;
				RectangleF rect = new RectangleF(rectangleF.Left + (xtextCharElement_0.Width - emphasisMarkSize) / 2f, xtextCharElement_0.AbsBounds.Bottom + 1f, emphasisMarkSize, emphasisMarkSize);
				SmoothingMode smoothingMode = documentPaintEventArgs_0.Graphics.SmoothingMode;
				documentPaintEventArgs_0.Graphics.SmoothingMode = SmoothingMode.HighQuality;
				documentPaintEventArgs_0.Graphics.FillEllipse(color, rect);
				documentPaintEventArgs_0.Graphics.SmoothingMode = smoothingMode;
			}
		}

		private void method_13(XTextCharElement xtextCharElement_0, XFontValue xfontValue_0, DocumentPaintEventArgs documentPaintEventArgs_0, RectangleF rectangleF_0, Color color_0)
		{
			if (xtextCharElement_0.ConnectFlag && xtextCharElement_0.LinkCharNum > 0)
			{
				string string_ = new string('\u0640', xtextCharElement_0.LinkCharNum);
				using (DrawStringFormatExt drawStringFormatExt = new DrawStringFormatExt())
				{
					drawStringFormatExt.SetStringFormatAsGenericTypographic();
					drawStringFormatExt.Alignment = StringAlignment.Near;
					drawStringFormatExt.LineAlignment = StringAlignment.Near;
					drawStringFormatExt.FormatFlags = (StringFormatFlags.NoWrap | StringFormatFlags.NoClip);
					RectangleF rect = new RectangleF(rectangleF_0.Left + xtextCharElement_0.Width, rectangleF_0.Top, xtextCharElement_0.WidthFix + 10f, rectangleF_0.Height);
					if (method_0().Options.BehaviorOptions.SpecifyDebugMode)
					{
						color_0 = Color.Red;
					}
					documentPaintEventArgs_0.Graphics.DrawString(string_, xfontValue_0, color_0, rect, drawStringFormatExt);
				}
			}
		}

		protected virtual void vmethod_6(XTextBookmark xtextBookmark_0, DCGraphics dcgraphics_0)
		{
			xtextBookmark_0.Height = method_0().DefaultStyle.DefaultLineHeight;
			xtextBookmark_0.Width = method_0().PixelToDocumentUnit(4f);
			xtextBookmark_0.SizeInvalid = false;
		}

		protected virtual void vmethod_7(XTextBookmark xtextBookmark_0, DocumentPaintEventArgs documentPaintEventArgs_0)
		{
		}

		public void Dispose()
		{
			if (class105_0 != null)
			{
				class105_0.Dispose();
				class105_0 = null;
			}
			highlightInfoList_0 = null;
			xtextDocument_0 = null;
			dictionary_1 = null;
		}
	}
}
