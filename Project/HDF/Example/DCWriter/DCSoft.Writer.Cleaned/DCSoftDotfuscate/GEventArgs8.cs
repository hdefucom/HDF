using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GEventArgs8 : EventArgs
	{
		private GClass290 gclass290_0 = null;

		public GClass290 method_0()
		{
			return gclass290_0;
		}

		public void method_1(GClass290 gclass290_1)
		{
			gclass290_0 = gclass290_1;
		}
	}
}
