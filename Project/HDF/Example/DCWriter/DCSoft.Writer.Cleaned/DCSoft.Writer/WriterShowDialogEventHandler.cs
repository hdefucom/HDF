using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       显示对话框事件委托类型
	///       </summary>
	/// <param name="eventSender">消息发送者</param>
	/// <param name="args">事件参数</param>
	[Guid("1B856029-ED44-4864-B5A8-CB62D5FB34BF")]
	[ComVisible(true)]
	[DocumentComment]
	[DCPublishAPI]
	public delegate void WriterShowDialogEventHandler(object sender, WriterShowDialogEventArgs e);
}
