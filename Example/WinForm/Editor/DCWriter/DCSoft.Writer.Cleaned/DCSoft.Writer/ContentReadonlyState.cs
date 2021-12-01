using DCSoft.Common;
using DCSoft.Design;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       内容只读状态
	///       </summary>
	[DCPublishAPI]
	[DocumentComment]
	[Editor(typeof(EnumEditorSupportDescription), typeof(UITypeEditor))]
	[ComVisible(true)]
	[Guid("D26AA5C4-47D8-426F-A228-9F6CEB1A46B9")]
	public enum ContentReadonlyState
	{
		/// <summary>
		///       只读
		///       </summary>
		[DCDescription(typeof(ContentReadonlyState), "True")]
		True,
		/// <summary>
		///       不只读
		///       </summary>
		[DCDescription(typeof(ContentReadonlyState), "False")]
		False,
		/// <summary>
		///       继承父节点
		///       </summary>
		[DCDescription(typeof(ContentReadonlyState), "Inherit")]
		Inherit
	}
}
