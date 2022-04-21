using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       编辑器鼠标事件委托对象
	///       </summary>
	/// <param name="eventSender">
	/// </param>
	/// <param name="args">
	/// </param>
	
	
	[ComVisible(true)]
	[Guid("E94B7DD8-18E1-45BC-80E7-5D14700CD666")]
	public delegate void WriterMouseEventHandler(object sender, WriterMouseEventArgs e);
}
