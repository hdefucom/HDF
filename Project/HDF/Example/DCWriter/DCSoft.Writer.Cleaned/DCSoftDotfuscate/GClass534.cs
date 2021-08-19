using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass534 : GClass533
	{
		private Graphics graphics_0 = null;

		public GClass534(Graphics graphics_1)
		{
			graphics_0 = graphics_1;
		}

		public Graphics method_0()
		{
			return graphics_0;
		}

		public void method_1(Graphics graphics_1)
		{
			graphics_0 = graphics_1;
		}

		public override void vmethod_0(Pen pen_0, RectangleF rectangleF_0)
		{
			graphics_0.DrawRectangle(pen_0, rectangleF_0.Left, rectangleF_0.Top, rectangleF_0.Width, rectangleF_0.Height);
		}

		public override void vmethod_1(Pen pen_0, GraphicsPath graphicsPath_0)
		{
			graphics_0.DrawPath(pen_0, graphicsPath_0);
		}

		public override void vmethod_2(Brush brush_0, RectangleF rectangleF_0)
		{
			graphics_0.FillRectangle(brush_0, rectangleF_0);
		}

		public override void vmethod_3(Brush brush_0, GraphicsPath graphicsPath_0)
		{
			graphics_0.FillPath(brush_0, graphicsPath_0);
		}

		public override void vmethod_5(Pen pen_0, float float_0, float float_1, float float_2, float float_3)
		{
			graphics_0.DrawLine(pen_0, float_0, float_1, float_2, float_3);
		}

		public override void vmethod_4(Pen pen_0, PointF pointF_0, PointF pointF_1)
		{
			graphics_0.DrawLine(pen_0, pointF_0, pointF_1);
		}

		public override void vmethod_6(Pen pen_0, PointF[] pointF_0)
		{
			graphics_0.DrawLines(pen_0, pointF_0);
		}

		public override void vmethod_7(string string_0, Font font_0, Brush brush_0, RectangleF rectangleF_0, StringFormat stringFormat_0)
		{
			graphics_0.DrawString(string_0, font_0, brush_0, rectangleF_0, stringFormat_0);
		}
	}
}
