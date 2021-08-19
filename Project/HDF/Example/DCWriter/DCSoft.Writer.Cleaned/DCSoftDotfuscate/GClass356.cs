using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[Serializable]
	[DefaultMember("Item")]
	[ComVisible(false)]
	public class GClass356 : List<GClass357>
	{
		public GClass357 method_0(string string_0)
		{
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					GClass357 current = enumerator.Current;
					if (current.Name == string_0)
					{
						return current;
					}
				}
			}
			return null;
		}
	}
}
