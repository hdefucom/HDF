using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass582 : GInterface31
	{
		private short short_0;

		private byte[] byte_0;

		public GClass582(short short_1)
		{
			short_0 = short_1;
		}

		public short imethod_0()
		{
			return short_0;
		}

		public void method_0(short short_1)
		{
			short_0 = short_1;
		}

		public void imethod_1(byte[] byte_1, int int_0, int int_1)
		{
			int num = 14;
			if (byte_1 == null)
			{
				throw new ArgumentNullException("data");
			}
			byte_0 = new byte[int_1];
			Array.Copy(byte_1, int_0, byte_0, 0, int_1);
		}

		public byte[] imethod_2()
		{
			return byte_0;
		}

		public byte[] method_1()
		{
			return byte_0;
		}

		public void method_2(byte[] byte_1)
		{
			byte_0 = byte_1;
		}
	}
}
