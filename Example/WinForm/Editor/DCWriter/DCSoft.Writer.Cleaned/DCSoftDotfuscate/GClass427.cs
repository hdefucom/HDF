using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[Serializable]
	[DefaultMember("Item")]
	[ComVisible(false)]
	[DebuggerTypeProxy(typeof(GClass421))]
	public class GClass427 : CollectionBase
	{
		public string method_0(string string_0)
		{
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					GClass426 gClass = (GClass426)enumerator.Current;
					if (gClass.Name == string_0)
					{
						return gClass.method_0();
					}
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
			return null;
		}

		public void method_1(string string_0, string string_1)
		{
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					GClass426 gClass = (GClass426)enumerator.Current;
					if (gClass.Name == string_0)
					{
						if (string_1 == null)
						{
							base.List.Remove(gClass);
						}
						else
						{
							gClass.method_1(string_1);
						}
						return;
					}
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
			if (string_1 != null)
			{
				GClass426 gClass2 = new GClass426();
				gClass2.Name = string_0;
				gClass2.method_1(string_1);
				base.List.Add(gClass2);
			}
		}

		public int method_2(GClass426 gclass426_0)
		{
			return base.List.Add(gclass426_0);
		}

		public void method_3(GClass426 gclass426_0)
		{
			base.List.Remove(gclass426_0);
		}
	}
}
