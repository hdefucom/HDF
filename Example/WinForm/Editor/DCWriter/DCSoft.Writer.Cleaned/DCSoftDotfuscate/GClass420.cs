using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass420
	{
		private int int_0 = 0;

		private int int_1 = 0;

		private int int_2 = 1;

		public int method_0()
		{
			return int_0;
		}

		public void method_1(int int_3)
		{
			int_0 = int_3;
		}

		public int method_2()
		{
			return int_1;
		}

		public void method_3(int int_3)
		{
			int_1 = int_3;
		}

		public int method_4()
		{
			return int_2;
		}

		public void method_5(int int_3)
		{
			int_2 = int_3;
		}

		public override string ToString()
		{
			return "ID:" + method_4() + " ListID:" + method_0() + " Count:" + method_2();
		}
	}
}
