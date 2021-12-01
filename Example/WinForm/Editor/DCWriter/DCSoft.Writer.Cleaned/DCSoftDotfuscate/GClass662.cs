using System.Collections;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass662 : GInterface50
	{
		private GInterface50 ginterface50_0;

		public GClass662(GInterface50 ginterface50_1)
		{
			ginterface50_0 = ginterface50_1;
		}

		public GClass645 imethod_0(GClass616 gclass616_0)
		{
			return imethod_1(gclass616_0, null);
		}

		public GClass645 imethod_1(GClass616 gclass616_0, Hashtable hashtable_0)
		{
			int num = gclass616_0.method_0();
			int num2 = gclass616_0.method_1();
			int num3 = num / 2;
			int num4 = num2 / 2;
			GClass616 gclass616_ = gclass616_0.method_6(0, 0, num3, num4);
			try
			{
				return ginterface50_0.imethod_1(gclass616_, hashtable_0);
			}
			catch (GException25)
			{
			}
			GClass616 gclass616_2 = gclass616_0.method_6(num3, 0, num3, num4);
			try
			{
				return ginterface50_0.imethod_1(gclass616_2, hashtable_0);
			}
			catch (GException25)
			{
			}
			GClass616 gclass616_3 = gclass616_0.method_6(0, num4, num3, num4);
			try
			{
				return ginterface50_0.imethod_1(gclass616_3, hashtable_0);
			}
			catch (GException25)
			{
			}
			GClass616 gclass616_4 = gclass616_0.method_6(num3, num4, num3, num4);
			try
			{
				return ginterface50_0.imethod_1(gclass616_4, hashtable_0);
			}
			catch (GException25)
			{
			}
			int int_ = num3 / 2;
			int int_2 = num4 / 2;
			GClass616 gclass616_5 = gclass616_0.method_6(int_, int_2, num3, num4);
			return ginterface50_0.imethod_1(gclass616_5, hashtable_0);
		}
	}
}
