using DCSoft.TDCode;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass599 : GClass597
	{
		internal static readonly int[] int_8 = new int[10]
		{
			0,
			11,
			13,
			14,
			19,
			25,
			28,
			21,
			22,
			26
		};

		private int[] int_9;

		internal override BarcodeFormat vmethod_1()
		{
			return BarcodeFormat.barcodeFormat_5;
		}

		public GClass599()
		{
			int_9 = new int[4];
		}

		protected internal override int vmethod_5(GClass659 gclass659_0, int[] int_10, StringBuilder stringBuilder_1)
		{
			int[] array = int_9;
			array[0] = 0;
			array[1] = 0;
			array[2] = 0;
			array[3] = 0;
			int num = gclass659_0.method_0();
			int num2 = int_10[1];
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
			int[] array2 = GClass597.smethod_4(gclass659_0, num2, bool_0: true, GClass597.int_5);
			num2 = array2[1];
			for (int i = 0; i < 6; i++)
			{
				if (num2 >= num)
				{
					break;
				}
				int num4 = GClass597.smethod_5(gclass659_0, array, num2, GClass597.int_6);
				stringBuilder_1.Append((char)(48 + num4));
				for (int j = 0; j < array.Length; j++)
				{
					num2 += array[j];
				}
			}
			return num2;
		}

		private static void smethod_6(StringBuilder stringBuilder_1, int int_10)
		{
			int num = 0;
			while (true)
			{
				if (num < 10)
				{
					if (int_10 == int_8[num])
					{
						break;
					}
					num++;
					continue;
				}
				throw GException25.smethod_0();
			}
			stringBuilder_1.Insert(0, (char)(48 + num));
		}
	}
}
