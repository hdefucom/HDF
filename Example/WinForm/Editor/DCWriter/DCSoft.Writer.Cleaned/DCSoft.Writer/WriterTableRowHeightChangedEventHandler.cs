using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       表格行高度改变事件委托类型
	///       </summary>
	/// <param name="eventSender">事件参数</param>
	/// <param name="args">事件参数</param>
	[ComVisible(true)]
	[Guid("F1266F85-78A4-4E04-B50E-CC0F07409FC8")]
	
	public delegate void WriterTableRowHeightChangedEventHandler(object sender, WriterTableRowHeightChangedEventArgs e);
}
