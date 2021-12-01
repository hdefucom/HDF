using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DCSoftDotfuscate
{
	internal class Class172
	{
		public static string smethod_0(string string_0)
		{
			int num = 2;
			if (string.IsNullOrEmpty(string_0))
			{
				return string_0;
			}
			StringBuilder stringBuilder = new StringBuilder();
			bool flag = false;
			foreach (char c in string_0)
			{
				if (char.IsWhiteSpace(c))
				{
					if (!flag)
					{
						stringBuilder.Append(" ");
					}
					flag = true;
				}
				else
				{
					flag = false;
					stringBuilder.Append(c);
				}
			}
			return stringBuilder.ToString();
		}

		public static string smethod_1(string string_0)
		{
			int num = 12;
			if (string_0 == null || string_0.Trim().Length == 0)
			{
				return string_0;
			}
			Uri uri = new Uri(string_0);
			string value = "";
			int num2 = 0;
			if (uri.Scheme == Uri.UriSchemeFile)
			{
				num2 = string_0.IndexOfAny("/\\".ToCharArray());
				if (num2 > 0)
				{
					value = string_0.Substring(0, num2 + 1);
					string_0 = string_0.Substring(num2 + 1);
				}
			}
			else
			{
				num2 = string_0.IndexOf("://");
				value = string_0.Substring(0, num2 + 3);
				string_0 = string_0.Substring(num2 + 3);
			}
			string value2 = "";
			num2 = string_0.LastIndexOfAny("/\\".ToCharArray());
			if (num2 > 0)
			{
				value2 = string_0.Substring(num2 + 1);
				string_0 = string_0.Substring(0, num2);
			}
			List<string> list = new List<string>();
			string[] array = string_0.Split('/', '\\');
			foreach (string text in array)
			{
				list.Add(text.Trim());
			}
			for (int j = 1; j < list.Count; j++)
			{
				if (list[j] == "..")
				{
					list.RemoveAt(j);
					list.RemoveAt(j - 1);
					j -= 2;
				}
				else if (list[j] == ".")
				{
					list.RemoveAt(j);
					j--;
				}
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(value);
			char value3 = (uri.Scheme == Uri.UriSchemeFile) ? Path.DirectorySeparatorChar : '/';
			for (int j = 0; j < list.Count; j++)
			{
				stringBuilder.Append(list[j]);
				stringBuilder.Append(value3);
			}
			stringBuilder.Append(value2);
			return stringBuilder.ToString();
		}
	}
}
