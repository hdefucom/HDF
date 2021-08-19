using System;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Serialization
{
	/// <summary>
	///       When applied to a method, specifies that the method is called when an error occurs serializing an object.
	///       </summary>
	[AttributeUsage(AttributeTargets.Method, Inherited = false)]
	[ComVisible(false)]
	public sealed class OnErrorAttribute : Attribute
	{
	}
}
