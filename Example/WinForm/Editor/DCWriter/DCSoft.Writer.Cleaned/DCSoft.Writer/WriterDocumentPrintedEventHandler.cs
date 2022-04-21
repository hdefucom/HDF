using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       文档打印事件
	///       </summary>
	/// <param name="eventSender">
	/// </param>
	/// <param name="args">
	/// </param>
	
	[Guid("BC2EB288-F656-4DB6-B75A-FCE3DBC90A23")]
	[ComVisible(true)]
	
	public delegate void WriterDocumentPrintedEventHandler(object sender, WriterDocumentPrintedEventArgs e);
}
