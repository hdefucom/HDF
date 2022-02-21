using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       文档外部链接点击事件
	///       </summary>
	[DocumentComment]
	
	[ComVisible(false)]
	public delegate void LinkClickEventHandler(object sender, LinkClickEventArgs e);
}
