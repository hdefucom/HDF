using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       遍历文档元素事件委托类型 
	///       </summary>
	/// <param name="eventSender">
	/// </param>
	/// <param name="args">
	/// </param>
	[ComVisible(false)]
	[DocumentComment]
	public delegate void ElementEnumerateEventHandler(object sender, ElementEnumerateEventArgs e);
}
