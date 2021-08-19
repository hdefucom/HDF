using Open_Newtonsoft_Json.Utilities;
using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Converters
{
	/// <summary>
	///       Converts a <see cref="T:System.DateTime" /> to and from the ISO 8601 date format (e.g. 2008-04-12T12:53Z).
	///       </summary>
	[ComVisible(false)]
	public class IsoDateTimeConverter : DateTimeConverterBase
	{
		private const string DefaultDateTimeFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.FFFFFFFK";

		private DateTimeStyles _dateTimeStyles = DateTimeStyles.RoundtripKind;

		private string _dateTimeFormat;

		private CultureInfo _culture;

		/// <summary>
		///       Gets or sets the date time styles used when converting a date to and from JSON.
		///       </summary>
		/// <value>The date time styles used when converting a date to and from JSON.</value>
		public DateTimeStyles DateTimeStyles
		{
			get
			{
				return _dateTimeStyles;
			}
			set
			{
				_dateTimeStyles = value;
			}
		}

		/// <summary>
		///       Gets or sets the date time format used when converting a date to and from JSON.
		///       </summary>
		/// <value>The date time format used when converting a date to and from JSON.</value>
		public string DateTimeFormat
		{
			get
			{
				return _dateTimeFormat ?? string.Empty;
			}
			set
			{
				_dateTimeFormat = StringUtils.NullEmptyString(value);
			}
		}

		/// <summary>
		///       Gets or sets the culture used when converting a date to and from JSON.
		///       </summary>
		/// <value>The culture used when converting a date to and from JSON.</value>
		public CultureInfo Culture
		{
			get
			{
				return _culture ?? CultureInfo.CurrentCulture;
			}
			set
			{
				_culture = value;
			}
		}

		/// <summary>
		///       Writes the JSON representation of the object.
		///       </summary>
		/// <param name="writer">The <see cref="T:Open_Newtonsoft_Json.JsonWriter" /> to write to.</param>
		/// <param name="value">The value.</param>
		/// <param name="serializer">The calling serializer.</param>
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			int num = 19;
			if (value is DateTime)
			{
				DateTime dateTime = (DateTime)value;
				if ((_dateTimeStyles & DateTimeStyles.AdjustToUniversal) == DateTimeStyles.AdjustToUniversal || (_dateTimeStyles & DateTimeStyles.AssumeUniversal) == DateTimeStyles.AssumeUniversal)
				{
					dateTime = dateTime.ToUniversalTime();
				}
				string value2 = dateTime.ToString(_dateTimeFormat ?? "yyyy'-'MM'-'dd'T'HH':'mm':'ss.FFFFFFFK", Culture);
				writer.WriteValue(value2);
				return;
			}
			throw new JsonSerializationException(StringUtils.FormatWith("Unexpected value when converting date. Expected DateTime or DateTimeOffset, got {0}.", CultureInfo.InvariantCulture, ReflectionUtils.GetObjectType(value)));
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
			int num = 10;
			bool flag = ReflectionUtils.IsNullableType(objectType);
			if (reader.TokenType == JsonToken.Null)
			{
				if (!ReflectionUtils.IsNullableType(objectType))
				{
					throw JsonSerializationException.Create(reader, StringUtils.FormatWith("Cannot convert null value to {0}.", CultureInfo.InvariantCulture, objectType));
				}
				return null;
			}
			if (reader.TokenType == JsonToken.Date)
			{
				return reader.Value;
			}
			if (reader.TokenType != JsonToken.String)
			{
				throw JsonSerializationException.Create(reader, StringUtils.FormatWith("Unexpected token parsing date. Expected String, got {0}.", CultureInfo.InvariantCulture, reader.TokenType));
			}
			string text = reader.Value.ToString();
			if (string.IsNullOrEmpty(text) && flag)
			{
				return null;
			}
			if (!string.IsNullOrEmpty(_dateTimeFormat))
			{
				return DateTime.ParseExact(text, _dateTimeFormat, Culture, _dateTimeStyles);
			}
			return DateTime.Parse(text, Culture, _dateTimeStyles);
		}
	}
}
