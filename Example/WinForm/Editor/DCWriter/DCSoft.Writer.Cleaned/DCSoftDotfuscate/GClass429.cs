using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass429
	{
		private int int_0 = 0;

		private int int_1 = 0;

		public int method_0()
		{
			return int_0;
		}

		public void method_1(int int_2)
		{
			int_0 = int_2;
			int_1 = 0;
		}

		public int method_2()
		{
			return int_1;
		}

		public void method_3(int int_2)
		{
			int_1 = int_2;
		}

		public bool method_4()
		{
			int_1--;
			return int_1 < 0;
		}

		public GClass429 method_5()
		{
			return (GClass429)MemberwiseClone();
		}
	}
}
