using DCSoft.Common;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	
	[ComVisible(false)]
	public class GClass126 : List<GClass127>
	{
		public GClass127 method_0(object object_0, bool bool_0)
		{
			if (object_0 == null)
			{
				return null;
			}
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					GClass127 current = enumerator.Current;
					if (current.method_0() == object_0)
					{
						return current;
					}
				}
			}
			if (bool_0)
			{
				GClass127 current = new GClass127();
				current.method_1(object_0);
				Add(current);
				return current;
			}
			return null;
		}
	}
}
