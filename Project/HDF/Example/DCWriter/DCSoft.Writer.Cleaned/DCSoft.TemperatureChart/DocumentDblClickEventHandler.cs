using System.Runtime.InteropServices;

namespace DCSoft.TemperatureChart
{
	/// <summary>
	///       文档双击事件委托类型
	///       </summary>
	/// <param name="eventSender">
	/// </param>
	/// <param name="args">
	/// </param>
	[ComVisible(true)]
	[Guid("0CF9FF68-CBD0-4FF2-B632-5FD2F6C9989B")]
	public delegate void DocumentDblClickEventHandler(object sender, DocumentDblClickEventArgs e);
}
