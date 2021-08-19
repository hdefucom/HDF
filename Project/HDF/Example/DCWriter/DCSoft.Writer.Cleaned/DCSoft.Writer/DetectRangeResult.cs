using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       检测区域的结果
	///       </summary>
	[ComVisible(false)]
	[DCPublishAPI]
	public enum DetectRangeResult
	{
		/// <summary>
		///       包含在区域中
		///       </summary>
		Include,
		/// <summary>
		///       不包含在区域中
		///       </summary>
		Exclude,
		/// <summary>
		///       结束
		///       </summary>
		Finish,
		/// <summary>
		///       取消获得区域操作
		///       </summary>
		Cancel
	}
}
