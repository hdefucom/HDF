using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass549 : GInterface25
	{
		private const uint uint_0 = 65521u;

		private uint uint_1;

		public long imethod_0()
		{
			return uint_1;
		}

		public GClass549()
		{
			imethod_1();
		}

		public void imethod_1()
		{
			uint_1 = 1u;
		}

		public void imethod_2(int int_0)
		{
			uint num = uint_1 & 0xFFFF;
			uint num2 = uint_1 >> 16;
			num = (uint)((int)num + (int_0 & 0xFF)) % 65521u;
			num2 = (num + num2) % 65521u;
			uint_1 = (num2 << 16) + num;
		}

		public void imethod_3(byte[] byte_0)
		{
			int num = 10;
			if (byte_0 == null)
			{
				throw new ArgumentNullException("buffer");
			}
			imethod_4(byte_0, 0, byte_0.Length);
		}

		public void imethod_4(byte[] byte_0, int int_0, int int_1)
		{
			int num = 18;
			if (byte_0 == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (int_0 < 0)
			{
				throw new ArgumentOutOfRangeException("offset", "cannot be negative");
			}
			if (int_1 < 0)
			{
				throw new ArgumentOutOfRangeException("count", "cannot be negative");
			}
			if (int_0 >= byte_0.Length)
			{
				throw new ArgumentOutOfRangeException("offset", "not a valid index into buffer");
			}
			if (int_0 + int_1 > byte_0.Length)
			{
				throw new ArgumentOutOfRangeException("count", "exceeds buffer size");
			}
			uint num2 = uint_1 & 0xFFFF;
			uint num3 = uint_1 >> 16;
			while (int_1 > 0)
			{
				int num4 = 3800;
				if (3800 > int_1)
				{
					num4 = int_1;
				}
				int_1 -= num4;
				while (--num4 >= 0)
				{
					num2 = (uint)((int)num2 + (byte_0[int_0++] & 0xFF));
					num3 += num2;
				}
				num2 %= 65521u;
				num3 %= 65521u;
			}
			uint_1 = ((num3 << 16) | num2);
		}
	}
}
