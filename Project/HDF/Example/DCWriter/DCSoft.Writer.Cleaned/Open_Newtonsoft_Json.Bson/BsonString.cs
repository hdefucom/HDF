using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Bson
{
	[ComVisible(false)]
	internal class BsonString : BsonValue
	{
		public int ByteCount
		{
			get;
			set;
		}

		public bool IncludeLength
		{
			get;
			set;
		}

		public BsonString(object value, bool includeLength)
			: base(value, BsonType.String)
		{
			IncludeLength = includeLength;
		}
	}
}
