using System;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	[DefaultMember("Item")]
	public class GClass477 : IDisposable
	{
		private ArrayList arrayList_0 = new ArrayList();

		public int method_0()
		{
			return arrayList_0.Count;
		}

		public GClass476 method_1(int int_0)
		{
			return (GClass476)arrayList_0[int_0];
		}

		protected internal void method_2()
		{
			foreach (GClass476 item in arrayList_0)
			{
				item.method_8();
			}
		}

		public int method_3(GClass476 gclass476_0)
		{
			return arrayList_0.IndexOf(gclass476_0);
		}

		public GClass476 method_4(GClass476 gclass476_0)
		{
			if (!arrayList_0.Contains(gclass476_0))
			{
				method_5(gclass476_0);
			}
			return gclass476_0;
		}

		public GClass476 method_5(GClass476 gclass476_0)
		{
			int num = 3;
			if (gclass476_0 != null)
			{
				arrayList_0.Add(gclass476_0);
				if (gclass476_0.Name == null)
				{
					gclass476_0.Name = "F" + arrayList_0.Count;
				}
			}
			return gclass476_0;
		}

		public void method_6()
		{
			arrayList_0.Clear();
		}

		public void method_7()
		{
			foreach (GClass476 item in arrayList_0)
			{
				item.method_19();
			}
		}

		public void method_8(GClass540 gclass540_0)
		{
			foreach (GClass476 item in arrayList_0)
			{
				item.method_17(gclass540_0);
			}
		}

		public void method_9(StreamWriter streamWriter_0)
		{
			foreach (GClass476 item in arrayList_0)
			{
				item.method_18(streamWriter_0);
			}
		}

		public void Dispose()
		{
		}
	}
}
