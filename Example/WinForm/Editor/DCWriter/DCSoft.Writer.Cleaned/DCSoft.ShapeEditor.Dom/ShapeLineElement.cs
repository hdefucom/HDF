using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DCSoft.ShapeEditor.Dom
{
	/// <summary>
	///       线条元素
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[Serializable]
	[ComVisible(false)]
	public class ShapeLineElement : ShapeElement
	{
		private const int int_1 = 0;

		private const int int_2 = 1;

		private float float_0 = 0f;

		private float float_1 = 0f;

		private float float_2 = 0f;

		private float float_3 = 0f;

		/// <summary>
		///       起点X坐标
		///       </summary>
		[Category("Layout")]
		[DefaultValue(0f)]
		public float X1
		{
			get
			{
				return float_0;
			}
			set
			{
				float_0 = value;
			}
		}

		/// <summary>
		///       起点Y坐标
		///       </summary>
		[Category("Layout")]
		[DefaultValue(0f)]
		public float Y1
		{
			get
			{
				return float_1;
			}
			set
			{
				float_1 = value;
			}
		}

		/// <summary>
		///       终点X坐标
		///       </summary>
		[Category("Layout")]
		[DefaultValue(0f)]
		public float X2
		{
			get
			{
				return float_2;
			}
			set
			{
				float_2 = value;
			}
		}

		/// <summary>
		///       终点Y坐标
		///       </summary>
		[Category("Layout")]
		[DefaultValue(0f)]
		public float Y2
		{
			get
			{
				return float_3;
			}
			set
			{
				float_3 = value;
			}
		}

		/// <summary>
		///       获得或设置对象的边界
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		public override RectangleF Bounds
		{
			get
			{
				return new RectangleF(Math.Min(X1, X2), Math.Min(Y1, Y2), Math.Abs(X1 - X2), Math.Abs(Y1 - Y2));
			}
			set
			{
				if (X1 < X2)
				{
					X1 = value.Left;
					X2 = value.Right;
				}
				else
				{
					X1 = value.Right;
					X2 = value.Left;
				}
				if (Y1 < Y2)
				{
					Y1 = value.Top;
					Y2 = value.Bottom;
				}
				else
				{
					Y1 = value.Bottom;
					Y2 = value.Top;
				}
			}
		}

		protected PointF OffsetPositionForRender
		{
			get
			{
				PointF absLocation = AbsLocation;
				RectangleF bounds = Bounds;
				absLocation.X -= bounds.Left;
				absLocation.Y -= bounds.Top;
				return absLocation;
			}
		}

		[Browsable(false)]
		public override GClass330 vmethod_4()
		{
			float left = Bounds.Left;
			float top = Bounds.Top;
			GClass330 gClass = new GClass330();
			gClass.Add(new GClass329(X1 - left, Y1 - top, Cursors.Cross, 0));
			gClass.Add(new GClass329(X2 - left, Y2 - top, Cursors.Cross, 1));
			return gClass;
		}

		public override void vmethod_0(float float_4, float float_5)
		{
			X1 *= float_4;
			Y1 *= float_5;
			X2 *= float_4;
			Y2 *= float_5;
		}

		public override void vmethod_6(ShapeRenderEventArgs shapeRenderEventArgs_0)
		{
			PointF offsetPositionForRender = OffsetPositionForRender;
			shapeRenderEventArgs_0.Graphics.DrawLine(RuntimeStyle.BorderColor, RuntimeStyle.BorderWidth, RuntimeStyle.BorderStyle, offsetPositionForRender.X + X1, offsetPositionForRender.Y + Y1, offsetPositionForRender.X + X2, offsetPositionForRender.Y + Y2);
		}

		public override void vmethod_1(GClass328 gclass328_0)
		{
			float left = Bounds.Left;
			float top = Bounds.Top;
			double num = MathCommon.smethod_20(X1 - left, Y1 - top, X2 - left, Y2 - top, gclass328_0.method_4(), gclass328_0.method_6(), bool_0: true);
			if (num <= (double)OwnerDocument.Options.ViewOptions.RuntimeControlPointSize)
			{
				gclass328_0.method_9(GEnum73.const_2);
			}
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
					if (geventArgs11_0.method_4().method_12() == 0)
					{
						X1 = pointF.X;
						Y1 = pointF.Y;
					}
					else if (geventArgs11_0.method_4().method_12() == 1)
					{
						X2 = pointF.X;
						Y2 = pointF.Y;
					}
					vmethod_15();
				}
				else if (geventArgs11_0.method_0() == GEnum76.const_2)
				{
					SizeF sizeF = geventArgs11_0.method_6().method_25(geventArgs11_0.method_12().CurrentMoveSize);
					vmethod_15();
					X1 += sizeF.Width;
					X2 += sizeF.Width;
					Y1 += sizeF.Height;
					Y2 += sizeF.Height;
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
			RectangleF clientRectangle = Parent.ClientRectangle;
			clientRectangle.Offset(Parent.AbsLocation);
			PointF pointF_ = new PointF(X1 + clientRectangle.X, Y1 + clientRectangle.Y);
			PointF pointF_2 = new PointF(X2 + clientRectangle.Y, Y2 + clientRectangle.Y);
			GEventArgs11 gEventArgs = (GEventArgs11)e.method_2().Tag;
			Point point_ = gEventArgs.method_6().method_27(pointF_);
			Point point_2 = gEventArgs.method_6().method_27(pointF_2);
			if (gEventArgs.method_0() == GEnum76.const_1)
			{
				if (gEventArgs.method_4().method_12() == 0)
				{
					point_ = e.method_5();
				}
				else
				{
					point_2 = e.method_5();
				}
				gEventArgs.method_14().method_13(point_, point_2);
			}
			else if (gEventArgs.method_0() == GEnum76.const_2)
			{
				point_.Offset(e.method_5().X - e.method_3().X, e.method_5().Y - e.method_3().Y);
				point_2.Offset(e.method_5().X - e.method_3().X, e.method_5().Y - e.method_3().Y);
				gEventArgs.method_14().method_13(point_, point_2);
			}
		}
	}
}
