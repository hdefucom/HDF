using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       文档元素执行表达式事件委托类型
	///       </summary>
	/// <param name="eventSender">参数</param>
	/// <param name="args">参数</param>
	[DocumentComment]
	[Guid("EEE5312C-0068-4FEB-B479-CCB87D498548")]
	
	[ComVisible(true)]
	public delegate void ElementExpressionEventHandler(object sender, ElementExpressionEventArgs e);
}
