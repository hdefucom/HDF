using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public abstract class GClass594 : GInterface50
	{
		private const int int_0 = 8;

		internal static readonly int int_1 = 256;

		public virtual GClass645 imethod_0(GClass616 gclass616_0)
		{
			return imethod_1(gclass616_0, null);
		}

		public virtual GClass645 imethod_1(GClass616 gclass616_0, Hashtable hashtable_0)
		{
			try
			{
				return method_0(gclass616_0, hashtable_0);
			}
			catch (GException25 gException)
			{
				if (!(hashtable_0?.ContainsKey(GClass633.gclass633_3) ?? false) || !gclass616_0.method_4())
				{
					throw gException;
				}
				GClass616 gClass = gclass616_0.method_7();
				GClass645 gClass2 = method_0(gClass, hashtable_0);
				Hashtable hashtable = gClass2.method_4();
				int num = 270;
				if (hashtable != null && hashtable.ContainsKey(GClass664.gclass664_1))
				{
					num = (num + (int)hashtable[GClass664.gclass664_1]) % 360;
				}
				gClass2.method_5(GClass664.gclass664_1, num);
				GClass639[] array = gClass2.method_2();
				int num2 = gClass.method_1();
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = new GClass639((float)num2 - array[i].vmethod_1() - 1f, array[i].vmethod_0());
				}
				return gClass2;
			}
		}

		private GClass645 method_0(GClass616 gclass616_0, Hashtable hashtable_0)
		{
			int num = gclass616_0.method_0();
			int num2 = gclass616_0.method_1();
			GClass659 gClass = new GClass659(num);
			int num3 = num2 >> 1;
			bool flag = hashtable_0?.ContainsKey(GClass633.gclass633_3) ?? false;
			int num4 = Math.Max(1, num2 >> (flag ? 7 : 4));
			int num5 = (!flag) ? 9 : num2;
			for (int i = 0; i < num5; i++)
			{
				int num6 = i + 1 >> 1;
				bool flag2 = (i & 1) == 0;
				int num7 = num3 + num4 * (flag2 ? num6 : (-num6));
				if (num7 < 0 || num7 >= num2)
				{
					break;
				}
				try
				{
					gClass = gclass616_0.method_5(num7, gClass);
				}
				catch (GException25)
				{
					continue;
				}
				for (int j = 0; j < 2; j++)
				{
					if (j == 1)
					{
						gClass.method_8();
						if (hashtable_0 != null && hashtable_0.ContainsKey(GClass633.gclass633_6))
						{
							Hashtable hashtable = Hashtable.Synchronized(new Hashtable());
							IEnumerator enumerator = hashtable_0.Keys.GetEnumerator();
							while (enumerator.MoveNext())
							{
								object current = enumerator.Current;
								if (!current.Equals(GClass633.gclass633_6))
								{
									hashtable[current] = hashtable_0[current];
								}
							}
							hashtable_0 = hashtable;
						}
					}
					try
					{
						GClass645 gClass2 = vmethod_0(num7, gClass, hashtable_0);
						if (j == 1)
						{
							gClass2.method_5(GClass664.gclass664_1, 180);
							GClass639[] array = gClass2.method_2();
							array[0] = new GClass639((float)num - array[0].vmethod_0() - 1f, array[0].vmethod_1());
							array[1] = new GClass639((float)num - array[1].vmethod_0() - 1f, array[1].vmethod_1());
						}
						return gClass2;
					}
					catch (GException25)
					{
					}
				}
			}
			throw GException25.smethod_0();
		}

		internal static void smethod_0(GClass659 gclass659_0, int int_2, int[] int_3)
		{
			int num = int_3.Length;
			for (int i = 0; i < num; i++)
			{
				int_3[i] = 0;
			}
			int num2 = gclass659_0.method_0();
			if (int_2 >= num2)
			{
				throw GException25.smethod_0();
			}
			bool flag = !gclass659_0.method_1(int_2);
			int num3 = 0;
			int j;
			for (j = int_2; j < num2; j++)
			{
				if (gclass659_0.method_1(j) ^ flag)
				{
					int_3[num3]++;
					continue;
				}
				num3++;
				if (num3 == num)
				{
					break;
				}
				int_3[num3] = 1;
				flag = !flag;
			}
			if (num3 != num && (num3 != num - 1 || j != num2))
			{
				throw GException25.smethod_0();
			}
		}

		internal static int smethod_1(int[] int_2, int[] int_3, int int_4)
		{
			int num = int_2.Length;
			int num2 = 0;
			int num3 = 0;
			for (int i = 0; i < num; i++)
			{
				num2 += int_2[i];
				num3 += int_3[i];
			}
			if (num2 < num3)
			{
				return int.MaxValue;
			}
			int num4 = (num2 << 8) / num3;
			int_4 = int_4 * num4 >> 8;
			int num5 = 0;
			int num6 = 0;
			while (true)
			{
				if (num6 < num)
				{
					int num7 = int_2[num6] << 8;
					int num8 = int_3[num6] * num4;
					int num9 = (num7 > num8) ? (num7 - num8) : (num8 - num7);
					if (num9 > int_4)
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

		public abstract GClass645 vmethod_0(int int_2, GClass659 gclass659_0, Hashtable hashtable_0);
	}
}
