using System.Collections;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass654
	{
		private GClass654()
		{
		}

		public static void smethod_0(ArrayList arrayList_0, GInterface51 ginterface51_0)
		{
			int count = arrayList_0.Count;
			for (int i = 1; i < count; i++)
			{
				object obj = arrayList_0[i];
				int num = i - 1;
				object value;
				while (num >= 0 && ginterface51_0.imethod_0(value = arrayList_0[num], obj) > 0)
				{
					arrayList_0[num + 1] = value;
					num--;
				}
				arrayList_0[num + 1] = obj;
			}
		}
	}
}
