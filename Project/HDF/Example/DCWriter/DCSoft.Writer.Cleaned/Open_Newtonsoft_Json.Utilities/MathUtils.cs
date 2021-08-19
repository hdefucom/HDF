using System;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Utilities
{
	[ComVisible(false)]
	internal static class MathUtils
	{
		public static int IntLength(ulong ulong_0)
		{
			if (ulong_0 < 10000000000L)
			{
				if (ulong_0 < 10L)
				{
					return 1;
				}
				if (ulong_0 < 100L)
				{
					return 2;
				}
				if (ulong_0 < 1000L)
				{
					return 3;
				}
				if (ulong_0 < 10000L)
				{
					return 4;
				}
				if (ulong_0 < 100000L)
				{
					return 5;
				}
				if (ulong_0 < 1000000L)
				{
					return 6;
				}
				if (ulong_0 < 10000000L)
				{
					return 7;
				}
				if (ulong_0 < 100000000L)
				{
					return 8;
				}
				if (ulong_0 < 1000000000L)
				{
					return 9;
				}
				return 10;
			}
			if (ulong_0 < 100000000000L)
			{
				return 11;
			}
			if (ulong_0 < 1000000000000L)
			{
				return 12;
			}
			if (ulong_0 < 10000000000000L)
			{
				return 13;
			}
			if (ulong_0 < 100000000000000L)
			{
				return 14;
			}
			if (ulong_0 < 1000000000000000L)
			{
				return 15;
			}
			if (ulong_0 < 10000000000000000L)
			{
				return 16;
			}
			if (ulong_0 < 100000000000000000L)
			{
				return 17;
			}
			if (ulong_0 < 1000000000000000000L)
			{
				return 18;
			}
			if (ulong_0 < 10000000000000000000uL)
			{
				return 19;
			}
			return 20;
		}

		public static char IntToHex(int int_0)
		{
			if (int_0 <= 9)
			{
				return (char)(int_0 + 48);
			}
			return (char)(int_0 - 10 + 97);
		}

		public static int? Min(int? val1, int? val2)
		{
			if (!val1.HasValue)
			{
				return val2;
			}
			if (!val2.HasValue)
			{
				return val1;
			}
			return Math.Min(val1.Value, val2.Value);
		}

		public static int? Max(int? val1, int? val2)
		{
			if (!val1.HasValue)
			{
				return val2;
			}
			if (!val2.HasValue)
			{
				return val1;
			}
			return Math.Max(val1.Value, val2.Value);
		}

		public static double? Max(double? val1, double? val2)
		{
			if (!val1.HasValue)
			{
				return val2;
			}
			if (!val2.HasValue)
			{
				return val1;
			}
			return Math.Max(val1.Value, val2.Value);
		}

		public static bool ApproxEquals(double double_0, double double_1)
		{
			if (double_0 == double_1)
			{
				return true;
			}
			double num = (Math.Abs(double_0) + Math.Abs(double_1) + 10.0) * 2.2204460492503131E-16;
			double num2 = double_0 - double_1;
			return 0.0 - num < num2 && num > num2;
		}
	}
}
