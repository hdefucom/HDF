using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       文档元素键盘事件委托类型
	///       </summary>
	/// <param name="eventSender">参数</param>
	/// <param name="args">参数</param>
	[Guid("63A99A83-B14E-4DC6-B0A8-31E2792107A1")]
	[DocumentComment]
	
	[ComVisible(true)]
	public delegate void ElementKeyEventHandler(object sender, ElementKeyEventArgs e);
}
