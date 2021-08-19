using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass339
	{
		private static byte[] byte_0 = new byte[8]
		{
			137,
			80,
			78,
			71,
			13,
			10,
			26,
			10
		};

		public static bool smethod_0(string string_0, byte[] byte_1)
		{
			int num = 19;
			if (string.IsNullOrEmpty(string_0))
			{
				throw new ArgumentNullException("fileName");
			}
			if (!File.Exists(string_0))
			{
				throw new FileNotFoundException(string_0);
			}
			if (byte_1 == null || byte_1.Length == 0)
			{
				throw new ArgumentNullException("bs");
			}
			byte[] array = new byte[byte_1.Length];
			bool result = false;
			using (FileStream fileStream = new FileStream(string_0, FileMode.Open, FileAccess.Read))
			{
				int num2 = fileStream.Read(array, 0, array.Length);
				if (num2 != array.Length)
				{
					return result;
				}
				result = true;
				for (int i = 0; i < byte_1.Length; i++)
				{
					if (array[i] != byte_1[i])
					{
						return false;
					}
				}
				return result;
			}
		}

		public static bool smethod_1(byte[] byte_1)
		{
			if (byte_1 != null && byte_1.Length > 2 && byte_1[0] == 77 && byte_1[1] == 90)
			{
				return true;
			}
			return false;
		}

		public static bool smethod_2(byte[] byte_1)
		{
			if (byte_1 != null && byte_1.Length >= 4 && byte_1[0] == 77 && byte_1[1] == 83 && byte_1[2] == 67 && byte_1[3] == 70)
			{
				return true;
			}
			return false;
		}

		public static bool smethod_3(byte[] byte_1)
		{
			if (byte_1 != null && byte_1.Length >= 4 && byte_1[0] == 80 && byte_1[1] == 75 && byte_1[2] == 3 && byte_1[3] == 4)
			{
				return true;
			}
			return false;
		}

		public static bool smethod_4(byte[] byte_1)
		{
			if (byte_1 != null && byte_1.Length >= 3 && byte_1[0] == 82 && byte_1[1] == 97 && byte_1[2] == 114)
			{
				return true;
			}
			return false;
		}

		public static bool smethod_5(byte[] byte_1)
		{
			if (byte_1 != null && byte_1.Length >= 4 && byte_1[0] == 37 && byte_1[1] == 80 && byte_1[2] == 68 && byte_1[3] == 70)
			{
				return true;
			}
			return false;
		}

		public static bool smethod_6(byte[] byte_1)
		{
			int num = 7;
			if (byte_1 != null && byte_1.Length > 5)
			{
				string @string = Encoding.ASCII.GetString(byte_1, 0, 5);
				if (@string == "{\rtf")
				{
					return true;
				}
			}
			return false;
		}

		public static bool smethod_7(byte[] byte_1)
		{
			if (byte_1 != null && byte_1.Length >= 2 && byte_1[0] == 10 && (byte_1[1] == 0 || byte_1[1] == 2 || byte_1[1] == 3 || byte_1[1] == 4 || byte_1[1] == 5))
			{
				return true;
			}
			return false;
		}

		public static bool smethod_8(byte[] byte_1)
		{
			if (byte_1 != null && byte_1.Length >= 2 && byte_1[0] == 56 && byte_1[1] == 66)
			{
				return true;
			}
			return false;
		}

		public static bool smethod_9(byte[] byte_1)
		{
			if (byte_1 != null && byte_1.Length >= 2)
			{
				if (byte_1[0] == 73 && byte_1[1] == 73)
				{
					return true;
				}
				if (byte_1[0] == 77 && byte_1[1] == 77)
				{
					return true;
				}
			}
			return false;
		}

		public static bool smethod_10(byte[] byte_1)
		{
			if (byte_1 != null && byte_1.Length >= 2 && byte_1[0] == 215 && byte_1[1] == 205)
			{
				return true;
			}
			return false;
		}

		public static bool smethod_11(byte[] byte_1)
		{
			if (byte_1 != null && byte_1.Length >= 4 && byte_1[0] == 0 && byte_1[1] == 0)
			{
				if (byte_1[2] == 1 && byte_1[3] == 0)
				{
					return true;
				}
				if (byte_1[2] == 2 && byte_1[3] == 0)
				{
					return true;
				}
			}
			return false;
		}

		public static bool smethod_12(byte[] byte_1)
		{
			if (byte_1 != null && byte_1.Length >= byte_0.Length)
			{
				int num = 0;
				while (true)
				{
					if (num < byte_0.Length)
					{
						if (byte_1[num] != byte_0[num])
						{
							break;
						}
						num++;
						continue;
					}
					return true;
				}
				return false;
			}
			return false;
		}

		public static bool smethod_13(byte[] byte_1)
		{
			if (byte_1 != null && byte_1.Length >= 6 && byte_1[0] == 71 && byte_1[1] == 73 && byte_1[2] == 70)
			{
				if (byte_1[3] == 56 && byte_1[4] == 55 && byte_1[5] == 97)
				{
					return true;
				}
				if (byte_1[3] == 56 && byte_1[4] == 57 && byte_1[5] == 97)
				{
					return true;
				}
			}
			return false;
		}

		public static bool smethod_14(byte[] byte_1)
		{
			if (byte_1 != null && byte_1.Length >= 2 && byte_1[0] == 66 && byte_1[1] == 77)
			{
				return true;
			}
			return false;
		}

		public static bool smethod_15(byte[] byte_1)
		{
			return smethod_16(byte_1, bool_0: false);
		}

		public static bool smethod_16(byte[] byte_1, bool bool_0)
		{
			if (byte_1 != null && byte_1.Length >= 12)
			{
				int num = byte_1.Length;
				if (bool_0 && (byte_1[num - 2] != byte.MaxValue || byte_1[num - 1] != 217))
				{
					return false;
				}
				if (byte_1[0] == byte.MaxValue && byte_1[1] == 216 && byte_1[2] == byte.MaxValue && byte_1[10] == 0 && byte_1[num - 2] == byte.MaxValue && byte_1[num - 1] == 217)
				{
					if (byte_1[3] == 224 && byte_1[6] == 74 && byte_1[7] == 70 && byte_1[8] == 73 && byte_1[9] == 70)
					{
						return true;
					}
					if (byte_1[3] == 225 && byte_1[6] == 69 && byte_1[7] == 120 && byte_1[8] == 105 && byte_1[9] == 102)
					{
						return true;
					}
				}
			}
			return false;
		}
	}
}
