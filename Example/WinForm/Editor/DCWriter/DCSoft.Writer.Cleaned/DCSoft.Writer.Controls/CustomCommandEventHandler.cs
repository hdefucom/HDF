using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       自定义命令事件委托类型
	///       </summary>
	/// <param name="objectSender">参数</param>
	/// <param name="args">参数</param>
	[Guid("00012345-6789-ABCD-EF01-234567890260")]
	
	[ComVisible(true)]
	public delegate void CustomCommandEventHandler(object sender, CustomCommandEventArgs e);
}
