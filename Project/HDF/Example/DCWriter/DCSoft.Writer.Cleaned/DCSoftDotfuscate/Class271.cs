using System;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	internal sealed class Class271
	{
		private const int int_0 = 0;

		private const int int_1 = 1;

		private const int int_2 = 2;

		private const int int_3 = 3;

		private const int int_4 = 4;

		private const int int_5 = 5;

		private const int int_6 = 6;

		private static readonly char[] char_0 = new char[40]
		{
			'*',
			'*',
			'*',
			' ',
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
			'A',
			'B',
			'C',
			'D',
			'E',
			'F',
			'G',
			'H',
			'I',
			'J',
			'K',
			'L',
			'M',
			'N',
			'O',
			'P',
			'Q',
			'R',
			'S',
			'T',
			'U',
			'V',
			'W',
			'X',
			'Y',
			'Z'
		};

		private static readonly char[] char_1 = new char[27]
		{
			'!',
			'"',
			'#',
			'$',
			'%',
			'&',
			'\'',
			'(',
			')',
			'*',
			'+',
			',',
			'-',
			'.',
			'/',
			':',
			';',
			'<',
			'=',
			'>',
			'?',
			'@',
			'[',
			'\\',
			']',
			'^',
			'_'
		};

		private static readonly char[] char_2 = new char[40]
		{
			'*',
			'*',
			'*',
			' ',
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
			'a',
			'b',
			'c',
			'd',
			'e',
			'f',
			'g',
			'h',
			'i',
			'j',
			'k',
			'l',
			'm',
			'n',
			'o',
			'p',
			'q',
			'r',
			's',
			't',
			'u',
			'v',
			'w',
			'x',
			'y',
			'z'
		};

		private static char[] char_3 = new char[32]
		{
			'\'',
			'A',
			'B',
			'C',
			'D',
			'E',
			'F',
			'G',
			'H',
			'I',
			'J',
			'K',
			'L',
			'M',
			'N',
			'O',
			'P',
			'Q',
			'R',
			'S',
			'T',
			'U',
			'V',
			'W',
			'X',
			'Y',
			'Z',
			'{',
			'|',
			'}',
			'~',
			'\u007f'
		};

		private Class271()
		{
		}

		internal static GClass678 smethod_0(sbyte[] sbyte_0)
		{
			GClass657 gClass = new GClass657(sbyte_0);
			StringBuilder stringBuilder = new StringBuilder(100);
			StringBuilder stringBuilder2 = new StringBuilder(0);
			ArrayList arrayList = ArrayList.Synchronized(new ArrayList(1));
			int num = 1;
			bool num2;
			do
			{
				switch (num)
				{
				case 2:
					smethod_2(gClass, stringBuilder);
					goto IL_0076;
				case 3:
					smethod_3(gClass, stringBuilder);
					goto IL_0076;
				case 4:
					smethod_4(gClass, stringBuilder);
					goto IL_0076;
				case 5:
					smethod_6(gClass, stringBuilder);
					goto IL_0076;
				case 6:
					smethod_7(gClass, stringBuilder, arrayList);
					goto IL_0076;
				case 1:
					num = smethod_1(gClass, stringBuilder, stringBuilder2);
					goto IL_0079;
				default:
					{
						throw GException25.smethod_0();
					}
					IL_0076:
					num = 1;
					goto IL_0079;
					IL_0079:
					num2 = (num != 0 && gClass.method_1() > 0);
					break;
				}
			}
			while (num2);
			if (stringBuilder2.Length > 0)
			{
				stringBuilder.Append(stringBuilder2.ToString());
			}
			return new GClass678(sbyte_0, stringBuilder.ToString(), (arrayList.Count == 0) ? null : arrayList, null);
		}

		private static int smethod_1(GClass657 gclass657_0, StringBuilder stringBuilder_0, StringBuilder stringBuilder_1)
		{
			int num = 4;
			bool flag = false;
			do
			{
				int num2 = gclass657_0.method_0(8);
				if (num2 != 0)
				{
					if (num2 > 128)
					{
						if (num2 != 129)
						{
							if (num2 <= 229)
							{
								int num3 = num2 - 130;
								if (num3 < 10)
								{
									stringBuilder_0.Append('0');
								}
								stringBuilder_0.Append(num3);
								continue;
							}
							if (num2 != 230)
							{
								if (num2 != 231)
								{
									if (num2 == 232 || num2 == 233 || num2 == 234)
									{
										continue;
									}
									if (num2 == 235)
									{
										flag = true;
										continue;
									}
									if (num2 == 236)
									{
										stringBuilder_0.Append("[)>\u001e05\u001d");
										stringBuilder_1.Insert(0, "\u001e\u0004");
										continue;
									}
									if (num2 == 237)
									{
										stringBuilder_0.Append("[)>\u001e06\u001d");
										stringBuilder_1.Insert(0, "\u001e\u0004");
										continue;
									}
									if (num2 != 238)
									{
										if (num2 != 239)
										{
											if (num2 != 240)
											{
												if (num2 != 241 && num2 >= 242)
												{
													throw GException25.smethod_0();
												}
												continue;
											}
											return 5;
										}
										return 3;
									}
									return 4;
								}
								return 6;
							}
							return 2;
						}
						return 0;
					}
					num2 = (flag ? (num2 + 128) : num2);
					flag = false;
					stringBuilder_0.Append((char)(num2 - 1));
					return 1;
				}
				throw GException25.smethod_0();
			}
			while (gclass657_0.method_1() > 0);
			return 1;
		}

		private static void smethod_2(GClass657 gclass657_0, StringBuilder stringBuilder_0)
		{
			bool flag = false;
			int[] array = new int[3];
			while (gclass657_0.method_1() != 8)
			{
				int num = gclass657_0.method_0(8);
				if (num == 254)
				{
					break;
				}
				smethod_5(num, gclass657_0.method_0(8), array);
				int num2 = 0;
				for (int i = 0; i < 3; i++)
				{
					int num3 = array[i];
					switch (num2)
					{
					case 0:
						if (num3 < 3)
						{
							num2 = num3 + 1;
						}
						else if (flag)
						{
							stringBuilder_0.Append((char)(char_0[num3] + 128));
							flag = false;
						}
						else
						{
							stringBuilder_0.Append(char_0[num3]);
						}
						break;
					case 1:
						if (flag)
						{
							stringBuilder_0.Append((char)(num3 + 128));
							flag = false;
						}
						else
						{
							stringBuilder_0.Append(num3);
						}
						num2 = 0;
						break;
					case 2:
						if (num3 < 27)
						{
							if (flag)
							{
								stringBuilder_0.Append((char)(char_1[num3] + 128));
								flag = false;
							}
							else
							{
								stringBuilder_0.Append(char_1[num3]);
							}
						}
						else
						{
							if (num3 == 27)
							{
								throw GException25.smethod_0();
							}
							if (num3 != 30)
							{
								throw GException25.smethod_0();
							}
							flag = true;
						}
						num2 = 0;
						break;
					case 3:
						if (flag)
						{
							stringBuilder_0.Append((char)(num3 + 224));
							flag = false;
						}
						else
						{
							stringBuilder_0.Append((char)(num3 + 96));
						}
						num2 = 0;
						break;
					default:
						throw GException25.smethod_0();
					}
				}
				if (gclass657_0.method_1() <= 0)
				{
					break;
				}
			}
		}

		private static void smethod_3(GClass657 gclass657_0, StringBuilder stringBuilder_0)
		{
			bool flag = false;
			int[] array = new int[3];
			while (gclass657_0.method_1() != 8)
			{
				int num = gclass657_0.method_0(8);
				if (num == 254)
				{
					break;
				}
				smethod_5(num, gclass657_0.method_0(8), array);
				int num2 = 0;
				for (int i = 0; i < 3; i++)
				{
					int num3 = array[i];
					switch (num2)
					{
					case 0:
						if (num3 < 3)
						{
							num2 = num3 + 1;
						}
						else if (flag)
						{
							stringBuilder_0.Append((char)(char_2[num3] + 128));
							flag = false;
						}
						else
						{
							stringBuilder_0.Append(char_2[num3]);
						}
						break;
					case 1:
						if (flag)
						{
							stringBuilder_0.Append((char)(num3 + 128));
							flag = false;
						}
						else
						{
							stringBuilder_0.Append(num3);
						}
						num2 = 0;
						break;
					case 2:
						if (num3 < 27)
						{
							if (flag)
							{
								stringBuilder_0.Append((char)(char_1[num3] + 128));
								flag = false;
							}
							else
							{
								stringBuilder_0.Append(char_1[num3]);
							}
						}
						else
						{
							if (num3 == 27)
							{
								throw GException25.smethod_0();
							}
							if (num3 != 30)
							{
								throw GException25.smethod_0();
							}
							flag = true;
						}
						num2 = 0;
						break;
					case 3:
						if (flag)
						{
							stringBuilder_0.Append((char)(char_3[num3] + 128));
							flag = false;
						}
						else
						{
							stringBuilder_0.Append(char_3[num3]);
						}
						num2 = 0;
						break;
					default:
						throw GException25.smethod_0();
					}
				}
				if (gclass657_0.method_1() <= 0)
				{
					break;
				}
			}
		}

		private static void smethod_4(GClass657 gclass657_0, StringBuilder stringBuilder_0)
		{
			int[] array = new int[3];
			while (gclass657_0.method_1() != 8)
			{
				int num = gclass657_0.method_0(8);
				if (num == 254)
				{
					break;
				}
				smethod_5(num, gclass657_0.method_0(8), array);
				for (int i = 0; i < 3; i++)
				{
					int num2 = array[i];
					if (num2 == 0)
					{
						stringBuilder_0.Append('\r');
						continue;
					}
					if (num2 == 1)
					{
						stringBuilder_0.Append('*');
						continue;
					}
					if (num2 == 2)
					{
						stringBuilder_0.Append('>');
						continue;
					}
					if (num2 == 3)
					{
						stringBuilder_0.Append(' ');
						continue;
					}
					if (num2 < 14)
					{
						stringBuilder_0.Append((char)(num2 + 44));
						continue;
					}
					if (num2 < 40)
					{
						stringBuilder_0.Append((char)(num2 + 51));
						continue;
					}
					throw GException25.smethod_0();
				}
				if (gclass657_0.method_1() <= 0)
				{
					break;
				}
			}
		}

		private static void smethod_5(int int_7, int int_8, int[] int_9)
		{
			int num = (int_7 << 8) + int_8 - 1;
			num -= (int_9[0] = num / 1600) * 1600;
			int_9[2] = num - (int_9[1] = num / 40) * 40;
		}

		private static void smethod_6(GClass657 gclass657_0, StringBuilder stringBuilder_0)
		{
			bool flag = false;
			while (gclass657_0.method_1() > 16)
			{
				for (int i = 0; i < 4; i++)
				{
					int num = gclass657_0.method_0(6);
					if (num == 11111)
					{
						flag = true;
					}
					if (!flag)
					{
						if ((num & 0x20) == 0)
						{
							num |= 0x40;
						}
						stringBuilder_0.Append(num);
					}
				}
				if (flag || gclass657_0.method_1() <= 0)
				{
					break;
				}
			}
		}

		private static void smethod_7(GClass657 gclass657_0, StringBuilder stringBuilder_0, ArrayList arrayList_0)
		{
			int num = 6;
			int num2 = gclass657_0.method_0(8);
			int num3 = (num2 == 0) ? (gclass657_0.method_1() / 8) : ((num2 >= 250) ? (250 * (num2 - 249) + gclass657_0.method_0(8)) : num2);
			sbyte[] array = new sbyte[num3];
			for (int i = 0; i < num3; i++)
			{
				array[i] = smethod_8(gclass657_0.method_0(8), i);
			}
			arrayList_0.Add(GClass634.smethod_0(array));
			try
			{
				stringBuilder_0.Append(Encoding.GetEncoding("ISO8859_1").GetString(GClass634.smethod_0(array)));
			}
			catch (IOException arg)
			{
				throw new SystemException("Platform does not support required encoding: " + arg);
			}
		}

		private static sbyte smethod_8(int int_7, int int_8)
		{
			int num = 149 * int_8 % 255 + 1;
			int num2 = int_7 - num;
			return (sbyte)((num2 >= 0) ? num2 : (num2 + 256));
		}
	}
}
