using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       编辑器表达式执行函数事件委托类型
	///       </summary>
	/// <param name="eventSender">
	/// </param>
	/// <param name="args">
	/// </param>
	[DocumentComment]
	[Guid("611852F5-9124-4928-B55A-272B5EF856D7")]
	[ComVisible(true)]
	
	public delegate void WriterExpressionFunctionEventHandler(object sender, WriterExpressionFunctionEventArgs e);
}
