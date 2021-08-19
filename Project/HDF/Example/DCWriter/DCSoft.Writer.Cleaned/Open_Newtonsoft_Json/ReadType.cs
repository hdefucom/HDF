using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json
{
	[ComVisible(false)]
	internal enum ReadType
	{
		Read,
		ReadAsInt32,
		ReadAsBytes,
		ReadAsString,
		ReadAsDecimal,
		ReadAsDateTime
	}
}
