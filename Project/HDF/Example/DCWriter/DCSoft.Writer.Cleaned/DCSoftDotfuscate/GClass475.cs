using System.Collections;
using System.Reflection;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	[DefaultMember("Item")]
	public class GClass475
	{
		private ArrayList arrayList_0 = new ArrayList();

		public void method_0(char char_0)
		{
			if (!arrayList_0.Contains(char_0))
			{
				arrayList_0.Add(char_0);
			}
		}

		public void method_1()
		{
			arrayList_0.Clear();
		}

		public int method_2()
		{
			return arrayList_0.Count;
		}

		public char method_3(int int_0)
		{
			return (char)arrayList_0[int_0];
		}

		public char[] method_4()
		{
			arrayList_0.Sort();
			return (char[])arrayList_0.ToArray(typeof(char));
		}
	}
}
