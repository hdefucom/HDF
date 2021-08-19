using DCSoft.Drawing;
using DCSoft.ShapeEditor.Dom;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass327 : GClass320
	{
		private List<Point> list_0 = new List<Point>();

		private Point point_0 = Point.Empty;

		public GClass327()
		{
			method_7(typeof(ShapePolygonElement));
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

		public override void vmethod_0()
		{
			base.vmethod_0();
			list_0.Clear();
			point_0 = Point.Empty;
		}

		public override GEnum75 vmethod_4(KeyEventArgs keyEventArgs_0)
		{
			if (keyEventArgs_0.KeyCode == Keys.Escape)
			{
				return GEnum75.const_3;
			}
			if (keyEventArgs_0.KeyCode == Keys.Return)
			{
				return method_14();
			}
			return GEnum75.const_1;
		}

		public override GEnum75 vmethod_1(ShapeMouseEventArgs shapeMouseEventArgs_0)
		{
			if (shapeMouseEventArgs_0.Button == MouseButtons.Right)
			{
				GEnum75 gEnum = method_14();
				if (gEnum != GEnum75.const_3)
				{
				}
				return gEnum;
			}
			method_13(bool_1: true);
			Point autoScrollPosition = method_0().AutoScrollPosition;
			list_0.Add(new Point(shapeMouseEventArgs_0.ClientX - autoScrollPosition.X, shapeMouseEventArgs_0.ClientY - autoScrollPosition.Y));
			return GEnum75.const_1;
		}

		public override GEnum75 vmethod_2(ShapeMouseEventArgs shapeMouseEventArgs_0)
		{
			if (list_0.Count == 0)
			{
				return GEnum75.const_1;
			}
			Point autoScrollPosition = method_0().AutoScrollPosition;
			if (list_0.Count > 1)
			{
				using (Graphics graphics = method_0().CreateGraphics())
				{
					graphics.TranslateTransform(autoScrollPosition.X, autoScrollPosition.Y);
					Color color = Color.Black;
					if (method_0().method_33() != null)
					{
						color = method_0().method_33().BorderColor;
					}
					else if (method_0().method_7() != null)
					{
						color = method_0().method_7().BorderColor;
					}
					using (Pen pen = new Pen(color))
					{
						graphics.DrawLines(pen, list_0.ToArray());
					}
				}
			}
			Point point = list_0[list_0.Count - 1];
			Point point2 = new Point(shapeMouseEventArgs_0.ClientX - autoScrollPosition.X, shapeMouseEventArgs_0.ClientY - autoScrollPosition.Y);
			using (GClass249 gClass = method_0().method_43())
			{
				if (!point_0.IsEmpty)
				{
					gClass.method_11(point_0.X + autoScrollPosition.X, point_0.Y + autoScrollPosition.Y, point.X + autoScrollPosition.X, point.Y + autoScrollPosition.Y);
				}
				gClass.method_11(point2.X + autoScrollPosition.X, point2.Y + autoScrollPosition.Y, point.X + autoScrollPosition.X, point.Y + autoScrollPosition.Y);
				point_0 = point2;
			}
			return GEnum75.const_1;
		}

		private GEnum75 method_14()
		{
			method_13(bool_1: false);
			if (list_0 == null || list_0.Count <= 2)
			{
				return GEnum75.const_3;
			}
			ShapePolygonElement shapePolygonElement = (ShapePolygonElement)vmethod_7();
			shapePolygonElement.Parent = method_4();
			shapePolygonElement.OwnerDocument = method_2();
			PointF[] array = new PointF[list_0.Count];
			Point autoScrollPosition = method_0().AutoScrollPosition;
			for (int i = 0; i < list_0.Count; i++)
			{
				Point point = list_0[i];
				point.Offset(autoScrollPosition.X, autoScrollPosition.Y);
				PointF pointF_ = method_0().method_23(point);
				pointF_ = method_0().method_28(pointF_, method_4());
				array[i] = pointF_;
			}
			shapePolygonElement.Points = array;
			shapePolygonElement.Bounds = RectangleCommon.GetPointsBounds(array);
			method_11(shapePolygonElement);
			return GEnum75.const_2;
		}

		public override ShapeElement vmethod_7()
		{
			ShapePolygonElement shapePolygonElement = (ShapePolygonElement)Activator.CreateInstance(method_6());
			shapePolygonElement.Parent = method_4();
			shapePolygonElement.OwnerDocument = method_2();
			_ = new PointF[list_0.Count];
			Point autoScrollPosition = method_0().AutoScrollPosition;
			for (int i = 0; i < list_0.Count; i++)
			{
				list_0[i].Offset(autoScrollPosition.X, autoScrollPosition.Y);
			}
			return shapePolygonElement;
		}
	}
}
