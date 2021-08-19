using DCSoft.TDCode;
using System;
using System.Collections;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass683 : GInterface52
	{
		public GClass658 imethod_0(string string_0, BarcodeFormat barcodeFormat_0, int int_0, int int_1)
		{
			return imethod_1(string_0, barcodeFormat_0, int_0, int_1, null);
		}

		public GClass658 imethod_1(string string_0, BarcodeFormat barcodeFormat_0, int int_0, int int_1, Hashtable hashtable_0)
		{
			int num = 18;
			if (barcodeFormat_0 == BarcodeFormat.barcodeFormat_4)
			{
				return new GClass668().imethod_1(string_0, barcodeFormat_0, int_0, int_1, hashtable_0);
			}
			if (barcodeFormat_0 == BarcodeFormat.barcodeFormat_5)
			{
				return new GClass669().imethod_1(string_0, barcodeFormat_0, int_0, int_1, hashtable_0);
			}
			if (barcodeFormat_0 == BarcodeFormat.barcodeFormat_0)
			{
				return new GClass610().imethod_1(string_0, barcodeFormat_0, int_0, int_1, hashtable_0);
			}
			throw new ArgumentException("No encoder available for format " + barcodeFormat_0);
		}

		public Size method_0(string string_0, BarcodeFormat barcodeFormat_0, int int_0, int int_1)
		{
			return method_1(string_0, barcodeFormat_0, int_0, int_1, null);
		}

		public Size method_1(string string_0, BarcodeFormat barcodeFormat_0, int int_0, int int_1, Hashtable hashtable_0)
		{
			int num = 1;
			Size result = new Size(0, 0);
			if (barcodeFormat_0 == BarcodeFormat.barcodeFormat_4)
			{
				return result;
			}
			if (barcodeFormat_0 == BarcodeFormat.barcodeFormat_5)
			{
				return result;
			}
			if (barcodeFormat_0 == BarcodeFormat.barcodeFormat_0)
			{
				return new GClass610().method_0(string_0, barcodeFormat_0, int_0, int_1, hashtable_0);
			}
			throw new ArgumentException("No encoder available for format " + barcodeFormat_0);
		}
	}
}
