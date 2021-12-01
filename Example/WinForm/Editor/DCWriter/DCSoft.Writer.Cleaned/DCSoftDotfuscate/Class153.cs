using System;

namespace DCSoftDotfuscate
{
	internal class Class153
	{
		public static byte[] smethod_0(byte[] byte_0, byte[] byte_1)
		{
			byte[] array = new byte[byte_0.Length + byte_1.Length];
			Array.Copy(byte_0, array, byte_0.Length);
			Array.Copy(byte_1, 0, array, byte_0.Length, byte_1.Length);
			return array;
		}

		public static bool smethod_1(byte[] byte_0, byte[] byte_1)
		{
			if (byte_0 == byte_1)
			{
				return true;
			}
			if (byte_0 == null || byte_1 == null)
			{
				return false;
			}
			if (byte_0.Length != byte_1.Length)
			{
				return false;
			}
			int num = 0;
			while (true)
			{
				if (num < byte_0.Length)
				{
					if (byte_0[num] != byte_1[num])
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

		public static bool smethod_2(byte[] byte_0, byte[] byte_1, int int_0)
		{
			int num = 13;
			if (byte_0 == null)
			{
				throw new ArgumentNullException("small");
			}
			if (byte_1 == null)
			{
				throw new ArgumentNullException("big");
			}
			if (int_0 < 0 || int_0 >= byte_1.Length)
			{
				throw new ArgumentOutOfRangeException(int_0 + " 0 ->" + byte_1.Length);
			}
			if (byte_0.Length + int_0 >= byte_1.Length)
			{
				return false;
			}
			int num2 = 0;
			while (true)
			{
				if (num2 < byte_0.Length)
				{
					int num3 = num2 + int_0;
					if (num3 < byte_1.Length)
					{
						if (byte_0[num2] != byte_1[num3])
						{
							break;
						}
						num2++;
						continue;
					}
					return false;
				}
				return true;
			}
			return false;
		}
	}
}
