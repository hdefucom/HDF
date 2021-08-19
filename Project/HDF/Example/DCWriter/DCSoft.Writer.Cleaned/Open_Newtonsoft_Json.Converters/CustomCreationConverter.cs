using System;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Converters
{
	/// <summary>
	///       Create a custom object
	///       </summary>
	/// <typeparam name="T">The object type to convert.</typeparam>
	[ComVisible(false)]
	public abstract class CustomCreationConverter<T> : JsonConverter
	{
		/// <summary>
		///       Gets a value indicating whether this <see cref="T:Open_Newtonsoft_Json.JsonConverter" /> can write JSON.
		///       </summary>
		/// <value>
		///   <c>true</c> if this <see cref="T:Open_Newtonsoft_Json.JsonConverter" /> can write JSON; otherwise, <c>false</c>.
		///       </value>
		public override bool CanWrite => false;

		/// <summary>
		///       Writes the JSON representation of the object.
		///       </summary>
		/// <param name="writer">The <see cref="T:Open_Newtonsoft_Json.JsonWriter" /> to write to.</param>
		/// <param name="value">The value.</param>
		/// <param name="serializer">The calling serializer.</param>
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotSupportedException("CustomCreationConverter should only be used while deserializing.");
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
			int num = 13;
			if (reader.TokenType == JsonToken.Null)
			{
				return null;
			}
			T val = Create(objectType);
			if (val == null)
			{
				throw new JsonSerializationException("No object created.");
			}
			serializer.Populate(reader, val);
			return val;
		}

		/// <summary>
		///       Creates an object which will then be populated by the serializer.
		///       </summary>
		/// <param name="objectType">Type of the object.</param>
		/// <returns>The created object.</returns>
		public abstract T Create(Type objectType);

		/// <summary>
		///       Determines whether this instance can convert the specified object type.
		///       </summary>
		/// <param name="objectType">Type of the object.</param>
		/// <returns>
		///   <c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.
		///       </returns>
		public override bool CanConvert(Type objectType)
		{
			return typeof(T).IsAssignableFrom(objectType);
		}
	}
}
