using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       未勾选时复选框的显示模式
	///       </summary>
	[ComVisible(true)]
	[Guid("149FA571-DB38-45CC-840A-B82B633998A3")]
	[DCPublishAPI]
	public enum PrintVisibilityModeWhenUnchecked
	{
		/// <summary>
		///       正常显示
		///       </summary>
		Visible,
		/// <summary>
		///       不打印勾选框，但仍然打印文本
		///       </summary>
		HiddenCheckBoxOnly,
		/// <summary>
		///       不打印
		///       </summary>
		HiddenAll
	}
}
