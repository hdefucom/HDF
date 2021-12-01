using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[Serializable]
	[ComVisible(false)]
	public class GException12 : GException4
	{
		public string string_0;

		public string string_1;

		public GException12()
		{
		}

		public GException12(GInterface14 ginterface14_1, string string_2, string string_3)
			: base(ginterface14_1)
		{
			string_1 = string_2;
			string_0 = string_3;
		}

		public override string ToString()
		{
			return "FailedPredicateException(" + string_1 + ",{" + string_0 + "}?)";
		}
	}
}
