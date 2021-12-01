using System;
using System.IO;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass584 : GInterface31
	{
		private DateTime dateTime_0 = DateTime.FromFileTime(0L);

		private DateTime dateTime_1 = DateTime.FromFileTime(0L);

		private DateTime dateTime_2 = DateTime.FromFileTime(0L);

		public short imethod_0()
		{
			return 10;
		}

		public void imethod_1(byte[] byte_0, int int_0, int int_1)
		{
			using (MemoryStream stream_ = new MemoryStream(byte_0, int_0, int_1, writable: false))
			{
				using (Stream0 stream = new Stream0(stream_))
				{
					stream.method_7();
					int num2;
					while (true)
					{
						if (stream.Position >= stream.Length)
						{
							return;
						}
						int num = stream.method_6();
						num2 = stream.method_6();
						if (num == 1)
						{
							break;
						}
						stream.Seek(num2, SeekOrigin.Current);
					}
					if (num2 >= 24)
					{
						long fileTime = stream.method_8();
						dateTime_1 = DateTime.FromFileTime(fileTime);
						long fileTime2 = stream.method_8();
						dateTime_0 = DateTime.FromFileTime(fileTime2);
						long fileTime3 = stream.method_8();
						dateTime_2 = DateTime.FromFileTime(fileTime3);
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
					stream.method_11(0);
					stream.method_9(1);
					stream.method_9(24);
					stream.method_13(dateTime_1.ToFileTime());
					stream.method_13(dateTime_0.ToFileTime());
					stream.method_13(dateTime_2.ToFileTime());
					return memoryStream.ToArray();
				}
			}
		}

		public static bool smethod_0(DateTime dateTime_3)
		{
			bool result = true;
			try
			{
				dateTime_3.ToFileTimeUtc();
				return result;
			}
			catch
			{
				return false;
			}
		}

		public DateTime method_0()
		{
			return dateTime_1;
		}

		public void method_1(DateTime dateTime_3)
		{
			int num = 1;
			if (!smethod_0(dateTime_3))
			{
				throw new ArgumentOutOfRangeException("value");
			}
			dateTime_1 = dateTime_3;
		}

		public DateTime method_2()
		{
			return dateTime_2;
		}

		public void method_3(DateTime dateTime_3)
		{
			int num = 14;
			if (!smethod_0(dateTime_3))
			{
				throw new ArgumentOutOfRangeException("value");
			}
			dateTime_2 = dateTime_3;
		}

		public DateTime method_4()
		{
			return dateTime_0;
		}

		public void method_5(DateTime dateTime_3)
		{
			int num = 12;
			if (!smethod_0(dateTime_3))
			{
				throw new ArgumentOutOfRangeException("value");
			}
			dateTime_0 = dateTime_3;
		}
	}
}
