using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	internal sealed class Class242 : GClass608
	{
		private Class242()
		{
		}

		public static GClass621 smethod_15(GClass645 gclass645_0)
		{
			int num = 16;
			string text = gclass645_0.method_0();
			if (text == null || (!text.StartsWith("tel:") && !text.StartsWith("TEL:")))
			{
				return null;
			}
			string string_ = text.StartsWith("TEL:") ? ("tel:" + text.Substring(4)) : text;
			int num2 = text.IndexOf('?', 4);
			string string_2 = (num2 < 0) ? text.Substring(4) : text.Substring(4, num2 - 4);
			return new GClass621(string_2, string_, null);
		}
	}
}
