using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	[DebuggerNonUserCode]
	internal class Class142
	{
		private Encoding encoding_0;

		private Stream stream_0;

		public Class142(Stream stream_1)
		{
			int num = 13;
			encoding_0 = Encoding.UTF8;
			stream_0 = null;
			
			if (stream_1 == null)
			{
				throw new ArgumentNullException("stream");
			}
			stream_0 = stream_1;
		}

		public Encoding method_0()
		{
			return encoding_0;
		}

		public void method_1(Encoding encoding_1)
		{
			encoding_0 = encoding_1;
		}

		public Stream method_2()
		{
			return stream_0;
		}

		public void method_3(byte byte_0)
		{
			stream_0.WriteByte(byte_0);
		}

		public void method_4(bool bool_0)
		{
			if (bool_0)
			{
				stream_0.WriteByte(1);
			}
			else
			{
				stream_0.WriteByte(0);
			}
		}

		public void method_5(short short_0)
		{
			byte[] bytes = BitConverter.GetBytes(short_0);
			stream_0.Write(bytes, 0, bytes.Length);
		}

		public void method_6(int int_0)
		{
			byte[] bytes = BitConverter.GetBytes(int_0);
			stream_0.Write(bytes, 0, bytes.Length);
		}

		public void method_7(long long_0)
		{
			byte[] bytes = BitConverter.GetBytes(long_0);
			stream_0.Write(bytes, 0, bytes.Length);
		}

		public void method_8(float float_0)
		{
			byte[] bytes = BitConverter.GetBytes(float_0);
			stream_0.Write(bytes, 0, bytes.Length);
		}

		public void method_9(double double_0)
		{
			byte[] bytes = BitConverter.GetBytes(double_0);
			stream_0.Write(bytes, 0, bytes.Length);
		}

		public void method_10(string string_0)
		{
			if (string_0 != null && string_0.Length > 0)
			{
				byte[] bytes = encoding_0.GetBytes(string_0);
				byte[] bytes2 = BitConverter.GetBytes(bytes.Length);
				stream_0.Write(bytes2, 0, bytes2.Length);
				stream_0.Write(bytes, 0, bytes.Length);
			}
			else
			{
				byte[] bytes = BitConverter.GetBytes(0);
				stream_0.Write(bytes, 0, bytes.Length);
			}
		}

		public void method_11(byte[] byte_0)
		{
			if (byte_0 != null && byte_0.Length > 0)
			{
				byte[] bytes = BitConverter.GetBytes(byte_0.Length);
				stream_0.Write(bytes, 0, bytes.Length);
				stream_0.Write(byte_0, 0, byte_0.Length);
			}
			else
			{
				byte[] bytes = BitConverter.GetBytes(0);
				stream_0.Write(bytes, 0, bytes.Length);
			}
		}
	}
}
