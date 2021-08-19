using System;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json
{
	/// <summary>
	///       Specifies reference handling options for the <see cref="T:Open_Newtonsoft_Json.JsonSerializer" />.
	///       Note that references cannot be preserved when a value is set via a non-default constructor such as types that implement ISerializable.
	///       </summary>
	/// <example>
	///   <code lang="cs" source="..\Src\Open_Newtonsoft_Json.Tests\Documentation\SerializationTests.cs" region="PreservingObjectReferencesOn" title="Preserve Object References" />
	/// </example>
	[Flags]
	[ComVisible(false)]
	public enum PreserveReferencesHandling
	{
		/// <summary>
		///       Do not preserve references when serializing types.
		///       </summary>
		None = 0x0,
		/// <summary>
		///       Preserve references when serializing into a JSON object structure.
		///       </summary>
		Objects = 0x1,
		/// <summary>
		///       Preserve references when serializing into a JSON array structure.
		///       </summary>
		Arrays = 0x2,
		/// <summary>
		///       Preserve references when serializing.
		///       </summary>
		All = 0x3
	}
}
