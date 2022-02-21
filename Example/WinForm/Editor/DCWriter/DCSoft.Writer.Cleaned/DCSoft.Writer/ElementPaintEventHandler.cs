using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       绘制文档元素事件委托类型
	///       </summary>
	/// <param name="eventSender">参数</param>
	/// <param name="args">参数</param>
	[DocumentComment]
	
	[ComVisible(true)]
	[Guid("6E056EE3-E5F4-401E-968D-634A2630DFED")]
	public delegate void ElementPaintEventHandler(object sender, ElementPaintEventArgs e);
}
