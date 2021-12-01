using DCSoft.Common;
using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	[DefaultMember("Item")]
	[DebuggerTypeProxy(typeof(ListDebugView))]
	[DebuggerDisplay("Count={ Count }")]
	public class GClass228 : ICollection
	{
		private ArrayList arrayList_0 = new ArrayList();

		public int Count => arrayList_0.Count;

		public object SyncRoot => arrayList_0.SyncRoot;

		public bool IsSynchronized => arrayList_0.IsSynchronized;

		public GClass163 method_0()
		{
			if (arrayList_0.Count > 0)
			{
				return (GClass163)arrayList_0[0];
			}
			return null;
		}

		public GClass163 method_1()
		{
			if (arrayList_0.Count > 0)
			{
				return (GClass163)arrayList_0[arrayList_0.Count - 1];
			}
			return null;
		}

		public GClass163 method_2(GClass163 gclass163_0)
		{
			int num = arrayList_0.IndexOf(gclass163_0);
			if (num > 0)
			{
				return (GClass163)arrayList_0[num - 1];
			}
			return null;
		}

		public GClass163 method_3(GClass163 gclass163_0)
		{
			int num = arrayList_0.IndexOf(gclass163_0);
			if (num >= 0 && num < arrayList_0.Count - 1)
			{
				return (GClass163)arrayList_0[num + 1];
			}
			return null;
		}

		public GClass163 method_4(int int_0)
		{
			return (GClass163)arrayList_0[int_0];
		}

		public bool method_5(GClass163 gclass163_0)
		{
			return arrayList_0.Contains(gclass163_0);
		}

		public void method_6(GClass163 gclass163_0)
		{
			arrayList_0.Add(gclass163_0);
		}

		public void method_7(GClass163 gclass163_0)
		{
			arrayList_0.Remove(gclass163_0);
		}

		public void method_8()
		{
			arrayList_0.Clear();
		}

		public int method_9(GClass163 gclass163_0)
		{
			return arrayList_0.IndexOf(gclass163_0);
		}

		public void CopyTo(Array array, int index)
		{
			arrayList_0.CopyTo(array, index);
		}

		public IEnumerator GetEnumerator()
		{
			return arrayList_0.GetEnumerator();
		}
	}
}
