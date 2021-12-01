using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass141
	{
		private Stream stream_0;

		public GClass141(Stream stream_1)
		{
			int num = 6;
			stream_0 = null;
			
			if (stream_1 == null)
			{
				throw new ArgumentNullException("stream");
			}
			stream_0 = stream_1;
		}

		public void method_0(bool bool_0)
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

		public void method_1(string string_0)
		{
			if (string.IsNullOrEmpty(string_0))
			{
				stream_0.WriteByte(0);
				return;
			}
			byte[] bytes = Encoding.UTF8.GetBytes(string_0);
			stream_0.WriteByte((byte)bytes.Length);
			stream_0.Write(bytes, 0, bytes.Length);
		}

		public void method_2(string string_0)
		{
			if (string.IsNullOrEmpty(string_0))
			{
				stream_0.WriteByte(0);
				stream_0.WriteByte(0);
				return;
			}
			byte[] bytes = Encoding.UTF8.GetBytes(string_0);
			byte[] bytes2 = BitConverter.GetBytes((short)bytes.Length);
			stream_0.Write(bytes2, 0, bytes2.Length);
			stream_0.Write(bytes, 0, bytes.Length);
		}

		public void method_3(byte byte_0)
		{
			stream_0.WriteByte(byte_0);
		}

		public void method_4(short short_0)
		{
			byte[] bytes = BitConverter.GetBytes(short_0);
			stream_0.Write(bytes, 0, bytes.Length);
		}

		public void method_5(int int_0)
		{
			byte[] bytes = BitConverter.GetBytes(int_0);
			stream_0.Write(bytes, 0, bytes.Length);
		}

		public void method_6(long long_0)
		{
			byte[] bytes = BitConverter.GetBytes(long_0);
			stream_0.Write(bytes, 0, bytes.Length);
		}

		public void method_7(float float_0)
		{
			byte[] bytes = BitConverter.GetBytes(float_0);
			stream_0.Write(bytes, 0, bytes.Length);
		}

		public void method_8(double double_0)
		{
			byte[] bytes = BitConverter.GetBytes(double_0);
			stream_0.Write(bytes, 0, bytes.Length);
		}

		public void method_9(DateTime dateTime_0)
		{
			byte[] bytes = BitConverter.GetBytes(dateTime_0.Ticks);
			stream_0.Write(bytes, 0, bytes.Length);
		}

		public void method_10(byte[] byte_0, int int_0, int int_1)
		{
			int num = 12;
			if (byte_0 == null || byte_0.Length < int_0 + int_1)
			{
				throw new ArgumentNullException("bs");
			}
			stream_0.Write(byte_0, int_0, int_1);
		}

		public void method_11(byte[] byte_0)
		{
			if (byte_0 != null && byte_0.Length > 0)
			{
				stream_0.Write(byte_0, 0, byte_0.Length);
			}
		}

		public void method_12(byte[] byte_0, int int_0)
		{
			if (int_0 <= 254)
			{
				if (byte_0 == null || byte_0.Length == 0)
				{
					stream_0.WriteByte(0);
					return;
				}
				stream_0.WriteByte((byte)byte_0.Length);
				stream_0.Write(byte_0, 0, byte_0.Length);
			}
			else if (int_0 <= 2147483646)
			{
				if (byte_0 == null || byte_0.Length == 0)
				{
					stream_0.WriteByte(0);
					stream_0.WriteByte(0);
				}
				else
				{
					method_4((short)byte_0.Length);
					stream_0.Write(byte_0, 0, byte_0.Length);
				}
			}
			else if (byte_0 == null || byte_0.Length == 0)
			{
				method_5(0);
			}
			else
			{
				method_5(byte_0.Length);
				stream_0.Write(byte_0, 0, byte_0.Length);
			}
		}

		public void method_13(object object_0)
		{
			int num = GClass142.smethod_0(object_0.GetType());
			long num2 = Convert.ToInt64(object_0);
			switch (num)
			{
			case 1:
				stream_0.WriteByte(Convert.ToByte(num2));
				break;
			case 2:
				method_4(Convert.ToInt16(num2));
				break;
			case 4:
				method_5(Convert.ToInt32(num2));
				break;
			case 8:
				method_6(num2);
				break;
			}
		}
	}
}
