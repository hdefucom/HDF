using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass557 : GClass556
	{
		private const int int_26 = 4096;

		private int int_27;

		private short[] short_0;

		private short[] short_1;

		private int int_28;

		private int int_29;

		private bool bool_1;

		private int int_30;

		private int int_31;

		private int int_32;

		private byte[] byte_0;

		private GEnum104 genum104_0;

		private int int_33;

		private int int_34;

		private int int_35;

		private int int_36;

		private int int_37;

		private byte[] byte_1;

		private long long_0;

		private int int_38;

		private int int_39;

		private GClass567 gclass567_0;

		private GClass550 gclass550_0;

		private GClass549 gclass549_0;

		public GClass557(GClass567 gclass567_1)
		{
			gclass567_0 = gclass567_1;
			gclass550_0 = new GClass550(gclass567_1);
			gclass549_0 = new GClass549();
			byte_0 = new byte[65536];
			short_0 = new short[32768];
			short_1 = new short[32768];
			int_31 = 1;
			int_30 = 1;
		}

		public bool method_0(bool bool_2, bool bool_3)
		{
			int num = 3;
			bool flag;
			bool num2;
			do
			{
				method_11();
				bool bool_4 = bool_2 && int_38 == int_39;
				switch (int_37)
				{
				case 0:
					flag = method_16(bool_4, bool_3);
					goto IL_0044;
				case 1:
					flag = method_17(bool_4, bool_3);
					goto IL_0044;
				case 2:
					flag = method_18(bool_4, bool_3);
					goto IL_0044;
				default:
					{
						throw new InvalidOperationException("unknown compressionFunction");
					}
					IL_0044:
					num2 = (gclass567_0.method_9() && flag);
					break;
				}
			}
			while (num2);
			return flag;
		}

		public void method_1(byte[] byte_2, int int_40, int int_41)
		{
			int num = 15;
			if (byte_2 == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (int_40 < 0)
			{
				throw new ArgumentOutOfRangeException("offset");
			}
			if (int_41 < 0)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			if (int_38 < int_39)
			{
				throw new InvalidOperationException("Old input was not completely processed");
			}
			int num2 = int_40 + int_41;
			if (int_40 > num2 || num2 > byte_2.Length)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			byte_1 = byte_2;
			int_38 = int_40;
			int_39 = num2;
		}

		public bool method_2()
		{
			return int_39 == int_38;
		}

		public void method_3(byte[] byte_2, int int_40, int int_41)
		{
			gclass549_0.imethod_4(byte_2, int_40, int_41);
			if (int_41 >= 3)
			{
				if (int_41 > 32506)
				{
					int_40 += int_41 - 32506;
					int_41 = 32506;
				}
				Array.Copy(byte_2, int_40, byte_0, int_31, int_41);
				method_12();
				int_41--;
				while (--int_41 > 0)
				{
					method_13();
					int_31++;
				}
				int_31 += 2;
				int_30 = int_31;
			}
		}

		public void method_4()
		{
			gclass550_0.method_0();
			gclass549_0.imethod_1();
			int_31 = 1;
			int_30 = 1;
			int_32 = 0;
			long_0 = 0L;
			bool_1 = false;
			int_29 = 2;
			for (int i = 0; i < 32768; i++)
			{
				short_0[i] = 0;
			}
			for (int i = 0; i < 32768; i++)
			{
				short_1[i] = 0;
			}
		}

		public void method_5()
		{
			gclass549_0.imethod_1();
		}

		public int method_6()
		{
			return (int)gclass549_0.imethod_0();
		}

		public long method_7()
		{
			return long_0;
		}

		public GEnum104 method_8()
		{
			return genum104_0;
		}

		public void method_9(GEnum104 genum104_1)
		{
			genum104_0 = genum104_1;
		}

		public void method_10(int int_40)
		{
			int num = 14;
			if (int_40 < 0 || int_40 > 9)
			{
				throw new ArgumentOutOfRangeException("level");
			}
			int_36 = GClass556.int_21[int_40];
			int_34 = GClass556.int_22[int_40];
			int_35 = GClass556.int_23[int_40];
			int_33 = GClass556.int_24[int_40];
			if (GClass556.int_25[int_40] == int_37)
			{
				return;
			}
			switch (int_37)
			{
			case 0:
				if (int_31 > int_30)
				{
					gclass550_0.method_3(byte_0, int_30, int_31 - int_30, bool_0: false);
					int_30 = int_31;
				}
				method_12();
				break;
			case 1:
				if (int_31 > int_30)
				{
					gclass550_0.method_4(byte_0, int_30, int_31 - int_30, bool_0: false);
					int_30 = int_31;
				}
				break;
			case 2:
				if (bool_1)
				{
					gclass550_0.method_6(byte_0[int_31 - 1] & 0xFF);
				}
				if (int_31 > int_30)
				{
					gclass550_0.method_4(byte_0, int_30, int_31 - int_30, bool_0: false);
					int_30 = int_31;
				}
				bool_1 = false;
				int_29 = 2;
				break;
			}
			int_37 = GClass556.int_25[int_40];
		}

		public void method_11()
		{
			if (int_31 >= 65274)
			{
				method_14();
			}
			while (int_32 < 262 && int_38 < int_39)
			{
				int num = 65536 - int_32 - int_31;
				if (num > int_39 - int_38)
				{
					num = int_39 - int_38;
				}
				Array.Copy(byte_1, int_38, byte_0, int_31 + int_32, num);
				gclass549_0.imethod_4(byte_1, int_38, num);
				int_38 += num;
				long_0 += num;
				int_32 += num;
			}
			if (int_32 >= 3)
			{
				method_12();
			}
		}

		private void method_12()
		{
			int_27 = ((byte_0[int_31] << 5) ^ byte_0[int_31 + 1]);
		}

		private int method_13()
		{
			int num = ((int_27 << 5) ^ byte_0[int_31 + 2]) & 0x7FFF;
			short num2 = short_1[int_31 & 0x7FFF] = short_0[num];
			short_0[num] = (short)int_31;
			int_27 = num;
			return num2 & 0xFFFF;
		}

		private void method_14()
		{
			Array.Copy(byte_0, 32768, byte_0, 0, 32768);
			int_28 -= 32768;
			int_31 -= 32768;
			int_30 -= 32768;
			for (int i = 0; i < 32768; i++)
			{
				int num = short_0[i] & 0xFFFF;
				short_0[i] = (short)((num >= 32768) ? (num - 32768) : 0);
			}
			for (int i = 0; i < 32768; i++)
			{
				int num = short_1[i] & 0xFFFF;
				short_1[i] = (short)((num >= 32768) ? (num - 32768) : 0);
			}
		}

		private bool method_15(int int_40)
		{
			int num = int_33;
			int num2 = int_35;
			short[] array = short_1;
			int num3 = int_31;
			int num4 = int_31 + int_29;
			int num5 = Math.Max(int_29, 2);
			int num6 = Math.Max(int_31 - 32506, 0);
			int num7 = int_31 + 258 - 1;
			byte b = byte_0[num4 - 1];
			byte b2 = byte_0[num4];
			if (num5 >= int_36)
			{
				num >>= 2;
			}
			if (num2 > int_32)
			{
				num2 = int_32;
			}
			do
			{
				if (byte_0[int_40 + num5] != b2 || byte_0[int_40 + num5 - 1] != b || byte_0[int_40] != byte_0[num3] || byte_0[int_40 + 1] != byte_0[num3 + 1])
				{
					continue;
				}
				int num8 = int_40 + 2;
				num3 += 2;
				while (byte_0[++num3] == byte_0[++num8] && byte_0[++num3] == byte_0[++num8] && byte_0[++num3] == byte_0[++num8] && byte_0[++num3] == byte_0[++num8] && byte_0[++num3] == byte_0[++num8] && byte_0[++num3] == byte_0[++num8] && byte_0[++num3] == byte_0[++num8] && byte_0[++num3] == byte_0[++num8] && num3 < num7)
				{
				}
				if (num3 > num4)
				{
					int_28 = int_40;
					num4 = num3;
					num5 = num3 - int_31;
					if (num5 >= num2)
					{
						break;
					}
					b = byte_0[num4 - 1];
					b2 = byte_0[num4];
				}
				num3 = int_31;
			}
			while ((int_40 = (array[int_40 & 0x7FFF] & 0xFFFF)) > num6 && --num != 0);
			int_29 = Math.Min(num5, int_32);
			return int_29 >= 3;
		}

		private bool method_16(bool bool_2, bool bool_3)
		{
			if (!bool_2 && int_32 == 0)
			{
				return false;
			}
			int_31 += int_32;
			int_32 = 0;
			int num = int_31 - int_30;
			if (num >= GClass556.int_20 || (int_30 < 32768 && num >= 32506) || bool_2)
			{
				bool flag = bool_3;
				if (num > GClass556.int_20)
				{
					num = GClass556.int_20;
					flag = false;
				}
				gclass550_0.method_3(byte_0, int_30, num, flag);
				int_30 += num;
				return !flag;
			}
			return true;
		}

		private bool method_17(bool bool_2, bool bool_3)
		{
			if (int_32 < 262 && !bool_2)
			{
				return false;
			}
			do
			{
				IL_0199:
				if (int_32 >= 262 || bool_2)
				{
					if (int_32 != 0)
					{
						if (int_31 > 65274)
						{
							method_14();
						}
						int num;
						if (int_32 >= 3 && (num = method_13()) != 0 && genum104_0 != GEnum104.const_2 && int_31 - num <= 32506 && method_15(num))
						{
							bool flag = gclass550_0.method_7(int_31 - int_28, int_29);
							int_32 -= int_29;
							if (int_29 <= int_34 && int_32 >= 3)
							{
								while (--int_29 > 0)
								{
									int_31++;
									method_13();
								}
								int_31++;
							}
							else
							{
								int_31 += int_29;
								if (int_32 >= 2)
								{
									method_12();
								}
							}
							int_29 = 2;
							if (!flag)
							{
								goto IL_0199;
							}
						}
						else
						{
							gclass550_0.method_6(byte_0[int_31] & 0xFF);
							int_31++;
							int_32--;
						}
						continue;
					}
					gclass550_0.method_4(byte_0, int_30, int_31 - int_30, bool_3);
					int_30 = int_31;
					return false;
				}
				return true;
			}
			while (!gclass550_0.method_5());
			bool flag2 = bool_3 && int_32 == 0;
			gclass550_0.method_4(byte_0, int_30, int_31 - int_30, flag2);
			int_30 = int_31;
			return !flag2;
		}

		private bool method_18(bool bool_2, bool bool_3)
		{
			if (int_32 < 262 && !bool_2)
			{
				return false;
			}
			do
			{
				if (int_32 >= 262 || bool_2)
				{
					if (int_32 != 0)
					{
						if (int_31 >= 65274)
						{
							method_14();
						}
						int num = int_28;
						int num2 = int_29;
						if (int_32 >= 3)
						{
							int num3 = method_13();
							if (genum104_0 != GEnum104.const_2 && num3 != 0 && int_31 - num3 <= 32506 && method_15(num3) && int_29 <= 5 && (genum104_0 == GEnum104.const_1 || (int_29 == 3 && int_31 - int_28 > 4096)))
							{
								int_29 = 2;
							}
						}
						if (num2 >= 3 && int_29 <= num2)
						{
							gclass550_0.method_7(int_31 - 1 - num, num2);
							num2 -= 2;
							do
							{
								int_31++;
								int_32--;
								if (int_32 >= 3)
								{
									method_13();
								}
							}
							while (--num2 > 0);
							int_31++;
							int_32--;
							bool_1 = false;
							int_29 = 2;
						}
						else
						{
							if (bool_1)
							{
								gclass550_0.method_6(byte_0[int_31 - 1] & 0xFF);
							}
							bool_1 = true;
							int_31++;
							int_32--;
						}
						continue;
					}
					if (bool_1)
					{
						gclass550_0.method_6(byte_0[int_31 - 1] & 0xFF);
					}
					bool_1 = false;
					gclass550_0.method_4(byte_0, int_30, int_31 - int_30, bool_3);
					int_30 = int_31;
					return false;
				}
				return true;
			}
			while (!gclass550_0.method_5());
			int num4 = int_31 - int_30;
			if (bool_1)
			{
				num4--;
			}
			bool flag = bool_3 && int_32 == 0 && !bool_1;
			gclass550_0.method_4(byte_0, int_30, num4, flag);
			int_30 += num4;
			return !flag;
		}
	}
}
