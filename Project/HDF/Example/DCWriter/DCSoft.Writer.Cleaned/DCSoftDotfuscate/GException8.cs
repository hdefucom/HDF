using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[Serializable]
	[ComVisible(false)]
	public class GException8 : GException4
	{
		public int int_4;

		public int int_5;

		public GException8(int int_6, int int_7, GInterface14 ginterface14_1)
			: base(ginterface14_1)
		{
			int_4 = int_6;
			int_5 = int_7;
		}

		public override string ToString()
		{
			return "MismatchedNotSetException(" + vmethod_0() + " not in [" + int_4 + "," + int_5 + "])";
		}
	}
}
