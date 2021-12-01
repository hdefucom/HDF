using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass587
	{
		private const int int_0 = 0;

		private const int int_1 = 1;

		private const int int_2 = 2;

		private const int int_3 = 3;

		private const int int_4 = 4;

		private const int int_5 = 5;

		private const int int_6 = 6;

		private const int int_7 = 7;

		private const int int_8 = 8;

		private const int int_9 = 9;

		private const int int_10 = 10;

		private const int int_11 = 11;

		private const int int_12 = 12;

		private static readonly int[] int_13 = new int[29]
		{
			3,
			4,
			5,
			6,
			7,
			8,
			9,
			10,
			11,
			13,
			15,
			17,
			19,
			23,
			27,
			31,
			35,
			43,
			51,
			59,
			67,
			83,
			99,
			115,
			131,
			163,
			195,
			227,
			258
		};

		private static readonly int[] int_14 = new int[29]
		{
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			1,
			1,
			1,
			1,
			2,
			2,
			2,
			2,
			3,
			3,
			3,
			3,
			4,
			4,
			4,
			4,
			5,
			5,
			5,
			5,
			0
		};

		private static readonly int[] int_15 = new int[30]
		{
			1,
			2,
			3,
			4,
			5,
			7,
			9,
			13,
			17,
			25,
			33,
			49,
			65,
			97,
			129,
			193,
			257,
			385,
			513,
			769,
			1025,
			1537,
			2049,
			3073,
			4097,
			6145,
			8193,
			12289,
			16385,
			24577
		};

		private static readonly int[] int_16 = new int[30]
		{
			0,
			0,
			0,
			0,
			1,
			1,
			2,
			2,
			3,
			3,
			4,
			4,
			5,
			5,
			6,
			6,
			7,
			7,
			8,
			8,
			9,
			9,
			10,
			10,
			11,
			11,
			12,
			12,
			13,
			13
		};

		private int int_17;

		private int int_18;

		private int int_19;

		private int int_20;

		private int int_21;

		private int int_22;

		private bool bool_0;

		private long long_0;

		private long long_1;

		private bool bool_1;

		private GClass554 gclass554_0;

		private GClass591 gclass591_0;

		private Class226 class226_0;

		private GClass588 gclass588_0;

		private GClass588 gclass588_1;

		private GClass549 gclass549_0;

		public GClass587()
			: this(bool_2: false)
		{
		}

		public GClass587(bool bool_2)
		{
			bool_1 = bool_2;
			gclass549_0 = new GClass549();
			gclass554_0 = new GClass554();
			gclass591_0 = new GClass591();
			int_17 = (bool_2 ? 2 : 0);
		}

		public void method_0()
		{
			int_17 = (bool_1 ? 2 : 0);
			long_1 = 0L;
			long_0 = 0L;
			gclass554_0.method_8();
			gclass591_0.method_8();
			class226_0 = null;
			gclass588_0 = null;
			gclass588_1 = null;
			bool_0 = false;
			gclass549_0.imethod_1();
		}

		private bool method_1()
		{
			int num = 2;
			int num2 = gclass554_0.method_0(16);
			if (num2 < 0)
			{
				return false;
			}
			gclass554_0.method_1(16);
			num2 = (((num2 << 8) | (num2 >> 8)) & 0xFFFF);
			if (num2 % 31 != 0)
			{
				throw new GException19("Header checksum illegal");
			}
			if ((num2 & 0xF00) != 2048)
			{
				throw new GException19("Compression Method unknown");
			}
			if ((num2 & 0x20) == 0)
			{
				int_17 = 2;
			}
			else
			{
				int_17 = 1;
				int_19 = 32;
			}
			return true;
		}

		private bool method_2()
		{
			while (true)
			{
				if (int_19 > 0)
				{
					int num = gclass554_0.method_0(8);
					if (num < 0)
					{
						break;
					}
					gclass554_0.method_1(8);
					int_18 = ((int_18 << 8) | num);
					int_19 -= 8;
					continue;
				}
				return false;
			}
			return false;
		}

		private bool method_3()
		{
			int num = 9;
			int num2 = gclass591_0.method_5();
			while (num2 >= 258)
			{
				switch (int_17)
				{
				case 7:
				{
					int num3;
					while (((num3 = gclass588_0.method_1(gclass554_0)) & -256) == 0)
					{
						gclass591_0.method_0(num3);
						if (--num2 < 258)
						{
							return true;
						}
					}
					if (num3 >= 257)
					{
						try
						{
							int_20 = int_13[num3 - 257];
							int_19 = int_14[num3 - 257];
						}
						catch (Exception)
						{
							throw new GException19("Illegal rep length code");
						}
						goto case 8;
					}
					if (num3 < 0)
					{
						return false;
					}
					gclass588_1 = null;
					gclass588_0 = null;
					int_17 = 2;
					return true;
				}
				case 8:
					if (int_19 > 0)
					{
						int_17 = 8;
						int num4 = gclass554_0.method_0(int_19);
						if (num4 < 0)
						{
							return false;
						}
						gclass554_0.method_1(int_19);
						int_20 += num4;
					}
					int_17 = 9;
					goto case 9;
				case 9:
				{
					int num3 = gclass588_1.method_1(gclass554_0);
					if (num3 >= 0)
					{
						try
						{
							int_21 = int_15[num3];
							int_19 = int_16[num3];
						}
						catch (Exception)
						{
							throw new GException19("Illegal rep dist code");
						}
						goto case 10;
					}
					return false;
				}
				case 10:
					if (int_19 > 0)
					{
						int_17 = 10;
						int num4 = gclass554_0.method_0(int_19);
						if (num4 < 0)
						{
							return false;
						}
						gclass554_0.method_1(int_19);
						int_21 += num4;
					}
					break;
				default:
					throw new GException19("Inflater unknown mode");
				}
				gclass591_0.method_2(int_20, int_21);
				num2 -= int_20;
				int_17 = 7;
			}
			return true;
		}

		private bool method_4()
		{
			int num = 12;
			while (true)
			{
				if (int_19 > 0)
				{
					int num2 = gclass554_0.method_0(8);
					if (num2 < 0)
					{
						break;
					}
					gclass554_0.method_1(8);
					int_18 = ((int_18 << 8) | num2);
					int_19 -= 8;
					continue;
				}
				if ((int)gclass549_0.imethod_0() != int_18)
				{
					throw new GException19("Adler chksum doesn't match: " + (int)gclass549_0.imethod_0() + " vs. " + int_18);
				}
				int_17 = 12;
				return false;
			}
			return false;
		}

		private bool method_5()
		{
			int num = 15;
			switch (int_17)
			{
			default:
				throw new GException19("Inflater.Decode unknown mode");
			case 0:
				return method_1();
			case 1:
				return method_2();
			case 2:
			{
				if (bool_0)
				{
					if (bool_1)
					{
						int_17 = 12;
						return false;
					}
					gclass554_0.method_5();
					int_19 = 32;
					int_17 = 11;
					return true;
				}
				int num2 = gclass554_0.method_0(3);
				if (num2 < 0)
				{
					return false;
				}
				gclass554_0.method_1(3);
				if ((num2 & 1) != 0)
				{
					bool_0 = true;
				}
				switch (num2 >> 1)
				{
				default:
					throw new GException19("Unknown block type " + num2);
				case 0:
					gclass554_0.method_5();
					int_17 = 3;
					break;
				case 1:
					gclass588_0 = GClass588.gclass588_0;
					gclass588_1 = GClass588.gclass588_1;
					int_17 = 7;
					break;
				case 2:
					class226_0 = new Class226();
					int_17 = 6;
					break;
				}
				return true;
			}
			case 3:
				if ((int_22 = gclass554_0.method_0(16)) < 0)
				{
					return false;
				}
				gclass554_0.method_1(16);
				int_17 = 4;
				goto case 4;
			case 4:
			{
				int num4 = gclass554_0.method_0(16);
				if (num4 < 0)
				{
					return false;
				}
				gclass554_0.method_1(16);
				if (num4 != (int_22 ^ 0xFFFF))
				{
					throw new GException19("broken uncompressed block");
				}
				int_17 = 5;
				goto case 5;
			}
			case 5:
			{
				int num3 = gclass591_0.method_3(gclass554_0, int_22);
				int_22 -= num3;
				if (int_22 == 0)
				{
					int_17 = 2;
					return true;
				}
				return !gclass554_0.method_6();
			}
			case 6:
				if (!class226_0.method_0(gclass554_0))
				{
					return false;
				}
				gclass588_0 = class226_0.method_1();
				gclass588_1 = class226_0.method_2();
				int_17 = 7;
				goto case 7;
			case 7:
			case 8:
			case 9:
			case 10:
				return method_3();
			case 11:
				return method_4();
			case 12:
				return false;
			}
		}

		public void method_6(byte[] byte_0)
		{
			method_7(byte_0, 0, byte_0.Length);
		}

		public void method_7(byte[] byte_0, int int_23, int int_24)
		{
			int num = 0;
			if (byte_0 == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (int_23 < 0)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (int_24 < 0)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			if (!method_13())
			{
				throw new InvalidOperationException("Dictionary is not needed");
			}
			gclass549_0.imethod_4(byte_0, int_23, int_24);
			if ((int)gclass549_0.imethod_0() != int_18)
			{
				throw new GException19("Wrong adler checksum");
			}
			gclass549_0.imethod_1();
			gclass591_0.method_4(byte_0, int_23, int_24);
			int_17 = 2;
		}

		public void method_8(byte[] byte_0)
		{
			method_9(byte_0, 0, byte_0.Length);
		}

		public void method_9(byte[] byte_0, int int_23, int int_24)
		{
			gclass554_0.method_9(byte_0, int_23, int_24);
			long_1 += int_24;
		}

		public int method_10(byte[] byte_0)
		{
			int num = 5;
			if (byte_0 == null)
			{
				throw new ArgumentNullException("buffer");
			}
			return method_11(byte_0, 0, byte_0.Length);
		}

		public int method_11(byte[] byte_0, int int_23, int int_24)
		{
			int num = 4;
			if (byte_0 == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (int_24 < 0)
			{
				throw new ArgumentOutOfRangeException("count", "count cannot be negative");
			}
			if (int_23 < 0)
			{
				throw new ArgumentOutOfRangeException("offset", "offset cannot be negative");
			}
			if (int_23 + int_24 > byte_0.Length)
			{
				throw new ArgumentException("count exceeds buffer bounds");
			}
			if (int_24 == 0)
			{
				if (!method_14())
				{
					method_5();
				}
				return 0;
			}
			int num2 = 0;
			do
			{
				if (int_17 == 11)
				{
					continue;
				}
				int num3 = gclass591_0.method_7(byte_0, int_23, int_24);
				if (num3 > 0)
				{
					gclass549_0.imethod_4(byte_0, int_23, num3);
					int_23 += num3;
					num2 += num3;
					long_0 += num3;
					int_24 -= num3;
					if (int_24 == 0)
					{
						return num2;
					}
				}
			}
			while (method_5() || (gclass591_0.method_6() > 0 && int_17 != 11));
			return num2;
		}

		public bool method_12()
		{
			return gclass554_0.method_6();
		}

		public bool method_13()
		{
			return int_17 == 1 && int_19 == 0;
		}

		public bool method_14()
		{
			return int_17 == 12 && gclass591_0.method_6() == 0;
		}

		public int method_15()
		{
			return (int)(method_13() ? int_18 : gclass549_0.imethod_0());
		}

		public long method_16()
		{
			return long_0;
		}

		public long method_17()
		{
			return long_1 - method_18();
		}

		public int method_18()
		{
			return gclass554_0.method_4();
		}
	}
}
