using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass419 : List<GClass420>
	{
		public GClass420 method_0(int int_0)
		{
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					GClass420 current = enumerator.Current;
					if (current.method_4() == int_0)
					{
						return current;
					}
				}
			}
			return null;
		}
	}
}
