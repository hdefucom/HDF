using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GEventArgs9 : EventArgs
	{
		private GClass290 gclass290_0 = null;

		private List<GClass290> list_0 = new List<GClass290>();

		public GEventArgs9(GClass290 gclass290_1)
		{
			gclass290_0 = gclass290_1;
		}

		public GClass290 method_0()
		{
			return gclass290_0;
		}

		public List<GClass290> method_1()
		{
			return list_0;
		}

		public void method_2(List<GClass290> list_1)
		{
			list_0 = list_1;
		}
	}
}
