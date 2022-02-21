using DCSoft.Common;
using DCSoft.Design;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       移动输入域焦点的快捷键
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	
	[DCDescription(typeof(MoveFocusHotKeys), "MoveFocusHotKeys")]
	[Guid("00012345-6789-ABCD-EF01-234567890070")]
	[Editor(typeof(EnumEditorSupportDescription), typeof(UITypeEditor))]
	[ComVisible(true)]
	[DocumentComment]
	public enum MoveFocusHotKeys
	{
		/// <summary>
		///       无快捷键
		///       </summary>
		[DCDescription(typeof(MoveFocusHotKeys), "None")]
		None,
		/// <summary>
		///       默认方式
		///       </summary>
		[DCDescription(typeof(MoveFocusHotKeys), "Default")]
		Default,
		/// <summary>
		///       Tab键
		///       </summary>
		[DCDescription(typeof(MoveFocusHotKeys), "Tab")]
		Tab,
		/// <summary>
		///       Enter键
		///       </summary>
		[DCDescription(typeof(MoveFocusHotKeys), "Enter")]
		Enter
	}
}
