using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.TemperatureChart
{
	/// <summary>
	///       标题行数据类型
	///       </summary>
	[ComVisible(false)]
	public enum TitleLineValueType
	{
		/// <summary>
		///        新增日期显示方式 住院日期首页第一天及跨年度第一天需写年、月、日，每页体温单的第一天及跨月份第一天需写月、日，其余只填日--宋建明
		///       </summary>
		NewSerialDate,
		/// <summary>
		///       一系列的日期数
		///       </summary>
		SerialDate,
		/// <summary>
		///       全局的天数
		///       </summary>
		GlobalDayIndex,
		/// <summary>
		///       不推荐使用，仅保留向下兼容性全局，请改用GlobalDayIndex
		///       </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		InDayIndex,
		/// <summary>
		///       天数
		///       </summary>
		DayIndex,
		/// <summary>
		///       小时刻数
		///       </summary>
		HourTick,
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
