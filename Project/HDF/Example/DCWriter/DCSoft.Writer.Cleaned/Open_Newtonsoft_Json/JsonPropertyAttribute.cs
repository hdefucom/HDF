using System;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json
{
	/// <summary>
	///       Instructs the <see cref="T:Open_Newtonsoft_Json.JsonSerializer" /> to always serialize the member with the specified name.
	///       </summary>
	[ComVisible(false)]
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
	public sealed class JsonPropertyAttribute : Attribute
	{
		internal NullValueHandling? _nullValueHandling;

		internal DefaultValueHandling? _defaultValueHandling;

		internal ReferenceLoopHandling? _referenceLoopHandling;

		internal ObjectCreationHandling? _objectCreationHandling;

		internal TypeNameHandling? _typeNameHandling;

		internal bool? _isReference;

		internal int? _order;

		internal Required? _required;

		internal bool? _itemIsReference;

		internal ReferenceLoopHandling? _itemReferenceLoopHandling;

		internal TypeNameHandling? _itemTypeNameHandling;

		/// <summary>
		///       Gets or sets the converter used when serializing the property's collection items.
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
		///       [JsonProperty(ItemConverterType = typeof(MyContainerConverter), ItemConverterParameters = new object[] { 123, "Four" })]
		///       </example>
		public object[] ItemConverterParameters
		{
			get;
			set;
		}

		/// <summary>
		///       Gets or sets the null value handling used when serializing this property.
		///       </summary>
		/// <value>The null value handling.</value>
		public NullValueHandling NullValueHandling
		{
			get
			{
				return _nullValueHandling ?? NullValueHandling.Include;
			}
			set
			{
				_nullValueHandling = value;
			}
		}

		/// <summary>
		///       Gets or sets the default value handling used when serializing this property.
		///       </summary>
		/// <value>The default value handling.</value>
		public DefaultValueHandling DefaultValueHandling
		{
			get
			{
				return _defaultValueHandling ?? DefaultValueHandling.Include;
			}
			set
			{
				_defaultValueHandling = value;
			}
		}

		/// <summary>
		///       Gets or sets the reference loop handling used when serializing this property.
		///       </summary>
		/// <value>The reference loop handling.</value>
		public ReferenceLoopHandling ReferenceLoopHandling
		{
			get
			{
				return _referenceLoopHandling ?? ReferenceLoopHandling.Error;
			}
			set
			{
				_referenceLoopHandling = value;
			}
		}

		/// <summary>
		///       Gets or sets the object creation handling used when deserializing this property.
		///       </summary>
		/// <value>The object creation handling.</value>
		public ObjectCreationHandling ObjectCreationHandling
		{
			get
			{
				return _objectCreationHandling ?? ObjectCreationHandling.Auto;
			}
			set
			{
				_objectCreationHandling = value;
			}
		}

		/// <summary>
		///       Gets or sets the type name handling used when serializing this property.
		///       </summary>
		/// <value>The type name handling.</value>
		public TypeNameHandling TypeNameHandling
		{
			get
			{
				return _typeNameHandling ?? TypeNameHandling.None;
			}
			set
			{
				_typeNameHandling = value;
			}
		}

		/// <summary>
		///       Gets or sets whether this property's value is serialized as a reference.
		///       </summary>
		/// <value>Whether this property's value is serialized as a reference.</value>
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
		///       Gets or sets the order of serialization and deserialization of a member.
		///       </summary>
		/// <value>The numeric order of serialization or deserialization.</value>
		public int Order
		{
			get
			{
				return _order ?? 0;
			}
			set
			{
				_order = value;
			}
		}

		/// <summary>
		///       Gets or sets a value indicating whether this property is required.
		///       </summary>
		/// <value>
		///       	A value indicating whether this property is required.
		///       </value>
		public Required Required
		{
			get
			{
				return _required ?? Required.Default;
			}
			set
			{
				_required = value;
			}
		}

		/// <summary>
		///       Gets or sets the name of the property.
		///       </summary>
		/// <value>The name of the property.</value>
		public string PropertyName
		{
			get;
			set;
		}

		/// <summary>
		///       Gets or sets the the reference loop handling used when serializing the property's collection items.
		///       </summary>
		/// <value>The collection's items reference loop handling.</value>
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
		///       Gets or sets the the type name handling used when serializing the property's collection items.
		///       </summary>
		/// <value>The collection's items type name handling.</value>
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
		///       Gets or sets whether this property's collection items are serialized as a reference.
		///       </summary>
		/// <value>Whether this property's collection items are serialized as a reference.</value>
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
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.JsonPropertyAttribute" /> class.
		///       </summary>
		public JsonPropertyAttribute()
		{
		}

		/// <summary>
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.JsonPropertyAttribute" /> class with the specified name.
		///       </summary>
		/// <param name="propertyName">Name of the property.</param>
		public JsonPropertyAttribute(string propertyName)
		{
			PropertyName = propertyName;
		}
	}
}
