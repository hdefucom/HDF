using System;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GStream6 : GStream5
	{
		private ArrayList arrayList_0 = new ArrayList();

		private GClass548 gclass548_0 = new GClass548();

		private GClass577 gclass577_0;

		private int int_0 = -1;

		private GEnum94 genum94_0 = GEnum94.const_1;

		private long long_0;

		private long long_1;

		private byte[] byte_2 = new byte[0];

		private bool bool_2;

		private long long_2 = -1L;

		private long long_3 = -1L;

		private GEnum93 genum93_0 = GEnum93.const_2;

		public GStream6(Stream stream_1)
			: base(stream_1, new GClass586(-1, bool_1: true))
		{
		}

		public GStream6(Stream stream_1, int int_1)
			: base(stream_1, new GClass586(-1, bool_1: true), int_1)
		{
		}

		public bool method_10()
		{
			return arrayList_0 == null;
		}

		public void method_11(string string_1)
		{
			int num = 7;
			byte[] array = GClass547.smethod_6(string_1);
			if (array.Length > 65535)
			{
				throw new ArgumentOutOfRangeException("comment");
			}
			byte_2 = array;
		}

		public void method_12(int int_1)
		{
			gclass586_0.method_10(int_1);
			int_0 = int_1;
		}

		public int method_13()
		{
			return gclass586_0.method_11();
		}

		public GEnum93 method_14()
		{
			return genum93_0;
		}

		public void method_15(GEnum93 genum93_1)
		{
			genum93_0 = genum93_1;
		}

		private void method_16(int int_1)
		{
			stream_0.WriteByte((byte)(int_1 & 0xFF));
			stream_0.WriteByte((byte)((int_1 >> 8) & 0xFF));
		}

		private void method_17(int int_1)
		{
			method_16(int_1);
			method_16(int_1 >> 16);
		}

		private void method_18(long long_4)
		{
			method_17((int)long_4);
			method_17((int)(long_4 >> 32));
		}

		public void method_19(GClass577 gclass577_1)
		{
			int num = 11;
			if (gclass577_1 == null)
			{
				throw new ArgumentNullException("entry");
			}
			if (arrayList_0 == null)
			{
				throw new InvalidOperationException("ZipOutputStream was finished");
			}
			if (gclass577_0 != null)
			{
				method_20();
			}
			if (arrayList_0.Count == int.MaxValue)
			{
				throw new GException24("Too many entries for Zip file");
			}
			GEnum94 gEnum = gclass577_1.method_36();
			int int_ = int_0;
			gclass577_1.method_8(gclass577_1.method_7() & 0x800);
			bool_2 = false;
			bool flag;
			if (gclass577_1.method_30() == 0L)
			{
				gclass577_1.method_33(gclass577_1.method_30());
				gclass577_1.method_35(0L);
				gEnum = GEnum94.const_0;
				flag = true;
			}
			else
			{
				flag = (gclass577_1.method_30() >= 0L && gclass577_1.method_0());
				if (gEnum == GEnum94.const_0)
				{
					if (!flag)
					{
						if (!method_2())
						{
							gEnum = GEnum94.const_1;
							int_ = 0;
						}
					}
					else
					{
						gclass577_1.method_33(gclass577_1.method_30());
						flag = gclass577_1.method_0();
					}
				}
			}
			if (!flag)
			{
				if (!method_2())
				{
					gclass577_1.method_8(gclass577_1.method_7() | 8);
				}
				else
				{
					bool_2 = true;
				}
			}
			if (method_3() != null)
			{
				gclass577_1.method_2(bool_1: true);
				if (gclass577_1.method_34() < 0L)
				{
					gclass577_1.method_8(gclass577_1.method_7() | 8);
				}
			}
			gclass577_1.method_12(long_1);
			gclass577_1.method_37(gEnum);
			genum94_0 = gEnum;
			long_3 = -1L;
			if (genum93_0 == GEnum93.const_1 || (gclass577_1.method_30() < 0L && genum93_0 == GEnum93.const_2))
			{
				gclass577_1.method_22();
			}
			method_17(67324752);
			method_16(gclass577_1.method_20());
			method_16(gclass577_1.method_7());
			method_16((byte)gclass577_1.method_38());
			method_17((int)gclass577_1.method_26());
			if (flag)
			{
				method_17((int)gclass577_1.method_34());
				if (gclass577_1.method_24())
				{
					method_17(-1);
					method_17(-1);
				}
				else
				{
					method_17((int)(gclass577_1.method_1() ? ((int)gclass577_1.method_32() + 12) : gclass577_1.method_32()));
					method_17((int)gclass577_1.method_30());
				}
			}
			else
			{
				if (bool_2)
				{
					long_2 = stream_0.Position;
				}
				method_17(0);
				if (bool_2)
				{
					long_3 = stream_0.Position;
				}
				if (gclass577_1.method_24() || bool_2)
				{
					method_17(-1);
					method_17(-1);
				}
				else
				{
					method_17(0);
					method_17(0);
				}
			}
			byte[] array = GClass547.smethod_7(gclass577_1.method_7(), gclass577_1.Name);
			if (array.Length > 65535)
			{
				throw new GException24("Entry name too long.");
			}
			GClass585 gClass = new GClass585(gclass577_1.method_39());
			if (gclass577_1.method_24())
			{
				gClass.method_11();
				if (flag)
				{
					gClass.method_17(gclass577_1.method_30());
					gClass.method_17(gclass577_1.method_32());
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
				if (bool_2)
				{
					long_3 = gClass.method_6();
				}
			}
			else
			{
				gClass.method_18(1);
			}
			if (gclass577_1.method_41() > 0)
			{
				smethod_0(gclass577_1, gClass);
			}
			byte[] array2 = gClass.method_0();
			method_16(array.Length);
			method_16(array2.Length);
			if (array.Length > 0)
			{
				stream_0.Write(array, 0, array.Length);
			}
			if (gclass577_1.method_24() && bool_2)
			{
				long_3 += stream_0.Position;
			}
			if (array2.Length > 0)
			{
				stream_0.Write(array2, 0, array2.Length);
			}
			long_1 += 30 + array.Length + array2.Length;
			if (gclass577_1.method_41() > 0)
			{
				long_1 += gclass577_1.method_45();
			}
			gclass577_0 = gclass577_1;
			gclass548_0.imethod_1();
			if (gEnum == GEnum94.const_1)
			{
				gclass586_0.method_0();
				gclass586_0.method_10(int_);
			}
			long_0 = 0L;
			if (gclass577_1.method_1())
			{
				if (gclass577_1.method_41() > 0)
				{
					method_22(gclass577_1);
				}
				else if (gclass577_1.method_34() < 0L)
				{
					method_21(gclass577_1.method_26() << 16);
				}
				else
				{
					method_21(gclass577_1.method_34());
				}
			}
		}

		public void method_20()
		{
			int num = 14;
			if (gclass577_0 == null)
			{
				throw new InvalidOperationException("No open entry");
			}
			long num2 = long_0;
			if (genum94_0 == GEnum94.const_1)
			{
				if (long_0 >= 0L)
				{
					base.vmethod_0();
					num2 = gclass586_0.method_3();
				}
				else
				{
					gclass586_0.method_0();
				}
			}
			if (gclass577_0.method_41() > 0)
			{
				stream_0.Write(byte_0, 0, 10);
			}
			if (gclass577_0.method_30() < 0L)
			{
				gclass577_0.method_31(long_0);
			}
			else if (gclass577_0.method_30() != long_0)
			{
				throw new GException24("size was " + long_0 + ", but I expected " + gclass577_0.method_30());
			}
			if (gclass577_0.method_32() < 0L)
			{
				gclass577_0.method_33(num2);
			}
			else if (gclass577_0.method_32() != num2)
			{
				throw new GException24("compressed size was " + num2 + ", but I expected " + gclass577_0.method_32());
			}
			if (gclass577_0.method_34() < 0L)
			{
				gclass577_0.method_35(gclass548_0.imethod_0());
			}
			else if (gclass577_0.method_34() != gclass548_0.imethod_0())
			{
				throw new GException24("crc was " + gclass548_0.imethod_0() + ", but I expected " + gclass577_0.method_34());
			}
			long_1 += num2;
			if (gclass577_0.method_1())
			{
				if (gclass577_0.method_41() > 0)
				{
					GClass577 gClass = gclass577_0;
					gClass.method_33(gClass.method_32() + gclass577_0.method_45());
				}
				else
				{
					GClass577 gClass2 = gclass577_0;
					gClass2.method_33(gClass2.method_32() + 12L);
				}
			}
			if (bool_2)
			{
				bool_2 = false;
				long position = stream_0.Position;
				stream_0.Seek(long_2, SeekOrigin.Begin);
				method_17((int)gclass577_0.method_34());
				if (gclass577_0.method_24())
				{
					if (long_3 == -1L)
					{
						throw new GException24("Entry requires zip64 but this has been turned off");
					}
					stream_0.Seek(long_3, SeekOrigin.Begin);
					method_18(gclass577_0.method_30());
					method_18(gclass577_0.method_32());
				}
				else
				{
					method_17((int)gclass577_0.method_32());
					method_17((int)gclass577_0.method_30());
				}
				stream_0.Seek(position, SeekOrigin.Begin);
			}
			if ((gclass577_0.method_7() & 8) != 0)
			{
				method_17(134695760);
				method_17((int)gclass577_0.method_34());
				if (gclass577_0.method_24())
				{
					method_18(gclass577_0.method_32());
					method_18(gclass577_0.method_30());
					long_1 += 24L;
				}
				else
				{
					method_17((int)gclass577_0.method_32());
					method_17((int)gclass577_0.method_30());
					long_1 += 16L;
				}
			}
			arrayList_0.Add(gclass577_0);
			gclass577_0 = null;
		}

		private void method_21(long long_4)
		{
			long_1 += 12L;
			method_6(method_3());
			byte[] array = new byte[12];
			Random random = new Random();
			random.NextBytes(array);
			array[11] = (byte)(long_4 >> 24);
			method_5(array, 0, array.Length);
			stream_0.Write(array, 0, array.Length);
		}

		private static void smethod_0(GClass577 gclass577_1, GClass585 gclass585_0)
		{
			gclass585_0.method_11();
			gclass585_0.method_15(2);
			gclass585_0.method_15(17729);
			gclass585_0.method_13(gclass577_1.method_43());
			gclass585_0.method_15((int)gclass577_1.method_36());
			gclass585_0.method_12(39169);
		}

		private void method_22(GClass577 gclass577_1)
		{
			method_7(gclass577_1, method_3(), out byte[] array, out byte[] byte_);
			stream_0.Write(array, 0, array.Length);
			stream_0.Write(byte_, 0, byte_.Length);
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			int num = 1;
			if (gclass577_0 == null)
			{
				throw new InvalidOperationException("No open entry.");
			}
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
			gclass548_0.imethod_4(buffer, offset, count);
			long_0 += count;
			switch (genum94_0)
			{
			case GEnum94.const_1:
				base.Write(buffer, offset, count);
				break;
			case GEnum94.const_0:
				if (method_3() != null)
				{
					method_23(buffer, offset, count);
				}
				else
				{
					stream_0.Write(buffer, offset, count);
				}
				break;
			}
		}

		private void method_23(byte[] byte_3, int int_1, int int_2)
		{
			byte[] array = new byte[4096];
			while (int_2 > 0)
			{
				int num = (int_2 < 4096) ? int_2 : 4096;
				Array.Copy(byte_3, int_1, array, 0, num);
				method_5(array, 0, num);
				stream_0.Write(array, 0, num);
				int_2 -= num;
				int_1 += num;
			}
		}

		public override void vmethod_0()
		{
			int num = 5;
			if (arrayList_0 != null)
			{
				if (gclass577_0 != null)
				{
					method_20();
				}
				long num2 = arrayList_0.Count;
				long num3 = 0L;
				foreach (GClass577 item in arrayList_0)
				{
					method_17(33639248);
					method_16(51);
					method_16(item.method_20());
					method_16(item.method_7());
					method_16((short)item.method_38());
					method_17((int)item.method_26());
					method_17((int)item.method_34());
					if (item.method_23() || item.method_32() >= 4294967295L)
					{
						method_17(-1);
					}
					else
					{
						method_17((int)item.method_32());
					}
					if (item.method_23() || item.method_30() >= 4294967295L)
					{
						method_17(-1);
					}
					else
					{
						method_17((int)item.method_30());
					}
					byte[] array = GClass547.smethod_7(item.method_7(), item.Name);
					if (array.Length > 65535)
					{
						throw new GException24("Name too long.");
					}
					GClass585 gClass2 = new GClass585(item.method_39());
					if (item.method_25())
					{
						gClass2.method_11();
						if (item.method_23() || item.method_30() >= 4294967295L)
						{
							gClass2.method_17(item.method_30());
						}
						if (item.method_23() || item.method_32() >= 4294967295L)
						{
							gClass2.method_17(item.method_32());
						}
						if (item.method_11() >= 4294967295L)
						{
							gClass2.method_17(item.method_11());
						}
						gClass2.method_12(1);
					}
					else
					{
						gClass2.method_18(1);
					}
					if (item.method_41() > 0)
					{
						smethod_0(item, gClass2);
					}
					byte[] array2 = gClass2.method_0();
					byte[] array3 = (item.method_48() != null) ? GClass547.smethod_7(item.method_7(), item.method_48()) : new byte[0];
					if (array3.Length > 65535)
					{
						throw new GException24("Comment too long.");
					}
					method_16(array.Length);
					method_16(array2.Length);
					method_16(array3.Length);
					method_16(0);
					method_16(0);
					if (item.method_13() != -1)
					{
						method_17(item.method_13());
					}
					else if (item.method_50())
					{
						method_17(16);
					}
					else
					{
						method_17(0);
					}
					if (item.method_11() >= 4294967295L)
					{
						method_17(-1);
					}
					else
					{
						method_17((int)item.method_11());
					}
					if (array.Length > 0)
					{
						stream_0.Write(array, 0, array.Length);
					}
					if (array2.Length > 0)
					{
						stream_0.Write(array2, 0, array2.Length);
					}
					if (array3.Length > 0)
					{
						stream_0.Write(array3, 0, array3.Length);
					}
					num3 += 46 + array.Length + array2.Length + array3.Length;
				}
				using (Stream0 stream = new Stream0(stream_0))
				{
					stream.method_5(num2, num3, long_1, byte_2);
				}
				arrayList_0 = null;
			}
		}
	}
}
