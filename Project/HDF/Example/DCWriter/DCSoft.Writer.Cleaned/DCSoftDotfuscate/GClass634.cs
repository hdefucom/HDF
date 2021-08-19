using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass634
	{
		[ComVisible(false)]
		public static byte[] smethod_0(sbyte[] sbyte_0)
		{
			byte[] array = null;
			if (sbyte_0 != null)
			{
				array = new byte[sbyte_0.Length];
				for (int i = 0; i < sbyte_0.Length; i++)
				{
					array[i] = (byte)sbyte_0[i];
				}
			}
			return array;
		}

		public static byte[] smethod_1(string string_0)
		{
			return Encoding.UTF8.GetBytes(string_0);
		}

		public static byte[] smethod_2(object[] object_0)
		{
			byte[] array = null;
			if (object_0 != null)
			{
				array = new byte[object_0.Length];
				for (int i = 0; i < object_0.Length; i++)
				{
					array[i] = (byte)object_0[i];
				}
			}
			return array;
		}

		public static int smethod_3(int int_0, int int_1)
		{
			if (int_0 >= 0)
			{
				return int_0 >> int_1;
			}
			return (int_0 >> int_1) + (2 << ~int_1);
		}

		public static int smethod_4(int int_0, long long_0)
		{
			return smethod_3(int_0, (int)long_0);
		}

		public static long smethod_5(long long_0, int int_0)
		{
			if (long_0 >= 0L)
			{
				return long_0 >> int_0;
			}
			return (long_0 >> int_0) + (2L << ~int_0);
		}

		public static long smethod_6(long long_0, long long_1)
		{
			return smethod_5(long_0, (int)long_1);
		}

		public static long smethod_7(long long_0)
		{
			return long_0;
		}

		public static ulong smethod_8(ulong ulong_0)
		{
			return ulong_0;
		}

		public static float smethod_9(float float_0)
		{
			return float_0;
		}

		public static double smethod_10(double double_0)
		{
			return double_0;
		}

		public static void smethod_11(string string_0, int int_0, int int_1, char[] char_0, int int_2)
		{
			int num = int_0;
			int num2 = int_2;
			while (num < int_1)
			{
				char_0[num2] = string_0[num];
				num++;
				num2++;
			}
		}

		public static void smethod_12(ArrayList arrayList_0, int int_0)
		{
			if (int_0 > arrayList_0.Count)
			{
				arrayList_0.AddRange(new Array[int_0 - arrayList_0.Count]);
			}
			else if (int_0 < arrayList_0.Count)
			{
				arrayList_0.RemoveRange(int_0, arrayList_0.Count - int_0);
			}
			arrayList_0.Capacity = int_0;
		}

		public static sbyte[] smethod_13(byte[] byte_0)
		{
			sbyte[] array = null;
			if (byte_0 != null)
			{
				array = new sbyte[byte_0.Length];
				for (int i = 0; i < byte_0.Length; i++)
				{
					array[i] = (sbyte)byte_0[i];
				}
			}
			return array;
		}
	}
}
