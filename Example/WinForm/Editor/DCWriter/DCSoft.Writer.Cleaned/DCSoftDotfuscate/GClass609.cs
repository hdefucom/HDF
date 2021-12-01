using DCSoft.TDCode;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass609 : GClass608
	{
		private GClass609()
		{
		}

		public static GClass625 smethod_15(GClass645 gclass645_0)
		{
			int num = 11;
			BarcodeFormat obj = gclass645_0.method_3();
			if (!BarcodeFormat.barcodeFormat_5.Equals(obj))
			{
				return null;
			}
			string text = gclass645_0.method_0();
			if (text == null)
			{
				return null;
			}
			int length = text.Length;
			if (length != 13)
			{
				return null;
			}
			if (!text.StartsWith("978") && !text.StartsWith("979"))
			{
				return null;
			}
			return new GClass625(text);
		}
	}
}
