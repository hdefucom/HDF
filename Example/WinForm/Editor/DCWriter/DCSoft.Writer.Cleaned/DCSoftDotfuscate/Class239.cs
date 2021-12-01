using System.Collections;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	internal sealed class Class239 : Class235
	{
		public static GClass631 smethod_17(GClass645 gclass645_0)
		{
			int num = 10;
			string text = gclass645_0.method_0();
			if (!(text?.StartsWith("BIZCARD:") ?? false))
			{
				return null;
			}
			string string_ = Class235.smethod_16("N:", text, bool_0: true);
			string string_2 = Class235.smethod_16("X:", text, bool_0: true);
			string string_3 = smethod_19(string_, string_2);
			string string_4 = Class235.smethod_16("T:", text, bool_0: true);
			string string_5 = Class235.smethod_16("C:", text, bool_0: true);
			string[] string_6 = Class235.smethod_15("A:", text, bool_0: true);
			string string_7 = Class235.smethod_16("B:", text, bool_0: true);
			string string_8 = Class235.smethod_16("M:", text, bool_0: true);
			string string_9 = Class235.smethod_16("F:", text, bool_0: true);
			string string_10 = Class235.smethod_16("E:", text, bool_0: true);
			return new GClass631(GClass608.smethod_3(string_3), null, smethod_18(string_7, string_8, string_9), GClass608.smethod_3(string_10), null, string_6, string_5, null, string_4, null);
		}

		private static string[] smethod_18(string string_0, string string_1, string string_2)
		{
			ArrayList arrayList = ArrayList.Synchronized(new ArrayList(3));
			if (string_0 != null)
			{
				arrayList.Add(string_0);
			}
			if (string_1 != null)
			{
				arrayList.Add(string_1);
			}
			if (string_2 != null)
			{
				arrayList.Add(string_2);
			}
			int count = arrayList.Count;
			if (count == 0)
			{
				return null;
			}
			string[] array = new string[count];
			for (int i = 0; i < count; i++)
			{
				array[i] = (string)arrayList[i];
			}
			return array;
		}

		private static string smethod_19(string string_0, string string_1)
		{
			if (string_0 == null)
			{
				return string_1;
			}
			return (string_1 == null) ? string_0 : (string_0 + ' ' + string_1);
		}
	}
}
