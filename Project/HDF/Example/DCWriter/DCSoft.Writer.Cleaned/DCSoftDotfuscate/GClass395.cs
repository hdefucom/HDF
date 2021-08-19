using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[Serializable]
	[ComVisible(false)]
	public class GClass395 : GClass383
	{
		[NonSerialized]
		private ArrayList arrayList_0 = new ArrayList();

		private GClass425 gclass425_0 = new GClass425();

		private int int_1 = 1;

		private int int_2 = 0;

		private bool bool_1 = false;

		private bool bool_2 = false;

		private int int_3 = 0;

		private int int_4 = int.MinValue;

		private int int_5 = int.MinValue;

		private int int_6 = int.MinValue;

		private int int_7 = int.MinValue;

		private int int_8 = 0;

		internal ArrayList method_17()
		{
			return arrayList_0;
		}

		internal void method_18(ArrayList arrayList_1)
		{
			arrayList_0 = arrayList_1;
		}

		public GClass425 method_19()
		{
			return gclass425_0;
		}

		public void method_20(GClass425 gclass425_1)
		{
			gclass425_0 = gclass425_1;
		}

		public int method_21()
		{
			return int_1;
		}

		public void method_22(int int_9)
		{
			int_1 = int_9;
		}

		internal int method_23()
		{
			return int_2;
		}

		internal void method_24(int int_9)
		{
			int_2 = int_9;
		}

		public bool method_25()
		{
			return bool_1;
		}

		public void method_26(bool bool_3)
		{
			bool_1 = bool_3;
		}

		public bool method_27()
		{
			return bool_2;
		}

		public void method_28(bool bool_3)
		{
			bool_2 = bool_3;
		}

		public int method_29()
		{
			return int_3;
		}

		public void method_30(int int_9)
		{
			int_3 = int_9;
		}

		public int method_31()
		{
			return int_4;
		}

		public void method_32(int int_9)
		{
			int_4 = int_9;
		}

		public int method_33()
		{
			return int_5;
		}

		public void method_34(int int_9)
		{
			int_5 = int_9;
		}

		public int method_35()
		{
			return int_6;
		}

		public void method_36(int int_9)
		{
			int_6 = int_9;
		}

		public int method_37()
		{
			return int_7;
		}

		public void method_38(int int_9)
		{
			int_7 = int_9;
		}

		public int method_39()
		{
			return int_8;
		}

		public void method_40(int int_9)
		{
			int_8 = int_9;
		}

		public override string ToString()
		{
			return "Row " + int_2;
		}
	}
}
