using System.IO;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass516 : GClass504
	{
		private int int_2 = 0;

		private int int_3 = 0;

		private int int_4 = 0;

		private int int_5 = 0;

		public GClass516()
		{
		}

		public GClass516(int int_6, int int_7, int int_8, int int_9)
		{
			int_2 = int_6;
			int_3 = int_7;
			int_4 = int_8;
			int_5 = int_9;
		}

		public int method_8()
		{
			return int_2;
		}

		public void method_9(int int_6)
		{
			if (int_6 >= 0)
			{
				int_2 = int_6;
			}
		}

		public int method_10()
		{
			return int_3;
		}

		public void method_11(int int_6)
		{
			if (int_6 >= 0)
			{
				int_3 = int_6;
			}
		}

		public int method_12()
		{
			return int_4;
		}

		public void method_13(int int_6)
		{
			if (int_6 >= 0)
			{
				int_4 = int_6;
			}
		}

		public int method_14()
		{
			return int_5;
		}

		public void method_15(int int_6)
		{
			if (int_6 >= 0)
			{
				int_5 = int_6;
			}
		}

		public GClass513 method_16()
		{
			GClass513 gClass = new GClass513();
			gClass.method_9(new GClass507(int_2));
			gClass.method_9(new GClass507(int_3));
			gClass.method_9(new GClass507(int_4));
			gClass.method_9(new GClass507(int_5));
			return gClass;
		}

		protected override void vmethod_1(StreamWriter streamWriter_0)
		{
			method_16().vmethod_0(streamWriter_0);
		}
	}
}
