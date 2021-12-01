using DCSoft.Barcode;
using System.Collections;

namespace DCSoftDotfuscate
{
	internal class Class89 : Class84
	{
		private static readonly string[] string_2 = new string[10]
		{
			"0001101",
			"0011001",
			"0010011",
			"0111101",
			"0100011",
			"0110001",
			"0101111",
			"0111011",
			"0110111",
			"0001011"
		};

		private static readonly string[] string_3 = new string[10]
		{
			"0100111",
			"0110011",
			"0011011",
			"0100001",
			"0011101",
			"0111001",
			"0000101",
			"0010001",
			"0001001",
			"0010111"
		};

		private static readonly string[] string_4 = new string[10]
		{
			"1110010",
			"1100110",
			"1101100",
			"1000010",
			"1011100",
			"1001110",
			"1010000",
			"1000100",
			"1001000",
			"1110100"
		};

		private static readonly string[] string_5 = new string[10]
		{
			"aaaaaa",
			"aababb",
			"aabbab",
			"aabbba",
			"abaabb",
			"abbaab",
			"abbbaa",
			"ababab",
			"ababba",
			"abbaba"
		};

		private static Hashtable hashtable_0 = null;

		private string string_6 = "N/A";

		public Class89(string string_7)
		{
			string_0 = string_7;
		}

		private string method_1()
		{
			int num = 4;
			string_1 = null;
			if (string_0.Length < 12 || string_0.Length > 13)
			{
				string_1 = BarcodeStrings.EAN13InvaliData;
				return null;
			}
			if (!method_0(string_0))
			{
				string_1 = BarcodeStrings.EAN13InvaliData;
				return null;
			}
			string text = string_5[int.Parse(string_0[0].ToString())];
			string str = "101";
			int i;
			for (i = 0; i < 6; i++)
			{
				if (text[i] == 'a')
				{
					str += string_2[int.Parse(string_0[i + 1].ToString())];
				}
				if (text[i] == 'b')
				{
					str += string_3[int.Parse(string_0[i + 1].ToString())];
				}
			}
			str += "01010";
			i = 1;
			while (i <= 5)
			{
				str += string_4[int.Parse(string_0[i++ + 6].ToString())];
			}
			int num2 = int.Parse(string_0[string_0.Length - 1].ToString());
			if (string_0.Length == 12)
			{
				int num3 = 0;
				int num4 = 0;
				for (int j = 0; j <= 10; j += 2)
				{
					num4 += int.Parse(string_0.Substring(j, 1));
				}
				for (int j = 1; j <= 11; j += 2)
				{
					num3 += int.Parse(string_0.Substring(j, 1)) * 3;
				}
				int num5 = num3 + num4;
				num2 = num5 % 10;
				num2 = 10 - num2;
				if (num2 == 10)
				{
					num2 = 0;
				}
				string_0 += num2;
			}
			str += string_4[num2];
			str += "101";
			method_2();
			string_6 = "N/A";
			string key = string_0.Substring(0, 2);
			string key2 = string_0.Substring(0, 3);
			if (hashtable_0.ContainsKey(key2))
			{
				string_6 = hashtable_0[key2].ToString();
			}
			else
			{
				if (!hashtable_0.ContainsKey(key))
				{
					string_1 = BarcodeStrings.EAN13InvaliCountry;
					return null;
				}
				string_6 = hashtable_0[key].ToString();
			}
			return str;
		}

		private void method_2()
		{
			int num = 17;
			if (hashtable_0 == null)
			{
				hashtable_0 = new Hashtable();
				hashtable_0.Add("00", "US / CANADA");
				hashtable_0.Add("01", "US / CANADA");
				hashtable_0.Add("02", "US / CANADA");
				hashtable_0.Add("03", "US / CANADA");
				hashtable_0.Add("04", "US / CANADA");
				hashtable_0.Add("05", "US / CANADA");
				hashtable_0.Add("06", "US / CANADA");
				hashtable_0.Add("07", "US / CANADA");
				hashtable_0.Add("08", "US / CANADA");
				hashtable_0.Add("09", "US / CANADA");
				hashtable_0.Add("10", "US / CANADA");
				hashtable_0.Add("11", "US / CANADA");
				hashtable_0.Add("12", "US / CANADA");
				hashtable_0.Add("13", "US / CANADA");
				hashtable_0.Add("20", "IN STORE");
				hashtable_0.Add("21", "IN STORE");
				hashtable_0.Add("22", "IN STORE");
				hashtable_0.Add("23", "IN STORE");
				hashtable_0.Add("24", "IN STORE");
				hashtable_0.Add("25", "IN STORE");
				hashtable_0.Add("26", "IN STORE");
				hashtable_0.Add("27", "IN STORE");
				hashtable_0.Add("28", "IN STORE");
				hashtable_0.Add("29", "IN STORE");
				hashtable_0.Add("30", "FRANCE");
				hashtable_0.Add("31", "FRANCE");
				hashtable_0.Add("32", "FRANCE");
				hashtable_0.Add("33", "FRANCE");
				hashtable_0.Add("34", "FRANCE");
				hashtable_0.Add("35", "FRANCE");
				hashtable_0.Add("36", "FRANCE");
				hashtable_0.Add("37", "FRANCE");
				hashtable_0.Add("40", "GERMANY");
				hashtable_0.Add("41", "GERMANY");
				hashtable_0.Add("42", "GERMANY");
				hashtable_0.Add("43", "GERMANY");
				hashtable_0.Add("44", "GERMANY");
				hashtable_0.Add("45", "JAPAN");
				hashtable_0.Add("46", "RUSSIAN FEDERATION");
				hashtable_0.Add("49", "JAPAN (JAN-13)");
				hashtable_0.Add("50", "UNITED KINGDOM");
				hashtable_0.Add("54", "BELGIUM / LUXEMBOURG");
				hashtable_0.Add("57", "DENMARK");
				hashtable_0.Add("64", "FINLAND");
				hashtable_0.Add("70", "NORWAY");
				hashtable_0.Add("73", "SWEDEN");
				hashtable_0.Add("76", "SWITZERLAND");
				hashtable_0.Add("80", "ITALY");
				hashtable_0.Add("81", "ITALY");
				hashtable_0.Add("82", "ITALY");
				hashtable_0.Add("83", "ITALY");
				hashtable_0.Add("84", "SPAIN");
				hashtable_0.Add("87", "NETHERLANDS");
				hashtable_0.Add("90", "AUSTRIA");
				hashtable_0.Add("91", "AUSTRIA");
				hashtable_0.Add("93", "AUSTRALIA");
				hashtable_0.Add("94", "NEW ZEALAND");
				hashtable_0.Add("99", "COUPONS");
				hashtable_0.Add("380", "BULGARIA");
				hashtable_0.Add("383", "SLOVENIJA");
				hashtable_0.Add("385", "CROATIA");
				hashtable_0.Add("387", "BOSNIA-HERZEGOVINA");
				hashtable_0.Add("460", "RUSSIA");
				hashtable_0.Add("461", "RUSSIA");
				hashtable_0.Add("462", "RUSSIA");
				hashtable_0.Add("463", "RUSSIA");
				hashtable_0.Add("464", "RUSSIA");
				hashtable_0.Add("465", "RUSSIA");
				hashtable_0.Add("466", "RUSSIA");
				hashtable_0.Add("467", "RUSSIA");
				hashtable_0.Add("468", "RUSSIA");
				hashtable_0.Add("469", "RUSSIA");
				hashtable_0.Add("471", "TAIWAN");
				hashtable_0.Add("474", "ESTONIA");
				hashtable_0.Add("475", "LATVIA");
				hashtable_0.Add("477", "LITHUANIA");
				hashtable_0.Add("479", "SRI LANKA");
				hashtable_0.Add("480", "PHILIPPINES");
				hashtable_0.Add("482", "UKRAINE");
				hashtable_0.Add("484", "MOLDOVA");
				hashtable_0.Add("485", "ARMENIA");
				hashtable_0.Add("486", "GEORGIA");
				hashtable_0.Add("487", "KAZAKHSTAN");
				hashtable_0.Add("489", "HONG KONG");
				hashtable_0.Add("520", "GREECE");
				hashtable_0.Add("528", "LEBANON");
				hashtable_0.Add("529", "CYPRUS");
				hashtable_0.Add("531", "MACEDONIA");
				hashtable_0.Add("535", "MALTA");
				hashtable_0.Add("539", "IRELAND");
				hashtable_0.Add("560", "PORTUGAL");
				hashtable_0.Add("569", "ICELAND");
				hashtable_0.Add("590", "POLAND");
				hashtable_0.Add("594", "ROMANIA");
				hashtable_0.Add("599", "HUNGARY");
				hashtable_0.Add("600", "SOUTH AFRICA");
				hashtable_0.Add("601", "SOUTH AFRICA");
				hashtable_0.Add("609", "MAURITIUS");
				hashtable_0.Add("611", "MOROCCO");
				hashtable_0.Add("613", "ALGERIA");
				hashtable_0.Add("619", "TUNISIA");
				hashtable_0.Add("622", "EGYPT");
				hashtable_0.Add("625", "JORDAN");
				hashtable_0.Add("626", "IRAN");
				hashtable_0.Add("627", "KUWAIT");
				hashtable_0.Add("628", "SAUDI ARABIA");
				hashtable_0.Add("629", "EMIRATES");
				hashtable_0.Add("690", "CHINA");
				hashtable_0.Add("691", "CHINA");
				hashtable_0.Add("692", "CHINA");
				hashtable_0.Add("693", "CHINA");
				hashtable_0.Add("694", "CHINA");
				hashtable_0.Add("695", "CHINA");
				hashtable_0.Add("729", "ISRAEL");
				hashtable_0.Add("740", "GUATEMALA");
				hashtable_0.Add("741", "EL SALVADOR");
				hashtable_0.Add("742", "HONDURAS");
				hashtable_0.Add("743", "NICARAGUA");
				hashtable_0.Add("744", "COSTA RICA");
				hashtable_0.Add("746", "DOMINICAN REPUBLIC");
				hashtable_0.Add("750", "MEXICO");
				hashtable_0.Add("759", "VENEZUELA");
				hashtable_0.Add("770", "COLOMBIA");
				hashtable_0.Add("773", "URUGUAY");
				hashtable_0.Add("775", "PERU");
				hashtable_0.Add("777", "BOLIVIA");
				hashtable_0.Add("779", "ARGENTINA");
				hashtable_0.Add("780", "CHILE");
				hashtable_0.Add("784", "PARAGUAY");
				hashtable_0.Add("785", "PERU");
				hashtable_0.Add("786", "ECUADOR");
				hashtable_0.Add("789", "BRAZIL");
				hashtable_0.Add("850", "CUBA");
				hashtable_0.Add("858", "SLOVAKIA");
				hashtable_0.Add("859", "CZECH REPUBLIC");
				hashtable_0.Add("860", "YUGLOSLAVIA");
				hashtable_0.Add("867", "NORTH KOREA");
				hashtable_0.Add("869", "TURKEY");
				hashtable_0.Add("880", "SOUTH KOREA");
				hashtable_0.Add("885", "THAILAND");
				hashtable_0.Add("888", "SINGAPORE");
				hashtable_0.Add("890", "INDIA");
				hashtable_0.Add("893", "VIETNAM");
				hashtable_0.Add("899", "INDONESIA");
				hashtable_0.Add("955", "MALAYSIA");
				hashtable_0.Add("958", "MACAU");
				hashtable_0.Add("977", "INTERNATIONAL STANDARD SERIAL NUMBER FOR PERIODICALS (ISSN)");
				hashtable_0.Add("978", "INTERNATIONAL STANDARD BOOK NUMBERING (ISBN)");
				hashtable_0.Add("979", "INTERNATIONAL STANDARD MUSIC NUMBER (ISMN)");
				hashtable_0.Add("980", "REFUND RECEIPTS");
				hashtable_0.Add("981", "COMMON CURRENCY COUPONS");
				hashtable_0.Add("982", "COMMON CURRENCY COUPONS");
			}
		}

		public override string vmethod_0()
		{
			return method_1();
		}
	}
}
