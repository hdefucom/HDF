using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[Serializable]
	[ComVisible(false)]
	public class GException7 : GException6
	{
		public GException7()
		{
		}

		public GException7(GClass83 gclass83_1, GInterface14 ginterface14_1)
			: base(gclass83_1, ginterface14_1)
		{
		}

		public override string ToString()
		{
			return string.Concat("MismatchedNotSetException(", vmethod_0(), "!=", gclass83_0, ")");
		}
	}
}
