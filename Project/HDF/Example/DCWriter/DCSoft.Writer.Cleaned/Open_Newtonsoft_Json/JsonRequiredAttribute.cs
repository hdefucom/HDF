using System;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json
{
	/// <summary>
	///       Instructs the <see cref="T:Open_Newtonsoft_Json.JsonSerializer" /> to always serialize the member, and require the member has a value.
	///       </summary>
	[ComVisible(false)]
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
	public sealed class JsonRequiredAttribute : Attribute
	{
	}
}
