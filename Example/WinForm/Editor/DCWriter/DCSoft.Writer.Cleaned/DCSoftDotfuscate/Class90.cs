using DCSoft.Barcode;

namespace DCSoftDotfuscate
{
	internal class Class90 : Class84
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

		private static readonly string[] string_4 = new string[4]
		{
			"aa",
			"ab",
			"ba",
			"bb"
		};

		public Class90(string string_5)
		{
			string_0 = string_5;
		}

		private string method_1()
		{
			int num = 16;
			string_1 = null;
			if (string_0.Length != 2 || !method_0(string_0))
			{
				string_1 = BarcodeStrings.UPCS2InvaliData;
				return null;
			}
			string text = "";
			try
			{
				text = string_4[int.Parse(string_0.Trim()) % 4];
			}
			catch
			{
				string_1 = BarcodeStrings.UPCS2InvaliData;
				return null;
			}
			string text2 = "1011";
			int index = 0;
			string text3 = text;
			for (int i = 0; i < text3.Length; i++)
			{
				switch (text3[i])
				{
				case 'a':
					text2 += string_2[int.Parse(string_0[index].ToString())];
					break;
				case 'b':
					text2 += string_3[int.Parse(string_0[index].ToString())];
					break;
				}
				if (index++ == 0)
				{
					text2 += "01";
				}
			}
			return text2;
		}

		public override string vmethod_0()
		{
			return method_1();
		}
	}
}
