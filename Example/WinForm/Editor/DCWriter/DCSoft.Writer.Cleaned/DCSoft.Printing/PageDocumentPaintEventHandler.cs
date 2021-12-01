using System.Runtime.InteropServices;

namespace DCSoft.Printing
{
	/// <summary>
	///       分页文档绘制内容事件委托类型
	///       </summary>
	/// <param name="sender">事件发起者</param>
	/// <param name="args">事件参数</param>
	[ComVisible(false)]
	public delegate void PageDocumentPaintEventHandler(object sender, PageDocumentPaintEventArgs e);
}
