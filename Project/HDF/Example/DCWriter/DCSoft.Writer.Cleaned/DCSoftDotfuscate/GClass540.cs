using System;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[DefaultMember("Item")]
	[ComVisible(false)]
	public class GClass540 : IDisposable
	{
		private ArrayList arrayList_0 = new ArrayList();

		private long long_0 = -1L;

		public GClass540()
		{
			method_3(new GClass541(null));
		}

		private void method_0(StreamWriter streamWriter_0)
		{
			streamWriter_0.Flush();
			long_0 = streamWriter_0.BaseStream.Position;
		}

		public void method_1(StreamWriter streamWriter_0)
		{
			method_0(streamWriter_0);
			streamWriter_0.WriteLine("xref");
			streamWriter_0.Write("0 " + Convert.ToString(method_5()));
			for (int i = 0; i < method_5(); i++)
			{
				streamWriter_0.WriteLine();
				method_6(i).method_3(streamWriter_0);
			}
			streamWriter_0.WriteLine();
		}

		public int method_2(GClass504 gclass504_0)
		{
			if (gclass504_0 == null)
			{
				return -1;
			}
			if (gclass504_0.method_0() != GEnum89.const_1)
			{
				return -1;
			}
			gclass504_0.method_3(method_3(new GClass541(gclass504_0)));
			return gclass504_0.method_2();
		}

		public int method_3(GClass541 gclass541_0)
		{
			if (gclass541_0 == null)
			{
				return -1;
			}
			return arrayList_0.Add(gclass541_0);
		}

		public void method_4()
		{
			arrayList_0.Clear();
		}

		public int method_5()
		{
			return arrayList_0.Count;
		}

		public GClass541 method_6(int int_0)
		{
			return arrayList_0[int_0] as GClass541;
		}

		public long method_7()
		{
			return long_0;
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
