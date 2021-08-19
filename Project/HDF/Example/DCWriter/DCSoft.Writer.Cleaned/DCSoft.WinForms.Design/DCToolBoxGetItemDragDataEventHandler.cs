using System.Runtime.InteropServices;

namespace DCSoft.WinForms.Design
{
	/// <summary>
	///       获得拖拽数据事件委托类型
	///       </summary>
	/// <param name="sender">参数</param>
	/// <param name="args">参数</param>
	[ComVisible(false)]
	public delegate void DCToolBoxGetItemDragDataEventHandler(object sender, DCToolBoxGetItemDragDataEventArgs e);
}
