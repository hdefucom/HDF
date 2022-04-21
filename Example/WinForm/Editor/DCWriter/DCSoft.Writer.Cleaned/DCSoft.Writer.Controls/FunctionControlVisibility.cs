using DCSoft.Common;
using DCSoft.Design;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       功能性控件可见性设置
	///       </summary>
	[Guid("61D497C3-E076-4C7B-81B3-60E48FE2C1AE")]
	[ComVisible(true)]
	[Editor(typeof(EnumEditorSupportDescription), typeof(UITypeEditor))]
	
	
	public enum FunctionControlVisibility
	{
		/// <summary>
		///       自动设置可见性
		///       </summary>
		[DCDescription(typeof(FunctionControlVisibility), "Auto")]
		Auto,
		/// <summary>
		///       一直显示
		///       </summary>
		[DCDescription(typeof(FunctionControlVisibility), "Visible")]
		Visible,
		/// <summary>
		///       一直隐藏
		///       </summary>
		[DCDescription(typeof(FunctionControlVisibility), "Hide")]
		Hide
	}
}
