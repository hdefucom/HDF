using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass138
	{
		private const int int_0 = 2;

		private static GClass138 gclass138_0 = null;

		private int int_1 = 0;

		private int int_2 = 0;

		private int int_3 = 0;

		private int int_4 = 0;

		private DateTime dateTime_0 = DateTime.MaxValue;

		private bool bool_0 = false;

		private int int_5 = 0;

		[NonSerialized]
		private Enum15 enum15_0 = Enum15.const_0;

		internal Enum14 enum14_0 = Enum14.flag_0;

		internal Enum13 enum13_0 = Enum13.flag_0;

		private string string_0 = null;

		private byte byte_0 = 0;

		private string string_1 = null;

		private string string_2 = null;

		private int int_6 = 0;

		private long long_0 = 0L;

		private string string_3 = null;

		private string string_4 = null;

		private string string_5 = null;

		private DateTime dateTime_1 = new DateTime(3000, 1, 1);

		private DateTime dateTime_2 = new DateTime(3000, 1, 1);

		private int int_7 = 3;

		private string string_6 = null;

		private int int_8 = 0;

		private string string_7 = null;

		private string string_8 = null;

		private string string_9 = null;

		public bool method_0(object object_0, int int_9, int int_10, DateTime dateTime_3, string string_10)
		{
			if (object_0 == null)
			{
				return false;
			}
			try
			{
				object[] array = (object[])object_0;
				if (array.Length == 26 || array.Length == 27)
				{
					int_6 = (int)array[0];
					byte_0 = (byte)array[1];
					string_6 = (string)array[2];
					int_2 = (int)array[3];
					string_7 = (string)array[4];
					dateTime_2 = (DateTime)array[5];
					string_0 = (string)array[6];
					string_2 = (string)array[7];
					string_1 = (string)array[8];
					dateTime_1 = (DateTime)array[9];
					enum14_0 = (Enum14)array[10];
					enum13_0 = (Enum13)array[11];
					int_5 = (int)array[12];
					dateTime_0 = (DateTime)array[13];
					string_9 = (string)array[14];
					string_8 = (string)array[15];
					int_8 = (int)array[16];
					int_1 = (int)array[17];
					int_3 = (int)array[18];
					enum15_0 = (Enum15)array[19];
					string_5 = (string)array[20];
					long_0 = (long)array[21];
					string_3 = (string)array[22];
					string_4 = (string)array[23];
					int_4 = (int)array[24];
					bool_0 = (bool)array[25];
					if (array.Length == 27)
					{
						int_7 = (int)array[26];
					}
					else
					{
						int_7 = 2;
					}
					return true;
				}
			}
			catch (Exception)
			{
			}
			return true;
		}

		public static GClass138 smethod_0()
		{
			if (gclass138_0 == null)
			{
				gclass138_0 = new GClass138();
				gclass138_0.enum14_0 = Enum14.flag_0;
				gclass138_0.enum13_0 = Enum13.flag_0;
				gclass138_0.string_4 = Class151.smethod_16();
			}
			return gclass138_0;
		}

		public int method_1()
		{
			return int_1;
		}

		public void method_2(int int_9)
		{
			int_1 = int_9;
		}

		public bool method_3()
		{
			return this == smethod_0();
		}

		public int method_4()
		{
			return int_4;
		}

		public DateTime method_5()
		{
			return dateTime_0;
		}

		public bool method_6()
		{
			return bool_0;
		}

		public int method_7()
		{
			return int_5;
		}

		public GClass137 method_8()
		{
			return new GClass137(int_5);
		}

		public bool method_9()
		{
			if (int_4 == 3)
			{
				return int_2 != int_3 + 2;
			}
			return int_2 != int_3;
		}

		internal Enum15 method_10()
		{
			return enum15_0;
		}

		internal void method_11(Enum15 enum15_1)
		{
			enum15_0 = enum15_1;
		}

		public bool method_12()
		{
			return method_10() == Enum15.const_1;
		}

		internal Enum14 method_13()
		{
			return enum14_0;
		}

		internal Enum13 method_14()
		{
			return enum13_0;
		}

		internal bool method_15(Enum14 enum14_1, Enum13 enum13_1)
		{
			if (enum13_0 != Enum13.flag_0 && (enum13_0 & enum13_1) == enum13_1)
			{
				return true;
			}
			if (enum14_0 != 0 && (enum14_0 & enum14_1) == enum14_1)
			{
				return true;
			}
			return false;
		}

		public string method_16()
		{
			return string_0;
		}

		public byte method_17()
		{
			return byte_0;
		}

		public string method_18()
		{
			return string_1;
		}

		public string method_19()
		{
			return string_2;
		}

		public void method_20(string string_10)
		{
			string_2 = string_10;
		}

		public bool method_21()
		{
			if (enum13_0 != Enum13.flag_0)
			{
				return (enum13_0 & Enum13.flag_13) == Enum13.flag_13;
			}
			return (enum14_0 & Enum14.flag_14) == Enum14.flag_14;
		}

		public bool method_22()
		{
			if (enum13_0 != Enum13.flag_0)
			{
				return (enum13_0 & Enum13.flag_17) == Enum13.flag_17;
			}
			return (enum14_0 & Enum14.flag_18) == Enum14.flag_18;
		}

		public bool method_23()
		{
			if (enum13_0 != Enum13.flag_0)
			{
				return (enum13_0 & Enum13.flag_20) == Enum13.flag_20;
			}
			return (enum14_0 & Enum14.flag_22) == Enum14.flag_22;
		}

		public bool method_24()
		{
			if (enum13_0 != Enum13.flag_0)
			{
				return (enum13_0 & Enum13.flag_21) == Enum13.flag_21;
			}
			return (enum14_0 & Enum14.flag_23) == Enum14.flag_23;
		}

		public bool method_25()
		{
			if (enum13_0 != Enum13.flag_0)
			{
				return (enum13_0 & Enum13.flag_22) == Enum13.flag_22;
			}
			return (enum14_0 & Enum14.flag_24) == Enum14.flag_24;
		}

		public bool method_26()
		{
			if (enum13_0 != Enum13.flag_0)
			{
				return (enum13_0 & Enum13.flag_18) == Enum13.flag_18;
			}
			return (enum14_0 & Enum14.flag_19) == Enum14.flag_19;
		}

		public bool method_27()
		{
			if (enum13_0 != Enum13.flag_0)
			{
				return (enum13_0 & Enum13.flag_27) == Enum13.flag_27;
			}
			return false;
		}

		public int method_28()
		{
			return int_6;
		}

		public void method_29(int int_9)
		{
			int_6 &= ~int_9;
		}

		public bool method_30(int int_9)
		{
			return (int_6 & int_9) == int_9;
		}

		public long method_31()
		{
			return long_0;
		}

		public string method_32()
		{
			return string_3;
		}

		public string method_33()
		{
			return string_4;
		}

		public bool method_34()
		{
			if (enum13_0 != Enum13.flag_0)
			{
				return (enum13_0 & Enum13.flag_10) == Enum13.flag_10;
			}
			return (enum14_0 & Enum14.flag_3) == Enum14.flag_3;
		}

		public bool method_35()
		{
			if (enum13_0 != Enum13.flag_0)
			{
				return (enum13_0 & Enum13.flag_6) == Enum13.flag_6;
			}
			return (enum14_0 & Enum14.flag_7) == Enum14.flag_7;
		}

		public string method_36()
		{
			return string_5;
		}

		public DateTime method_37()
		{
			return dateTime_1;
		}

		public bool method_38()
		{
			if ((dateTime_1 - DateTime.Now).TotalDays < 31.0)
			{
				return true;
			}
			return false;
		}

		public DateTime method_39()
		{
			return dateTime_2;
		}

		public bool method_40()
		{
			if (enum13_0 != Enum13.flag_0)
			{
				return (enum13_0 & Enum13.flag_29) == Enum13.flag_29;
			}
			return (enum14_0 & Enum14.flag_21) == Enum14.flag_21;
		}

		public int method_41()
		{
			return int_7;
		}

		public void method_42(int int_9)
		{
			int_7 = int_9;
		}

		public int method_43(int int_9)
		{
			if ((enum13_0 & Enum13.flag_30) == Enum13.flag_30)
			{
				return int_7;
			}
			return int_9;
		}

		public bool method_44()
		{
			if (enum13_0 != Enum13.flag_0)
			{
				return (enum13_0 & Enum13.flag_25) == Enum13.flag_25;
			}
			return (enum14_0 & Enum14.flag_26) == Enum14.flag_26;
		}

		public bool method_45()
		{
			if (enum13_0 != Enum13.flag_0)
			{
				return (enum13_0 & Enum13.flag_12) == Enum13.flag_12;
			}
			return (enum14_0 & Enum14.flag_10) == Enum14.flag_10;
		}

		public bool method_46()
		{
			if (enum13_0 != Enum13.flag_0)
			{
				return (enum13_0 & Enum13.flag_14) == Enum13.flag_14;
			}
			return (enum14_0 & Enum14.flag_16) == Enum14.flag_16;
		}

		public bool method_47()
		{
			if (enum13_0 != Enum13.flag_0)
			{
				return (enum13_0 & Enum13.flag_1) == Enum13.flag_1;
			}
			return (enum14_0 & Enum14.flag_28) == Enum14.flag_28;
		}

		public string method_48()
		{
			return string_6;
		}

		public int method_49()
		{
			return int_8;
		}

		public string method_50()
		{
			if (enum13_0 != Enum13.flag_0 && (enum13_0 & Enum13.flag_9) == Enum13.flag_9)
			{
				return string_7;
			}
			if ((enum14_0 & Enum14.flag_11) == Enum14.flag_11)
			{
				return string_7;
			}
			string b = "本软件授权给范绿峰，其他单位或个人不得使用。";
			if (string_0 == b)
			{
				return "";
			}
			return "南京都昌信息科技有限公司";
		}

		public string method_51()
		{
			return string_8;
		}

		public string method_52()
		{
			return string_9;
		}

		public string method_53()
		{
			if (method_34())
			{
				return string.Format(Class151.smethod_15(), method_33());
			}
			return Class151.smethod_17();
		}

		public GClass138 method_54()
		{
			return (GClass138)MemberwiseClone();
		}
	}
}
