using System;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass659
	{
		public int[] int_0;

		public int int_1;

		public int method_0()
		{
			return int_1;
		}

		public GClass659(int int_2)
		{
			int num = 16;
			
			if (int_2 < 1)
			{
				throw new ArgumentException("size must be at least 1");
			}
			int_1 = int_2;
			int_0 = smethod_0(int_2);
		}

		public bool method_1(int int_2)
		{
			return (int_0[int_2 >> 5] & (1 << (int_2 & 0x1F))) != 0;
		}

		public void method_2(int int_2)
		{
			int_0[int_2 >> 5] |= 1 << int_2;
		}

		public void method_3(int int_2)
		{
			int_0[int_2 >> 5] ^= 1 << int_2;
		}

		public void method_4(int int_2, int int_3)
		{
			int_0[int_2 >> 5] = int_3;
		}

		public void method_5()
		{
			int num = int_0.Length;
			for (int i = 0; i < num; i++)
			{
				int_0[i] = 0;
			}
		}

		public bool method_6(int int_2, int int_3, bool bool_0)
		{
			if (int_3 < int_2)
			{
				throw new ArgumentException();
			}
			if (int_3 == int_2)
			{
				return true;
			}
			int_3--;
			int num = int_2 >> 5;
			int num2 = int_3 >> 5;
			int num3 = num;
			while (true)
			{
				if (num3 <= num2)
				{
					int num4 = (num3 <= num) ? (int_2 & 0x1F) : 0;
					int num5 = (num3 < num2) ? 31 : (int_3 & 0x1F);
					int num6;
					if (num4 == 0 && num5 == 31)
					{
						num6 = -1;
					}
					else
					{
						num6 = 0;
						for (int i = num4; i <= num5; i++)
						{
							num6 |= 1 << i;
						}
					}
					if ((int_0[num3] & num6) != (bool_0 ? num6 : 0))
					{
						break;
					}
					num3++;
					continue;
				}
				return true;
			}
			return false;
		}

		public int[] method_7()
		{
			return int_0;
		}

		public void method_8()
		{
			int[] array = new int[int_0.Length];
			int num = int_1;
			for (int i = 0; i < num; i++)
			{
				if (method_1(num - i - 1))
				{
					array[i >> 5] |= 1 << i;
				}
			}
			int_0 = array;
		}

		private static int[] smethod_0(int int_2)
		{
			int num = int_2 >> 5;
			if ((int_2 & 0x1F) != 0)
			{
				num++;
			}
			return new int[num];
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder(int_1);
			for (int i = 0; i < int_1; i++)
			{
				if ((i & 7) == 0)
				{
					stringBuilder.Append(' ');
				}
				stringBuilder.Append(method_1(i) ? 'X' : '.');
			}
			return stringBuilder.ToString();
		}
	}
}
