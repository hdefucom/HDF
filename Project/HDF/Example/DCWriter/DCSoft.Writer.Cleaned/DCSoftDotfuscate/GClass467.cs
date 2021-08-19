using System.Collections;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	[DefaultMember("Item")]
	public class GClass467 : GClass466
	{
		private ArrayList arrayList_0 = new ArrayList();

		public GClass467(GClass466 gclass466_1)
			: base(gclass466_1)
		{
			method_12();
		}

		public int method_7()
		{
			return arrayList_0.Count;
		}

		public int method_8()
		{
			int num = 0;
			foreach (GClass466 item in arrayList_0)
			{
				num = ((!(item is GClass467)) ? (num + 1) : (num + ((GClass467)item).method_8()));
			}
			return num;
		}

		public GClass466 method_9(int int_0)
		{
			return (GClass466)arrayList_0[int_0];
		}

		private GClass513 method_10()
		{
			GClass513 gClass = new GClass513();
			foreach (GClass466 item in arrayList_0)
			{
				gClass.method_9(item.method_3());
			}
			return gClass;
		}

		protected override void vmethod_0(GClass540 gclass540_0)
		{
			foreach (GClass466 item in arrayList_0)
			{
				item.method_1(gclass540_0);
			}
		}

		protected override void vmethod_1(StreamWriter streamWriter_0)
		{
			foreach (GClass466 item in arrayList_0)
			{
				item.method_2(streamWriter_0);
			}
		}

		public override void vmethod_2()
		{
			method_3().method_8("Type", new GClass509("Pages"));
			method_3().method_8("Kids", method_10());
			method_3().method_8("Count", new GClass507(method_8()));
			base.vmethod_2();
			foreach (GClass466 item in arrayList_0)
			{
				item.vmethod_2();
			}
		}

		public GClass467 method_11()
		{
			GClass467 gClass = new GClass467(this);
			arrayList_0.Add(gClass);
			return gClass;
		}

		public GClass468 method_12()
		{
			GClass468 gClass = new GClass468(this);
			arrayList_0.Add(gClass);
			return gClass;
		}

		public void method_13()
		{
			arrayList_0.Clear();
		}

		public GClass468 method_14(ref int int_0)
		{
			int num = 0;
			GClass468 gClass;
			while (true)
			{
				if (num < method_7())
				{
					if (method_9(num) is GClass468)
					{
						int_0--;
						if (int_0 < 0)
						{
							return method_9(num) as GClass468;
						}
					}
					else
					{
						gClass = ((GClass467)method_9(num)).method_14(ref int_0);
						if (gClass != null)
						{
							break;
						}
					}
					num++;
					continue;
				}
				return null;
			}
			return gClass;
		}
	}
}
