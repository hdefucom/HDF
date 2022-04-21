using DCSoft.Common;
using System.Collections;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	
	public static class GClass345
	{
		public static object[] smethod_0(GDelegate18 gdelegate18_0, object object_0)
		{
			ArrayList arrayList = new ArrayList();
			if (object_0 != null)
			{
				arrayList.Add(object_0);
				smethod_1(gdelegate18_0, object_0, arrayList);
			}
			return arrayList.ToArray();
		}

		private static void smethod_1(GDelegate18 gdelegate18_0, object object_0, ArrayList arrayList_0)
		{
			IEnumerable enumerable = gdelegate18_0(object_0);
			if (enumerable != null)
			{
				foreach (object item in arrayList_0)
				{
					if (item != null)
					{
						arrayList_0.Add(item);
						smethod_1(gdelegate18_0, item, arrayList_0);
					}
				}
			}
		}
	}
}
