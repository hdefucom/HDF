using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public abstract class GClass455 : GClass454
	{
		private string string_0 = null;

		public string Name => string_0;

		public GClass455(string string_1)
		{
			string_0 = string_1;
		}

		public override void vmethod_2()
		{
			method_4().method_9("Type", "XObject");
			method_4().method_9("Name", string_0);
			base.vmethod_2();
		}

		public abstract float vmethod_3();

		public abstract float vmethod_4();
	}
}
