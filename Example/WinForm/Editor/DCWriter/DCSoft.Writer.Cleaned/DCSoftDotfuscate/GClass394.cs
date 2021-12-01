using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[Serializable]
	[ComVisible(false)]
	public class GClass394 : GClass383
	{
		private GEnum84 genum84_0 = GEnum84.const_0;

		public GEnum84 method_17()
		{
			return genum84_0;
		}

		public void method_18(GEnum84 genum84_1)
		{
			genum84_0 = genum84_1;
		}

		public string method_19()
		{
			int num = 13;
			foreach (GClass383 item in method_5())
			{
				if (item is GClass399)
				{
					GClass399 gClass2 = (GClass399)item;
					if (gClass2.Name == "fldinst")
					{
						return gClass2.vmethod_0();
					}
				}
			}
			return null;
		}

		public GClass399 method_20()
		{
			int num = 15;
			foreach (GClass383 item in method_5())
			{
				if (item is GClass399)
				{
					GClass399 gClass2 = (GClass399)item;
					if (gClass2.Name == "fldrslt")
					{
						return gClass2;
					}
				}
			}
			return null;
		}

		public string method_21()
		{
			return method_20()?.vmethod_0();
		}

		public override string ToString()
		{
			return "Field";
		}
	}
}
