using System.Collections;
using System.Collections.Specialized;
using System.Reflection;
using System.Text;

namespace DCSoftDotfuscate
{
	[DefaultMember("Item")]
	internal class Class171
	{
		private bool bool_0 = true;

		private string string_0;

		private string string_1;

		private int int_0;

		private int int_1;

		public static NameValueCollection smethod_0(string string_2)
		{
			if (string_2 == null || string_2.Length == 0)
			{
				return null;
			}
			string[] array = string_2.Split(';');
			NameValueCollection nameValueCollection = new NameValueCollection();
			string[] array2 = array;
			foreach (string text in array2)
			{
				int num = text.IndexOf('=');
				string text2 = null;
				string text3 = null;
				if (num > 0)
				{
					text2 = text.Substring(0, num);
					text3 = text.Substring(num + 1);
				}
				else
				{
					text2 = text;
					text3 = "";
				}
				text2 = text2.Trim();
				text3 = (nameValueCollection[text2] = text3.Trim());
			}
			return nameValueCollection;
		}

		public static string[] smethod_1(string string_2, string string_3, string string_4)
		{
			if (string_2 == null || string_3 == null || string_4 == null || string_3.Length == 0 || string_4.Length == 0 || string_2.Length == 0)
			{
				return new string[1]
				{
					string_2
				};
			}
			int num = string_2.IndexOf(string_3);
			if (num < 0)
			{
				return new string[1]
				{
					string_2
				};
			}
			ArrayList arrayList = new ArrayList();
			int num2 = 0;
			do
			{
				int num3 = string_2.IndexOf(string_4, num + 1);
				if (num3 <= num)
				{
					break;
				}
				int num4 = num;
				do
				{
					num = num4;
					num4 = string_2.IndexOf(string_3, num4 + 1);
				}
				while (num4 > num && num4 < num3);
				string value = string_2.Substring(num + string_3.Length, num3 - num - string_3.Length);
				if (num2 < num)
				{
					arrayList.Add(string_2.Substring(num2, num - num2));
				}
				else
				{
					arrayList.Add(null);
				}
				arrayList.Add(value);
				num = num3 + string_4.Length;
				num2 = num;
			}
			while (num >= 0 && num < string_2.Length);
			if (num2 < string_2.Length)
			{
				arrayList.Add(string_2.Substring(num2));
			}
			return (string[])arrayList.ToArray(typeof(string));
		}

		public static string smethod_2(string string_2)
		{
			char[] array = new char[string_2.Length];
			int num = 0;
			bool flag = false;
			for (int i = 0; i < string_2.Length; i++)
			{
				if (char.IsWhiteSpace(string_2[i]))
				{
					if (!flag)
					{
						flag = true;
						array[num] = ' ';
						num++;
					}
				}
				else
				{
					flag = false;
					array[num] = string_2[i];
					num++;
				}
			}
			if (num == 0)
			{
				return "";
			}
			return new string(array, 0, num);
		}

		public static bool smethod_3(string string_2)
		{
			if (string_2 != null && string_2.Length > 0)
			{
				foreach (char c in string_2)
				{
					if (!char.IsWhiteSpace(c))
					{
						return true;
					}
				}
			}
			return false;
		}

		public static bool smethod_4(string string_2)
		{
			if (string_2 == null)
			{
				return true;
			}
			int num = 0;
			while (true)
			{
				if (num < string_2.Length)
				{
					if (!char.IsWhiteSpace(string_2[num]))
					{
						break;
					}
					num++;
					continue;
				}
				return true;
			}
			return false;
		}

		public bool method_0()
		{
			return bool_0;
		}

		public void method_1(bool bool_1)
		{
			bool_0 = bool_1;
		}

		internal Class171(string string_2)
		{
			if (string_2 == null)
			{
				string_2 = "";
			}
			string_0 = string_2;
			int_0 = 0;
			int_1 = string_0.Length;
			string_1 = string_0.ToLower();
		}

		public int method_2()
		{
			return int_0;
		}

		public void method_3(int int_2)
		{
			int_0 = int_2;
		}

		public int method_4()
		{
			return int_1;
		}

		public bool method_5()
		{
			return int_0 >= int_1;
		}

		public char method_6()
		{
			int_0++;
			return string_0[int_0 - 1];
		}

		public char method_7()
		{
			return string_0[int_0];
		}

		public bool method_8(string string_2)
		{
			if (int_0 + string_2.Length < int_1)
			{
				string text = string_1.Substring(int_0, string_2.Length);
				return text.Equals(string_2);
			}
			return false;
		}

		public char method_9()
		{
			if (int_0 > 0)
			{
				return string_0[int_0 - 1];
			}
			return '\0';
		}

		public char method_10()
		{
			if (int_0 < int_1 - 1)
			{
				return string_0[int_0 + 1];
			}
			return '\0';
		}

		public char method_11()
		{
			if (int_0 < int_1 - 2)
			{
				return string_0[int_0 + 2];
			}
			return '\0';
		}

		public string method_12(int int_2)
		{
			if (int_2 + int_0 >= int_1)
			{
				int_2 = int_1 - int_0;
			}
			if (int_2 > 0)
			{
				return string_0.Substring(int_0, int_2);
			}
			return null;
		}

		public string method_13(int int_2)
		{
			if (int_2 > int_0)
			{
				int_2 = int_0;
			}
			if (int_2 > 0)
			{
				return string_0.Substring(int_0 - int_2, int_2);
			}
			return null;
		}

		public string method_14(int int_2)
		{
			if (int_2 > string_0.Length - int_0)
			{
				int_2 = string_0.Length - int_0;
			}
			string result = string_0.Substring(int_0, int_2);
			int_0 += int_2;
			return result;
		}

		public string method_15(int int_2)
		{
			if (method_5())
			{
				return null;
			}
			if (int_2 > int_1)
			{
				int_2 = int_1;
			}
			if (int_2 < int_0)
			{
				int_2 = int_0;
			}
			if (int_2 == int_0)
			{
				return null;
			}
			string result = string_0.Substring(int_0, int_2 - int_0);
			int_0 = int_2;
			return result;
		}

		public char method_16(int int_2)
		{
			return string_0[int_2];
		}

		public void method_17()
		{
			int_0++;
		}

		public void method_18()
		{
			int_0--;
		}

		public void method_19(int int_2)
		{
			int_0 += int_2;
		}

		public void method_20(char char_0)
		{
			while (int_0 >= 0 && string_0[int_0] != char_0)
			{
				int_0--;
			}
		}

		public void method_21(char char_0)
		{
			while (int_0 < int_1 && string_0[int_0] != char_0)
			{
				int_0++;
			}
		}

		public void method_22(string string_2)
		{
			while (int_0 < int_1 && string_2.IndexOf(string_0[int_0]) < 0)
			{
				int_0++;
			}
		}

		public void method_23(char char_0)
		{
			while (true)
			{
				if (int_0 < int_1)
				{
					if (string_0[int_0] == char_0)
					{
						break;
					}
					int_0++;
					continue;
				}
				return;
			}
			int_0++;
		}

		public void method_24(string string_2)
		{
			while (true)
			{
				if (int_0 < int_1)
				{
					if (string_2.IndexOf(string_0[int_0]) >= 0)
					{
						break;
					}
					int_0++;
					continue;
				}
				return;
			}
			int_0++;
		}

		public void method_25()
		{
			while (int_0 < int_1 && char.IsWhiteSpace(string_0[int_0]))
			{
				int_0++;
			}
		}

		public char method_26(string string_2)
		{
			bool flag = false;
			for (int i = int_0; i < int_1; i++)
			{
				if (string_2.IndexOf(string_0[i]) >= 0)
				{
					flag = true;
					continue;
				}
				int_0 = i;
				break;
			}
			if (flag)
			{
				return string_0[int_0 - 1];
			}
			return string_0[int_0];
		}

		public string method_27()
		{
			return method_28("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789:_.-");
		}

		public string method_28(string string_2)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = int_0; i < int_1 && string_2.IndexOf(string_0[i]) >= 0; i++)
			{
				stringBuilder.Append(string_0[i]);
			}
			if (stringBuilder.Length == 0)
			{
				return null;
			}
			return stringBuilder.ToString();
		}

		public string method_29()
		{
			return method_30("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789:_.-");
		}

		public string method_30(string string_2)
		{
			if (method_5())
			{
				return null;
			}
			int i = int_0;
			string result = null;
			for (; i < int_1; i++)
			{
				if (string_2.IndexOf(string_0[i]) < 0 && i > int_0)
				{
					result = string_0.Substring(int_0, i - int_0);
					int_0 = i;
					break;
				}
			}
			if (i == int_1)
			{
				result = string_0.Substring(int_0);
				int_0 = string_0.Length;
			}
			return result;
		}

		public string method_31()
		{
			int num = 0;
			int num2 = 0;
			string text = null;
			int num3 = int_0;
			char c;
			while (true)
			{
				if (num3 < int_1)
				{
					c = string_0[num3];
					if (!char.IsWhiteSpace(c))
					{
						break;
					}
					num3++;
					continue;
				}
				int_0 = int_1;
				return null;
			}
			num = num3;
			if (c == '>')
			{
				text = string_0.Substring(num + 1, num3 - num);
				int_0 = num3;
			}
			else if (c == '\'' || c == '"')
			{
				num2 = string_0.IndexOf(c, num + 1);
				if (num2 < 0)
				{
					num2 = int_1;
				}
				text = string_0.Substring(num + 1, num2 - num - 1);
				int_0 = num2 + 1;
			}
			else
			{
				for (int i = num3 + 1; i < int_1; i++)
				{
					if (char.IsWhiteSpace(string_0[i]) || string_0[i] == '>')
					{
						num2 = i;
						break;
					}
				}
				if (num2 == 0)
				{
					num2 = string_0.Length - 1;
				}
				text = string_0.Substring(num, num2 - num);
				int_0 = num2;
			}
			return text;
		}

		public string method_32(string string_2)
		{
			string result = method_33("</" + string_2);
			method_23('>');
			return result;
		}

		public string method_33(string string_2)
		{
			string_2 = string_2.ToLower();
			int num = string_1.IndexOf(string_2, int_0);
			return method_15((num >= 0) ? num : int_1);
		}

		public string method_34()
		{
			if (method_5())
			{
				return null;
			}
			StringBuilder stringBuilder = new StringBuilder();
			while (int_0 < int_1)
			{
				char c = string_0[int_0];
				if (c == '<')
				{
					char c2 = method_10();
					if (c2 == '\0')
					{
						stringBuilder.Append(c);
						int_0++;
						break;
					}
					if ((c2 != '>' && c2 != '<' && !char.IsWhiteSpace(c2)) || c2 == '!')
					{
						break;
					}
				}
				stringBuilder.Append(c);
				int_0++;
			}
			return stringBuilder.ToString();
		}
	}
}
