using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       编辑器数据对象应用范围
	///       </summary>
	[ComVisible(true)]
	[DocumentComment]
	[Guid("7D4D97D1-BA82-4DBA-AE09-9EE704CCD603")]
	[DCPublishAPI]
	public enum WriterDataObjectRange
	{
		/// <summary>
		///       整个操作系统范围
		///       </summary>
		OS,
		/// <summary>
		///       一个应用程序中所有的编辑器控件
		///       </summary>
		Application,
		/// <summary>
		///       一个编辑器控件内部
		///       </summary>
		SingleWriterControl
	}
}
