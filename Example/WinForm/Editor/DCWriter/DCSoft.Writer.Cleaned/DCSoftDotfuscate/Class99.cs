using DCSoft.Barcode;

namespace DCSoftDotfuscate
{
	internal class Class99 : Class84
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

		private static readonly string[] string_6 = new string[10]
		{
			"bbbaaa",
			"bbabaa",
			"bbaaba",
			"bbaaab",
			"babbaa",
			"baabba",
			"baaabb",
			"bababa",
			"babaab",
			"baabab"
		};

		private static readonly string[] string_7 = new string[10]
		{
			"aaabbb",
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

		public Class99(string string_8)
		{
			string_0 = string_8;
		}

		private string method_1()
		{
			int num = 14;
			string_1 = null;
			if (string_0.Length != 8 && string_0.Length != 12)
			{
				string_1 = BarcodeStrings.UPCEInvaliData;
				return null;
			}
			if (!method_0(string_0))
			{
				string_1 = BarcodeStrings.UPCEInvaliData;
				return null;
			}
			int num2 = int.Parse(string_0[string_0.Length - 1].ToString());
			int num3 = int.Parse(string_0[0].ToString());
			if (string_0.Length == 12)
			{
				string str = "";
				string text = string_0.Substring(1, 5);
				string text2 = string_0.Substring(6, 5);
				if (num3 != 0 && num3 != 1)
				{
					string_1 = BarcodeStrings.UPCEInvaliData;
					return null;
				}
				if (text.EndsWith("000") || text.EndsWith("100") || (text.EndsWith("200") && int.Parse(text2) <= 999))
				{
					str += text.Substring(0, 2);
					str += text2.Substring(2, 3);
					str += text[2];
				}
				else if (text.EndsWith("00") && int.Parse(text2) <= 99)
				{
					str += text.Substring(0, 3);
					str += text2.Substring(3, 2);
					str += "3";
				}
				else if (text.EndsWith("0") && int.Parse(text2) <= 9)
				{
					str += text.Substring(0, 4);
					str += text2[4];
					str += "4";
				}
				else
				{
					if (text.EndsWith("0") || int.Parse(text2) > 9 || int.Parse(text2) < 5)
					{
						string_1 = BarcodeStrings.UPCEInvaliData;
						return null;
					}
					str += text;
					str += text2[4];
				}
				string_0 = str;
			}
			string text3 = "";
			text3 = ((num3 != 0) ? string_7[num2] : string_6[num2]);
			string str2 = "101";
			int num4 = 0;
			string text4 = text3;
			foreach (char c in text4)
			{
				int num5 = int.Parse(string_0[num4++].ToString());
				switch (c)
				{
				case 'a':
					str2 += string_2[num5];
					break;
				case 'b':
					str2 += string_3[num5];
					break;
				}
			}
			str2 += "01010";
			return str2 + "1";
		}

		public override string vmethod_0()
		{
			return method_1();
		}
	}
}
