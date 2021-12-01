using System;
using System.IO;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	internal class Stream0 : Stream
	{
		private bool bool_0;

		private Stream stream_0;

		public override bool CanRead => stream_0.CanRead;

		public override bool CanSeek => stream_0.CanSeek;

		public override bool CanTimeout => stream_0.CanTimeout;

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
				stream_0.Position = value;
			}
		}

		public Stream0(string string_0)
		{
			stream_0 = new FileStream(string_0, FileMode.Open, FileAccess.ReadWrite);
			bool_0 = true;
		}

		public Stream0(Stream stream_1)
		{
			stream_0 = stream_1;
		}

		public bool method_0()
		{
			return bool_0;
		}

		public void method_1(bool bool_1)
		{
			bool_0 = bool_1;
		}

		public override void Flush()
		{
			stream_0.Flush();
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			return stream_0.Seek(offset, origin);
		}

		public override void SetLength(long value)
		{
			stream_0.SetLength(value);
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return stream_0.Read(buffer, offset, count);
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			stream_0.Write(buffer, offset, count);
		}

		public override void Close()
		{
			Stream stream = stream_0;
			stream_0 = null;
			if (bool_0 && stream != null)
			{
				bool_0 = false;
				stream.Close();
			}
		}

		private void method_2(GClass577 gclass577_0, Class216 class216_0)
		{
			int num = 18;
			GEnum94 gEnum = gclass577_0.method_36();
			bool flag = true;
			bool flag2 = false;
			method_11(67324752);
			method_9(gclass577_0.method_20());
			method_9(gclass577_0.method_7());
			method_9((byte)gEnum);
			method_11((int)gclass577_0.method_26());
			method_11((int)gclass577_0.method_34());
			if (gclass577_0.method_24())
			{
				method_11(-1);
				method_11(-1);
			}
			else
			{
				method_11((int)(gclass577_0.method_1() ? ((int)gclass577_0.method_32() + 12) : gclass577_0.method_32()));
				method_11((int)gclass577_0.method_30());
			}
			byte[] array = GClass547.smethod_7(gclass577_0.method_7(), gclass577_0.Name);
			if (array.Length > 65535)
			{
				throw new GException24("Entry name too long.");
			}
			GClass585 gClass = new GClass585(gclass577_0.method_39());
			if (gclass577_0.method_24() && (flag || flag2))
			{
				gClass.method_11();
				if (flag)
				{
					gClass.method_17(gclass577_0.method_30());
					gClass.method_17(gclass577_0.method_32());
				}
				else
				{
					gClass.method_17(-1L);
					gClass.method_17(-1L);
				}
				gClass.method_12(1);
				if (!gClass.method_8(1))
				{
					throw new GException24("Internal error cant find extra data");
				}
				class216_0?.method_1(gClass.method_6());
			}
			else
			{
				gClass.method_18(1);
			}
			byte[] array2 = gClass.method_0();
			method_9(array.Length);
			method_9(array2.Length);
			if (array.Length > 0)
			{
				stream_0.Write(array, 0, array.Length);
			}
			if (gclass577_0.method_24() && flag2)
			{
				class216_0.method_1(class216_0.method_0() + stream_0.Position);
			}
			if (array2.Length > 0)
			{
				stream_0.Write(array2, 0, array2.Length);
			}
		}

		public long method_3(int int_0, long long_0, int int_1, int int_2)
		{
			long num = long_0 - int_1;
			if (num < 0L)
			{
				return -1L;
			}
			long num2 = Math.Max(num - int_2, 0L);
			do
			{
				if (num >= num2)
				{
					Seek(num--, SeekOrigin.Begin);
					continue;
				}
				return -1L;
			}
			while (method_7() != int_0);
			return Position;
		}

		public void method_4(long long_0, long long_1, long long_2)
		{
			long position = stream_0.Position;
			method_11(101075792);
			method_13(44L);
			method_9(51);
			method_9(45);
			method_11(0);
			method_11(0);
			method_13(long_0);
			method_13(long_0);
			method_13(long_1);
			method_13(long_2);
			method_11(117853008);
			method_11(0);
			method_13(position);
			method_11(1);
		}

		public void method_5(long long_0, long long_1, long long_2, byte[] byte_0)
		{
			int num = 3;
			if (long_0 >= 65535L || long_2 >= 4294967295L || long_1 >= 4294967295L)
			{
				method_4(long_0, long_1, long_2);
			}
			method_11(101010256);
			method_9(0);
			method_9(0);
			if (long_0 >= 65535L)
			{
				method_10(ushort.MaxValue);
				method_10(ushort.MaxValue);
			}
			else
			{
				method_9((short)long_0);
				method_9((short)long_0);
			}
			if (long_1 >= 4294967295L)
			{
				method_12(uint.MaxValue);
			}
			else
			{
				method_11((int)long_1);
			}
			if (long_2 >= 4294967295L)
			{
				method_12(uint.MaxValue);
			}
			else
			{
				method_11((int)long_2);
			}
			int num2 = (byte_0 != null) ? byte_0.Length : 0;
			if (num2 > 65535)
			{
				throw new GException24($"Comment length({num2}) is too long can only be 64K");
			}
			method_9(num2);
			if (num2 > 0)
			{
				Write(byte_0, 0, byte_0.Length);
			}
		}

		public int method_6()
		{
			int num = stream_0.ReadByte();
			if (num < 0)
			{
				throw new EndOfStreamException();
			}
			int num2 = stream_0.ReadByte();
			if (num2 < 0)
			{
				throw new EndOfStreamException();
			}
			return num | (num2 << 8);
		}

		public int method_7()
		{
			return method_6() | (method_6() << 16);
		}

		public long method_8()
		{
			return (uint)method_7() | ((long)method_7() << 32);
		}

		public void method_9(int int_0)
		{
			stream_0.WriteByte((byte)(int_0 & 0xFF));
			stream_0.WriteByte((byte)((int_0 >> 8) & 0xFF));
		}

		public void method_10(ushort ushort_0)
		{
			stream_0.WriteByte((byte)(ushort_0 & 0xFF));
			stream_0.WriteByte((byte)(ushort_0 >> 8));
		}

		public void method_11(int int_0)
		{
			method_9(int_0);
			method_9(int_0 >> 16);
		}

		public void method_12(uint uint_0)
		{
			method_10((ushort)(uint_0 & 0xFFFF));
			method_10((ushort)(uint_0 >> 16));
		}

		public void method_13(long long_0)
		{
			method_11((int)long_0);
			method_11((int)(long_0 >> 32));
		}

		public void method_14(ulong ulong_0)
		{
			method_12((uint)(ulong_0 & 0xFFFFFFFF));
			method_12((uint)(ulong_0 >> 32));
		}

		public int method_15(GClass577 gclass577_0)
		{
			int num = 13;
			if (gclass577_0 == null)
			{
				throw new ArgumentNullException("entry");
			}
			int num2 = 0;
			if ((gclass577_0.method_7() & 8) != 0)
			{
				method_11(134695760);
				method_11((int)gclass577_0.method_34());
				num2 += 8;
				if (gclass577_0.method_24())
				{
					method_13(gclass577_0.method_32());
					method_13(gclass577_0.method_30());
					num2 += 16;
				}
				else
				{
					method_11((int)gclass577_0.method_32());
					method_11((int)gclass577_0.method_30());
					num2 += 8;
				}
			}
			return num2;
		}

		public void method_16(bool bool_1, GClass551 gclass551_0)
		{
			int num = 16;
			int num2 = method_7();
			if (num2 != 134695760)
			{
				throw new GException24("Data descriptor signature not found");
			}
			gclass551_0.method_5(method_7());
			if (bool_1)
			{
				gclass551_0.method_1(method_8());
				gclass551_0.method_3(method_8());
			}
			else
			{
				gclass551_0.method_1(method_7());
				gclass551_0.method_3(method_7());
			}
		}
	}
}
