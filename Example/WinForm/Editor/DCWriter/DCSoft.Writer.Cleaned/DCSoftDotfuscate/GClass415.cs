using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	[DefaultMember("Item")]
	[DebuggerDisplay("Count={ Count }")]
	[DebuggerTypeProxy(typeof(GClass421))]
	public class GClass415 : CollectionBase
	{
		public GClass406 method_0(int int_0)
		{
			return (GClass406)base.List[int_0];
		}

		public GClass406 method_1(string string_0)
		{
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					GClass406 gClass = (GClass406)enumerator.Current;
					if (gClass.vmethod_4() == string_0)
					{
						return gClass;
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

		public GClass406 method_2(Type type_0)
		{
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					GClass406 gClass = (GClass406)enumerator.Current;
					if (type_0.Equals(gClass.GetType()))
					{
						return gClass;
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

		public int method_3(string string_0, int int_0)
		{
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					GClass406 gClass = (GClass406)enumerator.Current;
					if (gClass.vmethod_4() == string_0 && gClass.vmethod_6())
					{
						return gClass.vmethod_8();
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
			return int_0;
		}

		public string method_4()
		{
			StringBuilder stringBuilder = new StringBuilder();
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					GClass406 gClass = (GClass406)enumerator.Current;
					if (gClass.method_1() == GEnum82.const_4)
					{
						stringBuilder.Append(gClass.vmethod_4());
					}
					else if (gClass is GClass407)
					{
						string text = gClass.vmethod_9().method_4();
						if (text != null)
						{
							stringBuilder.Append(text);
						}
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
			return stringBuilder.ToString();
		}

		public bool method_5(string string_0)
		{
			return method_1(string_0) != null;
		}

		public int method_6(GClass406 gclass406_0)
		{
			return base.List.IndexOf(gclass406_0);
		}

		internal void method_7(GClass415 gclass415_0)
		{
			base.InnerList.AddRange(gclass415_0);
		}

		internal void method_8(GClass406 gclass406_0)
		{
			base.List.Add(gclass406_0);
		}

		internal void method_9(GClass406 gclass406_0)
		{
			method_9(gclass406_0);
		}

		internal void method_10(int int_0, GClass406 gclass406_0)
		{
			base.List.Insert(int_0, gclass406_0);
		}
	}
}
