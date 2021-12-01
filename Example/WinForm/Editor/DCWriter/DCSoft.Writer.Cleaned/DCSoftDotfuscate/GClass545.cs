using System;
using System.IO;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass545 : GClass544
	{
		private long long_0;

		private long long_1 = long.MaxValue;

		private DateTime dateTime_0 = DateTime.MinValue;

		private DateTime dateTime_1 = DateTime.MaxValue;

		public GClass545(string string_0, long long_2, long long_3)
			: base(string_0)
		{
			method_1(long_2);
			method_3(long_3);
		}

		public GClass545(string string_0, DateTime dateTime_2, DateTime dateTime_3)
			: base(string_0)
		{
			method_5(dateTime_2);
			method_7(dateTime_3);
		}

		public GClass545(string string_0, long long_2, long long_3, DateTime dateTime_2, DateTime dateTime_3)
			: base(string_0)
		{
			method_1(long_2);
			method_3(long_3);
			method_5(dateTime_2);
			method_7(dateTime_3);
		}

		public override bool imethod_0(string string_0)
		{
			bool result;
			if (result = base.imethod_0(string_0))
			{
				FileInfo fileInfo = new FileInfo(string_0);
				result = (method_0() <= fileInfo.Length && method_2() >= fileInfo.Length && method_4() <= fileInfo.LastWriteTime && method_6() >= fileInfo.LastWriteTime);
			}
			return result;
		}

		public long method_0()
		{
			return long_0;
		}

		public void method_1(long long_2)
		{
			int num = 14;
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
			int num = 18;
			if (long_2 < 0L || long_0 > long_2)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			long_1 = long_2;
		}

		public DateTime method_4()
		{
			return dateTime_0;
		}

		public void method_5(DateTime dateTime_2)
		{
			int num = 2;
			if (dateTime_2 > dateTime_1)
			{
				throw new ArgumentOutOfRangeException("value", "Exceeds MaxDate");
			}
			dateTime_0 = dateTime_2;
		}

		public DateTime method_6()
		{
			return dateTime_1;
		}

		public void method_7(DateTime dateTime_2)
		{
			int num = 6;
			if (dateTime_0 > dateTime_2)
			{
				throw new ArgumentOutOfRangeException("value", "Exceeds MinDate");
			}
			dateTime_1 = dateTime_2;
		}
	}
}
