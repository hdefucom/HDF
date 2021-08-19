using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Bson
{
	[ComVisible(false)]
	internal abstract class BsonToken
	{
		public abstract BsonType Type
		{
			get;
		}

		public BsonToken Parent
		{
			get;
			set;
		}

		public int CalculatedSize
		{
			get;
			set;
		}
	}
}
