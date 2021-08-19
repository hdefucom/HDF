using DCSoft.Drawing;
using DCSoft.HtmlDom;
using DCSoftDotfuscate;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Text;
using System.Web;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       加载HTML文档事件参数
	///       </summary>
	[ComVisible(false)]
	public class ReadHTMLEventArgs
	{
		private bool _DoubleWhitespace = false;

		private XTextDocument _TextDocument = null;

		private HTMLDocument _HtmlDocument = null;

		private GClass163 _HtmlElement = null;

		private GClass222 _CurrentStyle = null;

		private static Dictionary<string, Color> htmlColors = null;

		private static string[] _fontNames = null;

		/// <summary>
		///       是否双倍扩展空格
		///       </summary>
		public bool DoubleWhitespace
		{
			get
			{
				return _DoubleWhitespace;
			}
			set
			{
				_DoubleWhitespace = value;
			}
		}

		/// <summary>
		///       文档对象
		///       </summary>
		public XTextDocument TextDocument => _TextDocument;

		/// <summary>
		///       HTML文档对象
		///       </summary>
		public HTMLDocument HtmlDocument => _HtmlDocument;

		/// <summary>
		///       HTML元素节点
		///       </summary>
		public GClass163 HtmlElement => _HtmlElement;

		/// <summary>
		///       父节点样式
		///       </summary>
		public GClass222 CurrentStyle
		{
			get
			{
				return _CurrentStyle;
			}
			set
			{
				_CurrentStyle = value;
			}
		}

		public ReadHTMLEventArgs(ReadHTMLEventArgs baseArgs, GClass163 element, XTextDocument textDocument, GClass222 currentStyle)
		{
			if (baseArgs != null)
			{
				_DoubleWhitespace = baseArgs._DoubleWhitespace;
			}
			_HtmlElement = element;
			_HtmlDocument = element.method_6();
			_TextDocument = textDocument;
			_CurrentStyle = currentStyle;
		}

		public SizeF ReadImageSize(GClass163 element)
		{
			int num = 0;
			float width = -1f;
			if (element.method_13("width"))
			{
				width = ToLength(element.method_9("width"));
			}
			if (element.method_0().method_4("width"))
			{
				float num2 = ToLength(element.method_0().method_5("width"));
				if (num2 > 0f)
				{
					width = num2;
				}
			}
			float height = -1f;
			if (element.method_13("height"))
			{
				height = ToLength(element.method_9("height"));
			}
			if (element.method_0().method_4("height"))
			{
				float num2 = ToLength(element.method_0().method_5("height"));
				if (num2 > 0f)
				{
					height = num2;
				}
			}
			return new SizeF(width, height);
		}

		public string GetDCTypeName(GClass163 gclass163_0)
		{
			int num = 4;
			return gclass163_0?.method_9("dctype");
		}

		public bool IsDCIgnore(GClass163 gclass163_0)
		{
			int num = 6;
			if (gclass163_0 == null)
			{
				return true;
			}
			return gclass163_0.method_9("dcignore") == "1";
		}

		public int ReadDCCustomAttributes(GClass163 element, object instance)
		{
			int num = 1;
			if (instance == null)
			{
				throw new ArgumentNullException("instance");
			}
			int num2 = 0;
			GClass116[] array = GClass116.smethod_1(instance.GetType());
			GClass116[] array2 = array;
			foreach (GClass116 gClass in array2)
			{
				GClass229 gClass2 = element.method_8().method_1(gClass.method_1().ToLower());
				if (gClass2 != null && !string.IsNullOrEmpty(gClass2.string_1) && gClass.method_5())
				{
					string string_ = HttpUtility.HtmlDecode(gClass2.string_1);
					gClass.method_7(instance, string_);
					num2++;
				}
			}
			return num2;
		}

		public DocumentContentStyle CreateContentStyle(GClass222 style, XTextElement targetElement, GClass163 sourceHtmlElement)
		{
			int num = 18;
			DocumentContentStyle documentContentStyle = new DocumentContentStyle();
			if (style != null)
			{
				foreach (GClass229 item in style.method_3())
				{
					ParseStyleItem(documentContentStyle, item.string_0, item.string_1, targetElement);
				}
			}
			if (sourceHtmlElement != null)
			{
				GClass163 gClass = sourceHtmlElement;
				while (gClass != null)
				{
					if (!gClass.method_13("refcommentindex"))
					{
						gClass = gClass.method_39();
						continue;
					}
					int result = -1;
					if (int.TryParse(gClass.method_9("refcommentindex"), out result))
					{
						documentContentStyle.CommentIndex = result;
					}
					break;
				}
			}
			return documentContentStyle;
		}

		private void ParseStyleItem(DocumentContentStyle cstyle, string styleName, string styleValue, XTextElement targetElement)
		{
			int num = 14;
			styleName = styleName.Trim().ToLower();
			switch (styleName)
			{
			case "dc_sup":
				cstyle.Superscript = true;
				cstyle.Subscript = false;
				break;
			case "dc_sub":
				cstyle.Superscript = false;
				cstyle.Subscript = true;
				break;
			case "text-decoration":
				if (styleValue != null)
				{
					switch (styleValue.Trim().ToLower())
					{
					case "line-through":
						cstyle.Strikeout = true;
						break;
					case "underline":
						cstyle.Underline = true;
						break;
					}
				}
				break;
			case "width":
			{
				float length = 0f;
				if (TryParseLength(styleValue, out length))
				{
					cstyle.float_1 = length;
				}
				break;
			}
			case "height":
			{
				float length = 0f;
				if (TryParseLength(styleValue, out length))
				{
					cstyle.float_2 = length;
				}
				break;
			}
			case "background":
			{
				string[] array2 = SplitItems(styleValue);
				if (array2 == null)
				{
					break;
				}
				string[] array3 = array2;
				foreach (string text in array3)
				{
					Color color = Color.Empty;
					string attributeUrl = GetAttributeUrl(text);
					if (attributeUrl != null)
					{
						attributeUrl = HtmlDocument.GetAbsoluteURL(attributeUrl);
						XImageValue xImageValue = new XImageValue();
						if (xImageValue.Load(attributeUrl) <= 0)
						{
							cstyle.BackgroundImage = xImageValue;
						}
					}
					else if (TryParseColor(text, out color))
					{
						cstyle.BackgroundColor = color;
					}
					else if (string.Equals(text, "repeat", StringComparison.CurrentCultureIgnoreCase))
					{
						cstyle.BackgroundRepeat = true;
					}
					else if (string.Equals(text, "no-repeat", StringComparison.CurrentCultureIgnoreCase))
					{
						cstyle.BackgroundRepeat = false;
					}
				}
				break;
			}
			case "background-color":
			{
				Color color = Color.Empty;
				if (TryParseColor(styleValue, out color))
				{
					cstyle.BackgroundColor = color;
				}
				break;
			}
			case "background-repeat":
			{
				string a = Trim(styleValue);
				if (string.Equals(a, "repeat", StringComparison.CurrentCultureIgnoreCase))
				{
					cstyle.BackgroundRepeat = true;
				}
				else if (string.Equals(a, "no-repeat", StringComparison.CurrentCultureIgnoreCase))
				{
					cstyle.BackgroundRepeat = false;
				}
				else
				{
					cstyle.BackgroundRepeat = true;
				}
				break;
			}
			case "border-left-style":
			{
				DashStyle style2 = DashStyle.Solid;
				if (TryParseBorderStyle(styleValue, out style2))
				{
					cstyle.BorderStyle = style2;
					if (style2 == DashStyle.Custom)
					{
						cstyle.BorderStyle = DashStyle.Solid;
						cstyle.BorderWidth = 0f;
					}
					cstyle.BorderLeft = true;
				}
				break;
			}
			case "border-top-style":
			{
				DashStyle style2 = DashStyle.Solid;
				if (TryParseBorderStyle(styleValue, out style2))
				{
					cstyle.BorderStyle = style2;
					if (style2 == DashStyle.Custom)
					{
						cstyle.BorderStyle = DashStyle.Solid;
						cstyle.BorderWidth = 0f;
					}
					cstyle.BorderTop = true;
				}
				break;
			}
			case "border-right-style":
			{
				DashStyle style2 = DashStyle.Solid;
				if (TryParseBorderStyle(styleValue, out style2))
				{
					cstyle.BorderStyle = style2;
					if (style2 == DashStyle.Custom)
					{
						cstyle.BorderStyle = DashStyle.Solid;
						cstyle.BorderWidth = 0f;
					}
					cstyle.BorderRight = true;
				}
				break;
			}
			case "border-bottom-style":
			{
				DashStyle style2 = DashStyle.Solid;
				if (TryParseBorderStyle(styleValue, out style2))
				{
					cstyle.BorderStyle = style2;
					if (style2 == DashStyle.Custom)
					{
						cstyle.BorderStyle = DashStyle.Solid;
						cstyle.BorderWidth = 0f;
					}
					cstyle.BorderBottom = true;
				}
				break;
			}
			case "border-left-color":
			{
				Color color = Color.Black;
				if (TryParseColor(styleValue, out color))
				{
					cstyle.BorderLeft = true;
					cstyle.BorderLeftColor = color;
				}
				break;
			}
			case "border-bottom-color":
			{
				Color color = Color.Black;
				if (TryParseColor(styleValue, out color))
				{
					cstyle.BorderBottom = true;
					cstyle.BorderBottomColor = color;
				}
				break;
			}
			case "border-top-color":
			{
				Color color = Color.Black;
				if (TryParseColor(styleValue, out color))
				{
					cstyle.BorderTop = true;
					cstyle.BorderTopColor = color;
				}
				break;
			}
			case "border-right-color":
			{
				Color color = Color.Black;
				if (TryParseColor(styleValue, out color))
				{
					cstyle.BorderRight = true;
					cstyle.BorderRightColor = color;
				}
				break;
			}
			case "border-left":
			case "border-top":
			case "border-right":
			case "border-bottom":
			{
				switch (styleName)
				{
				case "border-left":
					cstyle.BorderLeft = true;
					break;
				case "border-top":
					cstyle.BorderTop = true;
					break;
				case "border-right":
					cstyle.BorderRight = true;
					break;
				case "border-bottom":
					cstyle.BorderBottom = true;
					break;
				}
				string[] array2 = SplitItems(styleValue);
				if (array2 == null)
				{
					break;
				}
				string[] array3 = array2;
				int num2 = 0;
				while (true)
				{
					if (num2 >= array3.Length)
					{
						return;
					}
					string text = array3[num2];
					DashStyle style = DashStyle.Custom;
					Color color = Color.Empty;
					float width = 0f;
					if (TryParseBorderStyle(text, out style))
					{
						cstyle.BorderStyle = style;
						if (style == DashStyle.Custom)
						{
							break;
						}
					}
					else if (TryParseColor(text, out color))
					{
						switch (styleName)
						{
						case "border-left":
							cstyle.BorderLeftColor = color;
							break;
						case "border-top":
							cstyle.BorderTopColor = color;
							break;
						case "border-right":
							cstyle.BorderRightColor = color;
							break;
						case "border-bottom":
							cstyle.BorderBottomColor = color;
							break;
						}
					}
					else if (TryParseBorderWidth(text, ref width))
					{
						cstyle.BorderWidth = width;
					}
					num2++;
				}
				cstyle.BorderStyle = DashStyle.Solid;
				cstyle.BorderWidth = 0f;
				break;
			}
			case "border":
			{
				cstyle.BorderLeft = true;
				cstyle.BorderTop = true;
				cstyle.BorderRight = true;
				cstyle.BorderBottom = true;
				string[] array2 = SplitItems(styleValue);
				if (array2 == null)
				{
					break;
				}
				string[] array3 = array2;
				int num2 = 0;
				while (true)
				{
					if (num2 >= array3.Length)
					{
						return;
					}
					string text = array3[num2];
					DashStyle style = DashStyle.Custom;
					Color color = Color.Empty;
					float width = 0f;
					if (TryParseBorderStyle(text, out style))
					{
						cstyle.BorderStyle = style;
						if (style == DashStyle.Custom)
						{
							break;
						}
					}
					else if (TryParseColor(text, out color))
					{
						cstyle.BorderColor = color;
					}
					else if (TryParseBorderWidth(text, ref width))
					{
						cstyle.BorderWidth = width;
					}
					num2++;
				}
				cstyle.BorderStyle = DashStyle.Solid;
				cstyle.BorderWidth = 0f;
				break;
			}
			case "border-color":
			{
				cstyle.BorderLeft = true;
				cstyle.BorderTop = true;
				cstyle.BorderRight = true;
				cstyle.BorderBottom = true;
				Color[] array = ParseMultiColors(styleValue);
				if (array != null && array.Length == 1)
				{
					cstyle.BorderLeftColor = array[0];
					cstyle.BorderTopColor = array[0];
					cstyle.BorderRightColor = array[0];
					cstyle.BorderBottomColor = array[0];
				}
				else if (array != null && array.Length == 2)
				{
					cstyle.BorderTopColor = array[0];
					cstyle.BorderBottomColor = array[0];
					cstyle.BorderLeftColor = array[1];
					cstyle.BorderRightColor = array[1];
				}
				else if (array != null && array.Length == 3)
				{
					cstyle.BorderTopColor = array[0];
					cstyle.BorderRightColor = array[1];
					cstyle.BorderLeftColor = array[2];
					cstyle.BorderBottomColor = array[2];
				}
				else if (array != null && array.Length >= 4)
				{
					cstyle.BorderTopColor = array[0];
					cstyle.BorderRightColor = array[1];
					cstyle.BorderBottomColor = array[2];
					cstyle.BorderLeftColor = array[3];
				}
				break;
			}
			case "border-left-width":
			{
				float width = 0f;
				if (TryParseBorderWidth(styleValue, ref width))
				{
					cstyle.BorderWidth = width;
					cstyle.BorderLeft = true;
				}
				break;
			}
			case "border-top-width":
			{
				float width = 0f;
				if (TryParseBorderWidth(styleValue, ref width))
				{
					cstyle.BorderWidth = width;
					cstyle.BorderTop = true;
				}
				break;
			}
			case "border-right-width":
			{
				float width = 0f;
				if (TryParseBorderWidth(styleValue, ref width))
				{
					cstyle.BorderWidth = width;
					cstyle.BorderRight = true;
				}
				break;
			}
			case "border-bottom-width":
			{
				float width = 0f;
				if (TryParseBorderWidth(styleValue, ref width))
				{
					cstyle.BorderWidth = width;
					cstyle.BorderBottom = true;
				}
				break;
			}
			case "border-width":
			{
				float width = 0f;
				if (TryParseBorderWidth(styleValue, ref width))
				{
					cstyle.BorderWidth = width;
					cstyle.BorderLeft = true;
					cstyle.BorderTop = true;
					cstyle.BorderRight = true;
					cstyle.BorderBottom = true;
				}
				break;
			}
			case "border-style":
			{
				DashStyle style2 = DashStyle.Solid;
				if (TryParseBorderStyle(styleValue, out style2))
				{
					cstyle.BorderStyle = style2;
					if (style2 == DashStyle.Custom)
					{
						cstyle.BorderStyle = DashStyle.Solid;
						cstyle.BorderWidth = 0f;
					}
					cstyle.BorderLeft = true;
					cstyle.BorderTop = true;
					cstyle.BorderRight = true;
					cstyle.BorderBottom = true;
				}
				break;
			}
			case "color":
			{
				Color color = Color.Empty;
				if (TryParseColor(styleValue, out color))
				{
					cstyle.Color = color;
				}
				break;
			}
			case "font":
			{
				string[] array2 = SplitItems(styleValue);
				if (array2 == null)
				{
					break;
				}
				foreach (string text in array2)
				{
					float length2 = 0f;
					if (string.Equals(text, "italic", StringComparison.CurrentCultureIgnoreCase))
					{
						cstyle.Italic = true;
						continue;
					}
					if (string.Equals(text, "oblique", StringComparison.CurrentCultureIgnoreCase))
					{
						cstyle.Italic = true;
						continue;
					}
					if (string.Equals(text, "bold", StringComparison.CurrentCultureIgnoreCase))
					{
						cstyle.Bold = true;
						continue;
					}
					if (string.Equals(text, "bolder", StringComparison.CurrentCultureIgnoreCase))
					{
						cstyle.Bold = true;
						continue;
					}
					if (TryParseLength(text, out length2))
					{
						cstyle.FontSize = GraphicsUnitConvert.Convert(length2, TextDocument.DocumentGraphicsUnit, GraphicsUnit.Point);
						continue;
					}
					string fontName2 = GetFontName(text);
					if (fontName2 != null)
					{
						cstyle.FontName = fontName2;
					}
				}
				break;
			}
			case "font-family":
			{
				string fontName = GetFontName(styleValue);
				if (fontName != null)
				{
					cstyle.FontName = fontName;
				}
				break;
			}
			case "font-size":
			{
				float length2 = 0f;
				if (TryParseLength(styleValue, out length2))
				{
					cstyle.FontSize = GraphicsUnitConvert.Convert(length2, TextDocument.DocumentGraphicsUnit, GraphicsUnit.Point);
				}
				break;
			}
			case "font-style":
				if (Contains(styleValue, "italic") || Contains(styleValue, "oblique"))
				{
					cstyle.Italic = true;
				}
				break;
			case "font-weight":
				if (Contains(styleValue, "bold"))
				{
					cstyle.Bold = true;
				}
				else if (Contains(styleValue, "700"))
				{
					cstyle.Bold = true;
				}
				break;
			case "line-height":
				if (styleValue == null)
				{
					break;
				}
				styleValue = styleValue.Trim().ToLower();
				if (styleValue.EndsWith("%"))
				{
					string s = styleValue.Substring(0, styleValue.Length - 1);
					int result = 0;
					if (int.TryParse(s, out result))
					{
						switch (result)
						{
						case 100:
							cstyle.LineSpacing = 0f;
							cstyle.LineSpacingStyle = LineSpacingStyle.SpaceSingle;
							break;
						case 150:
							cstyle.LineSpacingStyle = LineSpacingStyle.Space1pt5;
							break;
						case 200:
							cstyle.LineSpacingStyle = LineSpacingStyle.SpaceDouble;
							break;
						default:
							cstyle.LineSpacingStyle = LineSpacingStyle.SpaceMultiple;
							cstyle.LineSpacing = (float)result / 100f;
							break;
						}
					}
				}
				else
				{
					float num3 = ToLength(styleValue);
					if (num3 > 0f)
					{
						cstyle.LineSpacingStyle = LineSpacingStyle.SpaceSpecify;
						cstyle.LineSpacing = num3;
					}
				}
				break;
			case "text-align":
				if (Contains(styleValue, "left"))
				{
					cstyle.Align = DocumentContentAlignment.Left;
				}
				else if (Contains(styleValue, "right"))
				{
					cstyle.Align = DocumentContentAlignment.Right;
				}
				else if (Contains(styleValue, "center"))
				{
					cstyle.Align = DocumentContentAlignment.Center;
				}
				else if (Contains(styleValue, "justify"))
				{
					cstyle.Align = DocumentContentAlignment.Justify;
				}
				break;
			case "text-indent":
			{
				float length = 0f;
				if (TryParseLength(styleValue, out length))
				{
					cstyle.FirstLineIndent = length;
				}
				break;
			}
			case "margin-left":
				if (targetElement is XTextParagraphFlagElement)
				{
					float length = 0f;
					if (TryParseLength(styleValue, out length))
					{
						cstyle.LeftIndent = length;
					}
				}
				break;
			case "margin-bottom":
				if (targetElement is XTextParagraphFlagElement)
				{
					float length = 0f;
					if (TryParseLength(styleValue, out length))
					{
						cstyle.SpacingAfterParagraph = length;
					}
				}
				break;
			case "margin-top":
				if (targetElement is XTextParagraphFlagElement)
				{
					float length = 0f;
					if (TryParseLength(styleValue, out length))
					{
						cstyle.SpacingBeforeParagraph = length;
					}
				}
				break;
			case "padding":
			{
				float[] array4 = ParseLengths(styleValue);
				if (array4 != null)
				{
					if (array4.Length >= 4)
					{
						cstyle.PaddingTop = array4[0];
						cstyle.PaddingRight = array4[1];
						cstyle.PaddingBottom = array4[2];
						cstyle.PaddingLeft = array4[3];
					}
					else if (array4.Length == 1)
					{
						cstyle.PaddingLeft = array4[0];
						cstyle.PaddingTop = array4[0];
						cstyle.PaddingRight = array4[0];
						cstyle.PaddingBottom = array4[0];
					}
					else if (array4.Length == 2)
					{
						cstyle.PaddingTop = array4[0];
						cstyle.PaddingBottom = array4[0];
						cstyle.PaddingLeft = array4[1];
						cstyle.PaddingRight = array4[1];
					}
					else if (array4.Length == 3)
					{
						cstyle.PaddingTop = array4[0];
						cstyle.PaddingRight = array4[1];
						cstyle.PaddingLeft = array4[1];
						cstyle.PaddingBottom = array4[2];
					}
				}
				break;
			}
			case "padding-left":
			{
				float length = 0f;
				if (TryParseLength(styleValue, out length))
				{
					cstyle.PaddingLeft = length;
				}
				break;
			}
			case "padding-top":
			{
				float length = 0f;
				if (TryParseLength(styleValue, out length))
				{
					cstyle.PaddingTop = length;
				}
				break;
			}
			case "padding-right":
			{
				float length = 0f;
				if (TryParseLength(styleValue, out length))
				{
					cstyle.PaddingRight = length;
				}
				break;
			}
			case "padding-bottom":
			{
				float length = 0f;
				if (TryParseLength(styleValue, out length))
				{
					cstyle.PaddingBottom = length;
				}
				break;
			}
			case "vertical-align":
				if (styleValue != null)
				{
					switch (styleValue.Trim().ToLower())
					{
					case "bottom":
						cstyle.VerticalAlign = VerticalAlignStyle.Bottom;
						break;
					case "middle":
						cstyle.VerticalAlign = VerticalAlignStyle.Middle;
						break;
					case "top":
						cstyle.VerticalAlign = VerticalAlignStyle.Top;
						break;
					}
				}
				break;
			case "letter-spacing":
			{
				float length = 0f;
				if (TryParseLength(styleValue, out length))
				{
					cstyle.LetterSpacing = length;
				}
				break;
			}
			}
		}

		private string Trim(string text)
		{
			return text?.Trim();
		}

		private bool Contains(string text, string item)
		{
			if (text != null)
			{
				return text.IndexOf(item, StringComparison.CurrentCultureIgnoreCase) >= 0;
			}
			return false;
		}

		private string[] SplitItems(string text)
		{
			if (string.IsNullOrEmpty(text))
			{
				return null;
			}
			List<string> list = new List<string>();
			StringBuilder stringBuilder = new StringBuilder();
			bool flag = false;
			foreach (char c in text)
			{
				if (flag)
				{
					if (c == ')')
					{
						flag = false;
					}
					stringBuilder.Append(c);
				}
				else if (char.IsWhiteSpace(c))
				{
					if (stringBuilder.Length > 0)
					{
						list.Add(stringBuilder.ToString());
						stringBuilder = new StringBuilder();
					}
				}
				else
				{
					stringBuilder.Append(c);
					if (c == '(')
					{
						flag = true;
					}
				}
			}
			if (stringBuilder.Length > 0)
			{
				list.Add(stringBuilder.ToString());
			}
			return list.ToArray();
		}

		private string GetAttributeUrl(string text)
		{
			int num = 11;
			if (text != null)
			{
				int num2 = text.IndexOf("url(", StringComparison.CurrentCultureIgnoreCase);
				if (num2 >= 0)
				{
					text = text.Substring(4);
					num2 = text.IndexOf(")");
					if (num2 >= 0)
					{
						text = text.Substring(0, num2).Trim();
					}
					return text;
				}
			}
			return null;
		}

		private bool TryParseLength(string text, out float length)
		{
			int num = 13;
			length = 0f;
			if (string.IsNullOrEmpty(text))
			{
				return false;
			}
			text = text.Trim();
			if ("0123456789.-".IndexOf(text[0]) >= 0)
			{
				double num2 = GraphicsUnitConvert.ParseCSSLength(text, TextDocument.DocumentGraphicsUnit, double.NaN);
				if (!double.IsNaN(num2))
				{
					length = (float)num2;
					return true;
				}
			}
			return false;
		}

		private bool TryParseBorderWidth(string text, ref float width)
		{
			int num = 9;
			if (string.IsNullOrEmpty(text))
			{
				return false;
			}
			if (string.Equals(text, "1px", StringComparison.CurrentCultureIgnoreCase))
			{
				width = 1f;
				return true;
			}
			text = text.Trim().ToLower();
			if (text == "medium" || text == "thin")
			{
				width = 1f;
				return true;
			}
			if (text == "thick")
			{
				width = 2f;
				return true;
			}
			float length = 0f;
			if (TryParseLength(text, out length))
			{
				width = length;
				return true;
			}
			return false;
		}

		private bool TryParseBorderStyle(string text, out DashStyle style)
		{
			int num = 15;
			if (text == null)
			{
				style = DashStyle.Custom;
				return false;
			}
			text = text.Trim();
			if (string.Equals(text, "dashed", StringComparison.CurrentCultureIgnoreCase))
			{
				style = DashStyle.Dash;
				return true;
			}
			if (string.Equals(text, "dotted", StringComparison.CurrentCultureIgnoreCase))
			{
				style = DashStyle.Dot;
				return true;
			}
			if (string.Equals(text, "solid", StringComparison.CurrentCultureIgnoreCase))
			{
				style = DashStyle.Solid;
				return true;
			}
			if (string.Equals(text, "none", StringComparison.CurrentCultureIgnoreCase))
			{
				style = DashStyle.Custom;
				return true;
			}
			style = DashStyle.Custom;
			return false;
		}

		/// <summary>
		///       解析多个颜色值
		///       </summary>
		/// <param name="text">
		/// </param>
		/// <returns>
		/// </returns>
		private Color[] ParseMultiColors(string text)
		{
			int num = 17;
			if (string.IsNullOrEmpty(text))
			{
				return null;
			}
			text = text.Trim();
			List<Color> list = new List<Color>();
			while (text.Length > 0)
			{
				text = text.Trim();
				if (text.StartsWith("rgb(", StringComparison.CurrentCultureIgnoreCase))
				{
					int num2 = text.IndexOf(')');
					if (num2 > 0)
					{
						string text2 = text.Substring(0, num2 + 1);
						Color color = Color.Black;
						if (TryParseColor(text2, out color))
						{
							list.Add(color);
						}
						string text3 = text.Substring(num2 + 1, text.Length - num2 - 1).Trim();
						text = text3;
						continue;
					}
				}
				string text4 = "";
				while (text.Length > 0 && !char.IsWhiteSpace(text[0]))
				{
					text4 += text[0];
					text = text.Substring(1, text.Length - 1);
				}
				Color color2 = Color.Black;
				if (TryParseColor(text4, out color2))
				{
					list.Add(color2);
				}
			}
			return list.ToArray();
		}

		private bool TryParseColor(string text, out Color color)
		{
			int num = 10;
			color = Color.Empty;
			if (htmlColors == null)
			{
				htmlColors = new Dictionary<string, Color>();
				string[] names = Enum.GetNames(typeof(KnownColor));
				foreach (string text2 in names)
				{
					htmlColors[text2.ToLower()] = Color.FromKnownColor((KnownColor)Enum.Parse(typeof(KnownColor), text2));
				}
			}
			try
			{
				if (text != null)
				{
					text = text.Trim();
					if (text.StartsWith("rgb(", StringComparison.CurrentCultureIgnoreCase))
					{
						if (text.Length > 5)
						{
							text = text.Substring(4, text.Length - 5);
							string[] array = text.Split(',');
							if (array.Length >= 3)
							{
								int result = 0;
								int.TryParse(array[0].Trim(), out result);
								int result2 = 0;
								int.TryParse(array[1].Trim(), out result2);
								int result3 = 0;
								int.TryParse(array[2].Trim(), out result3);
								color = Color.FromArgb(255, result, result2, result3);
							}
						}
						return true;
					}
					if (text.StartsWith("#"))
					{
						color = ColorTranslator.FromHtml(text);
						return true;
					}
					text = text.ToLower();
					if (htmlColors.ContainsKey(text))
					{
						color = htmlColors[text];
						return true;
					}
				}
			}
			catch
			{
			}
			return false;
		}

		public object ToEnumValue(string string_0, object defaultValue)
		{
			if (string.IsNullOrEmpty(string_0))
			{
				return defaultValue;
			}
			try
			{
				return Enum.Parse(defaultValue.GetType(), string_0);
			}
			catch (Exception)
			{
				return defaultValue;
			}
		}

		public bool ToBoolean(string string_0, bool defaultValue)
		{
			int num = 0;
			if (string.IsNullOrEmpty(string_0))
			{
				return defaultValue;
			}
			if (string.Compare(string_0, "true", ignoreCase: true) == 0 || string.Compare(string_0, "on", ignoreCase: true) == 0 || string.Compare(string_0, "yes", ignoreCase: true) == 0)
			{
				return true;
			}
			if (string.Compare(string_0, "false", ignoreCase: true) == 0 || string.Compare(string_0, "off", ignoreCase: true) == 0 || string.Compare(string_0, "no", ignoreCase: true) == 0)
			{
				return false;
			}
			return defaultValue;
		}

		public Color ToColor(string text, Color defaultValue)
		{
			if (string.IsNullOrEmpty(text))
			{
				return defaultValue;
			}
			Color color = defaultValue;
			if (TryParseColor(text, out color))
			{
				return color;
			}
			return defaultValue;
		}

		public int ToInt32(string text)
		{
			int result = 0;
			if (int.TryParse(text, out result))
			{
				return result;
			}
			return 0;
		}

		public float ToSingle(string text)
		{
			float result = 0f;
			if (float.TryParse(text, out result))
			{
				return result;
			}
			return 0f;
		}

		private float[] ParseLengths(string text)
		{
			List<float> list = new List<float>();
			string[] array = SplitItems(text);
			if (array != null)
			{
				string[] array2 = array;
				foreach (string cSSLength in array2)
				{
					double num = GraphicsUnitConvert.ParseCSSLength(cSSLength, TextDocument.DocumentGraphicsUnit, double.NaN);
					if (!double.IsNaN(num))
					{
						list.Add((float)num);
					}
				}
			}
			return list.ToArray();
		}

		public float ToLength(string text)
		{
			return (float)GraphicsUnitConvert.ParseCSSLength(text, TextDocument.DocumentGraphicsUnit, 0.0);
		}

		/// <summary>
		///       解析出字体名称
		///       </summary>
		/// <param name="text">
		/// </param>
		/// <returns>
		/// </returns>
		private string GetFontName(string text)
		{
			if (_fontNames == null)
			{
				FontFamily[] families = FontFamily.Families;
				_fontNames = new string[families.Length];
				for (int i = 0; i < families.Length; i++)
				{
					_fontNames[i] = families[i].Name;
				}
			}
			if (text != null)
			{
				text = text.Trim();
				string[] fontNames = _fontNames;
				foreach (string text2 in fontNames)
				{
					if (string.Equals(text2, text, StringComparison.CurrentCultureIgnoreCase))
					{
						return text2;
					}
				}
			}
			return null;
		}
	}
}
