using System.Collections;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	internal sealed class Class246 : GClass608
	{
		public static GClass631 smethod_15(GClass645 gclass645_0)
		{
			int num = 14;
			string text = gclass645_0.method_0();
			if (text == null || text.IndexOf("MEMORY") < 0 || text.IndexOf("\r\n") < 0)
			{
				return null;
			}
			string string_ = GClass608.smethod_13("NAME1:", text, '\r', bool_0: true);
			string string_2 = GClass608.smethod_13("NAME2:", text, '\r', bool_0: true);
			string[] string_3 = smethod_16("TEL", 3, text, bool_0: true);
			string[] string_4 = smethod_16("MAIL", 3, text, bool_0: true);
			string string_5 = GClass608.smethod_13("MEMORY:", text, '\r', bool_0: false);
			string text2 = GClass608.smethod_13("ADD:", text, '\r', bool_0: true);
			string[] string_6 = (text2 == null) ? null : new string[1]
			{
				text2
			};
			return new GClass631(GClass608.smethod_3(string_), string_2, string_3, string_4, string_5, string_6, null, null, null, null);
		}

		private static string[] smethod_16(string string_0, int int_0, string string_1, bool bool_0)
		{
			ArrayList arrayList = null;
			for (int i = 1; i <= int_0; i++)
			{
				string text = GClass608.smethod_13(string_0 + i + ':', string_1, '\r', bool_0);
				if (text == null)
				{
					break;
				}
				if (arrayList == null)
				{
					arrayList = ArrayList.Synchronized(new ArrayList(int_0));
				}
				arrayList.Add(text);
			}
			if (arrayList == null)
			{
				return null;
			}
			return GClass608.smethod_14(arrayList);
		}
	}
}
