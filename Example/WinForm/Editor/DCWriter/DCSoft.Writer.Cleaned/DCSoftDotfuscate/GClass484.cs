using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	[DefaultMember("Item")]
	public class GClass484 : GClass480
	{
		private GStruct21[] gstruct21_0;

		public GClass484(GClass478 gclass478_1)
			: base(gclass478_1)
		{
		}

		protected override void vmethod_0(GClass498 gclass498_0)
		{
			int num = Math.Max(method_5().method_13().method_6(), method_5().method_14().method_8());
			gstruct21_0 = new GStruct21[num];
			for (int i = 0; i < method_5().method_14().method_8(); i++)
			{
				gstruct21_0[i].ushort_0 = gclass498_0.method_7();
				gstruct21_0[i].short_0 = gclass498_0.method_8();
			}
			ushort ushort_ = gstruct21_0[method_5().method_14().method_8() - 1].ushort_0;
			for (int i = method_5().method_14().method_8(); i < num; i++)
			{
				gstruct21_0[i].ushort_0 = ushort_;
				gstruct21_0[i].short_0 = gclass498_0.method_8();
			}
		}

		protected override void vmethod_1(GClass498 gclass498_0)
		{
			int num = Math.Max(method_5().method_13().method_6(), method_5().method_14().method_8());
			for (int i = 0; i < method_5().method_14().method_8(); i++)
			{
				gclass498_0.method_21(gstruct21_0[i].ushort_0);
				gclass498_0.method_22(gstruct21_0[i].short_0);
			}
			for (int i = method_5().method_14().method_8(); i < num; i++)
			{
				gclass498_0.method_22(gstruct21_0[i].short_0);
			}
		}

		protected override void vmethod_2(GClass480 gclass480_0, GClass479 gclass479_0)
		{
			GClass484 gClass = gclass480_0 as GClass484;
			gstruct21_0 = new GStruct21[gClass.gstruct21_0.Length];
			gClass.gstruct21_0.CopyTo(gstruct21_0, 0);
		}

		protected internal override string vmethod_3()
		{
			return "hmtx";
		}

		public int method_6()
		{
			return gstruct21_0.Length;
		}

		public GStruct21 method_7(ushort ushort_0)
		{
			return gstruct21_0[ushort_0];
		}

		public override int vmethod_4()
		{
			return GStruct21.smethod_0() * method_6();
		}
	}
}
