using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       提示内容保护事件委托对象
	///       </summary>
	/// <param name="eventSender">事件发起者</param>
	/// <param name="args">参数</param>
	[DCInternal]
	[Guid("A3DD128C-BEF7-487E-98C8-1CB3D7E47DBA")]
	[ComVisible(true)]
	public delegate void PromptProtectedContentEventHandler(object sender, PromptProtectedContentEventArgs e);
}
