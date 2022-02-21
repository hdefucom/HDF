using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       标准图标列表编号
	///       </summary>
	[Guid("48A5A9F8-F984-4EF1-9D22-2555CC28571C")]
	
	[DocumentComment]
	[ComVisible(true)]
	public enum DCStdImageKey
	{
		/// <summary>
		///       无效编号
		///       </summary>
		None,
		/// <summary>
		///       勾选状态的复选框,必须为16*16的BMP图片格式,透明色为红色。
		///       </summary>
		CheckBoxChecked,
		/// <summary>
		///       不是勾选状态的复选框,必须为16*16的BMP图片格式,透明色为红色。
		///       </summary>
		CheckBoxUnchecked,
		/// <summary>
		///       勾选状态的单选框,必须为16*16的BMP图片格式,透明色为红色。
		///       </summary>
		RadioBoxChecked,
		/// <summary>
		///       不是勾选状态的单选框,必须为16*16的BMP图片格式,透明色为红色。
		///       </summary>
		RadioBoxUnchecked,
		/// <summary>
		///       从左到右时的段落符号，必须为9*12的BMP图片格式,透明色为红色。
		///       </summary>
		ParagraphFlagLeftToRight,
		/// <summary>
		///       从右到左时的段落符号,必须为9*12的BMP图片格式,透明色为红色。
		///       </summary>
		ParagraphFlagRightToLeft,
		/// <summary>
		///       换行符号,必须为9*12的BMP图片格式,透明色为红色。
		///       </summary>
		Linebreak,
		/// <summary>
		///       拖拽内容使用的把柄,必须为13*13的BMP图片格式,透明色为红色。
		///       </summary>
		DragHandle,
		/// <summary>
		///       操作系统使用的勾选状态的复选框,该图标是只读的。
		///       </summary>
		SystemCheckBoxChecked,
		/// <summary>
		///       操作系统使用的不是勾选状态的复选框,该图标是只读的。
		///       </summary>
		SystemCheckBoxUnchecked,
		/// <summary>
		///       操作系统使用的勾选状态的单选框,该图标是只读的。
		///       </summary>
		SystemRadioBoxChecked,
		/// <summary>
		///       操作系统使用的不是勾选状态的单选框,该图标是只读的。
		///       </summary>
		SystemRadioBoxUnchecked,
		/// <summary>
		///       收缩
		///       </summary>
		Collapse,
		/// <summary>
		///       展开
		///       </summary>
		Expand
	}
}
