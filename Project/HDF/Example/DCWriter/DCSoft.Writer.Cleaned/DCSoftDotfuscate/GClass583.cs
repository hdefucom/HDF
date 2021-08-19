using System;
using System.IO;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass583 : GInterface31
	{
		[Flags]
		[ComVisible(false)]
		public enum GEnum103 : byte
		{
			flag_0 = 0x1,
			flag_1 = 0x2,
			flag_2 = 0x4
		}

		private GEnum103 genum103_0;

		private DateTime dateTime_0 = new DateTime(1970, 1, 1);

		private DateTime dateTime_1 = new DateTime(1970, 1, 1);

		private DateTime dateTime_2 = new DateTime(1970, 1, 1);

		public short imethod_0()
		{
			return 21589;
		}

		public void imethod_1(byte[] byte_0, int int_0, int int_1)
		{
			using (MemoryStream stream_ = new MemoryStream(byte_0, int_0, int_1, writable: false))
			{
				using (Stream0 stream = new Stream0(stream_))
				{
					genum103_0 = (GEnum103)stream.ReadByte();
					if ((genum103_0 & GEnum103.flag_0) != 0 && int_1 >= 5)
					{
						int seconds = stream.method_7();
						dateTime_0 = (new DateTime(1970, 1, 1, 0, 0, 0).ToUniversalTime() + new TimeSpan(0, 0, 0, seconds, 0)).ToLocalTime();
					}
					if ((genum103_0 & GEnum103.flag_1) != 0)
					{
						int seconds = stream.method_7();
						dateTime_1 = (new DateTime(1970, 1, 1, 0, 0, 0).ToUniversalTime() + new TimeSpan(0, 0, 0, seconds, 0)).ToLocalTime();
					}
					if ((genum103_0 & GEnum103.flag_2) != 0)
					{
						int seconds = stream.method_7();
						dateTime_2 = (new DateTime(1970, 1, 1, 0, 0, 0).ToUniversalTime() + new TimeSpan(0, 0, 0, seconds, 0)).ToLocalTime();
					}
				}
			}
		}

		public byte[] imethod_2()
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (Stream0 stream = new Stream0(memoryStream))
				{
					stream.method_1(bool_1: false);
					stream.WriteByte((byte)genum103_0);
					if ((genum103_0 & GEnum103.flag_0) != 0)
					{
						int int_ = (int)(dateTime_0.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0).ToUniversalTime()).TotalSeconds;
						stream.method_11(int_);
					}
					if ((genum103_0 & GEnum103.flag_1) != 0)
					{
						int int_ = (int)(dateTime_1.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0).ToUniversalTime()).TotalSeconds;
						stream.method_11(int_);
					}
					if ((genum103_0 & GEnum103.flag_2) != 0)
					{
						int int_ = (int)(dateTime_2.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0).ToUniversalTime()).TotalSeconds;
						stream.method_11(int_);
					}
					return memoryStream.ToArray();
				}
			}
		}

		public static bool smethod_0(DateTime dateTime_3)
		{
			return dateTime_3 >= new DateTime(1901, 12, 13, 20, 45, 52) || dateTime_3 <= new DateTime(2038, 1, 19, 3, 14, 7);
		}

		public DateTime method_0()
		{
			return dateTime_0;
		}

		public void method_1(DateTime dateTime_3)
		{
			int num = 5;
			if (!smethod_0(dateTime_3))
			{
				throw new ArgumentOutOfRangeException("value");
			}
			genum103_0 |= GEnum103.flag_0;
			dateTime_0 = dateTime_3;
		}

		public DateTime method_2()
		{
			return dateTime_1;
		}

		public void method_3(DateTime dateTime_3)
		{
			int num = 18;
			if (!smethod_0(dateTime_3))
			{
				throw new ArgumentOutOfRangeException("value");
			}
			genum103_0 |= GEnum103.flag_1;
			dateTime_1 = dateTime_3;
		}

		public DateTime method_4()
		{
			return dateTime_2;
		}

		public void method_5(DateTime dateTime_3)
		{
			int num = 13;
			if (!smethod_0(dateTime_3))
			{
				throw new ArgumentOutOfRangeException("value");
			}
			genum103_0 |= GEnum103.flag_2;
			dateTime_2 = dateTime_3;
		}

		private GEnum103 method_6()
		{
			return genum103_0;
		}

		private void method_7(GEnum103 genum103_1)
		{
			genum103_0 = genum103_1;
		}
	}
}
