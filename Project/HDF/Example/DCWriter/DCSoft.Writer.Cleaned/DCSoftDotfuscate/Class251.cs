using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	internal sealed class Class251
	{
		private GClass679 gclass679_0;

		private GClass679 gclass679_1;

		private GClass676 gclass676_0;

		internal Class251(GClass679 gclass679_2)
		{
			int num = gclass679_2.method_2();
			if (num < 10 || num > 144 || (num & 1) != 0)
			{
				throw GException25.smethod_0();
			}
			gclass676_0 = method_0(gclass679_2);
			gclass679_0 = method_8(gclass679_2);
			gclass679_1 = new GClass679(gclass679_0.method_2());
		}

		internal GClass676 method_0(GClass679 gclass679_2)
		{
			if (gclass676_0 != null)
			{
				return gclass676_0;
			}
			int num = gclass679_2.method_2();
			int int_ = num;
			return GClass676.smethod_0(num, int_);
		}

		internal sbyte[] method_1()
		{
			sbyte[] array = new sbyte[gclass676_0.method_5()];
			int num = 0;
			int num2 = 4;
			int num3 = 0;
			int num4 = gclass679_0.method_2();
			int num5 = num4;
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			do
			{
				if (num2 == num4 && num3 == 0 && !flag)
				{
					array[num++] = (sbyte)method_4(num4, num5);
					num2 -= 2;
					num3 += 2;
					flag = true;
					continue;
				}
				if (num2 == num4 - 2 && num3 == 0 && (num5 & 3) != 0 && !flag2)
				{
					array[num++] = (sbyte)method_5(num4, num5);
					num2 -= 2;
					num3 += 2;
					flag2 = true;
					continue;
				}
				if (num2 == num4 + 4 && num3 == 2 && (num5 & 7) == 0 && !flag3)
				{
					array[num++] = (sbyte)method_6(num4, num5);
					num2 -= 2;
					num3 += 2;
					flag3 = true;
					continue;
				}
				if (num2 == num4 - 2 && num3 == 0 && (num5 & 7) == 4 && !flag4)
				{
					array[num++] = (sbyte)method_7(num4, num5);
					num2 -= 2;
					num3 += 2;
					flag4 = true;
					continue;
				}
				do
				{
					if (num2 < num4 && num3 >= 0 && !gclass679_1.method_3(num3, num2))
					{
						array[num++] = (sbyte)method_3(num2, num3, num4, num5);
					}
					num2 -= 2;
					num3 += 2;
				}
				while (num2 >= 0 && num3 < num5);
				num2++;
				num3 += 3;
				do
				{
					if (num2 >= 0 && num3 < num5 && !gclass679_1.method_3(num3, num2))
					{
						array[num++] = (sbyte)method_3(num2, num3, num4, num5);
					}
					num2 += 2;
					num3 -= 2;
				}
				while (num2 < num4 && num3 >= 0);
				num2 += 3;
				num3++;
			}
			while (num2 < num4 || num3 < num5);
			if (num != gclass676_0.method_5())
			{
				throw GException25.smethod_0();
			}
			return array;
		}

		internal bool method_2(int int_0, int int_1, int int_2, int int_3)
		{
			if (int_0 < 0)
			{
				int_0 += int_2;
				int_1 += 4 - ((int_2 + 4) & 7);
			}
			if (int_1 < 0)
			{
				int_1 += int_3;
				int_0 += 4 - ((int_3 + 4) & 7);
			}
			gclass679_1.method_4(int_1, int_0);
			return gclass679_0.method_3(int_1, int_0);
		}

		internal int method_3(int int_0, int int_1, int int_2, int int_3)
		{
			int num = 0;
			if (method_2(int_0 - 2, int_1 - 2, int_2, int_3))
			{
				num |= 1;
			}
			num <<= 1;
			if (method_2(int_0 - 2, int_1 - 1, int_2, int_3))
			{
				num |= 1;
			}
			num <<= 1;
			if (method_2(int_0 - 1, int_1 - 2, int_2, int_3))
			{
				num |= 1;
			}
			num <<= 1;
			if (method_2(int_0 - 1, int_1 - 1, int_2, int_3))
			{
				num |= 1;
			}
			num <<= 1;
			if (method_2(int_0 - 1, int_1, int_2, int_3))
			{
				num |= 1;
			}
			num <<= 1;
			if (method_2(int_0, int_1 - 2, int_2, int_3))
			{
				num |= 1;
			}
			num <<= 1;
			if (method_2(int_0, int_1 - 1, int_2, int_3))
			{
				num |= 1;
			}
			num <<= 1;
			if (method_2(int_0, int_1, int_2, int_3))
			{
				num |= 1;
			}
			return num;
		}

		internal int method_4(int int_0, int int_1)
		{
			int num = 0;
			if (method_2(int_0 - 1, 0, int_0, int_1))
			{
				num |= 1;
			}
			num <<= 1;
			if (method_2(int_0 - 1, 1, int_0, int_1))
			{
				num |= 1;
			}
			num <<= 1;
			if (method_2(int_0 - 1, 2, int_0, int_1))
			{
				num |= 1;
			}
			num <<= 1;
			if (method_2(0, int_1 - 2, int_0, int_1))
			{
				num |= 1;
			}
			num <<= 1;
			if (method_2(0, int_1 - 1, int_0, int_1))
			{
				num |= 1;
			}
			num <<= 1;
			if (method_2(1, int_1 - 1, int_0, int_1))
			{
				num |= 1;
			}
			num <<= 1;
			if (method_2(2, int_1 - 1, int_0, int_1))
			{
				num |= 1;
			}
			num <<= 1;
			if (method_2(3, int_1 - 1, int_0, int_1))
			{
				num |= 1;
			}
			return num;
		}

		internal int method_5(int int_0, int int_1)
		{
			int num = 0;
			if (method_2(int_0 - 3, 0, int_0, int_1))
			{
				num |= 1;
			}
			num <<= 1;
			if (method_2(int_0 - 2, 0, int_0, int_1))
			{
				num |= 1;
			}
			num <<= 1;
			if (method_2(int_0 - 1, 0, int_0, int_1))
			{
				num |= 1;
			}
			num <<= 1;
			if (method_2(0, int_1 - 4, int_0, int_1))
			{
				num |= 1;
			}
			num <<= 1;
			if (method_2(0, int_1 - 3, int_0, int_1))
			{
				num |= 1;
			}
			num <<= 1;
			if (method_2(0, int_1 - 2, int_0, int_1))
			{
				num |= 1;
			}
			num <<= 1;
			if (method_2(0, int_1 - 1, int_0, int_1))
			{
				num |= 1;
			}
			num <<= 1;
			if (method_2(1, int_1 - 1, int_0, int_1))
			{
				num |= 1;
			}
			return num;
		}

		internal int method_6(int int_0, int int_1)
		{
			int num = 0;
			if (method_2(int_0 - 1, 0, int_0, int_1))
			{
				num |= 1;
			}
			num <<= 1;
			if (method_2(int_0 - 1, int_1 - 1, int_0, int_1))
			{
				num |= 1;
			}
			num <<= 1;
			if (method_2(0, int_1 - 3, int_0, int_1))
			{
				num |= 1;
			}
			num <<= 1;
			if (method_2(0, int_1 - 2, int_0, int_1))
			{
				num |= 1;
			}
			num <<= 1;
			if (method_2(0, int_1 - 1, int_0, int_1))
			{
				num |= 1;
			}
			num <<= 1;
			if (method_2(1, int_1 - 3, int_0, int_1))
			{
				num |= 1;
			}
			num <<= 1;
			if (method_2(1, int_1 - 2, int_0, int_1))
			{
				num |= 1;
			}
			num <<= 1;
			if (method_2(1, int_1 - 1, int_0, int_1))
			{
				num |= 1;
			}
			return num;
		}

		internal int method_7(int int_0, int int_1)
		{
			int num = 0;
			if (method_2(int_0 - 3, 0, int_0, int_1))
			{
				num |= 1;
			}
			num <<= 1;
			if (method_2(int_0 - 2, 0, int_0, int_1))
			{
				num |= 1;
			}
			num <<= 1;
			if (method_2(int_0 - 1, 0, int_0, int_1))
			{
				num |= 1;
			}
			num <<= 1;
			if (method_2(0, int_1 - 2, int_0, int_1))
			{
				num |= 1;
			}
			num <<= 1;
			if (method_2(0, int_1 - 1, int_0, int_1))
			{
				num |= 1;
			}
			num <<= 1;
			if (method_2(1, int_1 - 1, int_0, int_1))
			{
				num |= 1;
			}
			num <<= 1;
			if (method_2(2, int_1 - 1, int_0, int_1))
			{
				num |= 1;
			}
			num <<= 1;
			if (method_2(3, int_1 - 1, int_0, int_1))
			{
				num |= 1;
			}
			return num;
		}

		internal GClass679 method_8(GClass679 gclass679_2)
		{
			int num = 6;
			int num2 = gclass676_0.method_1();
			int num3 = gclass676_0.method_2();
			if (gclass679_2.method_2() != num2)
			{
				throw new ArgumentException("Dimension of bitMarix must match the version size");
			}
			int num4 = gclass676_0.method_3();
			int num5 = gclass676_0.method_4();
			int num6 = num2 / num4;
			int num7 = num3 / num5;
			int int_ = num6 * num4;
			GClass679 gClass = new GClass679(int_);
			for (int i = 0; i < num6; i++)
			{
				int num8 = i * num4;
				for (int j = 0; j < num7; j++)
				{
					int num9 = j * num5;
					for (int k = 0; k < num4; k++)
					{
						int int_2 = i * (num4 + 2) + 1 + k;
						int int_3 = num8 + k;
						for (int l = 0; l < num5; l++)
						{
							int int_4 = j * (num5 + 2) + 1 + l;
							if (gclass679_2.method_3(int_4, int_2))
							{
								int int_5 = num9 + l;
								gClass.method_4(int_5, int_3);
							}
						}
					}
				}
			}
			return gClass;
		}
	}
}
