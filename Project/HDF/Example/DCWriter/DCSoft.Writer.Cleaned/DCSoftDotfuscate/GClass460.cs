using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public abstract class GClass460 : GClass459
	{
		private GClass476 gclass476_0;

		protected internal string Name => method_4().Name;

		public GClass460(GClass476 gclass476_1)
		{
			gclass476_0 = gclass476_1;
		}

		public virtual string vmethod_3(string string_0)
		{
			return "(" + Class206.smethod_1(string_0) + ")";
		}

		public override void vmethod_2()
		{
			int num = 1;
			method_3().method_9("Type", "Font");
			method_3().method_9("Subtype", vmethod_4());
			if (Name != null)
			{
				method_3().method_9("Name", Name);
			}
			method_3().method_9("BaseFont", vmethod_5());
		}

		protected internal GClass476 method_4()
		{
			return gclass476_0;
		}

		protected internal Font method_5()
		{
			return method_4().method_4();
		}

		protected internal GClass478 method_6()
		{
			return method_4().method_1();
		}

		public abstract string vmethod_4();

		public abstract string vmethod_5();
	}
}
