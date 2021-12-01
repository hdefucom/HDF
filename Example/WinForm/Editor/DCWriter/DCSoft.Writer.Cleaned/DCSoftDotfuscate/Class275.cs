using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	internal sealed class Class275
	{
		private GClass679 gclass679_0;

		private GClass672 gclass672_0;

		private Class228 class228_0;

		internal Class275(GClass679 gclass679_1)
		{
			int num = gclass679_1.method_2();
			if (num < 21 || (num & 3) != 1)
			{
				throw GException25.smethod_0();
			}
			gclass679_0 = gclass679_1;
		}

		internal Class228 method_0()
		{
			if (class228_0 != null)
			{
				return class228_0;
			}
			int int_ = 0;
			for (int i = 0; i < 6; i++)
			{
				int_ = method_2(i, 8, int_);
			}
			int_ = method_2(7, 8, int_);
			int_ = method_2(8, 8, int_);
			int_ = method_2(8, 7, int_);
			for (int num = 5; num >= 0; num--)
			{
				int_ = method_2(8, num, int_);
			}
			class228_0 = Class228.smethod_1(int_);
			if (class228_0 != null)
			{
				return class228_0;
			}
			int num2 = gclass679_0.method_2();
			int_ = 0;
			int num3 = num2 - 8;
			for (int i = num2 - 1; i >= num3; i--)
			{
				int_ = method_2(i, 8, int_);
			}
			for (int num = num2 - 7; num < num2; num++)
			{
				int_ = method_2(8, num, int_);
			}
			class228_0 = Class228.smethod_1(int_);
			if (class228_0 != null)
			{
				return class228_0;
			}
			throw GException25.smethod_0();
		}

		internal GClass672 method_1()
		{
			if (gclass672_0 != null)
			{
				return gclass672_0;
			}
			int num = gclass679_0.method_2();
			int num2 = num - 17 >> 2;
			if (num2 <= 6)
			{
				return GClass672.smethod_1(num2);
			}
			int num3 = 0;
			int num4 = num - 11;
			for (int num5 = 5; num5 >= 0; num5--)
			{
				for (int num6 = num - 9; num6 >= num4; num6--)
				{
					num3 = method_2(num6, num5, num3);
				}
			}
			gclass672_0 = GClass672.smethod_2(num3);
			if (gclass672_0 != null && gclass672_0.method_3() == num)
			{
				return gclass672_0;
			}
			num3 = 0;
			for (int num6 = 5; num6 >= 0; num6--)
			{
				for (int num5 = num - 9; num5 >= num4; num5--)
				{
					num3 = method_2(num6, num5, num3);
				}
			}
			gclass672_0 = GClass672.smethod_2(num3);
			if (gclass672_0 != null && gclass672_0.method_3() == num)
			{
				return gclass672_0;
			}
			throw GException25.smethod_0();
		}

		private int method_2(int int_0, int int_1, int int_2)
		{
			return gclass679_0.method_3(int_0, int_1) ? ((int_2 << 1) | 1) : (int_2 << 1);
		}

		internal sbyte[] method_3()
		{
			Class228 @class = method_0();
			GClass672 gClass = method_1();
			Class256 class2 = Class256.smethod_0(@class.method_1());
			int num = gclass679_0.method_2();
			class2.method_0(gclass679_0, num);
			GClass679 gClass2 = gClass.method_5();
			bool flag = true;
			sbyte[] array = new sbyte[gClass.method_2()];
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			for (int num5 = num - 1; num5 > 0; num5 -= 2)
			{
				if (num5 == 6)
				{
					num5--;
				}
				for (int i = 0; i < num; i++)
				{
					int int_ = flag ? (num - 1 - i) : i;
					for (int j = 0; j < 2; j++)
					{
						if (!gClass2.method_3(num5 - j, int_))
						{
							num4++;
							num3 <<= 1;
							if (gclass679_0.method_3(num5 - j, int_))
							{
								num3 |= 1;
							}
							if (num4 == 8)
							{
								array[num2++] = (sbyte)num3;
								num4 = 0;
								num3 = 0;
							}
						}
					}
				}
				flag = !flag;
			}
			if (num2 != gClass.method_2())
			{
				throw GException25.smethod_0();
			}
			return array;
		}
	}
}
