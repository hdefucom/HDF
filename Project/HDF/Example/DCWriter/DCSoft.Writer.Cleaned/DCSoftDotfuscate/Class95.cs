using DCSoft.Barcode;
using System;
using System.Collections;
using System.Text;

namespace DCSoftDotfuscate
{
	internal class Class95 : Class84
	{
		private static Hashtable hashtable_0 = null;

		private static Hashtable hashtable_1 = null;

		private bool bool_0 = false;

		public Class95(string string_2)
		{
			string_0 = string_2;
		}

		public Class95(string string_2, bool bool_1)
		{
			string_0 = string_2;
			bool_0 = bool_1;
		}

		private string method_1()
		{
			int num = 13;
			string_1 = null;
			method_2();
			method_3();
			string text = string_0;
			if (bool_0)
			{
				text = method_4(text);
			}
			if (string_1 != null)
			{
				return null;
			}
			string str = hashtable_0['*'].ToString();
			str += "0";
			string text2 = text;
			int num2 = 0;
			while (true)
			{
				if (num2 < text2.Length)
				{
					char c = text2[num2];
					if (!hashtable_0.ContainsKey(c))
					{
						break;
					}
					str += hashtable_0[c].ToString();
					str += "0";
					num2++;
					continue;
				}
				return str + hashtable_0['*'].ToString();
			}
			string_1 = BarcodeStrings.Code39InvaliData;
			return null;
		}

		private void method_2()
		{
			int num = 18;
			if (hashtable_0 == null)
			{
				hashtable_0 = new Hashtable();
				hashtable_0.Add('0', "101001101101");
				hashtable_0.Add('1', "110100101011");
				hashtable_0.Add('2', "101100101011");
				hashtable_0.Add('3', "110110010101");
				hashtable_0.Add('4', "101001101011");
				hashtable_0.Add('5', "110100110101");
				hashtable_0.Add('6', "101100110101");
				hashtable_0.Add('7', "101001011011");
				hashtable_0.Add('8', "110100101101");
				hashtable_0.Add('9', "101100101101");
				hashtable_0.Add('A', "110101001011");
				hashtable_0.Add('B', "101101001011");
				hashtable_0.Add('C', "110110100101");
				hashtable_0.Add('D', "101011001011");
				hashtable_0.Add('E', "110101100101");
				hashtable_0.Add('F', "101101100101");
				hashtable_0.Add('G', "101010011011");
				hashtable_0.Add('H', "110101001101");
				hashtable_0.Add('I', "101101001101");
				hashtable_0.Add('J', "101011001101");
				hashtable_0.Add('K', "110101010011");
				hashtable_0.Add('L', "101101010011");
				hashtable_0.Add('M', "110110101001");
				hashtable_0.Add('N', "101011010011");
				hashtable_0.Add('O', "110101101001");
				hashtable_0.Add('P', "101101101001");
				hashtable_0.Add('Q', "101010110011");
				hashtable_0.Add('R', "110101011001");
				hashtable_0.Add('S', "101101011001");
				hashtable_0.Add('T', "101011011001");
				hashtable_0.Add('U', "110010101011");
				hashtable_0.Add('V', "100110101011");
				hashtable_0.Add('W', "110011010101");
				hashtable_0.Add('X', "100101101011");
				hashtable_0.Add('Y', "110010110101");
				hashtable_0.Add('Z', "100110110101");
				hashtable_0.Add('-', "100101011011");
				hashtable_0.Add('.', "110010101101");
				hashtable_0.Add(' ', "100110101101");
				hashtable_0.Add('$', "100100100101");
				hashtable_0.Add('/', "100100101001");
				hashtable_0.Add('+', "100101001001");
				hashtable_0.Add('%', "101001001001");
				hashtable_0.Add('*', "100101101101");
			}
		}

		private void method_3()
		{
			int num = 6;
			if (hashtable_1 == null)
			{
				hashtable_1 = new Hashtable();
				hashtable_1.Add(Convert.ToChar(0).ToString(), "%U");
				hashtable_1.Add(Convert.ToChar(1).ToString(), "$A");
				hashtable_1.Add(Convert.ToChar(2).ToString(), "$B");
				hashtable_1.Add(Convert.ToChar(3).ToString(), "$C");
				hashtable_1.Add(Convert.ToChar(4).ToString(), "$D");
				hashtable_1.Add(Convert.ToChar(5).ToString(), "$E");
				hashtable_1.Add(Convert.ToChar(6).ToString(), "$F");
				hashtable_1.Add(Convert.ToChar(7).ToString(), "$G");
				hashtable_1.Add(Convert.ToChar(8).ToString(), "$H");
				hashtable_1.Add(Convert.ToChar(9).ToString(), "$I");
				hashtable_1.Add(Convert.ToChar(10).ToString(), "$J");
				hashtable_1.Add(Convert.ToChar(11).ToString(), "$K");
				hashtable_1.Add(Convert.ToChar(12).ToString(), "$L");
				hashtable_1.Add(Convert.ToChar(13).ToString(), "$M");
				hashtable_1.Add(Convert.ToChar(14).ToString(), "$N");
				hashtable_1.Add(Convert.ToChar(15).ToString(), "$O");
				hashtable_1.Add(Convert.ToChar(16).ToString(), "$P");
				hashtable_1.Add(Convert.ToChar(17).ToString(), "$Q");
				hashtable_1.Add(Convert.ToChar(18).ToString(), "$R");
				hashtable_1.Add(Convert.ToChar(19).ToString(), "$S");
				hashtable_1.Add(Convert.ToChar(20).ToString(), "$T");
				hashtable_1.Add(Convert.ToChar(21).ToString(), "$U");
				hashtable_1.Add(Convert.ToChar(22).ToString(), "$V");
				hashtable_1.Add(Convert.ToChar(23).ToString(), "$W");
				hashtable_1.Add(Convert.ToChar(24).ToString(), "$X");
				hashtable_1.Add(Convert.ToChar(25).ToString(), "$Y");
				hashtable_1.Add(Convert.ToChar(26).ToString(), "$Z");
				hashtable_1.Add(Convert.ToChar(27).ToString(), "%A");
				hashtable_1.Add(Convert.ToChar(28).ToString(), "%B");
				hashtable_1.Add(Convert.ToChar(29).ToString(), "%C");
				hashtable_1.Add(Convert.ToChar(30).ToString(), "%D");
				hashtable_1.Add(Convert.ToChar(31).ToString(), "%E");
				hashtable_1.Add("!", "/A");
				hashtable_1.Add("\"", "/B");
				hashtable_1.Add("#", "/C");
				hashtable_1.Add("$", "/D");
				hashtable_1.Add("%", "/E");
				hashtable_1.Add("&", "/F");
				hashtable_1.Add("'", "/G");
				hashtable_1.Add("(", "/H");
				hashtable_1.Add(")", "/I");
				hashtable_1.Add("*", "/J");
				hashtable_1.Add("+", "/K");
				hashtable_1.Add(",", "/L");
				hashtable_1.Add("/", "/O");
				hashtable_1.Add(":", "/Z");
				hashtable_1.Add(";", "%F");
				hashtable_1.Add("<", "%G");
				hashtable_1.Add("=", "%H");
				hashtable_1.Add(">", "%I");
				hashtable_1.Add("?", "%J");
				hashtable_1.Add("[", "%K");
				hashtable_1.Add("\\", "%L");
				hashtable_1.Add("]", "%M");
				hashtable_1.Add("^", "%N");
				hashtable_1.Add("_", "%O");
				hashtable_1.Add("{", "%P");
				hashtable_1.Add("|", "%Q");
				hashtable_1.Add("}", "%R");
				hashtable_1.Add("~", "%S");
				hashtable_1.Add("`", "%W");
				hashtable_1.Add("@", "%V");
				hashtable_1.Add("a", "+A");
				hashtable_1.Add("b", "+B");
				hashtable_1.Add("c", "+C");
				hashtable_1.Add("d", "+D");
				hashtable_1.Add("e", "+E");
				hashtable_1.Add("f", "+F");
				hashtable_1.Add("g", "+G");
				hashtable_1.Add("h", "+H");
				hashtable_1.Add("i", "+I");
				hashtable_1.Add("j", "+J");
				hashtable_1.Add("k", "+K");
				hashtable_1.Add("l", "+L");
				hashtable_1.Add("m", "+M");
				hashtable_1.Add("n", "+N");
				hashtable_1.Add("o", "+O");
				hashtable_1.Add("p", "+P");
				hashtable_1.Add("q", "+Q");
				hashtable_1.Add("r", "+R");
				hashtable_1.Add("s", "+S");
				hashtable_1.Add("t", "+T");
				hashtable_1.Add("u", "+U");
				hashtable_1.Add("v", "+V");
				hashtable_1.Add("w", "+W");
				hashtable_1.Add("x", "+X");
				hashtable_1.Add("y", "+Y");
				hashtable_1.Add("z", "+Z");
				hashtable_1.Add(Convert.ToChar(127).ToString(), "%T");
			}
		}

		private string method_4(string string_2)
		{
			StringBuilder stringBuilder = new StringBuilder();
			string string_3 = string_0;
			int num = 0;
			while (true)
			{
				if (num < string_3.Length)
				{
					char c = string_3[num];
					if (hashtable_0.ContainsKey(c))
					{
						stringBuilder.Append(c.ToString());
					}
					else
					{
						if (!hashtable_1.ContainsKey(c.ToString()))
						{
							break;
						}
						stringBuilder.Append(hashtable_1[c.ToString()].ToString());
					}
					num++;
					continue;
				}
				return stringBuilder.ToString();
			}
			string_1 = BarcodeStrings.Code39InvaliData;
			return null;
		}

		public override string vmethod_0()
		{
			return method_1();
		}
	}
}
