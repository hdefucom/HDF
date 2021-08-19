using Open_Newtonsoft_Json.Serialization;
using Open_Newtonsoft_Json.Utilities;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Converters
{
	/// <summary>
	///       Converts a <see cref="T:System.Collections.Generic.KeyValuePair`2" /> to and from JSON.
	///       </summary>
	[ComVisible(false)]
	public class KeyValuePairConverter : JsonConverter
	{
		private const string KeyName = "Key";

		private const string ValueName = "Value";

		private static readonly ThreadSafeStore<Type, ReflectionObject> ReflectionObjectPerType = new ThreadSafeStore<Type, ReflectionObject>(InitializeReflectionObject);

		private static ReflectionObject InitializeReflectionObject(Type type_0)
		{
			IList<Type> genericArguments = type_0.GetGenericArguments();
			Type type = genericArguments[0];
			Type type2 = genericArguments[1];
			return ReflectionObject.Create(type_0, type_0.GetConstructor(new Type[2]
			{
				type,
				type2
			}), "Key", "Value");
		}

		/// <summary>
		///       Writes the JSON representation of the object.
		///       </summary>
		/// <param name="writer">The <see cref="T:Open_Newtonsoft_Json.JsonWriter" /> to write to.</param>
		/// <param name="value">The value.</param>
		/// <param name="serializer">The calling serializer.</param>
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			int num = 1;
			ReflectionObject reflectionObject = ReflectionObjectPerType.Get(value.GetType());
			DefaultContractResolver defaultContractResolver = serializer.ContractResolver as DefaultContractResolver;
			writer.WriteStartObject();
			writer.WritePropertyName((defaultContractResolver != null) ? defaultContractResolver.GetResolvedPropertyName("Key") : "Key");
			serializer.Serialize(writer, reflectionObject.GetValue(value, "Key"), reflectionObject.GetType("Key"));
			writer.WritePropertyName((defaultContractResolver != null) ? defaultContractResolver.GetResolvedPropertyName("Value") : "Value");
			serializer.Serialize(writer, reflectionObject.GetValue(value, "Value"), reflectionObject.GetType("Value"));
			writer.WriteEndObject();
		}

		/// <summary>
		///       Reads the JSON representation of the object.
		///       </summary>
		/// <param name="reader">The <see cref="T:Open_Newtonsoft_Json.JsonReader" /> to read from.</param>
		/// <param name="objectType">Type of the object.</param>
		/// <param name="existingValue">The existing value of object being read.</param>
		/// <param name="serializer">The calling serializer.</param>
		/// <returns>The object value.</returns>
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			int num = 7;
			bool flag;
			Type gparam_ = (flag = ReflectionUtils.IsNullableType(objectType)) ? Nullable.GetUnderlyingType(objectType) : objectType;
			ReflectionObject reflectionObject = ReflectionObjectPerType.Get(gparam_);
			if (reader.TokenType == JsonToken.Null)
			{
				if (!flag)
				{
					throw JsonSerializationException.Create(reader, "Cannot convert null value to KeyValuePair.");
				}
				return null;
			}
			object obj = null;
			object obj2 = null;
			ReadAndAssert(reader);
			while (reader.TokenType == JsonToken.PropertyName)
			{
				string a = reader.Value.ToString();
				if (string.Equals(a, "Key", StringComparison.OrdinalIgnoreCase))
				{
					ReadAndAssert(reader);
					obj = serializer.Deserialize(reader, reflectionObject.GetType("Key"));
				}
				else if (string.Equals(a, "Value", StringComparison.OrdinalIgnoreCase))
				{
					ReadAndAssert(reader);
					obj2 = serializer.Deserialize(reader, reflectionObject.GetType("Value"));
				}
				else
				{
					reader.Skip();
				}
				ReadAndAssert(reader);
			}
			return reflectionObject.Creator(obj, obj2);
		}

		/// <summary>
		///       Determines whether this instance can convert the specified object type.
		///       </summary>
		/// <param name="objectType">Type of the object.</param>
		/// <returns>
		///   <c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.
		///       </returns>
		public override bool CanConvert(Type objectType)
		{
			Type type = ReflectionUtils.IsNullableType(objectType) ? Nullable.GetUnderlyingType(objectType) : objectType;
			if (TypeExtensions.IsValueType(type) && TypeExtensions.IsGenericType(type))
			{
				return type.GetGenericTypeDefinition() == typeof(KeyValuePair<, >);
			}
			return false;
		}

		private static void ReadAndAssert(JsonReader reader)
		{
			int num = 1;
			if (!reader.Read())
			{
				throw JsonSerializationException.Create(reader, "Unexpected end when reading KeyValuePair.");
			}
		}
	}
}
