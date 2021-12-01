using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Drawing
{
	/// <summary>
	///       内容对齐方式
	///       </summary>
	/// <remarks>
	///       本类型的数值和System.Drawing.ContentAlignment一样。
	///       </remarks>
	[ComVisible(true)]
	[Guid("AA61783C-53EB-42B1-A989-C094A963F8A4")]
	[DCPublishAPI]
	[DocumentComment]
	public enum DCContentAlignment
	{
		/// <summary>
		///       顶端左对齐
		///       </summary>
		[DCDescription(typeof(DCContentAlignment), "TopLeft")]
		TopLeft = 1,
		/// <summary>
		///       顶端居中对齐
		///       </summary>
		[DCDescription(typeof(DCContentAlignment), "TopCenter")]
		TopCenter = 2,
		/// <summary>
		///       顶端右对齐
		///       </summary>
		[DCDescription(typeof(DCContentAlignment), "TopRight")]
		TopRight = 4,
		/// <summary>
		///       水平居中左对齐
		///       </summary>
		[DCDescription(typeof(DCContentAlignment), "MiddleLeft")]
		MiddleLeft = 0x10,
		/// <summary>
		///       居中对齐
		///       </summary>
		[DCDescription(typeof(DCContentAlignment), "MiddleCenter")]
		MiddleCenter = 0x20,
		/// <summary>
		///       水平居中右对齐
		///       </summary>
		[DCDescription(typeof(DCContentAlignment), "MiddleRight")]
		MiddleRight = 0x40,
		/// <summary>
		///       低端左对齐
		///       </summary>
		[DCDescription(typeof(DCContentAlignment), "BottomLeft")]
		BottomLeft = 0x100,
		/// <summary>
		///       低端居中对齐
		///       </summary>
		[DCDescription(typeof(DCContentAlignment), "BottomCenter")]
		BottomCenter = 0x200,
		/// <summary>
		///       低端右对齐
		///       </summary>
		[DCDescription(typeof(DCContentAlignment), "BottomRight")]
		BottomRight = 0x400
	}
}
