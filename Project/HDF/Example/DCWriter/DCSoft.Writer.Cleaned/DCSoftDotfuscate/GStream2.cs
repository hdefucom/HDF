using System;
using System.IO;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GStream2 : Stream
	{
		protected GClass587 gclass587_0;

		protected GClass555 gclass555_0;

		private Stream stream_0;

		protected long long_0;

		private bool bool_0;

		private bool bool_1;

		public override bool CanRead => stream_0.CanRead;

		public override bool CanSeek => false;

		public override bool CanWrite => false;

		public override long Length => gclass555_0.method_0();

		public override long Position
		{
			get
			{
				return stream_0.Position;
			}
			set
			{
				throw new NotSupportedException("InflaterInputStream Position not supported");
			}
		}

		public GStream2(Stream stream_1)
			: this(stream_1, new GClass587(), 4096)
		{
		}

		public GStream2(Stream stream_1, GClass587 gclass587_1)
			: this(stream_1, gclass587_1, 4096)
		{
		}

		public GStream2(Stream stream_1, GClass587 gclass587_1, int int_0)
		{
			int num = 19;
			bool_1 = true;
			
			if (stream_1 == null)
			{
				throw new ArgumentNullException("baseInputStream");
			}
			if (gclass587_1 == null)
			{
				throw new ArgumentNullException("inflater");
			}
			if (int_0 <= 0)
			{
				throw new ArgumentOutOfRangeException("bufferSize");
			}
			stream_0 = stream_1;
			gclass587_0 = gclass587_1;
			gclass555_0 = new GClass555(stream_1, int_0);
		}

		public bool method_0()
		{
			return bool_1;
		}

		public void method_1(bool bool_2)
		{
			bool_1 = bool_2;
		}

		public long method_2(long long_1)
		{
			int num = 11;
			if (long_1 <= 0L)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			if (stream_0.CanSeek)
			{
				stream_0.Seek(long_1, SeekOrigin.Current);
				return long_1;
			}
			int num2 = 2048;
			if (long_1 < 2048L)
			{
				num2 = (int)long_1;
			}
			byte[] buffer = new byte[num2];
			int num3 = 1;
			long num4 = long_1;
			while (num4 > 0L && num3 > 0)
			{
				if (num4 < num2)
				{
					num2 = (int)num4;
				}
				num3 = stream_0.Read(buffer, 0, num2);
				num4 -= num3;
			}
			return long_1 - num4;
		}

		protected void method_3()
		{
			gclass555_0.method_15(null);
		}

		public virtual int vmethod_0()
		{
			return (!gclass587_0.method_14()) ? 1 : 0;
		}

		protected void method_4()
		{
			int num = 9;
			if (gclass555_0.method_4() <= 0)
			{
				gclass555_0.method_7();
				if (gclass555_0.method_4() <= 0)
				{
					throw new GException19("Unexpected EOF");
				}
			}
			gclass555_0.method_6(gclass587_0);
		}

		public override void Flush()
		{
			stream_0.Flush();
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotSupportedException("Seek not supported");
		}

		public override void SetLength(long value)
		{
			throw new NotSupportedException("InflaterInputStream SetLength not supported");
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			throw new NotSupportedException("InflaterInputStream Write not supported");
		}

		public override void WriteByte(byte value)
		{
			throw new NotSupportedException("InflaterInputStream WriteByte not supported");
		}

		public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
		{
			throw new NotSupportedException("InflaterInputStream BeginWrite not supported");
		}

		public override void Close()
		{
			if (!bool_0)
			{
				bool_0 = true;
				if (bool_1)
				{
					stream_0.Close();
				}
			}
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			int num = 4;
			if (gclass587_0.method_13())
			{
				throw new GException19("Need a dictionary");
			}
			int num2 = count;
			while (true)
			{
				int num3 = gclass587_0.method_11(buffer, offset, num2);
				offset += num3;
				num2 -= num3;
				if (num2 == 0 || gclass587_0.method_14())
				{
					break;
				}
				if (gclass587_0.method_12())
				{
					method_4();
				}
				else if (num3 == 0)
				{
					throw new GException24("Dont know what to do");
				}
			}
			return count - num2;
		}
	}
}
