using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass591
	{
		private const int int_0 = 32768;

		private const int int_1 = 32767;

		private byte[] byte_0 = new byte[32768];

		private int int_2;

		private int int_3;

		public void method_0(int int_4)
		{
			int num = 16;
			if (int_3++ == 32768)
			{
				throw new InvalidOperationException("Window full");
			}
			byte_0[int_2++] = (byte)int_4;
			int_2 &= 32767;
		}

		private void method_1(int int_4, int int_5, int int_6)
		{
			while (int_5-- > 0)
			{
				byte_0[int_2++] = byte_0[int_4++];
				int_2 &= 32767;
				int_4 &= 0x7FFF;
			}
		}

		public void method_2(int int_4, int int_5)
		{
			int num = 2;
			if ((int_3 += int_4) > 32768)
			{
				throw new InvalidOperationException("Window full");
			}
			int num2 = (int_2 - int_5) & 0x7FFF;
			int num3 = 32768 - int_4;
			if (num2 <= num3 && int_2 < num3)
			{
				if (int_4 <= int_5)
				{
					Array.Copy(byte_0, num2, byte_0, int_2, int_4);
					int_2 += int_4;
					return;
				}
				while (int_4-- > 0)
				{
					byte_0[int_2++] = byte_0[num2++];
				}
			}
			else
			{
				method_1(num2, int_4, int_5);
			}
		}

		public int method_3(GClass554 gclass554_0, int int_4)
		{
			int_4 = Math.Min(Math.Min(int_4, 32768 - int_3), gclass554_0.method_4());
			int num = 32768 - int_2;
			int num2;
			if (int_4 > num)
			{
				num2 = gclass554_0.method_7(byte_0, int_2, num);
				if (num2 == num)
				{
					num2 += gclass554_0.method_7(byte_0, 0, int_4 - num);
				}
			}
			else
			{
				num2 = gclass554_0.method_7(byte_0, int_2, int_4);
			}
			int_2 = ((int_2 + num2) & 0x7FFF);
			int_3 += num2;
			return num2;
		}

		public void method_4(byte[] byte_1, int int_4, int int_5)
		{
			int num = 17;
			if (byte_1 == null)
			{
				throw new ArgumentNullException("dictionary");
			}
			if (int_3 > 0)
			{
				throw new InvalidOperationException();
			}
			if (int_5 > 32768)
			{
				int_4 += int_5 - 32768;
				int_5 = 32768;
			}
			Array.Copy(byte_1, int_4, byte_0, 0, int_5);
			int_2 = (int_5 & 0x7FFF);
		}

		public int method_5()
		{
			return 32768 - int_3;
		}

		public int method_6()
		{
			return int_3;
		}

		public int method_7(byte[] byte_1, int int_4, int int_5)
		{
			int num = int_2;
			if (int_5 > int_3)
			{
				int_5 = int_3;
			}
			else
			{
				num = ((int_2 - int_3 + int_5) & 0x7FFF);
			}
			int num2 = int_5;
			int num3 = int_5 - num;
			if (num3 > 0)
			{
				Array.Copy(byte_0, 32768 - num3, byte_1, int_4, num3);
				int_4 += num3;
				int_5 = num;
			}
			Array.Copy(byte_0, num - int_5, byte_1, int_4, int_5);
			int_3 -= num2;
			if (int_3 < 0)
			{
				throw new InvalidOperationException();
			}
			return num2;
		}

		public void method_8()
		{
			int_2 = 0;
			int_3 = 0;
		}
	}
}
