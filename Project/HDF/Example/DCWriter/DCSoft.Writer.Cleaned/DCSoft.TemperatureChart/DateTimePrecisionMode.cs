using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.TemperatureChart
{
	/// <summary>
	///       日期时间精确度
	///       </summary>
	[ComVisible(false)]
	[DocumentComment]
	public enum DateTimePrecisionMode
	{
		/// <summary>
		///       无限制
		///       </summary>
		NoLimited,
		/// <summary>
		///       秒
		///       </summary>
		Second,
		/// <summary>
		///       分钟
		///       </summary>
		Minute,
		/// <summary>
		///       小时
		///       </summary>
		Hour,
		/// <summary>
		///       天
		///       </summary>
		Day,
		/// <summary>
		///       月
		///       </summary>
		Month,
		/// <summary>
		///       年
		///       </summary>
		Year
	}
}
