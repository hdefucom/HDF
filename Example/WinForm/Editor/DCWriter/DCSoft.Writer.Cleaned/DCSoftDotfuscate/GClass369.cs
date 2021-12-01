using DCSoft.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public static class GClass369
	{
		public static string smethod_0(Assembly assembly_0)
		{
			int num = 5;
			if (assembly_0 == null)
			{
				throw new ArgumentNullException("asm");
			}
			List<Type> list_ = new List<Type>();
			StringBuilder stringBuilder = new StringBuilder();
			List<Type> list = new List<Type>();
			list.AddRange(assembly_0.GetTypes());
			list.Sort(new TypeNameComparer(bool_1: true));
			foreach (Type item in list)
			{
				if (Attribute.GetCustomAttribute(item, typeof(SerializableAttribute), inherit: false) != null)
				{
					smethod_1(item, stringBuilder, list_);
				}
			}
			return stringBuilder.ToString();
		}

		private static void smethod_1(Type type_0, StringBuilder stringBuilder_0, List<Type> list_0)
		{
			int num = 13;
			if (typeof(Control).IsAssignableFrom(type_0))
			{
				stringBuilder_0.AppendLine("错误:控件类型" + type_0.FullName + "不能标记为序列化");
				return;
			}
			FieldInfo[] fields = type_0.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			foreach (FieldInfo fieldInfo in fields)
			{
				NonSerializedAttribute nonSerializedAttribute = (NonSerializedAttribute)Attribute.GetCustomAttribute(fieldInfo, typeof(NonSerializedAttribute), inherit: false);
				if (nonSerializedAttribute != null)
				{
					continue;
				}
				Type type = fieldInfo.FieldType;
				if (list_0.Contains(type))
				{
					continue;
				}
				list_0.Add(type);
				if (type.IsArray)
				{
					type = type.GetElementType();
					if (type == null)
					{
						type = fieldInfo.FieldType;
					}
				}
				if (type.IsPrimitive || type.IsEnum || type.Equals(typeof(string)))
				{
					continue;
				}
				SerializableAttribute serializableAttribute = (SerializableAttribute)Attribute.GetCustomAttribute(type, typeof(SerializableAttribute), inherit: false);
				if (serializableAttribute == null)
				{
					if (type.IsInterface)
					{
						stringBuilder_0.AppendLine("提示:字段 " + type_0.FullName + "." + fieldInfo.Name + " 的类型 " + type.FullName + " 没有标记为可序列化");
					}
					else
					{
						stringBuilder_0.AppendLine("警告:字段 " + type_0.FullName + "." + fieldInfo.Name + " 的类型 " + type.FullName + " 没有标记为可序列化");
					}
				}
				else
				{
					smethod_1(type, stringBuilder_0, list_0);
				}
			}
		}

		public static string smethod_2(string string_0)
		{
			int num = 16;
			if (string_0 == null)
			{
				return string_0;
			}
			int length = string_0.Length;
			if (length > 100)
			{
				string_0 = string_0.Substring(0, length) + "[长度" + length + "]";
			}
			return string_0;
		}

		public static string smethod_3(object object_0)
		{
			int num = 0;
			if (object_0 == null)
			{
				return "[NULL]";
			}
			StringBuilder stringBuilder = new StringBuilder();
			Type type = object_0.GetType();
			stringBuilder.AppendLine(type.FullName);
			if (type.IsPrimitive || type.IsEnum || object_0 is decimal || object_0 is DateTime || object_0 is string)
			{
				stringBuilder.AppendLine(string.Concat("[", object_0, "]"));
				return stringBuilder.ToString();
			}
			try
			{
				if (object_0 is byte[])
				{
					byte[] array = (byte[])object_0;
					return "[" + array.Length + "个字节]";
				}
				if (object_0 is IDictionary)
				{
					IDictionary dictionary = (IDictionary)object_0;
					foreach (object key in dictionary.Keys)
					{
						if (key != null)
						{
							object obj = dictionary[key];
							stringBuilder.Append(Convert.ToString(key));
						}
					}
				}
				PropertyInfo[] properties = type.GetProperties();
				PropertyInfo[] array2 = properties;
				foreach (PropertyInfo propertyInfo in array2)
				{
					if (propertyInfo.CanRead)
					{
						stringBuilder.Append(propertyInfo.Name + "=");
						try
						{
							object obj = propertyInfo.GetValue(object_0, null);
							stringBuilder.Append(smethod_4(obj));
						}
						catch (Exception ex)
						{
							stringBuilder.Append(ex.Message);
						}
						stringBuilder.AppendLine();
					}
				}
			}
			catch (Exception ex2)
			{
				stringBuilder.AppendLine(ex2.Message);
			}
			return stringBuilder.ToString();
		}

		public static string smethod_4(object object_0)
		{
			int num = 16;
			if (object_0 == null)
			{
				return "[NULL]";
			}
			if (DBNull.Value.Equals(object_0))
			{
				return "[DBNULL]";
			}
			if (object_0 is string)
			{
				string text = (string)object_0;
				int length = text.Length;
				if (text.Length > 20)
				{
					text = text.Substring(0, 20);
					return "\"" + text + "\"[共" + length + "个字符]";
				}
				return "\"" + text + "\"";
			}
			if (object_0 is byte[])
			{
				byte[] array = (byte[])object_0;
				return "[" + array.Length + "字节]";
			}
			if (object_0 is IEnumerable)
			{
				return smethod_6((IEnumerable)object_0);
			}
			return Convert.ToString(object_0);
		}

		public static string smethod_5(IEnumerable ienumerable_0, string string_0)
		{
			int num = 13;
			if (ienumerable_0 == null)
			{
				return "[NULL]";
			}
			if (string.IsNullOrEmpty(string_0))
			{
				return smethod_6(ienumerable_0);
			}
			StringBuilder stringBuilder = new StringBuilder();
			PropertyInfo propertyInfo = null;
			try
			{
				foreach (object item in ienumerable_0)
				{
					if (stringBuilder.Length > 0)
					{
						stringBuilder.Append(",");
					}
					if (item == null)
					{
						stringBuilder.Append("[NULL]");
					}
					if (propertyInfo == null)
					{
						propertyInfo = item.GetType().GetProperty(string_0, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
						if (propertyInfo == null)
						{
							return "没有属性 " + string_0;
						}
					}
					object value = propertyInfo.GetValue(item, null);
					if (value == null)
					{
						stringBuilder.Append("[NULL]");
					}
					else
					{
						stringBuilder.Append(Convert.ToString(value));
					}
				}
			}
			catch (Exception ex)
			{
				stringBuilder.Append(ex.Message);
			}
			return stringBuilder.ToString();
		}

		public static string smethod_6(IEnumerable ienumerable_0)
		{
			int num = 1;
			if (ienumerable_0 == null)
			{
				return "[NULL]";
			}
			StringBuilder stringBuilder = new StringBuilder();
			foreach (object item in ienumerable_0)
			{
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append(",");
				}
				if (item == null)
				{
					stringBuilder.Append("[NULL]");
				}
				else
				{
					stringBuilder.Append(Convert.ToString(item));
				}
			}
			return stringBuilder.ToString();
		}
	}
}
