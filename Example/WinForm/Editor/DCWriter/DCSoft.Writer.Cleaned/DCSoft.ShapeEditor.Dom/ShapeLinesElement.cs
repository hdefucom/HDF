using DCSoft.Drawing;
using DCSoftDotfuscate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DCSoft.ShapeEditor.Dom
{
	/// <summary>
	///       多边形对象
	///       </summary>
	[Serializable]
	[ComVisible(false)]
	public class ShapeLinesElement : ShapeElement
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
				int num = 16;
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

		/// <summary>
		///       获得或设置对象的边界
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		public override RectangleF Bounds
		{
			get
			{
				return RectangleCommon.GetPointsBounds(Points);
			}
			set
			{
			}
		}

		/// <summary>
		///       最小X坐标值
		///       </summary>
		[Browsable(false)]
		public float MinX
		{
			get
			{
				float num = 0f;
				for (int i = 0; i < Points.Length; i++)
				{
					num = ((i != 0) ? Math.Min(Points[i].X, num) : Points[i].X);
				}
				return num;
			}
		}

		/// <summary>
		///       最小Y坐标值
		///       </summary>
		[Browsable(false)]
		public float MinY
		{
			get
			{
				float num = 0f;
				for (int i = 0; i < Points.Length; i++)
				{
					num = ((i != 0) ? Math.Min(Points[i].Y, num) : Points[i].Y);
				}
				return num;
			}
		}

		[Browsable(false)]
		public override GClass330 vmethod_4()
		{
			if (Points == null || Points.Length <= 1)
			{
				return null;
			}
			GClass330 gClass = new GClass330();
			RectangleF pointsBounds = RectangleCommon.GetPointsBounds(Points);
			for (int i = 0; i < Points.Length; i++)
			{
				GClass329 gClass2 = new GClass329(Points[i].X - pointsBounds.X, Points[i].Y - pointsBounds.Y, Cursors.Cross);
				gClass2.method_13(i);
				gClass.Add(gClass2);
			}
			return gClass;
		}

		public override void vmethod_0(float float_0, float float_1)
		{
			for (int i = 0; i < Points.Length; i++)
			{
				Points[i].X *= float_0;
				Points[i].Y *= float_1;
			}
		}

		public override void vmethod_6(ShapeRenderEventArgs shapeRenderEventArgs_0)
		{
			if (Points != null && Points.Length > 1)
			{
				PointF absLocation = AbsLocation;
				float num = absLocation.X - MinX;
				float num2 = absLocation.Y - MinY;
				PointF[] array = new PointF[Points.Length];
				for (int i = 0; i < array.Length; i++)
				{
					array[i].X = Points[i].X + num;
					array[i].Y = Points[i].Y + num2;
				}
				shapeRenderEventArgs_0.Graphics.DrawLines(RuntimeStyle.BorderColor, RuntimeStyle.BorderWidth, RuntimeStyle.BorderStyle, array);
			}
		}

		public override void vmethod_1(GClass328 gclass328_0)
		{
			float minX = MinX;
			float minY = MinY;
			int num = 1;
			while (true)
			{
				if (num < Points.Length)
				{
					double num2 = MathCommon.smethod_20(Points[num - 1].X - minX, Points[num - 1].Y - minY, Points[num].X - minX, Points[num].Y - minY, gclass328_0.method_4(), gclass328_0.method_6(), bool_0: true);
					if (num2 <= (double)OwnerDocument.Options.ViewOptions.RuntimeControlPointSize)
					{
						break;
					}
					num++;
					continue;
				}
				return;
			}
			gclass328_0.method_9(GEnum73.const_2);
		}

		public override void vmethod_2(GEventArgs11 geventArgs11_0)
		{
			if (geventArgs11_0.method_0() == GEnum76.const_1 || geventArgs11_0.method_0() == GEnum76.const_2)
			{
				geventArgs11_0.method_12().Tag = geventArgs11_0;
				geventArgs11_0.method_12().Draw += method_0;
				if (!geventArgs11_0.method_12().CaptureMouseMove(bool_1: false))
				{
					return;
				}
				if (geventArgs11_0.method_0() == GEnum76.const_1)
				{
					PointF pointF = geventArgs11_0.method_6().method_23(geventArgs11_0.method_12().CurrentPosition);
					RectangleF clientRectangle = Parent.ClientRectangle;
					clientRectangle.Offset(Parent.AbsLocation);
					pointF.X -= clientRectangle.X;
					pointF.Y -= clientRectangle.Y;
					vmethod_15();
					Points[geventArgs11_0.method_4().method_12()].X = pointF.X;
					Points[geventArgs11_0.method_4().method_12()].Y = pointF.Y;
					vmethod_15();
				}
				else if (geventArgs11_0.method_0() == GEnum76.const_2)
				{
					SizeF sizeF = geventArgs11_0.method_6().method_25(geventArgs11_0.method_12().CurrentMoveSize);
					vmethod_15();
					for (int i = 0; i < Points.Length; i++)
					{
						Points[i].X += sizeF.Width;
						Points[i].Y += sizeF.Height;
					}
					vmethod_15();
				}
			}
			else
			{
				base.vmethod_2(geventArgs11_0);
			}
		}

		private void method_0(object sender, CaptureMouseMoveEventArgs e)
		{
			GEventArgs11 gEventArgs = (GEventArgs11)e.method_2().Tag;
			RectangleF clientRectangle = Parent.ClientRectangle;
			clientRectangle.Offset(Parent.AbsLocation);
			PointF[] array = new PointF[Points.Length];
			Point[] array2 = new Point[Points.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i].X = Points[i].X + clientRectangle.X;
				array[i].Y = Points[i].Y + clientRectangle.Y;
				array2[i] = gEventArgs.method_6().method_27(array[i]);
			}
			if (gEventArgs.method_0() == GEnum76.const_1)
			{
				int num = gEventArgs.method_4().method_12();
				array2[num] = e.method_5();
				if (num > 0)
				{
					gEventArgs.method_14().method_13(array2[num - 1], array2[num]);
				}
				if (num < array2.Length - 1)
				{
					gEventArgs.method_14().method_13(array2[num], array2[num + 1]);
				}
			}
			else if (gEventArgs.method_0() == GEnum76.const_2)
			{
				int dx = e.method_5().X - e.method_3().X;
				int dy = e.method_5().Y - e.method_3().Y;
				array2[0].Offset(dx, dy);
				for (int i = 1; i < array2.Length; i++)
				{
					array2[i].Offset(dx, dy);
					gEventArgs.method_14().method_13(array2[i - 1], array2[i]);
				}
			}
		}
	}
}
