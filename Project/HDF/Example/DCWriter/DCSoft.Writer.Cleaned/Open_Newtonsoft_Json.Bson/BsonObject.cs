using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Bson
{
	[ComVisible(false)]
	internal class BsonObject : BsonToken, IEnumerable<BsonProperty>
	{
		private readonly List<BsonProperty> _children = new List<BsonProperty>();

		public override BsonType Type => BsonType.Object;

		public void Add(string name, BsonToken token)
		{
			_children.Add(new BsonProperty
			{
				Name = new BsonString(name, includeLength: false),
				Value = token
			});
			token.Parent = this;
		}

		public IEnumerator<BsonProperty> GetEnumerator()
		{
			return _children.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
