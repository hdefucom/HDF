using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass644 : GClass643
	{
		private const int int_4 = 40;

		private GClass679 gclass679_0 = null;

		public override GClass679 vmethod_1()
		{
			method_1();
			return gclass679_0;
		}

		public GClass644(GClass605 gclass605_1)
			: base(gclass605_1)
		{
		}

		public override GClass642 vmethod_3(GClass605 gclass605_1)
		{
			return new GClass644(gclass605_1);
		}

		private void method_1()
		{
			if (gclass679_0 == null)
			{
				GClass605 gClass = vmethod_0();
				if (gClass.vmethod_1() >= 40 && gClass.vmethod_2() >= 40)
				{
					sbyte[] sbyte_ = gClass.vmethod_0();
					int num = gClass.vmethod_1();
					int num2 = gClass.vmethod_2();
					int int_ = num >> 3;
					int int_2 = num2 >> 3;
					int[][] int_3 = smethod_3(sbyte_, int_, int_2, num);
					gclass679_0 = new GClass679(num, num2);
					smethod_1(sbyte_, int_, int_2, num, int_3, gclass679_0);
				}
				else
				{
					gclass679_0 = base.vmethod_1();
				}
			}
		}

		private static void smethod_1(sbyte[] sbyte_1, int int_5, int int_6, int int_7, int[][] int_8, GClass679 gclass679_1)
		{
			for (int i = 0; i < int_6; i++)
			{
				for (int j = 0; j < int_5; j++)
				{
					int num = (j > 1) ? j : 2;
					num = ((num < int_5 - 2) ? num : (int_5 - 3));
					int num2 = (i > 1) ? i : 2;
					num2 = ((num2 < int_6 - 2) ? num2 : (int_6 - 3));
					int num3 = 0;
					for (int k = -2; k <= 2; k++)
					{
						int[] array = int_8[num2 + k];
						num3 += array[num - 2];
						num3 += array[num - 1];
						num3 += array[num];
						num3 += array[num + 1];
						num3 += array[num + 2];
					}
					int int_9 = num3 / 25;
					smethod_2(sbyte_1, j << 3, i << 3, int_9, int_7, gclass679_1);
				}
			}
		}

		private static void smethod_2(sbyte[] sbyte_1, int int_5, int int_6, int int_7, int int_8, GClass679 gclass679_1)
		{
			for (int i = 0; i < 8; i++)
			{
				int num = (int_6 + i) * int_8 + int_5;
				for (int j = 0; j < 8; j++)
				{
					int num2 = sbyte_1[num + j] & 0xFF;
					if (num2 < int_7)
					{
						gclass679_1.method_4(int_5 + j, int_6 + i);
					}
				}
			}
		}

		private static int[][] smethod_3(sbyte[] sbyte_1, int int_5, int int_6, int int_7)
		{
			int[][] array = new int[int_6][];
			for (int i = 0; i < int_6; i++)
			{
				array[i] = new int[int_5];
			}
			for (int j = 0; j < int_6; j++)
			{
				for (int k = 0; k < int_5; k++)
				{
					int num = 0;
					int num2 = 255;
					int num3 = 0;
					for (int l = 0; l < 8; l++)
					{
						int num4 = ((j << 3) + l) * int_7 + (k << 3);
						for (int m = 0; m < 8; m++)
						{
							int num5 = sbyte_1[num4 + m] & 0xFF;
							num += num5;
							if (num5 < num2)
							{
								num2 = num5;
							}
							if (num5 > num3)
							{
								num3 = num5;
							}
						}
					}
					int num6 = (num3 - num2 > 24) ? (num >> 6) : (num2 >> 1);
					array[j][k] = num6;
				}
			}
			return array;
		}
	}
}
