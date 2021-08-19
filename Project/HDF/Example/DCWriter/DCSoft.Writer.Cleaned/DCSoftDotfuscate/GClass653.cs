using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass653
	{
		public static readonly GClass653 gclass653_0;

		public static readonly GClass653 gclass653_1;

		public static readonly GClass653 gclass653_2;

		public static readonly GClass653 gclass653_3;

		public static readonly GClass653 gclass653_4;

		public static readonly GClass653 gclass653_5;

		public static readonly GClass653 gclass653_6;

		public static readonly GClass653 gclass653_7;

		public static readonly GClass653 gclass653_8;

		private int[] int_0;

		private int int_1;

		private string string_0;

		public string Name => string_0;

		public int method_0()
		{
			return int_1;
		}

		private GClass653(int[] int_2, int int_3, string string_1)
		{
			int_0 = int_2;
			int_1 = int_3;
			string_0 = string_1;
		}

		public static GClass653 smethod_0(int int_2)
		{
			switch (int_2)
			{
			case 0:
				return gclass653_0;
			case 1:
				return gclass653_1;
			case 2:
				return gclass653_2;
			case 3:
				return gclass653_3;
			case 4:
				return gclass653_4;
			case 5:
				return gclass653_7;
			default:
				throw new ArgumentException();
			case 7:
				return gclass653_5;
			case 8:
				return gclass653_6;
			case 9:
				return gclass653_8;
			}
		}

		public int method_1(GClass672 gclass672_0)
		{
			int num = 17;
			if (int_0 == null)
			{
				throw new ArgumentException("Character count doesn't apply to this mode");
			}
			int num2 = gclass672_0.method_0();
			int num3 = (num2 > 9) ? ((num2 <= 26) ? 1 : 2) : 0;
			return int_0[num3];
		}

		public override string ToString()
		{
			return string_0;
		}

		static GClass653()
		{
			int[] int_ = new int[3];
			gclass653_0 = new GClass653(int_, 0, "TERMINATOR");
			gclass653_1 = new GClass653(new int[3]
			{
				10,
				12,
				14
			}, 1, "NUMERIC");
			gclass653_2 = new GClass653(new int[3]
			{
				9,
				11,
				13
			}, 2, "ALPHANUMERIC");
			int_ = new int[3];
			gclass653_3 = new GClass653(int_, 3, "STRUCTURED_APPEND");
			gclass653_4 = new GClass653(new int[3]
			{
				8,
				16,
				16
			}, 4, "BYTE");
			gclass653_5 = new GClass653(null, 7, "ECI");
			gclass653_6 = new GClass653(new int[3]
			{
				8,
				10,
				12
			}, 8, "KANJI");
			gclass653_7 = new GClass653(null, 5, "FNC1_FIRST_POSITION");
			gclass653_8 = new GClass653(null, 9, "FNC1_SECOND_POSITION");
		}
	}
}
