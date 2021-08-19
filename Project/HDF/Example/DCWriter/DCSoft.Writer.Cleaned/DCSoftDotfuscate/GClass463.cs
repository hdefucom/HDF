using System.Collections;
using System.IO;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass463 : GClass459
	{
		private GClass460 gclass460_0;

		private GClass464 gclass464_0;

		private GClass513 gclass513_0;

		public GClass463(GClass460 gclass460_1)
		{
			gclass460_0 = gclass460_1;
			gclass464_0 = new GClass464(gclass460_1);
			gclass513_0 = new GClass513();
			gclass513_0.method_16(2);
		}

		public GClass460 method_4()
		{
			return gclass460_0;
		}

		public GClass464 method_5()
		{
			return gclass464_0;
		}

		private void method_6(ArrayList arrayList_0)
		{
			if (arrayList_0.Count != 0)
			{
				GClass513 gClass = new GClass513();
				for (int i = 0; i < arrayList_0.Count; i++)
				{
					gClass.method_11((int)method_4().method_4().method_11((ushort)arrayList_0[i]));
				}
				gclass513_0.method_11((ushort)arrayList_0[0]);
				gclass513_0.method_9(gClass);
				arrayList_0.Clear();
			}
		}

		private void method_7()
		{
			ushort[] array = method_4().method_6().method_10(method_4().method_4().method_3().method_4());
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < array.Length; i++)
			{
				if (arrayList.Count > 0 && (ushort)arrayList[arrayList.Count - 1] + 1 != array[i])
				{
					method_6(arrayList);
				}
				arrayList.Add(array[i]);
			}
			method_6(arrayList);
		}

		protected override void vmethod_0(GClass540 gclass540_0)
		{
			base.vmethod_0(gclass540_0);
			gclass464_0.method_1(gclass540_0);
		}

		protected override void vmethod_1(StreamWriter streamWriter_0)
		{
			base.vmethod_1(streamWriter_0);
			gclass464_0.method_2(streamWriter_0);
		}

		public override void vmethod_2()
		{
			method_3().method_9("Type", "Font");
			method_3().method_9("Subtype", "CIDFontType2");
			method_3().method_9("BaseFont", method_4().vmethod_5());
			GClass514 gClass = new GClass514();
			gClass.method_8("Registry", new GClass510("Adobe"));
			gClass.method_8("Ordering", new GClass510("Identity"));
			gClass.method_10("Supplement", 0);
			method_3().method_8("CIDSystemInfo", gClass);
			method_3().method_8("FontDescriptor", gclass464_0.method_3());
			gclass464_0.vmethod_2();
			method_3().method_8("W", gclass513_0);
			method_7();
		}
	}
}
