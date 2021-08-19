using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass619
	{
		private const int int_0 = 32;

		private GClass679 gclass679_0;

		public GClass619(GClass679 gclass679_1)
		{
			gclass679_0 = gclass679_1;
		}

		public GClass639[] method_0()
		{
			int num = gclass679_0.method_1();
			int num2 = gclass679_0.method_0();
			int num3 = num >> 1;
			int num4 = num2 >> 1;
			int num5 = Math.Max(1, num / 256);
			int num6 = Math.Max(1, num2 / 256);
			int num7 = 0;
			int int_ = num;
			int num8 = 0;
			int int_2 = num2;
			GClass639 gClass = method_1(num4, 0, 0, int_2, num3, -num5, 0, int_, num4 >> 1);
			num7 = (int)gClass.vmethod_1() - 1;
			GClass639 gClass2 = method_1(num4, -num6, 0, int_2, num3, 0, num7, int_, num3 >> 1);
			num8 = (int)gClass2.vmethod_0() - 1;
			GClass639 gClass3 = method_1(num4, num6, num8, int_2, num3, 0, num7, int_, num3 >> 1);
			int_2 = (int)gClass3.vmethod_0() + 1;
			GClass639 gClass4 = method_1(num4, 0, num8, int_2, num3, num5, num7, int_, num4 >> 1);
			int_ = (int)gClass4.vmethod_1() + 1;
			gClass = method_1(num4, 0, num8, int_2, num3, -num5, num7, int_, num4 >> 2);
			return new GClass639[4]
			{
				gClass,
				gClass2,
				gClass3,
				gClass4
			};
		}

		private GClass639 method_1(int int_1, int int_2, int int_3, int int_4, int int_5, int int_6, int int_7, int int_8, int int_9)
		{
			int[] array = null;
			int num = int_5;
			int num2 = int_1;
			while (true)
			{
				if (num >= int_8 || num < int_7 || num2 >= int_4 || num2 < int_3)
				{
					throw GException25.smethod_0();
				}
				int[] array2 = (int_2 != 0) ? method_2(num2, int_9, int_7, int_8, bool_0: false) : method_2(num, int_9, int_3, int_4, bool_0: true);
				if (array2 == null)
				{
					break;
				}
				array = array2;
				num += int_6;
				num2 += int_2;
			}
			if (array == null)
			{
				throw GException25.smethod_0();
			}
			if (int_2 == 0)
			{
				int num3 = num - int_6;
				if (array[0] < int_1)
				{
					if (array[1] > int_1)
					{
						return new GClass639((int_6 > 0) ? array[0] : array[1], num3);
					}
					return new GClass639(array[0], num3);
				}
				return new GClass639(array[1], num3);
			}
			int num4 = num2 - int_2;
			if (array[0] < int_5)
			{
				if (array[1] > int_5)
				{
					return new GClass639(num4, (int_2 < 0) ? array[0] : array[1]);
				}
				return new GClass639(num4, array[0]);
			}
			return new GClass639(num4, array[1]);
		}

		private int[] method_2(int int_1, int int_2, int int_3, int int_4, bool bool_0)
		{
			int num = int_3 + int_4 >> 1;
			int num2 = num;
			while (num2 >= int_3)
			{
				if (bool_0 ? gclass679_0.method_3(num2, int_1) : gclass679_0.method_3(int_1, num2))
				{
					num2--;
					continue;
				}
				int num3 = num2;
				do
				{
					num2--;
				}
				while (num2 >= int_3 && !(bool_0 ? gclass679_0.method_3(num2, int_1) : gclass679_0.method_3(int_1, num2)));
				int num4 = num3 - num2;
				if (num2 >= int_3 && num4 <= int_2)
				{
					continue;
				}
				num2 = num3;
				break;
			}
			num2++;
			int num5 = num;
			while (num5 < int_4)
			{
				if (bool_0 ? gclass679_0.method_3(num5, int_1) : gclass679_0.method_3(int_1, num5))
				{
					num5++;
					continue;
				}
				int num3 = num5;
				do
				{
					num5++;
				}
				while (num5 < int_4 && !(bool_0 ? gclass679_0.method_3(num5, int_1) : gclass679_0.method_3(int_1, num5)));
				int num4 = num5 - num3;
				if (num5 < int_4 && num4 <= int_2)
				{
					continue;
				}
				num5 = num3;
				break;
			}
			num5--;
			return (num5 > num2) ? new int[2]
			{
				num2,
				num5
			} : null;
		}
	}
}
