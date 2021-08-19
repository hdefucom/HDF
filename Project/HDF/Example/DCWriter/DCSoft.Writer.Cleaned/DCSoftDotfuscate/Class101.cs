using DCSoft.Barcode;

namespace DCSoftDotfuscate
{
	internal class Class101 : Class84
	{
		private static readonly string[] string_2 = new string[10]
		{
			"NNWWN",
			"WNNNW",
			"NWNNW",
			"WWNNN",
			"NNWNW",
			"WNWNN",
			"NWWNN",
			"NNNWW",
			"WNNWN",
			"NWNWN"
		};

		public Class101(string string_3)
		{
			string_0 = string_3;
		}

		private string method_1()
		{
			int num = 5;
			string_1 = null;
			if (string_0.Length % 2 != 0)
			{
				string_1 = BarcodeStrings.I25InvaliData;
				return null;
			}
			if (!method_0(string_0))
			{
				string_1 = BarcodeStrings.I25InvaliData;
				return null;
			}
			string str = "1010";
			for (int i = 0; i < string_0.Length; i += 2)
			{
				bool flag = true;
				string text = string_2[int.Parse(string_0[i].ToString())];
				string text2 = string_2[int.Parse(string_0[i + 1].ToString())];
				string text3 = "";
				while (text.Length > 0)
				{
					text3 = text3 + text[0] + text2[0];
					text = text.Substring(1);
					text2 = text2.Substring(1);
				}
				string text4 = text3;
				foreach (char c in text4)
				{
					str = ((!flag) ? ((c != 'N') ? (str + "00") : (str + "0")) : ((c != 'N') ? (str + "11") : (str + "1")));
					flag = !flag;
				}
			}
			return str + "1101";
		}

		public override string vmethod_0()
		{
			return method_1();
		}
	}
}
