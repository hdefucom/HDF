using DCSoft.Common;
using DCSoft.Design;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       文档数据校验模式
	///       </summary>
	
	[Guid("DB64F685-B510-44C6-AFCB-3602E20F399A")]
	[ComVisible(true)]
	[Editor(typeof(EnumEditorSupportDescription), typeof(UITypeEditor))]
	
	public enum DocumentValueValidateMode
	{
		/// <summary>
		///       禁止数据校验
		///       </summary>
		[DCDescription(typeof(DocumentValueValidateMode), "None")]
		None,
		/// <summary>
		///       实时的数据校验
		///       </summary>
		[DCDescription(typeof(DocumentValueValidateMode), "Dynamic")]
		Dynamic,
		/// <summary>
		///       当文本输入域失去输入焦点，也就是说光标离开输入域时才进行数据校验。
		///       </summary>
		[DCDescription(typeof(DocumentValueValidateMode), "LostFocus")]
		LostFocus,
		/// <summary>
		///       编辑器不自动进行数据校验，由应用程序编程调用来进行数据校验。
		///       </summary>
		[DCDescription(typeof(DocumentValueValidateMode), "Program")]
		Program
	}
}
