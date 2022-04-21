using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       OLE拖拽操作状态
	///       </summary>
	[ComVisible(false)]
	
	
	public enum DragOperationState
	{
		/// <summary>
		///       没有执行拖拽操作
		///       </summary>
		None,
		/// <summary>
		///       正在执行内部拖拽被选择区域的操作
		///       </summary>
		DragingSelection,
		/// <summary>
		///       正在接受来自外界的拖拽操作 
		///       </summary>
		Drag,
		/// <summary>
		///       在本编辑器内部执行拖拽内容操作。
		///       </summary>
		DragDropInOwnerWriterControl
	}
}
