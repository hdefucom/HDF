using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       准备播放媒体事件委托类型
	///       </summary>
	/// <param name="eventSender">事件发起者</param>
	/// <param name="args">参数</param>
	
	[ComVisible(true)]
	
	[Guid("0DE77369-D8AB-4D06-902B-FF6A9ED613F9")]
	public delegate void WriterBeforePlayMediaEventHandler(object sender, WriterBeforePlayMediaEventArgs e);
}
