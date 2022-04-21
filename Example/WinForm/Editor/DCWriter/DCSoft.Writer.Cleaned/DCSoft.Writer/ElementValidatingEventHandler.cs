using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       文档元素内容验证事件委托类型
	///       </summary>
	/// <param name="eventSender">参数</param>
	/// <param name="args">参数</param>
	[Guid("ECFAE7DA-9386-4549-A766-BEE02B576FA7")]
	
	[ComVisible(true)]
	public delegate void ElementValidatingEventHandler(object sender, ElementValidatingEventArgs e);
}
