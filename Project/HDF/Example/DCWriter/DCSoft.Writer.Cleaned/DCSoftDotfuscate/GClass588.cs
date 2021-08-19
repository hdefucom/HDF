using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass588
	{
		private const int int_0 = 15;

		private short[] short_0;

		public static GClass588 gclass588_0;

		public static GClass588 gclass588_1;

		static GClass588()
		{
			int num = 17;
			try
			{
				byte[] array = new byte[288];
				int num2 = 0;
				while (num2 < 144)
				{
					array[num2++] = 8;
				}
				while (num2 < 256)
				{
					array[num2++] = 9;
				}
				while (num2 < 280)
				{
					array[num2++] = 7;
				}
				while (num2 < 288)
				{
					array[num2++] = 8;
				}
				gclass588_0 = new GClass588(array);
				array = new byte[32];
				num2 = 0;
				while (num2 < 32)
				{
					array[num2++] = 5;
				}
				gclass588_1 = new GClass588(array);
			}
			catch (Exception)
			{
				throw new GException19("InflaterHuffmanTree: static tree length illegal");
			}
		}

		public GClass588(byte[] byte_0)
		{
			method_0(byte_0);
		}

		private void method_0(byte[] byte_0)
		{
			int[] array = new int[16];
			int[] array2 = new int[16];
			for (int i = 0; i < byte_0.Length; i++)
			{
				int num = byte_0[i];
				if (num > 0)
				{
					array[num]++;
				}
			}
			int num2 = 0;
			int num3 = 512;
			for (int num = 1; num <= 15; num++)
			{
				array2[num] = num2;
				num2 += array[num] << 16 - num;
				if (num >= 10)
				{
					int num4 = array2[num] & 0x1FF80;
					int num5 = num2 & 0x1FF80;
					num3 += num5 - num4 >> 16 - num;
				}
			}
			short_0 = new short[num3];
			int num6 = 512;
			for (int num = 15; num >= 10; num--)
			{
				int num5 = num2 & 0x1FF80;
				num2 -= array[num] << 16 - num;
				int num4 = num2 & 0x1FF80;
				for (int i = num4; i < num5; i += 128)
				{
					short_0[GClass550.smethod_0(i)] = (short)((-num6 << 4) | num);
					num6 += 1 << num - 9;
				}
			}
			for (int i = 0; i < byte_0.Length; i++)
			{
				int num = byte_0[i];
				if (num == 0)
				{
					continue;
				}
				num2 = array2[num];
				int num7 = GClass550.smethod_0(num2);
				if (num <= 9)
				{
					do
					{
						short_0[num7] = (short)((i << 4) | num);
						num7 += 1 << num;
					}
					while (num7 < 512);
				}
				else
				{
					int num8 = short_0[num7 & 0x1FF];
					int num9 = 1 << (num8 & 0xF);
					num8 = -(num8 >> 4);
					do
					{
						short_0[num8 | (num7 >> 9)] = (short)((i << 4) | num);
						num7 += 1 << num;
					}
					while (num7 < num9);
				}
				array2[num] = num2 + (1 << 16 - num);
			}
		}

		public int method_1(GClass554 gclass554_0)
		{
			int num4;
			int num;
			int num2;
			if ((num = gclass554_0.method_0(9)) >= 0)
			{
				if ((num2 = short_0[num]) >= 0)
				{
					gclass554_0.method_1(num2 & 0xF);
					return num2 >> 4;
				}
				int num3 = -(num2 >> 4);
				int int_ = num2 & 0xF;
				if ((num = gclass554_0.method_0(int_)) >= 0)
				{
					num2 = short_0[num3 | (num >> 9)];
					gclass554_0.method_1(num2 & 0xF);
					return num2 >> 4;
				}
				num4 = gclass554_0.method_3();
				num = gclass554_0.method_0(num4);
				num2 = short_0[num3 | (num >> 9)];
				if ((num2 & 0xF) <= num4)
				{
					gclass554_0.method_1(num2 & 0xF);
					return num2 >> 4;
				}
				return -1;
			}
			num4 = gclass554_0.method_3();
			num = gclass554_0.method_0(num4);
			num2 = short_0[num];
			if (num2 >= 0 && (num2 & 0xF) <= num4)
			{
				gclass554_0.method_1(num2 & 0xF);
				return num2 >> 4;
			}
			return -1;
		}
	}
}
