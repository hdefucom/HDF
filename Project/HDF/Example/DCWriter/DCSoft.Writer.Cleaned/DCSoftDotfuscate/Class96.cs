using DCSoft.Barcode;
using System.Collections;
using System.Text;

namespace DCSoftDotfuscate
{
	internal class Class96 : Class84
	{
		private static Hashtable hashtable_0 = null;

		public Class96(string string_2)
		{
			string_0 = string_2;
		}

		private string method_1()
		{
			int num = 15;
			string_1 = null;
			if (string_0.Length < 2)
			{
				string_1 = BarcodeStrings.CodabarError;
				return null;
			}
			switch (string_0[0].ToString().ToUpper().Trim())
			{
			case "A":
			case "B":
			case "C":
			case "D":
				switch (string_0[string_0.Trim().Length - 1].ToString().ToUpper().Trim())
				{
				case "A":
				case "B":
				case "C":
				case "D":
				{
					StringBuilder stringBuilder = new StringBuilder();
					method_2();
					string string_ = string_0;
					foreach (char c in string_)
					{
						stringBuilder.Append(hashtable_0[c].ToString());
						stringBuilder.Append("0");
					}
					stringBuilder.Remove(stringBuilder.Length - 1, 1);
					return stringBuilder.ToString();
				}
				default:
					string_1 = BarcodeStrings.CodabarError;
					return null;
				}
			default:
				string_1 = BarcodeStrings.CodabarError;
				return null;
			}
		}

		private void method_2()
		{
			int num = 7;
			if (hashtable_0 == null)
			{
				hashtable_0 = new Hashtable();
				hashtable_0.Add('0', "101010011");
				hashtable_0.Add('1', "101011001");
				hashtable_0.Add('2', "101001011");
				hashtable_0.Add('3', "110010101");
				hashtable_0.Add('4', "101101001");
				hashtable_0.Add('5', "110101001");
				hashtable_0.Add('6', "100101011");
				hashtable_0.Add('7', "100101101");
				hashtable_0.Add('8', "100110101");
				hashtable_0.Add('9', "110100101");
				hashtable_0.Add('-', "101001101");
				hashtable_0.Add('$', "101100101");
				hashtable_0.Add(':', "1101011011");
				hashtable_0.Add('/', "1101101011");
				hashtable_0.Add('.', "1101101101");
				hashtable_0.Add('+', "101100110011");
				hashtable_0.Add('A', "1011001001");
				hashtable_0.Add('B', "1010010011");
				hashtable_0.Add('C', "1001001011");
				hashtable_0.Add('D', "1010011001");
				hashtable_0.Add('a', "1011001001");
				hashtable_0.Add('b', "1010010011");
				hashtable_0.Add('c', "1001001011");
				hashtable_0.Add('d', "1010011001");
			}
		}

		public override string vmethod_0()
		{
			return method_1();
		}
	}
}
