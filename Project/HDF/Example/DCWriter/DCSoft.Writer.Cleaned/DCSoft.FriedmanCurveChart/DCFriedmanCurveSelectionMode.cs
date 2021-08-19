using System.Runtime.InteropServices;

namespace DCSoft.FriedmanCurveChart
{
	/// <summary>
	///       选择模式
	///       </summary>
	[ComVisible(false)]
	public enum DCFriedmanCurveSelectionMode
	{
		/// <summary>
		///       不选择
		///       </summary>
		None,
		/// <summary>
		///       单选模式
		///       </summary>
		SingleSelect,
		/// <summary>
		///       多选模式
		///       </summary>
		MultiSelec
	}
}
