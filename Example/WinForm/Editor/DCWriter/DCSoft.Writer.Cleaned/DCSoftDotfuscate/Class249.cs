using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	internal sealed class Class249
	{
		private const int int_0 = 900;

		private const int int_1 = 901;

		private const int int_2 = 902;

		private const int int_3 = 924;

		private const int int_4 = 928;

		private const int int_5 = 923;

		private const int int_6 = 922;

		private const int int_7 = 913;

		private const int int_8 = 15;

		private const int int_9 = 0;

		private const int int_10 = 1;

		private const int int_11 = 2;

		private const int int_12 = 3;

		private const int int_13 = 4;

		private const int int_14 = 25;

		private const int int_15 = 27;

		private const int int_16 = 27;

		private const int int_17 = 28;

		private const int int_18 = 28;

		private const int int_19 = 29;

		private const int int_20 = 29;

		private static readonly char[] char_0 = new char[29]
		{
			';',
			'<',
			'>',
			'@',
			'[',
			'\\',
			'}',
			'_',
			'`',
			'~',
			'!',
			'\r',
			'\t',
			',',
			':',
			'\n',
			'-',
			'.',
			'$',
			'/',
			'"',
			'|',
			'*',
			'(',
			')',
			'?',
			'{',
			'}',
			'\''
		};

		private static readonly char[] char_1 = new char[25]
		{
			'0',
			'1',
			'2',
			'3',
			'4',
			'5',
			'6',
			'7',
			'8',
			'9',
			'&',
			'\r',
			'\t',
			',',
			':',
			'#',
			'-',
			'.',
			'$',
			'/',
			'+',
			'%',
			'*',
			'=',
			'^'
		};

		private static readonly string[] string_0 = new string[16]
		{
			"000000000000000000000000000000000000000000001",
			"000000000000000000000000000000000000000000900",
			"000000000000000000000000000000000000000810000",
			"000000000000000000000000000000000000729000000",
			"000000000000000000000000000000000656100000000",
			"000000000000000000000000000000590490000000000",
			"000000000000000000000000000531441000000000000",
			"000000000000000000000000478296900000000000000",
			"000000000000000000000430467210000000000000000",
			"000000000000000000387420489000000000000000000",
			"000000000000000348678440100000000000000000000",
			"000000000000313810596090000000000000000000000",
			"000000000282429536481000000000000000000000000",
			"000000254186582832900000000000000000000000000",
			"000228767924549610000000000000000000000000000",
			"205891132094649000000000000000000000000000000"
		};

		private Class249()
		{
		}

		internal static GClass678 smethod_0(int[] int_21)
		{
			StringBuilder stringBuilder = new StringBuilder(100);
			int num = 1;
			num = 2;
			int num2 = int_21[1];
			while (num < int_21[0])
			{
				switch (num2)
				{
				default:
					num--;
					num = smethod_1(int_21, num, stringBuilder);
					break;
				case 924:
					num = smethod_3(num2, int_21, num, stringBuilder);
					break;
				case 913:
					num = smethod_3(num2, int_21, num, stringBuilder);
					break;
				case 900:
					num = smethod_1(int_21, num, stringBuilder);
					break;
				case 901:
					num = smethod_3(num2, int_21, num, stringBuilder);
					break;
				case 902:
					num = smethod_4(int_21, num, stringBuilder);
					break;
				}
				if (num < int_21.Length)
				{
					num2 = int_21[num++];
					continue;
				}
				throw GException25.smethod_0();
			}
			return new GClass678(null, stringBuilder.ToString(), null, null);
		}

		private static int smethod_1(int[] int_21, int int_22, StringBuilder stringBuilder_0)
		{
			int[] array = new int[int_21[0] << 1];
			int[] array2 = new int[int_21[0] << 1];
			int num = 0;
			bool flag = false;
			while (int_22 < int_21[0] && !flag)
			{
				int num2 = int_21[int_22++];
				if (num2 < 900)
				{
					array[num] = num2 / 30;
					array[num + 1] = num2 % 30;
					num += 2;
					continue;
				}
				switch (num2)
				{
				case 924:
					int_22--;
					flag = true;
					break;
				case 913:
					array[num] = 913;
					array2[num] = num2;
					num++;
					break;
				case 900:
					int_22--;
					flag = true;
					break;
				case 901:
					int_22--;
					flag = true;
					break;
				case 902:
					int_22--;
					flag = true;
					break;
				}
			}
			smethod_2(array, array2, num, stringBuilder_0);
			return int_22;
		}

		private static void smethod_2(int[] int_21, int[] int_22, int int_23, StringBuilder stringBuilder_0)
		{
			int num = 0;
			int num2 = 0;
			for (int i = 0; i < int_23; i++)
			{
				int num3 = int_21[i];
				char c = '\0';
				switch (num)
				{
				case 0:
					if (num3 < 26)
					{
						c = (char)(65 + num3);
						break;
					}
					switch (num3)
					{
					case 26:
						c = ' ';
						break;
					case 27:
						num = 1;
						break;
					case 28:
						num = 2;
						break;
					case 29:
						num2 = num;
						num = 4;
						break;
					case 913:
						stringBuilder_0.Append((char)int_22[i]);
						break;
					}
					break;
				case 1:
					if (num3 < 26)
					{
						c = (char)(97 + num3);
						break;
					}
					switch (num3)
					{
					case 26:
						c = ' ';
						break;
					case 28:
						num = 0;
						break;
					default:
						switch (num3)
						{
						case 28:
							num = 2;
							break;
						case 29:
							num2 = num;
							num = 4;
							break;
						case 913:
							stringBuilder_0.Append((char)int_22[i]);
							break;
						}
						break;
					}
					break;
				case 2:
					if (num3 < 25)
					{
						c = char_1[num3];
						break;
					}
					switch (num3)
					{
					case 25:
						num = 3;
						break;
					case 26:
						c = ' ';
						break;
					case 28:
						num = 0;
						break;
					case 29:
						num2 = num;
						num = 4;
						break;
					case 913:
						stringBuilder_0.Append((char)int_22[i]);
						break;
					}
					break;
				case 3:
					if (num3 < 29)
					{
						c = char_0[num3];
						break;
					}
					switch (num3)
					{
					case 29:
						num = 0;
						break;
					case 913:
						stringBuilder_0.Append((char)int_22[i]);
						break;
					}
					break;
				case 4:
					num = num2;
					if (num3 < 29)
					{
						c = char_0[num3];
					}
					else if (num3 == 29)
					{
						num = 0;
					}
					break;
				}
				if (c != 0)
				{
					stringBuilder_0.Append(c);
				}
			}
		}

		private static int smethod_3(int int_21, int[] int_22, int int_23, StringBuilder stringBuilder_0)
		{
			switch (int_21)
			{
			case 901:
			{
				int num = 0;
				long num2 = 0L;
				char[] array = new char[6];
				int[] array2 = new int[6];
				bool flag = false;
				while (int_23 < int_22[0] && !flag)
				{
					int num3 = int_22[int_23++];
					if (num3 < 900)
					{
						array2[num] = num3;
						num++;
						num2 *= 900L;
						num2 += num3;
					}
					else
					{
						if (num3 != 900 && num3 != 901 && num3 != 902 && num3 != 924 && num3 != 928 && num3 != 923 && num3 != 922)
						{
						}
						int_23--;
						flag = true;
					}
					if (num % 5 == 0 && num > 0)
					{
						for (int i = 0; i < 6; i++)
						{
							array[5 - i] = (char)(num2 % 256L);
							num2 >>= 8;
						}
						stringBuilder_0.Append(array);
						num = 0;
					}
				}
				for (int j = num / 5 * 5; j < num; j++)
				{
					stringBuilder_0.Append((char)array2[j]);
				}
				break;
			}
			case 924:
			{
				int num = 0;
				long num2 = 0L;
				bool flag = false;
				while (int_23 < int_22[0] && !flag)
				{
					int num3 = int_22[int_23++];
					if (num3 < 900)
					{
						num++;
						num2 *= 900L;
						num2 += num3;
					}
					else
					{
						if (num3 != 900 && num3 != 901 && num3 != 902 && num3 != 924 && num3 != 928 && num3 != 923 && num3 != 922)
						{
						}
						int_23--;
						flag = true;
					}
					if (num % 5 == 0 && num > 0)
					{
						char[] array = new char[6];
						for (int i = 0; i < 6; i++)
						{
							array[5 - i] = (char)(num2 % 256L);
							num2 >>= 8;
						}
						stringBuilder_0.Append(array);
					}
				}
				break;
			}
			}
			return int_23;
		}

		private static int smethod_4(int[] int_21, int int_22, StringBuilder stringBuilder_0)
		{
			int num = 0;
			bool flag = false;
			int[] array = new int[15];
			while (int_22 < int_21.Length && !flag)
			{
				int num2 = int_21[int_22++];
				if (num2 < 900)
				{
					array[num] = num2;
					num++;
				}
				else
				{
					if (num2 != 900 && num2 != 901 && num2 != 924 && num2 != 928 && num2 != 923 && num2 != 922)
					{
					}
					int_22--;
					flag = true;
				}
				if (num % 15 == 0 || num2 == 902)
				{
					string value = smethod_5(array, num);
					stringBuilder_0.Append(value);
					num = 0;
				}
			}
			return int_22;
		}

		private static string smethod_5(int[] int_21, int int_22)
		{
			StringBuilder stringBuilder = null;
			for (int i = 0; i < int_22; i++)
			{
				StringBuilder stringBuilder2 = smethod_6(string_0[int_22 - i - 1], int_21[i]);
				stringBuilder = ((stringBuilder != null) ? smethod_7(stringBuilder.ToString(), stringBuilder2.ToString()) : stringBuilder2);
			}
			string text = null;
			for (int i = 0; i < stringBuilder.Length; i++)
			{
				if (stringBuilder[i] == '1')
				{
					text = stringBuilder.ToString().Substring(i + 1);
					break;
				}
			}
			if (text == null)
			{
				text = stringBuilder.ToString();
			}
			return text;
		}

		private static StringBuilder smethod_6(string string_1, int int_21)
		{
			int num = 12;
			StringBuilder stringBuilder = new StringBuilder(string_1.Length);
			for (int i = 0; i < string_1.Length; i++)
			{
				stringBuilder.Append('0');
			}
			int num2 = int_21 / 100;
			int num3 = int_21 / 10 % 10;
			int num4 = int_21 % 10;
			for (int j = 0; j < num4; j++)
			{
				stringBuilder = smethod_7(stringBuilder.ToString(), string_1);
			}
			for (int j = 0; j < num3; j++)
			{
				stringBuilder = smethod_7(stringBuilder.ToString(), (string_1 + '0').Substring(1));
			}
			for (int j = 0; j < num2; j++)
			{
				stringBuilder = smethod_7(stringBuilder.ToString(), (string_1 + "00").Substring(2));
			}
			return stringBuilder;
		}

		private static StringBuilder smethod_7(string string_1, string string_2)
		{
			StringBuilder stringBuilder = new StringBuilder(5);
			StringBuilder stringBuilder2 = new StringBuilder(5);
			StringBuilder stringBuilder3 = new StringBuilder(string_1.Length);
			for (int i = 0; i < string_1.Length; i++)
			{
				stringBuilder3.Append('0');
			}
			int num = 0;
			for (int i = string_1.Length - 3; i > -1; i -= 3)
			{
				stringBuilder.Length = 0;
				stringBuilder.Append(string_1[i]);
				stringBuilder.Append(string_1[i + 1]);
				stringBuilder.Append(string_1[i + 2]);
				stringBuilder2.Length = 0;
				stringBuilder2.Append(string_2[i]);
				stringBuilder2.Append(string_2[i + 1]);
				stringBuilder2.Append(string_2[i + 2]);
				int num2 = int.Parse(stringBuilder.ToString());
				int num3 = int.Parse(stringBuilder2.ToString());
				int num4 = (num2 + num3 + num) % 1000;
				num = (num2 + num3 + num) / 1000;
				stringBuilder3[i + 2] = (char)(num4 % 10 + 48);
				stringBuilder3[i + 1] = (char)(num4 / 10 % 10 + 48);
				stringBuilder3[i] = (char)(num4 / 100 + 48);
			}
			return stringBuilder3;
		}
	}
}
