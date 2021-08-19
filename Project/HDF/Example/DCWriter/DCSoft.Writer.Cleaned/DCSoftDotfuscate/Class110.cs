#define DEBUG
using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.HtmlDom;
using DCSoft.Writer;
using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Web;

namespace DCSoftDotfuscate
{
	internal class Class110
	{
		private XTextDocument xtextDocument_0 = null;

		private HTMLDocument htmldocument_0 = null;

		private Dictionary<string, GClass222> dictionary_0 = new Dictionary<string, GClass222>();

		private static Dictionary<string, Color> dictionary_1 = null;

		private static string[] string_0 = null;

		public XTextDocument method_0()
		{
			return xtextDocument_0;
		}

		public void method_1(XTextDocument xtextDocument_1)
		{
			xtextDocument_0 = xtextDocument_1;
		}

		public HTMLDocument method_2()
		{
			return htmldocument_0;
		}

		public void method_3(HTMLDocument htmldocument_1)
		{
			htmldocument_0 = htmldocument_1;
		}

		public void method_4(HTMLDocument htmldocument_1, XTextDocument xtextDocument_1)
		{
			method_1(xtextDocument_1);
			method_3(htmldocument_1);
			xtextDocument_1.method_56();
			xtextDocument_1.FileName = htmldocument_1.Location;
			xtextDocument_1.FileFormat = "html";
			xtextDocument_1.Info.Title = htmldocument_1.Title;
			dictionary_0 = new Dictionary<string, GClass222>();
			foreach (GClass212 allStyle in htmldocument_1.AllStyles)
			{
				foreach (GClass223 item in allStyle.method_46())
				{
					dictionary_0[item.Name] = item;
				}
			}
			xtextDocument_1.Body.Elements.Clear();
			method_5(htmldocument_1.Body, xtextDocument_1.Body, xtextDocument_1.DefaultStyle);
			xtextDocument_1.Body.FixElements();
			xtextDocument_1.method_110();
		}

		private void method_5(GClass163 gclass163_0, XTextElement xtextElement_0, DocumentContentStyle documentContentStyle_0)
		{
			int num = 7;
			if (gclass163_0.vmethod_2() != null)
			{
				foreach (GClass163 item in gclass163_0.vmethod_2())
				{
					if (!(item is GClass215) && !(item.method_9("dcignore") == "1"))
					{
						string text = item.method_43();
						switch (text)
						{
						case "div":
							if (item.method_9("dctype") == typeof(XTextSectionElement).Name)
							{
								XTextSectionElement xTextSectionElement = new XTextSectionElement();
								xTextSectionElement.OwnerDocument = xtextDocument_0;
								method_0().Body.Elements.Add(xTextSectionElement);
								method_6(item, xTextSectionElement);
								xTextSectionElement.ID = item.method_9("id");
								xTextSectionElement.Style = method_9(item, documentContentStyle_0);
								method_5(item, xTextSectionElement, documentContentStyle_0);
							}
							else
							{
								method_5(item, xtextElement_0, documentContentStyle_0);
								XTextElement xTextElement = method_0().CreateElementByType(typeof(XTextParagraphFlagElement));
								xTextElement.StyleIndex = method_0().ContentStyles.GetStyleIndex(documentContentStyle_0);
								xtextElement_0.Elements.Add(xTextElement);
							}
							break;
						case "ul":
						case "ol":
							foreach (GClass163 item2 in item.vmethod_2())
							{
								if (item2.method_43() == "li")
								{
									method_5(item2, xtextElement_0, documentContentStyle_0);
									XTextParagraphFlagElement xTextParagraphFlagElement = (XTextParagraphFlagElement)method_0().CreateElementByType(typeof(XTextParagraphFlagElement));
									DocumentContentStyle style = (DocumentContentStyle)documentContentStyle_0.Clone();
									if (text == "ul")
									{
										style.ParagraphListStyle = ParagraphListStyle.BulletedList;
									}
									else
									{
										style.ParagraphListStyle = ParagraphListStyle.ListNumberStyle;
									}
									xTextParagraphFlagElement.StyleIndex = method_0().ContentStyles.GetStyleIndex(style);
									xtextElement_0.Elements.Add(xTextParagraphFlagElement);
								}
							}
							break;
						case "pre":
						{
							DocumentContentStyle style = method_9(item, documentContentStyle_0);
							XTextElementList collection = method_0().CreateTextElements(item.InnerText, null, style.method_34());
							xtextElement_0.Elements.AddRange(collection);
							XTextElement xTextElement = method_0().CreateElementByType(typeof(XTextParagraphFlagElement));
							xTextElement.StyleIndex = method_0().ContentStyles.GetStyleIndex(documentContentStyle_0);
							xtextElement_0.Elements.Add(xTextElement);
							break;
						}
						case "input":
						{
							string text2 = item.method_9("type");
							if (text2 != null)
							{
								text2 = text2.Trim().ToLower();
							}
							if (text2 == "text")
							{
								DocumentContentStyle style = method_9(item, documentContentStyle_0);
								XTextInputFieldElement element = (XTextInputFieldElement)method_0().CreateElementByType(typeof(XTextInputFieldElement));
								element.ID = item.method_9("id");
								element.Name = item.method_9("name");
								element.StyleIndex = method_0().ContentStyles.GetStyleIndex(style);
								element.SetInnerTextFast(item.method_9("value"));
								element.ToolTip = item.method_9("title");
								element.SetInnerTextFast(item.method_9("value"));
								element.BackgroundText = element.Name;
								if (string.IsNullOrEmpty(element.BackgroundText))
								{
									element.BackgroundText = element.ID;
								}
								if (item.method_13("readonly"))
								{
									element.ContentReadonly = ContentReadonlyState.True;
								}
								else
								{
									element.ContentReadonly = ContentReadonlyState.False;
								}
								xtextElement_0.Elements.Add(element);
							}
							else if (text2 == "button" || text2 == "submit")
							{
								DocumentContentStyle style = method_9(item, documentContentStyle_0);
								XTextButtonElement xTextButtonElement = (XTextButtonElement)method_0().CreateElementByType(typeof(XTextButtonElement));
								xTextButtonElement.ID = item.method_9("id");
								xTextButtonElement.StyleIndex = method_0().ContentStyles.GetStyleIndex(style);
								xTextButtonElement.Text = item.method_9("value");
								xtextElement_0.Elements.Add(xTextButtonElement);
							}
							else if (text2 == "image")
							{
								XTextImageElement xTextImageElement = method_8(item, documentContentStyle_0);
								if (xTextImageElement != null)
								{
									xtextElement_0.Elements.Add(xTextImageElement);
								}
							}
							break;
						}
						case "textarea":
						{
							DocumentContentStyle style = method_9(item, documentContentStyle_0);
							XTextInputFieldElement element = (XTextInputFieldElement)method_0().CreateElementByType(typeof(XTextInputFieldElement));
							element.ID = item.method_9("id");
							element.StyleIndex = method_0().ContentStyles.GetStyleIndex(style);
							element.AcceptChildElementTypes2 |= ElementType.ParagraphFlag;
							element.SetInnerTextFast(item.InnerText);
							element.ToolTip = item.method_9("title");
							if (item.method_13("readonly"))
							{
								element.ContentReadonly = ContentReadonlyState.True;
							}
							else
							{
								element.ContentReadonly = ContentReadonlyState.False;
							}
							xtextElement_0.Elements.Add(element);
							break;
						}
						case "select":
						{
							DocumentContentStyle style = method_9(item, documentContentStyle_0);
							XTextInputFieldElement element = (XTextInputFieldElement)method_0().CreateElementByType(typeof(XTextInputFieldElement));
							element.ID = item.method_9("id");
							element.StyleIndex = method_0().ContentStyles.GetStyleIndex(style);
							element.ToolTip = item.method_9("title");
							element.UserEditable = false;
							element.EnsureHasListItemsInstance();
							element.FieldSettings.EditStyle = InputFieldEditStyle.DropdownList;
							foreach (GClass163 item3 in item.vmethod_2())
							{
								if (item3.method_43() == "option")
								{
									ListItem listItem = new ListItem();
									listItem.Text = item3.InnerText;
									if (item3.method_13("value"))
									{
										listItem.Value = item3.method_9("value");
									}
									else
									{
										listItem.Value = listItem.Text;
									}
									if (item3.method_13("selected"))
									{
										element.SetInnerTextFast(listItem.Text);
									}
									element.FieldSettings.ListSource.Items.Add(listItem);
								}
							}
							xtextElement_0.Elements.Add(element);
							break;
						}
						case "img":
						{
							XTextImageElement xTextImageElement = method_8(item, documentContentStyle_0);
							if (xTextImageElement != null)
							{
								xtextElement_0.Elements.Add(xTextImageElement);
							}
							break;
						}
						case "#text":
						{
							string text4 = StringFormatHelper.NormalizeSpace(item.vmethod_7());
							text4 = text4.Replace("&nbsp;", " ");
							text4 = text4.Replace("&ensp;", " ");
							text4 = HttpUtility.HtmlDecode(text4);
							if (!string.IsNullOrEmpty(text4))
							{
								XTextElementList xTextElementList = xtextDocument_0.CreateTextElements(text4, documentContentStyle_0, documentContentStyle_0.method_34());
								if (xTextElementList != null && xTextElementList.Count > 0)
								{
									xtextElement_0.Elements.AddRange(xTextElementList);
								}
							}
							break;
						}
						case "p":
						{
							DocumentContentStyle documentContentStyle7 = method_9(item, documentContentStyle_0);
							string text3 = item.method_9("align");
							if (!string.IsNullOrEmpty(text3))
							{
								switch (text3.Trim().ToLower())
								{
								case "justify":
									documentContentStyle7.Align = DocumentContentAlignment.Justify;
									break;
								case "right":
									documentContentStyle7.Align = DocumentContentAlignment.Right;
									break;
								case "center":
									documentContentStyle7.Align = DocumentContentAlignment.Center;
									break;
								case "left":
									documentContentStyle7.Align = DocumentContentAlignment.Left;
									break;
								default:
									documentContentStyle7.Align = DocumentContentAlignment.Left;
									break;
								}
							}
							method_5(item, xtextElement_0, documentContentStyle7);
							XTextParagraphFlagElement xTextParagraphFlagElement = (XTextParagraphFlagElement)xtextDocument_0.CreateElementByType(typeof(XTextParagraphFlagElement));
							xTextParagraphFlagElement.StyleIndex = xtextDocument_0.ContentStyles.GetStyleIndex(documentContentStyle7);
							xtextElement_0.Elements.Add(xTextParagraphFlagElement);
							break;
						}
						case "br":
						{
							XTextLineBreakElement element2 = (XTextLineBreakElement)xtextDocument_0.CreateElementByType(typeof(XTextLineBreakElement));
							xtextElement_0.Elements.Add(element2);
							break;
						}
						case "sup":
						{
							DocumentContentStyle documentContentStyle6 = (DocumentContentStyle)documentContentStyle_0.Clone();
							documentContentStyle6.Superscript = true;
							method_5(item, xtextElement_0, documentContentStyle6);
							break;
						}
						case "sub":
						{
							DocumentContentStyle documentContentStyle6 = (DocumentContentStyle)documentContentStyle_0.Clone();
							documentContentStyle6.Subscript = true;
							method_5(item, xtextElement_0, documentContentStyle6);
							break;
						}
						case "strong":
						case "b":
						{
							DocumentContentStyle documentContentStyle6 = (DocumentContentStyle)documentContentStyle_0.Clone();
							documentContentStyle6.Bold = true;
							method_5(item, xtextElement_0, documentContentStyle6);
							break;
						}
						case "i":
						{
							DocumentContentStyle documentContentStyle6 = (DocumentContentStyle)documentContentStyle_0.Clone();
							documentContentStyle6.Italic = true;
							method_5(item, xtextElement_0, documentContentStyle6);
							break;
						}
						case "strike":
						{
							DocumentContentStyle documentContentStyle6 = (DocumentContentStyle)documentContentStyle_0.Clone();
							documentContentStyle6.Strikeout = true;
							method_5(item, xtextElement_0, documentContentStyle6);
							break;
						}
						case "a":
						{
							DocumentContentStyle documentContentStyle6 = (DocumentContentStyle)documentContentStyle_0.Clone();
							documentContentStyle6.Color = Color.Blue;
							method_5(item, xtextElement_0, documentContentStyle6);
							break;
						}
						case "font":
						{
							DocumentContentStyle documentContentStyle6 = method_9(item, documentContentStyle_0);
							if (item.method_13("color"))
							{
								documentContentStyle6.Color = method_20(item.method_9("color"), Color.Black);
							}
							if (item.method_13("face"))
							{
								documentContentStyle6.FontName = method_25(item.method_9("face"));
							}
							if (item.method_13("size"))
							{
								switch (method_21(item.method_9("size")))
								{
								case 1:
									documentContentStyle6.FontSize = 7f;
									break;
								case 2:
									documentContentStyle6.FontSize = 10f;
									break;
								case 3:
									documentContentStyle6.FontSize = 12f;
									break;
								case 4:
									documentContentStyle6.FontSize = 14f;
									break;
								case 5:
									documentContentStyle6.FontSize = 18f;
									break;
								case 6:
									documentContentStyle6.FontSize = 24f;
									break;
								case 7:
									documentContentStyle6.FontSize = 35f;
									break;
								}
							}
							method_5(item, xtextElement_0, documentContentStyle6);
							break;
						}
						case "h1":
						case "h2":
						case "h3":
						case "h4":
						case "h5":
						case "h6":
						{
							xtextElement_0.Elements.Add(method_0().CreateElementByType(typeof(XTextParagraphFlagElement)));
							float fontSize = 9f;
							switch (text)
							{
							case "h6":
								fontSize = 8f;
								break;
							case "h5":
								fontSize = 10f;
								break;
							case "h4":
								fontSize = 12f;
								break;
							case "h3":
								fontSize = 13f;
								break;
							case "h2":
								fontSize = 18f;
								break;
							case "h1":
								fontSize = 24f;
								break;
							}
							DocumentContentStyle documentContentStyle6 = method_9(item, documentContentStyle_0);
							if (!XDependencyObject.smethod_4(documentContentStyle6, "FontSize"))
							{
								documentContentStyle6.FontSize = fontSize;
							}
							method_5(item, xtextElement_0, documentContentStyle6);
							xtextElement_0.Elements.Add(method_0().CreateElementByType(typeof(XTextParagraphFlagElement)));
							break;
						}
						case "table":
						{
							new List<float>();
							DocumentContentStyle documentContentStyle = method_9(item, (DocumentContentStyle)documentContentStyle_0.Clone());
							documentContentStyle.BorderColor = Color.Black;
							documentContentStyle.BorderLeft = true;
							documentContentStyle.BorderTop = true;
							documentContentStyle.BorderRight = true;
							documentContentStyle.BorderBottom = true;
							if (item.method_8().method_2("border"))
							{
								documentContentStyle.BorderWidth = method_21(item.method_9("border"));
							}
							else
							{
								documentContentStyle.BorderWidth = 0f;
							}
							if (item.method_13("bgcolor"))
							{
								documentContentStyle.BackgroundColor = method_20(item.method_9("bgcolor"), Color.Transparent);
							}
							if (item.method_13("bordercolor"))
							{
								documentContentStyle.BorderColor = method_20(item.method_9("bordercolor"), Color.Black);
							}
							XTextTableElement xTextTableElement = (XTextTableElement)xtextDocument_0.CreateElementByType(typeof(XTextTableElement));
							xTextTableElement.OwnerDocument = method_0();
							xTextTableElement.CompressOwnerLineSpacing = true;
							xtextElement_0.Elements.Add(xTextTableElement);
							xTextTableElement.ID = item.method_9("id");
							method_6(item, xTextTableElement);
							GClass185 gClass3 = (GClass185)item;
							if (gClass3.method_73() != null && gClass3.method_73().Count > 0)
							{
								foreach (GClass163 item4 in gClass3.method_73())
								{
									XTextTableColumnElement xTextTableColumnElement = (XTextTableColumnElement)method_0().CreateElementByType(typeof(XTextTableColumnElement));
									DocumentContentStyle documentContentStyle2 = method_9(item4, documentContentStyle);
									if (documentContentStyle2.float_1 > 0f)
									{
										xTextTableColumnElement.Width = documentContentStyle2.float_1;
									}
									if (item4.method_13("width"))
									{
										xTextTableColumnElement.Width = method_24(item4.method_9("width"));
									}
									xTextTableElement.Columns.Add(xTextTableColumnElement);
									method_6(item4, xTextTableColumnElement);
								}
							}
							GClass163 gClass5 = item;
							foreach (GClass163 item5 in item.vmethod_2())
							{
								if (item5.method_43() == "tbody")
								{
									gClass5 = item5;
									break;
								}
							}
							foreach (GClass163 item6 in gClass5.vmethod_2())
							{
								if (item6.method_43() == "tr")
								{
									XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)xtextDocument_0.CreateElementByType(typeof(XTextTableRowElement));
									xTextTableElement.Rows.Add(xTextTableRowElement);
									method_6(item6, xTextTableRowElement);
									DocumentContentStyle documentContentStyle3 = method_9(item6, documentContentStyle);
									if (item6.method_13("bgcolor"))
									{
										documentContentStyle3.BackgroundColor = method_20(item6.method_9("bgcolor"), Color.Transparent);
									}
									foreach (GClass163 item7 in item6.vmethod_2())
									{
										if (item7.TagName.ToLower() == "td")
										{
											DocumentContentStyle documentContentStyle4 = method_9(item7, documentContentStyle3);
											if (!XDependencyObject.smethod_4(documentContentStyle4, "VerticalAlign"))
											{
												documentContentStyle4.VerticalAlign = VerticalAlignStyle.Middle;
											}
											XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)method_0().CreateElementByType(typeof(XTextTableCellElement));
											method_6(item7, xTextTableCellElement);
											if (documentContentStyle4.float_1 >= 0f)
											{
												xTextTableCellElement.Width = documentContentStyle4.float_1;
											}
											if (documentContentStyle4.float_2 >= 0f)
											{
												xTextTableCellElement.Height = documentContentStyle4.float_2;
											}
											xTextTableCellElement.StyleIndex = xtextDocument_0.ContentStyles.GetStyleIndex(documentContentStyle4);
											if (item7.method_13("rowspan"))
											{
												xTextTableCellElement.method_61(method_21(item7.method_9("rowspan")));
											}
											if (item7.method_13("colspan"))
											{
												xTextTableCellElement.method_60(method_21(item7.method_9("colspan")));
											}
											if (item7.method_13("title"))
											{
												xTextTableCellElement.ToolTip = item7.method_9("title");
											}
											xTextTableRowElement.Cells.Add(xTextTableCellElement);
											DocumentContentStyle documentContentStyle5 = (DocumentContentStyle)documentContentStyle4.Clone();
											XDependencyObject.smethod_8(documentContentStyle5, "BorderLeft");
											XDependencyObject.smethod_8(documentContentStyle5, "BorderTop");
											XDependencyObject.smethod_8(documentContentStyle5, "BorderRight");
											XDependencyObject.smethod_8(documentContentStyle5, "BorderBottom");
											XDependencyObject.smethod_8(documentContentStyle5, "BorderColor");
											XDependencyObject.smethod_8(documentContentStyle5, "BorderStyle");
											XDependencyObject.smethod_8(documentContentStyle5, "BorderWidth");
											method_5(item7, xTextTableCellElement, documentContentStyle5);
										}
									}
								}
							}
							int num2 = 0;
							foreach (XTextTableRowElement row in xTextTableElement.Rows)
							{
								int num3 = 0;
								foreach (XTextTableCellElement cell in row.Cells)
								{
									num3 += cell.ColSpan;
								}
								num2 = Math.Max(num2, num3);
							}
							XTextTableCellElement xTextTableCellElement2 = new XTextTableCellElement();
							XTextTableCellElement[,] array = new XTextTableCellElement[xTextTableElement.Rows.Count, num2];
							for (int i = 0; i < xTextTableElement.Rows.Count; i++)
							{
								XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)xTextTableElement.Rows[i];
								foreach (XTextTableCellElement cell2 in xTextTableRowElement.Cells)
								{
									int num4 = 0;
									for (int j = 0; j < num2; j++)
									{
										if (array[i, j] == null)
										{
											num4 = j;
											break;
										}
									}
									if (cell2.RowSpan == 1 && cell2.ColSpan == 1)
									{
										array[i, num4] = cell2;
									}
									else
									{
										for (int k = 0; k < cell2.ColSpan; k++)
										{
											for (int l = 0; l < cell2.RowSpan; l++)
											{
												if (k == 0 && l == 0)
												{
													array[i + l, num4 + k] = cell2;
												}
												else
												{
													if (i + l >= xTextTableElement.Rows.Count)
													{
														break;
													}
													if (array[i + l, num4 + k] == null)
													{
														array[i + l, num4 + k] = xTextTableCellElement2;
													}
												}
											}
										}
									}
								}
							}
							for (int i = 0; i < xTextTableElement.Rows.Count; i++)
							{
								XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)xTextTableElement.Rows[i];
								xTextTableRowElement.Cells.Clear();
								int styleIndex = -1;
								for (int num4 = 0; num4 < num2; num4++)
								{
									if (array[i, num4] == null || array[i, num4] == xTextTableCellElement2)
									{
										XTextTableCellElement xTextTableCellElement3 = (XTextTableCellElement)method_0().CreateElementByType(typeof(XTextTableCellElement));
										xTextTableCellElement3.StyleIndex = styleIndex;
										xTextTableRowElement.Cells.Add(xTextTableCellElement3);
									}
									else
									{
										styleIndex = array[i, num4].StyleIndex;
										xTextTableRowElement.Cells.Add(array[i, num4]);
									}
								}
							}
							float width = 50f;
							if (xTextTableElement.Columns.Count == 0)
							{
								width = (method_0().Body.ClientWidth - 10f) / (float)num2;
							}
							for (int j = xTextTableElement.Columns.Count; j < num2; j++)
							{
								XTextTableColumnElement xTextTableColumnElement = (XTextTableColumnElement)method_0().CreateElementByType(typeof(XTextTableColumnElement));
								xTextTableColumnElement.Width = width;
								xTextTableElement.Columns.Add(xTextTableColumnElement);
							}
							for (int j = 0; j < xTextTableElement.Columns.Count; j++)
							{
								XTextTableColumnElement xTextTableColumnElement = (XTextTableColumnElement)xTextTableElement.Columns[j];
								if (xTextTableColumnElement.Width <= 10f)
								{
									foreach (XTextTableRowElement row2 in xTextTableElement.Rows)
									{
										if (row2.Cells.Count > j)
										{
											xTextTableColumnElement.Width = Math.Max(xTextTableColumnElement.Width, row2.Cells[j].Width);
										}
									}
								}
								xTextTableColumnElement.Width = Math.Max(xTextTableColumnElement.Width, 50f);
							}
							foreach (XTextTableCellElement cell3 in xTextTableElement.Cells)
							{
								cell3.Width = 0f;
								cell3.Height = 0f;
							}
							break;
						}
						case "span":
						{
							string a = item.method_9("dctype");
							if (a == typeof(XTextInputFieldElement).Name)
							{
								XTextInputFieldElement element = method_7(item, documentContentStyle_0);
								xtextElement_0.Elements.Add(element);
							}
							else if (a == typeof(XTextLabelElement).Name)
							{
								XTextLabelElement xTextLabelElement = new XTextLabelElement();
								xTextLabelElement.OwnerDocument = method_0();
								xtextElement_0.Elements.Add(xTextLabelElement);
								method_6(item, xTextLabelElement);
								xTextLabelElement.ID = item.method_9("id");
								xTextLabelElement.Name = item.method_9("name");
								xTextLabelElement.Text = item.InnerText;
								xTextLabelElement.Style = method_9(item, documentContentStyle_0);
							}
							else
							{
								DocumentContentStyle documentContentStyle_ = method_9(item, documentContentStyle_0);
								method_5(item, xtextElement_0, documentContentStyle_);
							}
							break;
						}
						default:
						{
							DocumentContentStyle documentContentStyle_ = method_9(item, documentContentStyle_0);
							method_5(item, xtextElement_0, documentContentStyle_);
							break;
						}
						}
					}
				}
			}
		}

		public int method_6(GClass163 gclass163_0, object object_0)
		{
			int num = 19;
			if (object_0 == null)
			{
				throw new ArgumentNullException("instance");
			}
			int num2 = 0;
			PropertyInfo[] properties = object_0.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
			foreach (PropertyInfo propertyInfo in properties)
			{
				GClass229 gClass = gclass163_0.method_8().method_1("dc_" + propertyInfo.Name.ToLower());
				if (gClass == null || string.IsNullOrEmpty(gClass.string_1))
				{
					continue;
				}
				string text = HttpUtility.HtmlDecode(gClass.string_1);
				if (propertyInfo.CanWrite)
				{
					Type propertyType = propertyInfo.PropertyType;
					object obj = null;
					if (propertyType.Equals(typeof(Color)))
					{
						obj = ColorTranslator.FromHtml(text);
					}
					else if (propertyType.Equals(typeof(DateTime)))
					{
						obj = DateTime.Parse(text);
					}
					else if (typeof(IDCStringSerializable).IsAssignableFrom(propertyType))
					{
						IDCStringSerializable iDCStringSerializable = (IDCStringSerializable)Activator.CreateInstance(propertyType);
						iDCStringSerializable.DCReadString(text);
						obj = iDCStringSerializable;
					}
					else if (propertyType.IsEnum)
					{
						obj = Enum.Parse(propertyType, text);
					}
					else if (!(((HtmlAttributeAttribute)Attribute.GetCustomAttribute(propertyInfo, typeof(HtmlAttributeAttribute), inherit: true))?.AutoUseAttributeString ?? false))
					{
						obj = Convert.ChangeType(text, propertyType);
					}
					else
					{
						obj = Activator.CreateInstance(propertyType);
						ValueTypeHelper.SetPropertiesAttributeString(obj, text);
					}
					propertyInfo.SetValue(object_0, obj, null);
					num2++;
				}
			}
			return num2;
		}

		private XTextInputFieldElement method_7(GClass163 gclass163_0, DocumentContentStyle documentContentStyle_0)
		{
			int num = 0;
			XTextInputFieldElement xTextInputFieldElement = new XTextInputFieldElement();
			xTextInputFieldElement.OwnerDocument = method_0();
			method_6(gclass163_0, xTextInputFieldElement);
			xTextInputFieldElement.ID = gclass163_0.method_9("id");
			xTextInputFieldElement.Name = gclass163_0.method_9("name");
			xTextInputFieldElement.StyleIndex = xtextDocument_0.ContentStyles.GetStyleIndex(documentContentStyle_0);
			if (gclass163_0.method_13("listitemcount"))
			{
				int num2 = Convert.ToInt32(gclass163_0.method_9("listitemcount"));
				xTextInputFieldElement.EnsureHasListItemsInstance();
				xTextInputFieldElement.FieldSettings.EditStyle = InputFieldEditStyle.DropdownList;
				for (int i = 0; i < num2; i++)
				{
					ListItem listItem = new ListItem();
					listItem.Text = gclass163_0.method_9("listtext" + i);
					listItem.Value = gclass163_0.method_9("listvalue" + i);
					listItem.TextInList = gclass163_0.method_9("listtextinlist" + i);
					if (!string.IsNullOrEmpty(listItem.Text) || !string.IsNullOrEmpty(listItem.Value) || !string.IsNullOrEmpty(listItem.TextInList))
					{
						xTextInputFieldElement.FieldSettings.ListSource.Items.Add(listItem);
					}
				}
			}
			foreach (GClass163 item in gclass163_0.vmethod_2())
			{
				if (item.method_9("dcignore") != "1")
				{
					method_5(gclass163_0, xTextInputFieldElement, documentContentStyle_0);
				}
			}
			return xTextInputFieldElement;
		}

		private XTextImageElement method_8(GClass163 gclass163_0, DocumentContentStyle documentContentStyle_0)
		{
			int num = 4;
			DocumentContentStyle documentContentStyle = method_9(gclass163_0, documentContentStyle_0);
			documentContentStyle.BorderColor = Color.Black;
			documentContentStyle.BorderLeft = true;
			documentContentStyle.BorderTop = true;
			documentContentStyle.BorderRight = true;
			documentContentStyle.BorderBottom = true;
			documentContentStyle.BorderWidth = 0f;
			if (gclass163_0.method_13("border"))
			{
				documentContentStyle.BorderWidth = method_21(gclass163_0.method_9("border"));
			}
			XTextImageElement xTextImageElement = (XTextImageElement)method_0().CreateElementByType(typeof(XTextImageElement));
			method_6(gclass163_0, xTextImageElement);
			xTextImageElement.StyleIndex = method_0().ContentStyles.GetStyleIndex(documentContentStyle);
			if (gclass163_0.method_13("width"))
			{
				xTextImageElement.Width = method_24(gclass163_0.method_9("width"));
			}
			if (gclass163_0.method_13("height"))
			{
				xTextImageElement.Height = method_24(gclass163_0.method_9("height"));
			}
			if (gclass163_0.method_13("id"))
			{
				xTextImageElement.ID = gclass163_0.method_9("id");
			}
			if (gclass163_0.method_13("alt"))
			{
				xTextImageElement.Alt = gclass163_0.method_9("alt");
			}
			if (gclass163_0.method_13("title"))
			{
				xTextImageElement.Title = gclass163_0.method_9("title");
			}
			if (gclass163_0.method_13("src"))
			{
				XImageValue xImageValue = new XImageValue();
				string absoluteURL = method_2().GetAbsoluteURL(gclass163_0.method_9("src"));
				try
				{
					string text = string.Format(WriterStringsCore.Downloading_URL, absoluteURL);
					if (method_0().EditorControl != null)
					{
						method_0().EditorControl.SetStatusText(text);
					}
					if (method_0().Options.BehaviorOptions.DebugMode)
					{
						Debug.Write(text);
					}
					int num2 = 0;
					if (method_0().writerReadFileContentEventHandler_0 != null)
					{
						WriterReadFileContentEventArgs writerReadFileContentEventArgs = new WriterReadFileContentEventArgs(method_0().EditorControl, method_0(), xTextImageElement, absoluteURL, null);
						method_0().writerReadFileContentEventHandler_0(this, writerReadFileContentEventArgs);
						if (writerReadFileContentEventArgs.Cancel)
						{
							return xTextImageElement;
						}
						byte[] resultBinary = writerReadFileContentEventArgs.GetResultBinary();
						if (resultBinary != null && resultBinary.Length > 0)
						{
							num2 = resultBinary.Length;
							xImageValue.ImageData = resultBinary;
						}
					}
					if (num2 == 0)
					{
						num2 = xImageValue.Load(absoluteURL);
					}
					if (method_0().Options.BehaviorOptions.DebugMode)
					{
						Debug.WriteLine(WriterUtils.smethod_44(num2));
					}
				}
				catch (Exception ex)
				{
					xTextImageElement.Alt = absoluteURL + ":" + ex.Message;
					xTextImageElement.ImageData = null;
					if (method_0().Options.BehaviorOptions.DebugMode)
					{
						Debug.WriteLine(WriterStringsCore.Fail);
					}
				}
				if (method_0().EditorControl != null)
				{
					method_0().EditorControl.SetStatusText(null);
				}
				if (!xImageValue.HasContent)
				{
					xTextImageElement.Alt = absoluteURL;
					if (xTextImageElement.Width == 0f)
					{
						xTextImageElement.Width = 300f;
					}
					if (xTextImageElement.Height == 0f)
					{
						xTextImageElement.Height = 150f;
					}
				}
				xTextImageElement.Image = xImageValue;
			}
			if (xTextImageElement.Width == 0f || xTextImageElement.Height == 0f)
			{
				xTextImageElement.UpdateSize(keepSizePossible: false);
			}
			return xTextImageElement;
		}

		private DocumentContentStyle method_9(GClass163 gclass163_0, DocumentContentStyle documentContentStyle_0)
		{
			int num = 19;
			DocumentContentStyle documentContentStyle = (DocumentContentStyle)documentContentStyle_0.Clone();
			string key = "#" + gclass163_0.TagName;
			if (dictionary_0.ContainsKey(key))
			{
				method_10(dictionary_0[key], documentContentStyle);
			}
			string text = gclass163_0.method_35();
			if (!string.IsNullOrEmpty(text))
			{
				text = "." + text;
				if (dictionary_0.ContainsKey(text))
				{
					method_10(dictionary_0[text], documentContentStyle);
				}
			}
			text = gclass163_0.method_43() + "." + gclass163_0.method_35();
			if (!string.IsNullOrEmpty(text) && dictionary_0.ContainsKey(text))
			{
				method_10(dictionary_0[text], documentContentStyle);
			}
			string text2 = gclass163_0.method_9("style");
			if (!string.IsNullOrEmpty(text2))
			{
				GClass222 gClass = new GClass222();
				gClass.method_12(text2);
				method_10(gClass, documentContentStyle);
			}
			return documentContentStyle;
		}

		private void method_10(GClass222 gclass222_0, DocumentContentStyle documentContentStyle_0)
		{
			foreach (GClass229 item in gclass222_0.method_3())
			{
				string string_ = item.string_0.Trim().ToLower();
				string string_2 = item.string_1;
				method_11(documentContentStyle_0, string_, string_2);
			}
		}

		private void method_11(DocumentContentStyle documentContentStyle_0, string string_1, string string_2)
		{
			int num = 6;
			switch (string_1)
			{
			case "line-height":
				break;
			case "width":
			{
				float float_ = 0f;
				if (method_16(string_2, out float_))
				{
					documentContentStyle_0.float_1 = float_;
				}
				break;
			}
			case "height":
			{
				float float_ = 0f;
				if (method_16(string_2, out float_))
				{
					documentContentStyle_0.float_2 = float_;
				}
				break;
			}
			case "background":
			{
				string[] array = method_14(string_2);
				if (array == null)
				{
					break;
				}
				string[] array3 = array;
				foreach (string text2 in array3)
				{
					Color color_ = Color.Empty;
					string text4 = method_15(text2);
					if (text4 != null)
					{
						text4 = method_2().GetAbsoluteURL(text4);
						XImageValue xImageValue = new XImageValue();
						if (xImageValue.Load(text4) <= 0)
						{
							documentContentStyle_0.BackgroundImage = xImageValue;
						}
					}
					else if (method_19(text2, out color_))
					{
						documentContentStyle_0.BackgroundColor = color_;
					}
					else if (string.Equals(text2, "repeat", StringComparison.CurrentCultureIgnoreCase))
					{
						documentContentStyle_0.BackgroundRepeat = true;
					}
					else if (string.Equals(text2, "no-repeat", StringComparison.CurrentCultureIgnoreCase))
					{
						documentContentStyle_0.BackgroundRepeat = false;
					}
				}
				break;
			}
			case "background-color":
			{
				Color color_ = Color.Empty;
				if (method_19(string_2, out color_))
				{
					documentContentStyle_0.BackgroundColor = color_;
				}
				break;
			}
			case "background-repeat":
			{
				string a = method_12(string_2);
				if (string.Equals(a, "repeat", StringComparison.CurrentCultureIgnoreCase))
				{
					documentContentStyle_0.BackgroundRepeat = true;
				}
				else if (string.Equals(a, "no-repeat", StringComparison.CurrentCultureIgnoreCase))
				{
					documentContentStyle_0.BackgroundRepeat = false;
				}
				else
				{
					documentContentStyle_0.BackgroundRepeat = true;
				}
				break;
			}
			case "border":
			{
				string[] array = method_14(string_2);
				if (array == null)
				{
					break;
				}
				string[] array3 = array;
				int num2 = 0;
				while (true)
				{
					if (num2 >= array3.Length)
					{
						return;
					}
					string text2 = array3[num2];
					DashStyle dashStyle_ = DashStyle.Custom;
					Color color_ = Color.Empty;
					float float_3 = 0f;
					if (method_18(text2, out dashStyle_))
					{
						documentContentStyle_0.BorderStyle = dashStyle_;
						if (dashStyle_ == DashStyle.Custom)
						{
							break;
						}
					}
					else if (method_19(text2, out color_))
					{
						documentContentStyle_0.BorderColor = color_;
					}
					else if (method_17(text2, ref float_3))
					{
						documentContentStyle_0.BorderWidth = float_3;
					}
					num2++;
				}
				documentContentStyle_0.BorderStyle = DashStyle.Solid;
				documentContentStyle_0.BorderWidth = 0f;
				break;
			}
			case "border-color":
			{
				Color color_ = Color.Empty;
				if (method_19(string_2, out color_))
				{
					documentContentStyle_0.BorderColor = color_;
				}
				break;
			}
			case "border-width":
			{
				float float_3 = 0f;
				if (method_17(string_2, ref float_3))
				{
					documentContentStyle_0.BorderWidth = float_3;
				}
				break;
			}
			case "border-style":
			{
				DashStyle dashStyle_2 = DashStyle.Solid;
				if (method_18(string_2, out dashStyle_2))
				{
					documentContentStyle_0.BorderStyle = dashStyle_2;
					if (dashStyle_2 == DashStyle.Custom)
					{
						documentContentStyle_0.BorderStyle = DashStyle.Solid;
						documentContentStyle_0.BorderWidth = 0f;
					}
				}
				break;
			}
			case "color":
			{
				Color color_ = Color.Empty;
				if (method_19(string_2, out color_))
				{
					documentContentStyle_0.Color = color_;
				}
				break;
			}
			case "font":
			{
				string[] array = method_14(string_2);
				if (array == null)
				{
					break;
				}
				foreach (string text2 in array)
				{
					float float_2 = 0f;
					if (string.Equals(text2, "italic", StringComparison.CurrentCultureIgnoreCase))
					{
						documentContentStyle_0.Italic = true;
						continue;
					}
					if (string.Equals(text2, "oblique", StringComparison.CurrentCultureIgnoreCase))
					{
						documentContentStyle_0.Italic = true;
						continue;
					}
					if (string.Equals(text2, "bold", StringComparison.CurrentCultureIgnoreCase))
					{
						documentContentStyle_0.Bold = true;
						continue;
					}
					if (string.Equals(text2, "bolder", StringComparison.CurrentCultureIgnoreCase))
					{
						documentContentStyle_0.Bold = true;
						continue;
					}
					if (method_16(text2, out float_2))
					{
						documentContentStyle_0.FontSize = GraphicsUnitConvert.Convert(float_2, method_0().DocumentGraphicsUnit, GraphicsUnit.Point);
						continue;
					}
					string text3 = method_25(text2);
					if (text3 != null)
					{
						documentContentStyle_0.FontName = text3;
					}
				}
				break;
			}
			case "font-family":
			{
				string text = method_25(string_2);
				if (text != null)
				{
					documentContentStyle_0.FontName = text;
				}
				break;
			}
			case "font-size":
			{
				float float_2 = 0f;
				if (method_16(string_2, out float_2))
				{
					documentContentStyle_0.FontSize = GraphicsUnitConvert.Convert(float_2, method_0().DocumentGraphicsUnit, GraphicsUnit.Point);
				}
				break;
			}
			case "font-style":
				if (method_13(string_2, "italic") || method_13(string_2, "oblique"))
				{
					documentContentStyle_0.Italic = true;
				}
				break;
			case "font-weight":
				if (method_13(string_2, "bold"))
				{
					documentContentStyle_0.Bold = true;
				}
				else if (method_13(string_2, "700"))
				{
					documentContentStyle_0.Bold = true;
				}
				break;
			case "text-align":
				if (method_13(string_2, "left"))
				{
					documentContentStyle_0.Align = DocumentContentAlignment.Left;
				}
				else if (method_13(string_2, "right"))
				{
					documentContentStyle_0.Align = DocumentContentAlignment.Right;
				}
				else if (method_13(string_2, "center"))
				{
					documentContentStyle_0.Align = DocumentContentAlignment.Center;
				}
				else if (method_13(string_2, "justify"))
				{
					documentContentStyle_0.Align = DocumentContentAlignment.Justify;
				}
				break;
			case "text-indent":
			{
				float float_ = 0f;
				if (method_16(string_2, out float_))
				{
					documentContentStyle_0.FirstLineIndent = float_;
				}
				break;
			}
			case "padding":
			{
				float[] array2 = method_23(string_2);
				if (array2 != null)
				{
					if (array2.Length >= 4)
					{
						documentContentStyle_0.PaddingTop = array2[0];
						documentContentStyle_0.PaddingRight = array2[1];
						documentContentStyle_0.PaddingBottom = array2[2];
						documentContentStyle_0.PaddingLeft = array2[3];
					}
					else if (array2.Length == 1)
					{
						documentContentStyle_0.PaddingLeft = array2[0];
						documentContentStyle_0.PaddingTop = array2[0];
						documentContentStyle_0.PaddingRight = array2[0];
						documentContentStyle_0.PaddingBottom = array2[0];
					}
					else if (array2.Length == 2)
					{
						documentContentStyle_0.PaddingTop = array2[0];
						documentContentStyle_0.PaddingBottom = array2[0];
						documentContentStyle_0.PaddingLeft = array2[1];
						documentContentStyle_0.PaddingRight = array2[1];
					}
					else if (array2.Length == 3)
					{
						documentContentStyle_0.PaddingTop = array2[0];
						documentContentStyle_0.PaddingRight = array2[1];
						documentContentStyle_0.PaddingLeft = array2[1];
						documentContentStyle_0.PaddingBottom = array2[2];
					}
				}
				break;
			}
			case "padding-left":
			{
				float float_ = 0f;
				if (method_16(string_2, out float_))
				{
					documentContentStyle_0.PaddingLeft = float_;
				}
				break;
			}
			case "padding-top":
			{
				float float_ = 0f;
				if (method_16(string_2, out float_))
				{
					documentContentStyle_0.PaddingTop = float_;
				}
				break;
			}
			case "padding-right":
			{
				float float_ = 0f;
				if (method_16(string_2, out float_))
				{
					documentContentStyle_0.PaddingRight = float_;
				}
				break;
			}
			case "padding-bottom":
			{
				float float_ = 0f;
				if (method_16(string_2, out float_))
				{
					documentContentStyle_0.PaddingBottom = float_;
				}
				break;
			}
			}
		}

		private string method_12(string string_1)
		{
			return string_1?.Trim();
		}

		private bool method_13(string string_1, string string_2)
		{
			if (string_1 != null)
			{
				return string_1.IndexOf(string_2, StringComparison.CurrentCultureIgnoreCase) >= 0;
			}
			return false;
		}

		private string[] method_14(string string_1)
		{
			if (string.IsNullOrEmpty(string_1))
			{
				return null;
			}
			string[] array = string_1.Split(' ', '\r', '\n', '\t');
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = array[i].Trim();
			}
			return array;
		}

		private string method_15(string string_1)
		{
			int num = 19;
			if (string_1 != null)
			{
				int num2 = string_1.IndexOf("url(", StringComparison.CurrentCultureIgnoreCase);
				if (num2 >= 0)
				{
					string_1 = string_1.Substring(4);
					num2 = string_1.IndexOf(")");
					if (num2 >= 0)
					{
						string_1 = string_1.Substring(0, num2).Trim();
					}
					return string_1;
				}
			}
			return null;
		}

		private bool method_16(string string_1, out float float_0)
		{
			int num = 11;
			float_0 = 0f;
			if (string.IsNullOrEmpty(string_1))
			{
				return false;
			}
			string_1 = string_1.Trim();
			if ("0123456789.-".IndexOf(string_1[0]) >= 0)
			{
				double num2 = GraphicsUnitConvert.ParseCSSLength(string_1, method_0().DocumentGraphicsUnit, double.NaN);
				if (!double.IsNaN(num2))
				{
					float_0 = (float)num2;
					return true;
				}
			}
			return false;
		}

		private bool method_17(string string_1, ref float float_0)
		{
			int num = 12;
			if (string.IsNullOrEmpty(string_1))
			{
				return false;
			}
			string_1 = string_1.Trim().ToLower();
			if (string_1 == "medium" || string_1 == "thin")
			{
				float_0 = 1f;
				return true;
			}
			if (string_1 == "thick")
			{
				float_0 = 2f;
				return true;
			}
			float float_ = 0f;
			if (method_16(string_1, out float_))
			{
				float_0 = float_;
				return true;
			}
			return false;
		}

		private bool method_18(string string_1, out DashStyle dashStyle_0)
		{
			int num = 14;
			if (string_1 == null)
			{
				dashStyle_0 = DashStyle.Custom;
				return false;
			}
			string_1 = string_1.Trim();
			if (string.Equals(string_1, "dashed", StringComparison.CurrentCultureIgnoreCase))
			{
				dashStyle_0 = DashStyle.Dash;
				return true;
			}
			if (string.Equals(string_1, "dotted", StringComparison.CurrentCultureIgnoreCase))
			{
				dashStyle_0 = DashStyle.Dot;
				return true;
			}
			if (string.Equals(string_1, "solid", StringComparison.CurrentCultureIgnoreCase))
			{
				dashStyle_0 = DashStyle.Solid;
				return true;
			}
			if (string.Equals(string_1, "none", StringComparison.CurrentCultureIgnoreCase))
			{
				dashStyle_0 = DashStyle.Custom;
				return true;
			}
			dashStyle_0 = DashStyle.Custom;
			return false;
		}

		private bool method_19(string string_1, out Color color_0)
		{
			int num = 14;
			color_0 = Color.Empty;
			if (dictionary_1 == null)
			{
				dictionary_1 = new Dictionary<string, Color>();
				string[] names = Enum.GetNames(typeof(KnownColor));
				foreach (string text in names)
				{
					dictionary_1[text.ToLower()] = Color.FromKnownColor((KnownColor)Enum.Parse(typeof(KnownColor), text));
				}
			}
			try
			{
				if (string_1 != null)
				{
					string_1 = string_1.Trim();
					if (string_1.StartsWith("#"))
					{
						color_0 = ColorTranslator.FromHtml(string_1);
						return true;
					}
					string_1 = string_1.ToLower();
					if (dictionary_1.ContainsKey(string_1))
					{
						color_0 = dictionary_1[string_1];
						return true;
					}
				}
			}
			catch
			{
			}
			return false;
		}

		private Color method_20(string string_1, Color color_0)
		{
			Color color_ = color_0;
			if (method_19(string_1, out color_))
			{
				return color_;
			}
			return color_0;
		}

		private int method_21(string string_1)
		{
			return int.Parse(string_1);
		}

		private float method_22(string string_1)
		{
			return float.Parse(string_1);
		}

		private float[] method_23(string string_1)
		{
			List<float> list = new List<float>();
			string[] array = method_14(string_1);
			if (array != null)
			{
				string[] array2 = array;
				foreach (string cSSLength in array2)
				{
					double num = GraphicsUnitConvert.ParseCSSLength(cSSLength, method_0().DocumentGraphicsUnit, double.NaN);
					if (!double.IsNaN(num))
					{
						list.Add((float)num);
					}
				}
			}
			return list.ToArray();
		}

		private float method_24(string string_1)
		{
			return (float)GraphicsUnitConvert.ParseCSSLength(string_1, xtextDocument_0.DocumentGraphicsUnit, 0.0);
		}

		private string method_25(string string_1)
		{
			if (string_0 == null)
			{
				FontFamily[] families = FontFamily.Families;
				string_0 = new string[families.Length];
				for (int i = 0; i < families.Length; i++)
				{
					string_0[i] = families[i].Name;
				}
			}
			if (string_1 != null)
			{
				string_1 = string_1.Trim();
				string[] array = string_0;
				foreach (string text in array)
				{
					if (string.Equals(text, string_1, StringComparison.CurrentCultureIgnoreCase))
					{
						return text;
					}
				}
			}
			return null;
		}
	}
}
