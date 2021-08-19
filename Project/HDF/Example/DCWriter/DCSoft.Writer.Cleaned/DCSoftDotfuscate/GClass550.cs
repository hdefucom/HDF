using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass550
	{
		[ComVisible(false)]
		private class Class215
		{
			public short[] short_0;

			public byte[] byte_0;

			public int int_0;

			public int int_1;

			private short[] short_1;

			private int[] int_2;

			private int int_3;

			private GClass550 gclass550_0;

			public Class215(GClass550 gclass550_1, int int_4, int int_5, int int_6)
			{
				gclass550_0 = gclass550_1;
				int_0 = int_5;
				int_3 = int_6;
				short_0 = new short[int_4];
				int_2 = new int[int_6];
			}

			public void method_0()
			{
				for (int i = 0; i < short_0.Length; i++)
				{
					short_0[i] = 0;
				}
				short_1 = null;
				byte_0 = null;
			}

			public void method_1(int int_4)
			{
				gclass550_0.gclass567_0.method_7(short_1[int_4] & 0xFFFF, byte_0[int_4]);
			}

			public void method_2()
			{
				int num = 11;
				bool flag = true;
				for (int i = 0; i < short_0.Length; i++)
				{
					if (short_0[i] != 0)
					{
						flag = false;
					}
				}
				if (!flag)
				{
					throw new GException19("!Empty");
				}
			}

			public void method_3(short[] short_2, byte[] byte_1)
			{
				short_1 = short_2;
				byte_0 = byte_1;
			}

			public void method_4()
			{
				int[] array = new int[int_3];
				int num = 0;
				short_1 = new short[short_0.Length];
				for (int i = 0; i < int_3; i++)
				{
					array[i] = num;
					num += int_2[i] << 15 - i;
				}
				for (int j = 0; j < int_1; j++)
				{
					int i = byte_0[j];
					if (i > 0)
					{
						short_1[j] = smethod_0(array[i - 1]);
						array[i - 1] += 1 << 16 - i;
					}
				}
			}

			public void method_5()
			{
				int num = 12;
				int num2 = short_0.Length;
				int[] array = new int[num2];
				int num3 = 0;
				int num4 = 0;
				for (int i = 0; i < num2; i++)
				{
					int num5 = short_0[i];
					if (num5 != 0)
					{
						int num6 = num3++;
						int num7;
						while (num6 > 0 && short_0[array[num7 = (num6 - 1) / 2]] > num5)
						{
							array[num6] = array[num7];
							num6 = num7;
						}
						array[num6] = i;
						num4 = i;
					}
				}
				while (num3 < 2)
				{
					int num8 = (num4 < 2) ? (++num4) : 0;
					array[num3++] = num8;
				}
				int_1 = Math.Max(num4 + 1, int_0);
				int num9 = num3;
				int[] array2 = new int[4 * num3 - 2];
				int[] array3 = new int[2 * num3 - 1];
				int num10 = num9;
				for (int j = 0; j < num3; j++)
				{
					int num8 = array2[2 * j] = array[j];
					array2[2 * j + 1] = -1;
					array3[j] = short_0[num8] << 8;
					array[j] = j;
				}
				do
				{
					int num11 = array[0];
					int num12 = array[--num3];
					int num7 = 0;
					int num13;
					for (num13 = 1; num13 < num3; num13 = num13 * 2 + 1)
					{
						if (num13 + 1 < num3 && array3[array[num13]] > array3[array[num13 + 1]])
						{
							num13++;
						}
						array[num7] = array[num13];
						num7 = num13;
					}
					int num14 = array3[num12];
					while ((num13 = num7) > 0 && array3[array[num7 = (num13 - 1) / 2]] > num14)
					{
						array[num13] = array[num7];
					}
					array[num13] = num12;
					int num15 = array[0];
					num12 = num10++;
					array2[2 * num12] = num11;
					array2[2 * num12 + 1] = num15;
					int num16 = Math.Min(array3[num11] & 0xFF, array3[num15] & 0xFF);
					num14 = (array3[num12] = array3[num11] + array3[num15] - num16 + 1);
					num7 = 0;
					for (num13 = 1; num13 < num3; num13 = num7 * 2 + 1)
					{
						if (num13 + 1 < num3 && array3[array[num13]] > array3[array[num13 + 1]])
						{
							num13++;
						}
						array[num7] = array[num13];
						num7 = num13;
					}
					while ((num13 = num7) > 0 && array3[array[num7 = (num13 - 1) / 2]] > num14)
					{
						array[num13] = array[num7];
					}
					array[num13] = num12;
				}
				while (num3 > 1);
				if (array[0] != array2.Length / 2 - 1)
				{
					throw new GException19("Heap invariant violated");
				}
				method_9(array2);
			}

			public int method_6()
			{
				int num = 0;
				for (int i = 0; i < short_0.Length; i++)
				{
					num += short_0[i] * byte_0[i];
				}
				return num;
			}

			public void method_7(Class215 class215_0)
			{
				int num = -1;
				int num2 = 0;
				while (num2 < int_1)
				{
					int num3 = 1;
					int num4 = byte_0[num2];
					int num5;
					int num6;
					if (num4 == 0)
					{
						num5 = 138;
						num6 = 3;
					}
					else
					{
						num5 = 6;
						num6 = 3;
						if (num != num4)
						{
							class215_0.short_0[num4]++;
							num3 = 0;
						}
					}
					num = num4;
					num2++;
					while (num2 < int_1 && num == byte_0[num2])
					{
						num2++;
						if (++num3 >= num5)
						{
							break;
						}
					}
					if (num3 < num6)
					{
						class215_0.short_0[num] += (short)num3;
					}
					else if (num != 0)
					{
						class215_0.short_0[16]++;
					}
					else if (num3 <= 10)
					{
						class215_0.short_0[17]++;
					}
					else
					{
						class215_0.short_0[18]++;
					}
				}
			}

			public void method_8(Class215 class215_0)
			{
				int num = -1;
				int num2 = 0;
				while (num2 < int_1)
				{
					int num3 = 1;
					int num4 = byte_0[num2];
					int num5;
					int num6;
					if (num4 == 0)
					{
						num5 = 138;
						num6 = 3;
					}
					else
					{
						num5 = 6;
						num6 = 3;
						if (num != num4)
						{
							class215_0.method_1(num4);
							num3 = 0;
						}
					}
					num = num4;
					num2++;
					while (num2 < int_1 && num == byte_0[num2])
					{
						num2++;
						if (++num3 >= num5)
						{
							break;
						}
					}
					if (num3 < num6)
					{
						while (num3-- > 0)
						{
							class215_0.method_1(num);
						}
					}
					else if (num != 0)
					{
						class215_0.method_1(16);
						gclass550_0.gclass567_0.method_7(num3 - 3, 2);
					}
					else if (num3 <= 10)
					{
						class215_0.method_1(17);
						gclass550_0.gclass567_0.method_7(num3 - 3, 3);
					}
					else
					{
						class215_0.method_1(18);
						gclass550_0.gclass567_0.method_7(num3 - 11, 7);
					}
				}
			}

			private void method_9(int[] int_4)
			{
				byte_0 = new byte[short_0.Length];
				int num = int_4.Length / 2;
				int num2 = (num + 1) / 2;
				int num3 = 0;
				for (int i = 0; i < int_3; i++)
				{
					int_2[i] = 0;
				}
				int[] array = new int[num];
				array[num - 1] = 0;
				for (int i = num - 1; i >= 0; i--)
				{
					if (int_4[2 * i + 1] != -1)
					{
						int num4 = array[i] + 1;
						if (num4 > int_3)
						{
							num4 = int_3;
							num3++;
						}
						array[int_4[2 * i]] = (array[int_4[2 * i + 1]] = num4);
					}
					else
					{
						int num4 = array[i];
						int_2[num4 - 1]++;
						byte_0[int_4[2 * i]] = (byte)array[i];
					}
				}
				if (num3 == 0)
				{
					return;
				}
				int num5 = int_3 - 1;
				while (true)
				{
					if (int_2[--num5] != 0)
					{
						do
						{
							int_2[num5]--;
							int_2[++num5]++;
							num3 -= 1 << int_3 - 1 - num5;
						}
						while (num3 > 0 && num5 < int_3 - 1);
						if (num3 <= 0)
						{
							break;
						}
					}
				}
				int_2[int_3 - 1] += num3;
				int_2[int_3 - 2] -= num3;
				int num6 = 2 * num2;
				for (int num7 = int_3; num7 != 0; num7--)
				{
					int num8 = int_2[num7 - 1];
					while (num8 > 0)
					{
						int num9 = 2 * int_4[num6++];
						if (int_4[num9 + 1] == -1)
						{
							byte_0[int_4[num9]] = (byte)num7;
							num8--;
						}
					}
				}
			}
		}

		private const int int_0 = 16384;

		private const int int_1 = 286;

		private const int int_2 = 30;

		private const int int_3 = 19;

		private const int int_4 = 16;

		private const int int_5 = 17;

		private const int int_6 = 18;

		private const int int_7 = 256;

		private static readonly int[] int_8;

		private static readonly byte[] byte_0;

		private static short[] short_0;

		private static byte[] byte_1;

		private static short[] short_1;

		private static byte[] byte_2;

		public GClass567 gclass567_0;

		private Class215 class215_0;

		private Class215 class215_1;

		private Class215 class215_2;

		private short[] short_2;

		private byte[] byte_3;

		private int int_9;

		private int int_10;

		static GClass550()
		{
			int_8 = new int[19]
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
			byte_0 = new byte[16]
			{
				0,
				8,
				4,
				12,
				2,
				10,
				6,
				14,
				1,
				9,
				5,
				13,
				3,
				11,
				7,
				15
			};
			short_0 = new short[286];
			byte_1 = new byte[286];
			int num = 0;
			while (num < 144)
			{
				short_0[num] = smethod_0(48 + num << 8);
				byte_1[num++] = 8;
			}
			while (num < 256)
			{
				short_0[num] = smethod_0(256 + num << 7);
				byte_1[num++] = 9;
			}
			while (num < 280)
			{
				short_0[num] = smethod_0(-256 + num << 9);
				byte_1[num++] = 7;
			}
			while (num < 286)
			{
				short_0[num] = smethod_0(-88 + num << 8);
				byte_1[num++] = 8;
			}
			short_1 = new short[30];
			byte_2 = new byte[30];
			for (num = 0; num < 30; num++)
			{
				short_1[num] = smethod_0(num << 11);
				byte_2[num] = 5;
			}
		}

		public GClass550(GClass567 gclass567_1)
		{
			gclass567_0 = gclass567_1;
			class215_0 = new Class215(this, 286, 257, 15);
			class215_1 = new Class215(this, 30, 1, 15);
			class215_2 = new Class215(this, 19, 4, 7);
			short_2 = new short[16384];
			byte_3 = new byte[16384];
		}

		public void method_0()
		{
			int_9 = 0;
			int_10 = 0;
			class215_0.method_0();
			class215_1.method_0();
			class215_2.method_0();
		}

		public void method_1(int int_11)
		{
			class215_2.method_4();
			class215_0.method_4();
			class215_1.method_4();
			gclass567_0.method_7(class215_0.int_1 - 257, 5);
			gclass567_0.method_7(class215_1.int_1 - 1, 5);
			gclass567_0.method_7(int_11 - 4, 4);
			for (int i = 0; i < int_11; i++)
			{
				gclass567_0.method_7(class215_2.byte_0[int_8[i]], 3);
			}
			class215_0.method_8(class215_2);
			class215_1.method_8(class215_2);
		}

		public void method_2()
		{
			for (int i = 0; i < int_9; i++)
			{
				int num = byte_3[i] & 0xFF;
				int num2 = short_2[i];
				if (num2-- != 0)
				{
					int num3 = smethod_1(num);
					class215_0.method_1(num3);
					int num4 = (num3 - 261) / 4;
					if (num4 > 0 && num4 <= 5)
					{
						gclass567_0.method_7(num & ((1 << num4) - 1), num4);
					}
					int num5 = smethod_2(num2);
					class215_1.method_1(num5);
					num4 = num5 / 2 - 1;
					if (num4 > 0)
					{
						gclass567_0.method_7(num2 & ((1 << num4) - 1), num4);
					}
				}
				else
				{
					class215_0.method_1(num);
				}
			}
			class215_0.method_1(256);
		}

		public void method_3(byte[] byte_4, int int_11, int int_12, bool bool_0)
		{
			gclass567_0.method_7(bool_0 ? 1 : 0, 3);
			gclass567_0.method_6();
			gclass567_0.method_2(int_12);
			gclass567_0.method_2(~int_12);
			gclass567_0.method_4(byte_4, int_11, int_12);
			method_0();
		}

		public void method_4(byte[] byte_4, int int_11, int int_12, bool bool_0)
		{
			class215_0.short_0[256]++;
			class215_0.method_5();
			class215_1.method_5();
			class215_0.method_7(class215_2);
			class215_1.method_7(class215_2);
			class215_2.method_5();
			int num = 4;
			for (int num2 = 18; num2 > num; num2--)
			{
				if (class215_2.byte_0[int_8[num2]] > 0)
				{
					num = num2 + 1;
				}
			}
			int num3 = 14 + num * 3 + class215_2.method_6() + class215_0.method_6() + class215_1.method_6() + int_10;
			int num4 = int_10;
			for (int num2 = 0; num2 < 286; num2++)
			{
				num4 += class215_0.short_0[num2] * byte_1[num2];
			}
			for (int num2 = 0; num2 < 30; num2++)
			{
				num4 += class215_1.short_0[num2] * byte_2[num2];
			}
			if (num3 >= num4)
			{
				num3 = num4;
			}
			if (int_11 >= 0 && int_12 + 4 < num3 >> 3)
			{
				method_3(byte_4, int_11, int_12, bool_0);
			}
			else if (num3 == num4)
			{
				gclass567_0.method_7(2 + (bool_0 ? 1 : 0), 3);
				class215_0.method_3(short_0, byte_1);
				class215_1.method_3(short_1, byte_2);
				method_2();
				method_0();
			}
			else
			{
				gclass567_0.method_7(4 + (bool_0 ? 1 : 0), 3);
				method_1(num);
				method_2();
				method_0();
			}
		}

		public bool method_5()
		{
			return int_9 >= 16384;
		}

		public bool method_6(int int_11)
		{
			short_2[int_9] = 0;
			byte_3[int_9++] = (byte)int_11;
			class215_0.short_0[int_11]++;
			return method_5();
		}

		public bool method_7(int int_11, int int_12)
		{
			short_2[int_9] = (short)int_11;
			byte_3[int_9++] = (byte)(int_12 - 3);
			int num = smethod_1(int_12 - 3);
			class215_0.short_0[num]++;
			if (num >= 265 && num < 285)
			{
				int_10 += (num - 261) / 4;
			}
			int num2 = smethod_2(int_11 - 1);
			class215_1.short_0[num2]++;
			if (num2 >= 4)
			{
				int_10 += num2 / 2 - 1;
			}
			return method_5();
		}

		public static short smethod_0(int int_11)
		{
			return (short)((byte_0[int_11 & 0xF] << 12) | (byte_0[(int_11 >> 4) & 0xF] << 8) | (byte_0[(int_11 >> 8) & 0xF] << 4) | byte_0[int_11 >> 12]);
		}

		private static int smethod_1(int int_11)
		{
			if (int_11 == 255)
			{
				return 285;
			}
			int num = 257;
			while (int_11 >= 8)
			{
				num += 4;
				int_11 >>= 1;
			}
			return num + int_11;
		}

		private static int smethod_2(int int_11)
		{
			int num = 0;
			while (int_11 >= 4)
			{
				num += 2;
				int_11 >>= 1;
			}
			return num + int_11;
		}
	}
}
