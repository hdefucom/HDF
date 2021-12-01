using DCSoft.TDCode;
using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass670 : GClass667
	{
		public override GClass658 imethod_1(string string_0, BarcodeFormat barcodeFormat_0, int int_0, int int_1, Hashtable hashtable_0)
		{
			int num = 16;
			if (barcodeFormat_0 != BarcodeFormat.barcodeFormat_7)
			{
				throw new ArgumentException("Can only encode CODE_39, but got " + barcodeFormat_0);
			}
			return base.imethod_1(string_0, barcodeFormat_0, int_0, int_1, hashtable_0);
		}

		public override sbyte[] vmethod_0(string string_0)
		{
			int num = 16;
			int length = string_0.Length;
			if (length > 80)
			{
				throw new ArgumentException("Requested contents should be less than 80 digits long, but got " + length);
			}
			int[] array = new int[9];
			int num2 = 25 + length;
			for (int i = 0; i < length; i++)
			{
				int num3 = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ-. *$/+%".IndexOf(string_0[i]);
				smethod_2(GClass604.int_2[num3], array);
				for (int j = 0; j < array.Length; j++)
				{
					num2 += array[j];
				}
			}
			sbyte[] array2 = new sbyte[num2];
			smethod_2(GClass604.int_2[39], array);
			int num4 = GClass667.smethod_1(array2, 0, array, 1);
			int[] int_ = new int[1]
			{
				1
			};
			num4 += GClass667.smethod_1(array2, num4, int_, 0);
			for (int i = length - 1; i >= 0; i--)
			{
				int num3 = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ-. *$/+%".IndexOf(string_0[i]);
				smethod_2(GClass604.int_2[num3], array);
				num4 += GClass667.smethod_1(array2, num4, array, 1);
				num4 += GClass667.smethod_1(array2, num4, int_, 0);
			}
			smethod_2(GClass604.int_2[39], array);
			num4 += GClass667.smethod_1(array2, num4, array, 1);
			return array2;
		}

		private static void smethod_2(int int_0, int[] int_1)
		{
			for (int i = 0; i < 9; i++)
			{
				int num = int_0 & (1 << i);
				int_1[i] = ((num == 0) ? 1 : 2);
			}
		}
	}
}
