using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json
{
	/// <summary>
	///       Specifies how date formatted strings, e.g. "\/Date(1198908717056)\/" and "2012-03-21T05:40Z", are parsed when reading JSON text.
	///       </summary>
	[ComVisible(false)]
	public enum DateParseHandling
	{
		/// <summary>
		///       Date formatted strings are not parsed to a date type and are read as strings.
		///       </summary>
		None,
		/// <summary>
		///       Date formatted strings, e.g. "\/Date(1198908717056)\/" and "2012-03-21T05:40Z", are parsed to <see cref="F:Open_Newtonsoft_Json.DateParseHandling.DateTime" />.
		///       </summary>
		DateTime
	}
}
