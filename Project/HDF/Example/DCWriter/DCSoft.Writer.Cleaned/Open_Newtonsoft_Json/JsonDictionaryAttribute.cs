using System;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json
{
	/// <summary>
	///       Instructs the <see cref="T:Open_Newtonsoft_Json.JsonSerializer" /> how to serialize the collection.
	///       </summary>
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = false)]
	[ComVisible(false)]
	public sealed class JsonDictionaryAttribute : JsonContainerAttribute
	{
		/// <summary>
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.JsonDictionaryAttribute" /> class.
		///       </summary>
		public JsonDictionaryAttribute()
		{
		}

		/// <summary>
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.JsonDictionaryAttribute" /> class with the specified container Id.
		///       </summary>
		/// <param name="id">The container Id.</param>
		public JsonDictionaryAttribute(string string_0)
			: base(string_0)
		{
		}
	}
}
