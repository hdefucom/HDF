using DCSoft.Common;
using System;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       打印预览缩放比率
	///       </summary>
	[ComVisible(true)]
	[Flags]
	[Guid("E41771FA-DF00-48D1-B81F-7CB8164367E9")]
	[DocumentComment]
	public enum PrintPreviewZoomRate
	{
		/// <summary>
		///       10%的缩放率
		///       </summary>
		Zooom10 = 0x0,
		/// <summary>
		///       25%的缩放率
		///       </summary>
		Zoom25 = 0x1,
		/// <summary>
		///       50%的缩放率
		///       </summary>
		Zoom50 = 0x2,
		/// <summary>
		///       75%的缩放率
		///       </summary>
		Zoom75 = 0x3,
		/// <summary>
		///       100%的缩放率
		///       </summary>
		Zoom100 = 0x4,
		/// <summary>
		///       150%的缩放率
		///       </summary>
		Zoom150 = 0x5,
		/// <summary>
		///       250%的缩放率
		///       </summary>
		Zoom250 = 0x6,
		/// <summary>
		///       500%的缩放率
		///       </summary>
		Zoom500 = 0x7
	}
}
