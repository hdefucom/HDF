using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       编辑器事件委托类型
	///       </summary>
	/// <param name="eventSender">参数</param>
	/// <param name="args">参数</param>
	/// <remarks>编制 袁永福</remarks>
	[ComVisible(true)]
	[Guid("E2CA6971-3F9B-4995-80EF-B99065098394")]
	[DocumentComment]
	[DCPublishAPI]
	public delegate void WriterEventHandler(object sender, WriterEventArgs e);
}
