using DCSoft.Barcode;

namespace DCSoftDotfuscate
{
	internal class Class100 : Class84
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
			"bbaaa",
			"babaa",
			"baaba",
			"baaab",
			"abbaa",
			"aabba",
			"aaabb",
			"ababa",
			"abaab",
			"aabab"
		};

		public Class100(string string_5)
		{
			string_0 = string_5;
		}

		private string method_1()
		{
			int num = 12;
			string_1 = null;
			if (string_0.Length != 5 || !method_0(string_0))
			{
				string_1 = BarcodeStrings.UPCS5InvaliData;
				return null;
			}
			int num2 = 0;
			int num3 = 0;
			for (int i = 0; i <= 4; i += 2)
			{
				num3 += int.Parse(string_0.Substring(i, 1)) * 3;
			}
			for (int i = 1; i < 4; i += 2)
			{
				num2 += int.Parse(string_0.Substring(i, 1)) * 9;
			}
			int num4 = num2 + num3;
			int num5 = num4 % 10;
			string text = string_4[num5];
			string text2 = "";
			int num6 = 0;
			string text3 = text;
			foreach (char c in text3)
			{
				text2 = ((num6 != 0) ? (text2 + "01") : (text2 + "1011"));
				switch (c)
				{
				case 'a':
					text2 += string_2[int.Parse(string_0[num6].ToString())];
					break;
				case 'b':
					text2 += string_3[int.Parse(string_0[num6].ToString())];
					break;
				}
				num6++;
			}
			return text2;
		}

		public override string vmethod_0()
		{
			return method_1();
		}
	}
}
