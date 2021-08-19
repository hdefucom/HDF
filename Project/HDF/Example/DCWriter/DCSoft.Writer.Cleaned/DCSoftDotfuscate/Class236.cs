using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	internal sealed class Class236 : Class235
	{
		private Class236()
		{
		}

		public static GClass624 smethod_17(GClass645 gclass645_0)
		{
			int num = 10;
			string text = gclass645_0.method_0();
			if (!(text?.StartsWith("MEBKM:") ?? false))
			{
				return null;
			}
			string string_ = Class235.smethod_16("TITLE:", text, bool_0: true);
			string[] array = Class235.smethod_15("URL:", text, bool_0: true);
			if (array == null)
			{
				return null;
			}
			string text2 = array[0];
			if (!Class245.smethod_16(text2))
			{
				return null;
			}
			return new GClass624(text2, string_);
		}
	}
}
