using System.Runtime.InteropServices;

namespace DCSoft.FriedmanCurveChart
{
	/// <summary>
	///       数据点垂直对齐方式
	///       </summary>
	[Guid("07A16E11-E830-42DD-8A7B-79D7C66E5818")]
	[ComVisible(true)]
	public enum FCValuePointUpAndDown
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
