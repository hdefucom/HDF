using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass87 : GClass86
	{
		public override object imethod_3(GInterface12 ginterface12_0)
		{
			return new GClass78(ginterface12_0);
		}

		public override GInterface12 vmethod_0(GInterface12 ginterface12_0)
		{
			return new GClass85(ginterface12_0);
		}

		public override GInterface12 vmethod_1(int int_0, string string_0)
		{
			return new GClass85(int_0, string_0);
		}

		public override object imethod_7(object object_0)
		{
			return ((GInterface11)object_0).imethod_1();
		}

		public override object imethod_9(object object_0, int int_0)
		{
			return ((GInterface11)object_0).imethod_3(int_0);
		}

		public override int imethod_10(object object_0)
		{
			return ((GInterface11)object_0).imethod_6();
		}

		public override string imethod_12(object object_0)
		{
			return ((GInterface11)object_0).imethod_9();
		}

		public override int imethod_13(object object_0)
		{
			if (object_0 == null)
			{
				return 0;
			}
			return ((GInterface11)object_0).imethod_14();
		}

		public override GInterface12 imethod_14(object object_0)
		{
			if (object_0 is GClass78)
			{
				return ((GClass78)object_0).vmethod_3();
			}
			return null;
		}

		public override int imethod_15(object object_0)
		{
			return ((GInterface11)object_0).imethod_10();
		}

		public override int imethod_16(object object_0)
		{
			return ((GInterface11)object_0).imethod_12();
		}

		public override void imethod_22(object object_0, GInterface12 ginterface12_0, GInterface12 ginterface12_1)
		{
			if (object_0 != null)
			{
				int int_ = 0;
				int int_2 = 0;
				if (ginterface12_0 != null)
				{
					int_ = ginterface12_0.imethod_8();
				}
				if (ginterface12_1 != null)
				{
					int_2 = ginterface12_1.imethod_8();
				}
				((GInterface11)object_0).imethod_11(int_);
				((GInterface11)object_0).imethod_13(int_2);
			}
		}
	}
}
