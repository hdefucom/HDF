using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Linq.JsonPath
{
	[ComVisible(false)]
	internal enum QueryOperator
	{
		None,
		Equals,
		NotEquals,
		Exists,
		LessThan,
		LessThanOrEquals,
		GreaterThan,
		GreaterThanOrEquals,
		And,
		Or
	}
}
