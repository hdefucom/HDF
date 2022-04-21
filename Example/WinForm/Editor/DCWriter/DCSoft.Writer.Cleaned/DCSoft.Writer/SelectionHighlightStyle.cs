using DCSoft.Common;
using DCSoft.Design;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       选择区域的高亮度显示方式
	///       </summary>
	[Editor(typeof(EnumEditorSupportDescription), typeof(UITypeEditor))]
	[ComVisible(true)]
	[Guid("B68E481B-5B1F-415A-B936-0A8F3C8D4828")]
	
	
	public enum SelectionHighlightStyle
	{
		/// <summary>
		///       无任何高亮度显示方式
		///       </summary>
		[DCDescription(typeof(SelectionHighlightStyle), "None")]
		None,
		/// <summary>
		///       反色高亮度显示
		///       </summary>
		[DCDescription(typeof(SelectionHighlightStyle), "Invert")]
		Invert,
		/// <summary>
		///       使用遮盖色高亮度显示
		///       </summary>
		[DCDescription(typeof(SelectionHighlightStyle), "MaskColor")]
		MaskColor
	}
}
