using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Bson
{
	[ComVisible(false)]
	internal class BsonProperty
	{
		public BsonString Name
		{
			get;
			set;
		}

		public BsonToken Value
		{
			get;
			set;
		}
	}
}
