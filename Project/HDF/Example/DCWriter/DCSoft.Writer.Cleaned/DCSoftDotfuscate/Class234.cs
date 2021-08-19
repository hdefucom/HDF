using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	internal sealed class Class234 : Class231
	{
		private static readonly string[] string_0 = new string[36]
		{
			null,
			"http://www.",
			"https://www.",
			"http://",
			"https://",
			"tel:",
			"mailto:",
			"ftp://anonymous:anonymous@",
			"ftp://ftp.",
			"ftps://",
			"sftp://",
			"smb://",
			"nfs://",
			"ftp://",
			"dav://",
			"news:",
			"telnet://",
			"imap:",
			"rtsp://",
			"urn:",
			"pop:",
			"sip:",
			"sips:",
			"tftp:",
			"btspp://",
			"btl2cap://",
			"btgoep://",
			"tcpobex://",
			"irdaobex://",
			"file://",
			"urn:epc:id:",
			"urn:epc:tag:",
			"urn:epc:pat:",
			"urn:epc:raw:",
			"urn:epc:",
			"urn:nfc:"
		};

		public static GClass624 smethod_16(GClass645 gclass645_0)
		{
			int num = 3;
			sbyte[] array = gclass645_0.method_1();
			if (array == null)
			{
				return null;
			}
			Class267 @class = Class267.smethod_0(array, 0);
			if (@class == null || !@class.method_0() || !@class.method_1())
			{
				return null;
			}
			if (!@class.method_2().Equals("U"))
			{
				return null;
			}
			string string_ = smethod_17(@class.method_3());
			return new GClass624(string_, null);
		}

		internal static string smethod_17(sbyte[] sbyte_0)
		{
			int num = 4;
			int num2 = sbyte_0[0] & 0xFF;
			string text = null;
			if (num2 < string_0.Length)
			{
				text = string_0[num2];
			}
			string text2 = Class231.smethod_15(sbyte_0, 1, sbyte_0.Length - 1, "UTF-8");
			return (text == null) ? text2 : (text + text2);
		}
	}
}
