using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public abstract class GClass480
	{
		protected const string string_0 = "The required table doesn't exist in the font file";

		private GClass478 gclass478_0;

		private GClass497 gclass497_0;

		public GClass480(GClass478 gclass478_1)
		{
			gclass478_0 = gclass478_1;
		}

		protected virtual void vmethod_0(GClass498 gclass498_0)
		{
		}

		protected virtual void vmethod_1(GClass498 gclass498_0)
		{
		}

		protected virtual void vmethod_2(GClass480 gclass480_0, GClass479 gclass479_0)
		{
		}

		protected internal abstract string vmethod_3();

		public void method_0(GClass498 gclass498_0)
		{
			if (method_4() != null)
			{
				gclass498_0.method_27(method_4().method_7());
				vmethod_0(gclass498_0);
			}
		}

		public void method_1(GClass498 gclass498_0)
		{
			gclass498_0.method_25();
			if (method_4() != null)
			{
				method_4().method_5(gclass498_0.vmethod_3());
			}
			vmethod_1(gclass498_0);
		}

		public void method_2(GClass480 gclass480_0)
		{
			method_3(gclass480_0, null);
		}

		public void method_3(GClass480 gclass480_0, GClass479 gclass479_0)
		{
			if (gclass480_0 != null && GetType().Equals(gclass480_0.GetType()))
			{
				vmethod_2(gclass480_0, gclass479_0);
				if (method_4() == null)
				{
					method_5().method_11().method_4(this);
				}
			}
		}

		protected internal GClass497 method_4()
		{
			if (gclass497_0 == null)
			{
				gclass497_0 = method_5().method_11().method_12(vmethod_3());
			}
			return gclass497_0;
		}

		public GClass478 method_5()
		{
			return gclass478_0;
		}

		public virtual int vmethod_4()
		{
			return 0;
		}
	}
}
