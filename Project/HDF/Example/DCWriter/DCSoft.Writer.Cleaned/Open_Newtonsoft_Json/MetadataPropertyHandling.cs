using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json
{
	/// <summary>
	///       Specifies metadata property handling options for the <see cref="T:Open_Newtonsoft_Json.JsonSerializer" />.
	///       </summary>
	[ComVisible(false)]
	public enum MetadataPropertyHandling
	{
		/// <summary>
		///       Read metadata properties located at the start of a JSON object.
		///       </summary>
		Default,
		/// <summary>
		///       Read metadata properties located anywhere in a JSON object. Note that this setting will impact performance.
		///       </summary>
		ReadAhead,
		/// <summary>
		///       Do not try to read metadata properties.
		///       </summary>
		Ignore
	}
}
