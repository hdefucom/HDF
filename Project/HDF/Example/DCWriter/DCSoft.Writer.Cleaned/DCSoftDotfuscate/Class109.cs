using DCSoft.Writer.Dom;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	internal class Class109
	{
		private static List<Type> list_0;

		private static Dictionary<Type, XmlSerializer> dictionary_0;

		private static Dictionary<Type, XmlSerializer> dictionary_1;

		static Class109()
		{
			list_0 = new List<Type>();
			dictionary_0 = new Dictionary<Type, XmlSerializer>();
			dictionary_1 = new Dictionary<Type, XmlSerializer>();
			list_0.Add(typeof(XTextDocument));
			list_0.Add(typeof(XTextCharElement));
			list_0.Add(typeof(XTextParagraphFlagElement));
			list_0.Add(typeof(XTextObjectElement));
			list_0.Add(typeof(XTextImageElement));
			list_0.Add(typeof(XTextLineBreakElement));
			list_0.Add(typeof(XTextBookmark));
			list_0.Add(typeof(XTextStringElement));
			list_0.Add(typeof(XTextDocumentHeaderElement));
			list_0.Add(typeof(XTextDocumentBodyElement));
			list_0.Add(typeof(XTextDocumentFooterElement));
			list_0.Add(typeof(XTextTableElement));
			list_0.Add(typeof(XTextTableRowElement));
			list_0.Add(typeof(XTextTableColumnElement));
			list_0.Add(typeof(XTextTableCellElement));
			list_0.Add(typeof(XTextPageBreakElement));
			list_0.Add(typeof(XTextFieldElementBase));
			list_0.Add(typeof(XTextInputFieldElementBase));
			list_0.Add(typeof(XTextInputFieldElement));
			list_0.Add(typeof(XTextCheckBoxElement));
			list_0.Add(typeof(XTextRadioBoxElement));
			list_0.Add(typeof(XTextSignElement));
			list_0.Add(typeof(XTextDocumentFieldElement));
			list_0.Add(typeof(XTextPageInfoElement));
			list_0.Add(typeof(XTextContentLinkFieldElement));
			list_0.Add(typeof(XTextControlHostElement));
			list_0.Add(typeof(XTextSectionElement));
			list_0.Add(typeof(XTextHorizontalLineElement));
			list_0.Add(typeof(XTextBeanFieldElement));
			list_0.Add(typeof(XTextFileBlockElement));
			list_0.Add(typeof(XTextLabelElement));
			list_0.Add(typeof(XTextButtonElement));
			list_0.Add(typeof(XTextCustomShapeElement));
			list_0.Add(typeof(XTextDirectoryFieldElement));
		}

		public static Type[] smethod_0()
		{
			return list_0.ToArray();
		}

		public static void smethod_1(Type type_0)
		{
			int num = 4;
			if (type_0 == null)
			{
				throw new ArgumentNullException("elementType");
			}
			if (typeof(XTextElement).IsAssignableFrom(type_0))
			{
				if (!list_0.Contains(type_0))
				{
					list_0.Add(type_0);
					dictionary_0.Clear();
				}
				return;
			}
			throw new ArgumentOutOfRangeException(type_0.FullName + "<> XTextElement");
		}

		public static XmlSerializer smethod_2(Type type_0)
		{
			if (dictionary_0.ContainsKey(type_0))
			{
				return dictionary_0[type_0];
			}
			XmlSerializer xmlSerializer = new XmlSerializer(type_0, list_0.ToArray());
			dictionary_0[type_0] = xmlSerializer;
			xmlSerializer.UnknownNode += smethod_6;
			xmlSerializer.UnknownAttribute += smethod_5;
			xmlSerializer.UnknownElement += smethod_4;
			xmlSerializer.UnreferencedObject += smethod_3;
			return xmlSerializer;
		}

		private static void smethod_3(object sender, UnreferencedObjectEventArgs e)
		{
		}

		private static void smethod_4(object sender, XmlElementEventArgs e)
		{
		}

		private static void smethod_5(object sender, XmlAttributeEventArgs e)
		{
			if (e.Attr.Name != "xsi:type")
			{
			}
		}

		private static void smethod_6(object sender, XmlNodeEventArgs e)
		{
			if (e.Name != "xsi:type")
			{
			}
		}

		public static XmlSerializer smethod_7(Type type_0)
		{
			int num = 11;
			if (type_0 == null)
			{
				throw new ArgumentNullException("elementType");
			}
			if (dictionary_1.ContainsKey(type_0))
			{
				return dictionary_1[type_0];
			}
			XmlSerializer xmlSerializer = new XmlSerializer(type_0);
			dictionary_1[type_0] = xmlSerializer;
			return xmlSerializer;
		}
	}
}
