using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       带取消功能的文档事件委托类型
	///       </summary>
	/// <param name="eventSender">参数</param>
	/// <param name="args">参数</param>
	[ComVisible(true)]
	[Guid("D1DA0DD1-2FAE-49FC-B43C-B421A5D7F33B")]
	
	
	public delegate void ElementCancelEventHandler(object sender, ElementCancelEventArgs e);
}
