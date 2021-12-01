using System;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	[DefaultMember("Item")]
	public class GClass469 : IDisposable
	{
		private ArrayList arrayList_0 = new ArrayList();

		private GClass455 method_0(string string_0)
		{
			int num = 0;
			while (true)
			{
				if (num < method_8())
				{
					if (method_9(num).Name == string_0)
					{
						break;
					}
					num++;
					continue;
				}
				return null;
			}
			return method_9(num);
		}

		public int method_1(GClass455 gclass455_0)
		{
			int num = 0;
			while (true)
			{
				if (num < method_8())
				{
					if (method_9(num) == gclass455_0)
					{
						break;
					}
					num++;
					continue;
				}
				return -1;
			}
			return num;
		}

		public GClass455 method_2(GClass455 gclass455_0)
		{
			if (method_1(gclass455_0) == -1)
			{
				method_3(gclass455_0);
			}
			return gclass455_0;
		}

		public GClass455 method_3(GClass455 gclass455_0)
		{
			if (gclass455_0 != null)
			{
				arrayList_0.Add(gclass455_0);
			}
			return gclass455_0;
		}

		public void method_4()
		{
			arrayList_0.Clear();
		}

		public void method_5()
		{
			for (int i = 0; i < method_8(); i++)
			{
				method_9(i).vmethod_2();
			}
		}

		public void method_6(GClass540 gclass540_0)
		{
			for (int i = 0; i < method_8(); i++)
			{
				method_9(i).method_1(gclass540_0);
			}
		}

		public void method_7(StreamWriter streamWriter_0)
		{
			for (int i = 0; i < method_8(); i++)
			{
				method_9(i).method_2(streamWriter_0);
			}
		}

		public int method_8()
		{
			return arrayList_0.Count;
		}

		public GClass455 method_9(int int_0)
		{
			return arrayList_0[int_0] as GClass455;
		}

		public GClass455 method_10(string string_0)
		{
			return method_0(string_0);
		}

		public void Dispose()
		{
			foreach (object item in arrayList_0)
			{
				if (item is IDisposable)
				{
					((IDisposable)item).Dispose();
				}
			}
			arrayList_0.Clear();
		}
	}
}
