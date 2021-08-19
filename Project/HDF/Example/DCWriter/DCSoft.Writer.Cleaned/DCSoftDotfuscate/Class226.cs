using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	internal class Class226
	{
		private const int int_0 = 0;

		private const int int_1 = 1;

		private const int int_2 = 2;

		private const int int_3 = 3;

		private const int int_4 = 4;

		private const int int_5 = 5;

		private static readonly int[] int_6 = new int[3]
		{
			3,
			3,
			11
		};

		private static readonly int[] int_7 = new int[3]
		{
			2,
			3,
			7
		};

		private static readonly int[] int_8 = new int[19]
		{
			16,
			17,
			18,
			0,
			8,
			7,
			9,
			6,
			10,
			5,
			11,
			4,
			12,
			3,
			13,
			2,
			14,
			1,
			15
		};

		private byte[] byte_0;

		private byte[] byte_1;

		private GClass588 gclass588_0;

		private int int_9;

		private int int_10;

		private int int_11;

		private int int_12;

		private int int_13;

		private int int_14;

		private byte byte_2;

		private int int_15;

		public bool method_0(GClass554 gclass554_0)
		{
			while (true)
			{
				switch (int_9)
				{
				case 5:
				{
					int num = int_7[int_14];
					int num2 = gclass554_0.method_0(num);
					if (num2 >= 0)
					{
						gclass554_0.method_1(num);
						num2 += int_6[int_14];
						if (int_15 + num2 <= int_13)
						{
							while (num2-- > 0)
							{
								byte_1[int_15++] = byte_2;
							}
							if (int_15 == int_13)
							{
								return true;
							}
							goto IL_009a;
						}
						throw new GException19();
					}
					return false;
				}
				case 4:
				{
					int num3;
					while (((num3 = gclass588_0.method_1(gclass554_0)) & -16) == 0)
					{
						byte_1[int_15++] = (byte_2 = (byte)num3);
						if (int_15 == int_13)
						{
							return true;
						}
					}
					if (num3 >= 0)
					{
						if (num3 >= 17)
						{
							byte_2 = 0;
						}
						else if (int_15 == 0)
						{
							throw new GException19();
						}
						int_14 = num3 - 16;
						int_9 = 5;
						goto case 5;
					}
					return false;
				}
				case 3:
					while (int_15 < int_12)
					{
						int num4 = gclass554_0.method_0(3);
						if (num4 >= 0)
						{
							gclass554_0.method_1(3);
							byte_0[int_8[int_15]] = (byte)num4;
							int_15++;
							continue;
						}
						return false;
					}
					gclass588_0 = new GClass588(byte_0);
					byte_0 = null;
					int_15 = 0;
					int_9 = 4;
					goto case 4;
				case 2:
					int_12 = gclass554_0.method_0(4);
					if (int_12 >= 0)
					{
						int_12 += 4;
						gclass554_0.method_1(4);
						byte_0 = new byte[19];
						int_15 = 0;
						int_9 = 3;
						goto case 3;
					}
					return false;
				case 1:
					int_11 = gclass554_0.method_0(5);
					if (int_11 >= 0)
					{
						int_11++;
						gclass554_0.method_1(5);
						int_13 = int_10 + int_11;
						byte_1 = new byte[int_13];
						int_9 = 2;
						goto case 2;
					}
					return false;
				case 0:
					int_10 = gclass554_0.method_0(5);
					if (int_10 >= 0)
					{
						int_10 += 257;
						gclass554_0.method_1(5);
						int_9 = 1;
						goto case 1;
					}
					return false;
				}
				continue;
				IL_009a:
				int_9 = 4;
			}
		}

		public GClass588 method_1()
		{
			byte[] destinationArray = new byte[int_10];
			Array.Copy(byte_1, 0, destinationArray, 0, int_10);
			return new GClass588(destinationArray);
		}

		public GClass588 method_2()
		{
			byte[] destinationArray = new byte[int_11];
			Array.Copy(byte_1, int_10, destinationArray, 0, int_11);
			return new GClass588(destinationArray);
		}
	}
}
