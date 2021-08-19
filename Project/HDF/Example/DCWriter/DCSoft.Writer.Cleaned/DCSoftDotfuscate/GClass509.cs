using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass509 : GClass504
	{
		private const string string_0 = "%()<>[]{}/#";

		private string string_1 = null;

		public GClass509(string string_2)
		{
			string_1 = string_2;
		}

		public string method_8()
		{
			return string_1;
		}

		public void method_9(string string_2)
		{
			string_1 = string_2;
		}

		protected override void vmethod_1(StreamWriter streamWriter_0)
		{
			streamWriter_0.Write("/" + method_10(string_1));
		}

		private static bool smethod_0(char char_0)
		{
			return "%()<>[]{}/#".IndexOf(char_0) >= 0;
		}

		private string method_10(string string_2)
		{
			int num = 3;
			StringBuilder stringBuilder = new StringBuilder();
			foreach (char c in string_2)
			{
				if (smethod_0(c) || c < '!' || c > '~')
				{
					stringBuilder.Append("@" + Class206.smethod_2(c));
				}
				else
				{
					stringBuilder.Append(c);
				}
			}
			return stringBuilder.ToString();
		}

		public override string ToString()
		{
			return "Name:" + method_8();
		}
	}
}
