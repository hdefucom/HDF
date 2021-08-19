using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass623 : GClass620
	{
		public const int int_0 = -1;

		public const int int_1 = 0;

		public const int int_2 = 1;

		public const int int_3 = 2;

		private string string_0;

		private string string_1;

		private int int_4;

		public string method_0()
		{
			return string_0;
		}

		public string method_1()
		{
			return string_1;
		}

		public int method_2()
		{
			return int_4;
		}

		public override string vmethod_1()
		{
			if (string_0 == null)
			{
				return string_1;
			}
			return string_0 + '\n' + string_1;
		}

		internal GClass623(int int_5, string string_2, string string_3)
			: base(GClass660.gclass660_10)
		{
			int_4 = int_5;
			string_1 = string_2;
			string_0 = string_3;
		}
	}
}
