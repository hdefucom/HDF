using System;
using System.Globalization;

namespace DCSoftDotfuscate
{
	internal class Class206
	{
		private static string smethod_0(char char_0)
		{
			int num = 0;
			switch (char_0)
			{
			case '(':
				return "\\(";
			case ')':
				return "\\)";
			case '\\':
				return "\\\\";
			case '\r':
				return "\\r";
			case '\n':
				return "\\n";
			case '\t':
				return "\\t";
			case '\b':
				return "\\b";
			case '\u0012':
				return "\\f";
			default:
				return Convert.ToString(char_0);
			}
		}

		public static string smethod_1(string string_0)
		{
			string text = "";
			for (int i = 0; i < string_0.Length; i++)
			{
				text += smethod_0(string_0[i]);
			}
			return text;
		}

		public static string smethod_2(char char_0)
		{
			byte[] bytes = BitConverter.GetBytes(char_0);
			return bytes[0].ToString("X2", CultureInfo.CurrentCulture);
		}

		public static string smethod_3(char char_0)
		{
			byte[] bytes = BitConverter.GetBytes(char_0);
			string str = bytes[1].ToString("X2", CultureInfo.CurrentCulture);
			return str + bytes[0].ToString("X2", CultureInfo.CurrentCulture);
		}

		public static string smethod_4(string string_0)
		{
			string text = "";
			for (int i = 0; i < string_0.Length; i++)
			{
				if (string_0[i] != ' ' && string_0[i] != '\r' && string_0[i] != '\n')
				{
					text += string_0[i];
				}
			}
			return text;
		}
	}
}
