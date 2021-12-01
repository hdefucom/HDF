using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[Serializable]
	[ComVisible(false)]
	public class GException9 : GException4
	{
		public int int_4;

		public GException9()
		{
		}

		public GException9(int int_5, GInterface14 ginterface14_1)
			: base(ginterface14_1)
		{
			int_4 = int_5;
		}

		public override string ToString()
		{
			return "MismatchedTokenException(" + vmethod_0() + "!=" + int_4 + ")";
		}
	}
}
