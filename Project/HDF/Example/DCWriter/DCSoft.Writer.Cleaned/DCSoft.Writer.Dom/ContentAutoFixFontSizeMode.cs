using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       单元格内容自适应设置字体大小模式。
	///       </summary>
	[Guid("8A20F8C0-2D0D-48DA-B6C4-ADBC21405606")]
	[DCPublishAPI]
	[ComVisible(true)]
	[DocumentComment]
	public enum ContentAutoFixFontSizeMode
	{
		/// <summary>
		///       无设置
		///       </summary>
		None,
		/// <summary>
		///       单行设置
		///       </summary>
		SingleLine,
		/// <summary>
		///       多行设置,只有单元格所在表格行为固定高度（XTextTableRowElement.SpecifyHeight属性值不为0）
		///       该设置才有效，否则等于SingleLine。
		///       </summary>
		MultiLine
	}
}
