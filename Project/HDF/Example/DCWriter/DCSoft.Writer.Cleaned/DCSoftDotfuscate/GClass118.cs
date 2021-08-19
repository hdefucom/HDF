using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.Writer.Dom;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Web;
using System.Windows.Forms;
using System.Xml;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass118
	{
		private XTextDocument xtextDocument_0 = null;

		private XTextDocumentList xtextDocumentList_0 = new XTextDocumentList();

		protected Font font_0 = Control.DefaultFont;

		private GClass119 gclass119_0 = new GClass119();

		protected Encoding encoding_0 = Encoding.GetEncoding(936);

		private string string_0 = "";

		protected bool bool_0 = false;

		private Rectangle rectangle_0 = Rectangle.Empty;

		private Dictionary<DocumentContentStyle, string> dictionary_0 = new Dictionary<DocumentContentStyle, string>();

		protected StringWriter stringWriter_0 = new StringWriter();

		protected XmlTextWriter xmlTextWriter_0 = null;

		private Hashtable hashtable_0 = new Hashtable();

		protected StringDictionary stringDictionary_0 = new StringDictionary();

		private StringBuilder stringBuilder_0 = null;

		private static XmlDocument xmlDocument_0 = null;

		public GClass118()
		{
			method_16();
		}

		public GClass118(bool bool_1)
		{
			method_6().method_3(bool_1);
			method_16();
		}

		public XTextDocument method_0()
		{
			if (xtextDocument_0 == null && xtextDocumentList_0 != null)
			{
				return xtextDocumentList_0.FirstDocument;
			}
			return xtextDocument_0;
		}

		public void method_1(XTextDocument xtextDocument_1)
		{
			xtextDocument_0 = xtextDocument_1;
		}

		public XTextDocumentList method_2()
		{
			return xtextDocumentList_0;
		}

		public void method_3(XTextDocumentList xtextDocumentList_1)
		{
			xtextDocumentList_0 = xtextDocumentList_1;
		}

		public Font method_4()
		{
			return font_0;
		}

		public void method_5(Font font_1)
		{
			font_0 = font_1;
		}

		public GClass119 method_6()
		{
			if (gclass119_0 == null)
			{
				gclass119_0 = new GClass119();
			}
			return gclass119_0;
		}

		public void method_7(GClass119 gclass119_1)
		{
			gclass119_0 = gclass119_1;
		}

		public Encoding method_8()
		{
			return encoding_0;
		}

		public void method_9(Encoding encoding_1)
		{
			encoding_0 = encoding_1;
		}

		public string method_10()
		{
			return string_0;
		}

		public void method_11(string string_1)
		{
			string_0 = string_1;
		}

		public bool method_12()
		{
			return bool_0;
		}

		public void method_13(bool bool_1)
		{
			bool_0 = bool_1;
		}

		public Rectangle method_14()
		{
			return rectangle_0;
		}

		public void method_15(Rectangle rectangle_1)
		{
			rectangle_0 = rectangle_1;
		}

		public void method_16()
		{
			stringWriter_0 = new StringWriter();
			xmlTextWriter_0 = new XmlTextWriter(stringWriter_0);
			if (method_6().method_2())
			{
				xmlTextWriter_0.Formatting = Formatting.Indented;
				xmlTextWriter_0.Indentation = 3;
				xmlTextWriter_0.IndentChar = ' ';
			}
			else
			{
				xmlTextWriter_0.Formatting = Formatting.None;
			}
		}

		public void method_17(string string_1)
		{
			xmlTextWriter_0.WriteStartElement(string_1);
		}

		public void method_18()
		{
			xmlTextWriter_0.WriteEndElement();
		}

		public void method_19(string string_1)
		{
			xmlTextWriter_0.WriteString(string_1);
		}

		public void method_20(bool bool_1)
		{
			int num = 3;
			if (!bool_1)
			{
				xmlTextWriter_0.WriteAttributeString("disabled", "true");
			}
		}

		public void method_21(string string_1, string string_2)
		{
			xmlTextWriter_0.WriteAttributeString(string_1, string_2);
		}

		public void method_22(string string_1, string string_2)
		{
			xmlTextWriter_0.WriteElementString(string_1, string_2);
		}

		protected virtual void vmethod_0(int int_0)
		{
			int num = 13;
			if (int_0 > 0)
			{
				if (method_6().method_2())
				{
					xmlTextWriter_0.WriteStartElement("span");
				}
				for (int i = 0; i < int_0; i++)
				{
					xmlTextWriter_0.WriteRaw("&nbsp;");
				}
				if (method_6().method_2())
				{
					xmlTextWriter_0.WriteEndElement();
				}
			}
		}

		public void method_23(string string_1, Font font_1, Color color_0)
		{
			int num = 9;
			if (font_1 == null)
			{
				return;
			}
			xmlTextWriter_0.WriteStartElement("font");
			if (color_0.ToArgb() != Color.Black.ToArgb())
			{
				xmlTextWriter_0.WriteAttributeString("color", method_59(color_0));
			}
			if (font_1 != null)
			{
				if (font_0 == null || font_0.Name != font_1.Name)
				{
					xmlTextWriter_0.WriteAttributeString("face", font_1.Name);
				}
				if (font_0 == null || font_0.Size != font_1.Size)
				{
					xmlTextWriter_0.WriteAttributeString("style", "font-size:" + font_1.Size + "pt");
				}
				if (font_1.Bold)
				{
					xmlTextWriter_0.WriteStartElement("b");
				}
				if (font_1.Italic)
				{
					xmlTextWriter_0.WriteStartElement("i");
				}
			}
			method_24(string_1);
			if (font_1 != null)
			{
				if (font_1.Italic)
				{
					xmlTextWriter_0.WriteEndElement();
				}
				if (font_1.Bold)
				{
					xmlTextWriter_0.WriteEndElement();
				}
			}
			xmlTextWriter_0.WriteEndElement();
		}

		public void method_24(string string_1)
		{
			int num = 12;
			if (string_1 != null)
			{
				string_1 = HttpUtility.HtmlEncode(string_1);
				string_1 = string_1.Replace("\t", "&nbsp;&nbsp;&nbsp;&nbsp;");
				string_1 = string_1.Replace(" ", "&nbsp;");
				string_1 = string_1.Replace("\r\n", "<br />");
				if (string_1.Length == 0)
				{
					xmlTextWriter_0.WriteString(" ");
				}
				else if (method_6().method_6())
				{
					xmlTextWriter_0.WriteString(string_1);
				}
				else
				{
					xmlTextWriter_0.WriteRaw(string_1);
				}
			}
			else
			{
				xmlTextWriter_0.WriteString(" ");
			}
		}

		public string method_25(byte[] byte_0, ImageFormat imageFormat_0)
		{
			int num = 11;
			if (byte_0 == null || byte_0.Length == 0)
			{
				return null;
			}
			foreach (string key in hashtable_0.Keys)
			{
				if (hashtable_0[key] == byte_0)
				{
					return key;
				}
			}
			if (imageFormat_0 == null)
			{
				if (GClass339.smethod_14(byte_0))
				{
					imageFormat_0 = ImageFormat.Bmp;
				}
				else if (GClass339.smethod_13(byte_0))
				{
					imageFormat_0 = ImageFormat.Gif;
				}
				else if (GClass339.smethod_15(byte_0))
				{
					imageFormat_0 = ImageFormat.Jpeg;
				}
				else if (GClass339.smethod_12(byte_0))
				{
					imageFormat_0 = ImageFormat.Png;
				}
			}
			string text2 = GClass343.smethod_2(imageFormat_0);
			if (text2 == null)
			{
				text2 = ".bmp";
			}
			string text3 = hashtable_0.Count + text2;
			hashtable_0[text3] = byte_0;
			return text3;
		}

		public string method_26(Image image_0, ImageFormat imageFormat_0)
		{
			if (image_0 == null)
			{
				return null;
			}
			byte[] value = null;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				if (imageFormat_0 == null)
				{
					imageFormat_0 = image_0.RawFormat;
					if (imageFormat_0 == null)
					{
						imageFormat_0 = ImageFormat.Jpeg;
					}
				}
				image_0.Save(memoryStream, imageFormat_0);
				memoryStream.Close();
				value = memoryStream.ToArray();
			}
			string arg = GClass343.smethod_2(imageFormat_0);
			string text = hashtable_0.Count + arg;
			hashtable_0[text] = value;
			return text;
		}

		public void method_27(string string_1)
		{
			foreach (string key in hashtable_0.Keys)
			{
				string path = Path.Combine(string_1, key);
				byte[] array = (byte[])hashtable_0[key];
				using (FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write))
				{
					fileStream.Write(array, 0, array.Length);
					fileStream.Close();
				}
			}
		}

		public string method_28(DocumentContentStyle documentContentStyle_0)
		{
			int num = 12;
			if (documentContentStyle_0 == null)
			{
				throw new ArgumentNullException("style");
			}
			GraphicsUnit unit = GraphicsUnit.Document;
			if (method_0() != null)
			{
				unit = method_0().DocumentGraphicsUnit;
			}
			StringBuilder stringBuilder = new StringBuilder();
			string str = "solid";
			switch (documentContentStyle_0.BorderStyle)
			{
			case DashStyle.Solid:
				str = "solid";
				break;
			case DashStyle.Dash:
				str = "dashed";
				break;
			case DashStyle.Dot:
				str = "dotted";
				break;
			case DashStyle.DashDot:
				str = "dotted";
				break;
			case DashStyle.DashDotDot:
				str = "dotted";
				break;
			}
			str = "1" + str + " " + method_59(documentContentStyle_0.BorderColor);
			if (documentContentStyle_0.BorderLeft && documentContentStyle_0.BorderTop && documentContentStyle_0.BorderRight && documentContentStyle_0.BorderBottom && documentContentStyle_0.BorderWidth > 0f)
			{
				stringBuilder.Append("border:" + str);
				str = null;
			}
			string[] array = XDependencyObject.smethod_10(documentContentStyle_0);
			string[] array2 = array;
			foreach (string text in array2)
			{
				string text2 = null;
				switch (text)
				{
				case "BorderLeft":
					if (documentContentStyle_0.BorderLeft && str != null && documentContentStyle_0.BorderWidth > 0f)
					{
						text2 = "border-left:" + str;
					}
					break;
				case "BorderTop":
					if (documentContentStyle_0.BorderTop && str != null && documentContentStyle_0.BorderWidth > 0f)
					{
						text2 = "border-top:" + str;
					}
					break;
				case "BorderRight":
					if (documentContentStyle_0.BorderRight && str != null && documentContentStyle_0.BorderWidth > 0f)
					{
						text2 = "border-right:" + str;
					}
					break;
				case "BorderBottom":
					if (documentContentStyle_0.BorderBottom && str != null && documentContentStyle_0.BorderWidth > 0f)
					{
						text2 = "border-bottom:" + str;
					}
					break;
				case "Align":
					switch (documentContentStyle_0.Align)
					{
					default:
						text2 = "text-align:left";
						break;
					case DocumentContentAlignment.Left:
						text2 = "text-align:left";
						break;
					case DocumentContentAlignment.Center:
						text2 = "text-align:center";
						break;
					case DocumentContentAlignment.Right:
						text2 = "text-align:right";
						break;
					case DocumentContentAlignment.Justify:
						text2 = "text-align:justify";
						break;
					}
					break;
				case "BackgroundColor":
					text2 = method_59(documentContentStyle_0.BackgroundColor);
					break;
				case "BackgroundImage":
				{
					XImageValue backgroundImage = documentContentStyle_0.BackgroundImage;
					if (backgroundImage != null && backgroundImage.HasContent)
					{
						string str2 = method_26(backgroundImage.Value, null);
						text2 = "background-image:url(" + str2 + ")";
					}
					break;
				}
				case "BackgroundPosition":
					switch (documentContentStyle_0.BackgroundPosition)
					{
					case ContentAlignment.MiddleCenter:
						text2 = "center center";
						break;
					case ContentAlignment.MiddleLeft:
						text2 = "center left";
						break;
					case ContentAlignment.TopLeft:
						text2 = "top left";
						break;
					case ContentAlignment.TopCenter:
						text2 = "top center";
						break;
					case ContentAlignment.TopRight:
						text2 = "top right";
						break;
					case ContentAlignment.BottomLeft:
						text2 = "bottom left";
						break;
					case ContentAlignment.MiddleRight:
						text2 = "center right";
						break;
					case ContentAlignment.BottomRight:
						text2 = "bottom right";
						break;
					case ContentAlignment.BottomCenter:
						text2 = "bottom center";
						break;
					}
					text2 = "background-position:" + text2;
					break;
				case "BackgroundPositionX":
					text2 = "background-position-x:" + GraphicsUnitConvert.ToCSSLength(documentContentStyle_0.BackgroundPositionX, unit, GEnum87.const_5);
					break;
				case "BackgroundPositionY":
					text2 = "background-position-y:" + GraphicsUnitConvert.ToCSSLength(documentContentStyle_0.BackgroundPositionY, unit, GEnum87.const_5);
					break;
				case "BackgroundRepeat":
					text2 = ((!documentContentStyle_0.BackgroundRepeat) ? "background-repeat:no-repeat" : "background-repeat:repeat");
					break;
				case "Bold":
					if (documentContentStyle_0.Bold)
					{
						text2 = "font-weight:bold";
					}
					break;
				case "Color":
					if (documentContentStyle_0.Color.A != 0)
					{
						text2 = "color:" + method_59(documentContentStyle_0.Color);
					}
					break;
				case "FirstLineIndent":
					if ((double)Math.Abs(documentContentStyle_0.FirstLineIndent) > 0.05)
					{
						text2 = "text-indent:" + GraphicsUnitConvert.ToCSSLength(documentContentStyle_0.FirstLineIndent, unit, GEnum87.const_5);
					}
					break;
				case "FontName":
					text2 = "font-family:" + documentContentStyle_0.FontName;
					break;
				case "FontSize":
					text2 = "font-size:" + documentContentStyle_0.FontSize + "pt";
					break;
				case "Italic":
					if (documentContentStyle_0.Italic)
					{
						text2 = "font-style:italic";
					}
					break;
				case "MarginBottom":
					if ((double)Math.Abs(documentContentStyle_0.MarginBottom) > 0.05)
					{
						text2 = "margin-bottom:" + GraphicsUnitConvert.ToCSSLength(documentContentStyle_0.MarginBottom, unit, GEnum87.const_5);
					}
					break;
				case "MarginTop":
					if ((double)Math.Abs(documentContentStyle_0.MarginTop) > 0.05)
					{
						text2 = "margin-top:" + GraphicsUnitConvert.ToCSSLength(documentContentStyle_0.MarginTop, unit, GEnum87.const_5);
					}
					break;
				case "MarginLeft":
					if ((double)Math.Abs(documentContentStyle_0.MarginLeft) > 0.05)
					{
						text2 = "margin-left:" + GraphicsUnitConvert.ToCSSLength(documentContentStyle_0.MarginLeft, unit, GEnum87.const_5);
					}
					break;
				case "MarginRight":
					if ((double)Math.Abs(documentContentStyle_0.MarginRight) > 0.05)
					{
						text2 = "margin-right:" + GraphicsUnitConvert.ToCSSLength(documentContentStyle_0.MarginRight, unit, GEnum87.const_5);
					}
					break;
				case "PaddingBottom":
					if ((double)Math.Abs(documentContentStyle_0.PaddingBottom) > 0.05)
					{
						text2 = "padding-bottom:" + GraphicsUnitConvert.ToCSSLength(documentContentStyle_0.PaddingBottom, unit, GEnum87.const_5);
					}
					break;
				case "PaddingTop":
					if ((double)Math.Abs(documentContentStyle_0.PaddingTop) > 0.05)
					{
						text2 = "padding-top:" + GraphicsUnitConvert.ToCSSLength(documentContentStyle_0.PaddingTop, unit, GEnum87.const_5);
					}
					break;
				case "PaddingRight":
					if ((double)Math.Abs(documentContentStyle_0.PaddingRight) > 0.05)
					{
						text2 = "padding-right:" + GraphicsUnitConvert.ToCSSLength(documentContentStyle_0.PaddingRight, unit, GEnum87.const_5);
					}
					break;
				case "PaddingLeft":
					if ((double)Math.Abs(documentContentStyle_0.PaddingLeft) > 0.05)
					{
						text2 = "padding-left:" + GraphicsUnitConvert.ToCSSLength(documentContentStyle_0.PaddingLeft, unit, GEnum87.const_5);
					}
					break;
				case "PageBreakAfter":
					if (documentContentStyle_0.PageBreakAfter)
					{
						text2 = "page-break-after:always";
					}
					break;
				case "PageBreakBefore":
					if (documentContentStyle_0.PageBreakBefore)
					{
						text2 = "page-break-before:always";
					}
					break;
				case "RightToLeft":
					if (documentContentStyle_0.RightToLeft)
					{
						text2 = "direction:rtl";
					}
					break;
				case "Spacing":
					if ((double)Math.Abs(documentContentStyle_0.Spacing) > 0.05)
					{
						text2 = "letter-spacing:" + GraphicsUnitConvert.ToCSSLength(documentContentStyle_0.Spacing, unit, GEnum87.const_5);
					}
					break;
				case "Strikeout":
					if (documentContentStyle_0.Strikeout)
					{
						text2 = "text-decoration:line-through";
					}
					break;
				case "Underline":
					if (documentContentStyle_0.Underline)
					{
						text2 = "text-decoration:underline";
					}
					break;
				case "VertialText":
					if (!documentContentStyle_0.VertialText)
					{
					}
					break;
				case "VerticalAlign":
					switch (documentContentStyle_0.VerticalAlign)
					{
					case VerticalAlignStyle.Top:
						text2 = "vertical:top";
						break;
					case VerticalAlignStyle.Middle:
						text2 = "vertical:middle";
						break;
					case VerticalAlignStyle.Bottom:
						text2 = "vertical:bottom";
						break;
					}
					break;
				case "Visible":
					if (!documentContentStyle_0.Visible)
					{
						text2 = "visibility:hidden";
					}
					break;
				case "Zoom":
					text2 = "zoom:" + documentContentStyle_0.Zoom;
					break;
				}
				if (text2 != null)
				{
					if (stringBuilder.Length > 0)
					{
						stringBuilder.Append(";");
					}
					stringBuilder.Append(text2);
				}
			}
			return stringBuilder.ToString();
		}

		private string method_29(string string_1)
		{
			int num = 18;
			foreach (string key in stringDictionary_0.Keys)
			{
				if (string.Compare(string_1, stringDictionary_0[key], ignoreCase: false) == 0)
				{
					return key;
				}
			}
			string text2 = "x_" + stringDictionary_0.Count;
			stringDictionary_0[text2] = string_1;
			return text2;
		}

		public void method_30()
		{
			stringBuilder_0 = new StringBuilder();
		}

		public void method_31()
		{
			int num = 6;
			if (stringBuilder_0 != null)
			{
				xmlTextWriter_0.WriteAttributeString("style", stringBuilder_0.ToString());
			}
			stringBuilder_0 = null;
		}

		public void method_32()
		{
			int num = 9;
			if (stringBuilder_0 != null && stringBuilder_0.Length > 0)
			{
				string string_ = stringBuilder_0.ToString();
				string value = method_29(string_);
				xmlTextWriter_0.WriteAttributeString("class", value);
			}
			stringBuilder_0 = null;
		}

		public void method_33(string string_1)
		{
			int num = 7;
			string text = method_29(string_1);
			if (text != null)
			{
				xmlTextWriter_0.WriteAttributeString("class", text);
			}
		}

		public string method_34()
		{
			int num = 4;
			if (stringDictionary_0.Count == 0)
			{
				return "";
			}
			StringBuilder stringBuilder = new StringBuilder();
			foreach (string key in stringDictionary_0.Keys)
			{
				stringBuilder.Append(Environment.NewLine);
				stringBuilder.Append("   ." + key + "{" + stringDictionary_0[key] + "}");
			}
			stringBuilder.Append(Environment.NewLine);
			return stringBuilder.ToString();
		}

		public void method_35(BorderStyle borderStyle_0, bool bool_1)
		{
			int num = 18;
			switch (borderStyle_0)
			{
			case BorderStyle.None:
				return;
			case BorderStyle.FixedSingle:
				method_42("border", "1 solid black");
				break;
			}
			if (borderStyle_0 == BorderStyle.Fixed3D)
			{
				if (bool_1)
				{
					method_42("border", "2 outset control");
				}
				else
				{
					method_42("border", "2 inset control");
				}
			}
		}

		public void method_36(string string_1, string string_2)
		{
			int num = 9;
			if (stringBuilder_0 != null)
			{
				if (stringBuilder_0.Length > 0)
				{
					stringBuilder_0.Append(";");
				}
				stringBuilder_0.Append(string_1);
				stringBuilder_0.Append(":");
				stringBuilder_0.Append(HttpUtility.HtmlEncode(string_2));
			}
		}

		public void method_37(string string_1)
		{
			if (stringBuilder_0 != null)
			{
				if (stringBuilder_0.Length > 0)
				{
					stringBuilder_0.Append(';');
				}
				stringBuilder_0.Append(string_1);
			}
		}

		public void method_38(Cursor cursor_0)
		{
			method_42("cursor", method_58(cursor_0));
		}

		public void method_39(Color color_0)
		{
			int num = 2;
			if (color_0.A != 0)
			{
				method_42("background", method_59(color_0));
			}
		}

		public void method_40(int int_0, int int_1)
		{
			int num = 17;
			if (int_0 > 0)
			{
				method_42("width", int_0 + " px");
			}
			if (int_1 > 0)
			{
				method_42("height", int_1 + " px");
			}
		}

		public void method_41(Font font_1, Color color_0)
		{
			int num = 10;
			Font defaultFont = font_0;
			if (defaultFont == null)
			{
				defaultFont = Control.DefaultFont;
			}
			if (color_0.A != 0 && color_0.ToArgb() != Color.Black.ToArgb())
			{
				method_42("color", method_59(color_0));
			}
			if (font_1 != null)
			{
				if (font_1.Name != defaultFont.Name)
				{
					method_42("font-family", font_1.Name);
				}
				if (font_1.Size != defaultFont.Size)
				{
					method_42("font-size", font_1.Size + "pt");
				}
				if (font_1.Italic)
				{
					method_42("font-style", "italic");
				}
				if (font_1.Bold)
				{
					method_42("font-weight", "bold");
				}
				if (font_1.Underline)
				{
					method_42("text-decoration", "underline");
				}
				else if (font_1.Strikeout)
				{
					method_42("text-decoration", "line-through");
				}
			}
		}

		public void method_42(string string_1, string string_2)
		{
			int num = 17;
			if (stringBuilder_0.Length > 0)
			{
				stringBuilder_0.Append(";");
			}
			stringBuilder_0.Append(string_1);
			stringBuilder_0.Append(":");
			stringBuilder_0.Append(HttpUtility.HtmlEncode(string_2));
		}

		public void method_43(int int_0, int int_1, int int_2, int int_3)
		{
			int num = 11;
			if (int_0 != 0)
			{
				method_42("padding-left", int_0.ToString());
			}
			if (int_1 != 0)
			{
				method_42("padding-top", int_1.ToString());
			}
			if (int_2 != 0)
			{
				method_42("padding-right", int_2.ToString());
			}
			if (int_3 != 0)
			{
				method_42("padding-bottom", int_3.ToString());
			}
		}

		public void method_44(int int_0, int int_1)
		{
			method_42("position", "absolute");
			method_42("left", int_0.ToString());
			method_42("top", int_1.ToString());
		}

		public void method_45(StringAlignment stringAlignment_0)
		{
			int num = 14;
			if (stringBuilder_0.Length > 0)
			{
				stringBuilder_0.Append(';');
			}
			stringBuilder_0.Append("text-align:");
			switch (stringAlignment_0)
			{
			case StringAlignment.Far:
				stringBuilder_0.Append("right");
				break;
			case StringAlignment.Center:
				stringBuilder_0.Append("center");
				break;
			default:
				stringBuilder_0.Append("left");
				break;
			}
		}

		public void method_46(DocumentContentAlignment documentContentAlignment_0)
		{
			int num = 4;
			if (stringBuilder_0.Length > 0)
			{
				stringBuilder_0.Append(';');
			}
			stringBuilder_0.Append("text-align:");
			switch (documentContentAlignment_0)
			{
			case DocumentContentAlignment.Left:
				stringBuilder_0.Append("left");
				break;
			case DocumentContentAlignment.Center:
				stringBuilder_0.Append("center");
				break;
			case DocumentContentAlignment.Right:
				stringBuilder_0.Append("right");
				break;
			case DocumentContentAlignment.Justify:
				stringBuilder_0.Append("justify");
				break;
			default:
				stringBuilder_0.Append("left");
				break;
			}
		}

		public void method_47(StringAlignment stringAlignment_0)
		{
			int num = 1;
			if (stringBuilder_0.Length > 0)
			{
				stringBuilder_0.Append(';');
			}
			stringBuilder_0.Append("vertical-align:");
			switch (stringAlignment_0)
			{
			case StringAlignment.Near:
				stringBuilder_0.Append("top");
				break;
			case StringAlignment.Center:
				stringBuilder_0.Append("middle");
				break;
			case StringAlignment.Far:
				stringBuilder_0.Append("bottom");
				break;
			default:
				stringBuilder_0.Append("top");
				break;
			}
		}

		public void method_48(DocumentContentAlignment documentContentAlignment_0)
		{
			int num = 5;
			if (stringBuilder_0.Length > 0)
			{
				stringBuilder_0.Append(';');
			}
			stringBuilder_0.Append("vertical-align:");
			switch (documentContentAlignment_0)
			{
			case DocumentContentAlignment.Left:
				stringBuilder_0.Append("top");
				break;
			case DocumentContentAlignment.Center:
				stringBuilder_0.Append("middle");
				break;
			case DocumentContentAlignment.Right:
				stringBuilder_0.Append("bottom");
				break;
			default:
				stringBuilder_0.Append("top");
				break;
			}
		}

		public override string ToString()
		{
			xmlTextWriter_0.Flush();
			string string_ = stringWriter_0.ToString();
			string_ = method_57(string_);
			string_ = "<style>" + method_34() + "</style>" + Environment.NewLine + string_;
			return method_57(string_);
		}

		public string method_49()
		{
			return method_60(bool_1: false);
		}

		public void method_50(Stream stream_0)
		{
			byte[] bytes = encoding_0.GetBytes(method_60(bool_1: true));
			stream_0.Write(bytes, 0, bytes.Length);
		}

		public void method_51(string string_1)
		{
			byte[] bytes = encoding_0.GetBytes(method_60(bool_1: true));
			using (FileStream fileStream = new FileStream(string_1, FileMode.Create, FileAccess.Write))
			{
				fileStream.Write(bytes, 0, bytes.Length);
			}
		}

		public void method_52(Stream stream_0)
		{
			byte[] bytes = encoding_0.GetBytes(method_60(bool_1: true));
			stream_0.Write(bytes, 0, bytes.Length);
		}

		public void method_53(string string_1)
		{
			byte[] bytes = encoding_0.GetBytes(method_60(bool_1: true));
			using (FileStream fileStream = new FileStream(string_1, FileMode.Create, FileAccess.Write))
			{
				fileStream.Write(bytes, 0, bytes.Length);
			}
		}

		public void method_54(Stream stream_0)
		{
			byte[] bytes = encoding_0.GetBytes(method_60(bool_1: false));
			stream_0.Write(bytes, 0, bytes.Length);
		}

		public void method_55(TextWriter textWriter_0)
		{
			textWriter_0.Write(method_60(bool_1: false));
		}

		public void method_56(string string_1)
		{
			using (FileStream stream_ = new FileStream(string_1, FileMode.Create))
			{
				method_54(stream_);
			}
		}

		private string method_57(string string_1)
		{
			int num = 17;
			if (string_1 != null)
			{
				int num2 = string_1.IndexOf("?>");
				num2 = ((num2 > 0) ? (num2 + 2) : 0);
				int num3 = num2;
				while (true)
				{
					if (num3 < string_1.Length)
					{
						if (!char.IsWhiteSpace(string_1, num3))
						{
							break;
						}
						num3++;
						continue;
					}
					return string_1;
				}
				return string_1.Substring(num3);
			}
			return null;
		}

		private string method_58(Cursor cursor_0)
		{
			int num = 14;
			if (cursor_0.Equals(Cursors.Default))
			{
				return "default";
			}
			if (cursor_0.Equals(Cursors.Cross))
			{
				return "crosshair";
			}
			if (cursor_0.Equals(Cursors.IBeam))
			{
				return "text";
			}
			if (cursor_0.Equals(Cursors.Arrow))
			{
				return "point";
			}
			if (cursor_0.Equals(Cursors.WaitCursor))
			{
				return "wait";
			}
			if (cursor_0.Equals(Cursors.AppStarting))
			{
				return "progress";
			}
			if (cursor_0.Equals(Cursors.Hand))
			{
				return "hand";
			}
			if (cursor_0.Equals(Cursors.Help))
			{
				return "help";
			}
			if (cursor_0.Equals(Cursors.SizeAll))
			{
				return "move";
			}
			if (cursor_0.Equals(Cursors.SizeNS))
			{
				return "n-resize";
			}
			if (cursor_0.Equals(Cursors.SizeWE))
			{
				return "e-resize";
			}
			if (cursor_0.Equals(Cursors.SizeNESW))
			{
				return "ne-resize";
			}
			if (cursor_0.Equals(Cursors.SizeNWSE))
			{
				return "se-resize";
			}
			return "default";
		}

		private string method_59(Color color_0)
		{
			int num = 1;
			if (color_0.A != byte.MaxValue)
			{
				return "#" + color_0.A.ToString("X2") + Convert.ToInt32(color_0.ToArgb() & 0xFFFFFF).ToString("X6");
			}
			return "#" + Convert.ToInt32(color_0.ToArgb() & 0xFFFFFF).ToString("X6");
		}

		private string method_60(bool bool_1)
		{
			int num = 8;
			StringWriter stringWriter = new StringWriter();
			XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);
			if (method_6().method_2())
			{
				xmlTextWriter.Formatting = Formatting.Indented;
				xmlTextWriter.IndentChar = ' ';
				xmlTextWriter.Indentation = 3;
			}
			else
			{
				xmlTextWriter.Formatting = Formatting.None;
			}
			xmlTextWriter.WriteStartDocument();
			xmlTextWriter.WriteStartElement("html");
			if (bool_1)
			{
				xmlTextWriter.WriteAttributeString("xmlns:o", "urn:schemas-microsoft-com:office:office");
				xmlTextWriter.WriteAttributeString("xmlns:x", "urn:schemas-microsoft-com:office:excel");
				xmlTextWriter.WriteAttributeString("xmlns:v", "urn:schemas-microsoft-com:vml");
			}
			xmlTextWriter.WriteStartElement("head");
			string text = method_10();
			if (text != null && text.Length > 0)
			{
				xmlTextWriter.WriteElementString("title", text);
			}
			xmlTextWriter.WriteStartElement("meta");
			xmlTextWriter.WriteAttributeString("http-equiv", "Content-Type");
			xmlTextWriter.WriteAttributeString("content", "text/html;charset=" + encoding_0.BodyName);
			xmlTextWriter.WriteEndElement();
			if (bool_1)
			{
				smethod_0(text).WriteContentTo(xmlTextWriter);
			}
			xmlTextWriter.WriteEndElement();
			xmlTextWriter.WriteStartElement("body");
			xmlTextWriter.WriteAttributeString("style", "font-size:" + font_0.Size + "pt");
			xmlTextWriter.WriteRaw(Environment.NewLine);
			xmlTextWriter.WriteRaw(ToString());
			xmlTextWriter.WriteEndElement();
			xmlTextWriter.WriteEndElement();
			xmlTextWriter.WriteEndDocument();
			xmlTextWriter.Close();
			return method_57(stringWriter.ToString());
		}

		private static XmlDocument smethod_0(string string_1)
		{
			int num = 9;
			if (xmlDocument_0 == null)
			{
				xmlDocument_0 = new XmlDocument();
				xmlDocument_0.LoadXml("<xml xmlns:o='urn:schemas-microsoft-com:office:office'\r\nxmlns:x='urn:schemas-microsoft-com:office:excel'>\r\n\t\t\t\t\t\t<o:DocumentProperties>\r\n\t\t\t\t\t\t\t<o:Author>XReport</o:Author>\r\n\t\t\t\t\t\t\t<o:LastAuthor>ys2006</o:LastAuthor>\r\n\t\t\t\t\t\t\t<o:Created></o:Created>\r\n\t\t\t\t\t\t\t<o:LastSaved></o:LastSaved>\r\n\t\t\t\t\t\t\t<o:Company>DCSoft</o:Company>\r\n\t\t\t\t\t\t\t<o:Version>9.2812</o:Version>\r\n\t\t\t\t\t\t</o:DocumentProperties>\r\n\t\t\t\t\t\t<x:ExcelWorkbook>\r\n\t\t\t\t\t\t\t<x:ExcelWorksheets>\r\n\t\t\t\t\t\t\t\t<x:ExcelWorksheet>\r\n\t\t\t\t\t\t\t\t\t<x:Name id='nameelement' ></x:Name>\r\n\t\t\t\t\t\t\t\t\t<x:WorksheetOptions>\r\n\t\t\t\t\t\t\t\t\t\t<x:DefaultRowHeight>285</x:DefaultRowHeight>\r\n\t\t\t\t\t\t\t\t\t\t<x:Print>\r\n\t\t\t\t\t\t\t\t\t\t\t<x:ValidPrinterInfo />\r\n\t\t\t\t\t\t\t\t\t\t\t<x:PaperSizeIndex>9</x:PaperSizeIndex>\r\n\t\t\t\t\t\t\t\t\t\t\t<x:HorizontalResolution>100</x:HorizontalResolution>\r\n\t\t\t\t\t\t\t\t\t\t\t<x:VerticalResolution>100</x:VerticalResolution>\r\n\t\t\t\t\t\t\t\t\t\t</x:Print>\r\n\t\t\t\t\t\t\t\t\t\t<x:Selected />\r\n\t\t\t\t\t\t\t\t\t\t<x:ProtectContents>False</x:ProtectContents>\r\n\t\t\t\t\t\t\t\t\t\t<x:ProtectObjects>False</x:ProtectObjects>\r\n\t\t\t\t\t\t\t\t\t\t<x:ProtectScenarios>False</x:ProtectScenarios>\r\n\t\t\t\t\t\t\t\t\t</x:WorksheetOptions>\r\n\t\t\t\t\t\t\t\t</x:ExcelWorksheet>\r\n\t\t\t\t\t\t\t</x:ExcelWorksheets>\r\n\t\t\t\t\t\t\t<x:WindowHeight>13275</x:WindowHeight>\r\n\t\t\t\t\t\t\t<x:WindowWidth>18180</x:WindowWidth>\r\n\t\t\t\t\t\t\t<x:WindowTopX>480</x:WindowTopX>\r\n\t\t\t\t\t\t\t<x:WindowTopY>15</x:WindowTopY>\r\n\t\t\t\t\t\t\t<x:ProtectStructure>False</x:ProtectStructure>\r\n\t\t\t\t\t\t\t<x:ProtectWindows>False</x:ProtectWindows>\r\n\t\t\t\t\t\t</x:ExcelWorkbook>\r\n\t\t\t\t\t</xml>");
			}
			xmlDocument_0.SelectSingleNode("//*[@id='nameelement']").InnerText = string_1;
			return xmlDocument_0;
		}
	}
}
