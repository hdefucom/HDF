using Open_Newtonsoft_Json.Utilities;
using System;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Bson
{
	/// <summary>
	///       Represents a BSON Oid (object id).
	///       </summary>
	[ComVisible(false)]
	public class BsonObjectId
	{
		/// <summary>
		///       Gets or sets the value of the Oid.
		///       </summary>
		/// <value>The value of the Oid.</value>
		public byte[] Value
		{
			get;
			private set;
		}

		/// <summary>
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.Bson.BsonObjectId" /> class.
		///       </summary>
		/// <param name="value">The Oid value.</param>
		public BsonObjectId(byte[] value)
		{
			int num = 8;
			
			ValidationUtils.ArgumentNotNull(value, "value");
			if (value.Length != 12)
			{
				throw new ArgumentException("An ObjectId must be 12 bytes", "value");
			}
			Value = value;
		}
	}
}
