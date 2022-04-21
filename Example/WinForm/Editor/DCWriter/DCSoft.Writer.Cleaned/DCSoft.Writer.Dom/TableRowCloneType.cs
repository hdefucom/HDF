using DCSoft.Common;
using DCSoft.Design;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       表格行复制模式
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[ComVisible(true)]
	[Guid("7981C946-F761-4990-A19B-4F368873BF56")]
	
	[Editor(typeof(EnumEditorSupportDescription), typeof(UITypeEditor))]
	public enum TableRowCloneType
	{
		/// <summary>
		///       默认方式，只复制表格行及单元格，不复制内容。对于单元格是继承上级设置。
		///       </summary>
		[DCDescription(typeof(TableRowCloneType), "Default")]
		Default,
		/// <summary>
		///       复制内容，但删除输入域中的内容。
		///       </summary>
		[DCDescription(typeof(TableRowCloneType), "ContentWithClearField")]
		ContentWithClearField,
		/// <summary>
		///       完整的复制，包括输入域中的内容。
		///       </summary>
		[DCDescription(typeof(TableRowCloneType), "Complete")]
		Complete
	}
}
