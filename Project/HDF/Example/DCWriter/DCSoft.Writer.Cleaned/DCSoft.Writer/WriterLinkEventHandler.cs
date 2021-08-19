using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       超链接事件委托类型
	///       </summary>
	/// <param name="eventSender">事件发起者</param>
	/// <param name="args">事件参数</param>
	[ComVisible(true)]
	[DCPublishAPI]
	[DocumentComment]
	[Guid("FAD7614A-6C96-4B63-AB57-9C6FFADB23A6")]
	public delegate void WriterLinkEventHandler(object sender, WriterLinkEventArgs e);
}
