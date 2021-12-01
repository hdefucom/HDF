using DCSoft.Drawing;
using DCSoft.Printing;
using DCSoft.RTF;
using DCSoft.Writer.Dom;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Serialization;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass103 : GClass102
	{
		public const string string_0 = "DCWriter.Object:";

		private GClass416 gclass416_0 = null;

		private bool bool_1 = false;

		private bool bool_2 = false;

		private bool bool_3 = true;

		private XTextElement xtextElement_0 = null;

		private RuntimeDocumentContentStyle runtimeDocumentContentStyle_0 = null;

		internal bool bool_4 = true;

		public GClass103()
		{
		}

		public GClass103(TextWriter textWriter_0)
		{
			gclass416_0 = new GClass416(textWriter_0);
			gclass416_0.method_10(bool_3: false);
		}

		public virtual bool vmethod_4(TextWriter textWriter_0)
		{
			gclass416_0 = new GClass416(textWriter_0);
			gclass416_0.method_10(bool_3: false);
			return true;
		}

		public virtual bool vmethod_5(string string_1)
		{
			gclass416_0 = new GClass416(string_1);
			gclass416_0.method_10(bool_3: false);
			return true;
		}

		public virtual void vmethod_6()
		{
			gclass416_0.vmethod_2();
		}

		public GClass416 method_10()
		{
			return gclass416_0;
		}

		public void method_11(GClass416 gclass416_1)
		{
			gclass416_0 = gclass416_1;
		}

		public bool method_12()
		{
			return bool_1;
		}

		public void method_13(bool bool_5)
		{
			bool_1 = bool_5;
		}

		public bool method_14()
		{
			return bool_2;
		}

		public void method_15(bool bool_5)
		{
			bool_2 = bool_5;
		}

		public bool method_16()
		{
			return bool_3;
		}

		public void method_17(bool bool_5)
		{
			bool_3 = bool_5;
		}

		public XTextElement method_18()
		{
			return xtextElement_0;
		}

		public void method_19(XTextElement xtextElement_1)
		{
			xtextElement_0 = xtextElement_1;
		}

		public int method_20(float float_0)
		{
			return GraphicsUnitConvert.ToTwips(float_0, method_4().DocumentGraphicsUnit);
		}

		public void method_21(XTextElement xtextElement_1, Image image_0)
		{
			int num = 11;
			bool flag = false;
			if (image_0 == null)
			{
				image_0 = xtextElement_1.CreateContentImage();
				flag = true;
			}
			Size size = new Size(GraphicsUnitConvert.ToTwips(image_0.Width, GraphicsUnit.Pixel), GraphicsUnitConvert.ToTwips(image_0.Height, GraphicsUnit.Pixel));
			method_23();
			method_28("object");
			method_28("objemb");
			method_27("objclass", "DCWriter.Object:" + xtextElement_1.GetType().FullName, bool_5: true);
			method_28("objw" + size.Width);
			method_28("objh" + size.Height);
			StringWriter stringWriter = new StringWriter();
			XmlSerializer xmlSerializer = Class109.smethod_7(xtextElement_1.GetType());
			xmlSerializer.Serialize(stringWriter, xtextElement_1);
			stringWriter.Close();
			string s = stringWriter.ToString();
			byte[] bytes = Encoding.UTF8.GetBytes(s);
			method_23();
			method_25("objdata", bool_5: true);
			method_26(bytes);
			method_24();
			method_23();
			method_28("result");
			method_45(image_0, image_0.Width, image_0.Height, null, xtextElement_1.RuntimeStyle);
			method_24();
			method_24();
			if (flag)
			{
				image_0.Dispose();
			}
		}

		public int method_22()
		{
			return method_10().method_0().method_6();
		}

		public void method_23()
		{
			method_10().method_12();
		}

		public void method_24()
		{
			method_10().method_13();
		}

		public void method_25(string string_1, bool bool_5)
		{
			method_10().method_15(string_1, bool_5);
		}

		public void method_26(byte[] byte_0)
		{
			method_10().method_0().method_19(byte_0);
		}

		public void method_27(string string_1, string string_2, bool bool_5)
		{
			method_10().method_12();
			method_10().method_0().method_14(string_1, bool_5);
			method_10().method_31(string_2);
			method_10().method_13();
		}

		public void method_28(string string_1)
		{
			method_10().method_14(string_1);
		}

		public void method_29()
		{
			int num = 15;
			method_10().method_7(new GClass419());
			method_10().method_5(new GClass403());
			method_10().method_7(new GClass419());
			int tickCount = Environment.TickCount;
			foreach (XTextDocument item in method_2())
			{
				method_10().method_3().method_4(item.DefaultStyle.FontName, Encoding.Default);
				method_10().method_8().method_4(Color.Black);
				method_10().method_8().method_4(Color.White);
				method_10().method_8().method_4(item.DefaultStyle.Color);
				method_10().method_8().method_4(item.Options.ViewOptions.BackgroundTextColor);
				foreach (DocumentContentStyle style in item.ContentStyles.Styles)
				{
					if (!string.IsNullOrEmpty(style.FontName))
					{
						method_10().method_3().method_4(style.FontName, Encoding.Default);
					}
					method_10().method_8().method_4(style.Color);
					method_10().method_8().method_4(style.BackgroundColor);
					method_10().method_8().method_4(style.BorderLeftColor);
					method_10().method_8().method_4(style.BorderTopColor);
					method_10().method_8().method_4(style.BorderRightColor);
					method_10().method_8().method_4(style.BorderBottomColor);
					method_10().method_8().method_4(style.PrintColor);
				}
				foreach (XTextElement element in item.Elements)
				{
					XTextDocumentContentElement xTextDocumentContentElement = element as XTextDocumentContentElement;
					if (xTextDocumentContentElement == null && item.Options.BehaviorOptions.WeakMode)
					{
						throw new InvalidCastException(element.GetType().Name + "->XTextDocumentContentElement");
					}
					GClass404 gClass = new GClass404();
					gClass.method_1(method_10().method_4().Count + 1);
					gClass.method_3(tickCount++);
					method_10().method_4().Add(gClass);
					if (xTextDocumentContentElement.RootParagraphFlag != null)
					{
						method_30(xTextDocumentContentElement.RootParagraphFlag.ChildParagraphs, gClass, 0);
						if (gClass.method_12().Count == 0)
						{
							method_10().method_4().Remove(gClass);
						}
					}
					if (xTextDocumentContentElement.FreeParagraphFlagGroups != null)
					{
						foreach (List<XTextParagraphFlagElement> freeParagraphFlagGroup in xTextDocumentContentElement.FreeParagraphFlagGroups)
						{
							GClass404 gClass2 = new GClass404();
							gClass2.method_1(method_10().method_4().Count + 1);
							gClass2.method_3(tickCount++);
							method_10().method_4().Add(gClass2);
							method_30(freeParagraphFlagGroup, gClass2, 0);
							if (gClass2.method_12().Count == 0)
							{
								method_10().method_4().Remove(gClass2);
							}
						}
					}
				}
			}
		}

		private void method_30(List<XTextParagraphFlagElement> list_0, GClass404 gclass404_0, int int_0)
		{
			int num = 8;
			if (list_0 != null && list_0.Count != 0)
			{
				int rTFListOverriedID = 0;
				int num2 = -1;
				foreach (XTextParagraphFlagElement item in list_0)
				{
					if (item.OutlineLevel >= 0)
					{
						item.RTFOutlineLevel = int_0;
					}
					else
					{
						item.RTFOutlineLevel = -1;
					}
					if (item.ListIndex == 1)
					{
						num2++;
						if (num2 > 0)
						{
							gclass404_0 = new GClass404();
							gclass404_0.method_1(method_10().method_4().Count + 1);
							method_10().method_4().Add(gclass404_0);
							rTFListOverriedID = 0;
						}
						GClass405 gClass = gclass404_0.method_14(int_0);
						gClass.method_1(1);
						method_31(gClass, item.RuntimeStyle, int_0);
						if (item.RuntimeStyle.IsBulletedList && method_10().method_3().method_1("Wingdings") == null)
						{
							GClass431 gClass2 = method_10().method_3().method_3("Wingdings");
							gClass2.method_5(2);
						}
						gclass404_0.method_12().IndexOf(gClass);
						bool flag = false;
						foreach (GClass420 item2 in method_10().method_6())
						{
							if (item2.method_0() == gclass404_0.method_0())
							{
								rTFListOverriedID = item2.method_4();
								flag = true;
								break;
							}
						}
						if (!flag)
						{
							GClass420 gClass3 = new GClass420();
							gClass3.method_5(method_10().method_6().Count + 1);
							gClass3.method_1(gclass404_0.method_0());
							method_10().method_6().Add(gClass3);
							rTFListOverriedID = gClass3.method_4();
						}
					}
					item.RTFListOverriedID = rTFListOverriedID;
					method_30(item.ChildParagraphs, gclass404_0, int_0 + 1);
				}
			}
		}

		private void method_31(GClass405 gclass405_0, RuntimeDocumentContentStyle runtimeDocumentContentStyle_1, int int_0)
		{
			int num = 11;
			gclass405_0.method_11(GClass470.smethod_1(runtimeDocumentContentStyle_1.ParagraphListStyle));
			gclass405_0.method_1(1);
			if (runtimeDocumentContentStyle_1.IsBulletedList)
			{
				gclass405_0.method_3(LevelNumberType.Bullet);
				return;
			}
			if (int_0 >= 0)
			{
				StringBuilder stringBuilder = new StringBuilder();
				StringBuilder stringBuilder2 = new StringBuilder();
				for (int i = 0; i <= int_0; i++)
				{
					stringBuilder.Append((char)i);
					stringBuilder.Append('.');
					stringBuilder2.Append((char)(1 + i * 2));
				}
				gclass405_0.method_11(stringBuilder.ToString());
				gclass405_0.method_13(stringBuilder2.ToString());
			}
			switch (runtimeDocumentContentStyle_1.ParagraphListStyle)
			{
			case ParagraphListStyle.BulletedList:
				gclass405_0.method_3(LevelNumberType.Bullet);
				break;
			case ParagraphListStyle.ListNumberStyle:
				gclass405_0.method_3(LevelNumberType.Arabic);
				break;
			case ParagraphListStyle.ListNumberStyleArabic1:
				gclass405_0.method_3(LevelNumberType.Arabic_Abjad_style);
				break;
			case ParagraphListStyle.ListNumberStyleArabic2:
				gclass405_0.method_3(LevelNumberType.Arabic_Alif_Ba_Tah);
				break;
			case ParagraphListStyle.ListNumberStyleLowercaseLetter:
				gclass405_0.method_3(LevelNumberType.Lowercase_letter);
				break;
			case ParagraphListStyle.ListNumberStyleLowercaseRoman:
				gclass405_0.method_3(LevelNumberType.Lowercase_Roman_numeral);
				break;
			default:
				gclass405_0.method_3(LevelNumberType.Arabic);
				break;
			case ParagraphListStyle.ListNumberStyleSimpChinNum1:
				gclass405_0.method_3(LevelNumberType.Chinese_numbering_2);
				break;
			case ParagraphListStyle.ListNumberStyleSimpChinNum2:
				gclass405_0.method_3(LevelNumberType.Chinese_numbering_1);
				break;
			case ParagraphListStyle.ListNumberStyleTradChinNum1:
				gclass405_0.method_3(LevelNumberType.Chinese_double_byte_numbering_2);
				break;
			case ParagraphListStyle.ListNumberStyleTradChinNum2:
				gclass405_0.method_3(LevelNumberType.Chinese_double_byte_numbering_1);
				break;
			case ParagraphListStyle.ListNumberStyleUppercaseLetter:
				gclass405_0.method_3(LevelNumberType.Uppercase_letter);
				break;
			case ParagraphListStyle.ListNumberStyleUppercaseRoman:
				gclass405_0.method_3(LevelNumberType.Uppercase_Roman_numeral);
				break;
			case ParagraphListStyle.ListNumberStyleZodiac1:
				gclass405_0.method_3(LevelNumberType.Chinese_Zodiac_numbering_1);
				break;
			case ParagraphListStyle.ListNumberStyleZodiac2:
				gclass405_0.method_3(LevelNumberType.Chinese_Zodiac_numbering_2);
				break;
			}
			if (runtimeDocumentContentStyle_1.IsBulletedList && method_10().method_3().method_1("Wingdings") == null)
			{
				GClass431 gClass = method_10().method_3().method_3("Wingdings");
				gClass.method_5(2);
			}
		}

		public void method_32(XTextDocument xtextDocument_0)
		{
			int num = 19;
			if (xtextDocument_0 == null)
			{
				throw new ArgumentNullException("document");
			}
			method_10().method_10(bool_3: false);
			method_10().method_2()["title"] = xtextDocument_0.Info.Title;
			method_10().method_2()["subject"] = xtextDocument_0.Info.Description;
			method_10().method_2()["author"] = xtextDocument_0.Info.Author;
			method_10().method_2()["creatim"] = xtextDocument_0.Info.CreationTime;
			method_10().method_2()["comment"] = xtextDocument_0.Info.Comment;
			method_10().method_2()["operator"] = xtextDocument_0.Info.Operator;
			method_10().method_20();
			XPageSettings pageSettings = xtextDocument_0.PageSettings;
			method_10().method_14("paperw" + method_20(pageSettings.ViewPaperWidth));
			method_10().method_14("paperh" + method_20(pageSettings.ViewPaperHeight));
			if (pageSettings.Landscape)
			{
				method_10().method_14("landscape");
			}
			method_10().method_14("margl" + method_20(pageSettings.ViewLeftMargin));
			method_10().method_14("margr" + method_20(pageSettings.ViewRightMargin));
			int num2 = 0;
			if (method_14())
			{
				num2 = 80;
			}
			if (method_16())
			{
				float num3 = pageSettings.ViewTopMargin;
				if (!method_4().Header.HasContentElement)
				{
					num3 = Math.Max(num3, pageSettings.ViewHeaderDistance + method_4().Header.Height);
				}
				float num4 = pageSettings.ViewBottomMargin;
				if (!method_4().Footer.HasContentElement)
				{
					num4 = Math.Max(pageSettings.BottomMargin, pageSettings.ViewFooterDistance);
				}
				method_10().method_14("margt" + method_20(num3 - (float)num2));
				method_10().method_14("margb" + method_20(num4 - (float)num2));
				if (pageSettings.FooterDistance > 0)
				{
					method_10().method_14("footery" + method_20(pageSettings.ViewFooterDistance - (float)num2));
				}
				if (pageSettings.HeaderDistance > 0)
				{
					method_10().method_14("headery" + method_20(pageSettings.ViewHeaderDistance - (float)num2));
				}
			}
			else
			{
				method_10().method_14("margt" + method_20(pageSettings.ViewTopMargin - (float)num2));
				method_10().method_14("margb" + method_20(pageSettings.ViewBottomMargin - (float)num2));
			}
		}

		public void method_33()
		{
			method_4();
			method_32(method_4());
		}

		public override void vmethod_3(XTextElement xtextElement_1)
		{
			xtextElement_1.vmethod_19(this);
		}

		public void method_34()
		{
			gclass416_0.method_21();
		}

		public void method_35(RuntimeDocumentContentStyle runtimeDocumentContentStyle_1, XTextParagraphFlagElement xtextParagraphFlagElement_0)
		{
			int num = 14;
			if (bool_4)
			{
				bool_4 = false;
				method_10().method_0().method_12(Environment.NewLine);
			}
			else
			{
				method_10().method_14("par");
			}
			if (runtimeDocumentContentStyle_0 != null)
			{
				if (runtimeDocumentContentStyle_0.ParagraphListStyle != 0)
				{
					method_10().method_14("pard");
				}
				else
				{
					method_10().method_14("pard");
				}
			}
			else
			{
				method_10().method_14("pard");
			}
			method_10().method_14("plain");
			if (xtextParagraphFlagElement_0.RTFListOverriedID >= 0)
			{
				method_10().method_14("ls" + xtextParagraphFlagElement_0.RTFListOverriedID);
			}
			int num2 = xtextParagraphFlagElement_0.RTFOutlineLevel;
			if (num2 < 0)
			{
				num2 = runtimeDocumentContentStyle_1.ParagraphOutlineLevel;
			}
			if (num2 >= 0)
			{
				method_10().method_14("outlinelevel" + num2);
				if (runtimeDocumentContentStyle_1.ParagraphMultiLevel)
				{
					method_10().method_14("ilvl" + Convert.ToString(num2));
				}
			}
			method_36(runtimeDocumentContentStyle_1, bool_5: true);
			if (runtimeDocumentContentStyle_1.Align == DocumentContentAlignment.Left)
			{
				method_10().method_14("ql");
			}
			if (runtimeDocumentContentStyle_1.Align == DocumentContentAlignment.Center)
			{
				method_10().method_14("qc");
			}
			else if (runtimeDocumentContentStyle_1.Align == DocumentContentAlignment.Right)
			{
				method_10().method_14("qr");
			}
			else if (runtimeDocumentContentStyle_1.Align == DocumentContentAlignment.Justify)
			{
				method_10().method_14("qj");
			}
			else if (runtimeDocumentContentStyle_1.Align == DocumentContentAlignment.Distribute)
			{
				method_10().method_14("qd");
			}
			if (runtimeDocumentContentStyle_1.FirstLineIndent != 0f)
			{
				method_10().method_14("fi" + method_20(runtimeDocumentContentStyle_1.FirstLineIndent));
			}
			else
			{
				method_10().method_14("fi0");
			}
			if (runtimeDocumentContentStyle_1.LeftIndent != 0f)
			{
				method_10().method_14("li" + method_20(runtimeDocumentContentStyle_1.LeftIndent));
			}
			else
			{
				method_10().method_14("li0");
			}
			if ((double)runtimeDocumentContentStyle_1.SpacingBeforeParagraph > 0.1)
			{
				method_28("sb" + method_20(runtimeDocumentContentStyle_1.SpacingBeforeParagraph));
			}
			if ((double)runtimeDocumentContentStyle_1.SpacingAfterParagraph > 0.1)
			{
				method_28("sa" + method_20(runtimeDocumentContentStyle_1.SpacingAfterParagraph));
			}
			switch (runtimeDocumentContentStyle_1.LineSpacingStyle)
			{
			case LineSpacingStyle.SpaceSingle:
				method_28("slmult0");
				break;
			case LineSpacingStyle.Space1pt5:
				method_28("slmult1");
				method_28("sl" + Convert.ToInt32(360.0));
				break;
			case LineSpacingStyle.SpaceDouble:
				method_28("slmult1");
				method_28("sl" + Convert.ToInt32(480));
				break;
			case LineSpacingStyle.SpaceSpecify:
				method_28("sl" + method_20(runtimeDocumentContentStyle_1.LineSpacing));
				break;
			case LineSpacingStyle.SpaceMultiple:
				method_28("slmult1");
				method_28("sl" + Convert.ToInt32(240f * runtimeDocumentContentStyle_1.LineSpacing));
				break;
			}
			runtimeDocumentContentStyle_0 = runtimeDocumentContentStyle_1;
		}

		private void method_36(RuntimeDocumentContentStyle runtimeDocumentContentStyle_1, bool bool_5)
		{
			int num = 10;
			if (runtimeDocumentContentStyle_1.BorderWidth <= 0f || (!runtimeDocumentContentStyle_1.BorderLeft && !runtimeDocumentContentStyle_1.BorderTop && !runtimeDocumentContentStyle_1.BorderRight && !runtimeDocumentContentStyle_1.BorderBottom))
			{
				return;
			}
			method_10().method_14("brdrcf" + Convert.ToString(method_10().method_8().method_6(runtimeDocumentContentStyle_1.BorderColor) + 1));
			if (bool_5)
			{
				if (runtimeDocumentContentStyle_1.BorderLeft)
				{
					method_10().method_14("brdrl");
				}
				if (runtimeDocumentContentStyle_1.BorderTop)
				{
					method_10().method_14("brdrt");
				}
				if (runtimeDocumentContentStyle_1.BorderRight)
				{
					method_10().method_14("brdrr");
				}
				if (runtimeDocumentContentStyle_1.BorderBottom)
				{
					method_10().method_14("brdrb");
				}
				if (runtimeDocumentContentStyle_1.BorderSpacing > 0f)
				{
					method_10().method_14("brsp" + method_20(runtimeDocumentContentStyle_1.BorderSpacing));
				}
			}
			else if (runtimeDocumentContentStyle_1.BorderLeft || runtimeDocumentContentStyle_1.BorderTop || runtimeDocumentContentStyle_1.BorderRight || runtimeDocumentContentStyle_1.BorderBottom)
			{
				method_10().method_14("chbrdr");
			}
			switch (runtimeDocumentContentStyle_1.BorderStyle)
			{
			case DashStyle.Dash:
				method_10().method_14("brdrdash");
				break;
			case DashStyle.Dot:
				method_10().method_14("brdrdot");
				break;
			case DashStyle.DashDot:
				method_10().method_14("brdrdashd");
				break;
			case DashStyle.DashDotDot:
				method_10().method_14("brdrdashdd");
				break;
			}
			if (runtimeDocumentContentStyle_1.BorderWidth == 1f)
			{
				method_10().method_14("brdrs");
			}
			else
			{
				method_10().method_14("brdrth");
			}
		}

		public void method_37()
		{
		}

		public void method_38(string string_1)
		{
			method_10().method_12();
			method_10().method_14("field");
			method_10().method_12();
			method_10().method_0().method_14("fldinst", bool_1: true);
			method_10().method_12();
			method_10().method_14("hich");
			method_10().method_31(" HYPERLINK \"" + string_1 + "\"");
			method_10().method_13();
			method_10().method_13();
			method_10().method_12();
			method_10().method_14("fldrslt");
			method_10().method_12();
		}

		public void method_39()
		{
			method_10().method_13();
			method_10().method_13();
			method_10().method_13();
		}

		public void method_40(string string_1, RuntimeDocumentContentStyle runtimeDocumentContentStyle_1)
		{
			int num = 4;
			method_10().method_14("plain");
			int num2 = 0;
			string fontName = runtimeDocumentContentStyle_1.FontName;
			num2 = method_10().method_3().method_8(fontName);
			if (num2 >= 0)
			{
				method_10().method_14("f" + num2);
			}
			if (runtimeDocumentContentStyle_1.Bold)
			{
				method_10().method_14("b");
			}
			if (runtimeDocumentContentStyle_1.Italic)
			{
				method_10().method_14("i");
			}
			if (runtimeDocumentContentStyle_1.Underline)
			{
				method_10().method_14("ul");
			}
			if (runtimeDocumentContentStyle_1.Strikeout)
			{
				method_10().method_14("strike");
			}
			method_10().method_14("fs" + Convert.ToInt32(runtimeDocumentContentStyle_1.FontSize * 2f));
			num2 = method_10().method_8().method_6(runtimeDocumentContentStyle_1.BackgroundColor);
			if (num2 >= 0)
			{
				method_10().method_14("chcbpat" + Convert.ToString(num2 + 1));
			}
			Color color_ = runtimeDocumentContentStyle_1.PrintColor;
			if (color_.A == 0)
			{
				color_ = runtimeDocumentContentStyle_1.Color;
			}
			if (!runtimeDocumentContentStyle_1.ColorForRTF.IsEmpty)
			{
				color_ = runtimeDocumentContentStyle_1.ColorForRTF;
			}
			num2 = method_10().method_8().method_6(color_);
			if (num2 >= 0)
			{
				method_10().method_14("cf" + Convert.ToString(num2 + 1));
			}
			if (runtimeDocumentContentStyle_1.Subscript)
			{
				method_10().method_14("sub");
			}
			if (runtimeDocumentContentStyle_1.Superscript)
			{
				method_10().method_14("super");
			}
			method_10().method_31(string_1);
			if (runtimeDocumentContentStyle_1.Subscript)
			{
				method_10().method_14("sub0");
			}
			if (runtimeDocumentContentStyle_1.Superscript)
			{
				method_10().method_14("super0");
			}
			if (runtimeDocumentContentStyle_1.Bold)
			{
				method_10().method_14("b0");
			}
			if (runtimeDocumentContentStyle_1.Italic)
			{
				method_10().method_14("i0");
			}
			if (runtimeDocumentContentStyle_1.Underline)
			{
				method_10().method_14("ul0");
			}
			if (runtimeDocumentContentStyle_1.Strikeout)
			{
				method_10().method_14("strike0");
			}
			method_36(runtimeDocumentContentStyle_1, bool_5: false);
		}

		public void method_41()
		{
		}

		public void method_42(string string_1)
		{
			method_10().method_12();
			method_10().method_0().method_14("bkmkstart", bool_1: true);
			method_10().method_14("f0");
			method_10().method_31(string_1);
			method_10().method_13();
		}

		public void method_43(string string_1)
		{
			method_10().method_12();
			method_10().method_0().method_14("bkmkend", bool_1: true);
			method_10().method_14("f0");
			method_10().method_31(string_1);
			method_10().method_13();
		}

		public void method_44()
		{
			method_10().method_14("line");
		}

		public void method_45(Image image_0, int int_0, int int_1, byte[] byte_0, RuntimeDocumentContentStyle runtimeDocumentContentStyle_1)
		{
			int num = 3;
			if (byte_0 != null || image_0 != null)
			{
				if (byte_0 == null)
				{
					MemoryStream memoryStream = new MemoryStream();
					image_0.Save(memoryStream, ImageFormat.Jpeg);
					memoryStream.Close();
					byte_0 = memoryStream.ToArray();
				}
				method_10().method_12();
				method_10().method_14("pict");
				method_10().method_14("jpegblip");
				method_10().method_14("picscalex" + Convert.ToInt32((double)int_0 * 100.0 / (double)image_0.Size.Width));
				method_10().method_14("picscaley" + Convert.ToInt32((double)int_1 * 100.0 / (double)image_0.Size.Height));
				method_10().method_14("picwgoal" + Convert.ToString(image_0.Size.Width * 15));
				method_10().method_14("pichgoal" + Convert.ToString(image_0.Size.Height * 15));
				method_10().method_0().method_19(byte_0);
				method_10().method_13();
			}
		}

		public void method_46()
		{
			int num = 2;
			XTextDocument xTextDocument = method_4();
			method_29();
			method_32(xTextDocument);
			if (method_16())
			{
				XPageSettings pageSettings = xTextDocument.PageSettings;
				if (xTextDocument.PageSettings.RuntimeHeaderFooterDifferentFirstPage)
				{
					method_10().method_14("titlepg");
					if (pageSettings.HeaderDistance > 0 && xTextDocument.HeaderForFirstPage.HasContentElement)
					{
						method_10().method_23();
						method_6(new RectangleF(0f, 0f, xTextDocument.Width, xTextDocument.HeaderForFirstPage.Height));
						xTextDocument.HeaderForFirstPage.vmethod_19(this);
						method_10().method_24();
					}
					if ((pageSettings.FooterDistance > 0) & xTextDocument.FooterForFirstPage.HasContentElement)
					{
						method_10().method_26();
						method_6(new RectangleF(0f, 0f, xTextDocument.Width, xTextDocument.FooterForFirstPage.Height));
						xTextDocument.FooterForFirstPage.vmethod_19(this);
						method_10().method_27();
					}
				}
				if (pageSettings.HeaderDistance > 0 && xTextDocument.Header.HasContentElement)
				{
					method_10().method_22();
					method_6(new RectangleF(0f, 0f, xTextDocument.Width, xTextDocument.Header.Height));
					xTextDocument.Header.vmethod_19(this);
					method_10().method_24();
				}
				if ((pageSettings.FooterDistance > 0) & xTextDocument.Footer.HasContentElement)
				{
					method_10().method_25();
					method_6(new RectangleF(0f, 0f, xTextDocument.Width, xTextDocument.Footer.Height));
					xTextDocument.Footer.vmethod_19(this);
					method_10().method_27();
				}
			}
			foreach (XTextDocument item in method_2())
			{
				bool_4 = true;
				item.Body.vmethod_19(this);
			}
			method_34();
		}
	}
}
