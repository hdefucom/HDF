using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public abstract class GClass55
	{
		private GClass55 gclass55_0 = null;

		public GClass55 method_0()
		{
			return gclass55_0;
		}

		public void method_1(GClass55 gclass55_1)
		{
			gclass55_0 = gclass55_1;
		}

		public static GClass55 smethod_0(GClass78 gclass78_0)
		{
			int num = 12;
			if (gclass78_0 == null)
			{
				throw new ArgumentNullException("tree");
			}
			switch (gclass78_0.imethod_14())
			{
			default:
				return null;
			case 99:
				return new GClass58(gclass78_0.imethod_9());
			case 4:
				return new GClass58(((GClass78)gclass78_0.imethod_3(0)).imethod_9());
			case 5:
				return new GClass56(GEnum1.const_1, smethod_0((GClass78)gclass78_0.imethod_3(0)));
			case 6:
				return new GClass57(GEnum2.const_1, smethod_0((GClass78)gclass78_0.imethod_3(0)), smethod_0((GClass78)gclass78_0.imethod_3(1)));
			case 7:
				return new GClass57(GEnum2.const_0, smethod_0((GClass78)gclass78_0.imethod_3(0)), smethod_0((GClass78)gclass78_0.imethod_3(1)));
			case 8:
				return new GClass57(GEnum2.const_7, smethod_0((GClass78)gclass78_0.imethod_3(0)), smethod_0((GClass78)gclass78_0.imethod_3(1)));
			case 9:
				return new GClass57(GEnum2.const_2, smethod_0((GClass78)gclass78_0.imethod_3(0)), smethod_0((GClass78)gclass78_0.imethod_3(1)));
			case 10:
				return new GClass57(GEnum2.const_5, smethod_0((GClass78)gclass78_0.imethod_3(0)), smethod_0((GClass78)gclass78_0.imethod_3(1)));
			case 11:
				return new GClass57(GEnum2.const_3, smethod_0((GClass78)gclass78_0.imethod_3(0)), smethod_0((GClass78)gclass78_0.imethod_3(1)));
			case 12:
				return new GClass57(GEnum2.const_6, smethod_0((GClass78)gclass78_0.imethod_3(0)), smethod_0((GClass78)gclass78_0.imethod_3(1)));
			case 13:
				return new GClass57(GEnum2.const_4, smethod_0((GClass78)gclass78_0.imethod_3(0)), smethod_0((GClass78)gclass78_0.imethod_3(1)));
			case 14:
				return new GClass57(GEnum2.const_9, smethod_0((GClass78)gclass78_0.imethod_3(0)), smethod_0((GClass78)gclass78_0.imethod_3(1)));
			case 15:
				return new GClass57(GEnum2.const_8, smethod_0((GClass78)gclass78_0.imethod_3(0)), smethod_0((GClass78)gclass78_0.imethod_3(1)));
			case 16:
				return new GClass57(GEnum2.const_12, smethod_0((GClass78)gclass78_0.imethod_3(0)), smethod_0((GClass78)gclass78_0.imethod_3(1)));
			case 17:
				return new GClass57(GEnum2.const_11, smethod_0((GClass78)gclass78_0.imethod_3(0)), smethod_0((GClass78)gclass78_0.imethod_3(1)));
			case 18:
				return new GClass57(GEnum2.const_10, smethod_0((GClass78)gclass78_0.imethod_3(0)), smethod_0((GClass78)gclass78_0.imethod_3(1)));
			case 19:
				return new GClass56(GEnum1.const_0, smethod_0((GClass78)gclass78_0.imethod_3(0)));
			case 20:
				return new GClass59(gclass78_0.imethod_9(), GEnum3.const_0);
			case 21:
				return new GClass59(gclass78_0.imethod_9(), GEnum3.const_3);
			case 22:
			{
				string text = gclass78_0.imethod_9();
				if (text != null && text.Length >= 2 && text.StartsWith("'"))
				{
					text = text.Substring(1, text.Length - 2);
				}
				return new GClass59(text, GEnum3.const_1);
			}
			case 23:
				return new GClass59(gclass78_0.imethod_9(), GEnum3.const_2);
			case 24:
				return new GClass59(gclass78_0.imethod_9(), GEnum3.const_4);
			case 25:
			{
				GClass55[] array = new GClass55[gclass78_0.imethod_6()];
				for (int i = 0; i < gclass78_0.imethod_6(); i++)
				{
					array[i] = smethod_0((GClass78)gclass78_0.imethod_3(i));
				}
				return new GClass60(gclass78_0.imethod_9(), array);
			}
			}
		}

		public virtual void vmethod_0(GClass75 gclass75_0)
		{
			gclass75_0.vmethod_0(this);
		}
	}
}
