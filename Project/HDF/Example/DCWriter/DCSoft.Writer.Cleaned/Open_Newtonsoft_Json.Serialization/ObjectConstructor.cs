using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Serialization
{
	/// <summary>
	///       Represents a method that constructs an object.
	///       </summary>
	/// <typeparam name="T">The object type to create.</typeparam>
	[ComVisible(false)]
	public delegate object ObjectConstructor<T>(params object[] args);
}
