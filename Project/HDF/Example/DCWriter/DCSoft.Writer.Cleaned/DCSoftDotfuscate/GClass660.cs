using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass660
	{
		public static readonly GClass660 gclass660_0 = new GClass660("ADDRESSBOOK");

		public static readonly GClass660 gclass660_1 = new GClass660("EMAIL_ADDRESS");

		public static readonly GClass660 gclass660_2 = new GClass660("PRODUCT");

		public static readonly GClass660 gclass660_3 = new GClass660("URI");

		public static readonly GClass660 gclass660_4 = new GClass660("TEXT");

		public static readonly GClass660 gclass660_5 = new GClass660("ANDROID_INTENT");

		public static readonly GClass660 gclass660_6 = new GClass660("GEO");

		public static readonly GClass660 gclass660_7 = new GClass660("TEL");

		public static readonly GClass660 gclass660_8 = new GClass660("SMS");

		public static readonly GClass660 gclass660_9 = new GClass660("CALENDAR");

		public static readonly GClass660 gclass660_10 = new GClass660("NDEF_SMART_POSTER");

		public static readonly GClass660 gclass660_11 = new GClass660("MOBILETAG_RICH_WEB");

		public static readonly GClass660 gclass660_12 = new GClass660("ISBN");

		private string string_0;

		private GClass660(string string_1)
		{
			string_0 = string_1;
		}

		public override string ToString()
		{
			return string_0;
		}
	}
}
