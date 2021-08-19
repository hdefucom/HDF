using System;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json
{
	/// <summary>
	///       Instructs the <see cref="T:Open_Newtonsoft_Json.JsonSerializer" /> how to serialize the object.
	///       </summary>
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface, AllowMultiple = false)]
	[ComVisible(false)]
	public sealed class JsonObjectAttribute : JsonContainerAttribute
	{
		private MemberSerialization _memberSerialization = MemberSerialization.OptOut;

		internal Required? _itemRequired;

		/// <summary>
		///       Gets or sets the member serialization.
		///       </summary>
		/// <value>The member serialization.</value>
		public MemberSerialization MemberSerialization
		{
			get
			{
				return _memberSerialization;
			}
			set
			{
				_memberSerialization = value;
			}
		}

		/// <summary>
		///       Gets or sets a value that indicates whether the object's properties are required.
		///       </summary>
		/// <value>
		///       	A value indicating whether the object's properties are required.
		///       </value>
		public Required ItemRequired
		{
			get
			{
				return _itemRequired ?? Required.Default;
			}
			set
			{
				_itemRequired = value;
			}
		}

		/// <summary>
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.JsonObjectAttribute" /> class.
		///       </summary>
		public JsonObjectAttribute()
		{
		}

		/// <summary>
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.JsonObjectAttribute" /> class with the specified member serialization.
		///       </summary>
		/// <param name="memberSerialization">The member serialization.</param>
		public JsonObjectAttribute(MemberSerialization memberSerialization)
		{
			MemberSerialization = memberSerialization;
		}

		/// <summary>
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.JsonObjectAttribute" /> class with the specified container Id.
		///       </summary>
		/// <param name="id">The container Id.</param>
		public JsonObjectAttribute(string string_0)
			: base(string_0)
		{
		}
	}
}
