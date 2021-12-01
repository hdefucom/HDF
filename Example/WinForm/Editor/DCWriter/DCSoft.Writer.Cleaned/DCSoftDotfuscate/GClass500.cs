using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass500 : GClass498
	{
		private byte[] byte_0;

		private int int_12;

		public GClass500(byte[] byte_1)
		{
			byte_0 = byte_1;
		}

		protected override byte vmethod_0()
		{
			return byte_0[int_12++];
		}

		protected override void vmethod_1(byte byte_1)
		{
			byte_0[int_12++] = byte_1;
		}

		protected override void vmethod_2(int int_13)
		{
			int_12 = int_13;
		}

		public override int vmethod_3()
		{
			return int_12;
		}

		public override int vmethod_4()
		{
			return byte_0.Length;
		}

		public byte[] method_28()
		{
			return byte_0;
		}
	}
}
