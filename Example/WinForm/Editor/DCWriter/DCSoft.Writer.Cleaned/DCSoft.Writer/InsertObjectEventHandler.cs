using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       向文档插入对象事件委托类型
	///       </summary>
	/// <param name="eventSender">参数</param>
	/// <param name="args">参数</param>
	[Guid("00012345-6789-ABCD-EF01-23456789006D")]
	
	[ComVisible(true)]
	[DocumentComment]
	public delegate void InsertObjectEventHandler(object sender, InsertObjectEventArgs e);
}
