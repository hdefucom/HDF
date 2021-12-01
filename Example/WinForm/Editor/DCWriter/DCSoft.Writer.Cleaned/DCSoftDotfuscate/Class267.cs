using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	internal sealed class Class267
	{
		private const int int_0 = 63;

		private const int int_1 = 17;

		public const string string_0 = "T";

		public const string string_1 = "U";

		public const string string_2 = "Sp";

		public const string string_3 = "act";

		private int int_2;

		private string string_4;

		private sbyte[] sbyte_0;

		private int int_3;

		internal bool method_0()
		{
			return (int_2 & 0x80) != 0;
		}

		internal bool method_1()
		{
			return (int_2 & 0x40) != 0;
		}

		internal string method_2()
		{
			return string_4;
		}

		internal sbyte[] method_3()
		{
			return sbyte_0;
		}

		internal int method_4()
		{
			return int_3;
		}

		private Class267(int int_4, string string_5, sbyte[] sbyte_1, int int_5)
		{
			int_2 = int_4;
			string_4 = string_5;
			sbyte_0 = sbyte_1;
			int_3 = int_5;
		}

		internal static Class267 smethod_0(sbyte[] sbyte_1, int int_4)
		{
			int num = 10;
			int num2 = sbyte_1[int_4] & 0xFF;
			if (((num2 ^ 0x11) & 0x3F) != 0)
			{
				return null;
			}
			int num3 = sbyte_1[int_4 + 1] & 0xFF;
			int num4 = sbyte_1[int_4 + 2] & 0xFF;
			string string_ = Class231.smethod_15(sbyte_1, int_4 + 3, num3, "US-ASCII");
			sbyte[] array = new sbyte[num4];
			Array.Copy(sbyte_1, int_4 + 3 + num3, array, 0, num4);
			return new Class267(num2, string_, array, 3 + num3 + num4);
		}
	}
}
