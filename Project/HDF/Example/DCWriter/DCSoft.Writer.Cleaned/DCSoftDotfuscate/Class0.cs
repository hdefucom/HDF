using DCSoft.Writer;
using DCSoft.Writer.Dom;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Xml;

namespace DCSoftDotfuscate
{
	internal class Class0
	{
		private class Class1
		{
			public Type type_0 = null;

			public string string_0 = null;

			public string string_1 = null;
		}

		private class Class2
		{
			public Type type_0 = null;

			public object object_0 = null;

			public PropertyInfo propertyInfo_0 = null;

			public bool method_0(object object_1)
			{
				return object_1 == object_0;
			}

			public object method_1(object object_1)
			{
				return propertyInfo_0.GetValue(object_1, null);
			}

			public void method_2(object object_1, object object_2)
			{
				propertyInfo_0.SetValue(object_1, object_2, null);
			}
		}

		private class Class3
		{
			public bool bool_0 = false;

			public string[] string_0 = null;

			public int[] int_0 = null;
		}

		private static Dictionary<Type, Dictionary<string, Class2>> dictionary_0 = new Dictionary<Type, Dictionary<string, Class2>>();

		private static Dictionary<Type, Class3> dictionary_1 = new Dictionary<Type, Class3>();

		private void method_0(XmlWriter xmlWriter_0, object object_0, string string_0, object object_1)
		{
			if (object_1 != null)
			{
				object_1.GetType();
				if (object_1 is XTextElementList)
				{
					XTextElementList xtextElementList_ = (XTextElementList)object_1;
					WriterUtils.smethod_60(xtextElementList_, bool_2: false);
				}
			}
		}

		public void method_1(XTextElement xtextElement_0)
		{
		}

		private void method_2(XmlWriter xmlWriter_0, XTextBarcodeFieldElement xtextBarcodeFieldElement_0)
		{
			method_8(xmlWriter_0, xtextBarcodeFieldElement_0, "ID,StyleIndex", bool_0: true);
			method_9(xmlWriter_0, xtextBarcodeFieldElement_0, "AcceptTab");
			method_9(xmlWriter_0, xtextBarcodeFieldElement_0, "Attributes");
			method_9(xmlWriter_0, xtextBarcodeFieldElement_0, "AutoExitEditMode");
			method_9(xmlWriter_0, xtextBarcodeFieldElement_0, "BackgroundText");
			method_9(xmlWriter_0, xtextBarcodeFieldElement_0, "BackgroundTextColor");
			method_7(xmlWriter_0, xtextBarcodeFieldElement_0);
		}

		private void method_3(XmlWriter xmlWriter_0, XTextInputFieldElementBase xtextInputFieldElementBase_0)
		{
			method_9(xmlWriter_0, xtextInputFieldElementBase_0, "AcceptTab");
			method_9(xmlWriter_0, xtextInputFieldElementBase_0, "Attributes");
			method_9(xmlWriter_0, xtextInputFieldElementBase_0, "AutoExitEditMode");
			method_9(xmlWriter_0, xtextInputFieldElementBase_0, "BackgroundText");
			method_9(xmlWriter_0, xtextInputFieldElementBase_0, "BackgroundTextColor");
			method_7(xmlWriter_0, xtextInputFieldElementBase_0);
		}

		private void method_4(XmlWriter xmlWriter_0, XTextContainerElement xtextContainerElement_0)
		{
			method_5(xmlWriter_0, xtextContainerElement_0);
			method_9(xmlWriter_0, xtextContainerElement_0, "ContentReadonly");
			method_7(xmlWriter_0, xtextContainerElement_0);
			method_9(xmlWriter_0, xtextContainerElement_0, "CopySource");
			method_9(xmlWriter_0, xtextContainerElement_0, "Deleteable");
		}

		private void method_5(XmlWriter xmlWriter_0, XTextElement xtextElement_0)
		{
			int num = 9;
			if (string.IsNullOrEmpty(xtextElement_0.ID))
			{
				xmlWriter_0.WriteAttributeString("ID", xtextElement_0.ID);
			}
			if (xtextElement_0.StyleIndex >= 0)
			{
				xmlWriter_0.WriteAttributeString("StyleIndex", xtextElement_0.StyleIndex.ToString());
			}
		}

		private void method_6(XmlWriter xmlWriter_0, XTextElementList xtextElementList_0)
		{
			int num = 8;
			if (xtextElementList_0 != null)
			{
				XTextElementList xTextElementList = WriterUtils.smethod_60(xtextElementList_0, bool_2: false);
				xmlWriter_0.WriteStartElement("Elements");
				foreach (XTextElement item in xTextElementList)
				{
					method_1(item);
				}
				xmlWriter_0.WriteEndElement();
			}
		}

		private void method_7(XmlWriter xmlWriter_0, XTextElement xtextElement_0)
		{
			int num = 6;
			XAttributeList attributes = xtextElement_0.Attributes;
			if (attributes != null)
			{
				xmlWriter_0.WriteStartElement("Attributes");
				foreach (XAttribute item in attributes)
				{
					xmlWriter_0.WriteStartElement("Attribute");
					xmlWriter_0.WriteAttributeString("Name", item.Name);
					xmlWriter_0.WriteString(item.Value);
					xmlWriter_0.WriteEndElement();
				}
				xmlWriter_0.WriteEndElement();
			}
		}

		private void method_8(XmlWriter xmlWriter_0, object object_0, string string_0, bool bool_0)
		{
		}

		private void method_9(XmlWriter xmlWriter_0, object object_0, string string_0)
		{
			int num = 17;
			if (xmlWriter_0 != null && object_0 != null)
			{
				if (string.IsNullOrEmpty(string_0))
				{
					throw new ArgumentNullException("propertyName");
				}
				Class2 @class = smethod_0(object_0, string_0);
				object obj = @class.method_1(object_0);
				if (obj != null && !@class.method_0(obj))
				{
					xmlWriter_0.WriteElementString(string_0, method_11(obj));
				}
			}
		}

		private static Class2 smethod_0(object object_0, string string_0)
		{
			int num = 5;
			Type type = object_0.GetType();
			Dictionary<string, Class2> dictionary = null;
			if (dictionary_0.ContainsKey(type))
			{
				dictionary = dictionary_0[type];
			}
			else
			{
				dictionary = new Dictionary<string, Class2>();
				dictionary_0[type] = dictionary;
				PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
				PropertyInfo[] array = properties;
				foreach (PropertyInfo propertyInfo in array)
				{
					ParameterInfo[] indexParameters = propertyInfo.GetIndexParameters();
					if ((indexParameters == null || indexParameters.Length <= 0) && propertyInfo.CanRead && propertyInfo.CanWrite)
					{
						Class2 @class = new Class2();
						DefaultValueAttribute defaultValueAttribute = (DefaultValueAttribute)Attribute.GetCustomAttribute(propertyInfo, typeof(DefaultValueAttribute), inherit: false);
						if (defaultValueAttribute != null)
						{
							@class.object_0 = defaultValueAttribute;
						}
						@class.propertyInfo_0 = propertyInfo;
						@class.type_0 = propertyInfo.PropertyType;
						dictionary[propertyInfo.Name] = @class;
					}
				}
			}
			if (!dictionary.ContainsKey(string_0))
			{
				throw new ArgumentOutOfRangeException(object_0.GetType().Name + "!" + string_0);
			}
			return dictionary[string_0];
		}

		private void method_10(bool bool_0, bool bool_1)
		{
		}

		private string method_11(object object_0)
		{
			if (object_0 is DateTime)
			{
				return method_12((DateTime)object_0);
			}
			if (object_0 is Color)
			{
				return method_13((Color)object_0);
			}
			if (object_0 is Enum)
			{
				return method_14(object_0);
			}
			return object_0.ToString();
		}

		private string method_12(DateTime dateTime_0)
		{
			return dateTime_0.ToString("yyyy-MM-dd HH:mm:ss");
		}

		private string method_13(Color color_0)
		{
			return ColorTranslator.ToHtml(color_0);
		}

		private string method_14(object object_0)
		{
			Type type = object_0.GetType();
			Class3 @class = smethod_1(type);
			if (@class.bool_0)
			{
				StringBuilder stringBuilder = new StringBuilder();
				int num = Convert.ToInt32(object_0);
				for (int i = 0; i < @class.int_0.Length; i++)
				{
					if (num % @class.int_0[i] == @class.int_0[i])
					{
						if (stringBuilder.Length > 0)
						{
							stringBuilder.Append('|');
						}
						stringBuilder.Append(@class.string_0[i]);
					}
				}
				return stringBuilder.ToString();
			}
			return object_0.ToString();
		}

		private static Class3 smethod_1(Type type_0)
		{
			if (dictionary_1.ContainsKey(type_0))
			{
				return dictionary_1[type_0];
			}
			Class3 @class = new Class3();
			@class.bool_0 = (Attribute.GetCustomAttribute(type_0, typeof(FlagsAttribute), inherit: false) != null);
			List<string> list = new List<string>();
			List<int> list2 = new List<int>();
			foreach (object value in Enum.GetValues(type_0))
			{
				list.Add(value.ToString());
				list2.Add(Convert.ToInt32(value));
			}
			@class.string_0 = list.ToArray();
			@class.int_0 = list2.ToArray();
			dictionary_1[type_0] = @class;
			return @class;
		}
	}
}
