using System;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass344 : IComparable
	{
		private string string_0 = null;

		private int int_0 = 1;

		private int int_1 = 1;

		private int int_2 = 0;

		private int int_3 = 0;

		private bool bool_0 = false;

		public GClass344()
		{
		}

		public GClass344(int int_4, int int_5)
		{
			int_0 = int_4;
			int_1 = int_5;
		}

		public GClass344(string string_1)
		{
			method_15(string_1);
		}

		public string method_0()
		{
			return string_0;
		}

		public void method_1(string string_1)
		{
			string_0 = string_1;
		}

		public int method_2()
		{
			return int_0;
		}

		public void method_3(int int_4)
		{
			int_0 = int_4;
		}

		public string method_4()
		{
			return int_0.ToString();
		}

		public void method_5(string string_1)
		{
			int_0 = Convert.ToInt32(string_1);
		}

		public int method_6()
		{
			return int_1;
		}

		public void method_7(int int_4)
		{
			int_1 = int_4;
		}

		public string method_8()
		{
			return smethod_3(int_1);
		}

		public void method_9(string string_1)
		{
			int_1 = smethod_5(string_1);
		}

		public int method_10()
		{
			return int_2;
		}

		public void method_11(int int_4)
		{
			int_2 = int_4;
		}

		public int method_12()
		{
			return int_3;
		}

		public void method_13(int int_4)
		{
			int_3 = int_4;
		}

		public string method_14()
		{
			int num = 0;
			string text;
			if (this.int_2 == 0 && int_3 == 0 && !bool_0)
			{
				text = smethod_1(int_0, int_1);
				if (method_0() == null || !string.IsNullOrEmpty(method_0()))
				{
					text = method_0() + "!" + text;
				}
				return text;
			}
			int num2 = Math.Min(int_0, int_0 + int_3);
			int num3 = Math.Min(int_1, int_1 + this.int_2);
			int int_ = num2 + Math.Abs(int_3);
			int int_2 = num3 + Math.Abs(this.int_2);
			text = smethod_1(num2, num3) + ":" + smethod_1(int_, int_2);
			if (!string.IsNullOrEmpty(method_0()))
			{
				text = method_0() + "!" + text;
			}
			return text;
		}

		public void method_15(string string_1)
		{
			int num = 0;
			if (string_1 == null || string.IsNullOrEmpty(string_1))
			{
				return;
			}
			int num2 = string_1.IndexOf("!");
			if (num2 >= 0)
			{
				method_1(string_1.Substring(0, num2).Trim());
				string_1 = string_1.Substring(num2 + 1);
			}
			num2 = string_1.IndexOf(":");
			if (num2 >= 0)
			{
				bool_0 = true;
				string string_2 = string_1.Substring(0, num2).Trim();
				string string_3 = string_1.Substring(num2 + 1).Trim();
				int_0 = smethod_4(string_2);
				int_1 = smethod_5(string_2);
				int num3 = smethod_4(string_3);
				int num4 = smethod_5(string_3);
				int_3 = Math.Abs(num3 - int_0);
				int_2 = Math.Abs(num4 - int_1);
				if (int_0 > num3)
				{
					int_0 = num3;
				}
				if (int_1 > num4)
				{
					int_1 = num4;
				}
			}
			else
			{
				bool_0 = false;
				int_0 = smethod_4(string_1);
				int_1 = smethod_5(string_1);
				int_2 = 0;
				int_3 = 0;
			}
		}

		public bool method_16()
		{
			return bool_0;
		}

		public bool method_17(int int_4, int int_5)
		{
			return int_4 >= int_0 && int_4 <= int_0 + int_3 && int_5 >= int_1 && int_5 <= int_1 + int_2;
		}

		public void method_18(int int_4, int int_5)
		{
			int_0 += int_4;
			int_1 += int_5;
		}

		public override string ToString()
		{
			return method_14();
		}

		public int CompareTo(object target)
		{
			GClass344 gClass = target as GClass344;
			if (gClass != null)
			{
				if (method_2() < gClass.method_2())
				{
					return -1;
				}
				if (method_2() == gClass.method_2())
				{
					return method_6() - gClass.method_6();
				}
				return 1;
			}
			return 0;
		}

		public bool method_19(GClass344 gclass344_0)
		{
			if (gclass344_0 != null && gclass344_0.method_2() >= method_2() && gclass344_0.method_6() >= method_6() && gclass344_0.method_2() + gclass344_0.method_12() <= method_2() + method_12() && gclass344_0.method_6() + gclass344_0.method_10() <= method_6() + method_10())
			{
				return true;
			}
			return false;
		}

		public static bool smethod_0(string string_1)
		{
			int num = 8;
			if (string_1 == null || string.IsNullOrEmpty(string_1))
			{
				return false;
			}
			int num2 = string_1.IndexOf("!");
			if (num2 >= 0)
			{
				string_1 = string_1.Substring(num2 + 1);
			}
			num2 = string_1.IndexOf(":");
			if (num2 > 0)
			{
				string string_2 = string_1.Substring(0, num2).Trim();
				string string_3 = string_1.Substring(num2 + 1).Trim();
				if (smethod_2(string_2) && smethod_2(string_3))
				{
					return true;
				}
				return false;
			}
			return smethod_2(string_1);
		}

		public static string smethod_1(int int_4, int int_5)
		{
			return smethod_3(int_5) + int_4;
		}

		public static bool smethod_2(string string_1)
		{
			if (string_1 == null || string.IsNullOrEmpty(string_1))
			{
				return false;
			}
			string_1 = string_1.ToUpper();
			int num = 0;
			int num2 = 0;
			bool result = true;
			string text = string_1;
			foreach (char c in text)
			{
				if (c >= 'A' && c <= 'Z')
				{
					if (num2 <= 0)
					{
						num++;
						if (num > 3)
						{
							result = false;
							break;
						}
						continue;
					}
					result = false;
					break;
				}
				if (c >= '0' && c <= '9')
				{
					if (num != 0)
					{
						num2++;
						if (num2 > 7)
						{
							result = false;
							break;
						}
						continue;
					}
					result = false;
					break;
				}
				result = false;
				break;
			}
			if (num == 0 || num2 == 0)
			{
				return false;
			}
			return result;
		}

		public static string smethod_3(int int_4)
		{
			int num = 17;
			StringBuilder stringBuilder = new StringBuilder();
			string text = "0ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			while (true)
			{
				int num2 = int_4 % 26;
				if (num2 != 0)
				{
					stringBuilder.Insert(0, text[num2]);
				}
				else
				{
					stringBuilder.Insert(0, "Z");
					num2 = 26;
				}
				if (int_4 <= 26)
				{
					break;
				}
				int_4 = (int_4 - num2) / 26;
			}
			return stringBuilder.ToString();
		}

		public static int smethod_4(string string_1)
		{
			if (string_1 == null || string_1.Length == 0)
			{
				return 1;
			}
			int num = 0;
			foreach (char c in string_1)
			{
				if (char.IsNumber(c))
				{
					num = num * 10 + c - 48;
				}
			}
			return num;
		}

		public static int smethod_5(string string_1)
		{
			if (string_1 == null || string_1.Length == 0)
			{
				return 1;
			}
			int num = 0;
			string_1 = string_1.ToUpper();
			string text = string_1;
			foreach (char c in text)
			{
				if (char.IsLetter(c))
				{
					num = num * 26 + c - 65 + 1;
				}
			}
			return num;
		}

		public static int smethod_6(string string_1)
		{
			if (string_1 == null || string_1.Length == 0)
			{
				return -1;
			}
			int num = 0;
			bool flag = false;
			foreach (char c in string_1)
			{
				if (char.IsNumber(c))
				{
					num = num * 10 + c - 48;
					flag = true;
				}
			}
			if (flag)
			{
				return num;
			}
			return -1;
		}

		public static int smethod_7(string string_1)
		{
			if (string_1 == null || string_1.Length == 0)
			{
				return -1;
			}
			int num = 0;
			bool flag = false;
			string_1 = string_1.ToUpper();
			string text = string_1;
			foreach (char c in text)
			{
				if (char.IsLetter(c))
				{
					num = num * 26 + c - 65 + 1;
					flag = true;
				}
			}
			if (flag)
			{
				return num;
			}
			return -1;
		}
	}
}
