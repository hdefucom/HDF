using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.Drawing
{
	/// <summary>
	///       图示样式信息
	///       </summary>
	[Serializable]
	[ComVisible(false)]
	[TypeConverter(typeof(GClass536))]
	public class ShapeSymbleStyle
	{
		private Color intBorderColor = Color.Black;

		private Color intBackColor = Color.White;

		private int intSize = 50;

		private ShapeTypes intStyle = ShapeTypes.Rectangle;

		/// <summary>
		///       边框色
		///       </summary>
		[DefaultValue(typeof(Color), "Black")]
		public Color BorderColor
		{
			get
			{
				return intBorderColor;
			}
			set
			{
				intBorderColor = value;
			}
		}

		/// <summary>
		///       背景色
		///       </summary>
		[DefaultValue(typeof(Color), "White")]
		public Color BackColor
		{
			get
			{
				return intBackColor;
			}
			set
			{
				intBackColor = value;
			}
		}

		/// <summary>
		///       图示大小
		///       </summary>
		[DefaultValue(50)]
		public int Size
		{
			get
			{
				return intSize;
			}
			set
			{
				intSize = value;
			}
		}

		/// <summary>
		///       图示样式
		///       </summary>
		[DefaultValue(ShapeTypes.Rectangle)]
		public ShapeTypes Style
		{
			get
			{
				return intStyle;
			}
			set
			{
				intStyle = value;
			}
		}

		/// <summary>
		///       绘制图形
		///       </summary>
		/// <param name="g">画布对象</param>
		/// <param name="x">X坐标</param>
		/// <param name="y">Y坐标</param>
		public void Draw(Graphics graphics_0, float float_0, float float_1)
		{
			using (SolidBrush fillBrush = new SolidBrush(intBackColor))
			{
				using (Pen borderPen = new Pen(intBorderColor))
				{
					ShapeDrawer shapeDrawer = new ShapeDrawer();
					shapeDrawer.Bounds = new RectangleF(float_0 - (float)(intSize / 2), float_1 - (float)(intSize / 2), intSize, intSize);
					shapeDrawer.BorderPen = borderPen;
					shapeDrawer.FillBrush = fillBrush;
					shapeDrawer.DrawAndFill(graphics_0);
				}
			}
		}
	}
}
