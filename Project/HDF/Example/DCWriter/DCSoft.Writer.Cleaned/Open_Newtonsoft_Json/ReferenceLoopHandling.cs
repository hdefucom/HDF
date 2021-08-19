using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json
{
	/// <summary>
	///       Specifies reference loop handling options for the <see cref="T:Open_Newtonsoft_Json.JsonSerializer" />.
	///       </summary>
	[ComVisible(false)]
	public enum ReferenceLoopHandling
	{
		/// <summary>
		///       Throw a <see cref="T:Open_Newtonsoft_Json.JsonSerializationException" /> when a loop is encountered.
		///       </summary>
		Error,
		/// <summary>
		///       Ignore loop references and do not serialize.
		///       </summary>
		Ignore,
		/// <summary>
		///       Serialize loop references.
		///       </summary>
		Serialize
	}
}
