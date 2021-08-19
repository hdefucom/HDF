using Open_Newtonsoft_Json.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Serialization
{
	/// <summary>
	///       Contract details for a <see cref="T:System.Type" /> used by the <see cref="T:Open_Newtonsoft_Json.JsonSerializer" />.
	///       </summary>
	[ComVisible(false)]
	public class JsonArrayContract : JsonContainerContract
	{
		private readonly Type _genericCollectionDefinitionType;

		private Type _genericWrapperType;

		private ObjectConstructor<object> _genericWrapperCreator;

		private Func<object> _genericTemporaryCollectionCreator;

		private readonly ConstructorInfo _parametrizedConstructor;

		private ObjectConstructor<object> _parametrizedCreator;

		/// <summary>
		///       Gets the <see cref="T:System.Type" /> of the collection items.
		///       </summary>
		/// <value>The <see cref="T:System.Type" /> of the collection items.</value>
		public Type CollectionItemType
		{
			get;
			private set;
		}

		/// <summary>
		///       Gets a value indicating whether the collection type is a multidimensional array.
		///       </summary>
		/// <value>
		///   <c>true</c> if the collection type is a multidimensional array; otherwise, <c>false</c>.</value>
		public bool IsMultidimensionalArray
		{
			get;
			private set;
		}

		internal bool IsArray
		{
			get;
			private set;
		}

		internal bool ShouldCreateWrapper
		{
			get;
			private set;
		}

		internal bool CanDeserialize
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
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.Serialization.JsonArrayContract" /> class.
		///       </summary>
		/// <param name="underlyingType">The underlying type for the contract.</param>
		public JsonArrayContract(Type underlyingType)
			: base(underlyingType)
		{
			ContractType = JsonContractType.Array;
			IsArray = base.CreatedType.IsArray;
			bool canDeserialize;
			Type implementingType;
			if (IsArray)
			{
				CollectionItemType = ReflectionUtils.GetCollectionItemType(base.UnderlyingType);
				IsReadOnlyOrFixedSize = true;
				_genericCollectionDefinitionType = typeof(List<>).MakeGenericType(CollectionItemType);
				canDeserialize = true;
				IsMultidimensionalArray = (IsArray && base.UnderlyingType.GetArrayRank() > 1);
			}
			else if (typeof(IList).IsAssignableFrom(underlyingType))
			{
				if (ReflectionUtils.ImplementsGenericDefinition(underlyingType, typeof(ICollection<>), out _genericCollectionDefinitionType))
				{
					CollectionItemType = _genericCollectionDefinitionType.GetGenericArguments()[0];
				}
				else
				{
					CollectionItemType = ReflectionUtils.GetCollectionItemType(underlyingType);
				}
				if (underlyingType == typeof(IList))
				{
					base.CreatedType = typeof(List<object>);
				}
				if (CollectionItemType != null)
				{
					_parametrizedConstructor = CollectionUtils.ResolveEnumerableCollectionConstructor(underlyingType, CollectionItemType);
				}
				IsReadOnlyOrFixedSize = ReflectionUtils.InheritsGenericDefinition(underlyingType, typeof(ReadOnlyCollection<>));
				canDeserialize = true;
			}
			else if (ReflectionUtils.ImplementsGenericDefinition(underlyingType, typeof(ICollection<>), out _genericCollectionDefinitionType))
			{
				CollectionItemType = _genericCollectionDefinitionType.GetGenericArguments()[0];
				if (ReflectionUtils.IsGenericDefinition(underlyingType, typeof(ICollection<>)) || ReflectionUtils.IsGenericDefinition(underlyingType, typeof(IList<>)))
				{
					base.CreatedType = typeof(List<>).MakeGenericType(CollectionItemType);
				}
				_parametrizedConstructor = CollectionUtils.ResolveEnumerableCollectionConstructor(underlyingType, CollectionItemType);
				canDeserialize = true;
				ShouldCreateWrapper = true;
			}
			else if (ReflectionUtils.ImplementsGenericDefinition(underlyingType, typeof(IEnumerable<>), out implementingType))
			{
				CollectionItemType = implementingType.GetGenericArguments()[0];
				if (ReflectionUtils.IsGenericDefinition(base.UnderlyingType, typeof(IEnumerable<>)))
				{
					base.CreatedType = typeof(List<>).MakeGenericType(CollectionItemType);
				}
				_parametrizedConstructor = CollectionUtils.ResolveEnumerableCollectionConstructor(underlyingType, CollectionItemType);
				if (TypeExtensions.IsGenericType(underlyingType) && underlyingType.GetGenericTypeDefinition() == typeof(IEnumerable<>))
				{
					_genericCollectionDefinitionType = implementingType;
					IsReadOnlyOrFixedSize = false;
					ShouldCreateWrapper = false;
					canDeserialize = true;
				}
				else
				{
					_genericCollectionDefinitionType = typeof(List<>).MakeGenericType(CollectionItemType);
					IsReadOnlyOrFixedSize = true;
					ShouldCreateWrapper = true;
					canDeserialize = HasParametrizedCreator;
				}
			}
			else
			{
				canDeserialize = false;
				ShouldCreateWrapper = true;
			}
			CanDeserialize = canDeserialize;
			if (CollectionItemType != null && ReflectionUtils.IsNullableType(CollectionItemType) && (ReflectionUtils.InheritsGenericDefinition(base.CreatedType, typeof(List<>), out implementingType) || (IsArray && !IsMultidimensionalArray)))
			{
				ShouldCreateWrapper = true;
			}
		}

		internal IWrappedCollection CreateWrapper(object list)
		{
			if (_genericWrapperCreator == null)
			{
				_genericWrapperType = typeof(CollectionWrapper<>).MakeGenericType(CollectionItemType);
				Type type = (!ReflectionUtils.InheritsGenericDefinition(_genericCollectionDefinitionType, typeof(List<>)) && _genericCollectionDefinitionType.GetGenericTypeDefinition() != typeof(IEnumerable<>)) ? _genericCollectionDefinitionType : typeof(ICollection<>).MakeGenericType(CollectionItemType);
				ConstructorInfo constructor = _genericWrapperType.GetConstructor(new Type[1]
				{
					type
				});
				_genericWrapperCreator = JsonTypeReflector.ReflectionDelegateFactory.CreateParametrizedConstructor(constructor);
			}
			return (IWrappedCollection)_genericWrapperCreator(list);
		}

		internal IList CreateTemporaryCollection()
		{
			if (_genericTemporaryCollectionCreator == null)
			{
				Type type = IsMultidimensionalArray ? typeof(object) : CollectionItemType;
				Type type2 = typeof(List<>).MakeGenericType(type);
				_genericTemporaryCollectionCreator = JsonTypeReflector.ReflectionDelegateFactory.CreateDefaultConstructor<object>(type2);
			}
			return (IList)_genericTemporaryCollectionCreator();
		}
	}
}
