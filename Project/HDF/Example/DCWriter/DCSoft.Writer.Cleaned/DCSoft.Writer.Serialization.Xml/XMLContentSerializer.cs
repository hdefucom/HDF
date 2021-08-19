#define DEBUG
using DCSoft.Common;
using DCSoft.Writer.Dom;
using DCSoftDotfuscate;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace DCSoft.Writer.Serialization.Xml
{
	/// <summary>
	///       标准的XML内容编码器
	///       </summary>
	internal class XMLContentSerializer : ContentSerializer
	{
		private static XMLContentSerializer xmlcontentSerializer_0 = new XMLContentSerializer();

		/// <summary>
		///       对象唯一静态实例
		///       </summary>
		public static XMLContentSerializer Instance => xmlcontentSerializer_0;

		public override int Priority => -1;

		public override string Name => "XML";

		public override string FileExtension => ".xml";

		public override string FileFilter => WriterStringsCore.XMLFilter;

		public override GEnum14 Flags => GEnum14.flag_1 | GEnum14.flag_2 | GEnum14.flag_3 | GEnum14.flag_4;

		public static XTextElement smethod_0(string string_0, bool bool_0)
		{
			int num = 9;
			if (string.IsNullOrEmpty(string_0))
			{
				if (bool_0)
				{
					throw new ArgumentNullException("xml");
				}
				return null;
			}
			string text = null;
			if (bool_0)
			{
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.LoadXml(string_0);
				text = xmlDocument.DocumentElement.Name;
			}
			else
			{
				try
				{
					XmlDocument xmlDocument = new XmlDocument();
					xmlDocument.LoadXml(string_0);
					text = xmlDocument.DocumentElement.Name;
				}
				catch (Exception)
				{
					return null;
				}
			}
			Type type = null;
			Type[] array = Class109.smethod_0();
			foreach (Type type2 in array)
			{
				XmlTypeAttribute xmlTypeAttribute = (XmlTypeAttribute)Attribute.GetCustomAttribute(type2, typeof(XmlTypeAttribute), inherit: false);
				if (xmlTypeAttribute == null || !(xmlTypeAttribute.TypeName == text))
				{
					if (type2.Name == text)
					{
						type = type2;
						break;
					}
					continue;
				}
				type = type2;
				break;
			}
			if (type == null)
			{
				if (bool_0)
				{
					throw new ArgumentOutOfRangeException("xml节点名称不对：" + text);
				}
				return null;
			}
			if (bool_0)
			{
				return (XTextElement)XMLHelper.LoadObjectFromXMLString(type, string_0);
			}
			try
			{
				return (XTextElement)XMLHelper.LoadObjectFromXMLString(type, string_0);
			}
			catch (Exception)
			{
			}
			return null;
		}

		public XMLContentSerializer()
		{
			base.ContentEncoding = null;
		}

		public override bool NeedRefreshPages(XTextDocument document)
		{
			if (document.Options.BehaviorOptions.GeneratePageContentVersion)
			{
				return true;
			}
			return false;
		}

		private void method_0(object sender, UnreferencedObjectEventArgs e)
		{
		}

		private void method_1(object sender, XmlElementEventArgs e)
		{
		}

		private void method_2(object sender, XmlAttributeEventArgs e)
		{
			if (e.Attr.Name != "xsi:type")
			{
			}
		}

		private void method_3(object sender, XmlNodeEventArgs e)
		{
			if (e.Name != "xsi:type")
			{
			}
		}

		public override bool Deserialize(TextReader reader, XTextDocument document, ContentSerializeOptions options)
		{
			if (!XTextDocument.smethod_8(document.WriterControl, GEnum6.const_1, Name))
			{
				return false;
			}
			float tickCountFloat = CountDown.GetTickCountFloat();
			XmlSerializer xmlSerializer = Class109.smethod_2(document.GetType());
			XmlTextReader xmlTextReader = new XmlTextReader(reader);
			xmlTextReader.WhitespaceHandling = WhitespaceHandling.All;
			XTextDocument xTextDocument = null;
			if (DocumentBehaviorOptions.GlobalSpecifyDebugMode)
			{
				try
				{
					xTextDocument = (XTextDocument)xmlSerializer.Deserialize(xmlTextReader);
					xTextDocument.Elements.Clear();
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.ToString());
					throw ex;
				}
			}
			else
			{
				xTextDocument = (XTextDocument)xmlSerializer.Deserialize(xmlTextReader);
				xTextDocument.Elements.Clear();
			}
			if (xTextDocument == null)
			{
				return false;
			}
			if (xTextDocument.Info.FieldBorderElementWidth == 0.5f)
			{
				xTextDocument.Info.FieldBorderElementWidth = 1f;
			}
			if (!xTextDocument.HasLocalConfig)
			{
				xTextDocument.LocalConfig.OldWhitespaceWidth = true;
			}
			document.method_126(xTextDocument, bool_32: true, bool_33: true);
			xTextDocument.Dispose();
			tickCountFloat = CountDown.GetTickCountFloat() - tickCountFloat;
			return true;
		}

		private Encoding method_4(XTextDocument xtextDocument_0, ContentSerializeOptions contentSerializeOptions_0)
		{
			Encoding encoding = contentSerializeOptions_0.ContentEncoding;
			if (encoding == null)
			{
				encoding = base.ContentEncoding;
			}
			if (encoding == null && !string.IsNullOrEmpty(xtextDocument_0.Options.BehaviorOptions.XMLContentEncodingName))
			{
				try
				{
					encoding = Encoding.GetEncoding(xtextDocument_0.Options.BehaviorOptions.XMLContentEncodingName);
				}
				catch (Exception ex)
				{
					Debug.WriteLine(ex.Message);
				}
			}
			if (encoding == null)
			{
				encoding = Encoding.UTF8;
			}
			return encoding;
		}

		public override bool Deserialize(Stream stream, XTextDocument document, ContentSerializeOptions options)
		{
			StreamReader reader = new StreamReader(stream, method_4(document, options), detectEncodingFromByteOrderMarks: true);
			return Deserialize(reader, document, options);
		}

		public override bool Serialize(Stream stream, XTextDocument document, ContentSerializeOptions options)
		{
			Encoding encoding = method_4(document, options);
			StreamWriter writer = new StreamWriter(stream, encoding);
			return Serialize(writer, document, options);
		}

		public override bool Serialize(TextWriter writer, XTextDocument document, ContentSerializeOptions options)
		{
			int num = 15;
			if (!XTextDocument.smethod_8(document.WriterControl, GEnum6.const_5, Name))
			{
				return false;
			}
			XmlSerializer xmlSerializer = Class109.smethod_2(document.GetType());
			bool compressXMLContent = document.Options.BehaviorOptions.CompressXMLContent;
			XmlTextWriter xmlTextWriter = null;
			StringWriter stringWriter = null;
			if (compressXMLContent)
			{
				stringWriter = new StringWriter();
				xmlTextWriter = new XmlTextWriter(stringWriter);
				xmlTextWriter.Formatting = Formatting.None;
			}
			else
			{
				xmlTextWriter = new XmlTextWriter(writer);
				if (options.Formated)
				{
					xmlTextWriter.Formatting = Formatting.Indented;
					xmlTextWriter.Indentation = 3;
					xmlTextWriter.IndentChar = ' ';
				}
				else
				{
					xmlTextWriter.Formatting = Formatting.None;
				}
			}
			document.Options.BehaviorOptions.AutoCreateInstanceInProperty = false;
			bool autoCreateInstanceInProperty = false;
			if (DocumentBehaviorOptions.GlobalSpecifyDebugMode)
			{
				try
				{
					xmlSerializer.Serialize(xmlTextWriter, document);
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.ToString());
					throw ex;
				}
				finally
				{
					document.Options.BehaviorOptions.AutoCreateInstanceInProperty = autoCreateInstanceInProperty;
				}
			}
			else
			{
				try
				{
					xmlSerializer.Serialize(xmlTextWriter, document);
				}
				finally
				{
					document.Options.BehaviorOptions.AutoCreateInstanceInProperty = autoCreateInstanceInProperty;
				}
			}
			if (compressXMLContent)
			{
				xmlTextWriter.Flush();
				xmlTextWriter.Close();
				stringWriter.Close();
				string text = stringWriter.ToString();
				text = text.Replace("<Attributes />", "");
				text = text.Replace("<Expressions />", "");
				text = text.Replace("<XElements />", "");
				text = text.Replace("<ValueBinding />", "");
				text = text.Replace("<BorderElementColor />", "");
				text = text.Replace("<EventExpressions />", "");
				text = text.Replace("<LabelText />", "");
				text = text.Replace("<PageTexts />", "");
				text = text.Replace("<PropertyExpressions />", "");
				text = text.Replace("<XElements xsi:nil=\"true\" />", "");
				text = text.Replace("<LastSelectedListItems />", "");
				text = text.Replace("<SourceName />", "");
				text = text.Replace("<TextInList />", "");
				text = text.Replace("<Group />", "");
				text = text.Replace("<ListValueFormatString />", "");
				text = text.Replace("<PageImages />", "");
				text = text.Replace("<InnerValue />", "");
				text = text.Replace("<Name />", "");
				text = text.Replace("<FieldSettings />", "");
				text = text.Replace("<StartBorderText />", "");
				text = text.Replace("<EndBorderText />", "");
				text = text.Replace("<Value />", "");
				writer.Write(text);
			}
			writer.Flush();
			return true;
		}
	}
}
