using System;
using System.IO;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass563
	{
		public static void smethod_0(Stream stream_0, byte[] byte_0)
		{
			smethod_1(stream_0, byte_0, 0, byte_0.Length);
		}

		public static void smethod_1(Stream stream_0, byte[] byte_0, int int_0, int int_1)
		{
			int num = 14;
			if (stream_0 == null)
			{
				throw new ArgumentNullException("stream");
			}
			if (byte_0 == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (int_0 < 0 || int_0 > byte_0.Length)
			{
				throw new ArgumentOutOfRangeException("offset");
			}
			if (int_1 < 0 || int_0 + int_1 > byte_0.Length)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			while (true)
			{
				if (int_1 > 0)
				{
					int num2 = stream_0.Read(byte_0, int_0, int_1);
					if (num2 <= 0)
					{
						break;
					}
					int_0 += num2;
					int_1 -= num2;
					continue;
				}
				return;
			}
			throw new EndOfStreamException();
		}

		public static void smethod_2(Stream stream_0, Stream stream_1, byte[] byte_0)
		{
			int num = 14;
			if (stream_0 == null)
			{
				throw new ArgumentNullException("source");
			}
			if (stream_1 == null)
			{
				throw new ArgumentNullException("destination");
			}
			if (byte_0 == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (byte_0.Length < 128)
			{
				throw new ArgumentException("Buffer is too small", "buffer");
			}
			bool flag = true;
			while (flag)
			{
				int num2 = stream_0.Read(byte_0, 0, byte_0.Length);
				if (num2 > 0)
				{
					stream_1.Write(byte_0, 0, num2);
					continue;
				}
				stream_1.Flush();
				flag = false;
			}
		}

		public static void smethod_3(Stream stream_0, Stream stream_1, byte[] byte_0, GDelegate28 gdelegate28_0, TimeSpan timeSpan_0, object object_0, string string_0)
		{
			smethod_4(stream_0, stream_1, byte_0, gdelegate28_0, timeSpan_0, object_0, string_0, -1L);
		}

		public static void smethod_4(Stream stream_0, Stream stream_1, byte[] byte_0, GDelegate28 gdelegate28_0, TimeSpan timeSpan_0, object object_0, string string_0, long long_0)
		{
			int num = 19;
			if (stream_0 == null)
			{
				throw new ArgumentNullException("source");
			}
			if (stream_1 == null)
			{
				throw new ArgumentNullException("destination");
			}
			if (byte_0 == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (byte_0.Length < 128)
			{
				throw new ArgumentException("Buffer is too small", "buffer");
			}
			if (gdelegate28_0 == null)
			{
				throw new ArgumentNullException("progressHandler");
			}
			bool flag = true;
			DateTime now = DateTime.Now;
			long num2 = 0L;
			long long_ = 0L;
			if (long_0 >= 0L)
			{
				long_ = long_0;
			}
			else if (stream_0.CanSeek)
			{
				long_ = stream_0.Length - stream_0.Position;
			}
			GEventArgs17 e = new GEventArgs17(string_0, num2, long_);
			gdelegate28_0(object_0, e);
			bool flag2 = true;
			while (flag)
			{
				int num3 = stream_0.Read(byte_0, 0, byte_0.Length);
				if (num3 > 0)
				{
					num2 += num3;
					flag2 = false;
					stream_1.Write(byte_0, 0, num3);
				}
				else
				{
					stream_1.Flush();
					flag = false;
				}
				if (DateTime.Now - now > timeSpan_0)
				{
					flag2 = true;
					now = DateTime.Now;
					e = new GEventArgs17(string_0, num2, long_);
					gdelegate28_0(object_0, e);
					flag = e.method_0();
				}
			}
			if (!flag2)
			{
				e = new GEventArgs17(string_0, num2, long_);
				gdelegate28_0(object_0, e);
			}
		}

		private GClass563()
		{
		}
	}
}
