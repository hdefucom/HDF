using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[DebuggerTypeProxy(typeof(GClass421))]
	[DebuggerDisplay("Count={ Count }")]
	[ComVisible(false)]
	[DefaultMember("Item")]
	public class GClass430 : CollectionBase
	{
		public GClass431 method_0(int int_0)
		{
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					GClass431 gClass = (GClass431)enumerator.Current;
					if (gClass.method_0() == int_0)
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

		public GClass431 method_1(string string_0)
		{
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					GClass431 gClass = (GClass431)enumerator.Current;
					if (gClass.Name == string_0)
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

		public string method_2(int int_0)
		{
			return method_0(int_0)?.Name;
		}

		public GClass431 method_3(string string_0)
		{
			return method_5(base.Count, string_0, Encoding.Default);
		}

		public GClass431 method_4(string string_0, Encoding encoding_0)
		{
			return method_5(base.Count, string_0, encoding_0);
		}

		public GClass431 method_5(int int_0, string string_0, Encoding encoding_0)
		{
			if (method_1(string_0) == null)
			{
				GClass431 gClass = new GClass431(int_0, string_0);
				if (encoding_0 != null)
				{
					gClass.method_5(GClass431.smethod_1(encoding_0));
				}
				base.List.Add(gClass);
				return gClass;
			}
			return method_1(string_0);
		}

		public void method_6(GClass431 gclass431_0)
		{
			base.List.Add(gclass431_0);
		}

		public void method_7(string string_0)
		{
			GClass431 gClass = method_1(string_0);
			if (gClass != null)
			{
				base.List.Remove(gClass);
			}
		}

		public int method_8(string string_0)
		{
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					GClass431 gClass = (GClass431)enumerator.Current;
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
			return -1;
		}

		public void method_9(GClass414 gclass414_0)
		{
			int num = 17;
			gclass414_0.method_10();
			gclass414_0.method_13("fonttbl");
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					GClass431 gClass = (GClass431)enumerator.Current;
					gclass414_0.method_10();
					gclass414_0.method_13("f" + gClass.method_0());
					if (gClass.method_4() != 0)
					{
						gclass414_0.method_13("fcharset" + gClass.method_4());
					}
					gclass414_0.method_15(gClass.Name);
					gclass414_0.method_11();
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
			gclass414_0.method_11();
		}

		public override string ToString()
		{
			int num = 10;
			StringBuilder stringBuilder = new StringBuilder();
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					GClass431 gClass = (GClass431)enumerator.Current;
					stringBuilder.Append(Environment.NewLine);
					stringBuilder.Append("Index " + gClass.method_0() + "   Name:" + gClass.Name);
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

		public GClass430 method_10()
		{
			GClass430 gClass = new GClass430();
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					GClass431 gClass2 = (GClass431)enumerator.Current;
					GClass431 value = gClass2.method_7();
					gClass.List.Add(value);
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
