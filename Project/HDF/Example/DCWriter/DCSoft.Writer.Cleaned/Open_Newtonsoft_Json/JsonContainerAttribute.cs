using System;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json
{
	/// <summary>
	///       Instructs the <see cref="T:Open_Newtonsoft_Json.JsonSerializer" /> how to serialize the object.
	///       </summary>
	[ComVisible(false)]
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = false)]
	public abstract class JsonContainerAttribute : Attribute
	{
		internal bool? _isReference;

		internal bool? _itemIsReference;

		internal ReferenceLoopHandling? _itemReferenceLoopHandling;

		internal TypeNameHandling? _itemTypeNameHandling;

		/// <summary>
		///       Gets or sets the id.
		///       </summary>
		/// <value>The id.</value>
		public string Id
		{
			get;
			set;
		}

		/// <summary>
		///       Gets or sets the title.
		///       </summary>
		/// <value>The title.</value>
		public string Title
		{
			get;
			set;
		}

		/// <summary>
		///       Gets or sets the description.
		///       </summary>
		/// <value>The description.</value>
		public string Description
		{
			get;
			set;
		}

		/// <summary>
		///       Gets the collection's items converter.
		///       </summary>
		/// <value>The collection's items converter.</value>
		public Type ItemConverterType
		{
			get;
			set;
		}

		/// <summary>
		///       The parameter list to use when constructing the JsonConverter described by ItemConverterType.
		///       If null, the default constructor is used.
		///       When non-null, there must be a constructor defined in the JsonConverter that exactly matches the number,
		///       order, and type of these parameters.
		///       </summary>
		/// <example>
		///       [JsonContainer(ItemConverterType = typeof(MyContainerConverter), ItemConverterParameters = new object[] { 123, "Four" })]
		///       </example>
		public object[] ItemConverterParameters
		{
			get;
			set;
		}

		/// <summary>
		///       Gets or sets a value that indicates whether to preserve object references.
		///       </summary>
		/// <value>
		///   <c>true</c> to keep object reference; otherwise, <c>false</c>. The default is <c>false</c>.
		///       </value>
		public bool IsReference
		{
			get
			{
				return _isReference ?? false;
			}
			set
			{
				_isReference = value;
			}
		}

		/// <summary>
		///       Gets or sets a value that indicates whether to preserve collection's items references.
		///       </summary>
		/// <value>
		///   <c>true</c> to keep collection's items object references; otherwise, <c>false</c>. The default is <c>false</c>.
		///       </value>
		public bool ItemIsReference
		{
			get
			{
				return _itemIsReference ?? false;
			}
			set
			{
				_itemIsReference = value;
			}
		}

		/// <summary>
		///       Gets or sets the reference loop handling used when serializing the collection's items.
		///       </summary>
		/// <value>The reference loop handling.</value>
		public ReferenceLoopHandling ItemReferenceLoopHandling
		{
			get
			{
				return _itemReferenceLoopHandling ?? ReferenceLoopHandling.Error;
			}
			set
			{
				_itemReferenceLoopHandling = value;
			}
		}

		/// <summary>
		///       Gets or sets the type name handling used when serializing the collection's items.
		///       </summary>
		/// <value>The type name handling.</value>
		public TypeNameHandling ItemTypeNameHandling
		{
			get
			{
				return _itemTypeNameHandling ?? TypeNameHandling.None;
			}
			set
			{
				_itemTypeNameHandling = value;
			}
		}

		/// <summary>
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.JsonContainerAttribute" /> class.
		///       </summary>
		protected JsonContainerAttribute()
		{
		}

		/// <summary>
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.JsonContainerAttribute" /> class with the specified container Id.
		///       </summary>
		/// <param name="id">The container Id.</param>
		protected JsonContainerAttribute(string string_0)
		{
			Id = string_0;
		}
	}
}
