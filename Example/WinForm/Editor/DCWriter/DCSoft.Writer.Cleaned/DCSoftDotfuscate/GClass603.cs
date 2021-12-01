using DCSoft.TDCode;
using System.Collections;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass603 : GClass594
	{
		private const int int_2 = 3;

		private const int int_3 = 1;

		private static readonly int int_4 = (int)((float)GClass594.int_1 * 0.42f);

		private static readonly int int_5 = (int)((float)GClass594.int_1 * 0.8f);

		private static readonly int[] int_6 = new int[4]
		{
			6,
			10,
			14,
			44
		};

		private int int_7 = -1;

		private static readonly int[] int_8 = new int[4]
		{
			1,
			1,
			1,
			1
		};

		private static readonly int[] int_9 = new int[3]
		{
			1,
			1,
			3
		};

		private static readonly int[][] int_10 = new int[10][]
		{
			new int[5]
			{
				1,
				1,
				3,
				3,
				1
			},
			new int[5]
			{
				3,
				1,
				1,
				1,
				3
			},
			new int[5]
			{
				1,
				3,
				1,
				1,
				3
			},
			new int[5]
			{
				3,
				3,
				1,
				1,
				1
			},
			new int[5]
			{
				1,
				1,
				3,
				1,
				3
			},
			new int[5]
			{
				3,
				1,
				3,
				1,
				1
			},
			new int[5]
			{
				1,
				3,
				3,
				1,
				1
			},
			new int[5]
			{
				1,
				1,
				1,
				3,
				3
			},
			new int[5]
			{
				3,
				1,
				1,
				3,
				1
			},
			new int[5]
			{
				1,
				3,
				1,
				3,
				1
			}
		};

		public override GClass645 vmethod_0(int int_11, GClass659 gclass659_0, Hashtable hashtable_0)
		{
			int[] array = method_1(gclass659_0);
			int[] array2 = method_3(gclass659_0);
			StringBuilder stringBuilder = new StringBuilder(20);
			smethod_2(gclass659_0, array[1], array2[0], stringBuilder);
			string text = stringBuilder.ToString();
			int[] array3 = null;
			if (hashtable_0 != null)
			{
				array3 = (int[])hashtable_0[GClass633.gclass633_4];
			}
			if (array3 == null)
			{
				array3 = int_6;
			}
			int length = text.Length;
			bool flag = false;
			for (int i = 0; i < array3.Length; i++)
			{
				if (length == array3[i])
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				throw GException25.smethod_0();
			}
			return new GClass645(text, null, new GClass639[2]
			{
				new GClass639(array[1], int_11),
				new GClass639(array2[0], int_11)
			}, BarcodeFormat.barcodeFormat_8);
		}

		private static void smethod_2(GClass659 gclass659_0, int int_11, int int_12, StringBuilder stringBuilder_0)
		{
			int[] array = new int[10];
			int[] array2 = new int[5];
			int[] array3 = new int[5];
			while (int_11 < int_12)
			{
				GClass594.smethod_0(gclass659_0, int_11, array);
				for (int i = 0; i < 5; i++)
				{
					int num = i << 1;
					array2[i] = array[num];
					array3[i] = array[num + 1];
				}
				int num2 = smethod_5(array2);
				stringBuilder_0.Append((char)(48 + num2));
				num2 = smethod_5(array3);
				stringBuilder_0.Append((char)(48 + num2));
				for (int j = 0; j < array.Length; j++)
				{
					int_11 += array[j];
				}
			}
		}

		internal int[] method_1(GClass659 gclass659_0)
		{
			int int_ = smethod_3(gclass659_0);
			int[] array = smethod_4(gclass659_0, int_, int_8);
			int_7 = array[1] - array[0] >> 2;
			method_2(gclass659_0, array[0]);
			return array;
		}

		private void method_2(GClass659 gclass659_0, int int_11)
		{
			int num = int_7 * 10;
			int num2 = int_11 - 1;
			while (num > 0 && num2 >= 0 && !gclass659_0.method_1(num2))
			{
				num--;
				num2--;
			}
			if (num != 0)
			{
				throw GException25.smethod_0();
			}
		}

		private static int smethod_3(GClass659 gclass659_0)
		{
			int num = gclass659_0.method_0();
			int i;
			for (i = 0; i < num && !gclass659_0.method_1(i); i++)
			{
			}
			if (i == num)
			{
				throw GException25.smethod_0();
			}
			return i;
		}

		internal int[] method_3(GClass659 gclass659_0)
		{
			gclass659_0.method_8();
			try
			{
				int int_ = smethod_3(gclass659_0);
				int[] array = smethod_4(gclass659_0, int_, int_9);
				method_2(gclass659_0, array[0]);
				int num = array[0];
				array[0] = gclass659_0.method_0() - array[1];
				array[1] = gclass659_0.method_0() - num;
				return array;
			}
			finally
			{
				gclass659_0.method_8();
			}
		}

		private static int[] smethod_4(GClass659 gclass659_0, int int_11, int[] int_12)
		{
			int num = int_12.Length;
			int[] array = new int[num];
			int num2 = gclass659_0.method_0();
			bool flag = false;
			int num3 = 0;
			int num4 = int_11;
			int num5 = int_11;
			while (true)
			{
				if (num5 < num2)
				{
					if (gclass659_0.method_1(num5) ^ flag)
					{
						array[num3]++;
					}
					else
					{
						if (num3 == num - 1)
						{
							if (GClass594.smethod_1(array, int_12, int_5) < int_4)
							{
								break;
							}
							num4 += array[0] + array[1];
							for (int i = 2; i < num; i++)
							{
								array[i - 2] = array[i];
							}
							array[num - 2] = 0;
							array[num - 1] = 0;
							num3--;
						}
						else
						{
							num3++;
						}
						array[num3] = 1;
						flag = !flag;
					}
					num5++;
					continue;
				}
				throw GException25.smethod_0();
			}
			return new int[2]
			{
				num4,
				num5
			};
		}

		private static int smethod_5(int[] int_11)
		{
			int num = int_4;
			int num2 = -1;
			int num3 = int_10.Length;
			for (int i = 0; i < num3; i++)
			{
				int[] array = int_10[i];
				int num4 = GClass594.smethod_1(int_11, array, int_5);
				if (num4 < num)
				{
					num = num4;
					num2 = i;
				}
			}
			if (num2 < 0)
			{
				throw GException25.smethod_0();
			}
			return num2;
		}
	}
}
