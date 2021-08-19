using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public abstract class GClass642
	{
		private GClass605 gclass605_0;

		public virtual GClass605 vmethod_0()
		{
			return gclass605_0;
		}

		public abstract GClass679 vmethod_1();

		protected internal GClass642(GClass605 gclass605_1)
		{
			int num = 3;
			
			if (gclass605_1 == null)
			{
				throw new ArgumentException("Source must be non-null.");
			}
			gclass605_0 = gclass605_1;
		}

		public abstract GClass659 vmethod_2(int int_0, GClass659 gclass659_0);

		public abstract GClass642 vmethod_3(GClass605 gclass605_1);
	}
}
