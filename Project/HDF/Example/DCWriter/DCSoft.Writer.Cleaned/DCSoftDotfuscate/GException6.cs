using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[Serializable]
	[ComVisible(false)]
	public class GException6 : GException4
	{
		public GClass83 gclass83_0;

		public GException6()
		{
		}

		public GException6(GClass83 gclass83_1, GInterface14 ginterface14_1)
			: base(ginterface14_1)
		{
			gclass83_0 = gclass83_1;
		}

		public override string ToString()
		{
			return string.Concat("MismatchedSetException(", vmethod_0(), "!=", gclass83_0, ")");
		}
	}
}
