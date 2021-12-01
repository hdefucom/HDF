using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass570
	{
		private GClass571 gclass571_0;

		private GClass577 gclass577_0;

		private bool bool_0;

		private int int_0;

		private long long_0;

		private GEnum99 genum99_0;

		public GClass570(GClass571 gclass571_1)
		{
			gclass571_0 = gclass571_1;
		}

		public GEnum99 method_0()
		{
			return genum99_0;
		}

		public GClass571 method_1()
		{
			return gclass571_0;
		}

		public GClass577 method_2()
		{
			return gclass577_0;
		}

		public int method_3()
		{
			return int_0;
		}

		public long method_4()
		{
			return long_0;
		}

		public bool method_5()
		{
			return bool_0;
		}

		internal void method_6()
		{
			int_0++;
			bool_0 = false;
		}

		internal void method_7(GEnum99 genum99_1)
		{
			genum99_0 = genum99_1;
		}

		internal void method_8(GClass577 gclass577_1)
		{
			gclass577_0 = gclass577_1;
			bool_0 = true;
			long_0 = 0L;
		}

		internal void method_9(long long_1)
		{
			long_0 = long_1;
		}
	}
}
