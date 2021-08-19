using DCSoft.Common;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[DCInternal]
	[ComVisible(false)]
	public class GStream0 : Stream
	{
		private byte[] byte_0;

		private int int_0;

		private int int_1;

		public override bool CanRead => true;

		public override bool CanSeek => true;

		public override bool CanWrite => false;

		public override long Length => int_1;

		public override long Position
		{
			get
			{
				return int_0;
			}
			set
			{
				int_0 = (int)value;
			}
		}

		public GStream0(byte[] byte_1)
		{
			int num = 2;
			byte_0 = null;
			int_0 = 0;
			int_1 = 0;
			
			if (byte_1 == null)
			{
				throw new ArgumentNullException("data");
			}
			byte_0 = byte_1;
			int_1 = byte_1.Length;
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
			byte_0 = null;
			int_1 = 0;
			int_0 = 0;
		}

		public override void Close()
		{
			base.Close();
			byte_0 = null;
			int_1 = 0;
			int_0 = 0;
		}

		public override void Flush()
		{
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			int num = 4;
			if (offset < 0)
			{
				throw new ArgumentOutOfRangeException("offset=" + offset);
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count=" + count);
			}
			if (buffer.Length - offset < count)
			{
				throw new ArgumentOutOfRangeException("Length-offset>= count");
			}
			int num2 = int_1 - int_0;
			if (num2 > count)
			{
				num2 = count;
			}
			if (num2 <= 0)
			{
				return 0;
			}
			if (num2 <= 8)
			{
				int num3 = num2;
				while (--num3 >= 0)
				{
					buffer[offset + num3] = byte_0[int_0 + num3];
				}
			}
			else
			{
				Buffer.BlockCopy(byte_0, int_0, buffer, offset, num2);
			}
			int_0 += num2;
			return num2;
		}

		public override int ReadByte()
		{
			if (int_0 >= int_1)
			{
				return -1;
			}
			return byte_0[int_0++];
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			switch (origin)
			{
			default:
				throw new ArgumentException(origin.ToString());
			case SeekOrigin.Begin:
				if (offset < 0L)
				{
					throw new IOException(origin.ToString());
				}
				int_0 = (int)offset;
				break;
			case SeekOrigin.Current:
				int_0 += (int)offset;
				break;
			case SeekOrigin.End:
				int_0 = int_1 + (int)offset;
				break;
			}
			return int_0;
		}

		public override void SetLength(long value)
		{
			throw new NotImplementedException();
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			throw new NotImplementedException();
		}
	}
}
