using System.Collections;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass79 : ArrayList
	{
		public object method_0()
		{
			return this[Count - 1];
		}

		public object method_1()
		{
			object result = this[Count - 1];
			RemoveAt(Count - 1);
			return result;
		}

		public void method_2(object object_0)
		{
			Add(object_0);
		}
	}
}
