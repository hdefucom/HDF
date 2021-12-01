using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       编辑器控件视图状态
	///       </summary>
	[Guid("A7315728-F85B-40B0-861C-84CA2B1F0FA8")]
	[DocumentComment]
	[ComVisible(true)]
	public enum WriterControlExtViewMode
	{
		/// <summary>
		///       正常模式
		///       </summary>
		Normal,
		/// <summary>
		///       续打模式
		///       </summary>
		JumpPrint,
		/// <summary>
		///       偏移续打模式
		///       </summary>
		OffsetJumpPrint,
		/// <summary>
		///       区域选择模式
		///       </summary>
		BoundsSelection
	}
}
