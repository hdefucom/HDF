using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[Serializable]
	[ComVisible(false)]
	public class GClass390 : GClass383
	{
		private int int_1 = 1;

		private int int_2 = 1;

		private int int_3 = int.MinValue;

		private int int_4 = int.MinValue;

		private int int_5 = int.MinValue;

		private int int_6 = int.MinValue;

		private GEnum83 genum83_0 = GEnum83.const_0;

		private GClass425 gclass425_0 = new GClass425();

		private bool bool_1 = true;

		private int int_7 = 0;

		private int int_8 = 0;

		private int int_9 = 0;

		private GClass390 gclass390_0 = null;

		public GClass390()
		{
			gclass425_0.method_14(1);
		}

		public int method_17()
		{
			return int_1;
		}

		public void method_18(int int_10)
		{
			int_1 = int_10;
		}

		public int method_19()
		{
			return int_2;
		}

		public void method_20(int int_10)
		{
			int_2 = int_10;
		}

		public int method_21()
		{
			return int_3;
		}

		public void method_22(int int_10)
		{
			int_3 = int_10;
		}

		public int method_23()
		{
			if (int_3 != int.MinValue)
			{
				return int_3;
			}
			if (method_10() != null)
			{
				int num = ((GClass395)method_10()).method_31();
				if (num != int.MinValue)
				{
					return num;
				}
			}
			return 0;
		}

		public int method_24()
		{
			return int_4;
		}

		public void method_25(int int_10)
		{
			int_4 = int_10;
		}

		public int method_26()
		{
			if (int_4 != int.MinValue)
			{
				return int_4;
			}
			if (method_10() != null)
			{
				int num = ((GClass395)method_10()).method_33();
				if (num != int.MinValue)
				{
					return num;
				}
			}
			return 0;
		}

		public int method_27()
		{
			return int_5;
		}

		public void method_28(int int_10)
		{
			int_5 = int_10;
		}

		public int method_29()
		{
			if (int_5 != int.MinValue)
			{
				return int_5;
			}
			if (method_10() != null)
			{
				int num = ((GClass395)method_10()).method_35();
				if (num != int.MinValue)
				{
					return num;
				}
			}
			return 0;
		}

		public int method_30()
		{
			return int_6;
		}

		public void method_31(int int_10)
		{
			int_6 = int_10;
		}

		public int method_32()
		{
			if (int_6 != int.MinValue)
			{
				return int_6;
			}
			if (method_10() != null)
			{
				int num = ((GClass395)method_10()).method_37();
				if (num != int.MinValue)
				{
					return num;
				}
			}
			return 0;
		}

		public GEnum83 method_33()
		{
			return genum83_0;
		}

		public void method_34(GEnum83 genum83_1)
		{
			genum83_0 = genum83_1;
		}

		public GClass425 method_35()
		{
			return gclass425_0;
		}

		public void method_36(GClass425 gclass425_1)
		{
			gclass425_0 = gclass425_1;
		}

		public bool method_37()
		{
			return bool_1;
		}

		public void method_38(bool bool_2)
		{
			bool_1 = bool_2;
		}

		public int method_39()
		{
			return int_7;
		}

		public void method_40(int int_10)
		{
			int_7 = int_10;
		}

		public int method_41()
		{
			return int_8;
		}

		public void method_42(int int_10)
		{
			int_8 = int_10;
		}

		public int method_43()
		{
			return int_9;
		}

		public void method_44(int int_10)
		{
			int_9 = int_10;
		}

		public GClass390 method_45()
		{
			return gclass390_0;
		}

		public void method_46(GClass390 gclass390_1)
		{
			gclass390_0 = gclass390_1;
		}

		public override string ToString()
		{
			int num = 12;
			if (gclass390_0 == null)
			{
				if (int_1 != 1 || int_2 != 1)
				{
					return "Cell: RowSpan:" + int_1 + " ColSpan:" + int_2 + " Width:" + method_41();
				}
				return "Cell:Width:" + method_41();
			}
			return "Cell:Overrided";
		}
	}
}
