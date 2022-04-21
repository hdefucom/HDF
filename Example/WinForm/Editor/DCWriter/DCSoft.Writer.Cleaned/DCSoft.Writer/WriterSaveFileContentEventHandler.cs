using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       保存文件内容事件委托类型
	///       </summary>
	/// <param name="eventSender">事件发起者</param>
	/// <param name="args">事件参数</param>
	
	
	[Guid("92113BEC-BCAB-4F56-B53A-896FDF23591A")]
	[ComVisible(true)]
	public delegate void WriterSaveFileContentEventHandler(object sender, WriterSaveFileContentEventArgs e);
}
