using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       文档内容正在发生改变时事件委托类型
	///       </summary>
	/// <param name="eventSender">发起者</param>
	/// <param name="args">事件参数</param>
	/// <remarks>编写 袁永福</remarks>
	[Guid("00012345-6789-ABCD-EF01-234567890060")]
	[ComVisible(true)]
	[DocumentComment]
	
	public delegate void ContentChangingEventHandler(object sender, ContentChangingEventArgs e);
}
