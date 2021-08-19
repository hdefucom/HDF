using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json
{
	/// <summary>
	///       Specifies missing member handling options for the <see cref="T:Open_Newtonsoft_Json.JsonSerializer" />.
	///       </summary>
	[ComVisible(false)]
	public enum MissingMemberHandling
	{
		/// <summary>
		///       Ignore a missing member and do not attempt to deserialize it.
		///       </summary>
		Ignore,
		/// <summary>
		///       Throw a <see cref="T:Open_Newtonsoft_Json.JsonSerializationException" /> when a missing member is encountered during deserialization.
		///       </summary>
		Error
	}
}
