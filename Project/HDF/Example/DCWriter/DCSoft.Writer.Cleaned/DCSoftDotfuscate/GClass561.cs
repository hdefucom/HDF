using System;
using System.IO;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass561
	{
		public const int int_0 = 512;

		public const int int_1 = 20;

		public const int int_2 = 10240;

		private Stream stream_0;

		private Stream stream_1;

		private byte[] byte_0;

		private int int_3;

		private int int_4;

		private int int_5 = 10240;

		private int int_6 = 20;

		private bool bool_0 = true;

		public int method_0()
		{
			return int_5;
		}

		[Obsolete("Use RecordSize property instead")]
		public int method_1()
		{
			return int_5;
		}

		public int method_2()
		{
			return int_6;
		}

		[Obsolete("Use BlockFactor property instead")]
		public int method_3()
		{
			return int_6;
		}

		protected GClass561()
		{
		}

		public static GClass561 smethod_0(Stream stream_2)
		{
			int num = 1;
			if (stream_2 == null)
			{
				throw new ArgumentNullException("inputStream");
			}
			return smethod_1(stream_2, 20);
		}

		public static GClass561 smethod_1(Stream stream_2, int int_7)
		{
			int num = 18;
			if (stream_2 == null)
			{
				throw new ArgumentNullException("inputStream");
			}
			if (int_7 <= 0)
			{
				throw new ArgumentOutOfRangeException("blockFactor", "Factor cannot be negative");
			}
			GClass561 gClass = new GClass561();
			gClass.stream_0 = stream_2;
			gClass.stream_1 = null;
			gClass.method_4(int_7);
			return gClass;
		}

		public static GClass561 smethod_2(Stream stream_2)
		{
			int num = 4;
			if (stream_2 == null)
			{
				throw new ArgumentNullException("outputStream");
			}
			return smethod_3(stream_2, 20);
		}

		public static GClass561 smethod_3(Stream stream_2, int int_7)
		{
			int num = 9;
			if (stream_2 == null)
			{
				throw new ArgumentNullException("outputStream");
			}
			if (int_7 <= 0)
			{
				throw new ArgumentOutOfRangeException("blockFactor", "Factor cannot be negative");
			}
			GClass561 gClass = new GClass561();
			gClass.stream_0 = null;
			gClass.stream_1 = stream_2;
			gClass.method_4(int_7);
			return gClass;
		}

		private void method_4(int int_7)
		{
			int_6 = int_7;
			int_5 = int_7 * 512;
			byte_0 = new byte[method_0()];
			if (stream_0 != null)
			{
				int_4 = -1;
				int_3 = method_2();
			}
			else
			{
				int_4 = 0;
				int_3 = 0;
			}
		}

		[Obsolete("Use IsEndOfArchiveBlock instead")]
		public bool method_5(byte[] byte_1)
		{
			int num = 19;
			if (byte_1 == null)
			{
				throw new ArgumentNullException("block");
			}
			if (byte_1.Length != 512)
			{
				throw new ArgumentException("block length is invalid");
			}
			int num2 = 0;
			while (true)
			{
				if (num2 < 512)
				{
					if (byte_1[num2] != 0)
					{
						break;
					}
					num2++;
					continue;
				}
				return true;
			}
			return false;
		}

		public static bool smethod_4(byte[] byte_1)
		{
			int num = 1;
			if (byte_1 == null)
			{
				throw new ArgumentNullException("block");
			}
			if (byte_1.Length != 512)
			{
				throw new ArgumentException("block length is invalid");
			}
			int num2 = 0;
			while (true)
			{
				if (num2 < 512)
				{
					if (byte_1[num2] != 0)
					{
						break;
					}
					num2++;
					continue;
				}
				return true;
			}
			return false;
		}

		public void method_6()
		{
			int num = 1;
			if (stream_0 == null)
			{
				throw new GException20("no input stream defined");
			}
			if (int_3 >= method_2() && !method_8())
			{
				throw new GException20("Failed to read a record");
			}
			int_3++;
		}

		public byte[] method_7()
		{
			int num = 2;
			if (stream_0 == null)
			{
				throw new GException20("TarBuffer.ReadBlock - no input stream defined");
			}
			if (int_3 >= method_2() && !method_8())
			{
				throw new GException20("Failed to read a record");
			}
			byte[] array = new byte[512];
			Array.Copy(byte_0, int_3 * 512, array, 0, 512);
			int_3++;
			return array;
		}

		private bool method_8()
		{
			int num = 9;
			if (stream_0 == null)
			{
				throw new GException20("no input stream stream defined");
			}
			int_3 = 0;
			int num2 = 0;
			int num3 = method_0();
			while (num3 > 0)
			{
				long num4 = stream_0.Read(byte_0, num2, num3);
				if (num4 <= 0L)
				{
					break;
				}
				num2 += (int)num4;
				num3 -= (int)num4;
			}
			int_4++;
			return true;
		}

		public int method_9()
		{
			return int_3;
		}

		public bool method_10()
		{
			return bool_0;
		}

		public void method_11(bool bool_1)
		{
			bool_0 = bool_1;
		}

		[Obsolete("Use CurrentBlock property instead")]
		public int method_12()
		{
			return int_3;
		}

		public int method_13()
		{
			return int_4;
		}

		[Obsolete("Use CurrentRecord property instead")]
		public int method_14()
		{
			return int_4;
		}

		public void method_15(byte[] byte_1)
		{
			int num = 5;
			if (byte_1 == null)
			{
				throw new ArgumentNullException("block");
			}
			if (stream_1 == null)
			{
				throw new GException20("TarBuffer.WriteBlock - no output stream defined");
			}
			if (byte_1.Length != 512)
			{
				string string_ = $"TarBuffer.WriteBlock - block to write has length '{byte_1.Length}' which is not the block size of '{512}'";
				throw new GException20(string_);
			}
			if (int_3 >= method_2())
			{
				method_17();
			}
			Array.Copy(byte_1, 0, byte_0, int_3 * 512, 512);
			int_3++;
		}

		public void method_16(byte[] byte_1, int int_7)
		{
			int num = 13;
			if (byte_1 == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (stream_1 == null)
			{
				throw new GException20("TarBuffer.WriteBlock - no output stream stream defined");
			}
			if (int_7 < 0 || int_7 >= byte_1.Length)
			{
				throw new ArgumentOutOfRangeException("offset");
			}
			if (int_7 + 512 > byte_1.Length)
			{
				string string_ = $"TarBuffer.WriteBlock - record has length '{byte_1.Length}' with offset '{int_7}' which is less than the record size of '{int_5}'";
				throw new GException20(string_);
			}
			if (int_3 >= method_2())
			{
				method_17();
			}
			Array.Copy(byte_1, int_7, byte_0, int_3 * 512, 512);
			int_3++;
		}

		private void method_17()
		{
			int num = 10;
			if (stream_1 == null)
			{
				throw new GException20("TarBuffer.WriteRecord no output stream defined");
			}
			stream_1.Write(byte_0, 0, method_0());
			stream_1.Flush();
			int_3 = 0;
			int_4++;
		}

		private void method_18()
		{
			int num = 18;
			if (stream_1 == null)
			{
				throw new GException20("TarBuffer.WriteFinalRecord no output stream defined");
			}
			if (int_3 > 0)
			{
				int num2 = int_3 * 512;
				Array.Clear(byte_0, num2, method_0() - num2);
				method_17();
			}
			stream_1.Flush();
		}

		public void method_19()
		{
			if (stream_1 != null)
			{
				method_18();
				if (bool_0)
				{
					stream_1.Close();
				}
				stream_1 = null;
			}
			else if (stream_0 != null)
			{
				if (bool_0)
				{
					stream_0.Close();
				}
				stream_0 = null;
			}
		}
	}
}
