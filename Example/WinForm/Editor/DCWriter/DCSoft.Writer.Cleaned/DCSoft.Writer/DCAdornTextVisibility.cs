using DCSoft.Common;
using DCSoft.Design;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       扩展文本显示方式
	///       </summary>
	
	[Guid("63AD161B-4BA6-4A39-952D-56BE7C0F0AA3")]
	[Editor(typeof(EnumEditorSupportDescription), typeof(UITypeEditor))]
	
	[ComVisible(true)]
	public enum DCAdornTextVisibility
	{
		/// <summary>
		///       隐藏
		///       </summary>
		Hidden,
		/// <summary>
		///       只显示光标所在元素的扩展文本
		///       </summary>
		Actived,
		/// <summary>
		///       显示所有的扩展文本
		///       </summary>
		Both
	}
}
