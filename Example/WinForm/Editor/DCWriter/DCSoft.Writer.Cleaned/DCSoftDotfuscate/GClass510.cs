using System.IO;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass510 : GClass504
	{
		private string string_0 = null;

		public GClass510(string string_1)
		{
			string_0 = string_1;
		}

		public string method_8()
		{
			return string_0;
		}

		public void method_9(string string_1)
		{
			string_0 = string_1;
		}

		protected override void vmethod_1(StreamWriter streamWriter_0)
		{
			streamWriter_0.Write("(" + Class206.smethod_1(string_0) + ")");
		}

		public override string ToString()
		{
			return "String:" + method_8();
		}
	}
}
