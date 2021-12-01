using DCSoft.TDCode;
using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass661 : GInterface50
	{
		private static readonly GClass639[] gclass639_0 = new GClass639[0];

		private GClass615 gclass615_0 = new GClass615();

		public GClass645 imethod_0(GClass616 gclass616_0)
		{
			return imethod_1(gclass616_0, null);
		}

		public GClass645 imethod_1(GClass616 gclass616_0, Hashtable hashtable_0)
		{
			GClass678 gClass;
			GClass639[] gclass639_;
			if (hashtable_0 != null && hashtable_0.ContainsKey(GClass633.gclass633_1))
			{
				GClass679 gclass679_ = smethod_0(gclass616_0);
				gClass = gclass615_0.method_1(gclass679_);
				gclass639_ = gclass639_0;
			}
			else
			{
				GClass663 gClass2 = new GClass682(gclass616_0).method_0();
				gClass = gclass615_0.method_1(gClass2.method_0());
				gclass639_ = gClass2.method_1();
			}
			return new GClass645(gClass.method_1(), gClass.method_0(), gclass639_, BarcodeFormat.barcodeFormat_9);
		}

		private static GClass679 smethod_0(GClass616 gclass616_0)
		{
			GClass679 gClass = gclass616_0.method_2();
			int num = gClass.method_1();
			int num2 = gClass.method_0();
			int num3 = Math.Min(num, num2);
			int i;
			for (i = 0; i < num3 && !gClass.method_3(i, i); i++)
			{
			}
			if (i == num3)
			{
				throw GException25.smethod_0();
			}
			int j;
			for (j = i; j < num3 && gClass.method_3(j, j); j++)
			{
			}
			if (j == num3)
			{
				throw GException25.smethod_0();
			}
			int num4 = j - i;
			int num5 = num2 - 1;
			while (num5 >= 0 && !gClass.method_3(num5, i))
			{
				num5--;
			}
			if (num5 < 0)
			{
				throw GException25.smethod_0();
			}
			num5++;
			if ((num5 - i) % num4 != 0)
			{
				throw GException25.smethod_0();
			}
			int num6 = (num5 - i) / num4;
			i += num4 >> 1;
			int num7 = i + (num6 - 1) * num4;
			if (num7 >= num2 || num7 >= num)
			{
				throw GException25.smethod_0();
			}
			GClass679 gClass2 = new GClass679(num6);
			for (int k = 0; k < num6; k++)
			{
				int int_ = i + k * num4;
				for (int l = 0; l < num6; l++)
				{
					if (gClass.method_3(i + l * num4, int_))
					{
						gClass2.method_4(l, k);
					}
				}
			}
			return gClass2;
		}
	}
}
