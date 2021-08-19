using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json
{
	/// <summary>
	///       Specifies how floating point numbers, e.g. 1.0 and 9.9, are parsed when reading JSON text.
	///       </summary>
	[ComVisible(false)]
	public enum FloatParseHandling
	{
		/// <summary>
		///       Floating point numbers are parsed to <see cref="F:Open_Newtonsoft_Json.FloatParseHandling.Double" />.
		///       </summary>
		Double,
		/// <summary>
		///       Floating point numbers are parsed to <see cref="F:Open_Newtonsoft_Json.FloatParseHandling.Decimal" />.
		///       </summary>
		Decimal
	}
}
