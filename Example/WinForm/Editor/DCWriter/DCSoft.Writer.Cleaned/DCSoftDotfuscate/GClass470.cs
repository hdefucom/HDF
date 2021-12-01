using DCSoft.Common;
using DCSoft.Drawing;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public static class GClass470
	{
		private static Dictionary<ParagraphListStyle, string> dictionary_0 = null;

		public static Dictionary<ParagraphListStyle, string> smethod_0()
		{
			int num = 7;
			if (dictionary_0 == null)
			{
				dictionary_0 = new Dictionary<ParagraphListStyle, string>();
				dictionary_0[ParagraphListStyle.ListNumberStyle] = "\0.";
				dictionary_0[ParagraphListStyle.ListNumberStyleArabic1] = "\0,";
				dictionary_0[ParagraphListStyle.ListNumberStyleArabic2] = "\0)";
				dictionary_0[ParagraphListStyle.ListNumberStyleLowercaseLetter] = "\0)";
				dictionary_0[ParagraphListStyle.ListNumberStyleLowercaseRoman] = "\0)";
				dictionary_0[ParagraphListStyle.ListNumberStyleNumberInCircle] = "\0,";
				dictionary_0[ParagraphListStyle.ListNumberStyleSimpChinNum1] = "\0.";
				dictionary_0[ParagraphListStyle.ListNumberStyleSimpChinNum2] = "\0)";
				dictionary_0[ParagraphListStyle.ListNumberStyleTradChinNum1] = "\0.";
				dictionary_0[ParagraphListStyle.ListNumberStyleTradChinNum2] = "\0)";
				dictionary_0[ParagraphListStyle.ListNumberStyleUppercaseLetter] = "\0)";
				dictionary_0[ParagraphListStyle.ListNumberStyleUppercaseRoman] = "\0)";
				dictionary_0[ParagraphListStyle.ListNumberStyleZodiac1] = "\0,";
				dictionary_0[ParagraphListStyle.ListNumberStyleZodiac2] = "\0,";
				dictionary_0[ParagraphListStyle.None] = null;
				dictionary_0[ParagraphListStyle.BulletedList] = new string('\uf06c', 1);
				dictionary_0[ParagraphListStyle.BulletedListBlock] = new string('\uf06e', 1);
				dictionary_0[ParagraphListStyle.BulletedListCheck] = new string('\uf0fc', 1);
				dictionary_0[ParagraphListStyle.BulletedListDiamond] = new string('\uf075', 1);
				dictionary_0[ParagraphListStyle.BulletedListRightArrow] = new string('\uf0d8', 1);
				dictionary_0[ParagraphListStyle.BulletedListHollowStar] = new string('\uf0b2', 1);
			}
			return dictionary_0;
		}

		public static string smethod_1(ParagraphListStyle paragraphListStyle_0)
		{
			if (smethod_0().ContainsKey(paragraphListStyle_0))
			{
				return smethod_0()[paragraphListStyle_0];
			}
			return null;
		}

		public static string smethod_2(ParagraphListStyle paragraphListStyle_0)
		{
			if (smethod_0().ContainsKey(paragraphListStyle_0))
			{
				return smethod_0()[paragraphListStyle_0];
			}
			return new string('\uf06c', 1);
		}

		public static ParagraphListStyle smethod_3(char char_0)
		{
			foreach (ParagraphListStyle key in smethod_0().Keys)
			{
				string text = smethod_0()[key];
				if (!string.IsNullOrEmpty(text) && (text[0] & 0xFF) == (char_0 & 0xFF))
				{
					return key;
				}
			}
			return ParagraphListStyle.BulletedList;
		}

		public static string smethod_4(int int_0, ParagraphListStyle paragraphListStyle_0)
		{
			int num = 2;
			string result = int_0.ToString();
			switch (paragraphListStyle_0)
			{
			case ParagraphListStyle.ListNumberStyle:
				result = int_0.ToString();
				break;
			case ParagraphListStyle.ListNumberStyleArabic1:
				result = int_0.ToString();
				break;
			case ParagraphListStyle.ListNumberStyleArabic2:
				result = int_0.ToString();
				break;
			case ParagraphListStyle.ListNumberStyleLowercaseLetter:
				result = StringConvertHelper.GetLetterNumber(int_0 - 1, "abcdefghijklmnopqrstuvwxyz");
				break;
			case ParagraphListStyle.ListNumberStyleLowercaseRoman:
				result = StringConvertHelper.GetRomanNumber(int_0).ToLower();
				break;
			case ParagraphListStyle.ListNumberStyleNumberInCircle:
			{
				string text = "_①②③④⑤⑥⑦⑧⑨⑩";
				result = text[int_0 % text.Length].ToString();
				break;
			}
			case ParagraphListStyle.ListNumberStyleSimpChinNum1:
				result = StringConvertHelper.ToChineseNumber2(int_0, lowercase: true);
				break;
			case ParagraphListStyle.ListNumberStyleSimpChinNum2:
				result = StringConvertHelper.ToChineseNumber2(int_0, lowercase: true);
				break;
			case ParagraphListStyle.ListNumberStyleTradChinNum1:
				result = StringConvertHelper.ToChineseNumber2(int_0, lowercase: false);
				break;
			case ParagraphListStyle.ListNumberStyleTradChinNum2:
				result = StringConvertHelper.ToChineseNumber2(int_0, lowercase: false);
				break;
			case ParagraphListStyle.ListNumberStyleUppercaseLetter:
				result = StringConvertHelper.GetLetterNumber(int_0 - 1, "ABCDEFGHIJKLMNOPQRSTUVWXYZ");
				break;
			case ParagraphListStyle.ListNumberStyleUppercaseRoman:
				result = StringConvertHelper.GetRomanNumber(int_0).ToUpper();
				break;
			case ParagraphListStyle.ListNumberStyleZodiac1:
			{
				string text = "_甲乙丙丁戊己庚辛壬癸";
				result = text[int_0 % text.Length].ToString();
				break;
			}
			case ParagraphListStyle.ListNumberStyleZodiac2:
			{
				string text = "_子丑寅卯辰巳午未申酉戌亥";
				result = text[int_0 % text.Length].ToString();
				break;
			}
			}
			return result;
		}

		public static string smethod_5(int int_0, ParagraphListStyle paragraphListStyle_0)
		{
			int num = 14;
			string text = "\0.";
			if (smethod_0().ContainsKey(paragraphListStyle_0))
			{
				text = smethod_0()[paragraphListStyle_0];
			}
			if (string.IsNullOrEmpty(text))
			{
				return null;
			}
			string newValue = smethod_4(int_0, paragraphListStyle_0);
			return text.Replace("\0", newValue);
		}

		public static bool smethod_6(ParagraphListStyle paragraphListStyle_0)
		{
			return paragraphListStyle_0 == ParagraphListStyle.BulletedList || paragraphListStyle_0 == ParagraphListStyle.BulletedListBlock || paragraphListStyle_0 == ParagraphListStyle.BulletedListCheck || paragraphListStyle_0 == ParagraphListStyle.BulletedListDiamond || paragraphListStyle_0 == ParagraphListStyle.BulletedListHollowStar || paragraphListStyle_0 == ParagraphListStyle.BulletedListRightArrow;
		}

		public static bool smethod_7(ParagraphListStyle paragraphListStyle_0)
		{
			return paragraphListStyle_0 == ParagraphListStyle.ListNumberStyle || paragraphListStyle_0 == ParagraphListStyle.ListNumberStyleArabic1 || paragraphListStyle_0 == ParagraphListStyle.ListNumberStyleArabic2 || paragraphListStyle_0 == ParagraphListStyle.ListNumberStyleLowercaseLetter || paragraphListStyle_0 == ParagraphListStyle.ListNumberStyleLowercaseRoman || paragraphListStyle_0 == ParagraphListStyle.ListNumberStyleNumberInCircle || paragraphListStyle_0 == ParagraphListStyle.ListNumberStyleSimpChinNum1 || paragraphListStyle_0 == ParagraphListStyle.ListNumberStyleSimpChinNum2 || paragraphListStyle_0 == ParagraphListStyle.ListNumberStyleTradChinNum1 || paragraphListStyle_0 == ParagraphListStyle.ListNumberStyleTradChinNum2 || paragraphListStyle_0 == ParagraphListStyle.ListNumberStyleUppercaseLetter || paragraphListStyle_0 == ParagraphListStyle.ListNumberStyleUppercaseRoman || paragraphListStyle_0 == ParagraphListStyle.ListNumberStyleZodiac1 || paragraphListStyle_0 == ParagraphListStyle.ListNumberStyleZodiac2;
		}
	}
}
