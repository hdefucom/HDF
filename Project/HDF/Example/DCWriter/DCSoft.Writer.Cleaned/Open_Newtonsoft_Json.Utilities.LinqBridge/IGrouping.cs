using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Utilities.LinqBridge
{
	/// <summary>
	///       Represents a collection of objects that have a common key.
	///       </summary>
	[ComVisible(false)]
	internal interface IGrouping<TKey, TElement> : IEnumerable<TElement>
	{
		/// <summary>
		///       Gets the key of the <see cref="T:Open_Newtonsoft_Json.Utilities.LinqBridge.IGrouping`2" />.
		///       </summary>
		TKey Key
		{
			get;
		}
	}
}
