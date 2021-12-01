using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[Serializable]
	[ComVisible(false)]
	public class GClass391 : GClass383
	{
		private GClass409 gclass409_1 = new GClass409();

		public GClass409 method_17()
		{
			return gclass409_1;
		}

		public void method_18(GClass409 gclass409_2)
		{
			gclass409_1 = gclass409_2;
		}

		public override string ToString()
		{
			return "Table(Rows:" + method_5().Count + " Columns:" + gclass409_1.Count + ")";
		}
	}
}
