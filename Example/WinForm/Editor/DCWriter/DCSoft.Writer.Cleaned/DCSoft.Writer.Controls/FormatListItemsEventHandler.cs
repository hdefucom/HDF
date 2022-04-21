using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       获得列表项目显示的文本的事件委托类型
	///       </summary>
	/// <param name="eventSender">参数</param>
	/// <param name="args">参数</param>
	[Guid("7ABE9097-75CF-4F59-B3DD-93361003992E")]
	[ComVisible(true)]
	
	
	public delegate void FormatListItemsEventHandler(object sender, FormatListItemsEventArgs e);
}
