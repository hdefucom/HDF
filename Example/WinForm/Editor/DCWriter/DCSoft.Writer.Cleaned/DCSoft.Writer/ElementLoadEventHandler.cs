using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       文档元素加载事件委托对象
	///       </summary>
	/// <param name="eventSender">参数</param>
	/// <param name="args">参数</param>
	[Guid("7534DC89-ADC3-4AF9-96AD-670D7B754B60")]
	[ComVisible(true)]
	
	public delegate void ElementLoadEventHandler(object sender, ElementLoadEventArgs e);
}
