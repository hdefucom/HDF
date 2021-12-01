using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       可见性状态
	///       </summary>
	[ComVisible(true)]
	[DocumentComment]
	[Guid("4FE933CA-282D-4D3B-9905-4104C73ED62D")]
	[DCPublishAPI]
	public enum DCVisibleState
	{
		/// <summary>
		///       可见
		///       </summary>
		Visible,
		/// <summary>
		///       隐藏的
		///       </summary>
		Hidden,
		/// <summary>
		///       默认
		///       </summary>
		Default,
		/// <summary>
		///       一直可见
		///       </summary>
		AlwaysVisible
	}
}
