using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Utilities
{
	[ComVisible(false)]
	internal enum ParseResult
	{
		None,
		Success,
		Overflow,
		Invalid
	}
}
