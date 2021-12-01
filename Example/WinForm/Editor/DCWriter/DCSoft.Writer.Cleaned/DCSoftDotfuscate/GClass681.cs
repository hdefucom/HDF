using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass681
	{
		private GClass618 gclass618_0;

		public GClass681(GClass618 gclass618_1)
		{
			gclass618_0 = gclass618_1;
		}

		public void method_0(int[] int_0, int int_1)
		{
			int num = 6;
			Class255 @class = new Class255(gclass618_0, int_0);
			int[] array = new int[int_1];
			bool flag = gclass618_0.Equals(GClass618.gclass618_1);
			bool flag2 = true;
			int i;
			for (i = 0; i < int_1; i++)
			{
				int num2 = @class.method_4(gclass618_0.method_3(flag ? (i + 1) : i));
				array[array.Length - 1 - i] = num2;
				if (num2 != 0)
				{
					flag2 = false;
				}
			}
			if (flag2)
			{
				return;
			}
			Class255 class255_ = new Class255(gclass618_0, array);
			Class255[] array2 = method_1(gclass618_0.method_2(int_1, 1), class255_, int_1);
			Class255 class255_2 = array2[0];
			Class255 class255_3 = array2[1];
			int[] array3 = method_2(class255_2);
			int[] array4 = method_3(class255_3, array3, flag);
			i = 0;
			while (true)
			{
				if (i < array3.Length)
				{
					int num3 = int_0.Length - 1 - gclass618_0.method_4(array3[i]);
					if (num3 < 0)
					{
						break;
					}
					int_0[num3] = GClass618.smethod_0(int_0[num3], array4[i]);
					i++;
					continue;
				}
				return;
			}
			throw new GException27("Bad error location");
		}

		private Class255[] method_1(Class255 class255_0, Class255 class255_1, int int_0)
		{
			int num = 12;
			if (class255_0.method_1() < class255_1.method_1())
			{
				Class255 @class = class255_0;
				class255_0 = class255_1;
				class255_1 = @class;
			}
			Class255 class2 = class255_0;
			Class255 class3 = class255_1;
			Class255 class4 = gclass618_0.method_1();
			Class255 class5 = gclass618_0.method_0();
			Class255 class6 = gclass618_0.method_0();
			Class255 class7 = gclass618_0.method_1();
			int num4;
			while (true)
			{
				if (class3.method_1() >= int_0 / 2)
				{
					Class255 class8 = class2;
					Class255 class255_2 = class4;
					Class255 class255_3 = class6;
					class2 = class3;
					class4 = class5;
					class6 = class7;
					if (!class2.method_2())
					{
						class3 = class8;
						Class255 class9 = gclass618_0.method_0();
						int int_ = class2.method_3(class2.method_1());
						int int_2 = gclass618_0.method_5(int_);
						while (class3.method_1() >= class2.method_1() && !class3.method_2())
						{
							int num2 = class3.method_1() - class2.method_1();
							int num3 = gclass618_0.method_6(class3.method_3(class3.method_1()), int_2);
							class9 = class9.method_5(gclass618_0.method_2(num2, num3));
							class3 = class3.method_5(class2.method_8(num2, num3));
						}
						class5 = class9.method_6(class4).method_5(class255_2);
						class7 = class9.method_6(class6).method_5(class255_3);
						continue;
					}
					throw new GException27("r_{i-1} was zero");
				}
				num4 = class7.method_3(0);
				if (num4 != 0)
				{
					break;
				}
				throw new GException27("sigmaTilde(0) was zero");
			}
			int int_3 = gclass618_0.method_5(num4);
			Class255 class10 = class7.method_7(int_3);
			Class255 class11 = class3.method_7(int_3);
			return new Class255[2]
			{
				class10,
				class11
			};
		}

		private int[] method_2(Class255 class255_0)
		{
			int num = 11;
			int num2 = class255_0.method_1();
			if (num2 == 1)
			{
				return new int[1]
				{
					class255_0.method_3(1)
				};
			}
			int[] array = new int[num2];
			int num3 = 0;
			for (int i = 1; i < 256; i++)
			{
				if (num3 >= num2)
				{
					break;
				}
				if (class255_0.method_4(i) == 0)
				{
					array[num3] = gclass618_0.method_5(i);
					num3++;
				}
			}
			if (num3 != num2)
			{
				throw new GException27("Error locator degree does not match number of roots");
			}
			return array;
		}

		private int[] method_3(Class255 class255_0, int[] int_0, bool bool_0)
		{
			int num = int_0.Length;
			int[] array = new int[num];
			for (int i = 0; i < num; i++)
			{
				int num2 = gclass618_0.method_5(int_0[i]);
				int int_ = 1;
				for (int j = 0; j < num; j++)
				{
					if (i != j)
					{
						int_ = gclass618_0.method_6(int_, GClass618.smethod_0(1, gclass618_0.method_6(int_0[j], num2)));
					}
				}
				array[i] = gclass618_0.method_6(class255_0.method_4(num2), gclass618_0.method_5(int_));
				if (bool_0)
				{
					array[i] = gclass618_0.method_6(array[i], num2);
				}
			}
			return array;
		}
	}
}
