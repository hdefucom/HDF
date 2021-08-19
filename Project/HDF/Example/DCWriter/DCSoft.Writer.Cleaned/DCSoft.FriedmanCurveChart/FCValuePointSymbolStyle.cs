using System.Runtime.InteropServices;

namespace DCSoft.FriedmanCurveChart
{
	/// <summary>
	///       点符号样式
	///       </summary>
	[Guid("9C1D03C9-A189-48CA-8D10-83100B5ED0D1")]
	[ComVisible(true)]
	public enum FCValuePointSymbolStyle
	{
		/// <summary>
		///       无图例
		///       </summary>
		None,
		/// <summary>
		///       默认样式
		///       </summary>
		Default,
		/// <summary>
		///       实心圆
		///       </summary>
		SolidCicle,
		/// <summary>
		///       空心圆
		///       </summary>
		HollowCicle,
		/// <summary>
		///       交叉线
		///       </summary>
		Cross,
		/// <summary>
		///       正方形
		///       </summary>
		Square,
		/// <summary>
		///       空心正方形
		///       </summary>
		HollowSquare,
		/// <summary>
		///       菱形
		///       </summary>
		Diamond,
		/// <summary>
		///       空心矩形
		///       </summary>
		HollowDiamond,
		/// <summary>
		///       V型
		///       </summary>
		V,
		/// <summary>
		///       倒过来的V型
		///       </summary>
		VReversed
	}
}
