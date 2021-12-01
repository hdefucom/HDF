using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass481 : GClass480
	{
		private byte[] byte_0;

		private byte[] byte_1;

		private uint uint_0;

		private uint uint_1;

		private ushort ushort_0;

		private ushort ushort_1;

		private byte[] byte_2;

		private byte[] byte_3;

		private short short_0;

		private short short_1;

		private short short_2;

		private short short_3;

		private ushort ushort_2;

		private ushort ushort_3;

		private short short_4;

		private short short_5;

		private short short_6;

		public GClass481(GClass478 gclass478_1)
			: base(gclass478_1)
		{
		}

		protected override void vmethod_0(GClass498 gclass498_0)
		{
			byte_0 = gclass498_0.method_11(4);
			byte_1 = gclass498_0.method_11(4);
			uint_0 = gclass498_0.method_4();
			uint_1 = gclass498_0.method_4();
			ushort_0 = gclass498_0.method_2();
			ushort_1 = gclass498_0.method_2();
			byte_2 = gclass498_0.method_11(8);
			byte_3 = gclass498_0.method_11(8);
			short_0 = gclass498_0.method_8();
			short_1 = gclass498_0.method_8();
			short_2 = gclass498_0.method_8();
			short_3 = gclass498_0.method_8();
			ushort_2 = gclass498_0.method_2();
			ushort_3 = gclass498_0.method_2();
			short_4 = gclass498_0.method_3();
			short_5 = gclass498_0.method_3();
			short_6 = gclass498_0.method_3();
		}

		protected override void vmethod_1(GClass498 gclass498_0)
		{
			gclass498_0.method_13(byte_0);
			gclass498_0.method_13(byte_1);
			gclass498_0.method_19(uint_0);
			gclass498_0.method_19(uint_1);
			gclass498_0.method_17(ushort_0);
			gclass498_0.method_17(ushort_1);
			gclass498_0.method_13(byte_2);
			gclass498_0.method_13(byte_3);
			gclass498_0.method_22(short_0);
			gclass498_0.method_22(short_1);
			gclass498_0.method_22(short_2);
			gclass498_0.method_22(short_3);
			gclass498_0.method_17(ushort_2);
			gclass498_0.method_17(ushort_3);
			gclass498_0.method_18(short_4);
			gclass498_0.method_18(short_5);
			gclass498_0.method_18(short_6);
		}

		protected override void vmethod_2(GClass480 gclass480_0, GClass479 gclass479_0)
		{
			GClass481 gClass = gclass480_0 as GClass481;
			byte_0 = new byte[gClass.byte_0.Length];
			gClass.byte_0.CopyTo(byte_0, 0);
			byte_1 = new byte[gClass.byte_1.Length];
			gClass.byte_1.CopyTo(byte_1, 0);
			uint_0 = 0u;
			uint_1 = gClass.uint_1;
			ushort_0 = gClass.ushort_0;
			ushort_1 = gClass.method_7();
			byte_2 = new byte[gClass.byte_2.Length];
			gClass.byte_2.CopyTo(byte_2, 0);
			byte_3 = new byte[gClass.byte_3.Length];
			gClass.byte_3.CopyTo(byte_3, 0);
			short_0 = gClass.method_8();
			short_1 = gClass.method_9();
			short_2 = gClass.method_10();
			short_3 = gClass.method_11();
			ushort_2 = gClass.ushort_2;
			ushort_3 = gClass.ushort_3;
			short_4 = gClass.short_4;
			short_5 = gClass.short_5;
			short_6 = gClass.short_6;
		}

		protected internal override string vmethod_3()
		{
			return "head";
		}

		public void method_6(GClass498 gclass498_0)
		{
			if (method_4() != null)
			{
				gclass498_0.method_27(method_4().method_7());
				gclass498_0.method_26(8);
				if (uint_0 == 0)
				{
					uint_0 = GClass501.smethod_0(gclass498_0, 0, gclass498_0.vmethod_4());
					uint_0 = (uint)(-1313820742 - (int)uint_0);
				}
				gclass498_0.method_19(uint_0);
			}
		}

		public ushort method_7()
		{
			return ushort_1;
		}

		public short method_8()
		{
			return short_0;
		}

		public short method_9()
		{
			return short_1;
		}

		public short method_10()
		{
			return short_2;
		}

		public short method_11()
		{
			return short_3;
		}

		public short method_12()
		{
			return short_5;
		}

		public override int vmethod_4()
		{
			return smethod_0();
		}

		public static int smethod_0()
		{
			return 54;
		}
	}
}
