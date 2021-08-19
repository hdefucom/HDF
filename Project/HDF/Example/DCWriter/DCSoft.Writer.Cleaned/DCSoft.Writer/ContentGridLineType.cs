using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       内容网格线类型
	///       </summary>
	[Guid("00012345-6789-ABCD-EF01-234567890064")]
	[ComVisible(true)]
	[DocumentComment]
	public enum ContentGridLineType
	{
		/// <summary>
		///       不显示网格线
		///       </summary>
		None,
		/// <summary>
		///       显示网格线
		///       </summary>
		Display,
		/// <summary>
		///       网格显示延伸到容器低端
		///       </summary>
		ExtentToBottom
	}
}
