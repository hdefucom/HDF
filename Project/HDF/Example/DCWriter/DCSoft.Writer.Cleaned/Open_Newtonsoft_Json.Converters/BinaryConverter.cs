using Open_Newtonsoft_Json.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Converters
{
	/// <summary>
	///       Converts a binary value to and from a base 64 string value.
	///       </summary>
	[ComVisible(false)]
	public class BinaryConverter : JsonConverter
	{
		/// <summary>
		///       Writes the JSON representation of the object.
		///       </summary>
		/// <param name="writer">The <see cref="T:Open_Newtonsoft_Json.JsonWriter" /> to write to.</param>
		/// <param name="value">The value.</param>
		/// <param name="serializer">The calling serializer.</param>
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			if (value == null)
			{
				writer.WriteNull();
				return;
			}
			byte[] byteArray = GetByteArray(value);
			writer.WriteValue(byteArray);
		}

		private byte[] GetByteArray(object value)
		{
			int num = 14;
			if (!(value is SqlBinary))
			{
				throw new JsonSerializationException(StringUtils.FormatWith("Unexpected value type when writing binary: {0}", CultureInfo.InvariantCulture, value.GetType()));
			}
			return ((SqlBinary)value).Value;
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
			int num = 17;
			Type type = ReflectionUtils.IsNullableType(objectType) ? Nullable.GetUnderlyingType(objectType) : objectType;
			if (reader.TokenType == JsonToken.Null)
			{
				if (!ReflectionUtils.IsNullable(objectType))
				{
					throw JsonSerializationException.Create(reader, StringUtils.FormatWith("Cannot convert null value to {0}.", CultureInfo.InvariantCulture, objectType));
				}
				return null;
			}
			byte[] value;
			if (reader.TokenType == JsonToken.StartArray)
			{
				value = ReadByteArray(reader);
			}
			else
			{
				if (reader.TokenType != JsonToken.String)
				{
					throw JsonSerializationException.Create(reader, StringUtils.FormatWith("Unexpected token parsing binary. Expected String or StartArray, got {0}.", CultureInfo.InvariantCulture, reader.TokenType));
				}
				string s = reader.Value.ToString();
				value = Convert.FromBase64String(s);
			}
			if (type == typeof(SqlBinary))
			{
				return new SqlBinary(value);
			}
			throw JsonSerializationException.Create(reader, StringUtils.FormatWith("Unexpected object type when writing binary: {0}", CultureInfo.InvariantCulture, objectType));
		}

		private byte[] ReadByteArray(JsonReader reader)
		{
			int num = 15;
			List<byte> list = new List<byte>();
			while (reader.Read())
			{
				switch (reader.TokenType)
				{
				case JsonToken.Integer:
					list.Add(Convert.ToByte(reader.Value, CultureInfo.InvariantCulture));
					break;
				case JsonToken.Comment:
					break;
				default:
					throw JsonSerializationException.Create(reader, StringUtils.FormatWith("Unexpected token when reading bytes: {0}", CultureInfo.InvariantCulture, reader.TokenType));
				case JsonToken.EndArray:
					return list.ToArray();
				}
			}
			throw JsonSerializationException.Create(reader, "Unexpected end when reading bytes.");
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
			if (objectType == typeof(SqlBinary) || objectType == typeof(SqlBinary?))
			{
				return true;
			}
			return false;
		}
	}
}
