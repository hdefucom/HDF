using DCSoft.Common;
using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[DCInternal]
	[ComVisible(false)]
	public class GClass367 : IDisposable
	{
		private byte[] byte_0 = new byte[100];

		private int int_0 = 100;

		private int int_1 = 0;

		public int method_0()
		{
			return int_1;
		}

		public void method_1()
		{
			byte_0 = new byte[100];
			int_0 = 100;
			int_1 = 0;
		}

		private void method_2(int int_2)
		{
			if (int_0 < int_2)
			{
				byte[] array = new byte[(int)((double)int_2 * 1.5)];
				if (int_1 > 0)
				{
					Buffer.BlockCopy(byte_0, 0, array, 0, int_1);
				}
				byte_0 = array;
				int_0 = array.Length;
			}
		}

		public void method_3(byte byte_1)
		{
			lock (this)
			{
				method_2(int_1 + 1);
				byte_0[int_1] = byte_1;
				int_1++;
			}
		}

		public void method_4(byte[] byte_1, int int_2, int int_3)
		{
			int num = 16;
			if (byte_1 == null)
			{
				throw new ArgumentNullException("bs");
			}
			if (int_2 < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex=" + int_2);
			}
			if (int_3 < 0)
			{
				throw new ArgumentOutOfRangeException("length=" + int_3);
			}
			if (int_3 != 0)
			{
				if (int_2 + int_3 > byte_1.Length)
				{
					throw new ArgumentOutOfRangeException("startIndex+length>" + byte_1.Length);
				}
				lock (this)
				{
					method_2(int_1 + int_3);
					Buffer.BlockCopy(byte_1, int_2, byte_0, int_1, int_3);
					int_1 += int_3;
				}
			}
		}

		public void method_5(byte[] byte_1)
		{
			if (byte_1 != null && byte_1.Length != 0)
			{
				method_4(byte_1, 0, byte_1.Length);
			}
		}

		public byte[] method_6()
		{
			lock (this)
			{
				byte[] array = new byte[int_1];
				Buffer.BlockCopy(byte_0, 0, array, 0, int_1);
				return array;
			}
		}

		public void Dispose()
		{
			byte_0 = null;
			int_0 = 0;
			int_1 = 0;
		}
	}
}
