using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass618
	{
		public static readonly GClass618 gclass618_0 = new GClass618(285);

		public static readonly GClass618 gclass618_1 = new GClass618(301);

		private int[] int_0;

		private int[] int_1;

		private Class255 class255_0;

		private Class255 class255_1;

		internal Class255 method_0()
		{
			return class255_0;
		}

		internal Class255 method_1()
		{
			return class255_1;
		}

		private GClass618(int int_2)
		{
			int_0 = new int[256];
			int_1 = new int[256];
			int num = 1;
			for (int i = 0; i < 256; i++)
			{
				int_0[i] = num;
				num <<= 1;
				if (num >= 256)
				{
					num ^= int_2;
				}
			}
			for (int i = 0; i < 255; i++)
			{
				int_1[int_0[i]] = i;
			}
			int[] array = new int[1];
			class255_0 = new Class255(this, array);
			class255_1 = new Class255(this, new int[1]
			{
				1
			});
		}

		internal Class255 method_2(int int_2, int int_3)
		{
			if (int_2 < 0)
			{
				throw new ArgumentException();
			}
			if (int_3 == 0)
			{
				return class255_0;
			}
			int[] array = new int[int_2 + 1];
			array[0] = int_3;
			return new Class255(this, array);
		}

		internal static int smethod_0(int int_2, int int_3)
		{
			return int_2 ^ int_3;
		}

		internal int method_3(int int_2)
		{
			return int_0[int_2];
		}

		internal int method_4(int int_2)
		{
			if (int_2 == 0)
			{
				throw new ArgumentException();
			}
			return int_1[int_2];
		}

		internal int method_5(int int_2)
		{
			if (int_2 == 0)
			{
				throw new ArithmeticException();
			}
			return int_0[255 - int_1[int_2]];
		}

		internal int method_6(int int_2, int int_3)
		{
			if (int_2 == 0 || int_3 == 0)
			{
				return 0;
			}
			if (int_2 == 1)
			{
				return int_3;
			}
			if (int_3 == 1)
			{
				return int_2;
			}
			return int_0[(int_1[int_2] + int_1[int_3]) % 255];
		}
	}
}
