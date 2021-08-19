using System;
using System.IO;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GStream10 : Stream
	{
		[ComVisible(false)]
		private struct Struct80
		{
			public int int_0;

			public int int_1;

			public int int_2;
		}

		private const int int_0 = 2097152;

		private const int int_1 = -2097153;

		private const int int_2 = 15;

		private const int int_3 = 0;

		private const int int_4 = 20;

		private const int int_5 = 10;

		private const int int_6 = 1000;

		private readonly int[] int_7 = new int[14]
		{
			1,
			4,
			13,
			40,
			121,
			364,
			1093,
			3280,
			9841,
			29524,
			88573,
			265720,
			797161,
			2391484
		};

		private bool bool_0 = true;

		private int int_8;

		private int int_9;

		private int int_10;

		private bool bool_1;

		private int int_11;

		private int int_12;

		private int int_13;

		private GInterface25 ginterface25_0 = new GClass579();

		private bool[] bool_2 = new bool[256];

		private int int_14;

		private char[] char_0 = new char[256];

		private char[] char_1 = new char[256];

		private char[] char_2 = new char[18002];

		private char[] char_3 = new char[18002];

		private byte[] byte_0;

		private int[] int_15;

		private int[] int_16;

		private short[] short_0;

		private int[] int_17;

		private int int_18;

		private int[] int_19 = new int[258];

		private int int_20;

		private int int_21;

		private int int_22;

		private bool bool_3;

		private int int_23;

		private int int_24 = -1;

		private int int_25;

		private uint uint_0;

		private uint uint_1;

		private int int_26;

		private Stream stream_0;

		private bool bool_4;

		public override bool CanRead => false;

		public override bool CanSeek => false;

		public override bool CanWrite => stream_0.CanWrite;

		public override long Length => stream_0.Length;

		public override long Position
		{
			get
			{
				return stream_0.Position;
			}
			set
			{
				throw new NotSupportedException("BZip2OutputStream position cannot be set");
			}
		}

		public GStream10(Stream stream_1)
			: this(stream_1, 9)
		{
		}

		public GStream10(Stream stream_1, int int_27)
		{
			method_9(stream_1);
			int_20 = 50;
			if (int_27 > 9)
			{
				int_27 = 9;
			}
			if (int_27 < 1)
			{
				int_27 = 1;
			}
			int_10 = int_27;
			method_24();
			method_5();
			method_6();
		}

		~GStream10()
		{
			Dispose(disposing: false);
		}

		public bool method_0()
		{
			return bool_0;
		}

		public void method_1(bool bool_5)
		{
			bool_0 = bool_5;
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotSupportedException("BZip2OutputStream Seek not supported");
		}

		public override void SetLength(long value)
		{
			throw new NotSupportedException("BZip2OutputStream SetLength not supported");
		}

		public override int ReadByte()
		{
			throw new NotSupportedException("BZip2OutputStream ReadByte not supported");
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			throw new NotSupportedException("BZip2OutputStream Read not supported");
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			int num = 19;
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (offset < 0)
			{
				throw new ArgumentOutOfRangeException("offset");
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			if (buffer.Length - offset < count)
			{
				throw new ArgumentException("Offset/count out of range");
			}
			for (int i = 0; i < count; i++)
			{
				WriteByte(buffer[offset + i]);
			}
		}

		public override void WriteByte(byte value)
		{
			int num = (256 + value) % 256;
			if (int_24 != -1)
			{
				if (int_24 == num)
				{
					int_25++;
					if (int_25 > 254)
					{
						method_3();
						int_24 = -1;
						int_25 = 0;
					}
				}
				else
				{
					method_3();
					int_25 = 1;
					int_24 = num;
				}
			}
			else
			{
				int_24 = num;
				int_25++;
			}
		}

		public override void Close()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		private void method_2()
		{
			int_14 = 0;
			for (int i = 0; i < 256; i++)
			{
				if (bool_2[i])
				{
					char_0[int_14] = (char)i;
					char_1[i] = (char)int_14;
					int_14++;
				}
			}
		}

		private void method_3()
		{
			if (int_8 < int_26)
			{
				bool_2[int_24] = true;
				for (int i = 0; i < int_25; i++)
				{
					ginterface25_0.imethod_2(int_24);
				}
				switch (int_25)
				{
				default:
					bool_2[int_25 - 4] = true;
					int_8++;
					byte_0[int_8 + 1] = (byte)int_24;
					int_8++;
					byte_0[int_8 + 1] = (byte)int_24;
					int_8++;
					byte_0[int_8 + 1] = (byte)int_24;
					int_8++;
					byte_0[int_8 + 1] = (byte)int_24;
					int_8++;
					byte_0[int_8 + 1] = (byte)(int_25 - 4);
					break;
				case 1:
					int_8++;
					byte_0[int_8 + 1] = (byte)int_24;
					break;
				case 2:
					int_8++;
					byte_0[int_8 + 1] = (byte)int_24;
					int_8++;
					byte_0[int_8 + 1] = (byte)int_24;
					break;
				case 3:
					int_8++;
					byte_0[int_8 + 1] = (byte)int_24;
					int_8++;
					byte_0[int_8 + 1] = (byte)int_24;
					int_8++;
					byte_0[int_8 + 1] = (byte)int_24;
					break;
				}
			}
			else
			{
				method_7();
				method_6();
				method_3();
			}
		}

		public int method_4()
		{
			return int_11;
		}

		protected override void Dispose(bool disposing)
		{
			try
			{
				base.Dispose(disposing);
				if (!bool_4)
				{
					bool_4 = true;
					if (int_25 > 0)
					{
						method_3();
					}
					int_24 = -1;
					method_7();
					method_8();
					Flush();
				}
			}
			finally
			{
				if (disposing && method_0())
				{
					stream_0.Close();
				}
			}
		}

		public override void Flush()
		{
			stream_0.Flush();
		}

		private void method_5()
		{
			int_11 = 0;
			int_23 = 0;
			method_12(66);
			method_12(90);
			method_12(104);
			method_12(48 + int_10);
			uint_1 = 0u;
		}

		private void method_6()
		{
			ginterface25_0.imethod_1();
			int_8 = -1;
			for (int i = 0; i < 256; i++)
			{
				bool_2[i] = false;
			}
			int_26 = 100000 * int_10 - 20;
		}

		private void method_7()
		{
			if (int_8 >= 0)
			{
				uint_0 = (uint)ginterface25_0.imethod_0();
				uint_1 = ((uint_1 << 1) | (uint_1 >> 31));
				uint_1 ^= uint_0;
				method_22();
				method_12(49);
				method_12(65);
				method_12(89);
				method_12(38);
				method_12(83);
				method_12(89);
				method_13((int)uint_0);
				if (bool_1)
				{
					method_11(1, 1);
					int_23++;
				}
				else
				{
					method_11(1, 0);
				}
				method_16();
			}
		}

		private void method_8()
		{
			method_12(23);
			method_12(114);
			method_12(69);
			method_12(56);
			method_12(80);
			method_12(144);
			method_13((int)uint_1);
			method_10();
		}

		private void method_9(Stream stream_1)
		{
			stream_0 = stream_1;
			int_13 = 0;
			int_12 = 0;
			int_11 = 0;
		}

		private void method_10()
		{
			while (int_13 > 0)
			{
				int num = int_12 >> 24;
				stream_0.WriteByte((byte)num);
				int_12 <<= 8;
				int_13 -= 8;
				int_11++;
			}
		}

		private void method_11(int int_27, int int_28)
		{
			while (int_13 >= 8)
			{
				int num = int_12 >> 24;
				stream_0.WriteByte((byte)num);
				int_12 <<= 8;
				int_13 -= 8;
				int_11++;
			}
			int_12 |= int_28 << 32 - int_13 - int_27;
			int_13 += int_27;
		}

		private void method_12(int int_27)
		{
			method_11(8, int_27);
		}

		private void method_13(int int_27)
		{
			method_11(8, (int_27 >> 24) & 0xFF);
			method_11(8, (int_27 >> 16) & 0xFF);
			method_11(8, (int_27 >> 8) & 0xFF);
			method_11(8, int_27 & 0xFF);
		}

		private void method_14(int int_27, int int_28)
		{
			method_11(int_27, int_28);
		}

		private void method_15()
		{
			char[][] array = new char[6][];
			for (int i = 0; i < 6; i++)
			{
				array[i] = new char[258];
			}
			int num = 0;
			int num2 = int_14 + 2;
			for (int j = 0; j < 6; j++)
			{
				for (int k = 0; k < num2; k++)
				{
					array[j][k] = '\u000f';
				}
			}
			if (int_18 <= 0)
			{
				smethod_0();
			}
			int num3 = (int_18 < 200) ? 2 : ((int_18 < 600) ? 3 : ((int_18 < 1200) ? 4 : ((int_18 >= 2400) ? 6 : 5)));
			int num4 = num3;
			int num5 = int_18;
			int num6 = 0;
			while (num4 > 0)
			{
				int num7 = num5 / num4;
				int l = 0;
				int num8;
				for (num8 = num6 - 1; l < num7; l += int_19[num8])
				{
					if (num8 >= num2 - 1)
					{
						break;
					}
					num8++;
				}
				if (num8 > num6 && num4 != num3 && num4 != 1 && (num3 - num4) % 2 == 1)
				{
					l -= int_19[num8];
					num8--;
				}
				for (int k = 0; k < num2; k++)
				{
					if (k >= num6 && k <= num8)
					{
						array[num4 - 1][k] = '\0';
					}
					else
					{
						array[num4 - 1][k] = '\u000f';
					}
				}
				num4--;
				num6 = num8 + 1;
				num5 -= l;
			}
			int[][] array2 = new int[6][];
			for (int i = 0; i < 6; i++)
			{
				array2[i] = new int[258];
			}
			int[] array3 = new int[6];
			short[] array4 = new short[6];
			for (int m = 0; m < 4; m++)
			{
				for (int j = 0; j < num3; j++)
				{
					array3[j] = 0;
				}
				for (int j = 0; j < num3; j++)
				{
					for (int k = 0; k < num2; k++)
					{
						array2[j][k] = 0;
					}
				}
				num = 0;
				int num9 = 0;
				num6 = 0;
				while (num6 < int_18)
				{
					int num8 = num6 + 50 - 1;
					if (num8 >= int_18)
					{
						num8 = int_18 - 1;
					}
					for (int j = 0; j < num3; j++)
					{
						array4[j] = 0;
					}
					if (num3 == 6)
					{
						short num10 = 0;
						short num11 = 0;
						short num12 = 0;
						short num13 = 0;
						short num14 = 0;
						short num15 = 0;
						for (int i = num6; i <= num8; i++)
						{
							short num16 = short_0[i];
							num15 = (short)(num15 + (short)array[0][num16]);
							num14 = (short)(num14 + (short)array[1][num16]);
							num13 = (short)(num13 + (short)array[2][num16]);
							num12 = (short)(num12 + (short)array[3][num16]);
							num11 = (short)(num11 + (short)array[4][num16]);
							num10 = (short)(num10 + (short)array[5][num16]);
						}
						array4[0] = num15;
						array4[1] = num14;
						array4[2] = num13;
						array4[3] = num12;
						array4[4] = num11;
						array4[5] = num10;
					}
					else
					{
						for (int i = num6; i <= num8; i++)
						{
							short num16 = short_0[i];
							for (int j = 0; j < num3; j++)
							{
								array4[j] += (short)array[j][num16];
							}
						}
					}
					int num17 = 999999999;
					int num18 = -1;
					for (int j = 0; j < num3; j++)
					{
						if (array4[j] < num17)
						{
							num17 = array4[j];
							num18 = j;
						}
					}
					num9 += num17;
					array3[num18]++;
					char_2[num] = (char)num18;
					num++;
					for (int i = num6; i <= num8; i++)
					{
						array2[num18][short_0[i]]++;
					}
					num6 = num8 + 1;
				}
				for (int j = 0; j < num3; j++)
				{
					smethod_1(array[j], array2[j], num2, 20);
				}
			}
			array2 = null;
			array3 = null;
			array4 = null;
			if (num3 >= 8)
			{
				smethod_0();
			}
			if (num >= 32768 || num > 18002)
			{
				smethod_0();
			}
			char[] array5 = new char[6];
			for (int i = 0; i < num3; i++)
			{
				array5[i] = (char)i;
			}
			for (int i = 0; i < num; i++)
			{
				char c = char_2[i];
				int num19 = 0;
				char c2 = array5[0];
				while (c != c2)
				{
					num19++;
					char c3 = c2;
					c2 = array5[num19];
					array5[num19] = c3;
				}
				array5[0] = c2;
				char_3[i] = (char)num19;
			}
			int[][] array6 = new int[6][];
			for (int i = 0; i < 6; i++)
			{
				array6[i] = new int[258];
			}
			for (int j = 0; j < num3; j++)
			{
				int num20 = 32;
				int num21 = 0;
				for (int i = 0; i < num2; i++)
				{
					if (array[j][i] > num21)
					{
						num21 = array[j][i];
					}
					if (array[j][i] < num20)
					{
						num20 = array[j][i];
					}
				}
				if (num21 > 20)
				{
					smethod_0();
				}
				if (num20 < 1)
				{
					smethod_0();
				}
				smethod_2(array6[j], array[j], num20, num21, num2);
			}
			bool[] array7 = new bool[16];
			for (int i = 0; i < 16; i++)
			{
				array7[i] = false;
				for (int num19 = 0; num19 < 16; num19++)
				{
					if (bool_2[i * 16 + num19])
					{
						array7[i] = true;
					}
				}
			}
			for (int i = 0; i < 16; i++)
			{
				if (array7[i])
				{
					method_11(1, 1);
				}
				else
				{
					method_11(1, 0);
				}
			}
			for (int i = 0; i < 16; i++)
			{
				if (!array7[i])
				{
					continue;
				}
				for (int num19 = 0; num19 < 16; num19++)
				{
					if (bool_2[i * 16 + num19])
					{
						method_11(1, 1);
					}
					else
					{
						method_11(1, 0);
					}
				}
			}
			method_11(3, num3);
			method_11(15, num);
			for (int i = 0; i < num; i++)
			{
				for (int num19 = 0; num19 < char_3[i]; num19++)
				{
					method_11(1, 1);
				}
				method_11(1, 0);
			}
			for (int j = 0; j < num3; j++)
			{
				int n = array[j][0];
				method_11(5, n);
				for (int i = 0; i < num2; i++)
				{
					for (; n < array[j][i]; n++)
					{
						method_11(2, 2);
					}
					while (n > array[j][i])
					{
						method_11(2, 3);
						n--;
					}
					method_11(1, 0);
				}
			}
			int num22 = 0;
			num6 = 0;
			while (num6 < int_18)
			{
				int num8 = num6 + 50 - 1;
				if (num8 >= int_18)
				{
					num8 = int_18 - 1;
				}
				for (int i = num6; i <= num8; i++)
				{
					method_11(array[char_2[num22]][short_0[i]], array6[char_2[num22]][short_0[i]]);
				}
				num6 = num8 + 1;
				num22++;
			}
			if (num22 != num)
			{
				smethod_0();
			}
		}

		private void method_16()
		{
			method_14(24, int_9);
			method_25();
			method_15();
		}

		private void method_17(int int_27, int int_28, int int_29)
		{
			int num = int_28 - int_27 + 1;
			if (num < 2)
			{
				return;
			}
			int i;
			for (i = 0; int_7[i] < num; i++)
			{
			}
			for (i--; i >= 0; i--)
			{
				int num2 = int_7[i];
				int num3 = int_27 + num2;
				while (num3 <= int_28)
				{
					int num4 = int_16[num3];
					int num5 = num3;
					while (method_23(int_16[num5 - num2] + int_29, num4 + int_29))
					{
						int_16[num5] = int_16[num5 - num2];
						num5 -= num2;
						if (num5 <= int_27 + num2 - 1)
						{
							break;
						}
					}
					int_16[num5] = num4;
					num3++;
					if (num3 > int_28)
					{
						break;
					}
					num4 = int_16[num3];
					num5 = num3;
					while (method_23(int_16[num5 - num2] + int_29, num4 + int_29))
					{
						int_16[num5] = int_16[num5 - num2];
						num5 -= num2;
						if (num5 <= int_27 + num2 - 1)
						{
							break;
						}
					}
					int_16[num5] = num4;
					num3++;
					if (num3 > int_28)
					{
						break;
					}
					num4 = int_16[num3];
					num5 = num3;
					while (method_23(int_16[num5 - num2] + int_29, num4 + int_29))
					{
						int_16[num5] = int_16[num5 - num2];
						num5 -= num2;
						if (num5 <= int_27 + num2 - 1)
						{
							break;
						}
					}
					int_16[num5] = num4;
					num3++;
					if (int_21 > int_22 && bool_3)
					{
						return;
					}
				}
			}
		}

		private void method_18(int int_27, int int_28, int int_29)
		{
			int num = 0;
			while (int_29 > 0)
			{
				num = int_16[int_27];
				int_16[int_27] = int_16[int_28];
				int_16[int_28] = num;
				int_27++;
				int_28++;
				int_29--;
			}
		}

		private void method_19(int int_27, int int_28, int int_29)
		{
			Struct80[] array = new Struct80[1000];
			int num = 0;
			array[0].int_0 = int_27;
			array[0].int_1 = int_28;
			array[0].int_2 = int_29;
			num = 1;
			while (num > 0)
			{
				if (num >= 1000)
				{
					smethod_0();
				}
				num--;
				int num2 = array[num].int_0;
				int num3 = array[num].int_1;
				int num4 = array[num].int_2;
				if (num3 - num2 < 20 || num4 > 10)
				{
					method_17(num2, num3, num4);
					if (int_21 > int_22 && bool_3)
					{
						break;
					}
					continue;
				}
				int num5 = smethod_3(byte_0[int_16[num2] + num4 + 1], byte_0[int_16[num3] + num4 + 1], byte_0[int_16[num2 + num3 >> 1] + num4 + 1]);
				int num6;
				int num7 = num6 = num2;
				int num8;
				int num9 = num8 = num3;
				int num10;
				while (true)
				{
					int num11;
					if (num7 <= num9)
					{
						num10 = byte_0[int_16[num7] + num4 + 1] - num5;
						if (num10 == 0)
						{
							num11 = int_16[num7];
							int_16[num7] = int_16[num6];
							int_16[num6] = num11;
							num6++;
							num7++;
							continue;
						}
						if (num10 <= 0)
						{
							num7++;
							continue;
						}
					}
					while (num7 <= num9)
					{
						num10 = byte_0[int_16[num9] + num4 + 1] - num5;
						if (num10 == 0)
						{
							num11 = int_16[num9];
							int_16[num9] = int_16[num8];
							int_16[num8] = num11;
							num8--;
							num9--;
						}
						else
						{
							if (num10 < 0)
							{
								break;
							}
							num9--;
						}
					}
					if (num7 > num9)
					{
						break;
					}
					num11 = int_16[num7];
					int_16[num7] = int_16[num9];
					int_16[num9] = num11;
					num7++;
					num9--;
				}
				if (num8 < num6)
				{
					array[num].int_0 = num2;
					array[num].int_1 = num3;
					array[num].int_2 = num4 + 1;
					num++;
					continue;
				}
				num10 = ((num6 - num2 < num7 - num6) ? (num6 - num2) : (num7 - num6));
				method_18(num2, num7 - num10, num10);
				int num12 = (num3 - num8 < num8 - num9) ? (num3 - num8) : (num8 - num9);
				method_18(num7, num3 - num12 + 1, num12);
				num10 = num2 + num7 - num6 - 1;
				num12 = num3 - (num8 - num9) + 1;
				array[num].int_0 = num2;
				array[num].int_1 = num10;
				array[num].int_2 = num4;
				num++;
				array[num].int_0 = num10 + 1;
				array[num].int_1 = num12 - 1;
				array[num].int_2 = num4 + 1;
				num++;
				array[num].int_0 = num12;
				array[num].int_1 = num3;
				array[num].int_2 = num4;
				num++;
			}
		}

		private void method_20()
		{
			int[] array = new int[256];
			int[] array2 = new int[256];
			bool[] array3 = new bool[256];
			for (int i = 0; i < 20; i++)
			{
				byte_0[int_8 + i + 2] = byte_0[i % (int_8 + 1) + 1];
			}
			for (int i = 0; i <= int_8 + 20; i++)
			{
				int_15[i] = 0;
			}
			byte_0[0] = byte_0[int_8 + 1];
			if (int_8 < 4000)
			{
				for (int i = 0; i <= int_8; i++)
				{
					int_16[i] = i;
				}
				bool_3 = false;
				int_22 = 0;
				int_21 = 0;
				method_17(0, int_8, 0);
				return;
			}
			int num = 0;
			for (int i = 0; i <= 255; i++)
			{
				array3[i] = false;
			}
			for (int i = 0; i <= 65536; i++)
			{
				int_17[i] = 0;
			}
			int num2 = byte_0[0];
			for (int i = 0; i <= int_8; i++)
			{
				int num3 = byte_0[i + 1];
				int_17[(num2 << 8) + num3]++;
				num2 = num3;
			}
			for (int i = 1; i <= 65536; i++)
			{
				int_17[i] += int_17[i - 1];
			}
			num2 = byte_0[1];
			int num4;
			for (int i = 0; i < int_8; i++)
			{
				int num3 = byte_0[i + 2];
				num4 = (num2 << 8) + num3;
				num2 = num3;
				int_17[num4]--;
				int_16[int_17[num4]] = i;
			}
			num4 = (byte_0[int_8 + 1] << 8) + byte_0[1];
			int_17[num4]--;
			int_16[int_17[num4]] = int_8;
			for (int i = 0; i <= 255; i++)
			{
				array[i] = i;
			}
			int num5 = 1;
			do
			{
				num5 = 3 * num5 + 1;
			}
			while (num5 <= 256);
			do
			{
				num5 /= 3;
				for (int i = num5; i <= 255; i++)
				{
					int num6 = array[i];
					num4 = i;
					while (int_17[array[num4 - num5] + 1 << 8] - int_17[array[num4 - num5] << 8] > int_17[num6 + 1 << 8] - int_17[num6 << 8])
					{
						array[num4] = array[num4 - num5];
						num4 -= num5;
						if (num4 <= num5 - 1)
						{
							break;
						}
					}
					array[num4] = num6;
				}
			}
			while (num5 != 1);
			for (int i = 0; i <= 255; i++)
			{
				int num7 = array[i];
				for (num4 = 0; num4 <= 255; num4++)
				{
					int num8 = (num7 << 8) + num4;
					if ((int_17[num8] & 0x200000) == 2097152)
					{
						continue;
					}
					int num9 = int_17[num8] & -2097153;
					int num10 = (int_17[num8 + 1] & -2097153) - 1;
					if (num10 > num9)
					{
						method_19(num9, num10, 2);
						num += num10 - num9 + 1;
						if (int_21 > int_22 && bool_3)
						{
							return;
						}
					}
					int_17[num8] |= 2097152;
				}
				array3[num7] = true;
				if (i < 255)
				{
					int num11 = int_17[num7 << 8] & -2097153;
					int num12 = (int_17[num7 + 1 << 8] & -2097153) - num11;
					int j;
					for (j = 0; num12 >> j > 65534; j++)
					{
					}
					for (num4 = 0; num4 < num12; num4++)
					{
						int num13 = int_16[num11 + num4];
						int num14 = num4 >> j;
						int_15[num13] = num14;
						if (num13 < 20)
						{
							int_15[num13 + int_8 + 1] = num14;
						}
					}
					if (num12 - 1 >> j > 65535)
					{
						smethod_0();
					}
				}
				for (num4 = 0; num4 <= 255; num4++)
				{
					array2[num4] = (int_17[(num4 << 8) + num7] & -2097153);
				}
				for (num4 = (int_17[num7 << 8] & -2097153); num4 < (int_17[num7 + 1 << 8] & -2097153); num4++)
				{
					num2 = byte_0[int_16[num4]];
					if (!array3[num2])
					{
						int_16[array2[num2]] = ((int_16[num4] == 0) ? int_8 : (int_16[num4] - 1));
						array2[num2]++;
					}
				}
				for (num4 = 0; num4 <= 255; num4++)
				{
					int_17[(num4 << 8) + num7] |= 2097152;
				}
			}
		}

		private void method_21()
		{
			int num = 0;
			int num2 = 0;
			for (int i = 0; i < 256; i++)
			{
				bool_2[i] = false;
			}
			for (int i = 0; i <= int_8; i++)
			{
				if (num == 0)
				{
					num = Class220.int_10[num2];
					num2++;
					if (num2 == 512)
					{
						num2 = 0;
					}
				}
				num--;
				byte_0[i + 1] ^= (byte)((num == 1) ? 1 : 0);
				byte_0[i + 1] &= byte.MaxValue;
				bool_2[byte_0[i + 1]] = true;
			}
		}

		private void method_22()
		{
			int_22 = int_20 * int_8;
			int_21 = 0;
			bool_1 = false;
			bool_3 = true;
			method_20();
			if (int_21 > int_22 && bool_3)
			{
				method_21();
				int_21 = 0;
				int_22 = 0;
				bool_1 = true;
				bool_3 = false;
				method_20();
			}
			int_9 = -1;
			for (int i = 0; i <= int_8; i++)
			{
				if (int_16[i] == 0)
				{
					int_9 = i;
					break;
				}
			}
			if (int_9 == -1)
			{
				smethod_0();
			}
		}

		private bool method_23(int int_27, int int_28)
		{
			byte b = byte_0[int_27 + 1];
			byte b2 = byte_0[int_28 + 1];
			if (b != b2)
			{
				return b > b2;
			}
			int_27++;
			int_28++;
			b = byte_0[int_27 + 1];
			b2 = byte_0[int_28 + 1];
			if (b != b2)
			{
				return b > b2;
			}
			int_27++;
			int_28++;
			b = byte_0[int_27 + 1];
			b2 = byte_0[int_28 + 1];
			if (b != b2)
			{
				return b > b2;
			}
			int_27++;
			int_28++;
			b = byte_0[int_27 + 1];
			b2 = byte_0[int_28 + 1];
			if (b != b2)
			{
				return b > b2;
			}
			int_27++;
			int_28++;
			b = byte_0[int_27 + 1];
			b2 = byte_0[int_28 + 1];
			if (b != b2)
			{
				return b > b2;
			}
			int_27++;
			int_28++;
			b = byte_0[int_27 + 1];
			b2 = byte_0[int_28 + 1];
			if (b != b2)
			{
				return b > b2;
			}
			int_27++;
			int_28++;
			int num = int_8 + 1;
			do
			{
				b = byte_0[int_27 + 1];
				b2 = byte_0[int_28 + 1];
				if (b == b2)
				{
					int num2 = int_15[int_27];
					int num3 = int_15[int_28];
					if (num2 == num3)
					{
						int_27++;
						int_28++;
						b = byte_0[int_27 + 1];
						b2 = byte_0[int_28 + 1];
						if (b == b2)
						{
							num2 = int_15[int_27];
							num3 = int_15[int_28];
							if (num2 == num3)
							{
								int_27++;
								int_28++;
								b = byte_0[int_27 + 1];
								b2 = byte_0[int_28 + 1];
								if (b == b2)
								{
									num2 = int_15[int_27];
									num3 = int_15[int_28];
									if (num2 == num3)
									{
										int_27++;
										int_28++;
										b = byte_0[int_27 + 1];
										b2 = byte_0[int_28 + 1];
										if (b == b2)
										{
											num2 = int_15[int_27];
											num3 = int_15[int_28];
											if (num2 == num3)
											{
												int_27++;
												int_28++;
												if (int_27 > int_8)
												{
													int_27 -= int_8;
													int_27--;
												}
												if (int_28 > int_8)
												{
													int_28 -= int_8;
													int_28--;
												}
												num -= 4;
												int_21++;
												continue;
											}
											return num2 > num3;
										}
										return b > b2;
									}
									return num2 > num3;
								}
								return b > b2;
							}
							return num2 > num3;
						}
						return b > b2;
					}
					return num2 > num3;
				}
				return b > b2;
			}
			while (num >= 0);
			return false;
		}

		private void method_24()
		{
			int num = 100000 * int_10;
			byte_0 = new byte[num + 1 + 20];
			int_15 = new int[num + 20];
			int_16 = new int[num];
			int_17 = new int[65537];
			if (byte_0 != null && int_15 != null && int_16 != null && int_17 != null)
			{
			}
			short_0 = new short[2 * num];
		}

		private void method_25()
		{
			char[] array = new char[256];
			method_2();
			int num = int_14 + 1;
			for (int i = 0; i <= num; i++)
			{
				int_19[i] = 0;
			}
			int num2 = 0;
			int num3 = 0;
			for (int i = 0; i < int_14; i++)
			{
				array[i] = (char)i;
			}
			for (int i = 0; i <= int_8; i++)
			{
				char c = char_1[byte_0[int_16[i]]];
				int num4 = 0;
				char c2 = array[0];
				while (c != c2)
				{
					num4++;
					char c3 = c2;
					c2 = array[num4];
					array[num4] = c3;
				}
				array[0] = c2;
				if (num4 == 0)
				{
					num3++;
					continue;
				}
				if (num3 > 0)
				{
					num3--;
					while (true)
					{
						switch (num3 % 2)
						{
						case 1:
							short_0[num2] = 1;
							num2++;
							int_19[1]++;
							break;
						case 0:
							short_0[num2] = 0;
							num2++;
							int_19[0]++;
							break;
						}
						if (num3 < 2)
						{
							break;
						}
						num3 = (num3 - 2) / 2;
					}
					num3 = 0;
				}
				short_0[num2] = (short)(num4 + 1);
				num2++;
				int_19[num4 + 1]++;
			}
			if (num3 > 0)
			{
				num3--;
				while (true)
				{
					switch (num3 % 2)
					{
					case 1:
						short_0[num2] = 1;
						num2++;
						int_19[1]++;
						break;
					case 0:
						short_0[num2] = 0;
						num2++;
						int_19[0]++;
						break;
					}
					if (num3 < 2)
					{
						break;
					}
					num3 = (num3 - 2) / 2;
				}
			}
			short_0[num2] = (short)num;
			num2++;
			int_19[num]++;
			int_18 = num2;
		}

		private static void smethod_0()
		{
			throw new GException22("BZip2 output stream panic");
		}

		private static void smethod_1(char[] char_4, int[] int_27, int int_28, int int_29)
		{
			int[] array = new int[260];
			int[] array2 = new int[516];
			int[] array3 = new int[516];
			for (int i = 0; i < int_28; i++)
			{
				array2[i + 1] = ((int_27[i] == 0) ? 1 : int_27[i]) << 8;
			}
			while (true)
			{
				int num = int_28;
				int num2 = 0;
				array[0] = 0;
				array2[0] = 0;
				array3[0] = -2;
				for (int i = 1; i <= int_28; i++)
				{
					array3[i] = -1;
					num2++;
					array[num2] = i;
					int num3 = num2;
					int num4 = array[num3];
					while (array2[num4] < array2[array[num3 >> 1]])
					{
						array[num3] = array[num3 >> 1];
						num3 >>= 1;
					}
					array[num3] = num4;
				}
				if (num2 >= 260)
				{
					smethod_0();
				}
				while (num2 > 1)
				{
					int num5 = array[1];
					array[1] = array[num2];
					num2--;
					int num3 = 1;
					int num6 = 0;
					int num4 = array[1];
					while (true)
					{
						num6 = num3 << 1;
						if (num6 > num2)
						{
							break;
						}
						if (num6 < num2 && array2[array[num6 + 1]] < array2[array[num6]])
						{
							num6++;
						}
						if (array2[num4] < array2[array[num6]])
						{
							break;
						}
						array[num3] = array[num6];
						num3 = num6;
					}
					array[num3] = num4;
					int num7 = array[1];
					array[1] = array[num2];
					num2--;
					num3 = 1;
					num6 = 0;
					num4 = array[1];
					while (true)
					{
						num6 = num3 << 1;
						if (num6 > num2)
						{
							break;
						}
						if (num6 < num2 && array2[array[num6 + 1]] < array2[array[num6]])
						{
							num6++;
						}
						if (array2[num4] < array2[array[num6]])
						{
							break;
						}
						array[num3] = array[num6];
						num3 = num6;
					}
					array[num3] = num4;
					num++;
					array3[num5] = (array3[num7] = num);
					array2[num] = ((int)((array2[num5] & 0xFFFFFF00) + (array2[num7] & 0xFFFFFF00)) | (1 + (((array2[num5] & 0xFF) > (array2[num7] & 0xFF)) ? (array2[num5] & 0xFF) : (array2[num7] & 0xFF))));
					array3[num] = -1;
					num2++;
					array[num2] = num;
					num3 = num2;
					num4 = array[num3];
					while (array2[num4] < array2[array[num3 >> 1]])
					{
						array[num3] = array[num3 >> 1];
						num3 >>= 1;
					}
					array[num3] = num4;
				}
				if (num >= 516)
				{
					smethod_0();
				}
				bool flag = false;
				for (int i = 1; i <= int_28; i++)
				{
					int num8 = 0;
					int num9 = i;
					while (array3[num9] >= 0)
					{
						num9 = array3[num9];
						num8++;
					}
					char_4[i - 1] = (char)num8;
					if (num8 > int_29)
					{
						flag = true;
					}
				}
				if (flag)
				{
					for (int i = 1; i < int_28; i++)
					{
						int num8 = array2[i] >> 8;
						num8 = 1 + num8 / 2;
						array2[i] = num8 << 8;
					}
					continue;
				}
				break;
			}
		}

		private static void smethod_2(int[] int_27, char[] char_4, int int_28, int int_29, int int_30)
		{
			int num = 0;
			for (int i = int_28; i <= int_29; i++)
			{
				for (int j = 0; j < int_30; j++)
				{
					if (char_4[j] == i)
					{
						int_27[j] = num;
						num++;
					}
				}
				num <<= 1;
			}
		}

		private static byte smethod_3(byte byte_1, byte byte_2, byte byte_3)
		{
			if (byte_1 > byte_2)
			{
				byte b = byte_1;
				byte_1 = byte_2;
				byte_2 = b;
			}
			if (byte_2 > byte_3)
			{
				byte b = byte_2;
				byte_2 = byte_3;
				byte_3 = b;
			}
			if (byte_1 > byte_2)
			{
				byte_2 = byte_1;
			}
			return byte_2;
		}
	}
}
