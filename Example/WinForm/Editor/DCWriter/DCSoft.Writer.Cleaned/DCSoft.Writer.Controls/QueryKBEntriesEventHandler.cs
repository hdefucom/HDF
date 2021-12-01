using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       查询知识库列表使用的事件委托类型
	///       </summary>
	/// <param name="eventSender">参数</param>
	/// <param name="args">参数</param>
	[Guid("E368ACB7-14FA-42C3-993E-8B8AF86E56D0")]
	[DCPublishAPI]
	[ComVisible(true)]
	public delegate void QueryKBEntriesEventHandler(object sender, QueryKBEntriesEventArgs e);
}
