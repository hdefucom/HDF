using DCSoft.TDCode;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass598 : GClass597
	{
		private int[] int_8;

		internal override BarcodeFormat vmethod_1()
		{
			return BarcodeFormat.barcodeFormat_4;
		}

		public GClass598()
		{
			int_8 = new int[4];
		}

		protected internal override int vmethod_5(GClass659 gclass659_0, int[] int_9, StringBuilder stringBuilder_1)
		{
			int[] array = int_8;
			array[0] = 0;
			array[1] = 0;
			array[2] = 0;
			array[3] = 0;
			int num = gclass659_0.method_0();
			int num2 = int_9[1];
			for (int i = 0; i < 4; i++)
			{
				if (num2 >= num)
				{
					break;
				}
				int num3 = GClass597.smethod_5(gclass659_0, array, num2, GClass597.int_6);
				stringBuilder_1.Append((char)(48 + num3));
				for (int j = 0; j < array.Length; j++)
				{
					num2 += array[j];
				}
			}
			int[] array2 = GClass597.smethod_4(gclass659_0, num2, bool_0: true, GClass597.int_5);
			num2 = array2[1];
			for (int i = 0; i < 4; i++)
			{
				if (num2 >= num)
				{
					break;
				}
				int num3 = GClass597.smethod_5(gclass659_0, array, num2, GClass597.int_6);
				stringBuilder_1.Append((char)(48 + num3));
				for (int j = 0; j < array.Length; j++)
				{
					num2 += array[j];
				}
			}
			return num2;
		}
	}
}
