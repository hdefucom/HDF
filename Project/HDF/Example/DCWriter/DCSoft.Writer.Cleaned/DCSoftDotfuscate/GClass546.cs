using System;
using System.IO;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[Obsolete("Use ExtendedPathFilter instead")]
	[ComVisible(false)]
	public class GClass546 : GClass544
	{
		private long long_0;

		private long long_1 = long.MaxValue;

		public GClass546(string string_0, long long_2, long long_3)
			: base(string_0)
		{
			method_1(long_2);
			method_3(long_3);
		}

		public override bool imethod_0(string string_0)
		{
			bool result;
			if (result = base.imethod_0(string_0))
			{
				FileInfo fileInfo = new FileInfo(string_0);
				long length = fileInfo.Length;
				result = (method_0() <= length && method_2() >= length);
			}
			return result;
		}

		public long method_0()
		{
			return long_0;
		}

		public void method_1(long long_2)
		{
			int num = 17;
			if (long_2 < 0L || long_1 < long_2)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			long_0 = long_2;
		}

		public long method_2()
		{
			return long_1;
		}

		public void method_3(long long_2)
		{
			int num = 19;
			if (long_2 < 0L || long_0 > long_2)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			long_1 = long_2;
		}
	}
}
