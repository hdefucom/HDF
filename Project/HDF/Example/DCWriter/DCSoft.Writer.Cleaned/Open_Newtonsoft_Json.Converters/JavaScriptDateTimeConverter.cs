using Open_Newtonsoft_Json.Utilities;
using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Converters
{
	/// <summary>
	///       Converts a <see cref="T:System.DateTime" /> to and from a JavaScript date constructor (e.g. new Date(52231943)).
	///       </summary>
	[ComVisible(false)]
	public class JavaScriptDateTimeConverter : DateTimeConverterBase
	{
		/// <summary>
		///       Writes the JSON representation of the object.
		///       </summary>
		/// <param name="writer">The <see cref="T:Open_Newtonsoft_Json.JsonWriter" /> to write to.</param>
		/// <param name="value">The value.</param>
		/// <param name="serializer">The calling serializer.</param>
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			int num = 19;
			if (!(value is DateTime))
			{
				throw new JsonSerializationException("Expected date object value.");
			}
			DateTime dateTime = ((DateTime)value).ToUniversalTime();
			long value2 = DateTimeUtils.ConvertDateTimeToJavaScriptTicks(dateTime);
			writer.WriteStartConstructor("Date");
			writer.WriteValue(value2);
			writer.WriteEndConstructor();
		}

		/// <summary>
		///       Reads the JSON representation of the object.
		///       </summary>
		/// <param name="reader">The <see cref="T:Open_Newtonsoft_Json.JsonReader" /> to read from.</param>
		/// <param name="objectType">Type of the object.</param>
		/// <param name="existingValue">The existing property value of the JSON that is being converted.</param>
		/// <param name="serializer">The calling serializer.</param>
		/// <returns>The object value.</returns>
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			int num = 4;
			if (reader.TokenType == JsonToken.Null)
			{
				if (!ReflectionUtils.IsNullable(objectType))
				{
					throw JsonSerializationException.Create(reader, StringUtils.FormatWith("Cannot convert null value to {0}.", CultureInfo.InvariantCulture, objectType));
				}
				return null;
			}
			if (reader.TokenType != JsonToken.StartConstructor || !string.Equals(reader.Value.ToString(), "Date", StringComparison.Ordinal))
			{
				throw JsonSerializationException.Create(reader, StringUtils.FormatWith("Unexpected token or value when parsing date. Token: {0}, Value: {1}", CultureInfo.InvariantCulture, reader.TokenType, reader.Value));
			}
			reader.Read();
			if (reader.TokenType != JsonToken.Integer)
			{
				throw JsonSerializationException.Create(reader, StringUtils.FormatWith("Unexpected token parsing date. Expected Integer, got {0}.", CultureInfo.InvariantCulture, reader.TokenType));
			}
			long javaScriptTicks = (long)reader.Value;
			DateTime dateTime = DateTimeUtils.ConvertJavaScriptTicksToDateTime(javaScriptTicks);
			reader.Read();
			if (reader.TokenType != JsonToken.EndConstructor)
			{
				throw JsonSerializationException.Create(reader, StringUtils.FormatWith("Unexpected token parsing date. Expected EndConstructor, got {0}.", CultureInfo.InvariantCulture, reader.TokenType));
			}
			return dateTime;
		}
	}
}
