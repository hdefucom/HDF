using DCSoft.Drawing;
using DCSoft.Printing;
using DCSoft.RTF;
using DCSoft.Writer;
using DCSoft.Writer.Dom;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DCSoftDotfuscate
{
	internal class Class122
	{
		private bool bool_0 = false;

		private string string_0 = Control.DefaultFont.Name;

		private bool bool_1 = true;

		private GClass386 gclass386_0 = new GClass386();

		private bool bool_2 = true;

		public bool method_0()
		{
			return bool_0;
		}

		public void method_1(bool bool_3)
		{
			bool_0 = bool_3;
		}

		public string method_2()
		{
			return string_0;
		}

		public void method_3(string string_1)
		{
			string_0 = string_1;
		}

		public bool method_4()
		{
			return bool_1;
		}

		public void method_5(bool bool_3)
		{
			bool_1 = bool_3;
		}

		public virtual bool vmethod_0(TextReader textReader_0)
		{
			gclass386_0.method_62(textReader_0);
			gclass386_0.method_65(gclass386_0);
			return true;
		}

		public virtual bool vmethod_1(string string_1)
		{
			gclass386_0.method_63(string_1);
			gclass386_0.method_65(gclass386_0);
			return true;
		}

		public void method_6(XTextDocument xtextDocument_0)
		{
			int num = 3;
			xtextDocument_0.Clear();
			if (method_4())
			{
				XPageSettings xPageSettings = new XPageSettings();
				xPageSettings.HeaderFooterDifferentFirstPage = gclass386_0.method_17();
				xPageSettings.Landscape = gclass386_0.method_48();
				xPageSettings.LeftMargin = GraphicsUnitConvert.FromTwips(gclass386_0.method_40(), GraphicsUnit.Document) / 3;
				xPageSettings.TopMargin = GraphicsUnitConvert.FromTwips(gclass386_0.method_42(), GraphicsUnit.Document) / 3;
				xPageSettings.RightMargin = GraphicsUnitConvert.FromTwips(gclass386_0.method_44(), GraphicsUnit.Document) / 3;
				xPageSettings.BottomMargin = GraphicsUnitConvert.FromTwips(gclass386_0.method_46(), GraphicsUnit.Document) / 3;
				int num2 = GraphicsUnitConvert.FromTwips(gclass386_0.method_36(), GraphicsUnit.Document) / 3;
				int num3 = GraphicsUnitConvert.FromTwips(gclass386_0.method_38(), GraphicsUnit.Document) / 3;
				xPageSettings.PaperKind = PaperKind.Custom;
				xPageSettings.PaperWidth = num2;
				xPageSettings.PaperHeight = num3;
				xPageSettings.SetPageSize(num2, num3, gclass386_0.method_48());
				xtextDocument_0.PageSettings = xPageSettings;
				xtextDocument_0.Info.Title = gclass386_0.method_32().method_2();
				xtextDocument_0.Info.Author = gclass386_0.method_32().method_6();
				if (gclass386_0.method_32().method_38() != DateTime.MinValue)
				{
					xtextDocument_0.Info.CreationTime = gclass386_0.method_32().method_38();
				}
				xtextDocument_0.Info.Description = gclass386_0.method_32().method_18();
				if (gclass386_0.method_32().method_42() != DateTime.MinValue)
				{
					xtextDocument_0.Info.LastPrintTime = gclass386_0.method_32().method_42();
				}
				if (gclass386_0.method_32().method_40() != DateTime.MinValue)
				{
					xtextDocument_0.Info.LastModifiedTime = gclass386_0.method_32().method_40();
				}
				xtextDocument_0.Info.EditMinute = gclass386_0.method_32().method_24();
			}
			xtextDocument_0.Elements.Clear();
			xtextDocument_0.method_40(DomReadyStates.Loading);
			method_11(gclass386_0, xtextDocument_0, xtextDocument_0.Elements, new GClass425());
			xtextDocument_0.method_40(DomReadyStates.Loaded);
			xtextDocument_0.AfterLoad(new ElementLoadEventArgs(xtextDocument_0, "rtf"));
		}

		public XTextElementList method_7(XTextDocument xtextDocument_0)
		{
			XTextElementList xTextElementList = new XTextElementList();
			method_11(gclass386_0, xtextDocument_0, xTextElementList, new GClass425());
			return xTextElementList;
		}

		public void method_8(XTextDocument xtextDocument_0)
		{
			xtextDocument_0.Clear();
			method_6(xtextDocument_0);
		}

		public static DocumentContentStyle smethod_0(GClass425 gclass425_0, GraphicsUnit graphicsUnit_0, GClass386 gclass386_1)
		{
			int num = 6;
			if (gclass425_0 == null)
			{
				throw new ArgumentNullException("format");
			}
			DocumentContentStyle documentContentStyle = new DocumentContentStyle();
			if (gclass386_1.method_90() != null && gclass386_1.method_90().ContainsKey(gclass425_0.method_73()))
			{
				Dictionary<string, string> dictionary = gclass386_1.method_90()[gclass425_0.method_73()];
				if (dictionary != null && dictionary.ContainsKey("outlinelevel"))
				{
					string value = dictionary["outlinelevel"];
					if (!string.IsNullOrEmpty(value))
					{
						int num3 = documentContentStyle.TitleLevel = Convert.ToInt32(value);
					}
				}
			}
			if (gclass425_0.method_1() >= 0)
			{
				documentContentStyle.ParagraphMultiLevel = true;
				documentContentStyle.ParagraphOutlineLevel = gclass425_0.method_1();
			}
			if (gclass425_0.method_71() >= 0)
			{
				if (gclass425_0.method_71() != 4)
				{
				}
				GClass420 gClass = gclass386_1.method_30().method_0(gclass425_0.method_71());
				if (gClass != null)
				{
					GClass404 gClass2 = gclass386_1.method_28().method_0(gClass.method_0());
					if (gClass2 != null)
					{
						GClass405 gClass3 = gClass2.method_15(gclass425_0.method_1());
						if (gClass3 != null && gClass3.method_2() == LevelNumberType.No_number)
						{
							documentContentStyle.ParagraphListStyle = ParagraphListStyle.BulletedList;
						}
					}
				}
			}
			switch (gclass425_0.method_39())
			{
			case GEnum80.const_0:
				documentContentStyle.Align = DocumentContentAlignment.Left;
				break;
			case GEnum80.const_1:
				documentContentStyle.Align = DocumentContentAlignment.Center;
				break;
			case GEnum80.const_2:
				documentContentStyle.Align = DocumentContentAlignment.Right;
				break;
			case GEnum80.const_3:
				documentContentStyle.Align = DocumentContentAlignment.Justify;
				break;
			}
			documentContentStyle.BackgroundColor = gclass425_0.method_63();
			if (gclass425_0.method_63() == Color.White)
			{
				documentContentStyle.BackgroundColor = Color.Transparent;
			}
			documentContentStyle.Bold = gclass425_0.method_51();
			documentContentStyle.BorderTopColor = gclass425_0.method_11();
			documentContentStyle.BorderLeftColor = gclass425_0.method_11();
			documentContentStyle.BorderRightColor = gclass425_0.method_11();
			documentContentStyle.BorderBottomColor = gclass425_0.method_11();
			documentContentStyle.BorderStyle = gclass425_0.method_15();
			documentContentStyle.BorderLeft = gclass425_0.method_3();
			documentContentStyle.BorderTop = gclass425_0.method_5();
			documentContentStyle.BorderBottom = gclass425_0.method_9();
			documentContentStyle.BorderRight = gclass425_0.method_7();
			documentContentStyle.BorderWidth = gclass425_0.method_13();
			documentContentStyle.BorderSpacing = GraphicsUnitConvert.FromTwips(gclass425_0.method_19(), graphicsUnit_0);
			if (gclass425_0.method_3() || gclass425_0.method_5() || gclass425_0.method_7() || gclass425_0.method_9())
			{
				if (gclass425_0.method_17())
				{
					documentContentStyle.BorderWidth = 2f;
				}
				else
				{
					documentContentStyle.BorderWidth = 1f;
				}
			}
			documentContentStyle.FontName = gclass425_0.method_45();
			documentContentStyle.FontSize = gclass425_0.method_47();
			documentContentStyle.Italic = gclass425_0.method_53();
			documentContentStyle.LeftIndent = GraphicsUnitConvert.FromTwips(gclass425_0.method_27(), graphicsUnit_0);
			if (gclass425_0.method_31() == 0)
			{
				documentContentStyle.LineSpacingStyle = LineSpacingStyle.SpaceSingle;
			}
			else if (gclass425_0.method_31() < 0)
			{
				documentContentStyle.LineSpacingStyle = LineSpacingStyle.SpaceSpecify;
				documentContentStyle.LineSpacing = GraphicsUnitConvert.FromTwips(gclass425_0.method_31(), graphicsUnit_0);
			}
			else if (gclass425_0.method_33())
			{
				documentContentStyle.LineSpacingStyle = LineSpacingStyle.SpaceMultiple;
				documentContentStyle.LineSpacing = (float)gclass425_0.method_31() / 240f;
			}
			else
			{
				documentContentStyle.LineSpacingStyle = LineSpacingStyle.SpaceExactly;
			}
			documentContentStyle.Link = gclass425_0.method_65();
			if (gclass425_0.method_71() >= 0)
			{
				GClass420 gClass4 = gclass386_1.method_30().method_0(gclass425_0.method_71());
				if (gClass4 != null)
				{
					GClass404 gClass2 = gclass386_1.method_28().method_0(gClass4.method_0());
					if (gClass2 != null)
					{
						documentContentStyle.ParagraphListStyle = smethod_2(gClass2);
					}
				}
			}
			documentContentStyle.FirstLineIndent = GraphicsUnitConvert.FromTwips(gclass425_0.method_25(), graphicsUnit_0);
			documentContentStyle.Spacing = GraphicsUnitConvert.FromTwips(gclass425_0.method_29(), graphicsUnit_0);
			documentContentStyle.SpacingBeforeParagraph = GraphicsUnitConvert.FromTwips(gclass425_0.method_35(), graphicsUnit_0);
			documentContentStyle.SpacingAfterParagraph = GraphicsUnitConvert.FromTwips(gclass425_0.method_37(), graphicsUnit_0);
			documentContentStyle.Strikeout = gclass425_0.method_57();
			documentContentStyle.Subscript = gclass425_0.method_69();
			documentContentStyle.Superscript = gclass425_0.method_67();
			documentContentStyle.Color = gclass425_0.method_61();
			documentContentStyle.Underline = gclass425_0.method_55();
			return documentContentStyle;
		}

		internal static void smethod_1(GClass404 gclass404_0, DocumentContentStyle documentContentStyle_0)
		{
			int paragraphOutlineLevel = documentContentStyle_0.ParagraphOutlineLevel;
			GClass405 gClass = gclass404_0.method_14(paragraphOutlineLevel);
			gClass.method_11(GClass470.smethod_1(documentContentStyle_0.ParagraphListStyle));
			if (documentContentStyle_0.IsBulletedList)
			{
				gClass.method_3(LevelNumberType.Bullet);
				return;
			}
			if (documentContentStyle_0.ParagraphOutlineLevel >= 0)
			{
				int paragraphOutlineLevel2 = documentContentStyle_0.ParagraphOutlineLevel;
				StringBuilder stringBuilder = new StringBuilder();
				StringBuilder stringBuilder2 = new StringBuilder();
				for (int i = 0; i <= paragraphOutlineLevel2; i++)
				{
					stringBuilder.Append((char)i);
					stringBuilder.Append('.');
					stringBuilder2.Append((char)(1 + i * 2));
				}
				gClass.method_11(stringBuilder.ToString());
				gClass.method_13(stringBuilder2.ToString());
			}
			switch (documentContentStyle_0.ParagraphListStyle)
			{
			case ParagraphListStyle.BulletedList:
				gClass.method_3(LevelNumberType.Bullet);
				break;
			case ParagraphListStyle.ListNumberStyle:
				gClass.method_3(LevelNumberType.Arabic);
				break;
			case ParagraphListStyle.ListNumberStyleArabic1:
				gClass.method_3(LevelNumberType.Arabic_Abjad_style);
				break;
			case ParagraphListStyle.ListNumberStyleArabic2:
				gClass.method_3(LevelNumberType.Arabic_Alif_Ba_Tah);
				break;
			case ParagraphListStyle.ListNumberStyleLowercaseLetter:
				gClass.method_3(LevelNumberType.Lowercase_letter);
				break;
			case ParagraphListStyle.ListNumberStyleLowercaseRoman:
				gClass.method_3(LevelNumberType.Lowercase_Roman_numeral);
				break;
			default:
				gClass.method_3(LevelNumberType.Arabic);
				break;
			case ParagraphListStyle.ListNumberStyleSimpChinNum1:
				gClass.method_3(LevelNumberType.Chinese_numbering_2);
				break;
			case ParagraphListStyle.ListNumberStyleSimpChinNum2:
				gClass.method_3(LevelNumberType.Chinese_numbering_1);
				break;
			case ParagraphListStyle.ListNumberStyleTradChinNum1:
				gClass.method_3(LevelNumberType.Chinese_double_byte_numbering_2);
				break;
			case ParagraphListStyle.ListNumberStyleTradChinNum2:
				gClass.method_3(LevelNumberType.Chinese_double_byte_numbering_1);
				break;
			case ParagraphListStyle.ListNumberStyleUppercaseLetter:
				gClass.method_3(LevelNumberType.Uppercase_letter);
				break;
			case ParagraphListStyle.ListNumberStyleUppercaseRoman:
				gClass.method_3(LevelNumberType.Uppercase_Roman_numeral);
				break;
			case ParagraphListStyle.ListNumberStyleZodiac1:
				gClass.method_3(LevelNumberType.Chinese_Zodiac_numbering_1);
				break;
			case ParagraphListStyle.ListNumberStyleZodiac2:
				gClass.method_3(LevelNumberType.Chinese_Zodiac_numbering_2);
				break;
			}
		}

		internal static ParagraphListStyle smethod_2(GClass404 gclass404_0)
		{
			Dictionary<ParagraphListStyle, string> dictionary = GClass470.smethod_0();
			GClass405 gClass = gclass404_0.method_15(0);
			if (gClass == null)
			{
				return ParagraphListStyle.ListNumberStyle;
			}
			switch (gClass.method_2())
			{
			case LevelNumberType.Arabic:
				if (!string.IsNullOrEmpty(gClass.method_10()))
				{
					string b = gClass.method_10();
					if (dictionary[ParagraphListStyle.ListNumberStyleArabic1] == b)
					{
						return ParagraphListStyle.ListNumberStyleArabic1;
					}
					if (dictionary[ParagraphListStyle.ListNumberStyleArabic2] == b)
					{
						return ParagraphListStyle.ListNumberStyleArabic2;
					}
				}
				return ParagraphListStyle.ListNumberStyle;
			case LevelNumberType.Uppercase_Roman_numeral:
				return ParagraphListStyle.ListNumberStyleUppercaseRoman;
			case LevelNumberType.Lowercase_Roman_numeral:
				return ParagraphListStyle.ListNumberStyleLowercaseRoman;
			case LevelNumberType.Uppercase_letter:
				return ParagraphListStyle.ListNumberStyleUppercaseLetter;
			case LevelNumberType.Lowercase_letter:
				return ParagraphListStyle.ListNumberStyleLowercaseLetter;
			case LevelNumberType.No_number:
				return ParagraphListStyle.BulletedList;
			case LevelNumberType.Arabic_with_leading_zero:
				return ParagraphListStyle.ListNumberStyle;
			case LevelNumberType.Bullet:
			{
				string text = gClass.method_10();
				if (text.Length >= 0)
				{
					return GClass470.smethod_3(text[0]);
				}
				return ParagraphListStyle.BulletedList;
			}
			case LevelNumberType.Chinese_numbering_1:
				return ParagraphListStyle.ListNumberStyleSimpChinNum2;
			case LevelNumberType.Chinese_numbering_2:
				return ParagraphListStyle.ListNumberStyleSimpChinNum1;
			case LevelNumberType.Chinese_Zodiac_numbering_1:
				return ParagraphListStyle.ListNumberStyleZodiac1;
			case LevelNumberType.Chinese_Zodiac_numbering_2:
				return ParagraphListStyle.ListNumberStyleZodiac2;
			case LevelNumberType.Taiwanese_double_byte_numbering_1:
				return ParagraphListStyle.ListNumberStyleTradChinNum1;
			case LevelNumberType.Taiwanese_double_byte_numbering_2:
				return ParagraphListStyle.ListNumberStyleTradChinNum2;
			case LevelNumberType.Chinese_double_byte_numbering_1:
				return ParagraphListStyle.ListNumberStyleTradChinNum2;
			case LevelNumberType.Chinese_double_byte_numbering_2:
				return ParagraphListStyle.ListNumberStyleTradChinNum1;
			case LevelNumberType.Chinese_double_byte_numbering_3:
				return ParagraphListStyle.ListNumberStyleSimpChinNum1;
			case LevelNumberType.Chinese_double_byte_numbering_4:
				return ParagraphListStyle.ListNumberStyleTradChinNum1;
			case LevelNumberType.Arabic_Alif_Ba_Tah:
				return ParagraphListStyle.ListNumberStyleArabic2;
			default:
				gClass.method_2();
				return ParagraphListStyle.ListNumberStyle;
			case LevelNumberType.Arabic_Abjad_style:
				return ParagraphListStyle.ListNumberStyleArabic1;
			}
		}

		public bool method_9()
		{
			return bool_2;
		}

		public void method_10(bool bool_3)
		{
			bool_2 = bool_3;
		}

		private void method_11(GClass383 gclass383_0, XTextDocument xtextDocument_0, XTextElementList xtextElementList_0, GClass425 gclass425_0)
		{
			int num = 18;
			if (gclass425_0 == null)
			{
				gclass425_0 = new GClass425();
			}
			foreach (GClass383 item in gclass383_0.method_5())
			{
				if (item is GClass397)
				{
					GClass397 gClass2 = (GClass397)item;
					if (gClass2.method_19())
					{
						if (gClass2.method_17() == GEnum85.const_3)
						{
							XTextDocumentHeaderForFirstPageElement xTextDocumentHeaderForFirstPageElement = (XTextDocumentHeaderForFirstPageElement)xtextElementList_0.method_5(typeof(XTextDocumentHeaderForFirstPageElement));
							if (xTextDocumentHeaderForFirstPageElement == null)
							{
								xTextDocumentHeaderForFirstPageElement = new XTextDocumentHeaderForFirstPageElement();
								xtextElementList_0.Add(xTextDocumentHeaderForFirstPageElement);
							}
							xTextDocumentHeaderForFirstPageElement.Elements.Clear();
							xtextDocument_0.PageSettings.HeaderDistance = (int)(GraphicsUnitConvert.FromTwips((double)gclass386_0.method_50(), GraphicsUnit.Inch) * 100.0);
							method_11(item, xtextDocument_0, xTextDocumentHeaderForFirstPageElement.Elements, gclass425_0);
						}
						else
						{
							XTextDocumentHeaderElement xTextDocumentHeaderElement = (XTextDocumentHeaderElement)xtextElementList_0.method_5(typeof(XTextDocumentHeaderElement));
							if (xTextDocumentHeaderElement == null)
							{
								xTextDocumentHeaderElement = new XTextDocumentHeaderElement();
								xtextElementList_0.Add(xTextDocumentHeaderElement);
							}
							xTextDocumentHeaderElement.Elements.Clear();
							xtextDocument_0.PageSettings.HeaderDistance = (int)(GraphicsUnitConvert.FromTwips((double)gclass386_0.method_50(), GraphicsUnit.Inch) * 100.0);
							method_11(item, xtextDocument_0, xTextDocumentHeaderElement.Elements, gclass425_0);
						}
					}
				}
				else if (item is GClass398)
				{
					GClass398 gClass3 = (GClass398)item;
					if (gClass3.method_19())
					{
						if (gClass3.method_17() == GEnum85.const_3)
						{
							XTextDocumentFooterForFirstPageElement xTextDocumentFooterForFirstPageElement = (XTextDocumentFooterForFirstPageElement)xtextElementList_0.method_5(typeof(XTextDocumentFooterForFirstPageElement));
							if (xTextDocumentFooterForFirstPageElement == null)
							{
								xTextDocumentFooterForFirstPageElement = new XTextDocumentFooterForFirstPageElement();
								xtextElementList_0.Add(xTextDocumentFooterForFirstPageElement);
							}
							xTextDocumentFooterForFirstPageElement.Elements.Clear();
							xtextDocument_0.PageSettings.FooterDistance = (int)(GraphicsUnitConvert.FromTwips((double)gclass386_0.method_52(), GraphicsUnit.Inch) * 100.0);
							method_11(item, xtextDocument_0, xTextDocumentFooterForFirstPageElement.Elements, gclass425_0);
						}
						else
						{
							XTextDocumentFooterElement xTextDocumentFooterElement = (XTextDocumentFooterElement)xtextElementList_0.method_5(typeof(XTextDocumentFooterElement));
							if (xTextDocumentFooterElement == null)
							{
								xTextDocumentFooterElement = new XTextDocumentFooterElement();
								xtextElementList_0.Add(xTextDocumentFooterElement);
							}
							xTextDocumentFooterElement.Elements.Clear();
							xtextDocument_0.PageSettings.FooterDistance = (int)(GraphicsUnitConvert.FromTwips((double)gclass386_0.method_52(), GraphicsUnit.Inch) * 100.0);
							method_11(item, xtextDocument_0, xTextDocumentFooterElement.Elements, gclass425_0);
						}
					}
				}
				else if (item is GClass388)
				{
					GClass388 gClass4 = (GClass388)item;
					DocumentContentStyle style = smethod_0(gClass4.method_21(), xtextDocument_0.DocumentGraphicsUnit, gclass386_0);
					method_11(item, xtextDocument_0, xtextElementList_0, gClass4.method_21());
					if (!gClass4.method_19() || method_9())
					{
						XTextParagraphFlagElement xTextParagraphFlagElement = new XTextParagraphFlagElement();
						xTextParagraphFlagElement.StyleIndex = xtextDocument_0.ContentStyles.GetStyleIndex(style);
						xtextElementList_0.Add(xTextParagraphFlagElement);
					}
				}
				else if (item is GClass393)
				{
					GClass393 gClass5 = (GClass393)item;
					if (!gClass5.method_17().method_59() && gClass5.method_19() != null && gClass5.method_19().Length > 0)
					{
						if (gclass425_0 != null && gclass425_0.method_73() >= 0 && gClass5.method_17() != null)
						{
							gClass5.method_17().method_74(gclass425_0.method_73());
						}
						DocumentContentStyle style = smethod_0(gClass5.method_17(), xtextDocument_0.DocumentGraphicsUnit, gclass386_0);
						string text = gClass5.method_19();
						if (text.Length > 1 && (text[0] == '○' || text[0] == '□' || text[0] == '△' || text[0] == '◇'))
						{
							bool flag = false;
							int num2 = gclass383_0.method_5().method_4(gClass5);
							if (num2 < gclass383_0.method_5().Count - 1)
							{
								GClass383 gClass6 = gclass383_0.method_5().method_0(num2 + 1);
								if (gClass6 is GClass394)
								{
									GClass394 gClass7 = (GClass394)gClass6;
									if (gClass7.method_19() != null && gClass7.method_19().IndexOf("eq \\o\\ac") >= 0)
									{
										flag = true;
									}
								}
							}
							if (flag)
							{
								if (text[0] == '○')
								{
									style.CharacterCircle = CharacterCircleStyles.Circle;
								}
								else if (text[0] == '□' || text[0] == '△' || text[0] == '◇')
								{
									style.CharacterCircle = CharacterCircleStyles.Rectangle;
								}
								text = text.Substring(1);
							}
						}
						int styleIndex = xtextDocument_0.ContentStyles.GetStyleIndex(style);
						xtextElementList_0.AddRange(xtextDocument_0.CreateChars(text, styleIndex));
					}
				}
				else if (item is GClass400)
				{
					GClass400 gClass8 = (GClass400)item;
					XTextImageElement xTextImageElement = new XTextImageElement();
					xTextImageElement.OwnerDocument = xtextDocument_0;
					xTextImageElement.Image = new XImageValue(gClass8.method_19());
					DocumentContentStyle style = smethod_0(gClass8.method_37(), xtextDocument_0.DocumentGraphicsUnit, gclass386_0);
					xTextImageElement.StyleIndex = xtextDocument_0.ContentStyles.GetStyleIndex(style);
					xTextImageElement.Width = GraphicsUnitConvert.FromTwips(gClass8.method_31(), xtextDocument_0.DocumentGraphicsUnit);
					xTextImageElement.Height = GraphicsUnitConvert.FromTwips(gClass8.method_33(), xtextDocument_0.DocumentGraphicsUnit);
					GClass383 gClass9 = gClass8.method_10();
					int num3 = 0;
					while (gClass9 != null && num3++ < 4)
					{
						if (gClass9 is GClass396)
						{
							GClass396 gClass10 = (GClass396)gClass9;
							xTextImageElement.Width = GraphicsUnitConvert.FromTwips(gClass10.method_21(), xtextDocument_0.DocumentGraphicsUnit);
							xTextImageElement.Height = GraphicsUnitConvert.FromTwips(gClass10.method_23(), xtextDocument_0.DocumentGraphicsUnit);
							break;
						}
						gClass9 = gClass9.method_10();
					}
					xtextElementList_0.Add(xTextImageElement);
				}
				else if (item is GClass389)
				{
					GClass389 gClass11 = (GClass389)item;
					if (gClass11.method_21() != null && gClass11.method_21().StartsWith("DCWriter.Object:"))
					{
						string typeName = gClass11.method_21().Substring("DCWriter.Object:".Length);
						Type type = Type.GetType(typeName, throwOnError: true, ignoreCase: true);
						if (type != null)
						{
							if (gClass11.method_23() != null && gClass11.method_23().Length > 0)
							{
								string @string = Encoding.UTF8.GetString(gClass11.method_23());
								StringReader textReader = new StringReader(@string);
								XmlSerializer xmlSerializer = Class109.smethod_7(type);
								XTextElement xTextElement = (XTextElement)xmlSerializer.Deserialize(textReader);
								if (xTextElement != null)
								{
									xTextElement.OwnerDocument = xtextDocument_0;
								}
								xtextElementList_0.Add(xTextElement);
							}
							else
							{
								XTextElement xTextElement = (XTextElement)Activator.CreateInstance(type);
								xTextElement.OwnerDocument = xtextDocument_0;
								xtextElementList_0.Add(xTextElement);
							}
						}
					}
					else
					{
						foreach (GClass383 item2 in item.method_5())
						{
							if (item2 is GClass399)
							{
								GClass399 gClass13 = (GClass399)item2;
								if (gClass13.Name == "result")
								{
									method_11(gClass13, xtextDocument_0, xtextElementList_0, gclass425_0.method_78());
									break;
								}
							}
						}
					}
				}
				else if (item is GClass394)
				{
					GClass394 gClass14 = (GClass394)item;
					if (gClass14.method_20() != null)
					{
						string a = gClass14.method_19();
						if (a == "PAGE")
						{
							XTextPageInfoElement xTextPageInfoElement = new XTextPageInfoElement();
							xTextPageInfoElement.ValueType = PageInfoValueType.PageIndex;
							xtextElementList_0.Add(xTextPageInfoElement);
						}
						else if (a == "NUMPAGES")
						{
							XTextPageInfoElement xTextPageInfoElement2 = new XTextPageInfoElement();
							xTextPageInfoElement2.ValueType = PageInfoValueType.NumOfPages;
							xtextElementList_0.Add(xTextPageInfoElement2);
						}
						else
						{
							method_11(gClass14.method_20(), xtextDocument_0, xtextElementList_0, gclass425_0.method_78());
						}
					}
				}
				else if (item is GClass391)
				{
					GClass391 gClass15 = (GClass391)item;
					if (gClass15.method_5().Count != 0 && gClass15.method_17().Count != 0)
					{
						XTextTableElement xTextTableElement = new XTextTableElement();
						xTextTableElement.CompressOwnerLineSpacing = true;
						xtextElementList_0.Add(xTextTableElement);
						float num4 = 0f;
						foreach (GClass387 item3 in gClass15.method_17())
						{
							XTextTableColumnElement xTextTableColumnElement = xTextTableElement.CreateColumnInstance();
							xTextTableColumnElement.Parent = xTextTableElement;
							xTextTableColumnElement.Width = GraphicsUnitConvert.FromTwips(item3.method_17(), xtextDocument_0.DocumentGraphicsUnit);
							num4 += xTextTableColumnElement.Width;
							xTextTableElement.Columns.Add(xTextTableColumnElement);
						}
						float viewClientWidth = xtextDocument_0.PageSettings.ViewClientWidth;
						if (num4 > viewClientWidth && (double)num4 < (double)viewClientWidth * 1.1)
						{
							float num5 = viewClientWidth / num4;
							foreach (XTextTableColumnElement column in xTextTableElement.Columns)
							{
								column.Width *= num5;
							}
						}
						foreach (GClass395 item4 in gClass15.method_5())
						{
							XTextTableRowElement xTextTableRowElement = xTextTableElement.CreateRowInstance();
							xTextTableRowElement.Height = GraphicsUnitConvert.FromTwips(item4.method_29(), xtextDocument_0.DocumentGraphicsUnit);
							DocumentContentStyle documentContentStyle = new DocumentContentStyle();
							documentContentStyle.BackgroundColor = item4.method_19().method_63();
							xTextTableRowElement.StyleIndex = xtextDocument_0.ContentStyles.GetStyleIndex(documentContentStyle);
							xTextTableElement.Rows.Add(xTextTableRowElement);
							foreach (GClass390 item5 in item4.method_5())
							{
								XTextTableCellElement xTextTableCellElement = xTextTableElement.CreateCellInstance();
								xTextTableRowElement.Cells.Add(xTextTableCellElement);
								xTextTableCellElement.RowSpan = item5.method_17();
								xTextTableCellElement.ColSpan = item5.method_19();
								DocumentContentStyle documentContentStyle2 = smethod_0(item5.method_35(), xtextDocument_0.DocumentGraphicsUnit, gclass386_0);
								documentContentStyle2.PaddingLeft = GraphicsUnitConvert.FromTwips(item5.method_23(), xtextDocument_0.DocumentGraphicsUnit);
								documentContentStyle2.PaddingTop = GraphicsUnitConvert.FromTwips(item5.method_26(), xtextDocument_0.DocumentGraphicsUnit);
								documentContentStyle2.PaddingRight = GraphicsUnitConvert.FromTwips(item5.method_29(), xtextDocument_0.DocumentGraphicsUnit);
								documentContentStyle2.PaddingBottom = GraphicsUnitConvert.FromTwips(item5.method_32(), xtextDocument_0.DocumentGraphicsUnit);
								if (item5.method_33() == GEnum83.const_0)
								{
									documentContentStyle2.VerticalAlign = VerticalAlignStyle.Top;
								}
								else if (item5.method_33() == GEnum83.const_1)
								{
									documentContentStyle2.VerticalAlign = VerticalAlignStyle.Middle;
								}
								else if (item5.method_33() == GEnum83.const_2)
								{
									documentContentStyle2.VerticalAlign = VerticalAlignStyle.Bottom;
								}
								xTextTableCellElement.StyleIndex = xtextDocument_0.ContentStyles.GetStyleIndex(documentContentStyle2);
								if (item5.method_45() == null)
								{
									method_11(item5, xtextDocument_0, xTextTableCellElement.Elements, item5.method_35());
								}
								xTextTableCellElement.FixElements();
							}
						}
						xTextTableElement.method_40();
						xTextTableElement.method_35();
						foreach (XTextTableCellElement cell in xTextTableElement.Cells)
						{
							if (cell.IsOverrided)
							{
								cell.StyleIndex = cell.OverrideCell.StyleIndex;
							}
						}
					}
				}
				else if (item is GClass396)
				{
					method_11(item, xtextDocument_0, xtextElementList_0, gclass425_0.method_78());
				}
				else if (item is GClass384)
				{
					method_11(item, xtextDocument_0, xtextElementList_0, gclass425_0.method_78());
				}
				else if (item is GClass392)
				{
					xtextElementList_0.Add(new XTextLineBreakElement());
				}
				else if (item is GClass385)
				{
					xtextElementList_0.Add(new XTextPageBreakElement());
				}
				else if (item.method_5() != null && item.method_5().Count > 0)
				{
					method_11(item, xtextDocument_0, xtextElementList_0, gclass425_0.method_78());
				}
			}
		}
	}
}
