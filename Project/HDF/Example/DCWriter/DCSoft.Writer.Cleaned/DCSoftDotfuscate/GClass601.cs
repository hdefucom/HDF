using DCSoft.TDCode;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass601 : GClass597
	{
		private static readonly int[] int_8 = new int[6]
		{
			1,
			1,
			1,
			1,
			1,
			1
		};

		private static readonly int[][] int_9 = new int[2][]
		{
			new int[10]
			{
				56,
				52,
				50,
				49,
				44,
				38,
				35,
				42,
				41,
				37
			},
			new int[10]
			{
				7,
				11,
				13,
				14,
				19,
				25,
				28,
				21,
				22,
				26
			}
		};

		private int[] int_10;

		internal override BarcodeFormat vmethod_1()
		{
			return BarcodeFormat.barcodeFormat_2;
		}

		public GClass601()
		{
			int_10 = new int[4];
		}

		protected internal override int vmethod_5(GClass659 gclass659_0, int[] int_11, StringBuilder stringBuilder_1)
		{
			int[] array = int_10;
			array[0] = 0;
			array[1] = 0;
			array[2] = 0;
			array[3] = 0;
			int num = gclass659_0.method_0();
			int num2 = int_11[1];
			int num3 = 0;
			for (int i = 0; i < 6; i++)
			{
				if (num2 >= num)
				{
					break;
				}
				int num4 = GClass597.smethod_5(gclass659_0, array, num2, GClass597.int_7);
				stringBuilder_1.Append((char)(48 + num4 % 10));
				for (int j = 0; j < array.Length; j++)
				{
					num2 += array[j];
				}
				if (num4 >= 10)
				{
					num3 |= 1 << 5 - i;
				}
			}
			smethod_6(stringBuilder_1, num3);
			return num2;
		}

		protected internal override int[] vmethod_4(GClass659 gclass659_0, int int_11)
		{
			return GClass597.smethod_4(gclass659_0, int_11, bool_0: true, int_8);
		}

		protected internal override bool vmethod_3(string string_0)
		{
			return base.vmethod_3(smethod_7(string_0));
		}

		private static void smethod_6(StringBuilder stringBuilder_1, int int_11)
		{
			for (int i = 0; i <= 1; i++)
			{
				for (int j = 0; j < 10; j++)
				{
					if (int_11 == int_9[i][j])
					{
						stringBuilder_1.Insert(0, (char)(48 + i));
						stringBuilder_1.Append((char)(48 + j));
						return;
					}
				}
			}
			throw GException25.smethod_0();
		}

		public static string smethod_7(string string_0)
		{
			int num = 1;
			char[] array = new char[6];
			GClass634.smethod_11(string_0, 1, 7, array, 0);
			StringBuilder stringBuilder = new StringBuilder(12);
			stringBuilder.Append(string_0[0]);
			char c = array[5];
			switch (c)
			{
			default:
				stringBuilder.Append(array, 0, 5);
				stringBuilder.Append("0000");
				stringBuilder.Append(c);
				break;
			case '0':
			case '1':
			case '2':
				stringBuilder.Append(array, 0, 2);
				stringBuilder.Append(c);
				stringBuilder.Append("0000");
				stringBuilder.Append(array, 2, 3);
				break;
			case '3':
				stringBuilder.Append(array, 0, 3);
				stringBuilder.Append("00000");
				stringBuilder.Append(array, 3, 2);
				break;
			case '4':
				stringBuilder.Append(array, 0, 4);
				stringBuilder.Append("00000");
				stringBuilder.Append(array[4]);
				break;
			}
			stringBuilder.Append(string_0[7]);
			return stringBuilder.ToString();
		}
	}
}
