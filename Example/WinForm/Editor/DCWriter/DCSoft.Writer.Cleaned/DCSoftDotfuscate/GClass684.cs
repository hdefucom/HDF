using DCSoft.TDCode;
using System.Collections;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass684 : GInterface50
	{
		private Hashtable hashtable_0;

		private ArrayList arrayList_0;

		public void method_0(Hashtable hashtable_1)
		{
			hashtable_0 = hashtable_1;
			bool flag = hashtable_1?.ContainsKey(GClass633.gclass633_3) ?? false;
			ArrayList arrayList = (hashtable_1 == null) ? null : ((ArrayList)hashtable_1[GClass633.gclass633_2]);
			arrayList_0 = ArrayList.Synchronized(new ArrayList(10));
			if (arrayList != null)
			{
				bool flag2;
				if ((flag2 = (arrayList.Contains(BarcodeFormat.barcodeFormat_3) || arrayList.Contains(BarcodeFormat.barcodeFormat_2) || arrayList.Contains(BarcodeFormat.barcodeFormat_5) || arrayList.Contains(BarcodeFormat.barcodeFormat_4) || arrayList.Contains(BarcodeFormat.barcodeFormat_7) || arrayList.Contains(BarcodeFormat.barcodeFormat_6) || arrayList.Contains(BarcodeFormat.barcodeFormat_8))) && !flag)
				{
					arrayList_0.Add(new GClass595(hashtable_1));
				}
				if (arrayList.Contains(BarcodeFormat.barcodeFormat_0))
				{
					arrayList_0.Add(new GClass611());
				}
				if (arrayList.Contains(BarcodeFormat.barcodeFormat_1))
				{
					arrayList_0.Add(new GClass637());
				}
				if (arrayList.Contains(BarcodeFormat.barcodeFormat_9))
				{
					arrayList_0.Add(new GClass661());
				}
				if (flag2 && flag)
				{
					arrayList_0.Add(new GClass595(hashtable_1));
				}
			}
			if (arrayList_0.Count == 0)
			{
				if (!flag)
				{
					arrayList_0.Add(new GClass595(hashtable_1));
				}
				arrayList_0.Add(new GClass611());
				if (flag)
				{
					arrayList_0.Add(new GClass595(hashtable_1));
				}
			}
		}

		public GClass645 imethod_0(GClass616 gclass616_0)
		{
			method_0(null);
			return method_2(gclass616_0);
		}

		public GClass645 imethod_1(GClass616 gclass616_0, Hashtable hashtable_1)
		{
			method_0(hashtable_1);
			return method_2(gclass616_0);
		}

		public GClass645 method_1(GClass616 gclass616_0)
		{
			if (arrayList_0 == null)
			{
				method_0(null);
			}
			return method_2(gclass616_0);
		}

		private GClass645 method_2(GClass616 gclass616_0)
		{
			int count = arrayList_0.Count;
			for (int i = 0; i < count; i++)
			{
				GInterface50 gInterface = (GInterface50)arrayList_0[i];
				try
				{
					return gInterface.imethod_1(gclass616_0, hashtable_0);
				}
				catch (GException25)
				{
				}
			}
			throw GException25.smethod_0();
		}
	}
}
