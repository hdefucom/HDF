using System.IO;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GStream3 : GStream2
	{
		protected GClass548 gclass548_0;

		private bool bool_2;

		public GStream3(Stream stream_1)
			: this(stream_1, 4096)
		{
		}

		public GStream3(Stream stream_1, int int_0)
			: base(stream_1, new GClass587(bool_2: true), int_0)
		{
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			int num;
			do
			{
				if (bool_2 || method_5())
				{
					num = base.Read(buffer, offset, count);
					if (num > 0)
					{
						gclass548_0.imethod_4(buffer, offset, num);
					}
					if (gclass587_0.method_14())
					{
						method_6();
					}
					continue;
				}
				return 0;
			}
			while (num <= 0);
			return num;
		}

		private bool method_5()
		{
			int num = 6;
			gclass548_0 = new GClass548();
			if (gclass555_0.method_4() <= 0)
			{
				gclass555_0.method_7();
				if (gclass555_0.method_4() <= 0)
				{
					return false;
				}
			}
			GClass548 gClass = new GClass548();
			int num2 = gclass555_0.method_11();
			if (num2 < 0)
			{
				throw new EndOfStreamException("EOS reading GZIP header");
			}
			gClass.imethod_2(num2);
			if (num2 != 31)
			{
				throw new GException23("Error GZIP header, first magic byte doesn't match");
			}
			num2 = gclass555_0.method_11();
			if (num2 < 0)
			{
				throw new EndOfStreamException("EOS reading GZIP header");
			}
			if (num2 != 139)
			{
				throw new GException23("Error GZIP header,  second magic byte doesn't match");
			}
			gClass.imethod_2(num2);
			int num3 = gclass555_0.method_11();
			if (num3 < 0)
			{
				throw new EndOfStreamException("EOS reading GZIP header");
			}
			if (num3 != 8)
			{
				throw new GException23("Error GZIP header, data not in deflate format");
			}
			gClass.imethod_2(num3);
			int num4 = gclass555_0.method_11();
			if (num4 < 0)
			{
				throw new EndOfStreamException("EOS reading GZIP header");
			}
			gClass.imethod_2(num4);
			if ((num4 & 0xE0) != 0)
			{
				throw new GException23("Reserved flag bits in GZIP header != 0");
			}
			int num5 = 0;
			while (true)
			{
				if (num5 < 6)
				{
					int num6 = gclass555_0.method_11();
					if (num6 < 0)
					{
						break;
					}
					gClass.imethod_2(num6);
					num5++;
					continue;
				}
				if ((num4 & 4) != 0)
				{
					for (num5 = 0; num5 < 2; num5++)
					{
						int num6 = gclass555_0.method_11();
						if (num6 >= 0)
						{
							gClass.imethod_2(num6);
							continue;
						}
						throw new EndOfStreamException("EOS reading GZIP header");
					}
					if (gclass555_0.method_11() < 0 || gclass555_0.method_11() < 0)
					{
						throw new EndOfStreamException("EOS reading GZIP header");
					}
					int num7 = gclass555_0.method_11();
					int num8 = gclass555_0.method_11();
					if (num7 < 0 || num8 < 0)
					{
						throw new EndOfStreamException("EOS reading GZIP header");
					}
					gClass.imethod_2(num7);
					gClass.imethod_2(num8);
					int num9 = (num7 << 8) | num8;
					for (num5 = 0; num5 < num9; num5++)
					{
						int num6 = gclass555_0.method_11();
						if (num6 >= 0)
						{
							gClass.imethod_2(num6);
							continue;
						}
						throw new EndOfStreamException("EOS reading GZIP header");
					}
				}
				if ((num4 & 8) != 0)
				{
					int num6;
					while ((num6 = gclass555_0.method_11()) > 0)
					{
						gClass.imethod_2(num6);
					}
					if (num6 < 0)
					{
						throw new EndOfStreamException("EOS reading GZIP header");
					}
					gClass.imethod_2(num6);
				}
				if ((num4 & 0x10) != 0)
				{
					int num6;
					while ((num6 = gclass555_0.method_11()) > 0)
					{
						gClass.imethod_2(num6);
					}
					if (num6 < 0)
					{
						throw new EndOfStreamException("EOS reading GZIP header");
					}
					gClass.imethod_2(num6);
				}
				if ((num4 & 2) != 0)
				{
					int num10 = gclass555_0.method_11();
					if (num10 < 0)
					{
						throw new EndOfStreamException("EOS reading GZIP header");
					}
					int num11 = gclass555_0.method_11();
					if (num11 < 0)
					{
						throw new EndOfStreamException("EOS reading GZIP header");
					}
					num10 = ((num10 << 8) | num11);
					if (num10 != ((int)gClass.imethod_0() & 0xFFFF))
					{
						throw new GException23("Header CRC value mismatch");
					}
				}
				bool_2 = true;
				return true;
			}
			throw new EndOfStreamException("EOS reading GZIP header");
		}

		private void method_6()
		{
			int num = 8;
			byte[] array = new byte[8];
			long num2 = gclass587_0.method_16() & 0xFFFFFFFF;
			GClass555 gclass555_ = gclass555_0;
			gclass555_.method_5(gclass555_.method_4() + gclass587_0.method_18());
			gclass587_0.method_0();
			int num3 = 8;
			while (true)
			{
				if (num3 > 0)
				{
					int num4 = gclass555_0.method_10(array, 8 - num3, num3);
					if (num4 > 0)
					{
						num3 -= num4;
						continue;
					}
					throw new EndOfStreamException("EOS reading GZIP footer");
				}
				int num5 = (array[0] & 0xFF) | ((array[1] & 0xFF) << 8) | ((array[2] & 0xFF) << 16) | (array[3] << 24);
				if (num5 != (int)gclass548_0.imethod_0())
				{
					throw new GException23("GZIP crc sum mismatch, theirs \"" + num5 + "\" and ours \"" + (int)gclass548_0.imethod_0());
				}
				uint num6 = (uint)((array[4] & 0xFF) | ((array[5] & 0xFF) << 8) | ((array[6] & 0xFF) << 16) | (array[7] << 24));
				if (num2 == num6)
				{
					break;
				}
				throw new GException23("Number of bytes mismatch in footer");
			}
			bool_2 = false;
		}
	}
}
