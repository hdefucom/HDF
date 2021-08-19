using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       下拉列表选择事件委托类型
	///       </summary>
	/// <param name="eventSender">事件发起者</param>
	/// <param name="args">事件参数</param>
	[Guid("76E9B91C-C1D8-455E-815E-DF9F542EDB89")]
	[DocumentComment]
	[ComVisible(true)]
	[DCPublishAPI]
	public delegate void WriterAfterFieldContentEditEventHandler(object sender, WriterAfterFieldContentEditEventArgs e);
}
