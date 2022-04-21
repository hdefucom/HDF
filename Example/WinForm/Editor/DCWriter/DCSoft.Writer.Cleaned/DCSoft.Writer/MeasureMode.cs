using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       字符测量模式
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[Guid("92556870-2C63-4F8D-AF25-6A64BC82C702")]
	[ComVisible(true)]
	
	public enum MeasureMode
	{
		/// <summary>
		///       默认方式
		///       </summary>
		Default,
		/// <summary>
		///       RTF兼容模式
		///       </summary>
		RichTextBoxCompatibility,
		/// <summary>
		///       旧格式兼容模式
		///       </summary>
		OldCompatibility
	}
}
