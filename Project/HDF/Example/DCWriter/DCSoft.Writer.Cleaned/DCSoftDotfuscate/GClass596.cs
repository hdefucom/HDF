using DCSoft.TDCode;
using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass596 : GClass594
	{
		private const int int_2 = 98;

		private const int int_3 = 99;

		private const int int_4 = 100;

		private const int int_5 = 101;

		private const int int_6 = 102;

		private const int int_7 = 97;

		private const int int_8 = 96;

		private const int int_9 = 101;

		private const int int_10 = 100;

		private const int int_11 = 103;

		private const int int_12 = 104;

		private const int int_13 = 105;

		private const int int_14 = 106;

		private static readonly int[][] int_15 = new int[107][]
		{
			new int[6]
			{
				2,
				1,
				2,
				2,
				2,
				2
			},
			new int[6]
			{
				2,
				2,
				2,
				1,
				2,
				2
			},
			new int[6]
			{
				2,
				2,
				2,
				2,
				2,
				1
			},
			new int[6]
			{
				1,
				2,
				1,
				2,
				2,
				3
			},
			new int[6]
			{
				1,
				2,
				1,
				3,
				2,
				2
			},
			new int[6]
			{
				1,
				3,
				1,
				2,
				2,
				2
			},
			new int[6]
			{
				1,
				2,
				2,
				2,
				1,
				3
			},
			new int[6]
			{
				1,
				2,
				2,
				3,
				1,
				2
			},
			new int[6]
			{
				1,
				3,
				2,
				2,
				1,
				2
			},
			new int[6]
			{
				2,
				2,
				1,
				2,
				1,
				3
			},
			new int[6]
			{
				2,
				2,
				1,
				3,
				1,
				2
			},
			new int[6]
			{
				2,
				3,
				1,
				2,
				1,
				2
			},
			new int[6]
			{
				1,
				1,
				2,
				2,
				3,
				2
			},
			new int[6]
			{
				1,
				2,
				2,
				1,
				3,
				2
			},
			new int[6]
			{
				1,
				2,
				2,
				2,
				3,
				1
			},
			new int[6]
			{
				1,
				1,
				3,
				2,
				2,
				2
			},
			new int[6]
			{
				1,
				2,
				3,
				1,
				2,
				2
			},
			new int[6]
			{
				1,
				2,
				3,
				2,
				2,
				1
			},
			new int[6]
			{
				2,
				2,
				3,
				2,
				1,
				1
			},
			new int[6]
			{
				2,
				2,
				1,
				1,
				3,
				2
			},
			new int[6]
			{
				2,
				2,
				1,
				2,
				3,
				1
			},
			new int[6]
			{
				2,
				1,
				3,
				2,
				1,
				2
			},
			new int[6]
			{
				2,
				2,
				3,
				1,
				1,
				2
			},
			new int[6]
			{
				3,
				1,
				2,
				1,
				3,
				1
			},
			new int[6]
			{
				3,
				1,
				1,
				2,
				2,
				2
			},
			new int[6]
			{
				3,
				2,
				1,
				1,
				2,
				2
			},
			new int[6]
			{
				3,
				2,
				1,
				2,
				2,
				1
			},
			new int[6]
			{
				3,
				1,
				2,
				2,
				1,
				2
			},
			new int[6]
			{
				3,
				2,
				2,
				1,
				1,
				2
			},
			new int[6]
			{
				3,
				2,
				2,
				2,
				1,
				1
			},
			new int[6]
			{
				2,
				1,
				2,
				1,
				2,
				3
			},
			new int[6]
			{
				2,
				1,
				2,
				3,
				2,
				1
			},
			new int[6]
			{
				2,
				3,
				2,
				1,
				2,
				1
			},
			new int[6]
			{
				1,
				1,
				1,
				3,
				2,
				3
			},
			new int[6]
			{
				1,
				3,
				1,
				1,
				2,
				3
			},
			new int[6]
			{
				1,
				3,
				1,
				3,
				2,
				1
			},
			new int[6]
			{
				1,
				1,
				2,
				3,
				1,
				3
			},
			new int[6]
			{
				1,
				3,
				2,
				1,
				1,
				3
			},
			new int[6]
			{
				1,
				3,
				2,
				3,
				1,
				1
			},
			new int[6]
			{
				2,
				1,
				1,
				3,
				1,
				3
			},
			new int[6]
			{
				2,
				3,
				1,
				1,
				1,
				3
			},
			new int[6]
			{
				2,
				3,
				1,
				3,
				1,
				1
			},
			new int[6]
			{
				1,
				1,
				2,
				1,
				3,
				3
			},
			new int[6]
			{
				1,
				1,
				2,
				3,
				3,
				1
			},
			new int[6]
			{
				1,
				3,
				2,
				1,
				3,
				1
			},
			new int[6]
			{
				1,
				1,
				3,
				1,
				2,
				3
			},
			new int[6]
			{
				1,
				1,
				3,
				3,
				2,
				1
			},
			new int[6]
			{
				1,
				3,
				3,
				1,
				2,
				1
			},
			new int[6]
			{
				3,
				1,
				3,
				1,
				2,
				1
			},
			new int[6]
			{
				2,
				1,
				1,
				3,
				3,
				1
			},
			new int[6]
			{
				2,
				3,
				1,
				1,
				3,
				1
			},
			new int[6]
			{
				2,
				1,
				3,
				1,
				1,
				3
			},
			new int[6]
			{
				2,
				1,
				3,
				3,
				1,
				1
			},
			new int[6]
			{
				2,
				1,
				3,
				1,
				3,
				1
			},
			new int[6]
			{
				3,
				1,
				1,
				1,
				2,
				3
			},
			new int[6]
			{
				3,
				1,
				1,
				3,
				2,
				1
			},
			new int[6]
			{
				3,
				3,
				1,
				1,
				2,
				1
			},
			new int[6]
			{
				3,
				1,
				2,
				1,
				1,
				3
			},
			new int[6]
			{
				3,
				1,
				2,
				3,
				1,
				1
			},
			new int[6]
			{
				3,
				3,
				2,
				1,
				1,
				1
			},
			new int[6]
			{
				3,
				1,
				4,
				1,
				1,
				1
			},
			new int[6]
			{
				2,
				2,
				1,
				4,
				1,
				1
			},
			new int[6]
			{
				4,
				3,
				1,
				1,
				1,
				1
			},
			new int[6]
			{
				1,
				1,
				1,
				2,
				2,
				4
			},
			new int[6]
			{
				1,
				1,
				1,
				4,
				2,
				2
			},
			new int[6]
			{
				1,
				2,
				1,
				1,
				2,
				4
			},
			new int[6]
			{
				1,
				2,
				1,
				4,
				2,
				1
			},
			new int[6]
			{
				1,
				4,
				1,
				1,
				2,
				2
			},
			new int[6]
			{
				1,
				4,
				1,
				2,
				2,
				1
			},
			new int[6]
			{
				1,
				1,
				2,
				2,
				1,
				4
			},
			new int[6]
			{
				1,
				1,
				2,
				4,
				1,
				2
			},
			new int[6]
			{
				1,
				2,
				2,
				1,
				1,
				4
			},
			new int[6]
			{
				1,
				2,
				2,
				4,
				1,
				1
			},
			new int[6]
			{
				1,
				4,
				2,
				1,
				1,
				2
			},
			new int[6]
			{
				1,
				4,
				2,
				2,
				1,
				1
			},
			new int[6]
			{
				2,
				4,
				1,
				2,
				1,
				1
			},
			new int[6]
			{
				2,
				2,
				1,
				1,
				1,
				4
			},
			new int[6]
			{
				4,
				1,
				3,
				1,
				1,
				1
			},
			new int[6]
			{
				2,
				4,
				1,
				1,
				1,
				2
			},
			new int[6]
			{
				1,
				3,
				4,
				1,
				1,
				1
			},
			new int[6]
			{
				1,
				1,
				1,
				2,
				4,
				2
			},
			new int[6]
			{
				1,
				2,
				1,
				1,
				4,
				2
			},
			new int[6]
			{
				1,
				2,
				1,
				2,
				4,
				1
			},
			new int[6]
			{
				1,
				1,
				4,
				2,
				1,
				2
			},
			new int[6]
			{
				1,
				2,
				4,
				1,
				1,
				2
			},
			new int[6]
			{
				1,
				2,
				4,
				2,
				1,
				1
			},
			new int[6]
			{
				4,
				1,
				1,
				2,
				1,
				2
			},
			new int[6]
			{
				4,
				2,
				1,
				1,
				1,
				2
			},
			new int[6]
			{
				4,
				2,
				1,
				2,
				1,
				1
			},
			new int[6]
			{
				2,
				1,
				2,
				1,
				4,
				1
			},
			new int[6]
			{
				2,
				1,
				4,
				1,
				2,
				1
			},
			new int[6]
			{
				4,
				1,
				2,
				1,
				2,
				1
			},
			new int[6]
			{
				1,
				1,
				1,
				1,
				4,
				3
			},
			new int[6]
			{
				1,
				1,
				1,
				3,
				4,
				1
			},
			new int[6]
			{
				1,
				3,
				1,
				1,
				4,
				1
			},
			new int[6]
			{
				1,
				1,
				4,
				1,
				1,
				3
			},
			new int[6]
			{
				1,
				1,
				4,
				3,
				1,
				1
			},
			new int[6]
			{
				4,
				1,
				1,
				1,
				1,
				3
			},
			new int[6]
			{
				4,
				1,
				1,
				3,
				1,
				1
			},
			new int[6]
			{
				1,
				1,
				3,
				1,
				4,
				1
			},
			new int[6]
			{
				1,
				1,
				4,
				1,
				3,
				1
			},
			new int[6]
			{
				3,
				1,
				1,
				1,
				4,
				1
			},
			new int[6]
			{
				4,
				1,
				1,
				1,
				3,
				1
			},
			new int[6]
			{
				2,
				1,
				1,
				4,
				1,
				2
			},
			new int[6]
			{
				2,
				1,
				1,
				2,
				1,
				4
			},
			new int[6]
			{
				2,
				1,
				1,
				2,
				3,
				2
			},
			new int[7]
			{
				2,
				3,
				3,
				1,
				1,
				1,
				2
			}
		};

		private static readonly int int_16 = (int)((float)GClass594.int_1 * 0.25f);

		private static readonly int int_17 = (int)((float)GClass594.int_1 * 0.7f);

		private static int[] smethod_2(GClass659 gclass659_0)
		{
			int num = gclass659_0.method_0();
			int i;
			for (i = 0; i < num && !gclass659_0.method_1(i); i++)
			{
			}
			int num2 = 0;
			int[] array = new int[6];
			int num3 = i;
			bool flag = false;
			int num4 = array.Length;
			int num5 = i;
			int num7;
			while (true)
			{
				if (num5 < num)
				{
					if (gclass659_0.method_1(num5) ^ flag)
					{
						array[num2]++;
					}
					else
					{
						if (num2 == num4 - 1)
						{
							int num6 = int_16;
							num7 = -1;
							for (int j = 103; j <= 105; j++)
							{
								int num8 = GClass594.smethod_1(array, int_15[j], int_17);
								if (num8 < num6)
								{
									num6 = num8;
									num7 = j;
								}
							}
							if (num7 >= 0 && gclass659_0.method_6(Math.Max(0, num3 - (num5 - num3) / 2), num3, bool_0: false))
							{
								break;
							}
							num3 += array[0] + array[1];
							for (int k = 2; k < num4; k++)
							{
								array[k - 2] = array[k];
							}
							array[num4 - 2] = 0;
							array[num4 - 1] = 0;
							num2--;
						}
						else
						{
							num2++;
						}
						array[num2] = 1;
						flag = !flag;
					}
					num5++;
					continue;
				}
				throw GException25.smethod_0();
			}
			return new int[3]
			{
				num3,
				num5,
				num7
			};
		}

		private static int smethod_3(GClass659 gclass659_0, int[] int_18, int int_19)
		{
			GClass594.smethod_0(gclass659_0, int_19, int_18);
			int num = int_16;
			int num2 = -1;
			for (int i = 0; i < int_15.Length; i++)
			{
				int[] array = int_15[i];
				int num3 = GClass594.smethod_1(int_18, array, int_17);
				if (num3 < num)
				{
					num = num3;
					num2 = i;
				}
			}
			if (num2 < 0)
			{
				throw GException25.smethod_0();
			}
			return num2;
		}

		public override GClass645 vmethod_0(int int_18, GClass659 gclass659_0, Hashtable hashtable_0)
		{
			int[] array = smethod_2(gclass659_0);
			int num = array[2];
			int num2;
			switch (num)
			{
			default:
				throw GException25.smethod_0();
			case 103:
				num2 = 101;
				break;
			case 104:
				num2 = 100;
				break;
			case 105:
				num2 = 99;
				break;
			}
			bool flag = false;
			bool flag2 = false;
			StringBuilder stringBuilder = new StringBuilder(20);
			int num3 = array[0];
			int i = array[1];
			int[] array2 = new int[6];
			int num4 = 0;
			int num5 = 0;
			int num6 = num;
			int num7 = 0;
			bool flag3 = true;
			while (!flag)
			{
				bool flag4 = flag2;
				flag2 = false;
				num4 = num5;
				num5 = smethod_3(gclass659_0, array2, i);
				if (num5 != 106)
				{
					flag3 = true;
				}
				if (num5 != 106)
				{
					num7++;
					num6 += num7 * num5;
				}
				num3 = i;
				for (int j = 0; j < array2.Length; j++)
				{
					i += array2[j];
				}
				switch (num5)
				{
				case 103:
				case 104:
				case 105:
					throw GException25.smethod_0();
				}
				switch (num2)
				{
				case 99:
					if (num5 < 100)
					{
						if (num5 < 10)
						{
							stringBuilder.Append('0');
						}
						stringBuilder.Append(num5);
						break;
					}
					if (num5 != 106)
					{
						flag3 = false;
					}
					switch (num5)
					{
					case 100:
						num2 = 100;
						break;
					case 101:
						num2 = 101;
						break;
					case 106:
						flag = true;
						break;
					}
					break;
				case 100:
					if (num5 < 96)
					{
						stringBuilder.Append((char)(32 + num5));
						break;
					}
					if (num5 != 106)
					{
						flag3 = false;
					}
					switch (num5)
					{
					case 98:
						flag2 = true;
						num2 = 99;
						break;
					case 99:
						num2 = 99;
						break;
					case 101:
						num2 = 101;
						break;
					case 106:
						flag = true;
						break;
					}
					break;
				case 101:
					if (num5 < 64)
					{
						stringBuilder.Append((char)(32 + num5));
						break;
					}
					if (num5 < 96)
					{
						stringBuilder.Append((char)(num5 - 64));
						break;
					}
					if (num5 != 106)
					{
						flag3 = false;
					}
					switch (num5)
					{
					case 98:
						flag2 = true;
						num2 = 100;
						break;
					case 99:
						num2 = 99;
						break;
					case 100:
						num2 = 100;
						break;
					case 106:
						flag = true;
						break;
					}
					break;
				}
				if (flag4)
				{
					switch (num2)
					{
					case 99:
						num2 = 100;
						break;
					case 100:
						num2 = 101;
						break;
					case 101:
						num2 = 99;
						break;
					}
				}
			}
			int num8;
			for (num8 = gclass659_0.method_0(); i < num8 && gclass659_0.method_1(i); i++)
			{
			}
			if (!gclass659_0.method_6(i, Math.Min(num8, i + (i - num3) / 2), bool_0: false))
			{
				throw GException25.smethod_0();
			}
			num6 -= num7 * num4;
			if (num6 % 103 != num4)
			{
				throw GException25.smethod_0();
			}
			int length = stringBuilder.Length;
			if (length > 0 && flag3)
			{
				if (num2 == 99)
				{
					stringBuilder.Remove(length - 2, length - (length - 2));
				}
				else
				{
					stringBuilder.Remove(length - 1, length - (length - 1));
				}
			}
			string text = stringBuilder.ToString();
			if (text.Length == 0)
			{
				throw GException25.smethod_0();
			}
			float float_ = (float)(array[1] + array[0]) / 2f;
			float float_2 = (float)(i + num3) / 2f;
			return new GClass645(text, null, new GClass639[2]
			{
				new GClass639(float_, int_18),
				new GClass639(float_2, int_18)
			}, BarcodeFormat.barcodeFormat_6);
		}
	}
}
