using System.Collections;
using System.Reflection;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[DefaultMember("Item")]
	[ComVisible(false)]
	public class GClass494 : GClass493
	{
		private const ushort ushort_0 = 1;

		private const ushort ushort_1 = 8;

		private const ushort ushort_2 = 32;

		private const ushort ushort_3 = 64;

		private const ushort ushort_4 = 128;

		private ArrayList arrayList_0 = new ArrayList();

		private void method_2(GClass498 gclass498_0)
		{
			ushort num = 0;
			do
			{
				num = gclass498_0.method_2();
				arrayList_0.Add(gclass498_0.method_2());
				if ((num & 1) == 0)
				{
					gclass498_0.method_26(2);
				}
				else
				{
					gclass498_0.method_26(4);
				}
				if ((num & 8) != 0)
				{
					gclass498_0.method_26(2);
				}
				else if ((num & 0x40) != 0)
				{
					gclass498_0.method_26(4);
				}
				else if ((num & 0x80) != 0)
				{
					gclass498_0.method_26(8);
				}
			}
			while ((num & 0x20) != 0);
		}

		public override void vmethod_0(GClass498 gclass498_0, int int_0)
		{
			int int_ = gclass498_0.vmethod_3();
			method_2(gclass498_0);
			gclass498_0.method_27(int_);
			base.vmethod_0(gclass498_0, int_0);
		}

		public int method_3()
		{
			return arrayList_0.Count;
		}

		public ushort method_4(int int_0)
		{
			return (ushort)arrayList_0[int_0];
		}
	}
}
