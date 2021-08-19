using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass624 : GClass620
	{
		private string string_0;

		private string string_1;

		public string method_0()
		{
			return string_0;
		}

		public string method_1()
		{
			return string_1;
		}

		public bool method_2()
		{
			return method_3();
		}

		public override string vmethod_1()
		{
			StringBuilder stringBuilder = new StringBuilder(30);
			GClass620.smethod_0(string_1, stringBuilder);
			GClass620.smethod_0(string_0, stringBuilder);
			return stringBuilder.ToString();
		}

		public GClass624(string string_2, string string_3)
			: base(GClass660.gclass660_3)
		{
			string_0 = smethod_2(string_2);
			string_1 = string_3;
		}

		private bool method_3()
		{
			int num = string_0.IndexOf(':');
			num++;
			int length;
			for (length = string_0.Length; num < length && string_0[num] == '/'; num++)
			{
			}
			int num2 = string_0.IndexOf('/', num);
			if (num2 < 0)
			{
				num2 = length;
			}
			int num3 = string_0.IndexOf('@', num);
			return num3 >= num && num3 < num2;
		}

		private static string smethod_2(string string_2)
		{
			int num = 18;
			int num2 = string_2.IndexOf(':');
			string_2 = ((num2 < 0) ? ("http://" + string_2) : ((!smethod_3(string_2, num2)) ? (string_2.Substring(0, num2).ToLower() + string_2.Substring(num2)) : ("http://" + string_2)));
			return string_2;
		}

		private static bool smethod_3(string string_2, int int_0)
		{
			int num = string_2.IndexOf('/', int_0 + 1);
			if (num < 0)
			{
				num = string_2.Length;
			}
			if (num <= int_0 + 1)
			{
				return false;
			}
			int num2 = int_0 + 1;
			while (true)
			{
				if (num2 < num)
				{
					if (string_2[num2] < '0' || string_2[num2] > '9')
					{
						break;
					}
					num2++;
					continue;
				}
				return true;
			}
			return false;
		}
	}
}
