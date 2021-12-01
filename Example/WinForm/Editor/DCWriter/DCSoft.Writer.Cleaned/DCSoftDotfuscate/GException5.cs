using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[Serializable]
	[ComVisible(false)]
	public class GException5 : GException4
	{
		public int int_4;

		public string string_0;

		public int int_5;

		public GException5()
		{
		}

		public GException5(string string_1, int int_6, int int_7, GInterface14 ginterface14_1)
			: base(ginterface14_1)
		{
			string_0 = string_1;
			int_4 = int_6;
			int_5 = int_7;
		}

		public override string ToString()
		{
			return "NoViableAltException(" + vmethod_0() + "!=[" + string_0 + "])";
		}
	}
}
