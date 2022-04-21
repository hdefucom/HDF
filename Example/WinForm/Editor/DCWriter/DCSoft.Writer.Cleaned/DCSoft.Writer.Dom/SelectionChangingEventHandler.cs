using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       选择区域正在发生改变事件委托类型
	///       </summary>
	/// <param name="eventSender">参数</param>
	/// <param name="args">参数</param>
	[Guid("F886DD59-6F8D-4FEC-B1B5-34990D93B71D")]
	
	
	[ComVisible(true)]
	public delegate void SelectionChangingEventHandler(object sender, SelectionChangingEventArgs e);
}
