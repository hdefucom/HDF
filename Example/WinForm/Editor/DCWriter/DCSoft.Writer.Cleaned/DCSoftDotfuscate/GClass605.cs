using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public abstract class GClass605
	{
		private int int_0;

		private int int_1;

		public abstract sbyte[] vmethod_0();

		public virtual int vmethod_1()
		{
			return int_0;
		}

		public virtual int vmethod_2()
		{
			return int_1;
		}

		public virtual bool vmethod_3()
		{
			return false;
		}

		public virtual bool vmethod_4()
		{
			return false;
		}

		protected internal GClass605(int int_2, int int_3)
		{
			int_0 = int_2;
			int_1 = int_3;
		}

		public abstract sbyte[] vmethod_5(int int_2, sbyte[] sbyte_0);

		public virtual GClass605 vmethod_6(int int_2, int int_3, int int_4, int int_5)
		{
			throw new SystemException("This luminance source does not support cropping.");
		}

		public virtual GClass605 vmethod_7()
		{
			throw new SystemException("This luminance source does not support rotation.");
		}
	}
}
