using DCSoft.Drawing;
using DCSoftDotfuscate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Serialization;

namespace DCSoft.ShapeEditor.Dom
{
	/// <summary>
	///       多边形对象
	///       </summary>
	[Serializable]
	[ComVisible(false)]
	public class ShapePolygonElement : ShapeRectangleElement
	{
		private PointF[] pointF_0 = null;

		[XmlIgnore]
		[Browsable(false)]
		public PointF[] Points
		{
			get
			{
				return pointF_0;
			}
			set
			{
				pointF_0 = value;
			}
		}

		[XmlElement("Points")]
		[Browsable(false)]
		public string PointsString
		{
			get
			{
				int num = 3;
				if (pointF_0 == null || pointF_0.Length == 0)
				{
					return null;
				}
				StringBuilder stringBuilder = new StringBuilder();
				for (int i = 0; i < Points.Length; i++)
				{
					if (stringBuilder.Length > 0)
					{
						stringBuilder.Append(",");
					}
					stringBuilder.Append(Points[i].X.ToString());
					stringBuilder.Append(",");
					stringBuilder.Append(Points[i].Y.ToString());
				}
				return stringBuilder.ToString();
			}
			set
			{
				Points = null;
				if (string.IsNullOrEmpty(value))
				{
					return;
				}
				string[] array = value.Split(',');
				List<PointF> list = new List<PointF>();
				for (int i = 0; i < array.Length; i += 2)
				{
					float result = 0f;
					if (!float.TryParse(array[i], out result))
					{
						result = float.NaN;
					}
					float result2 = 0f;
					if (!float.TryParse(array[i + 1], out result2))
					{
						result2 = float.NaN;
					}
					list.Add(new PointF(result, result2));
				}
				Points = list.ToArray();
			}
		}

		public override void vmethod_1(GClass328 gclass328_0)
		{
			if (Points == null || Points.Length <= 1)
			{
				gclass328_0.method_9(GEnum73.const_0);
				return;
			}
			GraphicsPath graphicsPath = vmethod_5();
			if (graphicsPath.IsVisible(gclass328_0.method_4(), gclass328_0.method_6()))
			{
				gclass328_0.method_9(GEnum73.const_2);
			}
		}

		public override GraphicsPath vmethod_5()
		{
			if (Points == null || Points.Length == 0)
			{
				return base.vmethod_5();
			}
			RectangleF pointsBounds = RectangleCommon.GetPointsBounds(Points);
			List<PointF> list = new List<PointF>();
			for (int i = 0; i < Points.Length; i++)
			{
				float x = Points[i].X;
				float y = Points[i].Y;
				x = base.Width * (x - pointsBounds.X) / pointsBounds.Width;
				y = base.Height * (y - pointsBounds.Y) / pointsBounds.Height;
				list.Add(new PointF(x, y));
			}
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddPolygon(list.ToArray());
			graphicsPath.CloseFigure();
			return graphicsPath;
		}
	}
}
