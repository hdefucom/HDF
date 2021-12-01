using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Printing
{
	/// <summary>
	///       续打模式
	///       </summary>
	[ComVisible(true)]
	[Guid("B1A2715F-5307-4B38-8D87-3B9FCC9E257B")]
	[DocumentComment]
	public enum JumpPrintMode
	{
		/// <summary>
		///       禁止续打
		///       </summary>
		Disable,
		/// <summary>
		///       常规续打模式,鼠标定位选择续打位置
		///       </summary>
		Normal,
		/// <summary>
		///       整体偏移续打模式，鼠标定位偏移续打位置
		///       </summary>
		Offset,
		/// <summary>
		///       增量续打模式，程序设置续打的页数和位置，第一页不忽略标题行
		///       </summary>
		Append
	}
}
