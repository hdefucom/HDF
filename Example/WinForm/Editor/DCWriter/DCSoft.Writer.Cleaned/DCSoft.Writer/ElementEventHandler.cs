using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       文档元素事件委托类型
	///       </summary>
	/// <param name="eventSender">参数</param>
	/// <param name="args">参数</param>
	[ComVisible(true)]
	
	[DocumentComment]
	[Guid("769AE107-E6BA-49E3-8298-1F5A654D15DF")]
	public delegate void ElementEventHandler(object sender, ElementEventArgs e);
}
