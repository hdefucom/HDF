using DCSoft.Common;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public static class GClass364
	{
		private class Class195 : List<Class196>
		{
			private int int_0 = 1;

			public int method_0()
			{
				return int_0++;
			}
		}

		private class Class196
		{
			private string string_0 = null;

			private int int_0 = 0;

			private DateTime dateTime_0 = DateTime.Now;

			private string string_1 = null;

			private string string_2 = null;

			public string method_0()
			{
				return string_0;
			}

			public void method_1(string string_3)
			{
				string_0 = string_3;
			}

			public int method_2()
			{
				return int_0;
			}

			public void method_3(int int_1)
			{
				int_0 = int_1;
			}

			public DateTime method_4()
			{
				return dateTime_0;
			}

			public void method_5(DateTime dateTime_1)
			{
				dateTime_0 = dateTime_1;
			}

			public string method_6()
			{
				return string_1;
			}

			public void method_7(string string_3)
			{
				string_1 = string_3;
			}

			public string method_8()
			{
				return string_2;
			}

			public void method_9(string string_3)
			{
				string_2 = string_3;
			}
		}

		private static bool bool_0 = true;

		private static Dictionary<Type, Class195> dictionary_0 = new Dictionary<Type, Class195>();

		public static bool smethod_0()
		{
			return bool_0;
		}

		public static void smethod_1(bool bool_1)
		{
			bool_0 = bool_1;
		}

		public static int smethod_2(object object_0, string string_0)
		{
			int num = 14;
			if (!smethod_0())
			{
				return -1;
			}
			if (object_0 == null)
			{
				throw new ArgumentNullException("obj");
			}
			Type type = object_0.GetType();
			Class195 @class = smethod_6(type);
			Class196 class2 = new Class196();
			class2.method_3(@class.method_0());
			class2.method_7(string_0);
			class2.method_9(GClass354.smethod_8(2));
			@class.Add(class2);
			return class2.method_2();
		}

		public static void smethod_3(Type type_0, int int_0, string string_0)
		{
			int num = 2;
			if (smethod_0())
			{
				if (type_0 == null)
				{
					throw new ArgumentNullException("t");
				}
				Class195 @class = smethod_6(type_0);
				foreach (Class196 item in @class)
				{
					if (item.method_2() == int_0)
					{
						@class.Remove(item);
						break;
					}
				}
			}
		}

		public static string smethod_4(Type type_0, int int_0)
		{
			int num = 5;
			if (type_0 == null)
			{
				throw new ArgumentNullException("t");
			}
			Class195 @class = smethod_6(type_0);
			foreach (Class196 item in @class)
			{
				if (item.method_2() == int_0)
				{
					return FormatUtils.ToYYYY_MM_DD_HH_MM_SS(item.method_4()) + "创建" + type_0.FullName + "#" + item.method_2() + " " + item.method_6() + "\r\n" + item.method_8();
				}
			}
			return null;
		}

		public static string smethod_5(Type type_0, int int_0)
		{
			int num = 3;
			if (!smethod_0())
			{
				return null;
			}
			if (type_0 == null)
			{
				throw new ArgumentNullException("t");
			}
			Class195 @class = smethod_6(type_0);
			if (@class.Count == 0)
			{
				return null;
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("报告时间:" + FormatUtils.ToYYYY_MM_DD_HH_MM_SS(DateTime.Now));
			foreach (Class196 item in @class)
			{
				stringBuilder.AppendLine(FormatUtils.ToYYYY_MM_DD_HH_MM_SS(item.method_4()) + "创建" + type_0.FullName + "#" + item.method_2());
				if (!string.IsNullOrEmpty(item.method_6()))
				{
					stringBuilder.AppendLine(item.method_6());
				}
				stringBuilder.AppendLine(item.method_8());
				if (stringBuilder.Length > int_0)
				{
					break;
				}
			}
			return stringBuilder.ToString();
		}

		private static Class195 smethod_6(Type type_0)
		{
			Class195 @class = null;
			if (!dictionary_0.ContainsKey(type_0))
			{
				@class = new Class195();
				dictionary_0[type_0] = @class;
			}
			else
			{
				@class = dictionary_0[type_0];
			}
			return @class;
		}
	}
}
