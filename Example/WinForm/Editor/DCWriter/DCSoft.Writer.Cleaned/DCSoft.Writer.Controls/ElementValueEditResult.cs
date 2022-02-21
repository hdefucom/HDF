using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       元素值编辑操作结果
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	
	[ComVisible(true)]
	[Guid("B96813EE-888D-49A5-BEBA-7442AE58352B")]
	public enum ElementValueEditResult
	{
		/// <summary>
		///       没执行任何编辑操作.
		///       </summary>
		None,
		/// <summary>
		///       试图执行编辑器操作，但用户取消了。
		///       </summary>
		UserCancel,
		/// <summary>
		///       成功执行了编辑器操作.
		///       </summary>
		UserAccept,
		/// <summary>
		///       正在加载用户界面
		///       </summary>
		OpeingUI
	}
}
