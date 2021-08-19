using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.FriedmanCurveChart
{
	/// <summary>
	///       文档视图样式
	///       </summary>
	[Guid("0418FCB8-9528-4A34-B67F-9ED15B3A4878")]
	[DocumentComment]
	[ComVisible(true)]
	public enum FCDocumentViewMode
	{
		/// <summary>
		///       页面视图模式
		///       </summary>
		Page,
		/// <summary>
		///       普通视图模式
		///       </summary>
		Normal,
		/// <summary>
		///       产程图视图模式
		///       </summary>
		FriedmanCurve
	}
}
