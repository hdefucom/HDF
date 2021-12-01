using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       文档事件委托类型
	///       </summary>
	/// <param name="eventSender">参数</param>
	/// <param name="args">参数</param>
	[ComVisible(true)]
	[DocumentComment]
	[Guid("E8F0C5A8-A6F7-4542-A801-144C978AD6F4")]
	public delegate void DocumentEventHandelr(object sender, DocumentEventArgs e);
}
