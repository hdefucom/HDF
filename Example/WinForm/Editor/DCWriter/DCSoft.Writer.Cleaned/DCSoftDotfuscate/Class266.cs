using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	internal sealed class Class266
	{
		private Class266()
		{
		}

		public static GClass624 smethod_0(GClass645 gclass645_0)
		{
			int num = 12;
			string text = gclass645_0.method_0();
			if (text == null || (!text.StartsWith("urlto:") && !text.StartsWith("URLTO:")))
			{
				return null;
			}
			int num2 = text.IndexOf(':', 6);
			if (num2 < 0)
			{
				return null;
			}
			string string_ = (num2 <= 6) ? null : text.Substring(6, num2 - 6);
			string string_2 = text.Substring(num2 + 1);
			return new GClass624(string_2, string_);
		}
	}
}
