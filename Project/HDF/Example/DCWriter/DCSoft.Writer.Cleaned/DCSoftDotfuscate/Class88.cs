using DCSoft.Barcode;

namespace DCSoftDotfuscate
{
	internal class Class88 : Class84
	{
		private static readonly string[] string_2 = new string[10]
		{
			"11101010101110",
			"10111010101110",
			"11101110101010",
			"10101110101110",
			"11101011101010",
			"10111011101010",
			"10101011101110",
			"10101110111010",
			"11101010111010",
			"10111010111010"
		};

		public Class88(string string_3)
		{
			string_0 = string_3;
		}

		private string method_1()
		{
			int num = 7;
			string_1 = null;
			if (!method_0(string_0))
			{
				string_1 = BarcodeStrings.S25InvaliData;
				return null;
			}
			string str = "11011010";
			string string_ = string_0;
			foreach (char c in string_)
			{
				str += string_2[int.Parse(c.ToString())];
			}
			return str + "1101011";
		}

		public override string vmethod_0()
		{
			return method_1();
		}
	}
}
