using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass482 : GClass480
	{
		private byte[] byte_0;

		private ushort ushort_0;

		private ushort ushort_1;

		private ushort ushort_2;

		private ushort ushort_3;

		private ushort ushort_4;

		private ushort ushort_5;

		private ushort ushort_6;

		private ushort ushort_7;

		private ushort ushort_8;

		private ushort ushort_9;

		private ushort ushort_10;

		private ushort ushort_11;

		private ushort ushort_12;

		private ushort ushort_13;

		public GClass482(GClass478 gclass478_1)
			: base(gclass478_1)
		{
		}

		protected override void vmethod_0(GClass498 gclass498_0)
		{
			byte_0 = gclass498_0.method_11(4);
			ushort_0 = gclass498_0.method_2();
			ushort_1 = gclass498_0.method_2();
			ushort_2 = gclass498_0.method_2();
			ushort_3 = gclass498_0.method_2();
			ushort_4 = gclass498_0.method_2();
			ushort_5 = gclass498_0.method_2();
			ushort_6 = gclass498_0.method_2();
			ushort_7 = gclass498_0.method_2();
			ushort_8 = gclass498_0.method_2();
			ushort_9 = gclass498_0.method_2();
			ushort_10 = gclass498_0.method_2();
			ushort_11 = gclass498_0.method_2();
			ushort_12 = gclass498_0.method_2();
			ushort_13 = gclass498_0.method_2();
		}

		protected override void vmethod_1(GClass498 gclass498_0)
		{
			gclass498_0.method_13(byte_0);
			gclass498_0.method_17(ushort_0);
			gclass498_0.method_17(ushort_1);
			gclass498_0.method_17(ushort_2);
			gclass498_0.method_17(ushort_3);
			gclass498_0.method_17(ushort_4);
			gclass498_0.method_17(ushort_5);
			gclass498_0.method_17(ushort_6);
			gclass498_0.method_17(ushort_7);
			gclass498_0.method_17(ushort_8);
			gclass498_0.method_17(ushort_9);
			gclass498_0.method_17(ushort_10);
			gclass498_0.method_17(ushort_11);
			gclass498_0.method_17(ushort_12);
			gclass498_0.method_17(ushort_13);
		}

		protected override void vmethod_2(GClass480 gclass480_0, GClass479 gclass479_0)
		{
			GClass482 gClass = gclass480_0 as GClass482;
			byte_0 = new byte[gClass.byte_0.Length];
			gClass.byte_0.CopyTo(byte_0, 0);
			ushort_0 = gClass.ushort_0;
			ushort_1 = gClass.ushort_1;
			ushort_2 = gClass.ushort_2;
			ushort_3 = gClass.ushort_3;
			ushort_4 = gClass.ushort_4;
			ushort_5 = gClass.ushort_5;
			ushort_6 = gClass.ushort_6;
			ushort_7 = gClass.ushort_7;
			ushort_8 = gClass.ushort_8;
			ushort_9 = gClass.ushort_9;
			ushort_10 = gClass.ushort_10;
			ushort_11 = gClass.ushort_11;
			ushort_12 = gClass.ushort_12;
			ushort_13 = gClass.ushort_13;
		}

		protected internal override string vmethod_3()
		{
			return "maxp";
		}

		public int method_6()
		{
			return Convert.ToInt32(ushort_0);
		}

		public override int vmethod_4()
		{
			return smethod_0();
		}

		public static int smethod_0()
		{
			return 32;
		}
	}
}
