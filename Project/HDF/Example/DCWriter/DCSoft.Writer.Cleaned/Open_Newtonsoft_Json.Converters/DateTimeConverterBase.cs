using System;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Converters
{
	/// <summary>
	///       Provides a base class for converting a <see cref="T:System.DateTime" /> to and from JSON.
	///       </summary>
	[ComVisible(false)]
	public abstract class DateTimeConverterBase : JsonConverter
	{
		/// <summary>
		///       Determines whether this instance can convert the specified object type.
		///       </summary>
		/// <param name="objectType">Type of the object.</param>
		/// <returns>
		///   <c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.
		///       </returns>
		public override bool CanConvert(Type objectType)
		{
			if (objectType == typeof(DateTime) || objectType == typeof(DateTime?))
			{
				return true;
			}
			return false;
		}
	}
}
