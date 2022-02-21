using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       判断能否插入对象事件委托类型
	///       </summary>
	/// <param name="eventSender">参数</param>
	/// <param name="args">参数</param>
	[DocumentComment]
	[Guid("00012345-6789-ABCD-EF01-23456789005A")]
	[ComVisible(true)]
	
	public delegate void CanInsertObjectEventHandler(object sender, CanInsertObjectEventArgs e);
}
