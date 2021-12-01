using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public abstract class GClass655
	{
		private int int_0;

		public virtual int vmethod_0()
		{
			return int_0;
		}

		internal GClass655(int int_1)
		{
			int_0 = int_1;
		}

		public static GClass655 smethod_0(int int_1)
		{
			int num = 9;
			if (int_1 < 0 || int_1 > 999999)
			{
				throw new ArgumentException("Bad ECI value: " + int_1);
			}
			if (int_1 < 900)
			{
				return GClass656.smethod_4(int_1);
			}
			return null;
		}
	}
}
