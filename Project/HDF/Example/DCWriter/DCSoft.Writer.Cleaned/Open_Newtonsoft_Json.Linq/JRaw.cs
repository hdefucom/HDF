using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Linq
{
	/// <summary>
	///       Represents a raw JSON string.
	///       </summary>
	[ComVisible(false)]
	public class JRaw : JValue
	{
		/// <summary>
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.Linq.JRaw" /> class from another <see cref="T:Open_Newtonsoft_Json.Linq.JRaw" /> object.
		///       </summary>
		/// <param name="other">A <see cref="T:Open_Newtonsoft_Json.Linq.JRaw" /> object to copy from.</param>
		public JRaw(JRaw other)
			: base(other)
		{
		}

		/// <summary>
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.Linq.JRaw" /> class.
		///       </summary>
		/// <param name="rawJson">The raw json.</param>
		public JRaw(object rawJson)
			: base(rawJson, JTokenType.Raw)
		{
		}

		/// <summary>
		///       Creates an instance of <see cref="T:Open_Newtonsoft_Json.Linq.JRaw" /> with the content of the reader's current token.
		///       </summary>
		/// <param name="reader">The reader.</param>
		/// <returns>An instance of <see cref="T:Open_Newtonsoft_Json.Linq.JRaw" /> with the content of the reader's current token.</returns>
		public static JRaw Create(JsonReader reader)
		{
			using (StringWriter stringWriter = new StringWriter(CultureInfo.InvariantCulture))
			{
				using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
				{
					jsonTextWriter.WriteToken(reader);
					return new JRaw(stringWriter.ToString());
				}
			}
		}

		internal override JToken CloneToken()
		{
			return new JRaw(this);
		}
	}
}
