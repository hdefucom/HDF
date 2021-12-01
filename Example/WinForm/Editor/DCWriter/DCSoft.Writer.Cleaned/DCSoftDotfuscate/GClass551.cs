using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass551
	{
		private long long_0;

		private long long_1;

		private long long_2;

		public long method_0()
		{
			return long_1;
		}

		public void method_1(long long_3)
		{
			long_1 = long_3;
		}

		public long method_2()
		{
			return long_0;
		}

		public void method_3(long long_3)
		{
			long_0 = long_3;
		}

		public long method_4()
		{
			return long_2;
		}

		public void method_5(long long_3)
		{
			long_2 = (long_3 & 0xFFFFFFFF);
		}
	}
}
