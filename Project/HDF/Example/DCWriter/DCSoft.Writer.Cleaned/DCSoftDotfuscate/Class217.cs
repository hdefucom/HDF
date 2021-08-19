using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	internal class Class217
	{
		private uint[] uint_0;

		protected byte method_0()
		{
			uint num = (uint_0[2] & 0xFFFF) | 2;
			return (byte)(num * (num ^ 1) >> 8);
		}

		protected void method_1(byte[] byte_0)
		{
			int num = 1;
			if (byte_0 == null)
			{
				throw new ArgumentNullException("keyData");
			}
			if (byte_0.Length != 12)
			{
				throw new InvalidOperationException("Key length is not valid");
			}
			uint_0 = new uint[3];
			uint_0[0] = (uint)((byte_0[3] << 24) | (byte_0[2] << 16) | (byte_0[1] << 8) | byte_0[0]);
			uint_0[1] = (uint)((byte_0[7] << 24) | (byte_0[6] << 16) | (byte_0[5] << 8) | byte_0[4]);
			uint_0[2] = (uint)((byte_0[11] << 24) | (byte_0[10] << 16) | (byte_0[9] << 8) | byte_0[8]);
		}

		protected void method_2(byte byte_0)
		{
			uint_0[0] = GClass548.smethod_0(uint_0[0], byte_0);
			uint_0[1] = uint_0[1] + (byte)uint_0[0];
			uint_0[1] = uint_0[1] * 134775813 + 1;
			uint_0[2] = GClass548.smethod_0(uint_0[2], (byte)(uint_0[1] >> 24));
		}

		protected void method_3()
		{
			uint_0[0] = 0u;
			uint_0[1] = 0u;
			uint_0[2] = 0u;
		}
	}
}
