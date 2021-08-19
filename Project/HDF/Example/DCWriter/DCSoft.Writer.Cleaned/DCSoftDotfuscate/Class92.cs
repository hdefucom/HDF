using DCSoft.Barcode;

namespace DCSoftDotfuscate
{
	internal class Class92 : Class84
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

		public Class92(string string_4)
		{
			string_0 = string_4;
		}

		private string method_1()
		{
			int num = 0;
			string_1 = null;
			if (string_0.Length != 8 && string_0.Length != 7)
			{
				string_1 = BarcodeStrings.EAN8InvaliData;
				return null;
			}
			if (!method_0(string_0))
			{
				string_1 = BarcodeStrings.EAN8InvaliData;
				return null;
			}
			int num2 = 0;
			if (string_0.Length == 7)
			{
				int num3 = 0;
				int num4 = 0;
				for (int i = 0; i <= 6; i += 2)
				{
					num4 += int.Parse(string_0.Substring(i, 1)) * 3;
				}
				for (int i = 1; i <= 5; i += 2)
				{
					num3 += int.Parse(string_0.Substring(i, 1));
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
			string str = "101";
			for (int i = 0; i < string_0.Length / 2; i++)
			{
				str += string_2[int.Parse(string_0[i].ToString())];
			}
			str += "01010";
			for (int i = string_0.Length / 2; i < string_0.Length; i++)
			{
				str += string_3[int.Parse(string_0[i].ToString())];
			}
			return str + "101";
		}

		public override string vmethod_0()
		{
			return method_1();
		}
	}
}
