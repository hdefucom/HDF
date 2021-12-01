using System.IO;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass507 : GClass504
	{
		private int int_2 = 0;

		public GClass507(int int_3)
		{
			int_2 = int_3;
		}

		public int method_8()
		{
			return int_2;
		}

		public void method_9(int int_3)
		{
			int_2 = int_3;
		}

		protected override void vmethod_1(StreamWriter streamWriter_0)
		{
			streamWriter_0.Write(int_2);
		}

		public override string ToString()
		{
			return "Num:" + method_8();
		}
	}
}
