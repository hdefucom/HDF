using System;
using System.IO;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass461 : GClass460
	{
		public const int int_0 = 32;

		public const int int_1 = 255;

		private GClass464 gclass464_0;

		private GClass513 gclass513_0 = new GClass513();

		public GClass461(GClass476 gclass476_1)
			: base(gclass476_1)
		{
			gclass464_0 = new GClass464(this);
			method_8();
		}

		public GClass464 method_7()
		{
			return gclass464_0;
		}

		public override string vmethod_4()
		{
			return "TrueType";
		}

		public override string vmethod_5()
		{
			return Class211.smethod_1(method_5(), bool_0: false);
		}

		private void method_8()
		{
			gclass513_0.method_1(GEnum89.const_1);
			gclass513_0.method_16(8);
			for (int i = 32; i <= 255; i++)
			{
				gclass513_0.method_11((int)method_4().method_10(Convert.ToChar(i)));
			}
		}

		protected override void vmethod_0(GClass540 gclass540_0)
		{
			base.vmethod_0(gclass540_0);
			gclass540_0.method_2(gclass513_0);
			gclass464_0.method_1(gclass540_0);
		}

		protected override void vmethod_1(StreamWriter streamWriter_0)
		{
			base.vmethod_1(streamWriter_0);
			gclass513_0.method_6(streamWriter_0);
			gclass464_0.method_2(streamWriter_0);
		}

		public override void vmethod_2()
		{
			base.vmethod_2();
			method_3().method_10("FirstChar", 32);
			method_3().method_10("LastChar", 255);
			method_3().method_8("Widths", gclass513_0);
			method_3().method_9("Encoding", "PDFDocEncoding");
			method_3().method_8("FontDescriptor", gclass464_0.method_3());
			gclass464_0.vmethod_2();
		}
	}
}
