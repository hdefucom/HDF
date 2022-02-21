using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       文档内容发生改变事件委托类型
	///       </summary>
	/// <param name="eventSender">发起者</param>
	/// <param name="args">事件参数</param>
	/// <remarks>编写 袁永福</remarks>
	[DocumentComment]
	
	[Guid("00012345-6789-ABCD-EF01-23456789005C")]
	[ComVisible(true)]
	public delegate void ContentChangedEventHandler(object sender, ContentChangedEventArgs e);
}
