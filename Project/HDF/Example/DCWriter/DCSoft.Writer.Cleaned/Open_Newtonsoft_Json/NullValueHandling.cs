using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json
{
	/// <summary>
	///       Specifies null value handling options for the <see cref="T:Open_Newtonsoft_Json.JsonSerializer" />.
	///       </summary>
	/// <example>
	///   <code lang="cs" source="..\Src\Open_Newtonsoft_Json.Tests\Documentation\SerializationTests.cs" region="ReducingSerializedJsonSizeNullValueHandlingObject" title="NullValueHandling Class" />
	///   <code lang="cs" source="..\Src\Open_Newtonsoft_Json.Tests\Documentation\SerializationTests.cs" region="ReducingSerializedJsonSizeNullValueHandlingExample" title="NullValueHandling Ignore Example" />
	/// </example>
	[ComVisible(false)]
	public enum NullValueHandling
	{
		/// <summary>
		///       Include null values when serializing and deserializing objects.
		///       </summary>
		Include,
		/// <summary>
		///       Ignore null values when serializing and deserializing objects.
		///       </summary>
		Ignore
	}
}
