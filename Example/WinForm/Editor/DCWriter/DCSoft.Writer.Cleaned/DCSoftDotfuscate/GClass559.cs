using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass559 : GInterface26
	{
		private const int int_0 = 260;

		private string string_0;

		private bool bool_0;

		private char char_0;

		private static readonly char[] char_1;

		public GClass559(string string_1)
		{
			int num = 1;
			char_0 = '_';
			
			if (string_1 == null)
			{
				throw new ArgumentNullException("baseDirectory", "Directory name is invalid");
			}
			method_1(string_1);
		}

		public GClass559()
		{
			char_0 = '_';
			
		}

		public string method_0()
		{
			return string_0;
		}

		public void method_1(string string_1)
		{
			int num = 1;
			if (string_1 == null)
			{
				throw new ArgumentNullException("value");
			}
			string_0 = Path.GetFullPath(string_1);
		}

		public bool method_2()
		{
			return bool_0;
		}

		public void method_3(bool bool_1)
		{
			bool_0 = bool_1;
		}

		public string imethod_1(string string_1)
		{
			int num = 12;
			string_1 = imethod_0(string_1);
			if (string_1.Length > 0)
			{
				while (string_1.EndsWith("\\"))
				{
					string_1 = string_1.Remove(string_1.Length - 1, 1);
				}
				return string_1;
			}
			throw new GException24("Cannot have an empty directory name");
		}

		public string imethod_0(string string_1)
		{
			if (string_1 != null)
			{
				string_1 = smethod_1(string_1, char_0);
				if (bool_0)
				{
					string_1 = Path.GetFileName(string_1);
				}
				if (string_0 != null)
				{
					string_1 = Path.Combine(string_0, string_1);
				}
			}
			else
			{
				string_1 = string.Empty;
			}
			return string_1;
		}

		public static bool smethod_0(string string_1)
		{
			return string_1 != null && string_1.Length <= 260 && string.Compare(string_1, smethod_1(string_1, '_')) == 0;
		}

		static GClass559()
		{
			char[] invalidPathChars = Path.GetInvalidPathChars();
			int num = invalidPathChars.Length + 3;
			char_1 = new char[num];
			Array.Copy(invalidPathChars, 0, char_1, 0, invalidPathChars.Length);
			char_1[num - 1] = '*';
			char_1[num - 2] = '?';
			char_1[num - 3] = ':';
		}

		public static string smethod_1(string string_1, char char_2)
		{
			int num = 6;
			if (string_1 == null)
			{
				throw new ArgumentNullException("name");
			}
			string_1 = GClass592.smethod_0(string_1.Replace("/", "\\"));
			while (string_1.Length > 0 && string_1[0] == '\\')
			{
				string_1 = string_1.Remove(0, 1);
			}
			while (string_1.Length > 0 && string_1[string_1.Length - 1] == '\\')
			{
				string_1 = string_1.Remove(string_1.Length - 1, 1);
			}
			int num2;
			for (num2 = string_1.IndexOf("\\\\"); num2 >= 0; num2 = string_1.IndexOf("\\\\"))
			{
				string_1 = string_1.Remove(num2, 1);
			}
			num2 = string_1.IndexOfAny(char_1);
			if (num2 >= 0)
			{
				StringBuilder stringBuilder = new StringBuilder(string_1);
				while (num2 >= 0)
				{
					stringBuilder[num2] = char_2;
					num2 = ((num2 < string_1.Length) ? string_1.IndexOfAny(char_1, num2 + 1) : (-1));
				}
				string_1 = stringBuilder.ToString();
			}
			if (string_1.Length > 260)
			{
				throw new PathTooLongException();
			}
			return string_1;
		}

		public char method_4()
		{
			return char_0;
		}

		public void method_5(char char_2)
		{
			int num = 4;
			int num2 = 0;
			while (true)
			{
				if (num2 < char_1.Length)
				{
					if (char_1[num2] != char_2)
					{
						num2++;
						continue;
					}
					throw new ArgumentException("invalid path character");
				}
				if (char_2 != '\\' && char_2 != '/')
				{
					break;
				}
				throw new ArgumentException("invalid replacement character");
			}
			char_0 = char_2;
		}
	}
}
