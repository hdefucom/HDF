using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json
{
	/// <summary>
	///       Specifies float format handling options when writing special floating point numbers, e.g. <see cref="F:System.Double.NaN" />,
	///       <see cref="F:System.Double.PositiveInfinity" /> and <see cref="F:System.Double.NegativeInfinity" /> with <see cref="T:Open_Newtonsoft_Json.JsonWriter" />.
	///       </summary>
	[ComVisible(false)]
	public enum FloatFormatHandling
	{
		/// <summary>
		///       Write special floating point values as strings in JSON, e.g. "NaN", "Infinity", "-Infinity".
		///       </summary>
		String,
		/// <summary>
		///       Write special floating point values as symbols in JSON, e.g. NaN, Infinity, -Infinity.
		///       Note that this will produce non-valid JSON.
		///       </summary>
		Symbol,
		/// <summary>
		///       Write special floating point values as the property's default value in JSON, e.g. 0.0 for a <see cref="T:System.Double" /> property, null for a <see cref="T:System.Nullable`1" /> property.
		///       </summary>
		DefaultValue
	}
}
