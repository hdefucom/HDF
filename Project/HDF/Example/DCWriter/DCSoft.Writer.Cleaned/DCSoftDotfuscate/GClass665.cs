using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass665
	{
		private GClass679 gclass679_0;

		private GInterface53 ginterface53_0;

		protected internal virtual GClass679 vmethod_0()
		{
			return gclass679_0;
		}

		protected internal virtual GInterface53 vmethod_1()
		{
			return ginterface53_0;
		}

		public GClass665(GClass679 gclass679_1)
		{
			gclass679_0 = gclass679_1;
		}

		public virtual GClass663 vmethod_2()
		{
			return vmethod_3(null);
		}

		public virtual GClass663 vmethod_3(Hashtable hashtable_0)
		{
			ginterface53_0 = ((hashtable_0 == null) ? null : ((GInterface53)hashtable_0[GClass633.gclass633_6]));
			GClass617 gClass = new GClass617(gclass679_0, ginterface53_0);
			GClass680 gclass680_ = gClass.vmethod_2(hashtable_0);
			return vmethod_4(gclass680_);
		}

		protected internal virtual GClass663 vmethod_4(GClass680 gclass680_0)
		{
			GClass640 gClass = gclass680_0.method_1();
			GClass640 gClass2 = gclass680_0.method_2();
			GClass640 gClass3 = gclass680_0.method_0();
			float num = vmethod_6(gClass, gClass2, gClass3);
			if (num < 1f)
			{
				throw GException25.smethod_0();
			}
			int num2 = smethod_1(gClass, gClass2, gClass3, num);
			GClass672 gClass4 = GClass672.smethod_0(num2);
			int num3 = gClass4.method_3() - 7;
			GClass641 gClass5 = null;
			if (gClass4.method_1().Length > 0)
			{
				float num4 = gClass2.vmethod_0() - gClass.vmethod_0() + gClass3.vmethod_0();
				float num5 = gClass2.vmethod_1() - gClass.vmethod_1() + gClass3.vmethod_1();
				float num6 = 1f - 3f / (float)num3;
				int int_ = (int)(gClass.vmethod_0() + num6 * (num4 - gClass.vmethod_0()));
				int int_2 = (int)(gClass.vmethod_1() + num6 * (num5 - gClass.vmethod_1()));
				for (int num7 = 4; num7 <= 16; num7 <<= 1)
				{
					try
					{
						gClass5 = vmethod_7(num, int_, int_2, num7);
					}
					catch (GException25)
					{
						continue;
					}
					break;
				}
			}
			GClass677 gclass677_ = vmethod_5(gClass, gClass2, gClass3, gClass5, num2);
			GClass679 gclass679_ = smethod_0(gclass679_0, gclass677_, num2);
			GClass639[] gclass639_ = (gClass5 != null) ? new GClass639[4]
			{
				gClass3,
				gClass,
				gClass2,
				gClass5
			} : new GClass639[3]
			{
				gClass3,
				gClass,
				gClass2
			};
			return new GClass663(gclass679_, gclass639_);
		}

		public virtual GClass677 vmethod_5(GClass639 gclass639_0, GClass639 gclass639_1, GClass639 gclass639_2, GClass639 gclass639_3, int int_0)
		{
			float num = (float)int_0 - 3.5f;
			float float_;
			float float_2;
			float float_4;
			float float_3;
			if (gclass639_3 != null)
			{
				float_ = gclass639_3.vmethod_0();
				float_2 = gclass639_3.vmethod_1();
				float_4 = (float_3 = num - 3f);
			}
			else
			{
				float_ = gclass639_1.vmethod_0() - gclass639_0.vmethod_0() + gclass639_2.vmethod_0();
				float_2 = gclass639_1.vmethod_1() - gclass639_0.vmethod_1() + gclass639_2.vmethod_1();
				float_4 = (float_3 = num);
			}
			return GClass677.smethod_0(3.5f, 3.5f, num, 3.5f, float_4, float_3, 3.5f, num, gclass639_0.vmethod_0(), gclass639_0.vmethod_1(), gclass639_1.vmethod_0(), gclass639_1.vmethod_1(), float_, float_2, gclass639_2.vmethod_0(), gclass639_2.vmethod_1());
		}

		private static GClass679 smethod_0(GClass679 gclass679_1, GClass677 gclass677_0, int int_0)
		{
			GClass649 gClass = GClass649.smethod_0();
			return gClass.vmethod_1(gclass679_1, int_0, gclass677_0);
		}

		protected internal static int smethod_1(GClass639 gclass639_0, GClass639 gclass639_1, GClass639 gclass639_2, float float_0)
		{
			int num = smethod_2(GClass639.smethod_1(gclass639_0, gclass639_1) / float_0);
			int num2 = smethod_2(GClass639.smethod_1(gclass639_0, gclass639_2) / float_0);
			int num3 = (num + num2 >> 1) + 7;
			switch (num3 & 3)
			{
			case 0:
				num3++;
				break;
			case 2:
				num3--;
				break;
			case 3:
				throw GException25.smethod_0();
			}
			return num3;
		}

		protected internal virtual float vmethod_6(GClass639 gclass639_0, GClass639 gclass639_1, GClass639 gclass639_2)
		{
			return (method_0(gclass639_0, gclass639_1) + method_0(gclass639_0, gclass639_2)) / 2f;
		}

		private float method_0(GClass639 gclass639_0, GClass639 gclass639_1)
		{
			float num = method_1((int)gclass639_0.vmethod_0(), (int)gclass639_0.vmethod_1(), (int)gclass639_1.vmethod_0(), (int)gclass639_1.vmethod_1());
			float num2 = method_1((int)gclass639_1.vmethod_0(), (int)gclass639_1.vmethod_1(), (int)gclass639_0.vmethod_0(), (int)gclass639_0.vmethod_1());
			if (float.IsNaN(num))
			{
				return num2 / 7f;
			}
			if (float.IsNaN(num2))
			{
				return num / 7f;
			}
			return (num + num2) / 14f;
		}

		private float method_1(int int_0, int int_1, int int_2, int int_3)
		{
			float num = method_2(int_0, int_1, int_2, int_3);
			float num2 = 1f;
			int num3 = int_0 - (int_2 - int_0);
			if (num3 < 0)
			{
				num2 = (float)int_0 / (float)(int_0 - num3);
				num3 = 0;
			}
			else if (num3 >= gclass679_0.method_0())
			{
				num2 = (float)(gclass679_0.method_0() - 1 - int_0) / (float)(num3 - int_0);
				num3 = gclass679_0.method_0() - 1;
			}
			int num4 = (int)((float)int_1 - (float)(int_3 - int_1) * num2);
			num2 = 1f;
			if (num4 < 0)
			{
				num2 = (float)int_1 / (float)(int_1 - num4);
				num4 = 0;
			}
			else if (num4 >= gclass679_0.method_1())
			{
				num2 = (float)(gclass679_0.method_1() - 1 - int_1) / (float)(num4 - int_1);
				num4 = gclass679_0.method_1() - 1;
			}
			num3 = (int)((float)int_0 + (float)(num3 - int_0) * num2);
			num += method_2(int_0, int_1, num3, num4);
			return num - 1f;
		}

		private float method_2(int int_0, int int_1, int int_2, int int_3)
		{
			bool flag;
			if (flag = (Math.Abs(int_3 - int_1) > Math.Abs(int_2 - int_0)))
			{
				int num = int_0;
				int_0 = int_1;
				int_1 = num;
				num = int_2;
				int_2 = int_3;
				int_3 = num;
			}
			int num2 = Math.Abs(int_2 - int_0);
			int num3 = Math.Abs(int_3 - int_1);
			int num4 = -num2 >> 1;
			int num5 = (int_1 < int_3) ? 1 : (-1);
			int num6 = (int_0 < int_2) ? 1 : (-1);
			int num7 = 0;
			int i = int_0;
			int num8 = int_1;
			for (; i != int_2; i += num6)
			{
				int int_4 = flag ? num8 : i;
				int int_5 = flag ? i : num8;
				if (num7 == 1)
				{
					if (gclass679_0.method_3(int_4, int_5))
					{
						num7++;
					}
				}
				else if (!gclass679_0.method_3(int_4, int_5))
				{
					num7++;
				}
				if (num7 != 3)
				{
					num4 += num3;
					if (num4 > 0)
					{
						if (num8 == int_3)
						{
							break;
						}
						num8 += num5;
						num4 -= num2;
					}
					continue;
				}
				int num9 = i - int_0;
				int num10 = num8 - int_1;
				return (float)Math.Sqrt(num9 * num9 + num10 * num10);
			}
			int num11 = int_2 - int_0;
			int num12 = int_3 - int_1;
			return (float)Math.Sqrt(num11 * num11 + num12 * num12);
		}

		protected internal virtual GClass641 vmethod_7(float float_0, int int_0, int int_1, float float_1)
		{
			int num = (int)(float_1 * float_0);
			int num2 = Math.Max(0, int_0 - num);
			int num3 = Math.Min(gclass679_0.method_0() - 1, int_0 + num);
			if ((float)(num3 - num2) < float_0 * 3f)
			{
				throw GException25.smethod_0();
			}
			int num4 = Math.Max(0, int_1 - num);
			int num5 = Math.Min(gclass679_0.method_1() - 1, int_1 + num);
			Class273 @class = new Class273(gclass679_0, num2, num4, num3 - num2, num5 - num4, float_0, ginterface53_0);
			return @class.method_0();
		}

		private static int smethod_2(float float_0)
		{
			return (int)(float_0 + 0.5f);
		}
	}
}
