using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       快速录入方式
	///       </summary>
	[ComVisible(true)]
	[Guid("40642D54-E0E5-4E08-96FC-199A9A3D20D4")]
	[DocumentComment]
	
	public enum DCFastInputMode
	{
		/// <summary>
		///       无设置
		///       </summary>
		None,
		/// <summary>
		///       输入域之前
		///       </summary>
		NextField,
		/// <summary>
		///       输入域前置边界符号之前。
		///       </summary>
		BeforeFieldBegin,
		/// <summary>
		///       输入域前置边界符号之后。
		///       </summary>
		AfterFieldBegin,
		/// <summary>
		///       输入域后置边界符号之前。
		///       </summary>
		BeforeFieldEnd,
		/// <summary>
		///       输入域后置边界符号之后。
		///       </summary>
		AfterFieldEnd
	}
}
