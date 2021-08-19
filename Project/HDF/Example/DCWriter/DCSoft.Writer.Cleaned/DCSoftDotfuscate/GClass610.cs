using DCSoft.TDCode;
using System;
using System.Collections;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass610 : GInterface52
	{
		private const int int_0 = 4;

		public GClass658 imethod_0(string string_0, BarcodeFormat barcodeFormat_0, int int_1, int int_2)
		{
			return imethod_1(string_0, barcodeFormat_0, int_1, int_2, null);
		}

		public GClass658 imethod_1(string string_0, BarcodeFormat barcodeFormat_0, int int_1, int int_2, Hashtable hashtable_0)
		{
			int num = 1;
			if (string_0 == null || string_0.Length == 0)
			{
				throw new ArgumentException("Found empty contents");
			}
			if (barcodeFormat_0 != BarcodeFormat.barcodeFormat_0)
			{
				throw new ArgumentException("Can only encode QR_CODE, but got " + barcodeFormat_0);
			}
			if (int_1 < 0 || int_2 < 0)
			{
				throw new ArgumentException("Requested dimensions are too small: " + int_1 + 'x' + int_2);
			}
			GClass636 gclass636_ = GClass636.gclass636_0;
			if (hashtable_0 != null)
			{
				GClass636 gClass = (GClass636)hashtable_0[GClass685.gclass685_0];
				if (gClass != null)
				{
					gclass636_ = gClass;
				}
			}
			GClass632 gclass632_ = new GClass632();
			GClass614.smethod_2(string_0, gclass636_, hashtable_0, gclass632_);
			return smethod_0(gclass632_, int_1, int_2);
		}

		private static GClass658 smethod_0(GClass632 gclass632_0, int int_1, int int_2)
		{
			GClass658 gClass = gclass632_0.method_18();
			int num = gClass.method_1();
			int num2 = gClass.method_0();
			int num3 = num + 8;
			int num4 = num2 + 8;
			int num5 = Math.Max(int_1, num3);
			int num6 = Math.Max(int_2, num4);
			int num7 = Math.Min(num5 / num3, num6 / num4);
			int num8 = (num5 - num * num7) / 2;
			int num9 = (num6 - num2 * num7) / 2;
			GClass658 gClass2 = new GClass658(num5, num6);
			sbyte[][] array = gClass2.method_2();
			sbyte[] array2 = new sbyte[num5];
			for (int i = 0; i < num9; i++)
			{
				smethod_1(array[i], (sbyte)GClass634.smethod_7(255L));
			}
			sbyte[][] array3 = gClass.method_2();
			for (int i = 0; i < num2; i++)
			{
				for (int j = 0; j < num8; j++)
				{
					array2[j] = (sbyte)GClass634.smethod_7(255L);
				}
				int num10 = num8;
				for (int j = 0; j < num; j++)
				{
					sbyte b = (sbyte)((array3[i][j] == 1) ? 0L : GClass634.smethod_7(255L));
					for (int k = 0; k < num7; k++)
					{
						array2[num10 + k] = b;
					}
					num10 += num7;
				}
				num10 = num8 + num * num7;
				for (int j = num10; j < num5; j++)
				{
					array2[j] = (sbyte)GClass634.smethod_7(255L);
				}
				num10 = num9 + i * num7;
				for (int k = 0; k < num7; k++)
				{
					Array.Copy(array2, 0, array[num10 + k], 0, num5);
				}
			}
			int num11 = num9 + num2 * num7;
			for (int i = num11; i < num6; i++)
			{
				smethod_1(array[i], (sbyte)GClass634.smethod_7(255L));
			}
			return gClass2;
		}

		private static void smethod_1(sbyte[] sbyte_0, sbyte sbyte_1)
		{
			for (int i = 0; i < sbyte_0.Length; i++)
			{
				sbyte_0[i] = sbyte_1;
			}
		}

		public Size method_0(string string_0, BarcodeFormat barcodeFormat_0, int int_1, int int_2, Hashtable hashtable_0)
		{
			int num = 12;
			if (string_0 == null || string_0.Length == 0)
			{
				throw new ArgumentException("Found empty contents");
			}
			if (barcodeFormat_0 != BarcodeFormat.barcodeFormat_0)
			{
				throw new ArgumentException("Can only encode QR_CODE, but got " + barcodeFormat_0);
			}
			if (int_1 < 0 || int_2 < 0)
			{
				throw new ArgumentException("Requested dimensions are too small: " + int_1 + 'x' + int_2);
			}
			GClass636 gclass636_ = GClass636.gclass636_0;
			if (hashtable_0 != null)
			{
				GClass636 gClass = (GClass636)hashtable_0[GClass685.gclass685_0];
				if (gClass != null)
				{
					gclass636_ = gClass;
				}
			}
			GClass632 gclass632_ = new GClass632();
			GClass614.smethod_2(string_0, gclass636_, hashtable_0, gclass632_);
			return smethod_2(gclass632_, int_1, int_2);
		}

		private static Size smethod_2(GClass632 gclass632_0, int int_1, int int_2)
		{
			GClass658 gClass = gclass632_0.method_18();
			int num = gClass.method_1();
			int num2 = gClass.method_0();
			int num3 = num + 8;
			int num4 = num2 + 8;
			int num5 = Math.Max(int_1, num3);
			int num6 = Math.Max(int_2, num4);
			int num7 = Math.Min(num5 / num3, num6 / num4);
			if (num7 <= 0)
			{
				num7 = 1;
			}
			return new Size(num * num7, num2 * num7);
		}
	}
}
