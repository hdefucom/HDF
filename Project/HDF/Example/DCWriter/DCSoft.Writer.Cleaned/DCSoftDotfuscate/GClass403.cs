using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass403 : List<GClass404>
	{
		public GClass404 method_0(int int_0)
		{
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					GClass404 current = enumerator.Current;
					if (current.method_0() == int_0)
					{
						return current;
					}
				}
			}
			return null;
		}
	}
}
