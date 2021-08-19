using System;
using System.IO;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass577 : ICloneable
	{
		[ComVisible(false)]
		[Flags]
		private enum Enum31 : byte
		{
			flag_0 = 0x0,
			flag_1 = 0x1,
			flag_2 = 0x2,
			flag_3 = 0x4,
			flag_4 = 0x8,
			flag_5 = 0x10
		}

		private Enum31 enum31_0;

		private int int_0;

		private ushort ushort_0;

		private string string_0;

		private ulong ulong_0;

		private ulong ulong_1;

		private ushort ushort_1;

		private uint uint_0;

		private uint uint_1;

		private GEnum94 genum94_0;

		private byte[] byte_0;

		private string string_1;

		private int int_1;

		private long long_0;

		private long long_1;

		private bool bool_0;

		private byte byte_1;

		private int int_2;

		private int int_3;

		public string Name => string_0;

		public GClass577(string string_2)
			: this(string_2, 0, 51, GEnum94.const_1)
		{
		}

		internal GClass577(string string_2, int int_4)
			: this(string_2, int_4, 51, GEnum94.const_1)
		{
		}

		internal GClass577(string string_2, int int_4, int int_5, GEnum94 genum94_1)
		{
			int num = 7;
			int_0 = -1;
			genum94_0 = GEnum94.const_1;
			long_0 = -1L;
			
			if (string_2 == null)
			{
				throw new ArgumentNullException("name");
			}
			if (string_2.Length > 65535)
			{
				throw new ArgumentException("Name is too long", "name");
			}
			if (int_4 != 0 && int_4 < 10)
			{
				throw new ArgumentOutOfRangeException("versionRequiredToExtract");
			}
			method_29(DateTime.Now);
			string_0 = string_2;
			ushort_0 = (ushort)int_5;
			ushort_1 = (ushort)int_4;
			genum94_0 = genum94_1;
		}

		[Obsolete("Use Clone instead")]
		public GClass577(GClass577 gclass577_0)
		{
			int num = 18;
			int_0 = -1;
			genum94_0 = GEnum94.const_1;
			long_0 = -1L;
			
			if (gclass577_0 == null)
			{
				throw new ArgumentNullException("entry");
			}
			enum31_0 = gclass577_0.enum31_0;
			string_0 = gclass577_0.string_0;
			ulong_0 = gclass577_0.ulong_0;
			ulong_1 = gclass577_0.ulong_1;
			uint_0 = gclass577_0.uint_0;
			uint_1 = gclass577_0.uint_1;
			genum94_0 = gclass577_0.genum94_0;
			string_1 = gclass577_0.string_1;
			ushort_1 = gclass577_0.ushort_1;
			ushort_0 = gclass577_0.ushort_0;
			int_0 = gclass577_0.int_0;
			int_1 = gclass577_0.int_1;
			long_0 = gclass577_0.long_0;
			long_1 = gclass577_0.long_1;
			bool_0 = gclass577_0.bool_0;
			if (gclass577_0.byte_0 != null)
			{
				byte_0 = new byte[gclass577_0.byte_0.Length];
				Array.Copy(gclass577_0.byte_0, 0, byte_0, 0, gclass577_0.byte_0.Length);
			}
		}

		public bool method_0()
		{
			return (enum31_0 & Enum31.flag_3) != 0;
		}

		public bool method_1()
		{
			return (int_1 & 1) != 0;
		}

		public void method_2(bool bool_1)
		{
			if (bool_1)
			{
				int_1 |= 1;
			}
			else
			{
				int_1 &= -2;
			}
		}

		public bool method_3()
		{
			return (int_1 & 0x800) != 0;
		}

		public void method_4(bool bool_1)
		{
			if (bool_1)
			{
				int_1 |= 2048;
			}
			else
			{
				int_1 &= -2049;
			}
		}

		internal byte method_5()
		{
			return byte_1;
		}

		internal void method_6(byte byte_2)
		{
			byte_1 = byte_2;
		}

		public int method_7()
		{
			return int_1;
		}

		public void method_8(int int_4)
		{
			int_1 = int_4;
		}

		public long method_9()
		{
			return long_0;
		}

		public void method_10(long long_2)
		{
			long_0 = long_2;
		}

		public long method_11()
		{
			return long_1;
		}

		public void method_12(long long_2)
		{
			long_1 = long_2;
		}

		public int method_13()
		{
			if ((enum31_0 & Enum31.flag_5) == 0)
			{
				return -1;
			}
			return int_0;
		}

		public void method_14(int int_4)
		{
			int_0 = int_4;
			enum31_0 |= Enum31.flag_5;
		}

		public int method_15()
		{
			return ushort_0 & 0xFF;
		}

		public bool method_16()
		{
			return method_18() == 0 || method_18() == 10;
		}

		private bool method_17(int int_4)
		{
			bool result = false;
			if ((enum31_0 & Enum31.flag_5) != 0 && (method_18() == 0 || method_18() == 10) && (method_13() & int_4) == int_4)
			{
				result = true;
			}
			return result;
		}

		public int method_18()
		{
			return (ushort_0 >> 8) & 0xFF;
		}

		public void method_19(int int_4)
		{
			ushort_0 &= 255;
			ushort_0 |= (ushort)((int_4 & 0xFF) << 8);
		}

		public int method_20()
		{
			if (ushort_1 != 0)
			{
				return ushort_1;
			}
			int result = 10;
			if (method_41() > 0)
			{
				result = 51;
			}
			else if (method_25())
			{
				result = 45;
			}
			else if (GEnum94.const_1 == genum94_0)
			{
				result = 20;
			}
			else if (method_50())
			{
				result = 20;
			}
			else if (method_1())
			{
				result = 20;
			}
			else if (method_17(8))
			{
				result = 11;
			}
			return result;
		}

		public bool method_21()
		{
			return method_20() <= 51 && (method_20() == 10 || method_20() == 11 || method_20() == 20 || method_20() == 45 || method_20() == 51) && method_52();
		}

		public void method_22()
		{
			bool_0 = true;
		}

		public bool method_23()
		{
			return bool_0;
		}

		public bool method_24()
		{
			bool result;
			if (!(result = bool_0))
			{
				ulong num = ulong_1;
				if (ushort_1 == 0 && method_1())
				{
					num += 12L;
				}
				result = ((ulong_0 >= 4294967295L || num >= 4294967295L) && (ushort_1 == 0 || ushort_1 >= 45));
			}
			return result;
		}

		public bool method_25()
		{
			return method_24() || long_1 >= 4294967295L;
		}

		public long method_26()
		{
			if ((enum31_0 & Enum31.flag_4) == 0)
			{
				return 0L;
			}
			return uint_1;
		}

		public void method_27(long long_2)
		{
			uint_1 = (uint)long_2;
			enum31_0 |= Enum31.flag_4;
		}

		public DateTime method_28()
		{
			uint second = Math.Min(59u, 2 * (uint_1 & 0x1F));
			uint minute = Math.Min(59u, (uint_1 >> 5) & 0x3F);
			uint hour = Math.Min(23u, (uint_1 >> 11) & 0x1F);
			uint month = Math.Max(1u, Math.Min(12u, (uint_1 >> 21) & 0xF));
			uint year = ((uint_1 >> 25) & 0x7F) + 1980;
			int day = Math.Max(1, Math.Min(DateTime.DaysInMonth((int)year, (int)month), (int)((uint_1 >> 16) & 0x1F)));
			return new DateTime((int)year, (int)month, day, (int)hour, (int)minute, (int)second);
		}

		public void method_29(DateTime dateTime_0)
		{
			uint num = (uint)dateTime_0.Year;
			uint num2 = (uint)dateTime_0.Month;
			uint num3 = (uint)dateTime_0.Day;
			uint num4 = (uint)dateTime_0.Hour;
			uint num5 = (uint)dateTime_0.Minute;
			uint num6 = (uint)dateTime_0.Second;
			if (num < 1980)
			{
				num = 1980u;
				num2 = 1u;
				num3 = 1u;
				num4 = 0u;
				num5 = 0u;
				num6 = 0u;
			}
			else if (num > 2107)
			{
				num = 2107u;
				num2 = 12u;
				num3 = 31u;
				num4 = 23u;
				num5 = 59u;
				num6 = 59u;
			}
			method_27((((num - 1980) & 0x7F) << 25) | (num2 << 21) | (num3 << 16) | (num4 << 11) | (num5 << 5) | (num6 >> 1));
		}

		public long method_30()
		{
			return ((enum31_0 & Enum31.flag_1) != 0) ? ((long)ulong_0) : (-1L);
		}

		public void method_31(long long_2)
		{
			ulong_0 = (ulong)long_2;
			enum31_0 |= Enum31.flag_1;
		}

		public long method_32()
		{
			return ((enum31_0 & Enum31.flag_2) != 0) ? ((long)ulong_1) : (-1L);
		}

		public void method_33(long long_2)
		{
			ulong_1 = (ulong)long_2;
			enum31_0 |= Enum31.flag_2;
		}

		public long method_34()
		{
			return ((enum31_0 & Enum31.flag_3) != 0) ? (uint_0 & 0xFFFFFFFF) : (-1L);
		}

		public void method_35(long long_2)
		{
			uint_0 = (uint)long_2;
			enum31_0 |= Enum31.flag_3;
		}

		public GEnum94 method_36()
		{
			return genum94_0;
		}

		public void method_37(GEnum94 genum94_1)
		{
			int num = 19;
			if (!smethod_0(genum94_1))
			{
				throw new NotSupportedException("Compression method not supported");
			}
			genum94_0 = genum94_1;
		}

		internal GEnum94 method_38()
		{
			return (method_41() > 0) ? GEnum94.const_4 : genum94_0;
		}

		public byte[] method_39()
		{
			return byte_0;
		}

		public void method_40(byte[] byte_2)
		{
			int num = 0;
			if (byte_2 == null)
			{
				byte_0 = null;
				return;
			}
			if (byte_2.Length > 65535)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			byte_0 = new byte[byte_2.Length];
			Array.Copy(byte_2, 0, byte_0, 0, byte_2.Length);
		}

		public int method_41()
		{
			int num = 4;
			switch (int_3)
			{
			default:
				throw new GException24("Invalid AESEncryptionStrength " + int_3);
			case 0:
				return 0;
			case 1:
				return 128;
			case 2:
				return 192;
			case 3:
				return 256;
			}
		}

		public void method_42(int int_4)
		{
			int num = 0;
			switch (int_4)
			{
			default:
				throw new GException24("AESKeySize must be 0, 128 or 256: " + int_4);
			case 256:
				int_3 = 3;
				break;
			case 128:
				int_3 = 1;
				break;
			case 0:
				int_3 = 0;
				break;
			}
		}

		internal byte method_43()
		{
			return (byte)int_3;
		}

		internal int method_44()
		{
			return method_41() / 16;
		}

		internal int method_45()
		{
			return 12 + method_44();
		}

		internal void method_46(bool bool_1)
		{
			int num = 8;
			GClass585 gClass = new GClass585(byte_0);
			if (gClass.method_8(1))
			{
				bool_0 = true;
				if (gClass.method_5() < 4)
				{
					throw new GException24("Extra data extended Zip64 information length is invalid");
				}
				if (bool_1 || ulong_0 == 4294967295L)
				{
					ulong_0 = (ulong)gClass.method_19();
				}
				if (bool_1 || ulong_1 == 4294967295L)
				{
					ulong_1 = (ulong)gClass.method_19();
				}
				if (!bool_1 && long_1 == 4294967295L)
				{
					long_1 = gClass.method_19();
				}
			}
			else if ((ushort_1 & 0xFF) >= 45 && (ulong_0 == 4294967295L || ulong_1 == 4294967295L))
			{
				throw new GException24("Zip64 Extended information required but is missing.");
			}
			if (gClass.method_8(10))
			{
				if (gClass.method_5() < 4)
				{
					throw new GException24("NTFS Extra data invalid");
				}
				gClass.method_20();
				while (gClass.method_7() >= 4)
				{
					int num2 = gClass.method_21();
					int num3 = gClass.method_21();
					if (num2 != 1)
					{
						gClass.method_23(num3);
						continue;
					}
					if (num3 >= 24)
					{
						long fileTime = gClass.method_19();
						gClass.method_19();
						gClass.method_19();
						method_29(DateTime.FromFileTime(fileTime));
					}
					break;
				}
			}
			else if (gClass.method_8(21589))
			{
				int num4 = gClass.method_5();
				int num5 = gClass.method_22();
				if ((num5 & 1) != 0 && num4 >= 5)
				{
					int seconds = gClass.method_20();
					method_29((new DateTime(1970, 1, 1, 0, 0, 0).ToUniversalTime() + new TimeSpan(0, 0, 0, seconds, 0)).ToLocalTime());
				}
			}
			if (genum94_0 == GEnum94.const_4)
			{
				method_47(gClass);
			}
		}

		private void method_47(GClass585 gclass585_0)
		{
			int num = 18;
			if (gclass585_0.method_8(39169))
			{
				ushort_1 = 51;
				method_8(method_7() | 0x40);
				int num2 = gclass585_0.method_5();
				if (num2 < 7)
				{
					throw new GException24("AES Extra Data Length " + num2 + " invalid.");
				}
				int num3 = gclass585_0.method_21();
				gclass585_0.method_21();
				int num4 = gclass585_0.method_22();
				int num5 = gclass585_0.method_21();
				int_2 = num3;
				int_3 = num4;
				genum94_0 = (GEnum94)num5;
				return;
			}
			throw new GException24("AES Extra Data missing");
		}

		public string method_48()
		{
			return string_1;
		}

		public void method_49(string string_2)
		{
			int num = 16;
			if (string_2 != null && string_2.Length > 65535)
			{
				throw new ArgumentOutOfRangeException("value", "cannot exceed 65535");
			}
			string_1 = string_2;
		}

		public bool method_50()
		{
			int length = string_0.Length;
			return (length > 0 && (string_0[length - 1] == '/' || string_0[length - 1] == '\\')) || method_17(16);
		}

		public bool method_51()
		{
			return !method_50() && !method_17(8);
		}

		public bool method_52()
		{
			return smethod_0(method_36());
		}

		public object Clone()
		{
			GClass577 gClass = (GClass577)MemberwiseClone();
			if (byte_0 != null)
			{
				gClass.byte_0 = new byte[byte_0.Length];
				Array.Copy(byte_0, 0, gClass.byte_0, 0, byte_0.Length);
			}
			return gClass;
		}

		public override string ToString()
		{
			return string_0;
		}

		public static bool smethod_0(GEnum94 genum94_1)
		{
			return genum94_1 == GEnum94.const_1 || genum94_1 == GEnum94.const_0;
		}

		public static string smethod_1(string string_2)
		{
			int num = 14;
			if (string_2 == null)
			{
				return string.Empty;
			}
			if (Path.IsPathRooted(string_2))
			{
				string_2 = string_2.Substring(Path.GetPathRoot(string_2).Length);
			}
			string_2 = string_2.Replace("\\", "/");
			while (string_2.Length > 0 && string_2[0] == '/')
			{
				string_2 = string_2.Remove(0, 1);
			}
			return string_2;
		}
	}
}
