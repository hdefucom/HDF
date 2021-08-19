using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Serialization
{
	/// <summary>
	///       Sets extension data for an object during deserialization.
	///       </summary>
	/// <param name="o">The object to set extension data on.</param>
	/// <param name="key">The extension data key.</param>
	/// <param name="value">The extension data value.</param>
	[ComVisible(false)]
	public delegate void ExtensionDataSetter(object object_0, string string_0, object value);
}
