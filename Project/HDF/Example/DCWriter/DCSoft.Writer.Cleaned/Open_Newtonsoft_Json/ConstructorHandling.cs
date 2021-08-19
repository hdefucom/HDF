using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json
{
	/// <summary>
	///       Specifies how constructors are used when initializing objects during deserialization by the <see cref="T:Open_Newtonsoft_Json.JsonSerializer" />.
	///       </summary>
	[ComVisible(false)]
	public enum ConstructorHandling
	{
		/// <summary>
		///       First attempt to use the public default constructor, then fall back to single paramatized constructor, then the non-public default constructor.
		///       </summary>
		Default,
		/// <summary>
		///       Json.NET will use a non-public default constructor before falling back to a paramatized constructor.
		///       </summary>
		AllowNonPublicDefaultConstructor
	}
}
