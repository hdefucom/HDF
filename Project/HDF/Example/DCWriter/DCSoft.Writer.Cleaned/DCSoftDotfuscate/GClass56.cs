using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass56 : GClass55
	{
		private GClass55 gclass55_1;

		private GEnum1 genum1_0;

		public GClass56(GEnum1 genum1_1, GClass55 gclass55_2)
		{
			genum1_0 = genum1_1;
			gclass55_1 = gclass55_2;
			gclass55_1.method_1(this);
		}

		public GClass55 method_2()
		{
			return gclass55_1;
		}

		public GEnum1 method_3()
		{
			return genum1_0;
		}

		public override void vmethod_0(GClass75 gclass75_0)
		{
			gclass75_0.vmethod_2(this);
		}

		public override string ToString()
		{
			return "Unary:" + genum1_0;
		}
	}
}
