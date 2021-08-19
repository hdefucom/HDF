using System;
using System.IO;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GStream8 : Stream
	{
		private const int int_0 = 1;

		private const int int_1 = 2;

		private const int int_2 = 3;

		private const int int_3 = 4;

		private const int int_4 = 5;

		private const int int_5 = 6;

		private const int int_6 = 7;

		private int int_7;

		private int int_8;

		private int int_9;

		private bool bool_0;

		private int int_10;

		private int int_11;

		private GInterface25 ginterface25_0 = new GClass579();

		private bool[] bool_1 = new bool[256];

		private int int_12;

		private byte[] byte_0 = new byte[256];

		private byte[] byte_1 = new byte[256];

		private byte[] byte_2 = new byte[18002];

		private byte[] byte_3 = new byte[18002];

		private int[] int_13;

		private byte[] byte_4;

		private int[] int_14 = new int[256];

		private int[][] int_15 = new int[6][];

		private int[][] int_16 = new int[6][];

		private int[][] int_17 = new int[6][];

		private int[] int_18 = new int[6];

		private Stream stream_0;

		private bool bool_2;

		private int int_19 = -1;

		private int int_20 = 1;

		private int int_21;

		private int int_22;

		private int int_23;

		private uint uint_0;

		private int int_24;

		private int int_25;

		private int int_26;

		private int int_27;

		private int int_28;

		private int int_29;

		private int int_30;

		private int int_31;

		private byte byte_5;

		private bool bool_3 = true;

		public override bool CanRead => stream_0.CanRead;

		public override bool CanSeek => stream_0.CanSeek;

		public override bool CanWrite => false;

		public override long Length => stream_0.Length;

		public override long Position
		{
			get
			{
				return stream_0.Position;
			}
			set
			{
				throw new NotSupportedException("BZip2InputStream position cannot be set");
			}
		}

		public GStream8(Stream stream_1)
		{
			for (int i = 0; i < 6; i++)
			{
				int_15[i] = new int[258];
				int_16[i] = new int[258];
				int_17[i] = new int[258];
			}
			method_7(stream_1);
			method_3();
			method_4();
			method_15();
		}

		public bool method_0()
		{
			return bool_3;
		}

		public void method_1(bool bool_4)
		{
			bool_3 = bool_4;
		}

		public override void Flush()
		{
			if (stream_0 != null)
			{
				stream_0.Flush();
			}
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotSupportedException("BZip2InputStream Seek not supported");
		}

		public override void SetLength(long value)
		{
			throw new NotSupportedException("BZip2InputStream SetLength not supported");
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			throw new NotSupportedException("BZip2InputStream Write not supported");
		}

		public override void WriteByte(byte value)
		{
			throw new NotSupportedException("BZip2InputStream WriteByte not supported");
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			int num = 15;
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			int num2 = 0;
			while (true)
			{
				if (num2 < count)
				{
					int num3 = ReadByte();
					if (num3 == -1)
					{
						break;
					}
					buffer[offset + num2] = (byte)num3;
					num2++;
					continue;
				}
				return count;
			}
			return num2;
		}

		public override void Close()
		{
			if (method_0() && stream_0 != null)
			{
				stream_0.Close();
			}
		}

		public override int ReadByte()
		{
			if (bool_2)
			{
				return -1;
			}
			int result = int_19;
			switch (int_20)
			{
			case 3:
				method_18();
				break;
			case 4:
				method_19();
				break;
			case 6:
				method_20();
				break;
			case 7:
				method_21();
				break;
			}
			return result;
		}

		private void method_2()
		{
			int_12 = 0;
			for (int i = 0; i < 256; i++)
			{
				if (bool_1[i])
				{
					byte_0[int_12] = (byte)i;
					byte_1[i] = (byte)int_12;
					int_12++;
				}
			}
		}

		private void method_3()
		{
			char c = method_10();
			char c2 = method_10();
			char c3 = method_10();
			char c4 = method_10();
			if (c != 'B' || c2 != 'Z' || c3 != 'h' || c4 < '1' || c4 > '9')
			{
				bool_2 = true;
				return;
			}
			method_22(c4 - 48);
			uint_0 = 0u;
		}

		private void method_4()
		{
			char c = method_10();
			char c2 = method_10();
			char c3 = method_10();
			char c4 = method_10();
			char c5 = method_10();
			char c6 = method_10();
			if (c == '\u0017' && c2 == 'r' && c3 == 'E' && c4 == '8' && c5 == 'P' && c6 == '\u0090')
			{
				method_6();
				return;
			}
			if (c != '1' || c2 != 'A' || c3 != 'Y' || c4 != '&' || c5 != 'S' || c6 != 'Y')
			{
				smethod_2();
				bool_2 = true;
				return;
			}
			int_21 = method_12();
			bool_0 = (method_9(1) == 1);
			method_14();
			ginterface25_0.imethod_1();
			int_20 = 1;
		}

		private void method_5()
		{
			int_23 = (int)ginterface25_0.imethod_0();
			if (int_21 != int_23)
			{
				smethod_3();
			}
			uint_0 = (uint)(((int)(uint_0 << 1) & -1) | (int)(uint_0 >> 31));
			uint_0 ^= (uint)int_23;
		}

		private void method_6()
		{
			int_22 = method_12();
			if (int_22 != (int)uint_0)
			{
				smethod_3();
			}
			bool_2 = true;
		}

		private void method_7(Stream stream_1)
		{
			stream_0 = stream_1;
			int_11 = 0;
			int_10 = 0;
		}

		private void method_8()
		{
			int num = 0;
			try
			{
				num = stream_0.ReadByte();
			}
			catch (Exception)
			{
				smethod_0();
			}
			if (num == -1)
			{
				smethod_0();
			}
			int_10 = ((int_10 << 8) | (num & 0xFF));
			int_11 += 8;
		}

		private int method_9(int int_32)
		{
			while (int_11 < int_32)
			{
				method_8();
			}
			int result = (int_10 >> int_11 - int_32) & ((1 << int_32) - 1);
			int_11 -= int_32;
			return result;
		}

		private char method_10()
		{
			return (char)method_9(8);
		}

		private int method_11(int int_32)
		{
			return method_9(int_32);
		}

		private int method_12()
		{
			int num = method_9(8);
			num = ((num << 8) | method_9(8));
			num = ((num << 8) | method_9(8));
			return (num << 8) | method_9(8);
		}

		private void method_13()
		{
			char[][] array = new char[6][];
			for (int i = 0; i < 6; i++)
			{
				array[i] = new char[258];
			}
			bool[] array2 = new bool[16];
			for (int i = 0; i < 16; i++)
			{
				array2[i] = (method_9(1) == 1);
			}
			for (int i = 0; i < 16; i++)
			{
				if (array2[i])
				{
					for (int j = 0; j < 16; j++)
					{
						bool_1[i * 16 + j] = (method_9(1) == 1);
					}
				}
				else
				{
					for (int j = 0; j < 16; j++)
					{
						bool_1[i * 16 + j] = false;
					}
				}
			}
			method_2();
			int num = int_12 + 2;
			int num2 = method_9(3);
			int num3 = method_9(15);
			for (int i = 0; i < num3; i++)
			{
				int j = 0;
				while (method_9(1) == 1)
				{
					j++;
				}
				byte_3[i] = (byte)j;
			}
			byte[] array3 = new byte[6];
			for (int k = 0; k < num2; k++)
			{
				array3[k] = (byte)k;
			}
			for (int i = 0; i < num3; i++)
			{
				int k = byte_3[i];
				byte b = array3[k];
				while (k > 0)
				{
					array3[k] = array3[k - 1];
					k--;
				}
				array3[0] = b;
				byte_2[i] = b;
			}
			for (int l = 0; l < num2; l++)
			{
				int num4 = method_9(5);
				for (int i = 0; i < num; i++)
				{
					while (method_9(1) == 1)
					{
						num4 = ((method_9(1) != 0) ? (num4 - 1) : (num4 + 1));
					}
					array[l][i] = (char)num4;
				}
			}
			for (int l = 0; l < num2; l++)
			{
				int num5 = 32;
				int num6 = 0;
				for (int i = 0; i < num; i++)
				{
					num6 = Math.Max(num6, array[l][i]);
					num5 = Math.Min(num5, array[l][i]);
				}
				smethod_4(int_15[l], int_16[l], int_17[l], array[l], num5, num6, num);
				int_18[l] = num5;
			}
		}

		private void method_14()
		{
			int num = 1;
			byte[] array = new byte[256];
			int num2 = 100000 * int_9;
			int_8 = method_11(24);
			method_13();
			int num3 = int_12 + 1;
			int num4 = -1;
			int num5 = 0;
			for (int i = 0; i <= 255; i++)
			{
				int_14[i] = 0;
			}
			for (int i = 0; i <= 255; i++)
			{
				array[i] = (byte)i;
			}
			int_7 = -1;
			if (num5 == 0)
			{
				num4++;
				num5 = 50;
			}
			num5--;
			int num6 = byte_2[num4];
			int num7 = int_18[num6];
			int num8 = method_9(num7);
			while (true)
			{
				if (num8 > int_15[num6][num7])
				{
					if (num7 > 20)
					{
						break;
					}
					num7++;
					while (int_11 < 1)
					{
						method_8();
					}
					int num9 = (int_10 >> int_11 - 1) & 1;
					int_11--;
					num8 = ((num8 << 1) | num9);
					continue;
				}
				if (num8 - int_16[num6][num7] < 0 || num8 - int_16[num6][num7] >= 258)
				{
					throw new GException22("Bzip data error");
				}
				int num10 = int_17[num6][num8 - int_16[num6][num7]];
				while (num10 != num3)
				{
					if (num10 == 0 || num10 == 1)
					{
						int num11 = -1;
						int num12 = 1;
						do
						{
							if (num10 != 0)
							{
								if (num10 == 1)
								{
									num11 += 2 * num12;
								}
							}
							else
							{
								num11 += num12;
							}
							num12 <<= 1;
							if (num5 == 0)
							{
								num4++;
								num5 = 50;
							}
							num5--;
							num6 = byte_2[num4];
							num7 = int_18[num6];
							num8 = method_9(num7);
							while (num8 > int_15[num6][num7])
							{
								num7++;
								while (int_11 < 1)
								{
									method_8();
								}
								int num9 = (int_10 >> int_11 - 1) & 1;
								int_11--;
								num8 = ((num8 << 1) | num9);
							}
							num10 = int_17[num6][num8 - int_16[num6][num7]];
						}
						while (num10 == 0 || num10 == 1);
						num11++;
						byte b = byte_0[array[0]];
						int_14[b] += num11;
						while (num11 > 0)
						{
							int_7++;
							byte_4[int_7] = b;
							num11--;
						}
						if (int_7 >= num2)
						{
							smethod_1();
						}
						continue;
					}
					int_7++;
					if (int_7 >= num2)
					{
						smethod_1();
					}
					byte b2 = array[num10 - 1];
					int_14[byte_0[b2]]++;
					byte_4[int_7] = byte_0[b2];
					for (int num13 = num10 - 1; num13 > 0; num13--)
					{
						array[num13] = array[num13 - 1];
					}
					array[0] = b2;
					if (num5 == 0)
					{
						num4++;
						num5 = 50;
					}
					num5--;
					num6 = byte_2[num4];
					num7 = int_18[num6];
					num8 = method_9(num7);
					while (num8 > int_15[num6][num7])
					{
						num7++;
						while (int_11 < 1)
						{
							method_8();
						}
						int num9 = (int_10 >> int_11 - 1) & 1;
						int_11--;
						num8 = ((num8 << 1) | num9);
					}
					num10 = int_17[num6][num8 - int_16[num6][num7]];
				}
				return;
			}
			throw new GException22("Bzip data error");
		}

		private void method_15()
		{
			int[] array = new int[257];
			array[0] = 0;
			Array.Copy(int_14, 0, array, 1, 256);
			for (int i = 1; i <= 256; i++)
			{
				array[i] += array[i - 1];
			}
			for (int i = 0; i <= int_7; i++)
			{
				byte b = byte_4[i];
				int_13[array[b]] = i;
				array[b]++;
			}
			array = null;
			int_27 = int_13[int_8];
			int_24 = 0;
			int_30 = 0;
			int_26 = 256;
			if (bool_0)
			{
				int_28 = 0;
				int_29 = 0;
				method_16();
			}
			else
			{
				method_17();
			}
		}

		private void method_16()
		{
			if (int_30 <= int_7)
			{
				int_25 = int_26;
				int_26 = byte_4[int_27];
				int_27 = int_13[int_27];
				if (int_28 == 0)
				{
					int_28 = Class220.int_10[int_29];
					int_29++;
					if (int_29 == 512)
					{
						int_29 = 0;
					}
				}
				int_28--;
				int_26 ^= ((int_28 == 1) ? 1 : 0);
				int_30++;
				int_19 = int_26;
				int_20 = 3;
				ginterface25_0.imethod_2(int_26);
			}
			else
			{
				method_5();
				method_4();
				method_15();
			}
		}

		private void method_17()
		{
			if (int_30 <= int_7)
			{
				int_25 = int_26;
				int_26 = byte_4[int_27];
				int_27 = int_13[int_27];
				int_30++;
				int_19 = int_26;
				int_20 = 6;
				ginterface25_0.imethod_2(int_26);
			}
			else
			{
				method_5();
				method_4();
				method_15();
			}
		}

		private void method_18()
		{
			if (int_26 != int_25)
			{
				int_20 = 2;
				int_24 = 1;
				method_16();
				return;
			}
			int_24++;
			if (int_24 >= 4)
			{
				byte_5 = byte_4[int_27];
				int_27 = int_13[int_27];
				if (int_28 == 0)
				{
					int_28 = Class220.int_10[int_29];
					int_29++;
					if (int_29 == 512)
					{
						int_29 = 0;
					}
				}
				int_28--;
				byte_5 ^= (byte)((int_28 == 1) ? 1 : 0);
				int_31 = 0;
				int_20 = 4;
				method_19();
			}
			else
			{
				int_20 = 2;
				method_16();
			}
		}

		private void method_19()
		{
			if (int_31 < byte_5)
			{
				int_19 = int_26;
				ginterface25_0.imethod_2(int_26);
				int_31++;
			}
			else
			{
				int_20 = 2;
				int_30++;
				int_24 = 0;
				method_16();
			}
		}

		private void method_20()
		{
			if (int_26 != int_25)
			{
				int_20 = 5;
				int_24 = 1;
				method_17();
				return;
			}
			int_24++;
			if (int_24 >= 4)
			{
				byte_5 = byte_4[int_27];
				int_27 = int_13[int_27];
				int_20 = 7;
				int_31 = 0;
				method_21();
			}
			else
			{
				int_20 = 5;
				method_17();
			}
		}

		private void method_21()
		{
			if (int_31 < byte_5)
			{
				int_19 = int_26;
				ginterface25_0.imethod_2(int_26);
				int_31++;
			}
			else
			{
				int_20 = 5;
				int_30++;
				int_24 = 0;
				method_17();
			}
		}

		private void method_22(int int_32)
		{
			int num = 8;
			if (0 > int_32 || int_32 > 9 || 0 > int_9 || int_9 > 9)
			{
				throw new GException22("Invalid block size");
			}
			int_9 = int_32;
			if (int_32 != 0)
			{
				int num2 = 100000 * int_32;
				byte_4 = new byte[num2];
				int_13 = new int[num2];
			}
		}

		private static void smethod_0()
		{
			throw new EndOfStreamException("BZip2 input stream end of compressed stream");
		}

		private static void smethod_1()
		{
			throw new GException22("BZip2 input stream block overrun");
		}

		private static void smethod_2()
		{
			throw new GException22("BZip2 input stream bad block header");
		}

		private static void smethod_3()
		{
			throw new GException22("BZip2 input stream crc error");
		}

		private static void smethod_4(int[] int_32, int[] int_33, int[] int_34, char[] char_0, int int_35, int int_36, int int_37)
		{
			int num = 0;
			for (int i = int_35; i <= int_36; i++)
			{
				for (int j = 0; j < int_37; j++)
				{
					if (char_0[j] == i)
					{
						int_34[num] = j;
						num++;
					}
				}
			}
			for (int i = 0; i < 23; i++)
			{
				int_33[i] = 0;
			}
			for (int i = 0; i < int_37; i++)
			{
				int_33[char_0[i] + 1]++;
			}
			for (int i = 1; i < 23; i++)
			{
				int_33[i] += int_33[i - 1];
			}
			for (int i = 0; i < 23; i++)
			{
				int_32[i] = 0;
			}
			int num2 = 0;
			for (int i = int_35; i <= int_36; i++)
			{
				num2 += int_33[i + 1] - int_33[i];
				int_32[i] = num2 - 1;
				num2 <<= 1;
			}
			for (int i = int_35 + 1; i <= int_36; i++)
			{
				int_33[i] = (int_32[i - 1] + 1 << 1) - int_33[i];
			}
		}
	}
}
