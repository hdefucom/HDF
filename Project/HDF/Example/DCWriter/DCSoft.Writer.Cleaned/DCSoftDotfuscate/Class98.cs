using DCSoft.Barcode;
using System;

namespace DCSoftDotfuscate
{
	internal class Class98 : Class84
	{
		private static readonly string[] string_2 = new string[10]
		{
			"100100100100",
			"100100100110",
			"100100110100",
			"100100110110",
			"100110100100",
			"100110100110",
			"100110110100",
			"100110110110",
			"110100100100",
			"110100100110"
		};

		private BarcodeStyle barcodeStyle_0 = BarcodeStyle.UNSPECIFIED;

		public Class98(string string_3, BarcodeStyle barcodeStyle_1)
		{
			barcodeStyle_0 = barcodeStyle_1;
			string_0 = string_3;
		}

		private string method_1()
		{
			int num = 1;
			string_1 = null;
			if (!method_0(string_0))
			{
				string_1 = BarcodeStrings.MSIInvaliData;
				return null;
			}
			string text = string_0;
			string text4;
			if (barcodeStyle_0 == BarcodeStyle.MSI_Mod10 || barcodeStyle_0 == BarcodeStyle.MSI_2Mod10)
			{
				string text2 = "";
				string text3 = "";
				for (int num2 = text.Length - 1; num2 >= 0; num2 -= 2)
				{
					text2 = text[num2] + text2;
					if (num2 - 1 >= 0)
					{
						text3 = text[num2 - 1] + text3;
					}
				}
				text2 = Convert.ToString(int.Parse(text2) * 2);
				int num3 = 0;
				int num4 = 0;
				text4 = text3;
				for (int i = 0; i < text4.Length; i++)
				{
					num3 += int.Parse(text4[i].ToString());
				}
				text4 = text2;
				for (int i = 0; i < text4.Length; i++)
				{
					num4 += int.Parse(text4[i].ToString());
				}
				text += 10 - (num4 + num3) % 10;
			}
			if (barcodeStyle_0 == BarcodeStyle.MSI_Mod11 || barcodeStyle_0 == BarcodeStyle.MSI_Mod11_Mod10)
			{
				int num5 = 0;
				int num6 = 2;
				for (int num2 = text.Length - 1; num2 >= 0; num2--)
				{
					if (num6 > 7)
					{
						num6 = 2;
					}
					num5 += int.Parse(text[num2].ToString()) * num6++;
				}
				text += 11 - num5 % 11;
			}
			if (barcodeStyle_0 == BarcodeStyle.MSI_2Mod10 || barcodeStyle_0 == BarcodeStyle.MSI_Mod11_Mod10)
			{
				string text2 = "";
				string text3 = "";
				for (int num2 = text.Length - 1; num2 >= 0; num2 -= 2)
				{
					text2 = text[num2] + text2;
					if (num2 - 1 >= 0)
					{
						text3 = text[num2 - 1] + text3;
					}
				}
				text2 = Convert.ToString(int.Parse(text2) * 2);
				int num3 = 0;
				int num4 = 0;
				text4 = text3;
				for (int i = 0; i < text4.Length; i++)
				{
					num3 += int.Parse(text4[i].ToString());
				}
				text4 = text2;
				for (int i = 0; i < text4.Length; i++)
				{
					num4 += int.Parse(text4[i].ToString());
				}
				text += 10 - (num4 + num3) % 10;
			}
			string str = "110";
			text4 = text;
			foreach (char c in text4)
			{
				str += string_2[int.Parse(c.ToString())];
			}
			return str + "1001";
		}

		public override string vmethod_0()
		{
			return method_1();
		}
	}
}
