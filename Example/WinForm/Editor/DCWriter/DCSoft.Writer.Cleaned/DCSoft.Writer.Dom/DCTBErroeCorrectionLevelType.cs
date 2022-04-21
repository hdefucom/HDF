using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       QR二维码纠错能力标准
	///       </summary>
	
	[ComVisible(true)]
	[Guid("7028C974-157A-4A79-81FA-CF7424A2D032")]
	public enum DCTBErroeCorrectionLevelType
	{
		L,
		M,
		Q,
		H
	}
}
