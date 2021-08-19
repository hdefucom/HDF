using DCSoft.Barcode;
using System.Text;

namespace DCSoftDotfuscate
{
	internal class Class87 : Class84
	{
		private const string string_2 = "1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ-. $/+%!@#$";

		private static string[] string_3 = new string[49]
		{
			"bsssbsbss",
			"bsbssbsss",
			"bsbsssbss",
			"bsbssssbs",
			"bssbsbsss",
			"bssbssbss",
			"bssbsssbs",
			"bsbsbssss",
			"bsssbssbs",
			"bssssbsbs",
			"bbsbsbsss",
			"bbsbssbss",
			"bbsbsssbs",
			"bbssbsbss",
			"bbssbssbs",
			"bbsssbsbs",
			"bsbbsbsss",
			"bsbbssbss",
			"bsbbsssbs",
			"bssbbsbss",
			"bsssbbsbs",
			"bsbsbbsss",
			"bsbssbbss",
			"bsbsssbbs",
			"bssbsbbss",
			"bsssbsbbs",
			"bbsbbsbss",
			"bbsbbssbs",
			"bbsbsbbss",
			"bbsbssbbs",
			"bbssbsbbs",
			"bbssbbsbs",
			"bsbbsbbss",
			"bsbbssbbs",
			"bssbbsbbs",
			"bssbbbsbs",
			"bssbsbbbs",
			"bbbsbsbss",
			"bbbsbssbs",
			"bbbssbsbs",
			"bsbbsbbbs",
			"bsbbbsbbs",
			"bbsbsbbbs",
			"bssbssbbs",
			"bbbsbbsbs",
			"bbbsbsbbs",
			"bssbbssbs",
			"bsbsbbbbs",
			"bsbsbbbbsb"
		};

		public Class87(string string_4)
		{
			string_0 = string_4;
		}

		public override string vmethod_0()
		{
			int num = 5;
			string_1 = null;
			StringBuilder stringBuilder = new StringBuilder();
			string string_ = string_0;
			string_ = string_.ToUpper();
			method_1(string_3[47], stringBuilder);
			string text = string_;
			int num2 = 0;
			while (true)
			{
				if (num2 < text.Length)
				{
					char value = text[num2];
					int num3 = "1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ-. $/+%!@#$".IndexOf(value);
					if (num3 < 0)
					{
						break;
					}
					method_1(string_3[num3], stringBuilder);
					num2++;
					continue;
				}
				int num4 = 0;
				int num5 = string_.Length;
				text = string_;
				foreach (char value in text)
				{
					num4 += "1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ-. $/+%!@#$".IndexOf(value) * num5;
					num5--;
				}
				num4 %= 47;
				method_1(string_3[num4], stringBuilder);
				num5 = string_.Length + 1;
				text = string_;
				foreach (char value in text)
				{
					num4 += "1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ-. $/+%!@#$".IndexOf(value) * num5;
					num5--;
				}
				num4 %= 47;
				method_1(string_3[num4], stringBuilder);
				method_1(string_3[48], stringBuilder);
				return stringBuilder.ToString();
			}
			string_1 = BarcodeStrings.Code93InvaliData;
			return null;
		}

		private void method_1(string string_4, StringBuilder stringBuilder_0)
		{
			int num = 10;
			bool flag = true;
			foreach (char c in string_4)
			{
				if (c == 'b')
				{
					stringBuilder_0.Append("1");
				}
				else
				{
					stringBuilder_0.Append("0");
				}
				flag = !flag;
			}
		}
	}
}
