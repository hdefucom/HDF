using DCSoft.ShapeEditor;
using DCSoft.ShapeEditor.Dom;
using DCSoft.WinForms.Native;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass324 : GClass320
	{
		private Point point_0 = Point.Empty;

		private Point point_1 = Point.Empty;

		protected GClass249 gclass249_0 = null;

		public GClass324()
		{
			method_7(typeof(ShapeWireLabelElement));
			method_8().BorderColor = Color.Black;
			method_8().BorderWidth = 4f;
			method_8().BorderStyle = DashStyle.Solid;
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
						ShapeWireLabelElement shapeWireLabelElement = (ShapeWireLabelElement)vmethod_7();
						PointF pointF_ = method_0().method_23(point_0);
						pointF_ = method_0().method_28(pointF_, method_4());
						shapeWireLabelElement.X1 = pointF_.X;
						shapeWireLabelElement.Y1 = pointF_.Y;
						pointF_ = method_0().method_23(mouseCapturer.CurrentPosition);
						pointF_ = method_0().method_28(pointF_, method_4());
						shapeWireLabelElement.X2 = pointF_.X;
						shapeWireLabelElement.Y2 = pointF_.Y;
						shapeWireLabelElement.Text = ResourceStrings.NewLabelText;
						shapeWireLabelElement.LabelAtLeft = (shapeWireLabelElement.X1 > shapeWireLabelElement.X2);
						shapeWireLabelElement.LabelAtUp = (shapeWireLabelElement.Y1 < shapeWireLabelElement.Y2);
						shapeMouseEventArgs_0.Handled = true;
						method_11(shapeWireLabelElement);
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
			gclass249_0.method_13(point_0, e.method_5());
		}

		public override ShapeElement vmethod_7()
		{
			ShapeElement shapeElement = (ShapeElement)Activator.CreateInstance(method_6());
			shapeElement.Parent = method_4();
			shapeElement.OwnerDocument = method_2();
			shapeElement.StyleIndex = method_0().method_35();
			return shapeElement;
		}
	}
}
