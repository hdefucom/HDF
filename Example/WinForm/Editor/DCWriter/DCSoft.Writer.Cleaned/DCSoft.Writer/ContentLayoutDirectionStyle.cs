using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       文档内容排版方向
	///       </summary>
	
	[ComVisible(true)]
	[DocumentComment]
	[Guid("4E19CE49-1EF3-4911-A72A-F58412F2F275")]
	public enum ContentLayoutDirectionStyle
	{
		/// <summary>
		///       默认样式
		///       </summary>
		Default,
		/// <summary>
		///       从左到右排版
		///       </summary>
		LeftToRight,
		/// <summary>
		///       从右到左排版
		///       </summary>
		RightToLeft,
		/// <summary>
		///       无效值
		///       </summary>
		Invalidate
	}
}
