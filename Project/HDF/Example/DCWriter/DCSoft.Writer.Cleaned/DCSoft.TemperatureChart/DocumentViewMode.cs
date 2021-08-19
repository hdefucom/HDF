using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.TemperatureChart
{
	/// <summary>
	///       文档视图样式
	///       </summary>
	[Guid("1B805085-38FF-44FC-8315-5AC3E76CFDA0")]
	[ComVisible(true)]
	[DocumentComment]
	public enum DocumentViewMode
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
		///       时间轴视图模式
		///       </summary>
		Timeline
	}
}
