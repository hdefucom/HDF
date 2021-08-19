using DCSoft.Barcode;

namespace DCSoftDotfuscate
{
	internal class Class86 : Class84
	{
		private static string[] string_2 = new string[12]
		{
			"101011",
			"1101011",
			"1001011",
			"1100101",
			"1011011",
			"1101101",
			"1001101",
			"1010011",
			"1101001",
			"110101",
			"101101",
			"1011001"
		};

		public Class86(string string_3)
		{
			string_0 = string_3;
		}

		private string method_1()
		{
			int num = 17;
			string_1 = null;
			if (!method_0(string_0.Replace("-", "")))
			{
				string_1 = BarcodeStrings.Code11Error;
				return null;
			}
			int num2 = 1;
			int num3 = 0;
			string string_ = string_0;
			for (int num4 = string_0.Length - 1; num4 >= 0; num4--)
			{
				if (num2 == 10)
				{
					num2 = 1;
				}
				num3 = ((string_0[num4] == '-') ? (num3 + 10 * num2++) : (num3 + int.Parse(string_0[num4].ToString()) * num2++));
			}
			string_ += num3 % 11;
			if (string_0.Length >= 1)
			{
				num2 = 1;
				int num5 = 0;
				for (int num4 = string_.Length - 1; num4 >= 0; num4--)
				{
					if (num2 == 9)
					{
						num2 = 1;
					}
					num5 = ((string_[num4] == '-') ? (num5 + 10 * num2++) : (num5 + int.Parse(string_[num4].ToString()) * num2++));
				}
				string_ += num5 % 11;
			}
			string str = "0";
			string str2 = string_2[11] + str;
			string text = string_;
			for (int i = 0; i < text.Length; i++)
			{
				char c = text[i];
				int num6 = (c == '-') ? 10 : int.Parse(c.ToString());
				str2 += string_2[num6];
				str2 += str;
			}
			return str2 + string_2[11];
		}

		public override string vmethod_0()
		{
			return method_1();
		}
	}
}
