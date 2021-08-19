using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.TemperatureChart
{
	/// <summary>
	///       时间单位
	///       </summary>
	[DocumentComment]
	[ComVisible(false)]
	public enum DCTimeUnit
	{
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
		///       星期
		///       </summary>
		Week,
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
