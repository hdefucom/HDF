using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       内容保护模式
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	
	[ComVisible(true)]
	[Guid("00012345-6789-ABCD-EF01-234567890065")]
	
	public enum ContentProtectType
	{
		/// <summary>
		///       无设置，不保护
		///       </summary>
		None,
		/// <summary>
		///       保护内容，但可以在中间插入内容
		///       </summary>
		Content,
		/// <summary>
		///       保护区域，这个区域中间不可插入内容
		///       </summary>
		Range
	}
}
