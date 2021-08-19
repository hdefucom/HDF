using System.Collections;
using System.Reflection;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[DefaultMember("Item")]
	[ComVisible(false)]
	public class GClass495
	{
		private ArrayList arrayList_0 = new ArrayList();

		public bool method_0(ushort ushort_0)
		{
			if (!arrayList_0.Contains(ushort_0))
			{
				arrayList_0.Add(ushort_0);
				return true;
			}
			return false;
		}

		public void method_1()
		{
			arrayList_0.Clear();
		}

		public int method_2()
		{
			return arrayList_0.Count;
		}

		public ushort method_3(int int_0)
		{
			return (ushort)arrayList_0[int_0];
		}

		public ushort[] method_4()
		{
			arrayList_0.Sort();
			ushort[] array = new ushort[method_2()];
			for (int i = 0; i < method_2(); i++)
			{
				array[i] = method_3(i);
			}
			return array;
		}
	}
}
