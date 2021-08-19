using DCSoft.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[DocumentComment]
	[ComVisible(false)]
	public static class GClass346
	{
		private class Class190 : IComparer
		{
			public int Compare(object object_0, object object_1)
			{
				return string.Compare(object_0.ToString(), object_1.ToString());
			}
		}

		private class Class191
		{
			private Class192[] class192_0 = null;

			public Class192[] method_0()
			{
				return class192_0;
			}

			public void method_1(Class192[] class192_1)
			{
				class192_0 = class192_1;
			}
		}

		private class Class192
		{
			private object object_0 = null;

			private string string_0 = null;

			private string string_1 = null;

			public Class192(object object_1, string string_2, string string_3)
			{
				object_0 = object_1;
				string_0 = string_2;
				string_1 = string_3;
			}

			public object method_0()
			{
				return object_0;
			}

			public string method_1()
			{
				return string_0;
			}

			public string method_2()
			{
				return string_1;
			}

			public override string ToString()
			{
				return string_1;
			}
		}

		private static Dictionary<Type, Class191> dictionary_0 = new Dictionary<Type, Class191>();

		public static object[] smethod_0(Type type_0)
		{
			int num = 12;
			if (type_0 == null)
			{
				throw new ArgumentNullException("enumType");
			}
			if (!type_0.IsEnum)
			{
				throw new ArgumentOutOfRangeException(type_0.FullName);
			}
			ArrayList arrayList = new ArrayList();
			foreach (object value in Enum.GetValues(type_0))
			{
				arrayList.Add(value);
			}
			arrayList.Sort(new Class190());
			return arrayList.ToArray();
		}

		public static object[] smethod_1(Type type_0)
		{
			Class191 @class = smethod_5(type_0);
			object[] array = new object[@class.method_0().Length * 2];
			for (int i = 0; i < @class.method_0().Length; i++)
			{
				array[i * 2] = @class.method_0()[i].method_0();
				array[i * 2 + 1] = @class.method_0()[i].method_2();
			}
			return array;
		}

		public static string[] smethod_2(Type type_0)
		{
			Class191 @class = smethod_5(type_0);
			string[] array = new string[@class.method_0().Length];
			for (int i = 0; i < @class.method_0().Length; i++)
			{
				array[i] = @class.method_0()[i].method_2();
			}
			return array;
		}

		public static string smethod_3(object object_0)
		{
			if (object_0 == null)
			{
				return null;
			}
			Class191 @class = smethod_5(object_0.GetType());
			int num = 0;
			while (true)
			{
				if (num < @class.method_0().Length)
				{
					if (@class.method_0()[num].method_0() == object_0)
					{
						break;
					}
					num++;
					continue;
				}
				return null;
			}
			return @class.method_0()[num].method_2();
		}

		public static object smethod_4(Type type_0, string string_0)
		{
			Class191 @class = smethod_5(type_0);
			Class192[] array = @class.method_0();
			int num = 0;
			Class192 class2;
			while (true)
			{
				if (num < array.Length)
				{
					class2 = array[num];
					if (string.Compare(class2.method_2(), string_0, ignoreCase: true) == 0)
					{
						break;
					}
					num++;
					continue;
				}
				return null;
			}
			return class2.method_0();
		}

		private static Class191 smethod_5(Type type_0)
		{
			int num = 10;
			if (type_0 == null)
			{
				throw new ArgumentNullException("enumType");
			}
			if (!type_0.IsEnum)
			{
				throw new ArgumentException(type_0.FullName);
			}
			if (!dictionary_0.ContainsKey(type_0))
			{
				Class191 @class = new Class191();
				List<Class192> list = new List<Class192>();
				FieldInfo[] fields = type_0.GetFields(BindingFlags.Static | BindingFlags.Public);
				foreach (FieldInfo fieldInfo in fields)
				{
					DescriptionAttribute descriptionAttribute = (DescriptionAttribute)Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute), inherit: false);
					string text = null;
					if (descriptionAttribute != null)
					{
						text = descriptionAttribute.Description;
					}
					string text2 = text;
					if (string.IsNullOrEmpty(text2))
					{
						text2 = fieldInfo.Name;
					}
					Class192 item = new Class192(fieldInfo.GetValue(null), text, text2);
					list.Add(item);
				}
				@class.method_1(list.ToArray());
				dictionary_0[type_0] = @class;
			}
			return dictionary_0[type_0];
		}
	}
}
