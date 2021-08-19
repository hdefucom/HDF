using DCSoft.Common;
using DCSoft.Drawing;
using DCSoftDotfuscate;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       运行时的样式值
	///       </summary>
	[DCInternal]
	public class RuntimeDocumentContentStyle
	{
		public readonly float Zoom;

		public readonly float MarginLeft;

		public readonly float MarginTop;

		public readonly float MarginRight;

		public readonly float MarginBottom;

		public readonly bool BackgroundRepeat;

		public readonly float BackgroundPositionX;

		public readonly float BackgroundPositionY;

		public readonly Color RuntimePrintColor;

		public readonly float BorderSpacing;

		public readonly bool HasFullBorder;

		public readonly bool HasVisibleBackground;

		public readonly float SpecifyGridLineStep;

		public readonly bool HasVisibleBorder;

		public readonly DocumentContentStyle Parent;

		public readonly string Link;

		public readonly Color Color;

		internal Color ColorForRTF;

		public readonly DocumentContentAlignment Align;

		public readonly Color BackgroundColor;

		public readonly bool HasBackgroundColorValue;

		public readonly Color BackgroundColor2;

		public readonly XImageValue BackgroundImage;

		public readonly ContentAlignment BackgroundPosition;

		public readonly XBrushStyleConst BackgroundStyle;

		public readonly bool Bold;

		public readonly bool BorderBottom;

		public readonly Color BorderBottomColor;

		public readonly Color BorderColor;

		public readonly bool BorderLeft;

		public readonly Color BorderLeftColor;

		public readonly bool BorderTop;

		public readonly Color BorderTopColor;

		public readonly bool BorderRight;

		public readonly Color BorderRightColor;

		public readonly DashStyle BorderStyle;

		public readonly float BorderWidth;

		public readonly string BulletedString;

		public readonly CharacterCircleStyles CharacterCircle;

		public readonly int CommentIndex;

		public readonly int CreatorIndex;

		public readonly float DefaultLineHeight;

		public readonly int DeleterIndex;

		public readonly bool EmphasisMark;

		public readonly float FirstLineIndent;

		public readonly bool FixedSpacing;

		public readonly XFontValue Font;

		public readonly float FontHeight;

		public readonly string FontName;

		public readonly float FontSize;

		public readonly FontStyle FontStyle;

		public readonly Color GridLineColor;

		public readonly float GridLineOffsetY;

		public readonly DashStyle GridLineStyle;

		public readonly ContentGridLineType GridLineType;

		public readonly bool IsBulletedList;

		public readonly bool IsListNumberStyle;

		public readonly bool Italic;

		public readonly ContentLayoutAlign LayoutAlign;

		public readonly ContentLayoutDirectionStyle LayoutDirection;

		public readonly float LayoutGridHeight;

		public readonly float LeftIndent;

		public readonly float LetterSpacing;

		public readonly float LineSpacing;

		public readonly LineSpacingStyle LineSpacingStyle;

		public readonly bool Multiline;

		public readonly float PaddingLeft;

		public readonly float PaddingTop;

		public readonly float PaddingRight;

		public readonly float PaddingBottom;

		public readonly bool PageBreakAfter;

		public readonly bool PageBreakBefore;

		public readonly ParagraphListStyle ParagraphListStyle;

		public readonly bool ParagraphMultiLevel;

		public readonly int ParagraphOutlineLevel;

		public readonly Color PrintBackColor;

		public readonly Color PrintColor;

		public readonly ContentProtectType ProtectType;

		public readonly bool RightToLeft;

		public readonly float Rotate;

		public readonly float RoundRadio;

		public readonly float RTFLineSpacing;

		public readonly float Spacing;

		public readonly float SpacingAfterParagraph;

		public readonly float SpacingBeforeParagraph;

		public readonly bool Strikeout;

		public readonly bool Subscript;

		public readonly bool Superscript;

		public readonly float TabWidth;

		public readonly int TitleLevel;

		public readonly bool Underline;

		public readonly TextUnderlineStyle UnderLineStyle;

		public readonly Color UnderlineColor;

		public readonly bool VertialText;

		public readonly VerticalAlignStyle VerticalAlign;

		public readonly RenderVisibility Visibility;

		public readonly bool Visible;

		public readonly bool VisibleInDirectory;

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="style">样式值</param>
		internal RuntimeDocumentContentStyle(DocumentContentStyle style)
		{
			int num = 19;
			ColorForRTF = Color.Empty;
			
			if (style == null)
			{
				throw new ArgumentNullException("style");
			}
			Parent = style;
			if (XTextDocument.smethod_13(GEnum6.const_62))
			{
				Color = style.Color;
			}
			else
			{
				Color = Color.Black;
			}
			Align = style.Align;
			if (XTextDocument.smethod_13(GEnum6.const_63))
			{
				BackgroundColor = style.BackgroundColor;
				BackgroundColor2 = style.BackgroundColor2;
			}
			else
			{
				BackgroundColor = Color.Transparent;
				BackgroundColor2 = Color.Transparent;
			}
			HasBackgroundColorValue = XDependencyObject.smethod_4(style, "BackgroundColor");
			BackgroundImage = style.BackgroundImage;
			BackgroundPosition = style.BackgroundPosition;
			BackgroundStyle = style.BackgroundStyle;
			BorderBottom = style.BorderBottom;
			BorderBottomColor = style.BorderBottomColor;
			BorderColor = style.BorderColor;
			BorderLeft = style.BorderLeft;
			BorderLeftColor = style.BorderLeftColor;
			BorderTop = style.BorderTop;
			BorderTopColor = style.BorderTopColor;
			BorderRight = style.BorderRight;
			BorderRightColor = style.BorderRightColor;
			BorderStyle = style.BorderStyle;
			BorderWidth = style.BorderWidth;
			ParagraphListStyle paragraphListStyle = style.ParagraphListStyle;
			if (style.IsBulletedList)
			{
				if (XTextDocument.smethod_13(GEnum6.const_81))
				{
					IsBulletedList = style.IsBulletedList;
					paragraphListStyle = ((!XTextDocument.smethod_13(GEnum6.const_82)) ? ParagraphListStyle.BulletedList : style.ParagraphListStyle);
				}
				else
				{
					IsBulletedList = false;
					paragraphListStyle = ParagraphListStyle.None;
				}
			}
			else if (style.IsListNumberStyle)
			{
				if (XTextDocument.smethod_13(GEnum6.const_80))
				{
					IsListNumberStyle = style.IsListNumberStyle;
					paragraphListStyle = ((!XTextDocument.smethod_13(GEnum6.const_82)) ? ParagraphListStyle.ListNumberStyle : style.ParagraphListStyle);
				}
				else
				{
					IsListNumberStyle = false;
					paragraphListStyle = ParagraphListStyle.None;
				}
			}
			BulletedString = GClass470.smethod_2(paragraphListStyle);
			ParagraphListStyle = paragraphListStyle;
			if (XTextDocument.smethod_13(GEnum6.const_78))
			{
				FirstLineIndent = style.FirstLineIndent;
			}
			else
			{
				FirstLineIndent = 0f;
			}
			FixedSpacing = style.FixedSpacing;
			if (XTextDocument.smethod_13(GEnum6.const_66))
			{
				CharacterCircle = style.CharacterCircle;
			}
			else
			{
				CharacterCircle = CharacterCircleStyles.None;
			}
			if (XTextDocument.smethod_13(GEnum6.const_148))
			{
				CommentIndex = style.CommentIndex;
			}
			else
			{
				CommentIndex = -1;
			}
			if (XTextDocument.smethod_13(GEnum6.const_133))
			{
				CreatorIndex = style.CreatorIndex;
				DeleterIndex = style.DeleterIndex;
			}
			else
			{
				CreatorIndex = -1;
				DeleterIndex = -1;
			}
			DefaultLineHeight = style.DefaultLineHeight;
			if (XTextDocument.smethod_13(GEnum6.const_65))
			{
				EmphasisMark = style.EmphasisMark;
			}
			else
			{
				EmphasisMark = false;
			}
			if (XTextDocument.smethod_13(GEnum6.const_59))
			{
				Font = style.Font;
				FontHeight = style.FontHeight;
				FontName = style.FontName;
			}
			if (XTextDocument.smethod_13(GEnum6.const_60))
			{
				FontSize = style.FontSize;
			}
			else
			{
				FontSize = XFontValue.DefaultFontSize;
			}
			if (XTextDocument.smethod_13(GEnum6.const_61))
			{
				FontStyle = style.FontStyle;
				Bold = style.Bold;
				Underline = style.Underline;
				Strikeout = style.Strikeout;
				Italic = style.Italic;
				UnderLineStyle = style.UnderlineStyle;
				if (!string.IsNullOrEmpty(style.UnderlineColor))
				{
					UnderlineColor = XMLSerializeHelper.StringToColor(style.UnderlineColor, style.Color);
				}
			}
			else
			{
				FontStyle = FontStyle.Regular;
				Bold = false;
				Underline = false;
				Strikeout = false;
				Italic = false;
				UnderLineStyle = TextUnderlineStyle.Single;
				UnderlineColor = style.Color;
			}
			GridLineColor = style.GridLineColor;
			GridLineOffsetY = style.GridLineOffsetY;
			GridLineStyle = style.GridLineStyle;
			GridLineType = style.GridLineType;
			LayoutAlign = style.LayoutAlign;
			if (LayoutAlign == ContentLayoutAlign.Surroundings && !XTextDocument.smethod_13(GEnum6.const_73))
			{
				LayoutAlign = ContentLayoutAlign.EmbedInText;
			}
			LayoutDirection = style.LayoutDirection;
			LayoutGridHeight = style.LayoutGridHeight;
			LeftIndent = style.LeftIndent;
			LetterSpacing = style.LetterSpacing;
			if (XTextDocument.smethod_13(GEnum6.const_79))
			{
				LineSpacing = style.LineSpacing;
				LineSpacingStyle = style.LineSpacingStyle;
			}
			else
			{
				LineSpacing = 0f;
				LineSpacingStyle = LineSpacingStyle.SpaceSingle;
			}
			Multiline = style.Multiline;
			PaddingLeft = style.PaddingLeft;
			PaddingTop = style.PaddingTop;
			PaddingRight = style.PaddingRight;
			PaddingBottom = style.PaddingBottom;
			PageBreakAfter = style.PageBreakAfter;
			PageBreakBefore = style.PageBreakBefore;
			ParagraphMultiLevel = style.ParagraphMultiLevel;
			ParagraphOutlineLevel = style.ParagraphOutlineLevel;
			PrintBackColor = style.PrintBackColor;
			PrintColor = style.PrintColor;
			if (XTextDocument.smethod_13(GEnum6.const_134))
			{
				ProtectType = style.ProtectType;
			}
			else
			{
				ProtectType = ContentProtectType.None;
			}
			RightToLeft = style.RightToLeft;
			Rotate = style.Rotate;
			RoundRadio = style.RoundRadio;
			RTFLineSpacing = style.RTFLineSpacing;
			Spacing = style.Spacing;
			if (XTextDocument.smethod_13(GEnum6.const_77))
			{
				SpacingAfterParagraph = style.SpacingAfterParagraph;
				SpacingBeforeParagraph = style.SpacingBeforeParagraph;
			}
			else
			{
				SpacingAfterParagraph = 0f;
				SpacingBeforeParagraph = 0f;
			}
			if (XTextDocument.smethod_13(GEnum6.const_64))
			{
				Subscript = style.Subscript;
				Superscript = style.Superscript;
			}
			else
			{
				Subscript = false;
				Superscript = false;
			}
			TabWidth = style.TabWidth;
			if (XTextDocument.smethod_13(GEnum6.const_84))
			{
				TitleLevel = style.TitleLevel;
			}
			else
			{
				TitleLevel = -1;
			}
			VertialText = style.VertialText;
			VerticalAlign = style.VerticalAlign;
			Visibility = style.Visibility;
			Visible = style.Visible;
			VisibleInDirectory = style.VisibleInDirectory;
			Link = style.Link;
			HasVisibleBorder = style.HasVisibleBorder;
			HasVisibleBackground = style.HasVisibleBackground;
			HasFullBorder = style.HasFullBorder;
			SpecifyGridLineStep = style.SpecifyGridLineStep;
			BorderSpacing = style.BorderSpacing;
			RuntimePrintColor = style.RuntimePrintColor;
			BackgroundPositionX = style.BackgroundPositionX;
			BackgroundPositionY = style.BackgroundPositionY;
			BackgroundRepeat = style.BackgroundRepeat;
			MarginLeft = style.MarginLeft;
			MarginTop = style.MarginTop;
			MarginRight = style.MarginRight;
			MarginBottom = style.MarginBottom;
			Zoom = style.Zoom;
		}

		/// <summary>
		///       根据设置创建绘制背景的画刷对象
		///       </summary>
		/// <returns>创建的画刷对象</returns>
		[DCInternal]
		public Brush CreateBackgroundBrush()
		{
			return CreateBackgroundBrush(GraphicsUnit.Pixel);
		}

		/// <summary>
		///       根据设置创建绘制背景的画刷对象
		///       </summary>
		/// <param name="unit">单位</param>
		/// <returns>创建的画刷对象</returns>
		[DCInternal]
		public Brush CreateBackgroundBrush(GraphicsUnit unit)
		{
			return CreateBackgroundBrush(new RectangleF(0f, 0f, 100f, 100f), unit);
		}

		/// <summary>
		///       根据设置创建绘制背景的画刷对象
		///       </summary>
		/// <param name="rect">矩形区域</param>
		/// <param name="unit">单位</param>
		/// <returns>创建的画刷对象</returns>
		[DCInternal]
		public Brush CreateBackgroundBrush(RectangleF rect, GraphicsUnit unit)
		{
			XBrushStyle xBrushStyle = CreateBackgroundBrush2(rect, unit);
			return xBrushStyle.method_4(rect, unit);
		}

		[DCInternal]
		public XBrushStyle CreateBackgroundBrush2()
		{
			return CreateBackgroundBrush2(new RectangleF(0f, 0f, 100f, 100f), GraphicsUnit.Pixel);
		}

		[DCInternal]
		public XBrushStyle CreateBackgroundBrush2(RectangleF rect)
		{
			return CreateBackgroundBrush2(rect, GraphicsUnit.Pixel);
		}

		[DCInternal]
		public XBrushStyle CreateBackgroundBrush2(RectangleF rect, GraphicsUnit unit)
		{
			XBrushStyle xBrushStyle = new XBrushStyle();
			xBrushStyle.Style = BackgroundStyle;
			xBrushStyle.Color = BackgroundColor;
			xBrushStyle.Color2 = BackgroundColor2;
			xBrushStyle.Style = BackgroundStyle;
			xBrushStyle.Image = BackgroundImage;
			xBrushStyle.Repeat = BackgroundRepeat;
			xBrushStyle.OffsetX = BackgroundPositionX;
			xBrushStyle.OffsetY = BackgroundPositionY;
			return xBrushStyle;
		}

		public string GetParagraphListText(int number)
		{
			return GClass470.smethod_5(number, ParagraphListStyle);
		}

		/// <summary>
		///       比较两个样式的边框设置是否一样
		///       </summary>
		/// <param name="style">另外一个样式对象</param>
		/// <returns>边框设置是否一样</returns>
		[DCInternal]
		public bool EqualsBorderStyle(RuntimeDocumentContentStyle style)
		{
			if (style == null)
			{
				return false;
			}
			if (style == this)
			{
				return true;
			}
			if (style.BorderLeft == BorderLeft && style.BorderTop == BorderTop && style.BorderRight == BorderRight && style.BorderBottom == BorderBottom && style.BorderLeftColor == BorderLeftColor && style.BorderTopColor == BorderTopColor && style.BorderRightColor == BorderRightColor && style.BorderBottomColor == BorderBottomColor && style.BorderWidth == BorderWidth && style.BorderStyle == BorderStyle)
			{
				return true;
			}
			return false;
		}

		/// <summary>
		///       根据设置创建绘制边框的画笔对象
		///       </summary>
		/// <returns>创建的画笔对象</returns>
		[DCInternal]
		public Pen CreateBorderPen()
		{
			Pen pen = new Pen(BorderTopColor, BorderWidth);
			pen.DashStyle = BorderStyle;
			return pen;
		}

		/// <summary>
		///       根据设置创建绘制边框的画笔对象
		///       </summary>
		/// <returns>创建的画笔对象</returns>
		[DCInternal]
		public XPenStyle CreateBorderPen2()
		{
			return new XPenStyle(BorderTopColor, BorderWidth, BorderStyle);
		}

		/// <summary>
		///       获得实际使用的行间距
		///       </summary>
		/// <param name="contentHeight">文本行内容高度</param>
		/// <param name="maxFontHeight">文本行中最大的字体高度</param>
		/// <param name="documentUnit">文档采用的度量单位</param>
		/// <returns>使用的行间距</returns>
		[DCInternal]
		public float GetLineSpacing(float contentHeight, float maxFontHeight, GraphicsUnit documentUnit)
		{
			LineSpacingStyle lineSpacingStyle = LineSpacingStyle;
			if (lineSpacingStyle == LineSpacingStyle.SpaceSpecify)
			{
				return LineSpacing;
			}
			if (lineSpacingStyle == LineSpacingStyle.SpaceSpecify)
			{
				return contentHeight + maxFontHeight * 0.1f;
			}
			float result = 0f;
			switch (lineSpacingStyle)
			{
			case LineSpacingStyle.SpaceSingle:
				result = contentHeight + maxFontHeight * 0.1f;
				break;
			case LineSpacingStyle.Space1pt5:
				result = contentHeight + maxFontHeight * 0.6f;
				break;
			case LineSpacingStyle.SpaceDouble:
				result = contentHeight + maxFontHeight * 1.1f;
				break;
			case LineSpacingStyle.SpaceExactly:
				result = Math.Max(contentHeight, maxFontHeight);
				break;
			case LineSpacingStyle.SpaceMultiple:
				result = contentHeight + maxFontHeight * (LineSpacing - 1f + 0.1f);
				break;
			}
			return result;
		}

		internal RuntimeDocumentContentStyle CloneInstance()
		{
			return (RuntimeDocumentContentStyle)MemberwiseClone();
		}

		public DocumentContentStyle CloneParent()
		{
			return (DocumentContentStyle)Parent.Clone();
		}

		public DocumentContentStyle CloneWithoutBorder()
		{
			return Parent.method_34();
		}

		/// <summary>
		///       根据对象设置绘制边框
		///       </summary>
		/// <param name="g">
		/// </param>
		/// <param name="rectangle">
		/// </param>
		[DCInternal]
		public void DrawBorder(DCGraphics dcgraphics_0, RectangleF rectangle)
		{
			float borderWidth = BorderWidth;
			DashStyle borderStyle = BorderStyle;
			DrawBorder(dcgraphics_0, rectangle, BorderLeft, BorderLeftColor, borderWidth, borderStyle, BorderTop, BorderTopColor, borderWidth, borderStyle, BorderRight, BorderRightColor, borderWidth, borderStyle, BorderBottom, BorderBottomColor, borderWidth, borderStyle);
		}

		[DCInternal]
		public static void DrawBorder(DCGraphics dcgraphics_0, Pen pen_0, RectangleF rectangle, bool leftBorder, bool topBorder, bool rightBorder, bool bottomBorder)
		{
			if (leftBorder && topBorder && rightBorder && bottomBorder)
			{
				dcgraphics_0.DrawRectangle(pen_0, rectangle.Left, rectangle.Top, rectangle.Width, rectangle.Height);
				return;
			}
			if (leftBorder)
			{
				dcgraphics_0.DrawLine(pen_0, rectangle.Left, rectangle.Bottom, rectangle.Left, rectangle.Top);
			}
			if (topBorder)
			{
				dcgraphics_0.DrawLine(pen_0, rectangle.Left, rectangle.Top, rectangle.Right, rectangle.Top);
			}
			if (rightBorder)
			{
				dcgraphics_0.DrawLine(pen_0, rectangle.Right, rectangle.Top, rectangle.Right, rectangle.Bottom);
			}
			if (bottomBorder)
			{
				dcgraphics_0.DrawLine(pen_0, rectangle.Left, rectangle.Bottom, rectangle.Right, rectangle.Bottom);
			}
		}

		[DCInternal]
		public static void DrawBorder(DCGraphics dcgraphics_0, RectangleF bounds, bool leftBorder, Color leftColor, float leftWidth, DashStyle leftStyle, bool topBorder, Color topColor, float topWidth, DashStyle topStyle, bool rightBorder, Color rightColor, float rightWidth, DashStyle rightStyle, bool bottomBorder, Color bottomColor, float bottomWidth, DashStyle bottomStyle)
		{
			if (leftColor == topColor && topColor == rightColor && rightColor == bottomColor && leftWidth == topWidth && topWidth == rightWidth && rightWidth == bottomWidth && leftStyle == topStyle && topStyle == rightStyle && rightStyle == bottomStyle && leftBorder && topBorder && rightBorder && bottomBorder)
			{
				if (leftColor.A != 0 && leftWidth > 0f)
				{
					XPenStyle xPenStyle = new XPenStyle(leftColor, leftWidth);
					xPenStyle.DashStyle = leftStyle;
					dcgraphics_0.DrawRectangle(xPenStyle, bounds.Left, bounds.Top, bounds.Width, bounds.Height);
				}
				return;
			}
			if (leftBorder && leftColor.A != 0 && leftWidth > 0f)
			{
				XPenStyle xPenStyle = new XPenStyle(leftColor, leftWidth);
				xPenStyle.DashStyle = leftStyle;
				dcgraphics_0.DrawLine(xPenStyle, bounds.Left, bounds.Top, bounds.Left, bounds.Bottom);
			}
			if (topBorder && topColor.A != 0 && topWidth > 0f)
			{
				XPenStyle xPenStyle = new XPenStyle(topColor, topWidth);
				xPenStyle.DashStyle = topStyle;
				dcgraphics_0.DrawLine(xPenStyle, bounds.Left, bounds.Top, bounds.Right, bounds.Top);
			}
			if (rightBorder && rightColor.A != 0 && rightWidth > 0f)
			{
				XPenStyle xPenStyle = new XPenStyle(rightColor, rightWidth);
				xPenStyle.DashStyle = rightStyle;
				dcgraphics_0.DrawLine(xPenStyle, bounds.Right, bounds.Top, bounds.Right, bounds.Bottom);
			}
			if (bottomBorder && bottomColor.A != 0 && bottomWidth > 0f)
			{
				XPenStyle xPenStyle = new XPenStyle(bottomColor, bottomWidth);
				xPenStyle.DashStyle = bottomStyle;
				dcgraphics_0.DrawLine(xPenStyle, bounds.Left, bounds.Bottom, bounds.Right, bounds.Bottom);
			}
		}

		/// <summary>
		///       获得客户区边界
		///       </summary>
		/// <param name="bounds">原始边界</param>
		/// <returns>获得的客户区边界</returns>
		[DCInternal]
		public RectangleF GetClientRectangleF(RectangleF bounds)
		{
			return new RectangleF(bounds.Left + PaddingLeft, bounds.Top + PaddingTop, bounds.Width - PaddingLeft - PaddingRight, bounds.Height - PaddingTop - PaddingBottom);
		}

		/// <summary>
		///       获得客户区边界
		///       </summary>
		/// <param name="left">原始边界左端位置</param>
		/// <param name="top">原始边界顶端位置</param>
		/// <param name="width">原始边界宽度</param>
		/// <param name="height">原始边界高度</param>
		/// <returns>获得的客户区边界</returns>
		[DCInternal]
		public RectangleF GetClientRectangleF(float left, float float_0, float width, float height)
		{
			return new RectangleF(left + PaddingLeft, float_0 + PaddingTop, width - PaddingLeft - PaddingRight, height - PaddingTop - PaddingBottom);
		}

		internal XFontValue GetFastFont(float fontSizeZoomRate)
		{
			XFontValue xFontValue = Font;
			if (fontSizeZoomRate != 1f)
			{
				xFontValue = xFontValue.Clone();
				xFontValue.Size *= fontSizeZoomRate;
			}
			return xFontValue;
		}
	}
}
