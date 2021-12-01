using System.Collections;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	internal sealed class Class248 : GClass608
	{
		private Class248()
		{
		}

		public static GClass631 smethod_15(GClass645 gclass645_0)
		{
			int num = 4;
			string text = gclass645_0.method_0();
			if (!(text?.StartsWith("BEGIN:VCARD") ?? false))
			{
				return null;
			}
			string[] array = smethod_16("FN", text, bool_0: true);
			if (array == null)
			{
				array = smethod_16("N", text, bool_0: true);
				smethod_20(array);
			}
			string[] string_ = smethod_16("TEL", text, bool_0: true);
			string[] string_2 = smethod_16("EMAIL", text, bool_0: true);
			string string_3 = smethod_17("NOTE", text, bool_0: false);
			string[] array2 = smethod_16("ADR", text, bool_0: true);
			if (array2 != null)
			{
				for (int i = 0; i < array2.Length; i++)
				{
					array2[i] = smethod_19(array2[i]);
				}
			}
			string string_4 = smethod_17("ORG", text, bool_0: true);
			string text2 = smethod_17("BDAY", text, bool_0: true);
			if (!smethod_18(text2))
			{
				text2 = null;
			}
			string string_5 = smethod_17("TITLE", text, bool_0: true);
			string string_6 = smethod_17("URL", text, bool_0: true);
			return new GClass631(array, null, string_, string_2, string_3, array2, string_4, text2, string_5, string_6);
		}

		private static string[] smethod_16(string string_0, string string_1, bool bool_0)
		{
			ArrayList arrayList = null;
			int i = 0;
			int length = string_1.Length;
			while (i < length)
			{
				i = string_1.IndexOf(string_0, i);
				if (i < 0)
				{
					break;
				}
				if (i > 0 && string_1[i - 1] != '\n')
				{
					i++;
					continue;
				}
				i += string_0.Length;
				if (string_1[i] != ':' && string_1[i] != ';')
				{
					continue;
				}
				for (; string_1[i] != ':'; i++)
				{
				}
				i++;
				int num = i;
				i = string_1.IndexOf('\n', i);
				if (i < 0)
				{
					i = length;
				}
				else if (i > num)
				{
					if (arrayList == null)
					{
						arrayList = ArrayList.Synchronized(new ArrayList(3));
					}
					string text = string_1.Substring(num, i - num);
					if (bool_0)
					{
						text = text.Trim();
					}
					arrayList.Add(text);
					i++;
				}
				else
				{
					i++;
				}
			}
			if (arrayList == null || arrayList.Count == 0)
			{
				return null;
			}
			return GClass608.smethod_14(arrayList);
		}

		internal static string smethod_17(string string_0, string string_1, bool bool_0)
		{
			string[] array = smethod_16(string_0, string_1, bool_0);
			return (array == null) ? null : array[0];
		}

		private static bool smethod_18(string string_0)
		{
			if (string_0 == null)
			{
				return true;
			}
			if (GClass608.smethod_8(string_0, 8))
			{
				return true;
			}
			return string_0.Length == 10 && string_0[4] == '-' && string_0[7] == '-' && GClass608.smethod_9(string_0, 0, 4) && GClass608.smethod_9(string_0, 5, 2) && GClass608.smethod_9(string_0, 8, 2);
		}

		private static string smethod_19(string string_0)
		{
			if (string_0 == null)
			{
				return null;
			}
			int length = string_0.Length;
			StringBuilder stringBuilder = new StringBuilder(length);
			for (int i = 0; i < length; i++)
			{
				char c = string_0[i];
				if (c == ';')
				{
					stringBuilder.Append(' ');
				}
				else
				{
					stringBuilder.Append(c);
				}
			}
			return stringBuilder.ToString().Trim();
		}

		private static void smethod_20(string[] string_0)
		{
			if (string_0 == null)
			{
				return;
			}
			for (int i = 0; i < string_0.Length; i++)
			{
				string text = string_0[i];
				string[] array = new string[5];
				int num = 0;
				int num2 = 0;
				int num3;
				while ((num3 = text.IndexOf(';', num)) > 0)
				{
					array[num2] = text.Substring(num, num3 - num);
					num2++;
					num = num3 + 1;
				}
				array[num2] = text.Substring(num);
				StringBuilder stringBuilder = new StringBuilder(100);
				smethod_21(array, 3, stringBuilder);
				smethod_21(array, 1, stringBuilder);
				smethod_21(array, 2, stringBuilder);
				smethod_21(array, 0, stringBuilder);
				smethod_21(array, 4, stringBuilder);
				string_0[i] = stringBuilder.ToString().Trim();
			}
		}

		private static void smethod_21(string[] string_0, int int_0, StringBuilder stringBuilder_0)
		{
			if (string_0[int_0] != null)
			{
				stringBuilder_0.Append(' ');
				stringBuilder_0.Append(string_0[int_0]);
			}
		}
	}
}
