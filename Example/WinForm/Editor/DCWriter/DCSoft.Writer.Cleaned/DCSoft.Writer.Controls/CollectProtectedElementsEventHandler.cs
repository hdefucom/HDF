using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       收集内容保护信息事件委托类型
	///       </summary>
	/// <param name="eventSender">参数</param>
	/// <param name="args">参数</param>
	[ComVisible(true)]
	[DocumentComment]
	[Guid("685235D1-6F04-43DF-87A7-2E11A8073F94")]
	[DCInternal]
	public delegate void CollectProtectedElementsEventHandler(object sender, CollectProtectedElementsEventArgs e);
}
