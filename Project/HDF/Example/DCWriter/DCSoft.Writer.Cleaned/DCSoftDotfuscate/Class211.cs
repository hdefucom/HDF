using System.Drawing;

namespace DCSoftDotfuscate
{
	internal class Class211
	{
		public static string string_0 = "DCSoft";

		public static string smethod_0(Font font_0, bool bool_0)
		{
			int num = 4;
			string text = Class206.smethod_4(font_0.Name);
			return bool_0 ? (string_0 + "+" + text) : text;
		}

		public static string smethod_1(Font font_0, bool bool_0)
		{
			int num = 12;
			string text = smethod_0(font_0, bool_0);
			string text2 = "";
			if (font_0.Bold)
			{
				text2 += "Bold";
			}
			if (font_0.Italic)
			{
				text2 += "Italic";
			}
			if (text2 != "")
			{
				text = text + "," + text2;
			}
			return text;
		}

		public static bool smethod_2(Font font_0, Font font_1)
		{
			if (font_0 == null || font_1 == null)
			{
				return false;
			}
			return smethod_1(font_0, bool_0: false) == smethod_1(font_1, bool_0: false);
		}
	}
}
