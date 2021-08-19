using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass616
	{
		private GClass642 gclass642_0;

		private GClass679 gclass679_0;

		public int method_0()
		{
			return gclass642_0.vmethod_0().vmethod_1();
		}

		public int method_1()
		{
			return gclass642_0.vmethod_0().vmethod_2();
		}

		public GClass679 method_2()
		{
			if (gclass679_0 == null)
			{
				gclass679_0 = gclass642_0.vmethod_1();
			}
			return gclass679_0;
		}

		public bool method_3()
		{
			return gclass642_0.vmethod_0().vmethod_3();
		}

		public bool method_4()
		{
			return gclass642_0.vmethod_0().vmethod_4();
		}

		public GClass616(GClass642 gclass642_1)
		{
			int num = 3;
			
			if (gclass642_1 == null)
			{
				throw new ArgumentException("Binarizer must be non-null.");
			}
			gclass642_0 = gclass642_1;
			gclass679_0 = null;
		}

		public GClass659 method_5(int int_0, GClass659 gclass659_0)
		{
			return gclass642_0.vmethod_2(int_0, gclass659_0);
		}

		public GClass616 method_6(int int_0, int int_1, int int_2, int int_3)
		{
			GClass605 gclass605_ = gclass642_0.vmethod_0().vmethod_6(int_0, int_1, int_2, int_3);
			return new GClass616(gclass642_0.vmethod_3(gclass605_));
		}

		public GClass616 method_7()
		{
			GClass605 gclass605_ = gclass642_0.vmethod_0().vmethod_7();
			return new GClass616(gclass642_0.vmethod_3(gclass605_));
		}
	}
}
