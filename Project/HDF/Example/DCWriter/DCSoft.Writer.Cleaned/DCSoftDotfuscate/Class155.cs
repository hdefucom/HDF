using System;
using System.IO;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	internal class Class155
	{
		private static Class152 class152_0 = new Class152();

		private static string string_0 = null;

		private static volatile int int_0 = 0;

		private static string string_1 = "FFFFFFFF";

		private static string string_2 = "FFFFFFFF";

		public static Class152 smethod_0()
		{
			return class152_0;
		}

		public static void smethod_1(Class152 class152_1)
		{
			class152_0 = class152_1;
		}

		public static string smethod_2()
		{
			return string_0;
		}

		public static void smethod_3(string string_3)
		{
			string_0 = string_3;
		}

		public string method_0()
		{
			return smethod_15(int_0);
		}

		public static int smethod_4()
		{
			return int_0;
		}

		public static string smethod_5()
		{
			return string_1;
		}

		public static void smethod_6(string string_3)
		{
			string_1 = string_3;
		}

		public static string smethod_7()
		{
			return string_2;
		}

		public static void smethod_8(string string_3)
		{
			string_2 = string_3;
		}

		public static bool smethod_9(string string_3)
		{
			int num = 8;
			int_0 = class152_0.method_33(0, ref string_0);
			if (int_0 == 0)
			{
				int_0 = class152_0.method_50(string_0);
				if (int_0 != 0)
				{
					MessageBox.Show("初始化失败");
					return false;
				}
				int_0 = class152_0.method_95("FFFFFFFF", "FFFFFFFF", string_1, string_2, string_0);
				if (int_0 != 0)
				{
					MessageBox.Show("设置固化密码错误");
					return false;
				}
				int_0 = class152_0.method_41("00000000", "00000000", "FFFFFFFF", "FFFFFFFF", string_0);
				if (int_0 != 0)
				{
					MessageBox.Show("设置写密码错误");
					return false;
				}
				int_0 = class152_0.method_42("00000000", "00000000", string_1, string_2, string_0);
				if (int_0 != 0)
				{
					MessageBox.Show("设置写密码错误");
					return false;
				}
				short short_ = 0;
				if (class152_0.method_55(ref short_, string_0) != 0)
				{
					MessageBox.Show("返回加密锁扩展版本号错误");
					return false;
				}
				if (short_ < 32)
				{
					MessageBox.Show("锁的扩展版本少于32,不支持设置锁的ID");
					return false;
				}
				if (string.IsNullOrEmpty(string_3))
				{
					string_3 = Guid.NewGuid().ToString().Substring(0, 16);
				}
				int_0 = class152_0.method_90(string_3, string_0);
				if (int_0 == 0)
				{
					if (smethod_10())
					{
						MessageBox.Show("设置ID成功。");
						return true;
					}
					return false;
				}
				MessageBox.Show("设置ID错误。");
			}
			return false;
		}

		public static bool smethod_10()
		{
			int_0 = class152_0.method_32(0, 2307, 1225227134, ref string_0);
			if (int_0 == 0)
			{
				return true;
			}
			string_0 = null;
			return false;
		}

		public static string smethod_11()
		{
			int num = 5;
			int int_ = 0;
			int int_2 = 0;
			if (smethod_10())
			{
				int_0 = class152_0.method_27(ref int_, ref int_2, string_0);
				if (int_0 == 0)
				{
					return int_.ToString("X") + "-" + int_2.ToString("X");
				}
			}
			return null;
		}

		public static byte[] smethod_12()
		{
			int int_ = 0;
			int int_2 = 0;
			if (smethod_10())
			{
				int_0 = class152_0.method_27(ref int_, ref int_2, string_0);
				if (int_0 == 0)
				{
					byte[] bytes = BitConverter.GetBytes(int_);
					byte[] bytes2 = BitConverter.GetBytes(int_2);
					return Class153.smethod_0(bytes, bytes2);
				}
			}
			return null;
		}

		public static bool smethod_13(byte[] byte_0)
		{
			int num = 8;
			if (byte_0 == null)
			{
				throw new ArgumentNullException("bs");
			}
			if (byte_0.Length > 494)
			{
				throw new ArgumentOutOfRangeException("512 bytes");
			}
			if (smethod_10())
			{
				MemoryStream memoryStream = new MemoryStream();
				byte[] bytes = BitConverter.GetBytes((short)(10 + byte_0.Length));
				memoryStream.Write(bytes, 0, bytes.Length);
				byte[] array = smethod_12();
				memoryStream.Write(array, 0, array.Length);
				memoryStream.Write(byte_0, 0, byte_0.Length);
				byte[] array2 = memoryStream.ToArray();
				for (int i = 2; i < array2.Length; i++)
				{
					array2[i] = (byte)(array2[i] ^ array[0]);
				}
				int_0 = class152_0.method_30(array2, 0, array2.Length, smethod_5(), smethod_7(), string_0);
				if (int_0 == 0)
				{
					return true;
				}
			}
			return false;
		}

		public static byte[] smethod_14(string string_3, string string_4)
		{
			int num = 12;
			if (string.IsNullOrEmpty(string_3))
			{
				string_3 = "ffffffff";
			}
			if (string.IsNullOrEmpty(string_4))
			{
				string_4 = "ffffffff";
			}
			if (smethod_10())
			{
				byte[] array = new byte[2];
				int_0 = class152_0.method_31(array, 0, 2, string_3, string_4, string_0);
				if (int_0 == 0)
				{
					int num2 = BitConverter.ToInt16(array, 0);
					if (num2 <= 0 || num2 > 494)
					{
						return null;
					}
					array = new byte[num2];
					int_0 = class152_0.method_31(array, 0, (short)num2, string_3, string_4, string_0);
					if (int_0 == 0)
					{
						byte[] array2 = smethod_12();
						for (int i = 2; i < array.Length; i++)
						{
							array[i] = (byte)(array[i] ^ array2[0]);
						}
						if (!Class153.smethod_2(array2, array, 2))
						{
							return null;
						}
						byte[] array3 = new byte[num2 - 10];
						Array.Copy(array, 10, array3, 0, array3.Length);
						return array3;
					}
				}
			}
			return null;
		}

		public static string smethod_15(int int_1)
		{
			switch (int_1)
			{
			case -47:
				return Class149.smethod_5();
			case -46:
				return Class149.smethod_4();
			case -83:
				return Class149.smethod_8();
			case -82:
				return Class149.smethod_7();
			case -81:
				return Class149.smethod_6();
			case -94:
				return Class149.smethod_12();
			case -93:
				return Class149.smethod_11();
			case -92:
				return Class149.smethod_10();
			default:
				return null;
			case -88:
				return Class149.smethod_9();
			}
		}
	}
}
