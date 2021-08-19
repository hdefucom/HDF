using DCSoft.Design;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace DCSoftDotfuscate
{
	internal class Class69
	{
		private class Class70 : IComparer<Class69>
		{
			public int Compare(Class69 class69_0, Class69 class69_1)
			{
				return string.Compare(class69_0.method_0().FullName, class69_1.method_0().FullName);
			}
		}

		private class Class71 : IComparer<Class68>
		{
			public int Compare(Class68 class68_0, Class68 class68_1)
			{
				int num = class68_0.int_0 - class68_1.int_0;
				if (num == 0)
				{
					return string.Compare(class68_0.method_4().Name, class68_1.method_4().Name);
				}
				return num;
			}
		}

		private static Dictionary<Type, Class69> dictionary_0 = new Dictionary<Type, Class69>();

		private Type type_0 = null;

		private int int_0 = 0;

		private Type type_1 = null;

		private string string_0 = null;

		private string string_1 = null;

		private Dictionary<string, object> dictionary_1 = new Dictionary<string, object>();

		private List<Type> list_0 = new List<Type>();

		private Class68[] class68_0 = null;

		public static List<Class69> smethod_0(Type type_2)
		{
			return smethod_1(new Type[1]
			{
				type_2
			});
		}

		public static List<Class69> smethod_1(IList ilist_0)
		{
			List<Class69> list = new List<Class69>();
			foreach (Type item in ilist_0)
			{
				smethod_2(item, list);
			}
			list.Sort(new Class70());
			smethod_4(list);
			return list;
		}

		private static void smethod_2(Type type_2, List<Class69> list_1)
		{
			Class69 @class = smethod_3(type_2);
			if (@class == null || list_1.Contains(@class))
			{
				return;
			}
			list_1.Add(@class);
			foreach (Type item in @class.method_6())
			{
				smethod_2(item, list_1);
			}
			if (@class.method_7() == null)
			{
				return;
			}
			Class68[] array = @class.method_7();
			foreach (Class68 class2 in array)
			{
				Class69 class3 = smethod_3(class2.method_4().PropertyType);
				if (class3 != null && !list_1.Contains(class3))
				{
					smethod_2(class2.method_4().PropertyType, list_1);
				}
				if (class2.method_11() != null && class2.method_11().Count > 0)
				{
					foreach (Type key in class2.method_11().Keys)
					{
						smethod_2(key, list_1);
					}
				}
			}
		}

		public static Class69 smethod_3(Type type_2)
		{
			int num = 7;
			if (type_2 == null)
			{
				return null;
			}
			if (type_2.IsPrimitive || type_2.Equals(typeof(string)) || type_2.Equals(typeof(DateTime)) || type_2.Equals(typeof(decimal)) || type_2.IsSubclassOf(typeof(Delegate)) || type_2.Equals(typeof(byte[])) || type_2.Equals(typeof(object)))
			{
				return null;
			}
			if (dictionary_0.ContainsKey(type_2))
			{
				return dictionary_0[type_2];
			}
			Class69 @class = new Class69();
			dictionary_0[type_2] = @class;
			@class.type_0 = type_2;
			@class.string_1 = type_2.Name;
			string cSharpTypeName = DesignUtils.GetCSharpTypeName(type_2);
			cSharpTypeName = cSharpTypeName.Replace('.', '_');
			cSharpTypeName = cSharpTypeName.Replace('<', '_');
			cSharpTypeName = (@class.string_0 = cSharpTypeName.Replace('>', '_'));
			XmlTypeAttribute xmlTypeAttribute = (XmlTypeAttribute)Attribute.GetCustomAttribute(type_2, typeof(XmlTypeAttribute), inherit: true);
			if (xmlTypeAttribute != null && !string.IsNullOrEmpty(xmlTypeAttribute.TypeName))
			{
				@class.string_1 = xmlTypeAttribute.TypeName;
			}
			Attribute[] customAttributes = Attribute.GetCustomAttributes(type_2, typeof(XmlIncludeAttribute), inherit: true);
			if (customAttributes != null && customAttributes.Length > 0)
			{
				Attribute[] array = customAttributes;
				for (int i = 0; i < array.Length; i++)
				{
					XmlIncludeAttribute xmlIncludeAttribute = (XmlIncludeAttribute)array[i];
					@class.list_0.Add(xmlIncludeAttribute.Type);
				}
			}
			@class.type_1 = DesignUtils.GetCollectionItemType(type_2, checkAddMethod: true);
			if (type_2.IsEnum)
			{
				FieldInfo[] fields = type_2.GetFields(BindingFlags.Static | BindingFlags.Public);
				foreach (FieldInfo fieldInfo in fields)
				{
					string name = fieldInfo.Name;
					XmlEnumAttribute xmlEnumAttribute = (XmlEnumAttribute)Attribute.GetCustomAttribute(fieldInfo, typeof(XmlEnumAttribute), inherit: true);
					if (xmlEnumAttribute != null)
					{
						name = xmlEnumAttribute.Name;
					}
					if (string.IsNullOrEmpty(name))
					{
						name = xmlEnumAttribute.Name;
					}
					@class.dictionary_1[name] = fieldInfo.GetValue(null);
				}
			}
			else
			{
				List<Class68> list = new List<Class68>();
				PropertyInfo[] properties = type_2.GetProperties(BindingFlags.Instance | BindingFlags.Public);
				foreach (PropertyInfo propertyInfo in properties)
				{
					if (!(propertyInfo.Name == "Styles") || !(type_2.Name == "DocumentContentStyleContainer"))
					{
					}
					if (!propertyInfo.CanRead || !propertyInfo.CanWrite)
					{
						continue;
					}
					ParameterInfo[] indexParameters = propertyInfo.GetIndexParameters();
					if ((indexParameters != null && indexParameters.Length > 0) || Attribute.GetCustomAttribute(propertyInfo, typeof(XmlIgnoreAttribute), inherit: false) != null || Attribute.GetCustomAttribute(propertyInfo, typeof(ObsoleteAttribute), inherit: true) != null)
					{
						continue;
					}
					Type propertyType = propertyInfo.PropertyType;
					if (propertyType.Equals(typeof(object)) || propertyType.Equals(typeof(Control)) || propertyType.IsSubclassOf(typeof(Delegate)))
					{
						continue;
					}
					Class68 class2 = new Class68();
					if (Attribute.GetCustomAttribute(propertyInfo, typeof(ObsoleteAttribute), inherit: true) != null)
					{
						class2.method_1(bool_4: true);
					}
					class2.method_3(propertyInfo.Name);
					class2.method_5(propertyInfo);
					XmlElementAttribute xmlElementAttribute = (XmlElementAttribute)Attribute.GetCustomAttribute(propertyInfo, typeof(XmlElementAttribute), inherit: false);
					if (xmlElementAttribute != null)
					{
						if (!string.IsNullOrEmpty(xmlElementAttribute.ElementName))
						{
							class2.method_3(xmlElementAttribute.ElementName);
						}
						class2.int_0 = 1;
					}
					else
					{
						XmlAttributeAttribute xmlAttributeAttribute = (XmlAttributeAttribute)Attribute.GetCustomAttribute(propertyInfo, typeof(XmlAttributeAttribute), inherit: true);
						if (xmlAttributeAttribute != null)
						{
							if (!string.IsNullOrEmpty(xmlAttributeAttribute.AttributeName))
							{
								class2.method_3(xmlAttributeAttribute.AttributeName);
							}
							class2.int_0 = 0;
						}
						else
						{
							XmlTextAttribute xmlTextAttribute = (XmlTextAttribute)Attribute.GetCustomAttribute(propertyInfo, typeof(XmlTextAttribute), inherit: true);
							if (xmlTextAttribute != null)
							{
								class2.int_0 = 3;
							}
						}
					}
					DefaultValueAttribute defaultValueAttribute = (DefaultValueAttribute)Attribute.GetCustomAttribute(propertyInfo, typeof(DefaultValueAttribute), inherit: true);
					if (defaultValueAttribute != null)
					{
						bool flag = true;
						if (defaultValueAttribute.Value == null)
						{
							if (propertyInfo.PropertyType.IsValueType)
							{
								flag = false;
							}
						}
						else if (!propertyInfo.PropertyType.IsInstanceOfType(defaultValueAttribute.Value))
						{
							flag = false;
						}
						if (flag)
						{
							class2.method_10(defaultValueAttribute.Value);
						}
					}
					Attribute[] customAttributes2 = Attribute.GetCustomAttributes(propertyInfo, typeof(XmlArrayItemAttribute), inherit: false);
					if (customAttributes2 != null && customAttributes2.Length > 0)
					{
						class2.method_7(bool_4: true);
						class2.int_0 = 2;
						Attribute[] array = customAttributes2;
						for (int j = 0; j < array.Length; j++)
						{
							XmlArrayItemAttribute xmlArrayItemAttribute = (XmlArrayItemAttribute)array[j];
							class2.method_11()[xmlArrayItemAttribute.Type] = xmlArrayItemAttribute.ElementName;
						}
						if (class2.method_11().Count == 1)
						{
							class2.method_13(bool_4: true);
						}
					}
					else
					{
						Type collectionItemType = DesignUtils.GetCollectionItemType(propertyInfo.PropertyType, checkAddMethod: true);
						if (collectionItemType != null)
						{
							class2.int_0 = 2;
							XmlTypeAttribute xmlTypeAttribute2 = (XmlTypeAttribute)Attribute.GetCustomAttribute(collectionItemType, typeof(XmlTypeAttribute), inherit: true);
							if (xmlTypeAttribute2 == null || string.IsNullOrEmpty(xmlTypeAttribute2.TypeName))
							{
								class2.method_11()[collectionItemType] = collectionItemType.Name;
							}
							else
							{
								class2.method_11()[collectionItemType] = xmlTypeAttribute2.TypeName;
							}
							if (collectionItemType.IsSealed)
							{
								class2.method_13(bool_4: true);
							}
						}
					}
					XmlArrayAttribute xmlArrayAttribute = (XmlArrayAttribute)Attribute.GetCustomAttribute(propertyInfo, typeof(XmlArrayAttribute), inherit: true);
					if (xmlArrayAttribute != null && !string.IsNullOrEmpty(xmlArrayAttribute.ElementName))
					{
						class2.method_3(xmlArrayAttribute.ElementName);
					}
					list.Add(class2);
					Class69 class3 = smethod_3(propertyInfo.PropertyType);
					if (class3 != null && (class3.method_7() == null || class3.method_7().Length == 0) && class3.method_2() == null && !class3.method_0().IsEnum)
					{
						list.Remove(class2);
					}
				}
				list.Sort(new Class71());
				@class.class68_0 = list.ToArray();
			}
			if (!XmlReader.IsName(@class.method_4()) && @class.method_2() != null)
			{
				@class.string_1 = @class.method_2().Name + "List";
			}
			return @class;
		}

		public static void smethod_4(IList ilist_0)
		{
			foreach (Class69 item in ilist_0)
			{
				item.int_0 = 0;
			}
			foreach (Class69 item2 in ilist_0)
			{
				List<Type> list = new List<Type>();
				if (item2.method_2() != null)
				{
					list.Add(item2.method_2());
				}
				if (item2.method_7() != null)
				{
					Class68[] array = item2.method_7();
					foreach (Class68 class2 in array)
					{
						list.Add(class2.method_4().PropertyType);
					}
				}
				foreach (Class69 item3 in ilist_0)
				{
					if (list.Contains(item3.method_0()))
					{
						item2.int_0++;
					}
				}
			}
		}

		public Type method_0()
		{
			return type_0;
		}

		public int method_1()
		{
			return int_0;
		}

		public Type method_2()
		{
			return type_1;
		}

		public string method_3()
		{
			return string_0;
		}

		public string method_4()
		{
			return string_1;
		}

		public Dictionary<string, object> method_5()
		{
			return dictionary_1;
		}

		public List<Type> method_6()
		{
			return list_0;
		}

		internal Class68[] method_7()
		{
			return class68_0;
		}
	}
}
