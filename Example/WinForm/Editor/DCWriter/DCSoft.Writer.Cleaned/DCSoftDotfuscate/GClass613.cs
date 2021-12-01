using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass613
	{
		private const int int_0 = 7973;

		private const int int_1 = 1335;

		private const int int_2 = 21522;

		private static readonly int[][] int_3 = new int[7][]
		{
			new int[7]
			{
				1,
				1,
				1,
				1,
				1,
				1,
				1
			},
			new int[7]
			{
				1,
				0,
				0,
				0,
				0,
				0,
				1
			},
			new int[7]
			{
				1,
				0,
				1,
				1,
				1,
				0,
				1
			},
			new int[7]
			{
				1,
				0,
				1,
				1,
				1,
				0,
				1
			},
			new int[7]
			{
				1,
				0,
				1,
				1,
				1,
				0,
				1
			},
			new int[7]
			{
				1,
				0,
				0,
				0,
				0,
				0,
				1
			},
			new int[7]
			{
				1,
				1,
				1,
				1,
				1,
				1,
				1
			}
		};

		private static readonly int[][] int_4;

		private static readonly int[][] int_5;

		private static readonly int[][] int_6;

		private static readonly int[][] int_7;

		private static readonly int[][] int_8;

		private GClass613()
		{
		}

		public static void smethod_0(GClass658 gclass658_0)
		{
			gclass658_0.method_6(-1);
		}

		public static void smethod_1(GClass635 gclass635_0, GClass636 gclass636_0, int int_9, int int_10, GClass658 gclass658_0)
		{
			smethod_0(gclass658_0);
			smethod_2(int_9, gclass658_0);
			smethod_3(gclass636_0, int_10, gclass658_0);
			smethod_4(int_9, gclass658_0);
			smethod_5(gclass635_0, int_10, gclass658_0);
		}

		public static void smethod_2(int int_9, GClass658 gclass658_0)
		{
			smethod_18(gclass658_0);
			smethod_13(gclass658_0);
			smethod_19(int_9, gclass658_0);
			smethod_12(gclass658_0);
		}

		public static void smethod_3(GClass636 gclass636_0, int int_9, GClass658 gclass658_0)
		{
			GClass635 gClass = new GClass635();
			smethod_8(gclass636_0, int_9, gClass);
			for (int i = 0; i < gClass.method_2(); i++)
			{
				int num = gClass.method_1(gClass.method_2() - 1 - i);
				int num2 = int_8[i][0];
				int num3 = int_8[i][1];
				gclass658_0.method_5(num2, num3, num);
				if (i < 8)
				{
					int num4 = gclass658_0.method_1() - i - 1;
					int num5 = 8;
					gclass658_0.method_5(num4, 8, num);
				}
				else
				{
					int num4 = 8;
					int num5 = gclass658_0.method_0() - 7 + (i - 8);
					gclass658_0.method_5(8, num5, num);
				}
			}
		}

		public static void smethod_4(int int_9, GClass658 gclass658_0)
		{
			if (int_9 < 7)
			{
				return;
			}
			GClass635 gClass = new GClass635();
			smethod_9(int_9, gClass);
			int num = 17;
			for (int i = 0; i < 6; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					int num2 = gClass.method_1(num);
					num--;
					gclass658_0.method_5(i, gclass658_0.method_0() - 11 + j, num2);
					gclass658_0.method_5(gclass658_0.method_0() - 11 + j, i, num2);
				}
			}
		}

		public static void smethod_5(GClass635 gclass635_0, int int_9, GClass658 gclass658_0)
		{
			int num = 8;
			int num2 = 0;
			int num3 = -1;
			int num4 = gclass658_0.method_1() - 1;
			int i = gclass658_0.method_0() - 1;
			while (num4 > 0)
			{
				if (num4 == 6)
				{
					num4--;
				}
				for (; i >= 0 && i < gclass658_0.method_0(); i += num3)
				{
					for (int j = 0; j < 2; j++)
					{
						int num5 = num4 - j;
						if (smethod_10(gclass658_0.method_3(num5, i)))
						{
							int num6;
							if (num2 < gclass635_0.method_2())
							{
								num6 = gclass635_0.method_1(num2);
								num2++;
							}
							else
							{
								num6 = 0;
							}
							if (int_9 != -1 && GClass638.smethod_4(int_9, num5, i))
							{
								num6 ^= 1;
							}
							gclass658_0.method_5(num5, i, num6);
						}
					}
				}
				num3 = -num3;
				i += num3;
				num4 -= 2;
			}
			if (num2 != gclass635_0.method_2())
			{
				throw new GException26("Not all bits consumed: " + num2 + '/' + gclass635_0.method_2());
			}
		}

		public static int smethod_6(int int_9)
		{
			int num = 0;
			while (int_9 != 0)
			{
				int_9 = GClass634.smethod_3(int_9, 1);
				num++;
			}
			return num;
		}

		public static int smethod_7(int int_9, int int_10)
		{
			int num = smethod_6(int_10);
			int_9 <<= num - 1;
			while (smethod_6(int_9) >= num)
			{
				int_9 ^= int_10 << smethod_6(int_9) - num;
			}
			return int_9;
		}

		public static void smethod_8(GClass636 gclass636_0, int int_9, GClass635 gclass635_0)
		{
			int num = 8;
			if (!GClass632.smethod_0(int_9))
			{
				throw new GException26("Invalid mask pattern");
			}
			int int_10 = (gclass636_0.method_0() << 3) | int_9;
			gclass635_0.method_5(int_10, 5);
			int num2 = smethod_7(int_10, 1335);
			gclass635_0.method_5(num2, 10);
			GClass635 gClass = new GClass635();
			gClass.method_5(21522, 15);
			gclass635_0.method_7(gClass);
			if (gclass635_0.method_2() != 15)
			{
				throw new GException26("should not happen but we got: " + gclass635_0.method_2());
			}
		}

		public static void smethod_9(int int_9, GClass635 gclass635_0)
		{
			int num = 15;
			gclass635_0.method_5(int_9, 6);
			int num2 = smethod_7(int_9, 7973);
			gclass635_0.method_5(num2, 12);
			if (gclass635_0.method_2() != 18)
			{
				throw new GException26("should not happen but we got: " + gclass635_0.method_2());
			}
		}

		private static bool smethod_10(int int_9)
		{
			return int_9 == -1;
		}

		private static bool smethod_11(int int_9)
		{
			return int_9 == -1 || int_9 == 0 || int_9 == 1;
		}

		private static void smethod_12(GClass658 gclass658_0)
		{
			int num = 8;
			while (true)
			{
				if (num < gclass658_0.method_1() - 8)
				{
					int num2 = (num + 1) % 2;
					if (smethod_11(gclass658_0.method_3(num, 6)))
					{
						if (smethod_10(gclass658_0.method_3(num, 6)))
						{
							gclass658_0.method_5(num, 6, num2);
						}
						if (!smethod_11(gclass658_0.method_3(6, num)))
						{
							break;
						}
						if (smethod_10(gclass658_0.method_3(6, num)))
						{
							gclass658_0.method_5(6, num, num2);
						}
						num++;
						continue;
					}
					throw new GException26();
				}
				return;
			}
			throw new GException26();
		}

		private static void smethod_13(GClass658 gclass658_0)
		{
			if (gclass658_0.method_3(8, gclass658_0.method_0() - 8) == 0)
			{
				throw new GException26();
			}
			gclass658_0.method_5(8, gclass658_0.method_0() - 8, 1);
		}

		private static void smethod_14(int int_9, int int_10, GClass658 gclass658_0)
		{
			int num = 0;
			if (int_4[0].Length != 8 || int_4.Length != 1)
			{
				throw new GException26("Bad horizontal separation pattern");
			}
			int num2 = 0;
			while (true)
			{
				if (num2 < 8)
				{
					if (!smethod_10(gclass658_0.method_3(int_9 + num2, int_10)))
					{
						break;
					}
					gclass658_0.method_5(int_9 + num2, int_10, int_4[0][num2]);
					num2++;
					continue;
				}
				return;
			}
			throw new GException26();
		}

		private static void smethod_15(int int_9, int int_10, GClass658 gclass658_0)
		{
			int num = 2;
			if (int_5[0].Length != 1 || int_5.Length != 7)
			{
				throw new GException26("Bad vertical separation pattern");
			}
			int num2 = 0;
			while (true)
			{
				if (num2 < 7)
				{
					if (!smethod_10(gclass658_0.method_3(int_9, int_10 + num2)))
					{
						break;
					}
					gclass658_0.method_5(int_9, int_10 + num2, int_5[num2][0]);
					num2++;
					continue;
				}
				return;
			}
			throw new GException26();
		}

		private static void smethod_16(int int_9, int int_10, GClass658 gclass658_0)
		{
			int num = 7;
			if (int_6[0].Length != 5 || int_6.Length != 5)
			{
				throw new GException26("Bad position adjustment");
			}
			for (int i = 0; i < 5; i++)
			{
				for (int j = 0; j < 5; j++)
				{
					if (smethod_10(gclass658_0.method_3(int_9 + j, int_10 + i)))
					{
						gclass658_0.method_5(int_9 + j, int_10 + i, int_6[i][j]);
						continue;
					}
					throw new GException26();
				}
			}
		}

		private static void smethod_17(int int_9, int int_10, GClass658 gclass658_0)
		{
			int num = 5;
			if (int_3[0].Length != 7 || int_3.Length != 7)
			{
				throw new GException26("Bad position detection pattern");
			}
			for (int i = 0; i < 7; i++)
			{
				for (int j = 0; j < 7; j++)
				{
					if (smethod_10(gclass658_0.method_3(int_9 + j, int_10 + i)))
					{
						gclass658_0.method_5(int_9 + j, int_10 + i, int_3[i][j]);
						continue;
					}
					throw new GException26();
				}
			}
		}

		private static void smethod_18(GClass658 gclass658_0)
		{
			int num = int_3[0].Length;
			smethod_17(0, 0, gclass658_0);
			smethod_17(gclass658_0.method_1() - num, 0, gclass658_0);
			smethod_17(0, gclass658_0.method_1() - num, gclass658_0);
			int num2 = int_4[0].Length;
			smethod_14(0, num2 - 1, gclass658_0);
			smethod_14(gclass658_0.method_1() - num2, num2 - 1, gclass658_0);
			smethod_14(0, gclass658_0.method_1() - num2, gclass658_0);
			int num3 = int_5.Length;
			smethod_15(num3, 0, gclass658_0);
			smethod_15(gclass658_0.method_0() - num3 - 1, 0, gclass658_0);
			smethod_15(num3, gclass658_0.method_0() - num3, gclass658_0);
		}

		private static void smethod_19(int int_9, GClass658 gclass658_0)
		{
			if (int_9 < 2)
			{
				return;
			}
			int num = int_9 - 1;
			int[] array = int_7[num];
			int num2 = int_7[num].Length;
			for (int i = 0; i < num2; i++)
			{
				for (int j = 0; j < num2; j++)
				{
					int num3 = array[i];
					int num4 = array[j];
					if (num4 != -1 && num3 != -1 && smethod_10(gclass658_0.method_3(num4, num3)))
					{
						smethod_16(num4 - 2, num3 - 2, gclass658_0);
					}
				}
			}
		}

		static GClass613()
		{
			int[][] array = new int[1][];
			int[] array2 = array[0] = new int[8];
			int_4 = array;
			array = new int[7][];
			array2 = (array[0] = new int[1]);
			array2 = (array[1] = new int[1]);
			array2 = (array[2] = new int[1]);
			array2 = (array[3] = new int[1]);
			array2 = (array[4] = new int[1]);
			array2 = (array[5] = new int[1]);
			array2 = (array[6] = new int[1]);
			int_5 = array;
			int_6 = new int[5][]
			{
				new int[5]
				{
					1,
					1,
					1,
					1,
					1
				},
				new int[5]
				{
					1,
					0,
					0,
					0,
					1
				},
				new int[5]
				{
					1,
					0,
					1,
					0,
					1
				},
				new int[5]
				{
					1,
					0,
					0,
					0,
					1
				},
				new int[5]
				{
					1,
					1,
					1,
					1,
					1
				}
			};
			int_7 = new int[40][]
			{
				new int[7]
				{
					-1,
					-1,
					-1,
					-1,
					-1,
					-1,
					-1
				},
				new int[7]
				{
					6,
					18,
					-1,
					-1,
					-1,
					-1,
					-1
				},
				new int[7]
				{
					6,
					22,
					-1,
					-1,
					-1,
					-1,
					-1
				},
				new int[7]
				{
					6,
					26,
					-1,
					-1,
					-1,
					-1,
					-1
				},
				new int[7]
				{
					6,
					30,
					-1,
					-1,
					-1,
					-1,
					-1
				},
				new int[7]
				{
					6,
					34,
					-1,
					-1,
					-1,
					-1,
					-1
				},
				new int[7]
				{
					6,
					22,
					38,
					-1,
					-1,
					-1,
					-1
				},
				new int[7]
				{
					6,
					24,
					42,
					-1,
					-1,
					-1,
					-1
				},
				new int[7]
				{
					6,
					26,
					46,
					-1,
					-1,
					-1,
					-1
				},
				new int[7]
				{
					6,
					28,
					50,
					-1,
					-1,
					-1,
					-1
				},
				new int[7]
				{
					6,
					30,
					54,
					-1,
					-1,
					-1,
					-1
				},
				new int[7]
				{
					6,
					32,
					58,
					-1,
					-1,
					-1,
					-1
				},
				new int[7]
				{
					6,
					34,
					62,
					-1,
					-1,
					-1,
					-1
				},
				new int[7]
				{
					6,
					26,
					46,
					66,
					-1,
					-1,
					-1
				},
				new int[7]
				{
					6,
					26,
					48,
					70,
					-1,
					-1,
					-1
				},
				new int[7]
				{
					6,
					26,
					50,
					74,
					-1,
					-1,
					-1
				},
				new int[7]
				{
					6,
					30,
					54,
					78,
					-1,
					-1,
					-1
				},
				new int[7]
				{
					6,
					30,
					56,
					82,
					-1,
					-1,
					-1
				},
				new int[7]
				{
					6,
					30,
					58,
					86,
					-1,
					-1,
					-1
				},
				new int[7]
				{
					6,
					34,
					62,
					90,
					-1,
					-1,
					-1
				},
				new int[7]
				{
					6,
					28,
					50,
					72,
					94,
					-1,
					-1
				},
				new int[7]
				{
					6,
					26,
					50,
					74,
					98,
					-1,
					-1
				},
				new int[7]
				{
					6,
					30,
					54,
					78,
					102,
					-1,
					-1
				},
				new int[7]
				{
					6,
					28,
					54,
					80,
					106,
					-1,
					-1
				},
				new int[7]
				{
					6,
					32,
					58,
					84,
					110,
					-1,
					-1
				},
				new int[7]
				{
					6,
					30,
					58,
					86,
					114,
					-1,
					-1
				},
				new int[7]
				{
					6,
					34,
					62,
					90,
					118,
					-1,
					-1
				},
				new int[7]
				{
					6,
					26,
					50,
					74,
					98,
					122,
					-1
				},
				new int[7]
				{
					6,
					30,
					54,
					78,
					102,
					126,
					-1
				},
				new int[7]
				{
					6,
					26,
					52,
					78,
					104,
					130,
					-1
				},
				new int[7]
				{
					6,
					30,
					56,
					82,
					108,
					134,
					-1
				},
				new int[7]
				{
					6,
					34,
					60,
					86,
					112,
					138,
					-1
				},
				new int[7]
				{
					6,
					30,
					58,
					86,
					114,
					142,
					-1
				},
				new int[7]
				{
					6,
					34,
					62,
					90,
					118,
					146,
					-1
				},
				new int[7]
				{
					6,
					30,
					54,
					78,
					102,
					126,
					150
				},
				new int[7]
				{
					6,
					24,
					50,
					76,
					102,
					128,
					154
				},
				new int[7]
				{
					6,
					28,
					54,
					80,
					106,
					132,
					158
				},
				new int[7]
				{
					6,
					32,
					58,
					84,
					110,
					136,
					162
				},
				new int[7]
				{
					6,
					26,
					54,
					82,
					110,
					138,
					166
				},
				new int[7]
				{
					6,
					30,
					58,
					86,
					114,
					142,
					170
				}
			};
			int_8 = new int[15][]
			{
				new int[2]
				{
					8,
					0
				},
				new int[2]
				{
					8,
					1
				},
				new int[2]
				{
					8,
					2
				},
				new int[2]
				{
					8,
					3
				},
				new int[2]
				{
					8,
					4
				},
				new int[2]
				{
					8,
					5
				},
				new int[2]
				{
					8,
					7
				},
				new int[2]
				{
					8,
					8
				},
				new int[2]
				{
					7,
					8
				},
				new int[2]
				{
					5,
					8
				},
				new int[2]
				{
					4,
					8
				},
				new int[2]
				{
					3,
					8
				},
				new int[2]
				{
					2,
					8
				},
				new int[2]
				{
					1,
					8
				},
				new int[2]
				{
					0,
					8
				}
			};
		}
	}
}
