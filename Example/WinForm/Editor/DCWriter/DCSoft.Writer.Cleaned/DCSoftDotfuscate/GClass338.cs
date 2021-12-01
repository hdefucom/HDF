using System;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass338
	{
		private StringBuilder stringBuilder_0;

		private char char_0;

		private char char_1;

		public GClass338()
		{
			stringBuilder_0 = new StringBuilder();
			char_0 = ':';
			char_1 = ';';
			
		}

		public GClass338(char char_2, char char_3)
		{
			int num = 8;
			stringBuilder_0 = new StringBuilder();
			char_0 = ':';
			char_1 = ';';
			
			if (char_2 == '\0')
			{
				throw new ArgumentNullException("valueSpliter");
			}
			if (char_3 == '\0')
			{
				throw new ArgumentNullException("itemSpliter");
			}
			char_0 = char_2;
			char_1 = char_3;
		}

		public char method_0()
		{
			return char_0;
		}

		public char method_1()
		{
			return char_1;
		}

		public void method_2(string string_0, string string_1)
		{
			int num = 19;
			if (stringBuilder_0.Length > 0)
			{
				stringBuilder_0.Append(char_1);
			}
			stringBuilder_0.Append(string_0);
			stringBuilder_0.Append(char_0);
			if (string.IsNullOrEmpty(string_1))
			{
				return;
			}
			int num2 = 0;
			while (true)
			{
				if (num2 < string_1.Length)
				{
					char c = string_1[num2];
					if (c == '\'' || c == char_1 || c == char_0)
					{
						break;
					}
					num2++;
					continue;
				}
				stringBuilder_0.Append(string_1);
				return;
			}
			stringBuilder_0.Append("\"" + string_1 + "\"");
		}

		public override string ToString()
		{
			return stringBuilder_0.ToString();
		}
	}
}
