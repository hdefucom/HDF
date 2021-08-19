using DCSoft.TDCode;
using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass668 : GClass667
	{
		private const int int_0 = 67;

		public override GClass658 imethod_1(string string_0, BarcodeFormat barcodeFormat_0, int int_1, int int_2, Hashtable hashtable_0)
		{
			int num = 4;
			if (barcodeFormat_0 != BarcodeFormat.barcodeFormat_4)
			{
				throw new ArgumentException("Can only encode EAN_8, but got " + barcodeFormat_0);
			}
			return base.imethod_1(string_0, barcodeFormat_0, int_1, int_2, hashtable_0);
		}

		public override sbyte[] vmethod_0(string string_0)
		{
			int num = 1;
			if (string_0.Length != 8)
			{
				throw new ArgumentException("Requested contents should be 8 digits long, but got " + string_0.Length);
			}
			sbyte[] array = new sbyte[67];
			int num2 = 0;
			num2 = 0 + GClass667.smethod_1(array, 0, GClass597.int_4, 1);
			for (int i = 0; i <= 3; i++)
			{
				int num3 = int.Parse(string_0.Substring(i, i + 1 - i));
				num2 += GClass667.smethod_1(array, num2, GClass597.int_6[num3], 0);
			}
			num2 += GClass667.smethod_1(array, num2, GClass597.int_5, 0);
			for (int i = 4; i <= 7; i++)
			{
				int num3 = int.Parse(string_0.Substring(i, i + 1 - i));
				num2 += GClass667.smethod_1(array, num2, GClass597.int_6[num3], 1);
			}
			num2 += GClass667.smethod_1(array, num2, GClass597.int_4, 1);
			return array;
		}
	}
}
