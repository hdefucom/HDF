using System.Collections;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass682
	{
		private const int int_0 = 2;

		private static int int_1 = (int)GClass634.smethod_9(107.52f);

		private static int int_2 = (int)GClass634.smethod_9(204.8f);

		private static readonly int[] int_3 = new int[8]
		{
			8,
			1,
			1,
			1,
			1,
			1,
			1,
			3
		};

		private static readonly int[] int_4 = new int[8]
		{
			3,
			1,
			1,
			1,
			1,
			1,
			1,
			8
		};

		private static readonly int[] int_5 = new int[9]
		{
			7,
			1,
			1,
			3,
			1,
			1,
			1,
			2,
			1
		};

		private static readonly int[] int_6 = new int[9]
		{
			1,
			2,
			1,
			1,
			1,
			3,
			1,
			1,
			7
		};

		private GClass616 gclass616_0;

		public GClass682(GClass616 gclass616_1)
		{
			gclass616_0 = gclass616_1;
		}

		public GClass663 method_0()
		{
			return method_1(null);
		}

		public GClass663 method_1(Hashtable hashtable_0)
		{
			GClass679 gclass679_ = gclass616_0.method_2();
			GClass639[] array = smethod_0(gclass679_);
			if (array == null)
			{
				array = smethod_1(gclass679_);
				if (array != null)
				{
					smethod_2(array, bool_0: true);
				}
			}
			else
			{
				smethod_2(array, bool_0: false);
			}
			if (array != null)
			{
				float num = smethod_3(array);
				if (num < 1f)
				{
					throw GException25.smethod_0();
				}
				int num2 = smethod_4(array[4], array[6], array[5], array[7], num);
				if (num2 < 1)
				{
					throw GException25.smethod_0();
				}
				GClass679 gclass679_2 = smethod_5(gclass679_, array[4], array[5], array[6], array[7], num2);
				return new GClass663(gclass679_2, new GClass639[4]
				{
					array[4],
					array[5],
					array[6],
					array[7]
				});
			}
			throw GException25.smethod_0();
		}

		private static GClass639[] smethod_0(GClass679 gclass679_0)
		{
			int num = gclass679_0.method_1();
			int num2 = gclass679_0.method_0();
			int num3 = num2 >> 1;
			GClass639[] array = new GClass639[8];
			bool flag = false;
			for (int i = 0; i < num; i++)
			{
				int[] array2 = smethod_7(gclass679_0, 0, i, num3, bool_0: false, int_3);
				if (array2 != null)
				{
					array[0] = new GClass639(array2[0], i);
					array[4] = new GClass639(array2[1], i);
					flag = true;
					break;
				}
			}
			if (flag)
			{
				flag = false;
				int i = num - 1;
				while (i > 0)
				{
					int[] array2 = smethod_7(gclass679_0, 0, i, num3, bool_0: false, int_3);
					if (array2 == null)
					{
						i--;
						continue;
					}
					array[1] = new GClass639(array2[0], i);
					array[5] = new GClass639(array2[1], i);
					flag = true;
					break;
				}
			}
			if (flag)
			{
				flag = false;
				for (int i = 0; i < num; i++)
				{
					int[] array2 = smethod_7(gclass679_0, num3, i, num3, bool_0: false, int_5);
					if (array2 != null)
					{
						array[2] = new GClass639(array2[1], i);
						array[6] = new GClass639(array2[0], i);
						flag = true;
						break;
					}
				}
			}
			if (flag)
			{
				flag = false;
				int i = num - 1;
				while (i > 0)
				{
					int[] array2 = smethod_7(gclass679_0, num3, i, num3, bool_0: false, int_5);
					if (array2 == null)
					{
						i--;
						continue;
					}
					array[3] = new GClass639(array2[1], i);
					array[7] = new GClass639(array2[0], i);
					flag = true;
					break;
				}
			}
			return flag ? array : null;
		}

		private static GClass639[] smethod_1(GClass679 gclass679_0)
		{
			int num = gclass679_0.method_1();
			int num2 = gclass679_0.method_0();
			int num3 = num2 >> 1;
			GClass639[] array = new GClass639[8];
			bool flag = false;
			int num4 = num - 1;
			while (num4 > 0)
			{
				int[] array2 = smethod_7(gclass679_0, num3, num4, num3, bool_0: true, int_4);
				if (array2 == null)
				{
					num4--;
					continue;
				}
				array[0] = new GClass639(array2[1], num4);
				array[4] = new GClass639(array2[0], num4);
				flag = true;
				break;
			}
			if (flag)
			{
				flag = false;
				for (num4 = 0; num4 < num; num4++)
				{
					int[] array2 = smethod_7(gclass679_0, num3, num4, num3, bool_0: true, int_4);
					if (array2 != null)
					{
						array[1] = new GClass639(array2[1], num4);
						array[5] = new GClass639(array2[0], num4);
						flag = true;
						break;
					}
				}
			}
			if (flag)
			{
				flag = false;
				num4 = num - 1;
				while (num4 > 0)
				{
					int[] array2 = smethod_7(gclass679_0, 0, num4, num3, bool_0: false, int_6);
					if (array2 == null)
					{
						num4--;
						continue;
					}
					array[2] = new GClass639(array2[0], num4);
					array[6] = new GClass639(array2[1], num4);
					flag = true;
					break;
				}
			}
			if (flag)
			{
				flag = false;
				for (num4 = 0; num4 < num; num4++)
				{
					int[] array2 = smethod_7(gclass679_0, 0, num4, num3, bool_0: false, int_6);
					if (array2 != null)
					{
						array[3] = new GClass639(array2[0], num4);
						array[7] = new GClass639(array2[1], num4);
						flag = true;
						break;
					}
				}
			}
			return flag ? array : null;
		}

		private static void smethod_2(GClass639[] gclass639_0, bool bool_0)
		{
			float num = gclass639_0[4].vmethod_1() - gclass639_0[6].vmethod_1();
			if (bool_0)
			{
				num = 0f - num;
			}
			if (num > 2f)
			{
				float num2 = gclass639_0[4].vmethod_0() - gclass639_0[0].vmethod_0();
				float num3 = gclass639_0[6].vmethod_0() - gclass639_0[0].vmethod_0();
				float num4 = gclass639_0[6].vmethod_1() - gclass639_0[0].vmethod_1();
				float num5 = num2 * num4 / num3;
				gclass639_0[4] = new GClass639(gclass639_0[4].vmethod_0(), gclass639_0[4].vmethod_1() + num5);
			}
			else if (0f - num > 2f)
			{
				float num2 = gclass639_0[2].vmethod_0() - gclass639_0[6].vmethod_0();
				float num3 = gclass639_0[2].vmethod_0() - gclass639_0[4].vmethod_0();
				float num4 = gclass639_0[2].vmethod_1() - gclass639_0[4].vmethod_1();
				float num5 = num2 * num4 / num3;
				gclass639_0[6] = new GClass639(gclass639_0[6].vmethod_0(), gclass639_0[6].vmethod_1() - num5);
			}
			num = gclass639_0[7].vmethod_1() - gclass639_0[5].vmethod_1();
			if (bool_0)
			{
				num = 0f - num;
			}
			if (num > 2f)
			{
				float num2 = gclass639_0[5].vmethod_0() - gclass639_0[1].vmethod_0();
				float num3 = gclass639_0[7].vmethod_0() - gclass639_0[1].vmethod_0();
				float num4 = gclass639_0[7].vmethod_1() - gclass639_0[1].vmethod_1();
				float num5 = num2 * num4 / num3;
				gclass639_0[5] = new GClass639(gclass639_0[5].vmethod_0(), gclass639_0[5].vmethod_1() + num5);
			}
			else if (0f - num > 2f)
			{
				float num2 = gclass639_0[3].vmethod_0() - gclass639_0[7].vmethod_0();
				float num3 = gclass639_0[3].vmethod_0() - gclass639_0[5].vmethod_0();
				float num4 = gclass639_0[3].vmethod_1() - gclass639_0[5].vmethod_1();
				float num5 = num2 * num4 / num3;
				gclass639_0[7] = new GClass639(gclass639_0[7].vmethod_0(), gclass639_0[7].vmethod_1() - num5);
			}
		}

		private static float smethod_3(GClass639[] gclass639_0)
		{
			float num = GClass639.smethod_1(gclass639_0[0], gclass639_0[4]);
			float num2 = GClass639.smethod_1(gclass639_0[1], gclass639_0[5]);
			float num3 = (num + num2) / 34f;
			float num4 = GClass639.smethod_1(gclass639_0[6], gclass639_0[2]);
			float num5 = GClass639.smethod_1(gclass639_0[7], gclass639_0[3]);
			float num6 = (num4 + num5) / 36f;
			return (num3 + num6) / 2f;
		}

		private static int smethod_4(GClass639 gclass639_0, GClass639 gclass639_1, GClass639 gclass639_2, GClass639 gclass639_3, float float_0)
		{
			int num = smethod_6(GClass639.smethod_1(gclass639_0, gclass639_1) / float_0);
			int num2 = smethod_6(GClass639.smethod_1(gclass639_2, gclass639_3) / float_0);
			return ((num + num2 >> 1) + 8) / 17 * 17;
		}

		private static GClass679 smethod_5(GClass679 gclass679_0, GClass639 gclass639_0, GClass639 gclass639_1, GClass639 gclass639_2, GClass639 gclass639_3, int int_7)
		{
			GClass649 gClass = GClass649.smethod_0();
			return gClass.vmethod_0(gclass679_0, int_7, 0f, 0f, int_7, 0f, int_7, int_7, 0f, int_7, gclass639_0.vmethod_0(), gclass639_0.vmethod_1(), gclass639_2.vmethod_0(), gclass639_2.vmethod_1(), gclass639_3.vmethod_0(), gclass639_3.vmethod_1(), gclass639_1.vmethod_0(), gclass639_1.vmethod_1());
		}

		private static int smethod_6(float float_0)
		{
			return (int)(float_0 + 0.5f);
		}

		private static int[] smethod_7(GClass679 gclass679_0, int int_7, int int_8, int int_9, bool bool_0, int[] int_10)
		{
			int num = int_10.Length;
			int[] array = new int[num];
			bool flag = bool_0;
			int num2 = 0;
			int num3 = int_7;
			int num4 = int_7;
			while (true)
			{
				if (num4 < int_7 + int_9)
				{
					if (gclass679_0.method_3(num4, int_8) ^ flag)
					{
						array[num2]++;
					}
					else
					{
						if (num2 == num - 1)
						{
							if (smethod_8(array, int_10, int_2) < int_1)
							{
								break;
							}
							num3 += array[0] + array[1];
							for (int i = 2; i < num; i++)
							{
								array[i - 2] = array[i];
							}
							array[num - 2] = 0;
							array[num - 1] = 0;
							num2--;
						}
						else
						{
							num2++;
						}
						array[num2] = 1;
						flag = !flag;
					}
					num4++;
					continue;
				}
				return null;
			}
			return new int[2]
			{
				num3,
				num4
			};
		}

		private static int smethod_8(int[] int_7, int[] int_8, int int_9)
		{
			int num = int_7.Length;
			int num2 = 0;
			int num3 = 0;
			for (int i = 0; i < num; i++)
			{
				num2 += int_7[i];
				num3 += int_8[i];
			}
			if (num2 < num3)
			{
				return int.MaxValue;
			}
			int num4 = (num2 << 8) / num3;
			int_9 = int_9 * num4 >> 8;
			int num5 = 0;
			int num6 = 0;
			while (true)
			{
				if (num6 < num)
				{
					int num7 = int_7[num6] << 8;
					int num8 = int_8[num6] * num4;
					int num9 = (num7 > num8) ? (num7 - num8) : (num8 - num7);
					if (num9 > int_9)
					{
						break;
					}
					num5 += num9;
					num6++;
					continue;
				}
				return num5 / num2;
			}
			return int.MaxValue;
		}
	}
}
