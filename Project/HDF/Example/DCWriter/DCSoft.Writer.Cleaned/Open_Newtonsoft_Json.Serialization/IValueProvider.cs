using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Serialization
{
	/// <summary>
	///       Provides methods to get and set values.
	///       </summary>
	[ComVisible(false)]
	public interface IValueProvider
	{
		/// <summary>
		///       Sets the value.
		///       </summary>
		/// <param name="target">The target to set the value on.</param>
		/// <param name="value">The value to set on the target.</param>
		void SetValue(object target, object value);

		/// <summary>
		///       Gets the value.
		///       </summary>
		/// <param name="target">The target to get the value from.</param>
		/// <returns>The value.</returns>
		object GetValue(object target);
	}
}
