using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass672
	{
		[ComVisible(false)]
		public sealed class GClass673
		{
			private int int_0;

			private GClass674[] gclass674_0;

			public int method_0()
			{
				return int_0;
			}

			public int method_1()
			{
				int num = 0;
				for (int i = 0; i < gclass674_0.Length; i++)
				{
					num += gclass674_0[i].method_0();
				}
				return num;
			}

			public int method_2()
			{
				return int_0 * method_1();
			}

			internal GClass673(int int_1, GClass674 gclass674_1)
			{
				int_0 = int_1;
				gclass674_0 = new GClass674[1]
				{
					gclass674_1
				};
			}

			internal GClass673(int int_1, GClass674 gclass674_1, GClass674 gclass674_2)
			{
				int_0 = int_1;
				gclass674_0 = new GClass674[2]
				{
					gclass674_1,
					gclass674_2
				};
			}

			public GClass674[] method_3()
			{
				return gclass674_0;
			}
		}

		[ComVisible(false)]
		public sealed class GClass674
		{
			private int int_0;

			private int int_1;

			public int method_0()
			{
				return int_0;
			}

			public int method_1()
			{
				return int_1;
			}

			internal GClass674(int int_2, int int_3)
			{
				int_0 = int_2;
				int_1 = int_3;
			}
		}

		private static readonly int[] int_0 = new int[34]
		{
			31892,
			34236,
			39577,
			42195,
			48118,
			51042,
			55367,
			58893,
			63784,
			68472,
			70749,
			76311,
			79154,
			84390,
			87683,
			92361,
			96236,
			102084,
			102881,
			110507,
			110734,
			117786,
			119615,
			126325,
			127568,
			133589,
			136944,
			141498,
			145311,
			150283,
			152622,
			158308,
			161089,
			167017
		};

		private static readonly GClass672[] gclass672_0 = smethod_3();

		private int int_1;

		private int[] int_2;

		private GClass673[] gclass673_0;

		private int int_3;

		public int method_0()
		{
			return int_1;
		}

		public int[] method_1()
		{
			return int_2;
		}

		public int method_2()
		{
			return int_3;
		}

		public int method_3()
		{
			return 17 + 4 * int_1;
		}

		private GClass672(int int_4, int[] int_5, GClass673 gclass673_1, GClass673 gclass673_2, GClass673 gclass673_3, GClass673 gclass673_4)
		{
			int_1 = int_4;
			int_2 = int_5;
			gclass673_0 = new GClass673[4]
			{
				gclass673_1,
				gclass673_2,
				gclass673_3,
				gclass673_4
			};
			int num = 0;
			int num2 = gclass673_1.method_0();
			GClass674[] array = gclass673_1.method_3();
			foreach (GClass674 gClass in array)
			{
				num += gClass.method_0() * (gClass.method_1() + num2);
			}
			int_3 = num;
		}

		public GClass673 method_4(GClass636 gclass636_0)
		{
			return gclass673_0[gclass636_0.method_1()];
		}

		public static GClass672 smethod_0(int int_4)
		{
			if (int_4 % 4 != 1)
			{
				throw GException25.smethod_0();
			}
			try
			{
				return smethod_1(int_4 - 17 >> 2);
			}
			catch (ArgumentException)
			{
				throw GException25.smethod_0();
			}
		}

		public static GClass672 smethod_1(int int_4)
		{
			if (int_4 < 1 || int_4 > 40)
			{
				throw new ArgumentException();
			}
			return gclass672_0[int_4 - 1];
		}

		internal static GClass672 smethod_2(int int_4)
		{
			int num = int.MaxValue;
			int int_5 = 0;
			int num2 = 0;
			while (true)
			{
				if (num2 < int_0.Length)
				{
					int num3 = int_0[num2];
					if (num3 == int_4)
					{
						break;
					}
					int num4 = Class228.smethod_0(int_4, num3);
					if (num4 < num)
					{
						int_5 = num2 + 7;
						num = num4;
					}
					num2++;
					continue;
				}
				if (num <= 3)
				{
					return smethod_1(int_5);
				}
				return null;
			}
			return smethod_1(num2 + 7);
		}

		internal GClass679 method_5()
		{
			int num = method_3();
			GClass679 gClass = new GClass679(num);
			gClass.method_7(0, 0, 9, 9);
			gClass.method_7(num - 8, 0, 8, 9);
			gClass.method_7(0, num - 8, 9, 8);
			int num2 = int_2.Length;
			for (int i = 0; i < num2; i++)
			{
				int int_ = int_2[i] - 2;
				for (int j = 0; j < num2; j++)
				{
					if ((i != 0 || (j != 0 && j != num2 - 1)) && (i != num2 - 1 || j != 0))
					{
						gClass.method_7(int_2[j] - 2, int_, 5, 5);
					}
				}
			}
			gClass.method_7(6, 9, 1, num - 17);
			gClass.method_7(9, 6, num - 17, 1);
			if (int_1 > 6)
			{
				gClass.method_7(num - 11, 0, 3, 6);
				gClass.method_7(0, num - 11, 6, 3);
			}
			return gClass;
		}

		public override string ToString()
		{
			return Convert.ToString(int_1);
		}

		private static GClass672[] smethod_3()
		{
			return new GClass672[40]
			{
				new GClass672(1, new int[0], new GClass673(7, new GClass674(1, 19)), new GClass673(10, new GClass674(1, 16)), new GClass673(13, new GClass674(1, 13)), new GClass673(17, new GClass674(1, 9))),
				new GClass672(2, new int[2]
				{
					6,
					18
				}, new GClass673(10, new GClass674(1, 34)), new GClass673(16, new GClass674(1, 28)), new GClass673(22, new GClass674(1, 22)), new GClass673(28, new GClass674(1, 16))),
				new GClass672(3, new int[2]
				{
					6,
					22
				}, new GClass673(15, new GClass674(1, 55)), new GClass673(26, new GClass674(1, 44)), new GClass673(18, new GClass674(2, 17)), new GClass673(22, new GClass674(2, 13))),
				new GClass672(4, new int[2]
				{
					6,
					26
				}, new GClass673(20, new GClass674(1, 80)), new GClass673(18, new GClass674(2, 32)), new GClass673(26, new GClass674(2, 24)), new GClass673(16, new GClass674(4, 9))),
				new GClass672(5, new int[2]
				{
					6,
					30
				}, new GClass673(26, new GClass674(1, 108)), new GClass673(24, new GClass674(2, 43)), new GClass673(18, new GClass674(2, 15), new GClass674(2, 16)), new GClass673(22, new GClass674(2, 11), new GClass674(2, 12))),
				new GClass672(6, new int[2]
				{
					6,
					34
				}, new GClass673(18, new GClass674(2, 68)), new GClass673(16, new GClass674(4, 27)), new GClass673(24, new GClass674(4, 19)), new GClass673(28, new GClass674(4, 15))),
				new GClass672(7, new int[3]
				{
					6,
					22,
					38
				}, new GClass673(20, new GClass674(2, 78)), new GClass673(18, new GClass674(4, 31)), new GClass673(18, new GClass674(2, 14), new GClass674(4, 15)), new GClass673(26, new GClass674(4, 13), new GClass674(1, 14))),
				new GClass672(8, new int[3]
				{
					6,
					24,
					42
				}, new GClass673(24, new GClass674(2, 97)), new GClass673(22, new GClass674(2, 38), new GClass674(2, 39)), new GClass673(22, new GClass674(4, 18), new GClass674(2, 19)), new GClass673(26, new GClass674(4, 14), new GClass674(2, 15))),
				new GClass672(9, new int[3]
				{
					6,
					26,
					46
				}, new GClass673(30, new GClass674(2, 116)), new GClass673(22, new GClass674(3, 36), new GClass674(2, 37)), new GClass673(20, new GClass674(4, 16), new GClass674(4, 17)), new GClass673(24, new GClass674(4, 12), new GClass674(4, 13))),
				new GClass672(10, new int[3]
				{
					6,
					28,
					50
				}, new GClass673(18, new GClass674(2, 68), new GClass674(2, 69)), new GClass673(26, new GClass674(4, 43), new GClass674(1, 44)), new GClass673(24, new GClass674(6, 19), new GClass674(2, 20)), new GClass673(28, new GClass674(6, 15), new GClass674(2, 16))),
				new GClass672(11, new int[3]
				{
					6,
					30,
					54
				}, new GClass673(20, new GClass674(4, 81)), new GClass673(30, new GClass674(1, 50), new GClass674(4, 51)), new GClass673(28, new GClass674(4, 22), new GClass674(4, 23)), new GClass673(24, new GClass674(3, 12), new GClass674(8, 13))),
				new GClass672(12, new int[3]
				{
					6,
					32,
					58
				}, new GClass673(24, new GClass674(2, 92), new GClass674(2, 93)), new GClass673(22, new GClass674(6, 36), new GClass674(2, 37)), new GClass673(26, new GClass674(4, 20), new GClass674(6, 21)), new GClass673(28, new GClass674(7, 14), new GClass674(4, 15))),
				new GClass672(13, new int[3]
				{
					6,
					34,
					62
				}, new GClass673(26, new GClass674(4, 107)), new GClass673(22, new GClass674(8, 37), new GClass674(1, 38)), new GClass673(24, new GClass674(8, 20), new GClass674(4, 21)), new GClass673(22, new GClass674(12, 11), new GClass674(4, 12))),
				new GClass672(14, new int[4]
				{
					6,
					26,
					46,
					66
				}, new GClass673(30, new GClass674(3, 115), new GClass674(1, 116)), new GClass673(24, new GClass674(4, 40), new GClass674(5, 41)), new GClass673(20, new GClass674(11, 16), new GClass674(5, 17)), new GClass673(24, new GClass674(11, 12), new GClass674(5, 13))),
				new GClass672(15, new int[4]
				{
					6,
					26,
					48,
					70
				}, new GClass673(22, new GClass674(5, 87), new GClass674(1, 88)), new GClass673(24, new GClass674(5, 41), new GClass674(5, 42)), new GClass673(30, new GClass674(5, 24), new GClass674(7, 25)), new GClass673(24, new GClass674(11, 12), new GClass674(7, 13))),
				new GClass672(16, new int[4]
				{
					6,
					26,
					50,
					74
				}, new GClass673(24, new GClass674(5, 98), new GClass674(1, 99)), new GClass673(28, new GClass674(7, 45), new GClass674(3, 46)), new GClass673(24, new GClass674(15, 19), new GClass674(2, 20)), new GClass673(30, new GClass674(3, 15), new GClass674(13, 16))),
				new GClass672(17, new int[4]
				{
					6,
					30,
					54,
					78
				}, new GClass673(28, new GClass674(1, 107), new GClass674(5, 108)), new GClass673(28, new GClass674(10, 46), new GClass674(1, 47)), new GClass673(28, new GClass674(1, 22), new GClass674(15, 23)), new GClass673(28, new GClass674(2, 14), new GClass674(17, 15))),
				new GClass672(18, new int[4]
				{
					6,
					30,
					56,
					82
				}, new GClass673(30, new GClass674(5, 120), new GClass674(1, 121)), new GClass673(26, new GClass674(9, 43), new GClass674(4, 44)), new GClass673(28, new GClass674(17, 22), new GClass674(1, 23)), new GClass673(28, new GClass674(2, 14), new GClass674(19, 15))),
				new GClass672(19, new int[4]
				{
					6,
					30,
					58,
					86
				}, new GClass673(28, new GClass674(3, 113), new GClass674(4, 114)), new GClass673(26, new GClass674(3, 44), new GClass674(11, 45)), new GClass673(26, new GClass674(17, 21), new GClass674(4, 22)), new GClass673(26, new GClass674(9, 13), new GClass674(16, 14))),
				new GClass672(20, new int[4]
				{
					6,
					34,
					62,
					90
				}, new GClass673(28, new GClass674(3, 107), new GClass674(5, 108)), new GClass673(26, new GClass674(3, 41), new GClass674(13, 42)), new GClass673(30, new GClass674(15, 24), new GClass674(5, 25)), new GClass673(28, new GClass674(15, 15), new GClass674(10, 16))),
				new GClass672(21, new int[5]
				{
					6,
					28,
					50,
					72,
					94
				}, new GClass673(28, new GClass674(4, 116), new GClass674(4, 117)), new GClass673(26, new GClass674(17, 42)), new GClass673(28, new GClass674(17, 22), new GClass674(6, 23)), new GClass673(30, new GClass674(19, 16), new GClass674(6, 17))),
				new GClass672(22, new int[5]
				{
					6,
					26,
					50,
					74,
					98
				}, new GClass673(28, new GClass674(2, 111), new GClass674(7, 112)), new GClass673(28, new GClass674(17, 46)), new GClass673(30, new GClass674(7, 24), new GClass674(16, 25)), new GClass673(24, new GClass674(34, 13))),
				new GClass672(23, new int[5]
				{
					6,
					30,
					54,
					74,
					102
				}, new GClass673(30, new GClass674(4, 121), new GClass674(5, 122)), new GClass673(28, new GClass674(4, 47), new GClass674(14, 48)), new GClass673(30, new GClass674(11, 24), new GClass674(14, 25)), new GClass673(30, new GClass674(16, 15), new GClass674(14, 16))),
				new GClass672(24, new int[5]
				{
					6,
					28,
					54,
					80,
					106
				}, new GClass673(30, new GClass674(6, 117), new GClass674(4, 118)), new GClass673(28, new GClass674(6, 45), new GClass674(14, 46)), new GClass673(30, new GClass674(11, 24), new GClass674(16, 25)), new GClass673(30, new GClass674(30, 16), new GClass674(2, 17))),
				new GClass672(25, new int[5]
				{
					6,
					32,
					58,
					84,
					110
				}, new GClass673(26, new GClass674(8, 106), new GClass674(4, 107)), new GClass673(28, new GClass674(8, 47), new GClass674(13, 48)), new GClass673(30, new GClass674(7, 24), new GClass674(22, 25)), new GClass673(30, new GClass674(22, 15), new GClass674(13, 16))),
				new GClass672(26, new int[5]
				{
					6,
					30,
					58,
					86,
					114
				}, new GClass673(28, new GClass674(10, 114), new GClass674(2, 115)), new GClass673(28, new GClass674(19, 46), new GClass674(4, 47)), new GClass673(28, new GClass674(28, 22), new GClass674(6, 23)), new GClass673(30, new GClass674(33, 16), new GClass674(4, 17))),
				new GClass672(27, new int[5]
				{
					6,
					34,
					62,
					90,
					118
				}, new GClass673(30, new GClass674(8, 122), new GClass674(4, 123)), new GClass673(28, new GClass674(22, 45), new GClass674(3, 46)), new GClass673(30, new GClass674(8, 23), new GClass674(26, 24)), new GClass673(30, new GClass674(12, 15), new GClass674(28, 16))),
				new GClass672(28, new int[6]
				{
					6,
					26,
					50,
					74,
					98,
					122
				}, new GClass673(30, new GClass674(3, 117), new GClass674(10, 118)), new GClass673(28, new GClass674(3, 45), new GClass674(23, 46)), new GClass673(30, new GClass674(4, 24), new GClass674(31, 25)), new GClass673(30, new GClass674(11, 15), new GClass674(31, 16))),
				new GClass672(29, new int[6]
				{
					6,
					30,
					54,
					78,
					102,
					126
				}, new GClass673(30, new GClass674(7, 116), new GClass674(7, 117)), new GClass673(28, new GClass674(21, 45), new GClass674(7, 46)), new GClass673(30, new GClass674(1, 23), new GClass674(37, 24)), new GClass673(30, new GClass674(19, 15), new GClass674(26, 16))),
				new GClass672(30, new int[6]
				{
					6,
					26,
					52,
					78,
					104,
					130
				}, new GClass673(30, new GClass674(5, 115), new GClass674(10, 116)), new GClass673(28, new GClass674(19, 47), new GClass674(10, 48)), new GClass673(30, new GClass674(15, 24), new GClass674(25, 25)), new GClass673(30, new GClass674(23, 15), new GClass674(25, 16))),
				new GClass672(31, new int[6]
				{
					6,
					30,
					56,
					82,
					108,
					134
				}, new GClass673(30, new GClass674(13, 115), new GClass674(3, 116)), new GClass673(28, new GClass674(2, 46), new GClass674(29, 47)), new GClass673(30, new GClass674(42, 24), new GClass674(1, 25)), new GClass673(30, new GClass674(23, 15), new GClass674(28, 16))),
				new GClass672(32, new int[6]
				{
					6,
					34,
					60,
					86,
					112,
					138
				}, new GClass673(30, new GClass674(17, 115)), new GClass673(28, new GClass674(10, 46), new GClass674(23, 47)), new GClass673(30, new GClass674(10, 24), new GClass674(35, 25)), new GClass673(30, new GClass674(19, 15), new GClass674(35, 16))),
				new GClass672(33, new int[6]
				{
					6,
					30,
					58,
					86,
					114,
					142
				}, new GClass673(30, new GClass674(17, 115), new GClass674(1, 116)), new GClass673(28, new GClass674(14, 46), new GClass674(21, 47)), new GClass673(30, new GClass674(29, 24), new GClass674(19, 25)), new GClass673(30, new GClass674(11, 15), new GClass674(46, 16))),
				new GClass672(34, new int[6]
				{
					6,
					34,
					62,
					90,
					118,
					146
				}, new GClass673(30, new GClass674(13, 115), new GClass674(6, 116)), new GClass673(28, new GClass674(14, 46), new GClass674(23, 47)), new GClass673(30, new GClass674(44, 24), new GClass674(7, 25)), new GClass673(30, new GClass674(59, 16), new GClass674(1, 17))),
				new GClass672(35, new int[7]
				{
					6,
					30,
					54,
					78,
					102,
					126,
					150
				}, new GClass673(30, new GClass674(12, 121), new GClass674(7, 122)), new GClass673(28, new GClass674(12, 47), new GClass674(26, 48)), new GClass673(30, new GClass674(39, 24), new GClass674(14, 25)), new GClass673(30, new GClass674(22, 15), new GClass674(41, 16))),
				new GClass672(36, new int[7]
				{
					6,
					24,
					50,
					76,
					102,
					128,
					154
				}, new GClass673(30, new GClass674(6, 121), new GClass674(14, 122)), new GClass673(28, new GClass674(6, 47), new GClass674(34, 48)), new GClass673(30, new GClass674(46, 24), new GClass674(10, 25)), new GClass673(30, new GClass674(2, 15), new GClass674(64, 16))),
				new GClass672(37, new int[7]
				{
					6,
					28,
					54,
					80,
					106,
					132,
					158
				}, new GClass673(30, new GClass674(17, 122), new GClass674(4, 123)), new GClass673(28, new GClass674(29, 46), new GClass674(14, 47)), new GClass673(30, new GClass674(49, 24), new GClass674(10, 25)), new GClass673(30, new GClass674(24, 15), new GClass674(46, 16))),
				new GClass672(38, new int[7]
				{
					6,
					32,
					58,
					84,
					110,
					136,
					162
				}, new GClass673(30, new GClass674(4, 122), new GClass674(18, 123)), new GClass673(28, new GClass674(13, 46), new GClass674(32, 47)), new GClass673(30, new GClass674(48, 24), new GClass674(14, 25)), new GClass673(30, new GClass674(42, 15), new GClass674(32, 16))),
				new GClass672(39, new int[7]
				{
					6,
					26,
					54,
					82,
					110,
					138,
					166
				}, new GClass673(30, new GClass674(20, 117), new GClass674(4, 118)), new GClass673(28, new GClass674(40, 47), new GClass674(7, 48)), new GClass673(30, new GClass674(43, 24), new GClass674(22, 25)), new GClass673(30, new GClass674(10, 15), new GClass674(67, 16))),
				new GClass672(40, new int[7]
				{
					6,
					30,
					58,
					86,
					114,
					142,
					170
				}, new GClass673(30, new GClass674(19, 118), new GClass674(6, 119)), new GClass673(28, new GClass674(18, 47), new GClass674(31, 48)), new GClass673(30, new GClass674(34, 24), new GClass674(34, 25)), new GClass673(30, new GClass674(20, 15), new GClass674(61, 16)))
			};
		}
	}
}
