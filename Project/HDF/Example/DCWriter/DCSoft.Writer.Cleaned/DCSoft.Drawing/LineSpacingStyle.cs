using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Drawing
{
	/// <summary>
	///       行间距样式
	///       </summary>
	[DocumentComment]
	[Guid("A444A5D5-D16B-4454-B210-C1F9603636E9")]
	[ComVisible(true)]
	public enum LineSpacingStyle
	{
		/// <summary>
		///       单倍行距,此时LineSpacing值无意义。
		///       </summary>
		SpaceSingle,
		/// <summary>
		///       1.5倍行距,此时LineSpacing值无意义。
		///       </summary>
		Space1pt5,
		/// <summary>
		///       双倍行距,此时LineSpacing值无意义。
		///       </summary>
		SpaceDouble,
		/// <summary>
		///       最小值,此时LineSpacing值无意义。
		///       </summary>
		SpaceExactly,
		/// <summary>
		///       固定值,此时LineSpacing指定了行间距。
		///       </summary>
		SpaceSpecify,
		/// <summary>
		///       多倍行距,此时LineSpacing指定的倍数。
		///       </summary>
		SpaceMultiple
	}
}
