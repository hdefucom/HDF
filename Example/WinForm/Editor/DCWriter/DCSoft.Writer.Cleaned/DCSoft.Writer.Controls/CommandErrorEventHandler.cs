using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       命令执行错误处理委托类型
	///       </summary>
	/// <param name="eventSender">参数</param>
	/// <param name="args">参数</param>
	[Guid("807C8050-C234-4A8D-90A7-196B1B970FC8")]
	[DocumentComment]
	[DCPublishAPI]
	[ComVisible(true)]
	public delegate void CommandErrorEventHandler(object sender, CommandErrorEventArgs e);
}
