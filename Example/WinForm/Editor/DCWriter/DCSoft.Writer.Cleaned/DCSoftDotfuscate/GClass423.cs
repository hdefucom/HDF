using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[Serializable]
	[ComVisible(false)]
	[DefaultMember("Item")]
	[DebuggerTypeProxy(typeof(GClass421))]
	public class GClass423 : CollectionBase
	{
		public GClass422 method_0(int int_0)
		{
			return (GClass422)base.List[int_0];
		}

		public int method_1(string string_0)
		{
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					GClass422 gClass = (GClass422)enumerator.Current;
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
			return int.MinValue;
		}

		public void method_2(string string_0, int int_0)
		{
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					GClass422 gClass = (GClass422)enumerator.Current;
					if (gClass.Name == string_0)
					{
						gClass.method_1(int_0);
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
			GClass422 gClass2 = new GClass422();
			gClass2.Name = string_0;
			gClass2.method_1(int_0);
			base.List.Add(gClass2);
		}

		public int method_3(GClass422 gclass422_0)
		{
			return base.List.Add(gclass422_0);
		}

		public int method_4(string string_0, int int_0)
		{
			GClass422 gClass = new GClass422();
			gClass.Name = string_0;
			gClass.method_1(int_0);
			return base.List.Add(gClass);
		}

		public void method_5(GClass422 gclass422_0)
		{
			base.List.Remove(gclass422_0);
		}

		public void method_6(string string_0)
		{
			for (int num = base.Count - 1; num >= 0; num--)
			{
				GClass422 gClass = (GClass422)base.List[num];
				if (gClass.Name == string_0)
				{
					base.List.RemoveAt(num);
				}
			}
		}

		public bool method_7(GClass422 gclass422_0)
		{
			return base.List.Contains(gclass422_0);
		}

		public bool method_8(string string_0)
		{
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					GClass422 gClass = (GClass422)enumerator.Current;
					if (gClass.Name == string_0)
					{
						return true;
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
			return false;
		}

		public GClass423 method_9()
		{
			GClass423 gClass = new GClass423();
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					GClass422 gClass2 = (GClass422)enumerator.Current;
					GClass422 gClass3 = new GClass422();
					gClass3.Name = gClass2.Name;
					gClass3.method_1(gClass2.method_0());
					gClass.List.Add(gClass3);
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
			return gClass;
		}
	}
}
