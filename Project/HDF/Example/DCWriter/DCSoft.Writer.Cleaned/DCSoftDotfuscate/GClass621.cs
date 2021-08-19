using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass621 : GClass620
	{
		private string string_0;

		private string string_1;

		private string string_2;

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

		public override string vmethod_1()
		{
			StringBuilder stringBuilder = new StringBuilder(20);
			GClass620.smethod_0(string_0, stringBuilder);
			GClass620.smethod_0(string_2, stringBuilder);
			return stringBuilder.ToString();
		}

		public GClass621(string string_3, string string_4, string string_5)
			: base(GClass660.gclass660_7)
		{
			string_0 = string_3;
			string_1 = string_4;
			string_2 = string_5;
		}
	}
}
