using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GStream9 : Stream
	{
		[ComVisible(false)]
		public interface GInterface32
		{
			GClass558 imethod_0(string string_0);

			GClass558 imethod_1(string string_0);

			GClass558 imethod_2(byte[] byte_0);
		}

		[ComVisible(false)]
		public class GClass589 : GInterface32
		{
			public GClass558 imethod_0(string string_0)
			{
				return GClass558.smethod_0(string_0);
			}

			public GClass558 imethod_1(string string_0)
			{
				return GClass558.smethod_1(string_0);
			}

			public GClass558 imethod_2(byte[] byte_0)
			{
				return new GClass558(byte_0);
			}
		}

		protected bool bool_0;

		protected long long_0;

		protected long long_1;

		protected byte[] byte_0;

		protected GClass561 gclass561_0;

		private GClass558 gclass558_0;

		protected GInterface32 ginterface32_0;

		private readonly Stream stream_0;

		public override bool CanRead => stream_0.CanRead;

		public override bool CanSeek => false;

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
				throw new NotSupportedException("TarInputStream Seek not supported");
			}
		}

		public GStream9(Stream stream_1)
			: this(stream_1, 20)
		{
		}

		public GStream9(Stream stream_1, int int_0)
		{
			stream_0 = stream_1;
			gclass561_0 = GClass561.smethod_1(stream_1, int_0);
		}

		public bool method_0()
		{
			return gclass561_0.method_10();
		}

		public void method_1(bool bool_1)
		{
			gclass561_0.method_11(bool_1);
		}

		public override void Flush()
		{
			stream_0.Flush();
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotSupportedException("TarInputStream Seek not supported");
		}

		public override void SetLength(long value)
		{
			throw new NotSupportedException("TarInputStream SetLength not supported");
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			throw new NotSupportedException("TarInputStream Write not supported");
		}

		public override void WriteByte(byte value)
		{
			throw new NotSupportedException("TarInputStream WriteByte not supported");
		}

		public override int ReadByte()
		{
			byte[] array = new byte[1];
			int num = Read(array, 0, 1);
			if (num <= 0)
			{
				return -1;
			}
			return array[0];
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			int num = 10;
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			int num2 = 0;
			if (long_1 >= long_0)
			{
				return 0;
			}
			long num3 = count;
			if (num3 + long_1 > long_0)
			{
				num3 = long_0 - long_1;
			}
			if (byte_0 != null)
			{
				int num4 = (int)((num3 > byte_0.Length) ? byte_0.Length : num3);
				Array.Copy(byte_0, 0, buffer, offset, num4);
				if (num4 >= byte_0.Length)
				{
					byte_0 = null;
				}
				else
				{
					int num5 = byte_0.Length - num4;
					byte[] destinationArray = new byte[num5];
					Array.Copy(byte_0, num4, destinationArray, 0, num5);
					byte_0 = destinationArray;
				}
				num2 += num4;
				num3 -= num4;
				offset += num4;
			}
			while (true)
			{
				if (num3 > 0L)
				{
					byte[] array = gclass561_0.method_7();
					if (array == null)
					{
						break;
					}
					int num4 = (int)num3;
					int num6 = array.Length;
					if (num6 > num4)
					{
						Array.Copy(array, 0, buffer, offset, num4);
						byte_0 = new byte[num6 - num4];
						Array.Copy(array, num4, byte_0, 0, num6 - num4);
					}
					else
					{
						num4 = num6;
						Array.Copy(array, 0, buffer, offset, num6);
					}
					num2 += num4;
					num3 -= num4;
					offset += num4;
					continue;
				}
				long_1 += num2;
				return num2;
			}
			throw new GException20("unexpected EOF with " + num3 + " bytes unread");
		}

		public override void Close()
		{
			gclass561_0.method_19();
		}

		public void method_2(GInterface32 ginterface32_1)
		{
			ginterface32_0 = ginterface32_1;
		}

		public int method_3()
		{
			return gclass561_0.method_0();
		}

		[Obsolete("Use RecordSize property instead")]
		public int method_4()
		{
			return gclass561_0.method_0();
		}

		public long method_5()
		{
			return long_0 - long_1;
		}

		public void method_6(long long_2)
		{
			byte[] array = new byte[8192];
			long num = long_2;
			while (num > 0L)
			{
				int count = (int)((num > array.Length) ? array.Length : num);
				int num2 = Read(array, 0, count);
				if (num2 != -1)
				{
					num -= num2;
					continue;
				}
				break;
			}
		}

		public bool method_7()
		{
			return false;
		}

		public void method_8(int int_0)
		{
		}

		public void method_9()
		{
		}

		public GClass558 method_10()
		{
			int num = 16;
			if (bool_0)
			{
				return null;
			}
			if (gclass558_0 != null)
			{
				method_12();
			}
			byte[] array = gclass561_0.method_7();
			if (array == null)
			{
				bool_0 = true;
			}
			else if (GClass561.smethod_4(array))
			{
				bool_0 = true;
			}
			if (bool_0)
			{
				gclass558_0 = null;
			}
			else
			{
				try
				{
					GClass560 gClass = new GClass560();
					gClass.method_29(array);
					if (!gClass.method_12())
					{
						throw new GException20("Header checksum is invalid");
					}
					long_1 = 0L;
					long_0 = gClass.method_7();
					StringBuilder stringBuilder = null;
					if (gClass.method_13() == 76)
					{
						byte[] array2 = new byte[512];
						long num2 = long_0;
						stringBuilder = new StringBuilder();
						while (num2 > 0L)
						{
							int num3 = Read(array2, 0, (int)((num2 > array2.Length) ? array2.Length : num2));
							if (num3 == -1)
							{
								throw new GException21("Failed to read long name entry");
							}
							stringBuilder.Append(GClass560.smethod_3(array2, 0, num3).ToString());
							num2 -= num3;
						}
						method_12();
						array = gclass561_0.method_7();
					}
					else if (gClass.method_13() == 103)
					{
						method_12();
						array = gclass561_0.method_7();
					}
					else if (gClass.method_13() == 120)
					{
						method_12();
						array = gclass561_0.method_7();
					}
					else if (gClass.method_13() == 86)
					{
						method_12();
						array = gclass561_0.method_7();
					}
					else if (gClass.method_13() != 48 && gClass.method_13() != 0 && gClass.method_13() != 53)
					{
						method_12();
						array = gclass561_0.method_7();
					}
					if (ginterface32_0 == null)
					{
						gclass558_0 = new GClass558(array);
						if (stringBuilder != null)
						{
							gclass558_0.Name = stringBuilder.ToString();
						}
					}
					else
					{
						gclass558_0 = ginterface32_0.imethod_2(array);
					}
					long_1 = 0L;
					long_0 = gclass558_0.method_15();
				}
				catch (GException21 gException)
				{
					long_0 = 0L;
					long_1 = 0L;
					gclass558_0 = null;
					string string_ = $"Bad header in record {gclass561_0.method_13()} block {gclass561_0.method_9()} {gException.Message}";
					throw new GException21(string_);
				}
			}
			return gclass558_0;
		}

		public void method_11(Stream stream_1)
		{
			byte[] array = new byte[32768];
			while (true)
			{
				int num = Read(array, 0, array.Length);
				if (num > 0)
				{
					stream_1.Write(array, 0, num);
					continue;
				}
				break;
			}
		}

		private void method_12()
		{
			long num = long_0 - long_1;
			if (num > 0L)
			{
				method_6(num);
			}
			byte_0 = null;
		}
	}
}
