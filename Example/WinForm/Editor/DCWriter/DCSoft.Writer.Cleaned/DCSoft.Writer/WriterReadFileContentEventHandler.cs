using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       读取文件内容事件委托类型
	///       </summary>
	/// <param name="eventSender">事件发起者</param>
	/// <param name="args">事件参数</param>
	
	[Guid("7B080AF5-93F3-4D7C-90C7-AA06A7DDB43D")]
	[ComVisible(true)]
	
	public delegate void WriterReadFileContentEventHandler(object sender, WriterReadFileContentEventArgs e);
}
