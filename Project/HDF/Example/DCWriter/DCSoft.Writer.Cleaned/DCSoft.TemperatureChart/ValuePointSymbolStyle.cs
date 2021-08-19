using System.Runtime.InteropServices;

namespace DCSoft.TemperatureChart
{
	/// <summary>
	///       点符号样式
	///       </summary>
	[ComVisible(true)]
	[Guid("27483E2C-E8F6-4717-A65D-72E48A4C895B")]
	public enum ValuePointSymbolStyle
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
		VReversed,
		/// <summary>
		///       字符类型
		///       </summary>
		Character,
		/// <summary>
		///       套圈字符类型
		///       </summary>
		CharacterCircle
	}
}
