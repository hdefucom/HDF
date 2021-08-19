using DCSoft.TDCode;
using System.Collections;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public abstract class GClass597 : GClass594
	{
		private static readonly int int_2;

		private static readonly int int_3;

		internal static readonly int[] int_4;

		internal static readonly int[] int_5;

		internal static readonly int[][] int_6;

		internal static int[][] int_7;

		private StringBuilder stringBuilder_0;

		internal abstract BarcodeFormat vmethod_1();

		protected internal GClass597()
		{
			stringBuilder_0 = new StringBuilder(20);
		}

		internal static int[] smethod_2(GClass659 gclass659_0)
		{
			bool flag = false;
			int[] array = null;
			int num = 0;
			while (!flag)
			{
				array = smethod_4(gclass659_0, num, bool_0: false, int_4);
				int num2 = array[0];
				num = array[1];
				int num3 = num2 - (num - num2);
				if (num3 >= 0)
				{
					flag = gclass659_0.method_6(num3, num2, bool_0: false);
				}
			}
			return array;
		}

		public override GClass645 vmethod_0(int int_8, GClass659 gclass659_0, Hashtable hashtable_0)
		{
			return vmethod_2(int_8, gclass659_0, smethod_2(gclass659_0), hashtable_0);
		}

		public virtual GClass645 vmethod_2(int int_8, GClass659 gclass659_0, int[] int_9, Hashtable hashtable_0)
		{
			GInterface53 gInterface = (hashtable_0 == null) ? null : ((GInterface53)hashtable_0[GClass633.gclass633_6]);
			gInterface?.imethod_0(new GClass639((float)(int_9[0] + int_9[1]) / 2f, int_8));
			StringBuilder stringBuilder = stringBuilder_0;
			stringBuilder.Length = 0;
			int num = vmethod_5(gclass659_0, int_9, stringBuilder);
			gInterface?.imethod_0(new GClass639(num, int_8));
			int[] array = vmethod_4(gclass659_0, num);
			gInterface?.imethod_0(new GClass639((float)(array[0] + array[1]) / 2f, int_8));
			int num2 = array[1];
			int num3 = num2 + (num2 - array[0]);
			if (num3 >= gclass659_0.method_0() || !gclass659_0.method_6(num2, num3, bool_0: false))
			{
				throw GException25.smethod_0();
			}
			string string_ = stringBuilder.ToString();
			float float_ = (float)(int_9[1] + int_9[0]) / 2f;
			float float_2 = (float)(array[1] + array[0]) / 2f;
			return new GClass645(string_, null, new GClass639[2]
			{
				new GClass639(float_, int_8),
				new GClass639(float_2, int_8)
			}, vmethod_1());
		}

		protected internal virtual bool vmethod_3(string string_0)
		{
			return smethod_3(string_0);
		}

		private static bool smethod_3(string string_0)
		{
			int length = string_0.Length;
			if (length == 0)
			{
				return false;
			}
			int num = 0;
			int num2 = length - 2;
			while (true)
			{
				if (num2 >= 0)
				{
					int num3 = string_0[num2] - 48;
					if (num3 < 0 || num3 > 9)
					{
						break;
					}
					num += num3;
					num2 -= 2;
					continue;
				}
				num *= 3;
				num2 = length - 1;
				while (true)
				{
					if (num2 >= 0)
					{
						int num3 = string_0[num2] - 48;
						if (num3 < 0 || num3 > 9)
						{
							break;
						}
						num += num3;
						num2 -= 2;
						continue;
					}
					return num % 10 == 0;
				}
				throw GException25.smethod_0();
			}
			throw GException25.smethod_0();
		}

		protected internal virtual int[] vmethod_4(GClass659 gclass659_0, int int_8)
		{
			return smethod_4(gclass659_0, int_8, bool_0: false, int_4);
		}

		internal static int[] smethod_4(GClass659 gclass659_0, int int_8, bool bool_0, int[] int_9)
		{
			int num = int_9.Length;
			int[] array = new int[num];
			int num2 = gclass659_0.method_0();
			bool flag = false;
			while (int_8 < num2)
			{
				flag = !gclass659_0.method_1(int_8);
				if (bool_0 == flag)
				{
					break;
				}
				int_8++;
			}
			int num3 = 0;
			int num4 = int_8;
			int num5 = int_8;
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
							if (GClass594.smethod_1(array, int_9, int_3) < int_2)
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

		internal static int smethod_5(GClass659 gclass659_0, int[] int_8, int int_9, int[][] int_10)
		{
			GClass594.smethod_0(gclass659_0, int_9, int_8);
			int num = int_2;
			int num2 = -1;
			int num3 = int_10.Length;
			for (int i = 0; i < num3; i++)
			{
				int[] array = int_10[i];
				int num4 = GClass594.smethod_1(int_8, array, int_3);
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

		protected internal abstract int vmethod_5(GClass659 gclass659_0, int[] int_8, StringBuilder stringBuilder_1);

		static GClass597()
		{
			int_2 = (int)((float)GClass594.int_1 * 0.42f);
			int_3 = (int)((float)GClass594.int_1 * 0.7f);
			int_4 = new int[3]
			{
				1,
				1,
				1
			};
			int_5 = new int[5]
			{
				1,
				1,
				1,
				1,
				1
			};
			int_6 = new int[10][]
			{
				new int[4]
				{
					3,
					2,
					1,
					1
				},
				new int[4]
				{
					2,
					2,
					2,
					1
				},
				new int[4]
				{
					2,
					1,
					2,
					2
				},
				new int[4]
				{
					1,
					4,
					1,
					1
				},
				new int[4]
				{
					1,
					1,
					3,
					2
				},
				new int[4]
				{
					1,
					2,
					3,
					1
				},
				new int[4]
				{
					1,
					1,
					1,
					4
				},
				new int[4]
				{
					1,
					3,
					1,
					2
				},
				new int[4]
				{
					1,
					2,
					1,
					3
				},
				new int[4]
				{
					3,
					1,
					1,
					2
				}
			};
			int_7 = new int[20][];
			for (int i = 0; i < 10; i++)
			{
				int_7[i] = int_6[i];
			}
			for (int i = 10; i < 20; i++)
			{
				int[] array = int_6[i - 10];
				int[] array2 = new int[array.Length];
				for (int j = 0; j < array.Length; j++)
				{
					array2[j] = array[array.Length - j - 1];
				}
				int_7[i] = array2;
			}
		}
	}
}
