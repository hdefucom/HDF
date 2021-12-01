using System.Collections;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass161
	{
		private int int_0 = 0;

		private int int_1 = 0;

		public GClass161()
		{
		}

		public GClass161(string string_0)
		{
			method_6(string_0);
		}

		public int method_0()
		{
			return int_0;
		}

		public void method_1(int int_2)
		{
			int_0 = int_2;
			method_4();
		}

		public int method_2()
		{
			return int_1;
		}

		public void method_3(int int_2)
		{
			int_1 = int_2;
			method_4();
		}

		private void method_4()
		{
			if (int_0 < 0)
			{
				int_0 = -int_0;
			}
			if (int_1 < 0)
			{
				int_1 = -int_1;
			}
			if (int_0 > int_1)
			{
				int num = int_0;
				int_0 = int_1;
				int_1 = num;
			}
		}

		public bool method_5(int int_2)
		{
			return int_2 >= int_0 && int_2 <= int_1;
		}

		public void method_6(string string_0)
		{
			int num = 6;
			int_0 = 0;
			int_1 = 0;
			if (string_0 == null || string_0.Trim().Length <= 0)
			{
				return;
			}
			string_0 = string_0.Trim();
			ArrayList arrayList = new ArrayList();
			int num2 = -1;
			string text = string_0;
			foreach (char value in text)
			{
				int num3 = "0123456789".IndexOf(value);
				if (num3 >= 0)
				{
					if (num2 == -1)
					{
						num2 = 0;
					}
					num2 = num2 * 10 + num3;
				}
				else if (num2 >= 0)
				{
					arrayList.Add(num2);
					num2 = -1;
				}
			}
			if (num2 >= 0)
			{
				arrayList.Add(num2);
			}
			if (arrayList.Count == 0)
			{
				int_0 = 0;
				int_1 = 0;
			}
			else if (arrayList.Count == 1)
			{
				int_0 = (int)arrayList[0];
				int_1 = int_0;
			}
			else
			{
				int_0 = (int)arrayList[0];
				int_1 = (int)arrayList[1];
			}
			method_4();
		}

		public override string ToString()
		{
			int num = 11;
			if (int_0 == int_1)
			{
				return int_0.ToString();
			}
			return int_0 + "-" + int_1;
		}
	}
}
