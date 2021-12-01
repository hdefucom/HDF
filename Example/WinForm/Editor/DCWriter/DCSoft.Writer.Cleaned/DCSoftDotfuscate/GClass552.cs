using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass552
	{
		public GDelegate26 gdelegate26_0;

		public GDelegate27 gdelegate27_0;

		public GDelegate28 gdelegate28_0;

		public GDelegate29 gdelegate29_0;

		public GDelegate30 gdelegate30_0;

		public GDelegate31 gdelegate31_0;

		private TimeSpan timeSpan_0 = TimeSpan.FromSeconds(3.0);

		public bool method_0(string string_0, Exception exception_0)
		{
			bool result = false;
			GDelegate30 gDelegate = gdelegate30_0;
			if (gDelegate != null)
			{
				GEventArgs18 gEventArgs = new GEventArgs18(string_0, exception_0);
				gDelegate(this, gEventArgs);
				result = gEventArgs.method_1();
			}
			return result;
		}

		public bool method_1(string string_0, Exception exception_0)
		{
			GDelegate31 gDelegate = gdelegate31_0;
			bool result;
			if (result = (gDelegate != null))
			{
				GEventArgs18 gEventArgs = new GEventArgs18(string_0, exception_0);
				gDelegate(this, gEventArgs);
				result = gEventArgs.method_1();
			}
			return result;
		}

		public bool method_2(string string_0)
		{
			bool result = true;
			GDelegate27 gDelegate = gdelegate27_0;
			if (gDelegate != null)
			{
				GEventArgs15 gEventArgs = new GEventArgs15(string_0);
				gDelegate(this, gEventArgs);
				result = gEventArgs.method_0();
			}
			return result;
		}

		public bool method_3(string string_0)
		{
			bool result = true;
			GDelegate29 gDelegate = gdelegate29_0;
			if (gDelegate != null)
			{
				GEventArgs15 gEventArgs = new GEventArgs15(string_0);
				gDelegate(this, gEventArgs);
				result = gEventArgs.method_0();
			}
			return result;
		}

		public bool method_4(string string_0, bool bool_0)
		{
			bool result = true;
			GDelegate26 gDelegate = gdelegate26_0;
			if (gDelegate != null)
			{
				GEventArgs16 gEventArgs = new GEventArgs16(string_0, bool_0);
				gDelegate(this, gEventArgs);
				result = gEventArgs.method_0();
			}
			return result;
		}

		public TimeSpan method_5()
		{
			return timeSpan_0;
		}

		public void method_6(TimeSpan timeSpan_1)
		{
			timeSpan_0 = timeSpan_1;
		}
	}
}
