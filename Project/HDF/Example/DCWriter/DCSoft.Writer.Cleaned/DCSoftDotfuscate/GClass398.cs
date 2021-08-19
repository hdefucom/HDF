using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[Serializable]
	[ComVisible(false)]
	public class GClass398 : GClass383
	{
		private GEnum85 genum85_0 = GEnum85.const_0;

		public GEnum85 method_17()
		{
			return genum85_0;
		}

		public void method_18(GEnum85 genum85_1)
		{
			genum85_0 = genum85_1;
		}

		public bool method_19()
		{
			return Class202.smethod_0(this);
		}

		public override string ToString()
		{
			return "Footer " + method_17();
		}
	}
}
