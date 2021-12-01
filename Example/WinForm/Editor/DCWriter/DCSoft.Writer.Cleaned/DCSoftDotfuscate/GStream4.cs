using System;
using System.IO;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GStream4 : GStream2
	{
		[ComVisible(false)]
		private delegate int Delegate7(byte[] byte_0, int int_0, int int_1);

		private Delegate7 delegate7_0;

		private GClass548 gclass548_0 = new GClass548();

		private GClass577 gclass577_0;

		private long long_1;

		private int int_0;

		private int int_1;

		private string string_0;

		public override long Length
		{
			get
			{
				int num = 3;
				if (gclass577_0 != null)
				{
					if (gclass577_0.method_30() < 0L)
					{
						throw new GException24("Length not available for the current entry");
					}
					return gclass577_0.method_30();
				}
				throw new InvalidOperationException("No current entry");
			}
		}

		public GStream4(Stream stream_1)
			: base(stream_1, new GClass587(bool_2: true))
		{
			delegate7_0 = method_12;
		}

		public GStream4(Stream stream_1, int int_2)
			: base(stream_1, new GClass587(bool_2: true), int_2)
		{
			delegate7_0 = method_12;
		}

		public string method_5()
		{
			return string_0;
		}

		public void method_6(string string_1)
		{
			string_0 = string_1;
		}

		public bool method_7()
		{
			return gclass577_0 != null && gclass577_0.method_21();
		}

		public GClass577 method_8()
		{
			int num = 17;
			if (gclass548_0 == null)
			{
				throw new InvalidOperationException("Closed.");
			}
			if (gclass577_0 != null)
			{
				method_11();
			}
			int num2 = gclass555_0.method_13();
			if (num2 == 33639248 || num2 == 101010256 || num2 == 84233040 || num2 == 117853008 || num2 == 101075792)
			{
				Close();
				return null;
			}
			if (num2 == 808471376 || num2 == 134695760)
			{
				num2 = gclass555_0.method_13();
			}
			if (num2 != 67324752)
			{
				throw new GException24("Wrong Local header signature: 0x" + $"{num2:X}");
			}
			short int_ = (short)gclass555_0.method_12();
			int_1 = gclass555_0.method_12();
			int_0 = gclass555_0.method_12();
			uint num3 = (uint)gclass555_0.method_13();
			int num4 = gclass555_0.method_13();
			long_0 = gclass555_0.method_13();
			long_1 = gclass555_0.method_13();
			int num5 = gclass555_0.method_12();
			int num6 = gclass555_0.method_12();
			bool flag = (int_1 & 1) == 1;
			byte[] array = new byte[num5];
			gclass555_0.method_8(array);
			string string_ = GClass547.smethod_5(int_1, array);
			gclass577_0 = new GClass577(string_, int_);
			gclass577_0.method_8(int_1);
			gclass577_0.method_37((GEnum94)int_0);
			if ((int_1 & 8) == 0)
			{
				gclass577_0.method_35(num4 & 0xFFFFFFFF);
				gclass577_0.method_31(long_1 & 0xFFFFFFFF);
				gclass577_0.method_33(long_0 & 0xFFFFFFFF);
				gclass577_0.method_6((byte)((num4 >> 24) & 0xFF));
			}
			else
			{
				if (num4 != 0)
				{
					gclass577_0.method_35(num4 & 0xFFFFFFFF);
				}
				if (long_1 != 0L)
				{
					gclass577_0.method_31(long_1 & 0xFFFFFFFF);
				}
				if (long_0 != 0L)
				{
					gclass577_0.method_33(long_0 & 0xFFFFFFFF);
				}
				gclass577_0.method_6((byte)((num3 >> 8) & 0xFF));
			}
			gclass577_0.method_27(num3);
			if (num6 > 0)
			{
				byte[] array2 = new byte[num6];
				gclass555_0.method_8(array2);
				gclass577_0.method_40(array2);
			}
			gclass577_0.method_46(bool_1: true);
			if (gclass577_0.method_32() >= 0L)
			{
				long_0 = gclass577_0.method_32();
			}
			if (gclass577_0.method_30() >= 0L)
			{
				long_1 = gclass577_0.method_30();
			}
			if (int_0 == 0 && ((!flag && long_0 != long_1) || (flag && long_0 - 12L != long_1)))
			{
				throw new GException24("Stored, but compressed != uncompressed");
			}
			if (gclass577_0.method_52())
			{
				delegate7_0 = method_14;
			}
			else
			{
				delegate7_0 = method_13;
			}
			return gclass577_0;
		}

		private void method_9()
		{
			int num = 6;
			if (gclass555_0.method_13() != 134695760)
			{
				throw new GException24("Data descriptor signature not found");
			}
			gclass577_0.method_35(gclass555_0.method_13() & 0xFFFFFFFF);
			if (gclass577_0.method_24())
			{
				long_0 = gclass555_0.method_14();
				long_1 = gclass555_0.method_14();
			}
			else
			{
				long_0 = gclass555_0.method_13();
				long_1 = gclass555_0.method_13();
			}
			gclass577_0.method_33(long_0);
			gclass577_0.method_31(long_1);
		}

		private void method_10(bool bool_2)
		{
			int num = 17;
			method_3();
			if ((int_1 & 8) != 0)
			{
				method_9();
			}
			long_1 = 0L;
			if (bool_2 && (gclass548_0.imethod_0() & 0xFFFFFFFF) != gclass577_0.method_34() && gclass577_0.method_34() != -1L)
			{
				throw new GException24("CRC mismatch");
			}
			gclass548_0.imethod_1();
			if (int_0 == 8)
			{
				gclass587_0.method_0();
			}
			gclass577_0 = null;
		}

		public void method_11()
		{
			int num = 2;
			if (gclass548_0 == null)
			{
				throw new InvalidOperationException("Closed");
			}
			if (gclass577_0 == null)
			{
				return;
			}
			if (int_0 == 8)
			{
				if ((int_1 & 8) != 0)
				{
					byte[] array = new byte[4096];
					while (Read(array, 0, array.Length) > 0)
					{
					}
					return;
				}
				long_0 -= gclass587_0.method_17();
				GClass555 gclass555_ = gclass555_0;
				gclass555_.method_5(gclass555_.method_4() + gclass587_0.method_18());
			}
			if (gclass555_0.method_4() > long_0 && long_0 >= 0L)
			{
				gclass555_0.method_5((int)(gclass555_0.method_4() - long_0));
			}
			else
			{
				long_0 -= gclass555_0.method_4();
				gclass555_0.method_5(0);
				while (long_0 != 0L)
				{
					long num2 = method_2(long_0);
					if (num2 > 0L)
					{
						long_0 -= num2;
						continue;
					}
					throw new GException24("Zip archive ends early.");
				}
			}
			method_10(bool_2: false);
		}

		public override int vmethod_0()
		{
			return (gclass577_0 != null) ? 1 : 0;
		}

		public override int ReadByte()
		{
			byte[] array = new byte[1];
			if (Read(array, 0, 1) <= 0)
			{
				return -1;
			}
			return array[0] & 0xFF;
		}

		private int method_12(byte[] byte_0, int int_2, int int_3)
		{
			throw new InvalidOperationException("Unable to read from this stream");
		}

		private int method_13(byte[] byte_0, int int_2, int int_3)
		{
			throw new GException24("The compression method for this entry is not supported");
		}

		private int method_14(byte[] byte_0, int int_2, int int_3)
		{
			int num = 8;
			if (!method_7())
			{
				throw new GException24("Library cannot extract this entry. Version required is (" + gclass577_0.method_20() + ")");
			}
			if (gclass577_0.method_1())
			{
				if (string_0 == null)
				{
					throw new GException24("No password set.");
				}
				GClass565 gClass = new GClass565();
				byte[] rgbKey = GClass564.smethod_0(GClass547.smethod_6(string_0));
				gclass555_0.method_15(gClass.CreateDecryptor(rgbKey, null));
				byte[] array = new byte[12];
				gclass555_0.method_10(array, 0, 12);
				if (array[11] != gclass577_0.method_5())
				{
					throw new GException24("Invalid password");
				}
				if (long_0 >= 12L)
				{
					long_0 -= 12L;
				}
				else if ((gclass577_0.method_7() & 8) == 0)
				{
					throw new GException24($"Entry compressed size {long_0} too small for encryption");
				}
			}
			else
			{
				gclass555_0.method_15(null);
			}
			if (long_0 > 0L || (int_1 & 8) != 0)
			{
				if (int_0 == 8 && gclass555_0.method_4() > 0)
				{
					gclass555_0.method_6(gclass587_0);
				}
				delegate7_0 = method_15;
				return method_15(byte_0, int_2, int_3);
			}
			delegate7_0 = method_12;
			return 0;
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			int num = 18;
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (offset < 0)
			{
				throw new ArgumentOutOfRangeException("offset", "Cannot be negative");
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count", "Cannot be negative");
			}
			if (buffer.Length - offset < count)
			{
				throw new ArgumentException("Invalid offset/count combination");
			}
			return delegate7_0(buffer, offset, count);
		}

		private int method_15(byte[] byte_0, int int_2, int int_3)
		{
			int num = 13;
			if (gclass548_0 == null)
			{
				throw new InvalidOperationException("Closed");
			}
			if (gclass577_0 == null || int_3 <= 0)
			{
				return 0;
			}
			if (int_2 + int_3 > byte_0.Length)
			{
				throw new ArgumentException("Offset + count exceeds buffer size");
			}
			bool flag = false;
			switch (int_0)
			{
			case 8:
				int_3 = base.Read(byte_0, int_2, int_3);
				if (int_3 <= 0)
				{
					if (!gclass587_0.method_14())
					{
						throw new GException24("Inflater not finished!");
					}
					gclass555_0.method_5(gclass587_0.method_18());
					if ((int_1 & 8) == 0 && ((gclass587_0.method_17() != long_0 && long_0 != 4294967295L && long_0 != -1L) || gclass587_0.method_16() != long_1))
					{
						throw new GException24("Size mismatch: " + long_0 + ";" + long_1 + " <-> " + gclass587_0.method_17() + ";" + gclass587_0.method_16());
					}
					gclass587_0.method_0();
					flag = true;
				}
				break;
			case 0:
				if (int_3 > long_0 && long_0 >= 0L)
				{
					int_3 = (int)long_0;
				}
				if (int_3 > 0)
				{
					int_3 = gclass555_0.method_10(byte_0, int_2, int_3);
					if (int_3 > 0)
					{
						long_0 -= int_3;
						long_1 -= int_3;
					}
				}
				if (long_0 == 0L)
				{
					flag = true;
				}
				else if (int_3 < 0)
				{
					throw new GException24("EOF in stored block");
				}
				break;
			}
			if (int_3 > 0)
			{
				gclass548_0.imethod_4(byte_0, int_2, int_3);
			}
			if (flag)
			{
				method_10(bool_2: true);
			}
			return int_3;
		}

		public override void Close()
		{
			delegate7_0 = method_12;
			gclass548_0 = null;
			gclass577_0 = null;
			base.Close();
		}
	}
}
