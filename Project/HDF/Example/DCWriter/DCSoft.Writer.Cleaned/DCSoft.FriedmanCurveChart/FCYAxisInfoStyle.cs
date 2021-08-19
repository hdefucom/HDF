using System.Runtime.InteropServices;

namespace DCSoft.FriedmanCurveChart
{
	/// <summary>
	///       Y坐标轴样式
	///       </summary>
	[Guid("82A689D2-2763-47D6-8CEB-E8A1F11F1C0D")]
	[ComVisible(true)]
	public enum FCYAxisInfoStyle
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
