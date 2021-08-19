using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	[ComVisible(false)]
	public class GAttribute4 : Attribute
	{
		private byte byte_0 = 0;

		private bool bool_0 = false;

		private bool bool_1 = true;

		public GAttribute4(byte byte_1)
		{
			byte_0 = byte_1;
		}

		public byte method_0()
		{
			return byte_0;
		}

		public void method_1(byte byte_1)
		{
			byte_0 = byte_1;
		}

		public bool method_2()
		{
			return bool_0;
		}

		public void method_3(bool bool_2)
		{
			bool_0 = bool_2;
		}

		public bool method_4()
		{
			return bool_1;
		}

		public void method_5(bool bool_2)
		{
			bool_1 = bool_2;
		}
	}
}
