using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json
{
	/// <summary>
	///       Specifies formatting options for the <see cref="T:Open_Newtonsoft_Json.JsonTextWriter" />.
	///       </summary>
	[ComVisible(false)]
	public enum Formatting
	{
		/// <summary>
		///       No special formatting is applied. This is the default.
		///       </summary>
		None,
		/// <summary>
		///       Causes child objects to be indented according to the <see cref="P:Open_Newtonsoft_Json.JsonTextWriter.Indentation" /> and <see cref="P:Open_Newtonsoft_Json.JsonTextWriter.IndentChar" /> settings.
		///       </summary>
		Indented
	}
}
