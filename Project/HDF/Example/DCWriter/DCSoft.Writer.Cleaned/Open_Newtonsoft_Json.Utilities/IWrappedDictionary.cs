using System.Collections;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Utilities
{
	[ComVisible(false)]
	internal interface IWrappedDictionary : IDictionary
	{
		object UnderlyingDictionary
		{
			get;
		}
	}
}
