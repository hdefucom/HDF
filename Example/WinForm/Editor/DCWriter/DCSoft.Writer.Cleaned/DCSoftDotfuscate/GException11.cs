using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[Serializable]
	[ComVisible(false)]
	public class GException11 : GException4
	{
		public int int_4;

		public GException11()
		{
		}

		public GException11(int int_5, GInterface14 ginterface14_1)
			: base(ginterface14_1)
		{
			int_4 = int_5;
		}
	}
}
