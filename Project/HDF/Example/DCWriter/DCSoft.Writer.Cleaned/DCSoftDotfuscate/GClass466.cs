using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass466 : GClass459
	{
		private GClass516 gclass516_0 = null;

		private GClass466 gclass466_0;

		public GClass466(GClass466 gclass466_1)
		{
			gclass466_0 = gclass466_1;
		}

		public GClass516 method_4()
		{
			return gclass516_0;
		}

		public void method_5(GClass516 gclass516_1)
		{
			gclass516_0 = gclass516_1;
		}

		public GClass466 method_6()
		{
			return gclass466_0;
		}

		public override void vmethod_2()
		{
			int num = 14;
			base.vmethod_2();
			if (gclass516_0 != null)
			{
				method_3().method_8("MediaBox", gclass516_0);
			}
			if (gclass466_0 != null)
			{
				method_3().method_8("Parent", gclass466_0.method_3());
			}
		}
	}
}
