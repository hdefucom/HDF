using System.Collections;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass666 : GClass665
	{
		private static readonly GClass663[] gclass663_0 = new GClass663[0];

		public GClass666(GClass679 gclass679_1)
			: base(gclass679_1)
		{
		}

		public GClass663[] method_3(Hashtable hashtable_0)
		{
			GClass679 gclass679_ = vmethod_0();
			Class253 @class = new Class253(gclass679_);
			GClass680[] array = @class.method_7(hashtable_0);
			if (array == null || array.Length == 0)
			{
				throw GException25.smethod_0();
			}
			ArrayList arrayList = ArrayList.Synchronized(new ArrayList(10));
			for (int i = 0; i < array.Length; i++)
			{
				try
				{
					arrayList.Add(vmethod_4(array[i]));
				}
				catch (GException25)
				{
				}
			}
			if (arrayList.Count == 0)
			{
				return gclass663_0;
			}
			GClass663[] array2 = new GClass663[arrayList.Count];
			for (int i = 0; i < arrayList.Count; i++)
			{
				array2[i] = (GClass663)arrayList[i];
			}
			return array2;
		}
	}
}
