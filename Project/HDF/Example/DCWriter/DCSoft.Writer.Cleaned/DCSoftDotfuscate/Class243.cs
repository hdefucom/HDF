using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	internal sealed class Class243 : GClass608
	{
		private Class243()
		{
		}

		public static GClass627 smethod_15(GClass645 gclass645_0)
		{
			int num = 6;
			string text = gclass645_0.method_0();
			if (text == null)
			{
				return null;
			}
			int num2 = text.IndexOf("BEGIN:VEVENT");
			if (num2 < 0)
			{
				return null;
			}
			int num3 = text.IndexOf("END:VEVENT");
			if (num3 < 0)
			{
				return null;
			}
			string string_ = Class248.smethod_17("SUMMARY", text, bool_0: true);
			string string_2 = Class248.smethod_17("DTSTART", text, bool_0: true);
			string string_3 = Class248.smethod_17("DTEND", text, bool_0: true);
			try
			{
				return new GClass627(string_, string_2, string_3, null, null, null);
			}
			catch (ArgumentException)
			{
				return null;
			}
		}
	}
}
