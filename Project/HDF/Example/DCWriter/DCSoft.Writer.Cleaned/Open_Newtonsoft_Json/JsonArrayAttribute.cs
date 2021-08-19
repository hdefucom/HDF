using System;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json
{
	/// <summary>
	///       Instructs the <see cref="T:Open_Newtonsoft_Json.JsonSerializer" /> how to serialize the collection.
	///       </summary>
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = false)]
	[ComVisible(false)]
	public sealed class JsonArrayAttribute : JsonContainerAttribute
	{
		private bool _allowNullItems;

		/// <summary>
		///       Gets or sets a value indicating whether null items are allowed in the collection.
		///       </summary>
		/// <value>
		///   <c>true</c> if null items are allowed in the collection; otherwise, <c>false</c>.</value>
		public bool AllowNullItems
		{
			get
			{
				return _allowNullItems;
			}
			set
			{
				_allowNullItems = value;
			}
		}

		/// <summary>
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.JsonArrayAttribute" /> class.
		///       </summary>
		public JsonArrayAttribute()
		{
		}

		/// <summary>
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.JsonObjectAttribute" /> class with a flag indicating whether the array can contain null items
		///       </summary>
		/// <param name="allowNullItems">A flag indicating whether the array can contain null items.</param>
		public JsonArrayAttribute(bool allowNullItems)
		{
			_allowNullItems = allowNullItems;
		}

		/// <summary>
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.JsonArrayAttribute" /> class with the specified container Id.
		///       </summary>
		/// <param name="id">The container Id.</param>
		public JsonArrayAttribute(string string_0)
			: base(string_0)
		{
		}
	}
}
