using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass628 : GClass620
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

		public override string vmethod_1()
		{
			return string_0;
		}

		public GClass628(string string_2, string string_3)
			: base(GClass660.gclass660_4)
		{
			string_0 = string_2;
			string_1 = string_3;
		}
	}
}
