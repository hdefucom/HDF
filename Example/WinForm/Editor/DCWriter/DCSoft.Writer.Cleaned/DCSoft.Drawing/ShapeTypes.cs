using DCSoft.Common;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.InteropServices;

namespace DCSoft.Drawing
{
	/// <summary>
	///       图形样式
	///       </summary>
	/// <remarks>
	///   <img src="images/ShapeTypes.png" />
	/// </remarks>
	[ComVisible(false)]
	[Editor("DCSoft.WinForms.Design.ShapeTypesEditor", typeof(UITypeEditor))]
	
	public enum ShapeTypes
	{
		/// <summary>
		///       矩形
		///       </summary>
		Rectangle,
		/// <summary>
		///       正方形
		///       </summary>
		Square,
		/// <summary>
		///       椭圆
		///       </summary>
		Ellipse,
		/// <summary>
		///       正圆
		///       </summary>
		Circle,
		/// <summary>
		///       菱形
		///       </summary>
		Diamond,
		/// <summary>
		///       向上的三角形
		///       </summary>
		TriangleUp,
		/// <summary>
		///       向右的三角形
		///       </summary>
		TriangleRight,
		/// <summary>
		///       向下的三角形
		///       </summary>
		TriangleDown,
		/// <summary>
		///       向左的三角形
		///       </summary>
		TriangleLeft,
		/// <summary>
		///       十字形
		///       </summary>
		Cross,
		/// <summary>
		///       X交叉形
		///       </summary>
		XCross,
		/// <summary>
		///       圆加上十字形
		///       </summary>
		CircleCross,
		/// <summary>
		///       圆加上X交叉形
		///       </summary>
		CircleXCross,
		/// <summary>
		///       默认状态
		///       </summary>
		Default,
		/// <summary>
		///       不显示任何图形
		///       </summary>
		None
	}
}
