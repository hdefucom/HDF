using DCSoft.TDCode;
using System.Collections;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass612 : GClass611, GInterface54
	{
		private static readonly GClass645[] gclass645_0 = new GClass645[0];

		public GClass645[] imethod_2(GClass616 gclass616_0)
		{
			return imethod_3(gclass616_0, null);
		}

		public GClass645[] imethod_3(GClass616 gclass616_0, Hashtable hashtable_0)
		{
			ArrayList arrayList = ArrayList.Synchronized(new ArrayList(10));
			GClass663[] array = new GClass666(gclass616_0.method_2()).method_3(hashtable_0);
			for (int i = 0; i < array.Length; i++)
			{
				try
				{
					GClass678 gClass = vmethod_0().method_1(array[i].method_0());
					GClass639[] gclass639_ = array[i].method_1();
					GClass645 gClass2 = new GClass645(gClass.method_1(), gClass.method_0(), gclass639_, BarcodeFormat.barcodeFormat_0);
					if (gClass.method_2() != null)
					{
						gClass2.method_5(GClass664.gclass664_2, gClass.method_2());
					}
					if (gClass.method_3() != null)
					{
						gClass2.method_5(GClass664.gclass664_3, gClass.method_3().ToString());
					}
					arrayList.Add(gClass2);
				}
				catch (GException25)
				{
				}
			}
			if (arrayList.Count == 0)
			{
				return gclass645_0;
			}
			GClass645[] array2 = new GClass645[arrayList.Count];
			for (int i = 0; i < arrayList.Count; i++)
			{
				array2[i] = (GClass645)arrayList[i];
			}
			return array2;
		}
	}
}
