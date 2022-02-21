using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       查询扩展文本事件委托对象
	///       </summary>
	/// <param name="eventSender">事件发起者</param>
	/// <param name="args">事件参数</param>
	[Guid("EE2A3DFE-A539-46BE-8200-9F4E80FD8BD8")]
	
	[ComVisible(true)]
	[DocumentComment]
	public delegate void WriterGetAdornTextEventHandler(object sender, WriterGetAdornTextEventArgs e);
}
