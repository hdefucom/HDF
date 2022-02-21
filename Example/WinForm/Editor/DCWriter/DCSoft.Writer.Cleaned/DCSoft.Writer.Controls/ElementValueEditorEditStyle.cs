using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       编辑器编辑模式
	///       </summary>
	[ComVisible(false)]
	
	public enum ElementValueEditorEditStyle
	{
		/// <summary>
		///       无编辑器
		///       </summary>
		None,
		/// <summary>
		///       下拉列表模式
		///       </summary>
		DropDown,
		/// <summary>
		///       对话框模式
		///       </summary>
		Modal
	}
}
