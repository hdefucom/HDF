using System;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass679
	{
		public int int_0;

		public int int_1;

		public int int_2;

		public int[] int_3;

		public int method_0()
		{
			return int_0;
		}

		public int method_1()
		{
			return int_1;
		}

		public int method_2()
		{
			int num = 10;
			if (int_0 != int_1)
			{
				throw new SystemException("Can't call getDimension() on a non-square matrix");
			}
			return int_0;
		}

		public GClass679(int int_4)
			: this(int_4, int_4)
		{
		}

		public GClass679(int int_4, int int_5)
		{
			int num = 8;
			
			if (int_4 < 1 || int_5 < 1)
			{
				throw new ArgumentException("Both dimensions must be greater than 0");
			}
			int_0 = int_4;
			int_1 = int_5;
			int num2 = int_4 >> 5;
			if ((int_4 & 0x1F) != 0)
			{
				num2++;
			}
			int_2 = num2;
			int_3 = new int[num2 * int_5];
		}

		public bool method_3(int int_4, int int_5)
		{
			int num = int_5 * int_2 + (int_4 >> 5);
			return (GClass634.smethod_3(int_3[num], int_4 & 0x1F) & 1) != 0;
		}

		public void method_4(int int_4, int int_5)
		{
			int num = int_5 * int_2 + (int_4 >> 5);
			int_3[num] |= 1 << int_4;
		}

		public void method_5(int int_4, int int_5)
		{
			int num = int_5 * int_2 + (int_4 >> 5);
			int_3[num] ^= 1 << int_4;
		}

		public void method_6()
		{
			int num = int_3.Length;
			for (int i = 0; i < num; i++)
			{
				int_3[i] = 0;
			}
		}

		public void method_7(int int_4, int int_5, int int_6, int int_7)
		{
			int num = 13;
			if (int_5 < 0 || int_4 < 0)
			{
				throw new ArgumentException("Left and top must be nonnegative");
			}
			if (int_7 < 1 || int_6 < 1)
			{
				throw new ArgumentException("Height and width must be at least 1");
			}
			int num2 = int_4 + int_6;
			int num3 = int_5 + int_7;
			if (num3 > int_1 || num2 > int_0)
			{
				throw new ArgumentException("The region must fit inside the matrix");
			}
			for (int i = int_5; i < num3; i++)
			{
				int num4 = i * int_2;
				for (int j = int_4; j < num2; j++)
				{
					int_3[num4 + (j >> 5)] |= 1 << j;
				}
			}
		}

		public GClass659 method_8(int int_4, GClass659 gclass659_0)
		{
			if (gclass659_0 == null || gclass659_0.method_0() < int_0)
			{
				gclass659_0 = new GClass659(int_0);
			}
			int num = int_4 * int_2;
			for (int i = 0; i < int_2; i++)
			{
				gclass659_0.method_4(i << 5, int_3[num + i]);
			}
			return gclass659_0;
		}

		public override string ToString()
		{
			int num = 3;
			StringBuilder stringBuilder = new StringBuilder(int_1 * (int_0 + 1));
			for (int i = 0; i < int_1; i++)
			{
				for (int j = 0; j < int_0; j++)
				{
					stringBuilder.Append(method_3(j, i) ? "X " : "  ");
				}
				stringBuilder.Append('\n');
			}
			return stringBuilder.ToString();
		}
	}
}
