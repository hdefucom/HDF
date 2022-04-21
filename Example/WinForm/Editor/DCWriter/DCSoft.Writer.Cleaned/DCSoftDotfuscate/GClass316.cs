using DCSoft.Common;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	
	[DefaultMember("Item")]
	public class GClass316 : List<GClass315>
	{
		public GClass315 method_0(string string_0)
		{
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					GClass315 current = enumerator.Current;
					if (string.Compare(current.method_1(), string_0, ignoreCase: true) == 0)
					{
						return current;
					}
				}
			}
			return null;
		}

		public GClass315 method_1(string string_0)
		{
			GClass315 gClass = new GClass315();
			gClass.method_2(string_0);
			Add(gClass);
			return gClass;
		}

		public GClass315 method_2(string string_0, string string_1)
		{
			GClass315 gClass = new GClass315();
			gClass.method_2(string_0);
			gClass.method_4(string_1);
			Add(gClass);
			return gClass;
		}
	}
}
