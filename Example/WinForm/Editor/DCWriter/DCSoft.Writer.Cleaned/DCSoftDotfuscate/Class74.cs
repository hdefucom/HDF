using AxNsoOfficeLib;
using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.Writer;
using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace DCSoftDotfuscate
{
	internal class Class74
	{
		private class Class75 : IComparer<ListItem>
		{
			public int Compare(ListItem listItem_0, ListItem listItem_1)
			{
				int result = 0;
				int.TryParse(listItem_0.Tag, out result);
				int result2 = 0;
				int.TryParse(listItem_1.Tag, out result2);
				return result - result2;
			}
		}

		private bool bool_0 = true;

		private string string_0 = null;

		private XTextDocument xtextDocument_0 = null;

		private XmlDocument xmlDocument_0 = null;

		private XmlDocument xmlDocument_1 = null;

		private XmlDocument xmlDocument_2 = null;

		private XmlDocument xmlDocument_3 = null;

		private XmlDocument xmlDocument_4 = null;

		private string string_1 = null;

		private Dictionary<string, byte[]> dictionary_0 = new Dictionary<string, byte[]>();

		private string string_2 = null;

		private Stack<XTextContainerElement> stack_0 = new Stack<XTextContainerElement>();

		private List<string> list_0 = new List<string>();

		private Dictionary<string, string> dictionary_1 = new Dictionary<string, string>();

		private TypeConverter typeConverter_0 = TypeDescriptor.GetConverter(typeof(Color));

		private bool bool_1 = false;

		private string string_3 = null;

		public bool method_0()
		{
			return bool_0;
		}

		public void method_1(bool bool_2)
		{
			bool_0 = bool_2;
		}

		public string method_2()
		{
			return string_0;
		}

		public void method_3(string string_4)
		{
			string_0 = string_4;
		}

		public bool method_4(Stream stream_0, XTextDocument xtextDocument_1, ContentSerializeOptions contentSerializeOptions_0)
		{
			int num = 10;
			if (stream_0 == null)
			{
				throw new ArgumentNullException("inputStream");
			}
			byte[] byte_ = FileHelper.LoadBinaryStream(stream_0);
			xtextDocument_0 = xtextDocument_1;
			try
			{
				bool_0 = true;
				return method_6(byte_);
			}
			catch (GException0)
			{
				if (contentSerializeOptions_0.WriterControl != null)
				{
					Control parent = contentSerializeOptions_0.WriterControl.Parent;
					AxNsoControlBase axNsoControlBase = null;
					while (parent != null)
					{
						if (parent is AxNsoControlBase)
						{
							axNsoControlBase = (AxNsoControlBase)parent;
							break;
						}
						parent = parent.Parent;
					}
					if (axNsoControlBase != null)
					{
						byte[] array = axNsoControlBase.DecryptODTBinary(byte_);
						if (array != null && array.Length > 0)
						{
							return method_6(array);
						}
						return false;
					}
				}
			}
			return true;
		}

		private XmlNamespaceManager method_5(XmlDocument xmlDocument_5)
		{
			XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(xmlDocument_5.NameTable);
			xmlNamespaceManager.AddNamespace("field", "urn:openoffice:names:experimental:ooo-ms-interop:xmlns:field:1.0");
			xmlNamespaceManager.AddNamespace("grddl", "http://www.w3.org/2003/g/data-view#");
			xmlNamespaceManager.AddNamespace("xhtml", "http://www.w3.org/1999/xhtml");
			xmlNamespaceManager.AddNamespace("of", "urn:oasis:names:tc:opendocument:xmlns:of:1.2");
			xmlNamespaceManager.AddNamespace("rpt", "http://openoffice.org/2005/report");
			xmlNamespaceManager.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance");
			xmlNamespaceManager.AddNamespace("xsd", "http://www.w3.org/2001/XMLSchema");
			xmlNamespaceManager.AddNamespace("xforms", "http://www.w3.org/2002/xforms");
			xmlNamespaceManager.AddNamespace("dom", "http://www.w3.org/2001/xml-events");
			xmlNamespaceManager.AddNamespace("oooc", "http://openoffice.org/2004/calc");
			xmlNamespaceManager.AddNamespace("ooow", "http://openoffice.org/2004/writer");
			xmlNamespaceManager.AddNamespace("ooo", "http://openoffice.org/2004/office");
			xmlNamespaceManager.AddNamespace("script", "urn:oasis:names:tc:opendocument:xmlns:script:1.0");
			xmlNamespaceManager.AddNamespace("form", "urn:oasis:names:tc:opendocument:xmlns:form:1.0");
			xmlNamespaceManager.AddNamespace("math", "http://www.w3.org/1998/Math/MathML");
			xmlNamespaceManager.AddNamespace("dr3d", "urn:oasis:names:tc:opendocument:xmlns:dr3d:1.0");
			xmlNamespaceManager.AddNamespace("chart", "urn:oasis:names:tc:opendocument:xmlns:chart:1.0");
			xmlNamespaceManager.AddNamespace("svg", "urn:oasis:names:tc:opendocument:xmlns:svg-compatible:1.0");
			xmlNamespaceManager.AddNamespace("number", "urn:oasis:names:tc:opendocument:xmlns:datastyle:1.0");
			xmlNamespaceManager.AddNamespace("meta", "urn:oasis:names:tc:opendocument:xmlns:meta:1.0");
			xmlNamespaceManager.AddNamespace("dc", "http://purl.org/dc/elements/1.1/");
			xmlNamespaceManager.AddNamespace("xlink", "http://www.w3.org/1999/xlink");
			xmlNamespaceManager.AddNamespace("fo", "urn:oasis:names:tc:opendocument:xmlns:xsl-fo-compatible:1.0");
			xmlNamespaceManager.AddNamespace("draw", "urn:oasis:names:tc:opendocument:xmlns:drawing:1.0");
			xmlNamespaceManager.AddNamespace("table", "urn:oasis:names:tc:opendocument:xmlns:table:1.0");
			xmlNamespaceManager.AddNamespace("text", "urn:oasis:names:tc:opendocument:xmlns:text:1.0");
			xmlNamespaceManager.AddNamespace("style", "urn:oasis:names:tc:opendocument:xmlns:style:1.0");
			xmlNamespaceManager.AddNamespace("office", "urn:oasis:names:tc:opendocument:xmlns:office:1.0");
			return xmlNamespaceManager;
		}

		private bool method_6(byte[] byte_0)
		{
			int num = 5;
			MemoryStream stream_ = new MemoryStream(byte_0);
			GClass571 gClass = new GClass571(stream_);
			dictionary_0 = new Dictionary<string, byte[]>();
			foreach (GClass577 item in gClass)
			{
				if (item.method_51() && item.method_30() > 0L && item.method_21())
				{
					byte[] array = new byte[item.method_30()];
					Stream stream = gClass.method_16(item);
					stream.Read(array, 0, array.Length);
					stream.Close();
					dictionary_0[item.Name] = array;
				}
			}
			if (xtextDocument_0 == null)
			{
				xtextDocument_0 = new XTextDocument();
			}
			xtextDocument_0.Clear();
			if (!method_19())
			{
				return false;
			}
			if (xmlDocument_0.DocumentElement.LocalName != "document-content")
			{
				return false;
			}
			XmlElement xmlElement = (XmlElement)XMLHelper.GetChildNode(xmlDocument_0.DocumentElement, "office:automatic-styles");
			if (xmlElement != null)
			{
				xtextDocument_0.ContentStyles.Styles.Clear();
				method_11(xmlElement);
			}
			XmlElement xmlElement2 = (XmlElement)XMLHelper.GetChildNode(xmlDocument_0.DocumentElement, "office:body");
			if (xmlElement2 != null)
			{
				XmlElement xmlElement3 = (XmlElement)XMLHelper.GetChildNode(xmlElement2, "office:text");
				if (xmlElement3 != null)
				{
					xtextDocument_0.Body.Elements.Clear();
					stack_0.Clear();
					stack_0.Push(xtextDocument_0.Body);
					method_7(xmlElement3, null);
				}
			}
			if (xmlDocument_3 != null)
			{
				XmlNamespaceManager nsmgr = method_5(xmlDocument_3);
				if (string.IsNullOrEmpty(string_2))
				{
					string_2 = "Standard";
				}
				XmlElement xmlElement4 = (XmlElement)xmlDocument_3.SelectSingleNode("office:document-styles/office:master-styles/style:master-page[@style:name='" + string_2 + "']", nsmgr);
				if (xmlElement4 == null)
				{
					xmlElement4 = (XmlElement)xmlDocument_3.SelectSingleNode("office:document-styles/office:master-styles/style:master-page", nsmgr);
				}
				if (xmlElement4 != null)
				{
					string attribute = xmlElement4.GetAttribute("style:page-layout-name");
					if (!string.IsNullOrEmpty(attribute))
					{
						XmlElement xmlElement5 = (XmlElement)xmlDocument_3.SelectSingleNode("office:document-styles/office:automatic-styles/style:page-layout[@style:name='" + attribute + "']", nsmgr);
						if (xmlElement5 != null)
						{
							XmlElement xmlElement6 = (XmlElement)XMLHelper.GetChildNode(xmlElement5, "style:page-layout-properties");
							if (xmlElement6 != null)
							{
								float num2 = 0f;
								float num3 = 0f;
								foreach (XmlAttribute attribute2 in xmlElement6.Attributes)
								{
									switch (attribute2.LocalName)
									{
									case "margin-left":
										xtextDocument_0.PageSettings.ViewLeftMargin = method_15(attribute2.Value);
										break;
									case "margin-top":
										xtextDocument_0.PageSettings.ViewTopMargin = method_15(attribute2.Value);
										break;
									case "margin-right":
										xtextDocument_0.PageSettings.ViewRightMargin = method_15(attribute2.Value);
										break;
									case "margin-bottom":
										xtextDocument_0.PageSettings.ViewLeftMargin = method_15(attribute2.Value);
										break;
									case "page-width":
										num2 = method_15(attribute2.Value) / 3f;
										break;
									case "page-height":
										num3 = method_15(attribute2.Value) / 3f;
										break;
									case "print-orientation":
										if (string.Compare(attribute2.Value, "landscape", ignoreCase: true) == 0)
										{
											xtextDocument_0.PageSettings.Landscape = true;
										}
										else
										{
											xtextDocument_0.PageSettings.Landscape = false;
										}
										break;
									}
								}
								if (num2 > 0f && num3 > 0f)
								{
									xtextDocument_0.PageSettings.SetPageSize((int)num2, (int)num3, vLandscape: false);
								}
							}
						}
					}
					XmlElement xmlElement_ = (XmlElement)XMLHelper.GetChildNode(xmlDocument_3.DocumentElement, "office:automatic-styles");
					method_11(xmlElement_);
					XmlElement xmlElement7 = (XmlElement)xmlElement4.SelectSingleNode("style:header", nsmgr);
					if (xmlElement7 != null)
					{
						xtextDocument_0.Header.Elements.Clear();
						stack_0.Clear();
						stack_0.Push(xtextDocument_0.Header);
						method_7(xmlElement7, null);
					}
					XmlElement xmlElement8 = (XmlElement)xmlElement4.SelectSingleNode("style:footer", nsmgr);
					if (xmlElement8 != null)
					{
						xtextDocument_0.Footer.Elements.Clear();
						stack_0.Clear();
						stack_0.Push(xtextDocument_0.Footer);
						method_7(xmlElement8, null);
					}
				}
			}
			foreach (XTextInputFieldElement item2 in xtextDocument_0.GetElementsByType(typeof(XTextInputFieldElement)))
			{
				if (item2.GetAttribute("UseStubString") == "TRUE")
				{
					if (!string.IsNullOrEmpty(item2.Text))
					{
						item2.BackgroundText = item2.Text;
						if (item2.Elements.FirstElement is XTextCharElement)
						{
							item2.BackgroundTextColor = item2.Elements[0].RuntimeStyle.Color;
						}
						item2.Elements.Clear();
					}
					item2.Attributes.RemoveByName("UseStubString");
					item2.Attributes.RemoveByName("StubString");
				}
			}
			return true;
		}

		private void method_7(XmlElement xmlElement_0, string string_4)
		{
			int num = 4;
			XmlNamespaceManager nsmgr = method_5(xmlElement_0.OwnerDocument);
			foreach (XmlNode childNode in xmlElement_0.ChildNodes)
			{
				XTextElement xTextElement = stack_0.Peek();
				if (childNode is XmlText)
				{
					string value = childNode.Value;
					if (!string.IsNullOrEmpty(value))
					{
						XTextStringElement xTextStringElement = new XTextStringElement();
						xTextStringElement.Text = value;
						xTextStringElement.StyleIndex = method_10(string_4, "text-properties");
						xTextElement.Elements.Add(xTextStringElement);
					}
				}
				else if (childNode is XmlElement && !(childNode.LocalName == "sequence-decls"))
				{
					XmlElement xmlElement = (XmlElement)childNode;
					string text = null;
					foreach (XmlAttribute attribute4 in xmlElement.Attributes)
					{
						if (attribute4.LocalName == "style-name")
						{
							text = attribute4.Value;
							break;
						}
					}
					if (text != null && string.IsNullOrEmpty(string_2) && dictionary_1.ContainsKey(text))
					{
						string_2 = dictionary_1[text];
					}
					switch (xmlElement.LocalName)
					{
					case "section":
					{
						XTextSectionElement xTextSectionElement = new XTextSectionElement();
						xTextElement.Elements.Add(xTextSectionElement);
						xTextSectionElement.ID = xmlElement.GetAttribute("text:name");
						xTextSectionElement.StyleIndex = method_10(text, "section-properties");
						stack_0.Push(xTextSectionElement);
						method_7(xmlElement, text);
						stack_0.Pop();
						break;
					}
					case "table":
					{
						XTextTableElement xTextTableElement = new XTextTableElement();
						xTextElement.Elements.Add(xTextTableElement);
						xTextTableElement.ID = xmlElement.GetAttribute("table:name");
						DocumentContentStyle documentContentStyle = method_9(text, "table-properties");
						if (documentContentStyle != null)
						{
							xTextTableElement.StyleIndex = documentContentStyle.Index;
							if (documentContentStyle.Tags != null && documentContentStyle.Tags.ContainsKey("protected") && method_13(documentContentStyle.Tags["protected"].ToString(), bool_2: false))
							{
								xTextTableElement.ContentReadonly = ContentReadonlyState.True;
							}
						}
						foreach (XmlNode childNode2 in xmlElement.ChildNodes)
						{
							if (childNode2 is XmlElement)
							{
								XmlElement xmlElement3 = (XmlElement)childNode2;
								if (xmlElement3.LocalName == "table-column")
								{
									int result = 1;
									if (!int.TryParse(xmlElement3.GetAttribute("table:number-columns-repeated"), out result))
									{
										result = 1;
									}
									text = xmlElement3.GetAttribute("table:style-name");
									DocumentContentStyle documentContentStyle2 = method_9(text, "table-column-properties");
									for (int i = 0; i < result; i++)
									{
										XTextTableColumnElement xTextTableColumnElement = new XTextTableColumnElement();
										if (documentContentStyle2 != null)
										{
											xTextTableColumnElement.StyleIndex = documentContentStyle2.Index;
											if (documentContentStyle2.Tags != null && documentContentStyle2.Tags.ContainsKey("column-width"))
											{
												xTextTableColumnElement.Width = method_15((string)documentContentStyle2.Tags["column-width"]);
											}
										}
										xTextTableElement.Columns.Add(xTextTableColumnElement);
									}
								}
							}
						}
						XmlNodeList xmlNodeList = xmlElement.SelectNodes("table:table-row | table:table-header-rows/table:table-row", nsmgr);
						foreach (XmlElement item in xmlNodeList)
						{
							XTextTableRowElement xTextTableRowElement = new XTextTableRowElement();
							xTextTableRowElement.HeaderStyle = (item.ParentNode.LocalName == "table-header-rows");
							text = item.GetAttribute("table:style-name");
							DocumentContentStyle documentContentStyle3 = method_9(text, "table-row-properties");
							if (documentContentStyle3 != null)
							{
								xTextTableRowElement.StyleIndex = documentContentStyle3.Index;
							}
							foreach (XmlNode childNode3 in item.ChildNodes)
							{
								if (childNode3.LocalName == "table-cell")
								{
									XmlElement xmlElement4 = (XmlElement)childNode3;
									XTextTableCellElement xTextTableCellElement = new XTextTableCellElement();
									text = xmlElement4.GetAttribute("table:style-name");
									DocumentContentStyle documentContentStyle2 = method_9(text, "table-cell-properties");
									if (documentContentStyle2 != null)
									{
										xTextTableCellElement.StyleIndex = documentContentStyle2.Index;
										if (documentContentStyle2.Tags != null && documentContentStyle2.Tags.ContainsKey("protect") && method_13(documentContentStyle2.Tags["protect"].ToString(), bool_2: false))
										{
											xTextTableCellElement.ContentReadonly = ContentReadonlyState.True;
										}
										if (xmlElement4.HasAttribute("table:number-columns-spanned"))
										{
											xTextTableCellElement.method_60(Convert.ToInt32(xmlElement4.GetAttribute("table:number-columns-spanned")));
										}
										if (xmlElement4.HasAttribute("table:number-rows-spanned"))
										{
											xTextTableCellElement.method_61(Convert.ToInt32(xmlElement4.GetAttribute("table:number-rows-spanned")));
										}
									}
									stack_0.Push(xTextTableCellElement);
									method_7(xmlElement4, text);
									stack_0.Pop();
									xTextTableRowElement.Cells.Add(xTextTableCellElement);
								}
								else if (childNode3.LocalName == "covered-table-cell")
								{
									XTextTableCellElement xTextTableCellElement = new XTextTableCellElement();
									xTextTableRowElement.Cells.Add(xTextTableCellElement);
								}
							}
							xTextTableElement.Rows.Add(xTextTableRowElement);
						}
						break;
					}
					case "p":
					{
						method_7((XmlElement)childNode, text);
						XTextParagraphFlagElement xTextParagraphFlagElement = new XTextParagraphFlagElement();
						xTextParagraphFlagElement.StyleIndex = method_10(text, "paragraph-properties");
						xTextElement.Elements.Add(xTextParagraphFlagElement);
						break;
					}
					case "newcontrol-base":
						method_10(string_4, "text-properties");
						if (xmlElement.GetAttribute("text:newcontrol-start") == "true")
						{
							NsoNewControlType nsoNewControlType = (NsoNewControlType)Convert.ToInt32(xmlElement.GetAttribute("text:newcontrol-type"));
							string text3 = xmlElement.GetAttribute("text:newcontrol-name");
							if (text3.EndsWith("_Start"))
							{
								text3 = text3.Substring(0, text3.Length - "_Start".Length);
							}
							switch (nsoNewControlType)
							{
							case NsoNewControlType.RadioButton:
								nsoNewControlType = NsoNewControlType.DateTimeBox;
								break;
							case NsoNewControlType.Checkbox:
								nsoNewControlType = NsoNewControlType.NumberBox;
								break;
							case NsoNewControlType.Combox:
								nsoNewControlType = NsoNewControlType.ListBox;
								break;
							}
							XTextElement xTextElement2 = null;
							if (nsoNewControlType == NsoNewControlType.None)
							{
								XTextInputFieldElement xTextInputFieldElement = new XTextInputFieldElement();
								xTextInputFieldElement.SetAttribute("NsoElementTypeName", "Section");
								xTextInputFieldElement.EnableHighlight = EnableState.Disabled;
								xTextInputFieldElement.ID = text3;
								xTextElement2 = xTextInputFieldElement;
							}
							else
							{
								xTextElement2 = AxNsoControlBase.CreateNewControl(text3, null, nsoNewControlType);
							}
							if (xTextElement2 != null)
							{
								if (xTextElement2 is XTextInputFieldElement)
								{
									XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)xTextElement2;
									xTextInputFieldElement.EditorActiveMode = (ValueEditorActiveMode.Program | ValueEditorActiveMode.F2 | ValueEditorActiveMode.MouseDblClick);
								}
								method_8(xTextElement2, xmlElement);
								xTextElement.Elements.Add(xTextElement2);
								if (xTextElement2 is XTextInputFieldElement)
								{
									stack_0.Push((XTextContainerElement)xTextElement2);
									list_0.Add(text3);
									method_7(xmlElement, text);
								}
							}
						}
						else if (xmlElement.GetAttribute("text:newcontrol-end") == "true")
						{
							string attribute3 = xmlElement.GetAttribute("text:newcontrol-name");
							if (attribute3 != null && attribute3.EndsWith("_End"))
							{
								attribute3 = attribute3.Substring(0, attribute3.Length - 4);
								if (list_0.Contains(attribute3))
								{
									XTextInputFieldElement xTextInputFieldElement = stack_0.Peek() as XTextInputFieldElement;
									if (xTextInputFieldElement != null && xTextInputFieldElement.Text == xTextInputFieldElement.ToolTip)
									{
										xTextInputFieldElement.Elements.Clear();
										xTextInputFieldElement.BackgroundText = xTextInputFieldElement.ToolTip;
									}
									stack_0.Pop();
									list_0.Remove(attribute3);
								}
							}
						}
						break;
					case "line-break":
					{
						XTextLineBreakElement element = new XTextLineBreakElement();
						xTextElement.Elements.Add(element);
						break;
					}
					case "a":
						method_7(xmlElement, text);
						break;
					case "span":
						method_7(xmlElement, text);
						break;
					case "tab":
					{
						XTextCharElement xTextCharElement = new XTextCharElement();
						xTextCharElement.CharValue = '\t';
						xTextElement.Elements.Add(xTextCharElement);
						break;
					}
					case "s":
					{
						XTextStringElement xTextStringElement = new XTextStringElement();
						xTextStringElement.Text = childNode.InnerText;
						xTextStringElement.StyleIndex = method_10(string_4, "text-properties");
						if (string.IsNullOrEmpty(xTextStringElement.Text) && xmlElement.HasAttribute("text:c"))
						{
							int num2 = Convert.ToInt32(xmlElement.GetAttribute("text:c"));
							if (num2 > 0)
							{
								xTextStringElement.Text = new string(' ', num2);
							}
						}
						xTextElement.Elements.Add(xTextStringElement);
						break;
					}
					case "frame":
					{
						XTextImageElement xTextImageElement = new XTextImageElement();
						xTextImageElement.ID = xmlElement.GetAttribute("draw:name");
						text = xmlElement.GetAttribute("draw:style-name");
						xTextImageElement.StyleIndex = method_10(text, "graphic-properties");
						if (xmlElement.HasAttribute("svg:width"))
						{
							xTextImageElement.Width = method_15(xmlElement.GetAttribute("svg:width"));
						}
						if (xmlElement.HasAttribute("svg:height"))
						{
							xTextImageElement.Height = method_15(xmlElement.GetAttribute("svg:height"));
						}
						XmlElement xmlElement2 = (XmlElement)XMLHelper.GetChildNode(xmlElement, "draw:image");
						if (xmlElement2 != null)
						{
							string attribute2 = xmlElement2.GetAttribute("xlink:href");
							if (!string.IsNullOrEmpty(attribute2) && dictionary_0.ContainsKey(attribute2))
							{
								xTextImageElement.ImageData = dictionary_0[attribute2];
								xTextElement.Elements.Add(xTextImageElement);
							}
						}
						break;
					}
					case "page-number":
					{
						XTextPageInfoElement xTextPageInfoElement = new XTextPageInfoElement();
						xTextPageInfoElement.AutoHeight = true;
						xTextPageInfoElement.StyleIndex = method_10(text, "text-properties");
						string attribute = xmlElement.GetAttribute("text:select-page");
						string text2 = attribute;
						if (text2 != null && text2 == "current")
						{
							xTextPageInfoElement.ValueType = PageInfoValueType.PageIndex;
						}
						xTextElement.Elements.Add(xTextPageInfoElement);
						break;
					}
					}
				}
			}
		}

		private void method_8(XTextElement xtextElement_0, XmlElement xmlElement_0)
		{
			int num = 7;
			if (xtextElement_0.Attributes == null)
			{
				xtextElement_0.Attributes = new XAttributeList();
			}
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
			Dictionary<string, string> dictionary3 = new Dictionary<string, string>();
			Dictionary<string, string> dictionary4 = new Dictionary<string, string>();
			foreach (XmlNode childNode in xmlElement_0.ChildNodes)
			{
				if (childNode.Name == "meta:property")
				{
					XmlElement xmlElement = (XmlElement)childNode;
					string attribute = xmlElement.GetAttribute("meta:property-value");
					if (!string.IsNullOrEmpty(attribute))
					{
						string text = "  {===}  ";
						int num2 = attribute.IndexOf(text);
						if (num2 > 0)
						{
							string text2 = attribute.Substring(0, num2).Trim();
							string text3 = attribute.Substring(num2 + text.Length);
							if (text2.StartsWith("ListEntryName"))
							{
								dictionary3[text2.Substring("ListEntryName".Length)] = text3;
							}
							else if (text2.StartsWith("ListEntryValue"))
							{
								dictionary4[text2.Substring("ListEntryValue".Length)] = text3;
							}
							else if (text2.StartsWith("ListEntryUserdefName"))
							{
								dictionary2[text2.Substring("ListEntryUserdefName".Length)] = text3;
							}
							else if (text2.StartsWith("ListEntryUserdefValue"))
							{
								dictionary[text2.Substring("ListEntryUserdefValue".Length)] = text3;
							}
							else
							{
								if (text2 == "IsMustFill" && method_13(text3, bool_2: false))
								{
									XTextInputFieldElement xTextInputFieldElement = xtextElement_0 as XTextInputFieldElement;
									if (xTextInputFieldElement != null)
									{
										if (xTextInputFieldElement.ValidateStyle == null)
										{
											xTextInputFieldElement.ValidateStyle = new ValueValidateStyle();
										}
										xTextInputFieldElement.ValidateStyle.Required = true;
									}
								}
								xtextElement_0.Attributes.SetValue(text2, text3);
								AxNsoControlBase.UpdateByNsoAttribute(xtextElement_0, text2);
							}
						}
					}
				}
			}
			if (dictionary3.Count > 0 && xtextElement_0 is XTextInputFieldElement)
			{
				XTextInputFieldElement xTextInputFieldElement2 = (XTextInputFieldElement)xtextElement_0;
				if (xTextInputFieldElement2.FieldSettings != null && xTextInputFieldElement2.FieldSettings.EditStyle == InputFieldEditStyle.DropdownList)
				{
					if (xTextInputFieldElement2.FieldSettings.ListSource == null)
					{
						xTextInputFieldElement2.FieldSettings.ListSource = new ListSourceInfo();
					}
					if (xTextInputFieldElement2.FieldSettings.ListSource.Items == null)
					{
						xTextInputFieldElement2.FieldSettings.ListSource.Items = new ListItemCollection();
					}
					foreach (string key in dictionary3.Keys)
					{
						string value = null;
						if (dictionary4.ContainsKey(key))
						{
							value = dictionary4[key];
						}
						ListItem listItem = new ListItem();
						listItem.Text = dictionary3[key];
						listItem.Value = value;
						listItem.Tag = key;
						xTextInputFieldElement2.FieldSettings.ListSource.Items.Add(listItem);
					}
					xTextInputFieldElement2.FieldSettings.ListSource.Items.Sort(new Class75());
				}
			}
			if (dictionary2.Count > 0)
			{
				foreach (string key2 in dictionary2.Keys)
				{
					if (dictionary.ContainsKey(key2))
					{
						string text4 = dictionary2[key2];
						string value = dictionary[key2];
						if (!string.IsNullOrEmpty(text4))
						{
							xtextElement_0.SetAttribute(text4, value);
						}
					}
				}
			}
		}

		private DocumentContentStyle method_9(string string_4, string string_5)
		{
			string b = string_4 + "#" + string_5;
			foreach (DocumentContentStyle style in xtextDocument_0.ContentStyles.Styles)
			{
				if (style.Name == b)
				{
					style.Index = xtextDocument_0.ContentStyles.Styles.IndexOf(style);
					return style;
				}
			}
			return null;
		}

		private int method_10(string string_4, string string_5)
		{
			int num = 16;
			if (string.IsNullOrEmpty(string_4))
			{
				return -1;
			}
			string b = string_4 + "#" + string_5;
			int num2 = 0;
			while (true)
			{
				if (num2 < xtextDocument_0.ContentStyles.Styles.Count)
				{
					DocumentContentStyle documentContentStyle = (DocumentContentStyle)xtextDocument_0.ContentStyles.Styles[num2];
					if (documentContentStyle.Name == b)
					{
						break;
					}
					num2++;
					continue;
				}
				return -1;
			}
			return num2;
		}

		private void method_11(XmlElement xmlElement_0)
		{
			int num = 10;
			if (xmlElement_0 != null)
			{
				foreach (XmlNode childNode in xmlElement_0.ChildNodes)
				{
					if (childNode.LocalName == "style")
					{
						XmlElement xmlElement = (XmlElement)childNode;
						if (xmlElement.HasAttribute("style:name"))
						{
							string attribute = xmlElement.GetAttribute("style:name");
							string attribute2 = xmlElement.GetAttribute("style:master-page-name");
							if (!string.IsNullOrEmpty(attribute2))
							{
								dictionary_1[attribute] = attribute2;
							}
							foreach (XmlNode childNode2 in xmlElement.ChildNodes)
							{
								if (childNode2 is XmlElement)
								{
									Dictionary<string, string> dictionary = new Dictionary<string, string>();
									foreach (XmlAttribute attribute3 in childNode2.Attributes)
									{
										dictionary[attribute3.LocalName] = attribute3.Value;
									}
									DocumentContentStyle documentContentStyle = method_12(dictionary);
									documentContentStyle.Name = attribute + "#" + childNode2.LocalName;
									documentContentStyle.Index = xtextDocument_0.ContentStyles.Styles.Count;
									xtextDocument_0.ContentStyles.Styles.Add(documentContentStyle);
								}
							}
						}
					}
				}
			}
		}

		private DocumentContentStyle method_12(Dictionary<string, string> dictionary_2)
		{
			int num = 17;
			DocumentContentStyle documentContentStyle = new DocumentContentStyle();
			foreach (string key in dictionary_2.Keys)
			{
				string text = dictionary_2[key];
				switch (key)
				{
				case "margin-left":
					documentContentStyle.MarginLeft = method_15(text);
					break;
				case "margin-top":
					documentContentStyle.MarginTop = method_15(text);
					break;
				case "margin-right":
					documentContentStyle.MarginRight = method_15(text);
					break;
				case "margin-bottom":
					documentContentStyle.MarginBottom = method_15(text);
					break;
				case "text-align":
					if (string.Compare(text, "left", ignoreCase: true) == 0)
					{
						documentContentStyle.Align = DocumentContentAlignment.Left;
					}
					else if (string.Compare(text, "center", ignoreCase: true) == 0)
					{
						documentContentStyle.Align = DocumentContentAlignment.Center;
					}
					else if (string.Compare(text, "right", ignoreCase: true) == 0)
					{
						documentContentStyle.Align = DocumentContentAlignment.Right;
					}
					else if (string.Compare(text, "justify", ignoreCase: true) == 0)
					{
						documentContentStyle.Align = DocumentContentAlignment.Justify;
					}
					break;
				case "text-indent":
					documentContentStyle.FirstLineIndent = method_15(text);
					break;
				case "number-lines":
					if (string.Compare(text, "true", ignoreCase: true) == 0)
					{
						documentContentStyle.ParagraphListStyle = ParagraphListStyle.ListNumberStyle;
					}
					else
					{
						documentContentStyle.ParagraphListStyle = ParagraphListStyle.None;
					}
					break;
				case "line-height":
					if (string.Compare(text, "normal", ignoreCase: true) != 0)
					{
						documentContentStyle.LineSpacingStyle = LineSpacingStyle.SpaceSpecify;
						documentContentStyle.LineSpacing = method_15(text);
					}
					break;
				case "vertical-align":
					if (string.Compare(text, "top", ignoreCase: true) == 0)
					{
						documentContentStyle.VerticalAlign = VerticalAlignStyle.Top;
					}
					else if (string.Compare(text, "middle", ignoreCase: true) == 0)
					{
						documentContentStyle.VerticalAlign = VerticalAlignStyle.Middle;
					}
					else if (string.Compare(text, "bottom", ignoreCase: true) == 0)
					{
						documentContentStyle.VerticalAlign = VerticalAlignStyle.Bottom;
					}
					break;
				case "border-color":
					documentContentStyle.BorderColor = method_14(text, Color.Black);
					break;
				case "border":
				{
					GClass535 gClass = new GClass535();
					gClass.method_8(text);
					documentContentStyle.BorderLeft = gClass.method_0();
					documentContentStyle.BorderTop = gClass.method_0();
					documentContentStyle.BorderRight = gClass.method_0();
					documentContentStyle.BorderBottom = gClass.method_0();
					documentContentStyle.BorderLeftColor = gClass.method_6();
					documentContentStyle.BorderStyle = gClass.method_2();
					documentContentStyle.BorderWidth = gClass.method_4();
					break;
				}
				case "border-left":
				{
					GClass535 gClass = new GClass535();
					gClass.method_8(text);
					documentContentStyle.BorderLeft = true;
					documentContentStyle.BorderLeftColor = gClass.method_6();
					documentContentStyle.BorderStyle = gClass.method_2();
					documentContentStyle.BorderWidth = gClass.method_4();
					break;
				}
				case "border-top":
				{
					GClass535 gClass = new GClass535();
					gClass.method_8(text);
					documentContentStyle.BorderTop = true;
					documentContentStyle.BorderTopColor = gClass.method_6();
					documentContentStyle.BorderStyle = gClass.method_2();
					documentContentStyle.BorderWidth = gClass.method_4();
					break;
				}
				case "border-right":
				{
					GClass535 gClass = new GClass535();
					gClass.method_8(text);
					documentContentStyle.BorderRight = true;
					documentContentStyle.BorderRightColor = gClass.method_6();
					documentContentStyle.BorderStyle = gClass.method_2();
					documentContentStyle.BorderWidth = gClass.method_4();
					break;
				}
				case "border-bottom":
				{
					GClass535 gClass = new GClass535();
					gClass.method_8(text);
					documentContentStyle.BorderBottom = true;
					documentContentStyle.BorderBottomColor = gClass.method_6();
					documentContentStyle.BorderStyle = gClass.method_2();
					documentContentStyle.BorderWidth = gClass.method_4();
					break;
				}
				case "padding":
					documentContentStyle.PaddingLeft = method_15(text);
					documentContentStyle.PaddingTop = documentContentStyle.PaddingLeft;
					documentContentStyle.PaddingRight = documentContentStyle.PaddingLeft;
					documentContentStyle.PaddingBottom = documentContentStyle.PaddingLeft;
					break;
				case "padding-left":
					documentContentStyle.PaddingLeft = method_15(text);
					break;
				case "padding-top":
					documentContentStyle.PaddingTop = method_15(text);
					break;
				case "padding-right":
					documentContentStyle.PaddingRight = method_15(text);
					break;
				case "padding-bottom":
					documentContentStyle.PaddingBottom = method_15(text);
					break;
				case "font-family":
				case "font-name":
					documentContentStyle.FontName = text;
					break;
				case "font-size":
					documentContentStyle.FontSize = (float)GraphicsUnitConvert.ParseCSSLength(text, GraphicsUnit.Point, 12.0);
					break;
				case "font-weight":
					if (string.Compare(text, "bold", ignoreCase: true) == 0)
					{
						documentContentStyle.Bold = true;
					}
					break;
				case "color":
					documentContentStyle.Color = method_14(text, Color.Black);
					break;
				case "text-underline-style":
					if (text == "solid")
					{
						documentContentStyle.Underline = true;
					}
					break;
				case "letter-spacing":
					if (text == "normal")
					{
						documentContentStyle.LetterSpacing = 0f;
					}
					else
					{
						documentContentStyle.LetterSpacing = method_15(text);
					}
					break;
				case "font-style":
					if (string.Compare(text, "normal", ignoreCase: true) == 0)
					{
						documentContentStyle.Italic = false;
					}
					else if (string.Compare(text, "italic", ignoreCase: true) == 0)
					{
						documentContentStyle.Italic = true;
					}
					else if (string.Compare(text, "oblique", ignoreCase: true) == 0)
					{
						documentContentStyle.Italic = true;
					}
					break;
				case "text-underline-type":
					if (string.Compare(text, "none", ignoreCase: true) == 0)
					{
						documentContentStyle.Underline = false;
					}
					else if (string.Compare(text, "single", ignoreCase: true) == 0)
					{
						documentContentStyle.Underline = true;
					}
					else if (string.Compare(text, "double", ignoreCase: true) == 0)
					{
						documentContentStyle.Underline = true;
					}
					break;
				case "background-color":
					documentContentStyle.BackgroundColor = method_14(text, Color.Transparent);
					break;
				default:
					if (documentContentStyle.Tags == null)
					{
						documentContentStyle.Tags = new Hashtable();
					}
					documentContentStyle.Tags[key] = text;
					break;
				case "justify-single-word":
				case "auto-text-indent":
				case "font-size-asian":
				case "language-asian":
					break;
				}
			}
			return documentContentStyle;
		}

		private bool method_13(string string_4, bool bool_2)
		{
			int num = 16;
			if (string.IsNullOrEmpty(string_4))
			{
				return bool_2;
			}
			if (string.Compare(string_4, "true", ignoreCase: true) == 0)
			{
				return true;
			}
			if (string.Compare(string_4, "false", ignoreCase: true) == 0)
			{
				return false;
			}
			return bool_2;
		}

		private Color method_14(string string_4, Color color_0)
		{
			if (string.IsNullOrEmpty(string_4))
			{
				return color_0;
			}
			return (Color)typeConverter_0.ConvertFromString(string_4);
		}

		private float method_15(string string_4)
		{
			return (float)GraphicsUnitConvert.ParseCSSLength(string_4, xtextDocument_0.DocumentGraphicsUnit, 0.0);
		}

		private static bool smethod_0(byte[] byte_0, byte[] byte_1)
		{
			if (byte_0 == byte_1)
			{
				return true;
			}
			if (byte_0 == null || byte_1 == null)
			{
				return true;
			}
			if (byte_0.Length != byte_1.Length)
			{
				return false;
			}
			int num = byte_0.Length;
			int num2 = 0;
			while (true)
			{
				if (num2 < num)
				{
					if (byte_0[num2] != byte_1[num2])
					{
						break;
					}
					num2++;
					continue;
				}
				return true;
			}
			return false;
		}

		public string method_16()
		{
			return string_3;
		}

		public void method_17(string string_4)
		{
			string_3 = string_4;
		}

		private bool method_18(XmlDocument xmlDocument_5)
		{
			int num = 6;
			bool result = true;
			XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(xmlDocument_5.NameTable);
			xmlNamespaceManager.AddNamespace("manifest", "urn:oasis:names:tc:opendocument:xmlns:manifest:1.0");
			foreach (XmlElement item in xmlDocument_5.DocumentElement.SelectNodes("manifest:file-entry", xmlNamespaceManager))
			{
				XmlElement xmlElement2 = (XmlElement)XMLHelper.GetChildNode(item, "manifest:encryption-data");
				if (xmlElement2 != null)
				{
					string attribute = item.GetAttribute("manifest:full-path");
					if (dictionary_0.ContainsKey(attribute))
					{
						byte[] buffer = dictionary_0[attribute];
						result = false;
						if (string.IsNullOrEmpty(string_0))
						{
							return false;
						}
						string attribute2 = xmlElement2.GetAttribute("manifest:checksum-type");
						string attribute3 = xmlElement2.GetAttribute("manifest:checksum");
						byte[] byte_ = null;
						if (!string.IsNullOrEmpty(attribute3))
						{
							byte_ = Convert.FromBase64String(attribute3);
						}
						if (attribute2 == "SHA1/1K")
						{
							SHA1CryptoServiceProvider sHA1CryptoServiceProvider = new SHA1CryptoServiceProvider();
							byte[] bytes = Encoding.UTF8.GetBytes(method_2());
							byte[] array = sHA1CryptoServiceProvider.ComputeHash(bytes);
							array = sHA1CryptoServiceProvider.ComputeHash(buffer);
							if (!smethod_0(array, byte_))
							{
								method_17("SHA1校验不通过");
								return false;
							}
						}
						XmlElement xmlElement3 = (XmlElement)XMLHelper.GetChildNode(xmlElement2, "manifest:algorithm");
						if (xmlElement3 == null)
						{
							method_17("没找到 manifest:algorithm");
							return false;
						}
						xmlElement3.GetAttribute("manifest:algorithm-name");
						string attribute4 = xmlElement3.GetAttribute("manifest:initialisation-vector");
						byte[] byte_2 = null;
						if (!string.IsNullOrEmpty(attribute4))
						{
							byte_2 = Convert.FromBase64String(attribute4);
						}
						new GClass347(byte_2);
					}
				}
			}
			return result;
		}

		private bool method_19()
		{
			int num = 7;
			bool_1 = false;
			xmlDocument_0 = null;
			xmlDocument_1 = null;
			xmlDocument_2 = null;
			xmlDocument_3 = null;
			string_1 = null;
			if (dictionary_0.ContainsKey("META-INF/manifest.xml"))
			{
				byte[] buffer = dictionary_0["META-INF/manifest.xml"];
				MemoryStream inStream = new MemoryStream(buffer);
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.Load(inStream);
				if (!method_18(xmlDocument))
				{
					bool_1 = true;
					if (method_0())
					{
						throw new GException0("ODT文档被加密了");
					}
					return false;
				}
				XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(xmlDocument.NameTable);
				xmlNamespaceManager.AddNamespace("manifest", "urn:oasis:names:tc:opendocument:xmlns:manifest:1.0");
				XmlNodeList xmlNodeList = xmlDocument.SelectNodes("//manifest:encryption-data", xmlNamespaceManager);
				if (xmlNodeList != null && xmlNodeList.Count > 0)
				{
					bool_1 = true;
					if (method_0())
					{
						throw new GException0("ODT文档被加密了");
					}
					return false;
				}
			}
			foreach (string key in dictionary_0.Keys)
			{
				byte[] buffer = dictionary_0[key];
				if (buffer != null && buffer.Length != 0)
				{
					switch (key)
					{
					case "content.xml":
					{
						MemoryStream inStream = new MemoryStream(buffer);
						xmlDocument_0 = new XmlDocument();
						xmlDocument_0.Load(inStream);
						break;
					}
					case "manifest.rdf":
					{
						MemoryStream inStream = new MemoryStream(buffer);
						xmlDocument_4 = new XmlDocument();
						xmlDocument_4.Load(inStream);
						break;
					}
					case "meta.xml":
					{
						MemoryStream inStream = new MemoryStream(buffer);
						xmlDocument_1 = new XmlDocument();
						xmlDocument_1.Load(inStream);
						XmlElement xmlElement = (XmlElement)XMLHelper.GetChildNode(xmlDocument_1.DocumentElement, "office:meta");
						if (xmlElement != null)
						{
							foreach (XmlNode childNode in xmlElement.ChildNodes)
							{
								switch (childNode.LocalName)
								{
								case "creation-date":
									xtextDocument_0.Info.CreationTime = Convert.ToDateTime(childNode.InnerText);
									break;
								case "generator":
									xtextDocument_0.Info.Operator = childNode.InnerText;
									break;
								case "creator":
									xtextDocument_0.Info.Author = childNode.InnerText;
									break;
								case "title":
									xtextDocument_0.Info.Title = childNode.InnerText;
									break;
								case "description":
									xtextDocument_0.Info.Description = childNode.InnerText;
									break;
								case "subject":
									xtextDocument_0.Info.Description = childNode.InnerText;
									break;
								case "print-date":
									xtextDocument_0.Info.LastPrintTime = Convert.ToDateTime(childNode.InnerText);
									break;
								case "user-defined":
								{
									XmlElement xmlElement2 = (XmlElement)childNode;
									string attribute = xmlElement2.GetAttribute("meta:name");
									string innerText = xmlElement2.InnerText;
									xtextDocument_0.SetAttribute(attribute, innerText);
									break;
								}
								}
							}
						}
						break;
					}
					case "mimetype":
						string_1 = Encoding.Default.GetString(buffer);
						break;
					case "settings.xml":
					{
						MemoryStream inStream = new MemoryStream(buffer);
						xmlDocument_2 = new XmlDocument();
						xmlDocument_2.Load(inStream);
						break;
					}
					case "styles.xml":
					{
						MemoryStream inStream = new MemoryStream(buffer);
						xmlDocument_3 = new XmlDocument();
						xmlDocument_3.Load(inStream);
						break;
					}
					}
				}
			}
			return true;
		}
	}
}
