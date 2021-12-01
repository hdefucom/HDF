using DCSoft.Barcode;
using System;

namespace DCSoftDotfuscate
{
	internal class Class93 : Class84
	{
		private static readonly string[] string_2 = new string[10]
		{
			"11000",
			"00011",
			"00101",
			"00110",
			"01001",
			"01010",
			"01100",
			"10001",
			"10010",
			"10100"
		};

		public Class93(string string_3)
		{
			string_0 = string_3;
		}

		private string method_1()
		{
			int num = 3;
			string_1 = null;
			string_0 = string_0.Replace("-", "");
			switch (string_0.Length)
			{
			default:
				string_1 = BarcodeStrings.PostnetError;
				return null;
			case 5:
			case 6:
			case 9:
			case 11:
			{
				string str = "1";
				int num2 = 0;
				string string_ = string_0;
				foreach (char value in string_)
				{
					try
					{
						int num3 = "0123456789".IndexOf(value);
						if (num3 < 0)
						{
							string_1 = BarcodeStrings.PostnetError;
							return null;
						}
						str += string_2[num3];
						num2 += num3;
					}
					catch (Exception ex)
					{
						string_1 = BarcodeStrings.PostnetError + "->" + ex.Message;
						return null;
					}
				}
				int num4 = num2 % 10;
				int num5 = 10 - ((num4 == 0) ? 10 : num4);
				str += string_2[num5];
				return str + "1";
			}
			}
		}

		public override string vmethod_0()
		{
			return method_1();
		}
	}
}
