using DCSoft.Common;
using DCSoft.Writer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass116 : IComparable<GClass116>
	{
		public const string string_0 = "dc_";

		private static Dictionary<Type, GClass116[]> dictionary_0 = new Dictionary<Type, GClass116[]>();

		private string string_1;

		private string string_2;

		private bool bool_0;

		private bool bool_1;

		private PropertyInfo propertyInfo_0;

		private Type type_0;

		private bool bool_2;

		private bool bool_3;

		private object object_0;

		public static string smethod_0(Type type_1)
		{
			int num = 11;
			GClass116[] array = smethod_1(type_1);
			StringBuilder stringBuilder = new StringBuilder();
			GClass116[] array2 = array;
			foreach (GClass116 gClass in array2)
			{
				stringBuilder.AppendLine("\"" + gClass.method_0() + "\",");
			}
			return stringBuilder.ToString();
		}

		public static GClass116[] smethod_1(Type type_1)
		{
			int num = 4;
			if (type_1 == null)
			{
				throw new ArgumentNullException("t");
			}
			if (dictionary_0.ContainsKey(type_1))
			{
				return dictionary_0[type_1];
			}
			List<GClass116> list = new List<GClass116>();
			PropertyInfo[] properties = type_1.GetProperties(BindingFlags.Instance | BindingFlags.Public);
			foreach (PropertyInfo propertyInfo in properties)
			{
				HtmlAttributeAttribute htmlAttributeAttribute = (HtmlAttributeAttribute)Attribute.GetCustomAttribute(propertyInfo, typeof(HtmlAttributeAttribute), inherit: true);
				if (htmlAttributeAttribute != null)
				{
					GClass116 item = new GClass116(propertyInfo);
					list.Add(item);
				}
			}
			list.Sort();
			dictionary_0[type_1] = list.ToArray();
			return list.ToArray();
		}

		private GClass116(PropertyInfo propertyInfo_1)
		{
			int num = 1;
			string_1 = null;
			string_2 = null;
			bool_0 = false;
			bool_1 = true;
			propertyInfo_0 = null;
			type_0 = null;
			bool_2 = true;
			bool_3 = true;
			object_0 = null;
			
			propertyInfo_0 = propertyInfo_1;
			bool_2 = propertyInfo_1.CanRead;
			bool_3 = propertyInfo_1.CanWrite;
			DefaultValueAttribute defaultValueAttribute = (DefaultValueAttribute)Attribute.GetCustomAttribute(propertyInfo_1, typeof(DefaultValueAttribute), inherit: true);
			if (defaultValueAttribute != null)
			{
				object_0 = defaultValueAttribute.Value;
			}
			type_0 = propertyInfo_1.PropertyType;
			string_1 = propertyInfo_1.Name;
			string_2 = "dc_" + propertyInfo_1.Name;
			HtmlAttributeAttribute htmlAttributeAttribute = (HtmlAttributeAttribute)Attribute.GetCustomAttribute(propertyInfo_1, typeof(HtmlAttributeAttribute), inherit: true);
			if (!string.IsNullOrEmpty(htmlAttributeAttribute.AttributeName))
			{
				string_2 = htmlAttributeAttribute.AttributeName;
			}
			if (string.IsNullOrEmpty(string_2))
			{
				string_2 = "property";
			}
			bool_0 = htmlAttributeAttribute.AutoUseAttributeString;
			bool_1 = htmlAttributeAttribute.DetectDefaultValue;
		}

		public string method_0()
		{
			return string_1;
		}

		public string method_1()
		{
			return string_2;
		}

		public bool method_2()
		{
			return bool_0;
		}

		public bool method_3()
		{
			return bool_1;
		}

		public bool method_4()
		{
			return bool_2;
		}

		public bool method_5()
		{
			return bool_3;
		}

		public string method_6(object object_1, ref bool bool_4)
		{
			int num = 8;
			if (object_1 == null)
			{
				throw new ArgumentNullException("instance");
			}
			if (!bool_2)
			{
				return null;
			}
			object value = propertyInfo_0.GetValue(object_1, null);
			if (value == null || DBNull.Value.Equals(value))
			{
				return null;
			}
			if (method_3() && object_0 != null && (object_0 == value || object.Equals(object_0, value)))
			{
				bool_4 = true;
				return null;
			}
			if (value is Color)
			{
				return XMLSerializeHelper.ColorToString((Color)value);
			}
			if (value is DateTime)
			{
				return ((DateTime)value).ToString("yyyy-MM-dd HH:mm:ss");
			}
			if (value is bool)
			{
				if ((bool)value)
				{
					return "true";
				}
				return "false";
			}
			if (value is IDCStringSerializable)
			{
				return ((IDCStringSerializable)value).DCWriteString();
			}
			if (method_2())
			{
				return ValueTypeHelper.GetPropertiesAttributeString(object_1, detectDefaultValue: true);
			}
			return value.ToString();
		}

		public bool method_7(object object_1, string string_3)
		{
			int num = 1;
			if (object_1 == null)
			{
				throw new ArgumentNullException("instance");
			}
			if (!bool_3)
			{
				return false;
			}
			if (string.IsNullOrEmpty(string_3))
			{
				if (object_0 != null)
				{
					propertyInfo_0.SetValue(object_1, object_0, null);
				}
				return true;
			}
			if (type_0.Equals(typeof(string)))
			{
				propertyInfo_0.SetValue(object_1, string_3, null);
			}
			else if (type_0.Equals(typeof(Color)))
			{
				Color color = XMLSerializeHelper.StringToColor(string_3, Color.Black);
				propertyInfo_0.SetValue(object_1, color, null);
			}
			else if (type_0.IsEnum)
			{
				object value = Enum.Parse(type_0, string_3, ignoreCase: true);
				propertyInfo_0.SetValue(object_1, value, null);
			}
			else if (typeof(IDCStringSerializable).IsAssignableFrom(type_0))
			{
				IDCStringSerializable iDCStringSerializable = (IDCStringSerializable)Activator.CreateInstance(type_0);
				iDCStringSerializable.DCReadString(string_3);
				propertyInfo_0.SetValue(object_1, iDCStringSerializable, null);
			}
			else if (type_0.IsEnum)
			{
				object value = Enum.Parse(type_0, string_3);
				propertyInfo_0.SetValue(object_1, value, null);
			}
			else
			{
				object value = null;
				if (!method_2())
				{
					value = Convert.ChangeType(string_3, type_0);
				}
				else
				{
					value = Activator.CreateInstance(type_0);
					ValueTypeHelper.SetPropertiesAttributeString(value, string_3);
				}
				propertyInfo_0.SetValue(object_1, value, null);
			}
			return true;
		}

		public int CompareTo(GClass116 other)
		{
			return string.Compare(method_0(), other.method_0());
		}
	}
}
