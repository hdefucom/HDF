using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       数据过滤器事件委托类型
	///       </summary>
	/// <param name="eventSender">发起者</param>
	/// <param name="args">事件参数</param>
	[DocumentComment]
	[ComVisible(true)]
	[Guid("6A4CEF82-6542-47FE-89F1-37EAD4A2BE4B")]
	public delegate void FilterValueEventHandler(object sender, FilterValueEventArgs e);
}
