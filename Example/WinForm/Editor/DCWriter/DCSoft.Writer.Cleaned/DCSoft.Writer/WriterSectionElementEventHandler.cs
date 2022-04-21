using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       文档节元素事件委托类型
	///       </summary>
	/// <param name="eventSender">参数</param>
	/// <param name="args">参数</param>
	
	
	[Guid("C6C8545A-C0FF-415C-9B30-35BB1042BB67")]
	[ComVisible(true)]
	public delegate void WriterSectionElementEventHandler(object sender, WriterSectionElementEventArgs e);
}
