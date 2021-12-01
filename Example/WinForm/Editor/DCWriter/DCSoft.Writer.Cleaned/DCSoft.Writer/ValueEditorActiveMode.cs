using DCSoft.Common;
using DCSoft.Writer.Dom.Design;
using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       元素数值编辑器激活模式
	///       </summary>
	[DocumentComment]
	[Guid("00012345-6789-ABCD-EF01-234567890073")]
	[Editor(typeof(ValueEditorActiveModeEditor), typeof(UITypeEditor))]
	[ComVisible(true)]
	[DCPublishAPI]
	[Flags]
	public enum ValueEditorActiveMode
	{
		/// <summary>
		///       无效状态
		///       </summary>
		None = 0x0,
		/// <summary>
		///       采用默认模式
		///       </summary>
		Default = 0x1,
		/// <summary>
		///       编程激活
		///       </summary>
		Program = 0x2,
		/// <summary>
		///       按下F2激活
		///       </summary>
		F2 = 0x4,
		/// <summary>
		///       对象获得输入焦点就激活
		///       </summary>
		GotFocus = 0x8,
		/// <summary>
		///       鼠标双击时就激活
		///       </summary>
		MouseDblClick = 0x10,
		/// <summary>
		///       鼠标左击就激活
		///       </summary>
		MouseClick = 0x20,
		/// <summary>
		///       鼠标右击就激活，当控件设置了快捷菜单，则该选项无效。
		///       </summary>
		MouseRightClick = 0x40,
		/// <summary>
		///       Enter键激活。
		///       </summary>
		Enter = 0x80
	}
}
