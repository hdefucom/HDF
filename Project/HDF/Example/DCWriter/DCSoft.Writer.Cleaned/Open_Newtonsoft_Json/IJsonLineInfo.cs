using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json
{
	/// <summary>
	///       Provides an interface to enable a class to return line and position information.
	///       </summary>
	[ComVisible(false)]
	public interface IJsonLineInfo
	{
		/// <summary>
		///       Gets the current line number.
		///       </summary>
		/// <value>The current line number or 0 if no line information is available (for example, HasLineInfo returns false).</value>
		int LineNumber
		{
			get;
		}

		/// <summary>
		///       Gets the current line position.
		///       </summary>
		/// <value>The current line position or 0 if no line information is available (for example, HasLineInfo returns false).</value>
		int LinePosition
		{
			get;
		}

		/// <summary>
		///       Gets a value indicating whether the class can return line information.
		///       </summary>
		/// <returns>
		///   <c>true</c> if LineNumber and LinePosition can be provided; otherwise, <c>false</c>.
		///       </returns>
		bool HasLineInfo();
	}
}
