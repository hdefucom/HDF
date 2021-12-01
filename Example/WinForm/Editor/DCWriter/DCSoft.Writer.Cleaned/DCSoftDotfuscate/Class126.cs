using DCSoft.Writer.Dom;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	internal static class Class126
	{
		[ComVisible(false)]
		public enum Enum11
		{
			const_0,
			const_1,
			const_2
		}

		private class Class127
		{
			public char char_0;

			public char char_1;

			public char char_2;

			public char char_3;

			public Enum11 enum11_0;

			public Class127(char char_4, char char_5, char char_6, char char_7, Enum11 enum11_1)
			{
				char_0 = char_4;
				char_1 = char_5;
				char_2 = char_6;
				char_3 = char_7;
				enum11_0 = enum11_1;
			}
		}

		public const char char_0 = '\u0640';

		private const string string_0 = "ېىوۈۇۆاە";

		private const string string_1 = "رزدۋژ";

		private static bool bool_0;

		private static int int_0;

		private static Class127[] class127_0;

		private static char char_1;

		private static char char_2;

		private static char[] char_3;

		private static char[] char_4;

		private static char char_5;

		private static char char_6;

		private static char char_7;

		private static char char_8;

		private static char char_9;

		private static char char_10;

		private static char char_11;

		private static char char_12;

		public static bool smethod_0()
		{
			return bool_0;
		}

		public static void smethod_1(bool bool_1)
		{
			bool_0 = bool_1;
		}

		public static bool smethod_2(XTextElementList xtextElementList_0)
		{
			return false;
		}

		public static bool smethod_3(XTextElementList xtextElementList_0)
		{
			if (!smethod_5())
			{
				return false;
			}
			List<XTextCharElement> list = null;
			int count = xtextElementList_0.Count;
			bool result = false;
			for (int i = 0; i < count; i++)
			{
				XTextElement xTextElement = xtextElementList_0[i];
				bool flag = false;
				if (xTextElement is XTextCharElement)
				{
					XTextCharElement xTextCharElement = (XTextCharElement)xTextElement;
					char charValue = xTextCharElement.CharValue;
					if (smethod_9(charValue))
					{
						if (list == null)
						{
							list = new List<XTextCharElement>();
						}
						list.Add(xTextCharElement);
						flag = true;
						xTextElement.IsRightToLeft = true;
					}
				}
				if ((flag && i != count - 1) || list == null || list.Count <= 0)
				{
					continue;
				}
				StringBuilder stringBuilder = new StringBuilder();
				foreach (XTextCharElement item in list)
				{
					stringBuilder.Append(item.CharValue);
				}
				string text = smethod_10(stringBuilder.ToString());
				for (int j = 0; j < text.Length; j++)
				{
					char c = text[j];
					XTextCharElement current = list[j];
					bool flag2 = false;
					if (j > 0 && (flag2 = smethod_6(current.CharValue, current.RuntimeCharValue, list[j - 1].CharValue)) && j > 2 && (list[j - 1].RuntimeCharValue == char_10 || list[j - 2].RuntimeCharValue == char_11))
					{
						flag2 = false;
					}
					if (c == '\0')
					{
						c = '\u0001';
					}
					if (current.char_1 != c || current.ConnectFlag != flag2)
					{
						current.ConnectFlag = flag2;
						current.char_1 = c;
						current.SizeInvalid = true;
						current.LinkCharNum = 0;
						result = true;
					}
				}
				list[0].ConnectFlag = false;
				for (int j = text.Length; j < list.Count; j++)
				{
					XTextCharElement current = list[j];
					if (current.char_1 != '\u0001' || current.ConnectFlag)
					{
						current.ConnectFlag = false;
						current.char_1 = '\u0001';
						current.SizeInvalid = true;
						current.LinkCharNum = 0;
						result = true;
					}
				}
				list.Clear();
			}
			return result;
		}

		public static void smethod_4()
		{
			int_0 = -1;
		}

		public static bool smethod_5()
		{
			if (!bool_0)
			{
				return false;
			}
			if (int_0 == -1)
			{
				GClass138 gClass = Class103.smethod_4();
				if (!(gClass?.method_34() ?? true))
				{
					int_0 = 1;
					return true;
				}
				if (gClass != null && (gClass.method_23() || gClass.method_8().method_7()))
				{
					int_0 = 1;
				}
				else
				{
					int_0 = 0;
				}
			}
			return int_0 == 1;
		}

		public static bool smethod_6(char char_13, char char_14, char char_15)
		{
			int num = 5;
			if (!smethod_5())
			{
				return false;
			}
			if (char_15 == '\u0640')
			{
				return "ېىوۈۇۆاە".IndexOf(char_13) > 0;
			}
			Class127[] array = class127_0;
			int num2 = 0;
			while (true)
			{
				if (num2 < array.Length)
				{
					Class127 @class = array[num2];
					if (@class != null && (@class.char_1 == char_14 || @class.char_0 == char_14))
					{
						break;
					}
					num2++;
					continue;
				}
				if ("ېىوۈۇۆاە".IndexOf(char_13) > 0 && smethod_8(char_15) && "رزدۋژ".IndexOf(char_15) < 0)
				{
					return true;
				}
				return false;
			}
			return false;
		}

		public static bool smethod_7(char char_13, char char_14)
		{
			if (!smethod_5())
			{
				return false;
			}
			if (char_13 == 'ل' && char_14 == 'ا')
			{
				return true;
			}
			if ((char_13 == 'ﻝ' || char_13 == 'ﻞ' || char_13 == 'ﻠ' || char_13 == 'ﻟ') && (char_13 == 'ﺍ' || char_13 == 'ﺎ'))
			{
				return true;
			}
			return false;
		}

		static Class126()
		{
			bool_0 = true;
			int_0 = -1;
			class127_0 = new Class127[256];
			char_1 = '\u0600';
			char_2 = 'ۿ';
			char_3 = new char[256];
			char_4 = new char[256];
			char_5 = 'چ';
			char_6 = 'غ';
			char_7 = 'ڭ';
			char_8 = 'ش';
			char_9 = 'ژ';
			char_10 = 'ﻻ';
			char_11 = 'ﻼ';
			char_12 = 'ئ';
			for (int i = 0; i < char_3.Length; i++)
			{
				char_3[i] = '\0';
			}
			for (int i = 0; i < char_4.Length; i++)
			{
				char_4[i] = '\0';
			}
			char_3[65] = 'ا';
			char_3[97] = 'ا';
			char_3[66] = 'ب';
			char_3[98] = 'ب';
			char_3[67] = 'ك';
			char_3[99] = 'ك';
			char_3[68] = 'د';
			char_3[100] = 'د';
			char_3[69] = 'ە';
			char_3[101] = 'ە';
			char_3[70] = 'ف';
			char_3[102] = 'ف';
			char_3[71] = 'گ';
			char_3[103] = 'گ';
			char_3[72] = 'ھ';
			char_3[104] = 'ھ';
			char_3[73] = 'ى';
			char_3[105] = 'ى';
			char_3[74] = 'ج';
			char_3[106] = 'ج';
			char_3[75] = 'ك';
			char_3[107] = 'ك';
			char_3[76] = 'ل';
			char_3[108] = 'ل';
			char_3[77] = 'م';
			char_3[109] = 'م';
			char_3[78] = 'ن';
			char_3[110] = 'ن';
			char_3[79] = 'و';
			char_3[111] = 'و';
			char_3[80] = 'پ';
			char_3[112] = 'پ';
			char_3[81] = 'ق';
			char_3[113] = 'ق';
			char_3[82] = 'ر';
			char_3[114] = 'ر';
			char_3[83] = 'س';
			char_3[115] = 'س';
			char_3[84] = 'ت';
			char_3[116] = 'ت';
			char_3[85] = 'ۇ';
			char_3[117] = 'ۇ';
			char_3[86] = 'ۋ';
			char_3[118] = 'ۋ';
			char_3[87] = 'ۋ';
			char_3[119] = 'ۋ';
			char_3[88] = 'خ';
			char_3[120] = 'خ';
			char_3[89] = 'ي';
			char_3[121] = 'ي';
			char_3[90] = 'ز';
			char_3[122] = 'ز';
			char_3[201] = 'ې';
			char_3[233] = 'ې';
			char_3[246] = 'ۆ';
			char_3[214] = 'ۆ';
			char_3[220] = 'ۈ';
			char_3[252] = 'ۈ';
			char_3[59] = '؛';
			char_3[63] = '؟';
			char_3[44] = '،';
			for (int i = 0; i < class127_0.Length; i++)
			{
				class127_0[i] = null;
			}
			class127_0[char_3[97] - char_1] = new Class127('ﺍ', 'ﺍ', 'ﺍ', 'ﺎ', Enum11.const_0);
			class127_0[char_3[101] - char_1] = new Class127('ﻩ', 'ﻩ', 'ﻩ', 'ﻪ', Enum11.const_0);
			class127_0[char_3[98] - char_1] = new Class127('ﺏ', 'ﺑ', 'ﺒ', 'ﺐ', Enum11.const_2);
			class127_0[char_3[112] - char_1] = new Class127('ﭖ', 'ﭘ', 'ﭙ', 'ﭗ', Enum11.const_2);
			class127_0[char_3[116] - char_1] = new Class127('ﺕ', 'ﺗ', 'ﺘ', 'ﺖ', Enum11.const_2);
			class127_0[char_3[106] - char_1] = new Class127('ﺝ', 'ﺟ', 'ﺠ', 'ﺞ', Enum11.const_2);
			class127_0[char_5 - char_1] = new Class127('ﭺ', 'ﭼ', 'ﭽ', 'ﭻ', Enum11.const_2);
			class127_0[char_3[120] - char_1] = new Class127('ﺥ', 'ﺧ', 'ﺨ', 'ﺦ', Enum11.const_2);
			class127_0[char_3[100] - char_1] = new Class127('ﺩ', 'ﺩ', 'ﺪ', 'ﺪ', Enum11.const_1);
			class127_0[char_3[114] - char_1] = new Class127('ﺭ', 'ﺭ', 'ﺮ', 'ﺮ', Enum11.const_1);
			class127_0[char_3[122] - char_1] = new Class127('ﺯ', 'ﺯ', 'ﺰ', 'ﺰ', Enum11.const_1);
			class127_0[char_9 - char_1] = new Class127('ﮊ', 'ﮊ', 'ﮋ', 'ﮋ', Enum11.const_1);
			class127_0[char_3[115] - char_1] = new Class127('ﺱ', 'ﺳ', 'ﺴ', 'ﺲ', Enum11.const_2);
			class127_0[char_8 - char_1] = new Class127('ﺵ', 'ﺷ', 'ﺸ', 'ﺶ', Enum11.const_2);
			class127_0[char_6 - char_1] = new Class127('ﻍ', 'ﻏ', 'ﻐ', 'ﻎ', Enum11.const_2);
			class127_0[char_3[102] - char_1] = new Class127('ﻑ', 'ﻓ', 'ﻔ', 'ﻒ', Enum11.const_2);
			class127_0[char_3[113] - char_1] = new Class127('ﻕ', 'ﻗ', 'ﻘ', 'ﻖ', Enum11.const_2);
			class127_0[char_3[107] - char_1] = new Class127('ﻙ', 'ﻛ', 'ﻜ', 'ﻚ', Enum11.const_2);
			class127_0[char_3[103] - char_1] = new Class127('ﮒ', 'ﮔ', 'ﮕ', 'ﮓ', Enum11.const_2);
			class127_0[char_7 - char_1] = new Class127('ﯓ', 'ﯕ', 'ﯖ', 'ﯔ', Enum11.const_2);
			class127_0[char_3[108] - char_1] = new Class127('ﻝ', 'ﻟ', 'ﻠ', 'ﻞ', Enum11.const_2);
			class127_0[char_3[109] - char_1] = new Class127('ﻡ', 'ﻣ', 'ﻤ', 'ﻢ', Enum11.const_2);
			class127_0[char_3[110] - char_1] = new Class127('ﻥ', 'ﻧ', 'ﻨ', 'ﻦ', Enum11.const_2);
			class127_0[char_3[104] - char_1] = new Class127('ﻫ', 'ﻫ', 'ﻬ', 'ﻬ', Enum11.const_2);
			class127_0[char_3[104] - char_1] = new Class127('ﮪ', 'ﮪ', 'ﮭ', 'ﮭ', Enum11.const_2);
			class127_0[char_3[111] - char_1] = new Class127('ﻭ', 'ﻭ', 'ﻮ', 'ﻮ', Enum11.const_1);
			class127_0[char_3[117] - char_1] = new Class127('ﯗ', 'ﯗ', 'ﯘ', 'ﯘ', Enum11.const_1);
			class127_0[char_3[214] - char_1] = new Class127('ﯙ', 'ﯙ', 'ﯚ', 'ﯚ', Enum11.const_1);
			class127_0[char_3[252] - char_1] = new Class127('ﯛ', 'ﯛ', 'ﯜ', 'ﯜ', Enum11.const_1);
			class127_0[char_3[119] - char_1] = new Class127('ﯞ', 'ﯞ', 'ﯟ', 'ﯟ', Enum11.const_1);
			class127_0[char_3[233] - char_1] = new Class127('ﯤ', 'ﯦ', 'ﯧ', 'ﯥ', Enum11.const_2);
			class127_0[char_3[105] - char_1] = new Class127('ﻯ', 'ﯨ', 'ﯩ', 'ﻰ', Enum11.const_2);
			class127_0[char_3[121] - char_1] = new Class127('ﻱ', 'ﻳ', 'ﻴ', 'ﻲ', Enum11.const_2);
			class127_0[char_12 - char_1] = new Class127('ﺋ', 'ﺋ', 'ﺌ', 'ﮌ', Enum11.const_2);
		}

		public static bool smethod_8(char char_13)
		{
			if (!smethod_5())
			{
				return false;
			}
			if (char_13 >= '\u0600' && char_13 <= 'ۿ')
			{
				return true;
			}
			return false;
		}

		private static bool smethod_9(char char_13)
		{
			if (char_13 >= '\u0600' && char_13 <= 'ۿ')
			{
				return true;
			}
			return false;
		}

		public static string smethod_10(string string_2)
		{
			if (!smethod_5())
			{
				return string_2;
			}
			Class127 @class = class127_0[char_3[108] - char_1];
			Enum11 @enum = Enum11.const_0;
			string text = "";
			int length = string_2.Length;
			int num = 0;
			char c = '\0';
			char c2 = '\0';
			char c3 = '\0';
			char[] array = new char[length];
			for (int i = 0; i < length; i++)
			{
				char c4 = string_2[i];
				if (c4 != '\u0640')
				{
				}
				if (char_1 <= c4 && c4 < char_2)
				{
					Class127 class2 = class127_0[c4 - char_1];
					if (class2 != null)
					{
						switch (@enum)
						{
						case Enum11.const_0:
							c = class2.char_0;
							break;
						case Enum11.const_1:
							c = class2.char_0;
							break;
						case Enum11.const_2:
							c = class2.char_3;
							break;
						}
						if (@enum != 0)
						{
							Class127 class3 = class127_0[c2 - char_1];
							if (class3 != null)
							{
								if (c3 == @class.char_0 && c4 == char_3[97])
								{
									array[num - 1] = char_10;
									@enum = Enum11.const_0;
									continue;
								}
								if (c3 == @class.char_3 && c4 == char_3[97])
								{
									array[num - 1] = char_11;
									@enum = Enum11.const_0;
									continue;
								}
								if (c3 == class3.char_0)
								{
									array[num - 1] = class3.char_1;
								}
								else if (c3 == class3.char_3)
								{
									array[num - 1] = class3.char_2;
								}
							}
						}
						@enum = class2.enum11_0;
					}
					else if (c4 == '\u0640')
					{
						if (c2 >= char_1)
						{
							Class127 class3 = class127_0[c2 - char_1];
							if (class3 != null)
							{
								if (c3 == class3.char_0)
								{
									array[num - 1] = class3.char_1;
								}
								else if (c3 == class3.char_3)
								{
									array[num - 1] = class3.char_2;
								}
							}
						}
						@enum = Enum11.const_2;
						c = c4;
					}
					else
					{
						c = c4;
						@enum = Enum11.const_0;
					}
				}
				else
				{
					c = c4;
					@enum = Enum11.const_0;
				}
				array[num] = c;
				c3 = c;
				c2 = c4;
				num++;
			}
			return new string(array, 0, num);
		}

		private static bool smethod_11(int int_1)
		{
			if ((65 <= int_1 && int_1 <= 90) || (97 <= int_1 && int_1 <= 122))
			{
				return true;
			}
			return false;
		}
	}
}
