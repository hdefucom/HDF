using System;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json
{
	/// <summary>
	///       Instructs the <see cref="T:Open_Newtonsoft_Json.JsonSerializer" /> not to serialize the public field or public read/write property value.
	///       </summary>
	[ComVisible(false)]
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
	public sealed class JsonIgnoreAttribute : Attribute
	{
	}
}
