using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace DCSoft.Common
{
	[ComVisible(false)]
	public static class XMLSerializeHelper
	{
		private class EnumTypeInfo
		{
			public bool WithFlags = false;

			public string[] Names = null;

			public int[] Values = null;
		}

		private static Dictionary<PropertyInfo, bool> _HasXmlIgnoreAttribute = new Dictionary<PropertyInfo, bool>();

		private static Dictionary<Type, EnumTypeInfo> _EnumTypeInfos = new Dictionary<Type, EnumTypeInfo>();

		                                                                    /// <summary>
		                                                                    ///       判断属性是否标记了XmlIgnoreAttribute特性
		                                                                    ///       </summary>
		                                                                    /// <param name="p">
		                                                                    /// </param>
		                                                                    /// <returns>
		                                                                    /// </returns>
		public static bool HasXmlIgnoreAttribute(PropertyInfo propertyInfo_0)
		{
			int num = 4;
			if (propertyInfo_0 == null)
			{
				throw new ArgumentNullException("p");
			}
			if (_HasXmlIgnoreAttribute.ContainsKey(propertyInfo_0))
			{
				return _HasXmlIgnoreAttribute[propertyInfo_0];
			}
			if (Attribute.GetCustomAttribute(propertyInfo_0, typeof(XmlIgnoreAttribute), inherit: true) == null)
			{
				_HasXmlIgnoreAttribute[propertyInfo_0] = false;
				return false;
			}
			_HasXmlIgnoreAttribute[propertyInfo_0] = true;
			return true;
		}

		public static string GetXmlTypeName(Type type_0)
		{
			int num = 14;
			if (type_0 == null)
			{
				throw new ArgumentNullException("t");
			}
			XmlTypeAttribute xmlTypeAttribute = (XmlTypeAttribute)Attribute.GetCustomAttribute(type_0, typeof(XmlTypeAttribute), inherit: true);
			string result = type_0.Name;
			if (xmlTypeAttribute != null && !string.IsNullOrEmpty(xmlTypeAttribute.TypeName))
			{
				result = xmlTypeAttribute.TypeName;
			}
			return result;
		}

		public static string ColorToString(Color color_0)
		{
			int num = 1;
			if (color_0.A == byte.MaxValue)
			{
				return "#" + color_0.R.ToString("X2") + color_0.G.ToString("X2") + color_0.B.ToString("X2");
			}
			return "#" + color_0.A.ToString("X2") + color_0.R.ToString("X2") + color_0.G.ToString("X2") + color_0.B.ToString("X2");
		}

		public static string ColorToString(Color color_0, Color defaultValue)
		{
			int num = 8;
			if (color_0.ToArgb() == defaultValue.ToArgb())
			{
				return null;
			}
			if (color_0.A == byte.MaxValue)
			{
				return "#" + color_0.R.ToString("X2") + color_0.G.ToString("X2") + color_0.B.ToString("X2");
			}
			return "#" + color_0.A.ToString("X2") + color_0.R.ToString("X2") + color_0.G.ToString("X2") + color_0.B.ToString("X2");
		}

		public static Color StringToColor(string string_0, Color defaultValue)
		{
			int num = 16;
			if (string.IsNullOrEmpty(string_0))
			{
				return defaultValue;
			}
			try
			{
				if (string_0.StartsWith("#"))
				{
					string_0 = string_0.Substring(1).Trim();
					int red;
					int green;
					int blue;
					if (string_0.Length == 8)
					{
						if (string_0 == "00000000")
						{
							return Color.Empty;
						}
						if (string.Compare(string_0, "00ffffff", ignoreCase: true) == 0)
						{
							return Color.Transparent;
						}
						int alpha = int.Parse(string_0.Substring(0, 2), NumberStyles.HexNumber);
						red = int.Parse(string_0.Substring(2, 2), NumberStyles.HexNumber);
						green = int.Parse(string_0.Substring(4, 2), NumberStyles.HexNumber);
						blue = int.Parse(string_0.Substring(6, 2), NumberStyles.HexNumber);
						return Color.FromArgb(alpha, red, green, blue);
					}
					if (string_0 == "000000")
					{
						return Color.Black;
					}
					if (string.Compare(string_0, "ffffff", ignoreCase: true) == 0)
					{
						return Color.White;
					}
					red = int.Parse(string_0.Substring(0, 2), NumberStyles.HexNumber);
					green = int.Parse(string_0.Substring(2, 2), NumberStyles.HexNumber);
					blue = int.Parse(string_0.Substring(4, 2), NumberStyles.HexNumber);
					return Color.FromArgb(red, green, blue);
				}
				if (string_0.IndexOf(',') > 0)
				{
					string[] array = string_0.Split(',');
					List<int> list = new List<int>();
					string[] array2 = array;
					foreach (string text in array2)
					{
						int result = 0;
						if (int.TryParse(text.Trim(), out result))
						{
							list.Add(result);
						}
					}
					if (list.Count == 1)
					{
						return Color.FromArgb(list[0], 255, 255);
					}
					if (list.Count == 2)
					{
						return Color.FromArgb(list[0], list[1], 255);
					}
					if (list.Count == 3)
					{
						return Color.FromArgb(list[0], list[1], list[2]);
					}
					if (list.Count == 4)
					{
						return Color.FromArgb(list[0], list[1], list[2], list[3]);
					}
				}
				return ColorTranslator.FromHtml(string_0);
			}
			catch
			{
				return defaultValue;
			}
		}

		public static int ReadAllAttributeValue(XmlReader reader, object instance)
		{
			int num = 0;
			if (reader.MoveToFirstAttribute())
			{
				do
				{
					if (ReadSinglePropertyValue(reader, instance))
					{
						num++;
					}
				}
				while (reader.MoveToNextAttribute());
			}
			return num;
		}

		public static bool ReadSinglePropertyValue(XmlReader reader, object instance)
		{
			int num = 19;
			if (reader == null)
			{
				throw new ArgumentNullException("reader");
			}
			if (instance == null)
			{
				throw new ArgumentNullException("instance");
			}
			string localName = reader.LocalName;
			if (string.IsNullOrEmpty(localName))
			{
				throw new ArgumentNullException("reader.LocalName");
			}
			string text = reader.Value;
			if (reader.NodeType == XmlNodeType.Element)
			{
				text = reader.ReadString();
			}
			PropertyInfo property = instance.GetType().GetProperty(localName, BindingFlags.Instance | BindingFlags.Public);
			if (property == null)
			{
				throw new ArgumentOutOfRangeException(instance.GetType().FullName + "没有属性" + localName);
			}
			object obj = null;
			obj = (property.PropertyType.Equals(typeof(DateTime)) ? ((object)ToDateTime(text)) : ((!property.PropertyType.Equals(typeof(Color))) ? Convert.ChangeType(text, property.PropertyType) : ((object)ToColor(text))));
			property.SetValue(instance, obj, null);
			return true;
		}

		public static bool WriteAttributeString(XmlWriter writer, object instance, string propertyName)
		{
			return WritePropertyValue(writer, instance, propertyName, attributeType: true);
		}

		public static bool WriteElementString(XmlWriter writer, object instance, string propertyName)
		{
			return WritePropertyValue(writer, instance, propertyName, attributeType: false);
		}

		private static bool WritePropertyValue(XmlWriter writer, object instance, string propertyName, bool attributeType)
		{
			int num = 8;
			if (writer == null)
			{
				throw new ArgumentNullException("writer");
			}
			if (instance == null)
			{
				throw new ArgumentNullException("instance");
			}
			if (string.IsNullOrEmpty(propertyName))
			{
				throw new ArgumentNullException("propertyName");
			}
			PropertyInfo property = instance.GetType().GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public);
			object value = property.GetValue(instance, null);
			if (value != null)
			{
				object propertyDefaultValue = ValueTypeHelper.GetPropertyDefaultValue(property);
				if (!value.Equals(propertyDefaultValue))
				{
					string value2 = ToString(value);
					if (!string.IsNullOrEmpty(value2))
					{
						if (attributeType)
						{
							writer.WriteAttributeString(propertyName, value2);
						}
						else
						{
							writer.WriteElementString(propertyName, value2);
						}
						return true;
					}
				}
			}
			return false;
		}

		public static DateTime ToDateTime(string string_0)
		{
			DateTime result = DateTime.MinValue;
			if (DateTime.TryParseExact(string_0, "yyyy-MM-dd HH:mm:ss", null, DateTimeStyles.AllowWhiteSpaces, out result))
			{
				return result;
			}
			return DateTime.MinValue;
		}

		public static Color ToColor(string string_0)
		{
			return ColorTranslator.FromHtml(string_0);
		}

		public static string ToString(object object_0)
		{
			if (object_0 == null || DBNull.Value.Equals(object_0))
			{
				return null;
			}
			if (object_0 is DateTime)
			{
				return FormatUtils.ToYYYY_MM_DD_HH_MM_SS((DateTime)object_0);
			}
			if (object_0 is Color)
			{
				return ColorTranslator.ToHtml((Color)object_0);
			}
			return object_0.ToString();
		}

		public static string DateTimeToString(DateTime dateTime_0)
		{
			return FormatUtils.ToYYYY_MM_DD_HH_MM_SS(dateTime_0);
		}

		public static DateTime StringToDateTime(string string_0, DateTime defaultValue)
		{
			if (string.IsNullOrEmpty(string_0))
			{
				return defaultValue;
			}
			DateTime result = DateTime.MinValue;
			if (DateTime.TryParse(string_0, out result))
			{
				return result;
			}
			return defaultValue;
		}

		public static object StringToEnum(string string_0, object defaultValue)
		{
			int num = 17;
			if (string.IsNullOrEmpty(string_0))
			{
				return defaultValue;
			}
			if (defaultValue == null)
			{
				throw new ArgumentNullException("defaultValue");
			}
			Type type = defaultValue.GetType();
			if (!type.IsEnum)
			{
				throw new ArgumentException("enumType=" + type.FullName);
			}
			EnumTypeInfo enumTypeInfo = GetEnumTypeInfo(type);
			int result = 0;
			if (int.TryParse(string_0, out result))
			{
				return Convert.ChangeType(result, type);
			}
			string[] array = string_0.Split('|', ',', ' ');
			int num2 = enumTypeInfo.Names.Length;
			string[] array2 = array;
			foreach (string text in array2)
			{
				if (string.IsNullOrEmpty(text))
				{
					continue;
				}
				for (int j = 0; j < num2; j++)
				{
					if (string.Compare(enumTypeInfo.Names[j], text, ignoreCase: true) == 0)
					{
						result += enumTypeInfo.Values[j];
						break;
					}
				}
				if (!enumTypeInfo.WithFlags)
				{
					break;
				}
			}
			return Convert.ChangeType(result, type);
		}

		public static string EnumToString(object Value)
		{
			Type type = Value.GetType();
			EnumTypeInfo enumTypeInfo = GetEnumTypeInfo(type);
			if (enumTypeInfo.WithFlags)
			{
				StringBuilder stringBuilder = new StringBuilder();
				int num = Convert.ToInt32(Value);
				for (int i = 0; i < enumTypeInfo.Values.Length; i++)
				{
					if (num % enumTypeInfo.Values[i] == enumTypeInfo.Values[i])
					{
						if (stringBuilder.Length > 0)
						{
							stringBuilder.Append('|');
						}
						stringBuilder.Append(enumTypeInfo.Names[i]);
					}
				}
				return stringBuilder.ToString();
			}
			return Value.ToString();
		}

		private static EnumTypeInfo GetEnumTypeInfo(Type type_0)
		{
			if (_EnumTypeInfos.ContainsKey(type_0))
			{
				return _EnumTypeInfos[type_0];
			}
			EnumTypeInfo enumTypeInfo = new EnumTypeInfo();
			enumTypeInfo.WithFlags = (Attribute.GetCustomAttribute(type_0, typeof(FlagsAttribute), inherit: false) != null);
			List<string> list = new List<string>();
			List<int> list2 = new List<int>();
			foreach (object value in Enum.GetValues(type_0))
			{
				list.Add(value.ToString());
				list2.Add(Convert.ToInt32(value));
			}
			enumTypeInfo.Names = list.ToArray();
			enumTypeInfo.Values = list2.ToArray();
			_EnumTypeInfos[type_0] = enumTypeInfo;
			return enumTypeInfo;
		}
	}
}
