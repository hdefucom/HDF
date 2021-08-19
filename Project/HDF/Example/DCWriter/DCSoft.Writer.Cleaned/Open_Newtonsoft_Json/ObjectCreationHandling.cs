using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json
{
	/// <summary>
	///       Specifies how object creation is handled by the <see cref="T:Open_Newtonsoft_Json.JsonSerializer" />.
	///       </summary>
	[ComVisible(false)]
	public enum ObjectCreationHandling
	{
		/// <summary>
		///       Reuse existing objects, create new objects when needed.
		///       </summary>
		Auto,
		/// <summary>
		///       Only reuse existing objects.
		///       </summary>
		Reuse,
		/// <summary>
		///       Always create new objects.
		///       </summary>
		Replace
	}
}
