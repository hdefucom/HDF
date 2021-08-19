using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Bson
{
	[ComVisible(false)]
	internal class BsonRegex : BsonToken
	{
		public BsonString Pattern
		{
			get;
			set;
		}

		public BsonString Options
		{
			get;
			set;
		}

		public override BsonType Type => BsonType.Regex;

		public BsonRegex(string pattern, string options)
		{
			Pattern = new BsonString(pattern, includeLength: false);
			Options = new BsonString(options, includeLength: false);
		}
	}
}
