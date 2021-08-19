using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass197 : GClass163
	{
		private string string_0;

		public override string TagName => "title";

		public override string vmethod_7()
		{
			return string_0;
		}

		public override void vmethod_8(string string_1)
		{
			string_0 = string_1;
		}

		public override string vmethod_4()
		{
			return string_0;
		}

		public override void vmethod_5(string string_1)
		{
			string_0 = string_1;
		}

		protected override bool vmethod_6()
		{
			return true;
		}
	}
}
