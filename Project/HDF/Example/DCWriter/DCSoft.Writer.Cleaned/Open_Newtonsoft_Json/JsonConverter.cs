using Open_Newtonsoft_Json.Schema;
using System;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json
{
	/// <summary>
	///       Converts an object to and from JSON.
	///       </summary>
	[ComVisible(false)]
	public abstract class JsonConverter
	{
		/// <summary>
		///       Gets a value indicating whether this <see cref="T:Open_Newtonsoft_Json.JsonConverter" /> can read JSON.
		///       </summary>
		/// <value>
		///   <c>true</c> if this <see cref="T:Open_Newtonsoft_Json.JsonConverter" /> can read JSON; otherwise, <c>false</c>.</value>
		public virtual bool CanRead => true;

		/// <summary>
		///       Gets a value indicating whether this <see cref="T:Open_Newtonsoft_Json.JsonConverter" /> can write JSON.
		///       </summary>
		/// <value>
		///   <c>true</c> if this <see cref="T:Open_Newtonsoft_Json.JsonConverter" /> can write JSON; otherwise, <c>false</c>.</value>
		public virtual bool CanWrite => true;

		/// <summary>
		///       Writes the JSON representation of the object.
		///       </summary>
		/// <param name="writer">The <see cref="T:Open_Newtonsoft_Json.JsonWriter" /> to write to.</param>
		/// <param name="value">The value.</param>
		/// <param name="serializer">The calling serializer.</param>
		public abstract void WriteJson(JsonWriter writer, object value, JsonSerializer serializer);

		/// <summary>
		///       Reads the JSON representation of the object.
		///       </summary>
		/// <param name="reader">The <see cref="T:Open_Newtonsoft_Json.JsonReader" /> to read from.</param>
		/// <param name="objectType">Type of the object.</param>
		/// <param name="existingValue">The existing value of object being read.</param>
		/// <param name="serializer">The calling serializer.</param>
		/// <returns>The object value.</returns>
		public abstract object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer);

		/// <summary>
		///       Determines whether this instance can convert the specified object type.
		///       </summary>
		/// <param name="objectType">Type of the object.</param>
		/// <returns>
		///   <c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.
		///       </returns>
		public abstract bool CanConvert(Type objectType);

		/// <summary>
		///   <para>
		///       Gets the <see cref="T:Open_Newtonsoft_Json.Schema.JsonSchema" /> of the JSON produced by the JsonConverter.
		///       </para>
		///   <note type="caution">
		///       JSON Schema validation has been moved to its own package. See <see href="http://www.newtonsoft.com/jsonschema">http://www.newtonsoft.com/jsonschema</see> for more details.
		///       </note>
		/// </summary>
		/// <returns>The <see cref="T:Open_Newtonsoft_Json.Schema.JsonSchema" /> of the JSON produced by the JsonConverter.</returns>
		[Obsolete("JSON Schema validation has been moved to its own package. It is strongly recommended that you do not override GetSchema() in your own converter. It is not used by Json.NET and will be removed at some point in the future. Converter's that override GetSchema() will stop working when it is removed.")]
		public virtual JsonSchema GetSchema()
		{
			return null;
		}
	}
}
