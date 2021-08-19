using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       授权信息显示模式
	///       </summary>
	[DocumentComment]
	[DCPublishAPI]
	[ComVisible(true)]
	[Guid("AB1ED97F-B476-49DF-AF30-937F344E05CD")]
	public enum DCLicenceDisplayMode
	{
		/// <summary>
		///       在页眉中显示
		///       </summary>
		PageHeader,
		/// <summary>
		///       在控件的抬头中显示
		///       </summary>
		ControlHeader,
		/// <summary>
		///       在程序等待操作界面中显示
		///       </summary>
		ProgressUI
	}
}
