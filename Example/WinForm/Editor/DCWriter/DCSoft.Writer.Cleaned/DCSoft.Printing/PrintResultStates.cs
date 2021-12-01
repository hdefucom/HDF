using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Printing
{
	/// <summary>
	///       打印结果状态
	///       </summary>
	[DCPublishAPI]
	[Guid("0C5AB15E-88BC-41A4-9FD5-534351F0A04C")]
	[ComVisible(true)]
	[DocumentComment]
	public enum PrintResultStates
	{
		/// <summary>
		///       无效状态
		///       </summary>
		None,
		/// <summary>
		///       部分打印成功
		///       </summary>
		PartialPrinted,
		/// <summary>
		///       完全打印成功
		///       </summary>
		CompletePrinted,
		/// <summary>
		///       打印错误
		///       </summary>
		Error,
		/// <summary>
		///       用户取消
		///       </summary>
		UserCancel
	}
}
