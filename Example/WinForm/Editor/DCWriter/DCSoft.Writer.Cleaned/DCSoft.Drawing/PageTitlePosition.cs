using DCSoft.Common;
using System;
using System.Runtime.InteropServices;

namespace DCSoft.Drawing
{
	/// <summary>
	///       页面标题位置
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[Guid("00012345-6789-ABCD-EF01-234567890071")]
	[Flags]
	[ComVisible(true)]
	[DocumentComment]
	public enum PageTitlePosition
	{
		/// <summary>
		///       左上角
		///       </summary>
		TopLeft = 0x1,
		/// <summary>
		///       顶部居中
		///       </summary>
		TopCenter = 0x2,
		/// <summary>
		///       右上角
		///       </summary>
		TopRight = 0x4,
		/// <summary>
		///       左下角
		///       </summary>
		BottomLeft = 0x8,
		/// <summary>
		///       低端居中
		///       </summary>
		BottomCenter = 0x10,
		/// <summary>
		///       右下角
		///       </summary>
		BottomRight = 0x20
	}
}
