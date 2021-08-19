using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[Serializable]
	[ComVisible(false)]
	public class GClass384 : GClass383
	{
		private GClass427 gclass427_0 = new GClass427();

		public GClass427 method_17()
		{
			return gclass427_0;
		}

		public void method_18(GClass427 gclass427_1)
		{
			gclass427_0 = gclass427_1;
		}

		public override string ToString()
		{
			return "ShapeGroup";
		}
	}
}
