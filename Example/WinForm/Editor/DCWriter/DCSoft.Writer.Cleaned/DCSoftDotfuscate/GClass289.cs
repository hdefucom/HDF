using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[Serializable]
	[ComVisible(false)]
	public class GClass289 : List<GClass290>
	{
		private class Class180 : IComparer<GClass290>
		{
			public int Compare(GClass290 gclass290_0, GClass290 gclass290_1)
			{
				return DateTime.Compare(gclass290_0.method_19(), gclass290_1.method_19());
			}
		}

		public GClass290 method_0(string string_0, string string_1)
		{
			GClass290 gClass = new GClass290();
			gClass.method_3(string_0);
			gClass.method_6(string_1);
			Add(gClass);
			return gClass;
		}

		public void method_1()
		{
			Sort(new Class180());
		}

		public GClass289 method_2()
		{
			GClass289 gClass = new GClass289();
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					GClass290 current = enumerator.Current;
					gClass.Add(current);
				}
			}
			return gClass;
		}
	}
}
