using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       查询辅助录入使用的字符串列表事件委托类型
	///       </summary>
	/// <param name="eventSender">
	/// </param>
	/// <param name="args">
	/// </param>
	[Guid("422ECAD7-F571-4355-94C6-AB2E7498BA2A")]
	[DCPublishAPI]
	[ComVisible(true)]
	public delegate void WriterQueryAssistInputItemsEventHandler(object sender, WriterQueryAssistInputItemsEventArgs e);
}
