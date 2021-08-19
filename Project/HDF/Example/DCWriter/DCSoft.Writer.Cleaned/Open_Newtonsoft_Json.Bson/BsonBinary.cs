using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Bson
{
	[ComVisible(false)]
	internal class BsonBinary : BsonValue
	{
		public BsonBinaryType BinaryType
		{
			get;
			set;
		}

		public BsonBinary(byte[] value, BsonBinaryType binaryType)
			: base(value, BsonType.Binary)
		{
			BinaryType = binaryType;
		}
	}
}
