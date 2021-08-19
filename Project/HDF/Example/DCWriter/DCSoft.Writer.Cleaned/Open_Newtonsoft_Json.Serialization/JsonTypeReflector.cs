using Open_Newtonsoft_Json.Utilities;
using Open_Newtonsoft_Json.Utilities.LinqBridge;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Permissions;

namespace Open_Newtonsoft_Json.Serialization
{
	[ComVisible(false)]
	internal static class JsonTypeReflector
	{
		public const string IdPropertyName = "$id";

		public const string RefPropertyName = "$ref";

		public const string TypePropertyName = "$type";

		public const string ValuePropertyName = "$value";

		public const string ArrayValuesPropertyName = "$values";

		public const string ShouldSerializePrefix = "ShouldSerialize";

		public const string SpecifiedPostfix = "Specified";

		private static bool? _dynamicCodeGeneration;

		private static bool? _fullyTrusted;

		private static readonly ThreadSafeStore<Type, Func<object[], JsonConverter>> JsonConverterCreatorCache = new ThreadSafeStore<Type, Func<object[], JsonConverter>>(GetJsonConverterCreator);

		public static bool DynamicCodeGeneration
		{
			get
			{
				if (!_dynamicCodeGeneration.HasValue)
				{
					try
					{
						new ReflectionPermission(ReflectionPermissionFlag.MemberAccess).Demand();
						new ReflectionPermission(ReflectionPermissionFlag.RestrictedMemberAccess).Demand();
						new SecurityPermission(SecurityPermissionFlag.SkipVerification).Demand();
						new SecurityPermission(SecurityPermissionFlag.UnmanagedCode).Demand();
						new SecurityPermission(PermissionState.Unrestricted).Demand();
						_dynamicCodeGeneration = true;
					}
					catch (Exception)
					{
						_dynamicCodeGeneration = false;
					}
				}
				return _dynamicCodeGeneration.Value;
			}
		}

		public static bool FullyTrusted
		{
			get
			{
				if (!_fullyTrusted.HasValue)
				{
					try
					{
						new SecurityPermission(PermissionState.Unrestricted).Demand();
						_fullyTrusted = true;
					}
					catch (Exception)
					{
						_fullyTrusted = false;
					}
				}
				return _fullyTrusted.Value;
			}
		}

		public static ReflectionDelegateFactory ReflectionDelegateFactory
		{
			get
			{
				if (DynamicCodeGeneration)
				{
					return DynamicReflectionDelegateFactory.Instance;
				}
				return LateBoundReflectionDelegateFactory.Instance;
			}
		}

		public static T GetCachedAttribute<T>(object attributeProvider) where T : Attribute
		{
			return CachedAttributeGetter<T>.GetAttribute(attributeProvider);
		}

		public static MemberSerialization GetObjectMemberSerialization(Type objectType, bool ignoreSerializableAttribute)
		{
			JsonObjectAttribute cachedAttribute = GetCachedAttribute<JsonObjectAttribute>(objectType);
			if (cachedAttribute != null)
			{
				return cachedAttribute.MemberSerialization;
			}
			if (!ignoreSerializableAttribute)
			{
				SerializableAttribute cachedAttribute2 = GetCachedAttribute<SerializableAttribute>(objectType);
				if (cachedAttribute2 != null)
				{
					return MemberSerialization.Fields;
				}
			}
			return MemberSerialization.OptOut;
		}

		public static JsonConverter GetJsonConverter(object attributeProvider)
		{
			JsonConverterAttribute cachedAttribute = GetCachedAttribute<JsonConverterAttribute>(attributeProvider);
			if (cachedAttribute != null)
			{
				Func<object[], JsonConverter> func = JsonConverterCreatorCache.Get(cachedAttribute.ConverterType);
				if (func != null)
				{
					return func(cachedAttribute.ConverterParameters);
				}
			}
			return null;
		}

		/// <summary>
		///       Lookup and create an instance of the JsonConverter type described by the argument.
		///       </summary>
		/// <param name="converterType">The JsonConverter type to create.</param>
		/// <param name="converterArgs">Optional arguments to pass to an initializing constructor of the JsonConverter.
		///       If null, the default constructor is used.</param>
		public static JsonConverter CreateJsonConverterInstance(Type converterType, object[] converterArgs)
		{
			Func<object[], JsonConverter> func = JsonConverterCreatorCache.Get(converterType);
			return func(converterArgs);
		}

		/// <summary>
		///       Create a factory function that can be used to create instances of a JsonConverter described by the 
		///       argument type.  The returned function can then be used to either invoke the converter's default ctor, or any 
		///       parameterized constructors by way of an object array.
		///       </summary>
		private static Func<object[], JsonConverter> GetJsonConverterCreator(Type converterType)
		{
			Func<object> defaultConstructor = ReflectionUtils.HasDefaultConstructor(converterType, nonPublic: false) ? ReflectionDelegateFactory.CreateDefaultConstructor<object>(converterType) : null;
			return delegate(object[] parameters)
			{
				int num = 3;
				try
				{
					if (parameters != null)
					{
						ObjectConstructor<object> objectConstructor = null;
						Type[] types = Enumerable.ToArray(Enumerable.Select(parameters, (object param) => param.GetType()));
						ConstructorInfo constructor = converterType.GetConstructor(types);
						if (null == constructor)
						{
							throw new JsonException(StringUtils.FormatWith("No matching parameterized constructor found for '{0}'.", CultureInfo.InvariantCulture, converterType));
						}
						objectConstructor = ReflectionDelegateFactory.CreateParametrizedConstructor(constructor);
						return (JsonConverter)objectConstructor(parameters);
					}
					if (defaultConstructor == null)
					{
						throw new JsonException(StringUtils.FormatWith("No parameterless constructor defined for '{0}'.", CultureInfo.InvariantCulture, converterType));
					}
					return (JsonConverter)defaultConstructor();
				}
				catch (Exception innerException)
				{
					throw new JsonException(StringUtils.FormatWith("Error creating '{0}'.", CultureInfo.InvariantCulture, converterType), innerException);
				}
			};
		}

		public static TypeConverter GetTypeConverter(Type type)
		{
			return TypeDescriptor.GetConverter(type);
		}

		private static T GetAttribute<T>(Type type) where T : Attribute
		{
			T attribute = ReflectionUtils.GetAttribute<T>(type, inherit: true);
			if (attribute != null)
			{
				return attribute;
			}
			Type[] interfaces = type.GetInterfaces();
			int num = 0;
			while (true)
			{
				if (num < interfaces.Length)
				{
					Type attributeProvider = interfaces[num];
					attribute = ReflectionUtils.GetAttribute<T>(attributeProvider, inherit: true);
					if (attribute != null)
					{
						break;
					}
					num++;
					continue;
				}
				return null;
			}
			return attribute;
		}

		private static T GetAttribute<T>(MemberInfo memberInfo) where T : Attribute
		{
			T attribute = ReflectionUtils.GetAttribute<T>(memberInfo, inherit: true);
			if (attribute != null)
			{
				return attribute;
			}
			if (memberInfo.DeclaringType != null)
			{
				Type[] interfaces = memberInfo.DeclaringType.GetInterfaces();
				foreach (Type targetType in interfaces)
				{
					MemberInfo memberInfoFromType = ReflectionUtils.GetMemberInfoFromType(targetType, memberInfo);
					if (memberInfoFromType != null)
					{
						attribute = ReflectionUtils.GetAttribute<T>(memberInfoFromType, inherit: true);
						if (attribute != null)
						{
							return attribute;
						}
					}
				}
			}
			return null;
		}

		public static T GetAttribute<T>(object provider) where T : Attribute
		{
			Type type = provider as Type;
			if (type != null)
			{
				return GetAttribute<T>(type);
			}
			MemberInfo memberInfo = provider as MemberInfo;
			if (memberInfo != null)
			{
				return GetAttribute<T>(memberInfo);
			}
			return ReflectionUtils.GetAttribute<T>(provider, inherit: true);
		}

		internal static void SetFullyTrusted(bool fullyTrusted)
		{
			_fullyTrusted = fullyTrusted;
		}

		internal static void SetDynamicCodeGeneration(bool dynamicCodeGeneration)
		{
			_dynamicCodeGeneration = dynamicCodeGeneration;
		}
	}
}
