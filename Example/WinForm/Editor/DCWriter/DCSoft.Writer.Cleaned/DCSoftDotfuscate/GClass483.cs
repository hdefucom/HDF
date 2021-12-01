using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass483 : GClass480
	{
		private byte[] byte_0;

		private short short_0;

		private short short_1;

		private short short_2;

		private ushort ushort_0;

		private short short_3;

		private short short_4;

		private short short_5;

		private short short_6;

		private short short_7;

		private byte[] byte_1;

		private short short_8;

		private ushort ushort_1;

		public GClass483(GClass478 gclass478_1)
			: base(gclass478_1)
		{
		}

		protected override void vmethod_0(GClass498 gclass498_0)
		{
			byte_0 = gclass498_0.method_11(4);
			short_0 = gclass498_0.method_8();
			short_1 = gclass498_0.method_8();
			short_2 = gclass498_0.method_8();
			ushort_0 = gclass498_0.method_7();
			short_3 = gclass498_0.method_8();
			short_4 = gclass498_0.method_8();
			short_5 = gclass498_0.method_8();
			short_6 = gclass498_0.method_3();
			short_7 = gclass498_0.method_3();
			byte_1 = gclass498_0.method_11(10);
			short_8 = gclass498_0.method_3();
			ushort_1 = gclass498_0.method_2();
		}

		protected override void vmethod_1(GClass498 gclass498_0)
		{
			gclass498_0.method_13(byte_0);
			gclass498_0.method_22(short_0);
			gclass498_0.method_22(short_1);
			gclass498_0.method_22(short_2);
			gclass498_0.method_21(ushort_0);
			gclass498_0.method_22(short_3);
			gclass498_0.method_22(short_4);
			gclass498_0.method_22(short_5);
			gclass498_0.method_18(short_6);
			gclass498_0.method_18(short_7);
			gclass498_0.method_13(byte_1);
			gclass498_0.method_18(short_8);
			gclass498_0.method_17(ushort_1);
		}

		protected override void vmethod_2(GClass480 gclass480_0, GClass479 gclass479_0)
		{
			GClass483 gClass = gclass480_0 as GClass483;
			byte_0 = new byte[gClass.byte_0.Length];
			gClass.byte_0.CopyTo(byte_0, 0);
			short_0 = gClass.short_0;
			short_1 = gClass.short_1;
			short_2 = gClass.short_2;
			ushort_0 = gClass.ushort_0;
			short_3 = gClass.short_3;
			short_4 = gClass.short_4;
			short_5 = gClass.short_5;
			short_6 = gClass.short_6;
			short_7 = gClass.short_7;
			byte_1 = new byte[gClass.byte_1.Length];
			gClass.byte_1.CopyTo(byte_1, 0);
			short_8 = gClass.short_8;
			ushort_1 = gClass.ushort_1;
		}

		protected internal override string vmethod_3()
		{
			return "hhea";
		}

		public short method_6()
		{
			return short_0;
		}

		public short method_7()
		{
			return short_1;
		}

		public int method_8()
		{
			return ushort_1;
		}

		public override int vmethod_4()
		{
			return smethod_0();
		}

		public static int smethod_0()
		{
			return 36;
		}
	}
}
