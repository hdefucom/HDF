using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Serialization
{
	/// <summary>
	///       Gets extension data for an object during serialization.
	///       </summary>
	/// <param name="o">The object to set extension data on.</param>
	[ComVisible(false)]
	public delegate IEnumerable<KeyValuePair<object, object>> ExtensionDataGetter(object object_0);
}
