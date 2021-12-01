using System;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass361
	{
		private string string_0 = null;

		private int int_0 = -1;

		private int int_1 = 0;

		public GClass361(string string_1)
		{
			string_0 = string_1;
			int_1 = 0;
			if (string_1 != null)
			{
				int_0 = string_1.Length;
			}
		}

		public bool method_0()
		{
			return int_1 >= int_0;
		}

		public string method_1()
		{
			for (int i = int_1; i < string_0.Length; i++)
			{
				if (!char.IsWhiteSpace(string_0[i]))
				{
					if (i <= int_1)
					{
						break;
					}
					string result = string_0.Substring(int_1, i - int_1);
					int_1 = i;
					return result;
				}
			}
			return null;
		}

		public string method_2()
		{
			if (int_1 < string_0.Length)
			{
				string result = string_0.Substring(int_1);
				int_1 = string_0.Length;
				return result;
			}
			return null;
		}

		public string method_3(char char_0)
		{
			int num = 0;
			if (int_1 < int_0)
			{
				num = string_0.IndexOf(char_0, int_1);
				if (num == -1)
				{
					num = string_0.Length;
				}
				string result = string_0.Substring(int_1, num - int_1);
				int_1 = num + 1;
				return result;
			}
			return null;
		}

		public double method_4()
		{
			StringBuilder stringBuilder = new StringBuilder();
			while (int_1 < int_0)
			{
				char c = string_0[int_1];
				if (!char.IsNumber(c) && c != '.')
				{
					break;
				}
				stringBuilder.Append(c);
				int_1++;
			}
			if (stringBuilder.Length > 0)
			{
				return Convert.ToDouble(stringBuilder.ToString());
			}
			return double.NaN;
		}

		public char method_5()
		{
			if (int_1 < int_0)
			{
				return string_0[int_1];
			}
			return '\0';
		}

		public char method_6()
		{
			int_1++;
			if (int_1 < int_0)
			{
				return string_0[int_1];
			}
			return '\0';
		}

		public string method_7(string string_1)
		{
			StringBuilder stringBuilder = new StringBuilder();
			while (int_1 < int_0)
			{
				char value = string_0[int_1];
				if (string_1.IndexOf(value) < 0)
				{
					break;
				}
				stringBuilder.Append(value);
				int_1++;
			}
			return stringBuilder.ToString();
		}
	}
}
