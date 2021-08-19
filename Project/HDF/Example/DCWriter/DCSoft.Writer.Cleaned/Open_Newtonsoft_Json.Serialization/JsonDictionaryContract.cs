using Open_Newtonsoft_Json.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Serialization
{
	/// <summary>
	///       Contract details for a <see cref="T:System.Type" /> used by the <see cref="T:Open_Newtonsoft_Json.JsonSerializer" />.
	///       </summary>
	[ComVisible(false)]
	public class JsonDictionaryContract : JsonContainerContract
	{
		private readonly Type _genericCollectionDefinitionType;

		private Type _genericWrapperType;

		private ObjectConstructor<object> _genericWrapperCreator;

		private Func<object> _genericTemporaryDictionaryCreator;

		private readonly ConstructorInfo _parametrizedConstructor;

		private ObjectConstructor<object> _parametrizedCreator;

		/// <summary>
		///       Gets or sets the property name resolver.
		///       </summary>
		/// <value>The property name resolver.</value>
		[Obsolete("PropertyNameResolver is obsolete. Use DictionaryKeyResolver instead.")]
		public Func<string, string> PropertyNameResolver
		{
			get
			{
				return DictionaryKeyResolver;
			}
			set
			{
				DictionaryKeyResolver = value;
			}
		}

		/// <summary>
		///       Gets or sets the dictionary key resolver.
		///       </summary>
		/// <value>The dictionary key resolver.</value>
		public Func<string, string> DictionaryKeyResolver
		{
			get;
			set;
		}

		/// <summary>
		///       Gets the <see cref="T:System.Type" /> of the dictionary keys.
		///       </summary>
		/// <value>The <see cref="T:System.Type" /> of the dictionary keys.</value>
		public Type DictionaryKeyType
		{
			get;
			private set;
		}

		/// <summary>
		///       Gets the <see cref="T:System.Type" /> of the dictionary values.
		///       </summary>
		/// <value>The <see cref="T:System.Type" /> of the dictionary values.</value>
		public Type DictionaryValueType
		{
			get;
			private set;
		}

		internal JsonContract KeyContract
		{
			get;
			set;
		}

		internal bool ShouldCreateWrapper
		{
			get;
			private set;
		}

		internal ObjectConstructor<object> ParametrizedCreator
		{
			get
			{
				if (_parametrizedCreator == null)
				{
					_parametrizedCreator = JsonTypeReflector.ReflectionDelegateFactory.CreateParametrizedConstructor(_parametrizedConstructor);
				}
				return _parametrizedCreator;
			}
		}

		internal bool HasParametrizedCreator => _parametrizedCreator != null || _parametrizedConstructor != null;

		/// <summary>
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.Serialization.JsonDictionaryContract" /> class.
		///       </summary>
		/// <param name="underlyingType">The underlying type for the contract.</param>
		public JsonDictionaryContract(Type underlyingType)
			: base(underlyingType)
		{
			ContractType = JsonContractType.Dictionary;
			Type keyType;
			Type valueType;
			if (ReflectionUtils.ImplementsGenericDefinition(underlyingType, typeof(IDictionary<, >), out _genericCollectionDefinitionType))
			{
				keyType = _genericCollectionDefinitionType.GetGenericArguments()[0];
				valueType = _genericCollectionDefinitionType.GetGenericArguments()[1];
				if (ReflectionUtils.IsGenericDefinition(base.UnderlyingType, typeof(IDictionary<, >)))
				{
					base.CreatedType = typeof(Dictionary<, >).MakeGenericType(keyType, valueType);
				}
			}
			else
			{
				ReflectionUtils.GetDictionaryKeyValueTypes(base.UnderlyingType, out keyType, out valueType);
				if (base.UnderlyingType == typeof(IDictionary))
				{
					base.CreatedType = typeof(Dictionary<object, object>);
				}
			}
			if (keyType != null && valueType != null)
			{
				_parametrizedConstructor = CollectionUtils.ResolveEnumerableCollectionConstructor(base.CreatedType, typeof(KeyValuePair<, >).MakeGenericType(keyType, valueType));
			}
			ShouldCreateWrapper = !typeof(IDictionary).IsAssignableFrom(base.CreatedType);
			DictionaryKeyType = keyType;
			DictionaryValueType = valueType;
			if (DictionaryValueType != null && ReflectionUtils.IsNullableType(DictionaryValueType) && ReflectionUtils.InheritsGenericDefinition(base.CreatedType, typeof(Dictionary<, >), out Type _))
			{
				ShouldCreateWrapper = true;
			}
		}

		internal IWrappedDictionary CreateWrapper(object dictionary)
		{
			if (_genericWrapperCreator == null)
			{
				_genericWrapperType = typeof(DictionaryWrapper<, >).MakeGenericType(DictionaryKeyType, DictionaryValueType);
				ConstructorInfo constructor = _genericWrapperType.GetConstructor(new Type[1]
				{
					_genericCollectionDefinitionType
				});
				_genericWrapperCreator = JsonTypeReflector.ReflectionDelegateFactory.CreateParametrizedConstructor(constructor);
			}
			return (IWrappedDictionary)_genericWrapperCreator(dictionary);
		}

		internal IDictionary CreateTemporaryDictionary()
		{
			if (_genericTemporaryDictionaryCreator == null)
			{
				Type type = typeof(Dictionary<, >).MakeGenericType(DictionaryKeyType, DictionaryValueType);
				_genericTemporaryDictionaryCreator = JsonTypeReflector.ReflectionDelegateFactory.CreateDefaultConstructor<object>(type);
			}
			return (IDictionary)_genericTemporaryDictionaryCreator();
		}
	}
}
