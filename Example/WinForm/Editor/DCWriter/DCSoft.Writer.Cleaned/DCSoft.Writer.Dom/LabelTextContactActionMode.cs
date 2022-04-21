using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       标签文本连接模式
	///       </summary>
	[Guid("218A3274-BEF8-4E2E-9D2C-14917B843110")]
	[ComVisible(true)]
	
	public enum LabelTextContactActionMode
	{
		/// <summary>
		///       禁止文本连接
		///       </summary>
		Disable,
		/// <summary>
		///       正常模式
		///       </summary>
		Normal,
		/// <summary>
		///       只显示当前页面中第一个文档节的文本
		///       </summary>
		FirstSectionInPage,
		/// <summary>
		///       只显示当前页面中最后一个文档节的文本
		///       </summary>
		LastSectionInPage,
		/// <summary>
		///       表格行
		///       </summary>
		TableRow,
		/// <summary>
		///       页面中的第一个表格行
		///       </summary>
		FirstTableRowInPage,
		/// <summary>
		///       页面中的最后一个表格行
		///       </summary>
		LastTableRowInPage
	}
}
