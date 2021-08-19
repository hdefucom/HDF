using DCSoft.TDCode;
using System.Collections;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass602 : GClass594
	{
		private ArrayList arrayList_0;

		public GClass602(Hashtable hashtable_0)
		{
			ArrayList arrayList = (hashtable_0 == null) ? null : ((ArrayList)hashtable_0[GClass633.gclass633_2]);
			arrayList_0 = ArrayList.Synchronized(new ArrayList(10));
			if (arrayList != null)
			{
				if (arrayList.Contains(BarcodeFormat.barcodeFormat_5))
				{
					arrayList_0.Add(new GClass599());
				}
				else if (arrayList.Contains(BarcodeFormat.barcodeFormat_3))
				{
					arrayList_0.Add(new GClass600());
				}
				if (arrayList.Contains(BarcodeFormat.barcodeFormat_4))
				{
					arrayList_0.Add(new GClass598());
				}
				if (arrayList.Contains(BarcodeFormat.barcodeFormat_2))
				{
					arrayList_0.Add(new GClass601());
				}
			}
			if (arrayList_0.Count == 0)
			{
				arrayList_0.Add(new GClass599());
				arrayList_0.Add(new GClass598());
				arrayList_0.Add(new GClass601());
			}
		}

		public override GClass645 vmethod_0(int int_2, GClass659 gclass659_0, Hashtable hashtable_0)
		{
			int[] int_3 = GClass597.smethod_2(gclass659_0);
			int count = arrayList_0.Count;
			int num = 0;
			GClass645 gClass2;
			while (true)
			{
				if (num < count)
				{
					GClass597 gClass = (GClass597)arrayList_0[num];
					try
					{
						gClass2 = gClass.vmethod_2(int_2, gclass659_0, int_3, hashtable_0);
					}
					catch (GException25)
					{
						goto IL_003a;
					}
					break;
				}
				throw GException25.smethod_0();
				IL_003a:
				num++;
			}
			if (gClass2.method_3().Equals(BarcodeFormat.barcodeFormat_5) && gClass2.method_0()[0] == '0')
			{
				return new GClass645(gClass2.method_0().Substring(1), null, gClass2.method_2(), BarcodeFormat.barcodeFormat_3);
			}
			return gClass2;
		}
	}
}
