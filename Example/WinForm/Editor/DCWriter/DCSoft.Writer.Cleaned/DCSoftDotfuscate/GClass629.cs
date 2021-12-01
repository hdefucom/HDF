using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass629 : GClass620
	{
		private string string_0;

		private string string_1;

		private string string_2;

		private string string_3;

		private string string_4;

		private string string_5;

		public string method_0()
		{
			return string_0;
		}

		public string method_1()
		{
			return string_1;
		}

		public string method_2()
		{
			return string_2;
		}

		public string method_3()
		{
			return string_3;
		}

		public string method_4()
		{
			return string_4;
		}

		public string method_5()
		{
			return string_5;
		}

		public override string vmethod_1()
		{
			StringBuilder stringBuilder = new StringBuilder(100);
			GClass620.smethod_0(string_1, stringBuilder);
			GClass620.smethod_0(string_2, stringBuilder);
			GClass620.smethod_0(string_3, stringBuilder);
			GClass620.smethod_0(string_4, stringBuilder);
			GClass620.smethod_0(string_5, stringBuilder);
			return stringBuilder.ToString();
		}

		public GClass629(string string_6, string string_7, string string_8, string string_9, string string_10, string string_11)
			: base(GClass660.gclass660_8)
		{
			string_0 = string_6;
			string_1 = string_7;
			string_2 = string_8;
			string_3 = string_9;
			string_4 = string_10;
			string_5 = string_11;
		}
	}
}
