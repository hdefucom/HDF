using System.Collections;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	internal sealed class Class244 : GClass608
	{
		public static GClass622 smethod_15(GClass645 gclass645_0)
		{
			int num = 17;
			string text = gclass645_0.method_0();
			if (text == null)
			{
				return null;
			}
			string text2;
			if (text.StartsWith("mailto:") || text.StartsWith("MAILTO:"))
			{
				text2 = text.Substring(7);
				int num2 = text2.IndexOf('?');
				if (num2 >= 0)
				{
					text2 = text2.Substring(0, num2);
				}
				Hashtable hashtable = GClass608.smethod_10(text);
				string string_ = null;
				string string_2 = null;
				if (hashtable != null)
				{
					if (text2.Length == 0)
					{
						text2 = (string)hashtable["to"];
					}
					string_ = (string)hashtable["subject"];
					string_2 = (string)hashtable["body"];
				}
				return new GClass622(text2, string_, string_2, text);
			}
			if (!Class238.smethod_18(text))
			{
				return null;
			}
			text2 = text;
			return new GClass622(text2, null, null, "mailto:" + text2);
		}
	}
}
