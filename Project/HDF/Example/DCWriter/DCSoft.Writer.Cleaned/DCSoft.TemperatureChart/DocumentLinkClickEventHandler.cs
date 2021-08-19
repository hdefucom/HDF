using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.TemperatureChart
{
	/// <summary>
	///       文档超链接点击事件委托类型
	///       </summary>
	/// <param name="eventSender">事件发起者</param>
	/// <param name="args">事件参数</param>
	[DocumentComment]
	[Guid("CB9CC65D-87DB-428C-90C2-76CFF4988964")]
	[ComVisible(true)]
	public delegate void DocumentLinkClickEventHandler(object sender, DocumentLinkClickEventArgs e);
}
