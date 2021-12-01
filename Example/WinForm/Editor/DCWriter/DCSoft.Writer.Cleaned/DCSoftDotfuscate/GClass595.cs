using DCSoft.TDCode;
using System.Collections;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass595 : GClass594
	{
		private ArrayList arrayList_0;

		public GClass595(Hashtable hashtable_0)
		{
			ArrayList arrayList = (hashtable_0 == null) ? null : ((ArrayList)hashtable_0[GClass633.gclass633_2]);
			bool bool_ = hashtable_0 != null && hashtable_0[GClass633.gclass633_5] != null;
			arrayList_0 = ArrayList.Synchronized(new ArrayList(10));
			if (arrayList != null)
			{
				if (arrayList.Contains(BarcodeFormat.barcodeFormat_5) || arrayList.Contains(BarcodeFormat.barcodeFormat_3) || arrayList.Contains(BarcodeFormat.barcodeFormat_4) || arrayList.Contains(BarcodeFormat.barcodeFormat_2))
				{
					arrayList_0.Add(new GClass602(hashtable_0));
				}
				if (arrayList.Contains(BarcodeFormat.barcodeFormat_7))
				{
					arrayList_0.Add(new GClass604(bool_));
				}
				if (arrayList.Contains(BarcodeFormat.barcodeFormat_6))
				{
					arrayList_0.Add(new GClass596());
				}
				if (arrayList.Contains(BarcodeFormat.barcodeFormat_8))
				{
					arrayList_0.Add(new GClass603());
				}
			}
			if (arrayList_0.Count == 0)
			{
				arrayList_0.Add(new GClass602(hashtable_0));
				arrayList_0.Add(new GClass604());
				arrayList_0.Add(new GClass596());
				arrayList_0.Add(new GClass603());
			}
		}

		public override GClass645 vmethod_0(int int_2, GClass659 gclass659_0, Hashtable hashtable_0)
		{
			int count = arrayList_0.Count;
			for (int i = 0; i < count; i++)
			{
				GClass594 gClass = (GClass594)arrayList_0[i];
				try
				{
					return gClass.vmethod_0(int_2, gclass659_0, hashtable_0);
				}
				catch (GException25)
				{
				}
			}
			throw GException25.smethod_0();
		}
	}
}
