using System.Collections;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass12 : GClass9
	{
		public override Size vmethod_2()
		{
			return Size.Empty;
		}

		public override IEnumerable vmethod_3()
		{
			return GClass288.smethod_2();
		}

		public override object vmethod_5(object object_1)
		{
			GClass288 gClass = (GClass288)object_1;
			return gClass.method_0();
		}
	}
}
