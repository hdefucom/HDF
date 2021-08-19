using Open_Newtonsoft_Json.Converters;
using Open_Newtonsoft_Json.Linq;
using Open_Newtonsoft_Json.Utilities;
using Open_Newtonsoft_Json.Utilities.LinqBridge;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Open_Newtonsoft_Json.Serialization
{
	/// <summary>
	///       Used by <see cref="T:Open_Newtonsoft_Json.JsonSerializer" /> to resolves a <see cref="T:Open_Newtonsoft_Json.Serialization.JsonContract" /> for a given <see cref="T:System.Type" />.
	///       </summary>
	[ComVisible(false)]
	public class DefaultContractResolver : IContractResolver
	{
		[ComVisible(false)]
		internal struct DictionaryEnumerator<TEnumeratorKey, TEnumeratorValue> : IEnumerable<KeyValuePair<object, object>>, IEnumerator<KeyValuePair<object, object>>
		{
			private readonly IEnumerator<KeyValuePair<TEnumeratorKey, TEnumeratorValue>> _e;

			public KeyValuePair<object, object> Current => new KeyValuePair<object, object>(_e.Current.Key, _e.Current.Value);

			object IEnumerator.Current => Current;

			public DictionaryEnumerator(IEnumerable<KeyValuePair<TEnumeratorKey, TEnumeratorValue>> ienumerable_0)
			{
				ValidationUtils.ArgumentNotNull(ienumerable_0, "e");
				_e = ienumerable_0.GetEnumerator();
			}

			public bool MoveNext()
			{
				return _e.MoveNext();
			}

			public void Reset()
			{
				_e.Reset();
			}

			public void Dispose()
			{
				_e.Dispose();
			}

			public IEnumerator<KeyValuePair<object, object>> GetEnumerator()
			{
				return this;
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return this;
			}
		}

		private static readonly IContractResolver _instance = new DefaultContractResolver(shareCache: true);

		private static readonly JsonConverter[] BuiltInConverters = new JsonConverter[7]
		{
			new XmlNodeConverter(),
			new BinaryConverter(),
			new DataSetConverter(),
			new DataTableConverter(),
			new KeyValuePairConverter(),
			new BsonObjectIdConverter(),
			new RegexConverter()
		};

		private static readonly object TypeContractCacheLock = new object();

		private static readonly DefaultContractResolverState _sharedState = new DefaultContractResolverState();

		private readonly DefaultContractResolverState _instanceState = new DefaultContractResolverState();

		private readonly bool _sharedCache;

		internal static IContractResolver Instance => _instance;

		/// <summary>
		///       Gets a value indicating whether members are being get and set using dynamic code generation.
		///       This value is determined by the runtime permissions available.
		///       </summary>
		/// <value>
		///   <c>true</c> if using dynamic code generation; otherwise, <c>false</c>.
		///       </value>
		public bool DynamicCodeGeneration => JsonTypeReflector.DynamicCodeGeneration;

		/// <summary>
		///       Gets or sets the default members search flags.
		///       </summary>
		/// <value>The default members search flags.</value>
		[Obsolete("DefaultMembersSearchFlags is obsolete. To modify the members serialized inherit from DefaultContractResolver and override the GetSerializableMembers method instead.")]
		public BindingFlags DefaultMembersSearchFlags
		{
			get;
			set;
		}

		/// <summary>
		///       Gets or sets a value indicating whether compiler generated members should be serialized.
		///       </summary>
		/// <value>
		///   <c>true</c> if serialized compiler generated members; otherwise, <c>false</c>.
		///       </value>
		public bool SerializeCompilerGeneratedMembers
		{
			get;
			set;
		}

		/// <summary>
		///       Gets or sets a value indicating whether to ignore the <see cref="T:System.Runtime.Serialization.ISerializable" /> interface when serializing and deserializing types.
		///       </summary>
		/// <value>
		///   <c>true</c> if the <see cref="T:System.Runtime.Serialization.ISerializable" /> interface will be ignored when serializing and deserializing types; otherwise, <c>false</c>.
		///       </value>
		public bool IgnoreSerializableInterface
		{
			get;
			set;
		}

		/// <summary>
		///       Gets or sets a value indicating whether to ignore the <see cref="T:System.SerializableAttribute" /> attribute when serializing and deserializing types.
		///       </summary>
		/// <value>
		///   <c>true</c> if the <see cref="T:System.SerializableAttribute" /> attribute will be ignored when serializing and deserializing types; otherwise, <c>false</c>.
		///       </value>
		public bool IgnoreSerializableAttribute
		{
			get;
			set;
		}

		/// <summary>
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.Serialization.DefaultContractResolver" /> class.
		///       </summary>
		public DefaultContractResolver()
		{
			DefaultMembersSearchFlags = (BindingFlags.Instance | BindingFlags.Public);
			IgnoreSerializableAttribute = true;
		}

		/// <summary>
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.Serialization.DefaultContractResolver" /> class.
		///       </summary>
		/// <param name="shareCache">
		///       If set to <c>true</c> the <see cref="T:Open_Newtonsoft_Json.Serialization.DefaultContractResolver" /> will use a cached shared with other resolvers of the same type.
		///       Sharing the cache will significantly improve performance with multiple resolver instances because expensive reflection will only
		///       happen once. This setting can cause unexpected behavior if different instances of the resolver are suppose to produce different
		///       results. When set to false it is highly recommended to reuse <see cref="T:Open_Newtonsoft_Json.Serialization.DefaultContractResolver" /> instances with the <see cref="T:Open_Newtonsoft_Json.JsonSerializer" />.
		///       </param>
		[Obsolete("DefaultContractResolver(bool) is obsolete. Use the parameterless constructor and cache instances of the contract resolver within your application for optimal performance.")]
		public DefaultContractResolver(bool shareCache)
			: this()
		{
			_sharedCache = shareCache;
		}

		internal DefaultContractResolverState GetState()
		{
			if (_sharedCache)
			{
				return _sharedState;
			}
			return _instanceState;
		}

		/// <summary>
		///       Resolves the contract for a given type.
		///       </summary>
		/// <param name="type">The type to resolve a contract for.</param>
		/// <returns>The contract for a given type.</returns>
		public virtual JsonContract ResolveContract(Type type)
		{
			int num = 2;
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			DefaultContractResolverState state = GetState();
			ResolverContractKey key = new ResolverContractKey(GetType(), type);
			JsonContract value = default(JsonContract);
			if (!(state.ContractCache?.TryGetValue(key, out value) ?? false))
			{
				value = CreateContract(type);
				lock (TypeContractCacheLock)
				{
					Dictionary<ResolverContractKey, JsonContract> contractCache = state.ContractCache;
					Dictionary<ResolverContractKey, JsonContract> dictionary = (contractCache != null) ? new Dictionary<ResolverContractKey, JsonContract>(contractCache) : new Dictionary<ResolverContractKey, JsonContract>();
					dictionary[key] = value;
					state.ContractCache = dictionary;
				}
			}
			return value;
		}

		/// <summary>
		///       Gets the serializable members for the type.
		///       </summary>
		/// <param name="objectType">The type to get serializable members for.</param>
		/// <returns>The serializable members for the type.</returns>
		protected virtual List<MemberInfo> GetSerializableMembers(Type objectType)
		{
			bool ignoreSerializableAttribute = IgnoreSerializableAttribute;
			MemberSerialization objectMemberSerialization = JsonTypeReflector.GetObjectMemberSerialization(objectType, ignoreSerializableAttribute);
			List<MemberInfo> list = Enumerable.ToList(Enumerable.Where(ReflectionUtils.GetFieldsAndProperties(objectType, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic), (MemberInfo memberInfo_0) => !ReflectionUtils.IsIndexedProperty(memberInfo_0)));
			List<MemberInfo> list2 = new List<MemberInfo>();
			if (objectMemberSerialization != MemberSerialization.Fields)
			{
				List<MemberInfo> list3 = Enumerable.ToList(Enumerable.Where(ReflectionUtils.GetFieldsAndProperties(objectType, DefaultMembersSearchFlags), (MemberInfo memberInfo_0) => !ReflectionUtils.IsIndexedProperty(memberInfo_0)));
				foreach (MemberInfo item in list)
				{
					if (SerializeCompilerGeneratedMembers || !item.IsDefined(typeof(CompilerGeneratedAttribute), inherit: true))
					{
						if (list3.Contains(item))
						{
							list2.Add(item);
						}
						else if (JsonTypeReflector.GetAttribute<JsonPropertyAttribute>(item) != null)
						{
							list2.Add(item);
						}
						else if (JsonTypeReflector.GetAttribute<JsonRequiredAttribute>(item) != null)
						{
							list2.Add(item);
						}
						else if (objectMemberSerialization == MemberSerialization.Fields && TypeExtensions.MemberType(item) == MemberTypes.Field)
						{
							list2.Add(item);
						}
					}
				}
			}
			else
			{
				foreach (MemberInfo item2 in list)
				{
					if (!((item2 as FieldInfo)?.IsStatic ?? true))
					{
						list2.Add(item2);
					}
				}
			}
			return list2;
		}

		/// <summary>
		///       Creates a <see cref="T:Open_Newtonsoft_Json.Serialization.JsonObjectContract" /> for the given type.
		///       </summary>
		/// <param name="objectType">Type of the object.</param>
		/// <returns>A <see cref="T:Open_Newtonsoft_Json.Serialization.JsonObjectContract" /> for the given type.</returns>
		protected virtual JsonObjectContract CreateObjectContract(Type objectType)
		{
			JsonObjectContract jsonObjectContract = new JsonObjectContract(objectType);
			InitializeContract(jsonObjectContract);
			bool ignoreSerializableAttribute = IgnoreSerializableAttribute;
			jsonObjectContract.MemberSerialization = JsonTypeReflector.GetObjectMemberSerialization(jsonObjectContract.NonNullableUnderlyingType, ignoreSerializableAttribute);
			CollectionUtils.AddRange(jsonObjectContract.Properties, CreateProperties(jsonObjectContract.NonNullableUnderlyingType, jsonObjectContract.MemberSerialization));
			JsonObjectAttribute cachedAttribute = JsonTypeReflector.GetCachedAttribute<JsonObjectAttribute>(jsonObjectContract.NonNullableUnderlyingType);
			if (cachedAttribute != null)
			{
				jsonObjectContract.ItemRequired = cachedAttribute._itemRequired;
			}
			if (jsonObjectContract.IsInstantiable)
			{
				ConstructorInfo attributeConstructor = GetAttributeConstructor(jsonObjectContract.NonNullableUnderlyingType);
				if (attributeConstructor != null)
				{
					jsonObjectContract.OverrideConstructor = attributeConstructor;
					CollectionUtils.AddRange(jsonObjectContract.CreatorParameters, CreateConstructorParameters(attributeConstructor, jsonObjectContract.Properties));
				}
				else if (jsonObjectContract.MemberSerialization == MemberSerialization.Fields)
				{
					if (JsonTypeReflector.FullyTrusted)
					{
						jsonObjectContract.DefaultCreator = jsonObjectContract.GetUninitializedObject;
					}
				}
				else if (jsonObjectContract.DefaultCreator == null || jsonObjectContract.DefaultCreatorNonPublic)
				{
					ConstructorInfo parametrizedConstructor = GetParametrizedConstructor(jsonObjectContract.NonNullableUnderlyingType);
					if (parametrizedConstructor != null)
					{
						jsonObjectContract.ParametrizedConstructor = parametrizedConstructor;
						CollectionUtils.AddRange(jsonObjectContract.CreatorParameters, CreateConstructorParameters(parametrizedConstructor, jsonObjectContract.Properties));
					}
				}
			}
			MemberInfo extensionDataMemberForType = GetExtensionDataMemberForType(jsonObjectContract.NonNullableUnderlyingType);
			if (extensionDataMemberForType != null)
			{
				SetExtensionDataDelegates(jsonObjectContract, extensionDataMemberForType);
			}
			return jsonObjectContract;
		}

		private MemberInfo GetExtensionDataMemberForType(Type type)
		{
			IEnumerable<MemberInfo> source = Enumerable.SelectMany(GetClassHierarchyForType(type), delegate(Type baseType)
			{
				IList<MemberInfo> list = new List<MemberInfo>();
				CollectionUtils.AddRange(list, baseType.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
				CollectionUtils.AddRange(list, baseType.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
				return list;
			});
			return Enumerable.LastOrDefault(source, delegate(MemberInfo memberInfo_0)
			{
				int num = 6;
				MemberTypes memberTypes = TypeExtensions.MemberType(memberInfo_0);
				if (memberTypes != MemberTypes.Property && memberTypes != MemberTypes.Field)
				{
					return false;
				}
				if (memberInfo_0.IsDefined(typeof(JsonExtensionDataAttribute), inherit: false))
				{
					if (!ReflectionUtils.CanReadMemberValue(memberInfo_0, nonPublic: true))
					{
						throw new JsonException(StringUtils.FormatWith("Invalid extension data attribute on '{0}'. Member '{1}' must have a getter.", CultureInfo.InvariantCulture, GetClrTypeFullName(memberInfo_0.DeclaringType), memberInfo_0.Name));
					}
					Type memberUnderlyingType = ReflectionUtils.GetMemberUnderlyingType(memberInfo_0);
					if (ReflectionUtils.ImplementsGenericDefinition(memberUnderlyingType, typeof(IDictionary<, >), out Type implementingType))
					{
						Type type2 = implementingType.GetGenericArguments()[0];
						Type type3 = implementingType.GetGenericArguments()[1];
						if (type2.IsAssignableFrom(typeof(string)) && type3.IsAssignableFrom(typeof(JToken)))
						{
							return true;
						}
					}
					throw new JsonException(StringUtils.FormatWith("Invalid extension data attribute on '{0}'. Member '{1}' type must implement IDictionary<string, JToken>.", CultureInfo.InvariantCulture, GetClrTypeFullName(memberInfo_0.DeclaringType), memberInfo_0.Name));
				}
				return false;
			});
		}

		private static void SetExtensionDataDelegates(JsonObjectContract contract, MemberInfo member)
		{
			int num = 11;
			JsonExtensionDataAttribute attribute = ReflectionUtils.GetAttribute<JsonExtensionDataAttribute>(member);
			if (attribute != null)
			{
				Type memberUnderlyingType = ReflectionUtils.GetMemberUnderlyingType(member);
				ReflectionUtils.ImplementsGenericDefinition(memberUnderlyingType, typeof(IDictionary<, >), out Type implementingType);
				Type type = implementingType.GetGenericArguments()[0];
				Type type2 = implementingType.GetGenericArguments()[1];
				bool isJTokenValueType = typeof(JToken).IsAssignableFrom(type2);
				Type type3 = (!ReflectionUtils.IsGenericDefinition(memberUnderlyingType, typeof(IDictionary<, >))) ? memberUnderlyingType : typeof(Dictionary<, >).MakeGenericType(type, type2);
				Func<object, object> getExtensionDataDictionary = JsonTypeReflector.ReflectionDelegateFactory.CreateGet<object>(member);
				Action<object, object> setExtensionDataDictionary = ReflectionUtils.CanSetMemberValue(member, nonPublic: true, canSetReadOnly: false) ? JsonTypeReflector.ReflectionDelegateFactory.CreateSet<object>(member) : null;
				Func<object> createExtensionDataDictionary = JsonTypeReflector.ReflectionDelegateFactory.CreateDefaultConstructor<object>(type3);
				MethodInfo method = memberUnderlyingType.GetMethod("Add", new Type[2]
				{
					type,
					type2
				});
				MethodCall<object, object> setExtensionDataDictionaryValue = JsonTypeReflector.ReflectionDelegateFactory.CreateMethodCall<object>(method);
				ExtensionDataSetter extensionDataSetter = delegate(object object_0, string string_0, object value)
				{
					int num2 = 11;
					object obj2 = getExtensionDataDictionary(object_0);
					if (obj2 == null)
					{
						if (setExtensionDataDictionary == null)
						{
							throw new JsonSerializationException(StringUtils.FormatWith("Cannot set value onto extension data member '{0}'. The extension data collection is null and it cannot be set.", CultureInfo.InvariantCulture, member.Name));
						}
						obj2 = createExtensionDataDictionary();
						setExtensionDataDictionary(object_0, obj2);
					}
					if (isJTokenValueType && !(value is JToken))
					{
						value = ((value != null) ? JToken.FromObject(value) : JValue.CreateNull());
					}
					setExtensionDataDictionaryValue(obj2, string_0, value);
				};
				Type type4 = typeof(DictionaryEnumerator<, >).MakeGenericType(type, type2);
				ConstructorInfo method2 = Enumerable.First(type4.GetConstructors());
				ObjectConstructor<object> createEnumerableWrapper = JsonTypeReflector.ReflectionDelegateFactory.CreateParametrizedConstructor(method2);
				ExtensionDataGetter extensionDataGetter = delegate(object object_0)
				{
					object obj = getExtensionDataDictionary(object_0);
					return (obj == null) ? null : ((IEnumerable<KeyValuePair<object, object>>)createEnumerableWrapper(obj));
				};
				if (attribute.ReadData)
				{
					contract.ExtensionDataSetter = extensionDataSetter;
				}
				if (attribute.WriteData)
				{
					contract.ExtensionDataGetter = extensionDataGetter;
				}
			}
		}

		private ConstructorInfo GetAttributeConstructor(Type objectType)
		{
			int num = 14;
			IList<ConstructorInfo> list = Enumerable.ToList(Enumerable.Where(objectType.GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic), (ConstructorInfo constructorInfo_0) => constructorInfo_0.IsDefined(typeof(JsonConstructorAttribute), inherit: true)));
			if (list.Count > 1)
			{
				throw new JsonException("Multiple constructors with the JsonConstructorAttribute.");
			}
			if (list.Count == 1)
			{
				return list[0];
			}
			if (objectType == typeof(Version))
			{
				return objectType.GetConstructor(new Type[4]
				{
					typeof(int),
					typeof(int),
					typeof(int),
					typeof(int)
				});
			}
			return null;
		}

		private ConstructorInfo GetParametrizedConstructor(Type objectType)
		{
			IList<ConstructorInfo> list = Enumerable.ToList(objectType.GetConstructors(BindingFlags.Instance | BindingFlags.Public));
			if (list.Count == 1)
			{
				return list[0];
			}
			return null;
		}

		/// <summary>
		///       Creates the constructor parameters.
		///       </summary>
		/// <param name="constructor">The constructor to create properties for.</param>
		/// <param name="memberProperties">The type's member properties.</param>
		/// <returns>Properties for the given <see cref="T:System.Reflection.ConstructorInfo" />.</returns>
		protected virtual IList<JsonProperty> CreateConstructorParameters(ConstructorInfo constructor, JsonPropertyCollection memberProperties)
		{
			ParameterInfo[] parameters = constructor.GetParameters();
			JsonPropertyCollection jsonPropertyCollection = new JsonPropertyCollection(constructor.DeclaringType);
			ParameterInfo[] array = parameters;
			foreach (ParameterInfo parameterInfo in array)
			{
				JsonProperty jsonProperty = (parameterInfo.Name != null) ? memberProperties.GetClosestMatchProperty(parameterInfo.Name) : null;
				if (jsonProperty != null && jsonProperty.PropertyType != parameterInfo.ParameterType)
				{
					jsonProperty = null;
				}
				if (jsonProperty != null || parameterInfo.Name != null)
				{
					JsonProperty jsonProperty2 = CreatePropertyFromConstructorParameter(jsonProperty, parameterInfo);
					if (jsonProperty2 != null)
					{
						jsonPropertyCollection.AddProperty(jsonProperty2);
					}
				}
			}
			return jsonPropertyCollection;
		}

		/// <summary>
		///       Creates a <see cref="T:Open_Newtonsoft_Json.Serialization.JsonProperty" /> for the given <see cref="T:System.Reflection.ParameterInfo" />.
		///       </summary>
		/// <param name="matchingMemberProperty">The matching member property.</param>
		/// <param name="parameterInfo">The constructor parameter.</param>
		/// <returns>A created <see cref="T:Open_Newtonsoft_Json.Serialization.JsonProperty" /> for the given <see cref="T:System.Reflection.ParameterInfo" />.</returns>
		protected virtual JsonProperty CreatePropertyFromConstructorParameter(JsonProperty matchingMemberProperty, ParameterInfo parameterInfo)
		{
			JsonProperty jsonProperty = new JsonProperty();
			jsonProperty.PropertyType = parameterInfo.ParameterType;
			jsonProperty.AttributeProvider = new ReflectionAttributeProvider(parameterInfo);
			SetPropertySettingsFromAttributes(jsonProperty, parameterInfo, parameterInfo.Name, parameterInfo.Member.DeclaringType, MemberSerialization.OptOut, out bool _);
			jsonProperty.Readable = false;
			jsonProperty.Writable = true;
			if (matchingMemberProperty != null)
			{
				jsonProperty.PropertyName = ((jsonProperty.PropertyName != parameterInfo.Name) ? jsonProperty.PropertyName : matchingMemberProperty.PropertyName);
				jsonProperty.Converter = (jsonProperty.Converter ?? matchingMemberProperty.Converter);
				jsonProperty.MemberConverter = (jsonProperty.MemberConverter ?? matchingMemberProperty.MemberConverter);
				if (!jsonProperty._hasExplicitDefaultValue && matchingMemberProperty._hasExplicitDefaultValue)
				{
					jsonProperty.DefaultValue = matchingMemberProperty.DefaultValue;
				}
				jsonProperty._required = (jsonProperty._required ?? matchingMemberProperty._required);
				jsonProperty.IsReference = (jsonProperty.IsReference ?? matchingMemberProperty.IsReference);
				jsonProperty.NullValueHandling = (jsonProperty.NullValueHandling ?? matchingMemberProperty.NullValueHandling);
				jsonProperty.DefaultValueHandling = (jsonProperty.DefaultValueHandling ?? matchingMemberProperty.DefaultValueHandling);
				jsonProperty.ReferenceLoopHandling = (jsonProperty.ReferenceLoopHandling ?? matchingMemberProperty.ReferenceLoopHandling);
				jsonProperty.ObjectCreationHandling = (jsonProperty.ObjectCreationHandling ?? matchingMemberProperty.ObjectCreationHandling);
				jsonProperty.TypeNameHandling = (jsonProperty.TypeNameHandling ?? matchingMemberProperty.TypeNameHandling);
			}
			return jsonProperty;
		}

		/// <summary>
		///       Resolves the default <see cref="T:Open_Newtonsoft_Json.JsonConverter" /> for the contract.
		///       </summary>
		/// <param name="objectType">Type of the object.</param>
		/// <returns>The contract's default <see cref="T:Open_Newtonsoft_Json.JsonConverter" />.</returns>
		protected virtual JsonConverter ResolveContractConverter(Type objectType)
		{
			return JsonTypeReflector.GetJsonConverter(objectType);
		}

		private Func<object> GetDefaultCreator(Type createdType)
		{
			return JsonTypeReflector.ReflectionDelegateFactory.CreateDefaultConstructor<object>(createdType);
		}

		private void InitializeContract(JsonContract contract)
		{
			JsonContainerAttribute cachedAttribute = JsonTypeReflector.GetCachedAttribute<JsonContainerAttribute>(contract.NonNullableUnderlyingType);
			if (cachedAttribute != null)
			{
				contract.IsReference = cachedAttribute._isReference;
			}
			contract.Converter = ResolveContractConverter(contract.NonNullableUnderlyingType);
			contract.InternalConverter = JsonSerializer.GetMatchingConverter(BuiltInConverters, contract.NonNullableUnderlyingType);
			if (contract.IsInstantiable && (ReflectionUtils.HasDefaultConstructor(contract.CreatedType, nonPublic: true) || TypeExtensions.IsValueType(contract.CreatedType)))
			{
				contract.DefaultCreator = GetDefaultCreator(contract.CreatedType);
				contract.DefaultCreatorNonPublic = (!TypeExtensions.IsValueType(contract.CreatedType) && ReflectionUtils.GetDefaultConstructor(contract.CreatedType) == null);
			}
			ResolveCallbackMethods(contract, contract.NonNullableUnderlyingType);
		}

		private void ResolveCallbackMethods(JsonContract contract, Type type_0)
		{
			GetCallbackMethodsForType(type_0, out List<SerializationCallback> onSerializing, out List<SerializationCallback> onSerialized, out List<SerializationCallback> onDeserializing, out List<SerializationCallback> onDeserialized, out List<SerializationErrorCallback> onError);
			if (onSerializing != null)
			{
				CollectionUtils.AddRange(contract.OnSerializingCallbacks, onSerializing);
			}
			if (onSerialized != null)
			{
				CollectionUtils.AddRange(contract.OnSerializedCallbacks, onSerialized);
			}
			if (onDeserializing != null)
			{
				CollectionUtils.AddRange(contract.OnDeserializingCallbacks, onDeserializing);
			}
			if (onDeserialized != null)
			{
				CollectionUtils.AddRange(contract.OnDeserializedCallbacks, onDeserialized);
			}
			if (onError != null)
			{
				CollectionUtils.AddRange(contract.OnErrorCallbacks, onError);
			}
		}

		private void GetCallbackMethodsForType(Type type, out List<SerializationCallback> onSerializing, out List<SerializationCallback> onSerialized, out List<SerializationCallback> onDeserializing, out List<SerializationCallback> onDeserialized, out List<SerializationErrorCallback> onError)
		{
			onSerializing = null;
			onSerialized = null;
			onDeserializing = null;
			onDeserialized = null;
			onError = null;
			foreach (Type item in GetClassHierarchyForType(type))
			{
				MethodInfo currentCallback = null;
				MethodInfo currentCallback2 = null;
				MethodInfo currentCallback3 = null;
				MethodInfo currentCallback4 = null;
				MethodInfo currentCallback5 = null;
				bool flag = ShouldSkipSerializing(item);
				bool flag2 = ShouldSkipDeserialized(item);
				MethodInfo[] methods = item.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				foreach (MethodInfo methodInfo in methods)
				{
					if (!methodInfo.ContainsGenericParameters)
					{
						Type prevAttributeType = null;
						ParameterInfo[] parameters = methodInfo.GetParameters();
						if (!flag && IsValidCallback(methodInfo, parameters, typeof(OnSerializingAttribute), currentCallback, ref prevAttributeType))
						{
							onSerializing = (onSerializing ?? new List<SerializationCallback>());
							onSerializing.Add(JsonContract.CreateSerializationCallback(methodInfo));
							currentCallback = methodInfo;
						}
						if (IsValidCallback(methodInfo, parameters, typeof(OnSerializedAttribute), currentCallback2, ref prevAttributeType))
						{
							onSerialized = (onSerialized ?? new List<SerializationCallback>());
							onSerialized.Add(JsonContract.CreateSerializationCallback(methodInfo));
							currentCallback2 = methodInfo;
						}
						if (IsValidCallback(methodInfo, parameters, typeof(OnDeserializingAttribute), currentCallback3, ref prevAttributeType))
						{
							onDeserializing = (onDeserializing ?? new List<SerializationCallback>());
							onDeserializing.Add(JsonContract.CreateSerializationCallback(methodInfo));
							currentCallback3 = methodInfo;
						}
						if (!flag2 && IsValidCallback(methodInfo, parameters, typeof(OnDeserializedAttribute), currentCallback4, ref prevAttributeType))
						{
							onDeserialized = (onDeserialized ?? new List<SerializationCallback>());
							onDeserialized.Add(JsonContract.CreateSerializationCallback(methodInfo));
							currentCallback4 = methodInfo;
						}
						if (IsValidCallback(methodInfo, parameters, typeof(OnErrorAttribute), currentCallback5, ref prevAttributeType))
						{
							onError = (onError ?? new List<SerializationErrorCallback>());
							onError.Add(JsonContract.CreateSerializationErrorCallback(methodInfo));
							currentCallback5 = methodInfo;
						}
					}
				}
			}
		}

		private static bool ShouldSkipDeserialized(Type type_0)
		{
			return false;
		}

		private static bool ShouldSkipSerializing(Type type_0)
		{
			return false;
		}

		private List<Type> GetClassHierarchyForType(Type type)
		{
			List<Type> list = new List<Type>();
			Type type2 = type;
			while (type2 != null && type2 != typeof(object))
			{
				list.Add(type2);
				type2 = TypeExtensions.BaseType(type2);
			}
			list.Reverse();
			return list;
		}

		/// <summary>
		///       Creates a <see cref="T:Open_Newtonsoft_Json.Serialization.JsonDictionaryContract" /> for the given type.
		///       </summary>
		/// <param name="objectType">Type of the object.</param>
		/// <returns>A <see cref="T:Open_Newtonsoft_Json.Serialization.JsonDictionaryContract" /> for the given type.</returns>
		protected virtual JsonDictionaryContract CreateDictionaryContract(Type objectType)
		{
			JsonDictionaryContract jsonDictionaryContract = new JsonDictionaryContract(objectType);
			InitializeContract(jsonDictionaryContract);
			jsonDictionaryContract.DictionaryKeyResolver = ResolveDictionaryKey;
			return jsonDictionaryContract;
		}

		/// <summary>
		///       Creates a <see cref="T:Open_Newtonsoft_Json.Serialization.JsonArrayContract" /> for the given type.
		///       </summary>
		/// <param name="objectType">Type of the object.</param>
		/// <returns>A <see cref="T:Open_Newtonsoft_Json.Serialization.JsonArrayContract" /> for the given type.</returns>
		protected virtual JsonArrayContract CreateArrayContract(Type objectType)
		{
			JsonArrayContract jsonArrayContract = new JsonArrayContract(objectType);
			InitializeContract(jsonArrayContract);
			return jsonArrayContract;
		}

		/// <summary>
		///       Creates a <see cref="T:Open_Newtonsoft_Json.Serialization.JsonPrimitiveContract" /> for the given type.
		///       </summary>
		/// <param name="objectType">Type of the object.</param>
		/// <returns>A <see cref="T:Open_Newtonsoft_Json.Serialization.JsonPrimitiveContract" /> for the given type.</returns>
		protected virtual JsonPrimitiveContract CreatePrimitiveContract(Type objectType)
		{
			JsonPrimitiveContract jsonPrimitiveContract = new JsonPrimitiveContract(objectType);
			InitializeContract(jsonPrimitiveContract);
			return jsonPrimitiveContract;
		}

		/// <summary>
		///       Creates a <see cref="T:Open_Newtonsoft_Json.Serialization.JsonLinqContract" /> for the given type.
		///       </summary>
		/// <param name="objectType">Type of the object.</param>
		/// <returns>A <see cref="T:Open_Newtonsoft_Json.Serialization.JsonLinqContract" /> for the given type.</returns>
		protected virtual JsonLinqContract CreateLinqContract(Type objectType)
		{
			JsonLinqContract jsonLinqContract = new JsonLinqContract(objectType);
			InitializeContract(jsonLinqContract);
			return jsonLinqContract;
		}

		/// <summary>
		///       Creates a <see cref="T:Open_Newtonsoft_Json.Serialization.JsonISerializableContract" /> for the given type.
		///       </summary>
		/// <param name="objectType">Type of the object.</param>
		/// <returns>A <see cref="T:Open_Newtonsoft_Json.Serialization.JsonISerializableContract" /> for the given type.</returns>
		protected virtual JsonISerializableContract CreateISerializableContract(Type objectType)
		{
			JsonISerializableContract jsonISerializableContract = new JsonISerializableContract(objectType);
			InitializeContract(jsonISerializableContract);
			ConstructorInfo constructor = jsonISerializableContract.NonNullableUnderlyingType.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[2]
			{
				typeof(SerializationInfo),
				typeof(StreamingContext)
			}, null);
			if (constructor != null)
			{
				ObjectConstructor<object> objectConstructor2 = jsonISerializableContract.ISerializableCreator = JsonTypeReflector.ReflectionDelegateFactory.CreateParametrizedConstructor(constructor);
			}
			return jsonISerializableContract;
		}

		/// <summary>
		///       Creates a <see cref="T:Open_Newtonsoft_Json.Serialization.JsonStringContract" /> for the given type.
		///       </summary>
		/// <param name="objectType">Type of the object.</param>
		/// <returns>A <see cref="T:Open_Newtonsoft_Json.Serialization.JsonStringContract" /> for the given type.</returns>
		protected virtual JsonStringContract CreateStringContract(Type objectType)
		{
			JsonStringContract jsonStringContract = new JsonStringContract(objectType);
			InitializeContract(jsonStringContract);
			return jsonStringContract;
		}

		/// <summary>
		///       Determines which contract type is created for the given type.
		///       </summary>
		/// <param name="objectType">Type of the object.</param>
		/// <returns>A <see cref="T:Open_Newtonsoft_Json.Serialization.JsonContract" /> for the given type.</returns>
		protected virtual JsonContract CreateContract(Type objectType)
		{
			if (IsJsonPrimitiveType(objectType))
			{
				return CreatePrimitiveContract(objectType);
			}
			Type type = ReflectionUtils.EnsureNotNullableType(objectType);
			JsonContainerAttribute cachedAttribute = JsonTypeReflector.GetCachedAttribute<JsonContainerAttribute>(type);
			if (cachedAttribute is JsonObjectAttribute)
			{
				return CreateObjectContract(objectType);
			}
			if (cachedAttribute is JsonArrayAttribute)
			{
				return CreateArrayContract(objectType);
			}
			if (cachedAttribute is JsonDictionaryAttribute)
			{
				return CreateDictionaryContract(objectType);
			}
			if (type == typeof(JToken) || type.IsSubclassOf(typeof(JToken)))
			{
				return CreateLinqContract(objectType);
			}
			if (CollectionUtils.IsDictionaryType(type))
			{
				return CreateDictionaryContract(objectType);
			}
			if (typeof(IEnumerable).IsAssignableFrom(type))
			{
				return CreateArrayContract(objectType);
			}
			if (CanConvertToString(type))
			{
				return CreateStringContract(objectType);
			}
			if (!IgnoreSerializableInterface && typeof(ISerializable).IsAssignableFrom(type))
			{
				return CreateISerializableContract(objectType);
			}
			if (IsIConvertible(type))
			{
				return CreatePrimitiveContract(type);
			}
			return CreateObjectContract(objectType);
		}

		internal static bool IsJsonPrimitiveType(Type type_0)
		{
			PrimitiveTypeCode typeCode = ConvertUtils.GetTypeCode(type_0);
			return typeCode != 0 && typeCode != PrimitiveTypeCode.Object;
		}

		internal static bool IsIConvertible(Type type_0)
		{
			if (typeof(IConvertible).IsAssignableFrom(type_0) || (ReflectionUtils.IsNullableType(type_0) && typeof(IConvertible).IsAssignableFrom(Nullable.GetUnderlyingType(type_0))))
			{
				return !typeof(JToken).IsAssignableFrom(type_0);
			}
			return false;
		}

		internal static bool CanConvertToString(Type type)
		{
			TypeConverter converter = ConvertUtils.GetConverter(type);
			if (converter != null && !(converter is ComponentConverter) && !(converter is ReferenceConverter) && converter.GetType() != typeof(TypeConverter) && converter.CanConvertTo(typeof(string)))
			{
				return true;
			}
			if (type == typeof(Type) || type.IsSubclassOf(typeof(Type)))
			{
				return true;
			}
			return false;
		}

		private static bool IsValidCallback(MethodInfo method, ParameterInfo[] parameters, Type attributeType, MethodInfo currentCallback, ref Type prevAttributeType)
		{
			int num = 8;
			if (!method.IsDefined(attributeType, inherit: false))
			{
				return false;
			}
			if (currentCallback != null)
			{
				throw new JsonException(StringUtils.FormatWith("Invalid attribute. Both '{0}' and '{1}' in type '{2}' have '{3}'.", CultureInfo.InvariantCulture, method, currentCallback, GetClrTypeFullName(method.DeclaringType), attributeType));
			}
			if (prevAttributeType != null)
			{
				throw new JsonException(StringUtils.FormatWith("Invalid Callback. Method '{3}' in type '{2}' has both '{0}' and '{1}'.", CultureInfo.InvariantCulture, prevAttributeType, attributeType, GetClrTypeFullName(method.DeclaringType), method));
			}
			if (method.IsVirtual)
			{
				throw new JsonException(StringUtils.FormatWith("Virtual Method '{0}' of type '{1}' cannot be marked with '{2}' attribute.", CultureInfo.InvariantCulture, method, GetClrTypeFullName(method.DeclaringType), attributeType));
			}
			if (method.ReturnType != typeof(void))
			{
				throw new JsonException(StringUtils.FormatWith("Serialization Callback '{1}' in type '{0}' must return void.", CultureInfo.InvariantCulture, GetClrTypeFullName(method.DeclaringType), method));
			}
			if (attributeType == typeof(OnErrorAttribute))
			{
				if (parameters == null || parameters.Length != 2 || parameters[0].ParameterType != typeof(StreamingContext) || parameters[1].ParameterType != typeof(ErrorContext))
				{
					throw new JsonException(StringUtils.FormatWith("Serialization Error Callback '{1}' in type '{0}' must have two parameters of type '{2}' and '{3}'.", CultureInfo.InvariantCulture, GetClrTypeFullName(method.DeclaringType), method, typeof(StreamingContext), typeof(ErrorContext)));
				}
			}
			else if (parameters == null || parameters.Length != 1 || parameters[0].ParameterType != typeof(StreamingContext))
			{
				throw new JsonException(StringUtils.FormatWith("Serialization Callback '{1}' in type '{0}' must have a single parameter of type '{2}'.", CultureInfo.InvariantCulture, GetClrTypeFullName(method.DeclaringType), method, typeof(StreamingContext)));
			}
			prevAttributeType = attributeType;
			return true;
		}

		internal static string GetClrTypeFullName(Type type)
		{
			int num = 0;
			if (TypeExtensions.IsGenericTypeDefinition(type) || !TypeExtensions.ContainsGenericParameters(type))
			{
				return type.FullName;
			}
			return string.Format(CultureInfo.InvariantCulture, "{0}.{1}", type.Namespace, type.Name);
		}

		/// <summary>
		///       Creates properties for the given <see cref="T:Open_Newtonsoft_Json.Serialization.JsonContract" />.
		///       </summary>
		/// <param name="type">The type to create properties for.</param>
		///       /// <param name="memberSerialization">The member serialization mode for the type.</param><returns>Properties for the given <see cref="T:Open_Newtonsoft_Json.Serialization.JsonContract" />.</returns>
		protected virtual IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
		{
			int num = 6;
			List<MemberInfo> serializableMembers = GetSerializableMembers(type);
			if (serializableMembers == null)
			{
				throw new JsonSerializationException("Null collection of seralizable members returned.");
			}
			JsonPropertyCollection jsonPropertyCollection = new JsonPropertyCollection(type);
			foreach (MemberInfo item in serializableMembers)
			{
				JsonProperty jsonProperty = CreateProperty(item, memberSerialization);
				if (jsonProperty != null)
				{
					DefaultContractResolverState state = GetState();
					lock (state.NameTable)
					{
						jsonProperty.PropertyName = state.NameTable.Add(jsonProperty.PropertyName);
					}
					jsonPropertyCollection.AddProperty(jsonProperty);
				}
			}
			return Enumerable.ToList(Enumerable.OrderBy(jsonPropertyCollection, (JsonProperty jsonProperty_0) => jsonProperty_0.Order ?? (-1)));
		}

		/// <summary>
		///       Creates the <see cref="T:Open_Newtonsoft_Json.Serialization.IValueProvider" /> used by the serializer to get and set values from a member.
		///       </summary>
		/// <param name="member">The member.</param>
		/// <returns>The <see cref="T:Open_Newtonsoft_Json.Serialization.IValueProvider" /> used by the serializer to get and set values from a member.</returns>
		protected virtual IValueProvider CreateMemberValueProvider(MemberInfo member)
		{
			if (DynamicCodeGeneration)
			{
				return new DynamicValueProvider(member);
			}
			return new ReflectionValueProvider(member);
		}

		/// <summary>
		///       Creates a <see cref="T:Open_Newtonsoft_Json.Serialization.JsonProperty" /> for the given <see cref="T:System.Reflection.MemberInfo" />.
		///       </summary>
		/// <param name="memberSerialization">The member's parent <see cref="T:Open_Newtonsoft_Json.MemberSerialization" />.</param>
		/// <param name="member">The member to create a <see cref="T:Open_Newtonsoft_Json.Serialization.JsonProperty" /> for.</param>
		/// <returns>A created <see cref="T:Open_Newtonsoft_Json.Serialization.JsonProperty" /> for the given <see cref="T:System.Reflection.MemberInfo" />.</returns>
		protected virtual JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
		{
			JsonProperty jsonProperty = new JsonProperty();
			jsonProperty.PropertyType = ReflectionUtils.GetMemberUnderlyingType(member);
			jsonProperty.DeclaringType = member.DeclaringType;
			jsonProperty.ValueProvider = CreateMemberValueProvider(member);
			jsonProperty.AttributeProvider = new ReflectionAttributeProvider(member);
			SetPropertySettingsFromAttributes(jsonProperty, member, member.Name, member.DeclaringType, memberSerialization, out bool allowNonPublicAccess);
			if (memberSerialization != MemberSerialization.Fields)
			{
				jsonProperty.Readable = ReflectionUtils.CanReadMemberValue(member, allowNonPublicAccess);
				jsonProperty.Writable = ReflectionUtils.CanSetMemberValue(member, allowNonPublicAccess, jsonProperty.HasMemberAttribute);
			}
			else
			{
				jsonProperty.Readable = true;
				jsonProperty.Writable = true;
			}
			jsonProperty.ShouldSerialize = CreateShouldSerializeTest(member);
			SetIsSpecifiedActions(jsonProperty, member, allowNonPublicAccess);
			return jsonProperty;
		}

		private void SetPropertySettingsFromAttributes(JsonProperty property, object attributeProvider, string name, Type declaringType, MemberSerialization memberSerialization, out bool allowNonPublicAccess)
		{
			JsonPropertyAttribute attribute = JsonTypeReflector.GetAttribute<JsonPropertyAttribute>(attributeProvider);
			JsonRequiredAttribute attribute2 = JsonTypeReflector.GetAttribute<JsonRequiredAttribute>(attributeProvider);
			string propertyName = (attribute == null || attribute.PropertyName == null) ? name : attribute.PropertyName;
			property.PropertyName = ResolvePropertyName(propertyName);
			property.UnderlyingName = name;
			bool flag = false;
			if (attribute != null)
			{
				property._required = attribute._required;
				property.Order = attribute._order;
				property.DefaultValueHandling = attribute._defaultValueHandling;
				flag = true;
			}
			if (attribute2 != null)
			{
				property._required = Required.Always;
				flag = true;
			}
			property.HasMemberAttribute = flag;
			bool flag2 = JsonTypeReflector.GetAttribute<JsonIgnoreAttribute>(attributeProvider) != null || JsonTypeReflector.GetAttribute<JsonExtensionDataAttribute>(attributeProvider) != null || JsonTypeReflector.GetAttribute<NonSerializedAttribute>(attributeProvider) != null;
			if (memberSerialization != MemberSerialization.OptIn)
			{
				bool flag3 = false;
				property.Ignored = (flag2 || flag3);
			}
			else
			{
				property.Ignored = (flag2 || !flag);
			}
			property.Converter = JsonTypeReflector.GetJsonConverter(attributeProvider);
			property.MemberConverter = JsonTypeReflector.GetJsonConverter(attributeProvider);
			DefaultValueAttribute attribute3 = JsonTypeReflector.GetAttribute<DefaultValueAttribute>(attributeProvider);
			if (attribute3 != null)
			{
				property.DefaultValue = attribute3.Value;
			}
			property.NullValueHandling = attribute?._nullValueHandling;
			property.ReferenceLoopHandling = attribute?._referenceLoopHandling;
			property.ObjectCreationHandling = attribute?._objectCreationHandling;
			property.TypeNameHandling = attribute?._typeNameHandling;
			property.IsReference = attribute?._isReference;
			property.ItemIsReference = attribute?._itemIsReference;
			property.ItemConverter = ((attribute == null || attribute.ItemConverterType == null) ? null : JsonTypeReflector.CreateJsonConverterInstance(attribute.ItemConverterType, attribute.ItemConverterParameters));
			property.ItemReferenceLoopHandling = attribute?._itemReferenceLoopHandling;
			property.ItemTypeNameHandling = attribute?._itemTypeNameHandling;
			allowNonPublicAccess = false;
			if ((DefaultMembersSearchFlags & BindingFlags.NonPublic) == BindingFlags.NonPublic)
			{
				allowNonPublicAccess = true;
			}
			if (flag)
			{
				allowNonPublicAccess = true;
			}
			if (memberSerialization == MemberSerialization.Fields)
			{
				allowNonPublicAccess = true;
			}
		}

		private Predicate<object> CreateShouldSerializeTest(MemberInfo member)
		{
			MethodInfo method = member.DeclaringType.GetMethod("ShouldSerialize" + member.Name, ReflectionUtils.EmptyTypes);
			if (method == null || method.ReturnType != typeof(bool))
			{
				return null;
			}
			MethodCall<object, object> shouldSerializeCall = JsonTypeReflector.ReflectionDelegateFactory.CreateMethodCall<object>(method);
			return (object object_0) => (bool)shouldSerializeCall(object_0);
		}

		private void SetIsSpecifiedActions(JsonProperty property, MemberInfo member, bool allowNonPublicAccess)
		{
			int num = 15;
			MemberInfo memberInfo = member.DeclaringType.GetProperty(member.Name + "Specified");
			if (memberInfo == null)
			{
				memberInfo = member.DeclaringType.GetField(member.Name + "Specified");
			}
			if (memberInfo != null && ReflectionUtils.GetMemberUnderlyingType(memberInfo) == typeof(bool))
			{
				Func<object, object> specifiedPropertyGet = JsonTypeReflector.ReflectionDelegateFactory.CreateGet<object>(memberInfo);
				property.GetIsSpecified = ((object object_0) => (bool)specifiedPropertyGet(object_0));
				if (ReflectionUtils.CanSetMemberValue(memberInfo, allowNonPublicAccess, canSetReadOnly: false))
				{
					property.SetIsSpecified = JsonTypeReflector.ReflectionDelegateFactory.CreateSet<object>(memberInfo);
				}
			}
		}

		/// <summary>
		///       Resolves the name of the property.
		///       </summary>
		/// <param name="propertyName">Name of the property.</param>
		/// <returns>Resolved name of the property.</returns>
		protected virtual string ResolvePropertyName(string propertyName)
		{
			return propertyName;
		}

		/// <summary>
		///       Resolves the key of the dictionary. By default <see cref="M:Open_Newtonsoft_Json.Serialization.DefaultContractResolver.ResolvePropertyName(System.String)" /> is used to resolve dictionary keys.
		///       </summary>
		/// <param name="dictionaryKey">Key of the dictionary.</param>
		/// <returns>Resolved key of the dictionary.</returns>
		protected virtual string ResolveDictionaryKey(string dictionaryKey)
		{
			return ResolvePropertyName(dictionaryKey);
		}

		/// <summary>
		///       Gets the resolved name of the property.
		///       </summary>
		/// <param name="propertyName">Name of the property.</param>
		/// <returns>Name of the property.</returns>
		public string GetResolvedPropertyName(string propertyName)
		{
			return ResolvePropertyName(propertyName);
		}
	}
}
