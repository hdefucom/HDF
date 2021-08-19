using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass638
	{
		private GClass638()
		{
		}

		public static int smethod_0(GClass658 gclass658_0)
		{
			return smethod_5(gclass658_0, bool_0: true) + smethod_5(gclass658_0, bool_0: false);
		}

		public static int smethod_1(GClass658 gclass658_0)
		{
			int num = 0;
			sbyte[][] array = gclass658_0.method_2();
			int num2 = gclass658_0.method_1();
			int num3 = gclass658_0.method_0();
			for (int i = 0; i < num3 - 1; i++)
			{
				for (int j = 0; j < num2 - 1; j++)
				{
					int num4 = array[i][j];
					if (num4 == array[i][j + 1] && num4 == array[i + 1][j] && num4 == array[i + 1][j + 1])
					{
						num += 3;
					}
				}
			}
			return num;
		}

		public static int smethod_2(GClass658 gclass658_0)
		{
			int num = 0;
			sbyte[][] array = gclass658_0.method_2();
			int num2 = gclass658_0.method_1();
			int num3 = gclass658_0.method_0();
			for (int i = 0; i < num3; i++)
			{
				for (int j = 0; j < num2; j++)
				{
					if (j + 6 < num2 && array[i][j] == 1 && array[i][j + 1] == 0 && array[i][j + 2] == 1 && array[i][j + 3] == 1 && array[i][j + 4] == 1 && array[i][j + 5] == 0 && array[i][j + 6] == 1 && ((j + 10 < num2 && array[i][j + 7] == 0 && array[i][j + 8] == 0 && array[i][j + 9] == 0 && array[i][j + 10] == 0) || (j - 4 >= 0 && array[i][j - 1] == 0 && array[i][j - 2] == 0 && array[i][j - 3] == 0 && array[i][j - 4] == 0)))
					{
						num += 40;
					}
					if (i + 6 < num3 && array[i][j] == 1 && array[i + 1][j] == 0 && array[i + 2][j] == 1 && array[i + 3][j] == 1 && array[i + 4][j] == 1 && array[i + 5][j] == 0 && array[i + 6][j] == 1 && ((i + 10 < num3 && array[i + 7][j] == 0 && array[i + 8][j] == 0 && array[i + 9][j] == 0 && array[i + 10][j] == 0) || (i - 4 >= 0 && array[i - 1][j] == 0 && array[i - 2][j] == 0 && array[i - 3][j] == 0 && array[i - 4][j] == 0)))
					{
						num += 40;
					}
				}
			}
			return num;
		}

		public static int smethod_3(GClass658 gclass658_0)
		{
			int num = 0;
			sbyte[][] array = gclass658_0.method_2();
			int num2 = gclass658_0.method_1();
			int num3 = gclass658_0.method_0();
			for (int i = 0; i < num3; i++)
			{
				for (int j = 0; j < num2; j++)
				{
					if (array[i][j] == 1)
					{
						num++;
					}
				}
			}
			int num4 = gclass658_0.method_0() * gclass658_0.method_1();
			double num5 = (double)num / (double)num4;
			return Math.Abs((int)(num5 * 100.0 - 50.0)) / 5 * 10;
		}

		public static bool smethod_4(int int_0, int int_1, int int_2)
		{
			int num = 14;
			if (!GClass632.smethod_0(int_0))
			{
				throw new ArgumentException("Invalid mask pattern");
			}
			int num3;
			switch (int_0)
			{
			default:
				throw new ArgumentException("Invalid mask pattern: " + int_0);
			case 0:
				num3 = ((int_2 + int_1) & 1);
				break;
			case 1:
				num3 = (int_2 & 1);
				break;
			case 2:
				num3 = int_1 % 3;
				break;
			case 3:
				num3 = (int_2 + int_1) % 3;
				break;
			case 4:
				num3 = ((GClass634.smethod_3(int_2, 1) + int_1 / 3) & 1);
				break;
			case 5:
			{
				int num2 = int_2 * int_1;
				num3 = (num2 & 1) + num2 % 3;
				break;
			}
			case 6:
			{
				int num2 = int_2 * int_1;
				num3 = (((num2 & 1) + num2 % 3) & 1);
				break;
			}
			case 7:
			{
				int num2 = int_2 * int_1;
				num3 = ((num2 % 3 + ((int_2 + int_1) & 1)) & 1);
				break;
			}
			}
			return num3 == 0;
		}

		private static int smethod_5(GClass658 gclass658_0, bool bool_0)
		{
			int num = 0;
			int num2 = 0;
			int num3 = -1;
			int num4 = bool_0 ? gclass658_0.method_0() : gclass658_0.method_1();
			int num5 = bool_0 ? gclass658_0.method_1() : gclass658_0.method_0();
			sbyte[][] array = gclass658_0.method_2();
			for (int i = 0; i < num4; i++)
			{
				for (int j = 0; j < num5; j++)
				{
					int num6 = bool_0 ? array[i][j] : array[j][i];
					if (num6 == num3)
					{
						num2++;
						if (num2 == 5)
						{
							num += 3;
						}
						else if (num2 > 5)
						{
							num++;
						}
					}
					else
					{
						num2 = 1;
						num3 = num6;
					}
				}
				num2 = 0;
			}
			return num;
		}
	}
}
