using System.Runtime.InteropServices;

namespace DCSoft.FriedmanCurveChart
{
	/// <summary>
	///       标题行数据类型
	///       </summary>
	[ComVisible(false)]
	public enum FCTitleLineValueType
	{
		HourTick,
		/// <summary>
		///       新增，按最初时刻自动生成持续时间的小时刻数
		///       </summary>********************************************************
		DurationTick,
		/// <summary>
		///       文本
		///       </summary>
		Text,
		/// <summary>
		///       数据
		///       </summary>
		Data,
		/// <summary>
		///       精确到刻度的文本
		///       </summary>
		TickText
	}
}
