using Open_Newtonsoft_Json.Utilities;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Serialization
{
	[ComVisible(false)]
	internal class DefaultContractResolverState
	{
		public Dictionary<ResolverContractKey, JsonContract> ContractCache;

		public PropertyNameTable NameTable = new PropertyNameTable();
	}
}
