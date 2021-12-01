using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass421
	{
		private object object_0;

		public GClass421(object object_1)
		{
			int num = 10;
			object_0 = null;
			
			if (object_1 == null)
			{
				throw new ArgumentNullException("instance");
			}
			object_0 = object_1;
		}

		public object method_0()
		{
			if (object_0 is IEnumerable)
			{
				CollectionBase collectionBase = (CollectionBase)object_0;
				object[] array = new object[collectionBase.Count];
				int num = 0;
				foreach (object item in collectionBase)
				{
					object obj = array[num] = item;
					num++;
				}
				return array;
			}
			if (object_0 is GClass418)
			{
				GClass418 gClass = (GClass418)object_0;
				object[] array = new object[gClass.method_9()];
				for (int num = 0; num < gClass.method_9(); num++)
				{
					array[num] = gClass.method_0(num);
				}
				return array;
			}
			if (object_0 is GClass424)
			{
				GClass424 gClass2 = (GClass424)object_0;
				return gClass2.method_46();
			}
			return object_0;
		}
	}
}
