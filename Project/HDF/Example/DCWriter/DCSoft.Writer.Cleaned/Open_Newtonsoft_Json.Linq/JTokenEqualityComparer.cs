using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Linq
{
	/// <summary>
	///       Compares tokens to determine whether they are equal.
	///       </summary>
	[ComVisible(false)]
	public class JTokenEqualityComparer : IEqualityComparer<JToken>
	{
		/// <summary>
		///       Determines whether the specified objects are equal.
		///       </summary>
		/// <param name="x">The first object of type <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> to compare.</param>
		/// <param name="y">The second object of type <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> to compare.</param>
		/// <returns>
		///       true if the specified objects are equal; otherwise, false.
		///       </returns>
		public bool Equals(JToken jtoken_0, JToken jtoken_1)
		{
			return JToken.DeepEquals(jtoken_0, jtoken_1);
		}

		/// <summary>
		///       Returns a hash code for the specified object.
		///       </summary>
		/// <param name="obj">The <see cref="T:System.Object" /> for which a hash code is to be returned.</param>
		/// <returns>A hash code for the specified object.</returns>
		/// <exception cref="T:System.ArgumentNullException">The type of <paramref name="obj" /> is a reference type and <paramref name="obj" /> is null.</exception>
		public int GetHashCode(JToken jtoken_0)
		{
			return jtoken_0?.GetDeepHashCode() ?? 0;
		}
	}
}
