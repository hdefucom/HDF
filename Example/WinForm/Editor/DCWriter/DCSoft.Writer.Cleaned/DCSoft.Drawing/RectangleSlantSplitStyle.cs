using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Drawing
{
	/// <summary>
	///       矩形分割斜线样式
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[Guid("731602F9-E5E1-4ABD-BD3B-44A4FF03D3AB")]
	[DocumentComment]
	[ComVisible(true)]
	public enum RectangleSlantSplitStyle
	{
		/// <summary>
		///       无样式
		///       </summary>
		None,
		/// <summary>
		///       从左上角出发的一条斜线
		///       </summary>
		TopLeftOneLine,
		/// <summary>
		///       从左上角出发的两条斜线
		///       </summary>
		TopLeftTwoLines,
		/// <summary>
		///       从右上角出发的一条斜线
		///       </summary>
		TopRightOneLine,
		/// <summary>
		///       从右上角出发的两条斜线
		///       </summary>
		TopRightTwoLines,
		/// <summary>
		///       从右下角出发的一条斜线
		///       </summary>
		BottomRightOneLine,
		/// <summary>
		///       从右下角出发的两条斜线
		///       </summary>
		BottomRigthTwoLines,
		/// <summary>
		///       从左下角出发的一条斜线
		///       </summary>
		BottomLeftOneLine,
		/// <summary>
		///       从左下角出发的两条斜线
		///       </summary>
		BottomLeftTwoLines
	}
}
