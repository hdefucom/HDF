using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Open_Newtonsoft_Json.Serialization
{
	/// <summary>
	///       Handles <see cref="T:Open_Newtonsoft_Json.JsonSerializer" /> serialization callback events.
	///       </summary>
	/// <param name="o">The object that raised the callback event.</param>
	/// <param name="context">The streaming context.</param>
	[ComVisible(false)]
	public delegate void SerializationCallback(object object_0, StreamingContext context);
}
