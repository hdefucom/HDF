using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass622 : GClass620
	{
		private string string_0;

		private string string_1;

		private string string_2;

		private string string_3;

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

		public override string vmethod_1()
		{
			StringBuilder stringBuilder = new StringBuilder(30);
			GClass620.smethod_0(string_0, stringBuilder);
			GClass620.smethod_0(string_1, stringBuilder);
			GClass620.smethod_0(string_2, stringBuilder);
			return stringBuilder.ToString();
		}

		internal GClass622(string string_4, string string_5, string string_6, string string_7)
			: base(GClass660.gclass660_1)
		{
			string_0 = string_4;
			string_1 = string_5;
			string_2 = string_6;
			string_3 = string_7;
		}
	}
}
