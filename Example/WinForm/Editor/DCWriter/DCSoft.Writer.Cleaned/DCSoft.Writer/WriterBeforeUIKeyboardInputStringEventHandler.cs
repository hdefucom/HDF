using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       用户界面键盘输入的字符串之前的事件委托类型
	///       </summary>
	/// <param name="eventSender">事件发起者</param>
	/// <param name="args">事件参数</param>
	/// <remarks>
	///       仅仅由于键盘操作输入字符串才会触发这个事件。由于粘帖操作而插入字符串不会触发事件。
	///       </remarks>
	
	[Guid("927BF770-67B6-4064-907E-5707BD4C75B2")]
	[ComVisible(true)]
	
	public delegate void WriterBeforeUIKeyboardInputStringEventHandler(object sender, WriterBeforeUIKeyboardInputStringEventArgs e);
}
