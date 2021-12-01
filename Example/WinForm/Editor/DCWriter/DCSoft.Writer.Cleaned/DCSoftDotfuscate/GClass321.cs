using DCSoft.Drawing;
using DCSoft.ShapeEditor.Dom;
using DCSoft.WinForms.Native;
using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass321 : GClass320
	{
		private Point point_0 = Point.Empty;

		private Point point_1 = Point.Empty;

		protected GClass249 gclass249_0 = null;

		public GClass321()
		{
			method_7(typeof(ShapeRectangleElement));
			method_8().Align = DocumentContentAlignment.Center;
			method_8().VerticalAlign = VerticalAlignStyle.Middle;
			method_8().BorderColor = Color.Black;
			method_8().BorderWidth = 1f;
			method_8().BorderLeft = true;
			method_8().BorderTop = true;
			method_8().BorderRight = true;
			method_8().BorderBottom = true;
			method_8().Multiline = true;
		}

		public override GEnum75 vmethod_1(ShapeMouseEventArgs shapeMouseEventArgs_0)
		{
			point_0 = new Point(shapeMouseEventArgs_0.ClientX, shapeMouseEventArgs_0.ClientY);
			if (MouseCapturer.DragDetect(method_0().Handle))
			{
				point_1 = point_0;
				using (gclass249_0 = method_0().method_43())
				{
					MouseCapturer mouseCapturer = new MouseCapturer(method_0());
					mouseCapturer.Draw += method_14;
					mouseCapturer.Tag = shapeMouseEventArgs_0;
					if (mouseCapturer.method_2(bool_1: false))
					{
						Rectangle rectangle = RectangleCommon.GetRectangle(point_0, mouseCapturer.CurrentPosition);
						RectangleF bounds = method_0().method_21(rectangle);
						bounds.Location = method_0().method_28(bounds.Location, method_4());
						ShapeRectangleElement shapeRectangleElement = (ShapeRectangleElement)vmethod_7();
						shapeRectangleElement.Bounds = bounds;
						shapeMouseEventArgs_0.Handled = true;
						shapeRectangleElement.StyleIndex = method_2().ContentStyles.GetStyleIndex(method_8());
						method_11(shapeRectangleElement);
						return GEnum75.const_2;
					}
					shapeMouseEventArgs_0.Handled = true;
					return GEnum75.const_3;
				}
			}
			shapeMouseEventArgs_0.Handled = true;
			return GEnum75.const_3;
		}

		private void method_14(object sender, CaptureMouseMoveEventArgs e)
		{
			Rectangle rectangle = RectangleCommon.GetRectangle(point_0, e.method_5());
			if (method_6().Equals(typeof(ShapeEllipseElement)) || method_6().IsSubclassOf(typeof(ShapeEllipseElement)))
			{
				gclass249_0.method_16(rectangle);
			}
			else
			{
				gclass249_0.DrawRectangle(rectangle);
			}
		}

		public override ShapeElement vmethod_7()
		{
			ShapeElement shapeElement = (ShapeElement)Activator.CreateInstance(method_6());
			shapeElement.Parent = method_4();
			shapeElement.OwnerDocument = method_2();
			RectangleF bounds = new RectangleF(Math.Min(point_0.X, point_1.X), Math.Min(point_0.Y, point_1.Y), Math.Abs(point_0.X - point_1.X), Math.Abs(point_0.Y - point_1.Y));
			PointF absLocation = method_4().AbsLocation;
			bounds.Offset(0f - absLocation.X, 0f - absLocation.Y);
			shapeElement.Bounds = bounds;
			return shapeElement;
		}
	}
}
