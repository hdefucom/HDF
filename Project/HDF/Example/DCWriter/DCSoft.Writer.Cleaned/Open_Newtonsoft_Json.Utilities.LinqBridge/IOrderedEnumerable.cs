using Open_Newtonsoft_Json.Serialization;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Utilities.LinqBridge
{
	/// <summary>
	///       Represents a sorted sequence.
	///       </summary>
	[ComVisible(false)]
	internal interface IOrderedEnumerable<TElement> : IEnumerable<TElement>
	{
		/// <summary>
		///       Performs a subsequent ordering on the elements of an 
		///       <see cref="T:Open_Newtonsoft_Json.Utilities.LinqBridge.IOrderedEnumerable`1" /> according to a key.
		///       </summary>
		IOrderedEnumerable<TElement> CreateOrderedEnumerable<TKey>(Func<TElement, TKey> keySelector, IComparer<TKey> comparer, bool descending);
	}
}
