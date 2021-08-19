using System.Collections;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass651
	{
		private GClass684 gclass684_0;

		private string string_0 = "UTF-8";

		public GClass651()
		{
			gclass684_0 = new GClass684();
		}

		public string method_0()
		{
			return string_0;
		}

		public GClass645 method_1(Bitmap bitmap_0)
		{
			GClass605 gclass605_ = new GClass606(bitmap_0, bitmap_0.Width, bitmap_0.Height);
			GClass616 gclass616_ = new GClass616(new GClass644(gclass605_));
			Hashtable hashtable = new Hashtable();
			hashtable.Add(GClass685.gclass685_1, method_0());
			return gclass684_0.imethod_1(gclass616_, hashtable);
		}
	}
}
