using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	internal sealed class Class237 : Class235
	{
		public static GClass631 smethod_17(GClass645 gclass645_0)
		{
			int num = 4;
			string text = gclass645_0.method_0();
			if (!(text?.StartsWith("MECARD:") ?? false))
			{
				return null;
			}
			string[] array = Class235.smethod_15("N:", text, bool_0: true);
			if (array == null)
			{
				return null;
			}
			string string_ = smethod_18(array[0]);
			string string_2 = Class235.smethod_16("SOUND:", text, bool_0: true);
			string[] string_3 = Class235.smethod_15("TEL:", text, bool_0: true);
			string[] string_4 = Class235.smethod_15("EMAIL:", text, bool_0: true);
			string string_5 = Class235.smethod_16("NOTE:", text, bool_0: false);
			string[] string_6 = Class235.smethod_15("ADR:", text, bool_0: true);
			string text2 = Class235.smethod_16("BDAY:", text, bool_0: true);
			if (text2 != null && !GClass608.smethod_8(text2, 8))
			{
				text2 = null;
			}
			string string_7 = Class235.smethod_16("URL:", text, bool_0: true);
			string string_8 = Class235.smethod_16("ORG:", text, bool_0: true);
			return new GClass631(GClass608.smethod_3(string_), string_2, string_3, string_4, string_5, string_6, string_8, text2, null, string_7);
		}

		private static string smethod_18(string string_0)
		{
			int num = string_0.IndexOf(',');
			if (num >= 0)
			{
				return string_0.Substring(num + 1) + ' ' + string_0.Substring(0, num);
			}
			return string_0;
		}
	}
}
