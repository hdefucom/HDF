using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       文档元素排版位置样式
	///       </summary>
	
	[ComVisible(true)]
	[Guid("9DB889B4-DDBC-434F-A376-D847B87D4A2D")]
	public enum ElementPositionStyle
	{
		/// <summary>
		///       标准模式
		///       </summary>
		Static,
		/// <summary>
		///       相对坐标定位模式
		///       </summary>
		Relative
	}
}
