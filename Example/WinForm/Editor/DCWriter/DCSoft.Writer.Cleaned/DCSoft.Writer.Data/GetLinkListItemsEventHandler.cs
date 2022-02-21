using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Data
{
	/// <summary>
	///       联动列表项目事件委托类型
	///       </summary>
	/// <param name="eventSender">事件发起者</param>
	/// <param name="args">事件参数</param>
	
	[Guid("C8DE77B7-7C93-4904-94CF-E61ADD5994DE")]
	[DocumentComment]
	[ComVisible(true)]
	public delegate void GetLinkListItemsEventHandler(object sender, GetLinkListItemsEventArgs e);
}
