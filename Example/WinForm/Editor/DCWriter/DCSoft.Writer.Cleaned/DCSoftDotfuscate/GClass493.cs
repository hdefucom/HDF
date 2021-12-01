using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass493
	{
		private byte[] byte_0;

		public virtual void vmethod_0(GClass498 gclass498_0, int int_0)
		{
			byte_0 = gclass498_0.method_11(int_0);
		}

		public void method_0(GClass498 gclass498_0)
		{
			gclass498_0.method_13(byte_0);
		}

		public byte[] method_1()
		{
			return byte_0;
		}
	}
}
