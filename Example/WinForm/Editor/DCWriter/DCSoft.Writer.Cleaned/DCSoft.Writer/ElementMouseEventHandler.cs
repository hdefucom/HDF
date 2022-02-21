using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       文档元素鼠标事件参数委托类型
	///       </summary>
	/// <param name="eventSender">参数</param>
	/// <param name="args">参数</param>
	[ComVisible(true)]
	
	[Guid("28A0AE96-8EF1-4FB1-9F1C-4B6A291F21C2")]
	[DocumentComment]
	public delegate void ElementMouseEventHandler(object sender, ElementMouseEventArgs e);
}
