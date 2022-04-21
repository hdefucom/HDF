using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       创建对象实例事件委托类型
	///       </summary>
	/// <param name="eventSender">参数</param>
	/// <param name="args">参数</param>
	[ComVisible(true)]
	
	
	[Guid("E0C25BFF-79B9-4BB2-8BC9-2FCD2BFF99A5")]
	public delegate void CreateInstanceEventHandler(object sender, CreateInstanceEventArgs e);
}
