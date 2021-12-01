using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass554
	{
		private byte[] byte_0;

		private int int_0;

		private int int_1;

		private uint uint_0;

		private int int_2;

		public int method_0(int int_3)
		{
			if (int_2 < int_3)
			{
				if (int_0 == int_1)
				{
					return -1;
				}
				uint_0 |= (uint)(((byte_0[int_0++] & 0xFF) | ((byte_0[int_0++] & 0xFF) << 8)) << int_2);
				int_2 += 16;
			}
			return (int)(uint_0 & ((1 << int_3) - 1));
		}

		public void method_1(int int_3)
		{
			uint_0 >>= int_3;
			int_2 -= int_3;
		}

		public int method_2(int int_3)
		{
			int num = method_0(int_3);
			if (num >= 0)
			{
				method_1(int_3);
			}
			return num;
		}

		public int method_3()
		{
			return int_2;
		}

		public int method_4()
		{
			return int_1 - int_0 + (int_2 >> 3);
		}

		public void method_5()
		{
			uint_0 >>= (int_2 & 7);
			int_2 &= -8;
		}

		public bool method_6()
		{
			return int_0 == int_1;
		}

		public int method_7(byte[] byte_1, int int_3, int int_4)
		{
			int num = 17;
			if (int_4 < 0)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			if ((int_2 & 7) != 0)
			{
				throw new InvalidOperationException("Bit buffer is not byte aligned!");
			}
			int num2 = 0;
			while (int_2 > 0 && int_4 > 0)
			{
				byte_1[int_3++] = (byte)uint_0;
				uint_0 >>= 8;
				int_2 -= 8;
				int_4--;
				num2++;
			}
			if (int_4 == 0)
			{
				return num2;
			}
			int num3 = int_1 - int_0;
			if (int_4 > num3)
			{
				int_4 = num3;
			}
			Array.Copy(byte_0, int_0, byte_1, int_3, int_4);
			int_0 += int_4;
			if (((int_0 - int_1) & 1) != 0)
			{
				uint_0 = (uint)(byte_0[int_0++] & 0xFF);
				int_2 = 8;
			}
			return num2 + int_4;
		}

		public void method_8()
		{
			uint_0 = 0u;
			int_2 = 0;
			int_1 = 0;
			int_0 = 0;
		}

		public void method_9(byte[] byte_1, int int_3, int int_4)
		{
			int num = 7;
			if (byte_1 == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (int_3 < 0)
			{
				throw new ArgumentOutOfRangeException("offset", "Cannot be negative");
			}
			if (int_4 < 0)
			{
				throw new ArgumentOutOfRangeException("count", "Cannot be negative");
			}
			if (int_0 < int_1)
			{
				throw new InvalidOperationException("Old input was not completely processed");
			}
			int num2 = int_3 + int_4;
			if (int_3 > num2 || num2 > byte_1.Length)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			if ((int_4 & 1) != 0)
			{
				uint_0 |= (uint)((byte_1[int_3++] & 0xFF) << int_2);
				int_2 += 8;
			}
			byte_0 = byte_1;
			int_0 = int_3;
			int_1 = num2;
		}
	}
}
