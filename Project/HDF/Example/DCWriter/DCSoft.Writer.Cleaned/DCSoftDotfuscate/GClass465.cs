using System.IO;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass465 : GClass459
	{
		private GClass467 gclass467_0 = new GClass467(null);

		public GClass465()
		{
			gclass467_0.method_5(new GClass516(0, 0, 596, 842));
		}

		public GClass467 method_4()
		{
			return gclass467_0;
		}

		protected override void vmethod_0(GClass540 gclass540_0)
		{
			base.vmethod_0(gclass540_0);
			gclass467_0.method_1(gclass540_0);
		}

		protected override void vmethod_1(StreamWriter streamWriter_0)
		{
			base.vmethod_1(streamWriter_0);
			gclass467_0.method_2(streamWriter_0);
		}

		public override void vmethod_2()
		{
			method_3().method_8("Type", new GClass509("Catalog"));
			method_3().method_8("Pages", gclass467_0.method_3());
			base.vmethod_2();
			gclass467_0.vmethod_2();
		}
	}
}
