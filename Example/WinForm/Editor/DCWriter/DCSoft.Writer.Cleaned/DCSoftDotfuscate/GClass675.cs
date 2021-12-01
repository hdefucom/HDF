using System.Collections;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass675 : GInterface54
	{
		private const int int_0 = 30;

		private GInterface50 ginterface50_0;

		public GClass675(GInterface50 ginterface50_1)
		{
			ginterface50_0 = ginterface50_1;
		}

		public GClass645[] imethod_2(GClass616 gclass616_0)
		{
			return imethod_3(gclass616_0, null);
		}

		public GClass645[] imethod_3(GClass616 gclass616_0, Hashtable hashtable_0)
		{
			ArrayList arrayList = ArrayList.Synchronized(new ArrayList(10));
			method_0(gclass616_0, hashtable_0, arrayList, 0, 0);
			if (arrayList.Count == 0)
			{
				throw GException25.smethod_0();
			}
			int count = arrayList.Count;
			GClass645[] array = new GClass645[count];
			for (int i = 0; i < count; i++)
			{
				array[i] = (GClass645)arrayList[i];
			}
			return array;
		}

		private void method_0(GClass616 gclass616_0, Hashtable hashtable_0, ArrayList arrayList_0, int int_1, int int_2)
		{
			GClass645 gClass;
			try
			{
				gClass = ginterface50_0.imethod_1(gclass616_0, hashtable_0);
			}
			catch (GException25)
			{
				return;
			}
			bool flag = false;
			for (int i = 0; i < arrayList_0.Count; i++)
			{
				GClass645 gClass2 = (GClass645)arrayList_0[i];
				if (gClass2.method_0().Equals(gClass.method_0()))
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				return;
			}
			arrayList_0.Add(smethod_0(gClass, int_1, int_2));
			GClass639[] array = gClass.method_2();
			if (array == null || array.Length == 0)
			{
				return;
			}
			int num = gclass616_0.method_0();
			int num2 = gclass616_0.method_1();
			float num3 = num;
			float num4 = num2;
			float num5 = 0f;
			float num6 = 0f;
			foreach (GClass639 gClass3 in array)
			{
				float num7 = gClass3.vmethod_0();
				float num8 = gClass3.vmethod_1();
				if (num7 < num3)
				{
					num3 = num7;
				}
				if (num8 < num4)
				{
					num4 = num8;
				}
				if (num7 > num5)
				{
					num5 = num7;
				}
				if (num8 > num6)
				{
					num6 = num8;
				}
			}
			if (num3 > 30f)
			{
				method_0(gclass616_0.method_6(0, 0, (int)num3, num2), hashtable_0, arrayList_0, int_1, int_2);
			}
			if (num4 > 30f)
			{
				method_0(gclass616_0.method_6(0, 0, num, (int)num4), hashtable_0, arrayList_0, int_1, int_2);
			}
			if (num5 < (float)(num - 30))
			{
				method_0(gclass616_0.method_6((int)num5, 0, num - (int)num5, num2), hashtable_0, arrayList_0, int_1 + (int)num5, int_2);
			}
			if (num6 < (float)(num2 - 30))
			{
				method_0(gclass616_0.method_6(0, (int)num6, num, num2 - (int)num6), hashtable_0, arrayList_0, int_1, int_2 + (int)num6);
			}
		}

		private static GClass645 smethod_0(GClass645 gclass645_0, int int_1, int int_2)
		{
			GClass639[] array = gclass645_0.method_2();
			GClass639[] array2 = new GClass639[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				GClass639 gClass = array[i];
				array2[i] = new GClass639(gClass.vmethod_0() + (float)int_1, gClass.vmethod_1() + (float)int_2);
			}
			return new GClass645(gclass645_0.method_0(), gclass645_0.method_1(), array2, gclass645_0.method_3());
		}
	}
}
