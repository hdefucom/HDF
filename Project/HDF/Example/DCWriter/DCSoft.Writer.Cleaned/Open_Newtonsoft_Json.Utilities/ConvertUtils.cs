using Open_Newtonsoft_Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace Open_Newtonsoft_Json.Utilities
{
	[ComVisible(false)]
	internal static class ConvertUtils
	{
		[ComVisible(false)]
		internal struct TypeConvertKey : IEquatable<TypeConvertKey>
		{
			private readonly Type _initialType;

			private readonly Type _targetType;

			public Type InitialType => _initialType;

			public Type TargetType => _targetType;

			public TypeConvertKey(Type initialType, Type targetType)
			{
				_initialType = initialType;
				_targetType = targetType;
			}

			public override int GetHashCode()
			{
				return _initialType.GetHashCode() ^ _targetType.GetHashCode();
			}

			public override bool Equals(object other)
			{
				if (!(other is TypeConvertKey))
				{
					return false;
				}
				return Equals((TypeConvertKey)other);
			}

			public bool Equals(TypeConvertKey other)
			{
				return _initialType == other._initialType && _targetType == other._targetType;
			}
		}

		[ComVisible(false)]
		internal enum ConvertResult
		{
			Success,
			CannotConvertNull,
			NotInstantiableType,
			NoValidConversion
		}

		private static readonly Dictionary<Type, PrimitiveTypeCode> TypeCodeMap = new Dictionary<Type, PrimitiveTypeCode>
		{
			{
				typeof(char),
				PrimitiveTypeCode.Char
			},
			{
				typeof(char?),
				PrimitiveTypeCode.CharNullable
			},
			{
				typeof(bool),
				PrimitiveTypeCode.Boolean
			},
			{
				typeof(bool?),
				PrimitiveTypeCode.BooleanNullable
			},
			{
				typeof(sbyte),
				PrimitiveTypeCode.SByte
			},
			{
				typeof(sbyte?),
				PrimitiveTypeCode.SByteNullable
			},
			{
				typeof(short),
				PrimitiveTypeCode.Int16
			},
			{
				typeof(short?),
				PrimitiveTypeCode.Int16Nullable
			},
			{
				typeof(ushort),
				PrimitiveTypeCode.UInt16
			},
			{
				typeof(ushort?),
				PrimitiveTypeCode.UInt16Nullable
			},
			{
				typeof(int),
				PrimitiveTypeCode.Int32
			},
			{
				typeof(int?),
				PrimitiveTypeCode.Int32Nullable
			},
			{
				typeof(byte),
				PrimitiveTypeCode.Byte
			},
			{
				typeof(byte?),
				PrimitiveTypeCode.ByteNullable
			},
			{
				typeof(uint),
				PrimitiveTypeCode.UInt32
			},
			{
				typeof(uint?),
				PrimitiveTypeCode.UInt32Nullable
			},
			{
				typeof(long),
				PrimitiveTypeCode.Int64
			},
			{
				typeof(long?),
				PrimitiveTypeCode.Int64Nullable
			},
			{
				typeof(ulong),
				PrimitiveTypeCode.UInt64
			},
			{
				typeof(ulong?),
				PrimitiveTypeCode.UInt64Nullable
			},
			{
				typeof(float),
				PrimitiveTypeCode.Single
			},
			{
				typeof(float?),
				PrimitiveTypeCode.SingleNullable
			},
			{
				typeof(double),
				PrimitiveTypeCode.Double
			},
			{
				typeof(double?),
				PrimitiveTypeCode.DoubleNullable
			},
			{
				typeof(DateTime),
				PrimitiveTypeCode.DateTime
			},
			{
				typeof(DateTime?),
				PrimitiveTypeCode.DateTimeNullable
			},
			{
				typeof(decimal),
				PrimitiveTypeCode.Decimal
			},
			{
				typeof(decimal?),
				PrimitiveTypeCode.DecimalNullable
			},
			{
				typeof(Guid),
				PrimitiveTypeCode.Guid
			},
			{
				typeof(Guid?),
				PrimitiveTypeCode.GuidNullable
			},
			{
				typeof(TimeSpan),
				PrimitiveTypeCode.TimeSpan
			},
			{
				typeof(TimeSpan?),
				PrimitiveTypeCode.TimeSpanNullable
			},
			{
				typeof(Uri),
				PrimitiveTypeCode.Uri
			},
			{
				typeof(string),
				PrimitiveTypeCode.String
			},
			{
				typeof(byte[]),
				PrimitiveTypeCode.Bytes
			},
			{
				typeof(DBNull),
				PrimitiveTypeCode.DBNull
			}
		};

		private static readonly TypeInformation[] PrimitiveTypeCodes = new TypeInformation[19]
		{
			new TypeInformation
			{
				Type = typeof(object),
				TypeCode = PrimitiveTypeCode.Empty
			},
			new TypeInformation
			{
				Type = typeof(object),
				TypeCode = PrimitiveTypeCode.Object
			},
			new TypeInformation
			{
				Type = typeof(object),
				TypeCode = PrimitiveTypeCode.DBNull
			},
			new TypeInformation
			{
				Type = typeof(bool),
				TypeCode = PrimitiveTypeCode.Boolean
			},
			new TypeInformation
			{
				Type = typeof(char),
				TypeCode = PrimitiveTypeCode.Char
			},
			new TypeInformation
			{
				Type = typeof(sbyte),
				TypeCode = PrimitiveTypeCode.SByte
			},
			new TypeInformation
			{
				Type = typeof(byte),
				TypeCode = PrimitiveTypeCode.Byte
			},
			new TypeInformation
			{
				Type = typeof(short),
				TypeCode = PrimitiveTypeCode.Int16
			},
			new TypeInformation
			{
				Type = typeof(ushort),
				TypeCode = PrimitiveTypeCode.UInt16
			},
			new TypeInformation
			{
				Type = typeof(int),
				TypeCode = PrimitiveTypeCode.Int32
			},
			new TypeInformation
			{
				Type = typeof(uint),
				TypeCode = PrimitiveTypeCode.UInt32
			},
			new TypeInformation
			{
				Type = typeof(long),
				TypeCode = PrimitiveTypeCode.Int64
			},
			new TypeInformation
			{
				Type = typeof(ulong),
				TypeCode = PrimitiveTypeCode.UInt64
			},
			new TypeInformation
			{
				Type = typeof(float),
				TypeCode = PrimitiveTypeCode.Single
			},
			new TypeInformation
			{
				Type = typeof(double),
				TypeCode = PrimitiveTypeCode.Double
			},
			new TypeInformation
			{
				Type = typeof(decimal),
				TypeCode = PrimitiveTypeCode.Decimal
			},
			new TypeInformation
			{
				Type = typeof(DateTime),
				TypeCode = PrimitiveTypeCode.DateTime
			},
			new TypeInformation
			{
				Type = typeof(object),
				TypeCode = PrimitiveTypeCode.Empty
			},
			new TypeInformation
			{
				Type = typeof(string),
				TypeCode = PrimitiveTypeCode.String
			}
		};

		private static readonly ThreadSafeStore<TypeConvertKey, Func<object, object>> CastConverters = new ThreadSafeStore<TypeConvertKey, Func<object, object>>(CreateCastConverter);

		public static PrimitiveTypeCode GetTypeCode(Type type_0)
		{
			bool isEnum;
			return GetTypeCode(type_0, out isEnum);
		}

		public static PrimitiveTypeCode GetTypeCode(Type type_0, out bool isEnum)
		{
			if (TypeCodeMap.TryGetValue(type_0, out PrimitiveTypeCode value))
			{
				isEnum = false;
				return value;
			}
			if (TypeExtensions.IsEnum(type_0))
			{
				isEnum = true;
				return GetTypeCode(Enum.GetUnderlyingType(type_0));
			}
			if (ReflectionUtils.IsNullableType(type_0))
			{
				Type underlyingType = Nullable.GetUnderlyingType(type_0);
				if (TypeExtensions.IsEnum(underlyingType))
				{
					Type type_ = typeof(Nullable<>).MakeGenericType(Enum.GetUnderlyingType(underlyingType));
					isEnum = true;
					return GetTypeCode(type_);
				}
			}
			isEnum = false;
			return PrimitiveTypeCode.Object;
		}

		public static TypeInformation GetTypeInformation(IConvertible convertable)
		{
			return PrimitiveTypeCodes[(int)convertable.GetTypeCode()];
		}

		public static bool IsConvertible(Type type_0)
		{
			return typeof(IConvertible).IsAssignableFrom(type_0);
		}

		public static TimeSpan ParseTimeSpan(string input)
		{
			return TimeSpan.Parse(input);
		}

		private static Func<object, object> CreateCastConverter(TypeConvertKey typeConvertKey_0)
		{
			int num = 5;
			MethodInfo method = typeConvertKey_0.TargetType.GetMethod("op_Implicit", new Type[1]
			{
				typeConvertKey_0.InitialType
			});
			if (method == null)
			{
				method = typeConvertKey_0.TargetType.GetMethod("op_Explicit", new Type[1]
				{
					typeConvertKey_0.InitialType
				});
			}
			if (method == null)
			{
				return null;
			}
			MethodCall<object, object> call = JsonTypeReflector.ReflectionDelegateFactory.CreateMethodCall<object>(method);
			return (object object_0) => call(null, object_0);
		}

		public static object Convert(object initialValue, CultureInfo culture, Type targetType)
		{
			int num = 2;
			object value;
			switch (TryConvertInternal(initialValue, culture, targetType, out value))
			{
			default:
				throw new InvalidOperationException("Unexpected conversion result.");
			case ConvertResult.CannotConvertNull:
				throw new Exception(StringUtils.FormatWith("Can not convert null {0} into non-nullable {1}.", CultureInfo.InvariantCulture, initialValue.GetType(), targetType));
			case ConvertResult.NotInstantiableType:
				throw new ArgumentException(StringUtils.FormatWith("Target type {0} is not a value type or a non-abstract class.", CultureInfo.InvariantCulture, targetType), "targetType");
			case ConvertResult.NoValidConversion:
				throw new InvalidOperationException(StringUtils.FormatWith("Can not convert from {0} to {1}.", CultureInfo.InvariantCulture, initialValue.GetType(), targetType));
			case ConvertResult.Success:
				return value;
			}
		}

		private static bool TryConvert(object initialValue, CultureInfo culture, Type targetType, out object value)
		{
			try
			{
				if (TryConvertInternal(initialValue, culture, targetType, out value) == ConvertResult.Success)
				{
					return true;
				}
				value = null;
				return false;
			}
			catch
			{
				value = null;
				return false;
			}
		}

		private static ConvertResult TryConvertInternal(object initialValue, CultureInfo culture, Type targetType, out object value)
		{
			int num = 16;
			if (initialValue == null)
			{
				throw new ArgumentNullException("initialValue");
			}
			if (ReflectionUtils.IsNullableType(targetType))
			{
				targetType = Nullable.GetUnderlyingType(targetType);
			}
			Type type = initialValue.GetType();
			if (targetType == type)
			{
				value = initialValue;
				return ConvertResult.Success;
			}
			if (IsConvertible(initialValue.GetType()) && IsConvertible(targetType))
			{
				if (TypeExtensions.IsEnum(targetType))
				{
					if (initialValue is string)
					{
						value = Enum.Parse(targetType, initialValue.ToString(), ignoreCase: true);
						return ConvertResult.Success;
					}
					if (IsInteger(initialValue))
					{
						value = Enum.ToObject(targetType, initialValue);
						return ConvertResult.Success;
					}
				}
				value = System.Convert.ChangeType(initialValue, targetType, culture);
				return ConvertResult.Success;
			}
			if (initialValue is byte[] && targetType == typeof(Guid))
			{
				value = new Guid((byte[])initialValue);
				return ConvertResult.Success;
			}
			if (initialValue is Guid && targetType == typeof(byte[]))
			{
				value = ((Guid)initialValue).ToByteArray();
				return ConvertResult.Success;
			}
			if (initialValue is string)
			{
				if (targetType == typeof(Guid))
				{
					value = new Guid((string)initialValue);
					return ConvertResult.Success;
				}
				if (targetType == typeof(Uri))
				{
					value = new Uri((string)initialValue, UriKind.RelativeOrAbsolute);
					return ConvertResult.Success;
				}
				if (targetType == typeof(TimeSpan))
				{
					value = ParseTimeSpan((string)initialValue);
					return ConvertResult.Success;
				}
				if (targetType == typeof(byte[]))
				{
					value = System.Convert.FromBase64String((string)initialValue);
					return ConvertResult.Success;
				}
				if (typeof(Type).IsAssignableFrom(targetType))
				{
					value = Type.GetType((string)initialValue, throwOnError: true);
					return ConvertResult.Success;
				}
			}
			TypeConverter converter = GetConverter(type);
			if (converter != null && converter.CanConvertTo(targetType))
			{
				value = converter.ConvertTo(null, culture, initialValue, targetType);
				return ConvertResult.Success;
			}
			TypeConverter converter2 = GetConverter(targetType);
			if (converter2 != null && converter2.CanConvertFrom(type))
			{
				value = converter2.ConvertFrom(null, culture, initialValue);
				return ConvertResult.Success;
			}
			if (initialValue == DBNull.Value)
			{
				if (ReflectionUtils.IsNullable(targetType))
				{
					value = EnsureTypeAssignable(null, type, targetType);
					return ConvertResult.Success;
				}
				value = null;
				return ConvertResult.CannotConvertNull;
			}
			if (initialValue is INullable)
			{
				value = EnsureTypeAssignable(ToValue((INullable)initialValue), type, targetType);
				return ConvertResult.Success;
			}
			if (TypeExtensions.IsInterface(targetType) || TypeExtensions.IsGenericTypeDefinition(targetType) || TypeExtensions.IsAbstract(targetType))
			{
				value = null;
				return ConvertResult.NotInstantiableType;
			}
			value = null;
			return ConvertResult.NoValidConversion;
		}

		/// <summary>
		///       Converts the value to the specified type. If the value is unable to be converted, the
		///       value is checked whether it assignable to the specified type.
		///       </summary>
		/// <param name="initialValue">The value to convert.</param>
		/// <param name="culture">The culture to use when converting.</param>
		/// <param name="targetType">The type to convert or cast the value to.</param>
		/// <returns>
		///       The converted type. If conversion was unsuccessful, the initial value
		///       is returned if assignable to the target type.
		///       </returns>
		public static object ConvertOrCast(object initialValue, CultureInfo culture, Type targetType)
		{
			if (targetType == typeof(object))
			{
				return initialValue;
			}
			if (initialValue == null && ReflectionUtils.IsNullable(targetType))
			{
				return null;
			}
			if (TryConvert(initialValue, culture, targetType, out object value))
			{
				return value;
			}
			return EnsureTypeAssignable(initialValue, ReflectionUtils.GetObjectType(initialValue), targetType);
		}

		private static object EnsureTypeAssignable(object value, Type initialType, Type targetType)
		{
			int num = 18;
			Type type = value?.GetType();
			if (value != null)
			{
				if (targetType.IsAssignableFrom(type))
				{
					return value;
				}
				Func<object, object> func = CastConverters.Get(new TypeConvertKey(type, targetType));
				if (func != null)
				{
					return func(value);
				}
			}
			else if (ReflectionUtils.IsNullable(targetType))
			{
				return null;
			}
			throw new ArgumentException(StringUtils.FormatWith("Could not cast or convert from {0} to {1}.", CultureInfo.InvariantCulture, (initialType != null) ? initialType.ToString() : "{null}", targetType));
		}

		public static object ToValue(INullable nullableValue)
		{
			int num = 2;
			if (nullableValue == null)
			{
				return null;
			}
			if (nullableValue is SqlInt32)
			{
				return ToValue((SqlInt32)(object)nullableValue);
			}
			if (nullableValue is SqlInt64)
			{
				return ToValue((SqlInt64)(object)nullableValue);
			}
			if (nullableValue is SqlBoolean)
			{
				return ToValue((SqlBoolean)(object)nullableValue);
			}
			if (nullableValue is SqlString)
			{
				return ToValue((SqlString)(object)nullableValue);
			}
			if (nullableValue is SqlDateTime)
			{
				return ToValue((SqlDateTime)(object)nullableValue);
			}
			throw new ArgumentException(StringUtils.FormatWith("Unsupported INullable type: {0}", CultureInfo.InvariantCulture, nullableValue.GetType()));
		}

		internal static TypeConverter GetConverter(Type type_0)
		{
			return JsonTypeReflector.GetTypeConverter(type_0);
		}

		public static bool IsInteger(object value)
		{
			switch (GetTypeCode(value.GetType()))
			{
			default:
				return false;
			case PrimitiveTypeCode.SByte:
			case PrimitiveTypeCode.Int16:
			case PrimitiveTypeCode.UInt16:
			case PrimitiveTypeCode.Int32:
			case PrimitiveTypeCode.Byte:
			case PrimitiveTypeCode.UInt32:
			case PrimitiveTypeCode.Int64:
			case PrimitiveTypeCode.UInt64:
				return true;
			}
		}

		public static ParseResult Int32TryParse(char[] chars, int start, int length, out int value)
		{
			value = 0;
			if (length == 0)
			{
				return ParseResult.Invalid;
			}
			bool flag;
			if (flag = (chars[start] == '-'))
			{
				if (length == 1)
				{
					return ParseResult.Invalid;
				}
				start++;
				length--;
			}
			int num = start + length;
			int num2 = start;
			while (true)
			{
				if (num2 < num)
				{
					int num3 = chars[num2] - 48;
					if (num3 >= 0 && num3 <= 9)
					{
						int num4 = 10 * value - num3;
						if (num4 > value)
						{
							break;
						}
						value = num4;
						num2++;
						continue;
					}
					return ParseResult.Invalid;
				}
				if (!flag)
				{
					if (value == int.MinValue)
					{
						return ParseResult.Overflow;
					}
					value = -value;
				}
				return ParseResult.Success;
			}
			num2++;
			while (true)
			{
				if (num2 < num)
				{
					int num3 = chars[num2] - 48;
					if (num3 < 0 || num3 > 9)
					{
						break;
					}
					num2++;
					continue;
				}
				return ParseResult.Overflow;
			}
			return ParseResult.Invalid;
		}

		public static ParseResult Int64TryParse(char[] chars, int start, int length, out long value)
		{
			value = 0L;
			if (length == 0)
			{
				return ParseResult.Invalid;
			}
			bool flag;
			if (flag = (chars[start] == '-'))
			{
				if (length == 1)
				{
					return ParseResult.Invalid;
				}
				start++;
				length--;
			}
			int num = start + length;
			int num2 = start;
			while (true)
			{
				if (num2 < num)
				{
					int num3 = chars[num2] - 48;
					if (num3 >= 0 && num3 <= 9)
					{
						long num4 = 10L * value - num3;
						if (num4 > value)
						{
							break;
						}
						value = num4;
						num2++;
						continue;
					}
					return ParseResult.Invalid;
				}
				if (!flag)
				{
					if (value == long.MinValue)
					{
						return ParseResult.Overflow;
					}
					value = -value;
				}
				return ParseResult.Success;
			}
			num2++;
			while (true)
			{
				if (num2 < num)
				{
					int num3 = chars[num2] - 48;
					if (num3 < 0 || num3 > 9)
					{
						break;
					}
					num2++;
					continue;
				}
				return ParseResult.Overflow;
			}
			return ParseResult.Invalid;
		}

		public static bool TryConvertGuid(string string_0, out Guid guid_0)
		{
			int num = 19;
			if (string_0 == null)
			{
				throw new ArgumentNullException("s");
			}
			Regex regex = new Regex("^[A-Fa-f0-9]{8}-([A-Fa-f0-9]{4}-){3}[A-Fa-f0-9]{12}$");
			Match match = regex.Match(string_0);
			if (match.Success)
			{
				guid_0 = new Guid(string_0);
				return true;
			}
			guid_0 = Guid.Empty;
			return false;
		}
	}
}
