using System;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom.Undo
{
	/// <summary>
	///       撤销操作方法类型
	///       </summary>
	[Flags]
	[ComVisible(false)]
	public enum UndoMethodTypes
	{
		/// <summary>
		///       无任何操作
		///       </summary>
		None = 0x0,
		/// <summary>
		///       重新分页
		///       </summary>
		RefreshPages = 0x1,
		/// <summary>
		///       刷新文档布局
		///       </summary>
		RefreshLayout = 0x2,
		/// <summary>
		///       刷新整个文档
		///       </summary>
		RefreshDocument = 0x3,
		/// <summary>
		///       刷新文档视图
		///       </summary>
		UpdateDocumentView = 0x4,
		/// <summary>
		///       重新绘制整个文档
		///       </summary>
		Invalidate = 0x5,
		/// <summary>
		///       刷新文档批注
		///       </summary>
		RefreshComment = 0x6,
		/// <summary>
		///       刷新段落层次树
		///       </summary>
		RefreshParagraphTree = 0x7,
		/// <summary>
		///       更新表达式引擎
		///       </summary>
		UpdateExpressionExecuter = 0x8
	}
}
