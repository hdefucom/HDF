using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       文档用户界面事件类型
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[ComVisible(true)]
	
	[Guid("A2D0E773-6E11-4B93-9583-0A20A2810E47")]
	
	public enum DocumentEventStyles
	{
		/// <summary>
		///       无效类型
		///       </summary>
		None,
		/// <summary>
		///       鼠标按键按下事件
		///       </summary>
		MouseDown,
		/// <summary>
		///       鼠标移动事件
		///       </summary>
		MouseMove,
		/// <summary>
		///       鼠标按键松开事件
		///       </summary>
		MouseUp,
		/// <summary>
		///       鼠标单击事件
		///       </summary>
		MouseClick,
		/// <summary>
		///       鼠标双击事件
		///       </summary>
		MouseDblClick,
		/// <summary>
		///       键盘按键按下事件
		///       </summary>
		KeyDown,
		/// <summary>
		///       键盘字符事件
		///       </summary>
		KeyPress,
		/// <summary>
		///       键盘按键松开事件
		///       </summary>
		KeyUp,
		/// <summary>
		///       失去输入焦点事件
		///       </summary>
		LostFocus,
		/// <summary>
		///       由于控件失去输入焦点而触发的文档元素失去输入焦点事件
		///       </summary>
		ControlLostFoucs,
		/// <summary>
		///       增强型的失去输入焦点事件
		///       </summary>
		LostFocusExt,
		/// <summary>
		///       获得输入焦点事件
		///       </summary>
		GotFocus,
		/// <summary>
		///       由于控件获得输入焦点而触发的文档元素获得输入焦点事件
		///       </summary>
		ControlGotFoucs,
		/// <summary>
		///       鼠标光标进入事件
		///       </summary>
		MouseEnter,
		/// <summary>
		///       鼠标光标离开事件
		///       </summary>
		MouseLeave,
		/// <summary>
		///       执行默认编辑方法
		///       </summary>
		DefaultEditMethod
	}
}
