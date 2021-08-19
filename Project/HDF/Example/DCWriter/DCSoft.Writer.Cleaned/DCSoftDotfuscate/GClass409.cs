using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[Serializable]
	[DefaultMember("Item")]
	[DebuggerTypeProxy(typeof(GClass421))]
	[ComVisible(false)]
	public class GClass409 : CollectionBase
	{
		public GClass383 method_0(int int_0)
		{
			return (GClass383)base.List[int_0];
		}

		public GClass383 method_1()
		{
			if (base.Count > 0)
			{
				return (GClass383)base.List[base.Count - 1];
			}
			return null;
		}

		public int method_2(GClass383 gclass383_0)
		{
			return base.List.Add(gclass383_0);
		}

		public void method_3(int int_0, GClass383 gclass383_0)
		{
			base.List.Insert(int_0, gclass383_0);
		}

		public int method_4(GClass383 gclass383_0)
		{
			return base.List.IndexOf(gclass383_0);
		}

		public void method_5(GClass383 gclass383_0)
		{
			base.List.Remove(gclass383_0);
		}

		public GClass383[] method_6()
		{
			return (GClass383[])base.InnerList.ToArray(typeof(GClass383));
		}
	}
}
