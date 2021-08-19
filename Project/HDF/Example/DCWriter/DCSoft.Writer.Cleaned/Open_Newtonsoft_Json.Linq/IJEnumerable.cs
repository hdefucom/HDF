using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Linq
{
	/// <summary>
	///       Represents a collection of <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> objects.
	///       </summary>
	/// <typeparam name="T">The type of token</typeparam>
	[ComVisible(false)]
	public interface IJEnumerable<T> : IEnumerable<T> where T : JToken
	{
		/// <summary>
		///       Gets the <see cref="T:Open_Newtonsoft_Json.Linq.IJEnumerable`1" /> with the specified key.
		///       </summary>
		/// <value>
		/// </value>
		IJEnumerable<JToken> this[object object_0]
		{
			get;
		}
	}
}
