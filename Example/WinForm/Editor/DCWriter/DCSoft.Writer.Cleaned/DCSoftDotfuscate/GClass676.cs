using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass676
	{
		internal sealed class Class269
		{
			private int int_0;

			private Class270[] class270_0;

			internal int method_0()
			{
				return int_0;
			}

			internal Class269(int int_1, Class270 class270_1)
			{
				int_0 = int_1;
				class270_0 = new Class270[1]
				{
					class270_1
				};
			}

			internal Class269(int int_1, Class270 class270_1, Class270 class270_2)
			{
				int_0 = int_1;
				class270_0 = new Class270[2]
				{
					class270_1,
					class270_2
				};
			}

			internal Class270[] method_1()
			{
				return class270_0;
			}
		}

		internal sealed class Class270
		{
			private int int_0;

			private int int_1;

			internal int method_0()
			{
				return int_0;
			}

			internal int method_1()
			{
				return int_1;
			}

			internal Class270(int int_2, int int_3)
			{
				int_0 = int_2;
				int_1 = int_3;
			}
		}

		private static readonly GClass676[] gclass676_0 = smethod_1();

		private int int_0;

		private int int_1;

		private int int_2;

		private int int_3;

		private int int_4;

		private Class269 class269_0;

		private int int_5;

		public int method_0()
		{
			return int_0;
		}

		public int method_1()
		{
			return int_1;
		}

		public int method_2()
		{
			return int_2;
		}

		public int method_3()
		{
			return int_3;
		}

		public int method_4()
		{
			return int_4;
		}

		public int method_5()
		{
			return int_5;
		}

		private GClass676(int int_6, int int_7, int int_8, int int_9, int int_10, Class269 class269_1)
		{
			int_0 = int_6;
			int_1 = int_7;
			int_2 = int_8;
			int_3 = int_9;
			int_4 = int_10;
			class269_0 = class269_1;
			int num = 0;
			int num2 = class269_1.method_0();
			Class270[] array = class269_1.method_1();
			foreach (Class270 @class in array)
			{
				num += @class.method_0() * (@class.method_1() + num2);
			}
			int_5 = num;
		}

		internal Class269 method_6()
		{
			return class269_0;
		}

		public static GClass676 smethod_0(int int_6, int int_7)
		{
			if ((int_6 & 1) != 0 || (int_7 & 1) != 0)
			{
				throw GException25.smethod_0();
			}
			int num = gclass676_0.Length;
			int num2 = 0;
			GClass676 gClass;
			while (true)
			{
				if (num2 < num)
				{
					gClass = gclass676_0[num2];
					if (gClass.int_1 == int_6 && gClass.int_2 == int_7)
					{
						break;
					}
					num2++;
					continue;
				}
				throw GException25.smethod_0();
			}
			return gClass;
		}

		public override string ToString()
		{
			return Convert.ToString(int_0);
		}

		private static GClass676[] smethod_1()
		{
			return new GClass676[30]
			{
				new GClass676(1, 10, 10, 8, 8, new Class269(5, new Class270(1, 3))),
				new GClass676(2, 12, 12, 10, 10, new Class269(7, new Class270(1, 5))),
				new GClass676(3, 14, 14, 12, 12, new Class269(10, new Class270(1, 8))),
				new GClass676(4, 16, 16, 14, 14, new Class269(12, new Class270(1, 12))),
				new GClass676(5, 18, 18, 16, 16, new Class269(14, new Class270(1, 18))),
				new GClass676(6, 20, 20, 18, 18, new Class269(18, new Class270(1, 22))),
				new GClass676(7, 22, 22, 20, 20, new Class269(20, new Class270(1, 30))),
				new GClass676(8, 24, 24, 22, 22, new Class269(24, new Class270(1, 36))),
				new GClass676(9, 26, 26, 24, 24, new Class269(28, new Class270(1, 44))),
				new GClass676(10, 32, 32, 14, 14, new Class269(36, new Class270(1, 62))),
				new GClass676(11, 36, 36, 16, 16, new Class269(42, new Class270(1, 86))),
				new GClass676(12, 40, 40, 18, 18, new Class269(48, new Class270(1, 114))),
				new GClass676(13, 44, 44, 20, 20, new Class269(56, new Class270(1, 144))),
				new GClass676(14, 48, 48, 22, 22, new Class269(68, new Class270(1, 174))),
				new GClass676(15, 52, 52, 24, 24, new Class269(42, new Class270(2, 102))),
				new GClass676(16, 64, 64, 14, 14, new Class269(56, new Class270(2, 140))),
				new GClass676(17, 72, 72, 16, 16, new Class269(36, new Class270(4, 92))),
				new GClass676(18, 80, 80, 18, 18, new Class269(48, new Class270(4, 114))),
				new GClass676(19, 88, 88, 20, 20, new Class269(56, new Class270(4, 144))),
				new GClass676(20, 96, 96, 22, 22, new Class269(68, new Class270(4, 174))),
				new GClass676(21, 104, 104, 24, 24, new Class269(56, new Class270(6, 136))),
				new GClass676(22, 120, 120, 18, 18, new Class269(68, new Class270(6, 175))),
				new GClass676(23, 132, 132, 20, 20, new Class269(62, new Class270(8, 163))),
				new GClass676(24, 144, 144, 22, 22, new Class269(62, new Class270(8, 156), new Class270(2, 155))),
				new GClass676(25, 8, 18, 6, 16, new Class269(7, new Class270(1, 5))),
				new GClass676(26, 8, 32, 6, 14, new Class269(11, new Class270(1, 10))),
				new GClass676(27, 12, 26, 10, 24, new Class269(14, new Class270(1, 16))),
				new GClass676(28, 12, 36, 10, 16, new Class269(18, new Class270(1, 22))),
				new GClass676(29, 16, 36, 10, 16, new Class269(24, new Class270(1, 32))),
				new GClass676(30, 16, 48, 14, 22, new Class269(28, new Class270(1, 49)))
			};
		}
	}
}
