using DCSoft.Barcode;
using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	internal class Class97 : Class84
	{
		[ComVisible(false)]
		public enum Enum9
		{
			const_0,
			const_1,
			const_2,
			const_3
		}

		private class Class102
		{
			public static readonly Class102[] class102_0;

			public string string_0 = null;

			public string string_1 = null;

			public string string_2 = null;

			public string string_3 = null;

			public string string_4 = null;

			static Class102()
			{
				class102_0 = null;
				class102_0 = (Class102[])new ArrayList
				{
					new Class102("0", " ", " ", "00", "11011001100"),
					new Class102("1", "!", "!", "01", "11001101100"),
					new Class102("2", "\"", "\"", "02", "11001100110"),
					new Class102("3", "#", "#", "03", "10010011000"),
					new Class102("4", "$", "$", "04", "10010001100"),
					new Class102("5", "%", "%", "05", "10001001100"),
					new Class102("6", "&", "&", "06", "10011001000"),
					new Class102("7", "'", "'", "07", "10011000100"),
					new Class102("8", "(", "(", "08", "10001100100"),
					new Class102("9", ")", ")", "09", "11001001000"),
					new Class102("10", "*", "*", "10", "11001000100"),
					new Class102("11", "+", "+", "11", "11000100100"),
					new Class102("12", ",", ",", "12", "10110011100"),
					new Class102("13", "-", "-", "13", "10011011100"),
					new Class102("14", ".", ".", "14", "10011001110"),
					new Class102("15", "/", "/", "15", "10111001100"),
					new Class102("16", "0", "0", "16", "10011101100"),
					new Class102("17", "1", "1", "17", "10011100110"),
					new Class102("18", "2", "2", "18", "11001110010"),
					new Class102("19", "3", "3", "19", "11001011100"),
					new Class102("20", "4", "4", "20", "11001001110"),
					new Class102("21", "5", "5", "21", "11011100100"),
					new Class102("22", "6", "6", "22", "11001110100"),
					new Class102("23", "7", "7", "23", "11101101110"),
					new Class102("24", "8", "8", "24", "11101001100"),
					new Class102("25", "9", "9", "25", "11100101100"),
					new Class102("26", ":", ":", "26", "11100100110"),
					new Class102("27", ";", ";", "27", "11101100100"),
					new Class102("28", "<", "<", "28", "11100110100"),
					new Class102("29", "=", "=", "29", "11100110010"),
					new Class102("30", ">", ">", "30", "11011011000"),
					new Class102("31", "?", "?", "31", "11011000110"),
					new Class102("32", "@", "@", "32", "11000110110"),
					new Class102("33", "A", "A", "33", "10100011000"),
					new Class102("34", "B", "B", "34", "10001011000"),
					new Class102("35", "C", "C", "35", "10001000110"),
					new Class102("36", "D", "D", "36", "10110001000"),
					new Class102("37", "E", "E", "37", "10001101000"),
					new Class102("38", "F", "F", "38", "10001100010"),
					new Class102("39", "G", "G", "39", "11010001000"),
					new Class102("40", "H", "H", "40", "11000101000"),
					new Class102("41", "I", "I", "41", "11000100010"),
					new Class102("42", "J", "J", "42", "10110111000"),
					new Class102("43", "K", "K", "43", "10110001110"),
					new Class102("44", "L", "L", "44", "10001101110"),
					new Class102("45", "M", "M", "45", "10111011000"),
					new Class102("46", "N", "N", "46", "10111000110"),
					new Class102("47", "O", "O", "47", "10001110110"),
					new Class102("48", "P", "P", "48", "11101110110"),
					new Class102("49", "Q", "Q", "49", "11010001110"),
					new Class102("50", "R", "R", "50", "11000101110"),
					new Class102("51", "S", "S", "51", "11011101000"),
					new Class102("52", "T", "T", "52", "11011100010"),
					new Class102("53", "U", "U", "53", "11011101110"),
					new Class102("54", "V", "V", "54", "11101011000"),
					new Class102("55", "W", "W", "55", "11101000110"),
					new Class102("56", "X", "X", "56", "11100010110"),
					new Class102("57", "Y", "Y", "57", "11101101000"),
					new Class102("58", "Z", "Z", "58", "11101100010"),
					new Class102("59", "[", "[", "59", "11100011010"),
					new Class102("60", "\\", "\\", "60", "11101111010"),
					new Class102("61", "]", "]", "61", "11001000010"),
					new Class102("62", "^", "^", "62", "11110001010"),
					new Class102("63", "_", "_", "63", "10100110000"),
					new Class102("64", "\0", "`", "64", "10100001100"),
					new Class102("65", Convert.ToChar(1).ToString(), "a", "65", "10010110000"),
					new Class102("66", Convert.ToChar(2).ToString(), "b", "66", "10010000110"),
					new Class102("67", Convert.ToChar(3).ToString(), "c", "67", "10000101100"),
					new Class102("68", Convert.ToChar(4).ToString(), "d", "68", "10000100110"),
					new Class102("69", Convert.ToChar(5).ToString(), "e", "69", "10110010000"),
					new Class102("70", Convert.ToChar(6).ToString(), "f", "70", "10110000100"),
					new Class102("71", Convert.ToChar(7).ToString(), "g", "71", "10011010000"),
					new Class102("72", Convert.ToChar(8).ToString(), "h", "72", "10011000010"),
					new Class102("73", Convert.ToChar(9).ToString(), "i", "73", "10000110100"),
					new Class102("74", Convert.ToChar(10).ToString(), "j", "74", "10000110010"),
					new Class102("75", Convert.ToChar(11).ToString(), "k", "75", "11000010010"),
					new Class102("76", Convert.ToChar(12).ToString(), "l", "76", "11001010000"),
					new Class102("77", Convert.ToChar(13).ToString(), "m", "77", "11110111010"),
					new Class102("78", Convert.ToChar(14).ToString(), "n", "78", "11000010100"),
					new Class102("79", Convert.ToChar(15).ToString(), "o", "79", "10001111010"),
					new Class102("80", Convert.ToChar(16).ToString(), "p", "80", "10100111100"),
					new Class102("81", Convert.ToChar(17).ToString(), "q", "81", "10010111100"),
					new Class102("82", Convert.ToChar(18).ToString(), "r", "82", "10010011110"),
					new Class102("83", Convert.ToChar(19).ToString(), "s", "83", "10111100100"),
					new Class102("84", Convert.ToChar(20).ToString(), "t", "84", "10011110100"),
					new Class102("85", Convert.ToChar(21).ToString(), "u", "85", "10011110010"),
					new Class102("86", Convert.ToChar(22).ToString(), "v", "86", "11110100100"),
					new Class102("87", Convert.ToChar(23).ToString(), "w", "87", "11110010100"),
					new Class102("88", Convert.ToChar(24).ToString(), "x", "88", "11110010010"),
					new Class102("89", Convert.ToChar(25).ToString(), "y", "89", "11011011110"),
					new Class102("90", Convert.ToChar(26).ToString(), "z", "90", "11011110110"),
					new Class102("91", Convert.ToChar(27).ToString(), "{", "91", "11110110110"),
					new Class102("92", Convert.ToChar(28).ToString(), "|", "92", "10101111000"),
					new Class102("93", Convert.ToChar(29).ToString(), ")", "93", "10100011110"),
					new Class102("94", Convert.ToChar(30).ToString(), "~", "94", "10001011110"),
					new Class102("95", Convert.ToChar(31).ToString(), Convert.ToChar(127).ToString(), "95", "10111101000"),
					new Class102("96", Convert.ToChar(202).ToString(), Convert.ToChar(202).ToString(), "96", "10111100010"),
					new Class102("97", Convert.ToChar(201).ToString(), Convert.ToChar(201).ToString(), "97", "11110101000"),
					new Class102("98", "SHIFT", "SHIFT", "98", "11110100010"),
					new Class102("99", "CODE_C", "CODE_C", "99", "10111011110"),
					new Class102("100", "CODE_B", Convert.ToChar(203).ToString(), "CODE_B", "10111101110"),
					new Class102("101", Convert.ToChar(203).ToString(), "CODE_A", "CODE_A", "11101011110"),
					new Class102("102", Convert.ToChar(200).ToString(), Convert.ToChar(200).ToString(), Convert.ToChar(200).ToString(), "11110101110"),
					new Class102("103", "START_A", "START_A", "START_A", "11010000100"),
					new Class102("104", "START_B", "START_B", "START_B", "11010010000"),
					new Class102("105", "START_C", "START_C", "START_C", "11010011100"),
					new Class102("", "STOP", "STOP", "STOP", "11000111010")
				}.ToArray(typeof(Class102));
			}

			public Class102(string string_5, string string_6, string string_7, string string_8, string string_9)
			{
				string_0 = string_5;
				string_1 = string_6;
				string_2 = string_7;
				string_3 = string_8;
				string_4 = string_9;
			}
		}

		private ArrayList arrayList_0 = new ArrayList();

		private ArrayList arrayList_1 = new ArrayList();

		private Enum9 enum9_0 = Enum9.const_0;

		public Class97(string string_2)
		{
			string_0 = string_2;
		}

		public Class97(string string_2, Enum9 enum9_1)
		{
			enum9_0 = enum9_1;
			string_0 = string_2;
		}

		private string method_1()
		{
			int num = 18;
			string_1 = null;
			StringBuilder stringBuilder = new StringBuilder();
			int num2 = 104;
			if (enum9_0 == Enum9.const_1)
			{
				stringBuilder.Append("11010000100");
				num2 = 103;
				for (int i = 0; i < string_0.Length; i++)
				{
					string b = string_0[i].ToString();
					bool flag = false;
					Class102[] class102_ = Class102.class102_0;
					foreach (Class102 @class in class102_)
					{
						if (@class.string_1 == b)
						{
							stringBuilder.Append(@class.string_4);
							num2 += Convert.ToInt32(@class.string_0) * (i + 1);
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						string_1 = BarcodeStrings.Code128InvaliData;
						return null;
					}
				}
				stringBuilder.Append(Class102.class102_0[num2 % 103].string_4);
				stringBuilder.Append("1100011101011");
			}
			else if (enum9_0 == Enum9.const_2)
			{
				stringBuilder.Append("11010010000");
				num2 = 104;
				for (int i = 0; i < string_0.Length; i++)
				{
					string b = string_0[i].ToString();
					bool flag = false;
					Class102[] class102_ = Class102.class102_0;
					foreach (Class102 @class in class102_)
					{
						if (@class.string_2 == b)
						{
							stringBuilder.Append(@class.string_4);
							num2 += Convert.ToInt32(@class.string_0) * (i + 1);
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						string_1 = BarcodeStrings.Code128InvaliData;
						return null;
					}
				}
				stringBuilder.Append(Class102.class102_0[num2 % 103].string_4);
				stringBuilder.Append("1100011101011");
			}
			else
			{
				if (enum9_0 != Enum9.const_3)
				{
					string_1 = BarcodeStrings.Code128InvaliData;
					return null;
				}
				stringBuilder.Append("11010011100");
				num2 = 105;
				string text = string_0;
				if (text.Length % 2 != 0)
				{
					text = "0" + text;
				}
				for (int i = 0; i < text.Length; i += 2)
				{
					string b = text.Substring(i, 2);
					bool flag = false;
					Class102[] class102_ = Class102.class102_0;
					foreach (Class102 @class in class102_)
					{
						if (@class.string_3 == b)
						{
							stringBuilder.Append(@class.string_4);
							num2 += Convert.ToInt32(@class.string_0) * (1 + i / 2);
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						string_1 = BarcodeStrings.Code128InvaliData;
						return null;
					}
				}
				stringBuilder.Append(Class102.class102_0[num2 % 103].string_4);
				stringBuilder.Append("1100011101011");
			}
			return stringBuilder.ToString();
		}

		public override string vmethod_0()
		{
			string_1 = null;
			return method_1();
		}
	}
}
