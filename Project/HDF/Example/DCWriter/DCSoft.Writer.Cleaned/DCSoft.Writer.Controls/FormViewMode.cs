using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       表单视图模式类型
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[Guid("D6138851-E2C4-4699-9EAD-D78CCA626573")]
	[DocumentComment]
	[DCPublishAPI]
	[ComVisible(true)]
	public enum FormViewMode
	{
		/// <summary>
		///       不处于表单视图模式
		///       </summary>
		Disable,
		/// <summary>
		///       普通表单视图模式
		///       </summary>
		Normal,
		/// <summary>
		///       严格的表单视图模式
		///       </summary>
		Strict
	}
}
