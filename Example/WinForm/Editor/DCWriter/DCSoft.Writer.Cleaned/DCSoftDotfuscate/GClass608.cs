using System.Collections;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public abstract class GClass608
	{
		public static GClass620 smethod_0(GClass645 gclass645_0)
		{
			return (GClass620)(Class236.smethod_17(gclass645_0) ?? Class237.smethod_17(gclass645_0) ?? Class238.smethod_17(gclass645_0) ?? Class246.smethod_15(gclass645_0) ?? Class248.smethod_15(gclass645_0) ?? Class239.smethod_17(gclass645_0) ?? Class243.smethod_15(gclass645_0) ?? Class244.smethod_15(gclass645_0) ?? Class242.smethod_15(gclass645_0) ?? Class240.smethod_15(gclass645_0) ?? Class247.smethod_15(gclass645_0) ?? Class266.smethod_0(gclass645_0) ?? Class245.smethod_15(gclass645_0) ?? GClass609.smethod_15(gclass645_0) ?? ((object)Class241.smethod_15(gclass645_0)) ?? ((object)new GClass628(gclass645_0.method_0(), null)));
		}

		protected internal static void smethod_1(string string_0, StringBuilder stringBuilder_0)
		{
			if (string_0 != null)
			{
				stringBuilder_0.Append('\n');
				stringBuilder_0.Append(string_0);
			}
		}

		protected internal static void smethod_2(string[] string_0, StringBuilder stringBuilder_0)
		{
			if (string_0 != null)
			{
				for (int i = 0; i < string_0.Length; i++)
				{
					stringBuilder_0.Append('\n');
					stringBuilder_0.Append(string_0[i]);
				}
			}
		}

		protected internal static string[] smethod_3(string string_0)
		{
			return (string_0 == null) ? null : new string[1]
			{
				string_0
			};
		}

		protected internal static string smethod_4(string string_0)
		{
			if (string_0 != null)
			{
				int num = string_0.IndexOf('\\');
				if (num >= 0)
				{
					int length = string_0.Length;
					StringBuilder stringBuilder = new StringBuilder(length - 1);
					stringBuilder.Append(string_0.ToCharArray(), 0, num);
					bool flag = false;
					for (int i = num; i < length; i++)
					{
						char c = string_0[i];
						if (flag || c != '\\')
						{
							stringBuilder.Append(c);
							flag = false;
						}
						else
						{
							flag = true;
						}
					}
					return stringBuilder.ToString();
				}
			}
			return string_0;
		}

		private static string smethod_5(string string_0)
		{
			if (string_0 == null)
			{
				return null;
			}
			char[] array = string_0.ToCharArray();
			int num = smethod_6(array);
			if (num < 0)
			{
				return string_0;
			}
			int num2 = array.Length;
			StringBuilder stringBuilder = new StringBuilder(num2 - 2);
			stringBuilder.Append(array, 0, num);
			for (int i = num; i < num2; i++)
			{
				char c = array[i];
				switch (c)
				{
				case '+':
					stringBuilder.Append(' ');
					break;
				case '%':
				{
					if (i >= num2 - 2)
					{
						stringBuilder.Append('%');
						break;
					}
					int num3 = smethod_7(array[++i]);
					int num4 = smethod_7(array[++i]);
					if (num3 < 0 || num4 < 0)
					{
						stringBuilder.Append('%');
						stringBuilder.Append(array[i - 1]);
						stringBuilder.Append(array[i]);
					}
					stringBuilder.Append((char)((num3 << 4) + num4));
					break;
				}
				default:
					stringBuilder.Append(c);
					break;
				}
			}
			return stringBuilder.ToString();
		}

		private static int smethod_6(char[] char_0)
		{
			int num = char_0.Length;
			int num2 = 0;
			while (true)
			{
				if (num2 < num)
				{
					char c = char_0[num2];
					if (c == '+' || c == '%')
					{
						break;
					}
					num2++;
					continue;
				}
				return -1;
			}
			return num2;
		}

		private static int smethod_7(char char_0)
		{
			switch (char_0)
			{
			case 'a':
			case 'b':
			case 'c':
			case 'd':
			case 'e':
			case 'f':
				return 10 + (char_0 - 97);
			case 'A':
			case 'B':
			case 'C':
			case 'D':
			case 'E':
			case 'F':
				return 10 + (char_0 - 65);
			case '0':
			case '1':
			case '2':
			case '3':
			case '4':
			case '5':
			case '6':
			case '7':
			case '8':
			case '9':
				return char_0 - 48;
			default:
				return -1;
			}
		}

		protected internal static bool smethod_8(string string_0, int int_0)
		{
			if (string_0 == null)
			{
				return false;
			}
			int length = string_0.Length;
			if (int_0 != length)
			{
				return false;
			}
			int num = 0;
			while (true)
			{
				if (num < int_0)
				{
					char c = string_0[num];
					if (c < '0' || c > '9')
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

		protected internal static bool smethod_9(string string_0, int int_0, int int_1)
		{
			if (string_0 == null)
			{
				return false;
			}
			int length = string_0.Length;
			int num = int_0 + int_1;
			if (length < num)
			{
				return false;
			}
			int num2 = int_0;
			while (true)
			{
				if (num2 < num)
				{
					char c = string_0[num2];
					if (c < '0' || c > '9')
					{
						break;
					}
					num2++;
					continue;
				}
				return true;
			}
			return false;
		}

		internal static Hashtable smethod_10(string string_0)
		{
			int num = string_0.IndexOf('?');
			if (num < 0)
			{
				return null;
			}
			Hashtable hashtable = Hashtable.Synchronized(new Hashtable(3));
			num++;
			int num2;
			while ((num2 = string_0.IndexOf('&', num)) >= 0)
			{
				smethod_11(string_0, num, num2, hashtable);
				num = num2 + 1;
			}
			smethod_11(string_0, num, string_0.Length, hashtable);
			return hashtable;
		}

		private static void smethod_11(string string_0, int int_0, int int_1, Hashtable hashtable_0)
		{
			int num = string_0.IndexOf('=', int_0);
			if (num >= 0)
			{
				string key = string_0.Substring(int_0, num - int_0);
				string string_ = string_0.Substring(num + 1, int_1 - (num + 1));
				string_ = (string)(hashtable_0[key] = smethod_5(string_));
			}
		}

		internal static string[] smethod_12(string string_0, string string_1, char char_0, bool bool_0)
		{
			ArrayList arrayList = null;
			int num = 0;
			int length = string_1.Length;
			while (num < length)
			{
				num = string_1.IndexOf(string_0, num);
				if (num < 0)
				{
					break;
				}
				num += string_0.Length;
				int num2 = num;
				bool flag = false;
				while (!flag)
				{
					num = string_1.IndexOf(char_0, num);
					if (num < 0)
					{
						num = string_1.Length;
						flag = true;
						continue;
					}
					if (string_1[num - 1] == '\\')
					{
						num++;
						continue;
					}
					if (arrayList == null)
					{
						arrayList = ArrayList.Synchronized(new ArrayList(3));
					}
					string text = smethod_4(string_1.Substring(num2, num - num2));
					if (bool_0)
					{
						text = text.Trim();
					}
					arrayList.Add(text);
					num++;
					flag = true;
				}
			}
			if (arrayList == null || arrayList.Count == 0)
			{
				return null;
			}
			return smethod_14(arrayList);
		}

		internal static string smethod_13(string string_0, string string_1, char char_0, bool bool_0)
		{
			string[] array = smethod_12(string_0, string_1, char_0, bool_0);
			return (array == null) ? null : array[0];
		}

		internal static string[] smethod_14(ArrayList arrayList_0)
		{
			int count = arrayList_0.Count;
			string[] array = new string[count];
			for (int i = 0; i < count; i++)
			{
				array[i] = (string)arrayList_0[i];
			}
			return array;
		}
	}
}
