using System;
using System.IO;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass585 : IDisposable
	{
		private int int_0;

		private int int_1;

		private int int_2;

		private MemoryStream memoryStream_0;

		private byte[] byte_0;

		public GClass585()
		{
			method_1();
		}

		public GClass585(byte[] byte_1)
		{
			if (byte_1 == null)
			{
				byte_0 = new byte[0];
			}
			else
			{
				byte_0 = byte_1;
			}
		}

		public byte[] method_0()
		{
			int num = 9;
			if (method_2() > 65535)
			{
				throw new GException24("Data exceeds maximum length");
			}
			return (byte[])byte_0.Clone();
		}

		public void method_1()
		{
			if (byte_0 == null || byte_0.Length != 0)
			{
				byte_0 = new byte[0];
			}
		}

		public int method_2()
		{
			return byte_0.Length;
		}

		public Stream method_3(int int_3)
		{
			Stream result = null;
			if (method_8(int_3))
			{
				result = new MemoryStream(byte_0, int_0, int_2, writable: false);
			}
			return result;
		}

		private GInterface31 method_4(short short_0)
		{
			GInterface31 result = null;
			if (method_8(short_0))
			{
				result = smethod_0(short_0, byte_0, int_1, int_2);
			}
			return result;
		}

		private static GInterface31 smethod_0(short short_0, byte[] byte_1, int int_3, int int_4)
		{
			GInterface31 gInterface = null;
			switch (short_0)
			{
			default:
				gInterface = new GClass582(short_0);
				break;
			case 21589:
				gInterface = new GClass583();
				break;
			case 10:
				gInterface = new GClass584();
				break;
			}
			gInterface.imethod_1(byte_1, int_3, int_4);
			return gInterface;
		}

		public int method_5()
		{
			return int_2;
		}

		public int method_6()
		{
			return int_0;
		}

		public int method_7()
		{
			int num = 15;
			if (int_1 > byte_0.Length || int_1 < 4)
			{
				throw new GException24("Find must be called before calling a Read method");
			}
			return int_1 + int_2 - int_0;
		}

		public bool method_8(int int_3)
		{
			int_1 = byte_0.Length;
			int_2 = 0;
			int_0 = 0;
			int num = int_1;
			int num2 = int_3 - 1;
			while (num2 != int_3 && int_0 < byte_0.Length - 3)
			{
				num2 = method_25();
				num = method_25();
				if (num2 != int_3)
				{
					int_0 += num;
				}
			}
			bool result;
			if (result = (num2 == int_3 && int_0 + num <= byte_0.Length))
			{
				int_1 = int_0;
				int_2 = num;
			}
			return result;
		}

		public void method_9(GInterface31 ginterface31_0)
		{
			int num = 17;
			if (ginterface31_0 == null)
			{
				throw new ArgumentNullException("taggedData");
			}
			method_10(ginterface31_0.imethod_0(), ginterface31_0.imethod_2());
		}

		public void method_10(int int_3, byte[] byte_1)
		{
			int num = 13;
			if (int_3 > 65535 || int_3 < 0)
			{
				throw new ArgumentOutOfRangeException("headerID");
			}
			int num2 = (byte_1 != null) ? byte_1.Length : 0;
			if (num2 > 65535)
			{
				throw new ArgumentOutOfRangeException("fieldData", "exceeds maximum length");
			}
			int num3 = byte_0.Length + num2 + 4;
			if (method_8(int_3))
			{
				num3 -= method_5() + 4;
			}
			if (num3 > 65535)
			{
				throw new GException24("Data exceeds maximum length");
			}
			method_18(int_3);
			byte[] array = new byte[num3];
			byte_0.CopyTo(array, 0);
			int int_4 = byte_0.Length;
			byte_0 = array;
			method_26(ref int_4, int_3);
			method_26(ref int_4, num2);
			byte_1?.CopyTo(array, int_4);
		}

		public void method_11()
		{
			memoryStream_0 = new MemoryStream();
		}

		public void method_12(int int_3)
		{
			byte[] byte_ = memoryStream_0.ToArray();
			memoryStream_0 = null;
			method_10(int_3, byte_);
		}

		public void method_13(byte byte_1)
		{
			memoryStream_0.WriteByte(byte_1);
		}

		public void method_14(byte[] byte_1)
		{
			int num = 2;
			if (byte_1 == null)
			{
				throw new ArgumentNullException("data");
			}
			memoryStream_0.Write(byte_1, 0, byte_1.Length);
		}

		public void method_15(int int_3)
		{
			memoryStream_0.WriteByte((byte)int_3);
			memoryStream_0.WriteByte((byte)(int_3 >> 8));
		}

		public void method_16(int int_3)
		{
			method_15((short)int_3);
			method_15((short)(int_3 >> 16));
		}

		public void method_17(long long_0)
		{
			method_16((int)(long_0 & 0xFFFFFFFF));
			method_16((int)(long_0 >> 32));
		}

		public bool method_18(int int_3)
		{
			bool result = false;
			if (method_8(int_3))
			{
				result = true;
				int num = int_1 - 4;
				byte[] destinationArray = new byte[byte_0.Length - (method_5() + 4)];
				Array.Copy(byte_0, 0, destinationArray, 0, num);
				int num2 = num + method_5() + 4;
				Array.Copy(byte_0, num2, destinationArray, num, byte_0.Length - num2);
				byte_0 = destinationArray;
			}
			return result;
		}

		public long method_19()
		{
			method_24(8);
			return (method_20() & 0xFFFFFFFF) | ((long)method_20() << 32);
		}

		public int method_20()
		{
			method_24(4);
			int result = byte_0[int_0] + (byte_0[int_0 + 1] << 8) + (byte_0[int_0 + 2] << 16) + (byte_0[int_0 + 3] << 24);
			int_0 += 4;
			return result;
		}

		public int method_21()
		{
			method_24(2);
			int result = byte_0[int_0] + (byte_0[int_0 + 1] << 8);
			int_0 += 2;
			return result;
		}

		public int method_22()
		{
			int result = -1;
			if (int_0 < byte_0.Length && int_1 + int_2 > int_0)
			{
				result = byte_0[int_0];
				int_0++;
			}
			return result;
		}

		public void method_23(int int_3)
		{
			method_24(int_3);
			int_0 += int_3;
		}

		private void method_24(int int_3)
		{
			int num = 8;
			if (int_1 > byte_0.Length || int_1 < 4)
			{
				throw new GException24("Find must be called before calling a Read method");
			}
			if (int_0 > int_1 + int_2 - int_3)
			{
				throw new GException24("End of extra data");
			}
			if (int_0 + int_3 < 4)
			{
				throw new GException24("Cannot read before start of tag");
			}
		}

		private int method_25()
		{
			int num = 3;
			if (int_0 > byte_0.Length - 2)
			{
				throw new GException24("End of extra data");
			}
			int result = byte_0[int_0] + (byte_0[int_0 + 1] << 8);
			int_0 += 2;
			return result;
		}

		private void method_26(ref int int_3, int int_4)
		{
			byte_0[int_3] = (byte)int_4;
			byte_0[int_3 + 1] = (byte)(int_4 >> 8);
			int_3 += 2;
		}

		public void Dispose()
		{
			if (memoryStream_0 != null)
			{
				memoryStream_0.Close();
			}
		}
	}
}
