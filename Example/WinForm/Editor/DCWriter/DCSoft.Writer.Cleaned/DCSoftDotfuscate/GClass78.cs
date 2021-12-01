using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass78 : GClass77
	{
		public int int_0;

		public int int_1;

		protected GInterface12 ginterface12_0;

		public GClass78()
		{
			int_0 = -1;
			int_1 = -1;
		}

		public GClass78(GInterface12 ginterface12_1)
		{
			int_0 = -1;
			int_1 = -1;
			ginterface12_0 = ginterface12_1;
		}

		public GClass78(GClass78 gclass78_0)
			: base(gclass78_0)
		{
			int_0 = -1;
			int_1 = -1;
			ginterface12_0 = gclass78_0.ginterface12_0;
		}

		public override GInterface11 imethod_1()
		{
			return new GClass78(this);
		}

		public override string ToString()
		{
			int num = 17;
			if (imethod_7())
			{
				return "nil";
			}
			return ginterface12_0.imethod_6();
		}

		public override int imethod_5()
		{
			if (ginterface12_0 == null || ginterface12_0.imethod_2() == -1)
			{
				if (imethod_6() > 0)
				{
					return imethod_3(0).imethod_5();
				}
				return 0;
			}
			return ginterface12_0.imethod_2();
		}

		public override bool imethod_7()
		{
			return ginterface12_0 == null;
		}

		public override int imethod_8()
		{
			if (ginterface12_0 == null || ginterface12_0.imethod_4() == 0)
			{
				if (imethod_6() > 0)
				{
					return imethod_3(0).imethod_8();
				}
				return 0;
			}
			return ginterface12_0.imethod_4();
		}

		public override string imethod_9()
		{
			return ToString();
		}

		public virtual GInterface12 vmethod_3()
		{
			return ginterface12_0;
		}

		public override int imethod_10()
		{
			if (int_0 == -1 && ginterface12_0 != null)
			{
				return ginterface12_0.imethod_8();
			}
			return int_0;
		}

		public override void imethod_11(int int_2)
		{
			int_0 = int_2;
		}

		public override int imethod_12()
		{
			if (int_1 == -1 && ginterface12_0 != null)
			{
				return ginterface12_0.imethod_8();
			}
			return int_1;
		}

		public override void imethod_13(int int_2)
		{
			int_1 = int_2;
		}

		public override int imethod_14()
		{
			if (ginterface12_0 == null)
			{
				return 0;
			}
			return ginterface12_0.imethod_10();
		}
	}
}
