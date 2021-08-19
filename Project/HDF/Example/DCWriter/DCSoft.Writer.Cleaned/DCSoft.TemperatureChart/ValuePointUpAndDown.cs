using System.Runtime.InteropServices;

namespace DCSoft.TemperatureChart
{
	/// <summary>
	///       数据点垂直对齐方式
	///       </summary>
	[ComVisible(true)]
	[Guid("9BFBDC7A-D887-4E5F-8B91-716921DE5621")]
	public enum ValuePointUpAndDown
	{
		/// <summary>
		///       居中
		///       </summary>
		None,
		/// <summary>
		///       上
		///       </summary>
		Up,
		/// <summary>
		///       下
		///       </summary>
		Down
	}
}
