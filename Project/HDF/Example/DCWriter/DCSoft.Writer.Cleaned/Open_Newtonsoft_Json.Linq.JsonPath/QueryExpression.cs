using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Linq.JsonPath
{
	[ComVisible(false)]
	internal abstract class QueryExpression
	{
		public QueryOperator Operator
		{
			get;
			set;
		}

		public abstract bool IsMatch(JToken jtoken_0);
	}
}
