using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       内容修改事件来源
	///       </summary>
	[DocumentComment]
	[ComVisible(false)]
	
	public enum ContentChangedEventSource
	{
		/// <summary>
		///       默认方式
		///       </summary>
		Default,
		/// <summary>
		///       撤销操作而导致的内容修改
		///       </summary>
		UndoRedo,
		/// <summary>
		///       数值编辑器而导致的内容修改
		///       </summary>
		ValueEditor,
		/// <summary>
		///       编程而导致的内容修改
		///       </summary>
		Program
	}
}
