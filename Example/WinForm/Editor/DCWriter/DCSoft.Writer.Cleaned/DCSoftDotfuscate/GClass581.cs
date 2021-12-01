using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass581 : GInterface24
	{
		private string string_0;

		private ArrayList arrayList_0;

		private ArrayList arrayList_1;

		public GClass581(string string_1)
		{
			string_0 = string_1;
			arrayList_0 = new ArrayList();
			arrayList_1 = new ArrayList();
			method_2();
		}

		public static bool smethod_0(string string_1)
		{
			bool result = true;
			try
			{
				new Regex(string_1, RegexOptions.IgnoreCase | RegexOptions.Singleline);
				return result;
			}
			catch (ArgumentException)
			{
				return false;
			}
		}

		public static bool smethod_1(string string_1)
		{
			int num = 16;
			if (string_1 == null)
			{
				throw new ArgumentNullException("toTest");
			}
			bool result = true;
			try
			{
				string[] array = smethod_2(string_1);
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i] != null && array[i].Length > 0)
					{
						string pattern = (array[i][0] == '+') ? array[i].Substring(1, array[i].Length - 1) : ((array[i][0] != '-') ? array[i] : array[i].Substring(1, array[i].Length - 1));
						new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);
					}
				}
				return result;
			}
			catch (ArgumentException)
			{
				return false;
			}
		}

		public static string[] smethod_2(string string_1)
		{
			int num = 7;
			char c = '\\';
			char[] array = new char[1]
			{
				';'
			};
			ArrayList arrayList = new ArrayList();
			if (string_1 != null && string_1.Length > 0)
			{
				int num2 = -1;
				StringBuilder stringBuilder = new StringBuilder();
				while (num2 < string_1.Length)
				{
					num2++;
					if (num2 >= string_1.Length)
					{
						arrayList.Add(stringBuilder.ToString());
					}
					else if (string_1[num2] == c)
					{
						num2++;
						if (num2 >= string_1.Length)
						{
							throw new ArgumentException("Missing terminating escape character", "original");
						}
						if (Array.IndexOf(array, string_1[num2]) < 0)
						{
							stringBuilder.Append(c);
						}
						stringBuilder.Append(string_1[num2]);
					}
					else if (Array.IndexOf(array, string_1[num2]) >= 0)
					{
						arrayList.Add(stringBuilder.ToString());
						stringBuilder.Length = 0;
					}
					else
					{
						stringBuilder.Append(string_1[num2]);
					}
				}
			}
			return (string[])arrayList.ToArray(typeof(string));
		}

		public override string ToString()
		{
			return string_0;
		}

		public bool method_0(string string_1)
		{
			bool result = false;
			if (arrayList_0.Count == 0)
			{
				return true;
			}
			foreach (Regex item in arrayList_0)
			{
				if (item.IsMatch(string_1))
				{
					return true;
				}
			}
			return result;
		}

		public bool method_1(string string_1)
		{
			bool result = false;
			foreach (Regex item in arrayList_1)
			{
				if (item.IsMatch(string_1))
				{
					return true;
				}
			}
			return result;
		}

		public bool imethod_0(string string_1)
		{
			return method_0(string_1) && !method_1(string_1);
		}

		private void method_2()
		{
			if (string_0 == null)
			{
				return;
			}
			string[] array = smethod_2(string_0);
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] != null && array[i].Length > 0)
				{
					bool flag = array[i][0] != '-';
					string pattern = (array[i][0] == '+') ? array[i].Substring(1, array[i].Length - 1) : ((array[i][0] != '-') ? array[i] : array[i].Substring(1, array[i].Length - 1));
					if (flag)
					{
						arrayList_0.Add(new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Singleline));
					}
					else
					{
						arrayList_1.Add(new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Singleline));
					}
				}
			}
		}
	}
}
