using DCSoft.TDCode;
using System.Collections;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass600 : GClass597
	{
		private GClass597 gclass597_0 = new GClass599();

		internal override BarcodeFormat vmethod_1()
		{
			return BarcodeFormat.barcodeFormat_3;
		}

		public override GClass645 vmethod_2(int int_8, GClass659 gclass659_0, int[] int_9, Hashtable hashtable_0)
		{
			return smethod_6(gclass597_0.vmethod_2(int_8, gclass659_0, int_9, hashtable_0));
		}

		public override GClass645 vmethod_0(int int_8, GClass659 gclass659_0, Hashtable hashtable_0)
		{
			return smethod_6(gclass597_0.vmethod_0(int_8, gclass659_0, hashtable_0));
		}

		public override GClass645 imethod_0(GClass616 gclass616_0)
		{
			return smethod_6(gclass597_0.imethod_0(gclass616_0));
		}

		public override GClass645 imethod_1(GClass616 gclass616_0, Hashtable hashtable_0)
		{
			return smethod_6(gclass597_0.imethod_1(gclass616_0, hashtable_0));
		}

		protected internal override int vmethod_5(GClass659 gclass659_0, int[] int_8, StringBuilder stringBuilder_1)
		{
			return gclass597_0.vmethod_5(gclass659_0, int_8, stringBuilder_1);
		}

		private static GClass645 smethod_6(GClass645 gclass645_0)
		{
			string text = gclass645_0.method_0();
			if (text[0] != '0')
			{
				throw GException25.smethod_0();
			}
			return new GClass645(text.Substring(1), null, gclass645_0.method_2(), BarcodeFormat.barcodeFormat_3);
		}
	}
}
