using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Serialization
{
	[ComVisible(false)]
	internal enum JsonContractType
	{
		None,
		Object,
		Array,
		Primitive,
		String,
		Dictionary,
		Dynamic,
		Serializable,
		Linq
	}
}
