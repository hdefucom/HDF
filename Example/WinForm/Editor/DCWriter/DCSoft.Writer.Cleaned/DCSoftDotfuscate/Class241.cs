using DCSoft.TDCode;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	internal sealed class Class241 : GClass608
	{
		private Class241()
		{
		}

		public static GClass630 smethod_15(GClass645 gclass645_0)
		{
			BarcodeFormat obj = gclass645_0.method_3();
			if (!BarcodeFormat.barcodeFormat_3.Equals(obj) && !BarcodeFormat.barcodeFormat_2.Equals(obj) && !BarcodeFormat.barcodeFormat_4.Equals(obj) && !BarcodeFormat.barcodeFormat_5.Equals(obj))
			{
				return null;
			}
			string text = gclass645_0.method_0();
			if (text == null)
			{
				return null;
			}
			int length = text.Length;
			int num = 0;
			while (true)
			{
				if (num < length)
				{
					char c = text[num];
					if (c < '0' || c > '9')
					{
						break;
					}
					num++;
					continue;
				}
				string string_ = (!BarcodeFormat.barcodeFormat_2.Equals(obj)) ? text : GClass601.smethod_7(text);
				return new GClass630(text, string_);
			}
			return null;
		}
	}
}
