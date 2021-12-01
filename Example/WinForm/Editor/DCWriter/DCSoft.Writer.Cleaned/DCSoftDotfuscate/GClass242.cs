using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[DefaultMember("Item")]
	[ComVisible(false)]
	public class GClass242 : List<GClass229>
	{
		public GClass242 method_0()
		{
			GClass242 gClass = new GClass242();
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					GClass229 current = enumerator.Current;
					gClass.Add(current.method_0());
				}
			}
			return gClass;
		}

		public GClass229 method_1(string string_0)
		{
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					GClass229 current = enumerator.Current;
					if (string.Compare(current.string_0, string_0, ignoreCase: true) == 0)
					{
						return current;
					}
				}
			}
			return null;
		}

		public bool method_2(string string_0)
		{
			return method_1(string_0) != null;
		}

		public void method_3(string string_0)
		{
			GClass229 gClass = method_1(string_0);
			if (gClass != null)
			{
				Remove(gClass);
			}
		}

		public void method_4(string[] string_0)
		{
			if (string_0 == null || string_0.Length == 0)
			{
				return;
			}
			for (int num = base.Count - 1; num >= 0; num--)
			{
				string string_ = base[num].string_0;
				foreach (string strA in string_0)
				{
					if (string.Compare(strA, string_, ignoreCase: true) == 0)
					{
						RemoveAt(num);
					}
				}
			}
		}

		public string method_5(string string_0)
		{
			return method_1(string_0)?.string_1;
		}

		public void method_6(string string_0, string string_1)
		{
			GClass229 gClass = method_1(string_0);
			if (gClass == null)
			{
				gClass = new GClass229();
				gClass.string_0 = string_0;
				Add(gClass);
			}
			gClass.string_1 = string_1;
		}
	}
}
