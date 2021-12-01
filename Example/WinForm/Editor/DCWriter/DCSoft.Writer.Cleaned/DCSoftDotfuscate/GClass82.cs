using System.Collections;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass82 : GClass80
	{
		public GClass82(GInterface13 ginterface13_1, string string_1)
			: base(ginterface13_1, string_1)
		{
		}

		public GClass82(GInterface13 ginterface13_1, string string_1, IList ilist_1)
			: base(ginterface13_1, string_1, ilist_1)
		{
		}

		public GClass82(GInterface13 ginterface13_1, string string_1, object object_1)
			: base(ginterface13_1, string_1, object_1)
		{
		}

		protected override object vmethod_0(object object_1)
		{
			return ginterface13_0.imethod_8(object_1);
		}

		public object method_5()
		{
			object obj = method_0();
			if (int_0 >= method_3() && method_3() == 1)
			{
				return ginterface13_0.imethod_7(obj);
			}
			return obj;
		}
	}
}
