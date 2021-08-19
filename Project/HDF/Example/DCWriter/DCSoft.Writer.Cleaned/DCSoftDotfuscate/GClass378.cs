using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass378
	{
		protected Stream stream_0 = null;

		protected Encoding encoding_0 = Encoding.UTF8;

		public GClass378()
		{
		}

		public GClass378(Stream stream_1)
		{
			stream_0 = stream_1;
		}

		public GClass378(Stream stream_1, Encoding encoding_1)
		{
			stream_0 = stream_1;
			encoding_0 = encoding_1;
		}

		public Stream method_0()
		{
			return stream_0;
		}

		public void method_1(Stream stream_1)
		{
			stream_0 = stream_1;
		}

		public Encoding method_2()
		{
			return encoding_0;
		}

		public void method_3(Encoding encoding_1)
		{
			encoding_0 = encoding_1;
		}

		protected virtual void vmethod_0(byte byte_0)
		{
			stream_0.WriteByte(byte_0);
		}

		protected virtual void vmethod_1(byte[] byte_0)
		{
			if (byte_0 != null || byte_0.Length != 0)
			{
				stream_0.Write(byte_0, 0, byte_0.Length);
			}
		}

		public void method_4(byte[] byte_0)
		{
			vmethod_1(byte_0);
		}

		public void method_5(byte[] byte_0)
		{
			int num = 16;
			if (byte_0 == null || byte_0.Length > 255)
			{
				throw new ArgumentException("最多只能填写255个字节");
			}
			vmethod_0((byte)byte_0.Length);
			vmethod_1(byte_0);
		}

		public void method_6(byte[] byte_0)
		{
			if (byte_0 == null || byte_0.Length == 0)
			{
				vmethod_1(BitConverter.GetBytes(0));
				return;
			}
			vmethod_1(BitConverter.GetBytes(byte_0.Length));
			vmethod_1(byte_0);
		}

		public void method_7(string string_0)
		{
			int num = 10;
			if (string_0 == null)
			{
				method_6(null);
				return;
			}
			int byteCount = encoding_0.GetByteCount(string_0);
			if (byteCount > 255)
			{
				throw new ArgumentException("最多只能填写255个字节");
			}
			byte[] bytes = encoding_0.GetBytes(string_0);
			method_6(bytes);
		}

		public void method_8(int[] int_0)
		{
			byte[] array = new byte[int_0.Length * 4];
			for (int i = 0; i < int_0.Length; i++)
			{
				byte[] bytes = BitConverter.GetBytes(int_0[i]);
				int num = i * 4;
				array[num] = bytes[0];
				array[num + 1] = bytes[1];
				array[num + 2] = bytes[2];
				array[num + 3] = bytes[3];
			}
			vmethod_1(array);
		}

		public void method_9(string string_0)
		{
			if (string_0 == null)
			{
				method_6(null);
			}
			else
			{
				method_6(encoding_0.GetBytes(string_0));
			}
		}

		public void method_10(byte[] byte_0)
		{
			method_6(byte_0);
		}

		public void method_11(byte byte_0)
		{
			vmethod_0(byte_0);
		}

		public void method_12(short short_0)
		{
			vmethod_1(BitConverter.GetBytes(short_0));
		}

		public void method_13(int int_0)
		{
			vmethod_1(BitConverter.GetBytes(int_0));
		}

		public void method_14(long long_0)
		{
			vmethod_1(BitConverter.GetBytes(long_0));
		}

		public void method_15(ushort ushort_0)
		{
			vmethod_1(BitConverter.GetBytes(ushort_0));
		}

		public void method_16(uint uint_0)
		{
			vmethod_1(BitConverter.GetBytes(uint_0));
		}

		public void method_17(ulong ulong_0)
		{
			vmethod_1(BitConverter.GetBytes(ulong_0));
		}

		public void method_18(float float_0)
		{
			vmethod_1(BitConverter.GetBytes(float_0));
		}

		public void method_19(double double_0)
		{
			vmethod_1(BitConverter.GetBytes(double_0));
		}

		public void method_20(bool bool_0)
		{
			vmethod_1(BitConverter.GetBytes(bool_0));
		}

		public void method_21(char char_0)
		{
			vmethod_1(BitConverter.GetBytes(char_0));
		}

		public void method_22(decimal decimal_0)
		{
			int[] bits = decimal.GetBits(decimal_0);
			method_8(bits);
		}

		public void method_23(DateTime dateTime_0)
		{
			vmethod_1(BitConverter.GetBytes(dateTime_0.Ticks));
		}

		public void method_24(Guid guid_0)
		{
			vmethod_1(guid_0.ToByteArray());
		}
	}
}
