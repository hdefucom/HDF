using System;
using System.IO;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GStream1 : Stream
	{
		private long long_0;

		private int int_0;

		private bool bool_0;

		protected long long_1;

		protected byte[] byte_0;

		protected byte[] byte_1;

		protected GClass561 gclass561_0;

		protected Stream stream_0;

		public override bool CanRead => stream_0.CanRead;

		public override bool CanSeek => stream_0.CanSeek;

		public override bool CanWrite => stream_0.CanWrite;

		public override long Length => stream_0.Length;

		public override long Position
		{
			get
			{
				return stream_0.Position;
			}
			set
			{
				stream_0.Position = value;
			}
		}

		public GStream1(Stream stream_1)
			: this(stream_1, 20)
		{
		}

		public GStream1(Stream stream_1, int int_1)
		{
			int num = 3;
			
			if (stream_1 == null)
			{
				throw new ArgumentNullException("outputStream");
			}
			stream_0 = stream_1;
			gclass561_0 = GClass561.smethod_3(stream_1, int_1);
			byte_1 = new byte[512];
			byte_0 = new byte[512];
		}

		public bool method_0()
		{
			return gclass561_0.method_10();
		}

		public void method_1(bool bool_1)
		{
			gclass561_0.method_11(bool_1);
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			return stream_0.Seek(offset, origin);
		}

		public override void SetLength(long value)
		{
			stream_0.SetLength(value);
		}

		public override int ReadByte()
		{
			return stream_0.ReadByte();
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return stream_0.Read(buffer, offset, count);
		}

		public override void Flush()
		{
			stream_0.Flush();
		}

		public void method_2()
		{
			if (method_5())
			{
				method_7();
			}
			method_8();
		}

		public override void Close()
		{
			if (!bool_0)
			{
				bool_0 = true;
				method_2();
				gclass561_0.method_19();
			}
		}

		public int method_3()
		{
			return gclass561_0.method_0();
		}

		[Obsolete("Use RecordSize property instead")]
		public int method_4()
		{
			return gclass561_0.method_0();
		}

		private bool method_5()
		{
			return long_0 < long_1;
		}

		public void method_6(GClass558 gclass558_0)
		{
			int num = 1;
			if (gclass558_0 == null)
			{
				throw new ArgumentNullException("entry");
			}
			if (gclass558_0.method_1().Name.Length >= 100)
			{
				GClass560 gClass = new GClass560();
				gClass.method_14(76);
				gClass.Name += "././@LongLink";
				gClass.method_4(0);
				gClass.method_6(0);
				gClass.method_24("");
				gClass.method_22("");
				gClass.method_16("");
				gClass.method_8(gclass558_0.method_1().Name.Length);
				gClass.method_30(byte_0);
				gclass561_0.method_15(byte_0);
				int num2 = 0;
				while (num2 < gclass558_0.method_1().Name.Length)
				{
					Array.Clear(byte_0, 0, byte_0.Length);
					GClass560.smethod_8(gclass558_0.method_1().Name, num2, byte_0, 0, 512);
					num2 += 512;
					gclass561_0.method_15(byte_0);
				}
			}
			gclass558_0.method_20(byte_0);
			gclass561_0.method_15(byte_0);
			long_0 = 0L;
			long_1 = (gclass558_0.method_17() ? 0L : gclass558_0.method_15());
		}

		public void method_7()
		{
			int num = 18;
			if (int_0 > 0)
			{
				Array.Clear(byte_1, int_0, byte_1.Length - int_0);
				gclass561_0.method_15(byte_1);
				long_0 += int_0;
				int_0 = 0;
			}
			if (long_0 < long_1)
			{
				string string_ = $"Entry closed at '{long_0}' before the '{long_1}' bytes specified in the header were written";
				throw new GException20(string_);
			}
		}

		public override void WriteByte(byte value)
		{
			Write(new byte[1]
			{
				value
			}, 0, 1);
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			int num = 3;
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (offset < 0)
			{
				throw new ArgumentOutOfRangeException("offset", "Cannot be negative");
			}
			if (buffer.Length - offset < count)
			{
				throw new ArgumentException("offset and count combination is invalid");
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count", "Cannot be negative");
			}
			if (long_0 + count > long_1)
			{
				string message = $"request to write '{count}' bytes exceeds size in header of '{long_1}' bytes";
				throw new ArgumentOutOfRangeException("count", message);
			}
			if (int_0 > 0)
			{
				if (int_0 + count >= byte_0.Length)
				{
					int num2 = byte_0.Length - int_0;
					Array.Copy(byte_1, 0, byte_0, 0, int_0);
					Array.Copy(buffer, offset, byte_0, int_0, num2);
					gclass561_0.method_15(byte_0);
					long_0 += byte_0.Length;
					offset += num2;
					count -= num2;
					int_0 = 0;
				}
				else
				{
					Array.Copy(buffer, offset, byte_1, int_0, count);
					offset += count;
					int_0 += count;
					count -= count;
				}
			}
			while (true)
			{
				if (count > 0)
				{
					if (count < byte_0.Length)
					{
						break;
					}
					gclass561_0.method_16(buffer, offset);
					int num3 = byte_0.Length;
					long_0 += num3;
					count -= num3;
					offset += num3;
					continue;
				}
				return;
			}
			Array.Copy(buffer, offset, byte_1, int_0, count);
			int_0 += count;
		}

		private void method_8()
		{
			Array.Clear(byte_0, 0, byte_0.Length);
			gclass561_0.method_15(byte_0);
		}
	}
}
