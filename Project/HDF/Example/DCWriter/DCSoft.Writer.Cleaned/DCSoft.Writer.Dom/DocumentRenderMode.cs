using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       正在呈现的的文档模式
	///       </summary>
	[Guid("BA6217FB-9AE9-4C6A-9941-F63E8DC12EF4")]
	[DCPublishAPI]
	[ComVisible(true)]
	public enum DocumentRenderMode
	{
		/// <summary>
		///       正在WinForm用户界面上绘制图形
		///       </summary>
		Paint,
		/// <summary>
		///       正在创建包含对象内容的位图
		///       </summary>
		Bitmap,
		/// <summary>
		///       阅读版式而绘制文档
		///       </summary>
		ReadPaint,
		/// <summary>
		///       正在打印
		///       </summary>
		Print,
		/// <summary>
		///       正在输出HTML文档
		///       </summary>
		Html,
		/// <summary>
		///       正在输出PDF文档
		///       </summary>
		PDF,
		/// <summary>
		///       正在输出RTF文档
		///       </summary>
		RTF
	}
}
