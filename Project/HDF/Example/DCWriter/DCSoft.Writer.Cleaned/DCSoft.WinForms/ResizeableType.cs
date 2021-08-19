using System.Runtime.InteropServices;

namespace DCSoft.WinForms
{
	/// <summary>
	///       可改变大小的操作类型
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[Guid("EBB6EC8A-6762-400E-A016-2B8BCB9C6D31")]
	[ComVisible(true)]
	public enum ResizeableType
	{
		/// <summary>
		///       固定大小
		///       </summary>
		FixSize,
		/// <summary>
		///       可改变宽度
		///       </summary>
		Width,
		/// <summary>
		///       可改变高度
		///       </summary>
		Height,
		/// <summary>
		///       可改变宽度高度
		///       </summary>
		WidthAndHeight
	}
}
