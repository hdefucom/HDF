using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.WinForms.Controls
{
	/// <summary>
	///       OLE拖拽事件委托类型
	///       </summary>
	/// <param name="sender">参数</param>
	/// <param name="args">参数</param>
	[ComVisible(false)]
	
	public delegate void DCCardListViewDragEventHandler(object sender, DCCardListViewDragEventArgs e);
}
