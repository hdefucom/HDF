using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       文档按钮事件委托类型
	///       </summary>
	/// <param name="eventSender">
	/// </param>
	/// <param name="args">
	/// </param>
	[ComVisible(true)]
	[Guid("086516CA-6DBF-4F48-94A1-E34DA51E590D")]
	
	public delegate void WriterButtonClickEventHandler(object sender, WriterButtonClickEventArgs e);
}
