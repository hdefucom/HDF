using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       输入来源
	///       </summary>
	[ComVisible(true)]
	[Guid("39EB4EA4-7E7D-4ED9-B088-368A18319BC5")]
	[DCPublishAPI]
	[DocumentComment]
	public enum InputValueSource
	{
		/// <summary>
		///       数据来自系统剪切板
		///       </summary>
		Clipboard,
		/// <summary>
		///       数据来用户界面的用户输入
		///       </summary>
		UI,
		/// <summary>
		///       OLE拖拽
		///       </summary>
		DragDrop,
		/// <summary>
		///       未知
		///       </summary>
		Unknow
	}
}
