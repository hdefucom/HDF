using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass586
	{
		public const int int_0 = 9;

		public const int int_1 = 1;

		public const int int_2 = -1;

		public const int int_3 = 0;

		public const int int_4 = 8;

		private const int int_5 = 1;

		private const int int_6 = 4;

		private const int int_7 = 8;

		private const int int_8 = 0;

		private const int int_9 = 1;

		private const int int_10 = 16;

		private const int int_11 = 20;

		private const int int_12 = 28;

		private const int int_13 = 30;

		private const int int_14 = 127;

		private int int_15;

		private bool bool_0;

		private int int_16;

		private long long_0;

		private GClass567 gclass567_0;

		private GClass557 gclass557_0;

		public GClass586()
			: this(-1, bool_1: false)
		{
		}

		public GClass586(int int_17)
			: this(int_17, bool_1: false)
		{
		}

		public GClass586(int int_17, bool bool_1)
		{
			int num = 19;
			
			if (int_17 == -1)
			{
				int_17 = 6;
			}
			else if (int_17 < 0 || int_17 > 9)
			{
				throw new ArgumentOutOfRangeException("level");
			}
			gclass567_0 = new GClass567();
			gclass557_0 = new GClass557(gclass567_0);
			bool_0 = bool_1;
			method_12(GEnum104.const_0);
			method_10(int_17);
			method_0();
		}

		public void method_0()
		{
			int_16 = (bool_0 ? 16 : 0);
			long_0 = 0L;
			gclass567_0.method_0();
			gclass557_0.method_4();
		}

		public int method_1()
		{
			return gclass557_0.method_6();
		}

		public long method_2()
		{
			return gclass557_0.method_7();
		}

		public long method_3()
		{
			return long_0;
		}

		public void method_4()
		{
			int_16 |= 4;
		}

		public void method_5()
		{
			int_16 |= 12;
		}

		public bool method_6()
		{
			return int_16 == 30 && gclass567_0.method_9();
		}

		public bool method_7()
		{
			return gclass557_0.method_2();
		}

		public void method_8(byte[] byte_0)
		{
			method_9(byte_0, 0, byte_0.Length);
		}

		public void method_9(byte[] byte_0, int int_17, int int_18)
		{
			int num = 1;
			if ((int_16 & 8) != 0)
			{
				throw new InvalidOperationException("Finish() already called");
			}
			gclass557_0.method_1(byte_0, int_17, int_18);
		}

		public void method_10(int int_17)
		{
			int num = 13;
			if (int_17 == -1)
			{
				int_17 = 6;
			}
			else if (int_17 < 0 || int_17 > 9)
			{
				throw new ArgumentOutOfRangeException("level");
			}
			if (int_15 != int_17)
			{
				int_15 = int_17;
				gclass557_0.method_10(int_17);
			}
		}

		public int method_11()
		{
			return int_15;
		}

		public void method_12(GEnum104 genum104_0)
		{
			gclass557_0.method_9(genum104_0);
		}

		public int method_13(byte[] byte_0)
		{
			return method_14(byte_0, 0, byte_0.Length);
		}

		public int method_14(byte[] byte_0, int int_17, int int_18)
		{
			int num = 19;
			int num2 = int_18;
			if (int_16 == 127)
			{
				throw new InvalidOperationException("Deflater closed");
			}
			if (int_16 < 16)
			{
				int num3 = 30720;
				int num4 = int_15 - 1 >> 1;
				if (num4 < 0 || num4 > 3)
				{
					num4 = 3;
				}
				num3 |= num4 << 6;
				if ((int_16 & 1) != 0)
				{
					num3 |= 0x20;
				}
				num3 += 31 - num3 % 31;
				gclass567_0.method_8(num3);
				if ((int_16 & 1) != 0)
				{
					int num5 = gclass557_0.method_6();
					gclass557_0.method_5();
					gclass567_0.method_8(num5 >> 16);
					gclass567_0.method_8(num5 & 0xFFFF);
				}
				int_16 = (0x10 | (int_16 & 0xC));
			}
			while (true)
			{
				int num6 = gclass567_0.method_10(byte_0, int_17, int_18);
				int_17 += num6;
				long_0 += num6;
				int_18 -= num6;
				if (int_18 != 0 && int_16 != 30)
				{
					if (gclass557_0.method_0((int_16 & 4) != 0, (int_16 & 8) != 0))
					{
						continue;
					}
					if (int_16 == 16)
					{
						break;
					}
					if (int_16 == 20)
					{
						if (int_15 != 0)
						{
							for (int num7 = 8 + (-gclass567_0.method_5() & 7); num7 > 0; num7 -= 10)
							{
								gclass567_0.method_7(2, 10);
							}
						}
						int_16 = 16;
					}
					else if (int_16 == 28)
					{
						gclass567_0.method_6();
						if (!bool_0)
						{
							int num8 = gclass557_0.method_6();
							gclass567_0.method_8(num8 >> 16);
							gclass567_0.method_8(num8 & 0xFFFF);
						}
						int_16 = 30;
					}
					continue;
				}
				return num2 - int_18;
			}
			return num2 - int_18;
		}

		public void method_15(byte[] byte_0)
		{
			method_16(byte_0, 0, byte_0.Length);
		}

		public void method_16(byte[] byte_0, int int_17, int int_18)
		{
			if (int_16 != 0)
			{
				throw new InvalidOperationException();
			}
			int_16 = 1;
			gclass557_0.method_3(byte_0, int_17, int_18);
		}
	}
}
