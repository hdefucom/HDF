using System.Collections;
using System.Reflection;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[DefaultMember("Item")]
	[ComVisible(false)]
	public class GClass488 : GClass480
	{
		private GClass492[] gclass492_0;

		private ArrayList arrayList_0 = new ArrayList();

		public GClass488(GClass478 gclass478_1)
			: base(gclass478_1)
		{
		}

		private void method_6(int int_0, GClass492 gclass492_1)
		{
			gclass492_0[int_0] = gclass492_1;
			if (gclass492_1 != null)
			{
				arrayList_0.Add(gclass492_1);
			}
		}

		protected override void vmethod_0(GClass498 gclass498_0)
		{
			gclass492_0 = new GClass492[method_5().method_13().method_6()];
			arrayList_0.Clear();
			int int_ = gclass498_0.vmethod_3();
			for (int i = 0; i < method_5().method_13().method_6(); i++)
			{
				uint num = method_5().method_18().method_7((ushort)i);
				uint num2 = method_5().method_18().method_7((ushort)(i + 1));
				if (num2 != num)
				{
					method_6(i, new GClass492((int)(num2 - num)));
					gclass498_0.method_27(int_);
					gclass498_0.method_26((int)num);
					gclass492_0[i].method_1(gclass498_0);
				}
			}
		}

		protected override void vmethod_1(GClass498 gclass498_0)
		{
			for (int i = 0; i < method_7(); i++)
			{
				method_8(i).method_2(gclass498_0);
			}
		}

		protected override void vmethod_2(GClass480 gclass480_0, GClass479 gclass479_0)
		{
			GClass488 gClass = gclass480_0 as GClass488;
			gclass492_0 = new GClass492[gClass.method_9().Length];
			arrayList_0.Clear();
			for (int i = 0; i < gclass479_0.ushort_0.Length; i++)
			{
				method_6(gclass479_0.ushort_0[i], gClass.method_9()[gclass479_0.ushort_0[i]]);
			}
		}

		protected internal override string vmethod_3()
		{
			return "glyf";
		}

		public int method_7()
		{
			return arrayList_0.Count;
		}

		public GClass492 method_8(int int_0)
		{
			return arrayList_0[int_0] as GClass492;
		}

		public GClass492[] method_9()
		{
			return gclass492_0;
		}

		public override int vmethod_4()
		{
			int num = 0;
			for (int i = 0; i < method_7(); i++)
			{
				num += method_8(i).method_4();
			}
			return num;
		}
	}
}
