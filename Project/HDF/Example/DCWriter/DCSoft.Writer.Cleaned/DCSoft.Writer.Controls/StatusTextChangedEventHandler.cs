using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       状态文本发生改变事件委托
	///       </summary>
	/// <param name="eventSender">
	/// </param>
	/// <param name="args">
	/// </param>
	[Guid("1945D863-62B6-482B-BF89-A2D5CF9890C5")]
	[ComVisible(true)]
	[DCPublishAPI]
	public delegate void StatusTextChangedEventHandler(object sender, StatusTextChangedEventArgs e);
}
