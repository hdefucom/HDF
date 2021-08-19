using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass607
	{
		private class Class229
		{
			private GClass639 gclass639_0;

			private GClass639 gclass639_1;

			private int int_0;

			public GClass639 method_0()
			{
				return gclass639_0;
			}

			public GClass639 method_1()
			{
				return gclass639_1;
			}

			public int method_2()
			{
				return int_0;
			}

			internal Class229(GClass639 gclass639_2, GClass639 gclass639_3, int int_1)
			{
				gclass639_0 = gclass639_2;
				gclass639_1 = gclass639_3;
				int_0 = int_1;
			}

			public override string ToString()
			{
				return string.Concat(gclass639_0, "/", gclass639_1, '/', int_0);
			}
		}

		private class Class230 : GInterface51
		{
			public int imethod_0(object object_0, object object_1)
			{
				return ((Class229)object_0).method_2() - ((Class229)object_1).method_2();
			}
		}

		private static readonly int[] int_0 = new int[5]
		{
			0,
			1,
			2,
			3,
			4
		};

		private GClass679 gclass679_0;

		private GClass619 gclass619_0;

		public GClass607(GClass679 gclass679_1)
		{
			gclass679_0 = gclass679_1;
			gclass619_0 = new GClass619(gclass679_1);
		}

		public GClass663 method_0()
		{
			GClass639[] array = gclass619_0.method_0();
			GClass639 gClass = array[0];
			GClass639 gClass2 = array[1];
			GClass639 gClass3 = array[2];
			GClass639 gClass4 = array[3];
			ArrayList arrayList = ArrayList.Synchronized(new ArrayList(4));
			arrayList.Add(method_1(gClass, gClass2));
			arrayList.Add(method_1(gClass, gClass3));
			arrayList.Add(method_1(gClass2, gClass4));
			arrayList.Add(method_1(gClass3, gClass4));
			GClass654.smethod_0(arrayList, new Class230());
			Class229 @class = (Class229)arrayList[0];
			Class229 class2 = (Class229)arrayList[1];
			Hashtable hashtable = Hashtable.Synchronized(new Hashtable());
			smethod_0(hashtable, @class.method_0());
			smethod_0(hashtable, @class.method_1());
			smethod_0(hashtable, class2.method_0());
			smethod_0(hashtable, class2.method_1());
			GClass639 gClass5 = null;
			GClass639 gClass6 = null;
			GClass639 gClass7 = null;
			IEnumerator enumerator = hashtable.Keys.GetEnumerator();
			while (enumerator.MoveNext())
			{
				GClass639 gClass8 = (GClass639)enumerator.Current;
				int num = (int)hashtable[gClass8];
				if (num == 2)
				{
					gClass6 = gClass8;
				}
				else if (gClass5 == null)
				{
					gClass5 = gClass8;
				}
				else
				{
					gClass7 = gClass8;
				}
			}
			if (gClass5 == null || gClass6 == null || gClass7 == null)
			{
				throw GException25.smethod_0();
			}
			GClass639[] array2 = new GClass639[3]
			{
				gClass5,
				gClass6,
				gClass7
			};
			GClass639.smethod_0(array2);
			GClass639 gClass9 = array2[0];
			gClass6 = array2[1];
			GClass639 gclass639_ = array2[2];
			GClass639 gclass639_2 = (!hashtable.ContainsKey(gClass)) ? gClass : ((!hashtable.ContainsKey(gClass2)) ? gClass2 : (hashtable.ContainsKey(gClass3) ? gClass4 : gClass3));
			int num2 = Math.Min(method_1(gclass639_, gclass639_2).method_2(), method_1(gClass9, gclass639_2).method_2());
			if ((num2 & 1) == 1)
			{
				num2++;
			}
			num2 += 2;
			GClass679 gclass679_ = smethod_1(gclass679_0, gclass639_, gClass6, gClass9, num2);
			return new GClass663(gclass679_, new GClass639[4]
			{
				gClass,
				gClass2,
				gClass3,
				gClass4
			});
		}

		private static void smethod_0(Hashtable hashtable_0, GClass639 gclass639_0)
		{
			int num = 0;
			try
			{
				if (hashtable_0.Count > 0)
				{
					num = (int)hashtable_0[gclass639_0];
				}
			}
			catch
			{
				num = 0;
			}
			hashtable_0[gclass639_0] = ((num == 0) ? int_0[1] : int_0[num + 1]);
		}

		private static GClass679 smethod_1(GClass679 gclass679_1, GClass639 gclass639_0, GClass639 gclass639_1, GClass639 gclass639_2, int int_1)
		{
			float float_ = gclass639_2.vmethod_0() - gclass639_1.vmethod_0() + gclass639_0.vmethod_0();
			float float_2 = gclass639_2.vmethod_1() - gclass639_1.vmethod_1() + gclass639_0.vmethod_1();
			GClass649 gClass = GClass649.smethod_0();
			return gClass.vmethod_0(gclass679_1, int_1, 0f, 0f, int_1, 0f, int_1, int_1, 0f, int_1, gclass639_0.vmethod_0(), gclass639_0.vmethod_1(), float_, float_2, gclass639_2.vmethod_0(), gclass639_2.vmethod_1(), gclass639_1.vmethod_0(), gclass639_1.vmethod_1());
		}

		private Class229 method_1(GClass639 gclass639_0, GClass639 gclass639_1)
		{
			int num = (int)gclass639_0.vmethod_0();
			int num2 = (int)gclass639_0.vmethod_1();
			int num3 = (int)gclass639_1.vmethod_0();
			int num4 = (int)gclass639_1.vmethod_1();
			bool flag;
			if (flag = (Math.Abs(num4 - num2) > Math.Abs(num3 - num)))
			{
				int num5 = num;
				num = num2;
				num2 = num5;
				num5 = num3;
				num3 = num4;
				num4 = num5;
			}
			int num6 = Math.Abs(num3 - num);
			int num7 = Math.Abs(num4 - num2);
			int num8 = -num6 >> 1;
			int num9 = (num2 < num4) ? 1 : (-1);
			int num10 = (num < num3) ? 1 : (-1);
			int num11 = 0;
			bool flag2 = gclass679_0.method_3(flag ? num2 : num, flag ? num : num2);
			int i = num;
			int num12 = num2;
			for (; i != num3; i += num10)
			{
				bool flag3;
				if ((flag3 = gclass679_0.method_3(flag ? num12 : i, flag ? i : num12)) != flag2)
				{
					num11++;
					flag2 = flag3;
				}
				num8 += num7;
				if (num8 > 0)
				{
					if (num12 == num4)
					{
						break;
					}
					num12 += num9;
					num8 -= num6;
				}
			}
			return new Class229(gclass639_0, gclass639_1, num11);
		}
	}
}
