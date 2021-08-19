using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass555
	{
		private int int_0;

		private byte[] byte_0;

		private int int_1;

		private byte[] byte_1;

		private byte[] byte_2;

		private int int_2;

		private ICryptoTransform icryptoTransform_0;

		private Stream stream_0;

		public GClass555(Stream stream_1)
			: this(stream_1, 4096)
		{
		}

		public GClass555(Stream stream_1, int int_3)
		{
			stream_0 = stream_1;
			if (int_3 < 1024)
			{
				int_3 = 1024;
			}
			byte_0 = new byte[int_3];
			byte_1 = byte_0;
		}

		public int method_0()
		{
			return int_0;
		}

		public byte[] method_1()
		{
			return byte_0;
		}

		public int method_2()
		{
			return int_1;
		}

		public byte[] method_3()
		{
			return byte_1;
		}

		public int method_4()
		{
			return int_2;
		}

		public void method_5(int int_3)
		{
			int_2 = int_3;
		}

		public void method_6(GClass587 gclass587_0)
		{
			if (int_2 > 0)
			{
				gclass587_0.method_9(byte_1, int_1 - int_2, int_2);
				int_2 = 0;
			}
		}

		public void method_7()
		{
			int_0 = 0;
			int num = byte_0.Length;
			while (num > 0)
			{
				int num2 = stream_0.Read(byte_0, int_0, num);
				if (num2 <= 0)
				{
					break;
				}
				int_0 += num2;
				num -= num2;
			}
			if (icryptoTransform_0 != null)
			{
				int_1 = icryptoTransform_0.TransformBlock(byte_0, 0, int_0, byte_1, 0);
			}
			else
			{
				int_1 = int_0;
			}
			int_2 = int_1;
		}

		public int method_8(byte[] byte_3)
		{
			return method_9(byte_3, 0, byte_3.Length);
		}

		public int method_9(byte[] byte_3, int int_3, int int_4)
		{
			int num = 17;
			if (int_4 < 0)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			int num2 = int_3;
			int num3 = int_4;
			while (true)
			{
				if (num3 > 0)
				{
					if (int_2 <= 0)
					{
						method_7();
						if (int_2 <= 0)
						{
							break;
						}
					}
					int num4 = Math.Min(num3, int_2);
					Array.Copy(byte_0, int_0 - int_2, byte_3, num2, num4);
					num2 += num4;
					num3 -= num4;
					int_2 -= num4;
					continue;
				}
				return int_4;
			}
			return 0;
		}

		public int method_10(byte[] byte_3, int int_3, int int_4)
		{
			int num = 19;
			if (int_4 < 0)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			int num2 = int_3;
			int num3 = int_4;
			while (true)
			{
				if (num3 > 0)
				{
					if (int_2 <= 0)
					{
						method_7();
						if (int_2 <= 0)
						{
							break;
						}
					}
					int num4 = Math.Min(num3, int_2);
					Array.Copy(byte_1, int_1 - int_2, byte_3, num2, num4);
					num2 += num4;
					num3 -= num4;
					int_2 -= num4;
					continue;
				}
				return int_4;
			}
			return 0;
		}

		public int method_11()
		{
			int num = 4;
			if (int_2 <= 0)
			{
				method_7();
				if (int_2 <= 0)
				{
					throw new GException24("EOF in header");
				}
			}
			byte result = byte_0[int_0 - int_2];
			int_2--;
			return result;
		}

		public int method_12()
		{
			return method_11() | (method_11() << 8);
		}

		public int method_13()
		{
			return method_12() | (method_12() << 16);
		}

		public long method_14()
		{
			return (uint)method_13() | ((long)method_13() << 32);
		}

		public void method_15(ICryptoTransform icryptoTransform_1)
		{
			icryptoTransform_0 = icryptoTransform_1;
			if (icryptoTransform_0 != null)
			{
				if (byte_0 == byte_1)
				{
					if (byte_2 == null)
					{
						byte_2 = new byte[byte_0.Length];
					}
					byte_1 = byte_2;
				}
				int_1 = int_0;
				if (int_2 > 0)
				{
					icryptoTransform_0.TransformBlock(byte_0, int_0 - int_2, int_2, byte_1, int_0 - int_2);
				}
			}
			else
			{
				byte_1 = byte_0;
				int_1 = int_0;
			}
		}
	}
}
