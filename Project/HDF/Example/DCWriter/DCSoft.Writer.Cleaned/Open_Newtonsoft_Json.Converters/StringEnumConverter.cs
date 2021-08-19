using Open_Newtonsoft_Json.Utilities;
using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Converters
{
	/// <summary>
	///       Converts an <see cref="T:System.Enum" /> to and from its name string value.
	///       </summary>
	[ComVisible(false)]
	public class StringEnumConverter : JsonConverter
	{
		/// <summary>
		///       Gets or sets a value indicating whether the written enum text should be camel case.
		///       </summary>
		/// <value>
		///   <c>true</c> if the written enum text will be camel case; otherwise, <c>false</c>.</value>
		public bool CamelCaseText
		{
			get;
			set;
		}

		/// <summary>
		///       Gets or sets a value indicating whether integer values are allowed.
		///       </summary>
		/// <value>
		///   <c>true</c> if integers are allowed; otherwise, <c>false</c>.</value>
		public bool AllowIntegerValues
		{
			get;
			set;
		}

		/// <summary>
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.Converters.StringEnumConverter" /> class.
		///       </summary>
		public StringEnumConverter()
		{
			AllowIntegerValues = true;
		}

		/// <summary>
		///       Writes the JSON representation of the object.
		///       </summary>
		/// <param name="writer">The <see cref="T:Open_Newtonsoft_Json.JsonWriter" /> to write to.</param>
		/// <param name="value">The value.</param>
		/// <param name="serializer">The calling serializer.</param>
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			int num = 3;
			if (value == null)
			{
				writer.WriteNull();
				return;
			}
			Enum @enum = (Enum)value;
			string text = @enum.ToString("G");
			if (char.IsNumber(text[0]) || text[0] == '-')
			{
				writer.WriteValue(value);
				return;
			}
			Type type = @enum.GetType();
			string value2 = EnumUtils.ToEnumName(type, text, CamelCaseText);
			writer.WriteValue(value2);
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
			int num = 18;
			bool isNullable;
			Type type = (isNullable = ReflectionUtils.IsNullableType(objectType)) ? Nullable.GetUnderlyingType(objectType) : objectType;
			if (reader.TokenType == JsonToken.Null)
			{
				if (!ReflectionUtils.IsNullableType(objectType))
				{
					throw JsonSerializationException.Create(reader, StringUtils.FormatWith("Cannot convert null value to {0}.", CultureInfo.InvariantCulture, objectType));
				}
				return null;
			}
			try
			{
				if (reader.TokenType == JsonToken.String)
				{
					string enumText = reader.Value.ToString();
					return EnumUtils.ParseEnumName(enumText, isNullable, type);
				}
				if (reader.TokenType == JsonToken.Integer)
				{
					if (!AllowIntegerValues)
					{
						throw JsonSerializationException.Create(reader, StringUtils.FormatWith("Integer value {0} is not allowed.", CultureInfo.InvariantCulture, reader.Value));
					}
					return ConvertUtils.ConvertOrCast(reader.Value, CultureInfo.InvariantCulture, type);
				}
			}
			catch (Exception exception_)
			{
				throw JsonSerializationException.Create(reader, StringUtils.FormatWith("Error converting value {0} to type '{1}'.", CultureInfo.InvariantCulture, MiscellaneousUtils.FormatValueForPrint(reader.Value), objectType), exception_);
			}
			throw JsonSerializationException.Create(reader, StringUtils.FormatWith("Unexpected token {0} when parsing enum.", CultureInfo.InvariantCulture, reader.TokenType));
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
			return TypeExtensions.IsEnum(type);
		}
	}
}
