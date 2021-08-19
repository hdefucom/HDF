using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass657
	{
		private sbyte[] sbyte_0;

		private int int_0;

		private int int_1;

		public GClass657(sbyte[] sbyte_1)
		{
			sbyte_0 = sbyte_1;
		}

		public int method_0(int int_2)
		{
			if (int_2 < 1 || int_2 > 32)
			{
				throw new ArgumentException();
			}
			int num = 0;
			if (int_1 > 0)
			{
				int num2 = 8 - int_1;
				int num3 = (int_2 < num2) ? int_2 : num2;
				int num4 = num2 - num3;
				int num5 = 255 >> 8 - num3 << num4;
				num = (sbyte_0[int_0] & num5) >> num4;
				int_2 -= num3;
				int_1 += num3;
				if (int_1 == 8)
				{
					int_1 = 0;
					int_0++;
				}
			}
			if (int_2 > 0)
			{
				while (int_2 >= 8)
				{
					num = ((num << 8) | (sbyte_0[int_0] & 0xFF));
					int_0++;
					int_2 -= 8;
				}
				if (int_2 > 0)
				{
					int num4 = 8 - int_2;
					int num5 = 255 >> num4 << num4;
					num = ((num << int_2) | ((sbyte_0[int_0] & num5) >> num4));
					int_1 += int_2;
				}
			}
			return num;
		}

		public int method_1()
		{
			return 8 * (sbyte_0.Length - int_0) - int_1;
		}
	}
}
