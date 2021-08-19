using System.Runtime.InteropServices;

namespace DCSoft.Script
{
	/// <summary>
	///       script error
	///       </summary>
	[ComVisible(false)]
	public enum ScriptErrorStyle
	{
		/// <summary>
		///       compile error
		///       </summary>
		Compile,
		/// <summary>
		///       runtime error
		///       </summary>
		Runtime
	}
}
