using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass580 : GInterface26
	{
		private string string_0;

		private static readonly char[] char_0;

		private static readonly char[] char_1;

		public GClass580()
		{
		}

		public GClass580(string string_1)
		{
			method_1(string_1);
		}

		static GClass580()
		{
			char[] invalidPathChars = Path.GetInvalidPathChars();
			int num = invalidPathChars.Length + 2;
			char_1 = new char[num];
			Array.Copy(invalidPathChars, 0, char_1, 0, invalidPathChars.Length);
			char_1[num - 1] = '*';
			char_1[num - 2] = '?';
			num = invalidPathChars.Length + 4;
			char_0 = new char[num];
			Array.Copy(invalidPathChars, 0, char_0, 0, invalidPathChars.Length);
			char_0[num - 1] = ':';
			char_0[num - 2] = '\\';
			char_0[num - 3] = '*';
			char_0[num - 4] = '?';
		}

		public string imethod_1(string string_1)
		{
			int num = 16;
			string_1 = imethod_0(string_1);
			if (string_1.Length > 0)
			{
				if (!string_1.EndsWith("/"))
				{
					string_1 += "/";
				}
				return string_1;
			}
			throw new GException24("Cannot have an empty directory name");
		}

		public string imethod_0(string string_1)
		{
			int num = 8;
			if (string_1 != null)
			{
				string text = string_1.ToLower();
				if (string_0 != null && text.IndexOf(string_0) == 0)
				{
					string_1 = string_1.Substring(string_0.Length);
				}
				string_1 = string_1.Replace("\\", "/");
				string_1 = GClass592.smethod_0(string_1);
				while (string_1.Length > 0 && string_1[0] == '/')
				{
					string_1 = string_1.Remove(0, 1);
				}
				while (string_1.Length > 0 && string_1[string_1.Length - 1] == '/')
				{
					string_1 = string_1.Remove(string_1.Length - 1, 1);
				}
				for (int num2 = string_1.IndexOf("//"); num2 >= 0; num2 = string_1.IndexOf("//"))
				{
					string_1 = string_1.Remove(num2, 1);
				}
				string_1 = smethod_0(string_1, '_');
			}
			else
			{
				string_1 = string.Empty;
			}
			return string_1;
		}

		public string method_0()
		{
			return string_0;
		}

		public void method_1(string string_1)
		{
			string_0 = string_1;
			if (string_0 != null)
			{
				string_0 = string_0.ToLower();
			}
		}

		private static string smethod_0(string string_1, char char_2)
		{
			int num = string_1.IndexOfAny(char_0);
			if (num >= 0)
			{
				StringBuilder stringBuilder = new StringBuilder(string_1);
				while (num >= 0)
				{
					stringBuilder[num] = char_2;
					num = ((num < string_1.Length) ? string_1.IndexOfAny(char_0, num + 1) : (-1));
				}
				string_1 = stringBuilder.ToString();
			}
			if (string_1.Length > 65535)
			{
				throw new PathTooLongException();
			}
			return string_1;
		}

		public static bool smethod_1(string string_1, bool bool_0)
		{
			bool result;
			if (result = (string_1 != null))
			{
				result = ((!bool_0) ? (string_1.IndexOfAny(char_0) < 0 && string_1.IndexOf('/') != 0) : (string_1.IndexOfAny(char_1) < 0));
			}
			return result;
		}

		public static bool smethod_2(string string_1)
		{
			return string_1 != null && string_1.IndexOfAny(char_0) < 0 && string_1.IndexOf('/') != 0;
		}
	}
}
