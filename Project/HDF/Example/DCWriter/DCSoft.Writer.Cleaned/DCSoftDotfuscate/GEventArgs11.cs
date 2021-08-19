using DCSoft.ShapeEditor.Dom;
using DCSoft.WinForms.Native;
using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GEventArgs11 : EventArgs
	{
		private GEnum76 genum76_0 = GEnum76.const_1;

		private ShapeElement shapeElement_0 = null;

		private GClass329 gclass329_0 = null;

		private GControl9 gcontrol9_0 = null;

		private PointF pointF_0 = PointF.Empty;

		private Point point_0 = Point.Empty;

		private MouseCapturer mouseCapturer_0 = null;

		private GClass249 gclass249_0 = null;

		public GEnum76 method_0()
		{
			return genum76_0;
		}

		public void method_1(GEnum76 genum76_1)
		{
			genum76_0 = genum76_1;
		}

		public ShapeElement method_2()
		{
			return shapeElement_0;
		}

		public void method_3(ShapeElement shapeElement_1)
		{
			shapeElement_0 = shapeElement_1;
		}

		public GClass329 method_4()
		{
			return gclass329_0;
		}

		public void method_5(GClass329 gclass329_1)
		{
			gclass329_0 = gclass329_1;
		}

		public GControl9 method_6()
		{
			return gcontrol9_0;
		}

		public void method_7(GControl9 gcontrol9_1)
		{
			gcontrol9_0 = gcontrol9_1;
		}

		public PointF method_8()
		{
			return pointF_0;
		}

		public void method_9(PointF pointF_1)
		{
			pointF_0 = pointF_1;
		}

		public Point method_10()
		{
			return point_0;
		}

		public void method_11(Point point_1)
		{
			point_0 = point_1;
		}

		public MouseCapturer method_12()
		{
			return mouseCapturer_0;
		}

		public void method_13(MouseCapturer mouseCapturer_1)
		{
			mouseCapturer_0 = mouseCapturer_1;
		}

		public GClass249 method_14()
		{
			return gclass249_0;
		}

		public void method_15(GClass249 gclass249_1)
		{
			gclass249_0 = gclass249_1;
		}
	}
}
