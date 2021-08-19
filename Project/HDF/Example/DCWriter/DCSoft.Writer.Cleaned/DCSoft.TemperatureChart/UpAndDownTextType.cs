using System.Runtime.InteropServices;

namespace DCSoft.TemperatureChart
{
	/// <summary>
	///       上下交替文本样式
	///       </summary>
	[ComVisible(false)]
	public enum UpAndDownTextType
	{
		/// <summary>
		///       不交替
		///       </summary>
		None,
		/// <summary>
		///       根据时刻交替
		///       </summary>
		ShowByTick,
		/// <summary>
		///       根据文本交替
		///       </summary>
		ShowByText
	}
}
