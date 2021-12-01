using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       表格行高度正在改变事件委托类型
	///       </summary>
	/// <param name="eventSender">事件参数</param>
	/// <param name="args">事件参数</param>
	[ComVisible(true)]
	[DCPublishAPI]
	[Guid("91ED0058-1CC1-4922-BFCA-17ABF63D02AA")]
	public delegate void WriterTableRowHeightChangingEventHandler(object sender, WriterTableRowHeightChangingEventArgs e);
}
