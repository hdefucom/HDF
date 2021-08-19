using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       编辑文档元素数值事件委托类型
	///       </summary>
	/// <param name="eventSender">事件发起者</param>
	/// <param name="args">事件参数</param>
	[DCPublishAPI]
	[ComVisible(true)]
	[Guid("51C8A5C3-9314-4CE0-981B-901B1623E760")]
	public delegate void WriterEditElementValueEventHandler(object sender, WriterEditElementValueEventArgs e);
}
