using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	internal sealed class Class228
	{
		private const int int_0 = 21522;

		private static readonly int[][] int_1 = new int[32][]
		{
			new int[2]
			{
				21522,
				0
			},
			new int[2]
			{
				20773,
				1
			},
			new int[2]
			{
				24188,
				2
			},
			new int[2]
			{
				23371,
				3
			},
			new int[2]
			{
				17913,
				4
			},
			new int[2]
			{
				16590,
				5
			},
			new int[2]
			{
				20375,
				6
			},
			new int[2]
			{
				19104,
				7
			},
			new int[2]
			{
				30660,
				8
			},
			new int[2]
			{
				29427,
				9
			},
			new int[2]
			{
				32170,
				10
			},
			new int[2]
			{
				30877,
				11
			},
			new int[2]
			{
				26159,
				12
			},
			new int[2]
			{
				25368,
				13
			},
			new int[2]
			{
				27713,
				14
			},
			new int[2]
			{
				26998,
				15
			},
			new int[2]
			{
				5769,
				16
			},
			new int[2]
			{
				5054,
				17
			},
			new int[2]
			{
				7399,
				18
			},
			new int[2]
			{
				6608,
				19
			},
			new int[2]
			{
				1890,
				20
			},
			new int[2]
			{
				597,
				21
			},
			new int[2]
			{
				3340,
				22
			},
			new int[2]
			{
				2107,
				23
			},
			new int[2]
			{
				13663,
				24
			},
			new int[2]
			{
				12392,
				25
			},
			new int[2]
			{
				16177,
				26
			},
			new int[2]
			{
				14854,
				27
			},
			new int[2]
			{
				9396,
				28
			},
			new int[2]
			{
				8579,
				29
			},
			new int[2]
			{
				11994,
				30
			},
			new int[2]
			{
				11245,
				31
			}
		};

		private static readonly int[] int_2 = new int[16]
		{
			0,
			1,
			1,
			2,
			1,
			2,
			2,
			3,
			1,
			2,
			2,
			3,
			2,
			3,
			3,
			4
		};

		private GClass636 gclass636_0;

		private sbyte sbyte_0;

		internal GClass636 method_0()
		{
			return gclass636_0;
		}

		internal sbyte method_1()
		{
			return sbyte_0;
		}

		private Class228(int int_3)
		{
			gclass636_0 = GClass636.smethod_0((int_3 >> 3) & 3);
			sbyte_0 = (sbyte)(int_3 & 7);
		}

		internal static int smethod_0(int int_3, int int_4)
		{
			int_3 ^= int_4;
			return int_2[int_3 & 0xF] + int_2[GClass634.smethod_3(int_3, 4) & 0xF] + int_2[GClass634.smethod_3(int_3, 8) & 0xF] + int_2[GClass634.smethod_3(int_3, 12) & 0xF] + int_2[GClass634.smethod_3(int_3, 16) & 0xF] + int_2[GClass634.smethod_3(int_3, 20) & 0xF] + int_2[GClass634.smethod_3(int_3, 24) & 0xF] + int_2[GClass634.smethod_3(int_3, 28) & 0xF];
		}

		internal static Class228 smethod_1(int int_3)
		{
			Class228 @class = smethod_2(int_3);
			if (@class != null)
			{
				return @class;
			}
			return smethod_2(int_3 ^ 0x5412);
		}

		private static Class228 smethod_2(int int_3)
		{
			int num = int.MaxValue;
			int int_4 = 0;
			int num2 = 0;
			int[] array;
			while (true)
			{
				if (num2 < int_1.Length)
				{
					array = int_1[num2];
					int num3 = array[0];
					if (num3 == int_3)
					{
						break;
					}
					int num4 = smethod_0(int_3, num3);
					if (num4 < num)
					{
						int_4 = array[1];
						num = num4;
					}
					num2++;
					continue;
				}
				if (num <= 3)
				{
					return new Class228(int_4);
				}
				return null;
			}
			return new Class228(array[1]);
		}

		public override int GetHashCode()
		{
			return (gclass636_0.method_1() << 3) | sbyte_0;
		}

		public override bool Equals(object other)
		{
			if (!(other is Class228))
			{
				return false;
			}
			Class228 @class = (Class228)other;
			return gclass636_0 == @class.gclass636_0 && sbyte_0 == @class.sbyte_0;
		}
	}
}
