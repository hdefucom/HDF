using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       下拉列表选择事件委托类型
	///       </summary>
	/// <param name="eventSender">事件发起者</param>
	/// <param name="args">事件参数</param>
	[ComVisible(true)]
	
	[Guid("FA97BCFB-CE87-4889-855D-7899262BBFEF")]
	[DocumentComment]
	public delegate void WriterBeforeFieldContentEditEventHandler(object sender, WriterBeforeFieldContentEditEventArgs e);
}
