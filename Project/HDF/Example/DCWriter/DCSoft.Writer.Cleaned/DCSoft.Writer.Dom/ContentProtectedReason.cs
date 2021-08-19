using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       内容保护的理由
	///       </summary>
	[ComVisible(false)]
	public enum ContentProtectedReason
	{
		/// <summary>
		///       无理由
		///       </summary>
		None,
		/// <summary>
		///       不能被重复逻辑删除
		///       </summary>
		LogicDeleteAgain,
		ControlReadonly,
		FormViewMode,
		Lock,
		Permission,
		ContentProtectStyle,
		UserEvent,
		ContainerReadonly,
		UnDeleteable
	}
}
