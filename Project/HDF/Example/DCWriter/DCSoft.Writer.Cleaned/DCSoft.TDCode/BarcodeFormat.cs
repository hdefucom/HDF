using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace DCSoft.TDCode
{
	/// <summary> Enumerates barcode formats known to this package.
	///
	///       </summary>
	/// <author>  Sean Owen
	///       </author>
	/// <author>www.Redivivus.in (suraj.supekar@redivivus.in) - Ported from ZXING Java Source 
	///       </author>
	[ComVisible(false)]
	public sealed class BarcodeFormat
	{
		private static readonly Hashtable hashtable_0 = Hashtable.Synchronized(new Hashtable());

		public static readonly BarcodeFormat barcodeFormat_0 = new BarcodeFormat("QR_CODE");

		public static readonly BarcodeFormat barcodeFormat_1 = new BarcodeFormat("DATAMATRIX");

		public static readonly BarcodeFormat barcodeFormat_2 = new BarcodeFormat("UPC_E");

		public static readonly BarcodeFormat barcodeFormat_3 = new BarcodeFormat("UPC_A");

		public static readonly BarcodeFormat barcodeFormat_4 = new BarcodeFormat("EAN_8");

		public static readonly BarcodeFormat barcodeFormat_5 = new BarcodeFormat("EAN_13");

		public static readonly BarcodeFormat barcodeFormat_6 = new BarcodeFormat("CODE_128");

		public static readonly BarcodeFormat barcodeFormat_7 = new BarcodeFormat("CODE_39");

		public static readonly BarcodeFormat barcodeFormat_8 = new BarcodeFormat("ITF");

		public static readonly BarcodeFormat barcodeFormat_9 = new BarcodeFormat("PDF417");

		private string string_0;

		public string Name => string_0;

		private BarcodeFormat(string string_1)
		{
			string_0 = string_1;
			hashtable_0[string_1] = this;
		}

		public override string ToString()
		{
			return string_0;
		}

		public static BarcodeFormat smethod_0(string string_1)
		{
			BarcodeFormat barcodeFormat = (BarcodeFormat)hashtable_0[string_1];
			if (barcodeFormat == null)
			{
				throw new ArgumentException();
			}
			return barcodeFormat;
		}
	}
}
