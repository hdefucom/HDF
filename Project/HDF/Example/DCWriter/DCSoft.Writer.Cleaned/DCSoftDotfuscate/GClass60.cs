using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass60 : GClass55
	{
		private string string_0;

		private GClass55[] gclass55_1;

		public GClass60(string string_1, GClass55[] gclass55_2)
		{
			string_0 = string_1;
			gclass55_1 = gclass55_2;
			GClass55[] array = gclass55_1;
			foreach (GClass55 gClass in array)
			{
				gClass.method_1(this);
			}
		}

		public string method_2()
		{
			return string_0;
		}

		public GClass55[] method_3()
		{
			return gclass55_1;
		}

		public override void vmethod_0(GClass75 gclass75_0)
		{
			gclass75_0.vmethod_4(this);
		}

		public override string ToString()
		{
			return "Function:" + method_2();
		}
	}
}
