using DCSoft.TDCode;
using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public abstract class GClass667 : GInterface52
	{
		public virtual GClass658 imethod_0(string string_0, BarcodeFormat barcodeFormat_0, int int_0, int int_1)
		{
			return imethod_1(string_0, barcodeFormat_0, int_0, int_1, null);
		}

		public virtual GClass658 imethod_1(string string_0, BarcodeFormat barcodeFormat_0, int int_0, int int_1, Hashtable hashtable_0)
		{
			int num = 0;
			if (string_0 == null || string_0.Length == 0)
			{
				throw new ArgumentException("Found empty contents");
			}
			if (int_0 < 0 || int_1 < 0)
			{
				throw new ArgumentException("Requested dimensions are too small: " + int_0 + 'x' + int_1);
			}
			sbyte[] sbyte_ = vmethod_0(string_0);
			return smethod_0(sbyte_, int_0, int_1);
		}

		private static GClass658 smethod_0(sbyte[] sbyte_0, int int_0, int int_1)
		{
			int num = sbyte_0.Length;
			int num2 = num + (GClass597.int_4.Length << 1);
			int num3 = Math.Max(int_0, num2);
			int num4 = Math.Max(1, int_1);
			int num5 = num3 / num2;
			int num6 = (num3 - num * num5) / 2;
			GClass658 gClass = new GClass658(num3, num4);
			sbyte[][] array = gClass.method_2();
			sbyte[] array2 = new sbyte[num3];
			for (int i = 0; i < num6; i++)
			{
				array2[i] = (sbyte)GClass634.smethod_7(255L);
			}
			int num7 = num6;
			for (int i = 0; i < num; i++)
			{
				sbyte b = (sbyte)((sbyte_0[i] != 1) ? ((sbyte)GClass634.smethod_7(255L)) : 0);
				for (int j = 0; j < num5; j++)
				{
					array2[num7 + j] = b;
				}
				num7 += num5;
			}
			num7 = num6 + num * num5;
			for (int i = num7; i < num3; i++)
			{
				array2[i] = (sbyte)GClass634.smethod_7(255L);
			}
			for (int j = 0; j < num4; j++)
			{
				Array.Copy(array2, 0, array[j], 0, num3);
			}
			return gClass;
		}

		protected internal static int smethod_1(sbyte[] sbyte_0, int int_0, int[] int_1, int int_2)
		{
			int num = 5;
			if (int_2 != 0 && int_2 != 1)
			{
				throw new ArgumentException("startColor must be either 0 or 1, but got: " + int_2);
			}
			sbyte b = (sbyte)int_2;
			int num2 = 0;
			for (int i = 0; i < int_1.Length; i++)
			{
				for (int j = 0; j < int_1[i]; j++)
				{
					sbyte_0[int_0] = b;
					int_0++;
					num2++;
				}
				b = (sbyte)(b ^ 1);
			}
			return num2;
		}

		public abstract sbyte[] vmethod_0(string string_0);
	}
}
