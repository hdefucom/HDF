using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.InteropServices;

namespace DCSoft.Drawing
{
	/// <summary>
	///       背景图案样式
	///       </summary>
	[Editor("DCSoft.WinForms.Design.XBrushStyleConstEditor", typeof(UITypeEditor))]
	[ComVisible(false)]
	public enum XBrushStyleConst
	{
		/// <summary>
		///       对象被禁止
		///       </summary>
		Disabled = -2,
		/// <summary>
		///       背景不启用图案,使用纯色填充
		///       </summary>
		Solid = -1,
		/// <summary>
		///       水平线的图案。
		///       </summary>
		Horizontal = 0,
		/// <summary>垂直线的图案。</summary>
		Vertical = 1,
		/// <summary>从左上到右下的对角线的线条图案。</summary>
		ForwardDiagonal = 2,
		/// <summary>从右上到左下的对角线的线条图案。</summary>
		BackwardDiagonal = 3,
		/// <summary>指定交叉的水平线和垂直线。</summary>
		Cross = 4,
		/// <summary>交叉对角线的图案。</summary>
		DiagonalCross = 5,
		/// <summary>指定 5% 阴影。前景色与背景色的比例为 5:100。</summary>
		Percent05 = 6,
		/// <summary>指定 10% 阴影。前景色与背景色的比例为 10:100。</summary>
		Percent10 = 7,
		/// <summary>指定 20% 阴影。前景色与背景色的比例为 20:100。</summary>
		Percent20 = 8,
		/// <summary>指定 25% 阴影。前景色与背景色的比例为 25:100。</summary>
		Percent25 = 9,
		/// <summary>指定 30% 阴影。前景色与背景色的比例为 30:100。</summary>
		Percent30 = 10,
		/// <summary>指定 40% 阴影。前景色与背景色的比例为 40:100。</summary>
		Percent40 = 11,
		/// <summary>指定 50% 阴影。前景色与背景色的比例为 50:100。</summary>
		Percent50 = 12,
		/// <summary>指定 60% 阴影。前景色与背景色的比例为 60:100。</summary>
		Percent60 = 13,
		/// <summary>指定 70% 阴影。前景色与背景色的比例为 70:100。</summary>
		Percent70 = 14,
		/// <summary>指定 75% 阴影。前景色与背景色的比例为 75:100。</summary>
		Percent75 = 0xF,
		/// <summary>指定 80% 阴影。前景色与背景色的比例为 80:100。</summary>
		Percent80 = 0x10,
		/// <summary>指定 90% 阴影。前景色与背景色的比例为 90:100。</summary>
		Percent90 = 17,
		/// <summary>
		///       样式
		///       </summary>
		LightDownwardDiagonal = 18,
		/// <summary>指定从顶点到底点向左倾斜的对角线，其两边夹角比 System.Drawing.Drawing2D.HatchStyle.BackwardDiagonal
		///       小 50%，但这些直线不是锯齿消除的。</summary>
		LightUpwardDiagonal = 19,
		/// <summary>指定从顶点到底点向右倾斜的对角线，其两边夹角比 System.Drawing.Drawing2D.HatchStyle.ForwardDiagonal
		///       小 50%，宽度是其两倍。此阴影图案不是锯齿消除的。</summary>
		DarkDownwardDiagonal = 20,
		/// <summary>指定从顶点到底点向左倾斜的对角线，其两边夹角比 System.Drawing.Drawing2D.HatchStyle.BackwardDiagonal
		///       小 50%，宽度是其两倍，但这些直线不是锯齿消除的。</summary>
		DarkUpwardDiagonal = 21,
		/// <summary>指定从顶点到底点向右倾斜的对角线，其间距与阴影样式 System.Drawing.Drawing2D.HatchStyle.ForwardDiagonal
		///       相同，宽度是其三倍，但它们不是锯齿消除的。</summary>
		WideDownwardDiagonal = 22,
		/// <summary>指定从顶点到底点向左倾斜的对角线，其间距与阴影样式 System.Drawing.Drawing2D.HatchStyle.BackwardDiagonal
		///       相同，宽度是其三倍，但它们不是锯齿消除的。</summary>
		WideUpwardDiagonal = 23,
		/// <summary>指定垂直线的两边夹角比 System.Drawing.Drawing2D.HatchStyle.Vertical 小 50%。</summary>
		LightVertical = 24,
		/// <summary>指定水平线，其两边夹角比 System.Drawing.Drawing2D.HatchStyle.Horizontal 小 50%。</summary>
		LightHorizontal = 25,
		/// <summary>指定垂直线的两边夹角比阴影样式 System.Drawing.Drawing2D.HatchStyle.Vertical 小 75%（或者比 System.Drawing.Drawing2D.HatchStyle.LightVertical
		///       小 25%）。</summary>
		NarrowVertical = 26,
		/// <summary>指定水平线的两边夹角比阴影样式 System.Drawing.Drawing2D.HatchStyle.Horizontal 小 75%（或者比
		///       System.Drawing.Drawing2D.HatchStyle.LightHorizontal 小 25%）。</summary>
		NarrowHorizontal = 27,
		/// <summary>指定垂直线的两边夹角比 System.Drawing.Drawing2D.HatchStyle.Vertical 小 50% 并且宽度是其两倍。</summary>
		DarkVertical = 28,
		/// <summary>指定水平线的两边夹角比 System.Drawing.Drawing2D.HatchStyle.Horizontal 小 50% 并且宽度是 System.Drawing.Drawing2D.HatchStyle.Horizontal
		///       的两倍。</summary>
		DarkHorizontal = 29,
		/// <summary>指定虚线对角线，这些对角线从顶点到底点向右倾斜。</summary>
		DashedDownwardDiagonal = 30,
		/// <summary>指定虚线对角线，这些对角线从顶点到底点向左倾斜。</summary>
		DashedUpwardDiagonal = 0x1F,
		/// <summary>指定虚线水平线。</summary>
		DashedHorizontal = 0x20,
		/// <summary>指定虚线垂直线。</summary>
		DashedVertical = 33,
		/// <summary>指定带有五彩纸屑外观的阴影。</summary>
		SmallConfetti = 34,
		/// <summary>指定具有五彩纸屑外观的阴影，并且它是由比 System.Drawing.Drawing2D.HatchStyle.SmallConfetti 更大的片构成的。</summary>
		LargeConfetti = 35,
		/// <summary>指定由 Z 字形构成的水平线。</summary>
		ZigZag = 36,
		/// <summary>指定由代字号“~”构成的水平线。</summary>
		Wave = 37,
		/// <summary>指定具有分层砖块外观的阴影，它从顶点到底点向左倾斜。</summary>
		DiagonalBrick = 38,
		/// <summary>指定具有水平分层砖块外观的阴影。</summary>
		HorizontalBrick = 39,
		/// <summary>指定具有织物外观的阴影。</summary>
		Weave = 40,
		/// <summary>指定具有格子花呢材料外观的阴影。</summary>
		Plaid = 41,
		/// <summary>指定具有草皮层外观的阴影。</summary>
		Divot = 42,
		/// <summary>指定互相交叉的水平线和垂直线，每一直线都是由点构成的。</summary>
		DottedGrid = 43,
		/// <summary>指定互相交叉的正向对角线和反向对角线，每一对角线都是由点构成的。</summary>
		DottedDiamond = 44,
		/// <summary>指定带有对角分层鹅卵石外观的阴影，它从顶点到底点向右倾斜。</summary>
		Shingle = 45,
		/// <summary>指定具有格架外观的阴影。</summary>
		Trellis = 46,
		/// <summary>指定具有球体彼此相邻放置的外观的阴影。</summary>
		Sphere = 47,
		/// <summary>指定互相交叉的水平线和垂直线，其两边夹角比阴影样式 System.Drawing.Drawing2D.HatchStyle.Cross 小 50%。</summary>
		SmallGrid = 48,
		/// <summary>指定带有棋盘外观的阴影。</summary>
		SmallCheckerBoard = 49,
		/// <summary>指定具有棋盘外观的阴影，棋盘所具有的方格大小是 System.Drawing.Drawing2D.HatchStyle.SmallCheckerBoard
		///       大小的两倍。</summary>
		LargeCheckerBoard = 50,
		/// <summary>指定互相交叉的正向对角线和反向对角线，但这些对角线不是锯齿消除的。</summary>
		OutlinedDiamond = 51,
		/// <summary>指定具有对角放置的棋盘外观的阴影。</summary>
		SolidDiamond = 52,
		/// <summary>
		///       指定从右上到左下的渐变。  
		///       </summary>
		GradientBackwardDiagonal = 1003,
		/// <summary>
		///       指定从左上到右下的渐变。  
		///       </summary>
		GradientForwardDiagonal = 1002,
		/// <summary>
		///       指定从左到右的渐变。  
		///       </summary>
		GradientHorizontal = 1000,
		/// <summary>
		///       指定从上到下的渐变。 
		///       </summary>
		GradientVertical = 1001,
		/// <summary>
		///       使用背景图片1
		///       </summary>
		BackImage1 = 2001,
		/// <summary>
		///       使用背景图片2
		///       </summary>
		BackImage2 = 2002,
		/// <summary>
		///       使用背景图片3
		///       </summary>
		BackImage3 = 2003,
		/// <summary>
		///       使用背景图片4
		///       </summary>
		BackImage4 = 2004,
		/// <summary>
		///       使用背景图片5
		///       </summary>
		BackImage5 = 2005,
		/// <summary>
		///       使用背景图片6
		///       </summary>
		BackImage6 = 2006,
		/// <summary>
		///       使用背景图片7
		///       </summary>
		BackImage7 = 2007,
		/// <summary>
		///       使用背景图片8
		///       </summary>
		BackImage8 = 2008,
		/// <summary>
		///       使用背景图片9
		///       </summary>
		BackImage9 = 2009,
		/// <summary>
		///       使用背景图片10
		///       </summary>
		BackImage10 = 2010,
		/// <summary>
		///       使用背景图片11
		///       </summary>
		BackImage11 = 2011,
		/// <summary>
		///       使用背景图片12
		///       </summary>
		BackImage12 = 2012,
		/// <summary>
		///       使用背景图片13
		///       </summary>
		BackImage13 = 2013,
		Black = 2014,
		White = 2015
	}
}
