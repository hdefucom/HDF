using System;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass560 : ICloneable
	{
		public const int int_0 = 100;

		public const int int_1 = 8;

		public const int int_2 = 8;

		public const int int_3 = 8;

		public const int int_4 = 8;

		public const int int_5 = 148;

		public const int int_6 = 12;

		public const int int_7 = 6;

		public const int int_8 = 2;

		public const int int_9 = 12;

		public const int int_10 = 32;

		public const int int_11 = 32;

		public const int int_12 = 8;

		public const byte byte_0 = 0;

		public const byte byte_1 = 48;

		public const byte byte_2 = 49;

		public const byte byte_3 = 50;

		public const byte byte_4 = 51;

		public const byte byte_5 = 52;

		public const byte byte_6 = 53;

		public const byte byte_7 = 54;

		public const byte byte_8 = 55;

		public const byte byte_9 = 103;

		public const byte byte_10 = 120;

		public const byte byte_11 = 65;

		public const byte byte_12 = 68;

		public const byte byte_13 = 69;

		public const byte byte_14 = 73;

		public const byte byte_15 = 75;

		public const byte byte_16 = 76;

		public const byte byte_17 = 77;

		public const byte byte_18 = 78;

		public const byte byte_19 = 83;

		public const byte byte_20 = 86;

		public const string string_0 = "ustar ";

		public const string string_1 = "ustar  ";

		private const long long_0 = 10000000L;

		private static readonly DateTime dateTime_0 = new DateTime(1970, 1, 1, 0, 0, 0, 0);

		private string string_2;

		private int int_13;

		private int int_14;

		private int int_15;

		private long long_1;

		private DateTime dateTime_1;

		private int int_16;

		private bool bool_0;

		private byte byte_21;

		private string string_3;

		private string string_4;

		private string string_5;

		private string string_6;

		private string string_7;

		private int int_17;

		private int int_18;

		internal static int int_19;

		internal static int int_20;

		internal static string string_8;

		internal static string string_9 = "None";

		internal static int int_21;

		internal static int int_22;

		internal static string string_10 = "None";

		internal static string string_11;

		public string Name
		{
			get
			{
				return string_2;
			}
			set
			{
				int num = 7;
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				string_2 = value;
			}
		}

		public GClass560()
		{
			method_18("ustar ");
			method_20(" ");
			Name = "";
			method_16("");
			method_4(int_21);
			method_6(int_22);
			method_22(string_11);
			method_24(string_10);
			method_8(0L);
		}

		[Obsolete("Use the Name property instead", true)]
		public string method_0()
		{
			return string_2;
		}

		public int method_1()
		{
			return int_13;
		}

		public void method_2(int int_23)
		{
			int_13 = int_23;
		}

		public int method_3()
		{
			return int_14;
		}

		public void method_4(int int_23)
		{
			int_14 = int_23;
		}

		public int method_5()
		{
			return int_15;
		}

		public void method_6(int int_23)
		{
			int_15 = int_23;
		}

		public long method_7()
		{
			return long_1;
		}

		public void method_8(long long_2)
		{
			int num = 11;
			if (long_2 < 0L)
			{
				throw new ArgumentOutOfRangeException("value", "Cannot be less than zero");
			}
			long_1 = long_2;
		}

		public DateTime method_9()
		{
			return dateTime_1;
		}

		public void method_10(DateTime dateTime_2)
		{
			int num = 8;
			if (dateTime_2 < dateTime_0)
			{
				throw new ArgumentOutOfRangeException("value", "ModTime cannot be before Jan 1st 1970");
			}
			dateTime_1 = new DateTime(dateTime_2.Year, dateTime_2.Month, dateTime_2.Day, dateTime_2.Hour, dateTime_2.Minute, dateTime_2.Second);
		}

		public int method_11()
		{
			return int_16;
		}

		public bool method_12()
		{
			return bool_0;
		}

		public byte method_13()
		{
			return byte_21;
		}

		public void method_14(byte byte_22)
		{
			byte_21 = byte_22;
		}

		public string method_15()
		{
			return string_3;
		}

		public void method_16(string string_12)
		{
			int num = 2;
			if (string_12 == null)
			{
				throw new ArgumentNullException("value");
			}
			string_3 = string_12;
		}

		public string method_17()
		{
			return string_4;
		}

		public void method_18(string string_12)
		{
			int num = 12;
			if (string_12 == null)
			{
				throw new ArgumentNullException("value");
			}
			string_4 = string_12;
		}

		public string method_19()
		{
			return string_5;
		}

		public void method_20(string string_12)
		{
			int num = 19;
			if (string_12 == null)
			{
				throw new ArgumentNullException("value");
			}
			string_5 = string_12;
		}

		public string method_21()
		{
			return string_6;
		}

		public void method_22(string string_12)
		{
			if (string_12 != null)
			{
				string_6 = string_12.Substring(0, Math.Min(32, string_12.Length));
				return;
			}
			string text = Environment.UserName;
			if (text.Length > 32)
			{
				text = text.Substring(0, 32);
			}
			string_6 = text;
		}

		public string method_23()
		{
			return string_7;
		}

		public void method_24(string string_12)
		{
			int num = 16;
			if (string_12 == null)
			{
				string_7 = "None";
			}
			else
			{
				string_7 = string_12;
			}
		}

		public int method_25()
		{
			return int_17;
		}

		public void method_26(int int_23)
		{
			int_17 = int_23;
		}

		public int method_27()
		{
			return int_18;
		}

		public void method_28(int int_23)
		{
			int_18 = int_23;
		}

		public object Clone()
		{
			return MemberwiseClone();
		}

		public void method_29(byte[] byte_22)
		{
			int num = 10;
			if (byte_22 == null)
			{
				throw new ArgumentNullException("header");
			}
			string_2 = smethod_3(byte_22, 0, 100).ToString();
			int_13 = (int)smethod_2(byte_22, 100, 8);
			method_4((int)smethod_2(byte_22, 108, 8));
			method_6((int)smethod_2(byte_22, 116, 8));
			method_8(smethod_2(byte_22, 124, 12));
			method_10(smethod_15(smethod_2(byte_22, 136, 12)));
			int_16 = (int)smethod_2(byte_22, 148, 8);
			method_14(byte_22[156]);
			method_16(smethod_3(byte_22, 157, 100).ToString());
			method_18(smethod_3(byte_22, 257, 6).ToString());
			method_20(smethod_3(byte_22, 263, 2).ToString());
			method_22(smethod_3(byte_22, 265, 32).ToString());
			method_24(smethod_3(byte_22, 297, 32).ToString());
			method_26((int)smethod_2(byte_22, 329, 8));
			method_28((int)smethod_2(byte_22, 337, 8));
			bool_0 = (method_11() == smethod_13(byte_22));
		}

		public void method_30(byte[] byte_22)
		{
			int num = 18;
			if (byte_22 == null)
			{
				throw new ArgumentNullException("outBuffer");
			}
			int num2 = 0;
			num2 = smethod_7(Name, byte_22, 0, 100);
			num2 = smethod_9(int_13, byte_22, num2, 8);
			num2 = smethod_9(method_3(), byte_22, num2, 8);
			num2 = smethod_9(method_5(), byte_22, num2, 8);
			num2 = smethod_10(method_7(), byte_22, num2, 12);
			num2 = smethod_10(smethod_14(method_9()), byte_22, num2, 12);
			int int_ = num2;
			for (int i = 0; i < 8; i++)
			{
				byte_22[num2++] = 32;
			}
			byte_22[num2++] = method_13();
			num2 = smethod_7(method_15(), byte_22, num2, 100);
			num2 = smethod_8(method_17(), 0, byte_22, num2, 6);
			num2 = smethod_7(method_19(), byte_22, num2, 2);
			num2 = smethod_7(method_21(), byte_22, num2, 32);
			num2 = smethod_7(method_23(), byte_22, num2, 32);
			if (method_13() == 51 || method_13() == 52)
			{
				num2 = smethod_9(method_25(), byte_22, num2, 8);
				num2 = smethod_9(method_27(), byte_22, num2, 8);
			}
			while (num2 < byte_22.Length)
			{
				byte_22[num2++] = 0;
			}
			int_16 = smethod_12(byte_22);
			smethod_11(int_16, byte_22, int_, 8);
			bool_0 = true;
		}

		public override int GetHashCode()
		{
			return Name.GetHashCode();
		}

		public override bool Equals(object other)
		{
			GClass560 gClass = other as GClass560;
			if (gClass != null)
			{
				return string_2 == gClass.string_2 && int_13 == gClass.int_13 && method_3() == gClass.method_3() && method_5() == gClass.method_5() && method_7() == gClass.method_7() && method_9() == gClass.method_9() && method_11() == gClass.method_11() && method_13() == gClass.method_13() && method_15() == gClass.method_15() && method_17() == gClass.method_17() && method_19() == gClass.method_19() && method_21() == gClass.method_21() && method_23() == gClass.method_23() && method_25() == gClass.method_25() && method_27() == gClass.method_27();
			}
			return false;
		}

		internal static void smethod_0(int int_23, string string_12, int int_24, string string_13)
		{
			int_21 = (int_19 = int_23);
			string_11 = (string_8 = string_12);
			int_22 = (int_20 = int_24);
			string_10 = (string_9 = string_13);
		}

		internal static void smethod_1()
		{
			int_21 = int_19;
			string_11 = string_8;
			int_22 = int_20;
			string_10 = string_9;
		}

		public static long smethod_2(byte[] byte_22, int int_23, int int_24)
		{
			int num = 14;
			if (byte_22 == null)
			{
				throw new ArgumentNullException("header");
			}
			long num2 = 0L;
			bool flag = true;
			int num3 = int_23 + int_24;
			for (int i = int_23; i < num3 && byte_22[i] != 0; i++)
			{
				if (byte_22[i] == 32 || byte_22[i] == 48)
				{
					if (flag)
					{
						continue;
					}
					if (byte_22[i] == 32)
					{
						break;
					}
				}
				flag = false;
				num2 = (num2 << 3) + (byte_22[i] - 48);
			}
			return num2;
		}

		public static StringBuilder smethod_3(byte[] byte_22, int int_23, int int_24)
		{
			int num = 7;
			if (byte_22 == null)
			{
				throw new ArgumentNullException("header");
			}
			if (int_23 < 0)
			{
				throw new ArgumentOutOfRangeException("offset", "Cannot be less than zero");
			}
			if (int_24 < 0)
			{
				throw new ArgumentOutOfRangeException("length", "Cannot be less than zero");
			}
			if (int_23 + int_24 > byte_22.Length)
			{
				throw new ArgumentException("Exceeds header size", "length");
			}
			StringBuilder stringBuilder = new StringBuilder(int_24);
			for (int i = int_23; i < int_23 + int_24 && byte_22[i] != 0; i++)
			{
				stringBuilder.Append((char)byte_22[i]);
			}
			return stringBuilder;
		}

		public static int smethod_4(StringBuilder stringBuilder_0, int int_23, byte[] byte_22, int int_24, int int_25)
		{
			int num = 1;
			if (stringBuilder_0 == null)
			{
				throw new ArgumentNullException("name");
			}
			if (byte_22 == null)
			{
				throw new ArgumentNullException("buffer");
			}
			return smethod_5(stringBuilder_0.ToString(), int_23, byte_22, int_24, int_25);
		}

		public static int smethod_5(string string_12, int int_23, byte[] byte_22, int int_24, int int_25)
		{
			int num = 19;
			if (string_12 == null)
			{
				throw new ArgumentNullException("name");
			}
			if (byte_22 == null)
			{
				throw new ArgumentNullException("buffer");
			}
			int i;
			for (i = 0; i < int_25 - 1 && int_23 + i < string_12.Length; i++)
			{
				byte_22[int_24 + i] = (byte)string_12[int_23 + i];
			}
			for (; i < int_25; i++)
			{
				byte_22[int_24 + i] = 0;
			}
			return int_24 + int_25;
		}

		public static int smethod_6(StringBuilder stringBuilder_0, byte[] byte_22, int int_23, int int_24)
		{
			int num = 8;
			if (stringBuilder_0 == null)
			{
				throw new ArgumentNullException("name");
			}
			if (byte_22 == null)
			{
				throw new ArgumentNullException("buffer");
			}
			return smethod_5(stringBuilder_0.ToString(), 0, byte_22, int_23, int_24);
		}

		public static int smethod_7(string string_12, byte[] byte_22, int int_23, int int_24)
		{
			int num = 1;
			if (string_12 == null)
			{
				throw new ArgumentNullException("name");
			}
			if (byte_22 == null)
			{
				throw new ArgumentNullException("buffer");
			}
			return smethod_5(string_12, 0, byte_22, int_23, int_24);
		}

		public static int smethod_8(string string_12, int int_23, byte[] byte_22, int int_24, int int_25)
		{
			int num = 10;
			if (string_12 == null)
			{
				throw new ArgumentNullException("toAdd");
			}
			if (byte_22 == null)
			{
				throw new ArgumentNullException("buffer");
			}
			for (int i = 0; i < int_25 && int_23 + i < string_12.Length; i++)
			{
				byte_22[int_24 + i] = (byte)string_12[int_23 + i];
			}
			return int_24 + int_25;
		}

		public static int smethod_9(long long_2, byte[] byte_22, int int_23, int int_24)
		{
			int num = 6;
			if (byte_22 == null)
			{
				throw new ArgumentNullException("buffer");
			}
			int num2 = int_24 - 1;
			byte_22[int_23 + num2] = 0;
			num2--;
			if (long_2 > 0L)
			{
				long num3 = long_2;
				while (num2 >= 0 && num3 > 0L)
				{
					byte_22[int_23 + num2] = (byte)(48 + (byte)(num3 & 7L));
					num3 >>= 3;
					num2--;
				}
			}
			while (num2 >= 0)
			{
				byte_22[int_23 + num2] = 48;
				num2--;
			}
			return int_23 + int_24;
		}

		public static int smethod_10(long long_2, byte[] byte_22, int int_23, int int_24)
		{
			return smethod_9(long_2, byte_22, int_23, int_24);
		}

		private static int smethod_11(long long_2, byte[] byte_22, int int_23, int int_24)
		{
			smethod_9(long_2, byte_22, int_23, int_24 - 1);
			return int_23 + int_24;
		}

		private static int smethod_12(byte[] byte_22)
		{
			int num = 0;
			for (int i = 0; i < byte_22.Length; i++)
			{
				num += byte_22[i];
			}
			return num;
		}

		private static int smethod_13(byte[] byte_22)
		{
			int num = 0;
			for (int i = 0; i < 148; i++)
			{
				num += byte_22[i];
			}
			for (int i = 0; i < 8; i++)
			{
				num += 32;
			}
			for (int i = 156; i < byte_22.Length; i++)
			{
				num += byte_22[i];
			}
			return num;
		}

		private static int smethod_14(DateTime dateTime_2)
		{
			return (int)((dateTime_2.Ticks - dateTime_0.Ticks) / 10000000L);
		}

		private static DateTime smethod_15(long long_2)
		{
			try
			{
				return new DateTime(dateTime_0.Ticks + long_2 * 10000000L);
			}
			catch (ArgumentOutOfRangeException)
			{
				return dateTime_0;
			}
		}
	}
}
