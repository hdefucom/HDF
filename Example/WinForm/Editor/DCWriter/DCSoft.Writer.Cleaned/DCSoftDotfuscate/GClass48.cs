using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass48 : GClass45
	{
		protected internal GInterface15 ginterface15_0;

		public GClass48(GInterface15 ginterface15_1)
		{
			vmethod_36(ginterface15_1);
		}

		public override void vmethod_26()
		{
			base.vmethod_26();
			if (ginterface15_0 != null)
			{
				ginterface15_0.imethod_7(0);
			}
		}

		public virtual void vmethod_33(string string_1, int int_8)
		{
			base.vmethod_28(string_1, int_8, ginterface15_0.imethod_10(1));
		}

		public virtual void vmethod_34(string string_1, int int_8)
		{
			base.vmethod_29(string_1, int_8, ginterface15_0.imethod_10(1));
		}

		public override GInterface14 vmethod_31()
		{
			return ginterface15_0;
		}

		public virtual GInterface15 vmethod_35()
		{
			return ginterface15_0;
		}

		public virtual void vmethod_36(GInterface15 ginterface15_1)
		{
			ginterface15_0 = null;
			vmethod_26();
			ginterface15_0 = ginterface15_1;
		}
	}
}
