using DCSoft.Common;
using System;
using System.Collections;
using System.Collections.Generic;
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
	[Serializable]
	[ComVisible(false)]
	public class GClass23
	{
		private int int_0 = Environment.TickCount;

		private StringWriter stringWriter_0 = new StringWriter();

		[NonSerialized]
		private XmlTextWriter xmlTextWriter_0 = null;

		private bool bool_0 = false;

		private float float_0 = 7.5f;

		private float float_1 = 18f;

		private string string_0 = "";

		private bool bool_1 = false;

		private bool bool_2 = false;

		[NonSerialized]
		private Encoding encoding_0 = Encoding.Default;

		private bool bool_3 = false;

		private XWebBrowsersStyle xwebBrowsersStyle_0 = XWebBrowsersStyle.InternetExplorer;

		private GEnum79 genum79_0 = GEnum79.const_0;

		private string string_1 = null;

		private Dictionary<string, string> dictionary_0 = new Dictionary<string, string>();

		private string string_2 = "xs_{0}";

		private bool bool_4 = false;

		private Dictionary<string, string> dictionary_1 = null;

		[NonSerialized]
		private Font font_0 = null;

		private bool bool_5 = false;

		private bool bool_6 = true;

		private int int_1 = 0;

		private string string_3 = null;

		private GClass356 gclass356_0 = new GClass356();

		[NonSerialized]
		public GDelegate21 gdelegate21_0 = null;

		private string string_4 = null;

		private bool bool_7 = false;

		private static XmlDocument xmlDocument_0 = null;

		public GClass23()
		{
			xmlTextWriter_0 = new XmlTextWriter(stringWriter_0);
		}

		public int method_0()
		{
			return int_0;
		}

		public int method_1()
		{
			return Environment.TickCount - int_0;
		}

		public StringBuilder method_2()
		{
			if (stringWriter_0 == null)
			{
				return null;
			}
			return stringWriter_0.GetStringBuilder();
		}

		public virtual void vmethod_0()
		{
			if (gclass356_0 != null)
			{
				gclass356_0.Clear();
			}
			if (xmlTextWriter_0 != null)
			{
				xmlTextWriter_0.Close();
				xmlTextWriter_0 = null;
			}
		}

		public virtual void vmethod_1()
		{
			xmlTextWriter_0.WriteStartDocument();
		}

		public virtual void vmethod_2()
		{
			int num = 17;
			int num2 = method_1();
			int num3 = (method_2() != null) ? method_2().Length : 0;
			xmlTextWriter_0.WriteComment("$$输出HTML代码,共输出" + num3 + "个字符，耗时 " + num2 + " 毫秒。$$");
			xmlTextWriter_0.WriteEndDocument();
		}

		public virtual void imethod_0(string string_5)
		{
			xmlTextWriter_0.WriteStartElement(string_5);
		}

		public virtual void imethod_1()
		{
			xmlTextWriter_0.WriteEndElement();
		}

		public virtual void imethod_2()
		{
			xmlTextWriter_0.WriteFullEndElement();
		}

		public void method_3(string string_5)
		{
			xmlTextWriter_0.WriteString(string_5);
		}

		public void method_4(string string_5)
		{
			xmlTextWriter_0.WriteEntityRef(string_5);
		}

		public void method_5(char char_0)
		{
			xmlTextWriter_0.WriteCharEntity(char_0);
		}

		public void method_6(string string_5, string string_6)
		{
			int num = 12;
			if (string.IsNullOrEmpty(string_5))
			{
				throw new ArgumentNullException("name");
			}
			imethod_0("param");
			method_19("name", string_5);
			if (string_6 != null)
			{
				method_19("value", string_6);
			}
			imethod_1();
		}

		public void method_7(string string_5)
		{
			int num = 9;
			if (!string.IsNullOrEmpty(string_5))
			{
				imethod_0("script");
				method_19("language", "javascript");
				method_3("   ");
				method_18(string_5);
				imethod_2();
			}
		}

		public void method_8(string string_5)
		{
			int num = 16;
			if (!string.IsNullOrEmpty(string_5))
			{
				imethod_0("script");
				method_19("language", "javascript");
				method_19("src", string_5);
				method_19("type", "text/javascript");
				imethod_2();
			}
		}

		public bool method_9()
		{
			return bool_0;
		}

		public void method_10(bool bool_8)
		{
			bool_0 = bool_8;
		}

		public float method_11()
		{
			return float_0;
		}

		public void method_12(float float_2)
		{
			float_0 = float_2;
		}

		public float method_13()
		{
			return float_1;
		}

		public void method_14(float float_2)
		{
			float_1 = float_2;
		}

		public void method_15(string string_5)
		{
			int num = 9;
			if (string_5 != null)
			{
				string_5 = HttpUtility.HtmlEncode(string_5);
				if (method_9())
				{
					string[] array = method_16(string_5);
					string[] array2 = array;
					foreach (string text in array2)
					{
						if (text[0] == ' ')
						{
							xmlTextWriter_0.WriteStartElement("span");
							int num2 = text.Length;
							if (num2 > 4)
							{
								num2 -= 2;
							}
							xmlTextWriter_0.WriteAttributeString("style", "width:" + Convert.ToString(method_11() * (float)num2));
							xmlTextWriter_0.WriteFullEndElement();
						}
						else
						{
							string text2 = null;
							text2 = ((!method_22()) ? text.Replace("\r\n", "<br />") : text.Replace("\r\n", "<br style='mso-data-placement:same-cell' />"));
							xmlTextWriter_0.WriteString(text2);
						}
					}
				}
				else
				{
					string_5 = string_5.Replace(" ", "&ensp;");
					string_5 = string_5.Replace("\t", "&ensp;&ensp;&ensp;");
					string_5 = ((!method_22()) ? string_5.Replace("\r\n", "<br />") : string_5.Replace("\r\n", "<br style='mso-data-placement:same-cell'/>"));
					if (string_5.Length == 0)
					{
						xmlTextWriter_0.WriteString(" ");
					}
					else
					{
						xmlTextWriter_0.WriteRaw(string_5);
					}
				}
			}
			else
			{
				xmlTextWriter_0.WriteString(" ");
			}
		}

		private string[] method_16(string string_5)
		{
			ArrayList arrayList = new ArrayList();
			StringBuilder stringBuilder = new StringBuilder();
			bool flag = false;
			foreach (char c in string_5)
			{
				bool flag2;
				if ((flag2 = (c == ' ')) != flag && stringBuilder.Length > 0)
				{
					arrayList.Add(stringBuilder.ToString());
					stringBuilder = new StringBuilder();
				}
				flag = flag2;
				stringBuilder.Append(c);
			}
			if (stringBuilder.Length > 0)
			{
				arrayList.Add(stringBuilder.ToString());
			}
			return (string[])arrayList.ToArray(typeof(string));
		}

		public void method_17(string string_5, string string_6)
		{
			xmlTextWriter_0.WriteElementString(string_5, string_6);
		}

		public void method_18(string string_5)
		{
			xmlTextWriter_0.WriteRaw(string_5);
		}

		public void method_19(string string_5, string string_6)
		{
			int num = 14;
			if (string_5 == null || string_5.Trim().Length == 0)
			{
				throw new ArgumentNullException("name");
			}
			xmlTextWriter_0.WriteAttributeString(string_5.Trim(), string_6);
		}

		public virtual void vmethod_3(int int_2)
		{
			int num = 1;
			if (int_2 > 0)
			{
				if (vmethod_4())
				{
					xmlTextWriter_0.WriteStartElement("span");
				}
				for (int i = 0; i < int_2; i++)
				{
					xmlTextWriter_0.WriteRaw("&nbsp;");
				}
				if (vmethod_4())
				{
					xmlTextWriter_0.WriteEndElement();
				}
			}
		}

		public string method_20()
		{
			return string_0;
		}

		public void method_21(string string_5)
		{
			string_0 = string_5;
		}

		public virtual bool vmethod_4()
		{
			return bool_1;
		}

		public virtual void vmethod_5(bool bool_8)
		{
			bool_1 = bool_8;
		}

		public bool method_22()
		{
			return bool_2;
		}

		public void method_23(bool bool_8)
		{
			bool_2 = bool_8;
		}

		public Encoding method_24()
		{
			if (encoding_0 == null)
			{
				encoding_0 = Encoding.Default;
			}
			return encoding_0;
		}

		public void method_25(Encoding encoding_1)
		{
			encoding_0 = encoding_1;
		}

		public bool method_26()
		{
			return bool_3;
		}

		public void method_27(bool bool_8)
		{
			bool_3 = bool_8;
		}

		public XWebBrowsersStyle method_28()
		{
			return xwebBrowsersStyle_0;
		}

		public void method_29(XWebBrowsersStyle xwebBrowsersStyle_1)
		{
			xwebBrowsersStyle_0 = xwebBrowsersStyle_1;
		}

		public GEnum78 method_30()
		{
			if (method_28() == XWebBrowsersStyle.InternetExplorer && method_31() == GEnum79.const_0)
			{
				return GEnum78.const_0;
			}
			return GEnum78.const_1;
		}

		public GEnum79 method_31()
		{
			return genum79_0;
		}

		public void method_32(GEnum79 genum79_1)
		{
			genum79_0 = genum79_1;
			string_1 = null;
		}

		public string method_33()
		{
			int num = 19;
			if (string_1 == null)
			{
				switch (method_31())
				{
				default:
					string_1 = "<html>";
					break;
				case GEnum79.const_0:
					string_1 = "<html>";
					break;
				case GEnum79.const_1:
					string_1 = "<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.01 Transitional//EN\" \"http://www.w3.org/TR/html4/loose.dtd\">" + Environment.NewLine + "<html>";
					break;
				case GEnum79.const_2:
					string_1 = "<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.01//EN\" \"http://www.w3.org/TR/html4/strict.dtd\">" + Environment.NewLine + "<html>";
					break;
				case GEnum79.const_3:
					string_1 = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">" + Environment.NewLine + "<html xmlns=\"http://www.w3.org/1999/xhtml\">";
					break;
				case GEnum79.const_4:
					string_1 = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Strict//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd\">" + Environment.NewLine + "<html xmlns=\"http://www.w3.org/1999/xhtml\">";
					break;
				case GEnum79.const_5:
					string_1 = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.1//EN\" \"http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd\">" + Environment.NewLine + "<html xmlns=\"http://www.w3.org/1999/xhtml\">";
					break;
				}
			}
			return string_1;
		}

		public string method_34()
		{
			xmlTextWriter_0.Flush();
			string string_ = stringWriter_0.ToString();
			return method_80(string_);
		}

		public void method_35()
		{
			stringWriter_0 = new StringWriter();
			xmlTextWriter_0 = new XmlTextWriter(stringWriter_0);
			if (vmethod_4())
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

		public string method_36()
		{
			int num = 19;
			if (string_2 == null || string_2.Length == 0)
			{
				return "xs_{0}";
			}
			return string_2;
		}

		public void method_37(string string_5)
		{
			string_2 = string_5;
		}

		public virtual bool vmethod_6()
		{
			return bool_4;
		}

		public virtual void vmethod_7(bool bool_8)
		{
			bool_4 = bool_8;
		}

		public string method_38()
		{
			int num = 2;
			if (dictionary_0 == null || dictionary_0.Count == 0)
			{
				return "";
			}
			StringBuilder stringBuilder = new StringBuilder();
			foreach (string key in dictionary_0.Keys)
			{
				stringBuilder.Append(Environment.NewLine);
				stringBuilder.Append("   ." + key + "{" + dictionary_0[key] + "}");
			}
			stringBuilder.Append(Environment.NewLine);
			return stringBuilder.ToString();
		}

		public void method_39()
		{
			dictionary_1 = new Dictionary<string, string>();
			method_53(0);
		}

		public void method_40(string string_5, string string_6)
		{
			int num = 4;
			if (dictionary_1 == null)
			{
				throw new InvalidOperationException("Can not set style");
			}
			dictionary_1[string_5] = string_6;
		}

		public Font method_41()
		{
			if (font_0 == null)
			{
				font_0 = Control.DefaultFont;
			}
			return font_0;
		}

		public void method_42(Font font_1)
		{
			font_0 = font_1;
		}

		public bool method_43()
		{
			return bool_5;
		}

		public void method_44(bool bool_8)
		{
			bool_5 = bool_8;
		}

		public void method_45(Font font_1)
		{
			int num = 1;
			if (font_1 == null)
			{
				throw new ArgumentNullException("font");
			}
			method_40("font-family", font_1.Name);
			method_40("font-size", font_1.Size + "pt");
			if (font_1.Italic)
			{
				method_40("font-style", "italic");
			}
			else if (method_43())
			{
				method_40("font-style", "normal");
			}
			if (font_1.Bold)
			{
				method_40("font-weight", "bold");
			}
			else if (method_43())
			{
				method_40("font-weight", "normal");
			}
			if (font_1.Underline)
			{
				method_40("text-decoration", "underline");
			}
			else if (method_43())
			{
				method_40("text-decoration", "none");
			}
			else if (font_1.Strikeout)
			{
				method_40("text-decoration", "line-through");
			}
			else if (method_43())
			{
				method_40("text-decoration", "none");
			}
		}

		public void method_46(int int_2, int int_3, int int_4, int int_5)
		{
			int num = 17;
			if (int_2 != 0)
			{
				method_40("padding-left", int_2.ToString());
			}
			if (int_3 != 0)
			{
				method_40("padding-top", int_3.ToString());
			}
			if (int_4 != 0)
			{
				method_40("padding-right", int_4.ToString());
			}
			if (int_5 != 0)
			{
				method_40("padding-bottom", int_5.ToString());
			}
		}

		public void method_47(int int_2, int int_3, int int_4, int int_5)
		{
			int num = 5;
			if (int_2 != 0)
			{
				method_40("margin-left", int_2.ToString());
			}
			if (int_3 != 0)
			{
				method_40("margin-top", int_3.ToString());
			}
			if (int_4 != 0)
			{
				method_40("margin-right", int_4.ToString());
			}
			if (int_5 != 0)
			{
				method_40("margin-bottom", int_5.ToString());
			}
		}

		public void method_48(string string_5, Color color_0, int int_2, DashStyle dashStyle_0)
		{
			int num = 4;
			if (int_2 > 0 && color_0.A != 0)
			{
				string text = "solid";
				switch (dashStyle_0)
				{
				case DashStyle.Solid:
					text = "solid";
					break;
				case DashStyle.Dash:
					text = "dashed";
					break;
				case DashStyle.Dot:
					text = "dotted";
					break;
				case DashStyle.DashDot:
					text = "dotted";
					break;
				case DashStyle.DashDotDot:
					text = "dotted";
					break;
				}
				text = int_2 + "px " + text + " " + method_61(color_0);
				if (string.IsNullOrEmpty(string_5))
				{
					method_40("border", text);
				}
				else
				{
					method_40("border-" + string_5, text);
				}
				if (string.Compare(string_5, "top", ignoreCase: true) == 0 || string.Compare(string_5, "bottom", ignoreCase: true) == 0)
				{
					method_53(method_52() + int_2);
				}
			}
		}

		public void method_49(string string_5, Color color_0, int int_2, DashStyle dashStyle_0)
		{
			int num = 16;
			if (!string.IsNullOrEmpty(string_5) && int_2 > 0)
			{
				string text = "solid";
				switch (dashStyle_0)
				{
				case DashStyle.Solid:
					text = "solid";
					break;
				case DashStyle.Dash:
					text = "dashed";
					break;
				case DashStyle.Dot:
					text = "dotted";
					break;
				case DashStyle.DashDot:
					text = "dotted";
					break;
				case DashStyle.DashDotDot:
					text = "dotted";
					break;
				}
				text = int_2 + "px " + text + " " + method_61(color_0);
				method_40("border-" + string_5, text);
				if (string.Compare(string_5, "top", ignoreCase: true) == 0 || string.Compare(string_5, "bottom", ignoreCase: true) == 0)
				{
					method_53(method_52() + int_2);
				}
			}
		}

		public bool method_50()
		{
			return bool_6;
		}

		public void method_51(bool bool_8)
		{
			bool_6 = bool_8;
		}

		public int method_52()
		{
			if (method_50())
			{
				return int_1;
			}
			return 0;
		}

		public void method_53(int int_2)
		{
			if (method_50())
			{
				int_1 = int_2;
			}
			else
			{
				int_1 = 0;
			}
		}

		public void method_54(bool bool_8, bool bool_9, bool bool_10, bool bool_11, Color color_0, int int_2, DashStyle dashStyle_0)
		{
			int num = 6;
			if ((!bool_8 && !bool_9 && !bool_10 && !bool_11) || int_2 <= 0 || color_0.A == 0)
			{
				return;
			}
			string text = "solid";
			switch (dashStyle_0)
			{
			case DashStyle.Solid:
				text = "solid";
				break;
			case DashStyle.Dash:
				text = "dashed";
				break;
			case DashStyle.Dot:
				text = "dotted";
				break;
			case DashStyle.DashDot:
				text = "dotted";
				break;
			case DashStyle.DashDotDot:
				text = "dotted";
				break;
			}
			text = int_2 + "px " + text + " " + method_61(color_0);
			if (bool_8 && bool_9 && bool_10 && bool_11)
			{
				method_40("border", text);
				method_53(method_52() + int_2);
				method_53(method_52() + int_2);
				return;
			}
			if (bool_8)
			{
				method_40("border-left", text);
			}
			if (bool_9)
			{
				method_40("border-top", text);
				method_53(method_52() + int_2);
			}
			if (bool_10)
			{
				method_40("border-right", text);
			}
			if (bool_11)
			{
				method_40("border-bottom", text);
				method_53(method_52() + int_2);
			}
		}

		public void method_55(string string_5)
		{
			method_40("background-image", "url(" + HttpUtility.HtmlAttributeEncode(string_5) + ")");
		}

		public void method_56(ContentAlignment contentAlignment_0)
		{
			int num = 13;
			string string_ = null;
			switch (contentAlignment_0)
			{
			case ContentAlignment.MiddleCenter:
				string_ = "center center";
				break;
			case ContentAlignment.MiddleLeft:
				string_ = "center left";
				break;
			case ContentAlignment.TopLeft:
				string_ = "top left";
				break;
			case ContentAlignment.TopCenter:
				string_ = "top center";
				break;
			case ContentAlignment.TopRight:
				string_ = "top right";
				break;
			case ContentAlignment.BottomLeft:
				string_ = "bottom left";
				break;
			case ContentAlignment.MiddleRight:
				string_ = "center right";
				break;
			case ContentAlignment.BottomRight:
				string_ = "bottom right";
				break;
			case ContentAlignment.BottomCenter:
				string_ = "bottom center";
				break;
			}
			method_40("background-position", string_);
		}

		public void method_57(int int_2, int int_3)
		{
			method_40("position", "absolute");
			method_40("left", int_2.ToString());
			method_40("top", int_3.ToString());
		}

		public void method_58(StringAlignment stringAlignment_0)
		{
			int num = 6;
			switch (stringAlignment_0)
			{
			case StringAlignment.Far:
				method_40("text-align", "right");
				break;
			case StringAlignment.Center:
				method_40("text-align", "center");
				break;
			default:
				method_40("text-align", "left");
				break;
			}
		}

		public void method_59(Cursor cursor_0)
		{
			method_40("cursor", method_60(cursor_0));
		}

		private string method_60(Cursor cursor_0)
		{
			int num = 6;
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

		public string method_61(Color color_0)
		{
			return smethod_0(color_0);
		}

		public string method_62(DashStyle dashStyle_0)
		{
			int num = 0;
			switch (dashStyle_0)
			{
			default:
				return "solid";
			case DashStyle.Solid:
				return "solid";
			case DashStyle.Dash:
				return "dashed";
			case DashStyle.Dot:
				return "dotted";
			case DashStyle.DashDot:
				return "dashed";
			case DashStyle.DashDotDot:
				return "dotted";
			}
		}

		public static string smethod_0(Color color_0)
		{
			int num = 1;
			if (color_0.A == 0)
			{
				return "transparent";
			}
			if (color_0.ToArgb() == Color.Black.ToArgb())
			{
				return "black";
			}
			if (color_0.ToArgb() == Color.White.ToArgb())
			{
				return "white";
			}
			if (color_0.A == byte.MaxValue)
			{
				return "#" + color_0.R.ToString("X2") + color_0.G.ToString("X2") + color_0.B.ToString("X2");
			}
			return ColorTranslator.ToHtml(color_0);
		}

		public void method_63()
		{
			int num = 17;
			if (dictionary_1 == null)
			{
				throw new InvalidOperationException("StyleString is null");
			}
			StringBuilder stringBuilder = new StringBuilder();
			foreach (string key in dictionary_1.Keys)
			{
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append(";");
				}
				stringBuilder.Append(key + ":" + HttpUtility.HtmlAttributeEncode(dictionary_1[key]));
			}
			string text = stringBuilder.ToString();
			dictionary_1 = null;
			if (vmethod_6())
			{
				string current = null;
				foreach (string key2 in dictionary_0.Keys)
				{
					if (dictionary_0[key2] == text)
					{
						current = key2;
						break;
					}
				}
				if (current == null)
				{
					current = string.Format(method_36(), dictionary_0.Count);
					dictionary_0[current] = text;
				}
				method_19("class", current);
			}
			else
			{
				method_19("style", text);
			}
		}

		public string method_64()
		{
			return string_3;
		}

		public void method_65(string string_5)
		{
			string_3 = string_5;
		}

		public GClass357 method_66(Image image_0, string string_5)
		{
			return method_67(image_0, string_5, null, null);
		}

		public GClass357 method_67(Image image_0, string string_5, object object_0, ImageFormat imageFormat_0)
		{
			int num = 19;
			if (image_0 == null)
			{
				throw new ArgumentNullException("img");
			}
			ImageFormat imageFormat = null;
			foreach (GClass357 item in method_68())
			{
				if (item.method_10() == image_0 && item.Name == string_5)
				{
					return item;
				}
			}
			GClass357 gClass = new GClass357();
			gClass.method_13(object_0);
			gClass.method_11(image_0);
			imageFormat = imageFormat_0;
			if (imageFormat == null)
			{
				imageFormat = GClass343.smethod_3(string_5);
			}
			gClass.method_7(GClass343.smethod_1(string_5));
			if (imageFormat != null)
			{
				MemoryStream memoryStream = new MemoryStream();
				image_0.Save(memoryStream, imageFormat);
				memoryStream.Close();
				gClass = new GClass357();
				if (string.IsNullOrEmpty(string_5))
				{
					string_5 = "image" + method_68().Count + "." + GClass343.smethod_2(imageFormat);
				}
				gClass.Name = string_5;
				gClass.method_9(memoryStream.ToArray());
			}
			else if (imageFormat_0 != null)
			{
				MemoryStream memoryStream = new MemoryStream();
				image_0.Save(memoryStream, imageFormat_0);
				memoryStream.Close();
				byte[] byte_ = memoryStream.ToArray();
				gClass.method_9(byte_);
				gClass.method_7(GClass343.smethod_0(imageFormat_0));
				if (string.IsNullOrEmpty(string_5))
				{
					string_5 = "image" + method_68().Count + "." + GClass343.smethod_2(imageFormat_0);
				}
				gClass.Name = string_5;
			}
			else
			{
				imageFormat = ImageFormat.Png;
				MemoryStream memoryStream = new MemoryStream();
				image_0.Save(memoryStream, ImageFormat.Png);
				memoryStream.Close();
				byte[] array = memoryStream.ToArray();
				memoryStream = new MemoryStream();
				image_0.Save(memoryStream, ImageFormat.Jpeg);
				memoryStream.Close();
				byte[] array2 = memoryStream.ToArray();
				if (array.Length > array2.Length)
				{
					gClass.method_9(array2);
					gClass.method_7("image/jpeg");
					if (string.IsNullOrEmpty(string_5))
					{
						string_5 = "image" + method_68().Count + ".jpg";
					}
					gClass.Name = string_5;
				}
				else
				{
					gClass.method_9(array);
					gClass.method_7("image/png");
					if (string.IsNullOrEmpty(string_5))
					{
						string_5 = "image" + method_68().Count + ".png";
					}
					gClass.Name = string_5;
				}
			}
			if (!string.IsNullOrEmpty(method_64()))
			{
				gClass.method_1(string.Format(method_64(), gClass.Name));
			}
			method_68().Add(gClass);
			if (gdelegate21_0 != null)
			{
				gdelegate21_0(this, new GClass355(this, gClass));
			}
			return gClass;
		}

		public GClass356 method_68()
		{
			return gclass356_0;
		}

		public void method_69(GClass356 gclass356_1)
		{
			gclass356_0 = gclass356_1;
		}

		public string method_70()
		{
			int num = 14;
			StringWriter stringWriter = new StringWriter();
			XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);
			if (vmethod_4())
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
			xmlTextWriter.WriteRaw("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">");
			xmlTextWriter.WriteStartElement("html");
			xmlTextWriter.WriteAttributeString("xmlns", "http://www.w3.org/1999/xhtml");
			if (method_22())
			{
				xmlTextWriter.WriteAttributeString("xmlns:o", "urn:schemas-microsoft-com:office:office");
				xmlTextWriter.WriteAttributeString("xmlns:x", "urn:schemas-microsoft-com:office:excel");
				xmlTextWriter.WriteAttributeString("xmlns:v", "urn:schemas-microsoft-com:vml");
			}
			xmlTextWriter.WriteStartElement("head");
			string text = method_20();
			if (text != null && text.Length > 0)
			{
				xmlTextWriter.WriteElementString("title", text);
			}
			xmlTextWriter.WriteStartElement("meta");
			xmlTextWriter.WriteAttributeString("http-equiv", "Content-Type");
			xmlTextWriter.WriteAttributeString("content", "text/html;charset=" + method_24().BodyName);
			xmlTextWriter.WriteEndElement();
			if (method_22())
			{
				smethod_1(text).WriteContentTo(xmlTextWriter);
			}
			xmlTextWriter.WriteEndElement();
			string text2 = method_38();
			if (!string.IsNullOrEmpty(text2))
			{
				xmlTextWriter.WriteStartElement("style");
				xmlTextWriter.WriteRaw(Environment.NewLine);
				xmlTextWriter.WriteString(text2);
				xmlTextWriter.WriteRaw(Environment.NewLine);
				xmlTextWriter.WriteEndElement();
			}
			xmlTextWriter.WriteStartElement("body");
			if (method_73())
			{
				xmlTextWriter.WriteAttributeString("CONTENTEDITABLE", "true");
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("font-size:" + method_41().Size + "pt;");
			if (!string.IsNullOrEmpty(method_71()))
			{
				stringBuilder.Append("background-image:url(" + HttpUtility.HtmlAttributeEncode(method_71()) + ");background-attachment:fixed;background-repeat:no-repeat;background-position:top center;");
			}
			xmlTextWriter.WriteAttributeString("style", stringBuilder.ToString());
			xmlTextWriter.WriteRaw(Environment.NewLine);
			xmlTextWriter.WriteRaw(method_34());
			xmlTextWriter.WriteEndElement();
			xmlTextWriter.WriteEndElement();
			xmlTextWriter.WriteEndDocument();
			xmlTextWriter.Close();
			return method_80(stringWriter.ToString());
		}

		public string method_71()
		{
			return string_4;
		}

		public void method_72(string string_5)
		{
			string_4 = string_5;
		}

		public bool method_73()
		{
			return bool_7;
		}

		public void method_74(bool bool_8)
		{
			bool_7 = bool_8;
		}

		public void method_75(TextWriter textWriter_0)
		{
			int num = 7;
			if (textWriter_0 == null)
			{
				throw new ArgumentNullException("writer");
			}
			textWriter_0.Write(method_70());
		}

		public void method_76(Stream stream_0)
		{
			int num = 7;
			if (stream_0 == null)
			{
				throw new ArgumentNullException("stream");
			}
			byte[] bytes = method_24().GetBytes(method_70());
			stream_0.Write(bytes, 0, bytes.Length);
		}

		public void method_77(string string_5, string string_6)
		{
			int num = 12;
			string text = method_70();
			string text2 = null;
			if (string.IsNullOrEmpty(string_6))
			{
				text2 = "";
			}
			else if (Path.IsPathRooted(string_6))
			{
				text2 = null;
				string directoryName = Path.GetDirectoryName(string_5);
				if (string_6.StartsWith(directoryName, StringComparison.InvariantCulture))
				{
					text2 = string_6.Substring(directoryName.Length);
					if (text2.StartsWith("\\"))
					{
						text2 = text2.Substring(1);
					}
				}
			}
			else
			{
				text2 = string_6;
			}
			Dictionary<GClass357, string> dictionary = new Dictionary<GClass357, string>();
			Path.GetDirectoryName(string_5);
			if (!string.IsNullOrEmpty(string_6) && method_68() != null && method_68().Count > 0)
			{
				foreach (GClass357 item in method_68())
				{
					string text3 = item.Name;
					if (!Path.IsPathRooted(text3))
					{
						text3 = Path.Combine(string_6, text3);
					}
					dictionary[item] = text3;
					if (text2 != null)
					{
						string text4 = Path.Combine(text2, item.Name);
						text4 = text4.Replace('\\', '/');
						text = text.Replace(item.method_0(), text4);
					}
					else
					{
						text = text.Replace(item.method_0(), text3);
					}
					if (item.method_8() != null && item.method_8().Length > 0)
					{
						using (FileStream fileStream = new FileStream(text3, FileMode.Create, FileAccess.Write))
						{
							fileStream.Write(item.method_8(), 0, item.method_8().Length);
						}
					}
				}
			}
			using (StreamWriter streamWriter = new StreamWriter(string_5, append: false, method_24()))
			{
				streamWriter.Write(text);
			}
		}

		public int method_78(string string_5)
		{
			int num = 9;
			if (string_5 == null || string_5.Trim().Length == 0)
			{
				throw new ArgumentNullException("path");
			}
			string_5 = string_5.Trim();
			if (!Directory.Exists(string_5))
			{
				Directory.CreateDirectory(string_5);
			}
			Dictionary<GClass357, string> dictionary = new Dictionary<GClass357, string>();
			if (method_68() != null && method_68().Count > 0)
			{
				foreach (GClass357 item in method_68())
				{
					string text = item.Name;
					if (!Path.IsPathRooted(text))
					{
						text = Path.Combine(string_5, text);
					}
					dictionary[item] = text;
					if (item.method_8() != null && item.method_8().Length > 0)
					{
						using (FileStream fileStream = new FileStream(text, FileMode.Create, FileAccess.Write))
						{
							fileStream.Write(item.method_8(), 0, item.method_8().Length);
						}
					}
				}
			}
			return dictionary.Count;
		}

		public void method_79(Stream stream_0)
		{
			using (StreamWriter textWriter_ = new StreamWriter(stream_0, method_24()))
			{
				GClass336 gClass = new GClass336(textWriter_);
				gClass.method_9(method_70());
				gClass.method_5(method_20());
				gClass.method_1(method_24());
				foreach (GClass357 item in method_68())
				{
					GClass337 gClass2 = new GClass337();
					gClass2.method_7(item.method_0());
					gClass2.method_1(item.method_8());
					gClass2.method_3(bool_2: true);
					gClass2.method_5(item.method_6());
					gClass2.method_11(item.method_2());
					gClass.method_6().Add(gClass2);
				}
				gClass.method_10();
			}
		}

		private static XmlDocument smethod_1(string string_5)
		{
			int num = 8;
			if (xmlDocument_0 == null)
			{
				xmlDocument_0 = new XmlDocument();
				xmlDocument_0.LoadXml("<xml xmlns:o='urn:schemas-microsoft-com:office:office'\r\nxmlns:x='urn:schemas-microsoft-com:office:excel'>\r\n\t\t\t\t\t\t<o:DocumentProperties>\r\n\t\t\t\t\t\t\t<o:Author>XReport</o:Author>\r\n\t\t\t\t\t\t\t<o:LastAuthor>ys2006</o:LastAuthor>\r\n\t\t\t\t\t\t\t<o:Created></o:Created>\r\n\t\t\t\t\t\t\t<o:LastSaved></o:LastSaved>\r\n\t\t\t\t\t\t\t<o:Company>DCSoft</o:Company>\r\n\t\t\t\t\t\t\t<o:Version>9.2812</o:Version>\r\n\t\t\t\t\t\t</o:DocumentProperties>\r\n\t\t\t\t\t\t<x:ExcelWorkbook>\r\n\t\t\t\t\t\t\t<x:ExcelWorksheets>\r\n\t\t\t\t\t\t\t\t<x:ExcelWorksheet>\r\n\t\t\t\t\t\t\t\t\t<x:Name id='nameelement' ></x:Name>\r\n\t\t\t\t\t\t\t\t\t<x:WorksheetOptions>\r\n\t\t\t\t\t\t\t\t\t\t<x:DefaultRowHeight>285</x:DefaultRowHeight>\r\n\t\t\t\t\t\t\t\t\t\t<x:Print>\r\n\t\t\t\t\t\t\t\t\t\t\t<x:ValidPrinterInfo />\r\n\t\t\t\t\t\t\t\t\t\t\t<x:PaperSizeIndex>9</x:PaperSizeIndex>\r\n\t\t\t\t\t\t\t\t\t\t\t<x:HorizontalResolution>100</x:HorizontalResolution>\r\n\t\t\t\t\t\t\t\t\t\t\t<x:VerticalResolution>100</x:VerticalResolution>\r\n\t\t\t\t\t\t\t\t\t\t</x:Print>\r\n\t\t\t\t\t\t\t\t\t\t<x:Selected />\r\n\t\t\t\t\t\t\t\t\t\t<x:ProtectContents>False</x:ProtectContents>\r\n\t\t\t\t\t\t\t\t\t\t<x:ProtectObjects>False</x:ProtectObjects>\r\n\t\t\t\t\t\t\t\t\t\t<x:ProtectScenarios>False</x:ProtectScenarios>\r\n\t\t\t\t\t\t\t\t\t</x:WorksheetOptions>\r\n\t\t\t\t\t\t\t\t</x:ExcelWorksheet>\r\n\t\t\t\t\t\t\t</x:ExcelWorksheets>\r\n\t\t\t\t\t\t\t<x:WindowHeight>13275</x:WindowHeight>\r\n\t\t\t\t\t\t\t<x:WindowWidth>18180</x:WindowWidth>\r\n\t\t\t\t\t\t\t<x:WindowTopX>480</x:WindowTopX>\r\n\t\t\t\t\t\t\t<x:WindowTopY>15</x:WindowTopY>\r\n\t\t\t\t\t\t\t<x:ProtectStructure>False</x:ProtectStructure>\r\n\t\t\t\t\t\t\t<x:ProtectWindows>False</x:ProtectWindows>\r\n\t\t\t\t\t\t</x:ExcelWorkbook>\r\n\t\t\t\t\t</xml>");
			}
			xmlDocument_0.SelectSingleNode("//*[@id='nameelement']").InnerText = string_5;
			return xmlDocument_0;
		}

		private string method_80(string string_5)
		{
			int num = 5;
			if (string_5 != null)
			{
				int num2 = string_5.IndexOf("?>");
				num2 = ((num2 > 0) ? (num2 + 2) : 0);
				int num3 = num2;
				while (true)
				{
					if (num3 < string_5.Length)
					{
						if (!char.IsWhiteSpace(string_5, num3))
						{
							break;
						}
						num3++;
						continue;
					}
					return string_5;
				}
				return string_5.Substring(num3);
			}
			return null;
		}
	}
}
