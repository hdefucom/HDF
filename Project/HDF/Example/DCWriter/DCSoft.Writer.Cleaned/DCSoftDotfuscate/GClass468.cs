using System.IO;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass468 : GClass466
	{
		private GClass458 gclass458_0;

		private GClass469 gclass469_0 = new GClass469();

		private GClass477 gclass477_0 = new GClass477();

		private GClass513 gclass513_0 = new GClass513();

		public GClass468(GClass466 gclass466_1)
			: base(gclass466_1)
		{
			gclass458_0 = method_7();
			method_8();
		}

		public override void Dispose()
		{
			base.Dispose();
			if (gclass469_0 != null)
			{
				gclass469_0.Dispose();
				gclass469_0 = null;
			}
			if (gclass477_0 != null)
			{
				gclass477_0.Dispose();
				gclass477_0 = null;
			}
			if (gclass513_0 != null)
			{
				gclass513_0.Dispose();
				gclass513_0 = null;
			}
		}

		private GClass458 method_7()
		{
			return new GClass458(this);
		}

		private void method_8()
		{
			gclass513_0.method_10("PDF");
			gclass513_0.method_10("Text");
			gclass513_0.method_10("ImageC");
		}

		private void method_9(GClass514 gclass514_0)
		{
			int num = 8;
			if (gclass477_0.method_0() > 0)
			{
				GClass514 gClass = new GClass514();
				for (int i = 0; i < gclass477_0.method_0(); i++)
				{
					gClass.method_8(gclass477_0.method_1(i).Name, gclass477_0.method_1(i).method_0());
				}
				gclass514_0.method_8("Font", gClass);
			}
		}

		private void method_10(GClass514 gclass514_0)
		{
			int num = 15;
			if (gclass469_0.method_8() > 0)
			{
				GClass514 gClass = new GClass514();
				for (int i = 0; i < gclass469_0.method_8(); i++)
				{
					gClass.method_8(gclass469_0.method_9(i).Name, gclass469_0.method_9(i).method_3());
				}
				gclass514_0.method_8("XObject", gClass);
			}
		}

		private void method_11(GClass514 gclass514_0)
		{
			int num = 13;
			if (gclass513_0.method_17() > 0)
			{
				gclass514_0.method_8("ProcSet", gclass513_0);
			}
		}

		protected override void vmethod_0(GClass540 gclass540_0)
		{
			gclass458_0.method_1(gclass540_0);
		}

		protected override void vmethod_1(StreamWriter streamWriter_0)
		{
			gclass458_0.method_2(streamWriter_0);
		}

		public override void vmethod_2()
		{
			method_3().method_8("Type", new GClass509("Page"));
			GClass514 gClass = new GClass514();
			method_9(gClass);
			method_10(gClass);
			method_11(gClass);
			method_3().method_8("Resources", gClass);
			method_3().method_8("Contents", gclass458_0.method_3());
			base.vmethod_2();
			gclass458_0.vmethod_2();
		}

		protected internal GClass469 method_12()
		{
			return gclass469_0;
		}

		protected internal GClass477 method_13()
		{
			return gclass477_0;
		}

		public GClass458 method_14()
		{
			return gclass458_0;
		}

		public void method_15(GClass458 gclass458_1)
		{
			gclass458_0 = gclass458_1;
			if (gclass458_0 == null)
			{
				gclass458_0 = method_7();
			}
		}

		public GClass513 method_16()
		{
			return gclass513_0;
		}
	}
}
