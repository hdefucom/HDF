using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[Serializable]
	[ComVisible(false)]
	public class GClass387 : GClass383
	{
		private int int_1 = 0;

		public int method_17()
		{
			return int_1;
		}

		public void method_18(int int_2)
		{
			int_1 = int_2;
		}

		public override string ToString()
		{
			return "Column";
		}
	}
}
