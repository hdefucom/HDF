using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass636
	{
		public static readonly GClass636 gclass636_0 = new GClass636(0, 1, "L");

		public static readonly GClass636 gclass636_1 = new GClass636(1, 0, "M");

		public static readonly GClass636 gclass636_2 = new GClass636(2, 3, "Q");

		public static readonly GClass636 gclass636_3 = new GClass636(3, 2, "H");

		private static readonly GClass636[] gclass636_4 = new GClass636[4]
		{
			gclass636_1,
			gclass636_0,
			gclass636_3,
			gclass636_2
		};

		private int int_0;

		private int int_1;

		private string string_0;

		public string Name => string_0;

		public int method_0()
		{
			return int_1;
		}

		private GClass636(int int_2, int int_3, string string_1)
		{
			int_0 = int_2;
			int_1 = int_3;
			string_0 = string_1;
		}

		public int method_1()
		{
			return int_0;
		}

		public override string ToString()
		{
			return string_0;
		}

		public static GClass636 smethod_0(int int_2)
		{
			if (int_2 < 0 || int_2 >= gclass636_4.Length)
			{
				throw new ArgumentException();
			}
			return gclass636_4[int_2];
		}
	}
}
