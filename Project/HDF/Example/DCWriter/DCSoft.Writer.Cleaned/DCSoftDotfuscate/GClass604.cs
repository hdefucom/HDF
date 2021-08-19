using DCSoft.TDCode;
using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass604 : GClass594
	{
		internal const string string_0 = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ-. *$/+%";

		private static readonly char[] char_0 = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ-. *$/+%".ToCharArray();

		internal static readonly int[] int_2 = new int[44]
		{
			52,
			289,
			97,
			352,
			49,
			304,
			112,
			37,
			292,
			100,
			265,
			73,
			328,
			25,
			280,
			88,
			13,
			268,
			76,
			28,
			259,
			67,
			322,
			19,
			274,
			82,
			7,
			262,
			70,
			22,
			385,
			193,
			448,
			145,
			400,
			208,
			133,
			388,
			196,
			148,
			168,
			162,
			138,
			42
		};

		private static readonly int int_3 = int_2[39];

		private bool bool_0;

		private bool bool_1;

		public GClass604()
		{
			bool_0 = false;
			bool_1 = false;
		}

		public GClass604(bool bool_2)
		{
			bool_0 = bool_2;
			bool_1 = false;
		}

		public GClass604(bool bool_2, bool bool_3)
		{
			bool_0 = bool_2;
			bool_1 = bool_3;
		}

		public override GClass645 vmethod_0(int int_4, GClass659 gclass659_0, Hashtable hashtable_0)
		{
			int num = 0;
			int[] array = smethod_2(gclass659_0);
			int i = array[1];
			int num2;
			for (num2 = gclass659_0.method_0(); i < num2 && !gclass659_0.method_1(i); i++)
			{
			}
			StringBuilder stringBuilder = new StringBuilder(20);
			int[] array2 = new int[9];
			char c;
			int num4;
			do
			{
				GClass594.smethod_0(gclass659_0, i, array2);
				int num3 = smethod_3(array2);
				if (num3 >= 0)
				{
					c = smethod_4(num3);
					stringBuilder.Append(c);
					num4 = i;
					for (int j = 0; j < array2.Length; j++)
					{
						i += array2[j];
					}
					for (; i < num2 && !gclass659_0.method_1(i); i++)
					{
					}
					continue;
				}
				throw GException25.smethod_0();
			}
			while (c != '*');
			stringBuilder.Remove(stringBuilder.Length - 1, 1);
			int num5 = 0;
			for (int j = 0; j < array2.Length; j++)
			{
				num5 += array2[j];
			}
			int num6 = i - num4 - num5;
			if (i != num2 && num6 / 2 < num5)
			{
				throw GException25.smethod_0();
			}
			if (bool_0)
			{
				int num7 = stringBuilder.Length - 1;
				int num8 = 0;
				for (int j = 0; j < num7; j++)
				{
					num8 += "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ-. *$/+%".IndexOf(stringBuilder[j]);
				}
				if (num8 % 43 != "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ-. *$/+%".IndexOf(stringBuilder[num7]))
				{
					throw GException25.smethod_0();
				}
				stringBuilder.Remove(num7, 1);
			}
			string text = stringBuilder.ToString();
			if (bool_1)
			{
				text = smethod_5(text);
			}
			if (text.Length == 0)
			{
				throw GException25.smethod_0();
			}
			float float_ = (float)(array[1] + array[0]) / 2f;
			float float_2 = (float)(i + num4) / 2f;
			return new GClass645(text, null, new GClass639[2]
			{
				new GClass639(float_, int_4),
				new GClass639(float_2, int_4)
			}, BarcodeFormat.barcodeFormat_7);
		}

		private static int[] smethod_2(GClass659 gclass659_0)
		{
			int num = gclass659_0.method_0();
			int i;
			for (i = 0; i < num && !gclass659_0.method_1(i); i++)
			{
			}
			int num2 = 0;
			int[] array = new int[9];
			int num3 = i;
			bool flag = false;
			int num4 = array.Length;
			int num5 = i;
			while (true)
			{
				if (num5 < num)
				{
					if (gclass659_0.method_1(num5) ^ flag)
					{
						array[num2]++;
					}
					else
					{
						if (num2 == num4 - 1)
						{
							if (smethod_3(array) == int_3 && gclass659_0.method_6(Math.Max(0, num3 - (num5 - num3) / 2), num3, bool_0: false))
							{
								break;
							}
							num3 += array[0] + array[1];
							for (int j = 2; j < num4; j++)
							{
								array[j - 2] = array[j];
							}
							array[num4 - 2] = 0;
							array[num4 - 1] = 0;
							num2--;
						}
						else
						{
							num2++;
						}
						array[num2] = 1;
						flag = !flag;
					}
					num5++;
					continue;
				}
				throw GException25.smethod_0();
			}
			return new int[2]
			{
				num3,
				num5
			};
		}

		private static int smethod_3(int[] int_4)
		{
			int num = int_4.Length;
			int num2 = 0;
			int num5;
			do
			{
				int num3 = int.MaxValue;
				int i;
				for (i = 0; i < num; i++)
				{
					int num4 = int_4[i];
					if (num4 < num3 && num4 > num2)
					{
						num3 = num4;
					}
				}
				num2 = num3;
				num5 = 0;
				int num6 = 0;
				int num7 = 0;
				for (i = 0; i < num; i++)
				{
					int num4 = int_4[i];
					if (int_4[i] > num2)
					{
						num7 |= 1 << num - 1 - i;
						num5++;
						num6 += num4;
					}
				}
				if (num5 != 3)
				{
					continue;
				}
				i = 0;
				while (true)
				{
					if (i < num && num5 > 0)
					{
						int num4 = int_4[i];
						if (int_4[i] > num2)
						{
							num5--;
							if (num4 << 1 >= num6)
							{
								break;
							}
						}
						i++;
						continue;
					}
					return num7;
				}
				return -1;
			}
			while (num5 > 3);
			return -1;
		}

		private static char smethod_4(int int_4)
		{
			int num = 0;
			while (true)
			{
				if (num < int_2.Length)
				{
					if (int_2[num] == int_4)
					{
						break;
					}
					num++;
					continue;
				}
				throw GException25.smethod_0();
			}
			return char_0[num];
		}

		private static string smethod_5(string string_1)
		{
			int length = string_1.Length;
			StringBuilder stringBuilder = new StringBuilder(length);
			for (int i = 0; i < length; i++)
			{
				char c = string_1[i];
				if (c == '+' || c == '$' || c == '%' || c == '/')
				{
					char c2 = string_1[i + 1];
					char value = '\0';
					switch (c)
					{
					case '/':
						if (c2 >= 'A' && c2 <= 'O')
						{
							value = (char)(c2 - 32);
						}
						else
						{
							if (c2 != 'Z')
							{
								throw GException25.smethod_0();
							}
							value = ':';
						}
						goto default;
					case '+':
						if (c2 >= 'A' && c2 <= 'Z')
						{
							value = (char)(c2 + 32);
							goto default;
						}
						throw GException25.smethod_0();
					case '$':
						if (c2 >= 'A' && c2 <= 'Z')
						{
							value = (char)(c2 - 64);
							goto default;
						}
						throw GException25.smethod_0();
					case '%':
						if (c2 >= 'A' && c2 <= 'E')
						{
							value = (char)(c2 - 38);
						}
						else
						{
							if (c2 < 'F' || c2 > 'W')
							{
								throw GException25.smethod_0();
							}
							value = (char)(c2 - 11);
						}
						goto default;
					default:
						stringBuilder.Append(value);
						i++;
						break;
					}
				}
				else
				{
					stringBuilder.Append(c);
				}
			}
			return stringBuilder.ToString();
		}
	}
}
