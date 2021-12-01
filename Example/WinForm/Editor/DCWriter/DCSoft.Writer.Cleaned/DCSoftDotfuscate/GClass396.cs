using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[Serializable]
	[ComVisible(false)]
	public class GClass396 : GClass383
	{
		private int int_1 = 0;

		private int int_2 = 0;

		private int int_3 = 0;

		private int int_4 = 0;

		private int int_5 = 0;

		private int int_6 = 0;

		private GClass427 gclass427_0 = new GClass427();

		public int method_17()
		{
			return int_1;
		}

		public void method_18(int int_7)
		{
			int_1 = int_7;
		}

		public int method_19()
		{
			return int_2;
		}

		public void method_20(int int_7)
		{
			int_2 = int_7;
		}

		public int method_21()
		{
			return int_3;
		}

		public void method_22(int int_7)
		{
			int_3 = int_7;
		}

		public int method_23()
		{
			return int_4;
		}

		public void method_24(int int_7)
		{
			int_4 = int_7;
		}

		public int method_25()
		{
			return int_5;
		}

		public void method_26(int int_7)
		{
			int_5 = int_7;
		}

		public int method_27()
		{
			return int_6;
		}

		public void method_28(int int_7)
		{
			int_6 = int_7;
		}

		public GClass427 method_29()
		{
			return gclass427_0;
		}

		public void method_30(GClass427 gclass427_1)
		{
			gclass427_0 = gclass427_1;
		}

		public override string ToString()
		{
			return "Shape:Left:" + int_1 + " Top:" + int_2 + " Width:" + int_3 + " Height:" + int_4;
		}
	}
}
