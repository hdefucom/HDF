using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass353
	{
		[ComVisible(false)]
		public delegate string GDelegate19(object object_0);

		[ComVisible(false)]
		public delegate object GDelegate20(string string_0);

		private Type type_0 = null;

		private object object_0 = null;

		public GDelegate19 gdelegate19_0 = null;

		public GDelegate20 gdelegate20_0 = null;

		private static Dictionary<Type, GClass353> dictionary_0 = null;

		[CompilerGenerated]
		private static GDelegate20 gdelegate20_1;

		[CompilerGenerated]
		private static GDelegate19 gdelegate19_1;

		[CompilerGenerated]
		private static GDelegate20 gdelegate20_2;

		[CompilerGenerated]
		private static GDelegate19 gdelegate19_2;

		[CompilerGenerated]
		private static GDelegate20 gdelegate20_3;

		[CompilerGenerated]
		private static GDelegate19 gdelegate19_3;

		[CompilerGenerated]
		private static GDelegate20 gdelegate20_4;

		[CompilerGenerated]
		private static GDelegate19 gdelegate19_4;

		[CompilerGenerated]
		private static GDelegate20 gdelegate20_5;

		[CompilerGenerated]
		private static GDelegate19 gdelegate19_5;

		[CompilerGenerated]
		private static GDelegate20 gdelegate20_6;

		[CompilerGenerated]
		private static GDelegate19 gdelegate19_6;

		[CompilerGenerated]
		private static GDelegate20 gdelegate20_7;

		[CompilerGenerated]
		private static GDelegate19 gdelegate19_7;

		[CompilerGenerated]
		private static GDelegate20 gdelegate20_8;

		[CompilerGenerated]
		private static GDelegate19 gdelegate19_8;

		[CompilerGenerated]
		private static GDelegate20 gdelegate20_9;

		[CompilerGenerated]
		private static GDelegate19 gdelegate19_9;

		[CompilerGenerated]
		private static GDelegate20 gdelegate20_10;

		[CompilerGenerated]
		private static GDelegate19 gdelegate19_10;

		[CompilerGenerated]
		private static GDelegate20 gdelegate20_11;

		[CompilerGenerated]
		private static GDelegate19 gdelegate19_11;

		[CompilerGenerated]
		private static GDelegate20 gdelegate20_12;

		[CompilerGenerated]
		private static GDelegate19 gdelegate19_12;

		[CompilerGenerated]
		private static GDelegate20 gdelegate20_13;

		[CompilerGenerated]
		private static GDelegate19 gdelegate19_13;

		[CompilerGenerated]
		private static GDelegate20 gdelegate20_14;

		[CompilerGenerated]
		private static GDelegate19 gdelegate19_14;

		[CompilerGenerated]
		private static GDelegate20 gdelegate20_15;

		[CompilerGenerated]
		private static GDelegate19 gdelegate19_15;

		public Type method_0()
		{
			return type_0;
		}

		public virtual object vmethod_0()
		{
			return object_0;
		}

		public virtual string vmethod_1(object object_1)
		{
			if (gdelegate19_0 != null)
			{
				return gdelegate19_0(object_1);
			}
			return Convert.ToString(object_1);
		}

		public virtual object vmethod_2(string string_0)
		{
			if (gdelegate20_0 != null)
			{
				return gdelegate20_0(string_0);
			}
			return null;
		}

		public static object smethod_0(Type type_1)
		{
			smethod_1();
			if (dictionary_0.ContainsKey(type_1))
			{
				GClass353 gClass = dictionary_0[type_1];
				return gClass.vmethod_0();
			}
			if (type_1.IsValueType)
			{
				return Activator.CreateInstance(type_1);
			}
			return null;
		}

		private static void smethod_1()
		{
			if (dictionary_0 == null)
			{
				dictionary_0 = new Dictionary<Type, GClass353>();
				smethod_2(typeof(string), null, (string string_0) => string_0, (object object_1) => (string)object_1);
				smethod_2(typeof(byte), (byte)0, (string string_0) => Convert.ToByte(string_0), (object object_1) => object_1.ToString());
				smethod_2(typeof(sbyte), (sbyte)0, (string string_0) => Convert.ToSByte(string_0), (object object_1) => object_1.ToString());
				smethod_2(typeof(char), '\0', (string string_0) => (string_0 == null || string_0.Length == 0) ? ((object)'\0') : ((object)string_0[0]), (object object_1) => object_1.ToString());
				smethod_2(typeof(short), (short)0, (string string_0) => Convert.ToInt16(string_0), (object object_1) => object_1.ToString());
				smethod_2(typeof(ushort), (ushort)0, (string string_0) => Convert.ToUInt16(string_0), (object object_1) => object_1.ToString());
				smethod_2(typeof(int), 0, (string string_0) => Convert.ToInt32(string_0), (object object_1) => object_1.ToString());
				smethod_2(typeof(uint), 0u, (string string_0) => Convert.ToUInt32(string_0), (object object_1) => object_1.ToString());
				smethod_2(typeof(long), 0L, (string string_0) => Convert.ToInt64(string_0), (object object_1) => object_1.ToString());
				smethod_2(typeof(ulong), 0uL, (string string_0) => Convert.ToUInt64(string_0), (object object_1) => object_1.ToString());
				smethod_2(typeof(float), 0f, (string string_0) => Convert.ToSingle(string_0), (object object_1) => object_1.ToString());
				smethod_2(typeof(double), 0.0, (string string_0) => Convert.ToDouble(string_0), (object object_1) => object_1.ToString());
				smethod_2(typeof(DateTime), DateTime.MinValue, (string string_0) => Convert.ToDateTime(string_0), (object object_1) => object_1.ToString());
				smethod_2(typeof(bool), false, (string string_0) => Convert.ToBoolean(string_0), (object object_1) => object_1.ToString());
				smethod_2(typeof(decimal), 0m, (string string_0) => Convert.ToDecimal(string_0), (object object_1) => object_1.ToString());
			}
		}

		public static GClass353 smethod_2(Type type_1, object object_1, GDelegate20 gdelegate20_16, GDelegate19 gdelegate19_16)
		{
			GClass353 gClass = new GClass353();
			gClass.type_0 = type_1;
			gClass.object_0 = object_1;
			gClass.gdelegate20_0 = gdelegate20_16;
			gClass.gdelegate19_0 = gdelegate19_16;
			dictionary_0[type_1] = gClass;
			return gClass;
		}

		[CompilerGenerated]
		private static object smethod_3(string string_0)
		{
			return string_0;
		}

		[CompilerGenerated]
		private static string smethod_4(object object_1)
		{
			return (string)object_1;
		}

		[CompilerGenerated]
		private static object smethod_5(string string_0)
		{
			return Convert.ToByte(string_0);
		}

		[CompilerGenerated]
		private static string smethod_6(object object_1)
		{
			return object_1.ToString();
		}

		[CompilerGenerated]
		private static object smethod_7(string string_0)
		{
			return Convert.ToSByte(string_0);
		}

		[CompilerGenerated]
		private static string smethod_8(object object_1)
		{
			return object_1.ToString();
		}

		[CompilerGenerated]
		private static object smethod_9(string string_0)
		{
			if (string_0 == null || string_0.Length == 0)
			{
				return '\0';
			}
			return string_0[0];
		}

		[CompilerGenerated]
		private static string smethod_10(object object_1)
		{
			return object_1.ToString();
		}

		[CompilerGenerated]
		private static object smethod_11(string string_0)
		{
			return Convert.ToInt16(string_0);
		}

		[CompilerGenerated]
		private static string smethod_12(object object_1)
		{
			return object_1.ToString();
		}

		[CompilerGenerated]
		private static object smethod_13(string string_0)
		{
			return Convert.ToUInt16(string_0);
		}

		[CompilerGenerated]
		private static string smethod_14(object object_1)
		{
			return object_1.ToString();
		}

		[CompilerGenerated]
		private static object smethod_15(string string_0)
		{
			return Convert.ToInt32(string_0);
		}

		[CompilerGenerated]
		private static string smethod_16(object object_1)
		{
			return object_1.ToString();
		}

		[CompilerGenerated]
		private static object smethod_17(string string_0)
		{
			return Convert.ToUInt32(string_0);
		}

		[CompilerGenerated]
		private static string smethod_18(object object_1)
		{
			return object_1.ToString();
		}

		[CompilerGenerated]
		private static object smethod_19(string string_0)
		{
			return Convert.ToInt64(string_0);
		}

		[CompilerGenerated]
		private static string smethod_20(object object_1)
		{
			return object_1.ToString();
		}

		[CompilerGenerated]
		private static object smethod_21(string string_0)
		{
			return Convert.ToUInt64(string_0);
		}

		[CompilerGenerated]
		private static string smethod_22(object object_1)
		{
			return object_1.ToString();
		}

		[CompilerGenerated]
		private static object smethod_23(string string_0)
		{
			return Convert.ToSingle(string_0);
		}

		[CompilerGenerated]
		private static string smethod_24(object object_1)
		{
			return object_1.ToString();
		}

		[CompilerGenerated]
		private static object smethod_25(string string_0)
		{
			return Convert.ToDouble(string_0);
		}

		[CompilerGenerated]
		private static string smethod_26(object object_1)
		{
			return object_1.ToString();
		}

		[CompilerGenerated]
		private static object smethod_27(string string_0)
		{
			return Convert.ToDateTime(string_0);
		}

		[CompilerGenerated]
		private static string smethod_28(object object_1)
		{
			return object_1.ToString();
		}

		[CompilerGenerated]
		private static object smethod_29(string string_0)
		{
			return Convert.ToBoolean(string_0);
		}

		[CompilerGenerated]
		private static string smethod_30(object object_1)
		{
			return object_1.ToString();
		}

		[CompilerGenerated]
		private static object smethod_31(string string_0)
		{
			return Convert.ToDecimal(string_0);
		}

		[CompilerGenerated]
		private static string smethod_32(object object_1)
		{
			return object_1.ToString();
		}
	}
}
