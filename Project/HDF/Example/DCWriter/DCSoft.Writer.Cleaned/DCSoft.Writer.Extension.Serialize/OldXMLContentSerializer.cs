#define DEBUG
using DCSoft.Common;
using DCSoft.Data;
using DCSoft.Drawing;
using DCSoft.Printing;
using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Extension.Medical;
using DCSoft.Writer.Security;
using DCSoft.Writer.Serialization;
using DCSoftDotfuscate;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace DCSoft.Writer.Extension.Serialize
{
	/// <summary>
	///       旧格式XML文档编码器
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	internal class OldXMLContentSerializer : ContentSerializer
	{
		private const ButtonBorderStyle buttonBorderStyle_0 = ButtonBorderStyle.Solid;

		private const int int_0 = 0;

		private const string string_0 = "border-top-color";

		private const string string_1 = "border-top-width";

		private const string string_2 = "border-top-style";

		private const string string_3 = "border-left-color";

		private const string string_4 = "border-left-width";

		private const string string_5 = "border-left-style";

		private const string string_6 = "border-right-color";

		private const string string_7 = "border-right-width";

		private const string string_8 = "border-right-style";

		private const string string_9 = "border-bottom-color";

		private const string string_10 = "border-bottom-width";

		private const string string_11 = "border-bottom-style";

		private const string string_12 = "border-color";

		private const string string_13 = "border-width";

		private const string string_14 = "border-style";

		private const string string_15 = "background-color";

		private static Color color_0 = Color.Black;

		private static Color color_1 = Color.White;

		/// <summary>
		///       名称
		///       </summary>
		public override string Name => "OldXML";

		public override int Priority => 10;

		/// <summary>
		///       文件扩展名
		///       </summary>
		public override string FileExtension => ".xml";

		/// <summary>
		///       文件名过滤字符串
		///       </summary>
		public override string FileFilter => "旧格式XML文件|*.xml";

		/// <summary>
		///       标记
		///       </summary>
		public override GEnum14 Flags => GEnum14.flag_1 | GEnum14.flag_3;

		/// <summary>
		///       初始化对象
		///       </summary>
		public OldXMLContentSerializer()
		{
			base.ContentEncoding = Encoding.UTF8;
		}

		/// <summary>
		///       反序列化加载文档内容
		///       </summary>
		/// <param name="reader">文本读取器</param>
		/// <param name="document">文档对象</param>
		/// <param name="options">文档选项</param>
		/// <returns>操作是否成功</returns>
		public override bool Deserialize(TextReader reader, XTextDocument document, ContentSerializeOptions options)
		{
			int num = 3;
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.PreserveWhitespace = true;
			xmlDocument.Load(reader);
			if (xmlDocument.DocumentElement.Name == "emrtextdoc")
			{
				return method_0(document, xmlDocument.DocumentElement);
			}
			if (xmlDocument.DocumentElement.Name == "document")
			{
				return method_1(document, xmlDocument.DocumentElement);
			}
			throw new NotSupportedException(xmlDocument.DocumentElement.Name);
		}

		/// <summary>
		///       反序列化加载文档内容
		///       </summary>
		/// <param name="stream">文件流对象</param>
		/// <param name="document">文档对象</param>
		/// <param name="options">文档选项</param>
		/// <returns>操作是否成功</returns>
		public override bool Deserialize(Stream stream, XTextDocument document, ContentSerializeOptions options)
		{
			int num = 4;
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.PreserveWhitespace = true;
			xmlDocument.Load(stream);
			if (xmlDocument.DocumentElement.Name == "emrtextdoc")
			{
				return method_0(document, xmlDocument.DocumentElement);
			}
			if (xmlDocument.DocumentElement.Name == "document")
			{
				return method_1(document, xmlDocument.DocumentElement);
			}
			throw new NotSupportedException(xmlDocument.DocumentElement.Name);
		}

		private bool method_0(XTextDocument xtextDocument_0, XmlElement xmlElement_0)
		{
			int num = 15;
			XFontValue defaultFont = xtextDocument_0.DefaultFont;
			Color color = xtextDocument_0.DefaultStyle.Color;
			xtextDocument_0.Clear();
			xtextDocument_0.MeasureMode = MeasureMode.Default;
			xtextDocument_0.PageSettings.LeftMargin = 50;
			xtextDocument_0.PageSettings.TopMargin = 50;
			xtextDocument_0.PageSettings.RightMargin = 50;
			xtextDocument_0.PageSettings.BottomMargin = 50;
			xtextDocument_0.DefaultStyle.Font = defaultFont;
			xtextDocument_0.DefaultStyle.Color = color;
			xtextDocument_0.EditorVersionString = xmlElement_0.GetAttribute("version");
			xtextDocument_0.method_40(DomReadyStates.Loading);
			foreach (XmlNode childNode in xmlElement_0.ChildNodes)
			{
				switch (childNode.Name)
				{
				case "headstring":
					method_8(xtextDocument_0.Header, childNode.InnerText);
					break;
				case "footerstring":
					method_8(xtextDocument_0.Footer, childNode.InnerText);
					break;
				case "savelogs":
					method_6(xtextDocument_0, (XmlElement)childNode);
					break;
				case "values":
					foreach (XmlNode childNode2 in childNode.ChildNodes)
					{
						if (childNode2 is XmlElement)
						{
							XmlElement xmlElement2 = (XmlElement)childNode2;
							if (xmlElement2.HasAttribute("name"))
							{
								xtextDocument_0.Parameters.SetValue(xmlElement2.GetAttribute("name"), xmlElement2.InnerText);
							}
						}
					}
					break;
				case "script":
				{
					XmlElement xmlElement = (XmlElement)childNode;
					xtextDocument_0.ScriptText = xmlElement.InnerText;
					break;
				}
				case "body":
					method_9(xtextDocument_0.Body, (XmlElement)childNode);
					break;
				case "div":
					method_9(xtextDocument_0.Body, (XmlElement)childNode);
					break;
				case "linespacing":
				{
					int result = 0;
					if (int.TryParse(childNode.InnerText, out result))
					{
						xtextDocument_0.DefaultStyle.LineSpacing = result;
					}
					break;
				}
				case "paraspacing":
				{
					int result = 0;
					if (int.TryParse(childNode.InnerText, out result))
					{
						xtextDocument_0.DefaultStyle.SpacingBeforeParagraph = result;
					}
					break;
				}
				case "docsettings":
					method_7(xtextDocument_0, (XmlElement)childNode);
					break;
				}
			}
			method_2(xtextDocument_0);
			xtextDocument_0.method_40(DomReadyStates.Loaded);
			ElementLoadEventArgs args = new ElementLoadEventArgs(xtextDocument_0, "OldXML");
			xtextDocument_0.AfterLoad(args);
			return true;
		}

		private bool method_1(XTextDocument xtextDocument_0, XmlElement xmlElement_0)
		{
			int num = 12;
			xtextDocument_0.Clear();
			xtextDocument_0.MeasureMode = MeasureMode.Default;
			XFontValue defaultFont = xtextDocument_0.DefaultFont;
			Color color = xtextDocument_0.DefaultStyle.Color;
			xtextDocument_0.Clear();
			xtextDocument_0.PageSettings.LeftMargin = 50;
			xtextDocument_0.PageSettings.TopMargin = 50;
			xtextDocument_0.PageSettings.RightMargin = 50;
			xtextDocument_0.PageSettings.BottomMargin = 50;
			xtextDocument_0.DefaultStyle.Font = defaultFont;
			xtextDocument_0.DefaultStyle.Color = color;
			xtextDocument_0.method_40(DomReadyStates.Loading);
			foreach (XmlNode childNode in xmlElement_0.ChildNodes)
			{
				switch (childNode.Name)
				{
				case "pagesettings":
					method_23(xtextDocument_0, (XmlElement)childNode);
					break;
				case "history":
					method_6(xtextDocument_0, (XmlElement)childNode);
					break;
				case "prop":
					foreach (XmlNode childNode2 in childNode.ChildNodes)
					{
						if (childNode2.Name == "pagesettings" || childNode2.Name == "pagesetting")
						{
							method_23(xtextDocument_0, (XmlElement)childNode2);
						}
						else if (!(childNode2.Name == "viewmode"))
						{
							if (childNode2.Name == "font")
							{
								foreach (XmlAttribute attribute in childNode2.Attributes)
								{
									switch (attribute.Name)
									{
									case "size":
										xtextDocument_0.DefaultStyle.FontSize = Convert.ToSingle(attribute.Value);
										break;
									case "color":
										xtextDocument_0.DefaultStyle.Color = smethod_0(attribute.Value, Color.Black);
										break;
									case "name":
										xtextDocument_0.DefaultStyle.FontName = attribute.Value;
										break;
									}
								}
							}
							else if (childNode2.Name == "key")
							{
								foreach (XmlAttribute attribute2 in childNode2.Attributes)
								{
									switch (attribute2.Name)
									{
									case "editor":
										xtextDocument_0.EditorVersionString = attribute2.Value;
										break;
									case "id":
										xtextDocument_0.ID = attribute2.Value;
										break;
									case "name":
										xtextDocument_0.ID = attribute2.Value;
										break;
									case "version":
										xtextDocument_0.Info.Version = attribute2.Value;
										break;
									}
								}
							}
						}
					}
					break;
				case "header":
				{
					xtextDocument_0.Header.Elements.Clear();
					method_9(xtextDocument_0.Header, (XmlElement)childNode);
					int count = xtextDocument_0.Header.Elements.Count;
					if (count > 2 && xtextDocument_0.Header.Elements[count - 1] is XTextParagraphFlagElement && xtextDocument_0.Header.Elements[count - 2] is XTextHorizontalLineElement)
					{
						xtextDocument_0.Header.Elements.RemoveAt(count - 1);
						xtextDocument_0.Header.Elements.RemoveAt(count - 2);
					}
					break;
				}
				case "body":
					xtextDocument_0.Body.Elements.Clear();
					method_9(xtextDocument_0.Body, (XmlElement)childNode);
					break;
				case "footer":
					xtextDocument_0.Footer.Elements.Clear();
					method_9(xtextDocument_0.Footer, (XmlElement)childNode);
					break;
				}
			}
			method_2(xtextDocument_0);
			xtextDocument_0.method_40(DomReadyStates.Loaded);
			ElementLoadEventArgs args = new ElementLoadEventArgs(xtextDocument_0, "OldXML");
			xtextDocument_0.AfterLoad(args);
			return true;
		}

		private void method_2(XTextDocument xtextDocument_0)
		{
			xtextDocument_0.FixDomState();
			using (DCGraphics dCGraphics = xtextDocument_0.CreateDCGraphics())
			{
				foreach (XTextButtonElement item in xtextDocument_0.GetElementsByType(typeof(XTextButtonElement)))
				{
					if (!string.IsNullOrEmpty(item.Text))
					{
						float val = dCGraphics.MeasureString(item.Text, item.RuntimeStyle.Font, 1000, XTextButtonElement.InnerFormatForDrawContent).Width + 30f;
						item.Width = Math.Max(item.Width, val);
					}
				}
			}
		}

		private void method_3(XmlElement xmlElement_0, XTextElement xtextElement_0)
		{
			XmlElement xmlElement = (XmlElement)XMLHelper.GetChildNode(xmlElement_0, "prop");
			if (xmlElement != null)
			{
				method_5(xmlElement, xtextElement_0);
			}
		}

		private float method_4(string string_16)
		{
			return GraphicsUnitConvert.Convert(Convert.ToSingle(string_16), GraphicsUnit.Pixel, GraphicsUnit.Document);
		}

		private void method_5(XmlElement xmlElement_0, XTextElement xtextElement_0)
		{
			int num = 2;
			XTextDocument ownerDocument = xtextElement_0.OwnerDocument;
			DocumentContentStyle documentContentStyle = null;
			foreach (XmlNode childNode in xmlElement_0.ChildNodes)
			{
				if (childNode.Name == "margins")
				{
					if (documentContentStyle == null)
					{
						documentContentStyle = new DocumentContentStyle();
					}
					XmlElement xmlElement = (XmlElement)childNode;
					if (xmlElement.HasAttribute("marginleft"))
					{
						documentContentStyle.PaddingLeft = method_4(xmlElement.GetAttribute("marginleft"));
					}
					if (xmlElement.HasAttribute("margintop"))
					{
						documentContentStyle.PaddingTop = method_4(xmlElement.GetAttribute("margintop"));
					}
					if (xmlElement.HasAttribute("marginright"))
					{
						documentContentStyle.PaddingRight = method_4(xmlElement.GetAttribute("marginright"));
					}
					if (xmlElement.HasAttribute("marginbottom"))
					{
						documentContentStyle.PaddingBottom = method_4(xmlElement.GetAttribute("marginbottom"));
					}
				}
				else if (childNode.Name == "diagonal")
				{
					if (xtextElement_0 is XTextTableCellElement)
					{
						XmlElement xmlElement = (XmlElement)childNode;
						XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)xtextElement_0;
						if (string.Compare(xmlElement.GetAttribute("rightdiagonal"), "True", ignoreCase: true) == 0)
						{
							xTextTableCellElement.SlantSplitLineStyle = RectangleSlantSplitStyle.BottomLeftOneLine;
						}
						if (string.Compare(xmlElement.GetAttribute("leftdiagonal"), "True", ignoreCase: true) == 0)
						{
							xTextTableCellElement.SlantSplitLineStyle = RectangleSlantSplitStyle.TopLeftOneLine;
						}
					}
				}
				else if (childNode.Name == "size")
				{
					if (xtextElement_0 is XTextTableRowElement)
					{
						XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)xtextElement_0;
						XmlElement xmlElement = (XmlElement)childNode;
						if (xmlElement.HasAttribute("height"))
						{
							xTextTableRowElement.SpecifyHeight = GraphicsUnitConvert.Convert(Convert.ToSingle(xmlElement.GetAttribute("height")), GraphicsUnit.Pixel, GraphicsUnit.Document);
						}
					}
				}
				else if (childNode.Name == "general")
				{
					if (xtextElement_0 is XTextTableRowElement)
					{
						XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)xtextElement_0;
						XmlElement xmlElement = (XmlElement)childNode;
						if (xmlElement.HasAttribute("title"))
						{
							xTextTableRowElement.HeaderStyle = Convert.ToBoolean(xmlElement.GetAttribute("title"));
						}
					}
				}
				else if (childNode.Name == "data")
				{
					XDataBinding xDataBinding = new XDataBinding();
					XmlElement xmlElement2 = (XmlElement)childNode;
					xDataBinding = new XDataBinding();
					xDataBinding.DataSource = xmlElement2.GetAttribute("table");
					xDataBinding.BindingPath = xmlElement2.GetAttribute("field");
					if (xmlElement2.HasAttribute("isrefresh"))
					{
						xDataBinding.AutoUpdate = Convert.ToBoolean(xmlElement2.GetAttribute("isrefresh"));
					}
					if (xtextElement_0 is XTextInputFieldElement)
					{
						((XTextInputFieldElement)xtextElement_0).ValueBinding = xDataBinding;
					}
					else if (xtextElement_0 is XTextCheckBoxElementBase)
					{
						((XTextCheckBoxElementBase)xtextElement_0).ValueBinding = xDataBinding;
					}
				}
				else if (childNode.Name == "custom")
				{
					XmlElement xmlElement2 = (XmlElement)childNode;
					string attribute = xmlElement2.GetAttribute("value");
					if (!string.IsNullOrEmpty(attribute) && xtextElement_0.Attributes != null)
					{
						xtextElement_0.SetAttribute("name" + xtextElement_0.Attributes.Count, attribute);
					}
				}
				else if (childNode.Name == "key")
				{
					foreach (XmlAttribute attribute2 in childNode.Attributes)
					{
						if (attribute2.Name == "name")
						{
							if (xtextElement_0 is XTextInputFieldElement)
							{
								((XTextInputFieldElement)xtextElement_0).Name = attribute2.Value;
							}
							else if (xtextElement_0 is XTextDocument)
							{
								((XTextDocument)xtextElement_0).Info.Title = attribute2.Value;
							}
						}
						else if (attribute2.Name == "id")
						{
							xtextElement_0.ID = attribute2.Value;
						}
						else if (attribute2.Name == "visible")
						{
							xtextElement_0.Visible = Convert.ToBoolean(attribute2.Value);
						}
						else if (attribute2.Name == "version")
						{
							if (xtextElement_0 is XTextDocument)
							{
								((XTextDocument)xtextElement_0).Info.Version = attribute2.Value;
							}
						}
						else if (attribute2.Name == "editor" && xtextElement_0 is XTextDocument)
						{
							((XTextDocument)xtextElement_0).Info.Operator = attribute2.Value;
						}
					}
				}
				else if (!(childNode.Name == "editright"))
				{
					if (childNode.Name == "title")
					{
						XmlElement xmlElement2 = (XmlElement)childNode;
						XTextStringElement xTextStringElement = new XTextStringElement();
						xTextStringElement.OwnerDocument = xtextElement_0.OwnerDocument;
						xTextStringElement.Text = xmlElement2.GetAttribute("text");
						xTextStringElement.Style.TitleLevel = 1;
						xtextElement_0.Elements.Add(xTextStringElement);
						method_5(xmlElement2, xTextStringElement);
					}
					else if (childNode.Name == "revision")
					{
						if (documentContentStyle == null)
						{
							documentContentStyle = new DocumentContentStyle();
						}
						XmlElement xmlElement3 = (XmlElement)childNode;
						if (xmlElement3.HasAttribute("creator"))
						{
							documentContentStyle.CreatorIndex = Convert.ToInt32(xmlElement3.GetAttribute("creator"));
						}
						if (xmlElement3.HasAttribute("deleter"))
						{
							documentContentStyle.DeleterIndex = Convert.ToInt32(xmlElement3.GetAttribute("deleter"));
						}
					}
					else if (childNode.Name == "font")
					{
						if (documentContentStyle == null)
						{
							documentContentStyle = new DocumentContentStyle();
						}
						foreach (XmlAttribute attribute3 in childNode.Attributes)
						{
							switch (attribute3.Name)
							{
							case "name":
								documentContentStyle.FontName = attribute3.Value;
								break;
							case "bgcolor":
								documentContentStyle.BackgroundColor = StringConvertHelper.ToColorValue(attribute3.Value, Color.Transparent);
								break;
							case "sup":
								documentContentStyle.Superscript = Convert.ToBoolean(attribute3.Value);
								break;
							case "sub":
								documentContentStyle.Subscript = Convert.ToBoolean(attribute3.Value);
								break;
							case "strikeout":
								documentContentStyle.Strikeout = Convert.ToBoolean(attribute3.Value);
								break;
							case "underline":
								documentContentStyle.Underline = Convert.ToBoolean(attribute3.Value);
								break;
							case "italic":
								documentContentStyle.Italic = Convert.ToBoolean(attribute3.Value);
								break;
							case "bold":
								documentContentStyle.Bold = Convert.ToBoolean(attribute3.Value);
								break;
							case "color":
								documentContentStyle.Color = StringConvertHelper.ToColorValue(attribute3.Value, Color.Black);
								break;
							case "size":
								documentContentStyle.FontSize = Convert.ToSingle(attribute3.Value);
								break;
							}
						}
					}
					else if (childNode.Name == "format")
					{
						if (documentContentStyle == null)
						{
							documentContentStyle = new DocumentContentStyle();
						}
						foreach (XmlAttribute attribute4 in childNode.Attributes)
						{
							switch (attribute4.Name)
							{
							case "leftindent":
								documentContentStyle.LeftIndent = Convert.ToInt32(attribute4.Value);
								break;
							case "firstindent":
								documentContentStyle.FirstLineIndent = Convert.ToInt32(attribute4.Value);
								break;
							case "linespacemode":
								if (attribute4.Value == "One")
								{
									documentContentStyle.LineSpacingStyle = LineSpacingStyle.SpaceSingle;
								}
								break;
							case "align":
								if (attribute4.Value == "Left")
								{
									documentContentStyle.Align = DocumentContentAlignment.Left;
								}
								else if (attribute4.Value == "Center")
								{
									documentContentStyle.Align = DocumentContentAlignment.Center;
								}
								else if (attribute4.Value == "Right")
								{
									documentContentStyle.Align = DocumentContentAlignment.Right;
								}
								else if (attribute4.Value == "Justify")
								{
									documentContentStyle.Align = DocumentContentAlignment.Justify;
								}
								break;
							}
						}
					}
				}
			}
			if (documentContentStyle != null)
			{
				xtextElement_0.StyleIndex = ownerDocument.ContentStyles.GetStyleIndex(documentContentStyle);
			}
		}

		private void method_6(XTextDocument xtextDocument_0, XmlElement xmlElement_0)
		{
			int num = 9;
			xtextDocument_0.UserHistories.Clear();
			XmlElement xmlElement = (XmlElement)XMLHelper.GetChildNode(xmlElement_0, "savelogs");
			if (xmlElement != null)
			{
				foreach (XmlNode childNode in xmlElement.ChildNodes)
				{
					if (childNode.Name == "savelog")
					{
						XmlElement xmlElement2 = (XmlElement)childNode;
						UserHistoryInfo userHistoryInfo = new UserHistoryInfo();
						if (xmlElement2.HasAttribute("time"))
						{
							userHistoryInfo.SavedTime = DateTime.Parse(xmlElement2.GetAttribute("time"));
						}
						if (xmlElement2.HasAttribute("level"))
						{
							int result = 0;
							if (int.TryParse(xmlElement2.GetAttribute("level"), out result))
							{
								userHistoryInfo.PermissionLevel = result;
							}
						}
						userHistoryInfo.ID = xmlElement2.GetAttribute("user");
						xtextDocument_0.UserHistories.Add(userHistoryInfo);
					}
				}
			}
		}

		private void method_7(XTextDocument xtextDocument_0, XmlElement xmlElement_0)
		{
			int num = 4;
			foreach (XmlAttribute attribute in xmlElement_0.Attributes)
			{
				switch (attribute.Name)
				{
				case "id":
					xtextDocument_0.ID = attribute.Value;
					break;
				case "title":
					xtextDocument_0.Info.Title = attribute.Value;
					break;
				case "filename":
					xtextDocument_0.FileName = attribute.Value;
					break;
				case "version":
					xtextDocument_0.Info.Version = attribute.Value;
					break;
				case "creator":
					xtextDocument_0.Info.Author = attribute.Value;
					break;
				case "createtime":
					xtextDocument_0.Info.CreationTime = DateTime.Parse(attribute.Value);
					break;
				case "modifier":
					xtextDocument_0.Info.Operator = attribute.Value;
					break;
				case "modifytime":
					xtextDocument_0.Info.LastModifiedTime = DateTime.Parse(attribute.Value);
					break;
				}
			}
		}

		private void method_8(XTextDocumentContentElement xtextDocumentContentElement_0, string string_16)
		{
			int num = 19;
			if (string_16 != null && string_16.Trim().Length != 0)
			{
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.LoadXml(string_16);
				XTextDocument ownerDocument = xtextDocumentContentElement_0.OwnerDocument;
				xtextDocumentContentElement_0.Elements.Clear();
				foreach (XmlNode childNode in xmlDocument.DocumentElement.ChildNodes)
				{
					if (childNode.Name == "text")
					{
						XmlElement xmlElement = (XmlElement)childNode;
						DocumentContentStyle documentContentStyle = new DocumentContentStyle();
						foreach (XmlAttribute attribute in xmlElement.Attributes)
						{
							switch (attribute.Name)
							{
							case "italic":
								documentContentStyle.Italic = true;
								break;
							case "center":
								documentContentStyle.Align = DocumentContentAlignment.Center;
								break;
							case "bold":
								documentContentStyle.Bold = true;
								break;
							case "fontsize":
								documentContentStyle.FontSize = Convert.ToSingle(attribute.Value);
								break;
							case "fontname":
								documentContentStyle.FontName = attribute.Value;
								break;
							}
						}
						string innerText = xmlElement.InnerText;
						if (!string.IsNullOrEmpty(innerText))
						{
							string[] array = VariableString.AnalyseVariableString(innerText, "[%", "%]");
							int styleIndex = ownerDocument.ContentStyles.GetStyleIndex(documentContentStyle);
							for (int i = 0; i < array.Length; i++)
							{
								string text = array[i];
								if (i % 2 == 1)
								{
									if (text == "pageindex")
									{
										XTextPageInfoElement xTextPageInfoElement = new XTextPageInfoElement();
										xTextPageInfoElement.ValueType = PageInfoValueType.PageIndex;
										xTextPageInfoElement.AutoHeight = true;
										xtextDocumentContentElement_0.Elements.Add(xTextPageInfoElement);
										xTextPageInfoElement.StyleIndex = styleIndex;
										text = null;
									}
									else if (text == "pagecount")
									{
										XTextPageInfoElement xTextPageInfoElement = new XTextPageInfoElement();
										xTextPageInfoElement.ValueType = PageInfoValueType.NumOfPages;
										xTextPageInfoElement.AutoHeight = true;
										xtextDocumentContentElement_0.Elements.Add(xTextPageInfoElement);
										xTextPageInfoElement.StyleIndex = styleIndex;
										text = null;
									}
								}
								if (!string.IsNullOrEmpty(text))
								{
									XTextElementList xTextElementList = ownerDocument.CreateTextElements(text, documentContentStyle, documentContentStyle);
									if (xTextElementList != null)
									{
										xtextDocumentContentElement_0.Elements.AddRange(xTextElementList);
									}
								}
							}
						}
						XTextParagraphFlagElement xTextParagraphFlagElement = (XTextParagraphFlagElement)ownerDocument.CreateElementByType(typeof(XTextParagraphFlagElement));
						xTextParagraphFlagElement.Style = documentContentStyle;
						xtextDocumentContentElement_0.Elements.Add(xTextParagraphFlagElement);
					}
				}
				xtextDocumentContentElement_0.FixElements();
			}
		}

		private void method_9(XTextContainerElement xtextContainerElement_0, XmlElement xmlElement_0)
		{
			int num = 8;
			_ = xtextContainerElement_0.OwnerDocument;
			foreach (XmlNode childNode in xmlElement_0.ChildNodes)
			{
				switch (childNode.Name)
				{
				case "roelement":
					method_19(xtextContainerElement_0, (XmlElement)childNode);
					break;
				case "table":
					method_35(xtextContainerElement_0, (XmlElement)childNode);
					break;
				case "br":
					xtextContainerElement_0.Elements.Add(new XTextLineBreakElement());
					break;
				case "p":
					method_33(xtextContainerElement_0, (XmlElement)childNode);
					break;
				case "paragraph":
					method_33(xtextContainerElement_0, (XmlElement)childNode);
					break;
				case "div":
					method_21(xtextContainerElement_0, (XmlElement)childNode);
					break;
				case "span":
					method_31(xtextContainerElement_0, (XmlElement)childNode);
					break;
				case "textflag":
					method_22(xtextContainerElement_0, (XmlElement)childNode);
					break;
				case "select":
					method_26(xtextContainerElement_0, (XmlElement)childNode);
					break;
				case "img":
					method_29(xtextContainerElement_0, (XmlElement)childNode);
					break;
				case "input":
					method_30(xtextContainerElement_0, (XmlElement)childNode);
					break;
				case "horizontalLine":
					method_20(xtextContainerElement_0, (XmlElement)childNode);
					break;
				case "macro":
					method_28(xtextContainerElement_0, (XmlElement)childNode);
					break;
				case "textelement":
					method_34(xtextContainerElement_0, (XmlElement)childNode);
					break;
				case "formelement":
					method_34(xtextContainerElement_0, (XmlElement)childNode);
					break;
				case "objectelement":
					method_27(xtextContainerElement_0, (XmlElement)childNode);
					break;
				case "range":
					method_25(xtextContainerElement_0, (XmlElement)childNode);
					break;
				case "panel":
					method_24(xtextContainerElement_0, (XmlElement)childNode);
					break;
				case "selement":
					method_17(xtextContainerElement_0, (XmlElement)childNode);
					break;
				case "helement":
					method_16(xtextContainerElement_0, (XmlElement)childNode);
					break;
				case "template":
					method_15(xtextContainerElement_0, (XmlElement)childNode);
					break;
				case "text":
					method_32(xtextContainerElement_0, (XmlElement)childNode);
					break;
				case "mensesformula":
					method_14(xtextContainerElement_0, (XmlElement)childNode);
					break;
				case "fnumelement":
					method_13(xtextContainerElement_0, (XmlElement)childNode);
					break;
				case "ftimeelement":
					method_12(xtextContainerElement_0, (XmlElement)childNode);
					break;
				case "fstrelement":
					method_11(xtextContainerElement_0, (XmlElement)childNode);
					break;
				case "btnelement":
					method_10(xtextContainerElement_0, (XmlElement)childNode);
					break;
				default:
					Debug.WriteLine("不识别的元素类型:" + childNode.Name);
					break;
				case "eof":
					break;
				}
			}
		}

		private void method_10(XTextContainerElement xtextContainerElement_0, XmlElement xmlElement_0)
		{
			int num = 17;
			XTextButtonElement xTextButtonElement = new XTextButtonElement();
			xtextContainerElement_0.AppendChildElement(xTextButtonElement);
			method_18(xTextButtonElement, xmlElement_0, bool_0: true);
			xTextButtonElement.Name = xmlElement_0.GetAttribute("name");
			xTextButtonElement.ID = xTextButtonElement.Name;
			if (xmlElement_0.HasAttribute("print"))
			{
				if (method_36(xmlElement_0.GetAttribute("print")))
				{
					xTextButtonElement.PrintVisibility = ElementVisibility.Visible;
				}
				else
				{
					xTextButtonElement.PrintVisibility = ElementVisibility.None;
				}
			}
			xTextButtonElement.Text = xmlElement_0.InnerText;
			xTextButtonElement.EventTemplateName = xmlElement_0.GetAttribute("event");
			if (xmlElement_0.HasAttribute("candelete"))
			{
				xTextButtonElement.Deleteable = method_36(xmlElement_0.GetAttribute("candelete"));
			}
		}

		private void method_11(XTextContainerElement xtextContainerElement_0, XmlElement xmlElement_0)
		{
			XTextStringElement xTextStringElement = new XTextStringElement();
			xtextContainerElement_0.AppendChildElement(xTextStringElement);
			method_18(xTextStringElement, xmlElement_0, bool_0: true);
			xTextStringElement.Text = xmlElement_0.InnerText;
		}

		private void method_12(XTextContainerElement xtextContainerElement_0, XmlElement xmlElement_0)
		{
			int num = 13;
			XTextInputFieldElement xTextInputFieldElement = new XTextInputFieldElement();
			xtextContainerElement_0.AppendChildElement(xTextInputFieldElement);
			xTextInputFieldElement.BackgroundText = xmlElement_0.GetAttribute("text");
			xTextInputFieldElement.FieldSettings = new InputFieldSettings();
			xTextInputFieldElement.FieldSettings.EditStyle = InputFieldEditStyle.DateTime;
			xTextInputFieldElement.Name = xmlElement_0.GetAttribute("name");
			xTextInputFieldElement.ID = xTextInputFieldElement.Name;
			method_18(xTextInputFieldElement, xmlElement_0, bool_0: true);
			xTextInputFieldElement.EventTemplateName = xmlElement_0.GetAttribute("event");
			xTextInputFieldElement.DisplayFormat = new ValueFormater();
			xTextInputFieldElement.DisplayFormat.Style = ValueFormatStyle.DateTime;
			if (xmlElement_0.HasAttribute("formatString"))
			{
				xTextInputFieldElement.DisplayFormat.Format = xmlElement_0.GetAttribute("formatString");
				xTextInputFieldElement.FieldSettings.EditStyle = WriterTools.GetEditStyleByDateTimeFormatString(xTextInputFieldElement.DisplayFormat.Format);
				if (string.IsNullOrEmpty(xTextInputFieldElement.BackgroundText))
				{
					xTextInputFieldElement.BackgroundText = xTextInputFieldElement.DisplayFormat.Format;
				}
			}
			xTextInputFieldElement.SetInnerTextFast(xmlElement_0.InnerText);
		}

		private void method_13(XTextContainerElement xtextContainerElement_0, XmlElement xmlElement_0)
		{
			int num = 0;
			XTextInputFieldElement xTextInputFieldElement = new XTextInputFieldElement();
			xtextContainerElement_0.AppendChildElement(xTextInputFieldElement);
			method_18(xTextInputFieldElement, xmlElement_0, bool_0: true);
			xTextInputFieldElement.FieldSettings = new InputFieldSettings();
			xTextInputFieldElement.FieldSettings.EditStyle = InputFieldEditStyle.Numeric;
			xTextInputFieldElement.Name = xmlElement_0.GetAttribute("name");
			xTextInputFieldElement.ValidateStyle = new ValueValidateStyle();
			xTextInputFieldElement.ValidateStyle.ValueType = ValueTypeStyle.Numeric;
			xTextInputFieldElement.SetInnerTextFast(xmlElement_0.InnerText);
			foreach (XmlAttribute attribute in xmlElement_0.Attributes)
			{
				switch (attribute.Name)
				{
				case "decimalDigits":
				{
					int num2 = Convert.ToInt32(attribute.Value);
					if (num2 > 0)
					{
						xTextInputFieldElement.ValidateStyle.MaxDecimalDigits = num2;
						xTextInputFieldElement.ValidateStyle.CheckDecimalDigits = true;
						xTextInputFieldElement.DisplayFormat = new ValueFormater();
						xTextInputFieldElement.DisplayFormat.Style = ValueFormatStyle.Numeric;
						xTextInputFieldElement.DisplayFormat.Format = "0." + new string('0', num2);
					}
					break;
				}
				case "minvalue":
					xTextInputFieldElement.ValidateStyle.MinValue = Convert.ToDouble(attribute.Value);
					xTextInputFieldElement.ValidateStyle.CheckMinValue = true;
					break;
				case "maxvalue":
					xTextInputFieldElement.ValidateStyle.MaxValue = Convert.ToDouble(attribute.Value);
					xTextInputFieldElement.ValidateStyle.CheckMaxValue = true;
					break;
				}
			}
		}

		private void method_14(XTextContainerElement xtextContainerElement_0, XmlElement xmlElement_0)
		{
			XTextMedicalExpressionFieldElement xTextMedicalExpressionFieldElement = new XTextMedicalExpressionFieldElement();
			xtextContainerElement_0.AppendChildElement(xTextMedicalExpressionFieldElement);
			method_18(xTextMedicalExpressionFieldElement, xmlElement_0, bool_0: true);
			xTextMedicalExpressionFieldElement.Name = xmlElement_0.GetAttribute("name");
			xTextMedicalExpressionFieldElement.SetInnerTextFast("value1,value2,value3,value4");
		}

		private void method_15(XTextContainerElement xtextContainerElement_0, XmlElement xmlElement_0)
		{
			XTextFileBlockElement xTextFileBlockElement = new XTextFileBlockElement();
			xtextContainerElement_0.AppendChildElement(xTextFileBlockElement);
			method_18(xTextFileBlockElement, xmlElement_0, bool_0: true);
			xTextFileBlockElement.Name = xmlElement_0.GetAttribute("name");
			xTextFileBlockElement.Text = xmlElement_0.InnerText;
		}

		private void method_16(XTextContainerElement xtextContainerElement_0, XmlElement xmlElement_0)
		{
			XTextStringElement xTextStringElement = new XTextStringElement();
			xTextStringElement.OwnerDocument = xtextContainerElement_0.OwnerDocument;
			xTextStringElement.Parent = xtextContainerElement_0;
			xtextContainerElement_0.Elements.Add(xTextStringElement);
			method_18(xTextStringElement, xmlElement_0, bool_0: true);
			xTextStringElement.Text = xmlElement_0.GetAttribute("text");
		}

		private void method_17(XTextContainerElement xtextContainerElement_0, XmlElement xmlElement_0)
		{
			int num = 18;
			XTextInputFieldElement xTextInputFieldElement = new XTextInputFieldElement();
			xTextInputFieldElement.OwnerDocument = xtextContainerElement_0.OwnerDocument;
			xTextInputFieldElement.Parent = xtextContainerElement_0;
			xtextContainerElement_0.Elements.Add(xTextInputFieldElement);
			method_18(xTextInputFieldElement, xmlElement_0, bool_0: true);
			xTextInputFieldElement.Name = xmlElement_0.GetAttribute("name");
			xTextInputFieldElement.BackgroundText = xTextInputFieldElement.Name;
			xTextInputFieldElement.FieldSettings = new InputFieldSettings();
			xTextInputFieldElement.SetInnerTextFast(xmlElement_0.GetAttribute("text"));
			xTextInputFieldElement.InnerValue = xmlElement_0.GetAttribute("code");
			if (xTextInputFieldElement.Text == xTextInputFieldElement.BackgroundText)
			{
				xTextInputFieldElement.Elements.Clear();
				xTextInputFieldElement.InnerValue = null;
			}
			switch (xmlElement_0.GetAttribute("type"))
			{
			case "singleelement":
				xTextInputFieldElement.FieldSettings.EditStyle = InputFieldEditStyle.DropdownList;
				break;
			case "multielement":
				xTextInputFieldElement.FieldSettings.EditStyle = InputFieldEditStyle.DropdownList;
				xTextInputFieldElement.FieldSettings.MultiSelect = true;
				break;
			default:
				xTextInputFieldElement.FieldSettings.EditStyle = InputFieldEditStyle.DropdownList;
				break;
			}
			xTextInputFieldElement.FieldSettings.ListSource = new ListSourceInfo();
			xTextInputFieldElement.FieldSettings.ListSource.Items = new ListItemCollection();
			foreach (XmlNode childNode in xmlElement_0.ChildNodes)
			{
				if (childNode.Name == "item")
				{
					ListItem listItem = new ListItem();
					foreach (XmlAttribute attribute in childNode.Attributes)
					{
						if (attribute.Name == "code")
						{
							listItem.Value = attribute.Value;
						}
						else if (attribute.Name == "group")
						{
							listItem.Group = attribute.Name;
						}
						else if (attribute.Name == "selected")
						{
						}
					}
					listItem.Text = childNode.InnerText;
					xTextInputFieldElement.FieldSettings.ListSource.Items.Add(listItem);
				}
			}
		}

		private void method_18(XTextElement xtextElement_0, XmlElement xmlElement_0, bool bool_0)
		{
			int num = 12;
			if (bool_0 && !(xtextElement_0 is XTextStringElement))
			{
				method_3(xmlElement_0, xtextElement_0);
			}
			foreach (XmlAttribute attribute in xmlElement_0.Attributes)
			{
				switch (attribute.Name)
				{
				case "id":
					xtextElement_0.ID = attribute.Value;
					break;
				case "fontname":
					xtextElement_0.Style.FontName = attribute.Value;
					break;
				case "fontsize":
					xtextElement_0.Style.FontSize = float.Parse(attribute.Value);
					break;
				case "fontbold":
					xtextElement_0.Style.Bold = method_36(attribute.Value);
					break;
				case "fontunderline":
					xtextElement_0.Style.Underline = method_36(attribute.Value);
					break;
				case "fontitalice":
					xtextElement_0.Style.Italic = method_36(attribute.Value);
					break;
				case "sup":
					xtextElement_0.Style.Superscript = method_36(attribute.Value);
					break;
				case "sub":
					xtextElement_0.Style.Subscript = method_36(attribute.Value);
					break;
				case "forecolor":
					xtextElement_0.Style.Color = smethod_0(attribute.Value, Color.Black);
					break;
				case "creator":
					xtextElement_0.Style.CreatorIndex = Convert.ToInt32(attribute.Value);
					break;
				case "deleter":
					xtextElement_0.Style.DeleterIndex = Convert.ToInt32(attribute.Value);
					break;
				case "border-color":
					xtextElement_0.Style.BorderColor = smethod_0(attribute.Value, Color.Black);
					break;
				case "border-width":
					xtextElement_0.Style.BorderWidth = Convert.ToInt32(attribute.Value);
					break;
				case "border-style":
					xtextElement_0.Style.BorderStyle = (DashStyle)Enum.Parse(typeof(DashStyle), attribute.Value);
					break;
				case "background-color":
					xtextElement_0.Style.BackgroundColor = smethod_0(attribute.Value, Color.White);
					break;
				}
			}
		}

		private void method_19(XTextContainerElement xtextContainerElement_0, XmlElement xmlElement_0)
		{
			XTextStringElement xTextStringElement = new XTextStringElement();
			xTextStringElement.OwnerDocument = xtextContainerElement_0.OwnerDocument;
			xTextStringElement.Parent = xtextContainerElement_0;
			xTextStringElement.Text = xmlElement_0.InnerText;
			method_18(xTextStringElement, xmlElement_0, bool_0: true);
			xtextContainerElement_0.Elements.Add(xTextStringElement);
		}

		private void method_20(XTextContainerElement xtextContainerElement_0, XmlElement xmlElement_0)
		{
			int num = 9;
			XTextHorizontalLineElement xTextHorizontalLineElement = new XTextHorizontalLineElement();
			xTextHorizontalLineElement.OwnerDocument = xtextContainerElement_0.OwnerDocument;
			xTextHorizontalLineElement.Parent = xtextContainerElement_0;
			foreach (XmlAttribute attribute in xmlElement_0.Attributes)
			{
				if (attribute.Name == "lineheight")
				{
					xTextHorizontalLineElement.LineSize = Convert.ToSingle(attribute.Value) * 3f;
				}
			}
			xtextContainerElement_0.Elements.Add(xTextHorizontalLineElement);
		}

		private void method_21(XTextContainerElement xtextContainerElement_0, XmlElement xmlElement_0)
		{
			int num = 7;
			XTextInputFieldElement xTextInputFieldElement = new XTextInputFieldElement();
			xTextInputFieldElement.OwnerDocument = xtextContainerElement_0.OwnerDocument;
			xTextInputFieldElement.Parent = xtextContainerElement_0;
			string text = null;
			if (xmlElement_0.HasAttribute("title"))
			{
				text = (xTextInputFieldElement.Name = xmlElement_0.GetAttribute("title"));
			}
			xTextInputFieldElement.Name = text;
			xTextInputFieldElement.EnableHighlight = EnableState.Disabled;
			method_18(xTextInputFieldElement, xmlElement_0, bool_0: true);
			if (!string.IsNullOrEmpty(text))
			{
				XTextStringElement xTextStringElement = new XTextStringElement();
				xTextStringElement.Text = text;
				xtextContainerElement_0.AppendChildElement(new XTextParagraphFlagElement());
				xtextContainerElement_0.AppendChildElement(xTextStringElement);
			}
			method_9(xTextInputFieldElement, xmlElement_0);
		}

		private void method_22(XTextContainerElement xtextContainerElement_0, XmlElement xmlElement_0)
		{
			int num = 6;
			XTextStringElement xTextStringElement = new XTextStringElement();
			if (xmlElement_0.HasAttribute("text"))
			{
				xTextStringElement.Text = xmlElement_0.GetAttribute("text");
			}
			method_18(xTextStringElement, xmlElement_0, bool_0: true);
			xtextContainerElement_0.Elements.Add(xTextStringElement);
		}

		private void method_23(XTextDocument xtextDocument_0, XmlElement xmlElement_0)
		{
			int num = 10;
			xtextDocument_0.PageSettings = new XPageSettings();
			foreach (XmlAttribute attribute in xmlElement_0.Attributes)
			{
				switch (attribute.Name)
				{
				case "papertype":
					try
					{
						xtextDocument_0.PageSettings.PaperKind = (PaperKind)Enum.Parse(typeof(PaperKind), attribute.Value);
					}
					catch
					{
					}
					break;
				case "leftmarginCM":
					xtextDocument_0.PageSettings.LeftMargin = (int)(GraphicsUnitConvert.ConvertFromCM(Convert.ToSingle(attribute.Value), GraphicsUnit.Inch) * 100f);
					break;
				case "topmarginCM":
					xtextDocument_0.PageSettings.TopMargin = (int)(GraphicsUnitConvert.ConvertFromCM(Convert.ToSingle(attribute.Value), GraphicsUnit.Inch) * 100f);
					break;
				case "rightmarginCM":
					xtextDocument_0.PageSettings.RightMargin = (int)(GraphicsUnitConvert.ConvertFromCM(Convert.ToSingle(attribute.Value), GraphicsUnit.Inch) * 100f);
					break;
				case "bottommarginCM":
					xtextDocument_0.PageSettings.BottomMargin = (int)(GraphicsUnitConvert.ConvertFromCM(Convert.ToSingle(attribute.Value), GraphicsUnit.Inch) * 100f);
					break;
				case "landscape":
					xtextDocument_0.PageSettings.Landscape = Convert.ToBoolean(attribute.Value);
					break;
				case "headerheightCM":
					xtextDocument_0.PageSettings.HeaderDistance = (int)(GraphicsUnitConvert.ConvertFromCM(Convert.ToSingle(attribute.Value), GraphicsUnit.Inch) * 100f);
					break;
				case "footerheightCM":
					xtextDocument_0.PageSettings.FooterDistance = (int)(GraphicsUnitConvert.ConvertFromCM(Convert.ToSingle(attribute.Value), GraphicsUnit.Inch) * 100f);
					break;
				case "width":
					xtextDocument_0.PageSettings.PaperWidth = Convert.ToInt32(attribute.Value);
					break;
				case "height":
					xtextDocument_0.PageSettings.PaperHeight = Convert.ToInt32(attribute.Value);
					break;
				}
			}
			foreach (XmlNode childNode in xmlElement_0.ChildNodes)
			{
				if (childNode.Name == "page")
				{
					XmlElement xmlElement = (XmlElement)childNode;
					if (xmlElement.HasAttribute("width"))
					{
						xtextDocument_0.PageSettings.PaperWidth = Convert.ToInt32(xmlElement.GetAttribute("width"));
					}
					if (xmlElement.HasAttribute("height"))
					{
						xtextDocument_0.PageSettings.PaperHeight = Convert.ToInt32(xmlElement.GetAttribute("height"));
					}
					if (xmlElement.HasAttribute("kind"))
					{
						xtextDocument_0.PageSettings.PaperKind = (PaperKind)Enum.Parse(typeof(PaperKind), xmlElement.GetAttribute("kind"));
					}
				}
				else if (childNode.Name == "margins")
				{
					XmlElement xmlElement = (XmlElement)childNode;
					if (xmlElement.HasAttribute("left"))
					{
						xtextDocument_0.PageSettings.LeftMargin = Convert.ToInt32(xmlElement.GetAttribute("left"));
					}
					if (xmlElement.HasAttribute("top"))
					{
						xtextDocument_0.PageSettings.TopMargin = Convert.ToInt32(xmlElement.GetAttribute("top"));
					}
					if (xmlElement.HasAttribute("right"))
					{
						xtextDocument_0.PageSettings.RightMargin = Convert.ToInt32(xmlElement.GetAttribute("right"));
					}
					if (xmlElement.HasAttribute("bottom"))
					{
						xtextDocument_0.PageSettings.BottomMargin = Convert.ToInt32(xmlElement.GetAttribute("bottom"));
					}
				}
				else if (childNode.Name == "landscape")
				{
					XmlElement xmlElement = (XmlElement)childNode;
					if (xmlElement.HasAttribute("value"))
					{
						xtextDocument_0.PageSettings.Landscape = Convert.ToBoolean(xmlElement.GetAttribute("value"));
					}
				}
			}
		}

		private void method_24(XTextContainerElement xtextContainerElement_0, XmlElement xmlElement_0)
		{
			if (xtextContainerElement_0 is XTextDocumentBodyElement)
			{
				XTextSectionElement xTextSectionElement = new XTextSectionElement();
				xTextSectionElement.OwnerDocument = xtextContainerElement_0.OwnerDocument;
				xTextSectionElement.CompressOwnerLineSpacing = true;
				xtextContainerElement_0.Elements.Add(xTextSectionElement);
				method_18(xTextSectionElement, xmlElement_0, bool_0: true);
				method_9(xTextSectionElement, xmlElement_0);
			}
			else
			{
				method_9(xtextContainerElement_0, xmlElement_0);
			}
		}

		private void method_25(XTextContainerElement xtextContainerElement_0, XmlElement xmlElement_0)
		{
			int num = 5;
			XTextStringElement xTextStringElement = new XTextStringElement();
			xTextStringElement.OwnerDocument = xtextContainerElement_0.OwnerDocument;
			bool flag = false;
			foreach (XmlNode childNode in xmlElement_0.ChildNodes)
			{
				if (childNode.Name == "text")
				{
					xTextStringElement.Text = childNode.InnerText;
					flag = true;
				}
			}
			if (!flag)
			{
				xTextStringElement.Text = xmlElement_0.InnerText;
			}
			method_18(xTextStringElement, xmlElement_0, bool_0: true);
			xtextContainerElement_0.Elements.Add(xTextStringElement);
		}

		private void method_26(XTextContainerElement xtextContainerElement_0, XmlElement xmlElement_0)
		{
			int num = 10;
			XTextInputFieldElement xTextInputFieldElement = new XTextInputFieldElement();
			xTextInputFieldElement.FieldSettings = new InputFieldSettings();
			xTextInputFieldElement.FieldSettings.ListSource = new ListSourceInfo();
			xTextInputFieldElement.FieldSettings.ListSource.Items = new ListItemCollection();
			xTextInputFieldElement.FieldSettings.EditStyle = InputFieldEditStyle.DropdownList;
			xTextInputFieldElement.ValueBinding = new XDataBinding();
			xTextInputFieldElement.ValueBinding.AutoUpdate = false;
			xTextInputFieldElement.OwnerDocument = xtextContainerElement_0.OwnerDocument;
			xTextInputFieldElement.Parent = xtextContainerElement_0;
			foreach (XmlAttribute attribute in xmlElement_0.Attributes)
			{
				if (attribute.Name == "source")
				{
					if (xTextInputFieldElement.ValueBinding == null)
					{
						xTextInputFieldElement.ValueBinding = new XDataBinding();
					}
					xTextInputFieldElement.ValueBinding.DataSource = attribute.Value;
				}
				else if (attribute.Name == "listsource")
				{
					if (xTextInputFieldElement.FieldSettings == null)
					{
						xTextInputFieldElement.FieldSettings = new InputFieldSettings();
					}
					xTextInputFieldElement.FieldSettings.ListSource.SourceName = attribute.Value;
				}
				else if (attribute.Name == "multiple")
				{
					if (xTextInputFieldElement.FieldSettings == null)
					{
						xTextInputFieldElement.FieldSettings = new InputFieldSettings();
					}
					xTextInputFieldElement.FieldSettings.MultiSelect = method_36(attribute.Value);
				}
				else if (attribute.Name == "value")
				{
					xTextInputFieldElement.InnerValue = attribute.Value;
				}
				else if (attribute.Name == "text")
				{
					string value = attribute.Value;
					if (value.StartsWith("[") && value.EndsWith("]"))
					{
						xTextInputFieldElement.BackgroundText = value.Substring(1, value.Length - 2);
					}
					else
					{
						xTextInputFieldElement.SetInnerTextFast(value);
					}
				}
				else if (attribute.Name == "name")
				{
					xTextInputFieldElement.Name = attribute.Value;
					if (string.IsNullOrEmpty(xTextInputFieldElement.BackgroundText))
					{
						xTextInputFieldElement.BackgroundText = xTextInputFieldElement.Name;
					}
				}
				else if (attribute.Name == "creator")
				{
					xTextInputFieldElement.Style.CreatorIndex = Convert.ToInt32(attribute.Value);
				}
				else if (attribute.Name == "deleter")
				{
					xTextInputFieldElement.Style.DeleterIndex = Convert.ToInt32(attribute.Value);
				}
			}
			foreach (XmlNode childNode in xmlElement_0.ChildNodes)
			{
				if (childNode.Name == "option")
				{
					XmlElement xmlElement = (XmlElement)childNode;
					ListItem listItem = new ListItem();
					listItem.Text = xmlElement.GetAttribute("text");
					listItem.Value = xmlElement.GetAttribute("value");
					xTextInputFieldElement.FieldSettings.ListSource.Items.Add(listItem);
				}
			}
			xtextContainerElement_0.Elements.Add(xTextInputFieldElement);
		}

		private void method_27(XTextContainerElement xtextContainerElement_0, XmlElement xmlElement_0)
		{
			int num = 11;
			XTextImageElement xTextImageElement = new XTextImageElement();
			xTextImageElement.OwnerDocument = xtextContainerElement_0.OwnerDocument;
			xTextImageElement.Parent = xtextContainerElement_0;
			xtextContainerElement_0.Elements.Add(xTextImageElement);
			method_18(xTextImageElement, xmlElement_0, bool_0: true);
			XmlElement xmlElement = (XmlElement)XMLHelper.GetChildNode(xmlElement_0, "image");
			if (xmlElement != null)
			{
				string innerText = xmlElement.InnerText;
				XImageValue xImageValue = new XImageValue();
				xImageValue.LoadBase64String(innerText);
				xTextImageElement.Image = xImageValue;
				xTextImageElement.Width = GraphicsUnitConvert.Convert(xImageValue.Width, GraphicsUnit.Pixel, GraphicsUnit.Document);
				xTextImageElement.Height = GraphicsUnitConvert.Convert(xImageValue.Height, GraphicsUnit.Pixel, GraphicsUnit.Document);
			}
			if (xmlElement_0.HasAttribute("width"))
			{
				xTextImageElement.Width = method_4(xmlElement_0.GetAttribute("width"));
			}
			if (xmlElement_0.HasAttribute("height"))
			{
				xTextImageElement.Height = method_4(xmlElement_0.GetAttribute("height"));
			}
		}

		private void method_28(XTextContainerElement xtextContainerElement_0, XmlElement xmlElement_0)
		{
			int num = 13;
			XTextInputFieldElement xTextInputFieldElement = new XTextInputFieldElement();
			xTextInputFieldElement.OwnerDocument = xtextContainerElement_0.OwnerDocument;
			xTextInputFieldElement.Parent = xtextContainerElement_0;
			foreach (XmlAttribute attribute in xmlElement_0.Attributes)
			{
				if (attribute.Name == "fontbold")
				{
					xTextInputFieldElement.Style.Bold = method_36(attribute.Value);
				}
				else if (attribute.Name == "fontsize")
				{
					xTextInputFieldElement.Style.FontSize = Convert.ToSingle(attribute.Value);
				}
				else if (attribute.Name == "fontname")
				{
					xTextInputFieldElement.Style.FontName = attribute.Value;
				}
				else if (attribute.Name == "name")
				{
					xTextInputFieldElement.ID = attribute.Value;
					xTextInputFieldElement.Name = attribute.Value;
					xTextInputFieldElement.ValueBinding = new XDataBinding();
					xTextInputFieldElement.ValueBinding.DataSource = xTextInputFieldElement.Name;
				}
			}
			method_18(xTextInputFieldElement, xmlElement_0, bool_0: true);
			xTextInputFieldElement.BackgroundText = xmlElement_0.InnerText;
			xtextContainerElement_0.Elements.Add(xTextInputFieldElement);
		}

		private void method_29(XTextContainerElement xtextContainerElement_0, XmlElement xmlElement_0)
		{
			int num = 13;
			XTextImageElement xTextImageElement = new XTextImageElement();
			xTextImageElement.OwnerDocument = xtextContainerElement_0.OwnerDocument;
			xTextImageElement.Parent = xtextContainerElement_0;
			string innerText = xmlElement_0.InnerText;
			if (!string.IsNullOrEmpty(innerText))
			{
				xTextImageElement.ImageData = Convert.FromBase64String(innerText);
			}
			xTextImageElement.UpdateSize(keepSizePossible: false);
			foreach (XmlAttribute attribute in xmlElement_0.Attributes)
			{
				if (attribute.Name == "src")
				{
					xTextImageElement.Source = attribute.Value;
				}
				else if (attribute.Name == "saveinfile")
				{
					xTextImageElement.SaveContentInFile = method_36(attribute.Value);
				}
				else if (attribute.Name == "width")
				{
					xTextImageElement.Width = Convert.ToInt32(attribute.Value);
				}
				else if (attribute.Name == "height")
				{
					xTextImageElement.Height = Convert.ToInt32(attribute.Value);
				}
			}
			xtextContainerElement_0.Elements.Add(xTextImageElement);
		}

		private void method_30(XTextContainerElement xtextContainerElement_0, XmlElement xmlElement_0)
		{
			int num = 12;
			XTextInputFieldElement xTextInputFieldElement = new XTextInputFieldElement();
			xTextInputFieldElement.OwnerDocument = xtextContainerElement_0.OwnerDocument;
			xTextInputFieldElement.Parent = xtextContainerElement_0;
			foreach (XmlAttribute attribute in xmlElement_0.Attributes)
			{
				if (attribute.Name == "source")
				{
					if (xTextInputFieldElement.ValueBinding == null)
					{
						xTextInputFieldElement.ValueBinding = new XDataBinding();
					}
					xTextInputFieldElement.ValueBinding.DataSource = attribute.Value;
				}
				else if (attribute.Name == "unit")
				{
					xTextInputFieldElement.UnitText = attribute.Value;
				}
				else if (attribute.Name == "name")
				{
					xTextInputFieldElement.Name = attribute.Value;
					if (string.IsNullOrEmpty(xTextInputFieldElement.BackgroundText))
					{
						xTextInputFieldElement.BackgroundText = attribute.Value;
					}
					xTextInputFieldElement.ID = xTextInputFieldElement.Name;
				}
			}
			method_18(xTextInputFieldElement, xmlElement_0, bool_0: true);
			string innerText = xmlElement_0.InnerText;
			if (!string.IsNullOrEmpty(innerText))
			{
				xTextInputFieldElement.SetInnerTextFast(innerText);
			}
			xtextContainerElement_0.Elements.Add(xTextInputFieldElement);
		}

		private void method_31(XTextContainerElement xtextContainerElement_0, XmlElement xmlElement_0)
		{
			int num = 11;
			XTextStringElement xTextStringElement = new XTextStringElement();
			xTextStringElement.OwnerDocument = xtextContainerElement_0.OwnerDocument;
			xTextStringElement.Parent = xtextContainerElement_0;
			xTextStringElement.Text = xmlElement_0.InnerText;
			method_18(xTextStringElement, xmlElement_0, bool_0: true);
			foreach (XmlAttribute attribute in xmlElement_0.Attributes)
			{
				if (attribute.Name == "type")
				{
				}
			}
			xtextContainerElement_0.Elements.Add(xTextStringElement);
		}

		private void method_32(XTextContainerElement xtextContainerElement_0, XmlElement xmlElement_0)
		{
			int num = 5;
			XTextStringElement xTextStringElement = new XTextStringElement();
			xTextStringElement.OwnerDocument = xtextContainerElement_0.OwnerDocument;
			xTextStringElement.Parent = xtextContainerElement_0;
			xTextStringElement.Text = xmlElement_0.InnerText;
			method_18(xTextStringElement, xmlElement_0, bool_0: true);
			foreach (XmlAttribute attribute in xmlElement_0.Attributes)
			{
				if (attribute.Name == "type")
				{
				}
			}
			xtextContainerElement_0.Elements.Add(xTextStringElement);
		}

		private void method_33(XTextContainerElement xtextContainerElement_0, XmlElement xmlElement_0)
		{
			int num = 5;
			XTextDocument ownerDocument = xtextContainerElement_0.OwnerDocument;
			XTextParagraphFlagElement xTextParagraphFlagElement = new XTextParagraphFlagElement();
			xTextParagraphFlagElement.OwnerDocument = ownerDocument;
			xTextParagraphFlagElement.Parent = xtextContainerElement_0;
			method_3(xmlElement_0, xTextParagraphFlagElement);
			foreach (XmlAttribute attribute in xmlElement_0.Attributes)
			{
				if (attribute.Name == "align")
				{
					if (attribute.Value == "0")
					{
						xTextParagraphFlagElement.Style.Align = DocumentContentAlignment.Left;
					}
					else if (attribute.Value == "1")
					{
						xTextParagraphFlagElement.Style.Align = DocumentContentAlignment.Right;
					}
					else if (attribute.Value == "2")
					{
						xTextParagraphFlagElement.Style.Align = DocumentContentAlignment.Center;
					}
					else if (attribute.Value == "4")
					{
						xTextParagraphFlagElement.Style.Align = DocumentContentAlignment.Justify;
					}
				}
			}
			if (xmlElement_0.ChildNodes.Count > 0)
			{
				method_9(xtextContainerElement_0, xmlElement_0);
			}
			foreach (XmlNode childNode in xmlElement_0.ChildNodes)
			{
				if (childNode.Name == "eof")
				{
					foreach (XmlAttribute attribute2 in childNode.Attributes)
					{
						if (attribute2.Name == "fontsize")
						{
							xTextParagraphFlagElement.Style.FontSize = Convert.ToSingle(attribute2.Value);
						}
					}
				}
			}
			xtextContainerElement_0.Elements.Add(xTextParagraphFlagElement);
		}

		private void method_34(XTextContainerElement xtextContainerElement_0, XmlElement xmlElement_0)
		{
			int num = 7;
			string attribute = xmlElement_0.GetAttribute("type");
			if (attribute == "radiobutton" || attribute == "checkbox")
			{
				XTextCheckBoxElementBase xTextCheckBoxElementBase = null;
				if (attribute == "radiobutton")
				{
					xTextCheckBoxElementBase = new XTextRadioBoxElement();
				}
				else if (attribute == "checkbox")
				{
					xTextCheckBoxElementBase = new XTextCheckBoxElement();
				}
				xtextContainerElement_0.Elements.Add(xTextCheckBoxElementBase);
				xTextCheckBoxElementBase.Multiline = false;
				method_18(xTextCheckBoxElementBase, xmlElement_0, bool_0: true);
				foreach (XmlAttribute attribute2 in xmlElement_0.Attributes)
				{
					switch (attribute2.Name)
					{
					case "value":
						xTextCheckBoxElementBase.CheckedValue = attribute2.Value;
						break;
					case "checked":
						xTextCheckBoxElementBase.Checked = method_36(attribute2.Value);
						break;
					case "group":
						xTextCheckBoxElementBase.Name = attribute2.Value;
						break;
					}
				}
				foreach (XmlNode childNode in xmlElement_0.ChildNodes)
				{
					if (childNode.Name == "text")
					{
						xTextCheckBoxElementBase.Caption = childNode.InnerText;
					}
				}
			}
			if (attribute == "textbox" || attribute == "datetime")
			{
				XTextInputFieldElement xTextInputFieldElement = new XTextInputFieldElement();
				xtextContainerElement_0.Elements.Add(xTextInputFieldElement);
				xTextInputFieldElement.FieldSettings = new InputFieldSettings();
				xTextInputFieldElement.OwnerDocument = xtextContainerElement_0.OwnerDocument;
				xTextInputFieldElement.Parent = xtextContainerElement_0;
				if (xmlElement_0.Name == "textelement")
				{
					xTextInputFieldElement.EnableHighlight = EnableState.Disabled;
				}
				method_18(xTextInputFieldElement, xmlElement_0, bool_0: true);
				if (attribute == "text")
				{
					xTextInputFieldElement.FieldSettings.EditStyle = InputFieldEditStyle.Text;
				}
				else if (attribute == "datetime")
				{
					xTextInputFieldElement.FieldSettings.EditStyle = InputFieldEditStyle.DateTime;
				}
				foreach (XmlAttribute attribute3 in xmlElement_0.Attributes)
				{
					if (attribute3.Name == "dateformat")
					{
						xTextInputFieldElement.DisplayFormat = new ValueFormater();
						xTextInputFieldElement.DisplayFormat.Style = ValueFormatStyle.DateTime;
						xTextInputFieldElement.DisplayFormat.Format = attribute3.Value;
						xTextInputFieldElement.FieldSettings.EditStyle = WriterTools.GetEditStyleByDateTimeFormatString(attribute3.Value);
					}
					else if (attribute3.Name == "isNotNull")
					{
						if (Convert.ToBoolean(attribute3.Value))
						{
							xTextInputFieldElement.ValidateStyle = new ValueValidateStyle();
							xTextInputFieldElement.ValidateStyle.Required = true;
						}
					}
					else if (attribute3.Name == "defaulttext")
					{
						xTextInputFieldElement.BackgroundText = attribute3.Value;
					}
					else if (attribute3.Name == "maskChar")
					{
						if (!string.IsNullOrEmpty(attribute3.Value))
						{
							xTextInputFieldElement.ViewEncryptType = ContentViewEncryptType.Both;
						}
					}
					else if (attribute3.Name == "annotation")
					{
						xTextInputFieldElement.ToolTip = attribute3.Value;
					}
				}
				foreach (XmlNode childNode2 in xmlElement_0.ChildNodes)
				{
					if (childNode2.Name == "text")
					{
						string innerText = childNode2.InnerText;
						if (innerText != xTextInputFieldElement.BackgroundText)
						{
							xTextInputFieldElement.SetInnerTextFast(childNode2.InnerText);
						}
					}
					else if (childNode2.Name == "options")
					{
						xTextInputFieldElement.FieldSettings.EditStyle = InputFieldEditStyle.DropdownList;
						xTextInputFieldElement.FieldSettings.ListSource = new ListSourceInfo();
						xTextInputFieldElement.FieldSettings.ListSource.Items = new ListItemCollection();
						foreach (XmlNode childNode3 in childNode2.ChildNodes)
						{
							if (childNode3.Name == "option")
							{
								XmlElement xmlElement = (XmlElement)childNode3;
								ListItem listItem = new ListItem();
								listItem.Text = xmlElement.GetAttribute("text");
								listItem.Value = xmlElement.GetAttribute("value");
								xTextInputFieldElement.FieldSettings.ListSource.Items.Add(listItem);
							}
						}
					}
				}
			}
		}

		private void method_35(XTextContainerElement xtextContainerElement_0, XmlElement xmlElement_0)
		{
			int num = 17;
			XTextDocument ownerDocument = xtextContainerElement_0.OwnerDocument;
			XTextTableElement xTextTableElement = (XTextTableElement)ownerDocument.CreateElementByType(typeof(XTextTableElement));
			xTextTableElement.OwnerDocument = ownerDocument;
			xTextTableElement.Parent = xtextContainerElement_0;
			xtextContainerElement_0.Elements.Add(xTextTableElement);
			method_18(xTextTableElement, xmlElement_0, bool_0: true);
			bool flag = false;
			foreach (XmlAttribute attribute in xmlElement_0.Attributes)
			{
				if (attribute.Name == "ChangeSize")
				{
					xTextTableElement.AllowUserToResizeColumns = Convert.ToBoolean(attribute.Value);
					xTextTableElement.AllowUserToResizeRows = xTextTableElement.AllowUserToResizeColumns;
				}
				else if (attribute.Name == "hidden-all-border")
				{
					flag = method_36(attribute.Value);
				}
			}
			foreach (XmlNode childNode in xmlElement_0.ChildNodes)
			{
				if (childNode.Name == "tablegrid")
				{
					foreach (XmlNode childNode2 in childNode.ChildNodes)
					{
						if (childNode2.Name == "tablecol")
						{
							XmlElement xmlElement = (XmlElement)childNode2;
							XTextTableColumnElement xTextTableColumnElement = new XTextTableColumnElement();
							xTextTableElement.Columns.Add(xTextTableColumnElement);
							xTextTableColumnElement.ID = xmlElement.GetAttribute("id");
							if (xmlElement.HasAttribute("width"))
							{
								xTextTableColumnElement.Width = method_4(xmlElement.GetAttribute("width"));
							}
						}
					}
				}
				else if (childNode.Name == "table-column")
				{
					foreach (XmlNode childNode3 in childNode.ChildNodes)
					{
						if (childNode3.Name == "column-width")
						{
							XTextTableColumnElement xTextTableColumnElement2 = xTextTableElement.CreateColumnInstance();
							xTextTableColumnElement2.Parent = xTextTableElement;
							xTextTableColumnElement2.OwnerDocument = ownerDocument;
							XmlElement xmlElement = (XmlElement)childNode3;
							if (xmlElement.HasAttribute("width"))
							{
								xTextTableColumnElement2.Width = Convert.ToSingle(xmlElement.GetAttribute("width"));
							}
							xTextTableElement.Columns.Add(xTextTableColumnElement2);
						}
					}
				}
				else if (childNode.Name == "col")
				{
					XTextTableColumnElement xTextTableColumnElement2 = xTextTableElement.CreateColumnInstance();
					xTextTableColumnElement2.Parent = xTextTableElement;
					xTextTableColumnElement2.OwnerDocument = ownerDocument;
					XmlElement xmlElement = (XmlElement)childNode;
					if (xmlElement.HasAttribute("width"))
					{
						int result = 0;
						if (int.TryParse(xmlElement.GetAttribute("width"), out result))
						{
							xTextTableColumnElement2.Width = result;
						}
					}
					xTextTableElement.Columns.Add(xTextTableColumnElement2);
				}
			}
			foreach (XmlNode childNode4 in xmlElement_0.ChildNodes)
			{
				if (childNode4.Name == "row" || childNode4.Name == "table-row" || childNode4.Name == "tablerow")
				{
					XmlElement xmlElement2 = (XmlElement)childNode4;
					XTextTableRowElement xTextTableRowElement = xTextTableElement.CreateRowInstance();
					xTextTableRowElement.Parent = xTextTableElement;
					xTextTableRowElement.OwnerDocument = ownerDocument;
					if (xmlElement2.HasAttribute("height"))
					{
						int result2 = 0;
						if (int.TryParse(xmlElement2.GetAttribute("height"), out result2))
						{
							xTextTableRowElement.SpecifyHeight = result2;
						}
					}
					xTextTableElement.Rows.Add(xTextTableRowElement);
					foreach (XmlNode childNode5 in xmlElement2.ChildNodes)
					{
						if (childNode5.Name == "cell" || childNode5.Name == "table-cell" || childNode5.Name == "tablecell")
						{
							XmlElement xmlElement_ = (XmlElement)childNode5;
							XTextTableCellElement xTextTableCellElement = xTextTableElement.CreateCellInstance();
							xTextTableCellElement.Elements.Clear();
							xTextTableRowElement.Cells.Add(xTextTableCellElement);
							xTextTableCellElement.Parent = xTextTableRowElement;
							xTextTableCellElement.OwnerDocument = ownerDocument;
							if (flag)
							{
								xTextTableCellElement.Style.BorderWidth = 0f;
								xTextTableCellElement.Style.BorderLeft = false;
								xTextTableCellElement.Style.BorderTop = false;
								xTextTableCellElement.Style.BorderRight = false;
								xTextTableCellElement.Style.BorderBottom = false;
							}
							else
							{
								xTextTableCellElement.Style.BorderWidth = 1f;
								xTextTableCellElement.Style.BorderColor = Color.Black;
								xTextTableCellElement.Style.BorderStyle = DashStyle.Solid;
								xTextTableCellElement.Style.BorderLeft = true;
								xTextTableCellElement.Style.BorderTop = true;
								xTextTableCellElement.Style.BorderRight = true;
								xTextTableCellElement.Style.BorderBottom = true;
								xTextTableCellElement.Style.PaddingLeft = 15f;
							}
							foreach (XmlAttribute attribute2 in childNode5.Attributes)
							{
								switch (attribute2.Name)
								{
								case "rowspan":
									xTextTableCellElement.RowSpan = Convert.ToInt32(attribute2.Value);
									break;
								case "colspan":
									xTextTableCellElement.ColSpan = Convert.ToInt32(attribute2.Value);
									break;
								case "padding-left":
									xTextTableCellElement.Style.PaddingLeft = Convert.ToInt32(attribute2.Value);
									break;
								case "padding-top":
									xTextTableCellElement.Style.PaddingTop = Convert.ToInt32(attribute2.Value);
									break;
								case "padding-right":
									xTextTableCellElement.Style.PaddingRight = Convert.ToInt32(attribute2.Value);
									break;
								case "padding-bottom":
									xTextTableCellElement.Style.PaddingBottom = Convert.ToInt32(attribute2.Value);
									break;
								case "valign":
									if (attribute2.Value == "0")
									{
										xTextTableCellElement.Style.VerticalAlign = VerticalAlignStyle.Top;
									}
									else if (attribute2.Value == "1")
									{
										xTextTableCellElement.Style.VerticalAlign = VerticalAlignStyle.Middle;
									}
									else if (attribute2.Value == "2")
									{
										xTextTableCellElement.Style.VerticalAlign = VerticalAlignStyle.Bottom;
									}
									break;
								case "caninsertenter":
									if (!Convert.ToBoolean(attribute2.Value))
									{
										xTextTableCellElement.AcceptChildElementTypes2 = (ElementType)MathCommon.smethod_25(16777215, 1024, bool_0: false);
									}
									break;
								}
							}
							method_9(xTextTableCellElement, xmlElement_);
						}
					}
				}
			}
		}

		private bool method_36(string string_16)
		{
			int num = 15;
			return string_16 == "1" || string_16 == "true" || string_16 == "True";
		}

		private DateTime method_37(string string_16)
		{
			int num = 7;
			if (string_16 != null && string_16.Length == 12)
			{
				return DateTime.ParseExact(string_16, "yyyyMMddHHmmss", null);
			}
			return DateTime.Parse(string_16);
		}

		private static Color smethod_0(string string_16, Color color_2)
		{
			int num = 11;
			if (string_16 != null)
			{
				string_16 = string_16.ToUpper().Trim();
				if (string_16.StartsWith("#") && string_16.Length <= 7)
				{
					int num2 = 0;
					int num3 = 0;
					int num4 = 1;
					while (true)
					{
						if (num4 < string_16.Length)
						{
							num3 = "0123456789ABCDEF".IndexOf(string_16[num4]);
							if (num3 < 0)
							{
								break;
							}
							num2 = num2 * 16 + num3;
							num4++;
							continue;
						}
						Color baseColor = Color.FromArgb(num2);
						return Color.FromArgb(255, baseColor);
					}
					return color_2;
				}
				try
				{
					return Color.FromArgb(Convert.ToInt32(string_16));
				}
				catch
				{
					return color_2;
				}
			}
			return color_2;
		}
	}
}
