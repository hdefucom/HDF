using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GStream5 : Stream
	{
		private string string_0;

		private ICryptoTransform icryptoTransform_0;

		protected byte[] byte_0;

		private byte[] byte_1;

		protected GClass586 gclass586_0;

		protected Stream stream_0;

		private bool bool_0;

		private bool bool_1;

		private static RNGCryptoServiceProvider rngcryptoServiceProvider_0;

		public override bool CanRead => false;

		public override bool CanSeek => false;

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
				throw new NotSupportedException("Position property not supported");
			}
		}

		public GStream5(Stream stream_1)
			: this(stream_1, new GClass586(), 512)
		{
		}

		public GStream5(Stream stream_1, GClass586 gclass586_1)
			: this(stream_1, gclass586_1, 512)
		{
		}

		public GStream5(Stream stream_1, GClass586 gclass586_1, int int_0)
		{
			int num = 17;
			bool_1 = true;
			
			if (stream_1 == null)
			{
				throw new ArgumentNullException("baseOutputStream");
			}
			if (!stream_1.CanWrite)
			{
				throw new ArgumentException("Must support writing", "baseOutputStream");
			}
			if (gclass586_1 == null)
			{
				throw new ArgumentNullException("deflater");
			}
			if (int_0 < 512)
			{
				throw new ArgumentOutOfRangeException("bufferSize");
			}
			stream_0 = stream_1;
			byte_1 = new byte[int_0];
			gclass586_0 = gclass586_1;
		}

		public virtual void vmethod_0()
		{
			int num = 4;
			gclass586_0.method_5();
			while (!gclass586_0.method_6())
			{
				int num2 = gclass586_0.method_14(byte_1, 0, byte_1.Length);
				if (num2 <= 0)
				{
					break;
				}
				if (icryptoTransform_0 != null)
				{
					method_5(byte_1, 0, num2);
				}
				stream_0.Write(byte_1, 0, num2);
			}
			if (!gclass586_0.method_6())
			{
				throw new GException19("Can't deflate all input?");
			}
			stream_0.Flush();
			if (icryptoTransform_0 != null)
			{
				if (icryptoTransform_0 is Class225)
				{
					byte_0 = ((Class225)icryptoTransform_0).method_1();
				}
				icryptoTransform_0.Dispose();
				icryptoTransform_0 = null;
			}
		}

		public bool method_0()
		{
			return bool_1;
		}

		public void method_1(bool bool_2)
		{
			bool_1 = bool_2;
		}

		public bool method_2()
		{
			return stream_0.CanSeek;
		}

		public string method_3()
		{
			return string_0;
		}

		public void method_4(string string_1)
		{
			if (string_1 != null && string_1.Length == 0)
			{
				string_0 = null;
			}
			else
			{
				string_0 = string_1;
			}
		}

		protected void method_5(byte[] byte_2, int int_0, int int_1)
		{
			icryptoTransform_0.TransformBlock(byte_2, 0, int_1, byte_2, 0);
		}

		protected void method_6(string string_1)
		{
			GClass565 gClass = new GClass565();
			byte[] rgbKey = GClass564.smethod_0(GClass547.smethod_6(string_1));
			icryptoTransform_0 = gClass.CreateEncryptor(rgbKey, null);
		}

		protected void method_7(GClass577 gclass577_0, string string_1, out byte[] byte_2, out byte[] byte_3)
		{
			byte_2 = new byte[gclass577_0.method_44()];
			if (rngcryptoServiceProvider_0 == null)
			{
				rngcryptoServiceProvider_0 = new RNGCryptoServiceProvider();
			}
			rngcryptoServiceProvider_0.GetBytes(byte_2);
			int int_ = gclass577_0.method_41() / 8;
			icryptoTransform_0 = new Class225(string_1, byte_2, int_, bool_2: true);
			byte_3 = ((Class225)icryptoTransform_0).method_0();
		}

		protected void method_8()
		{
			int num = 16;
			while (!gclass586_0.method_7())
			{
				int num2 = gclass586_0.method_14(byte_1, 0, byte_1.Length);
				if (num2 <= 0)
				{
					break;
				}
				if (icryptoTransform_0 != null)
				{
					method_5(byte_1, 0, num2);
				}
				stream_0.Write(byte_1, 0, num2);
			}
			if (!gclass586_0.method_7())
			{
				throw new GException19("DeflaterOutputStream can't deflate all input?");
			}
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotSupportedException("DeflaterOutputStream Seek not supported");
		}

		public override void SetLength(long value)
		{
			throw new NotSupportedException("DeflaterOutputStream SetLength not supported");
		}

		public override int ReadByte()
		{
			throw new NotSupportedException("DeflaterOutputStream ReadByte not supported");
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			throw new NotSupportedException("DeflaterOutputStream Read not supported");
		}

		public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
		{
			throw new NotSupportedException("DeflaterOutputStream BeginRead not currently supported");
		}

		public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
		{
			throw new NotSupportedException("BeginWrite is not supported");
		}

		public override void Flush()
		{
			gclass586_0.method_4();
			method_8();
			stream_0.Flush();
		}

		public override void Close()
		{
			if (!bool_0)
			{
				bool_0 = true;
				try
				{
					vmethod_0();
					if (icryptoTransform_0 != null)
					{
						method_9();
						icryptoTransform_0.Dispose();
						icryptoTransform_0 = null;
					}
				}
				finally
				{
					if (bool_1)
					{
						stream_0.Close();
					}
				}
			}
		}

		private void method_9()
		{
			if (icryptoTransform_0 is Class225)
			{
				byte_0 = ((Class225)icryptoTransform_0).method_1();
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
			gclass586_0.method_9(buffer, offset, count);
			method_8();
		}
	}
}
