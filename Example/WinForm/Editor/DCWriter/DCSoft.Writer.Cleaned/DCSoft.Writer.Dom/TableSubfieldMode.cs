using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       表格分栏模式
	///       </summary>
	
	[DocumentComment]
	[ComVisible(true)]
	[Guid("3B4D501C-EA0A-438B-88DD-5472BBD4DC82")]
	public enum TableSubfieldMode
	{
		/// <summary>
		///       不分栏
		///       </summary>
		None,
		/// <summary>
		///       从左到右，从上到下分栏
		///       </summary>
		LeftRightAndUpDown,
		/// <summary>
		///       从上到下，从左到右分栏
		///       </summary>
		UpDownAndLeftRight
	}
}
