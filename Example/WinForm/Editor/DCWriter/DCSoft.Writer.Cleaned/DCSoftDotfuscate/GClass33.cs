using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass33
	{
		private string string_0 = null;

		private List<GClass34> list_0 = new List<GClass34>();

		private GClass35 gclass35_0 = new GClass35();

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

		public List<GClass34> method_0()
		{
			return list_0;
		}

		public void method_1(List<GClass34> list_1)
		{
			list_0 = list_1;
		}

		public GClass35 method_2()
		{
			return gclass35_0;
		}

		public void method_3(GClass35 gclass35_1)
		{
			gclass35_0 = gclass35_1;
		}
	}
}
