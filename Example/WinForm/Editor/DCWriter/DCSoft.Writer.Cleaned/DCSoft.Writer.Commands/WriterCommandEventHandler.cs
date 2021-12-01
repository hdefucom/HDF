using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       编辑器命令事件委托类型
	///       </summary>
	/// <param name="eventSender">参数</param>
	/// <param name="args">参数</param>
	[ComVisible(true)]
	[DCPublishAPI]
	[DocumentComment]
	[Guid("707FBF79-4B03-4D77-90A0-91FCF72B577C")]
	public delegate void WriterCommandEventHandler(object sender, WriterCommandEventArgs e);
}
