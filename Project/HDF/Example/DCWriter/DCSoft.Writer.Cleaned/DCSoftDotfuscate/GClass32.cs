using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass32
	{
		private string string_0 = null;

		private List<GClass33> list_0 = new List<GClass33>();

		public string Name
		{
			get
			{
				return string_0;
			}
			set
			{
				string_0 = value;
			}
		}

		public List<GClass33> method_0()
		{
			return list_0;
		}

		public void method_1(List<GClass33> list_1)
		{
			list_0 = list_1;
		}
	}
}
