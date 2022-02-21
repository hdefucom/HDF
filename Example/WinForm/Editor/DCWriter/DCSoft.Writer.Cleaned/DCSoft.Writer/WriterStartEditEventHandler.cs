using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       控件开始编辑文档事件委托类型
	///       </summary>
	/// <param name="sender">
	/// </param>
	/// <param name="args">
	/// </param>
	
	[Guid("212AA263-7237-488A-AD74-AE965E31C7E9")]
	[ComVisible(true)]
	[DocumentComment]
	public delegate void WriterStartEditEventHandler(object sender, WriterStartEditEventArgs e);
}
