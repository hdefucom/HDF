using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass497
	{
		private byte[] byte_0;

		private uint uint_0;

		private uint uint_1;

		private uint uint_2;

		public void method_0(GClass498 gclass498_0)
		{
			byte_0 = gclass498_0.method_11(4);
			uint_0 = gclass498_0.method_4();
			uint_1 = gclass498_0.method_4();
			uint_2 = gclass498_0.method_4();
		}

		public void method_1(GClass498 gclass498_0)
		{
			gclass498_0.method_13(byte_0);
			gclass498_0.method_19(uint_0);
			gclass498_0.method_19(uint_1);
			gclass498_0.method_19(uint_2);
		}

		public void method_2(GClass498 gclass498_0)
		{
			gclass498_0.method_26(8);
			gclass498_0.method_19(uint_1);
			gclass498_0.method_26(4);
		}

		public void method_3(GClass498 gclass498_0)
		{
			if (uint_0 == 0)
			{
				uint_0 = GClass501.smethod_0(gclass498_0, method_7(), method_8());
			}
			gclass498_0.method_26(4);
			gclass498_0.method_19(uint_0);
			gclass498_0.method_26(8);
		}

		public void method_4(GClass480 gclass480_0)
		{
			if (gclass480_0.vmethod_3().Length == 4)
			{
				byte_0 = new byte[4];
				for (int i = 0; i < 4; i++)
				{
					byte_0[i] = Convert.ToByte(gclass480_0.vmethod_3()[i]);
				}
				uint_0 = 0u;
				uint_1 = 0u;
				uint_2 = (uint)gclass480_0.vmethod_4();
			}
		}

		public void method_5(int int_0)
		{
			if (uint_1 == 0)
			{
				uint_1 = (uint)int_0;
			}
		}

		public string method_6()
		{
			if (byte_0 == null)
			{
				return null;
			}
			string text = "";
			for (int i = 0; i < byte_0.Length; i++)
			{
				text += Convert.ToChar(byte_0[i]);
			}
			return text;
		}

		public int method_7()
		{
			return Convert.ToInt32(uint_1);
		}

		public int method_8()
		{
			return Convert.ToInt32(uint_2);
		}

		public static int smethod_0()
		{
			return 16;
		}
	}
}
