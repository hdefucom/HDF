using DCSoft.Common;
using DCSoft.Design;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       布尔状态值
	///       </summary>
	[ComVisible(true)]
	[DocumentComment]
	[Editor(typeof(EnumEditorSupportDescription), typeof(UITypeEditor))]
	[Guid("4B7880E2-FAE1-46B7-860A-9AFD6F62BE24")]
	[DCPublishAPI]
	public enum DCBooleanValue
	{
		/// <summary>
		///       只读
		///       </summary>
		[DCDescription(typeof(DCBooleanValue), "True")]
		True,
		/// <summary>
		///       不只读
		///       </summary>
		[DCDescription(typeof(DCBooleanValue), "False")]
		False,
		/// <summary>
		///       继承父节点
		///       </summary>
		[DCDescription(typeof(DCBooleanValue), "Inherit")]
		Inherit
	}
}
