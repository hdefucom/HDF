using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass59 : GClass55
	{
		private string string_0;

		private GEnum3 genum3_0;

		public GClass59(string string_1, GEnum3 genum3_1)
		{
			string_0 = string_1;
			genum3_0 = genum3_1;
		}

		public string method_2()
		{
			return string_0;
		}

		public GEnum3 method_3()
		{
			return genum3_0;
		}

		public override void vmethod_0(GClass75 gclass75_0)
		{
			gclass75_0.vmethod_3(this);
		}

		public override string ToString()
		{
			return string.Concat("Value:", genum3_0, ":", string_0);
		}
	}
}
