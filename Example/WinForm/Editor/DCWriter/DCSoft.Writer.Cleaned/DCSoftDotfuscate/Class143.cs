using System;
using System.IO;
using System.Security.Cryptography;

namespace DCSoftDotfuscate
{
	internal class Class143
	{
		private Enum14 enum14_0 = Enum14.flag_0;

		private int int_0 = 0;

		private int int_1 = 0;

		private string string_0 = null;

		private string string_1 = null;

		private string string_2 = null;

		private string string_3 = null;

		private long long_0 = 0L;

		private string string_4 = null;

		private string string_5 = null;

		private string string_6 = null;

		private DateTime dateTime_0 = DateTime.MaxValue;

		private DateTime dateTime_1 = DateTime.MaxValue;

		private DateTime dateTime_2 = new DateTime(3000, 1, 1);

		private string string_7 = null;

		private bool bool_0 = false;

		private string string_8 = null;

		internal Enum14 method_0()
		{
			return enum14_0;
		}

		internal void method_1(Enum14 enum14_1)
		{
			enum14_0 = enum14_1;
		}

		public int method_2()
		{
			return int_0;
		}

		public void method_3(int int_2)
		{
			int_0 = int_2;
		}

		public int method_4()
		{
			return int_1;
		}

		public void method_5(int int_2)
		{
			int_1 = int_2;
		}

		public string method_6()
		{
			return string_0;
		}

		public void method_7(string string_9)
		{
			string_0 = string_9;
		}

		public string method_8()
		{
			return string_1;
		}

		public void method_9(string string_9)
		{
			string_1 = string_9;
		}

		public string method_10()
		{
			return string_2;
		}

		public void method_11(string string_9)
		{
			string_2 = string_9;
		}

		public string method_12()
		{
			return string_3;
		}

		public void method_13(string string_9)
		{
			string_3 = string_9;
		}

		public long method_14()
		{
			return long_0;
		}

		public void method_15(long long_1)
		{
			long_0 = long_1;
		}

		public string method_16()
		{
			return string_4;
		}

		public void method_17(string string_9)
		{
			string_4 = string_9;
		}

		public string method_18()
		{
			return string_5;
		}

		public void method_19(string string_9)
		{
			string_5 = string_9;
		}

		public string method_20()
		{
			return string_6;
		}

		public void method_21(string string_9)
		{
			string_6 = string_9;
		}

		public DateTime method_22()
		{
			return dateTime_0;
		}

		public void method_23(DateTime dateTime_3)
		{
			dateTime_0 = dateTime_3;
		}

		public DateTime method_24()
		{
			return dateTime_1;
		}

		public void method_25(DateTime dateTime_3)
		{
			dateTime_1 = dateTime_3;
		}

		public DateTime method_26()
		{
			return dateTime_2;
		}

		public void method_27(DateTime dateTime_3)
		{
			dateTime_2 = dateTime_3;
		}

		public string method_28()
		{
			return string_7;
		}

		public void method_29(string string_9)
		{
			string_7 = string_9;
		}

		public bool method_30()
		{
			return bool_0;
		}

		public void method_31(bool bool_1)
		{
			bool_0 = bool_1;
		}

		public string method_32()
		{
			return string_8;
		}

		public void method_33(string string_9)
		{
			string_8 = string_9;
		}

		public string method_34()
		{
			MemoryStream memoryStream = new MemoryStream();
			Class142 @class = new Class142(memoryStream);
			@class.method_3(2);
			@class.method_3(0);
			@class.method_6((int)enum14_0);
			if ((enum14_0 & Enum14.flag_4) == Enum14.flag_4)
			{
				@class.method_6((int)long_0);
			}
			else if ((enum14_0 & Enum14.flag_5) == Enum14.flag_5)
			{
				@class.method_7(long_0);
			}
			if ((enum14_0 & Enum14.flag_1) == Enum14.flag_1)
			{
				@class.method_10(string_4);
			}
			if ((enum14_0 & Enum14.flag_2) == Enum14.flag_2)
			{
				@class.method_10(string_5);
			}
			if ((enum14_0 & Enum14.flag_6) == Enum14.flag_6)
			{
				@class.method_6(dateTime_0.Subtract(new DateTime(1980, 1, 1)).Days);
			}
			if ((enum14_0 & Enum14.flag_8) == Enum14.flag_8)
			{
				@class.method_10(string_6);
			}
			if ((enum14_0 & Enum14.flag_9) == Enum14.flag_9)
			{
				Random random = new Random();
				short short_ = (short)random.Next(65535);
				@class.method_5(short_);
			}
			if ((enum14_0 & Enum14.flag_10) == Enum14.flag_10)
			{
				@class.method_10(string_7);
			}
			if ((enum14_0 & Enum14.flag_11) == Enum14.flag_11)
			{
				@class.method_10(string_8);
			}
			if ((enum14_0 & Enum14.flag_12) == Enum14.flag_12)
			{
				@class.method_6(dateTime_2.Subtract(new DateTime(1980, 1, 1)).Days);
			}
			if ((enum14_0 & Enum14.flag_13) == Enum14.flag_13)
			{
				@class.method_10(method_12());
			}
			if ((enum14_0 & Enum14.flag_15) == Enum14.flag_15)
			{
				@class.method_10(method_8());
			}
			if ((enum14_0 & Enum14.flag_17) == Enum14.flag_17)
			{
				@class.method_10(method_10());
			}
			if ((enum14_0 & Enum14.flag_20) == Enum14.flag_20)
			{
				@class.method_10(method_6());
			}
			if ((enum14_0 & Enum14.flag_25) == Enum14.flag_25)
			{
				@class.method_6(method_2());
			}
			if ((enum14_0 & Enum14.flag_27) == Enum14.flag_27)
			{
				@class.method_6((int)method_24().Subtract(new DateTime(1980, 1, 1)).TotalDays);
			}
			method_31((enum14_0 & Enum14.flag_22) == Enum14.flag_22);
			@class.method_5((short)int_1);
			byte[] buffer = memoryStream.ToArray();
			MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
			byte[] buffer2 = mD5CryptoServiceProvider.ComputeHash(buffer);
			memoryStream.Write(buffer2, 0, 4);
			memoryStream.Close();
			buffer = memoryStream.ToArray();
			int num = 0;
			for (int i = 2; i < buffer.Length; i++)
			{
				num += buffer[i];
			}
			buffer[1] = (byte)(num ^ 0xDA);
			return GClass145.smethod_3(buffer);
		}
	}
}
