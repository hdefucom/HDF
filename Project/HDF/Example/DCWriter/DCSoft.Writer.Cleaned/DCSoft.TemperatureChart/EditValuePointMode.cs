using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.TemperatureChart
{
	/// <summary>
	///       编辑数据点模式
	///       </summary>
	[ComVisible(true)]
	[Guid("7668A908-E63B-413B-850F-24DA3DAC9E4E")]
	[DocumentComment]
	public enum EditValuePointMode
	{
		/// <summary>
		///       新增数据点
		///       </summary>
		Insert,
		/// <summary>
		///       删除数据点
		///       </summary>
		Delete,
		/// <summary>
		///       修改数据点数值
		///       </summary>
		Update
	}
}
