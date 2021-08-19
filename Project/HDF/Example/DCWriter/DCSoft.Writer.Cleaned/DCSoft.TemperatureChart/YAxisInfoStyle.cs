using System.Runtime.InteropServices;

namespace DCSoft.TemperatureChart
{
	/// <summary>
	///       Y坐标轴样式
	///       </summary>
	[ComVisible(true)]
	[Guid("56457014-298A-4D60-A54A-DCB482B65351")]
	public enum YAxisInfoStyle
	{
		/// <summary>
		///       数值
		///       </summary>
		Value,
		/// <summary>
		///       文本
		///       </summary>
		Text,
		/// <summary>
		///       完整的背景
		///       </summary>
		Background,
		/// <summary>
		///       部分背景
		///       </summary>
		PartialBackground
	}
}
