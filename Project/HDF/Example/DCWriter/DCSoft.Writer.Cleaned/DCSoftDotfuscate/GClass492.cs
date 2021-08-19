using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass492
	{
		private const int int_0 = 10;

		private short short_0;

		private short short_1;

		private short short_2;

		private short short_3;

		private short short_4;

		private GClass493 gclass493_0;

		private int int_1;

		public GClass492(int int_2)
		{
			int_1 = int_2;
		}

		private void method_0(GClass498 gclass498_0)
		{
			if (short_0 >= 0)
			{
				gclass493_0 = new GClass493();
			}
			else
			{
				gclass493_0 = new GClass494();
			}
			gclass493_0.vmethod_0(gclass498_0, int_1 - 10);
		}

		public void method_1(GClass498 gclass498_0)
		{
			short_0 = gclass498_0.method_3();
			short_1 = gclass498_0.method_8();
			short_2 = gclass498_0.method_8();
			short_3 = gclass498_0.method_8();
			short_4 = gclass498_0.method_8();
			method_0(gclass498_0);
		}

		public void method_2(GClass498 gclass498_0)
		{
			gclass498_0.method_18(short_0);
			gclass498_0.method_22(short_1);
			gclass498_0.method_22(short_2);
			gclass498_0.method_22(short_3);
			gclass498_0.method_22(short_4);
			if (gclass493_0 != null)
			{
				gclass493_0.method_0(gclass498_0);
			}
		}

		public GClass493 method_3()
		{
			return gclass493_0;
		}

		public int method_4()
		{
			return int_1;
		}

		public short method_5()
		{
			return short_1;
		}

		public short method_6()
		{
			return short_2;
		}

		public short method_7()
		{
			return short_3;
		}

		public short method_8()
		{
			return short_4;
		}
	}
}
