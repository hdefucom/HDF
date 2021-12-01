using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       边框文本对齐方式
	///       </summary>
	[DocumentComment]
	[Guid("991F57A7-B51F-4E39-91BC-B2969A783B54")]
	[ComVisible(true)]
	public enum DCBorderTextPosition
	{
		/// <summary>
		///       靠上对齐
		///       </summary>
		Top,
		/// <summary>
		///       垂直居中
		///       </summary>
		Middle,
		/// <summary>
		///       靠下对齐
		///       </summary>
		Bottom,
		/// <summary>
		///       从左上到右下
		///       </summary>
		LeftTopRightBottom,
		/// <summary>
		///       从左下到右上
		///       </summary>
		LeftBottomRightTop
	}
}
