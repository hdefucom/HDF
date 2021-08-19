using System.Runtime.InteropServices;

namespace DCSoft.RTF
{
	[ComVisible(false)]
	public enum RTFTokenType
	{
		None,
		Keyword,
		ExtKeyword,
		Control,
		Text,
		Eof,
		GroupStart,
		GroupEnd
	}
}
