using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Utilities.LinqBridge
{
	/// <summary>
	///       Defines an indexer, size property, and Boolean search method for 
	///       data structures that map keys to <see cref="T:System.Collections.Generic.IEnumerable`1" /> 
	///       sequences of values.
	///       </summary>
	[ComVisible(false)]
	internal interface ILookup<TKey, TElement> : IEnumerable<IGrouping<TKey, TElement>>
	{
		int Count
		{
			get;
		}

		IEnumerable<TElement> this[TKey gparam_0]
		{
			get;
		}

		bool Contains(TKey gparam_0);
	}
}
