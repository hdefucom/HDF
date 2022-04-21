using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       编辑器事件委托类型
	///       </summary>
	/// <param name="eventSender">参数</param>
	/// <param name="args">参数</param>
	/// <remarks>编制 袁永福</remarks>
	
	[Guid("5632A80E-F016-4F58-B795-9F0FF749DCEF")]
	
	[ComVisible(true)]
	public delegate void WriterCancelEventHandler(object sender, WriterCancelEventArgs e);
}
