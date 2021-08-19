using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       绘制文档内容的委托类型
	///       </summary>
	/// <param name="eventSender">参数</param>
	/// <param name="args">参数</param>
	[ComVisible(false)]
	[DCPublishAPI]
	[Guid("F4333861-7499-46F1-9459-2276D5B94B52")]
	[DocumentComment]
	public delegate void DocumentPaintEventHandler(object sender, DocumentPaintEventArgs e);
}
