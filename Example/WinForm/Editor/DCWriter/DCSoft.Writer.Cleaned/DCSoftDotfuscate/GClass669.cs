using DCSoft.TDCode;
using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass669 : GClass667
	{
		private const int int_0 = 95;

		public override GClass658 imethod_1(string string_0, BarcodeFormat barcodeFormat_0, int int_1, int int_2, Hashtable hashtable_0)
		{
			int num = 9;
			if (barcodeFormat_0 != BarcodeFormat.barcodeFormat_5)
			{
				throw new ArgumentException("Can only encode EAN_13, but got " + barcodeFormat_0);
			}
			return base.imethod_1(string_0, barcodeFormat_0, int_1, int_2, hashtable_0);
		}

		public override sbyte[] vmethod_0(string string_0)
		{
			int num = 6;
			if (string_0.Length != 13)
			{
				throw new ArgumentException("Requested contents should be 13 digits long, but got " + string_0.Length);
			}
			int num2 = int.Parse(string_0.Substring(0, 1));
			int num3 = GClass599.int_8[num2];
			sbyte[] array = new sbyte[95];
			int num4 = 0;
			num4 = 0 + GClass667.smethod_1(array, 0, GClass597.int_4, 1);
			for (int i = 1; i <= 6; i++)
			{
				int num5 = int.Parse(string_0.Substring(i, i + 1 - i));
				if (((num3 >> 6 - i) & 1) == 1)
				{
					num5 += 10;
				}
				num4 += GClass667.smethod_1(array, num4, GClass597.int_7[num5], 0);
			}
			num4 += GClass667.smethod_1(array, num4, GClass597.int_5, 0);
			for (int i = 7; i <= 12; i++)
			{
				int num5 = int.Parse(string_0.Substring(i, i + 1 - i));
				num4 += GClass667.smethod_1(array, num4, GClass597.int_6[num5], 1);
			}
			num4 += GClass667.smethod_1(array, num4, GClass597.int_4, 1);
			return array;
		}
	}
}
