using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       高亮度激活模式
	///       </summary>
	[ComVisible(false)]
	[DocumentComment]
	public enum HighlightActiveStyle
	{
		/// <summary>
		///       鼠标悬停时才激活
		///       </summary>
		[DCDescription(typeof(HighlightActiveStyle), "Hover")]
		Hover,
		/// <summary>
		///       静态的，一直处于激活状态,但不能打印
		///       </summary>
		[DCDescription(typeof(HighlightActiveStyle), "Static")]
		Static,
		/// <summary>
		///       永久的，一直处于激活状态，而且能打印
		///       </summary>
		[DCDescription(typeof(HighlightActiveStyle), "AllTime")]
		AllTime
	}
}
