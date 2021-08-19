using System;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass635
	{
		private const int int_0 = 32;

		private int int_1;

		private sbyte[] sbyte_0;

		public sbyte[] method_0()
		{
			return sbyte_0;
		}

		public GClass635()
		{
			int_1 = 0;
			sbyte_0 = new sbyte[32];
		}

		public int method_1(int int_2)
		{
			int num = 2;
			if (int_2 < 0 || int_2 >= int_1)
			{
				throw new ArgumentException("Bad index: " + int_2);
			}
			int num2 = sbyte_0[int_2 >> 3] & 0xFF;
			return (num2 >> 7 - (int_2 & 7)) & 1;
		}

		public int method_2()
		{
			return int_1;
		}

		public int method_3()
		{
			return int_1 + 7 >> 3;
		}

		public void method_4(int int_2)
		{
			int num = 16;
			if (int_2 != 0 && int_2 != 1)
			{
				throw new ArgumentException("Bad bit");
			}
			int num2 = int_1 & 7;
			if (num2 == 0)
			{
				method_8(0);
				int_1 -= 8;
			}
			sbyte_0[int_1 >> 3] |= (sbyte)(int_2 << 7 - num2);
			int_1++;
		}

		public void method_5(int int_2, int int_3)
		{
			int num = 0;
			if (int_3 < 0 || int_3 > 32)
			{
				throw new ArgumentException("Num bits must be between 0 and 32");
			}
			int num2 = int_3;
			while (num2 > 0)
			{
				if ((int_1 & 7) == 0 && num2 >= 8)
				{
					int int_4 = (int_2 >> num2 - 8) & 0xFF;
					method_8(int_4);
					num2 -= 8;
				}
				else
				{
					int int_5 = (int_2 >> num2 - 1) & 1;
					method_4(int_5);
					num2--;
				}
			}
		}

		public void method_6(GClass635 gclass635_0)
		{
			int num = gclass635_0.method_2();
			for (int i = 0; i < num; i++)
			{
				method_4(gclass635_0.method_1(i));
			}
		}

		public void method_7(GClass635 gclass635_0)
		{
			int num = 16;
			if (int_1 != gclass635_0.method_2())
			{
				throw new ArgumentException("BitVector sizes don't match");
			}
			int num2 = int_1 + 7 >> 3;
			for (int i = 0; i < num2; i++)
			{
				sbyte_0[i] ^= gclass635_0.sbyte_0[i];
			}
		}

		public override string ToString()
		{
			int num = 3;
			StringBuilder stringBuilder = new StringBuilder(int_1);
			for (int i = 0; i < int_1; i++)
			{
				if (method_1(i) == 0)
				{
					stringBuilder.Append('0');
					continue;
				}
				if (method_1(i) == 1)
				{
					stringBuilder.Append('1');
					continue;
				}
				throw new ArgumentException("Byte isn't 0 or 1");
			}
			return stringBuilder.ToString();
		}

		private void method_8(int int_2)
		{
			if (int_1 >> 3 == sbyte_0.Length)
			{
				sbyte[] destinationArray = new sbyte[sbyte_0.Length << 1];
				Array.Copy(sbyte_0, 0, destinationArray, 0, sbyte_0.Length);
				sbyte_0 = destinationArray;
			}
			sbyte_0[int_1 >> 3] = (sbyte)int_2;
			int_1 += 8;
		}
	}
}
