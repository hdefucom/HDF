using Open_Newtonsoft_Json.Utilities;
using System;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Serialization
{
	/// <summary>
	///       Contract details for a <see cref="T:System.Type" /> used by the <see cref="T:Open_Newtonsoft_Json.JsonSerializer" />.
	///       </summary>
	[ComVisible(false)]
	public class JsonContainerContract : JsonContract
	{
		private JsonContract _itemContract;

		private JsonContract _finalItemContract;

		internal JsonContract ItemContract
		{
			get
			{
				return _itemContract;
			}
			set
			{
				_itemContract = value;
				if (_itemContract != null)
				{
					_finalItemContract = (TypeExtensions.IsSealed(_itemContract.UnderlyingType) ? _itemContract : null);
				}
				else
				{
					_finalItemContract = null;
				}
			}
		}

		internal JsonContract FinalItemContract => _finalItemContract;

		/// <summary>
		///       Gets or sets the default collection items <see cref="T:Open_Newtonsoft_Json.JsonConverter" />.
		///       </summary>
		/// <value>The converter.</value>
		public JsonConverter ItemConverter
		{
			get;
			set;
		}

		/// <summary>
		///       Gets or sets a value indicating whether the collection items preserve object references.
		///       </summary>
		/// <value>
		///   <c>true</c> if collection items preserve object references; otherwise, <c>false</c>.</value>
		public bool? ItemIsReference
		{
			get;
			set;
		}

		/// <summary>
		///       Gets or sets the collection item reference loop handling.
		///       </summary>
		/// <value>The reference loop handling.</value>
		public ReferenceLoopHandling? ItemReferenceLoopHandling
		{
			get;
			set;
		}

		/// <summary>
		///       Gets or sets the collection item type name handling.
		///       </summary>
		/// <value>The type name handling.</value>
		public TypeNameHandling? ItemTypeNameHandling
		{
			get;
			set;
		}

		/// <summary>
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.Serialization.JsonContainerContract" /> class.
		///       </summary>
		/// <param name="underlyingType">The underlying type for the contract.</param>
		internal JsonContainerContract(Type underlyingType)
			: base(underlyingType)
		{
			JsonContainerAttribute cachedAttribute = JsonTypeReflector.GetCachedAttribute<JsonContainerAttribute>(underlyingType);
			if (cachedAttribute != null)
			{
				if (cachedAttribute.ItemConverterType != null)
				{
					ItemConverter = JsonTypeReflector.CreateJsonConverterInstance(cachedAttribute.ItemConverterType, cachedAttribute.ItemConverterParameters);
				}
				ItemIsReference = cachedAttribute._itemIsReference;
				ItemReferenceLoopHandling = cachedAttribute._itemReferenceLoopHandling;
				ItemTypeNameHandling = cachedAttribute._itemTypeNameHandling;
			}
		}
	}
}
