using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       解析被选中文本的事件委托类型
	///       </summary>
	/// <param name="eventSender">参数</param>
	/// <param name="args">参数</param>
	[ComVisible(true)]
	[Guid("6D275326-F335-447D-8109-989CF9EB5D45")]
	[DocumentComment]
	
	public delegate void ParseSelectedItemsEventHandler(object sender, ParseSelectedItemsEventArgs e);
}
