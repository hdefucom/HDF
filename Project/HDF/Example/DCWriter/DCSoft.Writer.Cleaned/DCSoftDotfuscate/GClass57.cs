using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass57 : GClass55
	{
		private GClass55 gclass55_1;

		private GClass55 gclass55_2;

		private GEnum2 genum2_0;

		public GClass57(GEnum2 genum2_1, GClass55 gclass55_3, GClass55 gclass55_4)
		{
			genum2_0 = genum2_1;
			gclass55_1 = gclass55_3;
			gclass55_1.method_1(this);
			gclass55_2 = gclass55_4;
			gclass55_2.method_1(this);
		}

		public GClass55 method_2()
		{
			return gclass55_1;
		}

		public GClass55 method_3()
		{
			return gclass55_2;
		}

		public GEnum2 method_4()
		{
			return genum2_0;
		}

		public override void vmethod_0(GClass75 gclass75_0)
		{
			gclass75_0.vmethod_1(this);
		}

		public override string ToString()
		{
			return "Bin:" + genum2_0;
		}
	}
}
