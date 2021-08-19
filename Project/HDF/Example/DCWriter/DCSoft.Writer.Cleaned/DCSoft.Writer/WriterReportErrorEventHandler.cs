using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       保存错误事件委托类型
	///       </summary>
	/// <param name="eventSender">
	/// </param>
	/// <param name="args">
	/// </param>
	[Guid("D6A1E701-689F-461D-8E28-FF47B46C0DDD")]
	[DCPublishAPI]
	[ComVisible(true)]
	public delegate void WriterReportErrorEventHandler(object sender, WriterReportErrorEventArgs e);
}
