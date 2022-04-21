using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       查询文档元素状态信息事件委托类型
	///       </summary>
	/// <param name="eventSender">参数</param>
	/// <param name="args">参数</param>
	[Guid("8ABE70B1-30BF-452B-B3C9-60FCDC09B979")]
	[ComVisible(true)]
	
	public delegate void ElementQueryStateEventHandler(object sender, ElementQueryStateEventArgs e);
}
