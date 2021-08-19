using System;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json
{
	/// <summary>
	///       Instructs the <see cref="T:Open_Newtonsoft_Json.JsonSerializer" /> to use the specified constructor when deserializing that object.
	///       </summary>
	[AttributeUsage(AttributeTargets.Constructor, AllowMultiple = false)]
	[ComVisible(false)]
	public sealed class JsonConstructorAttribute : Attribute
	{
	}
}
