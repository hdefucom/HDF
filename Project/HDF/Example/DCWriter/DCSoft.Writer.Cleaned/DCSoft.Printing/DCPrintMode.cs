using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Printing
{
	/// <summary>
	///       打印模式
	///       </summary>
	[ComVisible(true)]
	[DocumentComment]
	[Guid("AC92DAA8-D94E-4B4B-899F-37D1028FDB06")]
	public enum DCPrintMode
	{
		/// <summary>
		///       正常打印模式
		///       </summary>
		Normal,
		/// <summary>
		///       打印奇数页
		///       </summary>
		OddPage,
		/// <summary>
		///       打印偶数页
		///       </summary>
		EvenPage,
		/// <summary>
		///       手动双面打印
		///       </summary>
		ManualDuplex,
		/// <summary>
		///       打印当前页
		///       </summary>
		CurrentPage
	}
}
